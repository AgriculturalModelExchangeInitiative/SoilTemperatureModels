# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Init Begin%%
def init_campbell(NLAYR: int,
    THICK: 'Array[float]',
    BD: 'Array[float]',
    TMAX: float,
    TMIN: float,
    TAV: float,
    TAMP: float,
    XLAT: float,
    CLAY: 'Array[float]',
    SW: 'Array[float]',
    DEPTH: 'Array[float]',
    DOY: int,
    canopyHeight: float,
    SALB: float,
    SRAD: float,
    ESP: float,
    EOAD: float,
    ESAD: float,
    soilTemp: 'Array[float]'):

    minSoilTemp : 'Array[float]' = []
    maxSoilTemp : 'Array[float]' = []
    aveSoilTemp : 'Array[float]' = []
    morningSoilTemp : 'Array[float]' = []
    tempNew : 'Array[float]' = []
    heatCapacity : 'Array[float]' = []
    thermalConductivity : 'Array[float]' = []
    thermalConductance : 'Array[float]' = []
    heatStorage : 'Array[float]' = []
    thickness : 'Array[float]' = []
    depth : 'Array[float]' = []
    bulkDensity : 'Array[float]' = []
    soilWater : 'Array[float]' = []
    clay : 'Array[float]' = []
    volSpecHeatSoil : 'Array[float]' = []
    thermCondPar1 : 'Array[float]' = []
    thermCondPar2 : 'Array[float]' = []
    thermCondPar3 : 'Array[float]' = []
    thermCondPar4 : 'Array[float]' = []
    InitialValues:'Array[float]' = []

    #Constants
    soilRoughnessHeight:float
    AltitudeMetres:float
    NUM_PHANTOM_NODES:int
    CONSTANT_TEMPdepth:float
    AIRnode:int
    SURFACEnode:int
    TOPSOILnode:int
    soilRoughnessHeight = 57.0
    AltitudeMetres = 18.0
    NUM_PHANTOM_NODES = 5
    CONSTANT_TEMPdepth = 10.0
    AIRnode = 0
    SURFACEnode = 1
    TOPSOILnode = 2
    
    airPressure:float
    sumThickness:float
    BelowProfileDepth:float
    thicknessForPhantomNodes:float
    ave_temp:float
    I:int
    numNodes:int
    firstPhantomNode:int
    layer:int
    node:int    
    surfaceT:float
    minTempYesterday:float
    maxTempYesterday:float

    canopyHeight = max(canopyHeight, soilRoughnessHeight) * 0.001
    airPressure = 101325.0 * (1.0 - 2.25577e-5 * AltitudeMetres) ** 5.25588 * 0.01
    numNodes = NLAYR + NUM_PHANTOM_NODES

    thickness = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    thickness[:len(THICK)] = THICK
    sumThickness = 0.0
    #sumThickness = sum(thickness[1:NLAYR + 1])
    for I in range(0, NLAYR, 1):
        sumThickness = sumThickness + thickness[I]
    BelowProfileDepth = max(CONSTANT_TEMPdepth * 1000.0 - sumThickness, 1.0 * 1000.0)
    thicknessForPhantomNodes = BelowProfileDepth * 2.0 / NUM_PHANTOM_NODES
    firstPhantomNode = NLAYR
    for I in range(firstPhantomNode, firstPhantomNode + NUM_PHANTOM_NODES):
        thickness[I] = thicknessForPhantomNodes

    depth = [0.0]*(numNodes + 1 + 1)
    depth[:min(numNodes + 1 + 1, len(DEPTH))] = DEPTH
    depth[AIRnode] = 0.0
    depth[SURFACEnode] = 0.0
    depth[TOPSOILnode] = 0.5 * thickness[1] * 0.001

    for node in range(TOPSOILnode, numNodes):
        sumThickness = 0.0
        for I in range(1, node):
            sumThickness = sumThickness + thickness[I]
        depth[node + 1] = (sumThickness + 0.5 * thickness[node]) * 0.001

     # Bulk Density
    bulkDensity = [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES)
    bulkDensity[:min(NLAYR + 1 + NUM_PHANTOM_NODES, len(BD))] = BD
    bulkDensity[numNodes - 1] = bulkDensity[NLAYR]
    for layer in range(NLAYR + 1, NLAYR + NUM_PHANTOM_NODES):
        bulkDensity[layer] = bulkDensity[NLAYR]

     # Soil Water
    soilWater = [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES)
    soilWater[:min(NLAYR + 1 + NUM_PHANTOM_NODES, len(SW))] = SW
    for layer in range(NLAYR + 1, NLAYR + NUM_PHANTOM_NODES):
        soilWater[layer] = soilWater[NLAYR]

     # Clay
    clay = [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1, NLAYR + 1):
        clay[layer] = CLAY[layer - 1]
    for layer in range(NLAYR + 1, NLAYR + NUM_PHANTOM_NODES):
        clay[layer] = clay[NLAYR]

    maxSoilTemp = [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES)
    minSoilTemp = [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES)
    aveSoilTemp = [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES)
    volSpecHeatSoil = [0.0]*(numNodes + 1)
    soilTemp = [0.0]*(numNodes + 1 + 1)
    morningSoilTemp = [0.0]*(numNodes + 1 + 1)
    tempNew = [0.0]*(numNodes + 1 + 1)
    thermalConductivity = [0.0]*(numNodes + 1)
    heatStorage = [0.0]*(numNodes + 1)
    thermalConductance = [0.0]*(numNodes + 1 + 1)

    thermCondPar1,thermCondPar2,thermCondPar3,thermCondPar4 = doThermalConductivityCoeffs(NLAYR, numNodes, bulkDensity, clay)
    soilTemp = CalcSoilTemp(soilTemp, thickness, TAV, TAMP, DOY, XLAT)

    InitialValues = [0.0]*(NLAYR)
    InitialValues[:NLAYR] = soilTemp[TOPSOILnode:]

    ave_temp = (TMAX + TMIN) * 0.5
    surfaceT = (1.0 - SALB) * (ave_temp + (TMAX - ave_temp) * sqrt(max(SRAD, 0.1) * 23.8846 / 800.0)) + SALB * ave_temp
    soilTemp[SURFACEnode] = surfaceT

    for I in range(numNodes + 1, len(soilTemp)):
        soilTemp[I] = TAV

    tempNew[:numNodes + 1 + 1] = soilTemp

    minTempYesterday = TMIN
    maxTempYesterday = TMAX

    return (soilTemp,
    minSoilTemp,
    maxSoilTemp,
    aveSoilTemp,
    morningSoilTemp,
    tempNew,
    heatCapacity,
    thermalConductivity,
    thermalConductance,
    heatStorage)
    #%%CyML Init End%%

