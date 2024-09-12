# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Init Begin%%
def init_campbell(NLAYR:int,
         CONSTANT_TEMPdepth:float,
         THICK:'Array[float]',
         DEPTH:'Array[float]',
         BD:'Array[float]',
         T2M:float,
         TMAX:float,
         TMIN:float,
         TAV:float,
         TAMP:float,
         XLAT:float,
         CLAY:'Array[float]',
         SW:'Array[float]',
         DOY:int,
         canopyHeight:float,
         SALB:float,
         SRAD:float,
         ESP:float,
         ES:float,
         EOAD:float,
         instrumentHeight:float,
         boundaryLayerConductanceSource:str,
         netRadiationSource:str,
         windSpeed:float):
    airPressure:float = 1010.0
    soilTemp:'array[float]' = array('f',[0.0]*NLAYR)
    newTemperature:'array[float]' = array('f',[0.0]*NLAYR)
    minSoilTemp:'array[float]' = array('f',[0.0]*NLAYR)
    maxSoilTemp:'array[float]' = array('f',[0.0]*NLAYR)
    aveSoilTemp:'array[float]' = array('f',[0.0]*NLAYR)
    morningSoilTemp:'array[float]' = array('f',[0.0]*NLAYR)
    thermalCondPar1:'array[float]' = array('f',[0.0]*NLAYR)
    thermalCondPar2:'array[float]' = array('f',[0.0]*NLAYR)
    thermalCondPar3:'array[float]' = array('f',[0.0]*NLAYR)
    thermalCondPar4:'array[float]' = array('f',[0.0]*NLAYR)
    thermalConductivity:'array[float]' = array('f',[0.0]*NLAYR)
    thermalConductance:'array[float]' = array('f',[0.0]*NLAYR)
    heatStorage:'array[float]' = array('f',[0.0]*NLAYR)
    volSpecHeatSoil:'array[float]' = array('f',[0.0]*NLAYR)
    maxTempYesterday:float
    minTempYesterday:float
    SLCARB:'array[float]' = array('f',[0.0]*NLAYR)
    SLROCK:'array[float]' = array('f',[0.0]*NLAYR)
    SLSILT:'array[float]' = array('f',[0.0]*NLAYR)
    SLSAND:'array[float]' = array('f',[0.0]*NLAYR)
    _boundaryLayerConductance:float
    soilTemp = array('f', [0.0]*NLAYR)
    newTemperature = array('f', [0.0]*NLAYR)
    minSoilTemp = array('f', [0.0]*NLAYR)
    maxSoilTemp = array('f', [0.0]*NLAYR)
    aveSoilTemp = array('f', [0.0]*NLAYR)
    morningSoilTemp = array('f', [0.0]*NLAYR)
    thermalCondPar1 = array('f', [0.0]*NLAYR)
    thermalCondPar2 = array('f', [0.0]*NLAYR)
    thermalCondPar3 = array('f', [0.0]*NLAYR)
    thermalCondPar4 = array('f', [0.0]*NLAYR)
    thermalConductivity = array('f', [0.0]*NLAYR)
    thermalConductance = array('f', [0.0]*NLAYR)
    heatStorage = array('f', [0.0]*NLAYR)
    volSpecHeatSoil = array('f', [0.0]*NLAYR)
    maxTempYesterday = 0.0
    minTempYesterday = 0.0
    SLCARB = array('f', [0.0]*NLAYR)
    SLROCK = array('f', [0.0]*NLAYR)
    SLSILT = array('f', [0.0]*NLAYR)
    SLSAND = array('f', [0.0]*NLAYR)
    _boundaryLayerConductance = 0.0
    heatCapacity:'array[float]'
    thickness:'array[float]'
    depth:'array[float]'
    bulkDensity:'array[float]'
    soilWater:'array[float]'
    clay:'array[float]'
    carbon:'array[float]'
    rocks:'array[float]'
    sand:'array[float]'
    silt:'array[float]'
    soilRoughnessHeight:float
    defaultInstrumentHeight:float
    AltitudeMetres:float
    NUM_PHANTOM_NODES:int
    AIRnode:int
    SURFACEnode:int
    TOPSOILnode:int
    sumThickness:float
    BelowProfileDepth:float
    thicknessForPhantomNodes:float
    ave_temp:float
    i:int
    numNodes:int
    firstPhantomNode:int
    layer:int
    node:int
    surfaceT:float
    soilRoughnessHeight = 57.0
    defaultInstrumentHeight = 1.2
    AltitudeMetres = 18.0
    NUM_PHANTOM_NODES = 5
    AIRnode = 0
    SURFACEnode = 1
    TOPSOILnode = 2
    if instrumentHeight > 0.00001:
        instrumentHeight = instrumentHeight
    else:
        instrumentHeight = defaultInstrumentHeight
    numNodes = NLAYR + NUM_PHANTOM_NODES
    thickness = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    thickness[1:len(THICK)] = THICK
    sumThickness = 0.0
    for i in range(1 , NLAYR + 1 , 1):
        sumThickness = sumThickness + thickness[i]
    BelowProfileDepth = max(CONSTANT_TEMPdepth - sumThickness, 1000.0)
    thicknessForPhantomNodes = BelowProfileDepth * 2.0 / NUM_PHANTOM_NODES
    firstPhantomNode = NLAYR
    for i in range(firstPhantomNode , firstPhantomNode + NUM_PHANTOM_NODES , 1):
        thickness[i] = thicknessForPhantomNodes
    depth = [0.0] * (numNodes + 1 + 1)
    depth[AIRnode] = 0.0
    depth[SURFACEnode] = 0.0
    depth[TOPSOILnode] = 0.5 * thickness[1] / 1000.0
    for node in range(TOPSOILnode , numNodes + 1 , 1):
        sumThickness = 0.0
        for i in range(1 , node , 1):
            sumThickness = sumThickness + thickness[i]
        depth[node + 1] = (sumThickness + (0.5 * thickness[node])) / 1000.0
    bulkDensity = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    bulkDensity[:min(NLAYR + 1 + NUM_PHANTOM_NODES, len(BD))] = BD
    for layer in range(1 , NLAYR + 1 , 1):
        bulkDensity[layer] = BD[layer - 1]
    bulkDensity[numNodes] = bulkDensity[NLAYR]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
        bulkDensity[layer] = bulkDensity[NLAYR]
    soilWater = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    soilWater[:min(NLAYR + 1 + NUM_PHANTOM_NODES, len(SW))] = SW
    for layer in range(1 , NLAYR + 1 , 1):
        soilWater[layer] = SW[layer - 1]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
        soilWater[layer] = soilWater[NLAYR]
    carbon = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1 , NLAYR + 1 , 1):
        carbon[layer] = SLCARB[layer - 1]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
        carbon[layer] = carbon[NLAYR]
    rocks = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1 , NLAYR + 1 , 1):
        rocks[layer] = SLROCK[layer - 1]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
        rocks[layer] = rocks[NLAYR]
    sand = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1 , NLAYR + 1 , 1):
        sand[layer] = SLSAND[layer - 1]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
        sand[layer] = sand[NLAYR]
    silt = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1 , NLAYR + 1 , 1):
        silt[layer] = SLSILT[layer - 1]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
        silt[layer] = silt[NLAYR]
    clay = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1 , NLAYR + 1 , 1):
        clay[layer] = CLAY[layer - 1]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
        clay[layer] = clay[NLAYR]
    maxSoilTemp = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    minSoilTemp = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    aveSoilTemp = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    volSpecHeatSoil = [0.0] * (numNodes + 1)
    soilTemp = [0.0] * (numNodes + 1 + 1)
    morningSoilTemp = [0.0] * (numNodes + 1 + 1)
    newTemperature = [0.0] * (numNodes + 1 + 1)
    thermalConductivity = [0.0] * (numNodes + 1)
    heatStorage = [0.0] * (numNodes + 1)
    thermalConductance = [0.0] * (numNodes + 1 + 1)
    (thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4) = doThermalConductivityCoeffs(NLAYR, numNodes, bulkDensity, clay)
    newTemperature = CalcSoilTemp(soilTemp, thickness, TAV, TAMP, DOY, XLAT, numNodes)
    soilWater[numNodes] = soilWater[NLAYR]
    instrumentHeight = max(instrumentHeight, canopyHeight + 0.5)
    soilTemp = CalcSoilTemp(soilTemp, thickness, TAV, TAMP, DOY, XLAT, numNodes)
    soilTemp[AIRnode] = T2M
    surfaceT = (1.0 - SALB) * (T2M + ((TMAX - T2M) * sqrt(max(SRAD, 0.1) * 23.8846 / 800.0))) + (SALB * T2M)
    soilTemp[SURFACEnode] = surfaceT
    for i in range(numNodes + 1 , len(soilTemp) , 1):
        soilTemp[i] = TAV
    newTemperature[] = soilTemp
    maxTempYesterday = TMAX
    minTempYesterday = TMIN
    return (airPressure, soilTemp, newTemperature, minSoilTemp, maxSoilTemp, aveSoilTemp, morningSoilTemp, thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, thermalConductivity, thermalConductance, heatStorage, volSpecHeatSoil, maxTempYesterday, minTempYesterday, SLCARB, SLROCK, SLSILT, SLSAND, _boundaryLayerConductance)
