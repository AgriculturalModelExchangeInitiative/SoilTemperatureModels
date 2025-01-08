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
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
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
///            * name: Thickness
///                          ** description : Thickness of soil layers (mm)
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 
///                          ** min : 
///                          ** default : 
///                          ** unit : mm
///            * name: InitialValues
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
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
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
///                          ** datatype : DOUBLE
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
        double weather_Latitude = ex.weather_Latitude;
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
        double timestep = ex.timestep;
        bool doInitialisationStuff = false;
        double internalTimeStep = 0.0;
        double timeOfDaySecs = 0.0;
        int numNodes = 0;
        int numLayers = 0;
        double[] volSpecHeatSoil ;
        double[] soilTemp ;
        double[] morningSoilTemp ;
        double[] heatStorage ;
        double[] thermalConductance ;
        double[] thermalConductivity ;
        double boundaryLayerConductance = 0.0;
        double[] newTemperature ;
        double airTemperature = 0.0;
        double maxTempYesterday = 0.0;
        double minTempYesterday = 0.0;
        double[] soilWater ;
        double[] minSoilTemp ;
        double[] maxSoilTemp ;
        double[] aveSoilTemp ;
        double[] aveSoilWater ;
        double[] thickness ;
        double[] bulkDensity ;
        double[] rocks ;
        double[] carbon ;
        double[] sand ;
        double[] silt ;
        double[] clay ;
        double instrumentHeight = 0.0;
        double netRadiation = 0.0;
        double canopyHeight = 0.0;
        double instrumHeight = 0.0;
        doInitialisationStuff = true;
        instrumentHeight = getIniVariables(instrumHeight, defaultInstrumentHeight, instrumentHeight);
        getProfileVariables(ref maxSoilTemp, ref minSoilTemp, topsoilNode, ref thermalConductance, physical_BD, ref soilTemp, ref carbon, physical_ParticleSizeSand, physical_Thickness, ref newTemperature, ref heatStorage, numPhantomNodes, ref soilWater, ref nodeDepth, ref volSpecHeatSoil, ref aveSoilTemp, surfaceNode, ref rocks, physical_Rocks, physical_ParticleSizeSilt, ref thermalConductivity, ref silt, ref sand, ref numNodes, organic_Carbon, ref morningSoilTemp, DepthToConstantTemperature, ref clay, ref thickness, ref bulkDensity, waterBalance_SW, airNode, physical_ParticleSizeClay, ref numLayers, MissingValue);
        readParam(ref soilTemp, ref soilRoughnessHeight, ref newTemperature, bareSoilRoughness, ref thermCondPar2, ref thermCondPar3, ref thermCondPar4, bulkDensity, ref thermCondPar1, numNodes, clay, numLayers, weather_Latitude, weather_Amp, clock_Today_DayOfYear, weather_Tav, surfaceNode, thickness);
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

    private double[] _Thickness;
    /// <summary>
    /// Gets and sets the Thickness of soil layers (mm)
    /// </summary>
    [Description("Thickness of soil layers (mm)")] 
    [Units("mm")] 
    //[Crop2ML(datatype="DOUBLEARRAY", min=null, max=null, default=, parametercategory=constant, inputtype="parameter")] 
    public double[] Thickness
    {
        get { return this._Thickness; }
        set { this._Thickness= value; } 
    }

    private double[] _InitialValues;
    /// <summary>
    /// Gets and sets the Initial soil temperature
    /// </summary>
    [Description("Initial soil temperature")] 
    [Units("oC")] 
    //[Crop2ML(datatype="DOUBLEARRAY", min=null, max=null, default=, parametercategory=constant, inputtype="parameter")] 
    public double[] InitialValues
    {
        get { return this._InitialValues; }
        set { this._InitialValues= value; } 
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

    private double _airNode;
    /// <summary>
    /// Gets and sets the The index of the node in the atmosphere (aboveground)
    /// </summary>
    [Description("The index of the node in the atmosphere (aboveground)")] 
    [Units("")] 
    //[Crop2ML(datatype="DOUBLE", min=null, max=null, default=0, parametercategory=constant, inputtype="parameter")] 
    public double airNode
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
        double weather_Latitude = ex.weather_Latitude;
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
        double timestep = ex.timestep;
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
        getOtherVariables(ref soilWater, ref instrumentHeight, microClimate_CanopyHeight, waterBalance_SW, numNodes, ref canopyHeight, soilRoughnessHeight, numLayers);
        if (doInitialisationStuff)
        {
            if (ValuesInArray(InitialValues, MissingValue))
            {
                soilTemp = new double[numNodes + 1 + 1];
                soilTemp.ToList().GetRange(topsoilNode,topsoilNode + InitialValues.Length - topsoilNode) = InitialValues.ToList().GetRange(0,0 + InitialValues.Length - 0);
            }
            else
            {
                soilTemp = calcSoilTemperature(soilTemp, weather_Latitude, weather_Amp, numNodes, clock_Today_DayOfYear, weather_Tav, surfaceNode, thickness);
                InitialValues = new double[numLayers];
                InitialValues.ToList().GetRange(0,0 + numLayers - 0) = soilTemp.ToList().GetRange(topsoilNode,topsoilNode + numLayers - topsoilNode);
            }
            soilTemp[airNode] = weather_MeanT;
            soilTemp[surfaceNode] = calcSurfaceTemperature(waterBalance_Salb, weather_MeanT, weather_Radn, weather_MaxT);
            for (i=numNodes + 1 ; i!=soilTemp.Length ; i+=1)
            {
                soilTemp[i] = weather_Tav;
            }
            newTemperature.ToList().GetRange(0,0 + soilTemp.Length - 0) = soilTemp;
            maxTempYesterday = weather_MaxT;
            minTempYesterday = weather_MinT;
            doInitialisationStuff = false;
        }
        doProcess(ref maxSoilTemp, ref minSoilTemp, weather_MaxT, numIterationsForBoundaryLayerConductance, ref maxTempYesterday, ref thermalConductivity, ref timeOfDaySecs, ref soilTemp, weather_MeanT, ref morningSoilTemp, ref newTemperature, ref boundaryLayerConductance, constantBoundaryLayerConductance, ref airTemperature, timestep, weather_MinT, airNode, ref netRadiation, ref aveSoilTemp, ref minTempYesterday, ref internalTimeStep, boundarLayerConductanceSource, clock_Today_DayOfYear, weather_Latitude, weather_Radn, soilConstituentNames, soilWater, ref volSpecHeatSoil, numNodes, nodeDepth, surfaceNode, thickness, MissingValue, bulkDensity, carbon, pom, rocks, ps, sand, silt, clay, defaultTimeOfMaximumTemperature, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, stefanBoltzmannConstant, weather_AirPressure, instrumentHeight, weather_Wind, canopyHeight, netRadiationSource, ref thermalConductance, waterBalance_Es, ref heatStorage, latentHeatOfVapourisation, nu);
        s.doInitialisationStuff= doInitialisationStuff;
        s.volSpecHeatSoil= volSpecHeatSoil;
        s.soilTemp= soilTemp;
        s.morningSoilTemp= morningSoilTemp;
        s.heatStorage= heatStorage;
        s.thermalConductance= thermalConductance;
        s.thermalConductivity= thermalConductivity;
        s.boundaryLayerConductance= boundaryLayerConductance;
        s.newTemperature= newTemperature;
        s.maxTempYesterday= maxTempYesterday;
        s.minTempYesterday= minTempYesterday;
        s.soilWater= soilWater;
        s.minSoilTemp= minSoilTemp;
        s.maxSoilTemp= maxSoilTemp;
        s.aveSoilTemp= aveSoilTemp;
        s.instrumentHeight= instrumentHeight;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double getIniVariables(double instrumHeight, double defaultInstrumentHeight, double instrumentHeight)
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
    public static void  getProfileVariables(ref double[] maxSoilTemp, ref double[] minSoilTemp, int topsoilNode, ref double[] thermalConductance, double[] physical_BD, ref double[] soilTemp, ref double[] carbon, double[] physical_ParticleSizeSand, double[] physical_Thickness, ref double[] newTemperature, ref double[] heatStorage, int numPhantomNodes, ref double[] soilWater, ref double[] nodeDepth, ref double[] volSpecHeatSoil, ref double[] aveSoilTemp, int surfaceNode, ref double[] rocks, double[] physical_Rocks, double[] physical_ParticleSizeSilt, ref double[] thermalConductivity, ref double[] silt, ref double[] sand, ref int numNodes, double[] organic_Carbon, ref double[] morningSoilTemp, double DepthToConstantTemperature, ref double[] clay, ref double[] thickness, ref double[] bulkDensity, double[] waterBalance_SW, double airNode, double[] physical_ParticleSizeClay, ref int numLayers, double MissingValue)
    {
        int layer;
        int node;
        int i;
        double belowProfileDepth;
        double thicknessForPhantomNodes;
        int firstPhantomNode;
        double[] oldDepth ;
        double[] oldBulkDensity ;
        double[] oldSoilWater ;
        numLayers = physical_Thickness.Length;
        numNodes = numLayers + numPhantomNodes;
        thickness = new double[numLayers + numPhantomNodes + 1];
        thickness.ToList().GetRange(1,1 + physical_Thickness.Length - 1) = physical_Thickness;
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
            nodeDepth.ToList().GetRange(0,Math.Min(numNodes + 1 + 1, oldDepth.Length) - 0) = oldDepth.ToList().GetRange(0,Math.Min(numNodes + 1 + 1, oldDepth.Length) - 0);
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
            bulkDensity.ToList().GetRange(0,Math.Min(numLayers + 1 + numPhantomNodes, oldBulkDensity.Length) - 0) = oldBulkDensity.ToList().GetRange(0,Math.Min(numLayers + 1 + numPhantomNodes, oldBulkDensity.Length) - 0);
        }
        bulkDensity.ToList().GetRange(1,1 + physical_BD.Length - 1) = physical_BD;
        bulkDensity[numNodes] = bulkDensity[numLayers];
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            bulkDensity[layer] = bulkDensity[numLayers];
        }
        oldSoilWater = soilWater;
        soilWater = new double[numLayers + 1 + numPhantomNodes];
        if (oldSoilWater != null)
        {
            soilWater.ToList().GetRange(0,Math.Min(numLayers + 1 + numPhantomNodes, oldSoilWater.Length) - 0) = oldSoilWater.ToList().GetRange(0,Math.Min(numLayers + 1 + numPhantomNodes, oldSoilWater.Length) - 0);
        }
        if (waterBalance_SW != null)
        {
            for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
            {
                soilWater[layer] = Divide(waterBalance_SW[(layer - 1)] * thickness[(layer - 1)], thickness[layer], 0);
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
    public static void  doThermalConductivityCoeffs(ref double[] thermCondPar2, ref double[] thermCondPar3, ref double[] thermCondPar4, double[] bulkDensity, ref double[] thermCondPar1, int numNodes, double[] clay, int numLayers)
    {
        int layer;
        double[] oldGC1 ;
        double[] oldGC2 ;
        double[] oldGC3 ;
        double[] oldGC4 ;
        int element;
        oldGC1 = thermCondPar1;
        thermCondPar1 = new double[numNodes + 1];
        if (oldGC1 != null)
        {
            thermCondPar1.ToList().GetRange(0,Math.Min(numNodes + 1, oldGC1.Length) - 0) = oldGC1.ToList().GetRange(0,Math.Min(numNodes + 1, oldGC1.Length) - 0);
        }
        oldGC2 = thermCondPar2;
        thermCondPar2 = new double[numNodes + 1];
        if (oldGC2 != null)
        {
            thermCondPar2.ToList().GetRange(0,Math.Min(numNodes + 1, oldGC2.Length) - 0) = oldGC2.ToList().GetRange(0,Math.Min(numNodes + 1, oldGC2.Length) - 0);
        }
        oldGC3 = thermCondPar3;
        thermCondPar3 = new double[numNodes + 1];
        if (oldGC3 != null)
        {
            thermCondPar3.ToList().GetRange(0,Math.Min(numNodes + 1, oldGC3.Length) - 0) = oldGC3.ToList().GetRange(0,Math.Min(numNodes + 1, oldGC3.Length) - 0);
        }
        oldGC4 = thermCondPar4;
        thermCondPar4 = new double[numNodes + 1];
        if (oldGC4 != null)
        {
            thermCondPar4.ToList().GetRange(0,Math.Min(numNodes + 1, oldGC4.Length) - 0) = oldGC4.ToList().GetRange(0,Math.Min(numNodes + 1, oldGC4.Length) - 0);
        }
        for (layer=1 ; layer!=numLayers + 1 + 1 ; layer+=1)
        {
            element = layer;
            thermCondPar1[element] = 0.65 - (0.78 * bulkDensity[layer]) + (0.6 * Math.Pow(bulkDensity[layer], 2));
            thermCondPar2[element] = 1.06 * bulkDensity[layer];
            thermCondPar3[element] = 1.0 + Divide(2.6, Math.Sqrt(clay[layer]), 0);
            thermCondPar4[element] = 0.03 + (0.1 * Math.Pow(bulkDensity[layer], 2));
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static void  readParam(ref double[] soilTemp, ref double soilRoughnessHeight, ref double[] newTemperature, double bareSoilRoughness, ref double[] thermCondPar2, ref double[] thermCondPar3, ref double[] thermCondPar4, double[] bulkDensity, ref double[] thermCondPar1, int numNodes, double[] clay, int numLayers, double weather_Latitude, double weather_Amp, int clock_Today_DayOfYear, double weather_Tav, int surfaceNode, double[] thickness)
    {
        doThermalConductivityCoeffs(ref thermCondPar2, ref thermCondPar3, ref thermCondPar4, bulkDensity, ref thermCondPar1, numNodes, clay, numLayers);
        soilTemp = calcSoilTemperature(soilTemp, weather_Latitude, weather_Amp, numNodes, clock_Today_DayOfYear, weather_Tav, surfaceNode, thickness);
        newTemperature.ToList().GetRange(0,0 + soilTemp.Length - 0) = soilTemp;
        soilRoughnessHeight = bareSoilRoughness;
    }
    /// <summary>
    /// 
    /// </summary>
    public static void  getOtherVariables(ref double[] soilWater, ref double instrumentHeight, double microClimate_CanopyHeight, double[] waterBalance_SW, int numNodes, ref double canopyHeight, double soilRoughnessHeight, int numLayers)
    {
        soilWater.ToList().GetRange(1,1 + waterBalance_SW.Length - 1) = waterBalance_SW;
        soilWater[numNodes] = soilWater[numLayers];
        canopyHeight = Math.Max(microClimate_CanopyHeight, soilRoughnessHeight) / 1000.0;
        instrumentHeight = Math.Max(instrumentHeight, canopyHeight + 0.5);
    }
    /// <summary>
    /// 
    /// </summary>
    public static double volumetricFractionOrganicMatter(int layer, double[] bulkDensity, double[] carbon, double pom)
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
    public static double volumetricFractionWater(int layer, double[] soilWater, double[] bulkDensity, double[] carbon, double pom)
    {
        return (1 - volumetricFractionOrganicMatter(layer, bulkDensity, carbon, pom)) * soilWater[layer];
    }
    /// <summary>
    /// 
    /// </summary>
    public static double volumetricFractionClay(int layer, double[] bulkDensity, double[] clay, double ps, double[] carbon, double pom, double[] rocks)
    {
        return (1 - volumetricFractionOrganicMatter(layer, bulkDensity, carbon, pom) - volumetricFractionRocks(layer, rocks)) * clay[layer] / 100.0 * bulkDensity[layer] / ps;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double volumetricFractionSilt(int layer, double[] bulkDensity, double[] silt, double ps, double[] carbon, double pom, double[] rocks)
    {
        return (1 - volumetricFractionOrganicMatter(layer, bulkDensity, carbon, pom) - volumetricFractionRocks(layer, rocks)) * silt[layer] / 100.0 * bulkDensity[layer] / ps;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double volumetricFractionSand(int layer, double[] bulkDensity, double ps, double[] sand, double[] carbon, double pom, double[] rocks)
    {
        return (1 - volumetricFractionOrganicMatter(layer, bulkDensity, carbon, pom) - volumetricFractionRocks(layer, rocks)) * sand[layer] / 100.0 * bulkDensity[layer] / ps;
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
    public static double volumetricFractionAir(int layer, double[] rocks, double[] bulkDensity, double[] carbon, double pom, double ps, double[] sand, double[] silt, double[] clay, double[] soilWater)
    {
        return 1.0 - volumetricFractionRocks(layer, rocks) - volumetricFractionOrganicMatter(layer, bulkDensity, carbon, pom) - volumetricFractionSand(layer, bulkDensity, ps, sand, carbon, pom, rocks) - volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks) - volumetricFractionClay(layer, bulkDensity, clay, ps, carbon, pom, rocks) - volumetricFractionWater(layer, soilWater, bulkDensity, carbon, pom) - volumetricFractionIce(layer);
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
    public static double[] mapLayer2Node(double[] layerArray, double[] nodeArray, int numNodes, double[] nodeDepth, int surfaceNode, double[] thickness, double MissingValue)
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
            nodeArray[node] = Divide(layerArray[layer] * d1, dSum, 0) + Divide(layerArray[(layer + 1)] * d2, dSum, 0);
        }
        return nodeArray;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double ThermalConductance(string name, int layer, double[] rocks, double[] bulkDensity, double ps, double[] sand, double[] carbon, double pom, double[] silt, double[] clay)
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
            result = Math.Pow(thermalConductanceRocks, volumetricFractionRocks(layer, rocks)) * Math.Pow(thermalConductanceSand, volumetricFractionSand(layer, bulkDensity, ps, sand, carbon, pom, rocks)) + Math.Pow(thermalConductanceSilt, volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + Math.Pow(thermalConductanceClay, volumetricFractionClay(layer, bulkDensity, clay, ps, carbon, pom, rocks));
        }
        result = volumetricSpecificHeat(name, layer);
        return result;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double shapeFactor(string name, int layer, double[] soilWater, double[] bulkDensity, double[] carbon, double pom, double[] rocks, double ps, double[] sand, double[] silt, double[] clay)
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
            result = 0.333 - (0.333 * volumetricFractionIce(layer) / (volumetricFractionWater(layer, soilWater, bulkDensity, carbon, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, bulkDensity, carbon, pom, ps, sand, silt, clay, soilWater)));
            return result;
        }
        else if ( name == "Air")
        {
            result = 0.333 - (0.333 * volumetricFractionAir(layer, rocks, bulkDensity, carbon, pom, ps, sand, silt, clay, soilWater) / (volumetricFractionWater(layer, soilWater, bulkDensity, carbon, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, bulkDensity, carbon, pom, ps, sand, silt, clay, soilWater)));
            return result;
        }
        else if ( name == "Minerals")
        {
            result = shapeFactorRocks * volumetricFractionRocks(layer, rocks) + (shapeFactorSand * volumetricFractionSand(layer, bulkDensity, ps, sand, carbon, pom, rocks)) + (shapeFactorSilt * volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + (shapeFactorClay * volumetricFractionClay(layer, bulkDensity, clay, ps, carbon, pom, rocks));
        }
        result = volumetricSpecificHeat(name, layer);
        return result;
    }
    /// <summary>
    /// 
    /// </summary>
    public static void  doUpdate(int numInterationsPerDay, ref double[] maxSoilTemp, ref double[] minSoilTemp, double[] thermalConductivity, ref double[] soilTemp, double timeOfDaySecs, int numNodes, ref double boundaryLayerConductance, ref double[] aveSoilTemp, double airNode, double[] newTemperature, int surfaceNode, double internalTimeStep)
    {
        int node;
        soilTemp.ToList().GetRange(0,0 + newTemperature.Length - 0) = newTemperature;
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
            aveSoilTemp[node] = aveSoilTemp[node] + Divide(soilTemp[node], numInterationsPerDay, 0);
        }
        boundaryLayerConductance = boundaryLayerConductance + Divide(thermalConductivity[airNode], numInterationsPerDay, 0);
    }
    /// <summary>
    /// 
    /// </summary>
    public static void  doThomas(ref double[] newTemps, string netRadiationSource, ref double[] thermalConductance, double waterBalance_Eos, double waterBalance_Es, double[] thermalConductivity, double[] soilTemp, int numNodes, double internalTimeStep, ref double[] heatStorage, double latentHeatOfVapourisation, double[] nodeDepth, double nu, double[] volSpecHeatSoil, double airNode, double netRadiation, int surfaceNode, double timestep)
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
            heatStorage[node] = Divide(volSpecHeatSoil[node] * volumeOfSoilAtNode, internalTimeStep, 0);
            elementLength = nodeDepth[node + 1] - nodeDepth[node];
            thermalConductance[node] = Divide(thermalConductivity[node], elementLength, 0);
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
            radnNet = Divide(netRadiation * 1000000.0, internalTimeStep, 0);
        }
        else if ( netRadiationSource == "eos")
        {
            radnNet = Divide(waterBalance_Eos * latentHeatOfVapourisation, timestep, 0);
        }
        latentHeatFlux = Divide(waterBalance_Es * latentHeatOfVapourisation, timestep, 0);
        soilSurfaceHeatFlux = sensibleHeatFlux + radnNet - latentHeatFlux;
        d[surfaceNode] = d[surfaceNode] + soilSurfaceHeatFlux;
        d[numNodes] = d[numNodes] + (nu * thermalConductance[numNodes] * newTemps[(numNodes + 1)]);
        for (node=surfaceNode ; node!=numNodes - 1 + 1 ; node+=1)
        {
            c[node] = Divide(c[node], b[node], 0);
            d[node] = Divide(d[node], b[node], 0);
            b[node + 1] = b[node + 1] - (a[(node + 1)] * c[node]);
            d[node + 1] = d[node + 1] - (a[(node + 1)] * d[node]);
        }
        newTemps[numNodes] = Divide(d[numNodes], b[numNodes], 0);
        for (node=numNodes - 1 ; node!=surfaceNode - 1 ; node+=-1)
        {
            newTemps[node] = d[node] - (c[node] * newTemps[(node + 1)]);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static double getBoundaryLayerConductance(ref double[] TNew_zb, double stefanBoltzmannConstant, double airTemperature, double waterBalance_Eos, double weather_AirPressure, double instrumentHeight, double waterBalance_Eo, double weather_Wind, double canopyHeight, int surfaceNode)
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
            frictionVelocity = Divide(weather_Wind * vonKarmanConstant, Math.Log(Divide(instrumentHeight - d + roughnessFactorMomentum, roughnessFactorMomentum, 0)) + stabilityCorrectionMomentum, 0);
            boundaryLayerCond = Divide(SpecificHeatAir * vonKarmanConstant * frictionVelocity, Math.Log(Divide(instrumentHeight - d + roughnessFactorHeat, roughnessFactorHeat, 0)) + stabilityCorrectionHeat, 0);
            boundaryLayerCond = boundaryLayerCond + radiativeConductance;
            heatFluxDensity = boundaryLayerCond * (surfaceTemperature - airTemperature);
            stabilityParammeter = Divide(-vonKarmanConstant * instrumentHeight * gravitationalConstant * heatFluxDensity, SpecificHeatAir * kelvinT(airTemperature) * Math.Pow(frictionVelocity, 3.0), 0);
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
    public static double interpolateNetRadiation(double solarRadn, double cloudFr, double cva, double[] soilTemp, double airTemperature, double waterBalance_Eo, double waterBalance_Eos, double waterBalance_Salb, int surfaceNode, double internalTimeStep, double stefanBoltzmannConstant)
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
        PenetrationConstant = Divide(Math.Max(0.1, waterBalance_Eos), Math.Max(0.1, waterBalance_Eo), 0);
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
    public static double interpolateTemperature(double timeHours, double defaultTimeOfMaximumTemperature, double weather_MeanT, double weather_MaxT, double maxTempYesterday, double minTempYesterday, double weather_MinT)
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
    public static double[] doThermalConductivity(string[] soilConstituentNames, double[] soilWater, double[] thermalConductivity, int numNodes, double[] bulkDensity, double[] carbon, double pom, double[] rocks, double ps, double[] sand, double[] silt, double[] clay, double[] nodeDepth, int surfaceNode, double[] thickness, double MissingValue)
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
            foreach(str constituentName_cyml in soilConstituentNames)
            {
                constituentName = constituentName_cyml;
                shapeFactorConstituent = shapeFactor(constituentName, node, soilWater, bulkDensity, carbon, pom, rocks, ps, sand, silt, clay);
                thermalConductanceConstituent = ThermalConductance(constituentName, node, rocks, bulkDensity, ps, sand, carbon, pom, silt, clay);
                thermalConductanceWater = ThermalConductance("Water", node, rocks, bulkDensity, ps, sand, carbon, pom, silt, clay);
                k = 2.0 / 3.0 * Math.Pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0))), -1) + (1.0 / 3.0 * Math.Pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0) * (1 - (2 * shapeFactorConstituent)))), -1));
                numerator = numerator + (thermalConductanceConstituent * soilWater[node] * k);
                denominator = denominator + (soilWater[node] * k);
            }
            thermCondLayers[node] = numerator / denominator;
        }
        thermalConductivity = mapLayer2Node(thermCondLayers, thermalConductivity, numNodes, nodeDepth, surfaceNode, thickness, MissingValue);
        return thermalConductivity;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double[] doVolumetricSpecificHeat(string[] soilConstituentNames, double[] soilWater, double[] volSpecHeatSoil, int numNodes, double[] nodeDepth, int surfaceNode, double[] thickness, double MissingValue)
    {
        int node;
        string constituentName;
        double[] volspecHeatSoil_ =  new double [numNodes + 1];
        for (node=1 ; node!=numNodes + 1 ; node+=1)
        {
            volspecHeatSoil_[node] = (double)(0);
            foreach(str constituentName_cyml in soilConstituentNames)
            {
                constituentName = constituentName_cyml;
                if (!new List<string>{"Minerals"}.Contains(constituentName))
                {
                    volspecHeatSoil_[node] = volspecHeatSoil_[node] + (volumetricSpecificHeat(constituentName, node) * 1000000.0 * soilWater[node]);
                }
            }
        }
        volSpecHeatSoil = mapLayer2Node(volspecHeatSoil_, volSpecHeatSoil, numNodes, nodeDepth, surfaceNode, thickness, MissingValue);
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
    public static void  doNetRadiation(ref double[] solarRadn, ref double cloudFr, ref double cva, int ITERATIONSperDAY, int clock_Today_DayOfYear, double weather_Latitude, double weather_Radn, double weather_MinT)
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
        TSTEPS2RAD = Divide(2.0 * Math.PI, (double)(ITERATIONSperDAY), 0);
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
        fr = Divide(Math.Max(weather_Radn, 0.1), psr, 0);
        cloudFr = 2.33 - (3.33 * fr);
        cloudFr = Math.Min(Math.Max(cloudFr, 0.0), 1.0);
        for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
        {
            solarRadn[timestepNumber] = Math.Max(weather_Radn, 0.1) * Divide(m1[timestepNumber], m1Tot, 0);
        }
        cva = Math.Exp((31.3716 - (6014.79 / kelvinT(weather_MinT)) - (0.00792495 * kelvinT(weather_MinT)))) / kelvinT(weather_MinT);
    }
    /// <summary>
    /// 
    /// </summary>
    public static void  doProcess(ref double[] maxSoilTemp, ref double[] minSoilTemp, double weather_MaxT, int numIterationsForBoundaryLayerConductance, ref double maxTempYesterday, ref double[] thermalConductivity, ref double timeOfDaySecs, ref double[] soilTemp, double weather_MeanT, ref double[] morningSoilTemp, ref double[] newTemperature, ref double boundaryLayerConductance, double constantBoundaryLayerConductance, ref double airTemperature, double timestep, double weather_MinT, double airNode, ref double netRadiation, ref double[] aveSoilTemp, ref double minTempYesterday, ref double internalTimeStep, string boundarLayerConductanceSource, int clock_Today_DayOfYear, double weather_Latitude, double weather_Radn, string[] soilConstituentNames, double[] soilWater, ref double[] volSpecHeatSoil, int numNodes, double[] nodeDepth, int surfaceNode, double[] thickness, double MissingValue, double[] bulkDensity, double[] carbon, double pom, double[] rocks, double ps, double[] sand, double[] silt, double[] clay, double defaultTimeOfMaximumTemperature, double waterBalance_Eo, double waterBalance_Eos, double waterBalance_Salb, double stefanBoltzmannConstant, double weather_AirPressure, double instrumentHeight, double weather_Wind, double canopyHeight, string netRadiationSource, ref double[] thermalConductance, double waterBalance_Es, ref double[] heatStorage, double latentHeatOfVapourisation, double nu)
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
        doNetRadiation(ref solarRadn, ref cloudFr, ref cva, interactionsPerDay, clock_Today_DayOfYear, weather_Latitude, weather_Radn, weather_MinT);
        minSoilTemp = Zero(minSoilTemp);
        maxSoilTemp = Zero(maxSoilTemp);
        aveSoilTemp = Zero(aveSoilTemp);
        boundaryLayerConductance = 0.0;
        internalTimeStep = Math.Round(timestep / interactionsPerDay);
        volSpecHeatSoil = doVolumetricSpecificHeat(soilConstituentNames, soilWater, volSpecHeatSoil, numNodes, nodeDepth, surfaceNode, thickness, MissingValue);
        thermalConductivity = doThermalConductivity(soilConstituentNames, soilWater, thermalConductivity, numNodes, bulkDensity, carbon, pom, rocks, ps, sand, silt, clay, nodeDepth, surfaceNode, thickness, MissingValue);
        for (timeStepIteration=1 ; timeStepIteration!=interactionsPerDay + 1 ; timeStepIteration+=1)
        {
            timeOfDaySecs = internalTimeStep * (double)(timeStepIteration);
            if (timestep < (24.0 * 60.0 * 60.0))
            {
                airTemperature = weather_MeanT;
            }
            else
            {
                airTemperature = interpolateTemperature(timeOfDaySecs / 3600.0, defaultTimeOfMaximumTemperature, weather_MeanT, weather_MaxT, maxTempYesterday, minTempYesterday, weather_MinT);
            }
            newTemperature[airNode] = airTemperature;
            netRadiation = interpolateNetRadiation(solarRadn[timeStepIteration], cloudFr, cva, soilTemp, airTemperature, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, surfaceNode, internalTimeStep, stefanBoltzmannConstant);
            if (boundarLayerConductanceSource == "constant")
            {
                thermalConductivity[airNode] = constantBoundaryLayerConductance;
            }
            else if ( boundarLayerConductanceSource == "calc")
            {
                thermalConductivity[airNode] = getBoundaryLayerConductance(ref newTemperature, stefanBoltzmannConstant, airTemperature, waterBalance_Eos, weather_AirPressure, instrumentHeight, waterBalance_Eo, weather_Wind, canopyHeight, surfaceNode);
                for (iteration=1 ; iteration!=numIterationsForBoundaryLayerConductance + 1 ; iteration+=1)
                {
                    doThomas(ref newTemperature, netRadiationSource, ref thermalConductance, waterBalance_Eos, waterBalance_Es, thermalConductivity, soilTemp, numNodes, internalTimeStep, ref heatStorage, latentHeatOfVapourisation, nodeDepth, nu, volSpecHeatSoil, airNode, netRadiation, surfaceNode, timestep);
                    thermalConductivity[airNode] = getBoundaryLayerConductance(ref newTemperature, stefanBoltzmannConstant, airTemperature, waterBalance_Eos, weather_AirPressure, instrumentHeight, waterBalance_Eo, weather_Wind, canopyHeight, surfaceNode);
                }
            }
            doThomas(ref newTemperature, netRadiationSource, ref thermalConductance, waterBalance_Eos, waterBalance_Es, thermalConductivity, soilTemp, numNodes, internalTimeStep, ref heatStorage, latentHeatOfVapourisation, nodeDepth, nu, volSpecHeatSoil, airNode, netRadiation, surfaceNode, timestep);
            doUpdate(interactionsPerDay, ref maxSoilTemp, ref minSoilTemp, thermalConductivity, ref soilTemp, timeOfDaySecs, numNodes, ref boundaryLayerConductance, ref aveSoilTemp, airNode, newTemperature, surfaceNode, internalTimeStep);
            if (Math.Abs(timeOfDaySecs - (5.0 * 3600.0)) <= (Math.Min(timeOfDaySecs, 5.0 * 3600.0) * 0.0001))
            {
                morningSoilTemp.ToList().GetRange(0,0 + soilTemp.Length - 0) = soilTemp;
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
    public static double[] calcSoilTemperature(double[] soilTempIO, double weather_Latitude, double weather_Amp, int numNodes, int clock_Today_DayOfYear, double weather_Tav, int surfaceNode, double[] thickness)
    {
        int nodes;
        double[] cumulativeDepth ;
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
        soilTempIO.ToList().GetRange(surfaceNode,surfaceNode + numNodes - surfaceNode) = soilTemp.ToList().GetRange(0,0 + numNodes - 0);
        return soilTempIO;
    }
    /// <summary>
    /// 
    /// </summary>
    public static double calcSurfaceTemperature(double waterBalance_Salb, double weather_MeanT, double weather_Radn, double weather_MaxT)
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