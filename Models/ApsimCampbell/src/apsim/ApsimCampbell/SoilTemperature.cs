using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: SoilTemperature -Version:  1.0, -Time step:  1
///- Description:
///            * Title: SoilTemperature
///            * Authors: APSIM
///            * Reference: None
///            * Institution: APSIM Initiative
///            * ExtendedDescription:  Soil Temperature 
///            * ShortDescription: Heat flux and temperatures over the surface and soil profile (based on Campbell, 1985)
///- inputs:
///            * name: weather_MinT
///                          ** description : Minimum temperature
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : oC
///            * name: weather_MaxT
///                          ** description : Maximum temperature
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : oC
///            * name: weather_MeanT
///                          ** description : Mean temperature
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : oC
///            * name: weather_Tav
///                          ** description : Annual average temperature
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : oC
///            * name: weather_Amp
///                          ** description : Annual average temperature amplitude
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : oC
///            * name: weather_AirPressure
///                          ** description : Air pressure
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : hPa
///            * name: weather_Wind
///                          ** description : Wind speed
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : m/s
///            * name: weather_Latitude
///                          ** description : Latitude
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : deg
///            * name: weather_Radn
///                          ** description : Solar radiation
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : MJ/m2/day
///            * name: clock_Today_DayOfYear
///                          ** description : Day of year
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : INT
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : day number
///            * name: microClimate_CanopyHeight
///                          ** description : Canopy height
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : mm
///            * name: physical_Thickness
///                          ** description : Soil layer thickness
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : mm
///            * name: physical_BD
///                          ** description : Bulk density
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : g/cc
///            * name: ps
///                          ** description : ps
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : 
///            * name: physical_Rocks
///                          ** description : Rocks
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : %
///            * name: physical_ParticleSizeSand
///                          ** description : Particle size sand
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : %
///            * name: physical_ParticleSizeSilt
///                          ** description : Particle size silt
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : %
///            * name: physical_ParticleSizeClay
///                          ** description : Particle size clay
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : %
///            * name: organic_Carbon
///                          ** description : Total organic carbon
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : %
///            * name: waterBalance_SW
///                          ** description : Volumetric water content
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : mm/mm
///            * name: waterBalance_Eos
///                          ** description : Potential soil evaporation from soil surface
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : mm
///            * name: waterBalance_Eo
///                          ** description : Potential soil evapotranspiration from soil surface
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : mm
///            * name: waterBalance_Es
///                          ** description : Actual (realised) soil water evaporation
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : mm
///            * name: waterBalance_Salb
///                          ** description : Fraction of incoming radiation reflected from bare soil
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : 0-1
///            * name: InitialValues
///                          ** description : Initial soil temperature
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : oC
///            * name: pInitialValues
///                          ** description : Initial soil temperature
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : oC
///            * name: DepthToConstantTemperature
///                          ** description : Soil depth to constant temperature
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 10000
///                          ** unit : mm
///            * name: timestep
///                          ** description : Internal time-step (minutes)
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 24.0 * 60.0 * 60.0
///                          ** unit : minutes
///            * name: latentHeatOfVapourisation
///                          ** description : Latent heat of vapourisation for water
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 2465000
///                          ** unit : miJ/kg
///            * name: stefanBoltzmannConstant
///                          ** description : The Stefan-Boltzmann constant
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0.0000000567
///                          ** unit : W/m2/K4
///            * name: airNode
///                          ** description : The index of the node in the atmosphere (aboveground)
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : INT
///                          ** max : 
///                          ** min : 
///                          ** default : 0
///                          ** unit : 
///            * name: surfaceNode
///                          ** description : The index of the node on the soil surface (depth = 0)
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : INT
///                          ** max : 
///                          ** min : 
///                          ** default : 1
///                          ** unit : 
///            * name: topsoilNode
///                          ** description : The index of the first node within the soil (top layer)
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : INT
///                          ** max : 
///                          ** min : 
///                          ** default : 2
///                          ** unit : 
///            * name: numPhantomNodes
///                          ** description : The number of phantom nodes below the soil profile
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : INT
///                          ** max : 
///                          ** min : 
///                          ** default : 5
///                          ** unit : 
///            * name: constantBoundaryLayerConductance
///                          ** description : Boundary layer conductance, if constant
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 20
///                          ** unit : K/W
///            * name: numIterationsForBoundaryLayerConductance
///                          ** description : Number of iterations to calculate atmosphere boundary layer conductance
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : INT
///                          ** min : 
///                          ** default : 1
///                          ** unit : 
///            * name: defaultTimeOfMaximumTemperature
///                          ** description : Time of maximum temperature
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 14.0
///                          ** unit : minutes
///            * name: defaultInstrumentHeight
///                          ** description : Default instrument height
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 1.2
///                          ** unit : m
///            * name: bareSoilRoughness
///                          ** description : Roughness element height of bare soil
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 57
///                          ** unit : mm
///            * name: doInitialisationStuff
///                          ** description : Flag whether initialisation is needed
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : BOOLEAN
///                          ** max : 
///                          ** min : 
///                          ** default : false
///                          ** unit : mintes
///            * name: internalTimeStep
///                          ** description : Internal time-step
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0
///                          ** unit : sec
///            * name: timeOfDaySecs
///                          ** description : Time of day from midnight
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0
///                          ** unit : sec
///            * name: numNodes
///                          ** description : Number of nodes over the soil profile
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : INT
///                          ** max : 
///                          ** min : 
///                          ** default : 0
///                          ** unit : 
///            * name: numLayers
///                          ** description : Number of layers in the soil profile
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : INT
///                          ** max : 
///                          ** min : 
///                          ** default : 0
///                          ** unit : 
///            * name: nodeDepth
///                          ** description : Depths of nodes
///                          ** inputtype : parameter
///                          ** parametercategory : private
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : mm
///            * name: thermCondPar1
///                          ** description : Parameter 1 for computing thermal conductivity of soil solids
///                          ** inputtype : parameter
///                          ** parametercategory : private
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : 
///            * name: thermCondPar2
///                          ** description : Parameter 2 for computing thermal conductivity of soil solids
///                          ** inputtype : parameter
///                          ** parametercategory : private
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : 
///            * name: thermCondPar3
///                          ** description : Parameter 3 for computing thermal conductivity of soil solids
///                          ** inputtype : parameter
///                          ** parametercategory : private
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : 
///            * name: thermCondPar4
///                          ** description : Parameter 4 for computing thermal conductivity of soil solids
///                          ** inputtype : parameter
///                          ** parametercategory : private
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : 
///            * name: volSpecHeatSoil
///                          ** description : Volumetric specific heat over the soil profile
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : J/K/m3
///            * name: soilTemp
///                          ** description : Soil temperature over the soil profile at morning
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : oC
///            * name: morningSoilTemp
///                          ** description : Soil temperature over the soil profile at morning
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : oC
///            * name: heatStorage
///                          ** description : CP, heat storage between nodes
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : J/K
///            * name: thermalConductance
///                          ** description : K, conductance of element between nodes
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : W/K
///            * name: thermalConductivity
///                          ** description : Thermal conductivity
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : W.m/K
///            * name: boundaryLayerConductance
///                          ** description : Average daily atmosphere boundary layer conductance
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0
///                          ** unit : 
///            * name: newTemperature
///                          ** description : Soil temperature at the end of this iteration
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : oC
///            * name: airTemperature
///                          ** description : Air temperature
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0
///                          ** unit : oC
///            * name: maxTempYesterday
///                          ** description : Yesterday's maximum daily air temperature
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0
///                          ** unit : oC
///            * name: minTempYesterday
///                          ** description : Yesterday's minimum daily air temperature
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0
///                          ** unit : oC
///            * name: soilWater
///                          ** description : Volumetric water content of each soil layer
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : mm3/mm3
///            * name: minSoilTemp
///                          ** description : Minimum soil temperature
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : oC
///            * name: maxSoilTemp
///                          ** description : Maximum soil temperature
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : oC
///            * name: aveSoilTemp
///                          ** description : average soil temperature
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : oC
///            * name: aveSoilWater
///                          ** description : Average soil temperaturer
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : oC
///            * name: thickness
///                          ** description : Thickness of each soil, includes phantom layer
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : mm
///            * name: bulkDensity
///                          ** description : Soil bulk density, includes phantom layer
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : g/cm3
///            * name: rocks
///                          ** description : Volumetric fraction of rocks in each soil laye
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : %
///            * name: carbon
///                          ** description : Volumetric fraction of carbon (CHECK, OM?) in each soil layer
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : %
///            * name: sand
///                          ** description : Volumetric fraction of sand in each soil layer
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : %
///            * name: pom
///                          ** description : Particle density of organic matter
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : Mg/m3
///            * name: silt
///                          ** description : Volumetric fraction of silt in each soil layer
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : %
///            * name: clay
///                          ** description : Volumetric fraction of clay in each soil layer
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : %
///            * name: soilRoughnessHeight
///                          ** description : Height of soil roughness
///                          ** inputtype : parameter
///                          ** parametercategory : private
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0
///                          ** unit : mm
///            * name: instrumentHeight
///                          ** description : Height of instruments above soil surface
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0
///                          ** unit : mm
///            * name: netRadiation
///                          ** description : Net radiation per internal time-step
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0
///                          ** unit : MJ
///            * name: canopyHeight
///                          ** description : Height of canopy above ground
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0
///                          ** unit : mm
///            * name: instrumHeight
///                          ** description : Height of instruments above ground
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0
///                          ** unit : mm
///            * name: nu
///                          ** description : Forward/backward differencing coefficient
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 0.6
///                          ** unit : 0-1
///            * name: boundarLayerConductanceSource
///                          ** description : Flag whether boundary layer conductance is calculated or gotten from inpu
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : STRING
///                          ** max : 
///                          ** min : 
///                          ** default : calc
///                          ** unit : 
///            * name: netRadiationSource
///                          ** description : Flag whether net radiation is calculated or gotten from input
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : STRING
///                          ** max : 
///                          ** min : 
///                          ** default : calc
///                          ** unit : m
///            * name: MissingValue
///                          ** description : missing value
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** default : 99999
///                          ** unit : m
///            * name: soilConstituentNames
///                          ** description : soilConstituentNames
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : STRINGARRAY
///                          ** len : 8
///                          ** max : 
///                          ** min : 
///                          ** default : ["Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"]
///                          ** unit : m
///- outputs:
///            * name: heatStorage
///                          ** description : CP, heat storage between nodes
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** variablecategory : state
///                          ** max : 
///                          ** min : 
///                          ** unit : J/K
///            * name: instrumentHeight
///                          ** description : Height of instruments above soil surface
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** unit : mm
///            * name: canopyHeight
///                          ** description : Height of canopy above ground
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** unit : mm
///            * name: minSoilTemp
///                          ** description : Minimum soil temperature
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** unit : oC
///            * name: maxSoilTemp
///                          ** description : Maximum soil temperature
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** unit : oC
///            * name: aveSoilTemp
///                          ** description : average soil temperature
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** unit : oC
///            * name: volSpecHeatSoil
///                          ** description : Volumetric specific heat over the soil profile
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** unit : J/K/m3
///            * name: soilTemp
///                          ** description : Soil temperature over the soil profile at morning
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** unit : oC
///            * name: morningSoilTemp
///                          ** description : Soil temperature over the soil profile at morning
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** unit : oC
///            * name: newTemperature
///                          ** description : Soil temperature at the end of this iteration
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** unit : oC
///            * name: thermalConductivity
///                          ** description : Thermal conductivity
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** unit : W.m/K
///            * name: thermalConductance
///                          ** description : K, conductance of element between nodes
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** unit : W/K
///            * name: boundaryLayerConductance
///                          ** description : Average daily atmosphere boundary layer conductance
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** unit : 
///            * name: soilWater
///                          ** description : Volumetric water content of each soil layer
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** unit : mm3/mm3
///            * name: doInitialisationStuff
///                          ** description : Flag whether initialisation is needed
///                          ** variablecategory : state
///                          ** datatype : BOOLEAN
///                          ** max : 
///                          ** min : 
///                          ** unit : 
///            * name: maxTempYesterday
///                          ** description : Yesterday's maximum daily air temperature (oC)
///                          ** datatype : DOUBLE
///                          ** variablecategory : state
///                          ** max : 
///                          ** min : 
///                          ** unit : oC
///            * name: minTempYesterday
///                          ** description : Yesterday's minimum daily air temperature (oC)
///                          ** datatype : DOUBLE
///                          ** variablecategory : state
///                          ** len : 
///                          ** max : 
///                          ** unit : oC
///                          ** min : 
///            * name: airTemperature
///                          ** description : Air temperature
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** unit : oC
///            * name: internalTimeStep
///                          ** description : Internal time-step
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** unit : sec
///            * name: timeOfDaySecs
///                          ** description : Time of day from midnight
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** unit : sec
///            * name: netRadiation
///                          ** description : Net radiation per internal time-step
///                          ** variablecategory : state
///                          ** datatype : DOUBLE
///                          ** max : 
///                          ** min : 
///                          ** unit : MJ
///            * name: InitialValues
///                          ** description : Initial soil temperature
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** unit : oC
/// </summary>
public class SoilTemperature
{

