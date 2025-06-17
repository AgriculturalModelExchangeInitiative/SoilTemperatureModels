library(gsubfn)

#' update soil temp model
#'
#' This function compute the update soil temp model
#' @param canopy_temp_avg (degC) current canopy mean temperature state (0.0, -50.0-50.0) 
#' @param temp_profile (degC) current soil profile temperature (for 1 cm layers) state (, -50.0-50.0) 
#'
#' @return
#' \describe{
#'   \item{prev_canopy_temp (degC)}{previous crop temperature state (0.0-50.0)} 
#'   \item{prev_temp_profile (degC)}{previous soil temperature profile (for 1 cm layers) state (-50.0-50.0)} 
#' }
#' @export
model_update <- function (canopy_temp_avg,
         temp_profile){
    prev_canopy_temp <- 0.0
    prev_temp_profile <- vector(,1)
    n <- 0
    prev_canopy_temp <- canopy_temp_avg
    n <- length(temp_profile)
    prev_temp_profile <- vector(, n)
    prev_temp_profile <- temp_profile
    return (list ("prev_canopy_temp" = prev_canopy_temp,"prev_temp_profile" = prev_temp_profile))
}