# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_calculatehourlysoiltemperature(c:float,
         dayLength:float,
         maxTSoil:float,
         b:float,
         a:float,
         minTSoil:float):
    """
     - Name: CalculateHourlySoilTemperature -Version: 001, -Time step: 1
     - Description:
                 * Title: CalculateHourlySoilTemperature model
                 * Authors: loic.manceau@inra.fr
                 * Reference: ('http://biomamodelling.org',)
                 * Institution: INRA
                 * ExtendedDescription: Calculate Soil temperature on a hourly basis.Parton, W.J. and Logan, J.A., 1981. A model for diurnal variation in soil and air temperature. Agric. Meteorol., 23: 205-216
                 * ShortDescription: None
     - inputs:
                 * name: c
                               ** description : Nighttime temperature coefficient
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 0.49
                               ** unit : Dpmensionless
                 * name: dayLength
                               ** description : Length of the day
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 24
                               ** min : 0
                               ** default : 12
                               ** unit : hour
                 * name: maxTSoil
                               ** description : Maximum Soil Temperature
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 80
                               ** min : -30
                               ** default : 20
                               ** unit : °C
                 * name: b
                               ** description : Delay between sunrise and time when minimum temperature is reached
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 1.81
                               ** unit : Hour
                 * name: a
                               ** description : Delay between sunset and time when maximum temperature is reached
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 0.5
                               ** unit : Hour
                 * name: minTSoil
                               ** description : Minimum Soil Temperature
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 80
                               ** min : -30
                               ** default : 20
                               ** unit : °C
     - outputs:
                 * name: hourlySoilT
                               ** description : Hourly Soil Temperature
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 24
                               ** max : 80
                               ** min : -30
                               ** unit : °C
    """

    hourlySoilT:'array[float]' = array('f',[0.0]*24)
    i:int
    if maxTSoil == float(-999) and minTSoil == float(999):
        for i in range(0 , 12 , 1):
            hourlySoilT[i] = float(999)
        for i in range(12 , 24 , 1):
            hourlySoilT[i] = float(-999)
    else:
        for i in range(0 , 24 , 1):
            hourlySoilT[i] = 0.0
        hourlySoilT = getHourlySoilSurfaceTemperature(maxTSoil, minTSoil, dayLength, b, c, a)
    return hourlySoilT
#%%CyML Model End%%

def getHourlySoilSurfaceTemperature(TMax:float,
         TMin:float,
         ady:float,
         b:float,
         c:float,
         a:float):
    i:int
    result:'array[float]' = array('f',[0.0]*24)
    ahou:float
    ani:float
    bb:float
    be:float
    bbd:float
    ddy:float
    tsn:float
    ahou = pi * (ady / 24.0)
    ani = 24 - ady
    bb = 12 - (ady / 2) + c
    be = 12 + (ady / 2)
    for i in range(0 , 24 , 1):
        if i >= int(bb) and i <= int(be):
            result[i] = (TMax - TMin) * sin(3.14 * (i - bb) / (ady + (2 * a))) + TMin
        else:
            if i > int(be):
                bbd = i - be
            else:
                bbd = 24 + be + i
            ddy = ady - c
            tsn = (TMax - TMin) * sin(3.14 * ddy / (ady + (2 * a))) + TMin
            result[i] = TMin + ((tsn - TMin) * exp(-b * bbd / ani))
    return result