# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Init Begin%%
def init_temp_profile(min_air_temp:float,
         air_temp_day1:float,
         layer_thick:'Array[int]'):
    temp_amp:float = 0.0
    prev_temp_profile:'array[float]'
    prev_canopy_temp:float
    prev_temp_profile = None
    prev_canopy_temp = 0.0
    soil_depth:int
    soil_depth = sum(layer_thick)
    prev_temp_profile = array("f", [0] * soil_depth)
    prev_temp_profile = [air_temp_day1] * soil_depth
    prev_canopy_temp = air_temp_day1
    return (temp_amp, prev_temp_profile, prev_canopy_temp)
#%%CyML Init End%%

#%%CyML Model Begin%%
def model_temp_profile(temp_amp:float,
         prev_temp_profile:'Array[float]',
         prev_canopy_temp:float,
         min_air_temp:float,
         air_temp_day1:float,
         layer_thick:'Array[int]'):
    """
     - Name: temp_profile -Version: 1.0, -Time step: 1
     - Description:
                 * Title: tempprofile model
                 * Authors: None
                 * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
                 * Institution: INRAE
                 * ExtendedDescription: None
                 * ShortDescription: None
     - inputs:
                 * name: temp_amp
                               ** description : current temperature amplitude
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 100.0
                               ** min : 0.0
                               ** default : 0.0
                               ** unit : degC
                 * name: prev_temp_profile
                               ** description : previous soil temperature profile (for 1 cm layers)
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 50.0
                               ** min : -50.0
                               ** default : 
                               ** unit : degC
                 * name: prev_canopy_temp
                               ** description : previous crop temperature
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 50.0
                               ** min : 0.0
                               ** default : 
                               ** unit : degC
                 * name: min_air_temp
                               ** description : current minimum air temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 50.0
                               ** min : -50.0
                               ** default : 
                               ** unit : degC
                 * name: air_temp_day1
                               ** description : Mean temperature on first day
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 100.0
                               ** min : 0.0
                               ** default : 0.0
                               ** unit : degC
                 * name: layer_thick
                               ** description : layers thickness
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INTARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm
     - outputs:
                 * name: temp_profile
                               ** description : current soil profile temperature (for 1 cm layers)
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 50.0
                               ** min : -50.0
                               ** unit : degC
    """

    temp_profile:'array[float]'
    z:int
    n:int
    vexp:List[float] = []
    therm_diff:float = 5.37e-3
    temp_freq:float = 7.272e-5
    therm_amp:float
    n = len(prev_temp_profile)
    temp_profile = array("f", [0] * n)
    vexp = array("f", [0] * n)
    therm_amp = sqrt(temp_freq / 2 / therm_diff)
    for z in range(1 , n + 1 , 1):
        vexp[z - 1] = exp(-(z * therm_amp))
    for z in range(1 , n + 1 , 1):
        temp_profile[z - 1] = prev_temp_profile[z - 1] - (vexp[(z - 1)] * (prev_canopy_temp - min_air_temp)) + (0.1 * (prev_canopy_temp - prev_temp_profile[z - 1])) + (temp_amp * vexp[(z - 1)] / 2)
    return temp_profile
#%%CyML Model End%%