#%%CyML Model Begin%%
def model_campbell(NLAYR: int,
    THICK: 'Array[float]',
    BD: 'Array[float]',
    TMAX: float,
    TMIN: float,
    TAV: float,
    TAMP: float,
    XLAT: float,
    CLAY: 'Array[float]',
    SW: 'Array[float]',
    DEPTH: 'Array[float]',
    DOY: float,
    canopyHeight: float,
    SALB: float,
    SRAD: float,
    ESP: float,
    EOAD: float,
    ESAD: float,
    soilTemp: 'Array[float]'):
    """
    - Name: campbell
    - Version: 1.0
    - Time step: 1
    - Description:
                * Title: SoilTemperature model from Campbell implemented in APSIM
                * Author: Teiki Raihauti and Christophe Pradal
                * Reference: Campbell model (TODO)
                * Institution: CIRAD and INRAE
                * ExtendedDescription: TODO
                * ShortDescription: TODO
    - inputs: 
         * name: NLAYR
               ** description : number of soil layers in profile
               ** inputtype : parameter
               ** variablecategory : constant
               ** datatype : INT
               ** max :
               ** min : 1
               ** default : 10
               ** unit : dimensionless
         * name: THICK
               ** description : APSIM soil layer depths as thickness of layers
               ** inputtype : parameter
               ** variablecategory : constant
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max :
               ** min : 1
               ** default : 5
               ** unit : mm 
        * name: BD
               ** description : bd (soil bulk density) is name of the APSIM var for bulk density so set bulkDensity = bd later
               ** inputtype : parameter
               ** variablecategory : constant
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max :
               ** min : 1
               ** default : 
               ** unit : g/cm3
        * name: TMAX
               ** description : Max daily Air temperature
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 60
               ** min : -60
               ** default :
               ** unit : °C
        * name: TMIN
               ** description : Min daily Air temperature
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 60
               ** min : -60
               ** default :
               ** unit : °C
        * name: TAV
               ** description : Average daily Air temperature
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 60
               ** min : -60
               ** default :
               ** unit : °C
        * name: TAMP
               ** description : Amplitude air temperature
               ** inputtype : parameter
               ** variablecategory : constant
               ** datatype : DOUBLE
               ** max : 100
               ** min : -100
               ** default :
               ** unit : °C
        * name: XLAT
               ** description : Latitude
               ** inputtype : parameter
               ** variablecategory : constant
               ** datatype : DOUBLE
               ** max : 
               ** min :
               ** default :
               ** unit : °C
        * name: CLAY
               ** description : Proportion of clay in each layer of profile
               ** inputtype : parameter
               ** variablecategory : constant
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max : 1
               ** min : 0
               ** default : 0.5
               ** unit : dimensionless
        * name: SW
               ** description : volumetric water content
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max : 1
               ** min : 0
               ** default : 0.5
               ** unit : cc water / cc soil
        * name: DEPTH
               ** description : node depths
               ** inputtype : parameter
               ** variablecategory : constant
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max :
               ** min : 
               ** default :
               ** unit : m
        * name: DOY
               ** description : Day of year
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 366
               ** min : 0
               ** default : 0
               ** unit : dimensionless
        * name: canopyHeight
               ** description : height of canopy above ground
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 
               ** min : 0
               ** default : 0.057
               ** unit : m
        * name: SALB
               ** description : Soil albedo
               ** inputtype : parameter
               ** variablecategory : constant
               ** datatype : DOUBLE
               ** max : 1
               ** min : 0
               ** default : 
               ** unit : dimensionless
        * name: SRAD
               ** description : Radiation
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 
               ** min : 
               ** default : 
               ** unit : 
        * name: ESP
               ** description : Potential evaporation
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 
               ** min : 0
               ** default : 
               ** unit : mm
        * name: EOAD
               ** description : Potential evapotranspiration
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 
               ** min : 0
               ** default : 
               ** unit : mm
        * name: ESAD
               ** description : Actual evapotranspiration
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 
               ** min : 0
               ** default : 
               ** unit : mm
         * name: soilTemp
               ** description :  Temperature at end of last time-step within a day - midnight in layers
               ** inputtype : variable
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** default : 20.
               ** min : -60.
               ** max : 60.
               ** unit : degC
               ** uri : 
    - outputs: 
        * name: soilTemp
                    ** description :  Temperature at end of last time-step within a day - midnight in layers
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : -60.
                    ** max : 60.
                    ** unit : degC
                    ** uri : 
        * name: minSoilTemp
                    ** description : Minimum soil temperature in layers
                    ** variablecategory : auxiliary
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : -60.
                    ** max : 60.
                    ** unit : degC
                    ** uri : 
        * name: maxSoilTemp
                    ** description :  Maximum soil temperature in layers
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : -60.
                    ** max : 60.
                    ** unit : degC
                    ** uri : 
        * name: aveSoilTemp
                    ** description : Temperature averaged over all time-steps within a day in layers.
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : -60.
                    ** max : 60.
                    ** unit : degC
                    ** uri : 
        * name: morningSoilTemp
                    ** description : Temperature  in the morning in layers.
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : -60.
                    ** max : 60.
                    ** unit : degC
                    ** uri : 
        * name: tempNew
                    ** description : Soil temperature at the end of one iteration
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : -60.
                    ** max : 60.
                    ** unit : degC
                    ** uri : 
        * name: heatCapacity
                    ** description : Heat Capacity in layers
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : 
                    ** max : 
                    ** unit : J/m3/K/s
                    ** uri : 
        * name: thermalConductivity
                    ** description : thermal conductivity in layers
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : 
                    ** max : 
                    ** unit : (W/m2/K)
                    ** uri : 
        * name: thermalConductance
                    ** description : Thermal conductance between layers 
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : 
                    ** max : 
                    ** unit : 
                    ** uri : 
        * name: heatStorage
                    ** description : Heat storage between layers (internal)
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : 
                    ** max : 
                    ** unit : J/s/K
                    ** uri : 
    """

    #%%CyML Compute Begin%%
    minSoilTemp : 'Array[float]' = []
    maxSoilTemp : 'Array[float]' = []
    aveSoilTemp : 'Array[float]' = []
    morningSoilTemp : 'Array[float]' = []
    tempNew : 'Array[float]' = []
    heatCapacity : 'Array[float]' = []
    thermalConductivity : 'Array[float]' = []
    thermalConductance : 'Array[float]' = []
    heatStorage : 'Array[float]' = []


    soilTemp = compute(soilTemp, NLAYR)
    #%%CyML Compute End%%
    
    return soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp, morningSoilTemp, tempNew, heatCapacity, thermalConductivity, thermalConductance, heatStorage
