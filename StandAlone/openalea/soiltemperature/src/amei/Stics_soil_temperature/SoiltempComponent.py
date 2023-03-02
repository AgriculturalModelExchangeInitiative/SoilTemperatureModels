# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from Stics_soil_temperature.temp_amp import model_temp_amp
from Stics_soil_temperature.therm_amp import model_therm_amp
from Stics_soil_temperature.temp_profile import model_temp_profile

#%%CyML Model Begin%%
def model_soiltemp(max_temp:float,
         min_temp:float,
         therm_diff:float,
         temp_wave_freq:float,
         prev_temp_profile:'Array[float]',
         prev_canopy_temp:float,
         min_air_temp:float):
    """
     - Name: Soiltemp -Version: 1.0, -Time step: 1
     - Description:
                 * Title: soiltemp model
                 * Authors: None
                 * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
                 * Institution: INRAE
                 * ExtendedDescription: None
                 * ShortDescription: None
     - inputs:
                 * name: max_temp
                               ** description : current maximum temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 50.0
                               ** min : -50.0
                               ** default : 0.0
                               ** unit : degC
                 * name: min_temp
                               ** description : current minimum temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 50.0
                               ** min : -50.0
                               ** default : 0.0
                               ** unit : degC
                 * name: therm_diff
                               ** description : soil thermal diffusivity
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1.0e-1
                               ** min : 0.0
                               ** default : 5.37e-3
                               ** unit : cm2 s-1
                 * name: temp_wave_freq
                               ** description : angular frequency of the diurnal temperature sine wave
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0.0
                               ** default : 7.272e-5
                               ** unit : radians s-1
                 * name: prev_temp_profile
                               ** description : previous soil temperature profile 
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 1
                               ** max : 50.0
                               ** min : -50.0
                               ** default : 
                               ** unit : degC
                 * name: prev_canopy_temp
                               ** description : previous crop temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
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
     - outputs:
                 * name: temp_amp
                               ** description : current temperature amplitude
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 100.0
                               ** min : 0.0
                               ** unit : degC
                 * name: therm_amp
                               ** description : thermal amplitude
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : radians cm-2
                 * name: temp_profile
                               ** description : current soil profile temperature 
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 50.0
                               ** min : -50.0
                               ** unit : degC
    """

    temp_amp:float
    therm_amp:float
    temp_profile:'array[float]'
    temp_amp = model_temp_amp(min_temp, max_temp)
    therm_amp = model_therm_amp(therm_diff, temp_wave_freq)
    temp_profile = model_temp_profile(temp_amp, therm_amp, prev_temp_profile, prev_canopy_temp, min_air_temp)
    return (temp_amp, therm_amp, temp_profile)
#%%CyML Model End%%