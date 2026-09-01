library(gsubfn)

#' STEMP_ model
#'
#' This function compute the STEMP_ model
#' @param TMAX (degC) Maximum daily temperature exogenous (, -) 
#' @param MSALB (dimensionless) Soil albedo with mulch and soil water effects constant (, -) 
#' @param HDAY (day) Haverst day state (, -) 
#' @param NL (dimensionless) Number of soil layers constant (, -) 
#' @param SRFTEMP (degC) Temperature of soil surface litter state (, -) 
#' @param LL (cm3 [water] / cm3 [soil]) Volumetric soil water content in soil layer L at lower limit soil (, -) 
#' @param NLAYR (dimensionless) Actual number of soil layers constant (, -) 
#' @param DS (cm) Cumulative depth in soil layer L soil (, -) 
#' @param ST (degC) Soil temperature in soil layer L state (, -) 
#' @param SRAD (MJ/m2-d) Solar radiation exogenous (, -) 
#' @param TAMP (degC) Amplitude of temperature function used to calculate soil temperatures exogenous (, -) 
#' @param DLAYR (cm) Thickness of soil layer L constant (, -) 
#' @param TMA (degC) Array of previous 5 days of average soil temperatures state (, -) 
#' @param TDL (cm) Total water content of soil at drained upper limit state (, -) 
#' @param ISWWAT (dimensionless) Water simulation control switch constant (Y, -) 
#' @param CUMDPT (mm) Cumulative depth of soil profile state (, -) 
#' @param TAVG (degC) Average daily temperature exogenous (, -) 
#' @param BD (g [soil] / cm3 [soil]) Bulk density, soil layer NL soil (, -) 
#' @param SW (cm3 [water] / cm3 [soil]) Volumetric soil water content in layer L soil (, -) 
#' @param ATOT (degC) Sum of TMA array (last 5 days soil temperature) state (, -) 
#' @param TAV (degC) Average annual soil temperature, used with TAMP to calculate soil temperature. exogenous (, -) 
#' @param XLAT (degC) Latitude constant (, -) 
#' @param DUL (cm3[water]/cm3[soil]) Volumetric soil water content at Drained Upper Limit in soil layer L soil (, -) 
#' @param DSMID (cm) Depth to midpoint of soil layer L state (, -) 
#' @param DOY (d) Current day of simulation exogenous (, -) 
#'
#' @return
#' \describe{
#'   \item{CUMDPT (mm)}{Cumulative depth of soil profile state (-)} 
#'   \item{DSMID (cm)}{Depth to midpoint of soil layer L state (-)} 
#'   \item{TDL (cm)}{Total water content of soil at drained upper limit state (-)} 
#'   \item{TMA (degC)}{Array of previous 5 days of average soil temperatures state (-)} 
#'   \item{ATOT (degC)}{Sum of TMA array (last 5 days soil temperature) state (-)} 
#'   \item{SRFTEMP (degC)}{Temperature of soil surface litter state (-)} 
#'   \item{ST (degC)}{Soil temperature in soil layer L state (-)} 
#' }
#' @export
model_stemp_ <- function (TMAX,
         MSALB,
         HDAY,
         NL,
         SRFTEMP,
         LL,
         NLAYR,
         DS,
         ST,
         SRAD,
         TAMP,
         DLAYR,
         TMA,
         TDL,
         ISWWAT,
         CUMDPT,
         TAVG,
         BD,
         SW,
         ATOT,
         TAV,
         XLAT,
         DUL,
         DSMID,
         DOY){
    result <-  model_stemp(NL, ISWWAT, BD, DLAYR, DS, DUL, LL, NLAYR, MSALB, SRAD, SW, TAVG, TMAX, XLAT, TAV, TAMP, CUMDPT, DSMID, TDL, TMA, ATOT, SRFTEMP, ST, DOY, HDAY)
    CUMDPT <- result[[1]]
    DSMID <- result[[2]]
    TDL <- result[[3]]
    TMA <- result[[4]]
    ATOT <- result[[5]]
    SRFTEMP <- result[[6]]
    ST <- result[[7]]
    return (list ("CUMDPT" = CUMDPT,"DSMID" = DSMID,"TDL" = TDL,"TMA" = TMA,"ATOT" = ATOT,"SRFTEMP" = SRFTEMP,"ST" = ST))
}

