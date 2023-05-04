# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Init Begin%%
def init_snowcovercalculator(cCarbonContent:float,
         iTempMax:float,
         iTempMin:float,
         iRadiation:float,
         iRAIN:float,
         iCropResidues:float,
         iPotentialSoilEvaporation:float,
         iLeafAreaIndex:float,
         iSoilTempArray:'Array[float]'):
    Albedo:float
    SnowWaterContent:float = 0.0
    SoilSurfaceTemperature:float = 0.0
    AgeOfSnow:int = 0
    Albedo = 0.0
    TMEAN:float
    TAMPL:float
    DST:float
    Albedo = 0.0226 * log(cCarbonContent, 10) + 0.1502
    TMEAN = 0.5 * (iTempMax + iTempMin)
    TAMPL = 0.5 * (iTempMax - iTempMin)
    DST = TMEAN + (TAMPL * (iRadiation * (1 - Albedo) - 14) / 20)
    SoilSurfaceTemperature = DST
    return (Albedo, SnowWaterContent, SoilSurfaceTemperature, AgeOfSnow)
#%%CyML Init End%%

def model_snowcovercalculator(cCarbonContent:float,
         iTempMax:float,
         iTempMin:float,
         iRadiation:float,
         iRAIN:float,
         iCropResidues:float,
         iPotentialSoilEvaporation:float,
         iLeafAreaIndex:float,
         iSoilTempArray:'Array[float]',
         Albedo:float,
         SnowWaterContent:float,
         SoilSurfaceTemperature:float,
         AgeOfSnow:int):
    SnowIsolationIndex:float
    tiCropResidues:float
    tiSoilTempArray:float
    TMEAN:float
    TAMPL:float
    DST:float
    tSoilSurfaceTemperature:float
    tSnowIsolationIndex:float
    SNOWEVAPORATION:float
    SNOWMELT:float
    EAJ:float
    ageOfSnowFactor:float
    SNPKT:float
    tiCropResidues = iCropResidues * 10.0
    tiSoilTempArray = iSoilTempArray[0]
    TMEAN = 0.5 * (iTempMax + iTempMin)
    TAMPL = 0.5 * (iTempMax - iTempMin)
    DST = TMEAN + (TAMPL * (iRadiation * (1 - Albedo) - 14) / 20)
    if iRAIN > float(0) and (tiSoilTempArray < float(1) or (SnowWaterContent > float(3) or SoilSurfaceTemperature < float(0))):
        SnowWaterContent = SnowWaterContent + iRAIN
    tSnowIsolationIndex = 1.0
    if tiCropResidues < float(10):
        tSnowIsolationIndex = tiCropResidues / (tiCropResidues + exp(5.34 - (2.4 * tiCropResidues)))
    if SnowWaterContent < 1E-10:
        tSnowIsolationIndex = tSnowIsolationIndex * 0.85
        tSoilSurfaceTemperature = 0.5 * (DST + ((1 - tSnowIsolationIndex) * DST) + (tSnowIsolationIndex * tiSoilTempArray))
    else:
        tSnowIsolationIndex = max(SnowWaterContent / (SnowWaterContent + exp(0.47 - (0.62 * SnowWaterContent))), tSnowIsolationIndex)
        tSoilSurfaceTemperature = (1 - tSnowIsolationIndex) * DST + (tSnowIsolationIndex * tiSoilTempArray)
    if SnowWaterContent == float(0) and not (iRAIN > float(0) and tiSoilTempArray < float(1)):
        SnowWaterContent = float(0)
    else:
        EAJ = .5
        if SnowWaterContent < float(5):
            EAJ = exp(-max((0.4 * iLeafAreaIndex), (0.1 * (tiCropResidues + 0.1))))
        SNOWEVAPORATION = iPotentialSoilEvaporation * EAJ
        ageOfSnowFactor = AgeOfSnow / (AgeOfSnow + exp(5.34 - (2.395 * AgeOfSnow)))
        SNPKT = .3333 * (2 * min(tSoilSurfaceTemperature, tiSoilTempArray) + iTempMax)
        if TMEAN > float(0):
            SNOWMELT = max(0, sqrt(iTempMax * iRadiation) * (1.52 + (.54 * ageOfSnowFactor * SNPKT)))
        else:
            SNOWMELT = float(0)
        if SNOWMELT + SNOWEVAPORATION > SnowWaterContent:
            SNOWMELT = SNOWMELT / (SNOWMELT + SNOWEVAPORATION) * SnowWaterContent
            SNOWEVAPORATION = SNOWEVAPORATION / (SNOWMELT + SNOWEVAPORATION) * SnowWaterContent
        SnowWaterContent = SnowWaterContent - (SNOWMELT + SNOWEVAPORATION)
        if SnowWaterContent < float(0):
            SnowWaterContent = float(0)
        if SnowWaterContent < float(5):
            AgeOfSnow = 0
        else:
            AgeOfSnow = AgeOfSnow + 1
    SnowIsolationIndex = tSnowIsolationIndex
    SoilSurfaceTemperature = tSoilSurfaceTemperature
    return (SnowWaterContent, SoilSurfaceTemperature, AgeOfSnow, SnowIsolationIndex)