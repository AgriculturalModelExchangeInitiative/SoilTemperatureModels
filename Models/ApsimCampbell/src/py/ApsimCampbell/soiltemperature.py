# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Init Begin%%
def init_soiltemperature(weather_MinT:float,
         weather_MaxT:float,
         weather_MeanT:float,
         weather_Tav:float,
         weather_Amp:float,
         weather_AirPressure:float,
         weather_Wind:float,
         weather_Latitude:float,
         weather_Radn:float,
         clock_Today_DayOfYear:int,
         microClimate_CanopyHeight:float,
         physical_Thickness:'Array[float]',
         physical_BD:'Array[float]',
         ps:float,
         physical_Rocks:'Array[float]',
         physical_ParticleSizeSand:'Array[float]',
         physical_ParticleSizeSilt:'Array[float]',
         physical_ParticleSizeClay:'Array[float]',
         organic_Carbon:'Array[float]',
         waterBalance_SW:'Array[float]',
         waterBalance_Eos:float,
         waterBalance_Eo:float,
         waterBalance_Es:float,
         waterBalance_Salb:float,
         pInitialValues:'Array[float]',
         DepthToConstantTemperature:float,
         timestep:float,
         latentHeatOfVapourisation:float,
         stefanBoltzmannConstant:float,
         airNode:int,
         surfaceNode:int,
         topsoilNode:int,
         numPhantomNodes:int,
         constantBoundaryLayerConductance:float,
         numIterationsForBoundaryLayerConductance:int,
         defaultTimeOfMaximumTemperature:float,
         defaultInstrumentHeight:float,
         bareSoilRoughness:float,
         nodeDepth:'Array[float]',
         thermCondPar1:'Array[float]',
         thermCondPar2:'Array[float]',
         thermCondPar3:'Array[float]',
         thermCondPar4:'Array[float]',
         pom:float,
         soilRoughnessHeight:float,
         nu:float,
         boundarLayerConductanceSource:str,
         netRadiationSource:str,
         MissingValue:float,
         soilConstituentNames:'Array[str]'):
    InitialValues:'array[float]'
    doInitialisationStuff:bool = False
    internalTimeStep:float = 0.0
    timeOfDaySecs:float = 0.0
    numNodes:int = 0
    numLayers:int = 0
    volSpecHeatSoil:'array[float]'
    soilTemp:'array[float]'
    morningSoilTemp:'array[float]'
    heatStorage:'array[float]'
    thermalConductance:'array[float]'
    thermalConductivity:'array[float]'
    boundaryLayerConductance:float = 0.0
    newTemperature:'array[float]'
    airTemperature:float = 0.0
    maxTempYesterday:float = 0.0
    minTempYesterday:float = 0.0
    soilWater:'array[float]'
    minSoilTemp:'array[float]'
    maxSoilTemp:'array[float]'
    aveSoilTemp:'array[float]'
    aveSoilWater:'array[float]'
    thickness:'array[float]'
    bulkDensity:'array[float]'
    rocks:'array[float]'
    carbon:'array[float]'
    sand:'array[float]'
    silt:'array[float]'
    clay:'array[float]'
    instrumentHeight:float = 0.0
    netRadiation:float = 0.0
    canopyHeight:float = 0.0
    instrumHeight:float = 0.0
    InitialValues = None
    volSpecHeatSoil = None
    soilTemp = None
    morningSoilTemp = None
    heatStorage = None
    thermalConductance = None
    thermalConductivity = None
    newTemperature = None
    soilWater = None
    minSoilTemp = None
    maxSoilTemp = None
    aveSoilTemp = None
    aveSoilWater = None
    thickness = None
    bulkDensity = None
    rocks = None
    carbon = None
    sand = None
    silt = None
    clay = None
    doInitialisationStuff = True
    instrumentHeight = getIniVariables(instrumentHeight, instrumHeight, defaultInstrumentHeight)
    (heatStorage, minSoilTemp, bulkDensity, maxSoilTemp, nodeDepth, newTemperature, soilWater, thermalConductance, thermalConductivity, sand, carbon, thickness, rocks, clay, soilTemp, silt, volSpecHeatSoil, aveSoilTemp, morningSoilTemp, numNodes, numLayers) = getProfileVariables(heatStorage, minSoilTemp, bulkDensity, numNodes, physical_BD, maxSoilTemp, waterBalance_SW, organic_Carbon, physical_Rocks, nodeDepth, topsoilNode, newTemperature, surfaceNode, soilWater, thermalConductance, thermalConductivity, sand, carbon, thickness, numPhantomNodes, physical_ParticleSizeSand, rocks, clay, physical_ParticleSizeSilt, airNode, physical_ParticleSizeClay, soilTemp, numLayers, physical_Thickness, silt, volSpecHeatSoil, aveSoilTemp, morningSoilTemp, DepthToConstantTemperature, MissingValue)
    (newTemperature, soilTemp, thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1, soilRoughnessHeight) = readParam(bareSoilRoughness, newTemperature, soilRoughnessHeight, soilTemp, thermCondPar2, numLayers, bulkDensity, numNodes, thermCondPar3, thermCondPar4, clay, thermCondPar1, weather_Tav, clock_Today_DayOfYear, surfaceNode, weather_Amp, thickness, weather_Latitude)
    InitialValues = pInitialValues
    return (InitialValues, doInitialisationStuff, internalTimeStep, timeOfDaySecs, numNodes, numLayers, nodeDepth, thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4, volSpecHeatSoil, soilTemp, morningSoilTemp, heatStorage, thermalConductance, thermalConductivity, boundaryLayerConductance, newTemperature, airTemperature, maxTempYesterday, minTempYesterday, soilWater, minSoilTemp, maxSoilTemp, aveSoilTemp, aveSoilWater, thickness, bulkDensity, rocks, carbon, sand, silt, clay, soilRoughnessHeight, instrumentHeight, netRadiation, canopyHeight, instrumHeight)
#%%CyML Init End%%