#%%CyML Init End%%

#%%CyML Model Begin%%
def model_campbell(NLAYR:int,
         CONSTANT_TEMPdepth:float,
         THICK:'Array[float]',
         DEPTH:'Array[float]',
         BD:'Array[float]',
         T2M:float,
         TMAX:float,
         TMIN:float,
         TAV:float,
         TAMP:float,
         XLAT:float,
         CLAY:'Array[float]',
         SW:'Array[float]',
         DOY:int,
         airPressure:float,
         canopyHeight:float,
         SALB:float,
         SRAD:float,
         ESP:float,
         ES:float,
         EOAD:float,
         soilTemp:'Array[float]',
         newTemperature:'Array[float]',
         minSoilTemp:'Array[float]',
         maxSoilTemp:'Array[float]',
         aveSoilTemp:'Array[float]',
         morningSoilTemp:'Array[float]',
         thermalCondPar1:'Array[float]',
         thermalCondPar2:'Array[float]',
         thermalCondPar3:'Array[float]',
         thermalCondPar4:'Array[float]',
         thermalConductivity:'Array[float]',
         thermalConductance:'Array[float]',
         heatStorage:'Array[float]',
         volSpecHeatSoil:'Array[float]',
         maxTempYesterday:float,
         minTempYesterday:float,
         instrumentHeight:float,
         boundaryLayerConductanceSource:str,
         netRadiationSource:str,
         windSpeed:float,
         SLCARB:'Array[float]',
         SLROCK:'Array[float]',
         SLSILT:'Array[float]',
         SLSAND:'Array[float]',
         _boundaryLayerConductance:float):
    """
     - Name: campbell -Version: 1.0, -Time step: 1
     - Description:
                 * Title: SoilTemperature model from Campbell implemented in APSIM
                 * Authors: None
                 * Reference: Campbell model (TODO)
                 * Institution: CIRAD and INRAE
                 * ExtendedDescription: TODO
                 * ShortDescription: TODO
     - inputs:
                 * name: NLAYR
                               ** description : number of soil layers in profile
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 
                               ** min : 1
                               ** default : 10
                               ** unit : dimensionless
                 * name: CONSTANT_TEMPdepth
                               ** description : Depth of constant temperature
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 1000.0
                               ** unit : mm
                 * name: THICK
                               ** description : APSIM soil layer depths as thickness of layers
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 
                               ** min : 1
                               ** default : 50
                               ** unit : mm
                 * name: DEPTH
                               ** description : APSIM node depths
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : m
                 * name: BD
                               ** description : bd (soil bulk density) is name of the APSIM var for bulk density so set bulkDensity
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** default : 1.4
                               ** unit : g/cm3
                 * name: T2M
                               ** description : Mean daily Air temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 60
                               ** min : -60
                               ** default : 
                               ** unit : 
                 * name: TMAX
                               ** description : Max daily Air temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 60
                               ** min : -60
                               ** default : 
                               ** unit : 
                 * name: TMIN
                               ** description : Min daily Air temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 60
                               ** min : -60
                               ** default : 
                               ** unit : 
                 * name: TAV
                               ** description : Average daily Air temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 60
                               ** min : -60
                               ** default : 
                               ** unit : 
                 * name: TAMP
                               ** description : Amplitude air temperature
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 100
                               ** min : -100
                               ** default : 
                               ** unit : 
                 * name: XLAT
                               ** description : Latitude
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : 
                 * name: CLAY
                               ** description : Proportion of clay in each layer of profile
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 100
                               ** min : 0
                               ** default : 50
                               ** unit : 
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
                 * name: DOY
                               ** description : Day of year
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : INT
                               ** max : 366
                               ** min : 1
                               ** default : 1
                               ** unit : dimensionless
                 * name: airPressure
                               ** description : Air pressure
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 1010
                               ** unit : hPA
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
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 
                               ** unit : dimensionless
                 * name: SRAD
                               ** description : Solar radiation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 
                               ** unit : MJ/m2
                 * name: ESP
                               ** description : Potential evaporation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 
                               ** unit : mm
                 * name: ES
                               ** description : Actual evaporation
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
                 * name: soilTemp
                               ** description : Temperature at end of last time-step within a day - midnight in layers
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 60.
                               ** min : -60.
                               ** default : 
                               ** unit : degC
                 * name: newTemperature
                               ** description : Soil temperature at the end of one iteration
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 60.
                               ** min : -60.
                               ** default : 
                               ** unit : degC
                 * name: minSoilTemp
                               ** description : Minimum soil temperature in layers
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 60.
                               ** min : -60.
                               ** default : 
                               ** unit : degC
                 * name: maxSoilTemp
                               ** description : Maximum soil temperature in layers
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 60.
                               ** min : -60.
                               ** default : 
                               ** unit : degC
                 * name: aveSoilTemp
                               ** description : Temperature averaged over all time-steps within a day in layers.
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 60.
                               ** min : -60.
                               ** default : 
                               ** unit : degC
                 * name: morningSoilTemp
                               ** description : Temperature  in the morning in layers.
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 60.
                               ** min : -60.
                               ** default : 
                               ** unit : degC
                 * name: thermalCondPar1
                               ** description : thermal conductivity coeff in layers
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : (W/m2/K)
                 * name: thermalCondPar2
                               ** description : thermal conductivity coeff in layers
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : (W/m2/K)
                 * name: thermalCondPar3
                               ** description : thermal conductivity coeff in layers
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : (W/m2/K)
                 * name: thermalCondPar4
                               ** description : thermal conductivity coeff in layers
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : (W/m2/K)
                 * name: thermalConductivity
                               ** description : thermal conductivity in layers
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : (W/m2/K)
                 * name: thermalConductance
                               ** description : Thermal conductance between layers
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : (W/m2/K)
                 * name: heatStorage
                               ** description : Heat storage between layers (internal)
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : J/s/K
                 * name: volSpecHeatSoil
                               ** description : Volumetric specific heat over the soil profile
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : J/K/m3
                 * name: maxTempYesterday
                               ** description : Air max temperature from previous day
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 60
                               ** min : -60
                               ** default : 
                               ** unit : 
                 * name: minTempYesterday
                               ** description : Air min temperature from previous day
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 60
                               ** min : -60
                               ** default : 
                               ** unit : 
                 * name: instrumentHeight
                               ** description : Default instrument height
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0
                               ** default : 1.2
                               ** unit : m
                 * name: boundaryLayerConductanceSource
                               ** description : Flag whether boundary layer conductance is calculated or gotten from input
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : STRING
                               ** max : 
                               ** min : 
                               ** default : calc
                               ** unit : dimensionless
                 * name: netRadiationSource
                               ** description : Flag whether net radiation is calculated or gotten from input
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : STRING
                               ** max : 
                               ** min : 
                               ** default : calc
                               ** unit : dimensionless
                 * name: windSpeed
                               ** description : Speed of wind
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0.0
                               ** default : 3.0
                               ** unit : m/s
                 * name: SLCARB
                               ** description : Volumetric fraction of organic matter in the soil
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : 
                 * name: SLROCK
                               ** description : Volumetric fraction of rocks in the soil
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : 
                 * name: SLSILT
                               ** description : Volumetric fraction of silt in the soil
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : 
                 * name: SLSAND
                               ** description : Volumetric fraction of sand in the soil
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : 
                 * name: _boundaryLayerConductance
                               ** description : Boundary layer conductance
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : K/W
     - outputs:
                 * name: soilTemp
                               ** description : Temperature at end of last time-step within a day - midnight in layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 60.
                               ** min : -60.
                               ** unit : degC
                 * name: newTemperature
                               ** description : Soil temperature at the end of one iteration
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 60.
                               ** min : -60.
                               ** unit : degC
                 * name: minSoilTemp
                               ** description : Minimum soil temperature in layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 60.
                               ** min : -60.
                               ** unit : degC
                 * name: maxSoilTemp
                               ** description : Maximum soil temperature in layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 60.
                               ** min : -60.
                               ** unit : degC
                 * name: aveSoilTemp
                               ** description : Temperature averaged over all time-steps within a day in layers.
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 60.
                               ** min : -60.
                               ** unit : degC
                 * name: morningSoilTemp
                               ** description : Temperature  in the morning in layers.
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 60.
                               ** min : -60.
                               ** unit : degC
                 * name: airPressure
                               ** description : Air pressure
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : hPA
                 * name: thermalCondPar1
                               ** description : thermal conductivity coeff in layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** unit : (W/m2/K)
                 * name: thermalCondPar2
                               ** description : thermal conductivity coeff in layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** unit : (W/m2/K)
                 * name: thermalCondPar3
                               ** description : thermal conductivity coeff in layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** unit : (W/m2/K)
                 * name: thermalCondPar4
                               ** description : thermal conductivity coeff in layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** unit : (W/m2/K)
                 * name: thermalConductivity
                               ** description : thermal conductivity in layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** unit : (W/m2/K)
                 * name: thermalConductance
                               ** description : Thermal conductance between layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** unit : (W/m2/K)
                 * name: heatStorage
                               ** description : Heat storage between layers (internal)
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** unit : J/s/K
                 * name: volSpecHeatSoil
                               ** description : Volumetric specific heat over the soil profile
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** unit : J/K/m3
                 * name: maxTempYesterday
                               ** description : Air max temperature from previous day
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 60
                               ** min : -60
                               ** unit : 
                 * name: minTempYesterday
                               ** description : Air min temperature from previous day
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 60
                               ** min : -60
                               ** unit : 
                 * name: SLCARB
                               ** description : Volumetric fraction of organic matter in the soil
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** unit : 
                 * name: SLROCK
                               ** description : Volumetric fraction of rocks in the soil
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** unit : 
                 * name: SLSILT
                               ** description : Volumetric fraction of silt in the soil
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** unit : 
                 * name: SLSAND
                               ** description : Volumetric fraction of sand in the soil
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NLAYR
                               ** max : 
                               ** min : 
                               ** unit : 
                 * name: _boundaryLayerConductance
                               ** description : Boundary layer conductance
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : K/W
    """

    AIRnode:int
    SURFACEnode:int
    TOPSOILnode:int
    ITERATIONSperDAY:int
    NUM_PHANTOM_NODES:int
    DAYhrs:float
    MIN2SEC:float
    HR2MIN:float
    SEC2HR:float
    DAYmins:float
    DAYsecs:float
    PA2HPA:float
    MJ2J:float
    J2MJ:float
    tempStepSec:float
    BoundaryLayerConductanceIterations:int
    numNodes:int
    soilConstituentNames:'array[str]'
    timeStepIteration:int
    netRadiation:float
    constantBoundaryLayerConductance:float
    precision:float
    cva:float
    cloudFr:float
    solarRadn:'array[float]'
    layer:int
    timeOfDaySecs:float
    airTemperature:float
    iteration:int
    tMean:float
    internalTimeStep:float
    soilWater:'array[float]'
    copyLength:int
    AIRnode = 0
    SURFACEnode = 1
    TOPSOILnode = 2
    ITERATIONSperDAY = 48
    NUM_PHANTOM_NODES = 5
    DAYhrs = 24.0
    MIN2SEC = 60.0
    HR2MIN = 60.0
    SEC2HR = 1.0 / (HR2MIN * MIN2SEC)
    DAYmins = DAYhrs * HR2MIN
    DAYsecs = DAYmins * MIN2SEC
    PA2HPA = 1.0 / 100.0
    MJ2J = 1000000.0
    J2MJ = 1.0 / MJ2J
    tempStepSec = 24.0 * 60.0 * 60.0
    BoundaryLayerConductanceIterations = 1
    numNodes = NLAYR + NUM_PHANTOM_NODES
    soilConstituentNames = ["'Rocks'", "'OrganicMatter'", "'Sand'", "'Silt'", "'Clay'", "'Water'", "'Ice'", "'Air'"]
    timeStepIteration = 1
    constantBoundaryLayerConductance = 20.0
    layer = 0
    cva = 0.0
    cloudFr = 0.0
    solarRadn = [0.0] * 49
    (solarRadn, cloudFr, cva) = doNetRadiation(solarRadn, cloudFr, cva, ITERATIONSperDAY, DOY, SRAD, TMIN, XLAT)
    minSoilTemp = Zero(minSoilTemp)
    maxSoilTemp = Zero(maxSoilTemp)
    aveSoilTemp = Zero(aveSoilTemp)
    _boundaryLayerConductance = 0.0
    internalTimeStep = tempStepSec / float(ITERATIONSperDAY)
    soilWater = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    copyLength = min(NLAYR + 1 + NUM_PHANTOM_NODES, len(SW))
    soilWater[:copyLength] = SW[:copyLength]
    volSpecHeatSoil = doVolumetricSpecificHeat(volSpecHeatSoil, soilWater, numNodes, soilConstituentNames, THICK, DEPTH)
    thermalConductivity = doThermConductivity(soilWater, SLCARB, SLROCK, SLSAND, SLSILT, CLAY, BD, thermalConductivity, THICK, DEPTH, numNodes, soilConstituentNames)
    for timeStepIteration in range(1 , ITERATIONSperDAY + 1 , 1):
        timeOfDaySecs = internalTimeStep * float(timeStepIteration)
        if tempStepSec < (24.0 * 60.0 * 60.0):
            tMean = T2M
        else:
            tMean = InterpTemp(timeOfDaySecs * SEC2HR, TMAX, TMIN, T2M, maxTempYesterday, minTempYesterday)
        newTemperature[AIRnode] = tMean
        netRadiation = RadnNetInterpolate(internalTimeStep, solarRadn[timeStepIteration], cloudFr, cva, ESP, ES, tMean, SALB, soilTemp)
        if boundaryLayerConductanceSource == "'constant'":
            thermalConductivity[AIRnode] = constantBoundaryLayerConductance
        elif boundaryLayerConductanceSource == "'calc'":
            thermalConductivity[AIRnode] = boundaryLayerConductanceF(newTemperature, T2M, ESP, ES, airPressure, canopyHeight, windSpeed, instrumentHeight)
            for iteration in range(1 , BoundaryLayerConductanceIterations + 1 , 1):
                newTemperature = doThomas(newTemperature, soilTemp, thermalConductivity, thermalConductance, DEPTH, volSpecHeatSoil, internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource)
        newTemperature = doThomas(newTemperature, soilTemp, thermalConductivity, thermalConductance, DEPTH, volSpecHeatSoil, internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource)
        (soilTemp, _boundaryLayerConductance) = doUpdate(newTemperature, soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp, thermalConductivity, _boundaryLayerConductance, ITERATIONSperDAY, timeOfDaySecs, internalTimeStep, numNodes)
        precision = min(timeOfDaySecs, 5.0 * 3600.0) * 0.0001
        if abs(timeOfDaySecs - (5.0 * 3600.0)) <= precision:
            morningSoilTemp[] = soilTemp[]
    minTempYesterday = TMIN
    maxTempYesterday = TMAX
    return (soilTemp, newTemperature, minSoilTemp, maxSoilTemp, aveSoilTemp, morningSoilTemp, airPressure, thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, thermalConductivity, thermalConductance, heatStorage, volSpecHeatSoil, maxTempYesterday, minTempYesterday, SLCARB, SLROCK, SLSILT, SLSAND, _boundaryLayerConductance)
