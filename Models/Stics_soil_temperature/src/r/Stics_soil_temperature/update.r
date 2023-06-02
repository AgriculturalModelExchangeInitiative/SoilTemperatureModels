library(gsubfn)

model_update <- function (canopy_temp_avg,
         temp_profile){
    #'- Name: update -Version: 1.0, -Time step: 1
    #'- Description:
    #'            * Title: update soil temp model
    #'            * Authors: None
    #'            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    #'            * Institution: INRAE
    #'            * ExtendedDescription: None
    #'            * ShortDescription: None
    #'- inputs:
    #'            * name: canopy_temp_avg
    #'                          ** description : current temperature amplitude
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** max : 100.0
    #'                          ** min : 0.0
    #'                          ** default : 
    #'                          ** unit : degC
    #'            * name: temp_profile
    #'                          ** description : current soil profile temperature 
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 50.0
    #'                          ** min : -50.0
    #'                          ** default : 
    #'                          ** unit : degC
    #'- outputs:
    #'            * name: prev_temp_profile
    #'                          ** description : previous soil temperature profile 
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 1
    #'                          ** max : 50.0
    #'                          ** min : -50.0
    #'                          ** unit : degC
    #'            * name: prev_canopy_temp
    #'                          ** description : previous crop temperature
    #'                          ** datatype : DOUBLE
    #'                          ** variablecategory : exogenous
    #'                          ** max : 50.0
    #'                          ** min : 0.0
    #'                          ** unit : degC
    prev_temp_profile <- vector(,1)
    prev_canopy_temp <- canopy_temp_avg
    prev_temp_profile <- temp_profile
    return (list ("prev_temp_profile" = prev_temp_profile,"prev_canopy_temp" = prev_canopy_temp))
}