#' Initialization of the STEMP_ model
#' 
#' This function initialize the STEMP_ model
#' @param NL (dimensionless) Number of soil layers constant (, -) 
#' @param ISWWAT (dimensionless) Water simulation control switch constant (Y, -) 
#' @param BD (g [soil] / cm3 [soil]) Bulk density, soil layer NL soil (, -) 
#' @param DLAYR (cm) Thickness of soil layer L constant (, -) 
#' @param DS (cm) Cumulative depth in soil layer L soil (, -) 
#' @param DUL (cm3[water]/cm3[soil]) Volumetric soil water content at Drained Upper Limit in soil layer L soil (, -) 
#' @param LL (cm3 [water] / cm3 [soil]) Volumetric soil water content in soil layer L at lower limit soil (, -) 
#' @param NLAYR (dimensionless) Actual number of soil layers constant (, -) 
#' @param MSALB (dimensionless) Soil albedo with mulch and soil water effects constant (, -) 
#' @param SRAD (MJ/m2-d) Solar radiation exogenous (, -) 
#' @param SW (cm3 [water] / cm3 [soil]) Volumetric soil water content in layer L soil (, -) 
#' @param TAVG (degC) Average daily temperature exogenous (, -) 
#' @param TMAX (degC) Maximum daily temperature exogenous (, -) 
#' @param XLAT (degC) Latitude constant (, -) 
#' @param TAV (degC) Average annual soil temperature, used with TAMP to calculate soil temperature. exogenous (, -) 
#' @param TAMP (degC) Amplitude of temperature function used to calculate soil temperatures exogenous (, -) 
#' @param DOY (d) Current day of simulation exogenous (, -) 
#'
#' @return
#' \describe{
#'   \item{CUMDPT (mm)}{Cumulative depth of soil profile state (-)}
#'   \item{DSMID (cm)}{Depth to midpoint of soil layer L state (-)}
#'   \item{TDL (cm)}{Total water content of soil at drained upper limit state (-)}
#'   \item{TMA (degC)}{Array of previous 5 days of average soil temperatures state (-)}
#'   \item{ATOT (degC)}{Sum of TMA array (last 5 days soil temperature) state (-)}
#'   \item{SRFTEMP (degC)}{Temperature of soil surface litter state (-)}
#'   \item{ST (degC)}{Soil temperature in soil layer L state (-)}
#' }
#' @export
init_stemp_ <- function (NL,
         ISWWAT,
         BD,
         DLAYR,
         DS,
         DUL,
         LL,
         NLAYR,
         MSALB,
         SRAD,
         SW,
         TAVG,
         TMAX,
         XLAT,
         TAV,
         TAMP,
         DOY){
    HDAY <- 0.0
    SRFTEMP <- 0.0
    ST <- vector(,NL)
    TMA <- vector(,5)
    TDL <- 0.0
    CUMDPT <- 0.0
    ATOT <- 0.0
    DSMID <- vector(,NL)
    result <-  init_stemp(NL, ISWWAT, BD, DLAYR, DS, DUL, LL, NLAYR, MSALB, SRAD, SW, TAVG, TMAX, XLAT, TAV, TAMP, DOY)
    CUMDPT <- result[[1]]
    DSMID <- result[[2]]
    TDL <- result[[3]]
    TMA <- result[[4]]
    ATOT <- result[[5]]
    SRFTEMP <- result[[6]]
    ST <- result[[7]]
    HDAY <- result[[8]]
    return (list ("CUMDPT" = CUMDPT,"DSMID" = DSMID,"TDL" = TDL,"TMA" = TMA,"ATOT" = ATOT,"SRFTEMP" = SRFTEMP,"ST" = ST,"HDAY" = HDAY))
}