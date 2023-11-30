library(gsubfn)

init_thermalconductivitysimulat <- function (VolumetricWaterContent,
         BulkDensity,
         Clay){
    ThermalConductivity<- vector()
    ThermalConductivity <- NULL
    ThermalConductivity <-  rep(0.0,length(VolumetricWaterContent))
    return( ThermalConductivity)
}

model_thermalconductivitysimulat <- function (VolumetricWaterContent,
         BulkDensity,
         Clay,
         ThermalConductivity){
    #'- Name: ThermalConductivitySIMULAT -Version: 001, -Time step: 1
    #'- Description:
    #'            * Title: ThermalConductivitySIMULAT model
    #'            * Authors: simone.bregaglio
    #'            * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
    #'            * Institution: University Of Milan
    #'            * ExtendedDescription: Strategy for the calculation of thermal conductivity. Bristow, K.L., Thermal conductivity, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series
    #'            * ShortDescription: Strategy for the calculation of thermal conductivity
    #'- inputs:
    #'            * name: VolumetricWaterContent
    #'                          ** description : Volumetric soil water content
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 0.8
    #'                          ** min : 0
    #'                          ** default : 0.25
    #'                          ** unit : m3 m-3
    #'            * name: BulkDensity
    #'                          ** description : Bulk density
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 1.8
    #'                          ** min : 0.9
    #'                          ** default : 1.3
    #'                          ** unit : t m-3
    #'            * name: Clay
    #'                          ** description : Clay content of soil layer
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 100
    #'                          ** min : 0
    #'                          ** default : 0
    #'                          ** unit : 
    #'            * name: ThermalConductivity
    #'                          ** description : Thermal conductivity of soil layer
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 8
    #'                          ** min : 0.025
    #'                          ** default : 
    #'                          ** unit : W m-1 K-1
    #'- outputs:
    #'            * name: ThermalConductivity
    #'                          ** description : Thermal conductivity of soil layer
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 
    #'                          ** max : 8
    #'                          ** min : 0.025
    #'                          ** unit : W m-1 K-1
    Aterm <- as.double(0)
    Bterm <- as.double(0)
    Cterm <- as.double(0)
    Dterm <- as.double(0)
    Eterm <- as.double(4)
    for( i in seq(0, length(VolumetricWaterContent)-1, 1)){
        Aterm <- 0.65 - (0.78 * BulkDensity[i+1]) + (0.6 * BulkDensity[i+1] ^ 2)
        Bterm <- 1.06 * BulkDensity[i+1] * VolumetricWaterContent[i+1]
        Cterm <- 1 + (2.6 * sqrt(Clay[i+1] / 100))
        Dterm <- 0.03 + (0.1 * BulkDensity[i+1] ^ 2)
        ThermalConductivity[i+1] <- Aterm + (Bterm * VolumetricWaterContent[i+1]) - ((Aterm - Dterm) * exp((-(Cterm * VolumetricWaterContent[i+1]))) ^ Eterm)
    }
    return (list('ThermalConductivity' = ThermalConductivity))
}