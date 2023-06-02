# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Init Begin%%
def init_stemp_epic(NL:int,
         ISWWAT:str,
         BD:'Array[float]',
         DLAYR:'Array[float]',
         DS:'Array[float]',
         DUL:'Array[float]',
         LL:'Array[float]',
         NLAYR:int,
         TAMP:float,
         RAIN:float,
         SW:'Array[float]',
         TAVG:float,
         TMAX:float,
         TMIN:float,
         TAV:float,
         DEPIR:float,
         BIOMAS:float,
         MULCHMASS:float,
         SNOW:float):
    CUMDPT:float
    DSMID:'array[float]' = array('f',[0.0]*NL)
    TDL:float
    TMA:'array[float]' = array('f',[0.0]*5)
    NDays:int
    WetDay:'array[int]' = array('i',[0]*30)
    X2_PREV:float
    SRFTEMP:float
    ST:'array[float]' = array('f',[0.0]*NL)
    CUMDPT = 0.0
    DSMID = array('f', [0.0]*NL)
    TDL = 0.0
    TMA = array('f', [0.0]*5)
    NDays = 0
    WetDay = array('i', [0]*30)
    X2_PREV = 0.0
    SRFTEMP = 0.0
    ST = array('f', [0.0]*NL)
    I:int
    L:int
    ABD:float
    B:float
    DP:float
    FX:float
    PESW:float
    TBD:float
    WW:float
    TLL:float
    TSW:float
    X2_AVG:float
    WFT:float
    BCV:float
    CV:float
    BCV1:float
    BCV2:float
    SWI:'array[float]' = array('f',[0.0]*NL)
    SWI = SW
    TBD = 0.0
    TLL = 0.0
    TSW = 0.0
    TDL = 0.0
    CUMDPT = 0.0
    for L in range(1 , NLAYR + 1 , 1):
        DSMID[L - 1] = CUMDPT + (DLAYR[(L - 1)] * 5.0)
        CUMDPT = CUMDPT + (DLAYR[(L - 1)] * 10.0)
        TBD = TBD + (BD[(L - 1)] * DLAYR[(L - 1)])
        TLL = TLL + (LL[(L - 1)] * DLAYR[(L - 1)])
        TSW = TSW + (SWI[(L - 1)] * DLAYR[(L - 1)])
        TDL = TDL + (DUL[(L - 1)] * DLAYR[(L - 1)])
    if ISWWAT == "Y":
        PESW = max(0.0, TSW - TLL)
    else:
        PESW = max(0.0, TDL - TLL)
    ABD = TBD / DS[(NLAYR - 1)]
    FX = ABD / (ABD + (686.0 * exp(-(5.63 * ABD))))
    DP = 1000.0 + (2500.0 * FX)
    WW = 0.356 - (0.144 * ABD)
    B = log(500.0 / DP)
    for I in range(1 , 5 + 1 , 1):
        TMA[I - 1] = int(TAVG * 10000.) / 10000.
    X2_AVG = TMA[(1 - 1)] * 5.0
    for L in range(1 , NLAYR + 1 , 1):
        ST[L - 1] = TAVG
    WFT = 0.1
    WetDay = array('i', [0]*30)
    NDays = 0
    CV = MULCHMASS / 1000.
    BCV1 = CV / (CV + exp(5.3396 - (2.3951 * CV)))
    BCV2 = SNOW / (SNOW + exp(2.303 - (0.2197 * SNOW)))
    BCV = max(BCV1, BCV2)
    for I in range(1 , 8 + 1 , 1):
        (TMA, SRFTEMP, ST, X2_AVG, X2_PREV) = SOILT_EPIC(NL, B, BCV, CUMDPT, DP, DSMID, NLAYR, PESW, TAV, TAVG, TMAX, TMIN, 0, WFT, WW, TMA, ST, X2_PREV)
    return (CUMDPT, DSMID, TDL, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST)
#%%CyML Init End%%

