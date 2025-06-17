library(gsubfn)

#' Initialization of the tempprofile model
#' 
#' This function initialize the tempprofile model
#' @param min_air_temp (degC) current minimum air temperature exogenous (, -50.0-50.0) 
#' @param air_temp_day1 (degC) Mean temperature on first day constant (0.0, 0.0-100.0) 
#' @param layer_thick (cm) layers thickness constant (, -) 
#'
#' @return
#' \describe{
#'   \item{temp_profile (degC)}{current soil profile temperature (for 1 cm layers) state (-50.0-)}
#' }
#' @export
init_temp_profile <- function (min_air_temp,
         air_temp_day1,
         layer_thick){
    temp_amp <- 0.0
    prev_temp_profile<- vector()
    prev_canopy_temp <- 0.0
    prev_temp_profile <- NULL
    prev_canopy_temp <- 0.0
    soil_depth <- 0
    soil_depth <- sum(layer_thick)
    prev_temp_profile <- vector(, soil_depth)
    prev_temp_profile <- c(air_temp_day1) * soil_depth
    prev_canopy_temp <- air_temp_day1
    return (list ("temp_amp" = temp_amp,"prev_temp_profile" = prev_temp_profile,"prev_canopy_temp" = prev_canopy_temp))
}

#' tempprofile model
#'
#' This function compute the tempprofile model
#' @param temp_amp (degC) current temperature amplitude state (0.0, 0.0-100.0) 
#' @param prev_temp_profile (degC) previous soil temperature profile (for 1 cm layers) state (, -50.0-50.0) 
#' @param prev_canopy_temp (degC) previous crop temperature state (, 0.0-50.0) 
#' @param min_air_temp (degC) current minimum air temperature exogenous (, -50.0-50.0) 
#' @param air_temp_day1 (degC) Mean temperature on first day constant (0.0, 0.0-100.0) 
#' @param layer_thick (cm) layers thickness constant (, -) 
#'
#' @return
#' \describe{
#'   \item{temp_profile (degC)}{current soil profile temperature (for 1 cm layers) state (-50.0-)} 
#' }
#' @export
model_temp_profile <- function (temp_amp,
         prev_temp_profile,
         prev_canopy_temp,
         min_air_temp,
         air_temp_day1,
         layer_thick){
    temp_profile<- vector()
    z <- 0
    n <- 0
    vexp <- vector()
    therm_diff <- 5.37e-3
    temp_freq <- 7.272e-5
    therm_amp <- 0.0
    n <- length(prev_temp_profile)
    temp_profile <- vector(, n)
    vexp <- vector(, n)
    therm_amp <- sqrt(temp_freq / 2 / therm_diff)
    for( z in seq(1, n + 1-1, 1)){
        vexp[z - 1+1] <- exp(-(z * therm_amp))
    }
    for( z in seq(1, n + 1-1, 1)){
        temp_profile[z - 1+1] <- prev_temp_profile[z - 1+1] - (vexp[(z - 1)+1] * (prev_canopy_temp - min_air_temp)) + (0.1 * (prev_canopy_temp - prev_temp_profile[z - 1+1])) + (temp_amp * vexp[(z - 1)+1] / 2)
    }
    return (list('temp_profile' = temp_profile))
}