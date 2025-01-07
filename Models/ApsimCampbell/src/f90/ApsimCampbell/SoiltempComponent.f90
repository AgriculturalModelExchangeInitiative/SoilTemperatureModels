MODULE Soiltempmod
    USE Soiltemperaturemod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_soiltemp(Thickness, &
        thermalConductance, &
        weather_MaxT, &
        numIterationsForBoundaryLayerConductance, &
        newTemperature, &
        thermCondPar3, &
        instrumentHeight, &
        aveSoilWater, &
        defaultInstrumentHeight, &
        thermalConductivity, &
        silt, &
        weather_Radn, &
        bulkDensity, &
        latentHeatOfVapourisation, &
        microClimate_CanopyHeight, &
        weather_MinT, &
        physical_ParticleSizeClay, &
        airNode, &
        netRadiation, &
        ps, &
        rocks, &
        numLayers, &
        minSoilTemp, &
        instrumHeight, &
        soilTemp, &
        weather_Wind, &
        physical_ParticleSizeSand, &
        doInitialisationStuff, &
        canopyHeight, &
        boundaryLayerConductance, &
        defaultTimeOfMaximumTemperature, &
        soilWater, &
        netRadiationSource, &
        waterBalance_Eos, &
        maxTempYesterday, &
        weather_MeanT, &
        clay, &
        thickness, &
        weather_Latitude, &
        weather_Amp, &
        timestep, &
        maxSoilTemp, &
        topsoilNode, &
        MissingValue, &
        pom, &
        physical_BD, &
        timeOfDaySecs, &
        carbon, &
        physical_Thickness, &
        soilRoughnessHeight, &
        heatStorage, &
        numPhantomNodes, &
        thermCondPar4, &
        nodeDepth, &
        aveSoilTemp, &
        waterBalance_Salb, &
        minTempYesterday, &
        surfaceNode, &
        boundarLayerConductanceSource, &
        thermCondPar2, &
        physical_ParticleSizeSilt, &
        numNodes, &
        clock_Today_DayOfYear, &
        waterBalance_Eo, &
        DepthToConstantTemperature, &
        constantBoundaryLayerConductance, &
        nu, &
        waterBalance_SW, &
        waterBalance_Es, &
        weather_Tav, &
        volSpecHeatSoil, &
        bareSoilRoughness, &
        stefanBoltzmannConstant, &
        physical_Rocks, &
        InitialValues, &
        weather_AirPressure, &
        thermCondPar1, &
        sand, &
        morningSoilTemp, &
        organic_Carbon, &
        soilConstituentNames, &
        airTemperature, &
        internalTimeStep)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL , DIMENSION(: ), INTENT(IN) :: Thickness
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermalConductance
        REAL, INTENT(IN) :: weather_MaxT
        INTEGER, INTENT(IN) :: numIterationsForBoundaryLayerConductance
        REAL , DIMENSION(: ), INTENT(INOUT) :: newTemperature
        REAL , DIMENSION(: ), INTENT(IN) :: thermCondPar3
        REAL, INTENT(INOUT) :: instrumentHeight
        REAL , DIMENSION(: ), INTENT(IN) :: aveSoilWater
        REAL, INTENT(IN) :: defaultInstrumentHeight
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermalConductivity
        REAL , DIMENSION(: ), INTENT(IN) :: silt
        REAL, INTENT(IN) :: weather_Radn
        REAL , DIMENSION(: ), INTENT(IN) :: bulkDensity
        REAL, INTENT(IN) :: latentHeatOfVapourisation
        REAL, INTENT(IN) :: microClimate_CanopyHeight
        REAL, INTENT(IN) :: weather_MinT
        REAL , DIMENSION(: ), INTENT(IN) :: physical_ParticleSizeClay
        REAL, INTENT(IN) :: airNode
        REAL, INTENT(IN) :: netRadiation
        REAL, INTENT(IN) :: ps
        REAL , DIMENSION(: ), INTENT(IN) :: rocks
        INTEGER, INTENT(IN) :: numLayers
        REAL , DIMENSION(: ), INTENT(INOUT) :: minSoilTemp
        REAL, INTENT(IN) :: instrumHeight
        REAL , DIMENSION(: ), INTENT(INOUT) :: soilTemp
        REAL, INTENT(IN) :: weather_Wind
        REAL , DIMENSION(: ), INTENT(IN) :: physical_ParticleSizeSand
        LOGICAL, INTENT(INOUT) :: doInitialisationStuff
        REAL, INTENT(IN) :: canopyHeight
        REAL, INTENT(INOUT) :: boundaryLayerConductance
        REAL, INTENT(IN) :: defaultTimeOfMaximumTemperature
        REAL , DIMENSION(: ), INTENT(INOUT) :: soilWater
        CHARACTER(65), INTENT(IN) :: netRadiationSource
        REAL, INTENT(IN) :: waterBalance_Eos
        REAL, INTENT(INOUT) :: maxTempYesterday
        REAL, INTENT(IN) :: weather_MeanT
        REAL , DIMENSION(: ), INTENT(IN) :: clay
        REAL , DIMENSION(: ), INTENT(IN) :: thickness
        REAL, INTENT(IN) :: weather_Latitude
        REAL, INTENT(IN) :: weather_Amp
        REAL, INTENT(IN) :: timestep
        REAL , DIMENSION(: ), INTENT(INOUT) :: maxSoilTemp
        INTEGER, INTENT(IN) :: topsoilNode
        REAL, INTENT(IN) :: MissingValue
        REAL, INTENT(IN) :: pom
        REAL , DIMENSION(: ), INTENT(IN) :: physical_BD
        REAL, INTENT(IN) :: timeOfDaySecs
        REAL , DIMENSION(: ), INTENT(IN) :: carbon
        REAL , DIMENSION(: ), INTENT(IN) :: physical_Thickness
        REAL, INTENT(IN) :: soilRoughnessHeight
        REAL , DIMENSION(: ), INTENT(INOUT) :: heatStorage
        INTEGER, INTENT(IN) :: numPhantomNodes
        REAL , DIMENSION(: ), INTENT(IN) :: thermCondPar4
        REAL , DIMENSION(: ), INTENT(IN) :: nodeDepth
        REAL , DIMENSION(: ), INTENT(INOUT) :: aveSoilTemp
        REAL, INTENT(IN) :: waterBalance_Salb
        REAL, INTENT(INOUT) :: minTempYesterday
        INTEGER, INTENT(IN) :: surfaceNode
        CHARACTER(65), INTENT(IN) :: boundarLayerConductanceSource
        REAL , DIMENSION(: ), INTENT(IN) :: thermCondPar2
        REAL , DIMENSION(: ), INTENT(IN) :: physical_ParticleSizeSilt
        INTEGER, INTENT(IN) :: numNodes
        INTEGER, INTENT(IN) :: clock_Today_DayOfYear
        REAL, INTENT(IN) :: waterBalance_Eo
        REAL, INTENT(IN) :: DepthToConstantTemperature
        REAL, INTENT(IN) :: constantBoundaryLayerConductance
        REAL, INTENT(IN) :: nu
        REAL , DIMENSION(: ), INTENT(IN) :: waterBalance_SW
        REAL, INTENT(IN) :: waterBalance_Es
        REAL, INTENT(IN) :: weather_Tav
        REAL , DIMENSION(: ), INTENT(INOUT) :: volSpecHeatSoil
        REAL, INTENT(IN) :: bareSoilRoughness
        REAL, INTENT(IN) :: stefanBoltzmannConstant
        REAL , DIMENSION(: ), INTENT(IN) :: physical_Rocks
        REAL , DIMENSION(: ), INTENT(IN) :: InitialValues
        REAL, INTENT(IN) :: weather_AirPressure
        REAL , DIMENSION(: ), INTENT(IN) :: thermCondPar1
        REAL , DIMENSION(: ), INTENT(IN) :: sand
        REAL , DIMENSION(: ), INTENT(INOUT) :: morningSoilTemp
        REAL , DIMENSION(: ), INTENT(IN) :: organic_Carbon
        CHARACTER(65) , DIMENSION(8 ), INTENT(IN) :: soilConstituentNames
        REAL, INTENT(IN) :: airTemperature
        REAL, INTENT(IN) :: internalTimeStep
        !- Name: Soiltemp -Version: 2.0, -Time step: 1.0
        !- Description:
    !            * Title: Soiltemp model
    !            * Authors: Cyrille
    !            * Reference: None
    !            * Institution: INRAE
    !            * ExtendedDescription: Soil Temperature
    !            * ShortDescription: Soil Temperature
        !- inputs:
    !            * name: Thickness
    !                          ** description : Thickness of soil layers (mm)
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
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
    !            * name: weather_MaxT
    !                          ** description : Maximum temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: numIterationsForBoundaryLayerConductance
    !                          ** description : Number of iterations to calculate atmosphere boundary layer conductance
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** min : 
    !                          ** default : 1
    !                          ** unit : 
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
    !            * name: instrumentHeight
    !                          ** description : Height of instruments above soil surface
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : mm
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
    !            * name: defaultInstrumentHeight
    !                          ** description : Default instrument height
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 1.2
    !                          ** unit : m
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
    !            * name: weather_Radn
    !                          ** description : Solar radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : MJ/m2/day
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
    !            * name: latentHeatOfVapourisation
    !                          ** description : Latent heat of vapourisation for water
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 2465000
    !                          ** unit : miJ/kg
    !            * name: microClimate_CanopyHeight
    !                          ** description : Canopy height
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: weather_MinT
    !                          ** description : Minimum temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
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
    !            * name: airNode
    !                          ** description : The index of the node in the atmosphere (aboveground)
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : 
    !            * name: netRadiation
    !                          ** description : Net radiation per internal time-step
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : MJ
    !            * name: ps
    !                          ** description : ps
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
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
    !            * name: numLayers
    !                          ** description : Number of layers in the soil profile
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : 
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
    !            * name: instrumHeight
    !                          ** description : Height of instruments above ground
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : mm
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
    !            * name: weather_Wind
    !                          ** description : Wind speed
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : m/s
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
    !            * name: doInitialisationStuff
    !                          ** description : Flag whether initialisation is needed
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : BOOLEAN
    !                          ** max : 
    !                          ** min : 
    !                          ** default : false
    !                          ** unit : mintes
    !            * name: canopyHeight
    !                          ** description : Height of canopy above ground
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : mm
    !            * name: boundaryLayerConductance
    !                          ** description : Average daily atmosphere boundary layer conductance
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : 
    !            * name: defaultTimeOfMaximumTemperature
    !                          ** description : Time of maximum temperature
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 14.0
    !                          ** unit : minutes
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
    !            * name: netRadiationSource
    !                          ** description : Flag whether net radiation is calculated or gotten from input
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : STRING
    !                          ** max : 
    !                          ** min : 
    !                          ** default : calc
    !                          ** unit : m
    !            * name: waterBalance_Eos
    !                          ** description : Potential soil evaporation from soil surface
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: maxTempYesterday
    !                          ** description : Yesterday's maximum daily air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : oC
    !            * name: weather_MeanT
    !                          ** description : Mean temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
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
    !            * name: weather_Latitude
    !                          ** description : Latitude
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : deg
    !            * name: weather_Amp
    !                          ** description : Annual average temperature amplitude
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: timestep
    !                          ** description : Internal time-step (minutes)
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 24.0 * 60.0 * 60.0
    !                          ** unit : minutes
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
    !            * name: topsoilNode
    !                          ** description : The index of the first node within the soil (top layer)
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 2
    !                          ** unit : 
    !            * name: MissingValue
    !                          ** description : missing value
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 99999
    !                          ** unit : m
    !            * name: pom
    !                          ** description : Particle density of organic matter
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : Mg/m3
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
    !            * name: timeOfDaySecs
    !                          ** description : Time of day from midnight
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : sec
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
    !            * name: soilRoughnessHeight
    !                          ** description : Height of soil roughness
    !                          ** inputtype : parameter
    !                          ** parametercategory : private
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
    !            * name: numPhantomNodes
    !                          ** description : The number of phantom nodes below the soil profile
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 5
    !                          ** unit : 
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
    !            * name: waterBalance_Salb
    !                          ** description : Fraction of incoming radiation reflected from bare soil
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 0-1
    !            * name: minTempYesterday
    !                          ** description : Yesterday's minimum daily air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : oC
    !            * name: surfaceNode
    !                          ** description : The index of the node on the soil surface (depth = 0)
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 1
    !                          ** unit : 
    !            * name: boundarLayerConductanceSource
    !                          ** description : Flag whether boundary layer conductance is calculated or gotten from inpu
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : STRING
    !                          ** max : 
    !                          ** min : 
    !                          ** default : calc
    !                          ** unit : 
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
    !            * name: numNodes
    !                          ** description : Number of nodes over the soil profile
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : 
    !            * name: clock_Today_DayOfYear
    !                          ** description : Day of year
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : day number
    !            * name: waterBalance_Eo
    !                          ** description : Potential soil evapotranspiration from soil surface
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: DepthToConstantTemperature
    !                          ** description : Soil depth to constant temperature
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 10000
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
    !            * name: nu
    !                          ** description : Forward/backward differencing coefficient
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.6
    !                          ** unit : 0-1
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
    !            * name: waterBalance_Es
    !                          ** description : Actual (realised) soil water evaporation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: weather_Tav
    !                          ** description : Annual average temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
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
    !            * name: bareSoilRoughness
    !                          ** description : Roughness element height of bare soil
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 57
    !                          ** unit : mm
    !            * name: stefanBoltzmannConstant
    !                          ** description : The Stefan-Boltzmann constant
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0000000567
    !                          ** unit : W/m2/K4
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
    !            * name: InitialValues
    !                          ** description : Initial soil temperature
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: weather_AirPressure
    !                          ** description : Air pressure
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : hPa
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
    !            * name: airTemperature
    !                          ** description : Air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : oC
    !            * name: internalTimeStep
    !                          ** description : Internal time-step
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : sec
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
        call model_soiltemperature(weather_MinT, weather_MaxT, weather_MeanT,  &
                weather_Tav, weather_Amp, weather_AirPressure, weather_Wind,  &
                weather_Latitude, weather_Radn, clock_Today_DayOfYear,  &
                microClimate_CanopyHeight, physical_Thickness, physical_BD, ps,  &
                physical_Rocks, physical_ParticleSizeSand, physical_ParticleSizeSilt,  &
                physical_ParticleSizeClay, organic_Carbon, waterBalance_SW,  &
                waterBalance_Eos, waterBalance_Eo, waterBalance_Es,  &
                waterBalance_Salb, Thickness, InitialValues,  &
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

END MODULE
