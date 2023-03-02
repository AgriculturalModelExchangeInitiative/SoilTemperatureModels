MODULE Calculatesoiltemperaturemod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_calculatesoiltemperature(deepLayerT, &
        lambda_, &
        heatFlux, &
        meanTAir, &
        minTAir, &
        deepLayerT_t1, &
        maxTAir, &
        maxTSoil, &
        minTSoil)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: deepLayerT
        REAL, INTENT(IN) :: lambda_
        REAL, INTENT(IN) :: heatFlux
        REAL, INTENT(IN) :: meanTAir
        REAL, INTENT(IN) :: minTAir
        REAL, INTENT(INOUT) :: deepLayerT_t1
        REAL, INTENT(IN) :: maxTAir
        REAL, INTENT(OUT) :: maxTSoil
        REAL, INTENT(OUT) :: minTSoil
        !- Name: CalculateSoilTemperature -Version: 001, -Time step: 1
        !- Description:
    !            * Title: CalculateSoilTemperature model
    !            * Authors: loic.manceau@inra.fr
    !            * Reference: ('http://biomamodelling.org',)
    !            * Institution: INRA
    !            * ExtendedDescription: Calculation of minimum and maximum Soil temperature, Further used in shoot temperature estimate.
    !            * ShortDescription: None
        !- inputs:
    !            * name: deepLayerT
    !                          ** description : Temperature of the last soil layer
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 80
    !                          ** min : -30
    !                          ** default : 20
    !                          ** unit : °C
    !            * name: lambda_
    !                          ** description : Latente heat of water vaporization at 20°C
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 10
    !                          ** min : 0
    !                          ** default : 2.454
    !                          ** unit : MJ.kg-1
    !            * name: heatFlux
    !                          ** description : Soil Heat Flux from Energy Balance Component
    !                          ** inputtype : variable
    !                          ** variablecategory : rate
    !                          ** datatype : DOUBLE
    !                          ** max : 100
    !                          ** min : 0
    !                          ** default : 50
    !                          ** unit : g m-2 d-1
    !            * name: meanTAir
    !                          ** description : Mean Air Temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 80
    !                          ** min : -30
    !                          ** default : 22
    !                          ** unit : °C
    !            * name: minTAir
    !                          ** description : Minimum Air Temperature from Weather files
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 80
    !                          ** min : -30
    !                          ** default : 20
    !                          ** unit : °C
    !            * name: deepLayerT_t1
    !                          ** description : Temperature of the last soil layer
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 80
    !                          ** min : -30
    !                          ** default : 20
    !                          ** unit : °C
    !            * name: maxTAir
    !                          ** description : Maximum Air Temperature from Weather Files
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 80
    !                          ** min : -30
    !                          ** default : 25
    !                          ** unit : °C
        !- outputs:
    !            * name: deepLayerT_t1
    !                          ** description : Temperature of the last soil layer
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 80
    !                          ** min : -30
    !                          ** unit : °C
    !            * name: maxTSoil
    !                          ** description : Maximum Soil Temperature
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 80
    !                          ** min : -30
    !                          ** unit : °C
    !            * name: minTSoil
    !                          ** description : Minimum Soil Temperature
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 80
    !                          ** min : -30
    !                          ** unit : °C
        IF(maxTAir .EQ. REAL(-999) .AND. minTAir .EQ. REAL(999)) THEN
            minTSoil = REAL(999)
            maxTSoil = REAL(-999)
            deepLayerT_t1 = 0.0
        ELSE
            minTSoil = SoilMinimumTemperature(maxTAir, meanTAir, minTAir,  &
                    heatFlux, lambda_, deepLayerT)
            maxTSoil = SoilMaximumTemperature(maxTAir, meanTAir, minTAir,  &
                    heatFlux, lambda_, deepLayerT_t1)
            deepLayerT_t1 = UpdateTemperature(minTSoil, maxTSoil, deepLayerT)
        END IF
    END SUBROUTINE model_calculatesoiltemperature

    FUNCTION SoilTempB(weatherMinTemp, &
        deepTemperature) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: weatherMinTemp
        REAL, INTENT(IN) :: deepTemperature
        INTEGER:: i_cyml_r
        res_cyml = (weatherMinTemp + deepTemperature) / 2.0
    END FUNCTION SoilTempB

    FUNCTION SoilTempA(weatherMaxTemp, &
        weatherMeanTemp, &
        soilHeatFlux, &
        lambda_) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: weatherMaxTemp
        REAL, INTENT(IN) :: weatherMeanTemp
        REAL, INTENT(IN) :: soilHeatFlux
        REAL, INTENT(IN) :: lambda_
        INTEGER:: i_cyml_r
        REAL:: TempAdjustment
        REAL:: SoilAvailableEnergy
        IF (weatherMeanTemp .LT. 8.0) THEN
            TempAdjustment=(-0.5) * weatherMeanTemp + 4.0
        ELSE
            TempAdjustment=REAL(0)
        END IF
        SoilAvailableEnergy = soilHeatFlux * lambda_ / 1000
        res_cyml = weatherMaxTemp + (11.2 * (1.0 - EXP((-0.07) *  &
                (SoilAvailableEnergy - 5.5)))) + TempAdjustment
    END FUNCTION SoilTempA

    FUNCTION SoilMinimumTemperature(weatherMaxTemp, &
        weatherMeanTemp, &
        weatherMinTemp, &
        soilHeatFlux, &
        lambda_, &
        deepTemperature) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: weatherMaxTemp
        REAL, INTENT(IN) :: weatherMeanTemp
        REAL, INTENT(IN) :: weatherMinTemp
        REAL, INTENT(IN) :: soilHeatFlux
        REAL, INTENT(IN) :: lambda_
        REAL, INTENT(IN) :: deepTemperature
        INTEGER:: i_cyml_r
        res_cyml = MIN(SoilTempA(weatherMaxTemp, weatherMeanTemp,  &
                soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature))
    END FUNCTION SoilMinimumTemperature

    FUNCTION SoilMaximumTemperature(weatherMaxTemp, &
        weatherMeanTemp, &
        weatherMinTemp, &
        soilHeatFlux, &
        lambda_, &
        deepTemperature) RESULT(res_cyml)
        IMPLICIT NONE
        REAL, INTENT(IN) :: weatherMaxTemp
        REAL, INTENT(IN) :: weatherMeanTemp
        REAL, INTENT(IN) :: weatherMinTemp
        REAL, INTENT(IN) :: soilHeatFlux
        REAL, INTENT(IN) :: lambda_
        REAL, INTENT(IN) :: deepTemperature
        INTEGER:: i_cyml_r
        res_cyml = MAX(SoilTempA(weatherMaxTemp, weatherMeanTemp,  &
                soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature))
    END FUNCTION SoilMaximumTemperature

    FUNCTION UpdateTemperature(minSoilTemp, &
        maxSoilTemp, &
        Temperature) RESULT(Temperature)
        IMPLICIT NONE
        REAL, INTENT(IN) :: minSoilTemp
        REAL, INTENT(IN) :: maxSoilTemp
        REAL, INTENT(INOUT) :: Temperature
        REAL:: Temperature
        INTEGER:: i_cyml_r
        REAL:: meanTemp
        meanTemp = (minSoilTemp + maxSoilTemp) / 2.0
        Temperature = (9.0 * Temperature + meanTemp) / 10.0
    END FUNCTION UpdateTemperature

END MODULE