#%%CyML Model Begin%%
def model_soiltemperature(weather_MinT:float,
         weather_MaxT:float,
         weather_MeanT:float,
         weather_Tav:float,
         weather_Amp:float,
         weather_AirPressure:float,
         weather_Wind:float,
         weather_Latitude:float,
         weather_Radn:float,
         clock_Today_DayOfYear:int,
         microClimate_CanopyHeight:float,
         physical_Thickness:'Array[float]',
         physical_BD:'Array[float]',
         ps:float,
         physical_Rocks:'Array[float]',
         physical_ParticleSizeSand:'Array[float]',
         physical_ParticleSizeSilt:'Array[float]',
         physical_ParticleSizeClay:'Array[float]',
         organic_Carbon:'Array[float]',
         waterBalance_SW:'Array[float]',
         waterBalance_Eos:float,
         waterBalance_Eo:float,
         waterBalance_Es:float,
         waterBalance_Salb:float,
         InitialValues:'Array[float]',
         pInitialValues:'Array[float]',
         DepthToConstantTemperature:float,
         timestep:float,
         latentHeatOfVapourisation:float,
         stefanBoltzmannConstant:float,
         airNode:int,
         surfaceNode:int,
         topsoilNode:int,
         numPhantomNodes:int,
         constantBoundaryLayerConductance:float,
         numIterationsForBoundaryLayerConductance:int,
         defaultTimeOfMaximumTemperature:float,
         defaultInstrumentHeight:float,
         bareSoilRoughness:float,
         doInitialisationStuff:bool,
         internalTimeStep:float,
         timeOfDaySecs:float,
         numNodes:int,
         numLayers:int,
         nodeDepth:'Array[float]',
         thermCondPar1:'Array[float]',
         thermCondPar2:'Array[float]',
         thermCondPar3:'Array[float]',
         thermCondPar4:'Array[float]',
         volSpecHeatSoil:'Array[float]',
         soilTemp:'Array[float]',
         morningSoilTemp:'Array[float]',
         heatStorage:'Array[float]',
         thermalConductance:'Array[float]',
         thermalConductivity:'Array[float]',
         boundaryLayerConductance:float,
         newTemperature:'Array[float]',
         airTemperature:float,
         maxTempYesterday:float,
         minTempYesterday:float,
         soilWater:'Array[float]',
         minSoilTemp:'Array[float]',
         maxSoilTemp:'Array[float]',
         aveSoilTemp:'Array[float]',
         aveSoilWater:'Array[float]',
         thickness:'Array[float]',
         bulkDensity:'Array[float]',
         rocks:'Array[float]',
         carbon:'Array[float]',
         sand:'Array[float]',
         pom:float,
         silt:'Array[float]',
         clay:'Array[float]',
         soilRoughnessHeight:float,
         instrumentHeight:float,
         netRadiation:float,
         canopyHeight:float,
         instrumHeight:float,
         nu:float,
         boundarLayerConductanceSource:str,
         netRadiationSource:str,
         MissingValue:float,
         soilConstituentNames:'Array[str]'):
    """
     - Name: SoilTemperature -Version:  1.0, -Time step:  1
     - Description:
                 * Title: SoilTemperature
                 * Authors: APSIM
                 * Reference: None
                 * Institution: APSIM Initiative
                 * ExtendedDescription:  Soil Temperature 
                 * ShortDescription: Heat flux and temperatures over the surface and soil profile (based on Campbell, 1985)
     - inputs:
                 * name: weather_MinT
                               ** description : Minimum temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
                 * name: weather_MaxT
                               ** description : Maximum temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
                 * name: weather_MeanT
                               ** description : Mean temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
                 * name: weather_Tav
                               ** description : Annual average temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
                 * name: weather_Amp
                               ** description : Annual average temperature amplitude
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
                 * name: weather_AirPressure
                               ** description : Air pressure
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : hPa
                 * name: weather_Wind
                               ** description : Wind speed
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : m/s
                 * name: weather_Latitude
                               ** description : Latitude
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : deg
                 * name: weather_Radn
                               ** description : Solar radiation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : MJ/m2/day
                 * name: clock_Today_DayOfYear
                               ** description : Day of year
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : day number
                 * name: microClimate_CanopyHeight
                               ** description : Canopy height
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: physical_Thickness
                               ** description : Soil layer thickness
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: physical_BD
                               ** description : Bulk density
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : g/cc
                 * name: ps
                               ** description : ps
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : 
                 * name: physical_Rocks
                               ** description : Rocks
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : %
                 * name: physical_ParticleSizeSand
                               ** description : Particle size sand
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : %
                 * name: physical_ParticleSizeSilt
                               ** description : Particle size silt
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : %
                 * name: physical_ParticleSizeClay
                               ** description : Particle size clay
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : %
                 * name: organic_Carbon
                               ** description : Total organic carbon
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : %
                 * name: waterBalance_SW
                               ** description : Volumetric water content
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm/mm
                 * name: waterBalance_Eos
                               ** description : Potential soil evaporation from soil surface
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: waterBalance_Eo
                               ** description : Potential soil evapotranspiration from soil surface
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: waterBalance_Es
                               ** description : Actual (realised) soil water evaporation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: waterBalance_Salb
                               ** description : Fraction of incoming radiation reflected from bare soil
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : 0-1
                 * name: InitialValues
                               ** description : Initial soil temperature
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
                 * name: pInitialValues
                               ** description : Initial soil temperature
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
                 * name: DepthToConstantTemperature
                               ** description : Soil depth to constant temperature
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 10000
                               ** unit : mm
                 * name: timestep
                               ** description : Internal time-step (minutes)
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 24.0 * 60.0 * 60.0
                               ** unit : minutes
                 * name: latentHeatOfVapourisation
                               ** description : Latent heat of vapourisation for water
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 2465000
                               ** unit : miJ/kg
                 * name: stefanBoltzmannConstant
                               ** description : The Stefan-Boltzmann constant
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0000000567
                               ** unit : W/m2/K4
                 * name: airNode
                               ** description : The index of the node in the atmosphere (aboveground)
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : 
                 * name: surfaceNode
                               ** description : The index of the node on the soil surface (depth = 0)
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 1
                               ** unit : 
                 * name: topsoilNode
                               ** description : The index of the first node within the soil (top layer)
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 2
                               ** unit : 
                 * name: numPhantomNodes
                               ** description : The number of phantom nodes below the soil profile
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 5
                               ** unit : 
                 * name: constantBoundaryLayerConductance
                               ** description : Boundary layer conductance, if constant
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 20
                               ** unit : K/W
                 * name: numIterationsForBoundaryLayerConductance
                               ** description : Number of iterations to calculate atmosphere boundary layer conductance
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** min : 
                               ** default : 1
                               ** unit : 
                 * name: defaultTimeOfMaximumTemperature
                               ** description : Time of maximum temperature
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 14.0
                               ** unit : minutes
                 * name: defaultInstrumentHeight
                               ** description : Default instrument height
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 1.2
                               ** unit : m
                 * name: bareSoilRoughness
                               ** description : Roughness element height of bare soil
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 57
                               ** unit : mm
                 * name: doInitialisationStuff
                               ** description : Flag whether initialisation is needed
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : BOOLEAN
                               ** max : 
                               ** min : 
                               ** default : false
                               ** unit : mintes
                 * name: internalTimeStep
                               ** description : Internal time-step
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : sec
                 * name: timeOfDaySecs
                               ** description : Time of day from midnight
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : sec
                 * name: numNodes
                               ** description : Number of nodes over the soil profile
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : 
                 * name: numLayers
                               ** description : Number of layers in the soil profile
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : 
                 * name: nodeDepth
                               ** description : Depths of nodes
                               ** inputtype : parameter
                               ** parametercategory : private
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: thermCondPar1
                               ** description : Parameter 1 for computing thermal conductivity of soil solids
                               ** inputtype : parameter
                               ** parametercategory : private
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : 
                 * name: thermCondPar2
                               ** description : Parameter 2 for computing thermal conductivity of soil solids
                               ** inputtype : parameter
                               ** parametercategory : private
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : 
                 * name: thermCondPar3
                               ** description : Parameter 3 for computing thermal conductivity of soil solids
                               ** inputtype : parameter
                               ** parametercategory : private
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : 
                 * name: thermCondPar4
                               ** description : Parameter 4 for computing thermal conductivity of soil solids
                               ** inputtype : parameter
                               ** parametercategory : private
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : 
                 * name: volSpecHeatSoil
                               ** description : Volumetric specific heat over the soil profile
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : J/K/m3
                 * name: soilTemp
                               ** description : Soil temperature over the soil profile at morning
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
                 * name: morningSoilTemp
                               ** description : Soil temperature over the soil profile at morning
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
                 * name: heatStorage
                               ** description : CP, heat storage between nodes
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : J/K
                 * name: thermalConductance
                               ** description : K, conductance of element between nodes
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : W/K
                 * name: thermalConductivity
                               ** description : Thermal conductivity
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : W.m/K
                 * name: boundaryLayerConductance
                               ** description : Average daily atmosphere boundary layer conductance
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : 
                 * name: newTemperature
                               ** description : Soil temperature at the end of this iteration
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
                 * name: airTemperature
                               ** description : Air temperature
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : oC
                 * name: maxTempYesterday
                               ** description : Yesterday's maximum daily air temperature
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : oC
                 * name: minTempYesterday
                               ** description : Yesterday's minimum daily air temperature
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : oC
                 * name: soilWater
                               ** description : Volumetric water content of each soil layer
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm3/mm3
                 * name: minSoilTemp
                               ** description : Minimum soil temperature
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
                 * name: maxSoilTemp
                               ** description : Maximum soil temperature
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
                 * name: aveSoilTemp
                               ** description : average soil temperature
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
                 * name: aveSoilWater
                               ** description : Average soil temperaturer
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
                 * name: thickness
                               ** description : Thickness of each soil, includes phantom layer
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: bulkDensity
                               ** description : Soil bulk density, includes phantom layer
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : g/cm3
                 * name: rocks
                               ** description : Volumetric fraction of rocks in each soil laye
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : %
                 * name: carbon
                               ** description : Volumetric fraction of carbon (CHECK, OM?) in each soil layer
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : %
                 * name: sand
                               ** description : Volumetric fraction of sand in each soil layer
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : %
                 * name: pom
                               ** description : Particle density of organic matter
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : Mg/m3
                 * name: silt
                               ** description : Volumetric fraction of silt in each soil layer
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : %
                 * name: clay
                               ** description : Volumetric fraction of clay in each soil layer
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : %
                 * name: soilRoughnessHeight
                               ** description : Height of soil roughness
                               ** inputtype : parameter
                               ** parametercategory : private
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : mm
                 * name: instrumentHeight
                               ** description : Height of instruments above soil surface
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : mm
                 * name: netRadiation
                               ** description : Net radiation per internal time-step
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : MJ
                 * name: canopyHeight
                               ** description : Height of canopy above ground
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : mm
                 * name: instrumHeight
                               ** description : Height of instruments above ground
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : mm
                 * name: nu
                               ** description : Forward/backward differencing coefficient
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.6
                               ** unit : 0-1
                 * name: boundarLayerConductanceSource
                               ** description : Flag whether boundary layer conductance is calculated or gotten from inpu
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : STRING
                               ** max : 
                               ** min : 
                               ** default : calc
                               ** unit : 
                 * name: netRadiationSource
                               ** description : Flag whether net radiation is calculated or gotten from input
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : STRING
                               ** max : 
                               ** min : 
                               ** default : calc
                               ** unit : m
                 * name: MissingValue
                               ** description : missing value
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 99999
                               ** unit : m
                 * name: soilConstituentNames
                               ** description : soilConstituentNames
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : STRINGARRAY
                               ** len : 8
                               ** max : 
                               ** min : 
                               ** default : ["Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"]
                               ** unit : m
     - outputs:
                 * name: heatStorage
                               ** description : CP, heat storage between nodes
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : J/K
                 * name: instrumentHeight
                               ** description : Height of instruments above soil surface
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** unit : mm
                 * name: canopyHeight
                               ** description : Height of canopy above ground
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** unit : mm
                 * name: minSoilTemp
                               ** description : Minimum soil temperature
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** unit : oC
                 * name: maxSoilTemp
                               ** description : Maximum soil temperature
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** unit : oC
                 * name: aveSoilTemp
                               ** description : average soil temperature
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** unit : oC
                 * name: volSpecHeatSoil
                               ** description : Volumetric specific heat over the soil profile
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** unit : J/K/m3
                 * name: soilTemp
                               ** description : Soil temperature over the soil profile at morning
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** unit : oC
                 * name: morningSoilTemp
                               ** description : Soil temperature over the soil profile at morning
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** unit : oC
                 * name: newTemperature
                               ** description : Soil temperature at the end of this iteration
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** unit : oC
                 * name: thermalConductivity
                               ** description : Thermal conductivity
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** unit : W.m/K
                 * name: thermalConductance
                               ** description : K, conductance of element between nodes
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** unit : W/K
                 * name: boundaryLayerConductance
                               ** description : Average daily atmosphere boundary layer conductance
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** unit : 
                 * name: soilWater
                               ** description : Volumetric water content of each soil layer
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** unit : mm3/mm3
                 * name: doInitialisationStuff
                               ** description : Flag whether initialisation is needed
                               ** variablecategory : state
                               ** datatype : BOOLEAN
                               ** max : 
                               ** min : 
                               ** unit : 
                 * name: maxTempYesterday
                               ** description : Yesterday's maximum daily air temperature (oC)
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : oC
                 * name: minTempYesterday
                               ** description : Yesterday's minimum daily air temperature (oC)
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** len : 
                               ** max : 
                               ** unit : oC
                               ** min : 
                 * name: airTemperature
                               ** description : Air temperature
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** unit : oC
                 * name: internalTimeStep
                               ** description : Internal time-step
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** unit : sec
                 * name: timeOfDaySecs
                               ** description : Time of day from midnight
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** unit : sec
                 * name: netRadiation
                               ** description : Net radiation per internal time-step
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** unit : MJ
                 * name: InitialValues
                               ** description : Initial soil temperature
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** unit : oC
    """

    i:int
    (soilWater, instrumentHeight, canopyHeight) = getOtherVariables(numLayers, numNodes, soilWater, instrumentHeight, soilRoughnessHeight, waterBalance_SW, microClimate_CanopyHeight, canopyHeight)
    if doInitialisationStuff:
        if ValuesInArray(InitialValues, MissingValue):
            soilTemp = array('f', [0.0]*(numNodes + 1 + 1))
            soilTemp[topsoilNode:topsoilNode + len(InitialValues)] = InitialValues[0:0 + len(InitialValues)]
        else:
            soilTemp = calcSoilTemperature(soilTemp, weather_Tav, clock_Today_DayOfYear, surfaceNode, numNodes, weather_Amp, thickness, weather_Latitude)
            InitialValues = array('f', [0.0]*(numLayers))
            InitialValues[0:0 + numLayers] = soilTemp[topsoilNode:topsoilNode + numLayers]
        soilTemp[airNode] = weather_MeanT
        soilTemp[surfaceNode] = calcSurfaceTemperature(weather_MeanT, weather_MaxT, waterBalance_Salb, weather_Radn)
        for i in range(numNodes + 1 , len(soilTemp) , 1):
            soilTemp[i] = weather_Tav
        newTemperature[0:0 + len(soilTemp)] = soilTemp
        maxTempYesterday = weather_MaxT
        minTempYesterday = weather_MinT
        doInitialisationStuff = False
    (minSoilTemp, maxSoilTemp, soilTemp, newTemperature, thermalConductivity, aveSoilTemp, morningSoilTemp, volSpecHeatSoil, heatStorage, thermalConductance, timeOfDaySecs, netRadiation, airTemperature, internalTimeStep, minTempYesterday, boundaryLayerConductance, maxTempYesterday) = doProcess(timeOfDaySecs, netRadiation, minSoilTemp, maxSoilTemp, numIterationsForBoundaryLayerConductance, timestep, boundaryLayerConductance, maxTempYesterday, airNode, soilTemp, airTemperature, newTemperature, weather_MaxT, internalTimeStep, boundarLayerConductanceSource, thermalConductivity, minTempYesterday, aveSoilTemp, morningSoilTemp, weather_MeanT, constantBoundaryLayerConductance, weather_MinT, clock_Today_DayOfYear, weather_Radn, weather_Latitude, soilConstituentNames, numNodes, volSpecHeatSoil, soilWater, nodeDepth, thickness, surfaceNode, MissingValue, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay, defaultTimeOfMaximumTemperature, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, stefanBoltzmannConstant, weather_AirPressure, weather_Wind, instrumentHeight, canopyHeight, heatStorage, netRadiationSource, latentHeatOfVapourisation, waterBalance_Es, thermalConductance, nu)
    return (heatStorage, instrumentHeight, canopyHeight, minSoilTemp, maxSoilTemp, aveSoilTemp, volSpecHeatSoil, soilTemp, morningSoilTemp, newTemperature, thermalConductivity, thermalConductance, boundaryLayerConductance, soilWater, doInitialisationStuff, maxTempYesterday, minTempYesterday, airTemperature, internalTimeStep, timeOfDaySecs, netRadiation, InitialValues)
