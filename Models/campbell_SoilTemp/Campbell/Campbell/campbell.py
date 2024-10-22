#coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

#pi: float = 3.141592653589793
#%%CyML Init Begin%%
def init_campbell(NLAYR: int,
    THICK: 'Array[float]',
    BD: 'Array[float]',
    T2M: float,
    TMAX: float,
    TMIN: float,
    TAV: float,
    TAMP: float,
    XLAT: float,
    CONSTANT_TEMPdepth:float,
    SLCARB:'Array[float]',
    CLAY: 'Array[float]',
    SLROCK:'Array[float]',
    SLSILT:'Array[float]',
    SLSAND:'Array[float]',
    SW: 'Array[float]',
    DOY: int,
    canopyHeight: float,
    SALB: float,
    SRAD: float,
    ESP: float,
    ES: float,
    EOAD: float,
    instrumentHeight:float
    ):

    soilTemp:'Array[float]'
    minSoilTemp : 'Array[float]'
    maxSoilTemp : 'Array[float]'
    aveSoilTemp : 'Array[float]'
    morningSoilTemp : 'Array[float]'
    newTemperature : 'Array[float]'
    heatCapacity : 'Array[float]'
    thermalConductivity : 'Array[float]'
    thermalConductance : 'Array[float]'
    heatStorage : 'Array[float]'
    thickness : 'Array[float]'
    depth : 'Array[float]'
    bulkDensity : 'Array[float]'
    soilWater : 'Array[float]'
    clay : 'Array[float]'
    volSpecHeatSoil : 'Array[float]'
    thermalCondPar1 : 'Array[float]'
    thermalCondPar2 : 'Array[float]'
    thermalCondPar3 : 'Array[float]'
    thermalCondPar4 : 'Array[float]'
    carbon:'Array[float]'
    rocks:'Array[float]'
    sand:'Array[float]'
    silt:'Array[float]'

    #Constants
    soilRoughnessHeight:float = 57.0
    defaultInstrumentHeight:float = 1.2
    AltitudeMetres:float = 18.0
    NUM_PHANTOM_NODES:int = 5
    AIRnode:int = 0
    SURFACEnode:int = 1
    TOPSOILnode:int = 2
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
    maxTempYesterday: float
    minTempYesterday: float

    if instrumentHeight > 0.00001:
        instrumentHeight = instrumentHeight
    else:
        instrumentHeight = defaultInstrumentHeight

    numNodes = NLAYR + NUM_PHANTOM_NODES

    thickness = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1, NLAYR + 1):
       thickness[layer] = THICK[layer - 1]
    #thickness[1:len(THICK)] = THICK
    sumThickness = 0.0
    for i in range(1, NLAYR + 1):
        sumThickness = sumThickness + thickness[i]
    BelowProfileDepth = max(CONSTANT_TEMPdepth - sumThickness, 1000.0)
    thicknessForPhantomNodes = BelowProfileDepth * 2.0 / NUM_PHANTOM_NODES
    firstPhantomNode = NLAYR
    for i in range(firstPhantomNode, firstPhantomNode + NUM_PHANTOM_NODES):
        thickness[i] = thicknessForPhantomNodes

    depth = [0.0]*(numNodes + 1 + 1)
    depth[AIRnode] = 0.0
    depth[SURFACEnode] = 0.0
    depth[TOPSOILnode] = 0.5 * thickness[1] / 1000.0

    for node in range(TOPSOILnode, numNodes + 1):
        sumThickness = 0.0
        for i in range(1, node):
            sumThickness = sumThickness + thickness[i]
        depth[node + 1] = (sumThickness + 0.5 * thickness[node]) / 1000.0

    # Bulk Density
    bulkDensity = [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES)
    #bulkDensity[:min(NLAYR + 1 + NUM_PHANTOM_NODES, len(BD))] = BD
    for layer in range(1, NLAYR + 1):
       bulkDensity[layer] = BD[layer - 1]
    bulkDensity[numNodes] = bulkDensity[NLAYR]
    for layer in range(NLAYR + 1, NLAYR + NUM_PHANTOM_NODES + 1):
        bulkDensity[layer] = bulkDensity[NLAYR]

     # Soil Water
    soilWater = [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES)
    #soilWater[:min(NLAYR + 1 + NUM_PHANTOM_NODES, len(SW))] = SW
    for layer in range(1, NLAYR + 1):
       soilWater[layer] = SW[layer - 1]
    for layer in range(NLAYR + 1, NLAYR + NUM_PHANTOM_NODES + 1):
        soilWater[layer] = (soilWater[NLAYR-1] * thickness[NLAYR-1]) / thickness[NLAYR]


    #Carbon
    carbon = [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1,NLAYR + 1):
        carbon[layer] = SLCARB[layer - 1];
    for layer in range(NLAYR + 1 ,NLAYR + NUM_PHANTOM_NODES + 1):
        carbon[layer] = carbon[NLAYR]

    #Rocks
    rocks = [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1,NLAYR + 1):
        rocks[layer] = SLROCK[layer - 1];
    for layer in range(NLAYR + 1 ,NLAYR + NUM_PHANTOM_NODES + 1):
        rocks[layer] = rocks[NLAYR]

    #Sand
    sand = [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1,NLAYR + 1):
        sand[layer] = SLSAND[layer - 1];
    for layer in range(NLAYR + 1 ,NLAYR + NUM_PHANTOM_NODES + 1):
        sand[layer] = sand[NLAYR]

    #Silt
    silt = [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1,NLAYR + 1):
        silt[layer] = SLSILT[layer - 1];
    for layer in range(NLAYR + 1 ,NLAYR + NUM_PHANTOM_NODES + 1):
        silt[layer] = silt[NLAYR]

    # Clay
    clay = [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1, NLAYR + 1):
        clay[layer] = CLAY[layer - 1]
    for layer in range(NLAYR + 1, NLAYR + NUM_PHANTOM_NODES + 1):
        clay[layer] = clay[NLAYR]

    maxSoilTemp = [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES)
    minSoilTemp = [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES)
    aveSoilTemp = [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES)
    volSpecHeatSoil = [0.0]*(numNodes + 1)
    soilTemp = [0.0]*(numNodes + 1 + 1)
    morningSoilTemp = [0.0]*(numNodes + 1 + 1)
    newTemperature = [0.0]*(numNodes + 1 + 1)
    thermalConductivity = [0.0]*(numNodes + 1)
    heatStorage = [0.0]*(numNodes + 1)
    thermalConductance = [0.0]*(numNodes + 1 + 1)

    thermalCondPar1,thermalCondPar2,thermalCondPar3,thermalCondPar4 = doThermalConductivityCoeffs(NLAYR, numNodes, bulkDensity, clay)
    newTemperature = CalcSoilTemp(thickness, TAV, TAMP, DOY, XLAT,numNodes)

    #soilWater[numNodes] = soilWater[NLAYR]
    instrumentHeight = max(instrumentHeight, canopyHeight + 0.5)

    soilTemp = CalcSoilTemp(thickness, TAV, TAMP, DOY, XLAT,numNodes)

    soilTemp[AIRnode] = T2M
    surfaceT = (1.0 - SALB) * (T2M + (TMAX - T2M) * sqrt(max(SRAD, 0.1) * 23.8846 / 800.0)) + SALB * T2M
    soilTemp[SURFACEnode] = surfaceT

    for i in range(numNodes + 1, len(soilTemp)):
        soilTemp[i] = TAV

    for i in range(len(soilTemp)):
        newTemperature[i] = soilTemp[i]
    maxTempYesterday = TMAX
    minTempYesterday = TMIN

    return (soilTemp,
            minSoilTemp,
            maxSoilTemp,
            aveSoilTemp,
            morningSoilTemp,
            newTemperature,
            maxTempYesterday,
            minTempYesterday,
            thermalCondPar1,
            thermalCondPar2,
            thermalCondPar3,
            thermalCondPar4,
            thermalConductivity,
            thermalConductance,
            heatStorage,
            volSpecHeatSoil, 
            thickness, 
            depth, 
            bulkDensity, 
            soilWater, 
            clay, 
            rocks, 
            carbon, 
            sand, 
            silt)
    #%%CyML Init End%%

