# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from ApsimCampbell.soiltemperature import model_soiltemperature, init_soiltemperature

#%%CyML Model Begin%%
def model_soiltemp(netRadiation:float,
         aveSoilWater:'Array[float]',
         bulkDensity:'Array[float]',
         waterBalance_Eo:float,
         thermCondPar1:'Array[float]',
         topsoilNode:int,
         surfaceNode:int,
         internalTimeStep:float,
         thermalConductance:'Array[float]',
         thickness:'Array[float]',
         numPhantomNodes:int,
         soilConstituentNames:'Array[str]',
         doInitialisationStuff:bool,
         maxTempYesterday:float,
         waterBalance_Salb:float,
         physical_Thickness:'Array[float]',
         MissingValue:float,
         timeOfDaySecs:float,
         numNodes:int,
         timestep:float,
         organic_Carbon:'Array[float]',
         waterBalance_Es:float,
         weather_Wind:float,
         soilWater:'Array[float]',
         soilRoughnessHeight:float,
         physical_ParticleSizeSand:'Array[float]',
         numIterationsForBoundaryLayerConductance:int,
         clay:'Array[float]',
         weather_AirPressure:float,
         soilTemp:'Array[float]',
         clock_Today_DayOfYear:int,
         silt:'Array[float]',
         defaultTimeOfMaximumTemperature:float,
         pom:float,
         DepthToConstantTemperature:float,
         microClimate_CanopyHeight:float,
         constantBoundaryLayerConductance:float,
         waterBalance_Eos:float,
         instrumentHeight:float,
         thermCondPar4:'Array[float]',
         waterBalance_SW:'Array[float]',
         weather_Amp:float,
         nodeDepth:'Array[float]',
         nu:float,
         sand:'Array[float]',
         pInitialValues:'Array[float]',
         weather_MinT:float,
         ps:float,
         netRadiationSource:str,
         weather_Radn:float,
         airNode:int,
         numLayers:int,
         volSpecHeatSoil:'Array[float]',
         instrumHeight:float,
         canopyHeight:float,
         heatStorage:'Array[float]',
         minSoilTemp:'Array[float]',
         bareSoilRoughness:float,
         thermCondPar2:'Array[float]',
         defaultInstrumentHeight:float,
         maxSoilTemp:'Array[float]',
         physical_BD:'Array[float]',
         latentHeatOfVapourisation:float,
         weather_Latitude:float,
         physical_Rocks:'Array[float]',
         stefanBoltzmannConstant:float,
         weather_Tav:float,
         newTemperature:'Array[float]',
         airTemperature:float,
         weather_MaxT:float,
         boundarLayerConductanceSource:str,
         thermalConductivity:'Array[float]',
         minTempYesterday:float,
         carbon:'Array[float]',
         weather_MeanT:float,
         rocks:'Array[float]',
         InitialValues:'Array[float]',
         thermCondPar3:'Array[float]',
         physical_ParticleSizeSilt:'Array[float]',
         boundaryLayerConductance:float,
         physical_ParticleSizeClay:'Array[float]',
         aveSoilTemp:'Array[float]',
         morningSoilTemp:'Array[float]'):
    """
     - Name: Soiltemp -Version: 2.0, -Time step: 1.0
     - Description:
                 * Title: Soiltemp model
                 * Authors: Cyrille
                 * Reference: None
                 * Institution: INRAE
                 * ExtendedDescription: Soil Temperature
                 * ShortDescription: Soil Temperature
     - inputs:
                 * name: netRadiation
                               ** description : Net radiation per internal time-step
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : MJ
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
                 * name: waterBalance_Eo
                               ** description : Potential soil evapotranspiration from soil surface
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
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
                 * name: topsoilNode
                               ** description : The index of the first node within the soil (top layer)
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 2
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
                 * name: internalTimeStep
                               ** description : Internal time-step
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : sec
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
                 * name: numPhantomNodes
                               ** description : The number of phantom nodes below the soil profile
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 5
                               ** unit : 
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
                 * name: doInitialisationStuff
                               ** description : Flag whether initialisation is needed
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : BOOLEAN
                               ** max : 
                               ** min : 
                               ** default : false
                               ** unit : mintes
                 * name: maxTempYesterday
                               ** description : Yesterday's maximum daily air temperature
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : oC
                 * name: waterBalance_Salb
                               ** description : Fraction of incoming radiation reflected from bare soil
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : 0-1
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
                 * name: MissingValue
                               ** description : missing value
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 99999
                               ** unit : m
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
                 * name: timestep
                               ** description : Internal time-step (minutes)
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 24.0 * 60.0 * 60.0
                               ** unit : minutes
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
                 * name: waterBalance_Es
                               ** description : Actual (realised) soil water evaporation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: weather_Wind
                               ** description : Wind speed
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : m/s
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
                 * name: soilRoughnessHeight
                               ** description : Height of soil roughness
                               ** inputtype : parameter
                               ** parametercategory : private
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : mm
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
                 * name: numIterationsForBoundaryLayerConductance
                               ** description : Number of iterations to calculate atmosphere boundary layer conductance
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** min : 
                               ** default : 1
                               ** unit : 
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
                 * name: weather_AirPressure
                               ** description : Air pressure
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : hPa
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
                 * name: clock_Today_DayOfYear
                               ** description : Day of year
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : day number
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
                 * name: defaultTimeOfMaximumTemperature
                               ** description : Time of maximum temperature
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 14.0
                               ** unit : minutes
                 * name: pom
                               ** description : Particle density of organic matter
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : Mg/m3
                 * name: DepthToConstantTemperature
                               ** description : Soil depth to constant temperature
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 10000
                               ** unit : mm
                 * name: microClimate_CanopyHeight
                               ** description : Canopy height
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: constantBoundaryLayerConductance
                               ** description : Boundary layer conductance, if constant
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 20
                               ** unit : K/W
                 * name: waterBalance_Eos
                               ** description : Potential soil evaporation from soil surface
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
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
                 * name: weather_Amp
                               ** description : Annual average temperature amplitude
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
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
                 * name: nu
                               ** description : Forward/backward differencing coefficient
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.6
                               ** unit : 0-1
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
                 * name: weather_MinT
                               ** description : Minimum temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
                 * name: ps
                               ** description : ps
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
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
                 * name: weather_Radn
                               ** description : Solar radiation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : MJ/m2/day
                 * name: airNode
                               ** description : The index of the node in the atmosphere (aboveground)
                               ** inputtype : parameter
                               ** parametercategory : constant
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
                 * name: instrumHeight
                               ** description : Height of instruments above ground
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : mm
                 * name: canopyHeight
                               ** description : Height of canopy above ground
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : mm
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
                 * name: bareSoilRoughness
                               ** description : Roughness element height of bare soil
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 57
                               ** unit : mm
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
                 * name: defaultInstrumentHeight
                               ** description : Default instrument height
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 1.2
                               ** unit : m
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
                 * name: latentHeatOfVapourisation
                               ** description : Latent heat of vapourisation for water
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 2465000
                               ** unit : miJ/kg
                 * name: weather_Latitude
                               ** description : Latitude
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : deg
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
                 * name: stefanBoltzmannConstant
                               ** description : The Stefan-Boltzmann constant
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0000000567
                               ** unit : W/m2/K4
                 * name: weather_Tav
                               ** description : Annual average temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
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
                 * name: weather_MaxT
                               ** description : Maximum temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
                 * name: boundarLayerConductanceSource
                               ** description : Flag whether boundary layer conductance is calculated or gotten from inpu
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : STRING
                               ** max : 
                               ** min : 
                               ** default : calc
                               ** unit : 
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
                 * name: minTempYesterday
                               ** description : Yesterday's minimum daily air temperature
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : oC
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
                 * name: weather_MeanT
                               ** description : Mean temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : oC
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
                 * name: boundaryLayerConductance
                               ** description : Average daily atmosphere boundary layer conductance
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0
                               ** unit : 
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

    (heatStorage, instrumentHeight, canopyHeight, minSoilTemp, maxSoilTemp, aveSoilTemp, volSpecHeatSoil, soilTemp, morningSoilTemp, newTemperature, thermalConductivity, thermalConductance, boundaryLayerConductance, soilWater, doInitialisationStuff, maxTempYesterday, minTempYesterday, airTemperature, internalTimeStep, timeOfDaySecs, netRadiation, InitialValues) = model_soiltemperature(weather_MinT, weather_MaxT, weather_MeanT, weather_Tav, weather_Amp, weather_AirPressure, weather_Wind, weather_Latitude, weather_Radn, clock_Today_DayOfYear, microClimate_CanopyHeight, physical_Thickness, physical_BD, ps, physical_Rocks, physical_ParticleSizeSand, physical_ParticleSizeSilt, physical_ParticleSizeClay, organic_Carbon, waterBalance_SW, waterBalance_Eos, waterBalance_Eo, waterBalance_Es, waterBalance_Salb, InitialValues, pInitialValues, DepthToConstantTemperature, timestep, latentHeatOfVapourisation, stefanBoltzmannConstant, airNode, surfaceNode, topsoilNode, numPhantomNodes, constantBoundaryLayerConductance, numIterationsForBoundaryLayerConductance, defaultTimeOfMaximumTemperature, defaultInstrumentHeight, bareSoilRoughness, doInitialisationStuff, internalTimeStep, timeOfDaySecs, numNodes, numLayers, nodeDepth, thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4, volSpecHeatSoil, soilTemp, morningSoilTemp, heatStorage, thermalConductance, thermalConductivity, boundaryLayerConductance, newTemperature, airTemperature, maxTempYesterday, minTempYesterday, soilWater, minSoilTemp, maxSoilTemp, aveSoilTemp, aveSoilWater, thickness, bulkDensity, rocks, carbon, sand, pom, silt, clay, soilRoughnessHeight, instrumentHeight, netRadiation, canopyHeight, instrumHeight, nu, boundarLayerConductanceSource, netRadiationSource, MissingValue, soilConstituentNames)
    return (heatStorage, instrumentHeight, canopyHeight, minSoilTemp, maxSoilTemp, aveSoilTemp, volSpecHeatSoil, soilTemp, morningSoilTemp, newTemperature, thermalConductivity, thermalConductance, boundaryLayerConductance, soilWater, doInitialisationStuff, maxTempYesterday, minTempYesterday, airTemperature, internalTimeStep, timeOfDaySecs, netRadiation, InitialValues)
#%%CyML Model End%%

#%%CyML Init Begin%%
def init_soiltemp(weather_MinT:float,
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
    netRadiation:float
    aveSoilWater:'array[float]'
    bulkDensity:'array[float]'
    internalTimeStep:float
    thermalConductance:'array[float]'
    thickness:'array[float]'
    doInitialisationStuff:bool
    maxTempYesterday:float
    timeOfDaySecs:float
    numNodes:int
    soilWater:'array[float]'
    clay:'array[float]'
    soilTemp:'array[float]'
    silt:'array[float]'
    instrumentHeight:float
    sand:'array[float]'
    numLayers:int
    volSpecHeatSoil:'array[float]'
    instrumHeight:float
    canopyHeight:float
    heatStorage:'array[float]'
    minSoilTemp:'array[float]'
    maxSoilTemp:'array[float]'
    newTemperature:'array[float]'
    airTemperature:float
    thermalConductivity:'array[float]'
    minTempYesterday:float
    carbon:'array[float]'
    rocks:'array[float]'
    InitialValues:'array[float]'
    boundaryLayerConductance:float
    aveSoilTemp:'array[float]'
    morningSoilTemp:'array[float]'
    (InitialValues, doInitialisationStuff, internalTimeStep, timeOfDaySecs, numNodes, numLayers, nodeDepth, thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4, volSpecHeatSoil, soilTemp, morningSoilTemp, heatStorage, thermalConductance, thermalConductivity, boundaryLayerConductance, newTemperature, airTemperature, maxTempYesterday, minTempYesterday, soilWater, minSoilTemp, maxSoilTemp, aveSoilTemp, aveSoilWater, thickness, bulkDensity, rocks, carbon, sand, silt, clay, soilRoughnessHeight, instrumentHeight, netRadiation, canopyHeight, instrumHeight) = init_soiltemperature(weather_MinT, weather_MaxT, weather_MeanT, weather_Tav, weather_Amp, weather_AirPressure, weather_Wind, weather_Latitude, weather_Radn, clock_Today_DayOfYear, microClimate_CanopyHeight, physical_Thickness, physical_BD, ps, physical_Rocks, physical_ParticleSizeSand, physical_ParticleSizeSilt, physical_ParticleSizeClay, organic_Carbon, waterBalance_SW, waterBalance_Eos, waterBalance_Eo, waterBalance_Es, waterBalance_Salb, pInitialValues, DepthToConstantTemperature, timestep, latentHeatOfVapourisation, stefanBoltzmannConstant, airNode, surfaceNode, topsoilNode, numPhantomNodes, constantBoundaryLayerConductance, numIterationsForBoundaryLayerConductance, defaultTimeOfMaximumTemperature, defaultInstrumentHeight, bareSoilRoughness, nodeDepth, thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4, pom, soilRoughnessHeight, nu, boundarLayerConductanceSource, netRadiationSource, MissingValue, soilConstituentNames)
    return (InitialValues, doInitialisationStuff, internalTimeStep, timeOfDaySecs, numNodes, numLayers, nodeDepth, thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4, volSpecHeatSoil, soilTemp, morningSoilTemp, heatStorage, thermalConductance, thermalConductivity, boundaryLayerConductance, newTemperature, airTemperature, maxTempYesterday, minTempYesterday, soilWater, minSoilTemp, maxSoilTemp, aveSoilTemp, aveSoilWater, thickness, bulkDensity, rocks, carbon, sand, silt, clay, soilRoughnessHeight, instrumentHeight, netRadiation, canopyHeight, instrumHeight)
#%%CyML Init End%%