#%%CyML Model End%%

def doNetRadiation(solarRadn:'Array[float]',
         cloudFr:float,
         cva:float,
         ITERATIONSperDAY:int,
         doy:int,
         rad:float,
         tmin:float,
         latitude:float):
    pi:float = 3.14
    TSTEPS2RAD:float = Divide(2.0 * pi, float(ITERATIONSperDAY), 0.0)
    SOLARconst:float = 1360.0
    solarDeclination:float = 0.3985 * sin((4.869 + (doy * 2.0 * pi / 365.25) + (0.03345 * sin((6.224 + (doy * 2.0 * pi / 365.25))))))
    cD:float = sqrt(1.0 - (solarDeclination * solarDeclination))
    m1:'array[float]'
    m1Tot:float = 0.0
    psr:float
    timestepNumber:int = 1
    fr:float
    for timestepNumber in range(1 , ITERATIONSperDAY + 1 , 1):
        m1[timestepNumber] = (solarDeclination * sin(latitude * pi / 180.0) + (cD * cos(latitude * pi / 180.0) * cos(TSTEPS2RAD * (float(timestepNumber) - (float(ITERATIONSperDAY) / 2.0))))) * 24.0 / float(ITERATIONSperDAY)
        if m1[timestepNumber] > 0.0:
            m1Tot = m1Tot + m1[timestepNumber]
        else:
            m1[timestepNumber] = 0.0
    psr = m1Tot * SOLARconst * 3600.0 / 1000000.0
    fr = Divide(max(rad, 0.1), psr, 0.0)
    cloudFr = 2.33 - (3.33 * fr)
    cloudFr = min(max(cloudFr, 0.0), 1.0)
    for timestepNumber in range(1 , ITERATIONSperDAY + 1 , 1):
        solarRadn[timestepNumber] = max(rad, 0.1) * Divide(m1[timestepNumber], m1Tot, 0.0)
    kelvinTemp:float = kelvinT(tmin)
    cva = exp((31.3716 - (6014.79 / kelvinTemp) - (0.00792495 * kelvinTemp))) / kelvinTemp
    return (solarRadn, cloudFr, cva)