    /// <summary>
    /// initialization of the SoilTemperature component
    /// </summary>
    public void Init(SoiltempState s, SoiltempState s1, SoiltempRate r, SoiltempAuxiliary a, SoiltempExogenous ex)
    {
        double weather_MinT = ex.weather_MinT;
        double weather_MaxT = ex.weather_MaxT;
        double weather_MeanT = ex.weather_MeanT;
        double weather_Tav = ex.weather_Tav;
        double weather_Amp = ex.weather_Amp;
        double weather_AirPressure = ex.weather_AirPressure;
        double weather_Wind = ex.weather_Wind;
        double weather_Radn = ex.weather_Radn;
        int clock_Today_DayOfYear = ex.clock_Today_DayOfYear;
        double microClimate_CanopyHeight = ex.microClimate_CanopyHeight;
        double[] physical_Rocks = ex.physical_Rocks;
        double[] physical_ParticleSizeSand = ex.physical_ParticleSizeSand;
        double[] physical_ParticleSizeSilt = ex.physical_ParticleSizeSilt;
        double[] physical_ParticleSizeClay = ex.physical_ParticleSizeClay;
        double[] organic_Carbon = ex.organic_Carbon;
        double[] waterBalance_SW = ex.waterBalance_SW;
        double waterBalance_Eos = ex.waterBalance_Eos;
        double waterBalance_Eo = ex.waterBalance_Eo;
        double waterBalance_Es = ex.waterBalance_Es;
        double waterBalance_Salb = ex.waterBalance_Salb;
        double[] nodeDepth_loc = nodeDepth;
        double[] thermCondPar1_loc = thermCondPar1;
        double[] thermCondPar2_loc = thermCondPar2;
        double[] thermCondPar3_loc = thermCondPar3;
        double[] thermCondPar4_loc = thermCondPar4;
        double soilRoughnessHeight_loc = soilRoughnessHeight;
        double[] InitialValues = null ;
        bool doInitialisationStuff = false;
        double internalTimeStep = 0.0;
        double timeOfDaySecs = 0.0;
        int numNodes = 0;
        int numLayers = 0;
        double[] volSpecHeatSoil = null ;
        double[] soilTemp = null ;
        double[] morningSoilTemp = null ;
        double[] heatStorage = null ;
        double[] thermalConductance = null ;
        double[] thermalConductivity = null ;
        double boundaryLayerConductance = 0.0;
        double[] newTemperature = null ;
        double airTemperature = 0.0;
        double maxTempYesterday = 0.0;
        double minTempYesterday = 0.0;
        double[] soilWater = null ;
        double[] minSoilTemp = null ;
        double[] maxSoilTemp = null ;
        double[] aveSoilTemp = null ;
        double[] aveSoilWater = null ;
        double[] thickness = null ;
        double[] bulkDensity = null ;
        double[] rocks = null ;
        double[] carbon = null ;
        double[] sand = null ;
        double[] silt = null ;
        double[] clay = null ;
        double instrumentHeight = 0.0;
        double netRadiation = 0.0;
        double canopyHeight = 0.0;
        double instrumHeight = 0.0;
        doInitialisationStuff = true;
        instrumentHeight = getIniVariables(instrumentHeight, instrumHeight, defaultInstrumentHeight);
        getProfileVariables(ref heatStorage, ref minSoilTemp, ref bulkDensity, ref numNodes, physical_BD, ref maxSoilTemp, waterBalance_SW, organic_Carbon, physical_Rocks, ref nodeDepth_loc, topsoilNode, ref newTemperature, surfaceNode, ref soilWater, ref thermalConductance, ref thermalConductivity, ref sand, ref carbon, ref thickness, numPhantomNodes, physical_ParticleSizeSand, ref rocks, ref clay, physical_ParticleSizeSilt, airNode, physical_ParticleSizeClay, ref soilTemp, ref numLayers, physical_Thickness, ref silt, ref volSpecHeatSoil, ref aveSoilTemp, ref morningSoilTemp, DepthToConstantTemperature, MissingValue);
        readParam(bareSoilRoughness, ref newTemperature, ref soilRoughnessHeight_loc, ref soilTemp, ref thermCondPar2_loc, numLayers, bulkDensity, numNodes, ref thermCondPar3_loc, ref thermCondPar4_loc, clay, ref thermCondPar1_loc, weather_Tav, clock_Today_DayOfYear, surfaceNode, weather_Amp, thickness, weather_Latitude);
        InitialValues = pInitialValues;
        nodeDepth = nodeDepth_loc;
        thermCondPar1 = thermCondPar1_loc;
        thermCondPar2 = thermCondPar2_loc;
        thermCondPar3 = thermCondPar3_loc;
        thermCondPar4 = thermCondPar4_loc;
        soilRoughnessHeight = soilRoughnessHeight_loc;
        s.InitialValues= InitialValues;
        s.doInitialisationStuff= doInitialisationStuff;
        s.internalTimeStep= internalTimeStep;
        s.timeOfDaySecs= timeOfDaySecs;
        s.numNodes= numNodes;
        s.numLayers= numLayers;
        s.volSpecHeatSoil= volSpecHeatSoil;
        s.soilTemp= soilTemp;
        s.morningSoilTemp= morningSoilTemp;
        s.heatStorage= heatStorage;
        s.thermalConductance= thermalConductance;
        s.thermalConductivity= thermalConductivity;
        s.boundaryLayerConductance= boundaryLayerConductance;
        s.newTemperature= newTemperature;
        s.airTemperature= airTemperature;
        s.maxTempYesterday= maxTempYesterday;
        s.minTempYesterday= minTempYesterday;
        s.soilWater= soilWater;
        s.minSoilTemp= minSoilTemp;
        s.maxSoilTemp= maxSoilTemp;
        s.aveSoilTemp= aveSoilTemp;
        s.aveSoilWater= aveSoilWater;
        s.thickness= thickness;
        s.bulkDensity= bulkDensity;
        s.rocks= rocks;
        s.carbon= carbon;
        s.sand= sand;
        s.silt= silt;
        s.clay= clay;
        s.instrumentHeight= instrumentHeight;
        s.netRadiation= netRadiation;
        s.canopyHeight= canopyHeight;
        s.instrumHeight= instrumHeight;
    }

