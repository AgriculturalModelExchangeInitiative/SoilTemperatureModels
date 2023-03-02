library(gsubfn)

model_volumetricheatcapacitykluitenberg <- function (Silt,
         OrganicMatter,
         Sand,
         VolumetricWaterContent,
         BulkDensity,
         Clay,
         HeatCapacity){
    #'- Name: VolumetricHeatCapacityKluitenberg -Version: 001, -Time step: 1
    #'- Description:
    #'            * Title: VolumetricHeatCapacityKluitenberg model
    #'            * Authors: simone.bregaglio@unimi.it
    #'            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    #'            * Institution: University Of Milan
    #'            * ExtendedDescription: Strategy for the calculation of soil thermal diffusivity. Reference: J.M.H.Hendrickx, H. Xie, B. Borchers, J.B.J. Harrison, 2008. Global Prediction of Thermal Soil Regimes. SPIE Proceedings Volume 6953 Detection and Sensing of Mines, Explosive Objects, and Obscured Targets XIII.
    #'            * ShortDescription: None
    #'- inputs:
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
    #'            * name: HeatCapacity
    #'                          ** description : Volumetric specific heat of soil
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 300
    #'                          ** min : 0
    #'                          ** default : 20
    #'                          ** unit : MJ m-3 Â°C-1
    #'- outputs:
    #'            * name: HeatCapacity
    #'                          ** description : Volumetric specific heat of soil
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 
    #'                          ** max : 300
    #'                          ** min : 0
    #'                          ** unit : MJ m-3 Â°C-1
    SandFraction <- as.double(0)
    SiltFraction <- as.double(0)
    ClayFraction <- as.double(0)
    FractionMinerals <- as.double(0)
    OrganicMatterFraction <- as.double(0)
    for( i in seq(0, length(HeatCapacity)-1, 1)){
        SandFraction <- Sand[i+1] / (Sand[i+1] + Silt[i+1] + Clay[i+1] + OrganicMatter[i+1])
        SiltFraction <- Silt[i+1] / (Sand[i+1] + Silt[i+1] + Clay[i+1] + OrganicMatter[i+1])
        ClayFraction <- Clay[i+1] / (Sand[i+1] + Silt[i+1] + Clay[i+1] + OrganicMatter[i+1])
        FractionMinerals <- SandFraction + SiltFraction + ClayFraction
        OrganicMatterFraction <- OrganicMatter[i+1] / (Sand[i+1] + Silt[i+1] + Clay[i+1] + OrganicMatter[i+1])
        HeatCapacity[i+1] <- BulkDensity[i+1] * 0.73 * FractionMinerals + (BulkDensity[i+1] * 1.9 * OrganicMatterFraction) + (4.18 * VolumetricWaterContent[i+1])
    }
    return (list('HeatCapacity' = HeatCapacity))
}