#%%CyML Model End%%

def getIniVariables(instrumentHeight:float,
         instrumHeight:float,
         defaultInstrumentHeight:float):
    if instrumHeight > 0.00001:
        instrumentHeight = instrumHeight
    else:
        instrumentHeight = defaultInstrumentHeight
    return instrumentHeight

def getProfileVariables(heatStorage:'Array[float]',
         minSoilTemp:'Array[float]',
         bulkDensity:'Array[float]',
         numNodes:int,
         physical_BD:'Array[float]',
         maxSoilTemp:'Array[float]',
         waterBalance_SW:'Array[float]',
         organic_Carbon:'Array[float]',
         physical_Rocks:'Array[float]',
         nodeDepth:'Array[float]',
         topsoilNode:int,
         newTemperature:'Array[float]',
         surfaceNode:int,
         soilWater:'Array[float]',
         thermalConductance:'Array[float]',
         thermalConductivity:'Array[float]',
         sand:'Array[float]',
         carbon:'Array[float]',
         thickness:'Array[float]',
         numPhantomNodes:int,
         physical_ParticleSizeSand:'Array[float]',
         rocks:'Array[float]',
         clay:'Array[float]',
         physical_ParticleSizeSilt:'Array[float]',
         airNode:int,
         physical_ParticleSizeClay:'Array[float]',
         soilTemp:'Array[float]',
         numLayers:int,
         physical_Thickness:'Array[float]',
         silt:'Array[float]',
         volSpecHeatSoil:'Array[float]',
         aveSoilTemp:'Array[float]',
         morningSoilTemp:'Array[float]',
         DepthToConstantTemperature:float,
         MissingValue:float):
    layer:int
    node:int
    i:int
    belowProfileDepth:float
    thicknessForPhantomNodes:float
    firstPhantomNode:int
    oldDepth:'array[float]'
    oldBulkDensity:'array[float]'
    oldSoilWater:'array[float]'
    numLayers = len(physical_Thickness)
    numNodes = numLayers + numPhantomNodes
    thickness = array('f', [0.0]*(numLayers + numPhantomNodes + 1))
    thickness[1:1 + len(physical_Thickness)] = physical_Thickness
    belowProfileDepth = max(DepthToConstantTemperature - Sum(thickness, 1, numLayers, MissingValue), 1000.0)
    thicknessForPhantomNodes = belowProfileDepth * 2.0 / numPhantomNodes
    firstPhantomNode = numLayers
    for i in range(firstPhantomNode , firstPhantomNode + numPhantomNodes , 1):
        thickness[i] = thicknessForPhantomNodes
    oldDepth = nodeDepth
    nodeDepth = array('f', [0.0]*(numNodes + 1 + 1))
    if oldDepth is not None:
        nodeDepth[0:min(numNodes + 1 + 1, len(oldDepth))] = oldDepth[0:min(numNodes + 1 + 1, len(oldDepth))]
    nodeDepth[airNode] = 0.0
    nodeDepth[surfaceNode] = 0.0
    nodeDepth[topsoilNode] = 0.5 * thickness[1] / 1000.0
    for node in range(topsoilNode , numNodes + 1 , 1):
        nodeDepth[node + 1] = (Sum(thickness, 1, node - 1, MissingValue) + (0.5 * thickness[node])) / 1000.0
    oldBulkDensity = bulkDensity
    bulkDensity = array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    if oldBulkDensity is not None:
        bulkDensity[0:min(numLayers + 1 + numPhantomNodes, len(oldBulkDensity))] = oldBulkDensity[0:min(numLayers + 1 + numPhantomNodes, len(oldBulkDensity))]
    bulkDensity[1:1 + len(physical_BD)] = physical_BD
    bulkDensity[numNodes] = bulkDensity[numLayers]
    for layer in range(numLayers + 1 , numLayers + numPhantomNodes + 1 , 1):
        bulkDensity[layer] = bulkDensity[numLayers]
    oldSoilWater = soilWater
    soilWater = array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    if oldSoilWater is not None:
        soilWater[0:min(numLayers + 1 + numPhantomNodes, len(oldSoilWater))] = oldSoilWater[0:min(numLayers + 1 + numPhantomNodes, len(oldSoilWater))]
    if waterBalance_SW is not None:
        for layer in range(1 , numLayers + 1 , 1):
            soilWater[layer] = Divide(waterBalance_SW[(layer - 1)] * thickness[(layer - 1)], thickness[layer], float(0))
        for layer in range(numLayers + 1 , numLayers + numPhantomNodes + 1 , 1):
            soilWater[layer] = soilWater[numLayers]
    carbon = array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    for layer in range(1 , numLayers + 1 , 1):
        carbon[layer] = organic_Carbon[layer - 1]
    for layer in range(numLayers + 1 , numLayers + numPhantomNodes + 1 , 1):
        carbon[layer] = carbon[numLayers]
    rocks = array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    for layer in range(1 , numLayers + 1 , 1):
        rocks[layer] = physical_Rocks[layer - 1]
    for layer in range(numLayers + 1 , numLayers + numPhantomNodes + 1 , 1):
        rocks[layer] = rocks[numLayers]
    sand = array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    for layer in range(1 , numLayers + 1 , 1):
        sand[layer] = physical_ParticleSizeSand[layer - 1]
    for layer in range(numLayers + 1 , numLayers + numPhantomNodes + 1 , 1):
        sand[layer] = sand[numLayers]
    silt = array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    for layer in range(1 , numLayers + 1 , 1):
        silt[layer] = physical_ParticleSizeSilt[layer - 1]
    for layer in range(numLayers + 1 , numLayers + numPhantomNodes + 1 , 1):
        silt[layer] = silt[numLayers]
    clay = array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    for layer in range(1 , numLayers + 1 , 1):
        clay[layer] = physical_ParticleSizeClay[layer - 1]
    for layer in range(numLayers + 1 , numLayers + numPhantomNodes + 1 , 1):
        clay[layer] = clay[numLayers]
    maxSoilTemp = array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    minSoilTemp = array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    aveSoilTemp = array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    volSpecHeatSoil = array('f', [0.0]*(numNodes + 1))
    soilTemp = array('f', [0.0]*(numNodes + 1 + 1))
    morningSoilTemp = array('f', [0.0]*(numNodes + 1 + 1))
    newTemperature = array('f', [0.0]*(numNodes + 1 + 1))
    thermalConductivity = array('f', [0.0]*(numNodes + 1))
    heatStorage = array('f', [0.0]*(numNodes + 1))
    thermalConductance = array('f', [0.0]*(numNodes + 1 + 1))
    return (heatStorage, minSoilTemp, bulkDensity, maxSoilTemp, nodeDepth, newTemperature, soilWater, thermalConductance, thermalConductivity, sand, carbon, thickness, rocks, clay, soilTemp, silt, volSpecHeatSoil, aveSoilTemp, morningSoilTemp, numNodes, numLayers)

