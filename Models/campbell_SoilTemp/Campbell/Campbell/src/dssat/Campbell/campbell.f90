MODULE Campbellmod
    USE list_sub
    IMPLICIT NONE
CONTAINS

    SUBROUTINE init_campbell(NLAYR, &
        THICK, &
        BD, &
        SLCARB, &
        CLAY, &
        SLROCK, &
        SLSILT, &
        SLSAND, &
        SW, &
        CONSTANT_TEMPdepth, &
        T2M, &
        TMAX, &
        TMIN, &
        TAV, &
        TAMP, &
        XLAT, &
        DOY, &
        airPressure, &
        canopyHeight, &
        SALB, &
        SRAD, &
        ESP, &
        ES, &
        EOAD, &
        instrumentHeight, &
        boundaryLayerConductanceSource, &
        netRadiationSource, &
        windSpeed, &
        THICKApsim, &
        DEPTHApsim, &
        BDApsim, &
        CLAYApsim, &
        SWApsim, &
        soilTemp, &
        newTemperature, &
        minSoilTemp, &
        maxSoilTemp, &
        aveSoilTemp, &
        morningSoilTemp, &
        thermalCondPar1, &
        thermalCondPar2, &
        thermalCondPar3, &
        thermalCondPar4, &
        thermalConductivity, &
        thermalConductance, &
        heatStorage, &
        volSpecHeatSoil, &
        maxTempYesterday, &
        minTempYesterday, &
        SLCARBApsim, &
        SLROCKApsim, &
        SLSILTApsim, &
        SLSANDApsim, &
        _boundaryLayerConductance)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        INTEGER, INTENT(IN) :: NLAYR
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: THICK
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: BD
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: SLCARB
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: CLAY
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: SLROCK
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: SLSILT
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: SLSAND
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: SW
        REAL, INTENT(IN) :: CONSTANT_TEMPdepth
        REAL, INTENT(IN) :: T2M
        REAL, INTENT(IN) :: TMAX
        REAL, INTENT(IN) :: TMIN
        REAL, INTENT(IN) :: TAV
        REAL, INTENT(IN) :: TAMP
        REAL, INTENT(IN) :: XLAT
        INTEGER, INTENT(IN) :: DOY
        REAL, INTENT(IN) :: airPressure
        REAL, INTENT(IN) :: canopyHeight
        REAL, INTENT(IN) :: SALB
        REAL, INTENT(IN) :: SRAD
        REAL, INTENT(IN) :: ESP
        REAL, INTENT(IN) :: ES
        REAL, INTENT(IN) :: EOAD
        REAL, INTENT(IN) :: instrumentHeight
        CHARACTER(65), INTENT(IN) :: boundaryLayerConductanceSource
        CHARACTER(65), INTENT(IN) :: netRadiationSource
        REAL, INTENT(IN) :: windSpeed
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: THICKApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: DEPTHApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: BDApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: CLAYApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: SWApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: soilTemp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: newTemperature
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: minSoilTemp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: maxSoilTemp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: aveSoilTemp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: morningSoilTemp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: thermalCondPar1
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: thermalCondPar2
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: thermalCondPar3
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: thermalCondPar4
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: thermalConductivity
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: thermalConductance
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: heatStorage
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: volSpecHeatSoil
        REAL, INTENT(OUT) :: maxTempYesterday
        REAL, INTENT(OUT) :: minTempYesterday
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: SLCARBApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: SLROCKApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: SLSILTApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: SLSANDApsim
        REAL, INTENT(OUT) :: cy_boundaryLayerConductance
        REAL, ALLOCATABLE , DIMENSION(:):: heatCapacity
        REAL:: soilRoughnessHeight
        REAL:: defaultInstrumentHeight
        REAL:: AltitudeMetres
        INTEGER:: NUM_PHANTOM_NODES
        INTEGER:: AIRnode
        INTEGER:: SURFACEnode
        INTEGER:: TOPSOILnode
        REAL:: sumThickness
        REAL:: BelowProfileDepth
        REAL:: thicknessForPhantomNodes
        REAL:: ave_temp
        INTEGER:: I
        INTEGER:: numNodes
        INTEGER:: firstPhantomNode
        INTEGER:: layer
        INTEGER:: node
        REAL:: surfaceT
        
        deallocate(THICKApsim)

        deallocate(DEPTHApsim)

        deallocate(BDApsim)

        deallocate(CLAYApsim)

        deallocate(SWApsim)

        deallocate(soilTemp)

        deallocate(newTemperature)

        deallocate(minSoilTemp)

        deallocate(maxSoilTemp)

        deallocate(aveSoilTemp)

        deallocate(morningSoilTemp)

        deallocate(thermalCondPar1)

        deallocate(thermalCondPar2)

        deallocate(thermalCondPar3)

        deallocate(thermalCondPar4)

        deallocate(thermalConductivity)

        deallocate(thermalConductance)

        deallocate(heatStorage)

        deallocate(volSpecHeatSoil)

        maxTempYesterday = 0.0
        minTempYesterday = 0.0
        deallocate(SLCARBApsim)

        deallocate(SLROCKApsim)

        deallocate(SLSILTApsim)

        deallocate(SLSANDApsim)

        cy_boundaryLayerConductance = 0.0
        soilRoughnessHeight = 57.0
        defaultInstrumentHeight = 1.2
        AltitudeMetres = 18.0
        NUM_PHANTOM_NODES = 5
        AIRnode = 0
        SURFACEnode = 1
        TOPSOILnode = 2
        IF(instrumentHeight .GT. 0.00001) THEN
            instrumentHeight = instrumentHeight
        ELSE
            instrumentHeight = defaultInstrumentHeight
        END IF
        numNodes = NLAYR + NUM_PHANTOM_NODES
        THICKApsim = 0.0
        DO layer = 1 , NLAYR + 1-1, 1
            THICKApsim(layer+1) = THICK(layer - 1+1)
        END DO
        sumThickness = 0.0
        DO I = 1 , NLAYR + 1-1, 1
            sumThickness = sumThickness + THICKApsim(I+1)
        END DO
        BelowProfileDepth = MAX(CONSTANT_TEMPdepth - sumThickness, 1000.0)
        thicknessForPhantomNodes = BelowProfileDepth * 2.0 / NUM_PHANTOM_NODES
        firstPhantomNode = NLAYR
        DO I = firstPhantomNode , firstPhantomNode + NUM_PHANTOM_NODES-1, 1
            THICKApsim(I+1) = thicknessForPhantomNodes
        END DO
        DEPTHApsim = 0.0
        DEPTHApsim(AIRnode+1) = 0.0
        DEPTHApsim(SURFACEnode+1) = 0.0
        DEPTHApsim(TOPSOILnode+1) = 0.5 * THICKApsim(2) / 1000.0
        DO node = TOPSOILnode , numNodes + 1-1, 1
            sumThickness = 0.0
            DO I = 1 , node-1, 1
                sumThickness = sumThickness + THICKApsim(I+1)
            END DO
            DEPTHApsim(node + 1+1) = (sumThickness + (0.5 * THICKApsim(node+1)))  &
                    / 1000.0
        END DO
        BDApsim = 0.0
        DO layer = 1 , NLAYR + 1-1, 1
            BDApsim(layer+1) = BD(layer - 1+1)
        END DO
        BDApsim(numNodes+1) = BDApsim(NLAYR+1)
        DO layer = NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1-1, 1
            BDApsim(layer+1) = BDApsim(NLAYR+1)
        END DO
        SWApsim = 0.0
        DO layer = 1 , NLAYR + 1-1, 1
            SWApsim(layer+1) = SW(layer - 1+1)
        END DO
        DO layer = NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1-1, 1
            SWApsim(layer+1) = SWApsim((NLAYR - 1)+1) * THICKApsim((NLAYR - 1)+1)  &
                    / THICKApsim(NLAYR+1)
        END DO
        SLCARBApsim = 0.0
        DO layer = 1 , NLAYR + 1-1, 1
            SLCARBApsim(layer+1) = SLCARB(layer - 1+1)
        END DO
        DO layer = NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1-1, 1
            SLCARBApsim(layer+1) = SLCARBApsim(NLAYR+1)
        END DO
        SLROCKApsim = 0.0
        DO layer = 1 , NLAYR + 1-1, 1
            SLROCKApsim(layer+1) = SLROCK(layer - 1+1)
        END DO
        DO layer = NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1-1, 1
            SLROCKApsim(layer+1) = SLROCKApsim(NLAYR+1)
        END DO
        SLSANDApsim = 0.0
        DO layer = 1 , NLAYR + 1-1, 1
            SLSANDApsim(layer+1) = SLSAND(layer - 1+1)
        END DO
        DO layer = NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1-1, 1
            SLSANDApsim(layer+1) = SLSANDApsim(NLAYR+1)
        END DO
        SLSILTApsim = 0.0
        DO layer = 1 , NLAYR + 1-1, 1
            SLSILTApsim(layer+1) = SLSILT(layer - 1+1)
        END DO
        DO layer = NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1-1, 1
            SLSILTApsim(layer+1) = SLSILTApsim(NLAYR+1)
        END DO
        CLAYApsim = 0.0
        DO layer = 1 , NLAYR + 1-1, 1
            CLAYApsim(layer+1) = CLAY(layer - 1+1)
        END DO
        DO layer = NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1-1, 1
            CLAYApsim(layer+1) = CLAYApsim(NLAYR+1)
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
        call doThermalConductivityCoeffs(NLAYR, numNodes, BDApsim,  &
                CLAYApsim,thermalCondPar1,thermalCondPar2,thermalCondPar3,thermalCondPar4)
        newTemperature = CalcSoilTemp(THICKApsim, TAV, TAMP, DOY, XLAT,  &
                numNodes)
        instrumentHeight = MAX(instrumentHeight, canopyHeight + 0.5)
        soilTemp = CalcSoilTemp(THICKApsim, TAV, TAMP, DOY, XLAT, numNodes)
        soilTemp(AIRnode+1) = T2M
        surfaceT = (1.0 - SALB) * (T2M + ((TMAX - T2M) * SQRT(MAX(SRAD, 0.1)  &
                * 23.8846 / 800.0))) + (SALB * T2M)
        soilTemp(SURFACEnode+1) = surfaceT
        DO I = numNodes + 1 , SIZE(soilTemp)-1, 1
            soilTemp(I+1) = TAV
        END DO
        DO I = 0 , SIZE(soilTemp)-1, 1
            newTemperature(I+1) = soilTemp(I+1)
        END DO
        maxTempYesterday = TMAX
        minTempYesterday = TMIN
    END SUBROUTINE init_campbell

    SUBROUTINE model_campbell(NLAYR, &
        THICK, &
        BD, &
        SLCARB, &
        CLAY, &
        SLROCK, &
        SLSILT, &
        SLSAND, &
        SW, &
        THICKApsim, &
        DEPTHApsim, &
        CONSTANT_TEMPdepth, &
        BDApsim, &
        T2M, &
        TMAX, &
        TMIN, &
        TAV, &
        TAMP, &
        XLAT, &
        CLAYApsim, &
        SWApsim, &
        DOY, &
        airPressure, &
        canopyHeight, &
        SALB, &
        SRAD, &
        ESP, &
        ES, &
        EOAD, &
        soilTemp, &
        newTemperature, &
        minSoilTemp, &
        maxSoilTemp, &
        aveSoilTemp, &
        morningSoilTemp, &
        thermalCondPar1, &
        thermalCondPar2, &
        thermalCondPar3, &
        thermalCondPar4, &
        thermalConductivity, &
        thermalConductance, &
        heatStorage, &
        volSpecHeatSoil, &
        maxTempYesterday, &
        minTempYesterday, &
        instrumentHeight, &
        boundaryLayerConductanceSource, &
        netRadiationSource, &
        windSpeed, &
        SLCARBApsim, &
        SLROCKApsim, &
        SLSILTApsim, &
        SLSANDApsim, &
        _boundaryLayerConductance)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        INTEGER, INTENT(IN) :: NLAYR
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: THICK
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: BD
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: SLCARB
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: CLAY
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: SLROCK
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: SLSILT
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: SLSAND
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: SW
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: THICKApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: DEPTHApsim
        REAL, INTENT(IN) :: CONSTANT_TEMPdepth
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: BDApsim
        REAL, INTENT(IN) :: T2M
        REAL, INTENT(IN) :: TMAX
        REAL, INTENT(IN) :: TMIN
        REAL, INTENT(IN) :: TAV
        REAL, INTENT(IN) :: TAMP
        REAL, INTENT(IN) :: XLAT
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: CLAYApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: SWApsim
        INTEGER, INTENT(IN) :: DOY
        REAL, INTENT(IN) :: airPressure
        REAL, INTENT(IN) :: canopyHeight
        REAL, INTENT(IN) :: SALB
        REAL, INTENT(IN) :: SRAD
        REAL, INTENT(IN) :: ESP
        REAL, INTENT(IN) :: ES
        REAL, INTENT(IN) :: EOAD
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: soilTemp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: newTemperature
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: minSoilTemp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: maxSoilTemp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: aveSoilTemp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: morningSoilTemp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: thermalCondPar1
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: thermalCondPar2
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: thermalCondPar3
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: thermalCondPar4
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: thermalConductivity
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: thermalConductance
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: heatStorage
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: volSpecHeatSoil
        REAL, INTENT(INOUT) :: maxTempYesterday
        REAL, INTENT(INOUT) :: minTempYesterday
        REAL, INTENT(IN) :: instrumentHeight
        CHARACTER(65), INTENT(IN) :: boundaryLayerConductanceSource
        CHARACTER(65), INTENT(IN) :: netRadiationSource
        REAL, INTENT(IN) :: windSpeed
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: SLCARBApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: SLROCKApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: SLSILTApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: SLSANDApsim
        REAL, INTENT(INOUT) :: cy_boundaryLayerConductance
        INTEGER:: AIRnode
        INTEGER:: SURFACEnode
        INTEGER:: TOPSOILnode
        INTEGER:: ITERATIONSperDAY
        INTEGER:: NUM_PHANTOM_NODES
        REAL:: DAYhrs
        REAL:: MIN2SEC
        REAL:: HR2MIN
        REAL:: SEC2HR
        REAL:: DAYmins
        REAL:: DAYsecs
        REAL:: PA2HPA
        REAL:: MJ2J
        REAL:: J2MJ
        REAL:: tempStepSec
        INTEGER:: BoundaryLayerConductanceIterations
        INTEGER:: numNodes
        CHARACTER(65) , DIMENSION(: ), ALLOCATABLE :: soilConstituentNames
        INTEGER:: timeStepIteration
        REAL:: netRadiation
        REAL:: constantBoundaryLayerConductance
        REAL:: precision
        REAL:: cva
        REAL:: cloudFr
        REAL, ALLOCATABLE , DIMENSION(:):: solarRadn
        INTEGER:: layer
        REAL:: timeOfDaySecs
        REAL:: airTemperature
        INTEGER:: iteration
        REAL:: tMean
        REAL:: internalTimeStep
        !- Name: Campbell -Version: 1.0, -Time step: 1
        !- Description:
    !            * Title: SoilTemperature model from Campbell implemented in APSIM
    !            * Authors: None
    !            * Reference: Campbell model (TODO)
    !            * Institution: CIRAD and INRAE
    !            * ExtendedDescription: TODO
    !            * ShortDescription: TODO
        !- inputs:
    !            * name: NLAYR
    !                          ** description : number of soil layers in profile
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 1
    !                          ** default : 10
    !                          ** unit : dimensionless
    !            * name: THICK
    !                          ** description : Soil layer thickness of layers
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 1
    !                          ** default : 
    !                          ** unit : mm
    !            * name: BD
    !                          ** description : bd (soil bulk density)
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : g/cm3             uri :
    !            * name: SLCARB
    !                          ** description : Volumetric fraction of organic matter in the soil
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: CLAY
    !                          ** description : Proportion of CLAY in each layer of profile
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 100
    !                          ** min : 0
    !                          ** default : 50
    !                          ** unit : 
    !            * name: SLROCK
    !                          ** description : Volumetric fraction of rocks in the soil
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: SLSILT
    !                          ** description : Volumetric fraction of silt in the soil
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: SLSAND
    !                          ** description : Volumetric fraction of sand in the soil
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: SW
    !                          ** description : volumetric water content
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.5
    !                          ** unit : cc water / cc soil
    !            * name: THICKApsim
    !                          ** description : APSIM soil layer depths of layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 
    !                          ** min : 1
    !                          ** default : 
    !                          ** unit : mm
    !            * name: DEPTHApsim
    !                          ** description : Apsim node depths
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : m
    !            * name: CONSTANT_TEMPdepth
    !                          ** description : Depth of constant temperature
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 1000.0
    !                          ** unit : mm
    !            * name: BDApsim
    !                          ** description : Apsim bd (soil bulk density)
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : g/cm3             uri :
    !            * name: T2M
    !                          ** description : Mean daily Air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 60
    !                          ** min : -60
    !                          ** default : 
    !                          ** unit : 
    !            * name: TMAX
    !                          ** description : Max daily Air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 60
    !                          ** min : -60
    !                          ** default : 
    !                          ** unit : 
    !            * name: TMIN
    !                          ** description : Min daily Air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 60
    !                          ** min : -60
    !                          ** default : 
    !                          ** unit : 
    !            * name: TAV
    !                          ** description : Average annual air temperature
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 60
    !                          ** min : -60
    !                          ** default : 
    !                          ** unit : 
    !            * name: TAMP
    !                          ** description : Amplitude air temperature
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 100
    !                          ** min : -100
    !                          ** default : 
    !                          ** unit : 
    !            * name: XLAT
    !                          ** description : Latitude
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: CLAYApsim
    !                          ** description : Apsim proportion of CLAY in each layer of profile
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 100
    !                          ** min : 0
    !                          ** default : 
    !                          ** unit : 
    !            * name: SWApsim
    !                          ** description : Apsim volumetric water content
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 
    !                          ** unit : cc water / cc soil
    !            * name: DOY
    !                          ** description : Day of year
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : INT
    !                          ** max : 366
    !                          ** min : 1
    !                          ** default : 1
    !                          ** unit : dimensionless
    !            * name: airPressure
    !                          ** description : Air pressure
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 1010
    !                          ** unit : hPA
    !            * name: canopyHeight
    !                          ** description : height of canopy above ground
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 0.057
    !                          ** unit : m
    !            * name: SALB
    !                          ** description : Soil albedo
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 
    !                          ** unit : dimensionless
    !            * name: SRAD
    !                          ** description : Solar radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 
    !                          ** unit : MJ/m2
    !            * name: ESP
    !                          ** description : Potential evaporation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 
    !                          ** unit : mm
    !            * name: ES
    !                          ** description : Actual evaporation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 
    !                          ** unit : mm
    !            * name: EOAD
    !                          ** description : Potential evapotranspiration
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 
    !                          ** unit : mm
    !            * name: soilTemp
    !                          ** description : Temperature at end of last time-step within a day - midnight in layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** default : 
    !                          ** unit : degC
    !            * name: newTemperature
    !                          ** description : Soil temperature at the end of one iteration
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** default : 
    !                          ** unit : degC
    !            * name: minSoilTemp
    !                          ** description : Minimum soil temperature in layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** default : 
    !                          ** unit : degC
    !            * name: maxSoilTemp
    !                          ** description : Maximum soil temperature in layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** default : 
    !                          ** unit : degC
    !            * name: aveSoilTemp
    !                          ** description : Temperature averaged over all time-steps within a day in layers.
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** default : 
    !                          ** unit : degC
    !            * name: morningSoilTemp
    !                          ** description : Temperature  in the morning in layers.
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** default : 
    !                          ** unit : degC
    !            * name: thermalCondPar1
    !                          ** description : thermal conductivity coeff in layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalCondPar2
    !                          ** description : thermal conductivity coeff in layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalCondPar3
    !                          ** description : thermal conductivity coeff in layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalCondPar4
    !                          ** description : thermal conductivity coeff in layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalConductivity
    !                          ** description : thermal conductivity in layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalConductance
    !                          ** description : Thermal conductance between layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : (W/m2/K)
    !            * name: heatStorage
    !                          ** description : Heat storage between layers (internal)
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : J/s/K
    !            * name: volSpecHeatSoil
    !                          ** description : Volumetric specific heat over the soil profile
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : J/K/m3
    !            * name: maxTempYesterday
    !                          ** description : Air max temperature from previous day
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 60
    !                          ** min : -60
    !                          ** default : 
    !                          ** unit : 
    !            * name: minTempYesterday
    !                          ** description : Air min temperature from previous day
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 60
    !                          ** min : -60
    !                          ** default : 
    !                          ** unit : 
    !            * name: instrumentHeight
    !                          ** description : Default instrument height
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0
    !                          ** default : 1.2
    !                          ** unit : m
    !            * name: boundaryLayerConductanceSource
    !                          ** description : Flag whether boundary layer conductance is calculated or gotten from input
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : STRING
    !                          ** max : 
    !                          ** min : 
    !                          ** default : calc
    !                          ** unit : dimensionless
    !            * name: netRadiationSource
    !                          ** description : Flag whether net radiation is calculated or gotten from input
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : STRING
    !                          ** max : 
    !                          ** min : 
    !                          ** default : calc
    !                          ** unit : dimensionless
    !            * name: windSpeed
    !                          ** description : Speed of wind
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 0.0
    !                          ** default : 3.0
    !                          ** unit : m/s
    !            * name: SLCARBApsim
    !                          ** description : Apsim volumetric fraction of organic matter in the soil
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: SLROCKApsim
    !                          ** description : Apsim volumetric fraction of rocks in the soil
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: SLSILTApsim
    !                          ** description : Apsim volumetric fraction of silt in the soil
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: SLSANDApsim
    !                          ** description : Apsim volumetric fraction of sand in the soil
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: _boundaryLayerConductance
    !                          ** description : Boundary layer conductance
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : K/W
        !- outputs:
    !            * name: soilTemp
    !                          ** description : Temperature at end of last time-step within a day - midnight in layers
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** unit : degC
    !            * name: minSoilTemp
    !                          ** description : Minimum soil temperature in layers
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** unit : degC
    !            * name: maxSoilTemp
    !                          ** description : Maximum soil temperature in layers
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** unit : degC
    !            * name: aveSoilTemp
    !                          ** description : Temperature averaged over all time-steps within a day in layers.
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** unit : degC
    !            * name: morningSoilTemp
    !                          ** description : Temperature  in the morning in layers.
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** unit : degC
    !            * name: newTemperature
    !                          ** description : Soil temperature at the end of one iteration
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** unit : degC
    !            * name: maxTempYesterday
    !                          ** description : Air max temperature from previous day
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 60
    !                          ** min : -60
    !                          ** unit : 
    !            * name: minTempYesterday
    !                          ** description : Air min temperature from previous day
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 60
    !                          ** min : -60
    !                          ** unit : 
    !            * name: thermalCondPar1
    !                          ** description : thermal conductivity coeff in layers
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalCondPar2
    !                          ** description : thermal conductivity coeff in layers
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalCondPar3
    !                          ** description : thermal conductivity coeff in layers
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalCondPar4
    !                          ** description : thermal conductivity coeff in layers
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalConductivity
    !                          ** description : thermal conductivity in layers
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalConductance
    !                          ** description : Thermal conductance between layers
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : (W/m2/K)
    !            * name: heatStorage
    !                          ** description : Heat storage between layers (internal)
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : J/s/K
    !            * name: volSpecHeatSoil
    !                          ** description : Volumetric specific heat over the soil profile
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : J/K/m3
    !            * name: _boundaryLayerConductance
    !                          ** description : Boundary layer conductance
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : K/W
    !            * name: THICKApsim
    !                          ** description : APSIM soil layer thickness of layers
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 1
    !                          ** unit : mm
    !            * name: DEPTHApsim
    !                          ** description : APSIM node depths
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : m
    !            * name: BDApsim
    !                          ** description : soil bulk density of APSIM
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : g/cm3             uri :
    !            * name: SWApsim
    !                          ** description : Apsim volumetric water content
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 1
    !                          ** min : 0
    !                          ** unit : cc water / cc soil
    !            * name: CLAYApsim
    !                          ** description : Proportion of clay in each layer of profile
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 100
    !                          ** min : 0
    !                          ** unit : 
    !            * name: SLROCKApsim
    !                          ** description : Volumetric fraction of rocks in the soil
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : 
    !            * name: SLCARBApsim
    !                          ** description : Volumetric fraction of organic matter in the soil
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : 
    !            * name: SLSANDApsim
    !                          ** description : Volumetric fraction of sand in the soil
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : 
    !            * name: SLSILTApsim
    !                          ** description : Volumetric fraction of silt in the soil
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : 
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
        soilConstituentNames = (/'Rocks', 'OrganicMatter', 'Sand', 'Silt',  &
                'Clay', 'Water', 'Ice', 'Air'/)
        timeStepIteration = 1
        constantBoundaryLayerConductance = 20.0
        layer = 0
        cva = 0.0
        cloudFr = 0.0
        solarRadn = (/0.0/)
        DO layer = 0 , 50-1, 1
            call Add(solarRadn, 0.0)
        END DO
        call doNetRadiation(solarRadn, cloudFr, cva, ITERATIONSperDAY, DOY,  &
                SRAD, TMIN, XLAT)
        minSoilTemp = Zero(minSoilTemp)
        maxSoilTemp = Zero(maxSoilTemp)
        aveSoilTemp = Zero(aveSoilTemp)
        cy_boundaryLayerConductance = 0.0
        internalTimeStep = tempStepSec / REAL(ITERATIONSperDAY)
        volSpecHeatSoil = doVolumetricSpecificHeat(volSpecHeatSoil, SWApsim,  &
                numNodes, soilConstituentNames, THICKApsim, DEPTHApsim)
        thermalConductivity = doThermConductivity(SWApsim, SLCARBApsim,  &
                SLROCKApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, BDApsim,  &
                thermalConductivity, THICKApsim, DEPTHApsim, numNodes,  &
                soilConstituentNames)
        DO timeStepIteration = 1 , ITERATIONSperDAY + 1-1, 1
            timeOfDaySecs = internalTimeStep * REAL(timeStepIteration)
            IF(tempStepSec .LT. (24.0 * 60.0 * 60.0)) THEN
                tMean = T2M
            ELSE
                tMean = InterpTemp(timeOfDaySecs * SEC2HR, TMAX, TMIN, T2M,  &
                        maxTempYesterday, minTempYesterday)
            END IF
            newTemperature(AIRnode+1) = tMean
            netRadiation = RadnNetInterpolate(internalTimeStep,  &
                    solarRadn(timeStepIteration+1), cloudFr, cva, ESP, EOAD, tMean, SALB,  &
                    soilTemp)
            IF(boundaryLayerConductanceSource .EQ. 'constant') THEN
                thermalConductivity(AIRnode+1) = constantBoundaryLayerConductance
            ELSE IF ( boundaryLayerConductanceSource .EQ. 'calc') THEN
                thermalConductivity(AIRnode+1) =  &
                        boundaryLayerConductanceF(newTemperature, tMean, ESP, EOAD,  &
                        airPressure, canopyHeight, windSpeed, instrumentHeight)
                DO iteration = 1 , BoundaryLayerConductanceIterations + 1-1, 1
                    newTemperature = doThomas(newTemperature, soilTemp,  &
                            thermalConductivity, thermalConductance, DEPTHApsim, volSpecHeatSoil,  &
                            internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource)
                    thermalConductivity(AIRnode+1) =  &
                            boundaryLayerConductanceF(newTemperature, tMean, ESP, EOAD,  &
                            airPressure, canopyHeight, windSpeed, instrumentHeight)
                END DO
            END IF
            newTemperature = doThomas(newTemperature, soilTemp,  &
                    thermalConductivity, thermalConductance, DEPTHApsim, volSpecHeatSoil,  &
                    internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource)
            call doUpdate(newTemperature, soilTemp, minSoilTemp, maxSoilTemp,  &
                    aveSoilTemp, thermalConductivity, cy_boundaryLayerConductance,  &
                    ITERATIONSperDAY, timeOfDaySecs, internalTimeStep, numNodes)
            precision = MIN(timeOfDaySecs, 5.0 * 3600.0) * 0.0001
            IF(ABS(timeOfDaySecs - (5.0 * 3600.0)) .LE. precision) THEN
                DO layer = 0 , SIZE(soilTemp)-1, 1
                    morningSoilTemp(layer+1) = soilTemp(layer+1)
                END DO
            END IF
        END DO
        minTempYesterday = TMIN
        maxTempYesterday = TMAX
    END SUBROUTINE model_campbell

    SUBROUTINE doNetRadiation(solarRadn, &
        cloudFr, &
        cva, &
        ITERATIONSperDAY, &
        doy, &
        rad, &
        tmin, &
        latitude)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: solarRadn
        REAL, INTENT(INOUT) :: cloudFr
        REAL, INTENT(INOUT) :: cva
        INTEGER, INTENT(IN) :: ITERATIONSperDAY
        INTEGER, INTENT(IN) :: doy
        REAL, INTENT(IN) :: rad
        REAL, INTENT(IN) :: tmin
        REAL, INTENT(IN) :: latitude
        REAL, ALLOCATABLE , DIMENSION(:):: m1
        INTEGER:: lay
        REAL:: piVal
        REAL:: TSTEPS2RAD
        REAL:: SOLARconst
        REAL:: solarDeclination
        REAL:: cD
        REAL:: m1Tot
        REAL:: psr
        INTEGER:: timestepNumber
        REAL:: fr
        REAL:: scalar
        REAL:: kelvinTemp
        piVal = 3.141592653589793
        TSTEPS2RAD = 1.0
        SOLARconst = 1.0
        solarDeclination = 1.0
        cD = SQRT(1.0 - (solarDeclination * solarDeclination))
        m1Tot = 0.0
        timestepNumber = 1
        kelvinTemp = kelvinT(tmin)
        solarRadn = 0.0
        m1 = (/0.0/)
        DO lay = 0 , ITERATIONSperDAY + 1-1, 1
            call Add(m1, 0.0)
        END DO
        TSTEPS2RAD = Divide(2.0 * piVal, REAL(ITERATIONSperDAY), 0.0)
        SOLARconst = 1360.0
        solarDeclination = 0.3985 * SIN((4.869 + (doy * 2.0 * piVal / 365.25)  &
                + (0.03345 * SIN((6.224 + (doy * 2.0 * piVal / 365.25))))))
        DO timestepNumber = 1 , ITERATIONSperDAY + 1-1, 1
            m1(timestepNumber+1) = (solarDeclination * SIN(latitude * piVal /  &
                    180.0) + (cD * COS(latitude * piVal / 180.0) * COS(TSTEPS2RAD *  &
                    (REAL(timestepNumber) - (REAL(ITERATIONSperDAY) / 2.0))))) * 24.0 /  &
                    REAL(ITERATIONSperDAY)
            IF(m1(timestepNumber+1) .GT. 0.0) THEN
                m1Tot = m1Tot + m1(timestepNumber+1)
            ELSE
                m1(timestepNumber+1) = 0.0
            END IF
        END DO
        psr = m1Tot * SOLARconst * 3600.0 / 1000000.0
        fr = Divide(MAX(rad, 0.1), psr, 0.0)
        cloudFr = 2.33 - (3.33 * fr)
        cloudFr = MIN(MAX(cloudFr, 0.0), 1.0)
        scalar = MAX(rad, 0.1)
        DO timestepNumber = 1 , ITERATIONSperDAY + 1-1, 1
            solarRadn(timestepNumber+1) = scalar * Divide(m1(timestepNumber+1),  &
                    m1Tot, 0.0)
        END DO
        cva = EXP((31.3716 - (6014.79 / kelvinTemp) - (0.00792495 *  &
                kelvinTemp))) / kelvinTemp
    END SUBROUTINE doNetRadiation

    FUNCTION Divide(val1, &
        val2, &
        errVal) RESULT(returnValue)
        IMPLICIT NONE
        REAL, INTENT(IN) :: val1
        REAL, INTENT(IN) :: val2
        REAL, INTENT(IN) :: errVal
        REAL:: returnValue
        returnValue = errVal
        IF(val2 .NE. 0.0) THEN
            returnValue = val1 / val2
        END IF
    END FUNCTION Divide

    FUNCTION kelvinT(celciusT) RESULT(res)
        IMPLICIT NONE
        REAL, INTENT(IN) :: celciusT
        REAL:: res
        REAL:: ZEROTkelvin
        ZEROTkelvin = 273.18
        res = celciusT + ZEROTkelvin
    END FUNCTION kelvinT

    FUNCTION Zero(arr) RESULT(arr)
        IMPLICIT NONE
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: arr
        INTEGER:: I
        I = 0
        DO I = 0 , SIZE(arr)-1, 1
            arr(I+1) = 0.
        END DO
    END FUNCTION Zero

    FUNCTION doVolumetricSpecificHeat(volSpecLayer, &
        soilW, &
        numNodes, &
        constituents, &
        THICKApsim, &
        DEPTHApsim) RESULT(volSpecLayer)
        IMPLICIT NONE
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: volSpecLayer
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: soilW
        INTEGER, INTENT(IN) :: numNodes
        CHARACTER(65) , DIMENSION(: ), INTENT(IN) :: constituents
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: THICKApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: DEPTHApsim
        REAL, ALLOCATABLE , DIMENSION(:):: volSpecHeatSoil
        INTEGER:: node
        INTEGER:: constituent
        volSpecHeatSoil = (/0.0/)
        DO node = 0 , numNodes + 1-1, 1
            call Add(volSpecHeatSoil, 0.0)
        END DO
        DO node = 1 , numNodes + 1-1, 1
            volSpecHeatSoil(node+1) = 0.0
            DO constituent = 0 , SIZE(constituents)-1, 1
                volSpecHeatSoil(node+1) = volSpecHeatSoil(node+1) +  &
                        (volumetricSpecificHeat(constituents(constituent+1)) * 1000000.0 *  &
                        soilW(node+1))
            END DO
        END DO
        volSpecLayer = mapLayer2Node(volSpecHeatSoil, volSpecLayer,  &
                THICKApsim, DEPTHApsim, numNodes)
    END FUNCTION doVolumetricSpecificHeat

    FUNCTION volumetricSpecificHeat(name) RESULT(res)
        IMPLICIT NONE
        CHARACTER(65), INTENT(IN) :: name
        REAL:: res
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
        res = 0.0
        IF(name .EQ. 'Rocks') THEN
            res = specificHeatRocks
        ELSE IF ( name .EQ. 'OrganicMatter') THEN
            res = specificHeatOM
        ELSE IF ( name .EQ. 'Sand') THEN
            res = specificHeatSand
        ELSE IF ( name .EQ. 'Silt') THEN
            res = specificHeatSilt
        ELSE IF ( name .EQ. 'Clay') THEN
            res = specificHeatClay
        ELSE IF ( name .EQ. 'Water') THEN
            res = specificHeatWater
        ELSE IF ( name .EQ. 'Ice') THEN
            res = specificHeatIce
        ELSE IF ( name .EQ. 'Air') THEN
            res = specificHeatAir
        END IF
    END FUNCTION volumetricSpecificHeat

    FUNCTION mapLayer2Node(layerArray, &
        nodeArray, &
        THICKApsim, &
        DEPTHApsim, &
        numNodes) RESULT(nodeArray)
        IMPLICIT NONE
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: layerArray
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: nodeArray
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: THICKApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: DEPTHApsim
        INTEGER, INTENT(IN) :: numNodes
        INTEGER:: SURFACEnode
        REAL:: depthLayerAbove
        INTEGER:: node
        INTEGER:: I
        INTEGER:: layer
        REAL:: d1
        REAL:: d2
        REAL:: dSum
        SURFACEnode = 1
        node = 0
        I = 0
        DO node = SURFACEnode , numNodes + 1-1, 1
            layer = node - 1
            depthLayerAbove = 0.0
            IF(layer .GE. 1) THEN
                DO I = 1 , layer + 1-1, 1
                    depthLayerAbove = depthLayerAbove + THICKApsim(I+1)
                END DO
            END IF
            d1 = depthLayerAbove - (DEPTHApsim(node+1) * 1000.0)
            d2 = DEPTHApsim((node + 1)+1) * 1000.0 - depthLayerAbove
            dSum = d1 + d2
            nodeArray(node+1) = Divide(layerArray(layer+1) * d1, dSum, 0.0) +  &
                    Divide(layerArray((layer + 1)+1) * d2, dSum, 0.0)
        END DO
    END FUNCTION mapLayer2Node

    FUNCTION doThermConductivity(soilW, &
        SLCARBApsim, &
        SLROCKApsim, &
        SLSANDApsim, &
        SLSILTApsim, &
        CLAYApsim, &
        BDApsim, &
        thermalConductivity, &
        THICKApsim, &
        DEPTHApsim, &
        numNodes, &
        constituents) RESULT(thermalConductivity)
        IMPLICIT NONE
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: soilW
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLCARBApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLROCKApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLSANDApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLSILTApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: CLAYApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: BDApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: thermalConductivity
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: THICKApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: DEPTHApsim
        INTEGER, INTENT(IN) :: numNodes
        CHARACTER(65) , DIMENSION(: ), INTENT(IN) :: constituents
        REAL, ALLOCATABLE , DIMENSION(:):: thermCondLayers
        INTEGER:: I
        INTEGER:: node
        INTEGER:: constituent
        REAL:: temp
        REAL:: numerator
        REAL:: denominator
        REAL:: shapeFactorConstituent
        REAL:: thermalConductanceConstituent
        REAL:: thermalConductanceWater
        REAL:: k
        node = 1
        constituent = 1
        thermCondLayers = (/0.0/)
        DO I = 0 , numNodes + 1-1, 1
            call Add(thermCondLayers, 0.0)
        END DO
        DO node = 1 , numNodes + 1-1, 1
            numerator = 0.0
            denominator = 0.0
            DO constituent = 0 , SIZE(constituents)-1, 1
                shapeFactorConstituent = shapeFactor(constituents(constituent+1),  &
                        SLROCKApsim, SLCARBApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, soilW,  &
                        BDApsim, node)
                thermalConductanceConstituent =  &
                        ThermalConductance(constituents(constituent+1))
                thermalConductanceWater = ThermalConductance('Water')
                k = 2.0 / 3.0 *  ((1 + (shapeFactorConstituent *  &
                        (thermalConductanceConstituent / thermalConductanceWater - 1.0))) **  &
                        (-1)) + (1.0 / 3.0 *  ((1 + (shapeFactorConstituent *  &
                        (thermalConductanceConstituent / thermalConductanceWater - 1.0) *  &
                        (1.0 - (2.0 * shapeFactorConstituent)))) ** (-1)))
                numerator = numerator + (thermalConductanceConstituent *  &
                        soilW(node+1) * k)
                denominator = denominator + (soilW(node+1) * k)
            END DO
            thermCondLayers(node+1) = numerator / denominator
        END DO
        thermalConductivity = mapLayer2Node(thermCondLayers,  &
                thermalConductivity, THICKApsim, DEPTHApsim, numNodes)
    END FUNCTION doThermConductivity

    FUNCTION shapeFactor(name, &
        SLROCKApsim, &
        SLCARBApsim, &
        SLSANDApsim, &
        SLSILTApsim, &
        CLAYApsim, &
        SWApsim, &
        BDApsim, &
        layer) RESULT(res_cyml)
        IMPLICIT NONE
        CHARACTER(65), INTENT(IN) :: name
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLROCKApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLCARBApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLSANDApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLSILTApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: CLAYApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SWApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: BDApsim
        INTEGER, INTENT(IN) :: layer
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
            result = 0.333 - (0.333 * 0.0 / (volumetricFractionWater(SWApsim,  &
                    SLCARBApsim, BDApsim, layer) + 0.0 +  &
                    volumetricFractionAir(SLROCKApsim, SLCARBApsim, SLSANDApsim,  &
                    SLSILTApsim, CLAYApsim, SWApsim, BDApsim, layer)))
            res_cyml = result
        ELSE IF ( name .EQ. 'Air') THEN
            result = 0.333 - (0.333 * volumetricFractionAir(SLROCKApsim,  &
                    SLCARBApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, SWApsim, BDApsim,  &
                    layer) / (volumetricFractionWater(SWApsim, SLCARBApsim, BDApsim,  &
                    layer) + 0.0 + volumetricFractionAir(SLROCKApsim, SLCARBApsim,  &
                    SLSANDApsim, SLSILTApsim, CLAYApsim, SWApsim, BDApsim, layer)))
            res_cyml = result
        ELSE IF ( name .EQ. 'Minerals') THEN
            result = shapeFactorRocks * volumetricFractionRocks(SLROCKApsim,  &
                    layer) + (shapeFactorSand * volumetricFractionSand(SLSANDApsim,  &
                    SLROCKApsim, SLCARBApsim, BDApsim, layer)) + (shapeFactorSilt *  &
                    volumetricFractionSilt(SLSILTApsim, SLROCKApsim, SLCARBApsim,  &
                    BDApsim, layer)) + (shapeFactorClay *  &
                    volumetricFractionClay(CLAYApsim, SLROCKApsim, SLCARBApsim, BDApsim,  &
                    layer))
        END IF
        result = volumetricSpecificHeat(name)
        res_cyml = result
    END FUNCTION shapeFactor

    FUNCTION ThermalConductance(name) RESULT(result)
        IMPLICIT NONE
        CHARACTER(65), INTENT(IN) :: name
        REAL:: result
        REAL:: thermal_conductance_rocks
        REAL:: thermal_conductance_om
        REAL:: thermal_conductance_sand
        REAL:: thermal_conductance_silt
        REAL:: thermal_conductance_clay
        REAL:: thermal_conductance_water
        REAL:: thermal_conductance_ice
        REAL:: thermal_conductance_air
        thermal_conductance_rocks = 0.182
        thermal_conductance_om = 2.50
        thermal_conductance_sand = 0.182
        thermal_conductance_silt = 2.39
        thermal_conductance_clay = 1.39
        thermal_conductance_water = 4.18
        thermal_conductance_ice = 1.73
        thermal_conductance_air = 0.0012
        result = 0.0
        IF(name .EQ. 'Rocks') THEN
            result = thermal_conductance_rocks
        ELSE IF ( name .EQ. 'OrganicMatter') THEN
            result = thermal_conductance_om
        ELSE IF ( name .EQ. 'Sand') THEN
            result = thermal_conductance_sand
        ELSE IF ( name .EQ. 'Silt') THEN
            result = thermal_conductance_silt
        ELSE IF ( name .EQ. 'Clay') THEN
            result = thermal_conductance_clay
        ELSE IF ( name .EQ. 'Water') THEN
            result = thermal_conductance_water
        ELSE IF ( name .EQ. 'Ice') THEN
            result = thermal_conductance_ice
        ELSE IF ( name .EQ. 'Air') THEN
            result = thermal_conductance_air
        END IF
        result = volumetricSpecificHeat(name)
    END FUNCTION ThermalConductance

    FUNCTION volumetricFractionWater(SWApsim, &
        SLCARBApsim, &
        BDApsim, &
        layer) RESULT(res)
        IMPLICIT NONE
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SWApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLCARBApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: BDApsim
        INTEGER, INTENT(IN) :: layer
        REAL:: res
        res = (1.0 - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim,  &
                layer)) * SWApsim(layer+1)
    END FUNCTION volumetricFractionWater

    FUNCTION volumetricFractionAir(SLROCKApsim, &
        SLCARBApsim, &
        SLSANDApsim, &
        SLSILTApsim, &
        CLAYApsim, &
        SWApsim, &
        BDApsim, &
        layer) RESULT(res)
        IMPLICIT NONE
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLROCKApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLCARBApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLSANDApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLSILTApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: CLAYApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SWApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: BDApsim
        INTEGER, INTENT(IN) :: layer
        REAL:: res
        res = 1.0 - volumetricFractionRocks(SLROCKApsim, layer) -  &
                volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) -  &
                volumetricFractionSand(SLSANDApsim, SLROCKApsim, SLCARBApsim,  &
                BDApsim, layer) - volumetricFractionSilt(SLSILTApsim, SLROCKApsim,  &
                SLCARBApsim, BDApsim, layer) - volumetricFractionClay(CLAYApsim,  &
                SLROCKApsim, SLCARBApsim, BDApsim, layer) -  &
                volumetricFractionWater(SWApsim, SLCARBApsim, BDApsim, layer) - 0.0
    END FUNCTION volumetricFractionAir

    FUNCTION volumetricFractionRocks(SLROCKApsim, &
        layer) RESULT(res)
        IMPLICIT NONE
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLROCKApsim
        INTEGER, INTENT(IN) :: layer
        REAL:: res
        res = SLROCKApsim(layer+1) / 100.0
    END FUNCTION volumetricFractionRocks

    FUNCTION volumetricFractionSand(SLSANDApsim, &
        SLROCKApsim, &
        SLCARBApsim, &
        BDApsim, &
        layer) RESULT(res)
        IMPLICIT NONE
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLSANDApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLROCKApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLCARBApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: BDApsim
        INTEGER, INTENT(IN) :: layer
        REAL:: res
        REAL:: ps
        ps = 2.63
        res = (1.0 - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim,  &
                layer) - volumetricFractionRocks(SLROCKApsim, layer)) *  &
                SLSANDApsim(layer+1) / 100.0 * BDApsim(layer+1) / ps
    END FUNCTION volumetricFractionSand

    FUNCTION volumetricFractionSilt(SLSILTApsim, &
        SLROCKApsim, &
        SLCARBApsim, &
        BDApsim, &
        layer) RESULT(res)
        IMPLICIT NONE
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLSILTApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLROCKApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLCARBApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: BDApsim
        INTEGER, INTENT(IN) :: layer
        REAL:: res
        REAL:: ps
        ps = 2.63
        res = (1.0 - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim,  &
                layer) - volumetricFractionRocks(SLROCKApsim, layer)) *  &
                SLSILTApsim(layer+1) / 100.0 * BDApsim(layer+1) / ps
    END FUNCTION volumetricFractionSilt

    FUNCTION volumetricFractionClay(CLAYApsim, &
        SLROCKApsim, &
        SLCARBApsim, &
        BDApsim, &
        layer) RESULT(res)
        IMPLICIT NONE
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: CLAYApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLROCKApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLCARBApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: BDApsim
        INTEGER, INTENT(IN) :: layer
        REAL:: res
        REAL:: ps
        ps = 2.63
        res = (1.0 - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim,  &
                layer) - volumetricFractionRocks(SLROCKApsim, layer)) *  &
                CLAYApsim(layer+1) / 100.0 * BDApsim(layer+1) / ps
    END FUNCTION volumetricFractionClay

    FUNCTION volumetricFractionOrganicMatter(SLCARBApsim, &
        BDApsim, &
        layer) RESULT(res)
        IMPLICIT NONE
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: SLCARBApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: BDApsim
        INTEGER, INTENT(IN) :: layer
        REAL:: res
        REAL:: pom
        pom = 1.3
        res = SLCARBApsim(layer+1) / 100.0 * 2.5 * BDApsim(layer+1) / pom
    END FUNCTION volumetricFractionOrganicMatter

    FUNCTION InterpTemp(time_hours, &
        tmax, &
        tmin, &
        t2m, &
        max_temp_yesterday, &
        min_temp_yesterday) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: time_hours
        REAL, INTENT(IN) :: tmax
        REAL, INTENT(IN) :: tmin
        REAL, INTENT(IN) :: t2m
        REAL, INTENT(IN) :: max_temp_yesterday
        REAL, INTENT(IN) :: min_temp_yesterday
        REAL:: defaultTimeOfMaximumTemperature
        REAL:: midnight_temp
        REAL:: t_scale
        REAL:: piVal
        REAL:: time
        REAL:: max_t_time
        REAL:: min_t_time
        REAL:: current_temp
        defaultTimeOfMaximumTemperature = 14.0
        piVal = 3.141592653589793
        time = time_hours / 24.0
        max_t_time = defaultTimeOfMaximumTemperature / 24.0
        min_t_time = max_t_time - 0.5
        current_temp = 0.0
        IF(time .LT. min_t_time) THEN
            midnight_temp = SIN((0.0 + 0.25 - max_t_time) * 2.0 * piVal) *  &
                    (max_temp_yesterday - min_temp_yesterday) / 2.0 +  &
                    ((max_temp_yesterday + min_temp_yesterday) / 2.0)
            t_scale = (min_t_time - time) / min_t_time
            IF(t_scale .GT. 1.0) THEN
                t_scale = 1.0
            ELSE IF ( t_scale .LT. 0.0) THEN
                t_scale = 0.0
            END IF
            current_temp = tmin + (t_scale * (midnight_temp - tmin))
            res_cyml = current_temp
        ELSE
            current_temp = SIN((time + 0.25 - max_t_time) * 2.0 * piVal) * (tmax  &
                    - tmin) / 2.0 + t2m
            res_cyml = current_temp
        END IF
        res_cyml = current_temp
    END FUNCTION InterpTemp

    FUNCTION RadnNetInterpolate(internalTimeStep, &
        solarRadiation, &
        cloudFr, &
        cva, &
        potE, &
        potET, &
        tMean, &
        albedo, &
        soilTemp) RESULT(total)
        IMPLICIT NONE
        REAL, INTENT(IN) :: internalTimeStep
        REAL, INTENT(IN) :: solarRadiation
        REAL, INTENT(IN) :: cloudFr
        REAL, INTENT(IN) :: cva
        REAL, INTENT(IN) :: potE
        REAL, INTENT(IN) :: potET
        REAL, INTENT(IN) :: tMean
        REAL, INTENT(IN) :: albedo
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: soilTemp
        REAL:: total
        REAL:: EMISSIVITYsurface
        REAL:: w2MJ
        INTEGER:: SURFACEnode
        REAL:: emissivityAtmos
        REAL:: PenetrationConstant
        REAL:: lwRinSoil
        REAL:: lwRoutSoil
        REAL:: lwRnetSoil
        REAL:: swRin
        REAL:: swRout
        REAL:: swRnetSoil
        EMISSIVITYsurface = 0.96
        w2MJ = internalTimeStep / 1000000.0
        SURFACEnode = 1
        emissivityAtmos = (1 - (0.84 * cloudFr)) * 0.58 *  (cva ** (1.0 /  &
                7.0)) + (0.84 * cloudFr)
        PenetrationConstant = Divide(MAX(0.1, potE), MAX(0.1, potET), 0.0)
        lwRinSoil = longWaveRadn(emissivityAtmos, tMean) *  &
                PenetrationConstant * w2MJ
        lwRoutSoil = longWaveRadn(EMISSIVITYsurface, soilTemp(SURFACEnode+1))  &
                * PenetrationConstant * w2MJ
        lwRnetSoil = lwRinSoil - lwRoutSoil
        swRin = solarRadiation
        swRout = albedo * solarRadiation
        swRnetSoil = (swRin - swRout) * PenetrationConstant
        total = swRnetSoil + lwRnetSoil
    END FUNCTION RadnNetInterpolate

    FUNCTION longWaveRadn(emissivity, &
        tDegC) RESULT(res)
        IMPLICIT NONE
        REAL, INTENT(IN) :: emissivity
        REAL, INTENT(IN) :: tDegC
        REAL:: res
        REAL:: STEFAN_BOLTZMANNconst
        REAL:: kelvinTemp
        STEFAN_BOLTZMANNconst = 0.0000000567
        kelvinTemp = kelvinT(tDegC)
        res = STEFAN_BOLTZMANNconst * emissivity *  (kelvinTemp ** 4)
    END FUNCTION longWaveRadn

    FUNCTION boundaryLayerConductanceF(TNew_zb, &
        tMean, &
        potE, &
        potET, &
        airPressure, &
        canopyHeight, &
        windSpeed, &
        instrumentHeight) RESULT(BoundaryLayerCond)
        IMPLICIT NONE
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: TNew_zb
        REAL, INTENT(IN) :: tMean
        REAL, INTENT(IN) :: potE
        REAL, INTENT(IN) :: potET
        REAL, INTENT(IN) :: airPressure
        REAL, INTENT(IN) :: canopyHeight
        REAL, INTENT(IN) :: windSpeed
        REAL, INTENT(IN) :: instrumentHeight
        REAL:: BoundaryLayerCond
        REAL:: VONK
        REAL:: GRAVITATIONALconst
        REAL:: specificHeatOfAir
        REAL:: EMISSIVITYsurface
        INTEGER:: SURFACEnode
        REAL:: STEFAN_BOLTZMANNconst
        REAL:: SpecificHeatAir
        REAL:: RoughnessFacMomentum
        REAL:: RoughnessFacHeat
        REAL:: d
        REAL:: SurfaceTemperature
        REAL:: PenetrationConstant
        REAL:: kelvinTemp
        REAL:: radiativeConductance
        REAL:: FrictionVelocity
        REAL:: StabilityParam
        REAL:: StabilityCorMomentum
        REAL:: StabilityCorHeat
        REAL:: HeatFluxDensity
        INTEGER:: iteration
        VONK = 0.41
        GRAVITATIONALconst = 9.8
        specificHeatOfAir = 1010.0
        EMISSIVITYsurface = 0.98
        SURFACEnode = 1
        STEFAN_BOLTZMANNconst = 0.0000000567
        SpecificHeatAir = specificHeatOfAir * airDensity(tMean, airPressure)
        RoughnessFacMomentum = 0.13 * canopyHeight
        RoughnessFacHeat = 0.2 * RoughnessFacMomentum
        d = 0.77 * canopyHeight
        SurfaceTemperature = TNew_zb(SURFACEnode+1)
        PenetrationConstant = MAX(0.1, potE) / MAX(0.1, potET)
        kelvinTemp = kelvinT(tMean)
        radiativeConductance = 4.0 * STEFAN_BOLTZMANNconst *  &
                EMISSIVITYsurface * PenetrationConstant *  (kelvinTemp ** 3)
        FrictionVelocity = 0.0
        BoundaryLayerCond = 0.0
        StabilityParam = 0.0
        StabilityCorMomentum = 0.0
        StabilityCorHeat = 0.0
        HeatFluxDensity = 0.0
        iteration = 1
        DO iteration = 1 , 4-1, 1
            FrictionVelocity = Divide(windSpeed * VONK,  &
                    LOG(Divide(instrumentHeight - d + RoughnessFacMomentum,  &
                    RoughnessFacMomentum, 0.0)) + StabilityCorMomentum, 0.0)
            BoundaryLayerCond = Divide(SpecificHeatAir * VONK * FrictionVelocity,  &
                    LOG(Divide(instrumentHeight - d + RoughnessFacHeat, RoughnessFacHeat,  &
                    0.0)) + StabilityCorHeat, 0.0)
            BoundaryLayerCond = BoundaryLayerCond + radiativeConductance
            HeatFluxDensity = BoundaryLayerCond * (SurfaceTemperature - tMean)
            StabilityParam = Divide((-VONK) * instrumentHeight *  &
                    GRAVITATIONALconst * HeatFluxDensity, SpecificHeatAir * kelvinTemp *   &
                    (FrictionVelocity ** 3), 0.0)
            IF(StabilityParam .GT. 0.0) THEN
                StabilityCorHeat = 4.7 * StabilityParam
                StabilityCorMomentum = StabilityCorHeat
            ELSE
                StabilityCorHeat = (-2.0) * LOG((1.0 + SQRT(1.0 - (16.0 *  &
                        StabilityParam))) / 2.0)
                StabilityCorMomentum = 0.6 * StabilityCorHeat
            END IF
        END DO
    END FUNCTION boundaryLayerConductanceF

    FUNCTION airDensity(temperature, &
        AirPressure) RESULT(res)
        IMPLICIT NONE
        REAL, INTENT(IN) :: temperature
        REAL, INTENT(IN) :: AirPressure
        REAL:: res
        REAL:: MWair
        REAL:: RGAS
        REAL:: HPA2PA
        REAL:: kelvinTemp
        MWair = 0.02897
        RGAS = 8.3143
        HPA2PA = 100.0
        kelvinTemp = kelvinT(temperature)
        res = Divide(MWair * AirPressure * HPA2PA, kelvinTemp * RGAS, 0.0)
    END FUNCTION airDensity

    FUNCTION doThomas(newTemps, &
        soilTemp, &
        thermalConductivity, &
        thermalConductance, &
        DEPTHApsim, &
        volSpecHeatSoil, &
        gDt, &
        netRadiation, &
        potE, &
        actE, &
        numNodes, &
        netRadiationSource) RESULT(newTemps)
        IMPLICIT NONE
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: newTemps
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: soilTemp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: thermalConductivity
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: thermalConductance
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: DEPTHApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: volSpecHeatSoil
        REAL, INTENT(IN) :: gDt
        REAL, INTENT(IN) :: netRadiation
        REAL, INTENT(IN) :: potE
        REAL, INTENT(IN) :: actE
        INTEGER, INTENT(IN) :: numNodes
        CHARACTER(65), INTENT(IN) :: netRadiationSource
        REAL:: nu
        INTEGER:: AIRnode
        INTEGER:: SURFACEnode
        REAL:: MJ2J
        REAL:: latentHeatOfVapourisation
        REAL:: tempStepSec
        INTEGER:: I
        REAL, ALLOCATABLE , DIMENSION(:):: heatStorage
        REAL:: VolSoilAtNode
        REAL:: elementLength
        REAL:: g
        REAL:: sensibleHeatFlux
        REAL:: RadnNet
        REAL:: LatentHeatFlux
        REAL:: SoilSurfaceHeatFlux
        REAL, ALLOCATABLE , DIMENSION(:):: a
        REAL, ALLOCATABLE , DIMENSION(:):: b
        REAL, ALLOCATABLE , DIMENSION(:):: c
        REAL, ALLOCATABLE , DIMENSION(:):: d
        INTEGER:: node
        nu = 0.6
        AIRnode = 0
        SURFACEnode = 1
        MJ2J = 1000000.0
        latentHeatOfVapourisation = 2465000.0
        tempStepSec = 24.0 * 60.0 * 60.0
        g = 1 - nu
        node = SURFACEnode
        heatStorage = (/0./)
        a = (/0.0/)
        b = (/0.0/)
        c = (/0.0/)
        d = (/0.0/)
        DO I = 0 , numNodes + 1-1, 1
            call Add(a, 0.0)
            call Add(b, 0.0)
            call Add(c, 0.0)
            call Add(d, 0.0)
            call Add(heatStorage, 0.0)
        END DO
        call Add(a, 0.0)
        thermalConductance = 0.
        thermalConductance(AIRnode+1) = thermalConductivity(AIRnode+1)
        DO node = SURFACEnode , numNodes + 1-1, 1
            VolSoilAtNode = 0.5 * (DEPTHApsim(node + 1+1) - DEPTHApsim(node -  &
                    1+1))
            heatStorage(node+1) = Divide(volSpecHeatSoil(node+1) * VolSoilAtNode,  &
                    gDt, 0.0)
            elementLength = DEPTHApsim(node + 1+1) - DEPTHApsim(node+1)
            thermalConductance(node+1) = Divide(thermalConductivity(node+1),  &
                    elementLength, 0.0)
        END DO
        DO node = SURFACEnode , numNodes + 1-1, 1
            c(node+1) = (-nu) * thermalConductance(node+1)
            a(node + 1+1) = c(node+1)
            b(node+1) = nu * (thermalConductance(node+1) +  &
                    thermalConductance(node - 1+1)) + heatStorage(node+1)
            d(node+1) = g * thermalConductance((node - 1)+1) * soilTemp((node -  &
                    1)+1) + ((heatStorage(node+1) - (g * (thermalConductance(node+1) +  &
                    thermalConductance(node - 1+1)))) * soilTemp(node+1)) + (g *  &
                    thermalConductance(node+1) * soilTemp((node + 1)+1))
        END DO
        a(SURFACEnode+1) = 0.0
        sensibleHeatFlux = nu * thermalConductance(AIRnode+1) *  &
                newTemps(AIRnode+1)
        RadnNet = 0.0
        IF(netRadiationSource .EQ. 'calc') THEN
            RadnNet = Divide(netRadiation * 1000000.0, gDt, 0.0)
        ELSE IF ( netRadiationSource .EQ. 'eos') THEN
            RadnNet = Divide(potE * latentHeatOfVapourisation, tempStepSec, 0.0)
        END IF
        LatentHeatFlux = Divide(actE * latentHeatOfVapourisation,  &
                tempStepSec, 0.0)
        SoilSurfaceHeatFlux = sensibleHeatFlux + RadnNet - LatentHeatFlux
        d(SURFACEnode+1) = d(SURFACEnode+1) + SoilSurfaceHeatFlux
        d(numNodes+1) = d(numNodes+1) + (nu * thermalConductance(numNodes+1)  &
                * newTemps((numNodes + 1)+1))
        DO node = SURFACEnode , numNodes-1, 1
            c(node+1) = Divide(c(node+1), b(node+1), 0.0)
            d(node+1) = Divide(d(node+1), b(node+1), 0.0)
            b(node + 1+1) = b(node + 1+1) - (a((node + 1)+1) * c(node+1))
            d(node + 1+1) = d(node + 1+1) - (a((node + 1)+1) * d(node+1))
        END DO
        newTemps(numNodes+1) = Divide(d(numNodes+1), b(numNodes+1), 0.0)
        DO node = numNodes - 1 , SURFACEnode - 1+1, -1
            newTemps(node+1) = d(node+1) - (c(node+1) * newTemps((node + 1)+1))
        END DO
    END FUNCTION doThomas

    SUBROUTINE doUpdate(tempNew, &
        soilTemp, &
        minSoilTemp, &
        maxSoilTemp, &
        aveSoilTemp, &
        thermalConductivity, &
        boundaryLayerConductance, &
        IterationsPerDay, &
        timeOfDaySecs, &
        gDt, &
        numNodes)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: tempNew
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) :: soilTemp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: minSoilTemp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: maxSoilTemp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: aveSoilTemp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: thermalConductivity
        REAL, INTENT(INOUT) :: boundaryLayerConductance
        INTEGER, INTENT(IN) :: IterationsPerDay
        REAL, INTENT(IN) :: timeOfDaySecs
        REAL, INTENT(IN) :: gDt
        INTEGER, INTENT(IN) :: numNodes
        INTEGER:: SURFACEnode
        INTEGER:: AIRnode
        INTEGER:: node
        SURFACEnode = 1
        AIRnode = 0
        node = 1
        DO node = 0 , SIZE(tempNew)-1, 1
            soilTemp(node+1) = tempNew(node+1)
        END DO
        IF(timeOfDaySecs .LT. (gDt * 1.2)) THEN
            DO node = SURFACEnode , numNodes + 1-1, 1
                minSoilTemp(node+1) = soilTemp(node+1)
                maxSoilTemp(node+1) = soilTemp(node+1)
            END DO
        END IF
        DO node = SURFACEnode , numNodes + 1-1, 1
            IF(soilTemp(node+1) .LT. minSoilTemp(node+1)) THEN
                minSoilTemp(node+1) = soilTemp(node+1)
            ELSE IF ( soilTemp(node+1) .GT. maxSoilTemp(node+1)) THEN
                maxSoilTemp(node+1) = soilTemp(node+1)
            END IF
            aveSoilTemp(node+1) = aveSoilTemp(node+1) + Divide(soilTemp(node+1),  &
                    REAL(IterationsPerDay), 0.0)
        END DO
        boundaryLayerConductance = boundaryLayerConductance +  &
                Divide(thermalConductivity(AIRnode+1), REAL(IterationsPerDay), 0.0)
    END SUBROUTINE doUpdate

    SUBROUTINE doThermalConductivityCoeffs(nbLayers, &
        numNodes, &
        BDApsim, &
        CLAYApsim, &
        thermalCondPar1, &
        thermalCondPar2, &
        thermalCondPar3, &
        thermalCondPar4)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        INTEGER, INTENT(IN) :: nbLayers
        INTEGER, INTENT(IN) :: numNodes
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: BDApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: CLAYApsim
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: thermalCondPar1
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: thermalCondPar2
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: thermalCondPar3
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: thermalCondPar4
        INTEGER:: layer
        INTEGER:: element
        thermalCondPar1 = (/0.0/)
        thermalCondPar2 = (/0.0/)
        thermalCondPar3 = (/0.0/)
        thermalCondPar4 = (/0.0/)
        DO layer = 0 , numNodes + 1-1, 1
            call Add(thermalCondPar1, 0.0)
            call Add(thermalCondPar2, 0.0)
            call Add(thermalCondPar3, 0.0)
            call Add(thermalCondPar4, 0.0)
        END DO
        DO layer = 1 , nbLayers + 2-1, 1
            element = layer
            thermalCondPar1(element+1) = 0.65 - (0.78 * BDApsim(layer+1)) + (0.6  &
                    *  (BDApsim(layer+1) ** 2))
            thermalCondPar2(element+1) = 1.06 * BDApsim(layer+1)
            thermalCondPar3(element+1) = Divide(2.6, SQRT(CLAYApsim(layer+1)),  &
                    0.0)
            thermalCondPar3(element+1) = 1.0 + thermalCondPar3(element+1)
            thermalCondPar4(element+1) = 0.03 + (0.1 *  (BDApsim(layer+1) ** 2))
        END DO
    END SUBROUTINE doThermalConductivityCoeffs

    FUNCTION CalcSoilTemp(THICKApsim, &
        tav, &
        tamp, &
        doy, &
        latitude, &
        numNodes) RESULT(soilTempIO)
        IMPLICIT NONE
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: THICKApsim
        REAL, INTENT(IN) :: tav
        REAL, INTENT(IN) :: tamp
        INTEGER, INTENT(IN) :: doy
        REAL, INTENT(IN) :: latitude
        INTEGER, INTENT(IN) :: numNodes
        REAL, ALLOCATABLE , DIMENSION(:):: soilTempIO
        REAL, ALLOCATABLE , DIMENSION(:):: cumulativeDepth
        REAL, ALLOCATABLE , DIMENSION(:):: soilTemperat
        INTEGER:: Layer
        INTEGER:: nodes
        REAL:: tempValue
        REAL:: w
        REAL:: dh
        REAL:: zd
        REAL:: offset
        INTEGER:: SURFACEnode
        REAL:: piVal
        SURFACEnode = 1
        piVal = 3.141592653589793
        cumulativeDepth = (/0.0/)
        DO Layer = 0 , SIZE(THICKApsim)-1, 1
            call Add(cumulativeDepth, 0.0)
        END DO
        IF(SIZE(THICKApsim) .GT. 0) THEN
            cumulativeDepth(1) = THICKApsim(1)
            DO Layer = 1 , SIZE(THICKApsim)-1, 1
                cumulativeDepth(Layer+1) = THICKApsim(Layer+1) +  &
                        cumulativeDepth(Layer - 1+1)
            END DO
        END IF
        w = piVal
        w = 2.0 * w
        w = w / (365.25 * 24.0 * 3600.0)
        dh = 0.6
        zd = SQRT(2 * dh / w)
        offset = 0.25
        IF(latitude .GT. 0.0) THEN
            offset = -0.25
        END IF
        soilTemperat = (/0.0/)
        soilTempIO = (/0.0/)
        DO Layer = 0 , numNodes + 1-1, 1
            call Add(soilTemperat, 0.0)
            call Add(soilTempIO, 0.0)
        END DO
        DO nodes = 1 , numNodes + 1-1, 1
            soilTemperat(nodes+1) = tav + (tamp * EXP((-1.0) *  &
                    cumulativeDepth(nodes+1) / zd) * SIN(((doy / 365.0 + offset) * 2.0 *  &
                    piVal - (cumulativeDepth(nodes+1) / zd))))
        END DO
        DO Layer = SURFACEnode , numNodes + 1-1, 1
            soilTempIO(Layer+1) = soilTemperat(Layer - 1+1)
        END DO
    END FUNCTION CalcSoilTemp

END MODULE