    private double _weather_Latitude;
    /// <summary>
    /// Gets and sets the Latitude
    /// </summary>
    [Description("Latitude")] 
    [Units("deg")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=, parametercategory=constant, inputtype="parameter")] 
    public double weather_Latitude
    {
        get { return this._weather_Latitude; }
        set { this._weather_Latitude= value; } 
    }

    private double[] _physical_Thickness;
    /// <summary>
    /// Gets and sets the Soil layer thickness
    /// </summary>
    [Description("Soil layer thickness")] 
    [Units("mm")] 
    //[Crop2ML(datatype="DOUBLEARRAY", min=null, max=null, default=, parametercategory=constant, inputtype="parameter")] 
    public double[] physical_Thickness
    {
        get { return this._physical_Thickness; }
        set { this._physical_Thickness= value; } 
    }

    private double[] _physical_BD;
    /// <summary>
    /// Gets and sets the Bulk density
    /// </summary>
    [Description("Bulk density")] 
    [Units("g/cc")] 
    //[Crop2ML(datatype="DOUBLEARRAY", min=null, max=null, default=, parametercategory=constant, inputtype="parameter")] 
    public double[] physical_BD
    {
        get { return this._physical_BD; }
        set { this._physical_BD= value; } 
    }

    private double _ps;
    /// <summary>
    /// Gets and sets the ps
    /// </summary>
    [Description("ps")] 
    [Units("")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=, parametercategory=constant, inputtype="parameter")] 
    public double ps
    {
        get { return this._ps; }
        set { this._ps= value; } 
    }

    private double[] _pInitialValues;
    /// <summary>
    /// Gets and sets the Initial soil temperature
    /// </summary>
    [Description("Initial soil temperature")] 
    [Units("oC")] 
    //[Crop2ML(datatype="DOUBLEARRAY", min=null, max=null, default=, parametercategory=constant, inputtype="parameter")] 
    public double[] pInitialValues
    {
        get { return this._pInitialValues; }
        set { this._pInitialValues= value; } 
    }

    private double _DepthToConstantTemperature;
    /// <summary>
    /// Gets and sets the Soil depth to constant temperature
    /// </summary>
    [Description("Soil depth to constant temperature")] 
    [Units("mm")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=10000, parametercategory=constant, inputtype="parameter")] 
    public double DepthToConstantTemperature
    {
        get { return this._DepthToConstantTemperature; }
        set { this._DepthToConstantTemperature= value; } 
    }

    private double _timestep;
    /// <summary>
    /// Gets and sets the Internal time-step (minutes)
    /// </summary>
    [Description("Internal time-step (minutes)")] 
    [Units("minutes")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=24.0 * 60.0 * 60.0, parametercategory=constant, inputtype="parameter")] 
    public double timestep
    {
        get { return this._timestep; }
        set { this._timestep= value; } 
    }

    private double _latentHeatOfVapourisation;
    /// <summary>
    /// Gets and sets the Latent heat of vapourisation for water
    /// </summary>
    [Description("Latent heat of vapourisation for water")] 
    [Units("miJ/kg")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=2465000, parametercategory=constant, inputtype="parameter")] 
    public double latentHeatOfVapourisation
    {
        get { return this._latentHeatOfVapourisation; }
        set { this._latentHeatOfVapourisation= value; } 
    }

    private double _stefanBoltzmannConstant;
    /// <summary>
    /// Gets and sets the The Stefan-Boltzmann constant
    /// </summary>
    [Description("The Stefan-Boltzmann constant")] 
    [Units("W/m2/K4")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=0.0000000567, parametercategory=constant, inputtype="parameter")] 
    public double stefanBoltzmannConstant
    {
        get { return this._stefanBoltzmannConstant; }
        set { this._stefanBoltzmannConstant= value; } 
    }

    private int _airNode;
    /// <summary>
    /// Gets and sets the The index of the node in the atmosphere (aboveground)
    /// </summary>
    [Description("The index of the node in the atmosphere (aboveground)")] 
    [Units("")] 
    //[Crop2ML(datatype="INT", min=null, max=null, default=0, parametercategory=constant, inputtype="parameter")] 
    public int airNode
    {
        get { return this._airNode; }
        set { this._airNode= value; } 
    }

    private int _surfaceNode;
    /// <summary>
    /// Gets and sets the The index of the node on the soil surface (depth = 0)
    /// </summary>
    [Description("The index of the node on the soil surface (depth = 0)")] 
    [Units("")] 
    //[Crop2ML(datatype="INT", min=null, max=null, default=1, parametercategory=constant, inputtype="parameter")] 
    public int surfaceNode
    {
        get { return this._surfaceNode; }
        set { this._surfaceNode= value; } 
    }

    private int _topsoilNode;
    /// <summary>
    /// Gets and sets the The index of the first node within the soil (top layer)
    /// </summary>
    [Description("The index of the first node within the soil (top layer)")] 
    [Units("")] 
    //[Crop2ML(datatype="INT", min=null, max=null, default=2, parametercategory=constant, inputtype="parameter")] 
    public int topsoilNode
    {
        get { return this._topsoilNode; }
        set { this._topsoilNode= value; } 
    }

    private int _numPhantomNodes;
    /// <summary>
    /// Gets and sets the The number of phantom nodes below the soil profile
    /// </summary>
    [Description("The number of phantom nodes below the soil profile")] 
    [Units("")] 
    //[Crop2ML(datatype="INT", min=null, max=null, default=5, parametercategory=constant, inputtype="parameter")] 
    public int numPhantomNodes
    {
        get { return this._numPhantomNodes; }
        set { this._numPhantomNodes= value; } 
    }

    private double _constantBoundaryLayerConductance;
    /// <summary>
    /// Gets and sets the Boundary layer conductance, if constant
    /// </summary>
    [Description("Boundary layer conductance, if constant")] 
    [Units("K/W")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=20, parametercategory=constant, inputtype="parameter")] 
    public double constantBoundaryLayerConductance
    {
        get { return this._constantBoundaryLayerConductance; }
        set { this._constantBoundaryLayerConductance= value; } 
    }

    private int _numIterationsForBoundaryLayerConductance;
    /// <summary>
    /// Gets and sets the Number of iterations to calculate atmosphere boundary layer conductance
    /// </summary>
    [Description("Number of iterations to calculate atmosphere boundary layer conductance")] 
    [Units("")] 
    //[Crop2ML(datatype="INT", min=null, max=None, default=1, parametercategory=constant, inputtype="parameter")] 
    public int numIterationsForBoundaryLayerConductance
    {
        get { return this._numIterationsForBoundaryLayerConductance; }
        set { this._numIterationsForBoundaryLayerConductance= value; } 
    }

    private double _defaultTimeOfMaximumTemperature;
    /// <summary>
    /// Gets and sets the Time of maximum temperature
    /// </summary>
    [Description("Time of maximum temperature")] 
    [Units("minutes")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=14.0, parametercategory=constant, inputtype="parameter")] 
    public double defaultTimeOfMaximumTemperature
    {
        get { return this._defaultTimeOfMaximumTemperature; }
        set { this._defaultTimeOfMaximumTemperature= value; } 
    }

    private double _defaultInstrumentHeight;
    /// <summary>
    /// Gets and sets the Default instrument height
    /// </summary>
    [Description("Default instrument height")] 
    [Units("m")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=1.2, parametercategory=constant, inputtype="parameter")] 
    public double defaultInstrumentHeight
    {
        get { return this._defaultInstrumentHeight; }
        set { this._defaultInstrumentHeight= value; } 
    }

    private double _bareSoilRoughness;
    /// <summary>
    /// Gets and sets the Roughness element height of bare soil
    /// </summary>
    [Description("Roughness element height of bare soil")] 
    [Units("mm")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=57, parametercategory=constant, inputtype="parameter")] 
    public double bareSoilRoughness
    {
        get { return this._bareSoilRoughness; }
        set { this._bareSoilRoughness= value; } 
    }

    private double[] _nodeDepth;
    /// <summary>
    /// Gets and sets the Depths of nodes
    /// </summary>
    [Description("Depths of nodes")] 
    [Units("mm")] 
    //[Crop2ML(datatype="DOUBLEARRAY", min=null, max=null, default=, parametercategory=private, inputtype="parameter")] 
    public double[] nodeDepth
    {
        get { return this._nodeDepth; }
        set { this._nodeDepth= value; } 
    }

    private double[] _thermCondPar1;
    /// <summary>
    /// Gets and sets the Parameter 1 for computing thermal conductivity of soil solids
    /// </summary>
    [Description("Parameter 1 for computing thermal conductivity of soil solids")] 
    [Units("")] 
    //[Crop2ML(datatype="DOUBLEARRAY", min=null, max=null, default=, parametercategory=private, inputtype="parameter")] 
    public double[] thermCondPar1
    {
        get { return this._thermCondPar1; }
        set { this._thermCondPar1= value; } 
    }

    private double[] _thermCondPar2;
    /// <summary>
    /// Gets and sets the Parameter 2 for computing thermal conductivity of soil solids
    /// </summary>
    [Description("Parameter 2 for computing thermal conductivity of soil solids")] 
    [Units("")] 
    //[Crop2ML(datatype="DOUBLEARRAY", min=null, max=null, default=, parametercategory=private, inputtype="parameter")] 
    public double[] thermCondPar2
    {
        get { return this._thermCondPar2; }
        set { this._thermCondPar2= value; } 
    }

    private double[] _thermCondPar3;
    /// <summary>
    /// Gets and sets the Parameter 3 for computing thermal conductivity of soil solids
    /// </summary>
    [Description("Parameter 3 for computing thermal conductivity of soil solids")] 
    [Units("")] 
    //[Crop2ML(datatype="DOUBLEARRAY", min=null, max=null, default=, parametercategory=private, inputtype="parameter")] 
    public double[] thermCondPar3
    {
        get { return this._thermCondPar3; }
        set { this._thermCondPar3= value; } 
    }

    private double[] _thermCondPar4;
    /// <summary>
    /// Gets and sets the Parameter 4 for computing thermal conductivity of soil solids
    /// </summary>
    [Description("Parameter 4 for computing thermal conductivity of soil solids")] 
    [Units("")] 
    //[Crop2ML(datatype="DOUBLEARRAY", min=null, max=null, default=, parametercategory=private, inputtype="parameter")] 
    public double[] thermCondPar4
    {
        get { return this._thermCondPar4; }
        set { this._thermCondPar4= value; } 
    }

    private double _pom;
    /// <summary>
    /// Gets and sets the Particle density of organic matter
    /// </summary>
    [Description("Particle density of organic matter")] 
    [Units("Mg/m3")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=, parametercategory=constant, inputtype="parameter")] 
    public double pom
    {
        get { return this._pom; }
        set { this._pom= value; } 
    }

    private double _soilRoughnessHeight;
    /// <summary>
    /// Gets and sets the Height of soil roughness
    /// </summary>
    [Description("Height of soil roughness")] 
    [Units("mm")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=0, parametercategory=private, inputtype="parameter")] 
    public double soilRoughnessHeight
    {
        get { return this._soilRoughnessHeight; }
        set { this._soilRoughnessHeight= value; } 
    }

    private double _nu;
    /// <summary>
    /// Gets and sets the Forward/backward differencing coefficient
    /// </summary>
    [Description("Forward/backward differencing coefficient")] 
    [Units("0-1")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=0.6, parametercategory=constant, inputtype="parameter")] 
    public double nu
    {
        get { return this._nu; }
        set { this._nu= value; } 
    }

    private string _boundarLayerConductanceSource;
    /// <summary>
    /// Gets and sets the Flag whether boundary layer conductance is calculated or gotten from inpu
    /// </summary>
    [Description("Flag whether boundary layer conductance is calculated or gotten from inpu")] 
    [Units("")] 
    //[Crop2ML(datatype="STRING", min=null, max=null, default=calc, parametercategory=constant, inputtype="parameter")] 
    public string boundarLayerConductanceSource
    {
        get { return this._boundarLayerConductanceSource; }
        set { this._boundarLayerConductanceSource= value; } 
    }

    private string _netRadiationSource;
    /// <summary>
    /// Gets and sets the Flag whether net radiation is calculated or gotten from input
    /// </summary>
    [Description("Flag whether net radiation is calculated or gotten from input")] 
    [Units("m")] 
    //[Crop2ML(datatype="STRING", min=null, max=null, default=calc, parametercategory=constant, inputtype="parameter")] 
    public string netRadiationSource
    {
        get { return this._netRadiationSource; }
        set { this._netRadiationSource= value; } 
    }

    private double _MissingValue;
    /// <summary>
    /// Gets and sets the missing value
    /// </summary>
    [Description("missing value")] 
    [Units("m")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=99999, parametercategory=constant, inputtype="parameter")] 
    public double MissingValue
    {
        get { return this._MissingValue; }
        set { this._MissingValue= value; } 
    }

    private string[] _soilConstituentNames;
    /// <summary>
    /// Gets and sets the soilConstituentNames
    /// </summary>
    [Description("soilConstituentNames")] 
    [Units("m")] 
    //[Crop2ML(datatype="STRINGARRAY", min=null, max=null, default=["Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"], parametercategory=constant, inputtype="parameter")] 
    public string[] soilConstituentNames
    {
        get { return this._soilConstituentNames; }
        set { this._soilConstituentNames= value; } 
    }

    
    /// <summary>
    /// Constructor of the SoilTemperature component")
    /// </summary>  
    public SoilTemperature() { }
    
    /// <summary>
    /// Algorithm of the SoilTemperature component
    /// </summary>
    public void  CalculateModel(SoiltempState s, SoiltempState s1, SoiltempRate r, SoiltempAuxiliary a, SoiltempExogenous ex)
    {
        double weather_MinT = ex.weather_MinT;
        double weather_MaxT = ex.weather_MaxT;
        double weather_MeanT = ex.weather_MeanT;
        double weather_Tav = ex.weather_Tav;
        double weather_Amp = ex.weather_Amp;
        double weather_AirPressure = ex.weather_AirPressure;
        double weather_Wind = ex.weather_Wind;
        double weather_Radn = ex.weather_Radn;
        int clock_Today_DayOfYear = ex.clock_Today_DayOfYear;
        double microClimate_CanopyHeight = ex.microClimate_CanopyHeight;
        double[] physical_Rocks = ex.physical_Rocks;
        double[] physical_ParticleSizeSand = ex.physical_ParticleSizeSand;
        double[] physical_ParticleSizeSilt = ex.physical_ParticleSizeSilt;
        double[] physical_ParticleSizeClay = ex.physical_ParticleSizeClay;
        double[] organic_Carbon = ex.organic_Carbon;
        double[] waterBalance_SW = ex.waterBalance_SW;
        double waterBalance_Eos = ex.waterBalance_Eos;
        double waterBalance_Eo = ex.waterBalance_Eo;
        double waterBalance_Es = ex.waterBalance_Es;
        double waterBalance_Salb = ex.waterBalance_Salb;
        double[] InitialValues = s.InitialValues;
        bool doInitialisationStuff = s.doInitialisationStuff;
        double internalTimeStep = s.internalTimeStep;
        double timeOfDaySecs = s.timeOfDaySecs;
        int numNodes = s.numNodes;
        int numLayers = s.numLayers;
        double[] volSpecHeatSoil = s.volSpecHeatSoil;
        double[] soilTemp = s.soilTemp;
        double[] morningSoilTemp = s.morningSoilTemp;
        double[] heatStorage = s.heatStorage;
        double[] thermalConductance = s.thermalConductance;
        double[] thermalConductivity = s.thermalConductivity;
        double boundaryLayerConductance = s.boundaryLayerConductance;
        double[] newTemperature = s.newTemperature;
        double airTemperature = s.airTemperature;
        double maxTempYesterday = s.maxTempYesterday;
        double minTempYesterday = s.minTempYesterday;
        double[] soilWater = s.soilWater;
        double[] minSoilTemp = s.minSoilTemp;
        double[] maxSoilTemp = s.maxSoilTemp;
        double[] aveSoilTemp = s.aveSoilTemp;
        double[] aveSoilWater = s.aveSoilWater;
        double[] thickness = s.thickness;
        double[] bulkDensity = s.bulkDensity;
        double[] rocks = s.rocks;
        double[] carbon = s.carbon;
        double[] sand = s.sand;
        double[] silt = s.silt;
        double[] clay = s.clay;
        double instrumentHeight = s.instrumentHeight;
        double netRadiation = s.netRadiation;
        double canopyHeight = s.canopyHeight;
        double instrumHeight = s.instrumHeight;
        int i;
        getOtherVariables(numLayers, numNodes, ref soilWater, ref instrumentHeight, soilRoughnessHeight, waterBalance_SW, microClimate_CanopyHeight, ref canopyHeight);
        if (doInitialisationStuff)
        {
            if (ValuesInArray(InitialValues, MissingValue))
            {
                soilTemp = new double[numNodes + 1 + 1];
                 Array.ConstrainedCopy(InitialValues, 0, soilTemp, topsoilNode, InitialValues.Length);
            }
            else
            {
                soilTemp = calcSoilTemperature(soilTemp, weather_Tav, clock_Today_DayOfYear, surfaceNode, numNodes, weather_Amp, thickness, weather_Latitude);
                InitialValues = new double[numLayers];
                 Array.ConstrainedCopy(soilTemp, topsoilNode, InitialValues, 0, numLayers);
            }
            soilTemp[airNode] = weather_MeanT;
            soilTemp[surfaceNode] = calcSurfaceTemperature(weather_MeanT, weather_MaxT, waterBalance_Salb, weather_Radn);
            for (i=numNodes + 1 ; i!=soilTemp.Length ; i+=1)
            {
                soilTemp[i] = weather_Tav;
            }
            soilTemp.CopyTo(newTemperature, 0);
            maxTempYesterday = weather_MaxT;
            minTempYesterday = weather_MinT;
            doInitialisationStuff = false;
        }
        doProcess(ref timeOfDaySecs, ref netRadiation, ref minSoilTemp, ref maxSoilTemp, numIterationsForBoundaryLayerConductance, timestep, ref boundaryLayerConductance, ref maxTempYesterday, airNode, ref soilTemp, ref airTemperature, ref newTemperature, weather_MaxT, ref internalTimeStep, boundarLayerConductanceSource, ref thermalConductivity, ref minTempYesterday, ref aveSoilTemp, ref morningSoilTemp, weather_MeanT, constantBoundaryLayerConductance, weather_MinT, clock_Today_DayOfYear, weather_Radn, weather_Latitude, soilConstituentNames, numNodes, ref volSpecHeatSoil, soilWater, nodeDepth, thickness, surfaceNode, MissingValue, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay, defaultTimeOfMaximumTemperature, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, stefanBoltzmannConstant, weather_AirPressure, weather_Wind, instrumentHeight, canopyHeight, ref heatStorage, netRadiationSource, latentHeatOfVapourisation, waterBalance_Es, ref thermalConductance, nu);
        s.InitialValues= InitialValues;
        s.doInitialisationStuff= doInitialisationStuff;
        s.internalTimeStep= internalTimeStep;
        s.timeOfDaySecs= timeOfDaySecs;
        s.volSpecHeatSoil= volSpecHeatSoil;
        s.soilTemp= soilTemp;
        s.morningSoilTemp= morningSoilTemp;
        s.heatStorage= heatStorage;
        s.thermalConductance= thermalConductance;
        s.thermalConductivity= thermalConductivity;
        s.boundaryLayerConductance= boundaryLayerConductance;
        s.newTemperature= newTemperature;
        s.airTemperature= airTemperature;
        s.maxTempYesterday= maxTempYesterday;
        s.minTempYesterday= minTempYesterday;
        s.soilWater= soilWater;
        s.minSoilTemp= minSoilTemp;
        s.maxSoilTemp= maxSoilTemp;
        s.aveSoilTemp= aveSoilTemp;
        s.instrumentHeight= instrumentHeight;
        s.netRadiation= netRadiation;
        s.canopyHeight= canopyHeight;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double getIniVariables(double instrumentHeight, double instrumHeight, double defaultInstrumentHeight)
    {
        if (instrumHeight > 0.00001)
        {
            instrumentHeight = instrumHeight;
        }
        else
        {
            instrumentHeight = defaultInstrumentHeight;
        }
        return instrumentHeight;
    }
    /// <summary>
    /// 
    /// </summary>
    public static void  getProfileVariables(ref double[] heatStorage, ref double[] minSoilTemp, ref double[] bulkDensity, ref int numNodes, double[] physical_BD, ref double[] maxSoilTemp, double[] waterBalance_SW, double[] organic_Carbon, double[] physical_Rocks, ref double[] nodeDepth, int topsoilNode, ref double[] newTemperature, int surfaceNode, ref double[] soilWater, ref double[] thermalConductance, ref double[] thermalConductivity, ref double[] sand, ref double[] carbon, ref double[] thickness, int numPhantomNodes, double[] physical_ParticleSizeSand, ref double[] rocks, ref double[] clay, double[] physical_ParticleSizeSilt, int airNode, double[] physical_ParticleSizeClay, ref double[] soilTemp, ref int numLayers, double[] physical_Thickness, ref double[] silt, ref double[] volSpecHeatSoil, ref double[] aveSoilTemp, ref double[] morningSoilTemp, double DepthToConstantTemperature, double MissingValue)
    {
        int layer;
        int node;
        int i;
        double belowProfileDepth;
        double thicknessForPhantomNodes;
        int firstPhantomNode;
        double[] oldDepth = null ;
        double[] oldBulkDensity = null ;
        double[] oldSoilWater = null ;
        numLayers = physical_Thickness.Length;
        numNodes = numLayers + numPhantomNodes;
        thickness = new double[numLayers + numPhantomNodes + 1];
        physical_Thickness.CopyTo(thickness, 1);
        belowProfileDepth = Math.Max(DepthToConstantTemperature - Sum(thickness, 1, numLayers, MissingValue), 1000.0);
        thicknessForPhantomNodes = belowProfileDepth * 2.0 / numPhantomNodes;
        firstPhantomNode = numLayers;
        for (i=firstPhantomNode ; i!=firstPhantomNode + numPhantomNodes ; i+=1)
        {
            thickness[i] = thicknessForPhantomNodes;
        }
        oldDepth = nodeDepth;
        nodeDepth = new double[numNodes + 1 + 1];
        if (oldDepth != null)
        {
             Array.ConstrainedCopy(oldDepth, 0, nodeDepth, 0, Math.Min(numNodes + 1 + 1, oldDepth.Length));
        }
        nodeDepth[airNode] = 0.0;
        nodeDepth[surfaceNode] = 0.0;
        nodeDepth[topsoilNode] = 0.5 * thickness[1] / 1000.0;
        for (node=topsoilNode ; node!=numNodes + 1 ; node+=1)
        {
            nodeDepth[node + 1] = (Sum(thickness, 1, node - 1, MissingValue) + (0.5 * thickness[node])) / 1000.0;
        }
        oldBulkDensity = bulkDensity;
        bulkDensity = new double[numLayers + 1 + numPhantomNodes];
        if (oldBulkDensity != null)
        {
             Array.ConstrainedCopy(oldBulkDensity, 0, bulkDensity, 0, Math.Min(numLayers + 1 + numPhantomNodes, oldBulkDensity.Length));
        }
        physical_BD.CopyTo(bulkDensity, 1);
        bulkDensity[numNodes] = bulkDensity[numLayers];
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            bulkDensity[layer] = bulkDensity[numLayers];
        }
        oldSoilWater = soilWater;
        soilWater = new double[numLayers + 1 + numPhantomNodes];
        if (oldSoilWater != null)
        {
             Array.ConstrainedCopy(oldSoilWater, 0, soilWater, 0, Math.Min(numLayers + 1 + numPhantomNodes, oldSoilWater.Length));
        }
        if (waterBalance_SW != null)
        {
            for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
            {
                soilWater[layer] = Divide(waterBalance_SW[(layer - 1)] * thickness[(layer - 1)], thickness[layer], (double)(0));
            }
            for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
            {
                soilWater[layer] = soilWater[numLayers];
            }
        }
        carbon = new double[numLayers + 1 + numPhantomNodes];
        for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
        {
            carbon[layer] = organic_Carbon[layer - 1];
        }
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            carbon[layer] = carbon[numLayers];
        }
        rocks = new double[numLayers + 1 + numPhantomNodes];
        for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
        {
            rocks[layer] = physical_Rocks[layer - 1];
        }
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            rocks[layer] = rocks[numLayers];
        }
        sand = new double[numLayers + 1 + numPhantomNodes];
        for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
        {
            sand[layer] = physical_ParticleSizeSand[layer - 1];
        }
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            sand[layer] = sand[numLayers];
        }
        silt = new double[numLayers + 1 + numPhantomNodes];
        for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
        {
            silt[layer] = physical_ParticleSizeSilt[layer - 1];
        }
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            silt[layer] = silt[numLayers];
        }
        clay = new double[numLayers + 1 + numPhantomNodes];
        for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
        {
            clay[layer] = physical_ParticleSizeClay[layer - 1];
        }
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            clay[layer] = clay[numLayers];
        }
        maxSoilTemp = new double[numLayers + 1 + numPhantomNodes];
        minSoilTemp = new double[numLayers + 1 + numPhantomNodes];
        aveSoilTemp = new double[numLayers + 1 + numPhantomNodes];
        volSpecHeatSoil = new double[numNodes + 1];
        soilTemp = new double[numNodes + 1 + 1];
        morningSoilTemp = new double[numNodes + 1 + 1];
        newTemperature = new double[numNodes + 1 + 1];
        thermalConductivity = new double[numNodes + 1];
        heatStorage = new double[numNodes + 1];
        thermalConductance = new double[numNodes + 1 + 1];
    }
    /// <summary>
    /// 
    /// </summary>
    public static void  doThermalConductivityCoeffs(ref double[] thermCondPar2, int numLayers, double[] bulkDensity, int numNodes, ref double[] thermCondPar3, ref double[] thermCondPar4, double[] clay, ref double[] thermCondPar1)
    {
        int layer;
        double[] oldGC1 = null ;
        double[] oldGC2 = null ;
        double[] oldGC3 = null ;
        double[] oldGC4 = null ;
        int element;
        oldGC1 = thermCondPar1;
        thermCondPar1 = new double[numNodes + 1];
        if (oldGC1 != null)
        {
             Array.ConstrainedCopy(oldGC1, 0, thermCondPar1, 0, Math.Min(numNodes + 1, oldGC1.Length));
        }
        oldGC2 = thermCondPar2;
        thermCondPar2 = new double[numNodes + 1];
        if (oldGC2 != null)
        {
             Array.ConstrainedCopy(oldGC2, 0, thermCondPar2, 0, Math.Min(numNodes + 1, oldGC2.Length));
        }
        oldGC3 = thermCondPar3;
        thermCondPar3 = new double[numNodes + 1];
        if (oldGC3 != null)
        {
             Array.ConstrainedCopy(oldGC3, 0, thermCondPar3, 0, Math.Min(numNodes + 1, oldGC3.Length));
        }
        oldGC4 = thermCondPar4;
        thermCondPar4 = new double[numNodes + 1];
        if (oldGC4 != null)
        {
             Array.ConstrainedCopy(oldGC4, 0, thermCondPar4, 0, Math.Min(numNodes + 1, oldGC4.Length));
        }
        for (layer=1 ; layer!=numLayers + 1 + 1 ; layer+=1)
        {
            element = layer;
            thermCondPar1[element] = 0.65 - (0.78 * bulkDensity[layer]) + (0.6 * Math.Pow(bulkDensity[layer], 2));
            thermCondPar2[element] = 1.06 * bulkDensity[layer];
            thermCondPar3[element] = 1.0 + Divide(2.6, Math.Sqrt(clay[layer]), (double)(0));
            thermCondPar4[element] = 0.03 + (0.1 * Math.Pow(bulkDensity[layer], 2));
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static void  readParam(double bareSoilRoughness, ref double[] newTemperature, ref double soilRoughnessHeight, ref double[] soilTemp, ref double[] thermCondPar2, int numLayers, double[] bulkDensity, int numNodes, ref double[] thermCondPar3, ref double[] thermCondPar4, double[] clay, ref double[] thermCondPar1, double weather_Tav, int clock_Today_DayOfYear, int surfaceNode, double weather_Amp, double[] thickness, double weather_Latitude)
    {
        doThermalConductivityCoeffs(ref thermCondPar2, numLayers, bulkDensity, numNodes, ref thermCondPar3, ref thermCondPar4, clay, ref thermCondPar1);
        soilTemp = calcSoilTemperature(soilTemp, weather_Tav, clock_Today_DayOfYear, surfaceNode, numNodes, weather_Amp, thickness, weather_Latitude);
        soilTemp.CopyTo(newTemperature, 0);
        soilRoughnessHeight = bareSoilRoughness;
    }
    /// <summary>
    /// 
    /// </summary>
    public static void  getOtherVariables(int numLayers, int numNodes, ref double[] soilWater, ref double instrumentHeight, double soilRoughnessHeight, double[] waterBalance_SW, double microClimate_CanopyHeight, ref double canopyHeight)
    {
        waterBalance_SW.CopyTo(soilWater, 1);
        soilWater[numNodes] = soilWater[numLayers];
        canopyHeight = Math.Max(microClimate_CanopyHeight, soilRoughnessHeight) / 1000.0;
        instrumentHeight = Math.Max(instrumentHeight, canopyHeight + 0.5);
    }
    /// <summary>
    /// 
    /// </summary>
    public static double volumetricFractionOrganicMatter(int layer, double[] carbon, double[] bulkDensity, double pom)
    {
        return carbon[layer] / 100.0 * 2.5 * bulkDensity[layer] / pom;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double volumetricFractionRocks(int layer, double[] rocks)
    {
        return rocks[layer] / 100.0;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double volumetricFractionIce(int layer)
    {
        return 0.0;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double volumetricFractionWater(int layer, double[] soilWater, double[] carbon, double[] bulkDensity, double pom)
    {
        return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom)) * soilWater[layer];
    }
    /// <summary>
    /// 
    /// </summary>
    public static double volumetricFractionClay(int layer, double[] bulkDensity, double ps, double[] clay, double[] carbon, double pom, double[] rocks)
    {
        return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * clay[layer] / 100.0 * bulkDensity[layer] / ps;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double volumetricFractionSilt(int layer, double[] bulkDensity, double[] silt, double ps, double[] carbon, double pom, double[] rocks)
    {
        return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * silt[layer] / 100.0 * bulkDensity[layer] / ps;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double volumetricFractionSand(int layer, double[] bulkDensity, double[] sand, double ps, double[] carbon, double pom, double[] rocks)
    {
        return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * sand[layer] / 100.0 * bulkDensity[layer] / ps;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double kelvinT(double celciusT)
    {
        double celciusToKelvin;
        celciusToKelvin = 273.18;
        return celciusT + celciusToKelvin;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double Divide(double value1, double value2, double errVal)
    {
        if (value2 != (double)(0))
        {
            return value1 / value2;
        }
        return errVal;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double Sum(double[] values, int startIndex, int endIndex, double MissingValue)
    {
        double value;
        double result;
        int index;
        result = 0.0;
        index = -1;
        foreach(float value_cyml in values)
        {
            value = value_cyml;
            index = index + 1;
            if (index >= startIndex && value != MissingValue)
            {
                result = result + value;
            }
            if (index == endIndex)
            {
                break;
            }
        }
        return result;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double volumetricSpecificHeat(string name, int layer)
    {
        double specificHeatRocks;
        double specificHeatOM;
        double specificHeatSand;
        double specificHeatSilt;
        double specificHeatClay;
        double specificHeatWater;
        double specificHeatIce;
        double specificHeatAir;
        double result;
        specificHeatRocks = 7.7;
        specificHeatOM = 0.25;
        specificHeatSand = 7.7;
        specificHeatSilt = 2.74;
        specificHeatClay = 2.92;
        specificHeatWater = 0.57;
        specificHeatIce = 2.18;
        specificHeatAir = 0.025;
        result = 0.0;
        if (name == "Rocks")
        {
            result = specificHeatRocks;
        }
        else if ( name == "OrganicMatter")
        {
            result = specificHeatOM;
        }
        else if ( name == "Sand")
        {
            result = specificHeatSand;
        }
        else if ( name == "Silt")
        {
            result = specificHeatSilt;
        }
        else if ( name == "Clay")
        {
            result = specificHeatClay;
        }
        else if ( name == "Water")
        {
            result = specificHeatWater;
        }
        else if ( name == "Ice")
        {
            result = specificHeatIce;
        }
        else if ( name == "Air")
        {
            result = specificHeatAir;
        }
        return result;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double volumetricFractionAir(int layer, double[] rocks, double[] carbon, double[] bulkDensity, double pom, double[] sand, double ps, double[] silt, double[] clay, double[] soilWater)
    {
        return 1.0 - volumetricFractionRocks(layer, rocks) - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks) - volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks) - volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks) - volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) - volumetricFractionIce(layer);
    }
    /// <summary>
    /// 
    /// </summary>
    public static double airDensity(double temperature, double AirPressure)
    {
        double MWair;
        double RGAS;
        double HPA2PA;
        MWair = 0.02897;
        RGAS = 8.3143;
        HPA2PA = 100.0;
        return Divide(MWair * AirPressure * HPA2PA, kelvinT(temperature) * RGAS, 0.0);
    }
    /// <summary>
    /// 
    /// </summary>
    public static double longWaveRadn(double emissivity, double tDegC, double stefanBoltzmannConstant)
    {
        return stefanBoltzmannConstant * emissivity * Math.Pow(kelvinT(tDegC), 4);
    }
    /// <summary>
    /// 
    /// </summary>
    public static double[] mapLayer2Node(double[] layerArray, double[] nodeArray, double[] nodeDepth, int numNodes, double[] thickness, int surfaceNode, double MissingValue)
    {
        int node;
        int layer;
        double depthLayerAbove;
        double d1;
        double d2;
        double dSum;
        for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
        {
            layer = node - 1;
            depthLayerAbove = layer >= 1 ? Sum(thickness, 1, layer, MissingValue) : 0.0;
            d1 = depthLayerAbove - (nodeDepth[node] * 1000.0);
            d2 = nodeDepth[(node + 1)] * 1000.0 - depthLayerAbove;
            dSum = d1 + d2;
            nodeArray[node] = Divide(layerArray[layer] * d1, dSum, (double)(0)) + Divide(layerArray[(layer + 1)] * d2, dSum, (double)(0));
        }
        return nodeArray;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double ThermalConductance(string name, int layer, double[] rocks, double[] bulkDensity, double[] sand, double ps, double[] carbon, double pom, double[] silt, double[] clay)
    {
        double thermalConductanceRocks;
        double thermalConductanceOM;
        double thermalConductanceSand;
        double thermalConductanceSilt;
        double thermalConductanceClay;
        double thermalConductanceWater;
        double thermalConductanceIce;
        double thermalConductanceAir;
        double result;
        thermalConductanceRocks = 0.182;
        thermalConductanceOM = 2.50;
        thermalConductanceSand = 0.182;
        thermalConductanceSilt = 2.39;
        thermalConductanceClay = 1.39;
        thermalConductanceWater = 4.18;
        thermalConductanceIce = 1.73;
        thermalConductanceAir = 0.0012;
        result = 0.0;
        if (name == "Rocks")
        {
            result = thermalConductanceRocks;
        }
        else if ( name == "OrganicMatter")
        {
            result = thermalConductanceOM;
        }
        else if ( name == "Sand")
        {
            result = thermalConductanceSand;
        }
        else if ( name == "Silt")
        {
            result = thermalConductanceSilt;
        }
        else if ( name == "Clay")
        {
            result = thermalConductanceClay;
        }
        else if ( name == "Water")
        {
            result = thermalConductanceWater;
        }
        else if ( name == "Ice")
        {
            result = thermalConductanceIce;
        }
        else if ( name == "Air")
        {
            result = thermalConductanceAir;
        }
        else if ( name == "Minerals")
        {
            result = Math.Pow(thermalConductanceRocks, volumetricFractionRocks(layer, rocks)) * Math.Pow(thermalConductanceSand, volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks)) + Math.Pow(thermalConductanceSilt, volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + Math.Pow(thermalConductanceClay, volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks));
        }
        result = volumetricSpecificHeat(name, layer);
        return result;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double shapeFactor(string name, int layer, double[] soilWater, double[] carbon, double[] bulkDensity, double pom, double[] rocks, double[] sand, double ps, double[] silt, double[] clay)
    {
        double shapeFactorRocks;
        double shapeFactorOM;
        double shapeFactorSand;
        double shapeFactorSilt;
        double shapeFactorClay;
        double shapeFactorWater;
        double result;
        shapeFactorRocks = 0.182;
        shapeFactorOM = 0.5;
        shapeFactorSand = 0.182;
        shapeFactorSilt = 0.125;
        shapeFactorClay = 0.007755;
        shapeFactorWater = 1.0;
        result = 0.0;
        if (name == "Rocks")
        {
            result = shapeFactorRocks;
        }
        else if ( name == "OrganicMatter")
        {
            result = shapeFactorOM;
        }
        else if ( name == "Sand")
        {
            result = shapeFactorSand;
        }
        else if ( name == "Silt")
        {
            result = shapeFactorSilt;
        }
        else if ( name == "Clay")
        {
            result = shapeFactorClay;
        }
        else if ( name == "Water")
        {
            result = shapeFactorWater;
        }
        else if ( name == "Ice")
        {
            result = 0.333 - (0.333 * volumetricFractionIce(layer) / (volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater)));
            return result;
        }
        else if ( name == "Air")
        {
            result = 0.333 - (0.333 * volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater) / (volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater)));
            return result;
        }
        else if ( name == "Minerals")
        {
            result = shapeFactorRocks * volumetricFractionRocks(layer, rocks) + (shapeFactorSand * volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks)) + (shapeFactorSilt * volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + (shapeFactorClay * volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks));
        }
        result = volumetricSpecificHeat(name, layer);
        return result;
    }
    /// <summary>
    /// 
    /// </summary>
    public static void  doUpdate(int numInterationsPerDay, double timeOfDaySecs, ref double boundaryLayerConductance, ref double[] minSoilTemp, int airNode, ref double[] soilTemp, double[] newTemperature, int numNodes, int surfaceNode, double internalTimeStep, ref double[] maxSoilTemp, ref double[] aveSoilTemp, double[] thermalConductivity)
    {
        int node;
        newTemperature.CopyTo(soilTemp, 0);
        if (timeOfDaySecs < (internalTimeStep * 1.2))
        {
            for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
            {
                minSoilTemp[node] = soilTemp[node];
                maxSoilTemp[node] = soilTemp[node];
            }
        }
        for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
        {
            if (soilTemp[node] < minSoilTemp[node])
            {
                minSoilTemp[node] = soilTemp[node];
            }
            else if ( soilTemp[node] > maxSoilTemp[node])
            {
                maxSoilTemp[node] = soilTemp[node];
            }
            aveSoilTemp[node] = aveSoilTemp[node] + Divide(soilTemp[node], (double)(numInterationsPerDay), (double)(0));
        }
        boundaryLayerConductance = boundaryLayerConductance + Divide(thermalConductivity[airNode], (double)(numInterationsPerDay), (double)(0));
    }
    /// <summary>
    /// 
    /// </summary>
    public static void  doThomas(ref double[] newTemps, double netRadiation, ref double[] heatStorage, double waterBalance_Eos, int numNodes, double timestep, string netRadiationSource, double latentHeatOfVapourisation, double[] nodeDepth, double waterBalance_Es, int airNode, double[] soilTemp, int surfaceNode, double internalTimeStep, ref double[] thermalConductance, double[] thermalConductivity, double nu, double[] volSpecHeatSoil)
    {
        int node;
        double[] a =  new double [numNodes + 1 + 1];
        double[] b =  new double [numNodes + 1];
        double[] c =  new double [numNodes + 1];
        double[] d =  new double [numNodes + 1];
        double volumeOfSoilAtNode;
        double elementLength;
        double g;
        double sensibleHeatFlux;
        double radnNet;
        double latentHeatFlux;
        double soilSurfaceHeatFlux;
        thermalConductance[airNode] = thermalConductivity[airNode];
        for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
        {
            volumeOfSoilAtNode = 0.5 * (nodeDepth[node + 1] - nodeDepth[node - 1]);
            heatStorage[node] = Divide(volSpecHeatSoil[node] * volumeOfSoilAtNode, internalTimeStep, (double)(0));
            elementLength = nodeDepth[node + 1] - nodeDepth[node];
            thermalConductance[node] = Divide(thermalConductivity[node], elementLength, (double)(0));
        }
        g = 1 - nu;
        for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
        {
            c[node] = -nu * thermalConductance[node];
            a[node + 1] = c[node];
            b[node] = nu * (thermalConductance[node] + thermalConductance[node - 1]) + heatStorage[node];
            d[node] = g * thermalConductance[(node - 1)] * soilTemp[(node - 1)] + ((heatStorage[node] - (g * (thermalConductance[node] + thermalConductance[node - 1]))) * soilTemp[node]) + (g * thermalConductance[node] * soilTemp[(node + 1)]);
        }
        a[surfaceNode] = 0.0;
        sensibleHeatFlux = nu * thermalConductance[airNode] * newTemps[airNode];
        radnNet = 0.0;
        if (netRadiationSource == "calc")
        {
            radnNet = Divide(netRadiation * 1000000.0, internalTimeStep, (double)(0));
        }
        else if ( netRadiationSource == "eos")
        {
            radnNet = Divide(waterBalance_Eos * latentHeatOfVapourisation, timestep, (double)(0));
        }
        latentHeatFlux = Divide(waterBalance_Es * latentHeatOfVapourisation, timestep, (double)(0));
        soilSurfaceHeatFlux = sensibleHeatFlux + radnNet - latentHeatFlux;
        d[surfaceNode] = d[surfaceNode] + soilSurfaceHeatFlux;
        d[numNodes] = d[numNodes] + (nu * thermalConductance[numNodes] * newTemps[(numNodes + 1)]);
        for (node=surfaceNode ; node!=numNodes - 1 + 1 ; node+=1)
        {
            c[node] = Divide(c[node], b[node], (double)(0));
            d[node] = Divide(d[node], b[node], (double)(0));
            b[node + 1] = b[node + 1] - (a[(node + 1)] * c[node]);
            d[node + 1] = d[node + 1] - (a[(node + 1)] * d[node]);
        }
        newTemps[numNodes] = Divide(d[numNodes], b[numNodes], (double)(0));
        for (node=numNodes - 1 ; node!=surfaceNode - 1 ; node+=-1)
        {
            newTemps[node] = d[node] - (c[node] * newTemps[(node + 1)]);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static double getBoundaryLayerConductance(ref double[] TNew_zb, double weather_AirPressure, double stefanBoltzmannConstant, double waterBalance_Eos, double weather_Wind, double airTemperature, int surfaceNode, double waterBalance_Eo, double instrumentHeight, double canopyHeight)
    {
        int iteration;
        double vonKarmanConstant;
        double gravitationalConstant;
        double specificHeatOfAir;
        double surfaceEmissivity;
        double SpecificHeatAir;
        double roughnessFactorMomentum;
        double roughnessFactorHeat;
        double d;
        double surfaceTemperature;
        double diffusePenetrationConstant;
        double radiativeConductance;
        double frictionVelocity;
        double boundaryLayerCond;
        double stabilityParammeter;
        double stabilityCorrectionMomentum;
        double stabilityCorrectionHeat;
        double heatFluxDensity;
        vonKarmanConstant = 0.41;
        gravitationalConstant = 9.8;
        specificHeatOfAir = 1010.0;
        surfaceEmissivity = 0.98;
        SpecificHeatAir = specificHeatOfAir * airDensity(airTemperature, weather_AirPressure);
        roughnessFactorMomentum = 0.13 * canopyHeight;
        roughnessFactorHeat = 0.2 * roughnessFactorMomentum;
        d = 0.77 * canopyHeight;
        surfaceTemperature = TNew_zb[surfaceNode];
        diffusePenetrationConstant = Math.Max(0.1, waterBalance_Eos) / Math.Max(0.1, waterBalance_Eo);
        radiativeConductance = 4.0 * stefanBoltzmannConstant * surfaceEmissivity * diffusePenetrationConstant * Math.Pow(kelvinT(airTemperature), 3);
        frictionVelocity = 0.0;
        boundaryLayerCond = 0.0;
        stabilityParammeter = 0.0;
        stabilityCorrectionMomentum = 0.0;
        stabilityCorrectionHeat = 0.0;
        heatFluxDensity = 0.0;
        for (iteration=1 ; iteration!=3 + 1 ; iteration+=1)
        {
            frictionVelocity = Divide(weather_Wind * vonKarmanConstant, Math.Log(Divide(instrumentHeight - d + roughnessFactorMomentum, roughnessFactorMomentum, (double)(0))) + stabilityCorrectionMomentum, (double)(0));
            boundaryLayerCond = Divide(SpecificHeatAir * vonKarmanConstant * frictionVelocity, Math.Log(Divide(instrumentHeight - d + roughnessFactorHeat, roughnessFactorHeat, (double)(0))) + stabilityCorrectionHeat, (double)(0));
            boundaryLayerCond = boundaryLayerCond + radiativeConductance;
            heatFluxDensity = boundaryLayerCond * (surfaceTemperature - airTemperature);
            stabilityParammeter = Divide(-vonKarmanConstant * instrumentHeight * gravitationalConstant * heatFluxDensity, SpecificHeatAir * kelvinT(airTemperature) * Math.Pow(frictionVelocity, 3.0), (double)(0));
            if (stabilityParammeter > 0.0)
            {
                stabilityCorrectionHeat = 4.7 * stabilityParammeter;
                stabilityCorrectionMomentum = stabilityCorrectionHeat;
            }
            else
            {
                stabilityCorrectionHeat = -2.0 * Math.Log((1.0 + Math.Sqrt(1.0 - (16.0 * stabilityParammeter))) / 2.0);
                stabilityCorrectionMomentum = 0.6 * stabilityCorrectionHeat;
            }
        }
        return boundaryLayerCond;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double interpolateNetRadiation(double solarRadn, double cloudFr, double cva, double waterBalance_Eo, double waterBalance_Eos, double waterBalance_Salb, double[] soilTemp, double airTemperature, int surfaceNode, double internalTimeStep, double stefanBoltzmannConstant)
    {
        double surfaceEmissivity;
        double w2MJ;
        double emissivityAtmos;
        double PenetrationConstant;
        double lwRinSoil;
        double lwRoutSoil;
        double lwRnetSoil;
        double swRin;
        double swRout;
        double swRnetSoil;
        surfaceEmissivity = 0.96;
        w2MJ = internalTimeStep / 1000000.0;
        emissivityAtmos = (1 - (0.84 * cloudFr)) * 0.58 * Math.Pow(cva, 1.0 / 7.0) + (0.84 * cloudFr);
        PenetrationConstant = Divide(Math.Max(0.1, waterBalance_Eos), Math.Max(0.1, waterBalance_Eo), (double)(0));
        lwRinSoil = longWaveRadn(emissivityAtmos, airTemperature, stefanBoltzmannConstant) * PenetrationConstant * w2MJ;
        lwRoutSoil = longWaveRadn(surfaceEmissivity, soilTemp[surfaceNode], stefanBoltzmannConstant) * PenetrationConstant * w2MJ;
        lwRnetSoil = lwRinSoil - lwRoutSoil;
        swRin = solarRadn;
        swRout = waterBalance_Salb * solarRadn;
        swRnetSoil = (swRin - swRout) * PenetrationConstant;
        return swRnetSoil + lwRnetSoil;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double interpolateTemperature(double timeHours, double minTempYesterday, double maxTempYesterday, double weather_MeanT, double weather_MaxT, double weather_MinT, double defaultTimeOfMaximumTemperature)
    {
        double time;
        double maxT_time;
        double minT_time;
        double midnightT;
        double tScale;
        double currentTemperature;
        time = timeHours / 24.0;
        maxT_time = defaultTimeOfMaximumTemperature / 24.0;
        minT_time = maxT_time - 0.5;
        if (time < minT_time)
        {
            midnightT = Math.Sin((0.0 + 0.25 - maxT_time) * 2.0 * Math.PI) * (maxTempYesterday - minTempYesterday) / 2.0 + ((maxTempYesterday + minTempYesterday) / 2.0);
            tScale = (minT_time - time) / minT_time;
            if (tScale > 1.0)
            {
                tScale = 1.0;
            }
            else if ( tScale < (double)(0))
            {
                tScale = (double)(0);
            }
            currentTemperature = weather_MinT + (tScale * (midnightT - weather_MinT));
            return currentTemperature;
        }
        else
        {
            currentTemperature = Math.Sin((time + 0.25 - maxT_time) * 2.0 * Math.PI) * (weather_MaxT - weather_MinT) / 2.0 + weather_MeanT;
            return currentTemperature;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static double[] doThermalConductivity(string[] soilConstituentNames, int numNodes, double[] soilWater, double[] thermalConductivity, double[] carbon, double[] bulkDensity, double pom, double[] rocks, double[] sand, double ps, double[] silt, double[] clay, double[] nodeDepth, double[] thickness, int surfaceNode, double MissingValue)
    {
        int node;
        string constituentName;
        double[] thermCondLayers =  new double [numNodes + 1];
        double numerator;
        double denominator;
        double shapeFactorConstituent;
        double thermalConductanceConstituent;
        double thermalConductanceWater;
        double k;
        for (node=1 ; node!=numNodes + 1 ; node+=1)
        {
            numerator = 0.0;
            denominator = 0.0;
            foreach(string constituentName_cyml in soilConstituentNames)
            {
                constituentName = constituentName_cyml;
                shapeFactorConstituent = shapeFactor(constituentName, node, soilWater, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay);
                thermalConductanceConstituent = ThermalConductance(constituentName, node, rocks, bulkDensity, sand, ps, carbon, pom, silt, clay);
                thermalConductanceWater = ThermalConductance("Water", node, rocks, bulkDensity, sand, ps, carbon, pom, silt, clay);
                k = 2.0 / 3.0 * Math.Pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0))), -1) + (1.0 / 3.0 * Math.Pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0) * (1 - (2 * shapeFactorConstituent)))), -1));
                numerator = numerator + (thermalConductanceConstituent * soilWater[node] * k);
                denominator = denominator + (soilWater[node] * k);
            }
            thermCondLayers[node] = numerator / denominator;
        }
        thermalConductivity = mapLayer2Node(thermCondLayers, thermalConductivity, nodeDepth, numNodes, thickness, surfaceNode, MissingValue);
        return thermalConductivity;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double[] doVolumetricSpecificHeat(string[] soilConstituentNames, int numNodes, double[] volSpecHeatSoil, double[] soilWater, double[] nodeDepth, double[] thickness, int surfaceNode, double MissingValue)
    {
        int node;
        string constituentName;
        double[] volspecHeatSoil_ =  new double [numNodes + 1];
        for (node=1 ; node!=numNodes + 1 ; node+=1)
        {
            volspecHeatSoil_[node] = (double)(0);
            foreach(string constituentName_cyml in soilConstituentNames)
            {
                constituentName = constituentName_cyml;
                if (!new List<string>{"Minerals"}.Contains(constituentName))
                {
                    volspecHeatSoil_[node] = volspecHeatSoil_[node] + (volumetricSpecificHeat(constituentName, node) * 1000000.0 * soilWater[node]);
                }
            }
        }
        volSpecHeatSoil = mapLayer2Node(volspecHeatSoil_, volSpecHeatSoil, nodeDepth, numNodes, thickness, surfaceNode, MissingValue);
        return volSpecHeatSoil;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double[] Zero(double[] arr)
    {
        int i;
        if (arr != null)
        {
            for (i=0 ; i!=arr.Length ; i+=1)
            {
                arr[i] = (double)(0);
            }
        }
        return arr;
    }
    /// <summary>
    /// 
    /// </summary>
    public static void  doNetRadiation(ref double[] solarRadn, ref double cloudFr, ref double cva, int ITERATIONSperDAY, double weather_MinT, int clock_Today_DayOfYear, double weather_Radn, double weather_Latitude)
    {
        int timestepNumber;
        double TSTEPS2RAD;
        double solarConstant;
        double solarDeclination;
        double cD;
        double[] m1 =  new double [ITERATIONSperDAY + 1];
        double m1Tot;
        double psr;
        double fr;
        TSTEPS2RAD = Divide(2.0 * Math.PI, (double)(ITERATIONSperDAY), (double)(0));
        solarConstant = 1360.0;
        solarDeclination = 0.3985 * Math.Sin((4.869 + (clock_Today_DayOfYear * 2.0 * Math.PI / 365.25) + (0.03345 * Math.Sin((6.224 + (clock_Today_DayOfYear * 2.0 * Math.PI / 365.25))))));
        cD = Math.Sqrt(1.0 - (solarDeclination * solarDeclination));
        m1Tot = 0.0;
        for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
        {
            m1[timestepNumber] = (solarDeclination * Math.Sin(weather_Latitude * Math.PI / 180.0) + (cD * Math.Cos(weather_Latitude * Math.PI / 180.0) * Math.Cos(TSTEPS2RAD * (timestepNumber - (ITERATIONSperDAY / 2.0))))) * 24.0 / ITERATIONSperDAY;
            if (m1[timestepNumber] > 0.0)
            {
                m1Tot = m1Tot + m1[timestepNumber];
            }
            else
            {
                m1[timestepNumber] = 0.0;
            }
        }
        psr = m1Tot * solarConstant * 3600.0 / 1000000.0;
        fr = Divide(Math.Max(weather_Radn, 0.1), psr, (double)(0));
        cloudFr = 2.33 - (3.33 * fr);
        cloudFr = Math.Min(Math.Max(cloudFr, 0.0), 1.0);
        for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
        {
            solarRadn[timestepNumber] = Math.Max(weather_Radn, 0.1) * Divide(m1[timestepNumber], m1Tot, (double)(0));
        }
        cva = Math.Exp((31.3716 - (6014.79 / kelvinT(weather_MinT)) - (0.00792495 * kelvinT(weather_MinT)))) / kelvinT(weather_MinT);
    }
    /// <summary>
    /// 
    /// </summary>
    public static void  doProcess(ref double timeOfDaySecs, ref double netRadiation, ref double[] minSoilTemp, ref double[] maxSoilTemp, int numIterationsForBoundaryLayerConductance, double timestep, ref double boundaryLayerConductance, ref double maxTempYesterday, int airNode, ref double[] soilTemp, ref double airTemperature, ref double[] newTemperature, double weather_MaxT, ref double internalTimeStep, string boundarLayerConductanceSource, ref double[] thermalConductivity, ref double minTempYesterday, ref double[] aveSoilTemp, ref double[] morningSoilTemp, double weather_MeanT, double constantBoundaryLayerConductance, double weather_MinT, int clock_Today_DayOfYear, double weather_Radn, double weather_Latitude, string[] soilConstituentNames, int numNodes, ref double[] volSpecHeatSoil, double[] soilWater, double[] nodeDepth, double[] thickness, int surfaceNode, double MissingValue, double[] carbon, double[] bulkDensity, double pom, double[] rocks, double[] sand, double ps, double[] silt, double[] clay, double defaultTimeOfMaximumTemperature, double waterBalance_Eo, double waterBalance_Eos, double waterBalance_Salb, double stefanBoltzmannConstant, double weather_AirPressure, double weather_Wind, double instrumentHeight, double canopyHeight, ref double[] heatStorage, string netRadiationSource, double latentHeatOfVapourisation, double waterBalance_Es, ref double[] thermalConductance, double nu)
    {
        int timeStepIteration;
        int iteration;
        int interactionsPerDay;
        double cva;
        double cloudFr;
        double[] solarRadn =  new double [49];
        interactionsPerDay = 48;
        cva = 0.0;
        cloudFr = 0.0;
        doNetRadiation(ref solarRadn, ref cloudFr, ref cva, interactionsPerDay, weather_MinT, clock_Today_DayOfYear, weather_Radn, weather_Latitude);
        minSoilTemp = Zero(minSoilTemp);
        maxSoilTemp = Zero(maxSoilTemp);
        aveSoilTemp = Zero(aveSoilTemp);
        boundaryLayerConductance = 0.0;
        internalTimeStep = Math.Round(timestep / interactionsPerDay);
        volSpecHeatSoil = doVolumetricSpecificHeat(soilConstituentNames, numNodes, volSpecHeatSoil, soilWater, nodeDepth, thickness, surfaceNode, MissingValue);
        thermalConductivity = doThermalConductivity(soilConstituentNames, numNodes, soilWater, thermalConductivity, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay, nodeDepth, thickness, surfaceNode, MissingValue);
        for (timeStepIteration=1 ; timeStepIteration!=interactionsPerDay + 1 ; timeStepIteration+=1)
        {
            timeOfDaySecs = internalTimeStep * (double)(timeStepIteration);
            if (timestep < (24.0 * 60.0 * 60.0))
            {
                airTemperature = weather_MeanT;
            }
            else
            {
                airTemperature = interpolateTemperature(timeOfDaySecs / 3600.0, minTempYesterday, maxTempYesterday, weather_MeanT, weather_MaxT, weather_MinT, defaultTimeOfMaximumTemperature);
            }
            newTemperature[airNode] = airTemperature;
            netRadiation = interpolateNetRadiation(solarRadn[timeStepIteration], cloudFr, cva, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, soilTemp, airTemperature, surfaceNode, internalTimeStep, stefanBoltzmannConstant);
            if (boundarLayerConductanceSource == "constant")
            {
                thermalConductivity[airNode] = constantBoundaryLayerConductance;
            }
            else if ( boundarLayerConductanceSource == "calc")
            {
                thermalConductivity[airNode] = getBoundaryLayerConductance(ref newTemperature, weather_AirPressure, stefanBoltzmannConstant, waterBalance_Eos, weather_Wind, airTemperature, surfaceNode, waterBalance_Eo, instrumentHeight, canopyHeight);
                for (iteration=1 ; iteration!=numIterationsForBoundaryLayerConductance + 1 ; iteration+=1)
                {
                    doThomas(ref newTemperature, netRadiation, ref heatStorage, waterBalance_Eos, numNodes, timestep, netRadiationSource, latentHeatOfVapourisation, nodeDepth, waterBalance_Es, airNode, soilTemp, surfaceNode, internalTimeStep, ref thermalConductance, thermalConductivity, nu, volSpecHeatSoil);
                    thermalConductivity[airNode] = getBoundaryLayerConductance(ref newTemperature, weather_AirPressure, stefanBoltzmannConstant, waterBalance_Eos, weather_Wind, airTemperature, surfaceNode, waterBalance_Eo, instrumentHeight, canopyHeight);
                }
            }
            doThomas(ref newTemperature, netRadiation, ref heatStorage, waterBalance_Eos, numNodes, timestep, netRadiationSource, latentHeatOfVapourisation, nodeDepth, waterBalance_Es, airNode, soilTemp, surfaceNode, internalTimeStep, ref thermalConductance, thermalConductivity, nu, volSpecHeatSoil);
            doUpdate(interactionsPerDay, timeOfDaySecs, ref boundaryLayerConductance, ref minSoilTemp, airNode, ref soilTemp, newTemperature, numNodes, surfaceNode, internalTimeStep, ref maxSoilTemp, ref aveSoilTemp, thermalConductivity);
            if (Math.Abs(timeOfDaySecs - (5.0 * 3600.0)) <= (Math.Min(timeOfDaySecs, 5.0 * 3600.0) * 0.0001))
            {
                soilTemp.CopyTo(morningSoilTemp, 0);
            }
        }
        minTempYesterday = weather_MinT;
        maxTempYesterday = weather_MaxT;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double[] ToCumThickness(double[] Thickness)
    {
        int Layer;
        double[] CumThickness =  new double [Thickness.Length];
        if (Thickness.Length > 0)
        {
            CumThickness[0] = Thickness[0];
            for (Layer=1 ; Layer!=Thickness.Length ; Layer+=1)
            {
                CumThickness[Layer] = Thickness[Layer] + CumThickness[Layer - 1];
            }
        }
        return CumThickness;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double[] calcSoilTemperature(double[] soilTempIO, double weather_Tav, int clock_Today_DayOfYear, int surfaceNode, int numNodes, double weather_Amp, double[] thickness, double weather_Latitude)
    {
        int nodes;
        double[] cumulativeDepth = null ;
        double w;
        double dh;
        double zd;
        double offset;
        double[] soilTemp =  new double [numNodes + 1 + 1];
        cumulativeDepth = ToCumThickness(thickness);
        w = 2 * Math.PI / (365.25 * 24 * 3600);
        dh = 0.6;
        zd = Math.Sqrt(2 * dh / w);
        offset = 0.25;
        if (weather_Latitude > 0.0)
        {
            offset = -0.25;
        }
        for (nodes=1 ; nodes!=numNodes + 1 ; nodes+=1)
        {
            soilTemp[nodes] = weather_Tav + (weather_Amp * Math.Exp(-1 * cumulativeDepth[nodes] / zd) * Math.Sin(((clock_Today_DayOfYear / 365.0 + offset) * 2.0 * Math.PI - (cumulativeDepth[nodes] / zd))));
        }
         Array.ConstrainedCopy(soilTemp, 0, soilTempIO, surfaceNode, numNodes);
        return soilTempIO;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double calcSurfaceTemperature(double weather_MeanT, double weather_MaxT, double waterBalance_Salb, double weather_Radn)
    {
        double surfaceT;
        surfaceT = (1.0 - waterBalance_Salb) * (weather_MeanT + ((weather_MaxT - weather_MeanT) * Math.Sqrt(Math.Max(weather_Radn, 0.1) * 23.8846 / 800.0))) + (waterBalance_Salb * weather_MeanT);
        return surfaceT;
    }
    /// <summary>
    /// 
    /// </summary>
    public static bool ValuesInArray(double[] Values, double MissingValue)
    {
        double Value;
        if (Values != null)
        {
            foreach(float Value_cyml in Values)
            {
                Value = Value_cyml;
                if (Value != MissingValue && !double.IsNaN(Value))
                {
                    return true;
                }
            }
        }
        return false;
    }
}