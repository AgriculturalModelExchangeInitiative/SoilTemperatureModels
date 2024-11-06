library(gsubfn)

#' @Title Initialization of the SnowCoverCalculator model
#' @param cCarbonContent (http://www.wurvoc.org/vocabularies/om-1.8/percent) Carbon content of upper soil layer constant (0.5, 0.5-20.0) 
#' @param cInitialAgeOfSnow (http://www.wurvoc.org/vocabularies/om-1.8/percent) Initial age of snow constant (0, 0-) 
#' @param cInitialSnowWaterContent (http://www.wurvoc.org/vocabularies/om-1.8/percent) Initial snow water content constant (0.0, 0.0-1500.0) 
#' @param Albedo (http://www.wurvoc.org/vocabularies/om-1.8/one) Albedo constant (, 0.0-1.0) 
#' @param cSnowIsolationFactorA (http://www.wurvoc.org/vocabularies/om-1.8/one) Static part of the snow isolation index calculation constant (2.3, 0.0-10.0) 
#' @param cSnowIsolationFactorB (http://www.wurvoc.org/vocabularies/om-1.8/one) Dynamic part of the snow isolation index calculation constant (0.22, 0.0-1.0) 
#' @param iTempMax (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Daily maximum air temperature exogenous (, -40.0-50.0) 
#' @param iTempMin (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Daily minimum air temperature exogenous (, -40.0-50.0) 
#' @param iRadiation (http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre) Global Solar radiation exogenous (, 0.0-2000.0) 
#' @param iRAIN (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Rain amount exogenous (0.0, 0.0-60.0) 
#' @param iCropResidues (http://www.wurvoc.org/vocabularies/om-1.8/gram_per_square_metre) Crop residues plus above ground biomass exogenous (, 0.0-20000.0) 
#' @param iPotentialSoilEvaporation (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Potenial Evaporation exogenous (0.0, 0.0-12.0) 
#' @param iLeafAreaIndex (http://www.wurvoc.org/vocabularies/om-1.8/square_metre_per_square_metre) Leaf area index exogenous (, 0.0-10.0) 
#'
#' @return
#'   \item SnowWaterContent (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Snow water content state (0.0-) 
#'   \item SoilSurfaceTemperature (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Soil surface temperature state (-40.0-) 
#'   \item AgeOfSnow (http://www.wurvoc.org/vocabularies/om-1.8/day) Age of snow state (0-) 
#'
#' @export
init_snowcovercalculator <- function (cCarbonContent,
         cInitialAgeOfSnow,
         cInitialSnowWaterContent,
         Albedo,
         cSnowIsolationFactorA,
         cSnowIsolationFactorB,
         iTempMax,
         iTempMin,
         iRadiation,
         iRAIN,
         iCropResidues,
         iPotentialSoilEvaporation,
         iLeafAreaIndex){
    SnowWaterContent <- 0.0
    SoilSurfaceTemperature <- 0.0
    AgeOfSnow <- 0
    pInternalAlbedo <- 0.0
    if (Albedo == as.double(0))
    {
        pInternalAlbedo <- 0.0226 * log(cCarbonContent, 10) + 0.1502
    }
    else
    {
        pInternalAlbedo <- Albedo
    }
    TMEAN <- 0.5 * (iTempMax + iTempMin)
    TAMPL <- 0.5 * (iTempMax - iTempMin)
    DST <- TMEAN + (TAMPL * (iRadiation * (1 - pInternalAlbedo) - 14) / 20)
    SoilSurfaceTemperature <- DST
    AgeOfSnow <- cInitialAgeOfSnow
    SnowWaterContent <- cInitialSnowWaterContent
    return (list ("pInternalAlbedo" = pInternalAlbedo,"SnowWaterContent" = SnowWaterContent,"SoilSurfaceTemperature" = SoilSurfaceTemperature,"AgeOfSnow" = AgeOfSnow))
}

