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
    #'                          ** description : current canopy mean temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** max : 50.0
    #'                          ** min : -50.0
    #'                          ** default : 0.0
    #'                          ** unit : degC
    #'            * name: temp_profile
    #'                          ** description : current soil profile temperature (for 1 cm layers)
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 50.0
    #'                          ** min : -50.0
    #'                          ** default : 
    #'                          ** unit : degC
    #'- outputs:
    #'            * name: prev_canopy_temp
    #'                          ** description : previous crop temperature
    #'                          ** datatype : DOUBLE
    #'                          ** variablecategory : state
    #'                          ** max : 50.0
    #'                          ** min : 0.0
    #'                          ** unit : degC
    #'            * name: prev_temp_profile
    #'                          ** description : previous soil temperature profile (for 1 cm layers)
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 1
    #'                          ** max : 50.0
    #'                          ** min : -50.0
    #'                          ** unit : degC
    prev_temp_profile <- vector(,1)
    prev_canopy_temp <- canopy_temp_avg
    n <- length(temp_profile)
    prev_temp_profile <- vector(, n)
    prev_temp_profile <- temp_profile
    return (list ("prev_canopy_temp" = prev_canopy_temp,"prev_temp_profile" = prev_temp_profile))
}