library(gsubfn)

init_rangeofsoiltemperaturesdaycent <- function (LayerThickness){
    SoilTemperatureRangeByLayers<- vector()
    SoilTemperatureMinimum<- vector()
    SoilTemperatureMaximum<- vector()
    SoilTemperatureRangeByLayers <- NULL
    SoilTemperatureMinimum <- NULL
    SoilTemperatureMaximum <- NULL
    SoilTemperatureRangeByLayers <-  rep(0.0,length(LayerThickness))
    SoilTemperatureMaximum <-  rep(0.0,length(LayerThickness))
    SoilTemperatureMinimum <-  rep(0.0,length(LayerThickness))
    return (list ("SoilTemperatureRangeByLayers" = SoilTemperatureRangeByLayers,"SoilTemperatureMinimum" = SoilTemperatureMinimum,"SoilTemperatureMaximum" = SoilTemperatureMaximum))
}

model_rangeofsoiltemperaturesdaycent <- function (LayerThickness,
         SurfaceTemperatureMinimum,
         ThermalDiffusivity,
         SoilTemperatureByLayers,
         SurfaceTemperatureMaximum,
         SoilTemperatureRangeByLayers,
         SoilTemperatureMinimum,
         SoilTemperatureMaximum){
    #'- Name: RangeOfSoilTemperaturesDAYCENT -Version: 001, -Time step: 1
    #'- Description:
    #'            * Title: RangeOfSoilTemperaturesDAYCENT model
    #'            * Authors: simone.bregaglio
    #'            * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
    #'            * Institution: University Of Milan
    #'            * ExtendedDescription: Strategy for the calculation of soil thermal conductivity.Reference: DAYCENT model written in C code
    #'            * ShortDescription: Strategy for the calculation of soil thermal conductivity
    #'- inputs:
    #'            * name: LayerThickness
    #'                          ** description : Soil layer thickness
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 3
    #'                          ** min : 0.005
    #'                          ** default : 0.05
    #'                          ** unit : m
    #'            * name: SurfaceTemperatureMinimum
    #'                          ** description : Minimum surface soil temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : auxiliary
    #'                          ** datatype : DOUBLE
    #'                          ** max : 60
    #'                          ** min : -60
    #'                          ** default : 10
    #'                          ** unit : degC
    #'            * name: ThermalDiffusivity
    #'                          ** description : Thermal diffusivity of soil layer
    #'                          ** inputtype : variable
    #'                          ** variablecategory : auxiliary
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 1
    #'                          ** min : 0
    #'                          ** default : 0.0025
    #'                          ** unit : mm s-1
    #'            * name: SoilTemperatureByLayers
    #'                          ** description : Soil temperature of each layer
    #'                          ** inputtype : variable
    #'                          ** variablecategory : auxiliary
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 60
    #'                          ** min : -60
    #'                          ** default : 15
    #'                          ** unit : degC
    #'            * name: SurfaceTemperatureMaximum
    #'                          ** description : Maximum surface soil temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : auxiliary
    #'                          ** datatype : DOUBLE
    #'                          ** max : 60
    #'                          ** min : -60
    #'                          ** default : 25
    #'                          ** unit : degC
    #'            * name: SoilTemperatureRangeByLayers
    #'                          ** description : Soil temperature range by layers
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 50
    #'                          ** min : 0
    #'                          ** default : 
    #'                          ** unit : degC
    #'            * name: SoilTemperatureMinimum
    #'                          ** description : Minimum soil temperature by layers
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 60
    #'                          ** min : -60
    #'                          ** default : 
    #'                          ** unit : degC
    #'            * name: SoilTemperatureMaximum
    #'                          ** description : Maximum soil temperature by layers
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 60
    #'                          ** min : -60
    #'                          ** default : 
    #'                          ** unit : degC
    #'- outputs:
    #'            * name: SoilTemperatureRangeByLayers
    #'                          ** description : Soil temperature range by layers
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 
    #'                          ** max : 50
    #'                          ** min : 0
    #'                          ** unit : degC
    #'            * name: SoilTemperatureMinimum
    #'                          ** description : Minimum soil temperature by layers
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 
    #'                          ** max : 60
    #'                          ** min : -60
    #'                          ** unit : degC
    #'            * name: SoilTemperatureMaximum
    #'                          ** description : Maximum soil temperature by layers
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 
    #'                          ** max : 60
    #'                          ** min : -60
    #'                          ** unit : degC
    _DepthBottom <- as.double(0)
    _DepthCenterLayer <- as.double(0)
    SurfaceDiurnalRange <- SurfaceTemperatureMaximum - SurfaceTemperatureMinimum
    for( i in seq(0, length(SoilTemperatureByLayers)-1, 1)){
        if (i == 0)
        {
            _DepthCenterLayer <- LayerThickness[1] * 100 / 2
            SoilTemperatureRangeByLayers[1] <- SurfaceDiurnalRange * exp(-_DepthCenterLayer * (0.00005 / ThermalDiffusivity[1]) ^ 0.5)
            SoilTemperatureMaximum[1] <- SoilTemperatureByLayers[1] + (SoilTemperatureRangeByLayers[1] / 2)
            SoilTemperatureMinimum[1] <- SoilTemperatureByLayers[1] - (SoilTemperatureRangeByLayers[1] / 2)
        }
        else
        {
            _DepthBottom <- _DepthBottom + (LayerThickness[(i - 1)+1] * 100)
            _DepthCenterLayer <- _DepthBottom + (LayerThickness[i+1] * 100 / 2)
            SoilTemperatureRangeByLayers[i+1] <- SurfaceDiurnalRange * exp(-_DepthCenterLayer * (0.00005 / ThermalDiffusivity[i+1]) ^ 0.5)
            SoilTemperatureMaximum[i+1] <- SoilTemperatureByLayers[i+1] + (SoilTemperatureRangeByLayers[i+1] / 2)
            SoilTemperatureMinimum[i+1] <- SoilTemperatureByLayers[i+1] - (SoilTemperatureRangeByLayers[i+1] / 2)
        }
    }
    return (list ("SoilTemperatureRangeByLayers" = SoilTemperatureRangeByLayers,"SoilTemperatureMinimum" = SoilTemperatureMinimum,"SoilTemperatureMaximum" = SoilTemperatureMaximum))
}