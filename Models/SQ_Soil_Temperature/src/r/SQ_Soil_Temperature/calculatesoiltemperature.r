library(gsubfn)

init_calculatesoiltemperature <- function (meanTAir,
         minTAir,
         lambda_,
         meanAnnualAirTemp,
         maxTAir){
    deepLayerT <- 20.0
    deepLayerT <- meanAnnualAirTemp
    return( deepLayerT)
}

model_calculatesoiltemperature <- function (meanTAir,
         minTAir,
         lambda_,
         deepLayerT,
         meanAnnualAirTemp,
         heatFlux,
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
    #'            * name: meanTAir
    #'                          ** description : Mean Air Temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** default : 22
    #'                          ** unit : Â°C
    #'            * name: minTAir
    #'                          ** description : Minimum Air Temperature from Weather files
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** default : 20
    #'                          ** unit : Â°C
    #'            * name: lambda_
    #'                          ** description : Latente heat of water vaporization at 20Â°C
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** max : 10
    #'                          ** min : 0
    #'                          ** default : 2.454
    #'                          ** unit : MJ.kg-1
    #'            * name: deepLayerT
    #'                          ** description : Temperature of the last soil layer
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** default : 20
    #'                          ** unit : Â°C
    #'            * name: meanAnnualAirTemp
    #'                          ** description : Annual Mean Air Temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** default : 22
    #'                          ** unit : Â°C
    #'            * name: heatFlux
    #'                          ** description : Soil Heat Flux from Energy Balance Component
    #'                          ** inputtype : variable
    #'                          ** variablecategory : rate
    #'                          ** datatype : DOUBLE
    #'                          ** max : 100
    #'                          ** min : 0
    #'                          ** default : 50
    #'                          ** unit : g m-2 d-1
    #'            * name: maxTAir
    #'                          ** description : Maximum Air Temperature from Weather Files
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** default : 25
    #'                          ** unit : Â°C
    #'- outputs:
    #'            * name: minTSoil
    #'                          ** description : Minimum Soil Temperature
    #'                          ** datatype : DOUBLE
    #'                          ** variablecategory : state
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** unit : Â°C
    #'            * name: deepLayerT
    #'                          ** description : Temperature of the last soil layer
    #'                          ** datatype : DOUBLE
    #'                          ** variablecategory : state
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** unit : Â°C
    #'            * name: maxTSoil
    #'                          ** description : Maximum Soil Temperature
    #'                          ** datatype : DOUBLE
    #'                          ** variablecategory : state
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** unit : Â°C
    tmp <- meanAnnualAirTemp
    if (maxTAir == as.double(-999) && minTAir == as.double(999))
    {
        minTSoil <- as.double(999)
        maxTSoil <- as.double(-999)
        deepLayerT <- 0.0
    }
    else
    {
        minTSoil <- SoilMinimumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT)
        maxTSoil <- SoilMaximumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT)
        deepLayerT <- UpdateTemperature(minTSoil, maxTSoil, deepLayerT)
    }
    return (list ("minTSoil" = minTSoil,"deepLayerT" = deepLayerT,"maxTSoil" = maxTSoil))
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