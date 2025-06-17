library(gsubfn)

#' canopy_temp_avg model
#'
#' This function compute the canopy_temp_avg model
#' @param min_canopy_temp (degC) current minimum temperature exogenous (0.0, -50.0-50.0) 
#' @param max_canopy_temp (degC) current maximum temperature exogenous (0.0, -50.0-50.0) 
#'
#' @return
#' \describe{
#'   \item{canopy_temp_avg (degC)}{current temperature amplitude state (0.0-50.0)} 
#' }
#' @export
model_canopy_temp_avg <- function (min_canopy_temp,
         max_canopy_temp){
    canopy_temp_avg <- 0.0
    canopy_temp_avg <- (max_canopy_temp + min_canopy_temp) / 2
    return (list('canopy_temp_avg' = canopy_temp_avg))
}