MODULE Stemp_epicmod
    USE list_sub
    IMPLICIT NONE
CONTAINS

    SUBROUTINE init_stemp_epic(NL, &
        ISWWAT, &
        BD, &
        DLAYR, &
        DS, &
        DUL, &
        LL, &
        NLAYR, &
        TAMP, &
        RAIN, &
        SW, &
        TAVG, &
        TMAX, &
        TMIN, &
        TAV, &
        DEPIR, &
        BIOMAS, &
        MULCHMASS, &
        SNOW, &
        CUMDPT, &
        DSMID, &
        TMA, &
        NDays, &
        WetDay, &
        X2_PREV, &
        SRFTEMP, &
        ST)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        INTEGER, INTENT(IN) :: NL
        CHARACTER, INTENT(IN) :: ISWWAT
        REAL , DIMENSION(NL ), INTENT(IN) :: BD
        REAL , DIMENSION(NL ), INTENT(IN) :: DLAYR
        REAL , DIMENSION(NL ), INTENT(IN) :: DS
        REAL , DIMENSION(NL ), INTENT(IN) :: DUL
        REAL , DIMENSION(NL ), INTENT(IN) :: LL
        INTEGER, INTENT(IN) :: NLAYR
        REAL, INTENT(IN) :: TAMP
        REAL, INTENT(IN) :: RAIN
        REAL , DIMENSION(NL ), INTENT(IN) :: SW
        REAL, INTENT(IN) :: TAVG
        REAL, INTENT(IN) :: TMAX
        REAL, INTENT(IN) :: TMIN
        REAL, INTENT(IN) :: TAV
        REAL, INTENT(IN) :: DEPIR
        REAL, INTENT(IN) :: BIOMAS
        REAL, INTENT(IN) :: MULCHMASS
        REAL, INTENT(IN) :: SNOW
        REAL, INTENT(OUT) :: CUMDPT
        REAL , DIMENSION(NL ), INTENT(OUT) :: DSMID
        REAL , DIMENSION(5 ), INTENT(OUT) :: TMA
        INTEGER, INTENT(OUT) :: NDays
        INTEGER , DIMENSION(30 ), INTENT(OUT) :: WetDay
        REAL, INTENT(OUT) :: X2_PREV
        REAL, INTENT(OUT) :: SRFTEMP
        REAL , DIMENSION(NL ), INTENT(OUT) :: ST
        INTEGER:: I
        INTEGER:: L
        REAL:: ABD
        REAL:: B
        REAL:: DP
        REAL:: FX
        REAL:: PESW
        REAL:: TBD
        REAL:: WW
        REAL:: TDL
        REAL:: TLL
        REAL:: TSW
        REAL:: X2_AVG
        REAL:: WFT
        REAL:: BCV
        REAL:: CV
        REAL:: BCV1
        REAL:: BCV2
        REAL , DIMENSION(NL ):: SWI
        CUMDPT = 0.0
        DSMID = 0.0
        TMA = 0.0
        NDays = 0
        WetDay = 0
        X2_PREV = 0.0
        SRFTEMP = 0.0
        ST = 0.0
        SWI = SW
        TBD = 0.0
        TLL = 0.0
        TSW = 0.0
        TDL = 0.0
        CUMDPT = 0.0
        DO L = 1 , NLAYR + 1-1, 1
            DSMID(L - 1+1) = CUMDPT + (DLAYR((L - 1)+1) * 5.0)
            CUMDPT = CUMDPT + (DLAYR((L - 1)+1) * 10.0)
            TBD = TBD + (BD((L - 1)+1) * DLAYR((L - 1)+1))
            TLL = TLL + (LL((L - 1)+1) * DLAYR((L - 1)+1))
            TSW = TSW + (SWI((L - 1)+1) * DLAYR((L - 1)+1))
            TDL = TDL + (DUL((L - 1)+1) * DLAYR((L - 1)+1))
        END DO
        IF(ISWWAT .EQ. 'Y') THEN
            PESW = MAX(0.0, TSW - TLL)
        ELSE
            PESW = MAX(0.0, TDL - TLL)
        END IF
        ABD = TBD / DS((NLAYR - 1)+1)
        FX = ABD / (ABD + (686.0 * EXP((-5.63 * ABD))))
        DP = 1000.0 + (2500.0 * FX)
        WW = 0.356 - (0.144 * ABD)
        B = LOG(500.0 / DP)
        DO I = 1 , 5 + 1-1, 1
            TMA(I - 1+1) = INT(TAVG * 10000.) / 10000.
        END DO
        X2_AVG = TMA((1 - 1)+1) * 5.0
        DO L = 1 , NLAYR + 1-1, 1
            ST(L - 1+1) = TAVG
        END DO
        WFT = 0.1
        WetDay = 0
        NDays = 0
        CV = MULCHMASS / 1000.
        BCV1 = CV / (CV + EXP(5.3396 - (2.3951 * CV)))
        BCV2 = SNOW / (SNOW + EXP(2.303 - (0.2197 * SNOW)))
        BCV = MAX(BCV1, BCV2)
        DO I = 1 , 8 + 1-1, 1
            call SOILT_EPIC(NL, B, BCV, CUMDPT, DP, DSMID, NLAYR, PESW, TAV,  &
                    TAVG, TMAX, TMIN, 0, WFT, WW,TMA,SRFTEMP,ST,X2_AVG,X2_PREV)
        END DO
    END SUBROUTINE init_stemp_epic

    SUBROUTINE model_stemp_epic(NL, &
        ISWWAT, &
        BD, &
        DLAYR, &
        DS, &
        DUL, &
        LL, &
        NLAYR, &
        TAMP, &
        RAIN, &
        SW, &
        TAVG, &
        TMAX, &
        TMIN, &
        TAV, &
        CUMDPT, &
        DSMID, &
        TMA, &
        NDays, &
        WetDay, &
        X2_PREV, &
        SRFTEMP, &
        ST, &
        DEPIR, &
        BIOMAS, &
        MULCHMASS, &
        SNOW)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        INTEGER, INTENT(IN) :: NL
        CHARACTER, INTENT(IN) :: ISWWAT
        REAL , DIMENSION(NL ), INTENT(IN) :: BD
        REAL , DIMENSION(NL ), INTENT(IN) :: DLAYR
        REAL , DIMENSION(NL ), INTENT(IN) :: DS
        REAL , DIMENSION(NL ), INTENT(IN) :: DUL
        REAL , DIMENSION(NL ), INTENT(IN) :: LL
        INTEGER, INTENT(IN) :: NLAYR
        REAL, INTENT(IN) :: TAMP
        REAL, INTENT(IN) :: RAIN
        REAL , DIMENSION(NL ), INTENT(IN) :: SW
        REAL, INTENT(IN) :: TAVG
        REAL, INTENT(IN) :: TMAX
        REAL, INTENT(IN) :: TMIN
        REAL, INTENT(IN) :: TAV
        REAL, INTENT(INOUT) :: CUMDPT
        REAL , DIMENSION(NL ), INTENT(INOUT) :: DSMID
        REAL , DIMENSION(5 ), INTENT(INOUT) :: TMA
        INTEGER, INTENT(INOUT) :: NDays
        INTEGER , DIMENSION(30 ), INTENT(INOUT) :: WetDay
        REAL, INTENT(INOUT) :: X2_PREV
        REAL, INTENT(INOUT) :: SRFTEMP
        REAL , DIMENSION(NL ), INTENT(INOUT) :: ST
        REAL, INTENT(IN) :: DEPIR
        REAL, INTENT(IN) :: BIOMAS
        REAL, INTENT(IN) :: MULCHMASS
        REAL, INTENT(IN) :: SNOW
        INTEGER:: I
        INTEGER:: L
        INTEGER:: NWetDays
        REAL:: ABD
        REAL:: B
        REAL:: DP
        REAL:: FX
        REAL:: PESW
        REAL:: TBD
        REAL:: WW
        REAL:: TDL
        REAL:: TLL
        REAL:: TSW
        REAL:: X2_AVG
        REAL:: WFT
        REAL:: BCV
        REAL:: CV
        REAL:: BCV1
        REAL:: BCV2
        !- Name: STEMP_EPIC -Version:  1.0, -Time step:  1
        !- Description:
    !            * Title: Model of STEMP_EPIC
    !            * Authors: Kenneth N. Potter , Jimmy R. Williams 
    !            * Reference: https://doi.org/10.2134/agronj1994.00021962008600060014x
    !            * Institution: USDA-ARS, USDA-ARS
    !            * ExtendedDescription: None
    !            * ShortDescription: Determines soil temperature by layer test encore
        !- inputs:
    !            * name: NL
    !                          ** description : Number of soil layers
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : dimensionless
    !            * name: ISWWAT
    !                          ** description : Water simulation control switch (Y or N)
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : STRING
    !                          ** max : 
    !                          ** min : 
    !                          ** default : Y
    !                          ** unit : dimensionless
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
    !            * name: DLAYR
    !                          ** description : Thickness of soil layer NL
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : cm
    !            * name: DS
    !                          ** description : Cumulative depth in soil layer NL
    !                          ** inputtype : parameter
    !                          ** parametercategory : soil
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : cm
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
    !            * name: LL
    !                          ** description : Volumetric soil water content in soil layer NL at lower limit
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
    !            * name: TAMP
    !                          ** description : Annual amplitude of the average air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
    !            * name: RAIN
    !                          ** description : daily rainfall
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: SW
    !                          ** description : Volumetric soil water content in layer NL
    !                          ** inputtype : parameter
    !                          ** parametercategory : soil
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : cm3 [water] / cm3 [soil]
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
    !            * name: TMIN
    !                          ** description : Minimum Temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
    !            * name: TAV
    !                          ** description : Average annual soil temperature, used with TAMP to calculate soil temperature.
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
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
    !            * name: DSMID
    !                          ** description : Depth to midpoint of soil layer NL
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : cm
    !            * name: TMA
    !                          ** description : Array of previous 5 days of average soil temperatures.
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 5
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
    !            * name: NDays
    !                          ** description : Number of days ...
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : INT
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : day
    !            * name: WetDay
    !                          ** description : Wet Days
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : INTARRAY
    !                          ** len : 30
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : day
    !            * name: X2_PREV
    !                          ** description : Temperature of soil surface at precedent timestep
    !                          ** inputtype : variable
    !                          ** variablecategory : state
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
    !            * name: ST
    !                          ** description : Soil temperature in soil layer NL
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : degC
    !            * name: DEPIR
    !                          ** description : Depth of irrigation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
    !            * name: BIOMAS
    !                          ** description : Biomass
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : kg/ha
    !            * name: MULCHMASS
    !                          ** description : Mulch Mass
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : kg/ha
    !            * name: SNOW
    !                          ** description : Snow cover
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : mm
        !- outputs:
    !            * name: CUMDPT
    !                          ** description : Cumulative depth of soil profile
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : mm
    !            * name: DSMID
    !                          ** description : Depth to midpoint of soil layer NL
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : cm
    !            * name: TMA
    !                          ** description : Array of previous 5 days of average soil temperatures.
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 5
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : degC
    !            * name: NDays
    !                          ** description : Number of days ...
    !                          ** datatype : INT
    !                          ** variablecategory : state
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : day
    !            * name: WetDay
    !                          ** description : Wet Days
    !                          ** datatype : INTARRAY
    !                          ** variablecategory : state
    !                          ** len : 30
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : day
    !            * name: X2_PREV
    !                          ** description : Temperature of soil surface at precedent timestep
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
    !                          ** description : Soil temperature in soil layer NL
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : NL
    !                          ** max : 
    !                          ** min : 
    !                          ** unit : degC
        TBD = 0.0
        TLL = 0.0
        TSW = 0.0
        TDL = 0.0
        DO L = 1 , NLAYR + 1-1, 1
            TBD = TBD + (BD((L - 1)+1) * DLAYR((L - 1)+1))
            TDL = TDL + (DUL((L - 1)+1) * DLAYR((L - 1)+1))
            TLL = TLL + (LL((L - 1)+1) * DLAYR((L - 1)+1))
            TSW = TSW + (SW((L - 1)+1) * DLAYR((L - 1)+1))
        END DO
        ABD = TBD / DS((NLAYR - 1)+1)
        FX = ABD / (ABD + (686.0 * EXP((-5.63 * ABD))))
        DP = 1000.0 + (2500.0 * FX)
        WW = 0.356 - (0.144 * ABD)
        B = LOG(500.0 / DP)
        IF(ISWWAT .EQ. 'Y') THEN
            PESW = MAX(0.0, TSW - TLL)
        ELSE
            PESW = MAX(0.0, TDL - TLL)
        END IF
        IF(NDays .EQ. 30) THEN
            DO I = 1 , 29 + 1-1, 1
                WetDay(I - 1+1) = WetDay(I + 1 - 1+1)
            END DO
        ELSE
            NDays = NDays + 1
        END IF
        IF(RAIN + DEPIR .GT. 1.E-6) THEN
            WetDay(NDays - 1+1) = 1
        ELSE
            WetDay(NDays - 1+1) = 0
        END IF
        NWetDays = sum(WetDay)
        WFT = REAL(NWetDays) / REAL(NDays)
        CV = (BIOMAS + MULCHMASS) / 1000.
        BCV1 = CV / (CV + EXP(5.3396 - (2.3951 * CV)))
        BCV2 = SNOW / (SNOW + EXP(2.303 - (0.2197 * SNOW)))
        BCV = MAX(BCV1, BCV2)
        call SOILT_EPIC(NL, B, BCV, CUMDPT, DP, DSMID, NLAYR, PESW, TAV,  &
                TAVG, TMAX, TMIN, WetDay(NDays - 1+1), WFT,  &
                WW,TMA,SRFTEMP,ST,X2_AVG,X2_PREV)
    END SUBROUTINE model_stemp_epic

    SUBROUTINE SOILT_EPIC(NL, &
        B, &
        BCV, &
        CUMDPT, &
        DP, &
        DSMID, &
        NLAYR, &
        PESW, &
        TAV, &
        TAVG, &
        TMAX, &
        TMIN, &
        WetDay, &
        WFT, &
        WW, &
        TMA, &
        SRFTEMP, &
        ST, &
        X2_AVG, &
        X2_PREV)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        INTEGER, INTENT(IN) :: NL
        REAL, INTENT(IN) :: B
        REAL, INTENT(IN) :: BCV
        REAL, INTENT(IN) :: CUMDPT
        REAL, INTENT(IN) :: DP
        REAL , DIMENSION(NL ), INTENT(IN) :: DSMID
        INTEGER, INTENT(IN) :: NLAYR
        REAL, INTENT(IN) :: PESW
        REAL, INTENT(IN) :: TAV
        REAL, INTENT(IN) :: TAVG
        REAL, INTENT(IN) :: TMAX
        REAL, INTENT(IN) :: TMIN
        INTEGER, INTENT(IN) :: WetDay
        REAL, INTENT(IN) :: WFT
        REAL, INTENT(IN) :: WW
        INTEGER:: K
        INTEGER:: L
        REAL:: DD
        REAL:: FX
        REAL, INTENT(OUT) :: SRFTEMP
        REAL:: WC
        REAL:: ZD
        REAL , DIMENSION(5 ), INTENT(OUT) :: TMA
        REAL , DIMENSION(NL ), INTENT(OUT) :: ST
        REAL:: X1
        REAL:: X2
        REAL:: X3
        REAL:: F
        REAL, INTENT(OUT) :: X2_AVG
        REAL, INTENT(OUT) :: X2_PREV
        REAL:: LAG
        LAG = 0.5
        WC = MAX(0.01, PESW) / (WW * CUMDPT) * 10.0
        FX = EXP(B *  (((1.0 - WC) / (1.0 + WC)) ** 2))
        DD = FX * DP
        IF(WetDay .GT. 0) THEN
            X2 = WFT * (TAVG - TMIN) + TMIN
        ELSE
            X2 = WFT * (TMAX - TAVG) + TAVG + 2.
        END IF
        TMA(1 - 1+1) = X2
        DO K = 5 , 2 - 1+1, -1
            TMA(K - 1+1) = TMA(K - 1 - 1+1)
        END DO
        X2_AVG = sum(TMA) / 5.0
        X3 = (1. - BCV) * X2_AVG + (BCV * X2_PREV)
        SRFTEMP = MIN(X2_AVG, X3)
        X1 = TAV - X3
        DO L = 1 , NLAYR + 1-1, 1
            ZD = DSMID((L - 1)+1) / DD
            F = ZD / (ZD + EXP(-.8669 - (2.0775 * ZD)))
            ST(L - 1+1) = LAG * ST((L - 1)+1) + ((1. - LAG) * (F * X1 + X3))
        END DO
        X2_PREV = X2_AVG
    END SUBROUTINE SOILT_EPIC

END MODULE
