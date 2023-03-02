# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Init Begin%%
def init_stemp(NL:int,
         ISWWAT:str,
         BD:'Array[float]',
         DLAYR:'Array[float]',
         DS:'Array[float]',
         DUL:'Array[float]',
         LL:'Array[float]',
         NLAYR:int,
         MSALB:float,
         SRAD:float,
         SW:'Array[float]',
         TAVG:float,
         TMAX:float,
         XLAT:float,
         TAV:float,
         TAMP:float,
         DOY:int):
    CUMDPT:float
    DSMID:'array[float]' = array('f',[0.0]*NL)
    TMA:'array[float]' = array('f',[0.0]*NL)
    ATOT:float
    SRFTEMP:float
    ST:'array[float]' = array('f',[0.0]*NL)
    CUMDPT = 0.0
    DSMID = array('f', [0.0]*NL)
    TMA = array('f', [0.0]*NL)
    ATOT = 0.0
    SRFTEMP = 0.0
    ST = array('f', [0.0]*NL)
    I:int
    L:int
    ABD:float
    ALBEDO:float
    B:float
    DP:float
    FX:float
    HDAY:float
    PESW:float
    TBD:float
    WW:float
    TDL:float
    TLL:float
    TSW:float
    DLI:'array[float]' = array('f',[0.0]*NL)
    DSI:'array[float]' = array('f',[0.0]*NL)
    SWI:'array[float]' = array('f',[0.0]*NL)
    SWI = SW
    DSI = DS
    if XLAT < 0.0:
        HDAY = 20.0
    else:
        HDAY = 200.0
    TBD = 0.0
    TLL = 0.0
    TSW = 0.0
    TDL = 0.0
    CUMDPT = 0.0
    for L in range(1 , NLAYR + 1 , 1):
        if L == 1:
            DLI[L - 1] = DSI[L - 1]
        else:
            DLI[L - 1] = DSI[L - 1] - DSI[L - 1 - 1]
        DSMID[L - 1] = CUMDPT + (DLI[(L - 1)] * 5.0)
        CUMDPT = CUMDPT + (DLI[(L - 1)] * 10.0)
        TBD = TBD + (BD[(L - 1)] * DLI[(L - 1)])
        TLL = TLL + (LL[(L - 1)] * DLI[(L - 1)])
        TSW = TSW + (SWI[(L - 1)] * DLI[(L - 1)])
        TDL = TDL + (DUL[(L - 1)] * DLI[(L - 1)])
    if ISWWAT == "Y":
        PESW = max(0.0, TSW - TLL)
    else:
        PESW = max(0.0, TDL - TLL)
    ABD = TBD / DSI[(NLAYR - 1)]
    FX = ABD / (ABD + (686.0 * exp(-(5.63 * ABD))))
    DP = 1000.0 + (2500.0 * FX)
    WW = 0.356 - (0.144 * ABD)
    B = log(500.0 / DP)
    ALBEDO = MSALB
    for I in range(1 , 5 + 1 , 1):
        TMA[I - 1] = int(TAVG * 10000.) / 10000.
    ATOT = TMA[(1 - 1)] * 5.0
    for L in range(1 , NLAYR + 1 , 1):
        ST[L - 1] = TAVG
    for I in range(1 , 8 + 1 , 1):
        (ATOT, TMA, SRFTEMP, ST) = SOILT(NL, ALBEDO, B, CUMDPT, DOY, DP, HDAY, NLAYR, PESW, SRAD, TAMP, TAV, TAVG, TMAX, WW, DSMID, ATOT, TMA)
    return (CUMDPT, DSMID, TMA, ATOT, SRFTEMP, ST)
#%%CyML Init End%%

def model_stemp(NL:int,
         ISWWAT:str,
         BD:'Array[float]',
         DLAYR:'Array[float]',
         DS:'Array[float]',
         DUL:'Array[float]',
         LL:'Array[float]',
         NLAYR:int,
         MSALB:float,
         SRAD:float,
         SW:'Array[float]',
         TAVG:float,
         TMAX:float,
         XLAT:float,
         TAV:float,
         TAMP:float,
         CUMDPT:float,
         DSMID:'Array[float]',
         TMA:'Array[float]',
         ATOT:float,
         SRFTEMP:float,
         ST:'Array[float]',
         DOY:int):
    I:int
    L:int
    ABD:float
    ALBEDO:float
    B:float
    DP:float
    FX:float
    HDAY:float
    PESW:float
    TBD:float
    WW:float
    TDL:float
    TLL:float
    TSW:float
    TBD = 0.0
    TLL = 0.0
    TSW = 0.0
    TDL = 0.0
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
    ALBEDO = MSALB
    if ISWWAT == "Y":
        PESW = max(0.0, TSW - TLL)
    else:
        PESW = max(0.0, TDL - TLL)
    (ATOT, TMA, SRFTEMP, ST) = SOILT(NL, ALBEDO, B, CUMDPT, DOY, DP, HDAY, NLAYR, PESW, SRAD, TAMP, TAV, TAVG, TMAX, WW, DSMID, ATOT, TMA)
    return (CUMDPT, DSMID, TMA, ATOT, SRFTEMP, ST)

def SOILT(NL:int,
         ALBEDO:float,
         B:float,
         CUMDPT:float,
         DOY:int,
         DP:float,
         HDAY:float,
         NLAYR:int,
         PESW:float,
         SRAD:float,
         TAMP:float,
         TAV:float,
         TAVG:float,
         TMAX:float,
         WW:float,
         DSMID:'Array[float]',
         ATOT:float,
         TMA:'Array[float]'):
    K:int
    L:int
    ALX:float
    DD:float
    DT:float
    FX:float
    SRFTEMP:float
    TA:float
    WC:float
    ZD:float
    ST:'array[float]' = array('f',[0.0]*NL)
    ALX = (float(DOY) - HDAY) * 0.0174
    ATOT = ATOT - TMA[5 - 1]
    for K in range(5 , 2 - 1 , -1):
        TMA[K - 1] = TMA[K - 1 - 1]
    TMA[1 - 1] = (1.0 - ALBEDO) * (TAVG + ((TMAX - TAVG) * sqrt(SRAD * 0.03))) + (ALBEDO * TMA[(1 - 1)])
    TMA[1 - 1] = int(TMA[(1 - 1)] * 10000.) / 10000.
    ATOT = ATOT + TMA[1 - 1]
    WC = max(0.01, PESW) / (WW * CUMDPT) * 10.0
    FX = exp(B * pow((1.0 - WC) / (1.0 + WC), 2))
    DD = FX * DP
    TA = TAV + (TAMP * cos(ALX) / 2.0)
    DT = ATOT / 5.0 - TA
    for L in range(1 , NLAYR + 1 , 1):
        ZD = -(DSMID[(L - 1)] / DD)
        ST[L - 1] = TAV + ((TAMP / 2.0 * cos((ALX + ZD)) + DT) * exp(ZD))
        ST[L - 1] = int(ST[(L - 1)] * 1000.) / 1000.
    SRFTEMP = TAV + (TAMP / 2. * cos(ALX) + DT)
    return (ATOT, TMA, SRFTEMP, ST)