#%%CyML Model End%%
    

def compute(soilTemp: 'Array[float]', NLAYR: int):
    soilTemp2: 'Array[float]'=[]
    
    i : int
    for i in range(NLAYR):
        soilTemp2.append(float(i))

    return soilTemp2


def doThermalConductivityCoeffs(nbLayers:int, 
                                numNodes:int,
                                bulkDensity: 'Array[float]',
                                clay: 'Array[float]'):

    thermCondPar1 : 'Array[float]' = []
    thermCondPar2 : 'Array[float]' = []
    thermCondPar3 : 'Array[float]' = []
    thermCondPar4 : 'Array[float]' = []
    layer:int
    element:int

    thermCondPar1 = [0.0]*(numNodes + 1)
    thermCondPar2 = [0.0]*(numNodes + 1)
    thermCondPar3 = [0.0]*(numNodes + 1)
    thermCondPar4 = [0.0]*(numNodes + 1)

    for layer in range(1, nbLayers + 2):
         element = layer
         thermCondPar1[element] = 0.65 - 0.78 * bulkDensity[layer] + 0.6 * bulkDensity[layer] ** 2
         thermCondPar2[element] = 1.06 * bulkDensity[layer]
         thermCondPar3[element] = Divide(2.6, sqrt(clay[layer]), 0.0)
         thermCondPar3[element] = 1.0 + thermCondPar3[element]
         thermCondPar4[element] = 0.03 + 0.1 * bulkDensity[layer] ** 2

    return (thermCondPar1,thermCondPar2,thermCondPar3,thermCondPar4)


