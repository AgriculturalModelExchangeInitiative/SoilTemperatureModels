library(gsubfn)
#setwd('d:/Docs/AMEI_Workshop/AMEI_10_14_2022/Models/Simplace_Soil_Temperature/src/r')
source('Snowcovercalculator.r')
source('Stmpsimcalculator.r')
#' @Title Initialization of SoilTemperature component
#' 
#' @param cCarbonContent (http://www.wurvoc.org/vocabularies/om-1.8/percent) Carbon content of upper soil layer constant (0.5, 0.5-20.0) 
#' @param Albedo (http://www.wurvoc.org/vocabularies/om-1.8/one) Albedo constant (, 0.0-1.0) 
#' @param cInitialAgeOfSnow (http://www.wurvoc.org/vocabularies/om-1.8/percent) Initial age of snow constant (0, 0-) 
#' @param cInitialSnowWaterContent (http://www.wurvoc.org/vocabularies/om-1.8/percent) Initial snow water content constant (0.0, 0.0-1500.0) 
#' @param cSnowIsolationFactorA (http://www.wurvoc.org/vocabularies/om-1.8/one) Static part of the snow isolation index calculation constant (2.3, 0.0-10.0) 
#' @param cSnowIsolationFactorB (http://www.wurvoc.org/vocabularies/om-1.8/one) Dynamic part of the snow isolation index calculation constant (0.22, 0.0-1.0) 
#' @param iTempMax (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Daily maximum air temperature exogenous (, -40.0-50.0) 
#' @param iTempMin (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Daily minimum air temperature exogenous (, -40.0-50.0) 
#' @param iRadiation (http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre) Global Solar radiation exogenous (, 0.0-2000.0) 
#' @param iRAIN (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Rain amount exogenous (0.0, 0.0-60.0) 
#' @param iCropResidues (http://www.wurvoc.org/vocabularies/om-1.8/gram_per_square_metre) Crop residues plus above ground biomass exogenous (, 0.0-20000.0) 
#' @param iPotentialSoilEvaporation (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Potenial Evaporation exogenous (0.0, 0.0-12.0) 
#' @param iLeafAreaIndex (http://www.wurvoc.org/vocabularies/om-1.8/square_metre_per_square_metre) Leaf area index exogenous (, 0.0-10.0) 
#' @param cSoilLayerDepth (http://www.wurvoc.org/vocabularies/om-1.8/metre) Depth of soil layer constant (, 0.03-20.0) 
#' @param cFirstDayMeanTemp (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Mean air temperature on first day constant (, -40.0-50.0) 
#' @param cAVT (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Constant Temperature of deepest soil layer - use long term mean air temperature constant (, -10.0-20.0) 
#' @param cABD (http://www.wurvoc.org/vocabularies/om-1.8/tonne_per_cubic_metre) Mean bulk density constant (2.0, 1.0-4.0) 
#' @param cDampingDepth (http://www.wurvoc.org/vocabularies/om-1.8/metre) Initial value for damping depth of soil constant (6.0, 1.5-20.0) 
#' @param iSoilWaterContent (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Water content, sum of whole soil profile exogenous (5.0, 1.5-20.0) 
#'
#' @return
#'   \item SnowWaterContent (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Snow water content state (0.0-20.0) 
#'   \item SoilSurfaceTemperature (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Soil surface temperature state (-40.0-20.0) 
#'   \item AgeOfSnow (http://www.wurvoc.org/vocabularies/om-1.8/day) Age of snow state (0-20.0) 
#'   \item SoilTempArray (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Array of soil temperatures in layers  state (-40.0-20.0) 
#'   \item rSoilTempArrayRate (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius_per_day) Array of daily temperature change state (-20-20.0) 
#'
#' @export
init_SoilTemperature <- function(cCarbonContent, cAlbedo, cInitialAgeOfSnow, cInitialSnowWaterContent, cSnowIsolationFactorA, cSnowIsolationFactorB, iAirTemperatureMax, iAirTemperatureMin, iGlobalSolarRadiation, iRAIN, iCropResidues, iPotentialSoilEvaporation, iLeafAreaIndex, cSoilLayerDepth, cFirstDayMeanTemp, cAverageGroundTemperature, cAverageBulkDensity, cDampingDepth, iSoilWaterContent){
    Albedo <- cAlbedo
    iTempMax <- iAirTemperatureMax
    iTempMin <- iAirTemperatureMin
    iRadiation <- iGlobalSolarRadiation
    cAVT <- cAverageGroundTemperature
    cABD <- cAverageBulkDensity
    i_snowcovercalculator <- init_snowcovercalculator(cCarbonContent, cInitialAgeOfSnow, cInitialSnowWaterContent, Albedo, cSnowIsolationFactorA, cSnowIsolationFactorB, iTempMax, iTempMin, iRadiation, iRAIN, iCropResidues, iPotentialSoilEvaporation, iLeafAreaIndex)
    i_stmpsimcalculator <- init_stmpsimcalculator(cSoilLayerDepth, cFirstDayMeanTemp, cAVT, cABD, cDampingDepth, iSoilWaterContent)
    return (list ("SnowWaterContent" = SnowWaterContent,"SoilSurfaceTemperature" = SoilSurfaceTemperature,"AgeOfSnow" = AgeOfSnow,"SoilTempArray" = SoilTempArray,"rSoilTempArrayRate" = rSoilTempArrayRate))}

