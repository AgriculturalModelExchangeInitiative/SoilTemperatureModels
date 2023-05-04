MODULE Stemp_mod
    USE Stempmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_stemp_(ST, &
        CUMDPT, &
        HDAY, &
        TAV, &
        DS, &
        TDL, &
        XLAT, &
        SW, &
        SRAD, &
        ISWWAT, &
        DSMID, &
        BD, &
        TMA, &
        TAMP, &
        MSALB, &
        DUL, &
        TAVG, &
        TMAX, &
        SRFTEMP, &
        DLAYR, &
        NL, &
        DOY, &
        ATOT, &
        LL, &
        NLAYR)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL , DIMENSION(NL ), INTENT(INOUT) :: ST
        REAL, INTENT(INOUT) :: CUMDPT
        REAL, INTENT(IN) :: HDAY
        REAL, INTENT(IN) :: TAV
        REAL , DIMENSION(NL ), INTENT(IN) :: DS
        REAL, INTENT(INOUT) :: TDL
        REAL, INTENT(IN) :: XLAT
        REAL , DIMENSION(NL ), INTENT(IN) :: SW
        REAL, INTENT(IN) :: SRAD
        CHARACTER(65), INTENT(IN) :: ISWWAT
        REAL , DIMENSION(NL ), INTENT(INOUT) :: DSMID
        REAL , DIMENSION(NL ), INTENT(IN) :: BD
        REAL , DIMENSION(NL ), INTENT(INOUT) :: TMA
        REAL, INTENT(IN) :: TAMP
        REAL, INTENT(IN) :: MSALB
        REAL , DIMENSION(NL ), INTENT(IN) :: DUL
        REAL, INTENT(IN) :: TAVG
        REAL, INTENT(IN) :: TMAX
        REAL, INTENT(INOUT) :: SRFTEMP
        REAL , DIMENSION(NL ), INTENT(IN) :: DLAYR
        INTEGER, INTENT(IN) :: NL
        INTEGER, INTENT(IN) :: DOY
        REAL, INTENT(INOUT) :: ATOT
        REAL , DIMENSION(NL ), INTENT(IN) :: LL
        INTEGER, INTENT(IN) :: NLAYR
        !- Name: STEMP_ -Version:  1.0, -Time step:  1
        !- Description:
    !            * Title: STEMP_ model
    !            * Authors: DSSAT 
    !            * Reference: https://doi.org/10.2134/agronj1994.00021962008600060014x
    !            * Institution: DSSAT Florida
    !            * ExtendedDescription: None
    !            * ShortDescription: Determines soil temperature by layer
        !- inputs:
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
    !            * name: CUMDPT
    !                          ** description : Cumulative depth of soil profile
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: HDAY
    !                          ** description : Haverst day
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : day
    !            * name: TAV
    !                          ** description : Average annual soil temperature, used with TAMP to calculate soil temperature.
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
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
    !            * name: TDL
    !                          ** description : Total water content of soil at drained upper limit
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : cm
    !            * name: XLAT
    !                          ** description : Latitude
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
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
    !            * name: SRAD
    !                          ** description : Solar radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : MJ/m2-d
    !            * name: ISWWAT
    !                          ** description : Water simulation control switch
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : STRING
    !                          ** max : 
    !                          ** min : 
    !                          ** default : Y
    !                          ** unit : dimensionless
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
    !            * name: TMA
    !                          ** description : Array of previous 5 days of average soil temperatures
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NL
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
    !            * name: MSALB
    !                          ** description : Soil albedo with mulch and soil water effects
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : dimensionless
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
    !            * name: TAVG
    !                          ** description : Average daily temperature
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
    !            * name: SRFTEMP
    !                          ** description : Temperature of soil surface litter
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
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
    !            * name: NL
    !                          ** description : Number of soil layers
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : dimensionless
    !            * name: DOY
    !                          ** description : Current day of simulation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : d
    !            * name: ATOT
    !                          ** description : Sum of TMA array (last 5 days soil temperature)
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
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
    !            * name: NLAYR
    !                          ** description : Actual number of soil layers
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : dimensionless
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
    !                          ** len : NL
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