def Divide(val1:float, 
           val2:float, 
           errVal:float):

    returnValue:float = errVal
    if val2 != 0.0:
        returnValue = val1 / val2

    return returnValue


def CalcSoilTemp(soilTempIO: 'Array[float]',
                 thickness: 'Array[float]',
                tav:float,
                tamp:float, 
                doy:int, 
                latitude:float):

    cumulativeDepth: 'Array[float]'
    soilTemp: 'Array[float]'
    Layer:int
    nodes:int
    tempValue:float
    w:float
    pi:float
    dh:float
    zd:float 
    offset:float

    cumulativeDepth = [0.0]*len(thickness)
    if len(thickness) > 0:
        cumulativeDepth[0] = thickness[0]
        for Layer in range(1, len(thickness)):
            cumulativeDepth[Layer] = thickness[Layer] + cumulativeDepth[Layer - 1]

    pi = 3.141592653589793
    w = pi
    w = 2 * w
    w = w / (365.25 * 24.0 * 3600.0)
    dh = 0.6
    zd = sqrt(2 * dh / w)
    offset = 0.25
    if latitude > 0.0:
        offset = -0.25

    soilTemp = [0.0]*(numNodes + 2)
    for nodes in range(1, numNodes + 1):
        soilTemp[nodes] = tav + tamp 
        soilTemp[nodes] = soilTemp[nodes] * exp(-1 * cumulativeDepth[nodes] / zd) 
        tempValue = pi
        tempValue = 2.0 * tempValue - cumulativeDepth[nodes] / zd
        soilTemp[nodes] = soilTemp[nodes] * sin((doy / 365.0 + offset) * tempValue)

    soilTempIO[SURFACEnode:SURFACEnode + numNodes] = soilTemp[0:numNodes]
    return soilTempIO