def Divide(val1:float,
         val2:float,
         errVal:float):
    returnValue:float = errVal
    if val2 != 0.0:
        returnValue = val1 / val2
    return returnValue

def kelvinT(celciusT:float):
    ZEROTkelvin:float = 273.18
    res:float = celciusT + ZEROTkelvin
    return res

def Zero(arr:'Array[float]'):
    i:int = 0
    for i in range(0 , len(arr) , 1):
        arr[i] = 0.
    return arr

def doVolumetricSpecificHeat(volSpecLayer:'Array[float]',
         soilW:'Array[float]',
         numNodes:int,
         constituents:'Array[str]',
         thickness:'Array[float]',
         depth:'Array[float]'):
    volSpecHeatSoil:'array[float]'
    node:int
    constituent:int
    for node in range(1 , numNodes + 1 , 1):
        volSpecHeatSoil[node] = 0.0
        for constituent in range(0 , len(constituents) , 1):
            volSpecHeatSoil[node] = volSpecHeatSoil[node] + (volumetricSpecificHeat(constituents[constituent]) * 1000000.0 * soilW[node])
    volSpecLayer = mapLayer2Node(volSpecHeatSoil, volSpecLayer, thickness, depth, numNodes)
    return volSpecLayer

def volumetricSpecificHeat(name:str):
    specificHeatRocks:float = 7.7
    specificHeatOM:float = 0.25
    specificHeatSand:float = 7.7
    specificHeatSilt:float = 2.74
    specificHeatClay:float = 2.92
    specificHeatWater:float = 0.57
    specificHeatIce:float = 2.18
    specificHeatAir:float = 0.025
    res:float = 0.0
    if name == "'Rocks'":
        res = specificHeatRocks
    elif name == "'OrganicMatter'":
        res = specificHeatOM
    elif name == "'Sand'":
        res = specificHeatSand
    elif name == "'Silt'":
        res = specificHeatSilt
    elif name == "'Clay'":
        res = specificHeatClay
    elif name == "'Water'":
        res = specificHeatWater
    elif name == "'Ice'":
        res = specificHeatIce
    elif name == "'Air'":
        res = specificHeatAir
    return res

