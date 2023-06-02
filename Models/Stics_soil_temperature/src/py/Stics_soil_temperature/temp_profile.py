# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Init Begin%%
def init_temp_profile(temp_amp:float,
         therm_amp:float,
         min_air_temp:float,
         air_temp_day1:float,
         layer_thick:'Array[int]'):
    prev_temp_profile:'array[float]'
    prev_canopy_temp:float
    prev_temp_profile = None
    prev_canopy_temp = 0.0
    soil_depth:int
    soil_depth = sum(layer_thick)
    prev_temp_profile = array("f", [0] * soil_depth)
    prev_temp_profile = [air_temp_day1] * soil_depth
    prev_canopy_temp = air_temp_day1
    return (prev_temp_profile, prev_canopy_temp)
#%%CyML Init End%%

def model_temp_profile(temp_amp:float,
         therm_amp:float,
         prev_temp_profile:'Array[float]',
         prev_canopy_temp:float,
         min_air_temp:float,
         air_temp_day1:float,
         layer_thick:'Array[int]'):
    temp_profile:'array[float]'
    z:int
    n:int
    vexp:List[float] = []
    n = len(prev_temp_profile)
    temp_profile = array("f", [0] * n)
    vexp = array("f", [0] * n)
    for z in range(1 , n + 1 , 1):
        vexp[z - 1] = exp(-(z * therm_amp))
    for z in range(1 , n + 1 , 1):
        temp_profile[z - 1] = prev_temp_profile[z - 1] - (vexp[(z - 1)] * (prev_canopy_temp - min_air_temp)) + (0.1 * (prev_canopy_temp - prev_temp_profile[z - 1])) + (temp_amp * vexp[(z - 1)] / 2)
    return temp_profile