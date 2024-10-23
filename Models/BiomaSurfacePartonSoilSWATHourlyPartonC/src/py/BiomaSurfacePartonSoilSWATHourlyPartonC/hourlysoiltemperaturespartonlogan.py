# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_hourlysoiltemperaturespartonlogan(SoilTemperatureByLayersHourly:'Array[float]',
         HourOfSunrise:float,
         HourOfSunset:float,
         DayLength:float,
         SoilTemperatureMinimum:'Array[float]',
         SoilTemperatureMaximum:'Array[float]'):
    """
     - Name: HourlySoilTemperaturesPartonLogan -Version: 001, -Time step: 1
     - Description:
                 * Title: HourlySoilTemperaturesPartonLogan model
                 * Authors: simone.bregaglio
                 * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
                 * Institution: University Of Milan
                 * ExtendedDescription: Strategy for the calculation of hourly soil temperature. Reference: Parton, W.J.  and  Logan, J.A.,  1981. A model for diurnal variation  in soil  and  air temperature. Agric. Meteorol., 23: 205-216.
                 * ShortDescription: Strategy for the calculation of hourly soil temperature
     - inputs:
                 * name: SoilTemperatureByLayersHourly
                               ** description : Hourly soil temperature by layers
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 50
                               ** min : -50
                               ** default : 15
                               ** unit : degC
                 * name: HourOfSunrise
                               ** description : Hour of sunrise
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 24
                               ** min : 0
                               ** default : 6
                               ** unit : h
                 * name: HourOfSunset
                               ** description : Hour of sunset
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 24
                               ** min : 0
                               ** default : 17
                               ** unit : h
                 * name: DayLength
                               ** description : Length of the day
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 24
                               ** min : 0
                               ** default : 10
                               ** unit : h
                 * name: SoilTemperatureMinimum
                               ** description : Minimum soil temperature by layers
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** default : 15
                               ** unit : degC
                 * name: SoilTemperatureMaximum
                               ** description : Maximum soil temperature by layers
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** default : 15
                               ** unit : degC
     - outputs:
                 * name: SoilTemperatureByLayersHourly
                               ** description : Hourly soil temperature by layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 50
                               ** min : -50
                               ** unit : degC
    """

    h:int
    i:int
    TemperatureAtSunset:float
    for i in range(0 , len(SoilTemperatureMinimum) , 1):
        for h in range(0 , 24 , 1):
            if h >= int(HourOfSunrise) and h <= int(HourOfSunset):
                SoilTemperatureByLayersHourly[i * 24 + h] = SoilTemperatureMinimum[i] + ((SoilTemperatureMaximum[i] - SoilTemperatureMinimum[i]) * sin(pi * (h - 12 + (DayLength / 2)) / (DayLength + (2 * 1.8))))
        TemperatureAtSunset = SoilTemperatureByLayersHourly[i + int(HourOfSunset)]
        for h in range(0 , 24 , 1):
            if h > int(HourOfSunset):
                SoilTemperatureByLayersHourly[i + h] = (SoilTemperatureMinimum[i] - (TemperatureAtSunset * exp(-(24 - DayLength) / 2.2)) + ((TemperatureAtSunset - SoilTemperatureMinimum[i]) * exp(-(h - HourOfSunset) / 2.2))) / (1 - exp(-(24 - DayLength) / 2.2))
            elif h <= int(HourOfSunrise):
                SoilTemperatureByLayersHourly[i + h] = (SoilTemperatureMinimum[i] - (TemperatureAtSunset * exp(-(24 - DayLength) / 2.2)) + ((TemperatureAtSunset - SoilTemperatureMinimum[i]) * exp(-(h + 24 - HourOfSunset) / 2.2))) / (1 - exp(-(24 - DayLength) / 2.2))
    return SoilTemperatureByLayersHourly
#%%CyML Model End%%