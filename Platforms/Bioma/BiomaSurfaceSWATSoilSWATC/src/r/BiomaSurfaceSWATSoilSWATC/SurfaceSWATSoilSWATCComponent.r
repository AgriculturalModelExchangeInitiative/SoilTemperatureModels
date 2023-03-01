library(gsubfn)
library (gsubfn) 
setwd('D:/Docs/AMEI_Workshop/AMEI_10_14_2022/Platforms/Bioma/BiomaSurfaceSWATSoilSWATC/src/r')
source('Surfacetemperatureswat.r')
source('Soiltemperatureswat.r')

model_surfaceswatsoilswatc <- function (AirTemperatureMinimum,
         GlobalSolarRadiation,
         AboveGroundBiomass,
         WaterEquivalentOfSnowPack,
         AirTemperatureMaximum,
         Albedo,
         AirTemperatureAnnualAverage,
         VolumetricWaterContent,
         BulkDensity,
         SoilProfileDepth,
         LayerThickness,
         LagCoefficient){
    #'- Name: SurfaceSWATSoilSWATC -Version: 001, -Time step: 1
    #'- Description:
    #'            * Title: SurfaceSWATSoilSWATC model
    #'            * Authors: simone.bregaglio@unimi.it
    #'            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    #'            * Institution: Universiy Of Milan
    #'            * ExtendedDescription: Composite strategy for the calculation of surface and soil temperature with SWAT method. Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf.  Composite strategy. See also references of the associated strategies.
    #'            * ShortDescription: None
    #'- inputs:
    #'            * name: AirTemperatureMinimum
    #'                          ** description : Minimum daily air temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 50
    #'                          ** min : -60
    #'                          ** default : 5
    #'                          ** unit : Â°C
    #'            * name: GlobalSolarRadiation
    #'                          ** description : Daily global solar radiation
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 50
    #'                          ** min : 0
    #'                          ** default : 15
    #'                          ** unit : Mj m-2 d-1
    #'            * name: AboveGroundBiomass
    #'                          ** description : Above ground biomass
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** max : 60
    #'                          ** min : 0
    #'                          ** default : 3
    #'                          ** unit : Kg ha-1
    #'            * name: WaterEquivalentOfSnowPack
    #'                          ** description : Water equivalent of snow pack
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 1000
    #'                          ** min : 0
    #'                          ** default : 10
    #'                          ** unit : mm
    #'            * name: AirTemperatureMaximum
    #'                          ** description : Maximum daily air temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 60
    #'                          ** min : -40
    #'                          ** default : 15
    #'                          ** unit : Â°C
    #'            * name: Albedo
    #'                          ** description : Albedo of soil
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 1
    #'                          ** min : 0
    #'                          ** default : 0.2
    #'                          ** unit : unitless
    #'            * name: AirTemperatureAnnualAverage
    #'                          ** description : Annual average air temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 50
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
    #'            * name: SoilProfileDepth
    #'                          ** description : Soil profile depth
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** max : 50
    #'                          ** min : 0
    #'                          ** default : 3
    #'                          ** unit : m
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
    #'- outputs:
    #'            * name: SurfaceSoilTemperature
    #'                          ** description : Average surface soil temperature
    #'                          ** datatype : DOUBLE
    #'                          ** variablecategory : state
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
    SurfaceSoilTemperature <- model_surfacetemperatureswat(AirTemperatureMinimum, GlobalSolarRadiation, SoilTemperatureByLayers, AboveGroundBiomass, WaterEquivalentOfSnowPack, AirTemperatureMaximum, Albedo)
    SoilTemperatureByLayers <- model_soiltemperatureswat(SoilTemperatureByLayers, AirTemperatureAnnualAverage, VolumetricWaterContent, BulkDensity, SoilProfileDepth, LayerThickness, LagCoefficient, SurfaceSoilTemperature)
    return (list ("SurfaceSoilTemperature" = SurfaceSoilTemperature,"SoilTemperatureByLayers" = SoilTemperatureByLayers))
}