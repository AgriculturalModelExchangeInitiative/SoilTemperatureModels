MODULE Model_soiltempcampbellmod
    USE Campbellmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_model_soiltempcampbell(NLAYR, &
        THICK, &
        DEPTH, &
        CONSTANT_TEMPdepth, &
        BD, &
        T2M, &
        TMAX, &
        TMIN, &
        TAV, &
        TAMP, &
        XLAT, &
        CLAY, &
        SW, &
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
        SLCARB, &
        SLROCK, &
        SLSILT, &
        SLSAND, &
        _boundaryLayerConductance)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        INTEGER, INTENT(IN) :: NLAYR
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: THICK
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: DEPTH
        REAL, INTENT(IN) :: CONSTANT_TEMPdepth
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: BD
        REAL, INTENT(IN) :: T2M
        REAL, INTENT(IN) :: TMAX
        REAL, INTENT(IN) :: TMIN
        REAL, INTENT(IN) :: TAV
        REAL, INTENT(IN) :: TAMP
        REAL, INTENT(IN) :: XLAT
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: CLAY
        REAL , DIMENSION(NLAYR ), INTENT(IN) :: SW
        INTEGER, INTENT(IN) :: DOY
        REAL, INTENT(INOUT) :: airPressure
        REAL, INTENT(IN) :: canopyHeight
        REAL, INTENT(IN) :: SALB
        REAL, INTENT(IN) :: SRAD
        REAL, INTENT(IN) :: ESP
        REAL, INTENT(IN) :: ES
        REAL, INTENT(IN) :: EOAD
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: soilTemp
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: newTemperature
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: minSoilTemp
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: maxSoilTemp
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: aveSoilTemp
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: morningSoilTemp
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: thermalCondPar1
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: thermalCondPar2
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: thermalCondPar3
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: thermalCondPar4
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: thermalConductivity
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: thermalConductance
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: heatStorage
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: volSpecHeatSoil
        REAL, INTENT(INOUT) :: maxTempYesterday
        REAL, INTENT(INOUT) :: minTempYesterday
        REAL, INTENT(IN) :: instrumentHeight
        CHARACTER(65), INTENT(IN) :: boundaryLayerConductanceSource
        CHARACTER(65), INTENT(IN) :: netRadiationSource
        REAL, INTENT(IN) :: windSpeed
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: SLCARB
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: SLROCK
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: SLSILT
        REAL , DIMENSION(NLAYR ), INTENT(INOUT) :: SLSAND
        REAL, INTENT(INOUT) :: cy_boundaryLayerConductance
        !- Name: model_SoilTempCampbell -Version: 1.0, -Time step: 1
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
    !                          ** description : APSIM soil layer depths as thickness of layers
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 1
    !                          ** default : 50
    !                          ** unit : mm
    !            * name: DEPTH
    !                          ** description : APSIM node depths
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
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
    !            * name: BD
    !                          ** description : bd (soil bulk density) is name of the APSIM var for bulk density so set bulkDensity
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 1.4
    !                          ** unit : g/cm3
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
    !                          ** description : Average daily Air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
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
    !            * name: CLAY
    !                          ** description : Proportion of clay in each layer of profile
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 100
    !                          ** min : 0
    !                          ** default : 50
    !                          ** unit : 
    !            * name: SW
    !                          ** description : volumetric water content
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.5
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
    !                          ** variablecategory : state
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
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** default : 
    !                          ** unit : degC
    !            * name: newTemperature
    !                          ** description : Soil temperature at the end of one iteration
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** default : 
    !                          ** unit : degC
    !            * name: minSoilTemp
    !                          ** description : Minimum soil temperature in layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** default : 
    !                          ** unit : degC
    !            * name: maxSoilTemp
    !                          ** description : Maximum soil temperature in layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** default : 
    !                          ** unit : degC
    !            * name: aveSoilTemp
    !                          ** description : Temperature averaged over all time-steps within a day in layers.
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** default : 
    !                          ** unit : degC
    !            * name: morningSoilTemp
    !                          ** description : Temperature  in the morning in layers.
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** default : 
    !                          ** unit : degC
    !            * name: thermalCondPar1
    !                          ** description : thermal conductivity coeff in layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalCondPar2
    !                          ** description : thermal conductivity coeff in layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalCondPar3
    !                          ** description : thermal conductivity coeff in layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalCondPar4
    !                          ** description : thermal conductivity coeff in layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalConductivity
    !                          ** description : thermal conductivity in layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalConductance
    !                          ** description : Thermal conductance between layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : (W/m2/K)
    !            * name: heatStorage
    !                          ** description : Heat storage between layers (internal)
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : J/s/K
    !            * name: volSpecHeatSoil
    !                          ** description : Volumetric specific heat over the soil profile
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
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
    !            * name: SLCARB
    !                          ** description : Volumetric fraction of organic matter in the soil
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: SLROCK
    !                          ** description : Volumetric fraction of rocks in the soil
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: SLSILT
    !                          ** description : Volumetric fraction of silt in the soil
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: SLSAND
    !                          ** description : Volumetric fraction of sand in the soil
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NLAYR
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
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** unit : degC
    !            * name: minSoilTemp
    !                          ** description : Minimum soil temperature in layers
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** unit : degC
    !            * name: maxSoilTemp
    !                          ** description : Maximum soil temperature in layers
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** unit : degC
    !            * name: aveSoilTemp
    !                          ** description : Temperature averaged over all time-steps within a day in layers.
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** unit : degC
    !            * name: morningSoilTemp
    !                          ** description : Temperature  in the morning in layers.
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
    !                          ** max : 60.
    !                          ** min : -60.
    !                          ** unit : degC
    !            * name: newTemperature
    !                          ** description : Soil temperature at the end of one iteration
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
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
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalCondPar2
    !                          ** description : thermal conductivity coeff in layers
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalCondPar3
    !                          ** description : thermal conductivity coeff in layers
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalCondPar4
    !                          ** description : thermal conductivity coeff in layers
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalConductivity
    !                          ** description : thermal conductivity in layers
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : (W/m2/K)
    !            * name: thermalConductance
    !                          ** description : Thermal conductance between layers
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : (W/m2/K)
    !            * name: heatStorage
    !                          ** description : Heat storage between layers (internal)
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : J/s/K
    !            * name: volSpecHeatSoil
    !                          ** description : Volumetric specific heat over the soil profile
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
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
    !            * name: SLROCK
    !                          ** description : Volumetric fraction of rocks in the soil
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : 
    !            * name: SLCARB
    !                          ** description : Volumetric fraction of organic matter in the soil
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : 
    !            * name: SLSAND
    !                          ** description : Volumetric fraction of sand in the soil
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : 
    !            * name: SLSILT
    !                          ** description : Volumetric fraction of silt in the soil
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NLAYR
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : 
    !            * name: airPressure
    !                          ** description : Air pressure
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : hPA
        call model_campbell(NLAYR, THICK, DEPTH, CONSTANT_TEMPdepth, BD, T2M,  &
                TMAX, TMIN, TAV, TAMP, XLAT, CLAY, SW, DOY, airPressure,  &
                canopyHeight, SALB, SRAD, ESP, ES, EOAD, soilTemp, newTemperature,  &
                minSoilTemp, maxSoilTemp, aveSoilTemp, morningSoilTemp,  &
                thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4,  &
                thermalConductivity, thermalConductance, heatStorage,  &
                volSpecHeatSoil, maxTempYesterday, minTempYesterday,  &
                instrumentHeight, boundaryLayerConductanceSource, netRadiationSource,  &
                windSpeed, SLCARB, SLROCK, SLSILT, SLSAND,  &
                cy_boundaryLayerConductance)
    END SUBROUTINE model_model_soiltempcampbell

END MODULE