#' @Title SnowCoverCalculator model
#' @Description as given in the documentation
#' @Authors Gunther Krauss 
#' @Institutions INRES Pflanzenbau, Uni Bonn
#' @Reference ('http://www.simplace.net/doc/simplace_modules/',)
#' @Version 001
#'
#' @param cCarbonContent (http://www.wurvoc.org/vocabularies/om-1.8/percent) Carbon content of upper soil layer constant (0.5, 0.5-20.0) 
#' @param cInitialAgeOfSnow (http://www.wurvoc.org/vocabularies/om-1.8/percent) Initial age of snow constant (0, 0-) 
#' @param cInitialSnowWaterContent (http://www.wurvoc.org/vocabularies/om-1.8/percent) Initial snow water content constant (0.0, 0.0-1500.0) 
#' @param Albedo (http://www.wurvoc.org/vocabularies/om-1.8/one) Albedo constant (, 0.0-1.0) 
#' @param pInternalAlbedo (http://www.wurvoc.org/vocabularies/om-1.8/one) Albedo privat state (, 0.0-1.0) 
#' @param cSnowIsolationFactorA (http://www.wurvoc.org/vocabularies/om-1.8/one) Static part of the snow isolation index calculation constant (2.3, 0.0-10.0) 
#' @param cSnowIsolationFactorB (http://www.wurvoc.org/vocabularies/om-1.8/one) Dynamic part of the snow isolation index calculation constant (0.22, 0.0-1.0) 
#' @param iTempMax (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Daily maximum air temperature exogenous (, -40.0-50.0) 
#' @param iTempMin (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Daily minimum air temperature exogenous (, -40.0-50.0) 
#' @param iRadiation (http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre) Global Solar radiation exogenous (, 0.0-2000.0) 
#' @param iRAIN (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Rain amount exogenous (0.0, 0.0-60.0) 
#' @param iCropResidues (http://www.wurvoc.org/vocabularies/om-1.8/gram_per_square_metre) Crop residues plus above ground biomass exogenous (, 0.0-20000.0) 
#' @param iPotentialSoilEvaporation (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Potenial Evaporation exogenous (0.0, 0.0-12.0) 
#' @param iLeafAreaIndex (http://www.wurvoc.org/vocabularies/om-1.8/square_metre_per_square_metre) Leaf area index exogenous (, 0.0-10.0) 
#' @param iSoilTempArray (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Soil Temp array of last day auxiliary (, -15.0-35.0) 
#' @param SnowWaterContent (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Snow water content state (0.0, 0.0-1500.0) 
#' @param SoilSurfaceTemperature (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Soil surface temperature state (0.0, -40.0-70.0) 
#' @param AgeOfSnow (http://www.wurvoc.org/vocabularies/om-1.8/day) Age of snow state (0, 0-) 
#'
#' @return
#'   \item SnowWaterContent (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Snow water content state (0.0-) 
#'   \item SoilSurfaceTemperature (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Soil surface temperature state (-40.0-) 
#'   \item AgeOfSnow (http://www.wurvoc.org/vocabularies/om-1.8/day) Age of snow state (0-) 
#'   \item rSnowWaterContentRate (http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day) daily snow water content change rate rate (-1500.0-) 
#'   \item rSoilSurfaceTemperatureRate (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius_per_day) daily soil surface temperature change rate rate (-40.0-) 
#'   \item rAgeOfSnowRate (http://www.wurvoc.org/vocabularies/om-1.8/one) daily age of snow change rate rate (-) 
#'   \item SnowIsolationIndex (http://www.wurvoc.org/vocabularies/om-1.8/one) Snow isolation index auxiliary (0.0-) 
#'
#' @export
model_snowcovercalculator <- function (cCarbonContent,
         cInitialAgeOfSnow,
         cInitialSnowWaterContent,
         Albedo,
         pInternalAlbedo,
         cSnowIsolationFactorA,
         cSnowIsolationFactorB,
         iTempMax,
         iTempMin,
         iRadiation,
         iRAIN,
         iCropResidues,
         iPotentialSoilEvaporation,
         iLeafAreaIndex,
         iSoilTempArray,
         SnowWaterContent,
         SoilSurfaceTemperature,
         AgeOfSnow){
    tiCropResidues <- iCropResidues * 10.0
    tiSoilTempArray <- iSoilTempArray[1]
    TMEAN <- 0.5 * (iTempMax + iTempMin)
    TAMPL <- 0.5 * (iTempMax - iTempMin)
    DST <- TMEAN + (TAMPL * (iRadiation * (1 - pInternalAlbedo) - 14) / 20)
    if (iRAIN > as.double(0) && (tiSoilTempArray < as.double(1) || (SnowWaterContent > as.double(3) || SoilSurfaceTemperature < as.double(0))))
    {
        SnowWaterContent <- SnowWaterContent
    }
    tSnowIsolationIndex <- 1.0
    if (tiCropResidues < as.double(10))
    {
        tSnowIsolationIndex <- tiCropResidues / (tiCropResidues + exp(5.34 - (2.4 * tiCropResidues)))
    }
    if (SnowWaterContent < 1E-10)
    {
        tSnowIsolationIndex <- tSnowIsolationIndex * 0.85
        tSoilSurfaceTemperature <- 0.5 * (DST + ((1 - tSnowIsolationIndex) * DST) + (tSnowIsolationIndex * tiSoilTempArray))
    }
    else
    {
        tSnowIsolationIndex <- max(SnowWaterContent / (SnowWaterContent + exp(cSnowIsolationFactorA - (cSnowIsolationFactorB * SnowWaterContent))), tSnowIsolationIndex)
        tSoilSurfaceTemperature <- (1 - tSnowIsolationIndex) * DST + (tSnowIsolationIndex * tiSoilTempArray)
    }
    if (SnowWaterContent == as.double(0) && !(iRAIN > as.double(0) && tiSoilTempArray < as.double(1)))
    {
        SnowWaterContent <- as.double(0)
    }
    else
    {
        EAJ <- .5
        if (SnowWaterContent < as.double(5))
        {
            EAJ <- exp(-max((0.4 * iLeafAreaIndex), (0.1 * (tiCropResidues + 0.1))))
        }
        SNOWEVAPORATION <- iPotentialSoilEvaporation * EAJ
        ageOfSnowFactor <- AgeOfSnow / (AgeOfSnow + exp(5.34 - (2.395 * AgeOfSnow)))
        SNPKT <- .3333 * (2 * min(tSoilSurfaceTemperature, tiSoilTempArray) + iTempMax)
        if (TMEAN > as.double(0))
        {
            SNOWMELT <- max(0, sqrt(iTempMax * iRadiation) * (1.52 + (.54 * ageOfSnowFactor * SNPKT)))
        }
        else
        {
            SNOWMELT <- as.double(0)
        }
        if (SNOWMELT + SNOWEVAPORATION > SnowWaterContent)
        {
            SNOWMELT <- SNOWMELT / (SNOWMELT + SNOWEVAPORATION) * SnowWaterContent
            SNOWEVAPORATION <- SNOWEVAPORATION / (SNOWMELT + SNOWEVAPORATION) * SnowWaterContent
        }
        SnowWaterContent <- SnowWaterContent - (SNOWMELT + SNOWEVAPORATION)
        if (SnowWaterContent < as.double(0))
        {
            SnowWaterContent <- as.double(0)
        }
        if (SnowWaterContent < as.double(5))
        {
            AgeOfSnow <- 0
        }
        else
        {
            AgeOfSnow <- AgeOfSnow + 1
        }
    }
    rSnowWaterContentRate <- SnowWaterContent - SnowWaterContent
    rSoilSurfaceTemperatureRate <- tSoilSurfaceTemperature - SoilSurfaceTemperature
    rAgeOfSnowRate <- AgeOfSnow - AgeOfSnow
    SoilSurfaceTemperature <- tSoilSurfaceTemperature
    SnowIsolationIndex <- tSnowIsolationIndex
    return (list ("SnowWaterContent" = SnowWaterContent,"SoilSurfaceTemperature" = SoilSurfaceTemperature,"AgeOfSnow" = AgeOfSnow,"rSnowWaterContentRate" = rSnowWaterContentRate,"rSoilSurfaceTemperatureRate" = rSoilSurfaceTemperatureRate,"rAgeOfSnowRate" = rAgeOfSnowRate,"SnowIsolationIndex" = SnowIsolationIndex))
}