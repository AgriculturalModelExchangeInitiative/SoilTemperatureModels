MODULE Hourlysoiltemperaturespartonloganmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_hourlysoiltemperaturespartonlogan(SoilTemperatureMinimum, &
        DayLength, &
        SoilTemperatureMaximum, &
        HourOfSunset, &
        SoilTemperatureByLayersHourly, &
        HourOfSunrise)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL , DIMENSION(: ), INTENT(IN) :: SoilTemperatureMinimum
        REAL, INTENT(IN) :: DayLength
        REAL , DIMENSION(: ), INTENT(IN) :: SoilTemperatureMaximum
        REAL, INTENT(IN) :: HourOfSunset
        REAL , DIMENSION(: ), INTENT(INOUT) :: SoilTemperatureByLayersHourly
        REAL, INTENT(IN) :: HourOfSunrise
        INTEGER:: h
        INTEGER:: i
        REAL:: TemperatureAtSunset
        !- Name: HourlySoilTemperaturesPartonLogan -Version: 001, -Time step: 1
        !- Description:
    !            * Title: HourlySoilTemperaturesPartonLogan model
    !            * Authors: simone.bregaglio@unimi.it
    !            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    !            * Institution: University Of Milan
    !            * ExtendedDescription: Strategy for the calculation of hourly soil temperature. Reference: Parton, W.J.  and  Logan, J.A.,  1981. A model for diurnal variation  in soil  and  air temperature. Agric. Meteorol., 23: 205-216.
    !            * ShortDescription: None
        !- inputs:
    !            * name: SoilTemperatureMinimum
    !                          ** description : Minimum soil temperature by layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 60
    !                          ** min : -60
    !                          ** default : 15
    !                          ** unit : Â°C
    !            * name: DayLength
    !                          ** description : Length of the day
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 24
    !                          ** min : 0
    !                          ** default : 10
    !                          ** unit : h
    !            * name: SoilTemperatureMaximum
    !                          ** description : Maximum soil temperature by layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 60
    !                          ** min : -60
    !                          ** default : 15
    !                          ** unit : Â°C
    !            * name: HourOfSunset
    !                          ** description : Hour of sunset
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 24
    !                          ** min : 0
    !                          ** default : 17
    !                          ** unit : h
    !            * name: SoilTemperatureByLayersHourly
    !                          ** description : Hourly soil temperature by layers
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 50
    !                          ** min : -50
    !                          ** default : 15
    !                          ** unit : Â°C
    !            * name: HourOfSunrise
    !                          ** description : Hour of sunrise
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 24
    !                          ** min : 0
    !                          ** default : 6
    !                          ** unit : h
        !- outputs:
    !            * name: SoilTemperatureByLayersHourly
    !                          ** description : Hourly soil temperature by layers
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 50
    !                          ** min : -50
    !                          ** unit : Â°C
        DO i = 0 , SIZE(SoilTemperatureMinimum)-1, 1
            DO h = 0 , 24-1, 1
                IF(h .GE. INT(HourOfSunrise) .AND. h .LE. INT(HourOfSunset)) THEN
                    SoilTemperatureByLayersHourly(i * 24 + h+1) =  &
                            SoilTemperatureMinimum(i+1) + ((SoilTemperatureMaximum(i+1) -  &
                            SoilTemperatureMinimum(i+1)) * SIN(3.14159265 * (h - 12 + (DayLength  &
                            / 2)) / (DayLength + (2 * 1.8))))
                END IF
            END DO
            TemperatureAtSunset = SoilTemperatureByLayersHourly(i +  &
                    INT(HourOfSunset)+1)
            DO h = 0 , 24-1, 1
                IF(h .GT. INT(HourOfSunset)) THEN
                    SoilTemperatureByLayersHourly(i + h+1) = (SoilTemperatureMinimum(i+1)  &
                            - (TemperatureAtSunset * EXP((-(24 - DayLength)) / 2.2)) +  &
                            ((TemperatureAtSunset - SoilTemperatureMinimum(i+1)) * EXP((-(h -  &
                            HourOfSunset)) / 2.2))) / (1 - EXP((-(24 - DayLength)) / 2.2))
                ELSE IF ( h .LE. INT(HourOfSunrise)) THEN
                    SoilTemperatureByLayersHourly(i + h+1) = (SoilTemperatureMinimum(i+1)  &
                            - (TemperatureAtSunset * EXP((-(24 - DayLength)) / 2.2)) +  &
                            ((TemperatureAtSunset - SoilTemperatureMinimum(i+1)) * EXP((-(h + 24  &
                            - HourOfSunset)) / 2.2))) / (1 - EXP((-(24 - DayLength)) / 2.2))
                END IF
            END DO
        END DO
    END SUBROUTINE model_hourlysoiltemperaturespartonlogan

END MODULE
