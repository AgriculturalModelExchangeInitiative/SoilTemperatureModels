library(gsubfn)

#' temp_amp model
#'
#' This function compute the temp_amp model
#' @param min_temp (degC) current minimum temperature exogenous (0.0, -50.0-50.0) 
#' @param max_temp (degC) current maximum temperature exogenous (0.0, -50.0-50.0) 
#'
#' @return
#' \describe{
#'   \item{temp_amp (degC)}{current temperature amplitude state (0.0-50.0)} 
#' }
#' @export
model_temp_amp <- function (min_temp,
         max_temp){
    temp_amp <- 0.0
    temp_amp <- max_temp - min_temp
    return (list('temp_amp' = temp_amp))
}