#%%CyML Model Begin%%
def model_campbell(NLAYR: int,
    THICK: 'Array[float]',
    DEPTH: 'Array[float]',
    CONSTANT_TEMPdepth:float,
    BD: 'Array[float]',
    T2M: float,
    TMAX: float,
    TMIN: float,
    TAV: float,
    TAMP: float,
    XLAT: float,
    CLAY: 'Array[float]',
    SW: 'Array[float]',
    DOY: int,
    airPressure: float,
    canopyHeight: float,
    SALB: float,
    SRAD: float,
    ESP: float,
    ES: float,
    EOAD: float,  
    soilTemp: 'Array[float]',
    newTemperature: 'Array[float]',
    minSoilTemp: 'Array[float]',
    maxSoilTemp: 'Array[float]',
    aveSoilTemp: 'Array[float]',
    morningSoilTemp: 'Array[float]',
    thermalCondPar1: 'Array[float]',
    thermalCondPar2: 'Array[float]',
    thermalCondPar3: 'Array[float]',
    thermalCondPar4: 'Array[float]',
    thermalConductivity: 'Array[float]',
    thermalConductance: 'Array[float]',
    heatStorage: 'Array[float]',
    volSpecHeatSoil: 'Array[float]',
    maxTempYesterday: float,
    minTempYesterday: float,
    instrumentHeight:float,
    boundaryLayerConductanceSource:str,
    netRadiationSource:str,
    windSpeed:float,
    SLCARB:'Array[float]',
    SLROCK:'Array[float]',
    SLSILT:'Array[float]',
    SLSAND:'Array[float]',
    _boundaryLayerConductance:float
    ):
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
               ** description : bd (soil bulk density) is name of the APSIM var for bulk density so set bulkDensity = bd later
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
               ** unit : °C
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
               ** parametercategory : constant
               ** datatype : DOUBLE
               ** max : 100
               ** min : -100
               ** default :
               ** unit : °C
        * name: XLAT
               ** description : Latitude
               ** inputtype : parameter
               ** parametercategory : constant
               ** datatype : DOUBLE
               ** max : 
               ** min :
               ** default :
               ** unit : °C
        * name: CLAY
               ** description : Proportion of clay in each layer of profile
               ** inputtype : parameter
               ** parametercategory : constant
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max : 100
               ** min : 0
               ** default : 50
               ** unit : %
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
               ** description :  Temperature at end of last time-step within a day - midnight in layers
               ** inputtype : variable
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** default :
               ** min : -60.
               ** max : 60.
               ** unit : degC
               ** uri : 
        * name: newTemperature
                ** description : Soil temperature at the end of one iteration
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : -60.
                ** max : 60.
                ** unit : degC
                ** uri : 
        * name: minSoilTemp
                ** description : Minimum soil temperature in layers
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : -60.
                ** max : 60.
                ** unit : degC
                ** uri : 
        * name: maxSoilTemp
                ** description :  Maximum soil temperature in layers
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : -60.
                ** max : 60.
                ** unit : degC
                ** uri : 
        * name: aveSoilTemp
                ** description : Temperature averaged over all time-steps within a day in layers.
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : -60.
                ** max : 60.
                ** unit : degC
                ** uri : 
        * name: morningSoilTemp
                ** description : Temperature  in the morning in layers.
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : -60.
                ** max : 60.
                ** unit : degC
                ** uri : 
        * name: thermalCondPar1
               ** description : thermal conductivity coeff in layers
               ** inputtype : variable
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** default : 
               ** min : 
               ** max : 
               ** unit : (W/m2/K)
               ** uri : 
        * name: thermalCondPar2
               ** description : thermal conductivity coeff in layers
               ** inputtype : variable
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** default : 
               ** min : 
               ** max : 
               ** unit : (W/m2/K)
               ** uri : 
        * name: thermalCondPar3
               ** description : thermal conductivity coeff in layers
               ** inputtype : variable
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** default : 
               ** min : 
               ** max : 
               ** unit : (W/m2/K)
               ** uri : 
        * name: thermalCondPar4
               ** description : thermal conductivity coeff in layers
               ** inputtype : variable
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** default : 
               ** min : 
               ** max : 
               ** unit : (W/m2/K)
               ** uri :
        * name: thermalConductivity
                ** description : thermal conductivity in layers
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : 
                ** max : 
                ** unit : (W/m2/K)
                ** uri : 
        * name: thermalConductance
                ** description : Thermal conductance between layers 
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : 
                ** max : 
                ** unit : (W/m2/K)
                ** uri : 
        * name: heatStorage
                ** description : Heat storage between layers (internal)
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : 
                ** max : 
                ** unit : J/s/K
                ** uri : 
        * name: volSpecHeatSoil
                ** description : Volumetric specific heat over the soil profile
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : 
                ** max : 
                ** unit : J/K/m3
                ** uri : 
        * name: maxTempYesterday
               ** description : Air max temperature from previous day
               ** inputtype : variable
               ** variablecategory : state
               ** datatype : DOUBLE
               ** default : 
               ** min : -60
               ** max : 60
               ** unit : °C
               ** uri : 
        * name: minTempYesterday
               ** description : Air min temperature from previous day
               ** inputtype : variable
               ** variablecategory : state
               ** datatype : DOUBLE
               ** default : 
               ** min : -60
               ** max : 60
               ** unit : °C
               ** uri : 
        * name: instrumentHeight
               ** description : Default instrument height
               ** inputtype : parameter
               ** parametercategory : constant
               ** datatype : DOUBLE
               ** default : 1.2
               ** min : 0
               ** max : 
               ** unit : m
               ** uri : 
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
               ** default : 3.0
               ** min : 0.0
               ** max : 
               ** unit : m/s
               ** uri :
        * name: SLCARB
                ** description : Volumetric fraction of organic matter in the soil
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: SLROCK
                ** description : Volumetric fraction of rocks in the soil
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: SLSILT
                ** description : Volumetric fraction of silt in the soil
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: SLSAND
                ** description : Volumetric fraction of sand in the soil
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: _boundaryLayerConductance
                ** description : Boundary layer conductance
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLE
                ** default :
                ** min : 
                ** max : 
                ** unit : K/W
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
        * name: newTemperature
                ** description : Soil temperature at the end of one iteration
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** min : -60.
                ** max : 60.
                ** unit : degC
                ** uri : 
        * name: minSoilTemp
                ** description : Minimum soil temperature in layers
                ** variablecategory : state
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
        * name: airPressure
               ** description : Air pressure
               ** variablecategory : state
               ** datatype : DOUBLE
               ** max : 
               ** min : 
               ** unit : hPA
        * name: thermalCondPar1
               ** description : thermal conductivity coeff in layers
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** min : 
               ** max : 
               ** unit : (W/m2/K)
               ** uri : 
        * name: thermalCondPar2
               ** description : thermal conductivity coeff in layers
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** min : 
               ** max : 
               ** unit : (W/m2/K)
               ** uri : 
        * name: thermalCondPar3
               ** description : thermal conductivity coeff in layers
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** min : 
               ** max : 
               ** unit : (W/m2/K)
               ** uri : 
        * name: thermalCondPar4
               ** description : thermal conductivity coeff in layers
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** min : 
               ** max : 
               ** unit : (W/m2/K)
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
                ** unit : (W/m2/K)
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
        * name: volSpecHeatSoil
                ** description : Volumetric specific heat over the soil profile
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** min : 
                ** max : 
                ** unit : J/K/m3
                ** uri : 
        * name: maxTempYesterday
               ** description : Air max temperature from previous day
               ** variablecategory : state
               ** datatype : DOUBLE
               ** min : -60
               ** max : 60
               ** unit : °C
               ** uri : 
        * name: minTempYesterday
               ** description : Air min temperature from previous day
               ** variablecategory : state
               ** datatype : DOUBLE
               ** min : -60
               ** max : 60
               ** unit : °C
               ** uri : 
        * name: SLCARB
                ** description : Volumetric fraction of organic matter in the soil
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: SLROCK
                ** description : Volumetric fraction of rocks in the soil
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: SLSILT
                ** description : Volumetric fraction of silt in the soil
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: SLSAND
                ** description : Volumetric fraction of sand in the soil
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: _boundaryLayerConductance
                ** description : Boundary layer conductance
                ** variablecategory : state
                ** datatype : DOUBLE
                ** min : 
                ** max : 
                ** unit : K/W
                ** uri : 
    """

    #%%CyML Compute Begin%%

    # Constant
    AIRnode: int = 0
    SURFACEnode: int = 1
    TOPSOILnode: int = 2
    ITERATIONSperDAY : int = 48 # number of iterations in a day
    NUM_PHANTOM_NODES : int = 5
    DAYhrs: float = 24.0
    MIN2SEC: float = 60.0
    HR2MIN: float = 60.0
    SEC2HR: float = 1.0 / (HR2MIN * MIN2SEC)
    DAYmins: float = DAYhrs * HR2MIN
    DAYsecs: float = DAYmins * MIN2SEC
    PA2HPA: float  = 1.0 / 100.0
    MJ2J: float = 1000000.0
    J2MJ: float = 1.0 / MJ2J
    tempStepSec: float = 24.0 * 60.0 * 60.0
    BoundaryLayerConductanceIterations: int = 1
    numNodes:int = NLAYR + NUM_PHANTOM_NODES
    soilConstituentNames : 'Array[str]' = ["Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"]
    timeStepIteration: int = 1
    netRadiation: float
    constantBoundaryLayerConductance:float = 20.0
    precision: float
    cva:float
    cloudFr:float
    solarRadn: 'Array[float]'
    layer: int = 0
    timeOfDaySecs: float
    airTemperature:float
    iteration:int
    tMean:float

    cva = 0.0
    cloudFr = 0.0
    solarRadn = [0.0] * 49   # Total incoming short wave solar radiation per timestep
    solarRadn, cloudFr, cva = doNetRadiation(solarRadn, cloudFr, cva, ITERATIONSperDAY, DOY, SRAD, TMIN, XLAT)

    # zero the temperature profiles
    minSoilTemp = Zero(minSoilTemp)
    maxSoilTemp = Zero(maxSoilTemp)
    aveSoilTemp = Zero(aveSoilTemp)
    _boundaryLayerConductance = 0.0

    # calc dt
    internalTimeStep: float = tempStepSec / float(ITERATIONSperDAY)

    # These two call used to be inside the timestep loop. I've taken them outside,
    # as the results do not appear to vary over the course of the day.
    # The results would vary if soil water content were to vary, so if future versions
    # to more communication within subday time steps, these may need to be moved
    # back into the loop. EZJ March 2014
    soilWater: 'Array[float]' = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    copyLength: int = min(NLAYR + 1 + NUM_PHANTOM_NODES, len(SW)+1)
    soilWater[:copyLength] = SW[:copyLength]     # SW dimensioned for layers 1 to gNumlayers + extra for zone below bottom layer

    volSpecHeatSoil = doVolumetricSpecificHeat(volSpecHeatSoil, soilWater, numNodes, soilConstituentNames, THICK, DEPTH)      # RETURNS volSpecHeatSoil() (volumetric heat capacity of nodes)
    thermalConductivity = doThermConductivity(soilWater, SLCARB, SLROCK,
                                             SLSAND, SLSILT, CLAY, BD, thermalConductivity, THICK, DEPTH, numNodes, soilConstituentNames)     # RETURNS gThermConductivity_zb()

    for timeStepIteration in range(1, ITERATIONSperDAY+1):
        timeOfDaySecs = internalTimeStep * float(timeStepIteration)
        if (tempStepSec < 24.0 * 60.0 * 60.0):
            tMean = T2M
        else:
            tMean = InterpTemp(timeOfDaySecs * SEC2HR, TMAX, TMIN, T2M, maxTempYesterday, minTempYesterday)
        newTemperature[AIRnode] = tMean

        netRadiation = RadnNetInterpolate(internalTimeStep, solarRadn[timeStepIteration], 
                                                 cloudFr, cva, ESP, EOAD, tMean, SALB, soilTemp)

        if boundaryLayerConductanceSource == "constant":
            thermalConductivity[AIRnode] = constantBoundaryLayerConductance
        elif boundaryLayerConductanceSource == "calc":
            thermalConductivity[AIRnode] = boundaryLayerConductanceF(newTemperature, tMean, ESP, EOAD, airPressure, canopyHeight, windSpeed, instrumentHeight)
            for iteration in range(1, BoundaryLayerConductanceIterations + 1):
                newTemperature = doThomas(newTemperature, soilTemp, 
                        thermalConductivity, thermalConductance, DEPTH, 
                        volSpecHeatSoil, 
                        internalTimeStep,
                        netRadiation, 
                        ESP, ES,
                        numNodes, netRadiationSource)
                thermalConductivity[AIRnode] = boundaryLayerConductanceF(newTemperature, tMean, ESP, EOAD, airPressure, canopyHeight, windSpeed, instrumentHeight)
        
        # Final calculation with updated boundary layer conductance
        newTemperature = doThomas(newTemperature, soilTemp, 
                        thermalConductivity, thermalConductance, DEPTH,
                        volSpecHeatSoil, 
                        internalTimeStep,
                        netRadiation, 
                        ESP, ES, 
                        numNodes, netRadiationSource) # Update tempNew again
        soilTemp, _boundaryLayerConductance = doUpdate(newTemperature, 
                 soilTemp,
                 minSoilTemp, 
                 maxSoilTemp,
                 aveSoilTemp,
                 thermalConductivity,
                 _boundaryLayerConductance,
                 ITERATIONSperDAY, 
                 timeOfDaySecs,
                 internalTimeStep,
                 numNodes)
        
        # Check for precision and update morning soil temperature
        precision = min(timeOfDaySecs, 5.0 * 3600.0) * 0.0001
        if abs(timeOfDaySecs - 5.0 * 3600.0) <= precision:
            for layer in range(len(soilTemp)):
                morningSoilTemp[layer] = soilTemp[layer]  # Copy soilTemp to morningSoilTemp
        
    # Update previous day's minimum and maximum temperatures
    minTempYesterday = TMIN
    maxTempYesterday = TMAX

    #%%CyML Compute End%%
    
    return (soilTemp,
            minSoilTemp,
            maxSoilTemp,
            aveSoilTemp,
            morningSoilTemp,
            newTemperature,
            maxTempYesterday,
            minTempYesterday,
            thermalCondPar1,
            thermalCondPar2,
            thermalCondPar3,
            thermalCondPar4,
            thermalConductivity,
            thermalConductance,
            heatStorage,
            volSpecHeatSoil,
            _boundaryLayerConductance,
            THICK, DEPTH, BD, soilWater, 
            CLAY, SLROCK, SLCARB, SLSAND, SLSILT, airPressure)
#%%CyML Model End%%


def doThermalConductivityCoeffs(nbLayers:int, 
                                numNodes:int,
                                bulkDensity: 'Array[float]',
                                clay: 'Array[float]'):

    thermalCondPar1 : 'Array[float]' #= []
    thermalCondPar2 : 'Array[float]' #= []
    thermalCondPar3 : 'Array[float]' #= []
    thermalCondPar4 : 'Array[float]' #= []
    layer:int
    element:int

    thermalCondPar1 = [0.0]*(numNodes + 1)
    thermalCondPar2 = [0.0]*(numNodes + 1)
    thermalCondPar3 = [0.0]*(numNodes + 1)
    thermalCondPar4 = [0.0]*(numNodes + 1)

    for layer in range(1, nbLayers + 2):
         element = layer
         thermalCondPar1[element] = 0.65 - 0.78 * bulkDensity[layer] + 0.6 * bulkDensity[layer] ** 2
         thermalCondPar2[element] = 1.06 * bulkDensity[layer]
         thermalCondPar3[element] = Divide(2.6, sqrt(clay[layer]), 0.0)
         thermalCondPar3[element] = 1.0 + thermalCondPar3[element]
         thermalCondPar4[element] = 0.03 + 0.1 * bulkDensity[layer] ** 2

    return (thermalCondPar1,thermalCondPar2,thermalCondPar3,thermalCondPar4)


def Divide(val1:float, 
           val2:float, 
           errVal:float) -> float:

    returnValue:float = errVal
    if val2 != 0.0:
        returnValue = val1 / val2

    return returnValue


def CalcSoilTemp(thickness: 'Array[float]',
                tav:float,
                tamp:float, 
                doy:int, 
                latitude:float,
                numNodes:int):

    cumulativeDepth: 'Array[float]'
    soilTempIO: 'Array[float]'
    soilTemperat: 'Array[float]'
    Layer:int
    nodes:int
    tempValue:float
    w:float
    dh:float
    zd:float 
    offset:float
    SURFACEnode:int = 1
    _pi: float = 3.141592653589793

    cumulativeDepth = [0.0]*len(thickness)
    if len(thickness) > 0:
        cumulativeDepth[0] = thickness[0]
        for Layer in range(1, len(thickness)):
            cumulativeDepth[Layer] = thickness[Layer] + cumulativeDepth[Layer - 1]

    w = _pi
    w = 2.0 * w
    w = w / (365.25 * 24.0 * 3600.0)
    dh = 0.6
    zd = sqrt(2 * dh / w)
    offset = 0.25
    if latitude > 0.0:
        offset = -0.25

    soilTemperat = [0.0]*(numNodes + 2)
    soilTempIO = [0.0]*(numNodes + 1 + 1)
    for nodes in range(1, numNodes + 1):
        soilTemperat[nodes] = tav + tamp * exp(-1.0 * cumulativeDepth[nodes] / zd) * sin(((doy / 365.0) + offset) * 2.0 * _pi - (cumulativeDepth[nodes] / zd))

    for Layer in range(SURFACEnode, numNodes + 1):
        soilTempIO[Layer] = soilTemperat[Layer-1]
    return soilTempIO


def doNetRadiation(
        solarRadn: 'Array[float]',
        cloudFr: float,
        cva: float,
        ITERATIONSperDAY: int,
        doy: int,
        rad: float,
        tmin: float, 
        latitude: float
        ):

    _pi: float = 3.141592653589793
    TSTEPS2RAD:float = 1.0
    SOLARconst:float = 1.0
    solarDeclination:float = 1.0
    m1:'Array[float]' 
    m1 = [0.]*(ITERATIONSperDAY + 1)

    TSTEPS2RAD = Divide(2.0 * _pi, float(ITERATIONSperDAY), 0.0)          # convert timestep of day to radians
    SOLARconst = 1360.0     # W/M^2
    solarDeclination = 0.3985 * sin(4.869 + (doy * 2.0 * _pi / 365.25) + 0.03345 * sin(6.224 + (doy * 2.0 * _pi / 365.25)))
    cD: float = sqrt(1.0 - solarDeclination * solarDeclination)
  
    m1Tot: float = 0.0
    psr: float
    timestepNumber: int =1
    fr: float 

    for timestepNumber in range(1, ITERATIONSperDAY+1):
        m1[timestepNumber] = (solarDeclination * sin(latitude * _pi / 180.0) + cD * cos(latitude * _pi / 180.0) *
            cos(TSTEPS2RAD * (float(timestepNumber) - float(ITERATIONSperDAY) / 2.0))) * 24.0 / float(ITERATIONSperDAY)
        if (m1[timestepNumber] > 0.0):
            m1Tot = m1Tot + m1[timestepNumber]
        else:
            m1[timestepNumber] = 0.0
    
    psr = m1Tot * SOLARconst * 3600.0 / 1000000.0   # potential solar radiation for the day (mj/m^2)
    fr = Divide(max(rad, 0.1), psr, 0.0)               # ratio of potential to measured daily solar radiation (0-1)
    cloudFr = 2.33 - 3.33 * fr    # fractional cloud cover (0-1)
    cloudFr = min(max(cloudFr,0.0),1.0)

    for timestepNumber in range(1, ITERATIONSperDAY+1):
        solarRadn[timestepNumber] = max(rad, 0.1) * Divide(m1[timestepNumber], m1Tot, 0.0)

    # cva is vapour concentration of the air (g/m^3)
    kelvinTemp:float = kelvinT(tmin)
    cva = exp(31.3716 - 6014.79 / kelvinTemp - 0.00792495 * kelvinTemp) / kelvinTemp

    return solarRadn, cloudFr, cva

def kelvinT(celciusT: float) -> float:
    """ Convert deg Celcius to deg Kelvin.
    """
    ZEROTkelvin: float = 273.18
    res:float = celciusT + ZEROTkelvin
    return res

def Zero(arr: 'Array[float]') -> 'Array[float]':
    "Zero the specified array."
    i: int = 0
    for i in range(len(arr)):
        arr[i] = 0.
    return arr

def mapLayer2Node(layerArray: 'Array[float]', nodeArray: 'Array[float]', thickness: 'Array[float]', depth: 'Array[float]', numNodes: int):
    """
    Map layer properties to nodes by averaging properties between layers and nodes.

    Parameters:
    layerArray (list[float]): Array containing layer properties.
    nodeArray (list[float]): Array to store node properties.
    thickness (list[float]): Thickness of each soil layer (mm).
    depth (list[float]): Depth of nodes (m).
    numNodes (int): Number of nodes.
    """
    # Constant
    SURFACEnode: int = 1
    depthLayerAbove: float

    node: int = 0
    i: int = 0
    layer: int
    d1:float
    d2:float
    dSum:float

    for node in range(SURFACEnode, numNodes + 1):
        layer = node - 1  # Node n lies at the center of layer n-1
        depthLayerAbove = 0.0

        if layer >= 1:
            for i in range(1, layer + 1):
                depthLayerAbove = depthLayerAbove + thickness[i]

        d1 = depthLayerAbove - (depth[node] * 1000.0)
        d2 = depth[node + 1] * 1000.0 - depthLayerAbove
        dSum = d1 + d2

        nodeArray[node] = Divide(layerArray[layer] * d1, dSum, 0.0) + Divide(layerArray[layer + 1] * d2, dSum, 0.0)

    return nodeArray

def volumetricSpecificHeat(name:str) -> float:
    specificHeatRocks:float = 7.7
    specificHeatOM:float = 0.25
    specificHeatSand:float = 7.7
    specificHeatSilt:float = 2.74
    specificHeatClay:float = 2.92
    specificHeatWater:float = 0.57
    specificHeatIce:float = 2.18
    specificHeatAir:float = 0.025
    res:float = 0.0

    if name == "Rocks":
        res = specificHeatRocks
    elif name == "OrganicMatter":
        res = specificHeatOM
    elif name == "Sand":
        res = specificHeatSand
    elif name == "Silt":
        res = specificHeatSilt
    elif name == "Clay":
        res = specificHeatClay
    elif name == "Water":
        res = specificHeatWater
    elif name == "Ice":
        res = specificHeatIce
    elif name == "Air":
        res = specificHeatAir
    return res


    
def doVolumetricSpecificHeat(volSpecLayer: 'Array[float]', soilW: 'Array[float]',  numNodes:int, 
                             constituents:'Array[str]', thickness: 'Array[float]', depth: 'Array[float]') -> 'Array[float]':
    """
    Calculate the volumetric specific heat (volumetric heat capacity Cv) of the soil layer.
    Based on Campbell, G.S. (1985) "Soil physics with BASIC: Transport models for soil-plant systems".

    Parameters:
    soilW (list[float]): Soil water content by layer.

    Returns:
    list[float]: Volumetric specific heat of the soil layers (Cv) [Joules*m-3*K-1].
    """

    volSpecHeatSoil: 'Array[float]' 
    volSpecHeatSoil= [0.0] * (numNodes + 1)
    node:int
    constituent:int

    for node in range(1, numNodes + 1):
        volSpecHeatSoil[node] = 0.0
        for constituent in range(0, len(constituents)):
            volSpecHeatSoil[node] = volSpecHeatSoil[node] + (volumetricSpecificHeat(constituents[constituent]) * 1000000.0 * soilW[node])

    volSpecLayer = mapLayer2Node(volSpecHeatSoil, volSpecLayer, thickness, depth, numNodes)
    return volSpecLayer

def volumetricFractionRocks(rocks:'Array[float]', layer: int) -> float:
    res:float = rocks[layer] / 100.0
    return res

def volumetricFractionOrganicMatter(carbon:'Array[float]', bulkDensity:'Array[float]', layer: int) -> float:
    pom:float = 1.3
    res:float = carbon[layer] / 100.0 * 2.5 * bulkDensity[layer] / pom
    return res

def volumetricFractionSand(sand:'Array[float]', rocks:'Array[float]', carbon:'Array[float]', bulkDensity:'Array[float]', layer: int) -> float:
    ps:float = 2.63
    res:float = (1.0 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer) - 
            volumetricFractionRocks(rocks, layer)) * sand[layer] / 100.0 * bulkDensity[layer] / ps
    return res

def volumetricFractionSilt(silt:'Array[float]', rocks:'Array[float]', carbon:'Array[float]', bulkDensity:'Array[float]', layer: int) -> float:
    ps:float = 2.63
    res:float = (1.0 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer) - 
            volumetricFractionRocks(rocks, layer)) * silt[layer] / 100.0 * bulkDensity[layer] / ps
    return res

def volumetricFractionClay(clay:'Array[float]', rocks:'Array[float]', carbon:'Array[float]', bulkDensity:'Array[float]', layer: int) -> float:
    ps:float = 2.63
    res:float = (1.0 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer) - 
            volumetricFractionRocks(rocks, layer)) * clay[layer] / 100.0 * bulkDensity[layer] / ps
    return res

def volumetricFractionWater(soilWater:'Array[float]', carbon:'Array[float]', bulkDensity:'Array[float]', layer: int) -> float:
    res:float = (1.0 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer)) * soilWater[layer]
    return res

#def volumetricFractionIce() -> float:
#    return 0.0 

def volumetricFractionAir(rocks:'Array[float]', carbon:'Array[float]', sand:'Array[float]', silt:'Array[float]', 
                          clay:'Array[float]', soilWater:'Array[float]', bulkDensity:'Array[float]', layer: int) -> float:
    res:float = (1.0 - volumetricFractionRocks(rocks, layer) 
                 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer) 
                 - volumetricFractionSand(sand, rocks, carbon, bulkDensity, layer) 
                 - volumetricFractionSilt(silt, rocks, carbon, bulkDensity, layer) 
                 - volumetricFractionClay(clay, rocks, carbon, bulkDensity, layer) 
                 - volumetricFractionWater(soilWater, carbon, bulkDensity, layer) - 0.0)
    return res


def shapeFactor(name:str, rocks:'Array[float]', carbon:'Array[float]', sand:'Array[float]', silt:'Array[float]', 
                          clay:'Array[float]', soilWater:'Array[float]', bulkDensity:'Array[float]', layer:int):
    shapeFactorRocks:float = 0.182
    shapeFactorOM:float = 0.5
    shapeFactorSand:float = 0.182
    shapeFactorSilt:float = 0.125
    shapeFactorClay:float = 0.007755
    shapeFactorWater:float = 1.0
    #shapeFactorIce = 0.0
    #shapeFactorAir = .NaN

    result:float = 0.0

    if name == "Rocks":
        result = shapeFactorRocks
    elif name == "OrganicMatter":
        result = shapeFactorOM
    elif name == "Sand":
        result = shapeFactorSand
    elif name == "Silt":
        result = shapeFactorSilt
    elif name == "Clay":
        result = shapeFactorClay
    elif name == "Water":
        result = shapeFactorWater
    elif name == "Ice":
        result = 0.333 - 0.333 * 0.0 / (volumetricFractionWater(soilWater, carbon, bulkDensity, layer) + 0.0 
                                        + volumetricFractionAir(rocks, carbon, sand, silt, clay, soilWater, bulkDensity, layer))
        return result
    elif name == "Air":
        result = 0.333 - 0.333 * volumetricFractionAir(rocks, carbon, sand, silt, clay, soilWater, bulkDensity, layer) / (volumetricFractionWater(soilWater, carbon, bulkDensity, layer) + 0.0 + 
                                                                 volumetricFractionAir(rocks, carbon, sand, silt, clay, soilWater, bulkDensity, layer))
        return result
    elif name == "Minerals":
        result = (shapeFactorRocks * volumetricFractionRocks(rocks, layer) 
                  + shapeFactorSand * volumetricFractionSand(sand, rocks, carbon, bulkDensity, layer) 
                  + shapeFactorSilt * volumetricFractionSilt(silt, rocks, carbon, bulkDensity, layer) 
                  + shapeFactorClay * volumetricFractionClay(clay, rocks, carbon, bulkDensity, layer))
    
    result = volumetricSpecificHeat(name)
    return result

def ThermalConductance(name: str) -> float:
    thermal_conductance_rocks:float = 0.182
    thermal_conductance_om:float = 2.50
    thermal_conductance_sand:float = 0.182
    thermal_conductance_silt:float = 2.39
    thermal_conductance_clay:float = 1.39
    thermal_conductance_water:float = 4.18  # CHECK, this value seems to be the specific heat
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
    #elif name == "Minerals":
    #    result = math.pow(thermal_conductance_rocks, volumetricFractionRocks(layer)) * \
    #             math.pow(thermal_conductance_sand, volumetricFractionSand(layer)) + \
    #             math.pow(thermal_conductance_silt, volumetricFractionSilt(layer)) + \
    #             math.pow(thermal_conductance_clay, volumetricFractionClay(layer))
        # CHECK, this function seems odd (wrong), why power function, why multiply and add???

    result = volumetricSpecificHeat(name)  # This is wrong, but it was in the original code...
    return result


def doThermConductivity(soilW: 'Array[float]', carbon: 'Array[float]', rocks: 'Array[float]', sand: 'Array[float]', 
                        silt: 'Array[float]', clay: 'Array[float]', bulkDensity: 'Array[float]',
                                thermalConductivity: 'Array[float]', thickness: 'Array[float]', depth: 'Array[float]',
                                numNodes: int, constituents:'Array[str]') -> 'Array[float]':
    """
    Calculate the thermal conductivity of the soil layer based on Campbell's model.

    Parameters:
    soilW (list[float]): Soil water content by layer.
    thermalCondPar1 (list[float]): Parameter 1 for thermal conductivity calculation.
    thermalCondPar2 (list[float]): Parameter 2 for thermal conductivity calculation.
    thermalCondPar3 (list[float]): Parameter 3 for thermal conductivity calculation.
    thermalCondPar4 (list[float]): Parameter 4 for thermal conductivity calculation.
    numNodes (int): Number of nodes for the soil layers.

    Returns:
    list[float]: Thermal conductivity values for the soil layers.
    """
    thermCondLayers: 'Array[float]' 
    thermCondLayers = [0.0] * (numNodes + 1)
    node: int = 1
    constituent: int = 1
    temp:float
    numerator:float
    denominator:float
    shapeFactorConstituent:float
    thermalConductanceConstituent:float
    thermalConductanceWater:float
    k:float

    for node in range(1, numNodes + 1):
        numerator = 0.0
        denominator = 0.0
        for constituent in range(0, len(constituents)):
            shapeFactorConstituent = shapeFactor(constituents[constituent], rocks, carbon, sand, silt, clay, soilW, bulkDensity, node)
            thermalConductanceConstituent = ThermalConductance(constituents[constituent])
            thermalConductanceWater = ThermalConductance("Water")
            k = (2.0 / 3.0) * pow(1 + shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0), -1) + (1.0 / 3.0) * pow(1 + shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0) * (1.0 - 2.0 * shapeFactorConstituent), -1)
            numerator = numerator + (thermalConductanceConstituent * soilW[node] * k)
            denominator = denominator + (soilW[node] * k)

        thermCondLayers[node] = numerator / denominator

    # now get weighted average for soil elements between the nodes. i.e. map layers to nodes
    thermalConductivity = mapLayer2Node(thermCondLayers, thermalConductivity, thickness, depth, numNodes)
    return thermalConductivity

def InterpTemp(time_hours: float, tmax: float, tmin: float, t2m:float, max_temp_yesterday: float, min_temp_yesterday: float) -> float:
    """
    Interpolates the temperature for a given time based on maximum and minimum temperatures for today and yesterday.
    
    Parameters:
    time_hours (float): The current time in hours.
    tmax (float): Today's maximum temperature.
    tmin (float): Today's minimum temperature.
    max_temp_yesterday (float): Yesterday's maximum temperature.
    min_temp_yesterday (float): Yesterday's minimum temperature.
    
    Returns:
    float: The interpolated temperature at the given time.
    """
    defaultTimeOfMaximumTemperature:float = 14.0
    midnight_temp: float
    t_scale: float 
    _pi: float = 3.141592653589793

    # Convert current time and times for max and min temperatures to fractions of a day
    time: float = time_hours / 24.0  # Current time as a fraction of the day
    max_t_time: float = defaultTimeOfMaximumTemperature / 24.0  # Time of max temperature as a fraction of the day
    min_t_time: float = max_t_time - 0.5  # Time of minimum temperature, 12 hours before max temp
    current_temp: float = 0.0

    if time < min_t_time:
        # Before the time of minimum temperature
        midnight_temp = sin((0.0 + 0.25 - max_t_time) * 2.0 * _pi) * (max_temp_yesterday - min_temp_yesterday) / 2.0 + (max_temp_yesterday + min_temp_yesterday) / 2.0
        t_scale = (min_t_time - time) / min_t_time

        # Ensure t_scale is within bounds (0 <= t_scale <= 1)
        if t_scale > 1.0:
            t_scale = 1.0
        elif t_scale < 0.0:
            t_scale = 0.0

        current_temp = tmin + t_scale * (midnight_temp - tmin)
        return current_temp
    
    else:
        # At or after the time of minimum temperature
        current_temp = sin((time + 0.25 - max_t_time) * 2.0 * _pi) * (tmax - tmin) / 2.0 + t2m
        return current_temp
    return current_temp


def longWaveRadn(emissivity: float, tDegC: float) -> float:
    """
    calculate longwave radiation using the stefan-boltzmann law.
    
    parameters:
    emissivity (float): emissivity of the surface or atmosphere.
    tdegc (float): temperature in degrees celsius.
    
    returns:
    float: longwave radiation.
    """
    STEFAN_BOLTZMANNconst: float = 0.0000000567 # stefan-boltzmann constant in w/m^2k^4
    kelvinTemp:float = kelvinT(tDegC)
    res:float = STEFAN_BOLTZMANNconst * emissivity * (kelvinTemp ** 4)
    return res

def RadnNetInterpolate(internalTimeStep:float, solarRadiation: float, cloudFr: float, cva: float, potE: float, potET: float, tMean: float, albedo: float, soilTemp: 'Array[float]') -> float:
    """
    Calculate the net radiation at the soil surface.
    
    Parameters:
    solarRadiation (float): Incoming solar radiation.
    cloudFr (float): Cloud fraction.
    cva (float): Clear sky view angle.
    potE (float): Potential evaporation.
    potET (float): Potential evapotranspiration.
    tMean (float): Mean temperature in degrees Celsius.
    
    Returns:
    float: Net radiation (SW and LW) for timestep (MJ).
    """
    EMISSIVITYsurface:float = 0.96  # Campbell Eqn. 12.1
    w2MJ:float = internalTimeStep / 1000000.0
    SURFACEnode:int = 1

    # Eqns 12.2 & 12.3: Atmospheric emissivity
    emissivityAtmos: float = (1 - 0.84 * cloudFr) * 0.58 * pow(cva, (1.0 / 7.0)) + 0.84 * cloudFr

    # Penetration constant using Soilwat algorithm
    PenetrationConstant: float = Divide(max(0.1, potE), max(0.1, potET), 0.0)

    # Longwave radiation incoming and outgoing at the soil surface
    lwRinSoil: float = longWaveRadn(emissivityAtmos, tMean) * PenetrationConstant * w2MJ
    lwRoutSoil: float = longWaveRadn(EMISSIVITYsurface, soilTemp[SURFACEnode]) * PenetrationConstant * w2MJ

    # Net longwave radiation at the soil surface
    lwRnetSoil: float = lwRinSoil - lwRoutSoil

    # Shortwave radiation incoming and outgoing at the soil surface
    swRin: float = solarRadiation
    swRout: float = albedo * solarRadiation

    # Net shortwave radiation at the soil surface
    swRnetSoil: float = (swRin - swRout) * PenetrationConstant

    # Total net radiation (SW and LW)
    total:float = swRnetSoil + lwRnetSoil
    return total

def airDensity(temperature: float, AirPressure: float) -> float:
    """
    Calculate the density of air (kg/m³) at a given temperature and pressure.
    
    Parameters:
    temperature (float): Temperature in degrees Celsius.
    AirPressure (float): Air pressure in hPa (hectopascals).
    
    Returns:
    float: The density of air in kg/m³.
    """
    MWair:float = 0.02897  # Molecular weight of air (kg/mol)
    RGAS:float = 8.3143  # Universal gas constant (J/mol/K)
    HPA2PA:float = 100.0  # Conversion factor from hPa to Pascals
    
    kelvinTemp:float = kelvinT(temperature)
    res:float = Divide(MWair * AirPressure * HPA2PA, kelvinTemp * RGAS, 0.0)
    return res

def boundaryLayerConductanceF(TNew_zb: 'Array[float]', 
                              tMean: float, 
                              potE: float, 
                              potET: float, 
                              airPressure: float, 
                              canopyHeight: float,
                              windSpeed:float,
                              instrumentHeight: float
                              ) -> float:
    """
    Calculate atmospheric boundary layer conductance.
    
    Parameters:
    TNew_zb (list): Surface temperature profile.
    tMean (float): Mean air temperature (°C).
    potE (float): Potential evaporation.
    potET (float): Potential evapotranspiration.
    
    Returns:
    float: Thermal conductivity of the surface layer (W/m²/K).
    """
    # Constants
    VONK: float = 0.41  # von Karman's constant
    GRAVITATIONALconst: float = 9.8  # Gravitational constant (m/s²)
    specificHeatOfAir: float = 1010.0  # Specific heat of air at constant pressure (J/kg/K)
    EMISSIVITYsurface: float = 0.98  # Surface emissivity

    SURFACEnode: int = 1
    STEFAN_BOLTZMANNconst: float = 0.0000000567  # Stefan-Boltzmann constant in W/m^2K^4

    SpecificHeatAir: float = specificHeatOfAir * airDensity(tMean, airPressure)  # Volumetric specific heat of air (J/m³/K)
    
    # Roughness and zero-plane displacement
    RoughnessFacMomentum: float = 0.13 * canopyHeight  # Surface roughness factor for momentum
    RoughnessFacHeat: float = 0.2 * RoughnessFacMomentum  # Surface roughness factor for heat
    d: float = 0.77 * canopyHeight  # Zero-plane displacement
    
    SurfaceTemperature: float = TNew_zb[SURFACEnode]  # Surface temperature (°C)
    
    # Diffuse penetration constant
    PenetrationConstant: float = max(0.1, potE) / max(0.1, potET)
    
    # Radiative conductance
    kelvinTemp:float = kelvinT(tMean)
    radiativeConductance: float = 4.0 * STEFAN_BOLTZMANNconst * EMISSIVITYsurface * PenetrationConstant * pow(kelvinTemp, 3)
    
    # Initialize variables
    FrictionVelocity: float = 0.0
    BoundaryLayerCond: float = 0.0
    StabilityParam: float = 0.0
    StabilityCorMomentum: float = 0.0
    StabilityCorHeat: float = 0.0
    HeatFluxDensity: float = 0.0
    
    # Iterative calculation for boundary layer conductance
    iteration: int = 1
    for iteration in range(1, 4):
        FrictionVelocity = Divide(windSpeed * VONK, log(Divide(instrumentHeight - d + RoughnessFacMomentum, RoughnessFacMomentum, 0.0)) + StabilityCorMomentum, 0.0)
        
        BoundaryLayerCond = Divide(SpecificHeatAir * VONK * FrictionVelocity, log(Divide(instrumentHeight - d + RoughnessFacHeat, RoughnessFacHeat, 0.0)) + StabilityCorHeat, 0.0)
        BoundaryLayerCond = BoundaryLayerCond + radiativeConductance  # Add radiative conductance
        
        HeatFluxDensity = BoundaryLayerCond * (SurfaceTemperature - tMean)
        
        # Stability parameter (Eqn 12.14)
        StabilityParam = Divide(-VONK * instrumentHeight * GRAVITATIONALconst * HeatFluxDensity, SpecificHeatAir * kelvinTemp * pow(FrictionVelocity, 3), 0.0)
        
        # Stability correction (Eqns 12.15 - 12.17)
        if StabilityParam > 0.0:
            StabilityCorHeat = 4.7 * StabilityParam
            StabilityCorMomentum = StabilityCorHeat
        else:
            StabilityCorHeat = -2.0 * log((1.0 + sqrt(1.0 - 16.0 * StabilityParam)) / 2.0)
            StabilityCorMomentum = 0.6 * StabilityCorHeat

    return BoundaryLayerCond


def doThomas(newTemps: 'Array[float]', 
             soilTemp: 'Array[float]',
             thermalConductivity: 'Array[float]',
             thermalConductance:'Array[float]',
             depth: 'Array[float]',
             volSpecHeatSoil: 'Array[float]',
             gDt: float,
             netRadiation: float, 
             potE:float, actE: float, numNodes: int, netRadiationSource:str) -> 'Array[float]':
    """
    Numerical solution of the differential equations. Solves the
    tri_diagonal matrix using the Thomas algorithm.

    Based on Thomas, L.H. (1946) "Elliptic problems in linear difference equations over a network"
    Watson Sci Comput. Lab. Report., (Columbia University, New York).
    
    Remarks:
        This method uses John Hargreaves' version from Campbell Program 4.1.

        - The Thomas algorithm is used to solve the tridiagonal system.
        - The boundary conditions are accounted for at the soil surface and at the bottom of the soil column.
        - The function calculates coefficients for intermediate nodes and updates soil temperature values.
    """    
    nu: float = 0.6  
    AIRnode: int = 0  # Example node for air node
    SURFACEnode: int = 1  # Example value for surface node
    MJ2J: float = 1000000.0 # Megajoules to joules conversion factor
    latentHeatOfVapourisation: float = 2465000.0  # Latent heat of vaporization of water (J/kg)
    tempStepSec: float = 24.0 * 60.0 * 60.0
    heatStorage: 'Array[float]' 
    heatStorage = [0.] * (numNodes + 1)  # Array for heat storage
    VolSoilAtNode: float
    elementLength: float
    g: float = 1 - nu
    sensibleHeatFlux: float
    RadnNet: float
    LatentHeatFlux: float
    SoilSurfaceHeatFlux: float

    a: 'Array[float]'  # Thermal conductance at next node
    b: 'Array[float]'  # Heat storage at node
    c: 'Array[float]'  # Thermal conductance at node
    d: 'Array[float]'  # Heat flux at node
    a = [0.0] * (numNodes + 2)  # Thermal conductance at next node
    b = [0.0] * (numNodes + 1)  # Heat storage at node
    c = [0.0] * (numNodes + 1)  # Thermal conductance at node
    d = [0.0] * (numNodes + 1)  # Heat flux at node

    thermalConductance = [0.] * (numNodes+1)

    thermalConductance[AIRnode] = thermalConductivity[AIRnode]

    node : int = SURFACEnode
    for node in range(SURFACEnode, numNodes + 1):
        VolSoilAtNode = 0.5 * (depth[node + 1] - depth[node - 1])
        heatStorage[node] = Divide(volSpecHeatSoil[node] * VolSoilAtNode, gDt, 0.0)
        elementLength = depth[node + 1] - depth[node]
        thermalConductance[node] = Divide(thermalConductivity[node], elementLength, 0.0)

    for node in range(SURFACEnode, numNodes + 1):
        c[node] = (-nu) * thermalConductance[node]
        a[node + 1] = c[node]
        b[node] = nu * (thermalConductance[node] + thermalConductance[node - 1]) + heatStorage[node]
        d[node] = g * thermalConductance[node - 1] * soilTemp[node - 1] + (heatStorage[node] - g * (thermalConductance[node] + thermalConductance[node - 1])) * soilTemp[node] + g * thermalConductance[node] * soilTemp[node + 1]

    a[SURFACEnode] = 0.0

    sensibleHeatFlux = nu * thermalConductance[AIRnode] * newTemps[AIRnode]

    RadnNet = 0.0
    if netRadiationSource == 'calc':
        RadnNet = Divide(netRadiation * 1000000.0, gDt, 0.0)
    elif netRadiationSource == 'eos':
        RadnNet = Divide(potE * latentHeatOfVapourisation, tempStepSec, 0.0)

    LatentHeatFlux = Divide(actE * latentHeatOfVapourisation, tempStepSec, 0.0)
    SoilSurfaceHeatFlux = sensibleHeatFlux + RadnNet - LatentHeatFlux
    d[SURFACEnode] = d[SURFACEnode] + SoilSurfaceHeatFlux

    d[numNodes] = d[numNodes] + (nu * thermalConductance[numNodes] * newTemps[numNodes + 1])

    for node in range(SURFACEnode, numNodes):
        c[node] = Divide(c[node], b[node], 0.0)
        d[node] = Divide(d[node], b[node], 0.0)
        b[node + 1] = b[node + 1] - (a[node + 1] * c[node])
        d[node + 1] = d[node + 1] - (a[node + 1] * d[node])

    newTemps[numNodes] = Divide(d[numNodes], b[numNodes], 0.0)

    for node in range(numNodes - 1, SURFACEnode - 1, -1):
        newTemps[node] = d[node] - c[node] * newTemps[node + 1]

    return newTemps

def doUpdate(tempNew: 'Array[float]',
             soilTemp: 'Array[float]',
             minSoilTemp: 'Array[float]',
             maxSoilTemp: 'Array[float]',
             aveSoilTemp: 'Array[float]',
             thermalConductivity: 'Array[float]',
             boundaryLayerConductance: float,
             IterationsPerDay: int, 
             timeOfDaySecs: float,
             gDt: float,
             numNodes: int):
    """
    Determine min, max, and average soil temperature from the half-hourly iterations.
    
    Returns:
        None: The function modifies the global min, max, and average soil temperature arrays.
    """
    SURFACEnode: int = 1  # Example value for surface node
    AIRnode: int = 0  # Example value for surface node
    node: int = 1

    # Now transfer to old temperature array
    for node in range(len(tempNew)):
        soilTemp[node] = tempNew[node]
    

    # Initialize the min & max to soil temperature if this is the first iteration
    if timeOfDaySecs < gDt * 1.2:
        for node in range(SURFACEnode, numNodes + 1):
            minSoilTemp[node] = soilTemp[node]
            maxSoilTemp[node] = soilTemp[node]

    for node in range(SURFACEnode, numNodes + 1):
        if soilTemp[node] < minSoilTemp[node]:
            minSoilTemp[node] = soilTemp[node]
        elif soilTemp[node] > maxSoilTemp[node]:
            maxSoilTemp[node] = soilTemp[node]
        aveSoilTemp[node] = aveSoilTemp[node] + (Divide(soilTemp[node], float(IterationsPerDay), 0.0))

    boundaryLayerConductance = boundaryLayerConductance + (Divide(thermalConductivity[AIRnode], float(IterationsPerDay), 0.0))
    return soilTemp, boundaryLayerConductance