def doThermalConductivityCoeffs(thermCondPar2:'Array[float]',
         numLayers:int,
         bulkDensity:'Array[float]',
         numNodes:int,
         thermCondPar3:'Array[float]',
         thermCondPar4:'Array[float]',
         clay:'Array[float]',
         thermCondPar1:'Array[float]'):
    layer:int
    oldGC1:'array[float]'
    oldGC2:'array[float]'
    oldGC3:'array[float]'
    oldGC4:'array[float]'
    element:int
    oldGC1 = thermCondPar1
    thermCondPar1 = array('f', [0.0]*(numNodes + 1))
    if oldGC1 is not None:
        thermCondPar1[0:min(numNodes + 1, len(oldGC1))] = oldGC1[0:min(numNodes + 1, len(oldGC1))]
    oldGC2 = thermCondPar2
    thermCondPar2 = array('f', [0.0]*(numNodes + 1))
    if oldGC2 is not None:
        thermCondPar2[0:min(numNodes + 1, len(oldGC2))] = oldGC2[0:min(numNodes + 1, len(oldGC2))]
    oldGC3 = thermCondPar3
    thermCondPar3 = array('f', [0.0]*(numNodes + 1))
    if oldGC3 is not None:
        thermCondPar3[0:min(numNodes + 1, len(oldGC3))] = oldGC3[0:min(numNodes + 1, len(oldGC3))]
    oldGC4 = thermCondPar4
    thermCondPar4 = array('f', [0.0]*(numNodes + 1))
    if oldGC4 is not None:
        thermCondPar4[0:min(numNodes + 1, len(oldGC4))] = oldGC4[0:min(numNodes + 1, len(oldGC4))]
    for layer in range(1 , numLayers + 1 + 1 , 1):
        element = layer
        thermCondPar1[element] = 0.65 - (0.78 * bulkDensity[layer]) + (0.6 * pow(bulkDensity[layer], 2))
        thermCondPar2[element] = 1.06 * bulkDensity[layer]
        thermCondPar3[element] = 1.0 + Divide(2.6, sqrt(clay[layer]), float(0))
        thermCondPar4[element] = 0.03 + (0.1 * pow(bulkDensity[layer], 2))
    return (thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1)

def readParam(bareSoilRoughness:float,
         newTemperature:'Array[float]',
         soilRoughnessHeight:float,
         soilTemp:'Array[float]',
         thermCondPar2:'Array[float]',
         numLayers:int,
         bulkDensity:'Array[float]',
         numNodes:int,
         thermCondPar3:'Array[float]',
         thermCondPar4:'Array[float]',
         clay:'Array[float]',
         thermCondPar1:'Array[float]',
         weather_Tav:float,
         clock_Today_DayOfYear:int,
         surfaceNode:int,
         weather_Amp:float,
         thickness:'Array[float]',
         weather_Latitude:float):
    (thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1) = doThermalConductivityCoeffs(thermCondPar2, numLayers, bulkDensity, numNodes, thermCondPar3, thermCondPar4, clay, thermCondPar1)
    soilTemp = calcSoilTemperature(soilTemp, weather_Tav, clock_Today_DayOfYear, surfaceNode, numNodes, weather_Amp, thickness, weather_Latitude)
    newTemperature[0:0 + len(soilTemp)] = soilTemp
    soilRoughnessHeight = bareSoilRoughness
    return (newTemperature, soilTemp, thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1, soilRoughnessHeight)