def mapLayer2Node(layerArray:'Array[float]',
         nodeArray:'Array[float]',
         thickness:'Array[float]',
         depth:'Array[float]',
         numNodes:int):
    SURFACEnode:int = 1
    depthLayerAbove:float
    node:int = 0
    i:int = 0
    layer:int
    d1:float
    d2:float
    dSum:float
    for node in range(SURFACEnode , numNodes + 1 , 1):
        layer = node - 1
        depthLayerAbove = 0.0
        if layer >= 1:
            for i in range(1 , layer + 1 , 1):
                depthLayerAbove = depthLayerAbove + thickness[i]
        d1 = depthLayerAbove - (depth[node] * 1000.0)
        d2 = depth[(node + 1)] * 1000.0 - depthLayerAbove
        dSum = d1 + d2
        nodeArray[node] = Divide(layerArray[layer] * d1, dSum, 0.0) + Divide(layerArray[(layer + 1)] * d2, dSum, 0.0)
    return nodeArray

def doThermConductivity(soilW:'Array[float]',
         carbon:'Array[float]',
         rocks:'Array[float]',
         sand:'Array[float]',
         silt:'Array[float]',
         clay:'Array[float]',
         bulkDensity:'Array[float]',
         thermalConductivity:'Array[float]',
         thickness:'Array[float]',
         depth:'Array[float]',
         numNodes:int,
         constituents:'Array[str]'):
    thermCondLayers:'array[float]'
    node:int = 1
    constituent:int = 1
    temp:float
    numerator:float
    denominator:float
    shapeFactorConstituent:float
    thermalConductanceConstituent:float
    thermalConductanceWater:float
    k:float
    for node in range(1 , numNodes + 1 , 1):
        numerator = 0.0
        denominator = 0.0
        for constituent in range(0 , len(constituents) , 1):
            shapeFactorConstituent = shapeFactor(constituents[constituent], rocks, carbon, sand, silt, clay, soilW, bulkDensity, node)
            thermalConductanceConstituent = ThermalConductance(constituents[constituent])
            thermalConductanceWater = ThermalConductance("'Water'")
            k = 2.0 / 3.0 * pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0))), -1) + (1.0 / 3.0 * pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0) * (1.0 - (2.0 * shapeFactorConstituent)))), -1))
            numerator = numerator + (thermalConductanceConstituent * soilW[node] * k)
            denominator = denominator + (soilW[node] * k)
        thermCondLayers[node] = numerator / denominator
    thermalConductivity = mapLayer2Node(thermCondLayers, thermalConductivity, thickness, depth, numNodes)
    return thermalConductivity

def shapeFactor(name:str,
         rocks:'Array[float]',
         carbon:'Array[float]',
         sand:'Array[float]',
         silt:'Array[float]',
         clay:'Array[float]',
         soilWater:'Array[float]',
         bulkDensity:'Array[float]',
         layer:int):
    shapeFactorRocks:float = 0.182
    shapeFactorOM:float = 0.5
    shapeFactorSand:float = 0.182
    shapeFactorSilt:float = 0.125
    shapeFactorClay:float = 0.007755
    shapeFactorWater:float = 1.0
    result:float = 0.0
    if name == "'Rocks'":
        result = shapeFactorRocks
    elif name == "'OrganicMatter'":
        result = shapeFactorOM
    elif name == "'Sand'":
        result = shapeFactorSand
    elif name == "'Silt'":
        result = shapeFactorSilt
    elif name == "'Clay'":
        result = shapeFactorClay
    elif name == "'Water'":
        result = shapeFactorWater
    elif name == "'Ice'":
        result = 0.333 - (0.333 * 0.0 / (volumetricFractionWater(soilWater, carbon, bulkDensity, layer) + 0.0 + volumetricFractionAir(rocks, carbon, sand, silt, clay, soilWater, bulkDensity, layer)))
        return result
    elif name == "'Air'":
        result = 0.333 - (0.333 * volumetricFractionAir(rocks, carbon, sand, silt, clay, soilWater, bulkDensity, layer) / (volumetricFractionWater(soilWater, carbon, bulkDensity, layer) + 0.0 + volumetricFractionAir(rocks, carbon, sand, silt, clay, soilWater, bulkDensity, layer)))
        return result
    elif name == "'Minerals'":
        result = shapeFactorRocks * volumetricFractionRocks(rocks, layer) + (shapeFactorSand * volumetricFractionSand(sand, rocks, carbon, bulkDensity, layer)) + (shapeFactorSilt * volumetricFractionSilt(silt, rocks, carbon, bulkDensity, layer)) + (shapeFactorClay * volumetricFractionClay(clay, rocks, carbon, bulkDensity, layer))
    result = volumetricSpecificHeat(name)
    return result