def model_stemp_epic(NL:int,
         ISWWAT:str,
         BD:'Array[float]',
         DLAYR:'Array[float]',
         DS:'Array[float]',
         DUL:'Array[float]',
         LL:'Array[float]',
         NLAYR:int,
         TAMP:float,
         RAIN:float,
         SW:'Array[float]',
         TAVG:float,
         TMAX:float,
         TMIN:float,
         TAV:float,
         CUMDPT:float,
         DSMID:'Array[float]',
         TDL:float,
         TMA:'Array[float]',
         NDays:int,
         WetDay:'Array[int]',
         X2_PREV:float,
         SRFTEMP:float,
         ST:'Array[float]',
         DEPIR:float,
         BIOMAS:float,
         MULCHMASS:float,
         SNOW:float):
    I:int
    L:int
    NWetDays:int
    ABD:float
    B:float
    DP:float
    FX:float
    PESW:float
    TBD:float
    WW:float
    TLL:float
    TSW:float
    X2_AVG:float
    WFT:float
    BCV:float
    CV:float
    BCV1:float
    BCV2:float
    TBD = 0.0
    TLL = 0.0
    TSW = 0.0
    for L in range(1 , NLAYR + 1 , 1):
        TBD = TBD + (BD[(L - 1)] * DLAYR[(L - 1)])
        TDL = TDL + (DUL[(L - 1)] * DLAYR[(L - 1)])
        TLL = TLL + (LL[(L - 1)] * DLAYR[(L - 1)])
        TSW = TSW + (SW[(L - 1)] * DLAYR[(L - 1)])
    ABD = TBD / DS[(NLAYR - 1)]
    FX = ABD / (ABD + (686.0 * exp(-(5.63 * ABD))))
    DP = 1000.0 + (2500.0 * FX)
    WW = 0.356 - (0.144 * ABD)
    B = log(500.0 / DP)
    if ISWWAT == "Y":
        PESW = max(0.0, TSW - TLL)
    else:
        PESW = max(0.0, TDL - TLL)
    if NDays == 30:
        for I in range(1 , 29 + 1 , 1):
            WetDay[I - 1] = WetDay[I + 1 - 1]
    else:
        NDays = NDays + 1
    if RAIN + DEPIR > 1.E-6:
        WetDay[NDays - 1] = 1
    else:
        WetDay[NDays - 1] = 0
    NWetDays = sum(WetDay)
    WFT = float(NWetDays) / float(NDays)
    CV = (BIOMAS + MULCHMASS) / 1000.
    BCV1 = CV / (CV + exp(5.3396 - (2.3951 * CV)))
    BCV2 = SNOW / (SNOW + exp(2.303 - (0.2197 * SNOW)))
    BCV = max(BCV1, BCV2)
    (TMA, SRFTEMP, ST, X2_AVG, X2_PREV) = SOILT_EPIC(NL, B, BCV, CUMDPT, DP, DSMID, NLAYR, PESW, TAV, TAVG, TMAX, TMIN, WetDay[NDays - 1], WFT, WW, TMA, ST, X2_PREV)
    return (CUMDPT, DSMID, TDL, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST)

def SOILT_EPIC(NL:int,
         B:float,
         BCV:float,
         CUMDPT:float,
         DP:float,
         DSMID:'Array[float]',
         NLAYR:int,
         PESW:float,
         TAV:float,
         TAVG:float,
         TMAX:float,
         TMIN:float,
         WetDay:int,
         WFT:float,
         WW:float,
         TMA:'Array[float]',
         ST:'Array[float]',
         X2_PREV:float):
    K:int
    L:int
    DD:float
    FX:float
    SRFTEMP:float
    WC:float
    ZD:float
    X1:float
    X2:float
    X3:float
    F:float
    X2_AVG:float
    LAG:float
    LAG = 0.5
    WC = max(0.01, PESW) / (WW * CUMDPT) * 10.0
    FX = exp(B * pow((1.0 - WC) / (1.0 + WC), 2))
    DD = FX * DP
    if WetDay > 0:
        X2 = WFT * (TAVG - TMIN) + TMIN
    else:
        X2 = WFT * (TMAX - TAVG) + TAVG + 2.
    TMA[1 - 1] = X2
    for K in range(5 , 2 - 1 , -1):
        TMA[K - 1] = TMA[K - 1 - 1]
    X2_AVG = sum(TMA) / 5.0
    X3 = (1. - BCV) * X2_AVG + (BCV * X2_PREV)
    SRFTEMP = min(X2_AVG, X3)
    X1 = TAV - X3
    for L in range(1 , NLAYR + 1 , 1):
        ZD = DSMID[(L - 1)] / DD
        F = ZD / (ZD + exp(-.8669 - (2.0775 * ZD)))
        ST[L - 1] = LAG * ST[(L - 1)] + ((1. - LAG) * (F * X1 + X3))
    X2_PREV = X2_AVG
    return (TMA, SRFTEMP, ST, X2_AVG, X2_PREV)