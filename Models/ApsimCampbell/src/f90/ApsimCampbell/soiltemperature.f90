MODULE Soiltemperaturemod
    USE list_sub
    IMPLICIT NONE
CONTAINS

    SUBROUTINE init_soiltemperature(weather_MinT, &
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
        Thickness, &
        InitialValues, &
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
        REAL , DIMENSION(: ), INTENT(IN) :: waterBalance_SW
        REAL, INTENT(IN) :: waterBalance_Eos
        REAL, INTENT(IN) :: waterBalance_Eo
        REAL, INTENT(IN) :: waterBalance_Es
        REAL, INTENT(IN) :: waterBalance_Salb
        REAL , DIMENSION(: ), INTENT(IN) :: Thickness
        REAL , DIMENSION(: ), INTENT(IN) :: InitialValues
        REAL, INTENT(IN) :: DepthToConstantTemperature
        REAL, INTENT(IN) :: timestep
        REAL, INTENT(IN) :: latentHeatOfVapourisation
        REAL, INTENT(IN) :: stefanBoltzmannConstant
        REAL, INTENT(IN) :: airNode
        INTEGER, INTENT(IN) :: surfaceNode
        INTEGER, INTENT(IN) :: topsoilNode
        INTEGER, INTENT(IN) :: numPhantomNodes
        REAL, INTENT(IN) :: constantBoundaryLayerConductance
        INTEGER, INTENT(IN) :: numIterationsForBoundaryLayerConductance
        REAL, INTENT(IN) :: defaultTimeOfMaximumTemperature
        REAL, INTENT(IN) :: defaultInstrumentHeight
        REAL, INTENT(IN) :: bareSoilRoughness
        REAL , DIMENSION(: ), INTENT(INOUT) :: nodeDepth
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermCondPar1
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermCondPar2
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermCondPar3
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermCondPar4
        REAL, INTENT(IN) :: pom
        REAL, INTENT(INOUT) :: soilRoughnessHeight
        REAL, INTENT(IN) :: nu
        CHARACTER(65), INTENT(IN) :: boundarLayerConductanceSource
        CHARACTER(65), INTENT(IN) :: netRadiationSource
        REAL, INTENT(IN) :: MissingValue
        CHARACTER(65) , DIMENSION(8 ), INTENT(IN) :: soilConstituentNames
        LOGICAL, INTENT(OUT) :: doInitialisationStuff
        REAL, INTENT(OUT) :: internalTimeStep
        REAL, INTENT(OUT) :: timeOfDaySecs
        INTEGER, INTENT(OUT) :: numNodes
        INTEGER, INTENT(OUT) :: numLayers
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: volSpecHeatSoil
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: soilTemp
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: morningSoilTemp
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: heatStorage
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: thermalConductance
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: thermalConductivity
        REAL, INTENT(OUT) :: boundaryLayerConductance
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: newTemperature
        REAL, INTENT(OUT) :: airTemperature
        REAL, INTENT(OUT) :: maxTempYesterday
        REAL, INTENT(OUT) :: minTempYesterday
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: soilWater
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: minSoilTemp
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: maxSoilTemp
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: aveSoilTemp
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: aveSoilWater
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: thickness
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: bulkDensity
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: rocks
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: carbon
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: sand
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: silt
        REAL , DIMENSION(: ), ALLOCATABLE , INTENT(OUT) :: clay
        REAL, INTENT(OUT) :: instrumentHeight
        REAL, INTENT(OUT) :: netRadiation
        REAL, INTENT(OUT) :: canopyHeight
        REAL, INTENT(OUT) :: instrumHeight
        doInitialisationStuff = false
        internalTimeStep = 0.0
        timeOfDaySecs = 0.0
        numNodes = 0
        numLayers = 0
        boundaryLayerConductance = 0.0
        airTemperature = 0.0
        maxTempYesterday = 0.0
        minTempYesterday = 0.0
        instrumentHeight = 0.0
        netRadiation = 0.0
        canopyHeight = 0.0
        instrumHeight = 0.0
        doInitialisationStuff = .TRUE.
        instrumentHeight = getIniVariables(instrumHeight,  &
                defaultInstrumentHeight, instrumentHeight)
        call getProfileVariables(maxSoilTemp, minSoilTemp, topsoilNode,  &
                thermalConductance, physical_BD, soilTemp, carbon,  &
                physical_ParticleSizeSand, physical_Thickness, newTemperature,  &
                heatStorage, numPhantomNodes, soilWater, nodeDepth, volSpecHeatSoil,  &
                aveSoilTemp, surfaceNode, rocks, physical_Rocks,  &
                physical_ParticleSizeSilt, thermalConductivity, silt, sand, numNodes,  &
                organic_Carbon, morningSoilTemp, DepthToConstantTemperature, clay,  &
                thickness, bulkDensity, waterBalance_SW, airNode,  &
                physical_ParticleSizeClay, numLayers, MissingValue)
        call readParam(soilTemp, soilRoughnessHeight, newTemperature,  &
                bareSoilRoughness, thermCondPar2, thermCondPar3, thermCondPar4,  &
                bulkDensity, thermCondPar1, numNodes, clay, numLayers,  &
                weather_Latitude, weather_Amp, clock_Today_DayOfYear, weather_Tav,  &
                surfaceNode, thickness)
    END SUBROUTINE init_soiltemperature

    SUBROUTINE model_soiltemperature(weather_MinT, &
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
        Thickness, &
        InitialValues, &
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
        doInitialisationStuff, &
        internalTimeStep, &
        timeOfDaySecs, &
        numNodes, &
        numLayers, &
        nodeDepth, &
        thermCondPar1, &
        thermCondPar2, &
        thermCondPar3, &
        thermCondPar4, &
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
        pom, &
        silt, &
        clay, &
        soilRoughnessHeight, &
        instrumentHeight, &
        netRadiation, &
        canopyHeight, &
        instrumHeight, &
        nu, &
        boundarLayerConductanceSource, &
        netRadiationSource, &
        MissingValue, &
        soilConstituentNames)
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
        REAL , DIMENSION(: ), INTENT(IN) :: waterBalance_SW
        REAL, INTENT(IN) :: waterBalance_Eos
        REAL, INTENT(IN) :: waterBalance_Eo
        REAL, INTENT(IN) :: waterBalance_Es
        REAL, INTENT(IN) :: waterBalance_Salb
        REAL , DIMENSION(: ), INTENT(IN) :: Thickness
        REAL , DIMENSION(: ), INTENT(IN) :: InitialValues
        REAL, INTENT(IN) :: DepthToConstantTemperature
        REAL, INTENT(IN) :: timestep
        REAL, INTENT(IN) :: latentHeatOfVapourisation
        REAL, INTENT(IN) :: stefanBoltzmannConstant
        REAL, INTENT(IN) :: airNode
        INTEGER, INTENT(IN) :: surfaceNode
        INTEGER, INTENT(IN) :: topsoilNode
        INTEGER, INTENT(IN) :: numPhantomNodes
        REAL, INTENT(IN) :: constantBoundaryLayerConductance
        INTEGER, INTENT(IN) :: numIterationsForBoundaryLayerConductance
        REAL, INTENT(IN) :: defaultTimeOfMaximumTemperature
        REAL, INTENT(IN) :: defaultInstrumentHeight
        REAL, INTENT(IN) :: bareSoilRoughness
        LOGICAL, INTENT(INOUT) :: doInitialisationStuff
        REAL, INTENT(IN) :: internalTimeStep
        REAL, INTENT(IN) :: timeOfDaySecs
        INTEGER, INTENT(IN) :: numNodes
        INTEGER, INTENT(IN) :: numLayers
        REAL , DIMENSION(: ), INTENT(IN) :: nodeDepth
        REAL , DIMENSION(: ), INTENT(IN) :: thermCondPar1
        REAL , DIMENSION(: ), INTENT(IN) :: thermCondPar2
        REAL , DIMENSION(: ), INTENT(IN) :: thermCondPar3
        REAL , DIMENSION(: ), INTENT(IN) :: thermCondPar4
        REAL , DIMENSION(: ), INTENT(INOUT) :: volSpecHeatSoil
        REAL , DIMENSION(: ), INTENT(INOUT) :: soilTemp
        REAL , DIMENSION(: ), INTENT(INOUT) :: morningSoilTemp
        REAL , DIMENSION(: ), INTENT(INOUT) :: heatStorage
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermalConductance
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermalConductivity
        REAL, INTENT(INOUT) :: boundaryLayerConductance
        REAL , DIMENSION(: ), INTENT(INOUT) :: newTemperature
        REAL, INTENT(IN) :: airTemperature
        REAL, INTENT(INOUT) :: maxTempYesterday
        REAL, INTENT(INOUT) :: minTempYesterday
        REAL , DIMENSION(: ), INTENT(INOUT) :: soilWater
        REAL , DIMENSION(: ), INTENT(INOUT) :: minSoilTemp
        REAL , DIMENSION(: ), INTENT(INOUT) :: maxSoilTemp
        REAL , DIMENSION(: ), INTENT(INOUT) :: aveSoilTemp
        REAL , DIMENSION(: ), INTENT(IN) :: aveSoilWater
        REAL , DIMENSION(: ), INTENT(IN) :: thickness
        REAL , DIMENSION(: ), INTENT(IN) :: bulkDensity
        REAL , DIMENSION(: ), INTENT(IN) :: rocks
        REAL , DIMENSION(: ), INTENT(IN) :: carbon
        REAL , DIMENSION(: ), INTENT(IN) :: sand
        REAL, INTENT(IN) :: pom
        REAL , DIMENSION(: ), INTENT(IN) :: silt
        REAL , DIMENSION(: ), INTENT(IN) :: clay
        REAL, INTENT(IN) :: soilRoughnessHeight
        REAL, INTENT(INOUT) :: instrumentHeight
        REAL, INTENT(IN) :: netRadiation
        REAL, INTENT(IN) :: canopyHeight
        REAL, INTENT(IN) :: instrumHeight
        REAL, INTENT(IN) :: nu
        CHARACTER(65), INTENT(IN) :: boundarLayerConductanceSource
        CHARACTER(65), INTENT(IN) :: netRadiationSource
        REAL, INTENT(IN) :: MissingValue
        CHARACTER(65) , DIMENSION(8 ), INTENT(IN) :: soilConstituentNames
        INTEGER:: i
        !- Name: SoilTemperature -Version:  1.0, -Time step:  1
        !- Description:
    !            * Title: SoilTemperature
    !            * Authors: APSIM
    !            * Reference: None
    !            * Institution: APSIM Initiative
    !            * ExtendedDescription:  Soil Temperature 
    !            * ShortDescription: Heat flux and temperatures over the surface and soil profile (based on Campbell, 1985)
        !- inputs:
    !            * name: weather_MinT
    !                          ** description : Minimum temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
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
    !            * name: weather_MeanT
    !                          ** description : Mean temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: weather_Tav
    !                          ** description : Annual average temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : oC
    !            * name: weather_Amp
    !                          ** description : Annual average temperature amplitude
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
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
    !            * name: weather_Wind
    !                          ** description : Wind speed
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : m/s
    !            * name: weather_Latitude
    !                          ** description : Latitude
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : deg
    !            * name: weather_Radn
    !                          ** description : Solar radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : MJ/m2/day
    !            * name: clock_Today_DayOfYear
    !                          ** description : Day of year
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : day number
    !            * name: microClimate_CanopyHeight
    !                          ** description : Canopy height
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
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
    !            * name: ps
    !                          ** description : ps
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
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
    !            * name: waterBalance_Eos
    !                          ** description : Potential soil evaporation from soil surface
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: waterBalance_Eo
    !                          ** description : Potential soil evapotranspiration from soil surface
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: waterBalance_Es
    !                          ** description : Actual (realised) soil water evaporation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: waterBalance_Salb
    !                          ** description : Fraction of incoming radiation reflected from bare soil
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 0-1
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
    !            * name: DepthToConstantTemperature
    !                          ** description : Soil depth to constant temperature
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 10000
    !                          ** unit : mm
    !            * name: timestep
    !                          ** description : Internal time-step (minutes)
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 24.0 * 60.0 * 60.0
    !                          ** unit : minutes
    !            * name: latentHeatOfVapourisation
    !                          ** description : Latent heat of vapourisation for water
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 2465000
    !                          ** unit : miJ/kg
    !            * name: stefanBoltzmannConstant
    !                          ** description : The Stefan-Boltzmann constant
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0.0000000567
    !                          ** unit : W/m2/K4
    !            * name: airNode
    !                          ** description : The index of the node in the atmosphere (aboveground)
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
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
    !            * name: topsoilNode
    !                          ** description : The index of the first node within the soil (top layer)
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 2
    !                          ** unit : 
    !            * name: numPhantomNodes
    !                          ** description : The number of phantom nodes below the soil profile
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 5
    !                          ** unit : 
    !            * name: constantBoundaryLayerConductance
    !                          ** description : Boundary layer conductance, if constant
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 20
    !                          ** unit : K/W
    !            * name: numIterationsForBoundaryLayerConductance
    !                          ** description : Number of iterations to calculate atmosphere boundary layer conductance
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** min : 
    !                          ** default : 1
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
    !            * name: defaultInstrumentHeight
    !                          ** description : Default instrument height
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 1.2
    !                          ** unit : m
    !            * name: bareSoilRoughness
    !                          ** description : Roughness element height of bare soil
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 57
    !                          ** unit : mm
    !            * name: doInitialisationStuff
    !                          ** description : Flag whether initialisation is needed
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : BOOLEAN
    !                          ** max : 
    !                          ** min : 
    !                          ** default : false
    !                          ** unit : mintes
    !            * name: internalTimeStep
    !                          ** description : Internal time-step
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : sec
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
    !            * name: numLayers
    !                          ** description : Number of layers in the soil profile
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
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
    !            * name: boundaryLayerConductance
    !                          ** description : Average daily atmosphere boundary layer conductance
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
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
    !            * name: airTemperature
    !                          ** description : Air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : oC
    !            * name: maxTempYesterday
    !                          ** description : Yesterday's maximum daily air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : oC
    !            * name: minTempYesterday
    !                          ** description : Yesterday's minimum daily air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : oC
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
    !            * name: pom
    !                          ** description : Particle density of organic matter
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : Mg/m3
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
    !            * name: soilRoughnessHeight
    !                          ** description : Height of soil roughness
    !                          ** inputtype : parameter
    !                          ** parametercategory : private
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
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
    !            * name: netRadiation
    !                          ** description : Net radiation per internal time-step
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : MJ
    !            * name: canopyHeight
    !                          ** description : Height of canopy above ground
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
    !                          ** unit : mm
    !            * name: instrumHeight
    !                          ** description : Height of instruments above ground
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 0
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
    !            * name: boundarLayerConductanceSource
    !                          ** description : Flag whether boundary layer conductance is calculated or gotten from inpu
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : STRING
    !                          ** max : 
    !                          ** min : 
    !                          ** default : calc
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
    !            * name: MissingValue
    !                          ** description : missing value
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 99999
    !                          ** unit : m
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
        call getOtherVariables(soilWater, instrumentHeight,  &
                microClimate_CanopyHeight, waterBalance_SW, numNodes, canopyHeight,  &
                soilRoughnessHeight, numLayers)
        IF(doInitialisationStuff) THEN
            IF(ValuesInArray(InitialValues, MissingValue)) THEN
                soilTemp = 0.0
                soilTemp(topsoilNode:topsoilNode + SIZE(InitialValues)) =  &
                        InitialValues(0:0 + SIZE(InitialValues))
            ELSE
                soilTemp = calcSoilTemperature(soilTemp, weather_Latitude,  &
                        weather_Amp, numNodes, clock_Today_DayOfYear, weather_Tav,  &
                        surfaceNode, thickness)
                InitialValues = 0.0
                InitialValues(0:0 + numLayers) = soilTemp(topsoilNode:topsoilNode +  &
                        numLayers)
            END IF
            soilTemp(airNode+1) = weather_MeanT
            soilTemp(surfaceNode+1) = calcSurfaceTemperature(waterBalance_Salb,  &
                    weather_MeanT, weather_Radn, weather_MaxT)
            DO i = numNodes + 1 , SIZE(soilTemp)-1, 1
                soilTemp(i+1) = weather_Tav
            END DO
            newTemperature(0:0 + SIZE(soilTemp)) = soilTemp
            maxTempYesterday = weather_MaxT
            minTempYesterday = weather_MinT
            doInitialisationStuff = .FALSE.
        END IF
        call doProcess(maxSoilTemp, minSoilTemp, weather_MaxT,  &
                numIterationsForBoundaryLayerConductance, maxTempYesterday,  &
                thermalConductivity, timeOfDaySecs, soilTemp, weather_MeanT,  &
                morningSoilTemp, newTemperature, boundaryLayerConductance,  &
                constantBoundaryLayerConductance, airTemperature, timestep,  &
                weather_MinT, airNode, netRadiation, aveSoilTemp, minTempYesterday,  &
                internalTimeStep, boundarLayerConductanceSource,  &
                clock_Today_DayOfYear, weather_Latitude, weather_Radn,  &
                soilConstituentNames, soilWater, volSpecHeatSoil, numNodes,  &
                nodeDepth, surfaceNode, thickness, MissingValue, bulkDensity, carbon,  &
                pom, rocks, ps, sand, silt, clay, defaultTimeOfMaximumTemperature,  &
                waterBalance_Eo, waterBalance_Eos, waterBalance_Salb,  &
                stefanBoltzmannConstant, weather_AirPressure, instrumentHeight,  &
                weather_Wind, canopyHeight, netRadiationSource, thermalConductance,  &
                waterBalance_Es, heatStorage, latentHeatOfVapourisation, nu)
    END SUBROUTINE model_soiltemperature

    FUNCTION getIniVariables(instrumHeight, &
        defaultInstrumentHeight, &
        instrumentHeight) RESULT(instrumentHeight)
        IMPLICIT NONE
        REAL, INTENT(IN) :: instrumHeight
        REAL, INTENT(IN) :: defaultInstrumentHeight
        REAL, INTENT(INOUT) :: instrumentHeight
        IF(instrumHeight .GT. 0.00001) THEN
            instrumentHeight = instrumHeight
        ELSE
            instrumentHeight = defaultInstrumentHeight
        END IF
    END FUNCTION getIniVariables

    SUBROUTINE getProfileVariables(maxSoilTemp, &
        minSoilTemp, &
        topsoilNode, &
        thermalConductance, &
        physical_BD, &
        soilTemp, &
        carbon, &
        physical_ParticleSizeSand, &
        physical_Thickness, &
        newTemperature, &
        heatStorage, &
        numPhantomNodes, &
        soilWater, &
        nodeDepth, &
        volSpecHeatSoil, &
        aveSoilTemp, &
        surfaceNode, &
        rocks, &
        physical_Rocks, &
        physical_ParticleSizeSilt, &
        thermalConductivity, &
        silt, &
        sand, &
        numNodes, &
        organic_Carbon, &
        morningSoilTemp, &
        DepthToConstantTemperature, &
        clay, &
        thickness, &
        bulkDensity, &
        waterBalance_SW, &
        airNode, &
        physical_ParticleSizeClay, &
        numLayers, &
        MissingValue)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL , DIMENSION(: ), INTENT(INOUT) :: maxSoilTemp
        REAL , DIMENSION(: ), INTENT(INOUT) :: minSoilTemp
        INTEGER, INTENT(IN) :: topsoilNode
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermalConductance
        REAL , DIMENSION(: ), INTENT(IN) :: physical_BD
        REAL , DIMENSION(: ), INTENT(INOUT) :: soilTemp
        REAL , DIMENSION(: ), INTENT(INOUT) :: carbon
        REAL , DIMENSION(: ), INTENT(IN) :: physical_ParticleSizeSand
        REAL , DIMENSION(: ), INTENT(IN) :: physical_Thickness
        REAL , DIMENSION(: ), INTENT(INOUT) :: newTemperature
        REAL , DIMENSION(: ), INTENT(INOUT) :: heatStorage
        INTEGER, INTENT(IN) :: numPhantomNodes
        REAL , DIMENSION(: ), INTENT(INOUT) :: soilWater
        REAL , DIMENSION(: ), INTENT(INOUT) :: nodeDepth
        REAL , DIMENSION(: ), INTENT(INOUT) :: volSpecHeatSoil
        REAL , DIMENSION(: ), INTENT(INOUT) :: aveSoilTemp
        INTEGER, INTENT(IN) :: surfaceNode
        REAL , DIMENSION(: ), INTENT(INOUT) :: rocks
        REAL , DIMENSION(: ), INTENT(IN) :: physical_Rocks
        REAL , DIMENSION(: ), INTENT(IN) :: physical_ParticleSizeSilt
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermalConductivity
        REAL , DIMENSION(: ), INTENT(INOUT) :: silt
        REAL , DIMENSION(: ), INTENT(INOUT) :: sand
        INTEGER, INTENT(INOUT) :: numNodes
        REAL , DIMENSION(: ), INTENT(IN) :: organic_Carbon
        REAL , DIMENSION(: ), INTENT(INOUT) :: morningSoilTemp
        REAL, INTENT(IN) :: DepthToConstantTemperature
        REAL , DIMENSION(: ), INTENT(INOUT) :: clay
        REAL , DIMENSION(: ), INTENT(INOUT) :: thickness
        REAL , DIMENSION(: ), INTENT(INOUT) :: bulkDensity
        REAL , DIMENSION(: ), INTENT(IN) :: waterBalance_SW
        REAL, INTENT(IN) :: airNode
        REAL , DIMENSION(: ), INTENT(IN) :: physical_ParticleSizeClay
        INTEGER, INTENT(INOUT) :: numLayers
        REAL, INTENT(IN) :: MissingValue
        INTEGER:: layer
        INTEGER:: node
        INTEGER:: i
        REAL:: belowProfileDepth
        REAL:: thicknessForPhantomNodes
        INTEGER:: firstPhantomNode
        REAL , DIMENSION(: ), ALLOCATABLE :: oldDepth
        REAL , DIMENSION(: ), ALLOCATABLE :: oldBulkDensity
        REAL , DIMENSION(: ), ALLOCATABLE :: oldSoilWater
        numLayers = SIZE(physical_Thickness)
        numNodes = numLayers + numPhantomNodes
        thickness = 0.0
        thickness(1:1 + SIZE(physical_Thickness)) = physical_Thickness
        belowProfileDepth = MAX(DepthToConstantTemperature - Sum(thickness,  &
                1, numLayers, MissingValue), 1000.0)
        thicknessForPhantomNodes = belowProfileDepth * 2.0 / numPhantomNodes
        firstPhantomNode = numLayers
        DO i = firstPhantomNode , firstPhantomNode + numPhantomNodes-1, 1
            thickness(i+1) = thicknessForPhantomNodes
        END DO
        oldDepth = nodeDepth
        nodeDepth = 0.0
        IF(ALLOCATE(oldDepth)) THEN
            nodeDepth(0:MIN(numNodes + 1 + 1, SIZE(oldDepth))) =  &
                    oldDepth(0:MIN(numNodes + 1 + 1, SIZE(oldDepth)))
        END IF
        nodeDepth(airNode+1) = 0.0
        nodeDepth(surfaceNode+1) = 0.0
        nodeDepth(topsoilNode+1) = 0.5 * thickness(2) / 1000.0
        DO node = topsoilNode , numNodes + 1-1, 1
            nodeDepth(node + 1+1) = (Sum(thickness, 1, node - 1, MissingValue) +  &
                    (0.5 * thickness(node+1))) / 1000.0
        END DO
        oldBulkDensity = bulkDensity
        bulkDensity = 0.0
        IF(ALLOCATE(oldBulkDensity)) THEN
            bulkDensity(0:MIN(numLayers + 1 + numPhantomNodes,  &
                    SIZE(oldBulkDensity))) = oldBulkDensity(0:MIN(numLayers + 1 +  &
                    numPhantomNodes, SIZE(oldBulkDensity)))
        END IF
        bulkDensity(1:1 + SIZE(physical_BD)) = physical_BD
        bulkDensity(numNodes+1) = bulkDensity(numLayers+1)
        DO layer = numLayers + 1 , numLayers + numPhantomNodes + 1-1, 1
            bulkDensity(layer+1) = bulkDensity(numLayers+1)
        END DO
        oldSoilWater = soilWater
        soilWater = 0.0
        IF(ALLOCATE(oldSoilWater)) THEN
            soilWater(0:MIN(numLayers + 1 + numPhantomNodes, SIZE(oldSoilWater)))  &
                    = oldSoilWater(0:MIN(numLayers + 1 + numPhantomNodes,  &
                    SIZE(oldSoilWater)))
        END IF
        IF(ALLOCATE(waterBalance_SW)) THEN
            DO layer = 1 , numLayers + 1-1, 1
                soilWater(layer+1) = Divide(waterBalance_SW((layer - 1)+1) *  &
                        thickness((layer - 1)+1), thickness(layer+1), 0)
            END DO
            DO layer = numLayers + 1 , numLayers + numPhantomNodes + 1-1, 1
                soilWater(layer+1) = soilWater(numLayers+1)
            END DO
        END IF
        carbon = 0.0
        DO layer = 1 , numLayers + 1-1, 1
            carbon(layer+1) = organic_Carbon(layer - 1+1)
        END DO
        DO layer = numLayers + 1 , numLayers + numPhantomNodes + 1-1, 1
            carbon(layer+1) = carbon(numLayers+1)
        END DO
        rocks = 0.0
        DO layer = 1 , numLayers + 1-1, 1
            rocks(layer+1) = physical_Rocks(layer - 1+1)
        END DO
        DO layer = numLayers + 1 , numLayers + numPhantomNodes + 1-1, 1
            rocks(layer+1) = rocks(numLayers+1)
        END DO
        sand = 0.0
        DO layer = 1 , numLayers + 1-1, 1
            sand(layer+1) = physical_ParticleSizeSand(layer - 1+1)
        END DO
        DO layer = numLayers + 1 , numLayers + numPhantomNodes + 1-1, 1
            sand(layer+1) = sand(numLayers+1)
        END DO
        silt = 0.0
        DO layer = 1 , numLayers + 1-1, 1
            silt(layer+1) = physical_ParticleSizeSilt(layer - 1+1)
        END DO
        DO layer = numLayers + 1 , numLayers + numPhantomNodes + 1-1, 1
            silt(layer+1) = silt(numLayers+1)
        END DO
        clay = 0.0
        DO layer = 1 , numLayers + 1-1, 1
            clay(layer+1) = physical_ParticleSizeClay(layer - 1+1)
        END DO
        DO layer = numLayers + 1 , numLayers + numPhantomNodes + 1-1, 1
            clay(layer+1) = clay(numLayers+1)
        END DO
        maxSoilTemp = 0.0
        minSoilTemp = 0.0
        aveSoilTemp = 0.0
        volSpecHeatSoil = 0.0
        soilTemp = 0.0
        morningSoilTemp = 0.0
        newTemperature = 0.0
        thermalConductivity = 0.0
        heatStorage = 0.0
        thermalConductance = 0.0
    END SUBROUTINE getProfileVariables

    SUBROUTINE doThermalConductivityCoeffs(thermCondPar2, &
        thermCondPar3, &
        thermCondPar4, &
        bulkDensity, &
        thermCondPar1, &
        numNodes, &
        clay, &
        numLayers)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermCondPar2
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermCondPar3
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermCondPar4
        REAL , DIMENSION(: ), INTENT(IN) :: bulkDensity
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermCondPar1
        INTEGER, INTENT(IN) :: numNodes
        REAL , DIMENSION(: ), INTENT(IN) :: clay
        INTEGER, INTENT(IN) :: numLayers
        INTEGER:: layer
        REAL , DIMENSION(: ), ALLOCATABLE :: oldGC1
        REAL , DIMENSION(: ), ALLOCATABLE :: oldGC2
        REAL , DIMENSION(: ), ALLOCATABLE :: oldGC3
        REAL , DIMENSION(: ), ALLOCATABLE :: oldGC4
        INTEGER:: element
        oldGC1 = thermCondPar1
        thermCondPar1 = 0.0
        IF(ALLOCATE(oldGC1)) THEN
            thermCondPar1(0:MIN(numNodes + 1, SIZE(oldGC1))) =  &
                    oldGC1(0:MIN(numNodes + 1, SIZE(oldGC1)))
        END IF
        oldGC2 = thermCondPar2
        thermCondPar2 = 0.0
        IF(ALLOCATE(oldGC2)) THEN
            thermCondPar2(0:MIN(numNodes + 1, SIZE(oldGC2))) =  &
                    oldGC2(0:MIN(numNodes + 1, SIZE(oldGC2)))
        END IF
        oldGC3 = thermCondPar3
        thermCondPar3 = 0.0
        IF(ALLOCATE(oldGC3)) THEN
            thermCondPar3(0:MIN(numNodes + 1, SIZE(oldGC3))) =  &
                    oldGC3(0:MIN(numNodes + 1, SIZE(oldGC3)))
        END IF
        oldGC4 = thermCondPar4
        thermCondPar4 = 0.0
        IF(ALLOCATE(oldGC4)) THEN
            thermCondPar4(0:MIN(numNodes + 1, SIZE(oldGC4))) =  &
                    oldGC4(0:MIN(numNodes + 1, SIZE(oldGC4)))
        END IF
        DO layer = 1 , numLayers + 1 + 1-1, 1
            element = layer
            thermCondPar1(element+1) = 0.65 - (0.78 * bulkDensity(layer+1)) +  &
                    (0.6 *  (bulkDensity(layer+1) ** 2))
            thermCondPar2(element+1) = 1.06 * bulkDensity(layer+1)
            thermCondPar3(element+1) = 1.0 + Divide(2.6, SQRT(clay(layer+1)), 0)
            thermCondPar4(element+1) = 0.03 + (0.1 *  (bulkDensity(layer+1) ** 2))
        END DO
    END SUBROUTINE doThermalConductivityCoeffs

    SUBROUTINE readParam(soilTemp, &
        soilRoughnessHeight, &
        newTemperature, &
        bareSoilRoughness, &
        thermCondPar2, &
        thermCondPar3, &
        thermCondPar4, &
        bulkDensity, &
        thermCondPar1, &
        numNodes, &
        clay, &
        numLayers, &
        weather_Latitude, &
        weather_Amp, &
        clock_Today_DayOfYear, &
        weather_Tav, &
        surfaceNode, &
        thickness)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL , DIMENSION(: ), INTENT(INOUT) :: soilTemp
        REAL, INTENT(INOUT) :: soilRoughnessHeight
        REAL , DIMENSION(: ), INTENT(INOUT) :: newTemperature
        REAL, INTENT(IN) :: bareSoilRoughness
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermCondPar2
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermCondPar3
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermCondPar4
        REAL , DIMENSION(: ), INTENT(IN) :: bulkDensity
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermCondPar1
        INTEGER, INTENT(IN) :: numNodes
        REAL , DIMENSION(: ), INTENT(IN) :: clay
        INTEGER, INTENT(IN) :: numLayers
        REAL, INTENT(IN) :: weather_Latitude
        REAL, INTENT(IN) :: weather_Amp
        INTEGER, INTENT(IN) :: clock_Today_DayOfYear
        REAL, INTENT(IN) :: weather_Tav
        INTEGER, INTENT(IN) :: surfaceNode
        REAL , DIMENSION(: ), INTENT(IN) :: thickness
        call doThermalConductivityCoeffs(thermCondPar2, thermCondPar3,  &
                thermCondPar4, bulkDensity, thermCondPar1, numNodes, clay, numLayers)
        soilTemp = calcSoilTemperature(soilTemp, weather_Latitude,  &
                weather_Amp, numNodes, clock_Today_DayOfYear, weather_Tav,  &
                surfaceNode, thickness)
        newTemperature(0:0 + SIZE(soilTemp)) = soilTemp
        soilRoughnessHeight = bareSoilRoughness
    END SUBROUTINE readParam

    SUBROUTINE getOtherVariables(soilWater, &
        instrumentHeight, &
        microClimate_CanopyHeight, &
        waterBalance_SW, &
        numNodes, &
        canopyHeight, &
        soilRoughnessHeight, &
        numLayers)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL , DIMENSION(: ), INTENT(INOUT) :: soilWater
        REAL, INTENT(INOUT) :: instrumentHeight
        REAL, INTENT(IN) :: microClimate_CanopyHeight
        REAL , DIMENSION(: ), INTENT(IN) :: waterBalance_SW
        INTEGER, INTENT(IN) :: numNodes
        REAL, INTENT(INOUT) :: canopyHeight
        REAL, INTENT(IN) :: soilRoughnessHeight
        INTEGER, INTENT(IN) :: numLayers
        soilWater(1:1 + SIZE(waterBalance_SW)) = waterBalance_SW
        soilWater(numNodes+1) = soilWater(numLayers+1)
        canopyHeight = MAX(microClimate_CanopyHeight, soilRoughnessHeight) /  &
                1000.0
        instrumentHeight = MAX(instrumentHeight, canopyHeight + 0.5)
    END SUBROUTINE getOtherVariables

    FUNCTION volumetricFractionOrganicMatter(layer, &
        bulkDensity, &
        carbon, &
        pom) RESULT(res_cyml)
        IMPLICIT NONE
        INTEGER, INTENT(IN) :: layer
        REAL , DIMENSION(: ), INTENT(IN) :: bulkDensity
        REAL , DIMENSION(: ), INTENT(IN) :: carbon
        REAL, INTENT(IN) :: pom
        REAL:: res_cyml
        res_cyml = carbon(layer+1) / 100.0 * 2.5 * bulkDensity(layer+1) / pom
    END FUNCTION volumetricFractionOrganicMatter

    FUNCTION volumetricFractionRocks(layer, &
        rocks) RESULT(res_cyml)
        IMPLICIT NONE
        INTEGER, INTENT(IN) :: layer
        REAL , DIMENSION(: ), INTENT(IN) :: rocks
        REAL:: res_cyml
        res_cyml = rocks(layer+1) / 100.0
    END FUNCTION volumetricFractionRocks

    FUNCTION volumetricFractionIce(layer) RESULT(res_cyml)
        IMPLICIT NONE
        INTEGER, INTENT(IN) :: layer
        REAL:: res_cyml
        res_cyml = 0.0
    END FUNCTION volumetricFractionIce

    FUNCTION volumetricFractionWater(layer, &
        soilWater, &
        bulkDensity, &
        carbon, &
        pom) RESULT(res_cyml)
        IMPLICIT NONE
        INTEGER, INTENT(IN) :: layer
        REAL , DIMENSION(: ), INTENT(IN) :: soilWater
        REAL , DIMENSION(: ), INTENT(IN) :: bulkDensity
        REAL , DIMENSION(: ), INTENT(IN) :: carbon
        REAL, INTENT(IN) :: pom
        REAL:: res_cyml
        res_cyml = (1 - volumetricFractionOrganicMatter(layer, bulkDensity,  &
                carbon, pom)) * soilWater(layer+1)
    END FUNCTION volumetricFractionWater

    FUNCTION volumetricFractionClay(layer, &
        bulkDensity, &
        clay, &
        ps, &
        carbon, &
        pom, &
        rocks) RESULT(res_cyml)
        IMPLICIT NONE
        INTEGER, INTENT(IN) :: layer
        REAL , DIMENSION(: ), INTENT(IN) :: bulkDensity
        REAL , DIMENSION(: ), INTENT(IN) :: clay
        REAL, INTENT(IN) :: ps
        REAL , DIMENSION(: ), INTENT(IN) :: carbon
        REAL, INTENT(IN) :: pom
        REAL , DIMENSION(: ), INTENT(IN) :: rocks
        REAL:: res_cyml
        res_cyml = (1 - volumetricFractionOrganicMatter(layer, bulkDensity,  &
                carbon, pom) - volumetricFractionRocks(layer, rocks)) * clay(layer+1)  &
                / 100.0 * bulkDensity(layer+1) / ps
    END FUNCTION volumetricFractionClay

    FUNCTION volumetricFractionSilt(layer, &
        bulkDensity, &
        silt, &
        ps, &
        carbon, &
        pom, &
        rocks) RESULT(res_cyml)
        IMPLICIT NONE
        INTEGER, INTENT(IN) :: layer
        REAL , DIMENSION(: ), INTENT(IN) :: bulkDensity
        REAL , DIMENSION(: ), INTENT(IN) :: silt
        REAL, INTENT(IN) :: ps
        REAL , DIMENSION(: ), INTENT(IN) :: carbon
        REAL, INTENT(IN) :: pom
        REAL , DIMENSION(: ), INTENT(IN) :: rocks
        REAL:: res_cyml
        res_cyml = (1 - volumetricFractionOrganicMatter(layer, bulkDensity,  &
                carbon, pom) - volumetricFractionRocks(layer, rocks)) * silt(layer+1)  &
                / 100.0 * bulkDensity(layer+1) / ps
    END FUNCTION volumetricFractionSilt

    FUNCTION volumetricFractionSand(layer, &
        bulkDensity, &
        ps, &
        sand, &
        carbon, &
        pom, &
        rocks) RESULT(res_cyml)
        IMPLICIT NONE
        INTEGER, INTENT(IN) :: layer
        REAL , DIMENSION(: ), INTENT(IN) :: bulkDensity
        REAL, INTENT(IN) :: ps
        REAL , DIMENSION(: ), INTENT(IN) :: sand
        REAL , DIMENSION(: ), INTENT(IN) :: carbon
        REAL, INTENT(IN) :: pom
        REAL , DIMENSION(: ), INTENT(IN) :: rocks
        REAL:: res_cyml
        res_cyml = (1 - volumetricFractionOrganicMatter(layer, bulkDensity,  &
                carbon, pom) - volumetricFractionRocks(layer, rocks)) * sand(layer+1)  &
                / 100.0 * bulkDensity(layer+1) / ps
    END FUNCTION volumetricFractionSand

    FUNCTION kelvinT(celciusT) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: celciusT
        REAL:: celciusToKelvin
        REAL:: res_cyml
        celciusToKelvin = 273.18
        res_cyml = celciusT + celciusToKelvin
    END FUNCTION kelvinT

    FUNCTION Divide(value1, &
        value2, &
        errVal) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: value1
        REAL, INTENT(IN) :: value2
        REAL, INTENT(IN) :: errVal
        REAL:: res_cyml
        IF(value2 .NE. REAL(0)) THEN
            res_cyml = value1 / value2
        END IF
        res_cyml = errVal
    END FUNCTION Divide

    FUNCTION Sum(values, &
        startIndex, &
        endIndex, &
        MissingValue) RESULT(result)
        IMPLICIT NONE
        REAL , DIMENSION(: ), INTENT(IN) :: values
        INTEGER, INTENT(IN) :: startIndex
        INTEGER, INTENT(IN) :: endIndex
        REAL, INTENT(IN) :: MissingValue
        REAL:: result
        REAL:: value
        INTEGER:: i_cyml0
        INTEGER:: index
        result = 0.0
        index = -1
        DO i_cyml0 = 1, SIZE(values)
            value = values(i_cyml0)
            index = index + 1
            IF(index .GE. startIndex .AND. value .NE. MissingValue) THEN
                result = result + value
            END IF
            IF(index .EQ. endIndex) THEN
                exit
            END IF
        END DO
    END FUNCTION Sum

    FUNCTION volumetricSpecificHeat(name, &
        layer) RESULT(result)
        IMPLICIT NONE
        CHARACTER(65), INTENT(IN) :: name
        INTEGER, INTENT(IN) :: layer
        REAL:: result
        REAL:: specificHeatRocks
        REAL:: specificHeatOM
        REAL:: specificHeatSand
        REAL:: specificHeatSilt
        REAL:: specificHeatClay
        REAL:: specificHeatWater
        REAL:: specificHeatIce
        REAL:: specificHeatAir
        specificHeatRocks = 7.7
        specificHeatOM = 0.25
        specificHeatSand = 7.7
        specificHeatSilt = 2.74
        specificHeatClay = 2.92
        specificHeatWater = 0.57
        specificHeatIce = 2.18
        specificHeatAir = 0.025
        result = 0.0
        IF(name .EQ. 'Rocks') THEN
            result = specificHeatRocks
        ELSE IF ( name .EQ. 'OrganicMatter') THEN
            result = specificHeatOM
        ELSE IF ( name .EQ. 'Sand') THEN
            result = specificHeatSand
        ELSE IF ( name .EQ. 'Silt') THEN
            result = specificHeatSilt
        ELSE IF ( name .EQ. 'Clay') THEN
            result = specificHeatClay
        ELSE IF ( name .EQ. 'Water') THEN
            result = specificHeatWater
        ELSE IF ( name .EQ. 'Ice') THEN
            result = specificHeatIce
        ELSE IF ( name .EQ. 'Air') THEN
            result = specificHeatAir
        END IF
    END FUNCTION volumetricSpecificHeat

    FUNCTION volumetricFractionAir(layer, &
        rocks, &
        bulkDensity, &
        carbon, &
        pom, &
        ps, &
        sand, &
        silt, &
        clay, &
        soilWater) RESULT(res_cyml)
        IMPLICIT NONE
        INTEGER, INTENT(IN) :: layer
        REAL , DIMENSION(: ), INTENT(IN) :: rocks
        REAL , DIMENSION(: ), INTENT(IN) :: bulkDensity
        REAL , DIMENSION(: ), INTENT(IN) :: carbon
        REAL, INTENT(IN) :: pom
        REAL, INTENT(IN) :: ps
        REAL , DIMENSION(: ), INTENT(IN) :: sand
        REAL , DIMENSION(: ), INTENT(IN) :: silt
        REAL , DIMENSION(: ), INTENT(IN) :: clay
        REAL , DIMENSION(: ), INTENT(IN) :: soilWater
        REAL:: res_cyml
        res_cyml = 1.0 - volumetricFractionRocks(layer, rocks) -  &
                volumetricFractionOrganicMatter(layer, bulkDensity, carbon, pom) -  &
                volumetricFractionSand(layer, bulkDensity, ps, sand, carbon, pom,  &
                rocks) - volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon,  &
                pom, rocks) - volumetricFractionClay(layer, bulkDensity, clay, ps,  &
                carbon, pom, rocks) - volumetricFractionWater(layer, soilWater,  &
                bulkDensity, carbon, pom) - volumetricFractionIce(layer)
    END FUNCTION volumetricFractionAir

    FUNCTION airDensity(temperature, &
        AirPressure) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: temperature
        REAL, INTENT(IN) :: AirPressure
        REAL:: MWair
        REAL:: RGAS
        REAL:: HPA2PA
        REAL:: res_cyml
        MWair = 0.02897
        RGAS = 8.3143
        HPA2PA = 100.0
        res_cyml = Divide(MWair * AirPressure * HPA2PA, kelvinT(temperature)  &
                * RGAS, 0.0)
    END FUNCTION airDensity

    FUNCTION longWaveRadn(emissivity, &
        tDegC, &
        stefanBoltzmannConstant) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: emissivity
        REAL, INTENT(IN) :: tDegC
        REAL, INTENT(IN) :: stefanBoltzmannConstant
        REAL:: res_cyml
        res_cyml = stefanBoltzmannConstant * emissivity *  (kelvinT(tDegC) **  &
                4)
    END FUNCTION longWaveRadn

    FUNCTION mapLayer2Node(layerArray, &
        nodeArray, &
        numNodes, &
        nodeDepth, &
        surfaceNode, &
        thickness, &
        MissingValue) RESULT(nodeArray)
        IMPLICIT NONE
        REAL , DIMENSION(: ), INTENT(IN) :: layerArray
        REAL , DIMENSION(: ), INTENT(INOUT) :: nodeArray
        INTEGER, INTENT(IN) :: numNodes
        REAL , DIMENSION(: ), INTENT(IN) :: nodeDepth
        INTEGER, INTENT(IN) :: surfaceNode
        REAL , DIMENSION(: ), INTENT(IN) :: thickness
        REAL, INTENT(IN) :: MissingValue
        INTEGER:: node
        INTEGER:: layer
        REAL:: depthLayerAbove
        REAL:: d1
        REAL:: d2
        REAL:: dSum
        DO node = surfaceNode , numNodes + 1-1, 1
            layer = node - 1
            IF (layer .GE. 1) THEN
                depthLayerAbove=Sum(thickness, 1, layer, MissingValue)
            ELSE
                depthLayerAbove=0.0
            END IF
            d1 = depthLayerAbove - (nodeDepth(node+1) * 1000.0)
            d2 = nodeDepth((node + 1)+1) * 1000.0 - depthLayerAbove
            dSum = d1 + d2
            nodeArray(node+1) = Divide(layerArray(layer+1) * d1, dSum, 0) +  &
                    Divide(layerArray((layer + 1)+1) * d2, dSum, 0)
        END DO
    END FUNCTION mapLayer2Node

    FUNCTION ThermalConductance(name, &
        layer, &
        rocks, &
        bulkDensity, &
        ps, &
        sand, &
        carbon, &
        pom, &
        silt, &
        clay) RESULT(result)
        IMPLICIT NONE
        CHARACTER(65), INTENT(IN) :: name
        INTEGER, INTENT(IN) :: layer
        REAL , DIMENSION(: ), INTENT(IN) :: rocks
        REAL , DIMENSION(: ), INTENT(IN) :: bulkDensity
        REAL, INTENT(IN) :: ps
        REAL , DIMENSION(: ), INTENT(IN) :: sand
        REAL , DIMENSION(: ), INTENT(IN) :: carbon
        REAL, INTENT(IN) :: pom
        REAL , DIMENSION(: ), INTENT(IN) :: silt
        REAL , DIMENSION(: ), INTENT(IN) :: clay
        REAL:: result
        REAL:: thermalConductanceRocks
        REAL:: thermalConductanceOM
        REAL:: thermalConductanceSand
        REAL:: thermalConductanceSilt
        REAL:: thermalConductanceClay
        REAL:: thermalConductanceWater
        REAL:: thermalConductanceIce
        REAL:: thermalConductanceAir
        thermalConductanceRocks = 0.182
        thermalConductanceOM = 2.50
        thermalConductanceSand = 0.182
        thermalConductanceSilt = 2.39
        thermalConductanceClay = 1.39
        thermalConductanceWater = 4.18
        thermalConductanceIce = 1.73
        thermalConductanceAir = 0.0012
        result = 0.0
        IF(name .EQ. 'Rocks') THEN
            result = thermalConductanceRocks
        ELSE IF ( name .EQ. 'OrganicMatter') THEN
            result = thermalConductanceOM
        ELSE IF ( name .EQ. 'Sand') THEN
            result = thermalConductanceSand
        ELSE IF ( name .EQ. 'Silt') THEN
            result = thermalConductanceSilt
        ELSE IF ( name .EQ. 'Clay') THEN
            result = thermalConductanceClay
        ELSE IF ( name .EQ. 'Water') THEN
            result = thermalConductanceWater
        ELSE IF ( name .EQ. 'Ice') THEN
            result = thermalConductanceIce
        ELSE IF ( name .EQ. 'Air') THEN
            result = thermalConductanceAir
        ELSE IF ( name .EQ. 'Minerals') THEN
            result =  (thermalConductanceRocks ** volumetricFractionRocks(layer,  &
                    rocks)) *  (thermalConductanceSand ** volumetricFractionSand(layer,  &
                    bulkDensity, ps, sand, carbon, pom, rocks)) +   &
                    (thermalConductanceSilt ** volumetricFractionSilt(layer, bulkDensity,  &
                    silt, ps, carbon, pom, rocks)) +  (thermalConductanceClay **  &
                    volumetricFractionClay(layer, bulkDensity, clay, ps, carbon, pom,  &
                    rocks))
        END IF
        result = volumetricSpecificHeat(name, layer)
    END FUNCTION ThermalConductance

    FUNCTION shapeFactor(name, &
        layer, &
        soilWater, &
        bulkDensity, &
        carbon, &
        pom, &
        rocks, &
        ps, &
        sand, &
        silt, &
        clay) RESULT(res_cyml)
        IMPLICIT NONE
        CHARACTER(65), INTENT(IN) :: name
        INTEGER, INTENT(IN) :: layer
        REAL , DIMENSION(: ), INTENT(IN) :: soilWater
        REAL , DIMENSION(: ), INTENT(IN) :: bulkDensity
        REAL , DIMENSION(: ), INTENT(IN) :: carbon
        REAL, INTENT(IN) :: pom
        REAL , DIMENSION(: ), INTENT(IN) :: rocks
        REAL, INTENT(IN) :: ps
        REAL , DIMENSION(: ), INTENT(IN) :: sand
        REAL , DIMENSION(: ), INTENT(IN) :: silt
        REAL , DIMENSION(: ), INTENT(IN) :: clay
        REAL:: shapeFactorRocks
        REAL:: shapeFactorOM
        REAL:: shapeFactorSand
        REAL:: shapeFactorSilt
        REAL:: shapeFactorClay
        REAL:: shapeFactorWater
        REAL:: result
        shapeFactorRocks = 0.182
        shapeFactorOM = 0.5
        shapeFactorSand = 0.182
        shapeFactorSilt = 0.125
        shapeFactorClay = 0.007755
        shapeFactorWater = 1.0
        result = 0.0
        IF(name .EQ. 'Rocks') THEN
            result = shapeFactorRocks
        ELSE IF ( name .EQ. 'OrganicMatter') THEN
            result = shapeFactorOM
        ELSE IF ( name .EQ. 'Sand') THEN
            result = shapeFactorSand
        ELSE IF ( name .EQ. 'Silt') THEN
            result = shapeFactorSilt
        ELSE IF ( name .EQ. 'Clay') THEN
            result = shapeFactorClay
        ELSE IF ( name .EQ. 'Water') THEN
            result = shapeFactorWater
        ELSE IF ( name .EQ. 'Ice') THEN
            result = 0.333 - (0.333 * volumetricFractionIce(layer) /  &
                    (volumetricFractionWater(layer, soilWater, bulkDensity, carbon, pom)  &
                    + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks,  &
                    bulkDensity, carbon, pom, ps, sand, silt, clay, soilWater)))
            res_cyml = result
        ELSE IF ( name .EQ. 'Air') THEN
            result = 0.333 - (0.333 * volumetricFractionAir(layer, rocks,  &
                    bulkDensity, carbon, pom, ps, sand, silt, clay, soilWater) /  &
                    (volumetricFractionWater(layer, soilWater, bulkDensity, carbon, pom)  &
                    + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks,  &
                    bulkDensity, carbon, pom, ps, sand, silt, clay, soilWater)))
            res_cyml = result
        ELSE IF ( name .EQ. 'Minerals') THEN
            result = shapeFactorRocks * volumetricFractionRocks(layer, rocks) +  &
                    (shapeFactorSand * volumetricFractionSand(layer, bulkDensity, ps,  &
                    sand, carbon, pom, rocks)) + (shapeFactorSilt *  &
                    volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom,  &
                    rocks)) + (shapeFactorClay * volumetricFractionClay(layer,  &
                    bulkDensity, clay, ps, carbon, pom, rocks))
        END IF
        result = volumetricSpecificHeat(name, layer)
        res_cyml = result
    END FUNCTION shapeFactor

    SUBROUTINE doUpdate(numInterationsPerDay, &
        maxSoilTemp, &
        minSoilTemp, &
        thermalConductivity, &
        soilTemp, &
        timeOfDaySecs, &
        numNodes, &
        boundaryLayerConductance, &
        aveSoilTemp, &
        airNode, &
        newTemperature, &
        surfaceNode, &
        internalTimeStep)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        INTEGER, INTENT(IN) :: numInterationsPerDay
        REAL , DIMENSION(: ), INTENT(INOUT) :: maxSoilTemp
        REAL , DIMENSION(: ), INTENT(INOUT) :: minSoilTemp
        REAL , DIMENSION(: ), INTENT(IN) :: thermalConductivity
        REAL , DIMENSION(: ), INTENT(INOUT) :: soilTemp
        REAL, INTENT(IN) :: timeOfDaySecs
        INTEGER, INTENT(IN) :: numNodes
        REAL, INTENT(INOUT) :: boundaryLayerConductance
        REAL , DIMENSION(: ), INTENT(INOUT) :: aveSoilTemp
        REAL, INTENT(IN) :: airNode
        REAL , DIMENSION(: ), INTENT(IN) :: newTemperature
        INTEGER, INTENT(IN) :: surfaceNode
        REAL, INTENT(IN) :: internalTimeStep
        INTEGER:: node
        soilTemp(0:0 + SIZE(newTemperature)) = newTemperature
        IF(timeOfDaySecs .LT. (internalTimeStep * 1.2)) THEN
            DO node = surfaceNode , numNodes + 1-1, 1
                minSoilTemp(node+1) = soilTemp(node+1)
                maxSoilTemp(node+1) = soilTemp(node+1)
            END DO
        END IF
        DO node = surfaceNode , numNodes + 1-1, 1
            IF(soilTemp(node+1) .LT. minSoilTemp(node+1)) THEN
                minSoilTemp(node+1) = soilTemp(node+1)
            ELSE IF ( soilTemp(node+1) .GT. maxSoilTemp(node+1)) THEN
                maxSoilTemp(node+1) = soilTemp(node+1)
            END IF
            aveSoilTemp(node+1) = aveSoilTemp(node+1) + Divide(soilTemp(node+1),  &
                    numInterationsPerDay, 0)
        END DO
        boundaryLayerConductance = boundaryLayerConductance +  &
                Divide(thermalConductivity(airNode+1), numInterationsPerDay, 0)
    END SUBROUTINE doUpdate

    SUBROUTINE doThomas(newTemps, &
        netRadiationSource, &
        thermalConductance, &
        waterBalance_Eos, &
        waterBalance_Es, &
        thermalConductivity, &
        soilTemp, &
        numNodes, &
        internalTimeStep, &
        heatStorage, &
        latentHeatOfVapourisation, &
        nodeDepth, &
        nu, &
        volSpecHeatSoil, &
        airNode, &
        netRadiation, &
        surfaceNode, &
        timestep)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL , DIMENSION(: ), INTENT(INOUT) :: newTemps
        CHARACTER(65), INTENT(IN) :: netRadiationSource
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermalConductance
        REAL, INTENT(IN) :: waterBalance_Eos
        REAL, INTENT(IN) :: waterBalance_Es
        REAL , DIMENSION(: ), INTENT(IN) :: thermalConductivity
        REAL , DIMENSION(: ), INTENT(IN) :: soilTemp
        INTEGER, INTENT(IN) :: numNodes
        REAL, INTENT(IN) :: internalTimeStep
        REAL , DIMENSION(: ), INTENT(INOUT) :: heatStorage
        REAL, INTENT(IN) :: latentHeatOfVapourisation
        REAL , DIMENSION(: ), INTENT(IN) :: nodeDepth
        REAL, INTENT(IN) :: nu
        REAL , DIMENSION(: ), INTENT(IN) :: volSpecHeatSoil
        REAL, INTENT(IN) :: airNode
        REAL, INTENT(IN) :: netRadiation
        INTEGER, INTENT(IN) :: surfaceNode
        REAL, INTENT(IN) :: timestep
        INTEGER:: node
        REAL , DIMENSION(numNodes + 1 + 1 ):: a
        REAL , DIMENSION(numNodes + 1 ):: b
        REAL , DIMENSION(numNodes + 1 ):: c
        REAL , DIMENSION(numNodes + 1 ):: d
        REAL:: volumeOfSoilAtNode
        REAL:: elementLength
        REAL:: g
        REAL:: sensibleHeatFlux
        REAL:: radnNet
        REAL:: latentHeatFlux
        REAL:: soilSurfaceHeatFlux
        thermalConductance(airNode+1) = thermalConductivity(airNode+1)
        DO node = surfaceNode , numNodes + 1-1, 1
            volumeOfSoilAtNode = 0.5 * (nodeDepth(node + 1+1) - nodeDepth(node -  &
                    1+1))
            heatStorage(node+1) = Divide(volSpecHeatSoil(node+1) *  &
                    volumeOfSoilAtNode, internalTimeStep, 0)
            elementLength = nodeDepth(node + 1+1) - nodeDepth(node+1)
            thermalConductance(node+1) = Divide(thermalConductivity(node+1),  &
                    elementLength, 0)
        END DO
        g = 1 - nu
        DO node = surfaceNode , numNodes + 1-1, 1
            c(node+1) = (-nu) * thermalConductance(node+1)
            a(node + 1+1) = c(node+1)
            b(node+1) = nu * (thermalConductance(node+1) +  &
                    thermalConductance(node - 1+1)) + heatStorage(node+1)
            d(node+1) = g * thermalConductance((node - 1)+1) * soilTemp((node -  &
                    1)+1) + ((heatStorage(node+1) - (g * (thermalConductance(node+1) +  &
                    thermalConductance(node - 1+1)))) * soilTemp(node+1)) + (g *  &
                    thermalConductance(node+1) * soilTemp((node + 1)+1))
        END DO
        a(surfaceNode+1) = 0.0
        sensibleHeatFlux = nu * thermalConductance(airNode+1) *  &
                newTemps(airNode+1)
        radnNet = 0.0
        IF(netRadiationSource .EQ. 'calc') THEN
            radnNet = Divide(netRadiation * 1000000.0, internalTimeStep, 0)
        ELSE IF ( netRadiationSource .EQ. 'eos') THEN
            radnNet = Divide(waterBalance_Eos * latentHeatOfVapourisation,  &
                    timestep, 0)
        END IF
        latentHeatFlux = Divide(waterBalance_Es * latentHeatOfVapourisation,  &
                timestep, 0)
        soilSurfaceHeatFlux = sensibleHeatFlux + radnNet - latentHeatFlux
        d(surfaceNode+1) = d(surfaceNode+1) + soilSurfaceHeatFlux
        d(numNodes+1) = d(numNodes+1) + (nu * thermalConductance(numNodes+1)  &
                * newTemps((numNodes + 1)+1))
        DO node = surfaceNode , numNodes - 1 + 1-1, 1
            c(node+1) = Divide(c(node+1), b(node+1), 0)
            d(node+1) = Divide(d(node+1), b(node+1), 0)
            b(node + 1+1) = b(node + 1+1) - (a((node + 1)+1) * c(node+1))
            d(node + 1+1) = d(node + 1+1) - (a((node + 1)+1) * d(node+1))
        END DO
        newTemps(numNodes+1) = Divide(d(numNodes+1), b(numNodes+1), 0)
        DO node = numNodes - 1 , surfaceNode - 1+1, -1
            newTemps(node+1) = d(node+1) - (c(node+1) * newTemps((node + 1)+1))
        END DO
    END SUBROUTINE doThomas

    SUBROUTINE getBoundaryLayerConductance(TNew_zb, &
        stefanBoltzmannConstant, &
        airTemperature, &
        waterBalance_Eos, &
        weather_AirPressure, &
        instrumentHeight, &
        waterBalance_Eo, &
        weather_Wind, &
        canopyHeight, &
        surfaceNode, &
        boundaryLayerCond)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL , DIMENSION(: ), INTENT(INOUT) :: TNew_zb
        REAL, INTENT(IN) :: stefanBoltzmannConstant
        REAL, INTENT(IN) :: airTemperature
        REAL, INTENT(IN) :: waterBalance_Eos
        REAL, INTENT(IN) :: weather_AirPressure
        REAL, INTENT(IN) :: instrumentHeight
        REAL, INTENT(IN) :: waterBalance_Eo
        REAL, INTENT(IN) :: weather_Wind
        REAL, INTENT(IN) :: canopyHeight
        INTEGER, INTENT(IN) :: surfaceNode
        INTEGER:: iteration
        REAL:: vonKarmanConstant
        REAL:: gravitationalConstant
        REAL:: specificHeatOfAir
        REAL:: surfaceEmissivity
        REAL:: SpecificHeatAir
        REAL:: roughnessFactorMomentum
        REAL:: roughnessFactorHeat
        REAL:: d
        REAL:: surfaceTemperature
        REAL:: diffusePenetrationConstant
        REAL:: radiativeConductance
        REAL:: frictionVelocity
        REAL, INTENT(OUT) :: boundaryLayerCond
        REAL:: stabilityParammeter
        REAL:: stabilityCorrectionMomentum
        REAL:: stabilityCorrectionHeat
        REAL:: heatFluxDensity
        vonKarmanConstant = 0.41
        gravitationalConstant = 9.8
        specificHeatOfAir = 1010.0
        surfaceEmissivity = 0.98
        SpecificHeatAir = specificHeatOfAir * airDensity(airTemperature,  &
                weather_AirPressure)
        roughnessFactorMomentum = 0.13 * canopyHeight
        roughnessFactorHeat = 0.2 * roughnessFactorMomentum
        d = 0.77 * canopyHeight
        surfaceTemperature = TNew_zb(surfaceNode+1)
        diffusePenetrationConstant = MAX(0.1, waterBalance_Eos) / MAX(0.1,  &
                waterBalance_Eo)
        radiativeConductance = 4.0 * stefanBoltzmannConstant *  &
                surfaceEmissivity * diffusePenetrationConstant *   &
                (kelvinT(airTemperature) ** 3)
        frictionVelocity = 0.0
        boundaryLayerCond = 0.0
        stabilityParammeter = 0.0
        stabilityCorrectionMomentum = 0.0
        stabilityCorrectionHeat = 0.0
        heatFluxDensity = 0.0
        DO iteration = 1 , 3 + 1-1, 1
            frictionVelocity = Divide(weather_Wind * vonKarmanConstant,  &
                    LOG(Divide(instrumentHeight - d + roughnessFactorMomentum,  &
                    roughnessFactorMomentum, 0)) + stabilityCorrectionMomentum, 0)
            boundaryLayerCond = Divide(SpecificHeatAir * vonKarmanConstant *  &
                    frictionVelocity, LOG(Divide(instrumentHeight - d +  &
                    roughnessFactorHeat, roughnessFactorHeat, 0)) +  &
                    stabilityCorrectionHeat, 0)
            boundaryLayerCond = boundaryLayerCond + radiativeConductance
            heatFluxDensity = boundaryLayerCond * (surfaceTemperature -  &
                    airTemperature)
            stabilityParammeter = Divide((-vonKarmanConstant) * instrumentHeight  &
                    * gravitationalConstant * heatFluxDensity, SpecificHeatAir *  &
                    kelvinT(airTemperature) *  (frictionVelocity ** 3.0), 0)
            IF(stabilityParammeter .GT. 0.0) THEN
                stabilityCorrectionHeat = 4.7 * stabilityParammeter
                stabilityCorrectionMomentum = stabilityCorrectionHeat
            ELSE
                stabilityCorrectionHeat = (-2.0) * LOG((1.0 + SQRT(1.0 - (16.0 *  &
                        stabilityParammeter))) / 2.0)
                stabilityCorrectionMomentum = 0.6 * stabilityCorrectionHeat
            END IF
        END DO
    END SUBROUTINE getBoundaryLayerConductance

    FUNCTION interpolateNetRadiation(solarRadn, &
        cloudFr, &
        cva, &
        soilTemp, &
        airTemperature, &
        waterBalance_Eo, &
        waterBalance_Eos, &
        waterBalance_Salb, &
        surfaceNode, &
        internalTimeStep, &
        stefanBoltzmannConstant) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: solarRadn
        REAL, INTENT(IN) :: cloudFr
        REAL, INTENT(IN) :: cva
        REAL , DIMENSION(: ), INTENT(IN) :: soilTemp
        REAL, INTENT(IN) :: airTemperature
        REAL, INTENT(IN) :: waterBalance_Eo
        REAL, INTENT(IN) :: waterBalance_Eos
        REAL, INTENT(IN) :: waterBalance_Salb
        INTEGER, INTENT(IN) :: surfaceNode
        REAL, INTENT(IN) :: internalTimeStep
        REAL, INTENT(IN) :: stefanBoltzmannConstant
        REAL:: surfaceEmissivity
        REAL:: w2MJ
        REAL:: emissivityAtmos
        REAL:: PenetrationConstant
        REAL:: lwRinSoil
        REAL:: lwRoutSoil
        REAL:: lwRnetSoil
        REAL:: swRin
        REAL:: swRout
        REAL:: swRnetSoil
        REAL:: res_cyml
        surfaceEmissivity = 0.96
        w2MJ = internalTimeStep / 1000000.0
        emissivityAtmos = (1 - (0.84 * cloudFr)) * 0.58 *  (cva ** (1.0 /  &
                7.0)) + (0.84 * cloudFr)
        PenetrationConstant = Divide(MAX(0.1, waterBalance_Eos), MAX(0.1,  &
                waterBalance_Eo), 0)
        lwRinSoil = longWaveRadn(emissivityAtmos, airTemperature,  &
                stefanBoltzmannConstant) * PenetrationConstant * w2MJ
        lwRoutSoil = longWaveRadn(surfaceEmissivity, soilTemp(surfaceNode+1),  &
                stefanBoltzmannConstant) * PenetrationConstant * w2MJ
        lwRnetSoil = lwRinSoil - lwRoutSoil
        swRin = solarRadn
        swRout = waterBalance_Salb * solarRadn
        swRnetSoil = (swRin - swRout) * PenetrationConstant
        res_cyml = swRnetSoil + lwRnetSoil
    END FUNCTION interpolateNetRadiation

    FUNCTION interpolateTemperature(timeHours, &
        defaultTimeOfMaximumTemperature, &
        weather_MeanT, &
        weather_MaxT, &
        maxTempYesterday, &
        minTempYesterday, &
        weather_MinT) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: timeHours
        REAL, INTENT(IN) :: defaultTimeOfMaximumTemperature
        REAL, INTENT(IN) :: weather_MeanT
        REAL, INTENT(IN) :: weather_MaxT
        REAL, INTENT(IN) :: maxTempYesterday
        REAL, INTENT(IN) :: minTempYesterday
        REAL, INTENT(IN) :: weather_MinT
        REAL:: time
        REAL:: maxT_time
        REAL:: minT_time
        REAL:: midnightT
        REAL:: tScale
        REAL:: currentTemperature
        time = timeHours / 24.0
        maxT_time = defaultTimeOfMaximumTemperature / 24.0
        minT_time = maxT_time - 0.5
        IF(time .LT. minT_time) THEN
            midnightT = SIN((0.0 + 0.25 - maxT_time) * 2.0 * 3.14159265) *  &
                    (maxTempYesterday - minTempYesterday) / 2.0 + ((maxTempYesterday +  &
                    minTempYesterday) / 2.0)
            tScale = (minT_time - time) / minT_time
            IF(tScale .GT. 1.0) THEN
                tScale = 1.0
            ELSE IF ( tScale .LT. REAL(0)) THEN
                tScale = REAL(0)
            END IF
            currentTemperature = weather_MinT + (tScale * (midnightT -  &
                    weather_MinT))
            res_cyml = currentTemperature
        ELSE
            currentTemperature = SIN((time + 0.25 - maxT_time) * 2.0 *  &
                    3.14159265) * (weather_MaxT - weather_MinT) / 2.0 + weather_MeanT
            res_cyml = currentTemperature
        END IF
    END FUNCTION interpolateTemperature

    FUNCTION doThermalConductivity(soilConstituentNames, &
        soilWater, &
        thermalConductivity, &
        numNodes, &
        bulkDensity, &
        carbon, &
        pom, &
        rocks, &
        ps, &
        sand, &
        silt, &
        clay, &
        nodeDepth, &
        surfaceNode, &
        thickness, &
        MissingValue) RESULT(thermalConductivity)
        IMPLICIT NONE
        CHARACTER(65) , DIMENSION(: ), INTENT(IN) :: soilConstituentNames
        REAL , DIMENSION(: ), INTENT(IN) :: soilWater
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermalConductivity
        INTEGER, INTENT(IN) :: numNodes
        REAL , DIMENSION(: ), INTENT(IN) :: bulkDensity
        REAL , DIMENSION(: ), INTENT(IN) :: carbon
        REAL, INTENT(IN) :: pom
        REAL , DIMENSION(: ), INTENT(IN) :: rocks
        REAL, INTENT(IN) :: ps
        REAL , DIMENSION(: ), INTENT(IN) :: sand
        REAL , DIMENSION(: ), INTENT(IN) :: silt
        REAL , DIMENSION(: ), INTENT(IN) :: clay
        REAL , DIMENSION(: ), INTENT(IN) :: nodeDepth
        INTEGER, INTENT(IN) :: surfaceNode
        REAL , DIMENSION(: ), INTENT(IN) :: thickness
        REAL, INTENT(IN) :: MissingValue
        INTEGER:: node
        CHARACTER(65):: constituentName
        INTEGER:: i_cyml0
        REAL , DIMENSION(numNodes + 1 ):: thermCondLayers
        REAL:: numerator
        REAL:: denominator
        REAL:: shapeFactorConstituent
        REAL:: thermalConductanceConstituent
        REAL:: thermalConductanceWater
        REAL:: k
        DO node = 1 , numNodes + 1-1, 1
            numerator = 0.0
            denominator = 0.0
            DO i_cyml0 = 1, SIZE(soilConstituentNames)
                constituentName = soilConstituentNames(i_cyml0)
                shapeFactorConstituent = shapeFactor(constituentName, node,  &
                        soilWater, bulkDensity, carbon, pom, rocks, ps, sand, silt, clay)
                thermalConductanceConstituent = ThermalConductance(constituentName,  &
                        node, rocks, bulkDensity, ps, sand, carbon, pom, silt, clay)
                thermalConductanceWater = ThermalConductance('Water', node, rocks,  &
                        bulkDensity, ps, sand, carbon, pom, silt, clay)
                k = 2.0 / 3.0 *  ((1 + (shapeFactorConstituent *  &
                        (thermalConductanceConstituent / thermalConductanceWater - 1.0))) **  &
                        (-1)) + (1.0 / 3.0 *  ((1 + (shapeFactorConstituent *  &
                        (thermalConductanceConstituent / thermalConductanceWater - 1.0) * (1  &
                        - (2 * shapeFactorConstituent)))) ** (-1)))
                numerator = numerator + (thermalConductanceConstituent *  &
                        soilWater(node+1) * k)
                denominator = denominator + (soilWater(node+1) * k)
            END DO
            thermCondLayers(node+1) = numerator / denominator
        END DO
        thermalConductivity = mapLayer2Node(thermCondLayers,  &
                thermalConductivity, numNodes, nodeDepth, surfaceNode, thickness,  &
                MissingValue)
    END FUNCTION doThermalConductivity

    FUNCTION doVolumetricSpecificHeat(soilConstituentNames, &
        soilWater, &
        volSpecHeatSoil, &
        numNodes, &
        nodeDepth, &
        surfaceNode, &
        thickness, &
        MissingValue) RESULT(volSpecHeatSoil)
        IMPLICIT NONE
        CHARACTER(65) , DIMENSION(: ), INTENT(IN) :: soilConstituentNames
        REAL , DIMENSION(: ), INTENT(IN) :: soilWater
        REAL , DIMENSION(: ), INTENT(INOUT) :: volSpecHeatSoil
        INTEGER, INTENT(IN) :: numNodes
        REAL , DIMENSION(: ), INTENT(IN) :: nodeDepth
        INTEGER, INTENT(IN) :: surfaceNode
        REAL , DIMENSION(: ), INTENT(IN) :: thickness
        REAL, INTENT(IN) :: MissingValue
        INTEGER:: node
        CHARACTER(65):: constituentName
        INTEGER:: i_cyml0
        REAL , DIMENSION(numNodes + 1 ):: volspecHeatSoil_
        DO node = 1 , numNodes + 1-1, 1
            volspecHeatSoil_(node+1) = REAL(0)
            DO i_cyml0 = 1, SIZE(soilConstituentNames)
                constituentName = soilConstituentNames(i_cyml0)
                IF(ALL((/'Minerals'/) .NE. constituentName)) THEN
                    volspecHeatSoil_(node+1) = volspecHeatSoil_(node+1) +  &
                            (volumetricSpecificHeat(constituentName, node) * 1000000.0 *  &
                            soilWater(node+1))
                END IF
            END DO
        END DO
        volSpecHeatSoil = mapLayer2Node(volspecHeatSoil_, volSpecHeatSoil,  &
                numNodes, nodeDepth, surfaceNode, thickness, MissingValue)
    END FUNCTION doVolumetricSpecificHeat

    FUNCTION Zero(arr) RESULT(arr)
        IMPLICIT NONE
        REAL , DIMENSION(: ), INTENT(INOUT) :: arr
        INTEGER:: i
        IF(ALLOCATE(arr)) THEN
            DO i = 0 , SIZE(arr)-1, 1
                arr(i+1) = REAL(0)
            END DO
        END IF
    END FUNCTION Zero

    SUBROUTINE doNetRadiation(solarRadn, &
        cloudFr, &
        cva, &
        ITERATIONSperDAY, &
        clock_Today_DayOfYear, &
        weather_Latitude, &
        weather_Radn, &
        weather_MinT)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL , DIMENSION(: ), INTENT(INOUT) :: solarRadn
        REAL, INTENT(INOUT) :: cloudFr
        REAL, INTENT(INOUT) :: cva
        INTEGER, INTENT(IN) :: ITERATIONSperDAY
        INTEGER, INTENT(IN) :: clock_Today_DayOfYear
        REAL, INTENT(IN) :: weather_Latitude
        REAL, INTENT(IN) :: weather_Radn
        REAL, INTENT(IN) :: weather_MinT
        INTEGER:: timestepNumber
        REAL:: TSTEPS2RAD
        REAL:: solarConstant
        REAL:: solarDeclination
        REAL:: cD
        REAL , DIMENSION(ITERATIONSperDAY + 1 ):: m1
        REAL:: m1Tot
        REAL:: psr
        REAL:: fr
        TSTEPS2RAD = Divide(2.0 * 3.14159265, REAL(ITERATIONSperDAY), 0)
        solarConstant = 1360.0
        solarDeclination = 0.3985 * SIN((4.869 + (clock_Today_DayOfYear * 2.0  &
                * 3.14159265 / 365.25) + (0.03345 * SIN((6.224 +  &
                (clock_Today_DayOfYear * 2.0 * 3.14159265 / 365.25))))))
        cD = SQRT(1.0 - (solarDeclination * solarDeclination))
        m1Tot = 0.0
        DO timestepNumber = 1 , ITERATIONSperDAY + 1-1, 1
            m1(timestepNumber+1) = (solarDeclination * SIN(weather_Latitude *  &
                    3.14159265 / 180.0) + (cD * COS(weather_Latitude * 3.14159265 /  &
                    180.0) * COS(TSTEPS2RAD * (timestepNumber - (ITERATIONSperDAY /  &
                    2.0))))) * 24.0 / ITERATIONSperDAY
            IF(m1(timestepNumber+1) .GT. 0.0) THEN
                m1Tot = m1Tot + m1(timestepNumber+1)
            ELSE
                m1(timestepNumber+1) = 0.0
            END IF
        END DO
        psr = m1Tot * solarConstant * 3600.0 / 1000000.0
        fr = Divide(MAX(weather_Radn, 0.1), psr, 0)
        cloudFr = 2.33 - (3.33 * fr)
        cloudFr = MIN(MAX(cloudFr, 0.0), 1.0)
        DO timestepNumber = 1 , ITERATIONSperDAY + 1-1, 1
            solarRadn(timestepNumber+1) = MAX(weather_Radn, 0.1) *  &
                    Divide(m1(timestepNumber+1), m1Tot, 0)
        END DO
        cva = EXP((31.3716 - (6014.79 / kelvinT(weather_MinT)) - (0.00792495  &
                * kelvinT(weather_MinT)))) / kelvinT(weather_MinT)
    END SUBROUTINE doNetRadiation

    SUBROUTINE doProcess(maxSoilTemp, &
        minSoilTemp, &
        weather_MaxT, &
        numIterationsForBoundaryLayerConductance, &
        maxTempYesterday, &
        thermalConductivity, &
        timeOfDaySecs, &
        soilTemp, &
        weather_MeanT, &
        morningSoilTemp, &
        newTemperature, &
        boundaryLayerConductance, &
        constantBoundaryLayerConductance, &
        airTemperature, &
        timestep, &
        weather_MinT, &
        airNode, &
        netRadiation, &
        aveSoilTemp, &
        minTempYesterday, &
        internalTimeStep, &
        boundarLayerConductanceSource, &
        clock_Today_DayOfYear, &
        weather_Latitude, &
        weather_Radn, &
        soilConstituentNames, &
        soilWater, &
        volSpecHeatSoil, &
        numNodes, &
        nodeDepth, &
        surfaceNode, &
        thickness, &
        MissingValue, &
        bulkDensity, &
        carbon, &
        pom, &
        rocks, &
        ps, &
        sand, &
        silt, &
        clay, &
        defaultTimeOfMaximumTemperature, &
        waterBalance_Eo, &
        waterBalance_Eos, &
        waterBalance_Salb, &
        stefanBoltzmannConstant, &
        weather_AirPressure, &
        instrumentHeight, &
        weather_Wind, &
        canopyHeight, &
        netRadiationSource, &
        thermalConductance, &
        waterBalance_Es, &
        heatStorage, &
        latentHeatOfVapourisation, &
        nu)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL , DIMENSION(: ), INTENT(INOUT) :: maxSoilTemp
        REAL , DIMENSION(: ), INTENT(INOUT) :: minSoilTemp
        REAL, INTENT(IN) :: weather_MaxT
        INTEGER, INTENT(IN) :: numIterationsForBoundaryLayerConductance
        REAL, INTENT(INOUT) :: maxTempYesterday
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermalConductivity
        REAL, INTENT(INOUT) :: timeOfDaySecs
        REAL , DIMENSION(: ), INTENT(INOUT) :: soilTemp
        REAL, INTENT(IN) :: weather_MeanT
        REAL , DIMENSION(: ), INTENT(INOUT) :: morningSoilTemp
        REAL , DIMENSION(: ), INTENT(INOUT) :: newTemperature
        REAL, INTENT(INOUT) :: boundaryLayerConductance
        REAL, INTENT(IN) :: constantBoundaryLayerConductance
        REAL, INTENT(INOUT) :: airTemperature
        REAL, INTENT(IN) :: timestep
        REAL, INTENT(IN) :: weather_MinT
        REAL, INTENT(IN) :: airNode
        REAL, INTENT(INOUT) :: netRadiation
        REAL , DIMENSION(: ), INTENT(INOUT) :: aveSoilTemp
        REAL, INTENT(INOUT) :: minTempYesterday
        REAL, INTENT(INOUT) :: internalTimeStep
        CHARACTER(65), INTENT(IN) :: boundarLayerConductanceSource
        INTEGER, INTENT(IN) :: clock_Today_DayOfYear
        REAL, INTENT(IN) :: weather_Latitude
        REAL, INTENT(IN) :: weather_Radn
        CHARACTER(65) , DIMENSION(: ), INTENT(IN) :: soilConstituentNames
        REAL , DIMENSION(: ), INTENT(IN) :: soilWater
        REAL , DIMENSION(: ), INTENT(INOUT) :: volSpecHeatSoil
        INTEGER, INTENT(IN) :: numNodes
        REAL , DIMENSION(: ), INTENT(IN) :: nodeDepth
        INTEGER, INTENT(IN) :: surfaceNode
        REAL , DIMENSION(: ), INTENT(IN) :: thickness
        REAL, INTENT(IN) :: MissingValue
        REAL , DIMENSION(: ), INTENT(IN) :: bulkDensity
        REAL , DIMENSION(: ), INTENT(IN) :: carbon
        REAL, INTENT(IN) :: pom
        REAL , DIMENSION(: ), INTENT(IN) :: rocks
        REAL, INTENT(IN) :: ps
        REAL , DIMENSION(: ), INTENT(IN) :: sand
        REAL , DIMENSION(: ), INTENT(IN) :: silt
        REAL , DIMENSION(: ), INTENT(IN) :: clay
        REAL, INTENT(IN) :: defaultTimeOfMaximumTemperature
        REAL, INTENT(IN) :: waterBalance_Eo
        REAL, INTENT(IN) :: waterBalance_Eos
        REAL, INTENT(IN) :: waterBalance_Salb
        REAL, INTENT(IN) :: stefanBoltzmannConstant
        REAL, INTENT(IN) :: weather_AirPressure
        REAL, INTENT(IN) :: instrumentHeight
        REAL, INTENT(IN) :: weather_Wind
        REAL, INTENT(IN) :: canopyHeight
        CHARACTER(65), INTENT(IN) :: netRadiationSource
        REAL , DIMENSION(: ), INTENT(INOUT) :: thermalConductance
        REAL, INTENT(IN) :: waterBalance_Es
        REAL , DIMENSION(: ), INTENT(INOUT) :: heatStorage
        REAL, INTENT(IN) :: latentHeatOfVapourisation
        REAL, INTENT(IN) :: nu
        INTEGER:: timeStepIteration
        INTEGER:: iteration
        INTEGER:: interactionsPerDay
        REAL:: cva
        REAL:: cloudFr
        REAL , DIMENSION(49 ):: solarRadn
        interactionsPerDay = 48
        cva = 0.0
        cloudFr = 0.0
        call doNetRadiation(solarRadn, cloudFr, cva, interactionsPerDay,  &
                clock_Today_DayOfYear, weather_Latitude, weather_Radn, weather_MinT)
        minSoilTemp = Zero(minSoilTemp)
        maxSoilTemp = Zero(maxSoilTemp)
        aveSoilTemp = Zero(aveSoilTemp)
        boundaryLayerConductance = 0.0
        internalTimeStep = Round(timestep / interactionsPerDay)
        volSpecHeatSoil = doVolumetricSpecificHeat(soilConstituentNames,  &
                soilWater, volSpecHeatSoil, numNodes, nodeDepth, surfaceNode,  &
                thickness, MissingValue)
        thermalConductivity = doThermalConductivity(soilConstituentNames,  &
                soilWater, thermalConductivity, numNodes, bulkDensity, carbon, pom,  &
                rocks, ps, sand, silt, clay, nodeDepth, surfaceNode, thickness,  &
                MissingValue)
        DO timeStepIteration = 1 , interactionsPerDay + 1-1, 1
            timeOfDaySecs = internalTimeStep * REAL(timeStepIteration)
            IF(timestep .LT. (24.0 * 60.0 * 60.0)) THEN
                airTemperature = weather_MeanT
            ELSE
                airTemperature = interpolateTemperature(timeOfDaySecs / 3600.0,  &
                        defaultTimeOfMaximumTemperature, weather_MeanT, weather_MaxT,  &
                        maxTempYesterday, minTempYesterday, weather_MinT)
            END IF
            newTemperature(airNode+1) = airTemperature
            netRadiation =  &
                    interpolateNetRadiation(solarRadn(timeStepIteration+1), cloudFr, cva,  &
                    soilTemp, airTemperature, waterBalance_Eo, waterBalance_Eos,  &
                    waterBalance_Salb, surfaceNode, internalTimeStep,  &
                    stefanBoltzmannConstant)
            IF(boundarLayerConductanceSource .EQ. 'constant') THEN
                thermalConductivity(airNode+1) = constantBoundaryLayerConductance
            ELSE IF ( boundarLayerConductanceSource .EQ. 'calc') THEN
                call getBoundaryLayerConductance(newTemperature,  &
                        stefanBoltzmannConstant, airTemperature, waterBalance_Eos,  &
                        weather_AirPressure, instrumentHeight, waterBalance_Eo, weather_Wind,  &
                        canopyHeight, surfaceNode,thermalConductivity(airNode+1))
                DO iteration = 1 , numIterationsForBoundaryLayerConductance + 1-1, 1
                    call doThomas(newTemperature, netRadiationSource, thermalConductance,  &
                            waterBalance_Eos, waterBalance_Es, thermalConductivity, soilTemp,  &
                            numNodes, internalTimeStep, heatStorage, latentHeatOfVapourisation,  &
                            nodeDepth, nu, volSpecHeatSoil, airNode, netRadiation, surfaceNode,  &
                            timestep)
                    call getBoundaryLayerConductance(newTemperature,  &
                            stefanBoltzmannConstant, airTemperature, waterBalance_Eos,  &
                            weather_AirPressure, instrumentHeight, waterBalance_Eo, weather_Wind,  &
                            canopyHeight, surfaceNode,thermalConductivity(airNode+1))
                END DO
            END IF
            call doThomas(newTemperature, netRadiationSource, thermalConductance,  &
                    waterBalance_Eos, waterBalance_Es, thermalConductivity, soilTemp,  &
                    numNodes, internalTimeStep, heatStorage, latentHeatOfVapourisation,  &
                    nodeDepth, nu, volSpecHeatSoil, airNode, netRadiation, surfaceNode,  &
                    timestep)
            call doUpdate(interactionsPerDay, maxSoilTemp, minSoilTemp,  &
                    thermalConductivity, soilTemp, timeOfDaySecs, numNodes,  &
                    boundaryLayerConductance, aveSoilTemp, airNode, newTemperature,  &
                    surfaceNode, internalTimeStep)
            IF(ABS(timeOfDaySecs - (5.0 * 3600.0)) .LE. (MIN(timeOfDaySecs, 5.0 *  &
                    3600.0) * 0.0001)) THEN
                morningSoilTemp(0:0 + SIZE(soilTemp)) = soilTemp
            END IF
        END DO
        minTempYesterday = weather_MinT
        maxTempYesterday = weather_MaxT
    END SUBROUTINE doProcess

    FUNCTION ToCumThickness(Thickness) RESULT(CumThickness)
        IMPLICIT NONE
        REAL , DIMENSION(: ), INTENT(IN) :: Thickness
        REAL , DIMENSION(: ), ALLOCATABLE :: CumThickness
        INTEGER:: Layer
        IF(SIZE(Thickness) .GT. 0) THEN
            CumThickness(1) = Thickness(1)
            DO Layer = 1 , SIZE(Thickness)-1, 1
                CumThickness(Layer+1) = Thickness(Layer+1) + CumThickness(Layer - 1+1)
            END DO
        END IF
    END FUNCTION ToCumThickness

    FUNCTION calcSoilTemperature(soilTempIO, &
        weather_Latitude, &
        weather_Amp, &
        numNodes, &
        clock_Today_DayOfYear, &
        weather_Tav, &
        surfaceNode, &
        thickness) RESULT(soilTempIO)
        IMPLICIT NONE
        REAL , DIMENSION(: ), INTENT(INOUT) :: soilTempIO
        REAL, INTENT(IN) :: weather_Latitude
        REAL, INTENT(IN) :: weather_Amp
        INTEGER, INTENT(IN) :: numNodes
        INTEGER, INTENT(IN) :: clock_Today_DayOfYear
        REAL, INTENT(IN) :: weather_Tav
        INTEGER, INTENT(IN) :: surfaceNode
        REAL , DIMENSION(: ), INTENT(IN) :: thickness
        INTEGER:: nodes
        REAL , DIMENSION(: ), ALLOCATABLE :: cumulativeDepth
        REAL:: w
        REAL:: dh
        REAL:: zd
        REAL:: offset
        REAL , DIMENSION(numNodes + 1 + 1 ):: soilTemp
        cumulativeDepth = ToCumThickness(thickness)
        w = 2 * 3.14159265 / (365.25 * 24 * 3600)
        dh = 0.6
        zd = SQRT(2 * dh / w)
        offset = 0.25
        IF(weather_Latitude .GT. 0.0) THEN
            offset = -0.25
        END IF
        DO nodes = 1 , numNodes + 1-1, 1
            soilTemp(nodes+1) = weather_Tav + (weather_Amp * EXP((-1) *  &
                    cumulativeDepth(nodes+1) / zd) * SIN(((clock_Today_DayOfYear / 365.0  &
                    + offset) * 2.0 * 3.14159265 - (cumulativeDepth(nodes+1) / zd))))
        END DO
        soilTempIO(surfaceNode:surfaceNode + numNodes) = soilTemp(0:0 +  &
                numNodes)
    END FUNCTION calcSoilTemperature

    FUNCTION calcSurfaceTemperature(waterBalance_Salb, &
        weather_MeanT, &
        weather_Radn, &
        weather_MaxT) RESULT(surfaceT)
        IMPLICIT NONE
        REAL, INTENT(IN) :: waterBalance_Salb
        REAL, INTENT(IN) :: weather_MeanT
        REAL, INTENT(IN) :: weather_Radn
        REAL, INTENT(IN) :: weather_MaxT
        REAL:: surfaceT
        surfaceT = (1.0 - waterBalance_Salb) * (weather_MeanT +  &
                ((weather_MaxT - weather_MeanT) * SQRT(MAX(weather_Radn, 0.1) *  &
                23.8846 / 800.0))) + (waterBalance_Salb * weather_MeanT)
    END FUNCTION calcSurfaceTemperature

    FUNCTION ValuesInArray(Values, &
        MissingValue) RESULT(res_cyml)
        IMPLICIT NONE
        REAL , DIMENSION(: ), INTENT(IN) :: Values
        REAL, INTENT(IN) :: MissingValue
        REAL:: Value
        INTEGER:: i_cyml0
        LOGICAL:: res_cyml
        IF(ALLOCATE(Values)) THEN
            DO i_cyml0 = 1, SIZE(Values)
                Value = Values(i_cyml0)
                IF(Value .NE. MissingValue .AND. .NOT. Value .NE. Value) THEN
                    res_cyml = .TRUE.
                END IF
            END DO
        END IF
        res_cyml = .FALSE.
    END FUNCTION ValuesInArray

END MODULE
