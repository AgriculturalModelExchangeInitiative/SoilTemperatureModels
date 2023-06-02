library(gsubfn)

model_canopy_temp_avg <- function (min_canopy_temp,
         max_canopy_temp){
    #'- Name: canopy_temp_avg -Version: 1.0, -Time step: 1
    #'- Description:
    #'            * Title: canopy_temp_avg model
    #'            * Authors: None
    #'            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    #'            * Institution: INRAE
    #'            * ExtendedDescription: None
    #'            * ShortDescription: None
    #'- inputs:
    #'            * name: min_canopy_temp
    #'                          ** description : current minimum temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 50.0
    #'                          ** min : -50.0
    #'                          ** default : 0.0
    #'                          ** unit : degC
    #'            * name: max_canopy_temp
    #'                          ** description : current maximum temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 50.0
    #'                          ** min : -50.0
    #'                          ** default : 0.0
    #'                          ** unit : degC
    #'- outputs:
    #'            * name: canopy_temp_avg
    #'                          ** description : current temperature amplitude
    #'                          ** datatype : DOUBLE
    #'                          ** variablecategory : state
    #'                          ** max : 100.0
    #'                          ** min : 0.0
    #'                          ** unit : degC
    canopy_temp_avg <- (max_canopy_temp + min_canopy_temp) / 2
    return (list('canopy_temp_avg' = canopy_temp_avg))
}