library(gsubfn)

#' Initialization of the Model of STEMP
#' 
#' This function initialize the Model of STEMP
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
init_stemp <- function (NL,
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
    CUMDPT <- 0.0
    DSMID <- vector(,NL)
    TDL <- 0.0
    TMA <- vector(,5)
    ATOT <- 0.0
    SRFTEMP <- 0.0
    ST <- vector(,NL)
    HDAY <- 0.0
    CUMDPT <- 0.0
    DSMID <-  rep(0.0,NL)
    TDL <- 0.0
    TMA <-  rep(0.0,5)
    ATOT <- 0.0
    SRFTEMP <- 0.0
    ST <-  rep(0.0,NL)
    HDAY <- 0.0
    I <- 0
    L <- 0
    ABD <- 0.0
    ALBEDO <- 0.0
    B <- 0.0
    DP <- 0.0
    FX <- 0.0
    PESW <- 0.0
    TBD <- 0.0
    WW <- 0.0
    TLL <- 0.0
    TSW <- 0.0
    DLI <- vector(,NL)
    DSI <- vector(,NL)
    SWI <- vector(,NL)
    SWI <- SW
    DSI <- DS
    if (XLAT < 0.0)
    {
        HDAY <- 20.0
    }
    else
    {
        HDAY <- 200.0
    }
    TBD <- 0.0
    TLL <- 0.0
    TSW <- 0.0
    TDL <- 0.0
    CUMDPT <- 0.0
    for( L in seq(1, NLAYR + 1-1, 1)){
        if (L == 1)
        {
            DLI[L - 1+1] <- DSI[L - 1+1]
        }
        else
        {
            DLI[L - 1+1] <- DSI[L - 1+1] - DSI[L - 1 - 1+1]
        }
        DSMID[L - 1+1] <- CUMDPT + (DLI[(L - 1)+1] * 5.0)
        CUMDPT <- CUMDPT + (DLI[(L - 1)+1] * 10.0)
        TBD <- TBD + (BD[(L - 1)+1] * DLI[(L - 1)+1])
        TLL <- TLL + (LL[(L - 1)+1] * DLI[(L - 1)+1])
        TSW <- TSW + (SWI[(L - 1)+1] * DLI[(L - 1)+1])
        TDL <- TDL + (DUL[(L - 1)+1] * DLI[(L - 1)+1])
    }
    if (ISWWAT == 'Y')
    {
        PESW <- max(0.0, TSW - TLL)
    }
    else
    {
        PESW <- max(0.0, TDL - TLL)
    }
    ABD <- TBD / DSI[(NLAYR - 1)+1]
    FX <- ABD / (ABD + (686.0 * exp(-(5.63 * ABD))))
    DP <- 1000.0 + (2500.0 * FX)
    WW <- 0.356 - (0.144 * ABD)
    B <- log(500.0 / DP)
    ALBEDO <- MSALB
    for( I in seq(1, 5 + 1-1, 1)){
        TMA[I - 1+1] <- as.integer(TAVG * 10000.) / 10000.
    }
    ATOT <- TMA[(1 - 1)+1] * 5.0
    for( L in seq(1, NLAYR + 1-1, 1)){
        ST[L - 1+1] <- TAVG
    }
    for( I in seq(1, 8 + 1-1, 1)){
        result <-  SOILT(NL, ALBEDO, B, CUMDPT, DOY, DP, HDAY, NLAYR, PESW, SRAD, TAMP, TAV, TAVG, TMAX, WW, DSMID, ATOT, TMA)
        ATOT <- result[[1]]
        TMA <- result[[2]]
        SRFTEMP <- result[[3]]
        ST <- result[[4]]
    }
    return (list ("CUMDPT" = CUMDPT,"DSMID" = DSMID,"TDL" = TDL,"TMA" = TMA,"ATOT" = ATOT,"SRFTEMP" = SRFTEMP,"ST" = ST,"HDAY" = HDAY))
}

