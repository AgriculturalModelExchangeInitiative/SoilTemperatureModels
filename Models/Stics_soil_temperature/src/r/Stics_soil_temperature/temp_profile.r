library(gsubfn)

init_temp_profile <- function (temp_amp,
         therm_amp,
         min_air_temp,
         air_temp_day1,
         layer_thick){
    prev_temp_profile<- vector()
    prev_temp_profile <- NULL
    prev_canopy_temp <- 0.0
    soil_depth <- sum(layer_thick)
    prev_temp_profile <- vector(, soil_depth)
    prev_temp_profile <- c(air_temp_day1) * soil_depth
    prev_canopy_temp <- air_temp_day1
    return (list ("prev_temp_profile" = prev_temp_profile,"prev_canopy_temp" = prev_canopy_temp))
}

model_temp_profile <- function (temp_amp,
         therm_amp,
         prev_temp_profile,
         prev_canopy_temp,
         min_air_temp,
         air_temp_day1,
         layer_thick){
    #'- Name: temp_profile -Version: 1.0, -Time step: 1
    #'- Description:
    #'            * Title: tempprofile model
    #'            * Authors: None
    #'            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    #'            * Institution: INRAE
    #'            * ExtendedDescription: None
    #'            * ShortDescription: None
    #'- inputs:
    #'            * name: temp_amp
    #'                          ** description : current temperature amplitude
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 100.0
    #'                          ** min : 0.0
    #'                          ** default : 0.0
    #'                          ** unit : degC
    #'            * name: therm_amp
    #'                          ** description : current thermal amplitude
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 
    #'                          ** min : 
    #'                          ** default : 
    #'                          ** unit : 
    #'            * name: prev_temp_profile
    #'                          ** description : previous soil temperature profile 
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 50.0
    #'                          ** min : -50.0
    #'                          ** default : 
    #'                          ** unit : degC
    #'            * name: prev_canopy_temp
    #'                          ** description : previous crop temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** max : 50.0
    #'                          ** min : 0.0
    #'                          ** default : 
    #'                          ** unit : degC
    #'            * name: min_air_temp
    #'                          ** description : current minimum air temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 50.0
    #'                          ** min : -50.0
    #'                          ** default : 
    #'                          ** unit : degC
    #'            * name: air_temp_day1
    #'                          ** description : Mean temperature on first day
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** max : 100.0
    #'                          ** min : 0.0
    #'                          ** default : 0.0
    #'                          ** unit : degC
    #'            * name: layer_thick
    #'                          ** description : layers thickness
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : INTARRAY
    #'                          ** len : 
    #'                          ** max : 
    #'                          ** min : 
    #'                          ** default : 
    #'                          ** unit : cm
    #'- outputs:
    #'            * name: temp_profile
    #'                          ** description : current soil profile temperature 
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 
    #'                          ** max : 50.0
    #'                          ** min : -50.0
    #'                          ** unit : degC
    temp_profile<- vector()
    vexp <- vector()
    n <- length(prev_temp_profile)
    temp_profile <- vector(, n)
    vexp <- vector(, n)
    for( z in seq(1, n + 1-1, 1)){
        vexp[z - 1+1] <- exp(-(z * therm_amp))
    }
    for( z in seq(1, n + 1-1, 1)){
        temp_profile[z - 1+1] <- prev_temp_profile[z - 1+1] - (vexp[(z - 1)+1] * (prev_canopy_temp - min_air_temp)) + (0.1 * (prev_canopy_temp - prev_temp_profile[z - 1+1])) + (temp_amp * vexp[(z - 1)+1] / 2)
    }
    return (list('temp_profile' = temp_profile))
}