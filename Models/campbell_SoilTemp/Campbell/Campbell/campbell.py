# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

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
    airPressure: float,
    canopyHeight: float,
    SALB: float,
    SRAD: float,
    ESP: float,
    ES: float,
    EOAD: float,
    ESAD: float,    
    soilTemp: 'Array[float]',
    thermalCondPar1: 'Array[float]',
    thermalCondPar2: 'Array[float]',
    thermalCondPar3: 'Array[float]',
    thermalCondPar4: 'Array[float]',
    maxTempYesterday: float,
    minTempYesterday: float
    ):

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
    thermalCondPar1 : 'Array[float]' = []
    thermalCondPar2 : 'Array[float]' = []
    thermalCondPar3 : 'Array[float]' = []
    thermalCondPar4 : 'Array[float]' = []
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


    thermalCondPar1,thermalCondPar2,thermalCondPar3,thermalCondPar4 = doThermalConductivityCoeffs(NLAYR, numNodes, bulkDensity, clay)

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
            maxTempYesterday,
            minTempYesterday,
            minSoilTemp,
            maxSoilTemp,
            aveSoilTemp,
            morningSoilTemp,
            tempNew,
            heatCapacity,
            thermalCondPar1,
            thermalCondPar2,
            thermalCondPar3,
            thermalCondPar4,
            thermalConductivity,
            thermalConductance,
            heatStorage,
            airPressure)
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
    DOY: int,
    airPressure: float,
    canopyHeight: float,
    SALB: float,
    SRAD: float,
    ESP: float,
    ES: float,
    EOAD: float,
    ESAD: float,    
    soilTemp: 'Array[float]',
    thermalCondPar1: 'Array[float]',
    thermalCondPar2: 'Array[float]',
    thermalCondPar3: 'Array[float]',
    thermalCondPar4: 'Array[float]',
    maxTempYesterday: float,
    minTempYesterday: float
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
         * name: THICK
               ** description : APSIM soil layer depths as thickness of layers
               ** inputtype : parameter
               ** parametercategory : constant
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max :
               ** min : 1
               ** default : 5
               ** unit : mm 
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
               ** parametercategory : constant
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
               ** datatype : INT
               ** max : 366
               ** min : 0
               ** default : 0
               ** unit : dimensionless
        * name: airPressure
               ** description : Air pressure
               ** inputtype : variable
               ** variablecategory : state
               ** datatype : DOUBLE
               ** max : 
               ** min : 
               ** default : 
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
               ** parametercategory : constant
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
               ** min : 0
               ** default : 
               ** unit : MJ/m2-day
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
        * name: maxTempYesterday
                ** description :  Max temperature at previous day
                ** variablecategory : state
                ** datatype : DOUBLE
                ** min : -60.
                ** max : 60.
                ** unit : degC
                ** uri : 
        * name: minTempYesterday
                ** description :  Min temperature at previous day
                ** variablecategory : state
                ** datatype : DOUBLE
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
        * name: airPressure
                ** description : Air pressure
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLE
                ** max : 
                ** min : 
                ** default : 
                ** unit : hPa
    """

    #%%CyML Compute Begin%%
    
    #soilTemp : 'Array[float]' = []
    minSoilTemp : 'Array[float]' = []
    maxSoilTemp : 'Array[float]' = []
    aveSoilTemp : 'Array[float]' = []
    morningSoilTemp : 'Array[float]' = []
    tempNew : 'Array[float]' = []
    heatCapacity : 'Array[float]' = []
    thermalConductivity : 'Array[float]' = []
    thermalConductance : 'Array[float]' = []
    heatStorage : 'Array[float]' = []
    volSpecHeatSoil : 'Array[float]' = []

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
    tempStepSec: float = 1440.0 * 60.0
    BoundaryLayerConductanceIterations: int  = 1

    cva: float = 0.0
    cloudFr: float = 0.0
    solarRadn: 'Array[float]' = [0.] * 49   # Total incoming short wave solar radiation per timestep
    solarRadn, cloudFr, cva = doNetRadiation(solarRadn, cloudFr, cva, ITERATIONSperDAY, DOY, SRAD, TMIN, XLAT)

    # zero the temperature profiles
    Zero(minSoilTemp)
    Zero(maxSoilTemp)
    Zero(aveSoilTemp)
    _boundaryLayerConductance: float = 0.0

    # calc dt
    gDt: float = tempStepSec / float(ITERATIONSperDAY)

    # These two call used to be inside the timestep loop. I've taken them outside,
    # as the results do not appear to vary over the course of the day.
    # The results would vary if soil water content were to vary, so if future versions
    # to more communication within subday time steps, these may need to be moved
    # back into the loop. EZJ March 2014
    soilWater: 'Array[float]' = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)

    copyLength: int = min(NLAYR + 1 + NUM_PHANTOM_NODES, len(SW))
    soilWater[:copyLength] = SW[:copyLength]     # SW dimensioned for layers 1 to gNumlayers + extra for zone below bottom layer

    layer: int = 0
    for layer in range(NLAYR + 1, NLAYR + 1 + NUM_PHANTOM_NODES + 1):
        soilWater[layer] = soilWater[NLAYR]

    numNodes: int = NLAYR + NUM_PHANTOM_NODES
    volSpecHeatSoil = doVolumetricSpecificHeat(soilWater, BD, NLAYR)      # RETURNS volSpecHeatSoil() (volumetric heat capacity of nodes)
    thermalConductivity = doThermConductivityCampbell(soilWater,
                                thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4,
                                thermalConductivity, THICK, DEPTH, numNodes)     # RETURNS gThermConductivity_zb()

    timeStepIteration: int = 1
    for timeStepIteration in range(1, ITERATIONSperDAY+1):
        timeOfDaySecs: float = gDt * float(timeStepIteration)
        tMean: float
        if (tempStepSec < DAYsecs):
            tMean = 0.5 * (TMAX + TMIN)
        else:
            tMean = InterpTemp(timeOfDaySecs * SEC2HR, TMAX, TMIN, maxTempYesterday, minTempYesterday)
        tempNew[AIRnode] = tMean

        netRadiation: float = RadnNetInterpolate(solarRadn[timeStepIteration], 
                                                 cloudFr, cva, ESAD, EOAD, tMean, SALB, gDt, soilTemp)


        thermalConductivity[AIRnode] = boundaryLayerConductanceF(tempNew, tMean, ESAD, EOAD, airPressure, canopyHeight)
    
        #####

        # Iteratively update thermal conductivity and temperature using boundary layer conductance
        iteration: int= 1
        for iteration in range(1, BoundaryLayerConductanceIterations + 1):
            tempNew = doThomas(tempNew, soilTemp, 
                        thermalConductivity, DEPTH, 
                        volSpecHeatSoil, 
                        gDt,
                        netRadiation, 
                        ES,
                        numNodes)  # Update tempNew
            thermalConductivity[AIRnode] = boundaryLayerConductanceF(tempNew, tMean, potE, potET, airPressure, canopyHeight)
        
        # Final calculation with updated boundary layer conductance
        tempNew = doThomas(tempNew, soilTemp, 
                        thermalConductivity, DEPTH, 
                        volSpecHeatSoil, 
                        gDt,
                        netRadiation, 
                        ES,
                        numNodes) # Update tempNew again
        soilTemp, _boundaryLayerConductance = doUpdate(tempNew, 
                 soilTemp,
                 minSoilTemp, 
                 maxSoilTemp,
                 aveSoilTemp,
                 thermalConductivity,
                 _boundaryLayerConductance,
                 ITERATIONSperDAY, 
                 timeOfDaySecs,
                 gDt,
                 numNodes)
        
        # Check for precision and update morning soil temperature
        precision: float = min(timeOfDaySecs, 5.0 * HR2MIN * MIN2SEC) * 0.0001
        if abs(timeOfDaySecs - 5.0 * HR2MIN * MIN2SEC) <= precision:
            morningSoilTemp[:] = soilTemp[:]  # Copy soilTemp to morningSoilTemp
        
        # Update previous day's minimum and maximum temperatures
        minTempYesterday = TMIN
        maxTempYesterday = TMAX

    #%%CyML Compute End%%
    
    return (soilTemp,
            maxTempYesterday,
            minTempYesterday,
            minSoilTemp,
            maxSoilTemp,
            aveSoilTemp,
            morningSoilTemp,
            tempNew,
            heatCapacity,
            thermalCondPar1,
            thermalCondPar2,
            thermalCondPar3,
            thermalCondPar4,
            thermalConductivity,
            thermalConductance,
            heatStorage,
            airPressure)
#%%CyML Model End%%


def doThermalConductivityCoeffs(nbLayers:int, 
                                numNodes:int,
                                bulkDensity: 'Array[float]',
                                clay: 'Array[float]'):

    thermalCondPar1 : 'Array[float]' = []
    thermalCondPar2 : 'Array[float]' = []
    thermalCondPar3 : 'Array[float]' = []
    thermalCondPar4 : 'Array[float]' = []
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
    
    DAYSinYear: float = 365.25
    DAYhrs: float = 24.0
    MIN2SEC: float = 60.0
    HR2MIN: float = 60.0
    SEC2HR: float = 1.0 / (HR2MIN * MIN2SEC)
    DAYmins: float = DAYhrs * HR2MIN
    DAYsecs: float = DAYmins * MIN2SEC
    PA2HPA: float  = 1.0 / 100.0
    MJ2J: float = 1000000.0
    J2MJ: float = 1.0 / MJ2J
    DEG2RAD: float = pi / 180.0
    DOY2RAD: float = DEG2RAD * 360.0 / DAYSinYear
    TSTEPS2RAD: float = Divide(DEG2RAD * 360., float(ITERATIONSperDAY), 0.0)          # convert timestep of day to radians

    SOLARconst: float = 1360.0     # W/M^2
    solarDeclination: float = 0.3985 * sin(4.869 + doy * DOY2RAD + 0.03345 * sin(6.224 + doy * DOY2RAD))
    cD: float = sqrt(1.0 - solarDeclination * solarDeclination)
    m1: 'Array[float]' = [0.]*(ITERATIONSperDAY + 1)
    m1Tot: float = 0.0
    W2MJ: float
    psr: float

    timestepNumber: int =1
    for timestepNumber in range(1, ITERATIONSperDAY+1):
        m1[timestepNumber] = ((solarDeclination * sin(latitude * DEG2RAD) + cD * cos(latitude * DEG2RAD) *
            cos(TSTEPS2RAD * (float(timestepNumber) - float(ITERATIONSperDAY) / 2.0))) * 
            24.0 / float(ITERATIONSperDAY))
        if (m1[timestepNumber] > 0.0):
            m1Tot = m1Tot + m1[timestepNumber]
        else:
            m1[timestepNumber] = 0.0

    W2MJ = HR2MIN * MIN2SEC * J2MJ      # convert w to mj
    psr = m1Tot * SOLARconst * W2MJ   # potential solar radiation for the day (mj/m^2)
    fr: float 
    fr = Divide(max(rad, 0.1), psr, 0.0)               # ratio of potential to measured daily solar radiation (0-1)
    cloudFr = 2.33 - 3.33 * fr    # fractional cloud cover (0-1)
    if (cloudFr < 0.0):
        cloudFr = 0.0
    elif (cloudFr > 1.0): 
        cloudFr = 1.0

    for  timestepNumber in range(1, ITERATIONSperDAY+1):
        solarRadn[timestepNumber] = max(rad, 0.1) * Divide(m1[timestepNumber], m1Tot, 0.0)

    # cva is vapour concentration of the air (g/m^3)
    kelvinTemp:float = kelvinT(tmin)
    cva = exp(31.3716 - 6014.79 / kelvinTemp - 0.00792495 * kelvinTemp) / kelvinTemp

    return solarRadn, cloudFr, cva

def kelvinT(celciusT: float):
    """ Convert deg Celcius to deg Kelvin.
    """
    ZEROTkelvin: float = 273.18
    return celciusT + ZEROTkelvin

def Zero( arr: 'Array[float]'):
    "Zero the specified array."
    i: int = 0
    for i in range(len(arr)):
        arr[i] = 0.

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
    M2MM: float = 1000.0

    node: int = 0
    i: int = 0
    layer: int

    for node in range(SURFACEnode, numNodes + 1):
        layer = node - 1  # Node n lies at the center of layer n-1
        depthLayerAbove: float = 0.0

        if layer >= 1:
            for i in range(1, layer + 1):
                depthLayerAbove += thickness[i]

        d1:float = depthLayerAbove - (depth[node] * M2MM)
        d2:float = depth[node + 1] * M2MM - depthLayerAbove
        dSum:float = d1 + d2

        if dSum != 0.0:
            nodeArray[node] = (layerArray[layer] * d1 / dSum) + (layerArray[layer + 1] * d2 / dSum)
        else:
            nodeArray[node] = 0  # To prevent division by zero

    return nodeArray

    
def doVolumetricSpecificHeat(soilW: 'Array[float]', bulkDensity: 'Array[float]', numLayers: int) -> 'Array[float]':
    """
    Calculate the volumetric specific heat (volumetric heat capacity Cv) of the soil layer.
    Based on Campbell, G.S. (1985) "Soil physics with BASIC: Transport models for soil-plant systems".

    Parameters:
    soilW (list[float]): Soil water content by layer.
    bulkDensity (list[float]): Bulk density by layer.
    numLayers (int): Number of soil layers.
    volSpecHeatClay (float): Volumetric specific heat of clay.
    volSpecHeatWater (float): Volumetric specific heat of water.

    Returns:
    list[float]: Volumetric specific heat of the soil layers (Cv) [Joules*m-3*K-1].
    """
    SPECIFICbd: float = 2.65  # Specific bulk density (g/cc)
    volSpecHeatClay: float = 2.39e6  # [Joules*m-3*K-1]
    volSpecHeatWater: float = 4.18e6       # [Joules*m-3*K-1]

    volSpecHeatSoil: 'Array[float]' = [0.0] * (numLayers + 1)

    layer:int
    for layer in range(1, numLayers + 1):
        solidity:float = bulkDensity[layer] / SPECIFICbd
        volSpecHeatSoil[layer] = volSpecHeatClay * solidity + volSpecHeatWater * soilW[layer]

    # Assume surface node Cv is the same as top layer Cv
    volSpecHeatSoil[0] = volSpecHeatSoil[1]  # Surface node Cv is the same as top layer Cv
    return volSpecHeatSoil


def doThermConductivityCampbell(soilW: 'Array[float]', 
                                thermalCondPar1: 'Array[float]', thermalCondPar2: 'Array[float]', thermalCondPar3: 'Array[float]', thermalCondPar4: 'Array[float]', 
                                thermalConductivity: 'Array[float]', thickness: 'Array[float]', depth: 'Array[float]',
                                numNodes: int) -> 'Array[float]':
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
    thermCondLayers: 'Array[float]' = [0.0] * (numNodes + 1)

    layer: int = 1
    for layer in range(1, numNodes + 1):
        temp:float = pow((thermalCondPar3[layer] * soilW[layer]), 4) * (-1.0)
        thermCondLayers[layer] = thermalCondPar1[layer] + (thermalCondPar2[layer] * soilW[layer]) - (thermalCondPar1[layer] - thermalCondPar4[layer]) * exp(temp)

    # Map thermal conductivity layers to nodes
    thermalConductivity = mapLayer2Node(thermCondLayers, thermalConductivity, thickness, depth, numNodes)
    return thermalConductivity

def InterpTemp(time_hours: float, tmax: float, tmin: float, max_temp_yesterday: float, min_temp_yesterday: float):
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
    DAYhrs: float = 24.0

    # Convert current time and times for max and min temperatures to fractions of a day
    time: float = time_hours / DAYhrs  # Current time as a fraction of the day
    max_t_time: float = tmax / DAYhrs  # Time of max temperature as a fraction of the day
    min_t_time: float = max_t_time - 0.5  # Time of minimum temperature, 12 hours before max temp
    current_temp: float
    if time < min_t_time:
        # Before the time of minimum temperature
        midnight_temp: float = (sin((0.0 + 0.25 - max_t_time) * 2.0 * pi) 
                               * (max_temp_yesterday - min_temp_yesterday) / 2.0 
                               + (max_temp_yesterday + min_temp_yesterday) / 2.0)
        t_scale: float = (min_t_time - time) / min_t_time

        # Ensure t_scale is within bounds (0 <= t_scale <= 1)
        t_scale = max(0, min(t_scale, 1))

        current_temp = tmin + t_scale * (midnight_temp - tmin)
    
    else:
        # At or after the time of minimum temperature
        current_temp = (sin((time + 0.25 - max_t_time) * 2.0 * pi) 
                              * (tmax - tmin) / 2.0 
                              + (tmax + tmin) / 2.0 )
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
    STEFAN_BOLTZMANNconst: float = 5.67e-8  # stefan-boltzmann constant in w/m^2k^4
    kelvinTemp:float = kelvinT(tDegC)
    res:float = STEFAN_BOLTZMANNconst * emissivity * (kelvinTemp ** 4)
    return res

def RadnNetInterpolate(solarRadn: float, cloudFr: float, cva: float, potE: float, potET: float, tMean: float, albedo: float, gDt: float, soilTemp: 'Array[float]'):
    """
    Calculate the net radiation at the soil surface.
    
    Parameters:
    solarRadn (float): Incoming solar radiation.
    cloudFr (float): Cloud fraction.
    cva (float): Clear sky view angle.
    potE (float): Potential evaporation.
    potET (float): Potential evapotranspiration.
    tMean (float): Mean temperature in degrees Celsius.
    
    Returns:
    float: Net radiation (SW and LW) for timestep (MJ).
    """
    EMISSIVITYsurface:float = 0.96  # Campbell Eqn. 12.1
    MJ2J: float = 1000000.0
    J2MJ: float = 1.0 / MJ2J
    SURFACEnode: int = 1  # Index of surface node 


    # Convert W to MJ
    w2MJ: float = gDt * J2MJ

    # Eqns 12.2 & 12.3: Atmospheric emissivity
    emissivityAtmos: float = (1 - 0.84 * cloudFr) * 0.58 * pow(cva, (1.0 / 7.0)) + 0.84 * cloudFr

    # Penetration constant using Soilwat algorithm
    PenetrationConstant: float = Divide(max(0.1, potE), max(0.1, potET), 0.0)

    # Longwave radiation incoming and outgoing at the soil surface
    lwRinSoil: float = longWaveRadn(emissivityAtmos, tMean) 
    lwRinSoil = lwRinSoil * PenetrationConstant * w2MJ
    lwRoutSoil: float = longWaveRadn(EMISSIVITYsurface, soilTemp[SURFACEnode]) * PenetrationConstant * w2MJ

    # Net longwave radiation at the soil surface
    lwRnetSoil: float = lwRinSoil - lwRoutSoil

    # Shortwave radiation incoming and outgoing at the soil surface
    swRin: float = solarRadn
    swRout: float = albedo * solarRadn

    # Net shortwave radiation at the soil surface
    swRnetSoil: float = (swRin - swRout) * PenetrationConstant

    # Total net radiation (SW and LW)
    return swRnetSoil + lwRnetSoil

def RhoA(temperature: float, AirPressure: float) -> float:
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
    kelvinTemp = kelvinTemp * RGAS
    divide1:float = MWair * AirPressure * HPA2PA
    res:float = Divide(MWair * AirPressure * HPA2PA, kelvinTemp, 0.0)
    return res

def boundaryLayerConductanceF(TNew_zb: 'Array[float]', 
                              tMean: float, 
                              potE: float, 
                              potET: float, 
                              airPressure: float, 
                              canopyHeight: float
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
    CAPP: float = 1010.0  # Specific heat of air at constant pressure (J/kg/K)
    EMISSIVITYsurface: float = 0.98  # Surface emissivity
    SURFACEnode: int = 1
    STEFAN_BOLTZMANNconst: float = 5.67e-8  # Stefan-Boltzmann constant in W/m^2K^4
    windSpeed: float = 259.2
    instrumentHeight: float = 1.2

    SpecificHeatAir: float = CAPP * RhoA(tMean, airPressure)  # Volumetric specific heat of air (J/m³/K)
    
    # Roughness and zero-plane displacement
    RoughnessFacMomentum: float = 0.13 * canopyHeight  # Surface roughness factor for momentum
    RoughnessFacHeat: float = 0.2 * RoughnessFacMomentum  # Surface roughness factor for heat
    d: float = 0.77 * canopyHeight  # Zero-plane displacement
    
    SurfaceTemperature: float = TNew_zb[SURFACEnode]  # Surface temperature (°C)
    
    # Diffuse penetration constant
    PenetrationConstant: float = max(0.1, potE) / max(0.1, potET)
    
    # Radiative conductance
    radiativeConductance: float = 4.0 * STEFAN_BOLTZMANNconst * EMISSIVITYsurface * PenetrationConstant * pow(kelvinT(tMean), 3)
    
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
        BoundaryLayerCond += radiativeConductance  # Add radiative conductance
        
        HeatFluxDensity = BoundaryLayerCond * (SurfaceTemperature - tMean)
        
        # Stability parameter (Eqn 12.14)
        StabilityParam = Divide(-VONK * instrumentHeight * GRAVITATIONALconst * HeatFluxDensity, SpecificHeatAir * kelvinT(tMean) * pow(FrictionVelocity, 3), 0.0)
        
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
             depth: 'Array[float]',
             volSpecHeatSoil: 'Array[float]',
             gDt: float,
             netRadiation: float, 
             actE: float, numNodes: int):
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
    gDt: float = 1.0  # Example value for gDt
    MJ2J: float = 1000000.0 # Megajoules to joules conversion factor
    LAMBDA: float = 2465000.0  # Latent heat of vaporization of water (J/kg)
    tempStepSec: float = 1440.0 * 60.0
    heatStorage: 'Array[float]' = [0] * (numNodes + 1)  # Array for heat storage

    a: 'Array[float]' = [0.0] * (numNodes + 2)  # Thermal conductance at next node
    b: 'Array[float]' = [0.0] * (numNodes + 1)  # Heat storage at node
    c: 'Array[float]' = [0.0] * (numNodes + 1)  # Thermal conductance at node
    d: 'Array[float]' = [0.0] * (numNodes + 1)  # Heat flux at node

    thermalConductance = [0.] * (numNodes+1)

    thermalConductance[AIRnode] = thermalConductivity[AIRnode]

    node : int = SURFACEnode
    for node in range(SURFACEnode, numNodes + 1):
        VolSoilAtNode: float = 0.5 * (depth[node + 1] - depth[node - 1])
        heatStorage[node] = volSpecHeatSoil[node] * VolSoilAtNode / gDt
        elementLength: float = depth[node + 1] - depth[node]
        thermalConductance[node] = thermalConductivity[node] / elementLength

    g: float = 1 - nu
    for node in range(SURFACEnode, numNodes + 1):
        c[node] = (-nu) * thermalConductance[node]
        a[node + 1] = c[node]
        b[node] = nu * (thermalConductance[node] + thermalConductance[node - 1]) + heatStorage[node]
        d[node] = (
            g * thermalConductance[node - 1] * soilTemp[node - 1]
            + (heatStorage[node] - g * (thermalConductance[node] + thermalConductance[node - 1])) * soilTemp[node]
            + g * thermalConductance[node] * soilTemp[node + 1]
        )

    a[SURFACEnode] = 0.0

    sensibleHeatFlux: float = nu * thermalConductance[AIRnode] * newTemps[AIRnode]
    RadnNet: float = netRadiation * MJ2J / gDt
    LatentHeatFlux: float = actE * LAMBDA / tempStepSec
    SoilSurfaceHeatFlux: float = sensibleHeatFlux + RadnNet - LatentHeatFlux
    d[SURFACEnode] += SoilSurfaceHeatFlux

    d[numNodes] += nu * thermalConductance[numNodes] * newTemps[numNodes + 1]

    for node in range(SURFACEnode, numNodes):
        c[node] /= b[node]
        d[node] /= b[node]
        b[node + 1] -= a[node + 1] * c[node]
        d[node + 1] -= a[node + 1] * d[node]

    newTemps[numNodes] = d[numNodes] / b[numNodes]

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

    # Now transfer to old temperature array
    soilTemp[:] = tempNew[:]

    # Initialize the min & max to soil temperature if this is the first iteration
    if timeOfDaySecs < gDt * 1.2:
        node: int = 1
        for node in range(SURFACEnode, numNodes + 1):
            minSoilTemp[node] = soilTemp[node]
            maxSoilTemp[node] = soilTemp[node]

    for node in range(SURFACEnode, numNodes + 1):
        if soilTemp[node] < minSoilTemp[node]:
            minSoilTemp[node] = soilTemp[node]
        elif soilTemp[node] > maxSoilTemp[node]:
            maxSoilTemp[node] = soilTemp[node]
        aveSoilTemp[node] += soilTemp[node] / float(IterationsPerDay)

    boundaryLayerConductance += Divide(thermalConductivity[AIRnode], float(IterationsPerDay), 0.0)
    return soilTemp, boundaryLayerConductance