#' Model of STEMP
#'
#' This function compute the Model of STEMP
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
#' @param CUMDPT (mm) Cumulative depth of soil profile state (, -) 
#' @param DSMID (cm) Depth to midpoint of soil layer L state (, -) 
#' @param TDL (cm) Total water content of soil at drained upper limit state (, -) 
#' @param TMA (degC) Array of previous 5 days of average soil temperatures state (, -) 
#' @param ATOT (degC) Sum of TMA array (last 5 days soil temperature) state (, -) 
#' @param SRFTEMP (degC) Temperature of soil surface litter state (, -) 
#' @param ST (degC) Soil temperature in soil layer L state (, -) 
#' @param DOY (d) Current day of simulation exogenous (, -) 
#' @param HDAY (day) Haverst day state (, -) 
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
model_stemp <- function (NL,
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
         CUMDPT,
         DSMID,
         TDL,
         TMA,
         ATOT,
         SRFTEMP,
         ST,
         DOY,
         HDAY){
    L <- 0
    ABD <- 0.0
    ALBEDO <- 0.0
    B <- 0.0
    DP <- 0.0
    FX <- 0.0
    PESW <- 0.0
    TBD <- 0.0
    WW <- 0.0
    TLL <- 0.0
    TSW <- 0.0
    TBD <- 0.0
    TLL <- 0.0
    TSW <- 0.0
    for( L in seq(1, NLAYR + 1-1, 1)){
        TBD <- TBD + (BD[(L - 1)+1] * DLAYR[(L - 1)+1])
        TDL <- TDL + (DUL[(L - 1)+1] * DLAYR[(L - 1)+1])
        TLL <- TLL + (LL[(L - 1)+1] * DLAYR[(L - 1)+1])
        TSW <- TSW + (SW[(L - 1)+1] * DLAYR[(L - 1)+1])
    }
    ABD <- TBD / DS[(NLAYR - 1)+1]
    FX <- ABD / (ABD + (686.0 * exp(-(5.63 * ABD))))
    DP <- 1000.0 + (2500.0 * FX)
    WW <- 0.356 - (0.144 * ABD)
    B <- log(500.0 / DP)
    ALBEDO <- MSALB
    if (ISWWAT == 'Y')
    {
        PESW <- max(0.0, TSW - TLL)
    }
    else
    {
        PESW <- max(0.0, TDL - TLL)
    }
    result <-  SOILT(NL, ALBEDO, B, CUMDPT, DOY, DP, HDAY, NLAYR, PESW, SRAD, TAMP, TAV, TAVG, TMAX, WW, DSMID, ATOT, TMA)
    ATOT <- result[[1]]
    TMA <- result[[2]]
    SRFTEMP <- result[[3]]
    ST <- result[[4]]
    return (list ("CUMDPT" = CUMDPT,"DSMID" = DSMID,"TDL" = TDL,"TMA" = TMA,"ATOT" = ATOT,"SRFTEMP" = SRFTEMP,"ST" = ST))
}

SOILT <- function (NL,
         ALBEDO,
         B,
         CUMDPT,
         DOY,
         DP,
         HDAY,
         NLAYR,
         PESW,
         SRAD,
         TAMP,
         TAV,
         TAVG,
         TMAX,
         WW,
         DSMID,
         ATOT,
         TMA){
    K <- 0
    L <- 0
    ALX <- 0.0
    DD <- 0.0
    DT <- 0.0
    FX <- 0.0
    SRFTEMP <- 0.0
    TA <- 0.0
    WC <- 0.0
    ZD <- 0.0
    ST <- vector(,NL)
    ALX <- (as.double(DOY) - HDAY) * 0.0174
    ATOT <- ATOT - TMA[5 - 1+1]
    for( K in seq(5, 2 - 1+1, -1)){
        TMA[K - 1+1] <- TMA[K - 1 - 1+1]
    }
    TMA[1 - 1+1] <- TAVG
    TMA[1 - 1+1] <- as.integer(TMA[(1 - 1)+1] * 10000.) / 10000.
    ATOT <- ATOT + TMA[1 - 1+1]
    WC <- max(0.01, PESW) / (WW * CUMDPT) * 10.0
    FX <- exp(B * ((1.0 - WC) / (1.0 + WC)) ^ 2)
    DD <- FX * DP
    TA <- TAV + (TAMP * cos(ALX) / 2.0)
    DT <- ATOT / 5.0 - TA
    for( L in seq(1, NLAYR + 1-1, 1)){
        ZD <- -(DSMID[(L - 1)+1] / DD)
        ST[L - 1+1] <- TAV + ((TAMP / 2.0 * cos((ALX + ZD)) + DT) * exp(ZD))
    }
    SRFTEMP <- TAV + (TAMP / 2. * cos(ALX) + DT)
    return (list ("ATOT" = ATOT,"TMA" = TMA,"SRFTEMP" = SRFTEMP,"ST" = ST))
}