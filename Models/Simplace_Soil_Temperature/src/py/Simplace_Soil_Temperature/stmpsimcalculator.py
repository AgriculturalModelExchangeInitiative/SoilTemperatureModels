# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

#%%CyML Init Begin%%
def init_stmpsimcalculator(cSoilLayerDepth:'Array[float]',
         cFirstDayMeanTemp:float,
         cAVT:float,
         cABD:float,
         cDampingDepth:float,
         iSoilWaterContent:float,
         iSoilSurfaceTemperature:float):
    SoilTempArray:'array[float]'
    pSoilLayerDepth:'array[float]'
    SoilTempArray = None
    pSoilLayerDepth = None
    tProfileDepth:float
    additionalDepth:float
    firstAdditionalLayerHight:float
    layers:int
    tStmp:'array[float]'
    tz:'array[float]'
    i:int
    depth:float
    tProfileDepth = cSoilLayerDepth[len(cSoilLayerDepth) - 1]
    additionalDepth = cDampingDepth - tProfileDepth
    firstAdditionalLayerHight = additionalDepth - float(floor(additionalDepth))
    layers = int(abs(float(ceil(additionalDepth)))) + len(cSoilLayerDepth)
    tStmp = array("f", [0] * layers)
    tz = array("f", [0] * layers)
    for i in range(0 , len(tStmp) , 1):
        if i < len(cSoilLayerDepth):
            depth = cSoilLayerDepth[i]
        else:
            depth = tProfileDepth + firstAdditionalLayerHight + i - len(cSoilLayerDepth)
        tz[i] = depth
        tStmp[i] = (cFirstDayMeanTemp * (cDampingDepth - depth) + (cAVT * depth)) / cDampingDepth
    SoilTempArray = tStmp
    pSoilLayerDepth = tz
    return (SoilTempArray, pSoilLayerDepth)
#%%CyML Init End%%

def model_stmpsimcalculator(cSoilLayerDepth:'Array[float]',
         cFirstDayMeanTemp:float,
         cAVT:float,
         cABD:float,
         cDampingDepth:float,
         iSoilWaterContent:float,
         iSoilSurfaceTemperature:float,
         SoilTempArray:'Array[float]',
         pSoilLayerDepth:'Array[float]'):
    XLAG:float
    XLG1:float
    DP:float
    WC:float
    DD:float
    Z1:float
    i:int
    ZD:float
    RATE:float
    XLAG = .8
    XLG1 = 1 - XLAG
    DP = 1 + (2.5 * cABD / (cABD + exp(6.53 - (5.63 * cABD))))
    WC = 0.001 * iSoilWaterContent / ((.356 - (.144 * cABD)) * cSoilLayerDepth[(len(cSoilLayerDepth) - 1)])
    DD = exp(log(0.5 / DP) * ((1 - WC) / (1 + WC)) * 2) * DP
    Z1 = float(0)
    for i in range(0 , len(SoilTempArray) , 1):
        ZD = 0.5 * (Z1 + pSoilLayerDepth[i]) / DD
        RATE = ZD / (ZD + exp(-.8669 - (2.0775 * ZD))) * (cAVT - iSoilSurfaceTemperature)
        SoilTempArray[i] = XLAG * SoilTempArray[i] + (XLG1 * (RATE + iSoilSurfaceTemperature))
        Z1 = pSoilLayerDepth[i]
    return SoilTempArray