def ThermalConductance(name:str):
    thermal_conductance_rocks:float = 0.182
    thermal_conductance_om:float = 2.50
    thermal_conductance_sand:float = 0.182
    thermal_conductance_silt:float = 2.39
    thermal_conductance_clay:float = 1.39
    thermal_conductance_water:float = 4.18
    thermal_conductance_ice:float = 1.73
    thermal_conductance_air:float = 0.0012
    result:float = 0.0
    if name == "Rocks":
        result = thermal_conductance_rocks
    elif name == "OrganicMatter":
        result = thermal_conductance_om
    elif name == "Sand":
        result = thermal_conductance_sand
    elif name == "Silt":
        result = thermal_conductance_silt
    elif name == "Clay":
        result = thermal_conductance_clay
    elif name == "Water":
        result = thermal_conductance_water
    elif name == "Ice":
        result = thermal_conductance_ice
    elif name == "Air":
        result = thermal_conductance_air
    result = volumetricSpecificHeat(name)
    return result

def mapLayer2Node(layerArray:'Array[float]',
         nodeArray:'Array[float]',
         thickness:'Array[float]',
         depth:'Array[float]',
         numNodes:int):
    SURFACEnode:int = 1
    depthLayerAbove:float
    node:int = 0
    i:int = 0
    layer:int
    d1:float
    d2:float
    dSum:float
    for node in range(SURFACEnode , numNodes + 1 , 1):
        layer = node - 1
        depthLayerAbove = 0.0
        if layer >= 1:
            for i in range(1 , layer + 1 , 1):
                depthLayerAbove = depthLayerAbove + thickness[i]
        d1 = depthLayerAbove - (depth[node] * 1000.0)
        d2 = depth[(node + 1)] * 1000.0 - depthLayerAbove
        dSum = d1 + d2
        nodeArray[node] = Divide(layerArray[layer] * d1, dSum, 0.0) + Divide(layerArray[(layer + 1)] * d2, dSum, 0.0)
    return nodeArray

def volumetricFractionWater(soilWater:'Array[float]',
         carbon:'Array[float]',
         bulkDensity:'Array[float]',
         layer:int):
    return (1.0 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer)) * soilWater[layer]

def volumetricFractionAir(rocks:'Array[float]',
         carbon:'Array[float]',
         sand:'Array[float]',
         silt:'Array[float]',
         clay:'Array[float]',
         soilWater:'Array[float]',
         bulkDensity:'Array[float]',
         layer:int):
    return 1.0 - volumetricFractionRocks(rocks, layer) - volumetricFractionOrganicMatter(carbon, bulkDensity, layer) - volumetricFractionSand(sand, rocks, carbon, bulkDensity, layer) - volumetricFractionSilt(silt, rocks, carbon, bulkDensity, layer) - volumetricFractionClay(clay, rocks, carbon, bulkDensity, layer) - volumetricFractionWater(soilWater, carbon, bulkDensity, layer) - 0.0

def volumetricFractionRocks(rocks:'Array[float]',
         layer:int):
    return rocks[layer] / 100.0

def volumetricFractionSand(sand:'Array[float]',
         rocks:'Array[float]',
         carbon:'Array[float]',
         bulkDensity:'Array[float]',
         layer:int):
    ps:float = 2.63
    return (1.0 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer) - volumetricFractionRocks(rocks, layer)) * sand[layer] / 100.0 * bulkDensity[layer] / ps

def volumetricFractionSilt(silt:'Array[float]',
         rocks:'Array[float]',
         carbon:'Array[float]',
         bulkDensity:'Array[float]',
         layer:int):
    ps:float = 2.63
    return (1.0 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer) - volumetricFractionRocks(rocks, layer)) * silt[layer] / 100.0 * bulkDensity[layer] / ps

def volumetricFractionClay(clay:'Array[float]',
         rocks:'Array[float]',
         carbon:'Array[float]',
         bulkDensity:'Array[float]',
         layer:int):
    ps:float = 2.63
    return (1.0 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer) - volumetricFractionRocks(rocks, layer)) * clay[layer] / 100.0 * bulkDensity[layer] / ps

def volumetricSpecificHeat(name:str):
    specificHeatRocks:float = 7.7
    specificHeatOM:float = 0.25
    specificHeatSand:float = 7.7
    specificHeatSilt:float = 2.74
    specificHeatClay:float = 2.92
    specificHeatWater:float = 0.57
    specificHeatIce:float = 2.18
    specificHeatAir:float = 0.025
    res:float = 0.0
    if name == "'Rocks'":
        res = specificHeatRocks
    elif name == "'OrganicMatter'":
        res = specificHeatOM
    elif name == "'Sand'":
        res = specificHeatSand
    elif name == "'Silt'":
        res = specificHeatSilt
    elif name == "'Clay'":
        res = specificHeatClay
    elif name == "'Water'":
        res = specificHeatWater
    elif name == "'Ice'":
        res = specificHeatIce
    elif name == "'Air'":
        res = specificHeatAir
    return res

def volumetricFractionOrganicMatter(carbon:'Array[float]',
         bulkDensity:'Array[float]',
         layer:int):
    pom:float = 1.3
    return carbon[layer] / 100.0 * 2.5 * bulkDensity[layer] / pom

def InterpTemp(time_hours:float,
         tmax:float,
         tmin:float,
         t2m:float,
         max_temp_yesterday:float,
         min_temp_yesterday:float):
    defaultTimeOfMaximumTemperature:float = 14.0
    midnight_temp:float
    t_scale:float
    pi:float = 3.14
    time:float = time_hours / 24.0
    max_t_time:float = defaultTimeOfMaximumTemperature / 24.0
    min_t_time:float = max_t_time - 0.5
    current_temp:float
    if time < min_t_time:
        midnight_temp = sin((0.0 + 0.25 - max_t_time) * 2.0 * pi) * (max_temp_yesterday - min_temp_yesterday) / 2.0 + ((max_temp_yesterday + min_temp_yesterday) / 2.0)
        t_scale = (min_t_time - time) / min_t_time
        if t_scale > 1.0:
            t_scale = 1.0
        elif t_scale < 0.0:
            t_scale = 0.0
        current_temp = tmin + (t_scale * (midnight_temp - tmin))
        return current_temp
    else:
        current_temp = sin((time + 0.25 - max_t_time) * 2.0 * pi) * (tmax - tmin) / 2.0 + t2m
        return current_temp

