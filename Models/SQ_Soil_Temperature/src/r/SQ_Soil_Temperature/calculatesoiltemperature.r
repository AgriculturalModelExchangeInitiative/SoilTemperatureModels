library(gsubfn)

model_calculatesoiltemperature <- function (deepLayerT,
         lambda_,
         heatFlux,
         meanTAir,
         minTAir,
         deepLayerT_t1,
         maxTAir){
    #'- Name: CalculateSoilTemperature -Version: 001, -Time step: 1
    #'- Description:
    #'            * Title: CalculateSoilTemperature model
    #'            * Authors: loic.manceau@inra.fr
    #'            * Reference: ('http://biomamodelling.org',)
    #'            * Institution: INRA
    #'            * ExtendedDescription: Calculation of minimum and maximum Soil temperature, Further used in shoot temperature estimate.
    #'            * ShortDescription: None
    #'- inputs:
    #'            * name: deepLayerT
    #'                          ** description : Temperature of the last soil layer
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** default : 20
    #'                          ** unit : °C
    #'            * name: lambda_
    #'                          ** description : Latente heat of water vaporization at 20°C
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** max : 10
    #'                          ** min : 0
    #'                          ** default : 2.454
    #'                          ** unit : MJ.kg-1
    #'            * name: heatFlux
    #'                          ** description : Soil Heat Flux from Energy Balance Component
    #'                          ** inputtype : variable
    #'                          ** variablecategory : rate
    #'                          ** datatype : DOUBLE
    #'                          ** max : 100
    #'                          ** min : 0
    #'                          ** default : 50
    #'                          ** unit : g m-2 d-1
    #'            * name: meanTAir
    #'                          ** description : Mean Air Temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** default : 22
    #'                          ** unit : °C
    #'            * name: minTAir
    #'                          ** description : Minimum Air Temperature from Weather files
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** default : 20
    #'                          ** unit : °C
    #'            * name: deepLayerT_t1
    #'                          ** description : Temperature of the last soil layer
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** default : 20
    #'                          ** unit : °C
    #'            * name: maxTAir
    #'                          ** description : Maximum Air Temperature from Weather Files
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** default : 25
    #'                          ** unit : °C
    #'- outputs:
    #'            * name: deepLayerT_t1
    #'                          ** description : Temperature of the last soil layer
    #'                          ** datatype : DOUBLE
    #'                          ** variablecategory : state
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** unit : °C
    #'            * name: maxTSoil
    #'                          ** description : Maximum Soil Temperature
    #'                          ** datatype : DOUBLE
    #'                          ** variablecategory : state
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** unit : °C
    #'            * name: minTSoil
    #'                          ** description : Minimum Soil Temperature
    #'                          ** datatype : DOUBLE
    #'                          ** variablecategory : state
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** unit : °C
    if (maxTAir == as.double(-999) && minTAir == as.double(999))
    {
        minTSoil <- as.double(999)
        maxTSoil <- as.double(-999)
        deepLayerT_t1 <- 0.0
    }
    else
    {
        minTSoil <- SoilMinimumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT)
        maxTSoil <- SoilMaximumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT_t1)
        deepLayerT_t1 <- UpdateTemperature(minTSoil, maxTSoil, deepLayerT)
    }
    return (list ("deepLayerT_t1" = deepLayerT_t1,"maxTSoil" = maxTSoil,"minTSoil" = minTSoil))
}

SoilTempB <- function (weatherMinTemp,
         deepTemperature){
    return( (weatherMinTemp + deepTemperature) / 2.0)
}

SoilTempA <- function (weatherMaxTemp,
         weatherMeanTemp,
         soilHeatFlux,
         lambda_){
    TempAdjustment <-  if (weatherMeanTemp < 8.0)-0.5 * weatherMeanTemp + 4.0 else as.double(0)
    SoilAvailableEnergy <- soilHeatFlux * lambda_ / 1000
    return( weatherMaxTemp + (11.2 * (1.0 - exp(-0.07 * (SoilAvailableEnergy - 5.5)))) + TempAdjustment)
}

SoilMinimumTemperature <- function (weatherMaxTemp,
         weatherMeanTemp,
         weatherMinTemp,
         soilHeatFlux,
         lambda_,
         deepTemperature){
    return( min(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature)))
}

SoilMaximumTemperature <- function (weatherMaxTemp,
         weatherMeanTemp,
         weatherMinTemp,
         soilHeatFlux,
         lambda_,
         deepTemperature){
    return( max(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature)))
}

UpdateTemperature <- function (minSoilTemp,
         maxSoilTemp,
         Temperature){
    meanTemp <- (minSoilTemp + maxSoilTemp) / 2.0
    Temperature <- (9.0 * Temperature + meanTemp) / 10.0
    return( Temperature)
}