MODULE Soiltempmod
    USE Soiltemperaturemod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_soiltemp(netRadiation, &
        aveSoilWater, &
        bulkDensity, &
        waterBalance_Eo, &
        thermCondPar1, &
        topsoilNode, &
        surfaceNode, &
        internalTimeStep, &
        thermalConductance, &
        thickness, &
        numPhantomNodes, &
        soilConstituentNames, &
        doInitialisationStuff, &
        maxTempYesterday, &
        waterBalance_Salb, &
        physical_Thickness, &
        MissingValue, &
        timeOfDaySecs, &
        numNodes, &
        timestep, &
        organic_Carbon, &
        waterBalance_Es, &
        weather_Wind, &
        soilWater, &
        soilRoughnessHeight, &
        physical_ParticleSizeSand, &
        numIterationsForBoundaryLayerConductance, &
        clay, &
        weather_AirPressure, &
        soilTemp, &
        clock_Today_DayOfYear, &
        silt, &
        defaultTimeOfMaximumTemperature, &
        pom, &
        DepthToConstantTemperature, &
        microClimate_CanopyHeight, &
        constantBoundaryLayerConductance, &
        waterBalance_Eos, &
        instrumentHeight, &
        thermCondPar4, &
        waterBalance_SW, &
        weather_Amp, &
        nodeDepth, &
        nu, &
        sand, &
        pInitialValues, &
        weather_MinT, &
        ps, &
        netRadiationSource, &
        weather_Radn, &
        airNode, &
        numLayers, &
        volSpecHeatSoil, &
        instrumHeight, &
        canopyHeight, &
        heatStorage, &
        minSoilTemp, &
        bareSoilRoughness, &
        thermCondPar2, &
        defaultInstrumentHeight, &
        maxSoilTemp, &
        physical_BD, &
        latentHeatOfVapourisation, &
        weather_Latitude, &
        physical_Rocks, &
        stefanBoltzmannConstant, &
        weather_Tav, &
        newTemperature, &
        airTemperature, &
        weather_MaxT, &
        boundarLayerConductanceSource, &
        thermalConductivity, &
        minTempYesterday, &
        carbon, &
        weather_MeanT, &
        rocks, &
        InitialValues, &
        thermCondPar3, &
        physical_ParticleSizeSilt, &
        boundaryLayerConductance, &
        physical_ParticleSizeClay, &
        aveSoilTemp, &
        morningSoilTemp)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(INOUT) :: netRadiation
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(IN) :: aveSoilWater
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(IN) :: bulkDensity
        REAL, INTENT(IN) :: waterBalance_Eo
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(IN) :: thermCondPar1
        INTEGER, INTENT(IN) :: topsoilNode
        INTEGER, INTENT(IN) :: surfaceNode
        REAL, INTENT(INOUT) :: internalTimeStep
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) ::  &
                thermalConductance
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(IN) :: thickness
        INTEGER, INTENT(IN) :: numPhantomNodes
        CHARACTER(65) , DIMENSION(8 ), INTENT(IN) :: soilConstituentNames
        LOGICAL, INTENT(INOUT) :: doInitialisationStuff
        REAL, INTENT(INOUT) :: maxTempYesterday
        REAL, INTENT(IN) :: waterBalance_Salb
        REAL , DIMENSION(: ), INTENT(IN) :: physical_Thickness
        REAL, INTENT(IN) :: MissingValue
        REAL, INTENT(INOUT) :: timeOfDaySecs
        INTEGER, INTENT(IN) :: numNodes
        REAL, INTENT(IN) :: timestep
        REAL , DIMENSION(: ), INTENT(IN) :: organic_Carbon
        REAL, INTENT(IN) :: waterBalance_Es
        REAL, INTENT(IN) :: weather_Wind
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) :: soilWater
        REAL, INTENT(IN) :: soilRoughnessHeight
        REAL , DIMENSION(: ), INTENT(IN) :: physical_ParticleSizeSand
        INTEGER, INTENT(IN) :: numIterationsForBoundaryLayerConductance
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(IN) :: clay
        REAL, INTENT(IN) :: weather_AirPressure
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) :: soilTemp
        INTEGER, INTENT(IN) :: clock_Today_DayOfYear
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(IN) :: silt
        REAL, INTENT(IN) :: defaultTimeOfMaximumTemperature
        REAL, INTENT(IN) :: pom
        REAL, INTENT(IN) :: DepthToConstantTemperature
        REAL, INTENT(IN) :: microClimate_CanopyHeight
        REAL, INTENT(IN) :: constantBoundaryLayerConductance
        REAL, INTENT(IN) :: waterBalance_Eos
        REAL, INTENT(INOUT) :: instrumentHeight
        REAL , DIMENSION(: ), ALLOCATABLE, INTENT(IN) :: thermCondPar4
        REAL , DIMENSION(: ), ALLOCATABLE, INTENT(IN) :: waterBalance_SW
        REAL, INTENT(IN) :: weather_Amp
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(IN) :: nodeDepth
        REAL, INTENT(IN) :: nu
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(IN) :: sand
        REAL , DIMENSION(: ), INTENT(IN) :: pInitialValues
        REAL, INTENT(IN) :: weather_MinT
        REAL, INTENT(IN) :: ps
        CHARACTER(65), INTENT(IN) :: netRadiationSource
        REAL, INTENT(IN) :: weather_Radn
        INTEGER, INTENT(IN) :: airNode
        INTEGER, INTENT(IN) :: numLayers
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) :: volSpecHeatSoil
        REAL, INTENT(IN) :: instrumHeight
        REAL, INTENT(INOUT) :: canopyHeight
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) :: heatStorage
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) :: minSoilTemp
        REAL, INTENT(IN) :: bareSoilRoughness
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(IN) :: thermCondPar2
        REAL, INTENT(IN) :: defaultInstrumentHeight
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) :: maxSoilTemp
        REAL , DIMENSION(: ), INTENT(IN) :: physical_BD
        REAL, INTENT(IN) :: latentHeatOfVapourisation
        REAL, INTENT(IN) :: weather_Latitude
        REAL , DIMENSION(: ), INTENT(IN) :: physical_Rocks
        REAL, INTENT(IN) :: stefanBoltzmannConstant
        REAL, INTENT(IN) :: weather_Tav
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) :: newTemperature
        REAL, INTENT(INOUT) :: airTemperature
        REAL, INTENT(IN) :: weather_MaxT
        CHARACTER(65), INTENT(IN) :: boundarLayerConductanceSource
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) ::  &
                thermalConductivity
        REAL, INTENT(INOUT) :: minTempYesterday
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(IN) :: carbon
        REAL, INTENT(IN) :: weather_MeanT
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(IN) :: rocks
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) :: InitialValues
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(IN) :: thermCondPar3
        REAL , DIMENSION(: ), INTENT(IN) :: physical_ParticleSizeSilt
        REAL, INTENT(INOUT) :: boundaryLayerConductance
        REAL , DIMENSION(: ), INTENT(IN) :: physical_ParticleSizeClay
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) :: aveSoilTemp
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) :: morningSoilTemp
        !- Name: Soiltemp -Version: 2.0, -Time step: 1.0
        !- Description:
    !            * Title: Soiltemp model
    !            * Authors: Cyrille
    !            * Reference: None
    !            * Institution: INRAE
    !            * ExtendedDescription: Soil Temperature
    !            * ShortDescription: Soil Temperature
        !- inputs:
    !            * name: netRadiation
    !                          ** description : Net radiation per internal time-step
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : MJ
    !            * name: aveSoilWater
    !                          ** description : Average soil temperaturer
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: bulkDensity
    !                          ** description : Soil bulk density, includes phantom layer
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : g/cm3
    !            * name: waterBalance_Eo
    !                          ** description : Potential soil evapotranspiration from soil surface
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: thermCondPar1
    !                          ** description : Parameter 1 for computing thermal conductivity of soil solids
    !                          ** inputtype : parameter
    !                          ** parametercategory : private
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: topsoilNode
    !                          ** description : The index of the first node within the soil (top layer)
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 2
    !                          ** unit : 
    !            * name: surfaceNode
    !                          ** description : The index of the node on the soil surface (depth = 0)
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 1
    !                          ** unit : 
    !            * name: internalTimeStep
    !                          ** description : Internal time-step
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : sec
    !            * name: thermalConductance
    !                          ** description : K, conductance of element between nodes
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : W/K
    !            * name: thickness
    !                          ** description : Thickness of each soil, includes phantom layer
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: numPhantomNodes
    !                          ** description : The number of phantom nodes below the soil profile
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 5
    !                          ** unit : 
    !            * name: soilConstituentNames
    !                          ** description : soilConstituentNames
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : STRINGARRAY
    !                          ** len : 8
    !                          ** max : 
    !                          ** min : 
    !                          ** default : ["Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"]
    !                          ** unit : m
    !            * name: doInitialisationStuff
    !                          ** description : Flag whether initialisation is needed
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : BOOLEAN
    !                          ** max : 
    !                          ** min : 
    !                          ** default : false
    !                          ** unit : mintes
    !            * name: maxTempYesterday
    !                          ** description : Yesterday's maximum daily air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : oC
    !            * name: waterBalance_Salb
    !                          ** description : Fraction of incoming radiation reflected from bare soil
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 0-1
    !            * name: physical_Thickness
    !                          ** description : Soil layer thickness
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: MissingValue
    !                          ** description : missing value
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 99999
    !                          ** unit : m
    !            * name: timeOfDaySecs
    !                          ** description : Time of day from midnight
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : sec
    !            * name: numNodes
    !                          ** description : Number of nodes over the soil profile
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : 
    !            * name: timestep
    !                          ** description : Internal time-step (minutes)
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 24.0 * 60.0 * 60.0
    !                          ** unit : minutes
    !            * name: organic_Carbon
    !                          ** description : Total organic carbon
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : %
    !            * name: waterBalance_Es
    !                          ** description : Actual (realised) soil water evaporation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: weather_Wind
    !                          ** description : Wind speed
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : m/s
    !            * name: soilWater
    !                          ** description : Volumetric water content of each soil layer
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm3/mm3
    !            * name: soilRoughnessHeight
    !                          ** description : Height of soil roughness
    !                          ** inputtype : parameter
    !                          ** parametercategory : private
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : mm
    !            * name: physical_ParticleSizeSand
    !                          ** description : Particle size sand
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : %
    !            * name: numIterationsForBoundaryLayerConductance
    !                          ** description : Number of iterations to calculate atmosphere boundary layer conductance
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** min : 
    !                          ** default : 1
    !                          ** unit : 
    !            * name: clay
    !                          ** description : Volumetric fraction of clay in each soil layer
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : %
    !            * name: weather_AirPressure
    !                          ** description : Air pressure
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : hPa
    !            * name: soilTemp
    !                          ** description : Soil temperature over the soil profile at morning
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: clock_Today_DayOfYear
    !                          ** description : Day of year
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : day number
    !            * name: silt
    !                          ** description : Volumetric fraction of silt in each soil layer
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : %
    !            * name: defaultTimeOfMaximumTemperature
    !                          ** description : Time of maximum temperature
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 14.0
    !                          ** unit : minutes
    !            * name: pom
    !                          ** description : Particle density of organic matter
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : Mg/m3
    !            * name: DepthToConstantTemperature
    !                          ** description : Soil depth to constant temperature
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 10000
    !                          ** unit : mm
    !            * name: microClimate_CanopyHeight
    !                          ** description : Canopy height
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: constantBoundaryLayerConductance
    !                          ** description : Boundary layer conductance, if constant
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 20
    !                          ** unit : K/W
    !            * name: waterBalance_Eos
    !                          ** description : Potential soil evaporation from soil surface
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: instrumentHeight
    !                          ** description : Height of instruments above soil surface
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : mm
    !            * name: thermCondPar4
    !                          ** description : Parameter 4 for computing thermal conductivity of soil solids
    !                          ** inputtype : parameter
    !                          ** parametercategory : private
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: waterBalance_SW
    !                          ** description : Volumetric water content
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm/mm
    !            * name: weather_Amp
    !                          ** description : Annual average temperature amplitude
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: nodeDepth
    !                          ** description : Depths of nodes
    !                          ** inputtype : parameter
    !                          ** parametercategory : private
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: nu
    !                          ** description : Forward/backward differencing coefficient
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.6
    !                          ** unit : 0-1
    !            * name: sand
    !                          ** description : Volumetric fraction of sand in each soil layer
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : %
    !            * name: pInitialValues
    !                          ** description : Initial soil temperature
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: weather_MinT
    !                          ** description : Minimum temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: ps
    !                          ** description : ps
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: netRadiationSource
    !                          ** description : Flag whether net radiation is calculated or gotten from input
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : STRING
    !                          ** max : 
    !                          ** min : 
    !                          ** default : calc
    !                          ** unit : m
    !            * name: weather_Radn
    !                          ** description : Solar radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : MJ/m2/day
    !            * name: airNode
    !                          ** description : The index of the node in the atmosphere (aboveground)
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : 
    !            * name: numLayers
    !                          ** description : Number of layers in the soil profile
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : 
    !            * name: volSpecHeatSoil
    !                          ** description : Volumetric specific heat over the soil profile
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : J/K/m3
    !            * name: instrumHeight
    !                          ** description : Height of instruments above ground
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : mm
    !            * name: canopyHeight
    !                          ** description : Height of canopy above ground
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : mm
    !            * name: heatStorage
    !                          ** description : CP, heat storage between nodes
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : J/K
    !            * name: minSoilTemp
    !                          ** description : Minimum soil temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: bareSoilRoughness
    !                          ** description : Roughness element height of bare soil
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 57
    !                          ** unit : mm
    !            * name: thermCondPar2
    !                          ** description : Parameter 2 for computing thermal conductivity of soil solids
    !                          ** inputtype : parameter
    !                          ** parametercategory : private
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: defaultInstrumentHeight
    !                          ** description : Default instrument height
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 1.2
    !                          ** unit : m
    !            * name: maxSoilTemp
    !                          ** description : Maximum soil temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: physical_BD
    !                          ** description : Bulk density
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : g/cc
    !            * name: latentHeatOfVapourisation
    !                          ** description : Latent heat of vapourisation for water
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 2465000
    !                          ** unit : miJ/kg
    !            * name: weather_Latitude
    !                          ** description : Latitude
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : deg
    !            * name: physical_Rocks
    !                          ** description : Rocks
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : %
    !            * name: stefanBoltzmannConstant
    !                          ** description : The Stefan-Boltzmann constant
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0000000567
    !                          ** unit : W/m2/K4
    !            * name: weather_Tav
    !                          ** description : Annual average temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: newTemperature
    !                          ** description : Soil temperature at the end of this iteration
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: airTemperature
    !                          ** description : Air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : oC
    !            * name: weather_MaxT
    !                          ** description : Maximum temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: boundarLayerConductanceSource
    !                          ** description : Flag whether boundary layer conductance is calculated or gotten from inpu
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : STRING
    !                          ** max : 
    !                          ** min : 
    !                          ** default : calc
    !                          ** unit : 
    !            * name: thermalConductivity
    !                          ** description : Thermal conductivity
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : W.m/K
    !            * name: minTempYesterday
    !                          ** description : Yesterday's minimum daily air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : oC
    !            * name: carbon
    !                          ** description : Volumetric fraction of carbon (CHECK, OM?) in each soil layer
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : %
    !            * name: weather_MeanT
    !                          ** description : Mean temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: rocks
    !                          ** description : Volumetric fraction of rocks in each soil laye
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : %
    !            * name: InitialValues
    !                          ** description : Initial soil temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: thermCondPar3
    !                          ** description : Parameter 3 for computing thermal conductivity of soil solids
    !                          ** inputtype : parameter
    !                          ** parametercategory : private
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: physical_ParticleSizeSilt
    !                          ** description : Particle size silt
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : %
    !            * name: boundaryLayerConductance
    !                          ** description : Average daily atmosphere boundary layer conductance
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : 
    !            * name: physical_ParticleSizeClay
    !                          ** description : Particle size clay
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : %
    !            * name: aveSoilTemp
    !                          ** description : average soil temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: morningSoilTemp
    !                          ** description : Soil temperature over the soil profile at morning
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
        !- outputs:
    !            * name: heatStorage
    !                          ** description : CP, heat storage between nodes
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : J/K
    !            * name: instrumentHeight
    !                          ** description : Height of instruments above soil surface
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : mm
    !            * name: canopyHeight
    !                          ** description : Height of canopy above ground
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : mm
    !            * name: minSoilTemp
    !                          ** description : Minimum soil temperature
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : oC
    !            * name: maxSoilTemp
    !                          ** description : Maximum soil temperature
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : oC
    !            * name: aveSoilTemp
    !                          ** description : average soil temperature
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : oC
    !            * name: volSpecHeatSoil
    !                          ** description : Volumetric specific heat over the soil profile
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : J/K/m3
    !            * name: soilTemp
    !                          ** description : Soil temperature over the soil profile at morning
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : oC
    !            * name: morningSoilTemp
    !                          ** description : Soil temperature over the soil profile at morning
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : oC
    !            * name: newTemperature
    !                          ** description : Soil temperature at the end of this iteration
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : oC
    !            * name: thermalConductivity
    !                          ** description : Thermal conductivity
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : W.m/K
    !            * name: thermalConductance
    !                          ** description : K, conductance of element between nodes
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : W/K
    !            * name: boundaryLayerConductance
    !                          ** description : Average daily atmosphere boundary layer conductance
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : 
    !            * name: soilWater
    !                          ** description : Volumetric water content of each soil layer
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : mm3/mm3
    !            * name: doInitialisationStuff
    !                          ** description : Flag whether initialisation is needed
    !                          ** variablecategory : state
    !                          ** datatype : BOOLEAN
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : 
    !            * name: maxTempYesterday
    !                          ** description : Yesterday's maximum daily air temperature (oC)
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : oC
    !            * name: minTempYesterday
    !                          ** description : Yesterday's minimum daily air temperature (oC)
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 
    !                          ** unit : oC
    !                          ** min : 
    !            * name: airTemperature
    !                          ** description : Air temperature
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : oC
    !            * name: internalTimeStep
    !                          ** description : Internal time-step
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : sec
    !            * name: timeOfDaySecs
    !                          ** description : Time of day from midnight
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : sec
    !            * name: netRadiation
    !                          ** description : Net radiation per internal time-step
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : MJ
    !            * name: InitialValues
    !                          ** description : Initial soil temperature
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : oC
        call model_soiltemperature(weather_MinT, weather_MaxT, weather_MeanT,  &
                weather_Tav, weather_Amp, weather_AirPressure, weather_Wind,  &
                weather_Latitude, weather_Radn, clock_Today_DayOfYear,  &
                microClimate_CanopyHeight, physical_Thickness, physical_BD, ps,  &
                physical_Rocks, physical_ParticleSizeSand, physical_ParticleSizeSilt,  &
                physical_ParticleSizeClay, organic_Carbon, waterBalance_SW,  &
                waterBalance_Eos, waterBalance_Eo, waterBalance_Es,  &
                waterBalance_Salb, InitialValues, pInitialValues,  &
                DepthToConstantTemperature, timestep, latentHeatOfVapourisation,  &
                stefanBoltzmannConstant, airNode, surfaceNode, topsoilNode,  &
                numPhantomNodes, constantBoundaryLayerConductance,  &
                numIterationsForBoundaryLayerConductance,  &
                defaultTimeOfMaximumTemperature, defaultInstrumentHeight,  &
                bareSoilRoughness, doInitialisationStuff, internalTimeStep,  &
                timeOfDaySecs, numNodes, numLayers, nodeDepth, thermCondPar1,  &
                thermCondPar2, thermCondPar3, thermCondPar4, volSpecHeatSoil,  &
                soilTemp, morningSoilTemp, heatStorage, thermalConductance,  &
                thermalConductivity, boundaryLayerConductance, newTemperature,  &
                airTemperature, maxTempYesterday, minTempYesterday, soilWater,  &
                minSoilTemp, maxSoilTemp, aveSoilTemp, aveSoilWater, thickness,  &
                bulkDensity, rocks, carbon, sand, pom, silt, clay,  &
                soilRoughnessHeight, instrumentHeight, netRadiation, canopyHeight,  &
                instrumHeight, nu, boundarLayerConductanceSource, netRadiationSource,  &
                MissingValue, soilConstituentNames)
    END SUBROUTINE model_soiltemp

    SUBROUTINE init_soiltemp(weather_MinT, &
        weather_MaxT, &
        weather_MeanT, &
        weather_Tav, &
        weather_Amp, &
        weather_AirPressure, &
        weather_Wind, &
        weather_Latitude, &
        weather_Radn, &
        clock_Today_DayOfYear, &
        microClimate_CanopyHeight, &
        physical_Thickness, &
        physical_BD, &
        ps, &
        physical_Rocks, &
        physical_ParticleSizeSand, &
        physical_ParticleSizeSilt, &
        physical_ParticleSizeClay, &
        organic_Carbon, &
        waterBalance_SW, &
        waterBalance_Eos, &
        waterBalance_Eo, &
        waterBalance_Es, &
        waterBalance_Salb, &
        pInitialValues, &
        DepthToConstantTemperature, &
        timestep, &
        latentHeatOfVapourisation, &
        stefanBoltzmannConstant, &
        airNode, &
        surfaceNode, &
        topsoilNode, &
        numPhantomNodes, &
        constantBoundaryLayerConductance, &
        numIterationsForBoundaryLayerConductance, &
        defaultTimeOfMaximumTemperature, &
        defaultInstrumentHeight, &
        bareSoilRoughness, &
        nodeDepth, &
        thermCondPar1, &
        thermCondPar2, &
        thermCondPar3, &
        thermCondPar4, &
        pom, &
        soilRoughnessHeight, &
        nu, &
        boundarLayerConductanceSource, &
        netRadiationSource, &
        MissingValue, &
        soilConstituentNames, &
        InitialValues, &
        doInitialisationStuff, &
        internalTimeStep, &
        timeOfDaySecs, &
        numNodes, &
        numLayers, &
        volSpecHeatSoil, &
        soilTemp, &
        morningSoilTemp, &
        heatStorage, &
        thermalConductance, &
        thermalConductivity, &
        boundaryLayerConductance, &
        newTemperature, &
        airTemperature, &
        maxTempYesterday, &
        minTempYesterday, &
        soilWater, &
        minSoilTemp, &
        maxSoilTemp, &
        aveSoilTemp, &
        aveSoilWater, &
        thickness, &
        bulkDensity, &
        rocks, &
        carbon, &
        sand, &
        silt, &
        clay, &
        instrumentHeight, &
        netRadiation, &
        canopyHeight, &
        instrumHeight)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: weather_MinT
        REAL, INTENT(IN) :: weather_MaxT
        REAL, INTENT(IN) :: weather_MeanT
        REAL, INTENT(IN) :: weather_Tav
        REAL, INTENT(IN) :: weather_Amp
        REAL, INTENT(IN) :: weather_AirPressure
        REAL, INTENT(IN) :: weather_Wind
        REAL, INTENT(IN) :: weather_Latitude
        REAL, INTENT(IN) :: weather_Radn
        INTEGER, INTENT(IN) :: clock_Today_DayOfYear
        REAL, INTENT(IN) :: microClimate_CanopyHeight
        REAL , DIMENSION(: ), INTENT(IN) :: physical_Thickness
        REAL , DIMENSION(: ), INTENT(IN) :: physical_BD
        REAL, INTENT(IN) :: ps
        REAL , DIMENSION(: ), INTENT(IN) :: physical_Rocks
        REAL , DIMENSION(: ), INTENT(IN) :: physical_ParticleSizeSand
        REAL , DIMENSION(: ), INTENT(IN) :: physical_ParticleSizeSilt
        REAL , DIMENSION(: ), INTENT(IN) :: physical_ParticleSizeClay
        REAL , DIMENSION(: ), INTENT(IN) :: organic_Carbon
        REAL , DIMENSION(: ), ALLOCATABLE, INTENT(IN) :: waterBalance_SW
        REAL, INTENT(IN) :: waterBalance_Eos
        REAL, INTENT(IN) :: waterBalance_Eo
        REAL, INTENT(IN) :: waterBalance_Es
        REAL, INTENT(IN) :: waterBalance_Salb
        REAL , DIMENSION(: ), ALLOCATABLE, INTENT(IN) :: pInitialValues
        REAL, INTENT(IN) :: DepthToConstantTemperature
        REAL, INTENT(IN) :: timestep
        REAL, INTENT(IN) :: latentHeatOfVapourisation
        REAL, INTENT(IN) :: stefanBoltzmannConstant
        INTEGER, INTENT(IN) :: airNode
        INTEGER, INTENT(IN) :: surfaceNode
        INTEGER, INTENT(IN) :: topsoilNode
        INTEGER, INTENT(IN) :: numPhantomNodes
        REAL, INTENT(IN) :: constantBoundaryLayerConductance
        INTEGER, INTENT(IN) :: numIterationsForBoundaryLayerConductance
        REAL, INTENT(IN) :: defaultTimeOfMaximumTemperature
        REAL, INTENT(IN) :: defaultInstrumentHeight
        REAL, INTENT(IN) :: bareSoilRoughness
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) :: nodeDepth
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) :: thermCondPar1
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) :: thermCondPar2
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) :: thermCondPar3
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(INOUT) :: thermCondPar4
        REAL, INTENT(IN) :: pom
        REAL, INTENT(INOUT) :: soilRoughnessHeight
        REAL, INTENT(IN) :: nu
        CHARACTER(65), INTENT(IN) :: boundarLayerConductanceSource
        CHARACTER(65), INTENT(IN) :: netRadiationSource
        REAL, INTENT(IN) :: MissingValue
        CHARACTER(65) , DIMENSION(8 ), INTENT(IN) :: soilConstituentNames
        REAL, INTENT(OUT) :: netRadiation
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: aveSoilWater
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: bulkDensity
        REAL, INTENT(OUT) :: internalTimeStep
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: thermalConductance
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: thickness
        LOGICAL, INTENT(OUT) :: doInitialisationStuff
        REAL, INTENT(OUT) :: maxTempYesterday
        REAL, INTENT(OUT) :: timeOfDaySecs
        INTEGER, INTENT(OUT) :: numNodes
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: soilWater
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: clay
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: soilTemp
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: silt
        REAL, INTENT(OUT) :: instrumentHeight
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: sand
        INTEGER, INTENT(OUT) :: numLayers
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: volSpecHeatSoil
        REAL, INTENT(OUT) :: instrumHeight
        REAL, INTENT(OUT) :: canopyHeight
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: heatStorage
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: minSoilTemp
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: maxSoilTemp
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: newTemperature
        REAL, INTENT(OUT) :: airTemperature
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: thermalConductivity
        REAL, INTENT(OUT) :: minTempYesterday
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: carbon
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: rocks
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: InitialValues
        REAL, INTENT(OUT) :: boundaryLayerConductance
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: aveSoilTemp
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: morningSoilTemp
        call init_soiltemperature(weather_MinT, weather_MaxT, weather_MeanT,  &
                weather_Tav, weather_Amp, weather_AirPressure, weather_Wind,  &
                weather_Latitude, weather_Radn, clock_Today_DayOfYear,  &
                microClimate_CanopyHeight, physical_Thickness, physical_BD, ps,  &
                physical_Rocks, physical_ParticleSizeSand, physical_ParticleSizeSilt,  &
                physical_ParticleSizeClay, organic_Carbon, waterBalance_SW,  &
                waterBalance_Eos, waterBalance_Eo, waterBalance_Es,  &
                waterBalance_Salb, pInitialValues, DepthToConstantTemperature,  &
                timestep, latentHeatOfVapourisation, stefanBoltzmannConstant,  &
                airNode, surfaceNode, topsoilNode, numPhantomNodes,  &
                constantBoundaryLayerConductance,  &
                numIterationsForBoundaryLayerConductance,  &
                defaultTimeOfMaximumTemperature, defaultInstrumentHeight,  &
                bareSoilRoughness, nodeDepth, thermCondPar1, thermCondPar2,  &
                thermCondPar3, thermCondPar4, pom, soilRoughnessHeight, nu,  &
                boundarLayerConductanceSource, netRadiationSource, MissingValue,  &
                soilConstituentNames,InitialValues,doInitialisationStuff,internalTimeStep, &
                timeOfDaySecs,numNodes,numLayers,volSpecHeatSoil,soilTemp,morningSoilTemp, &
                heatStorage,thermalConductance,thermalConductivity,boundaryLayerConductance, &
                newTemperature,airTemperature,maxTempYesterday,minTempYesterday,soilWater, &
                minSoilTemp,maxSoilTemp,aveSoilTemp,aveSoilWater,thickness,bulkDensity,rocks, &
                carbon,sand,silt,clay,instrumentHeight,netRadiation,canopyHeight,instrumHeight)
    END SUBROUTINE init_soiltemp

END MODULE
