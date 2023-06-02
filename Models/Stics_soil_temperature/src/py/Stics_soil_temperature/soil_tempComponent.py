# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from Stics_soil_temperature.temp_amp import model_temp_amp
from Stics_soil_temperature.therm_amp import model_therm_amp
from Stics_soil_temperature.temp_profile import model_temp_profile
from Stics_soil_temperature.canopy_temp_avg import model_canopy_temp_avg
from Stics_soil_temperature.layers_temp import model_layers_temp
from Stics_soil_temperature.update import model_update

#%%CyML Model Begin%%
def model_soil_temp(min_temp:float,
         max_temp:float,
         temp_wave_freq:float,
         therm_diff:float,
         layer_thick:'Array[int]',
         min_air_temp:float,
         air_temp_day1:float,
         min_canopy_temp:float,
         max_canopy_temp:float):
    """
     - Name: soil_temp -Version: 1.0, -Time step: 1
     - Description:
                 * Title: soil temperature model
                 * Authors: None
                 * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
                 * Institution: INRAE
                 * ExtendedDescription: None
                 * ShortDescription: None
     - inputs:
                 * name: min_temp
                               ** description : current minimum temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 50.0
                               ** min : -50.0
                               ** default : 0.0
                               ** unit : degC
                 * name: max_temp
                               ** description : current maximum temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 50.0
                               ** min : -50.0
                               ** default : 0.0
                               ** unit : degC
                 * name: temp_wave_freq
                               ** description : angular frequency of the diurnal temperature sine wave
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0.0
                               ** default : 7.272e-5
                               ** unit : radians s-1
                 * name: therm_diff
                               ** description : soil thermal diffusivity
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1.0e-1
                               ** min : 0.0
                               ** default : 5.37e-3
                               ** unit : cm2 s-1
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
                 * name: min_canopy_temp
                               ** description : current minimum temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 50.0
                               ** min : -50.0
                               ** default : 0.0
                               ** unit : degC
                 * name: max_canopy_temp
                               ** description : current maximum temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 50.0
                               ** min : -50.0
                               ** default : 0.0
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
                 * name: canopy_temp_avg
                               ** description : current temperature amplitude
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 100.0
                               ** min : 0.0
                               ** unit : degC
                 * name: layer_temp
                               ** description : soil layers temperature
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 50.0
                               ** min : -50.0
                               ** unit : degC
                 * name: prev_temp_profile
                               ** description : previous soil temperature profile 
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 1
                               ** max : 50.0
                               ** min : -50.0
                               ** unit : degC
                 * name: prev_canopy_temp
                               ** description : previous crop temperature
                               ** datatype : DOUBLE
                               ** variablecategory : exogenous
                               ** max : 50.0
                               ** min : 0.0
                               ** unit : degC
    """

    temp_amp:float
    therm_amp:float
    prev_temp_profile:'array[float]'
    prev_canopy_temp:float
    temp_profile:'array[float]'
    canopy_temp_avg:float
    layer_temp:'array[float]'
    temp_amp = model_temp_amp(min_temp, max_temp)
    therm_amp = model_therm_amp(therm_diff, temp_wave_freq)
    canopy_temp_avg = model_canopy_temp_avg(min_canopy_temp, max_canopy_temp)
    temp_profile = model_temp_profile(temp_amp, therm_amp, prev_temp_profile, prev_canopy_temp, min_air_temp, air_temp_day1, layer_thick)
    layer_temp = model_layers_temp(temp_profile, layer_thick)
    (prev_temp_profile, prev_canopy_temp) = model_update(canopy_temp_avg, temp_profile)
    return (temp_amp, therm_amp, temp_profile, canopy_temp_avg, layer_temp, prev_temp_profile, prev_canopy_temp)
#%%CyML Model End%%