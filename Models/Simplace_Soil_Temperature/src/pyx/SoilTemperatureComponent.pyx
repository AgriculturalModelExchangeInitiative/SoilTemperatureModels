from datetime import datetime
from math import *
from Simplace_Soil_Temperature.snowcovercalculator import model_snowcovercalculator
from Simplace_Soil_Temperature.stmpsimcalculator import model_stmpsimcalculator
def model_soiltemperature(float cCarbonContent,
      float iAirTemperatureMax,
      float iAirTemperatureMin,
      float iGlobalSolarRadiation,
      float iRAIN,
      float iCropResidues,
      float iPotentialSoilEvaporation,
      float iLeafAreaIndex,
      float SoilTempArray[],
      float cSoilLayerDepth[],
      float cFirstDayMeanTemp,
      float cAverageGroundTemperature,
      float cAverageBulkDensity,
      float cDampingDepth,
      float iSoilWaterContent,
      float Albedo,
      float SnowWaterContent,
      float SoilSurfaceTemperature,
      int AgeOfSnow,
      float rSoilTempArrayRate[],
      float pSoilLayerDepth[]):
    cdef float iTempMax
    cdef float iTempMin
    cdef float iRadiation
    cdef float iSoilTempArray[]
    cdef float SnowIsolationIndex
    cdef float cAVT
    cdef float cABD
    cdef float iSoilSurfaceTemperature
    iTempMax = iAirTemperatureMax 
    iTempMin = iAirTemperatureMin 
    iRadiation = iGlobalSolarRadiation 
    iSoilTempArray = SoilTempArray 
    cAVT = cAverageGroundTemperature 
    cABD = cAverageBulkDensity 
    SnowWaterContent, SoilSurfaceTemperature, AgeOfSnow, SnowIsolationIndex = model_snowcovercalculator( cCarbonContent,iTempMax,iTempMin,iRadiation,iRAIN,iCropResidues,iPotentialSoilEvaporation,iLeafAreaIndex,iSoilTempArray,Albedo,SnowWaterContent,SoilSurfaceTemperature,AgeOfSnow)
    iSoilSurfaceTemperature = SoilSurfaceTemperature
    SoilTempArray, rSoilTempArrayRate = model_stmpsimcalculator( cSoilLayerDepth,cFirstDayMeanTemp,cAVT,cABD,cDampingDepth,iSoilWaterContent,iSoilSurfaceTemperature,SoilTempArray,rSoilTempArrayRate,pSoilLayerDepth)
    return SoilSurfaceTemperature, SnowIsolationIndex, SnowWaterContent, SoilTempArray, AgeOfSnow, rSoilTempArrayRate