def RadnNetInterpolate(internalTimeStep:float,
         solarRadn:float,
         cloudFr:float,
         cva:float,
         potE:float,
         actE:float,
         t2m:float,
         albedo:float,
         soilTemp:'Array[float]'):
    EMISSIVITYsurface:float = 0.96
    w2MJ:float = internalTimeStep / 1000000.0
    SURFACEnode:int = 1
    emissivityAtmos:float = (1 - (0.84 * cloudFr)) * 0.58 * pow(cva, 1.0 / 7.0) + (0.84 * cloudFr)
    PenetrationConstant:float = Divide(max(0.1, potE), max(0.1, actE), 0.0)
    lwRinSoil:float = longWaveRadn(emissivityAtmos, t2m) * PenetrationConstant * w2MJ
    lwRoutSoil:float = longWaveRadn(EMISSIVITYsurface, soilTemp[SURFACEnode]) * PenetrationConstant * w2MJ
    lwRnetSoil:float = lwRinSoil - lwRoutSoil
    swRin:float = solarRadn
    swRout:float = albedo * solarRadn
    swRnetSoil:float = (swRin - swRout) * PenetrationConstant
    total:float = swRnetSoil + lwRnetSoil
    return total

def Divide(val1:float,
         val2:float,
         errVal:float):
    returnValue:float = errVal
    if val2 != 0.0:
        returnValue = val1 / val2
    return returnValue

def longWaveRadn(emissivity:float,
         tDegC:float):
    STEFAN_BOLTZMANNconst:float = 0.0000000567
    kelvinTemp:float = kelvinT(tDegC)
    res:float = STEFAN_BOLTZMANNconst * emissivity * pow(kelvinTemp, 4)
    return res

def boundaryLayerConductanceF(TNew_zb:'Array[float]',
         t2M:float,
         potE:float,
         actE:float,
         airPressure:float,
         canopyHeight:float,
         windSpeed:float,
         instrumentHeight:float):
    VONK:float = 0.41
    GRAVITATIONALconst:float = 9.8
    specificHeatOfAir:float = 1010.0
    EMISSIVITYsurface:float = 0.98
    SURFACEnode:int = 1
    STEFAN_BOLTZMANNconst:float = 0.0000000567
    SpecificHeatAir:float = specificHeatOfAir * airDensity(t2M, airPressure)
    RoughnessFacMomentum:float = 0.13 * canopyHeight
    RoughnessFacHeat:float = 0.2 * RoughnessFacMomentum
    d:float = 0.77 * canopyHeight
    SurfaceTemperature:float = TNew_zb[SURFACEnode]
    PenetrationConstant:float = max(0.1, potE) / max(0.1, actE)
    kelvinTemp:float = kelvinT(t2M)
    radiativeConductance:float = 4.0 * STEFAN_BOLTZMANNconst * EMISSIVITYsurface * PenetrationConstant * pow(kelvinTemp, 3)
    FrictionVelocity:float = 0.0
    BoundaryLayerCond:float = 0.0
    StabilityParam:float = 0.0
    StabilityCorMomentum:float = 0.0
    StabilityCorHeat:float = 0.0
    HeatFluxDensity:float = 0.0
    iteration:int = 1
    for iteration in range(1 , 4 , 1):
        FrictionVelocity = Divide(windSpeed * VONK, log(Divide(instrumentHeight - d + RoughnessFacMomentum, RoughnessFacMomentum, 0.0)) + StabilityCorMomentum, 0.0)
        BoundaryLayerCond = Divide(SpecificHeatAir * VONK * FrictionVelocity, log(Divide(instrumentHeight - d + RoughnessFacHeat, RoughnessFacHeat, 0.0)) + StabilityCorHeat, 0.0)
        BoundaryLayerCond = BoundaryLayerCond + radiativeConductance
        HeatFluxDensity = BoundaryLayerCond * (SurfaceTemperature - t2M)
        StabilityParam = Divide(-VONK * instrumentHeight * GRAVITATIONALconst * HeatFluxDensity, SpecificHeatAir * kelvinTemp * pow(FrictionVelocity, 3), 0.0)
        if StabilityParam > 0.0:
            StabilityCorHeat = 4.7 * StabilityParam
            StabilityCorMomentum = StabilityCorHeat
        else:
            StabilityCorHeat = -2.0 * log((1.0 + sqrt(1.0 - (16.0 * StabilityParam))) / 2.0)
            StabilityCorMomentum = 0.6 * StabilityCorHeat
    return BoundaryLayerCond

def airDensity(temperature:float,
         AirPressure:float):
    MWair:float = 0.02897
    RGAS:float = 8.3143
    HPA2PA:float = 100.0
    kelvinTemp:float = kelvinT(temperature)
    res:float = Divide(MWair * AirPressure * HPA2PA, kelvinTemp * RGAS, 0.0)
    return res

def kelvinT(celciusT:float):
    ZEROTkelvin:float = 273.18
    res:float = celciusT + ZEROTkelvin
    return res

def Divide(val1:float,
         val2:float,
         errVal:float):
    returnValue:float = errVal
    if val2 != 0.0:
        returnValue = val1 / val2
    return returnValue

def kelvinT(celciusT:float):
    ZEROTkelvin:float = 273.18
    res:float = celciusT + ZEROTkelvin
    return res

def Divide(val1:float,
         val2:float,
         errVal:float):
    returnValue:float = errVal
    if val2 != 0.0:
        returnValue = val1 / val2
    return returnValue

