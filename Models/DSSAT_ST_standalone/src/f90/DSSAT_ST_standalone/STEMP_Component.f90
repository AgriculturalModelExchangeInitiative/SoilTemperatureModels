MODULE Stemp_mod
    USE Stempmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_stemp_(SRFTEMP, &
        TAMP, &
        XLAT, &
        HDAY, &
        TMA, &
        CUMDPT, &
        ISWWAT, &
        NLAYR, &
        ATOT, &
        DUL, &
        TDL, &
        SRAD, &
        DS, &
        LL, &
        TAV, &
        TMAX, &
        TAVG, &
        BD, &
        DOY, &
        DSMID, &
        MSALB, &
        NL, &
        DLAYR, &
        ST, &
        SW)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(INOUT) :: SRFTEMP
        REAL, INTENT(IN) :: TAMP
        REAL, INTENT(IN) :: XLAT
        REAL, INTENT(IN) :: HDAY
        REAL , DIMENSION(5 ), INTENT(INOUT) :: TMA
        REAL, INTENT(INOUT) :: CUMDPT
        CHARACTER(65), INTENT(IN) :: ISWWAT
        INTEGER, INTENT(IN) :: NLAYR
        REAL, INTENT(INOUT) :: ATOT
        REAL , DIMENSION(NL ), INTENT(IN) :: DUL
        REAL, INTENT(INOUT) :: TDL
        REAL, INTENT(IN) :: SRAD
        REAL , DIMENSION(NL ), INTENT(IN) :: DS
        REAL , DIMENSION(NL ), INTENT(IN) :: LL
        REAL, INTENT(IN) :: TAV
        REAL, INTENT(IN) :: TMAX
        REAL, INTENT(IN) :: TAVG
        REAL , DIMENSION(NL ), INTENT(IN) :: BD
        INTEGER, INTENT(IN) :: DOY
        REAL , DIMENSION(NL ), INTENT(INOUT) :: DSMID
        REAL, INTENT(IN) :: MSALB
        INTEGER, INTENT(IN) :: NL
        REAL , DIMENSION(NL ), INTENT(IN) :: DLAYR
        REAL , DIMENSION(NL ), INTENT(INOUT) :: ST
        REAL , DIMENSION(NL ), INTENT(IN) :: SW
        !- Name: STEMP_ -Version:  1.0, -Time step:  1
        !- Description:
    !            * Title: STEMP_ model
    !            * Authors: DSSAT 
    !            * Reference: https://doi.org/10.2134/agronj1994.00021962008600060014x
    !            * Institution: DSSAT Florida
    !            * ExtendedDescription: None
    !            * ShortDescription: Determines soil temperature by layer
        !- inputs:
    !            * name: SRFTEMP
    !                          ** description : Temperature of soil surface litter
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
    !            * name: TAMP
    !                          ** description : Amplitude of temperature function used to calculate soil temperatures
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
    !            * name: XLAT
    !                          ** description : Latitude
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
    !            * name: HDAY
    !                          ** description : Haverst day
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : day
    !            * name: TMA
    !                          ** description : Array of previous 5 days of average soil temperatures
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 5
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
    !            * name: CUMDPT
    !                          ** description : Cumulative depth of soil profile
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: ISWWAT
    !                          ** description : Water simulation control switch
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : STRING
    !                          ** max : 
    !                          ** min : 
    !                          ** default : Y
    !                          ** unit : dimensionless
    !            * name: NLAYR
    !                          ** description : Actual number of soil layers
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : dimensionless
    !            * name: ATOT
    !                          ** description : Sum of TMA array (last 5 days soil temperature)
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
    !            * name: DUL
    !                          ** description : Volumetric soil water content at Drained Upper Limit in soil layer L
    !                          ** inputtype : parameter
    !                          ** parametercategory : soil
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : cm3[water]/cm3[soil]
    !            * name: TDL
    !                          ** description : Total water content of soil at drained upper limit
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : cm
    !            * name: SRAD
    !                          ** description : Solar radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : MJ/m2-d
    !            * name: DS
    !                          ** description : Cumulative depth in soil layer L
    !                          ** inputtype : parameter
    !                          ** parametercategory : soil
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : cm
    !            * name: LL
    !                          ** description : Volumetric soil water content in soil layer L at lower limit
    !                          ** inputtype : parameter
    !                          ** parametercategory : soil
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : cm3 [water] / cm3 [soil]
    !            * name: TAV
    !                          ** description : Average annual soil temperature, used with TAMP to calculate soil temperature.
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
    !            * name: TMAX
    !                          ** description : Maximum daily temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
    !            * name: TAVG
    !                          ** description : Average daily temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
    !            * name: BD
    !                          ** description : Bulk density, soil layer NL
    !                          ** inputtype : parameter
    !                          ** parametercategory : soil
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : g [soil] / cm3 [soil]
    !            * name: DOY
    !                          ** description : Current day of simulation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : d
    !            * name: DSMID
    !                          ** description : Depth to midpoint of soil layer L
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : cm
    !            * name: MSALB
    !                          ** description : Soil albedo with mulch and soil water effects
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : dimensionless
    !            * name: NL
    !                          ** description : Number of soil layers
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : dimensionless
    !            * name: DLAYR
    !                          ** description : Thickness of soil layer L
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : cm
    !            * name: ST
    !                          ** description : Soil temperature in soil layer L
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
    !            * name: SW
    !                          ** description : Volumetric soil water content in layer L
    !                          ** inputtype : parameter
    !                          ** parametercategory : soil
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : cm3 [water] / cm3 [soil]
        !- outputs:
    !            * name: CUMDPT
    !                          ** description : Cumulative depth of soil profile
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : mm
    !            * name: DSMID
    !                          ** description : Depth to midpoint of soil layer L
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : cm
    !            * name: TDL
    !                          ** description : Total water content of soil at drained upper limit
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : cm
    !            * name: TMA
    !                          ** description : Array of previous 5 days of average soil temperatures
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 5
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : degC
    !            * name: ATOT
    !                          ** description : Sum of TMA array (last 5 days soil temperature)
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : degC
    !            * name: SRFTEMP
    !                          ** description : Temperature of soil surface litter
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : degC
    !            * name: ST
    !                          ** description : Soil temperature in soil layer L
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : degC
        call model_stemp(NL, ISWWAT, BD, DLAYR, DS, DUL, LL, NLAYR, MSALB,  &
                SRAD, SW, TAVG, TMAX, XLAT, TAV, TAMP, CUMDPT, DSMID, TDL, TMA, ATOT,  &
                SRFTEMP, ST, DOY, HDAY)
    END SUBROUTINE model_stemp_

END MODULE