def getOtherVariables(numLayers:int,
         numNodes:int,
         soilWater:'Array[float]',
         instrumentHeight:float,
         soilRoughnessHeight:float,
         waterBalance_SW:'Array[float]',
         microClimate_CanopyHeight:float,
         canopyHeight:float):
    soilWater[1:1 + len(waterBalance_SW)] = waterBalance_SW
    soilWater[numNodes] = soilWater[numLayers]
    canopyHeight = max(microClimate_CanopyHeight, soilRoughnessHeight) / 1000.0
    instrumentHeight = max(instrumentHeight, canopyHeight + 0.5)
    return (soilWater, instrumentHeight, canopyHeight)

def volumetricFractionOrganicMatter(layer:int,
         carbon:'Array[float]',
         bulkDensity:'Array[float]',
         pom:float):
    return carbon[layer] / 100.0 * 2.5 * bulkDensity[layer] / pom

def volumetricFractionRocks(layer:int,
         rocks:'Array[float]'):
    return rocks[layer] / 100.0

def volumetricFractionIce(layer:int):
    return 0.0

def volumetricFractionWater(layer:int,
         soilWater:'Array[float]',
         carbon:'Array[float]',
         bulkDensity:'Array[float]',
         pom:float):
    return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom)) * soilWater[layer]

def volumetricFractionClay(layer:int,
         bulkDensity:'Array[float]',
         ps:float,
         clay:'Array[float]',
         carbon:'Array[float]',
         pom:float,
         rocks:'Array[float]'):
    return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * clay[layer] / 100.0 * bulkDensity[layer] / ps

def volumetricFractionSilt(layer:int,
         bulkDensity:'Array[float]',
         silt:'Array[float]',
         ps:float,
         carbon:'Array[float]',
         pom:float,
         rocks:'Array[float]'):
    return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * silt[layer] / 100.0 * bulkDensity[layer] / ps

def volumetricFractionSand(layer:int,
         bulkDensity:'Array[float]',
         sand:'Array[float]',
         ps:float,
         carbon:'Array[float]',
         pom:float,
         rocks:'Array[float]'):
    return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * sand[layer] / 100.0 * bulkDensity[layer] / ps

def kelvinT(celciusT:float):
    celciusToKelvin:float
    celciusToKelvin = 273.18
    return celciusT + celciusToKelvin

def Divide(value1:float,
         value2:float,
         errVal:float):
    if value2 != float(0):
        return value1 / value2
    return errVal

def Sum(values:'Array[float]',
         startIndex:int,
         endIndex:int,
         MissingValue:float):
    value:float
    result:float
    index:int
    result = 0.0
    index = -1
    for value in values:
        index = index + 1
        if index >= startIndex and value != MissingValue:
            result = result + value
        if index == endIndex:
            break
    return result

def volumetricSpecificHeat(name:str,
         layer:int):
    specificHeatRocks:float
    specificHeatOM:float
    specificHeatSand:float
    specificHeatSilt:float
    specificHeatClay:float
    specificHeatWater:float
    specificHeatIce:float
    specificHeatAir:float
    result:float
    specificHeatRocks = 7.7
    specificHeatOM = 0.25
    specificHeatSand = 7.7
    specificHeatSilt = 2.74
    specificHeatClay = 2.92
    specificHeatWater = 0.57
    specificHeatIce = 2.18
    specificHeatAir = 0.025
    result = 0.0
    if name == "Rocks":
        result = specificHeatRocks
    elif name == "OrganicMatter":
        result = specificHeatOM
    elif name == "Sand":
        result = specificHeatSand
    elif name == "Silt":
        result = specificHeatSilt
    elif name == "Clay":
        result = specificHeatClay
    elif name == "Water":
        result = specificHeatWater
    elif name == "Ice":
        result = specificHeatIce
    elif name == "Air":
        result = specificHeatAir
    return result

def volumetricFractionAir(layer:int,
         rocks:'Array[float]',
         carbon:'Array[float]',
         bulkDensity:'Array[float]',
         pom:float,
         sand:'Array[float]',
         ps:float,
         silt:'Array[float]',
         clay:'Array[float]',
         soilWater:'Array[float]'):
    return 1.0 - volumetricFractionRocks(layer, rocks) - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks) - volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks) - volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks) - volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) - volumetricFractionIce(layer)

def airDensity(temperature:float,
         AirPressure:float):
    MWair:float
    RGAS:float
    HPA2PA:float
    MWair = 0.02897
    RGAS = 8.3143
    HPA2PA = 100.0
    return Divide(MWair * AirPressure * HPA2PA, kelvinT(temperature) * RGAS, 0.0)

def longWaveRadn(emissivity:float,
         tDegC:float,
         stefanBoltzmannConstant:float):
    return stefanBoltzmannConstant * emissivity * pow(kelvinT(tDegC), 4)

def mapLayer2Node(layerArray:'Array[float]',
         nodeArray:'Array[float]',
         nodeDepth:'Array[float]',
         numNodes:int,
         thickness:'Array[float]',
         surfaceNode:int,
         MissingValue:float):
    node:int
    layer:int
    depthLayerAbove:float
    d1:float
    d2:float
    dSum:float
    for node in range(surfaceNode , numNodes + 1 , 1):
        layer = node - 1
        depthLayerAbove = Sum(thickness, 1, layer, MissingValue) if layer >= 1 else 0.0
        d1 = depthLayerAbove - (nodeDepth[node] * 1000.0)
        d2 = nodeDepth[(node + 1)] * 1000.0 - depthLayerAbove
        dSum = d1 + d2
        nodeArray[node] = Divide(layerArray[layer] * d1, dSum, float(0)) + Divide(layerArray[(layer + 1)] * d2, dSum, float(0))
    return nodeArray

def ThermalConductance(name:str,
         layer:int,
         rocks:'Array[float]',
         bulkDensity:'Array[float]',
         sand:'Array[float]',
         ps:float,
         carbon:'Array[float]',
         pom:float,
         silt:'Array[float]',
         clay:'Array[float]'):
    thermalConductanceRocks:float
    thermalConductanceOM:float
    thermalConductanceSand:float
    thermalConductanceSilt:float
    thermalConductanceClay:float
    thermalConductanceWater:float
    thermalConductanceIce:float
    thermalConductanceAir:float
    result:float
    thermalConductanceRocks = 0.182
    thermalConductanceOM = 2.50
    thermalConductanceSand = 0.182
    thermalConductanceSilt = 2.39
    thermalConductanceClay = 1.39
    thermalConductanceWater = 4.18
    thermalConductanceIce = 1.73
    thermalConductanceAir = 0.0012
    result = 0.0
    if name == "Rocks":
        result = thermalConductanceRocks
    elif name == "OrganicMatter":
        result = thermalConductanceOM
    elif name == "Sand":
        result = thermalConductanceSand
    elif name == "Silt":
        result = thermalConductanceSilt
    elif name == "Clay":
        result = thermalConductanceClay
    elif name == "Water":
        result = thermalConductanceWater
    elif name == "Ice":
        result = thermalConductanceIce
    elif name == "Air":
        result = thermalConductanceAir
    elif name == "Minerals":
        result = pow(thermalConductanceRocks, volumetricFractionRocks(layer, rocks)) * pow(thermalConductanceSand, volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks)) + pow(thermalConductanceSilt, volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + pow(thermalConductanceClay, volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks))
    result = volumetricSpecificHeat(name, layer)
    return result

def shapeFactor(name:str,
         layer:int,
         soilWater:'Array[float]',
         carbon:'Array[float]',
         bulkDensity:'Array[float]',
         pom:float,
         rocks:'Array[float]',
         sand:'Array[float]',
         ps:float,
         silt:'Array[float]',
         clay:'Array[float]'):
    shapeFactorRocks:float
    shapeFactorOM:float
    shapeFactorSand:float
    shapeFactorSilt:float
    shapeFactorClay:float
    shapeFactorWater:float
    result:float
    shapeFactorRocks = 0.182
    shapeFactorOM = 0.5
    shapeFactorSand = 0.182
    shapeFactorSilt = 0.125
    shapeFactorClay = 0.007755
    shapeFactorWater = 1.0
    result = 0.0
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
        result = 0.333 - (0.333 * volumetricFractionIce(layer) / (volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater)))
        return result
    elif name == "Air":
        result = 0.333 - (0.333 * volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater) / (volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater)))
        return result
    elif name == "Minerals":
        result = shapeFactorRocks * volumetricFractionRocks(layer, rocks) + (shapeFactorSand * volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks)) + (shapeFactorSilt * volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + (shapeFactorClay * volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks))
    result = volumetricSpecificHeat(name, layer)
    return result

