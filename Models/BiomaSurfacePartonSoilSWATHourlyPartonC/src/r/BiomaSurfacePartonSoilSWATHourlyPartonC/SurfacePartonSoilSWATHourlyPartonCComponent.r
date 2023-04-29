library(gsubfn)
library (gsubfn) 
setwd('D:/Docs/AMEI_Workshop/AMEI_10_14_2022/Models/BiomaSurfacePartonSoilSWATHourlyPartonC/src/r')
source('Surfacetemperatureparton.r')
source('Soiltemperatureswat.r')
source('Volumetricheatcapacitykluitenberg.r')
source('Thermalconductivitysimulat.r')
source('Thermaldiffu.r')
source('Rangeofsoiltemperaturesdaycent.r')
source('Hourlysoiltemperaturespartonlogan.r')

model_surfacepartonsoilswathourlypartonc <- function (GlobalSolarRadiation,
         DayLength,
         AboveGroundBiomass,
         AirTemperatureMinimum,
         AirTemperatureMaximum,
         VolumetricWaterContent,
         BulkDensity,
         LayerThickness,
         LagCoefficient,
         AirTemperatureAnnualAverage,
         SoilProfileDepth,
         Sand,
         OrganicMatter,
         Clay,
         Silt,
         HourOfSunrise,
         HourOfSunset){
    #'- Name: SurfacePartonSoilSWATHourlyPartonC -Version: 001, -Time step: 1
    #'- Description:
    #'            * Title: SurfacePartonSoilSWATHourlyPartonC model
    #'            * Authors: simone.bregaglio@unimi.it
    #'            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    #'            * Institution: Universiy Of Milan
    #'            * ExtendedDescription: Composite strategy for the calculation of surface temperature with Parton's method and soil temperature with SWAT method. See also references of the associated strategies.
    #'            * ShortDescription: None
    #'- inputs:
    #'            * name: GlobalSolarRadiation
    #'                          ** description : Daily global solar radiation
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 50
    #'                          ** min : 0
    #'                          ** default : 15
    #'                          ** unit : Mj m-2 d-1
    #'            * name: DayLength
    #'                          ** description : Length of the day
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 24
    #'                          ** min : 0
    #'                          ** default : 10
    #'                          ** unit : h
    #'            * name: AboveGroundBiomass
    #'                          ** description : Above ground biomass
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** max : 60
    #'                          ** min : 0
    #'                          ** default : 3
    #'                          ** unit : Kg ha-1
    #'            * name: AirTemperatureMinimum
    #'                          ** description : Minimum daily air temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 50
    #'                          ** min : -60
    #'                          ** default : 5
    #'                          ** unit : Â°C
    #'            * name: AirTemperatureMaximum
    #'                          ** description : Maximum daily air temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 60
    #'                          ** min : -40
    #'                          ** default : 15
    #'                          ** unit : Â°C
    #'            * name: VolumetricWaterContent
    #'                          ** description : Volumetric soil water content
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 0.8
    #'                          ** min : 0
    #'                          ** default : 0.25
    #'                          ** unit : m3 m-3
    #'            * name: BulkDensity
    #'                          ** description : Bulk density
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 1.8
    #'                          ** min : 0.9
    #'                          ** default : 1.3
    #'                          ** unit : t m-3
    #'            * name: LayerThickness
    #'                          ** description : Soil layer thickness
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 3
    #'                          ** min : 0.005
    #'                          ** default : 0.05
    #'                          ** unit : m
    #'            * name: LagCoefficient
    #'                          ** description : Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** max : 1
    #'                          ** min : 0
    #'                          ** default : 0.8
    #'                          ** unit : dimensionless
    #'            * name: AirTemperatureAnnualAverage
    #'                          ** description : Annual average air temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 50
    #'                          ** min : -40
    #'                          ** default : 15
    #'                          ** unit : Â°C
    #'            * name: SoilProfileDepth
    #'                          ** description : Soil profile depth
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** max : 50
    #'                          ** min : 0
    #'                          ** default : 3
    #'                          ** unit : m
    #'            * name: Sand
    #'                          ** description : Sand content of soil layer
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 100
    #'                          ** min : 0
    #'                          ** default : 30
    #'                          ** unit : %
    #'            * name: OrganicMatter
    #'                          ** description : Organic matter content of soil layer
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 20
    #'                          ** min : 0
    #'                          ** default : 1.5
    #'                          ** unit : %
    #'            * name: Clay
    #'                          ** description : Clay content of soil layer
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 100
    #'                          ** min : 0
    #'                          ** default : 0
    #'                          ** unit : %
    #'            * name: Silt
    #'                          ** description : Silt content of soil layer
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 100
    #'                          ** min : 0
    #'                          ** default : 20
    #'                          ** unit : %
    #'            * name: HourOfSunrise
    #'                          ** description : Hour of sunrise
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 24
    #'                          ** min : 0
    #'                          ** default : 6
    #'                          ** unit : h
    #'            * name: HourOfSunset
    #'                          ** description : Hour of sunset
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 24
    #'                          ** min : 0
    #'                          ** default : 17
    #'                          ** unit : h
    #'- outputs:
    #'            * name: SurfaceSoilTemperature
    #'                          ** description : Average surface soil temperature
    #'                          ** datatype : DOUBLE
    #'                          ** variablecategory : state
    #'                          ** max : 60
    #'                          ** min : -60
    #'                          ** unit : Â°C
    #'            * name: SurfaceTemperatureMinimum
    #'                          ** description : Minimum surface soil temperature
    #'                          ** datatype : DOUBLE
    #'                          ** variablecategory : auxiliary
    #'                          ** max : 60
    #'                          ** min : -60
    #'                          ** unit : Â°C
    #'            * name: SurfaceTemperatureMaximum
    #'                          ** description : Maximum surface soil temperature
    #'                          ** datatype : DOUBLE
    #'                          ** variablecategory : auxiliary
    #'                          ** max : 60
    #'                          ** min : -60
    #'                          ** unit : Â°C
    #'            * name: SoilTemperatureByLayers
    #'                          ** description : Soil temperature of each layer
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 
    #'                          ** max : 60
    #'                          ** min : -60
    #'                          ** unit : Â°C
    #'            * name: HeatCapacity
    #'                          ** description : Volumetric specific heat of soil
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 
    #'                          ** max : 300
    #'                          ** min : 0
    #'                          ** unit : MJ m-3 Â°C-1
    #'            * name: ThermalConductivity
    #'                          ** description : Thermal conductivity of soil layer
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 
    #'                          ** max : 8
    #'                          ** min : 0.025
    #'                          ** unit : W m-1 K-1
    #'            * name: ThermalDiffusivity
    #'                          ** description : Thermal diffusivity of soil layer
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 
    #'                          ** max : 1
    #'                          ** min : 0
    #'                          ** unit : mm s-1
    #'            * name: SoilTemperatureRangeByLayers
    #'                          ** description : Soil temperature range by layers
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 
    #'                          ** max : 50
    #'                          ** min : 0
    #'                          ** unit : Â°C
    #'            * name: SoilTemperatureMinimum
    #'                          ** description : Minimum soil temperature by layers
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 
    #'                          ** max : 60
    #'                          ** min : -60
    #'                          ** unit : Â°C
    #'            * name: SoilTemperatureMaximum
    #'                          ** description : Maximum soil temperature by layers
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 
    #'                          ** max : 60
    #'                          ** min : -60
    #'                          ** unit : Â°C
    #'            * name: SoilTemperatureByLayersHourly
    #'                          ** description : Hourly soil temperature by layers
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 
    #'                          ** max : 50
    #'                          ** min : -50
    #'                          ** unit : Â°C
    SoilTemperatureByLayers<- vector()
    HeatCapacity<- vector()
    ThermalConductivity<- vector()
    ThermalDiffusivity<- vector()
    SoilTemperatureRangeByLayers<- vector()
    SoilTemperatureMinimum<- vector()
    SoilTemperatureMaximum<- vector()
    SoilTemperatureByLayersHourly<- vector()
    list[SurfaceSoilTemperature, SurfaceTemperatureMinimum, SurfaceTemperatureMaximum] <- model_surfacetemperatureparton(GlobalSolarRadiation, DayLength, AboveGroundBiomass, AirTemperatureMinimum, AirTemperatureMaximum)
    HeatCapacity <- model_volumetricheatcapacitykluitenberg(VolumetricWaterContent, Sand, BulkDensity, OrganicMatter, HeatCapacity, Clay, Silt)
    ThermalConductivity <- model_thermalconductivitysimulat(VolumetricWaterContent, BulkDensity, Clay)
    SoilTemperatureByLayers <- model_soiltemperatureswat(VolumetricWaterContent, SurfaceSoilTemperature, BulkDensity, LayerThickness, LagCoefficient, SoilTemperatureByLayers, AirTemperatureAnnualAverage, SoilProfileDepth)
    ThermalDiffusivity <- model_thermaldiffu(ThermalDiffusivity, ThermalConductivity, HeatCapacity)
    list[SoilTemperatureRangeByLayers, SoilTemperatureMinimum, SoilTemperatureMaximum] <- model_rangeofsoiltemperaturesdaycent(LayerThickness, SurfaceTemperatureMinimum, ThermalDiffusivity, SoilTemperatureByLayers, SurfaceTemperatureMaximum)
    SoilTemperatureByLayersHourly <- model_hourlysoiltemperaturespartonlogan(SoilTemperatureByLayersHourly, HourOfSunrise, HourOfSunset, DayLength, SoilTemperatureMinimum, SoilTemperatureMaximum)
    return (list ("SurfaceSoilTemperature" = SurfaceSoilTemperature,"SurfaceTemperatureMinimum" = SurfaceTemperatureMinimum,"SurfaceTemperatureMaximum" = SurfaceTemperatureMaximum,"SoilTemperatureByLayers" = SoilTemperatureByLayers,"HeatCapacity" = HeatCapacity,"ThermalConductivity" = ThermalConductivity,"ThermalDiffusivity" = ThermalDiffusivity,"SoilTemperatureRangeByLayers" = SoilTemperatureRangeByLayers,"SoilTemperatureMinimum" = SoilTemperatureMinimum,"SoilTemperatureMaximum" = SoilTemperatureMaximum,"SoilTemperatureByLayersHourly" = SoilTemperatureByLayersHourly))
}