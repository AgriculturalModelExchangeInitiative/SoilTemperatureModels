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
    TDL:float
    TMA:'array[float]' = array('f',[0.0]*5)
    ATOT:float
    SRFTEMP:float
    ST:'array[float]' = array('f',[0.0]*NL)
    HDAY:float
    CUMDPT = 0.0
    DSMID = array('f', [0.0]*NL)
    TDL = 0.0
    TMA = array('f', [0.0]*5)
    ATOT = 0.0
    SRFTEMP = 0.0
    ST = array('f', [0.0]*NL)
    HDAY = 0.0
    I:int
    L:int
    ABD:float
    ALBEDO:float
    B:float
    DP:float
    FX:float
    PESW:float
    TBD:float
    WW:float
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
    return (CUMDPT, DSMID, TDL, TMA, ATOT, SRFTEMP, ST, HDAY)
#%%CyML Init End%%

#%%CyML Model Begin%%
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
         TDL:float,
         TMA:'Array[float]',
         ATOT:float,
         SRFTEMP:float,
         ST:'Array[float]',
         DOY:int,
         HDAY:float):
    """
     - Name: STEMP -Version:  1.0, -Time step:  1
     - Description:
                 * Title: Model of STEMP
                 * Authors: DSSAT 
                 * Reference: https://doi.org/10.2134/agronj1994.00021962008600060014x
                 * Institution: DSSAT Florida
                 * ExtendedDescription: None
                 * ShortDescription: Determines soil temperature by layer
     - inputs:
                 * name: NL
                               ** description : Number of soil layers
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : dimensionless
                 * name: ISWWAT
                               ** description : Water simulation control switch
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : STRING
                               ** max : 
                               ** min : 
                               ** default : Y
                               ** unit : dimensionless
                 * name: BD
                               ** description : Bulk density, soil layer NL
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : g [soil] / cm3 [soil]
                 * name: DLAYR
                               ** description : Thickness of soil layer L
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm
                 * name: DS
                               ** description : Cumulative depth in soil layer L
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm
                 * name: DUL
                               ** description : Volumetric soil water content at Drained Upper Limit in soil layer L
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm3[water]/cm3[soil]
                 * name: LL
                               ** description : Volumetric soil water content in soil layer L at lower limit
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm3 [water] / cm3 [soil]
                 * name: NLAYR
                               ** description : Actual number of soil layers
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : dimensionless
                 * name: MSALB
                               ** description : Soil albedo with mulch and soil water effects
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : dimensionless
                 * name: SRAD
                               ** description : Solar radiation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : MJ/m2-d
                 * name: SW
                               ** description : Volumetric soil water content in layer L
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm3 [water] / cm3 [soil]
                 * name: TAVG
                               ** description : Average daily temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: TMAX
                               ** description : Maximum daily temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: XLAT
                               ** description : Latitude
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: TAV
                               ** description : Average annual soil temperature, used with TAMP to calculate soil temperature.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: TAMP
                               ** description : Amplitude of temperature function used to calculate soil temperatures
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: CUMDPT
                               ** description : Cumulative depth of soil profile
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: DSMID
                               ** description : Depth to midpoint of soil layer L
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm
                 * name: TDL
                               ** description : Total water content of soil at drained upper limit
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm
                 * name: TMA
                               ** description : Array of previous 5 days of average soil temperatures
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 5
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: ATOT
                               ** description : Sum of TMA array (last 5 days soil temperature)
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: SRFTEMP
                               ** description : Temperature of soil surface litter
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: ST
                               ** description : Soil temperature in soil layer L
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: DOY
                               ** description : Current day of simulation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : d
                 * name: HDAY
                               ** description : Haverst day
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : day
     - outputs:
                 * name: CUMDPT
                               ** description : Cumulative depth of soil profile
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : mm
                 * name: DSMID
                               ** description : Depth to midpoint of soil layer L
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** unit : cm
                 * name: TDL
                               ** description : Total water content of soil at drained upper limit
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : cm
                 * name: TMA
                               ** description : Array of previous 5 days of average soil temperatures
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 5
                               ** max : 
                               ** min : 
                               ** unit : degC
                 * name: ATOT
                               ** description : Sum of TMA array (last 5 days soil temperature)
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : degC
                 * name: SRFTEMP
                               ** description : Temperature of soil surface litter
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : degC
                 * name: ST
                               ** description : Soil temperature in soil layer L
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** unit : degC
    """

    L:int
    ABD:float
    ALBEDO:float
    B:float
    DP:float
    FX:float
    PESW:float
    TBD:float
    WW:float
    TLL:float
    TSW:float
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
    ALBEDO = MSALB
    if ISWWAT == "Y":
        PESW = max(0.0, TSW - TLL)
    else:
        PESW = max(0.0, TDL - TLL)
    (ATOT, TMA, SRFTEMP, ST) = SOILT(NL, ALBEDO, B, CUMDPT, DOY, DP, HDAY, NLAYR, PESW, SRAD, TAMP, TAV, TAVG, TMAX, WW, DSMID, ATOT, TMA)
    return (CUMDPT, DSMID, TDL, TMA, ATOT, SRFTEMP, ST)
#%%CyML Model End%%

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
    TMA[1 - 1] = TAVG
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