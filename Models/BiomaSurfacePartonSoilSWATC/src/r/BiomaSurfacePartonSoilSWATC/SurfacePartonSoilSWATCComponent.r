library(gsubfn)
library (gsubfn) 
setwd('/src/r')
source('Surfacetemperatureparton.r')
source('Soiltemperatureswat.r')

model_surfacepartonsoilswatc <- function (GlobalSolarRadiation,
         AirTemperatureMinimum,
         DayLength,
         AboveGroundBiomass,
         AirTemperatureMaximum,
         LayerThickness,
         VolumetricWaterContent,
         SoilProfileDepth,
         AirTemperatureAnnualAverage,
         LagCoefficient,
         BulkDensity){
    #'- Name: SurfacePartonSoilSWATC -Version: 001, -Time step: 1
    #'- Description:
    #'            * Title: SurfacePartonSoilSWATC model
    #'            * Authors: simone.bregaglio@unimi.it
    #'            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    #'            * Institution: Universiy Of Milan
    #'            * ExtendedDescription: Composite strategy for the calculation of surface temperature with Parton's method and soil temperature with SWAT method. Parton, W. J. 1984. Predicting soil temperatures in a shortgrass steppe. Soil Science 138:93-101. and Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf.  Composite strategy. See also references of the associated strategies.
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
    #'            * name: AirTemperatureMinimum
    #'                          ** description : Minimum daily air temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 50
    #'                          ** min : -60
    #'                          ** default : 5
    #'                          ** unit : Â°C
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
    #'            * name: AirTemperatureMaximum
    #'                          ** description : Maximum daily air temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 60
    #'                          ** min : -40
    #'                          ** default : 15
    #'                          ** unit : Â°C
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
    #'            * name: SoilProfileDepth
    #'                          ** description : Soil profile depth
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** max : 50
    #'                          ** min : 0
    #'                          ** default : 3
    #'                          ** unit : m
    #'            * name: AirTemperatureAnnualAverage
    #'                          ** description : Annual average air temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 50
    #'                          ** min : -40
    #'                          ** default : 15
    #'                          ** unit : Â°C
    #'            * name: LagCoefficient
    #'                          ** description : Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** max : 1
    #'                          ** min : 0
    #'                          ** default : 0.8
    #'                          ** unit : dimensionless
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
    #'- outputs:
    #'            * name: SurfaceSoilTemperature
    #'                          ** description : Average surface soil temperature
    #'                          ** datatype : DOUBLE
    #'                          ** variablecategory : state
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
    #'            * name: SurfaceTemperatureMinimum
    #'                          ** description : Minimum surface soil temperature
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
    SoilTemperatureByLayers<- vector()
    list[SurfaceSoilTemperature, SurfaceTemperatureMaximum, SurfaceTemperatureMinimum] <- model_surfacetemperatureparton(AboveGroundBiomass, GlobalSolarRadiation, AirTemperatureMinimum, SurfaceTemperatureMaximum, DayLength, SurfaceTemperatureMinimum, AirTemperatureMaximum)
    SoilTemperatureByLayers <- model_soiltemperatureswat(LayerThickness, VolumetricWaterContent, SurfaceSoilTemperature, SoilProfileDepth, AirTemperatureAnnualAverage, LagCoefficient, SoilTemperatureByLayers, BulkDensity)
    return (list ("SurfaceSoilTemperature" = SurfaceSoilTemperature,"SurfaceTemperatureMaximum" = SurfaceTemperatureMaximum,"SurfaceTemperatureMinimum" = SurfaceTemperatureMinimum,"SoilTemperatureByLayers" = SoilTemperatureByLayers))
}