def doThomas(newTemps:'Array[float]',
         soilTemp:'Array[float]',
         thermalConductivity:'Array[float]',
         thermalConductance:'Array[float]',
         depth:'Array[float]',
         volSpecHeatSoil:'Array[float]',
         gDt:float,
         netRadiation:float,
         potE:float,
         actE:float,
         numNodes:int,
         netRadiationSource:str):
    nu:float = 0.6
    AIRnode:int = 0
    SURFACEnode:int = 1
    MJ2J:float = 1000000.0
    latentHeatOfVapourisation:float = 2465000.0
    tempStepSec:float = 24.0 * 60.0 * 60.0
    heatStorage:'array[float]'
    VolSoilAtNode:float
    elementLength:float
    g:float = 1 - nu
    sensibleHeatFlux:float
    RadnNet:float
    LatentHeatFlux:float
    SoilSurfaceHeatFlux:float
    a:'array[float]'
    b:'array[float]'
    c:'array[float]'
    d:'array[float]'
    thermalConductance = [0.] * (numNodes + 1)
    thermalConductance[AIRnode] = thermalConductivity[AIRnode]
    node:int = SURFACEnode
    for node in range(SURFACEnode , numNodes + 1 , 1):
        VolSoilAtNode = 0.5 * (depth[node + 1] - depth[node - 1])
        heatStorage[node] = Divide(volSpecHeatSoil[node] * VolSoilAtNode, gDt, 0.0)
        elementLength = depth[node + 1] - depth[node]
        thermalConductance[node] = Divide(thermalConductivity[node], elementLength, 0.0)
    for node in range(SURFACEnode , numNodes + 1 , 1):
        c[node] = -nu * thermalConductance[node]
        a[node + 1] = c[node]
        b[node] = nu * (thermalConductance[node] + thermalConductance[node - 1]) + heatStorage[node]
        d[node] = g * thermalConductance[(node - 1)] * soilTemp[(node - 1)] + ((heatStorage[node] - (g * (thermalConductance[node] + thermalConductance[node - 1]))) * soilTemp[node]) + (g * thermalConductance[node] * soilTemp[(node + 1)])
    a[SURFACEnode] = 0.0
    sensibleHeatFlux = nu * thermalConductance[AIRnode] * newTemps[AIRnode]
    RadnNet = 0.0
    if netRadiationSource == "'calc'":
        RadnNet = Divide(netRadiation * 1000000.0, gDt, 0.0)
    elif netRadiationSource == "'eos'":
        RadnNet = Divide(potE * latentHeatOfVapourisation, tempStepSec, 0.0)
    LatentHeatFlux = Divide(actE * latentHeatOfVapourisation, tempStepSec, 0.0)
    SoilSurfaceHeatFlux = sensibleHeatFlux + RadnNet - LatentHeatFlux
    d[SURFACEnode] = d[SURFACEnode] + SoilSurfaceHeatFlux
    d[numNodes] = d[numNodes] + (nu * thermalConductance[numNodes] * newTemps[(numNodes + 1)])
    for node in range(SURFACEnode , numNodes , 1):
        c[node] = Divide(c[node], b[node], 0.0)
        d[node] = Divide(d[node], b[node], 0.0)
        b[node + 1] = b[node + 1] - (a[(node + 1)] * c[node])
        d[node + 1] = d[node + 1] - (a[(node + 1)] * d[node])
    newTemps[numNodes] = Divide(d[numNodes], b[numNodes], 0.0)
    for node in range(numNodes - 1 , SURFACEnode - 1 , -1):
        newTemps[node] = d[node] - (c[node] * newTemps[(node + 1)])
    return newTemps

def Divide(val1:float,
         val2:float,
         errVal:float):
    returnValue:float = errVal
    if val2 != 0.0:
        returnValue = val1 / val2
    return returnValue

def doUpdate(tempNew:'Array[float]',
         soilTemp:'Array[float]',
         minSoilTemp:'Array[float]',
         maxSoilTemp:'Array[float]',
         aveSoilTemp:'Array[float]',
         thermalConductivity:'Array[float]',
         boundaryLayerConductance:float,
         IterationsPerDay:int,
         timeOfDaySecs:float,
         gDt:float,
         numNodes:int):
    SURFACEnode:int = 1
    AIRnode:int = 0
    node:int = 1
    soilTemp[] = tempNew[]
    if timeOfDaySecs < (gDt * 1.2):
        for node in range(SURFACEnode , numNodes + 1 , 1):
            minSoilTemp[node] = soilTemp[node]
            maxSoilTemp[node] = soilTemp[node]
    for node in range(SURFACEnode , numNodes + 1 , 1):
        if soilTemp[node] < minSoilTemp[node]:
            minSoilTemp[node] = soilTemp[node]
        elif soilTemp[node] > maxSoilTemp[node]:
            maxSoilTemp[node] = soilTemp[node]
        aveSoilTemp[node] = aveSoilTemp[node] + Divide(soilTemp[node], float(IterationsPerDay), 0.0)
    boundaryLayerConductance = boundaryLayerConductance + Divide(thermalConductivity[AIRnode], float(IterationsPerDay), 0.0)
    return (soilTemp, boundaryLayerConductance)

def Divide(val1:float,
         val2:float,
         errVal:float):
    returnValue:float = errVal
    if val2 != 0.0:
        returnValue = val1 / val2
    return returnValue

def doThermalConductivityCoeffs(nbLayers:int,
         numNodes:int,
         bulkDensity:'Array[float]',
         clay:'Array[float]'):
    thermalCondPar1:'array[float]'
    thermalCondPar2:'array[float]'
    thermalCondPar3:'array[float]'
    thermalCondPar4:'array[float]'
    layer:int
    element:int
    thermalCondPar1 = [0.0] * (numNodes + 1)
    thermalCondPar2 = [0.0] * (numNodes + 1)
    thermalCondPar3 = [0.0] * (numNodes + 1)
    thermalCondPar4 = [0.0] * (numNodes + 1)
    for layer in range(1 , nbLayers + 2 , 1):
        element = layer
        thermalCondPar1[element] = 0.65 - (0.78 * bulkDensity[layer]) + (0.6 * pow(bulkDensity[layer], 2))
        thermalCondPar2[element] = 1.06 * bulkDensity[layer]
        thermalCondPar3[element] = Divide(2.6, sqrt(clay[layer]), 0.0)
        thermalCondPar3[element] = 1.0 + thermalCondPar3[element]
        thermalCondPar4[element] = 0.03 + (0.1 * pow(bulkDensity[layer], 2))
    return (thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4)

def Divide(val1:float,
         val2:float,
         errVal:float):
    returnValue:float = errVal
    if val2 != 0.0:
        returnValue = val1 / val2
    return returnValue

def CalcSoilTemp(soilTempIO:'Array[float]',
         thickness:'Array[float]',
         tav:float,
         tamp:float,
         doy:int,
         latitude:float,
         numNodes:int):
    cumulativeDepth:'array[float]'
    soilTemp:'array[float]'
    Layer:int
    nodes:int
    tempValue:float
    w:float
    dh:float
    zd:float
    offset:float
    SURFACEnode:int = 1
    pi:float = 3.14
    cumulativeDepth = [0.0] * len(thickness)
    if len(thickness) > 0:
        cumulativeDepth[0] = thickness[0]
        for Layer in range(1 , len(thickness) , 1):
            cumulativeDepth[Layer] = thickness[Layer] + cumulativeDepth[Layer - 1]
    w = pi
    w = 2.0 * w
    w = w / (365.25 * 24.0 * 3600.0)
    dh = 0.6
    zd = sqrt(2 * dh / w)
    offset = 0.25
    if latitude > 0.0:
        offset = -0.25
    soilTemp = [0.0] * (numNodes + 2)
    for nodes in range(1 , numNodes + 1 , 1):
        soilTemp[nodes] = tav + (tamp * exp(-1.0 * cumulativeDepth[nodes] / zd) * sin(((doy / 365.0 + offset) * 2.0 * pi - (cumulativeDepth[nodes] / zd))))
    soilTempIO[SURFACEnode:SURFACEnode + numNodes] = soilTemp[0:numNodes]
    return soilTempIO