def doUpdate(numInterationsPerDay:int,
         timeOfDaySecs:float,
         boundaryLayerConductance:float,
         minSoilTemp:'Array[float]',
         airNode:int,
         soilTemp:'Array[float]',
         newTemperature:'Array[float]',
         numNodes:int,
         surfaceNode:int,
         internalTimeStep:float,
         maxSoilTemp:'Array[float]',
         aveSoilTemp:'Array[float]',
         thermalConductivity:'Array[float]'):
    node:int
    soilTemp[0:0 + len(newTemperature)] = newTemperature
    if timeOfDaySecs < (internalTimeStep * 1.2):
        for node in range(surfaceNode , numNodes + 1 , 1):
            minSoilTemp[node] = soilTemp[node]
            maxSoilTemp[node] = soilTemp[node]
    for node in range(surfaceNode , numNodes + 1 , 1):
        if soilTemp[node] < minSoilTemp[node]:
            minSoilTemp[node] = soilTemp[node]
        elif soilTemp[node] > maxSoilTemp[node]:
            maxSoilTemp[node] = soilTemp[node]
        aveSoilTemp[node] = aveSoilTemp[node] + Divide(soilTemp[node], float(numInterationsPerDay), float(0))
    boundaryLayerConductance = boundaryLayerConductance + Divide(thermalConductivity[airNode], float(numInterationsPerDay), float(0))
    return (minSoilTemp, soilTemp, maxSoilTemp, aveSoilTemp, boundaryLayerConductance)

def doThomas(newTemps:'Array[float]',
         netRadiation:float,
         heatStorage:'Array[float]',
         waterBalance_Eos:float,
         numNodes:int,
         timestep:float,
         netRadiationSource:str,
         latentHeatOfVapourisation:float,
         nodeDepth:'Array[float]',
         waterBalance_Es:float,
         airNode:int,
         soilTemp:'Array[float]',
         surfaceNode:int,
         internalTimeStep:float,
         thermalConductance:'Array[float]',
         thermalConductivity:'Array[float]',
         nu:float,
         volSpecHeatSoil:'Array[float]'):
    node:int
    a:'array[float]' = array('f',[0.0]*(numNodes + 1 + 1))
    b:'array[float]' = array('f',[0.0]*(numNodes + 1))
    c:'array[float]' = array('f',[0.0]*(numNodes + 1))
    d:'array[float]' = array('f',[0.0]*(numNodes + 1))
    volumeOfSoilAtNode:float
    elementLength:float
    g:float
    sensibleHeatFlux:float
    radnNet:float
    latentHeatFlux:float
    soilSurfaceHeatFlux:float
    thermalConductance[airNode] = thermalConductivity[airNode]
    for node in range(surfaceNode , numNodes + 1 , 1):
        volumeOfSoilAtNode = 0.5 * (nodeDepth[node + 1] - nodeDepth[node - 1])
        heatStorage[node] = Divide(volSpecHeatSoil[node] * volumeOfSoilAtNode, internalTimeStep, float(0))
        elementLength = nodeDepth[node + 1] - nodeDepth[node]
        thermalConductance[node] = Divide(thermalConductivity[node], elementLength, float(0))
    g = 1 - nu
    for node in range(surfaceNode , numNodes + 1 , 1):
        c[node] = -nu * thermalConductance[node]
        a[node + 1] = c[node]
        b[node] = nu * (thermalConductance[node] + thermalConductance[node - 1]) + heatStorage[node]
        d[node] = g * thermalConductance[(node - 1)] * soilTemp[(node - 1)] + ((heatStorage[node] - (g * (thermalConductance[node] + thermalConductance[node - 1]))) * soilTemp[node]) + (g * thermalConductance[node] * soilTemp[(node + 1)])
    a[surfaceNode] = 0.0
    sensibleHeatFlux = nu * thermalConductance[airNode] * newTemps[airNode]
    radnNet = 0.0
    if netRadiationSource == "calc":
        radnNet = Divide(netRadiation * 1000000.0, internalTimeStep, float(0))
    elif netRadiationSource == "eos":
        radnNet = Divide(waterBalance_Eos * latentHeatOfVapourisation, timestep, float(0))
    latentHeatFlux = Divide(waterBalance_Es * latentHeatOfVapourisation, timestep, float(0))
    soilSurfaceHeatFlux = sensibleHeatFlux + radnNet - latentHeatFlux
    d[surfaceNode] = d[surfaceNode] + soilSurfaceHeatFlux
    d[numNodes] = d[numNodes] + (nu * thermalConductance[numNodes] * newTemps[(numNodes + 1)])
    for node in range(surfaceNode , numNodes - 1 + 1 , 1):
        c[node] = Divide(c[node], b[node], float(0))
        d[node] = Divide(d[node], b[node], float(0))
        b[node + 1] = b[node + 1] - (a[(node + 1)] * c[node])
        d[node + 1] = d[node + 1] - (a[(node + 1)] * d[node])
    newTemps[numNodes] = Divide(d[numNodes], b[numNodes], float(0))
    for node in range(numNodes - 1 , surfaceNode - 1 , -1):
        newTemps[node] = d[node] - (c[node] * newTemps[(node + 1)])
    return (newTemps, heatStorage, thermalConductance)

def getBoundaryLayerConductance(TNew_zb:'Array[float]',
         weather_AirPressure:float,
         stefanBoltzmannConstant:float,
         waterBalance_Eos:float,
         weather_Wind:float,
         airTemperature:float,
         surfaceNode:int,
         waterBalance_Eo:float,
         instrumentHeight:float,
         canopyHeight:float):
    iteration:int
    vonKarmanConstant:float
    gravitationalConstant:float
    specificHeatOfAir:float
    surfaceEmissivity:float
    SpecificHeatAir:float
    roughnessFactorMomentum:float
    roughnessFactorHeat:float
    d:float
    surfaceTemperature:float
    diffusePenetrationConstant:float
    radiativeConductance:float
    frictionVelocity:float
    boundaryLayerCond:float
    stabilityParammeter:float
    stabilityCorrectionMomentum:float
    stabilityCorrectionHeat:float
    heatFluxDensity:float
    vonKarmanConstant = 0.41
    gravitationalConstant = 9.8
    specificHeatOfAir = 1010.0
    surfaceEmissivity = 0.98
    SpecificHeatAir = specificHeatOfAir * airDensity(airTemperature, weather_AirPressure)
    roughnessFactorMomentum = 0.13 * canopyHeight
    roughnessFactorHeat = 0.2 * roughnessFactorMomentum
    d = 0.77 * canopyHeight
    surfaceTemperature = TNew_zb[surfaceNode]
    diffusePenetrationConstant = max(0.1, waterBalance_Eos) / max(0.1, waterBalance_Eo)
    radiativeConductance = 4.0 * stefanBoltzmannConstant * surfaceEmissivity * diffusePenetrationConstant * pow(kelvinT(airTemperature), 3)
    frictionVelocity = 0.0
    boundaryLayerCond = 0.0
    stabilityParammeter = 0.0
    stabilityCorrectionMomentum = 0.0
    stabilityCorrectionHeat = 0.0
    heatFluxDensity = 0.0
    for iteration in range(1 , 3 + 1 , 1):
        frictionVelocity = Divide(weather_Wind * vonKarmanConstant, log(Divide(instrumentHeight - d + roughnessFactorMomentum, roughnessFactorMomentum, float(0))) + stabilityCorrectionMomentum, float(0))
        boundaryLayerCond = Divide(SpecificHeatAir * vonKarmanConstant * frictionVelocity, log(Divide(instrumentHeight - d + roughnessFactorHeat, roughnessFactorHeat, float(0))) + stabilityCorrectionHeat, float(0))
        boundaryLayerCond = boundaryLayerCond + radiativeConductance
        heatFluxDensity = boundaryLayerCond * (surfaceTemperature - airTemperature)
        stabilityParammeter = Divide(-vonKarmanConstant * instrumentHeight * gravitationalConstant * heatFluxDensity, SpecificHeatAir * kelvinT(airTemperature) * pow(frictionVelocity, 3.0), float(0))
        if stabilityParammeter > 0.0:
            stabilityCorrectionHeat = 4.7 * stabilityParammeter
            stabilityCorrectionMomentum = stabilityCorrectionHeat
        else:
            stabilityCorrectionHeat = -2.0 * log((1.0 + sqrt(1.0 - (16.0 * stabilityParammeter))) / 2.0)
            stabilityCorrectionMomentum = 0.6 * stabilityCorrectionHeat
    return (boundaryLayerCond, TNew_zb)