#' @Title SoilTemperature model
#' @Description as given in the documentation
#' @Authors Gunther Krauss 
#' @Institutions INRES Pflanzenbau, Uni Bonn
#' @Reference ('http://www.simplace.net/doc/simplace_modules/',)
#' @Version 001
#'
#' @param cCarbonContent (http://www.wurvoc.org/vocabularies/om-1.8/percent) Carbon content of upper soil layer constant (0.5, 0.5-20.0) 
#' @param cAlbedo (http://www.wurvoc.org/vocabularies/om-1.8/one) Albedo constant (, 0.0-1.0) 
#' @param cInitialAgeOfSnow (http://www.wurvoc.org/vocabularies/om-1.8/percent) Initial age of snow constant (0, 0-) 
#' @param cInitialSnowWaterContent (http://www.wurvoc.org/vocabularies/om-1.8/percent) Initial snow water content constant (0.0, 0.0-1500.0) 
#' @param cSnowIsolationFactorA (http://www.wurvoc.org/vocabularies/om-1.8/one) Static part of the snow isolation index calculation constant (2.3, 0.0-10.0) 
#' @param cSnowIsolationFactorB (http://www.wurvoc.org/vocabularies/om-1.8/one) Dynamic part of the snow isolation index calculation constant (0.22, 0.0-1.0) 
#' @param iAirTemperatureMax (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Daily maximum air temperature exogenous (, -40.0-50.0) 
#' @param iAirTemperatureMin (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Daily minimum air temperature exogenous (, -40.0-50.0) 
#' @param iGlobalSolarRadiation (http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre) Global Solar radiation exogenous (, 0.0-2000.0) 
#' @param iRAIN (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Rain amount exogenous (0.0, 0.0-60.0) 
#' @param iCropResidues (http://www.wurvoc.org/vocabularies/om-1.8/gram_per_square_metre) Crop residues plus above ground biomass exogenous (, 0.0-20000.0) 
#' @param iPotentialSoilEvaporation (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Potenial Evaporation exogenous (0.0, 0.0-12.0) 
#' @param iLeafAreaIndex (http://www.wurvoc.org/vocabularies/om-1.8/square_metre_per_square_metre) Leaf area index exogenous (, 0.0-10.0) 
#' @param SoilTempArray (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Soil Temp array of last day auxiliary (, -15.0-35.0) 
#' @param cSoilLayerDepth (http://www.wurvoc.org/vocabularies/om-1.8/metre) Depth of soil layer constant (, 0.03-20.0) 
#' @param cFirstDayMeanTemp (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Mean air temperature on first day constant (, -40.0-50.0) 
#' @param cAverageGroundTemperature (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Constant Temperature of deepest soil layer - use long term mean air temperature constant (, -10.0-20.0) 
#' @param cAverageBulkDensity (http://www.wurvoc.org/vocabularies/om-1.8/tonne_per_cubic_metre) Mean bulk density constant (2.0, 1.0-4.0) 
#' @param cDampingDepth (http://www.wurvoc.org/vocabularies/om-1.8/metre) Initial value for damping depth of soil constant (6.0, 1.5-20.0) 
#' @param iSoilWaterContent (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Water content, sum of whole soil profile exogenous (5.0, 1.5-20.0) 
#' @param pInternalAlbedo (http://www.wurvoc.org/vocabularies/om-1.8/one) Albedo privat state (, 0.0-1.0) 
#' @param SnowWaterContent (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Snow water content state (0.0, 0.0-1500.0) 
#' @param SoilSurfaceTemperature (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Soil surface temperature state (0.0, -40.0-70.0) 
#' @param AgeOfSnow (http://www.wurvoc.org/vocabularies/om-1.8/day) Age of snow state (0, 0-) 
#' @param rSoilTempArrayRate (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius_per_day) Array of daily temperature change state (, -20-20) 
#' @param pSoilLayerDepth (http://www.wurvoc.org/vocabularies/om-1.8/metre) Depth of soil layer plus additional depth state (, 0.03-20.0) 
#'
#' @return
#'   \item SoilSurfaceTemperature (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Soil surface temperature state (-40.0-20.0) 
#'   \item SnowIsolationIndex (http://www.wurvoc.org/vocabularies/om-1.8/one) Snow isolation index auxiliary (0.0-20.0) 
#'   \item SnowWaterContent (http://www.wurvoc.org/vocabularies/om-1.8/millimetre) Snow water content state (0.0-20.0) 
#'   \item rSnowWaterContentRate (http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day) daily snow water content change rate rate (-1500.0-20.0) 
#'   \item rSoilSurfaceTemperatureRate (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius_per_day) daily soil surface temperature change rate rate (-40.0-20.0) 
#'   \item rAgeOfSnowRate (http://www.wurvoc.org/vocabularies/om-1.8/one) daily age of snow change rate rate (-20.0) 
#'   \item AgeOfSnow (http://www.wurvoc.org/vocabularies/om-1.8/day) Age of snow state (0-20.0) 
#'   \item SoilTempArray (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius) Array of soil temperatures in layers  state (-40.0-20.0) 
#'   \item rSoilTempArrayRate (http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius_per_day) Array of daily temperature change state (-20-20.0) 
#'
#' @export
model_soiltemperature <- function (cCarbonContent,
         cAlbedo,
         cInitialAgeOfSnow,
         cInitialSnowWaterContent,
         cSnowIsolationFactorA,
         cSnowIsolationFactorB,
         iAirTemperatureMax,
         iAirTemperatureMin,
         iGlobalSolarRadiation,
         iRAIN,
         iCropResidues,
         iPotentialSoilEvaporation,
         iLeafAreaIndex,
         SoilTempArray,
         cSoilLayerDepth,
         cFirstDayMeanTemp,
         cAverageGroundTemperature,
         cAverageBulkDensity,
         cDampingDepth,
         iSoilWaterContent,
         pInternalAlbedo,
         SnowWaterContent,
         SoilSurfaceTemperature,
         AgeOfSnow,
         rSoilTempArrayRate,
         pSoilLayerDepth){
    iSoilTempArray<- vector()
    Albedo <- cAlbedo
    iTempMax <- iAirTemperatureMax
    iTempMin <- iAirTemperatureMin
    iRadiation <- iGlobalSolarRadiation
    iSoilTempArray <- SoilTempArray
    cAVT <- cAverageGroundTemperature
    cABD <- cAverageBulkDensity
    list[SnowWaterContent, SoilSurfaceTemperature, AgeOfSnow, rSnowWaterContentRate, rSoilSurfaceTemperatureRate, rAgeOfSnowRate, SnowIsolationIndex] <- model_snowcovercalculator(cCarbonContent, cInitialAgeOfSnow, cInitialSnowWaterContent, Albedo, pInternalAlbedo, cSnowIsolationFactorA, cSnowIsolationFactorB, iTempMax, iTempMin, iRadiation, iRAIN, iCropResidues, iPotentialSoilEvaporation, iLeafAreaIndex, iSoilTempArray, SnowWaterContent, SoilSurfaceTemperature, AgeOfSnow)
    iSoilSurfaceTemperature <- SoilSurfaceTemperature
    list[SoilTempArray, rSoilTempArrayRate] <- model_stmpsimcalculator(cSoilLayerDepth, cFirstDayMeanTemp, cAVT, cABD, cDampingDepth, iSoilWaterContent, iSoilSurfaceTemperature, SoilTempArray, rSoilTempArrayRate, pSoilLayerDepth)
    return (list ("SoilSurfaceTemperature" = SoilSurfaceTemperature,"SnowIsolationIndex" = SnowIsolationIndex,"SnowWaterContent" = SnowWaterContent,"rSnowWaterContentRate" = rSnowWaterContentRate,"rSoilSurfaceTemperatureRate" = rSoilSurfaceTemperatureRate,"rAgeOfSnowRate" = rAgeOfSnowRate,"AgeOfSnow" = AgeOfSnow,"SoilTempArray" = SoilTempArray,"rSoilTempArrayRate" = rSoilTempArrayRate))
}