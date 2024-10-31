library(gsubfn)

#' @Title Initialization of the STMPsimCalculator model
#' @param cSoilLayerDepth (http://www.wurvoc.org/vocabularies/om-1.8/metre) Depth of soil layer constant (, 0.03-20.0) 
#' @param cFirstDayMeanTemp (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Mean air temperature on first day constant (, -40.0-50.0) 
#' @param cAVT (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Constant Temperature of deepest soil layer - use long term mean air temperature constant (, -10.0-20.0) 
#' @param cABD (http://www.wurvoc.org/vocabularies/om-1.8/tonne_per_cubic_metre) Mean bulk density constant (2.0, 1.0-4.0) 
#' @param cDampingDepth (http://www.wurvoc.org/vocabularies/om-1.8/metre) Initial value for damping depth of soil constant (6.0, 1.5-20.0) 
#' @param iSoilWaterContent (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Water content, sum of whole soil profile exogenous (5.0, 1.5-20.0) 
#'
#' @return
#'   \item SoilTempArray (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Array of soil temperatures in layers  state (-40.0-20.0) 
#'   \item rSoilTempArrayRate (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius_per_day) Array of daily temperature change state (-20-20.0) 
#'
#' @export
init_stmpsimcalculator <- function (cSoilLayerDepth,
         cFirstDayMeanTemp,
         cAVT,
         cABD,
         cDampingDepth,
         iSoilWaterContent){
    SoilTempArray<- vector()
    rSoilTempArrayRate<- vector()
    pSoilLayerDepth<- vector()
    SoilTempArray <- NULL
    rSoilTempArrayRate <- NULL
    pSoilLayerDepth <- NULL
    tStmp<- vector()
    tStmpRate<- vector()
    tz<- vector()
    tProfileDepth <- cSoilLayerDepth[length(cSoilLayerDepth) - 1+1]
    additionalDepth <- cDampingDepth - tProfileDepth
    firstAdditionalLayerHight <- additionalDepth - as.double(floor(additionalDepth))
    layers <- as.integer(abs(as.double(ceiling(additionalDepth)))) + length(cSoilLayerDepth)
    tStmp <- vector(, layers)
    tStmpRate <- vector(, layers)
    tz <- vector(, layers)
    for( i in seq(0, length(tStmp)-1, 1)){
        if (i < length(cSoilLayerDepth))
        {
            depth <- cSoilLayerDepth[i+1]
        }
        else
        {
            depth <- tProfileDepth + firstAdditionalLayerHight + i - length(cSoilLayerDepth)
        }
        tz[i+1] <- depth
        tStmp[i+1] <- (cFirstDayMeanTemp * (cDampingDepth - depth) + (cAVT * depth)) / cDampingDepth
    }
    rSoilTempArrayRate <- tStmpRate
    SoilTempArray <- tStmp
    pSoilLayerDepth <- tz
    return (list ("SoilTempArray" = SoilTempArray,"rSoilTempArrayRate" = rSoilTempArrayRate,"pSoilLayerDepth" = pSoilLayerDepth))
}

#' @Title STMPsimCalculator model
#' @Description as given in the documentation
#' @Authors Gunther Krauss 
#' @Institutions INRES Pflanzenbau, Uni Bonn
#' @Reference ('http://www.simplace.net/doc/simplace_modules/',)
#' @Version 001
#'
#' @param cSoilLayerDepth (http://www.wurvoc.org/vocabularies/om-1.8/metre) Depth of soil layer constant (, 0.03-20.0) 
#' @param cFirstDayMeanTemp (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Mean air temperature on first day constant (, -40.0-50.0) 
#' @param cAVT (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Constant Temperature of deepest soil layer - use long term mean air temperature constant (, -10.0-20.0) 
#' @param cABD (http://www.wurvoc.org/vocabularies/om-1.8/tonne_per_cubic_metre) Mean bulk density constant (2.0, 1.0-4.0) 
#' @param cDampingDepth (http://www.wurvoc.org/vocabularies/om-1.8/metre) Initial value for damping depth of soil constant (6.0, 1.5-20.0) 
#' @param iSoilWaterContent (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Water content, sum of whole soil profile exogenous (5.0, 1.5-20.0) 
#' @param iSoilSurfaceTemperature (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Temperature at soil surface auxiliary (, 1.5-20.0) 
#' @param SoilTempArray (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Array of soil temperatures in layers  state (, -40.0-50.0) 
#' @param rSoilTempArrayRate (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius_per_day) Array of daily temperature change state (, -20-20) 
#' @param pSoilLayerDepth (http://www.wurvoc.org/vocabularies/om-1.8/metre) Depth of soil layer plus additional depth state (, 0.03-20.0) 
#'
#' @return
#'   \item SoilTempArray (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Array of soil temperatures in layers  state (-40.0-20.0) 
#'   \item rSoilTempArrayRate (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius_per_day) Array of daily temperature change state (-20-20.0) 
#'
#' @export
model_stmpsimcalculator <- function (cSoilLayerDepth,
         cFirstDayMeanTemp,
         cAVT,
         cABD,
         cDampingDepth,
         iSoilWaterContent,
         iSoilSurfaceTemperature,
         SoilTempArray,
         rSoilTempArrayRate,
         pSoilLayerDepth){
    XLAG <- .8
    XLG1 <- 1 - XLAG
    DP <- 1 + (2.5 * cABD / (cABD + exp(6.53 - (5.63 * cABD))))
    WC <- 0.001 * iSoilWaterContent / ((.356 - (.144 * cABD)) * cSoilLayerDepth[(length(cSoilLayerDepth) - 1)+1])
    DD <- exp(log(0.5 / DP) * ((1 - WC) / (1 + WC)) * 2) * DP
    Z1 <- as.double(0)
    for( i in seq(0, length(SoilTempArray)-1, 1)){
        ZD <- 0.5 * (Z1 + pSoilLayerDepth[i+1]) / DD
        RATE <- ZD / (ZD + exp(-.8669 - (2.0775 * ZD))) * (cAVT - iSoilSurfaceTemperature)
        RATE <- XLG1 * (RATE + iSoilSurfaceTemperature - SoilTempArray[i+1])
        Z1 <- pSoilLayerDepth[i+1]
        rSoilTempArrayRate[i+1] <- RATE
        SoilTempArray[i+1] <- SoilTempArray[i+1] + rSoilTempArrayRate[i+1]
    }
    return (list ("SoilTempArray" = SoilTempArray,"rSoilTempArrayRate" = rSoilTempArrayRate))
}