def interpolateNetRadiation(solarRadn:float,
         cloudFr:float,
         cva:float,
         waterBalance_Eo:float,
         waterBalance_Eos:float,
         waterBalance_Salb:float,
         soilTemp:'Array[float]',
         airTemperature:float,
         surfaceNode:int,
         internalTimeStep:float,
         stefanBoltzmannConstant:float):
    surfaceEmissivity:float
    w2MJ:float
    emissivityAtmos:float
    PenetrationConstant:float
    lwRinSoil:float
    lwRoutSoil:float
    lwRnetSoil:float
    swRin:float
    swRout:float
    swRnetSoil:float
    surfaceEmissivity = 0.96
    w2MJ = internalTimeStep / 1000000.0
    emissivityAtmos = (1 - (0.84 * cloudFr)) * 0.58 * pow(cva, 1.0 / 7.0) + (0.84 * cloudFr)
    PenetrationConstant = Divide(max(0.1, waterBalance_Eos), max(0.1, waterBalance_Eo), float(0))
    lwRinSoil = longWaveRadn(emissivityAtmos, airTemperature, stefanBoltzmannConstant) * PenetrationConstant * w2MJ
    lwRoutSoil = longWaveRadn(surfaceEmissivity, soilTemp[surfaceNode], stefanBoltzmannConstant) * PenetrationConstant * w2MJ
    lwRnetSoil = lwRinSoil - lwRoutSoil
    swRin = solarRadn
    swRout = waterBalance_Salb * solarRadn
    swRnetSoil = (swRin - swRout) * PenetrationConstant
    return swRnetSoil + lwRnetSoil

def interpolateTemperature(timeHours:float,
         minTempYesterday:float,
         maxTempYesterday:float,
         weather_MeanT:float,
         weather_MaxT:float,
         weather_MinT:float,
         defaultTimeOfMaximumTemperature:float):
    time:float
    maxT_time:float
    minT_time:float
    midnightT:float
    tScale:float
    currentTemperature:float
    time = timeHours / 24.0
    maxT_time = defaultTimeOfMaximumTemperature / 24.0
    minT_time = maxT_time - 0.5
    if time < minT_time:
        midnightT = sin((0.0 + 0.25 - maxT_time) * 2.0 * pi) * (maxTempYesterday - minTempYesterday) / 2.0 + ((maxTempYesterday + minTempYesterday) / 2.0)
        tScale = (minT_time - time) / minT_time
        if tScale > 1.0:
            tScale = 1.0
        elif tScale < float(0):
            tScale = float(0)
        currentTemperature = weather_MinT + (tScale * (midnightT - weather_MinT))
        return currentTemperature
    else:
        currentTemperature = sin((time + 0.25 - maxT_time) * 2.0 * pi) * (weather_MaxT - weather_MinT) / 2.0 + weather_MeanT
        return currentTemperature

def doThermalConductivity(soilConstituentNames:'Array[str]',
         numNodes:int,
         soilWater:'Array[float]',
         thermalConductivity:'Array[float]',
         carbon:'Array[float]',
         bulkDensity:'Array[float]',
         pom:float,
         rocks:'Array[float]',
         sand:'Array[float]',
         ps:float,
         silt:'Array[float]',
         clay:'Array[float]',
         nodeDepth:'Array[float]',
         thickness:'Array[float]',
         surfaceNode:int,
         MissingValue:float):
    node:int
    constituentName:str
    thermCondLayers:'array[float]' = array('f',[0.0]*(numNodes + 1))
    numerator:float
    denominator:float
    shapeFactorConstituent:float
    thermalConductanceConstituent:float
    thermalConductanceWater:float
    k:float
    for node in range(1 , numNodes + 1 , 1):
        numerator = 0.0
        denominator = 0.0
        for constituentName in soilConstituentNames:
            shapeFactorConstituent = shapeFactor(constituentName, node, soilWater, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay)
            thermalConductanceConstituent = ThermalConductance(constituentName, node, rocks, bulkDensity, sand, ps, carbon, pom, silt, clay)
            thermalConductanceWater = ThermalConductance("Water", node, rocks, bulkDensity, sand, ps, carbon, pom, silt, clay)
            k = 2.0 / 3.0 * pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0))), -1) + (1.0 / 3.0 * pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0) * (1 - (2 * shapeFactorConstituent)))), -1))
            numerator = numerator + (thermalConductanceConstituent * soilWater[node] * k)
            denominator = denominator + (soilWater[node] * k)
        thermCondLayers[node] = numerator / denominator
    thermalConductivity = mapLayer2Node(thermCondLayers, thermalConductivity, nodeDepth, numNodes, thickness, surfaceNode, MissingValue)
    return thermalConductivity

def doVolumetricSpecificHeat(soilConstituentNames:'Array[str]',
         numNodes:int,
         volSpecHeatSoil:'Array[float]',
         soilWater:'Array[float]',
         nodeDepth:'Array[float]',
         thickness:'Array[float]',
         surfaceNode:int,
         MissingValue:float):
    node:int
    constituentName:str
    volspecHeatSoil_:'array[float]' = array('f',[0.0]*(numNodes + 1))
    for node in range(1 , numNodes + 1 , 1):
        volspecHeatSoil_[node] = float(0)
        for constituentName in soilConstituentNames:
            if constituentName not in ["Minerals"]:
                volspecHeatSoil_[node] = volspecHeatSoil_[node] + (volumetricSpecificHeat(constituentName, node) * 1000000.0 * soilWater[node])
    volSpecHeatSoil = mapLayer2Node(volspecHeatSoil_, volSpecHeatSoil, nodeDepth, numNodes, thickness, surfaceNode, MissingValue)
    return volSpecHeatSoil

def Zero(arr:'Array[float]'):
    i:int
    if arr is not None:
        for i in range(0 , len(arr) , 1):
            arr[i] = float(0)
    return arr

def doNetRadiation(solarRadn:'Array[float]',
         cloudFr:float,
         cva:float,
         ITERATIONSperDAY:int,
         weather_MinT:float,
         clock_Today_DayOfYear:int,
         weather_Radn:float,
         weather_Latitude:float):
    timestepNumber:int
    TSTEPS2RAD:float
    solarConstant:float
    solarDeclination:float
    cD:float
    m1:'array[float]' = array('f',[0.0]*(ITERATIONSperDAY + 1))
    m1Tot:float
    psr:float
    fr:float
    TSTEPS2RAD = Divide(2.0 * pi, float(ITERATIONSperDAY), float(0))
    solarConstant = 1360.0
    solarDeclination = 0.3985 * sin((4.869 + (clock_Today_DayOfYear * 2.0 * pi / 365.25) + (0.03345 * sin((6.224 + (clock_Today_DayOfYear * 2.0 * pi / 365.25))))))
    cD = sqrt(1.0 - (solarDeclination * solarDeclination))
    m1Tot = 0.0
    for timestepNumber in range(1 , ITERATIONSperDAY + 1 , 1):
        m1[timestepNumber] = (solarDeclination * sin(weather_Latitude * pi / 180.0) + (cD * cos(weather_Latitude * pi / 180.0) * cos(TSTEPS2RAD * (timestepNumber - (ITERATIONSperDAY / 2.0))))) * 24.0 / ITERATIONSperDAY
        if m1[timestepNumber] > 0.0:
            m1Tot = m1Tot + m1[timestepNumber]
        else:
            m1[timestepNumber] = 0.0
    psr = m1Tot * solarConstant * 3600.0 / 1000000.0
    fr = Divide(max(weather_Radn, 0.1), psr, float(0))
    cloudFr = 2.33 - (3.33 * fr)
    cloudFr = min(max(cloudFr, 0.0), 1.0)
    for timestepNumber in range(1 , ITERATIONSperDAY + 1 , 1):
        solarRadn[timestepNumber] = max(weather_Radn, 0.1) * Divide(m1[timestepNumber], m1Tot, float(0))
    cva = exp((31.3716 - (6014.79 / kelvinT(weather_MinT)) - (0.00792495 * kelvinT(weather_MinT)))) / kelvinT(weather_MinT)
    return (solarRadn, cloudFr, cva)

