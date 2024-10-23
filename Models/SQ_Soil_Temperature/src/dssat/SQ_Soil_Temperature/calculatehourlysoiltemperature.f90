MODULE Calculatehourlysoiltemperaturemod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_calculatehourlysoiltemperature(minTSoil, &
        dayLength, &
        b, &
        a, &
        maxTSoil, &
        c, &
        hourlySoilT)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: minTSoil
        REAL, INTENT(IN) :: dayLength
        REAL, INTENT(IN) :: b
        REAL, INTENT(IN) :: a
        REAL, INTENT(IN) :: maxTSoil
        REAL, INTENT(IN) :: c
        REAL , DIMENSION(24 ), INTENT(OUT) :: hourlySoilT
        INTEGER:: i
        !- Name: CalculateHourlySoilTemperature -Version: 001, -Time step: 1
        !- Description:
    !            * Title: CalculateHourlySoilTemperature model
    !            * Authors: loic.manceau@inra.fr
    !            * Reference: ('http://biomamodelling.org',)
    !            * Institution: INRA
    !            * ExtendedDescription: Calculate Soil temperature on a hourly basis.Parton, W.J. and Logan, J.A., 1981. A model for diurnal variation in soil and air temperature. Agric. Meteorol., 23: 205-216
    !            * ShortDescription: None
        !- inputs:
    !            * name: minTSoil
    !                          ** description : Minimum Soil Temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 80
    !                          ** min : -30
    !                          ** default : 20
    !                          ** unit : Â°C
    !            * name: dayLength
    !                          ** description : Length of the day
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 24
    !                          ** min : 0
    !                          ** default : 12
    !                          ** unit : hour
    !            * name: b
    !                          ** description : Delay between sunrise and time when minimum temperature is reached
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 10
    !                          ** min : 0
    !                          ** default : 1.81
    !                          ** unit : Hour
    !            * name: a
    !                          ** description : Delay between sunset and time when maximum temperature is reached
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 10
    !                          ** min : 0
    !                          ** default : 0.5
    !                          ** unit : Hour
    !            * name: maxTSoil
    !                          ** description : Maximum Soil Temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 80
    !                          ** min : -30
    !                          ** default : 20
    !                          ** unit : Â°C
    !            * name: c
    !                          ** description : Nighttime temperature coefficient
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 10
    !                          ** min : 0
    !                          ** default : 0.49
    !                          ** unit : Dpmensionless
        !- outputs:
    !            * name: hourlySoilT
    !                          ** description : Hourly Soil Temperature
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 24
    !                          ** max : 80
    !                          ** min : -30
    !                          ** unit : Â°C
        IF(maxTSoil .EQ. REAL(-999) .AND. minTSoil .EQ. REAL(999)) THEN
            DO i = 0 , 12-1, 1
                hourlySoilT(i+1) = REAL(999)
            END DO
            DO i = 12 , 24-1, 1
                hourlySoilT(i+1) = REAL(-999)
            END DO
        ELSE
            DO i = 0 , 24-1, 1
                hourlySoilT(i+1) = 0.0
            END DO
            hourlySoilT = getHourlySoilSurfaceTemperature(maxTSoil, minTSoil,  &
                    dayLength, b, a, c)
        END IF
    END SUBROUTINE model_calculatehourlysoiltemperature

    FUNCTION getHourlySoilSurfaceTemperature(TMax, &
        TMin, &
        ady, &
        b, &
        a, &
        c) RESULT(result)
        IMPLICIT NONE
        REAL, INTENT(IN) :: TMax
        REAL, INTENT(IN) :: TMin
        REAL, INTENT(IN) :: ady
        REAL, INTENT(IN) :: b
        REAL, INTENT(IN) :: a
        REAL, INTENT(IN) :: c
        REAL , DIMENSION(: ), ALLOCATABLE :: result
        INTEGER:: i
        REAL:: ahou
        REAL:: ani
        REAL:: bb
        REAL:: be
        REAL:: bbd
        REAL:: ddy
        REAL:: tsn
        ahou = 3.14159265 * (ady / 24.0)
        ani = 24 - ady
        bb = 12 - (ady / 2) + c
        be = 12 + (ady / 2)
        DO i = 0 , 24-1, 1
            IF(i .GE. INT(bb) .AND. i .LE. INT(be)) THEN
                result(i+1) = (TMax - TMin) * SIN(3.14 * (i - bb) / (ady + (2 * a)))  &
                        + TMin
            ELSE
                IF(i .GT. INT(be)) THEN
                    bbd = i - be
                ELSE
                    bbd = 24 + be + i
                END IF
                ddy = ady - c
                tsn = (TMax - TMin) * SIN(3.14 * ddy / (ady + (2 * a))) + TMin
                result(i+1) = TMin + ((tsn - TMin) * EXP((-b) * bbd / ani))
            END IF
        END DO
    END FUNCTION getHourlySoilSurfaceTemperature

END MODULE