def doProcess(timeOfDaySecs:float,
         netRadiation:float,
         minSoilTemp:'Array[float]',
         maxSoilTemp:'Array[float]',
         numIterationsForBoundaryLayerConductance:int,
         timestep:float,
         boundaryLayerConductance:float,
         maxTempYesterday:float,
         airNode:int,
         soilTemp:'Array[float]',
         airTemperature:float,
         newTemperature:'Array[float]',
         weather_MaxT:float,
         internalTimeStep:float,
         boundarLayerConductanceSource:str,
         thermalConductivity:'Array[float]',
         minTempYesterday:float,
         aveSoilTemp:'Array[float]',
         morningSoilTemp:'Array[float]',
         weather_MeanT:float,
         constantBoundaryLayerConductance:float,
         weather_MinT:float,
         clock_Today_DayOfYear:int,
         weather_Radn:float,
         weather_Latitude:float,
         soilConstituentNames:'Array[str]',
         numNodes:int,
         volSpecHeatSoil:'Array[float]',
         soilWater:'Array[float]',
         nodeDepth:'Array[float]',
         thickness:'Array[float]',
         surfaceNode:int,
         MissingValue:float,
         carbon:'Array[float]',
         bulkDensity:'Array[float]',
         pom:float,
         rocks:'Array[float]',
         sand:'Array[float]',
         ps:float,
         silt:'Array[float]',
         clay:'Array[float]',
         defaultTimeOfMaximumTemperature:float,
         waterBalance_Eo:float,
         waterBalance_Eos:float,
         waterBalance_Salb:float,
         stefanBoltzmannConstant:float,
         weather_AirPressure:float,
         weather_Wind:float,
         instrumentHeight:float,
         canopyHeight:float,
         heatStorage:'Array[float]',
         netRadiationSource:str,
         latentHeatOfVapourisation:float,
         waterBalance_Es:float,
         thermalConductance:'Array[float]',
         nu:float):
    timeStepIteration:int
    iteration:int
    interactionsPerDay:int
    cva:float
    cloudFr:float
    solarRadn:'array[float]' = array('f',[0.0]*(49))
    interactionsPerDay = 48
    cva = 0.0
    cloudFr = 0.0
    (solarRadn, cloudFr, cva) = doNetRadiation(solarRadn, cloudFr, cva, interactionsPerDay, weather_MinT, clock_Today_DayOfYear, weather_Radn, weather_Latitude)
    minSoilTemp = Zero(minSoilTemp)
    maxSoilTemp = Zero(maxSoilTemp)
    aveSoilTemp = Zero(aveSoilTemp)
    boundaryLayerConductance = 0.0
    internalTimeStep = round(timestep / interactionsPerDay)
    volSpecHeatSoil = doVolumetricSpecificHeat(soilConstituentNames, numNodes, volSpecHeatSoil, soilWater, nodeDepth, thickness, surfaceNode, MissingValue)
    thermalConductivity = doThermalConductivity(soilConstituentNames, numNodes, soilWater, thermalConductivity, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay, nodeDepth, thickness, surfaceNode, MissingValue)
    for timeStepIteration in range(1 , interactionsPerDay + 1 , 1):
        timeOfDaySecs = internalTimeStep * float(timeStepIteration)
        if timestep < (24.0 * 60.0 * 60.0):
            airTemperature = weather_MeanT
        else:
            airTemperature = interpolateTemperature(timeOfDaySecs / 3600.0, minTempYesterday, maxTempYesterday, weather_MeanT, weather_MaxT, weather_MinT, defaultTimeOfMaximumTemperature)
        newTemperature[airNode] = airTemperature
        netRadiation = interpolateNetRadiation(solarRadn[timeStepIteration], cloudFr, cva, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, soilTemp, airTemperature, surfaceNode, internalTimeStep, stefanBoltzmannConstant)
        if boundarLayerConductanceSource == "constant":
            thermalConductivity[airNode] = constantBoundaryLayerConductance
        elif boundarLayerConductanceSource == "calc":
            (thermalConductivity[airNode], newTemperature) = getBoundaryLayerConductance(newTemperature, weather_AirPressure, stefanBoltzmannConstant, waterBalance_Eos, weather_Wind, airTemperature, surfaceNode, waterBalance_Eo, instrumentHeight, canopyHeight)
            for iteration in range(1 , numIterationsForBoundaryLayerConductance + 1 , 1):
                (newTemperature, heatStorage, thermalConductance) = doThomas(newTemperature, netRadiation, heatStorage, waterBalance_Eos, numNodes, timestep, netRadiationSource, latentHeatOfVapourisation, nodeDepth, waterBalance_Es, airNode, soilTemp, surfaceNode, internalTimeStep, thermalConductance, thermalConductivity, nu, volSpecHeatSoil)
                (thermalConductivity[airNode], newTemperature) = getBoundaryLayerConductance(newTemperature, weather_AirPressure, stefanBoltzmannConstant, waterBalance_Eos, weather_Wind, airTemperature, surfaceNode, waterBalance_Eo, instrumentHeight, canopyHeight)
        (newTemperature, heatStorage, thermalConductance) = doThomas(newTemperature, netRadiation, heatStorage, waterBalance_Eos, numNodes, timestep, netRadiationSource, latentHeatOfVapourisation, nodeDepth, waterBalance_Es, airNode, soilTemp, surfaceNode, internalTimeStep, thermalConductance, thermalConductivity, nu, volSpecHeatSoil)
        (minSoilTemp, soilTemp, maxSoilTemp, aveSoilTemp, boundaryLayerConductance) = doUpdate(interactionsPerDay, timeOfDaySecs, boundaryLayerConductance, minSoilTemp, airNode, soilTemp, newTemperature, numNodes, surfaceNode, internalTimeStep, maxSoilTemp, aveSoilTemp, thermalConductivity)
        if abs(timeOfDaySecs - (5.0 * 3600.0)) <= (min(timeOfDaySecs, 5.0 * 3600.0) * 0.0001):
            morningSoilTemp[0:0 + len(soilTemp)] = soilTemp
    minTempYesterday = weather_MinT
    maxTempYesterday = weather_MaxT
    return (minSoilTemp, maxSoilTemp, soilTemp, newTemperature, thermalConductivity, aveSoilTemp, morningSoilTemp, volSpecHeatSoil, heatStorage, thermalConductance, timeOfDaySecs, netRadiation, airTemperature, internalTimeStep, minTempYesterday, boundaryLayerConductance, maxTempYesterday)

def ToCumThickness(Thickness:'Array[float]'):
    Layer:int
    CumThickness:'array[float]' = array('f',[0.0]*(len(Thickness)))
    if len(Thickness) > 0:
        CumThickness[0] = Thickness[0]
        for Layer in range(1 , len(Thickness) , 1):
            CumThickness[Layer] = Thickness[Layer] + CumThickness[Layer - 1]
    return CumThickness

def calcSoilTemperature(soilTempIO:'Array[float]',
         weather_Tav:float,
         clock_Today_DayOfYear:int,
         surfaceNode:int,
         numNodes:int,
         weather_Amp:float,
         thickness:'Array[float]',
         weather_Latitude:float):
    nodes:int
    cumulativeDepth:'array[float]'
    w:float
    dh:float
    zd:float
    offset:float
    soilTemp:'array[float]' = array('f',[0.0]*(numNodes + 1 + 1))
    cumulativeDepth = ToCumThickness(thickness)
    w = 2 * pi / (365.25 * 24 * 3600)
    dh = 0.6
    zd = sqrt(2 * dh / w)
    offset = 0.25
    if weather_Latitude > 0.0:
        offset = -0.25
    for nodes in range(1 , numNodes + 1 , 1):
        soilTemp[nodes] = weather_Tav + (weather_Amp * exp(-1 * cumulativeDepth[nodes] / zd) * sin(((clock_Today_DayOfYear / 365.0 + offset) * 2.0 * pi - (cumulativeDepth[nodes] / zd))))
    soilTempIO[surfaceNode:surfaceNode + numNodes] = soilTemp[0:0 + numNodes]
    return soilTempIO

def calcSurfaceTemperature(weather_MeanT:float,
         weather_MaxT:float,
         waterBalance_Salb:float,
         weather_Radn:float):
    surfaceT:float
    surfaceT = (1.0 - waterBalance_Salb) * (weather_MeanT + ((weather_MaxT - weather_MeanT) * sqrt(max(weather_Radn, 0.1) * 23.8846 / 800.0))) + (waterBalance_Salb * weather_MeanT)
    return surfaceT

def ValuesInArray(Values:'Array[float]',
         MissingValue:float):
    Value:float
    if Values is not None:
        for Value in Values:
            if Value != MissingValue and not isnan(Value):
                return True
    return False