# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from Stics_soil_temperature.temp_amp import model_temp_amp
from Stics_soil_temperature.temp_profile import model_temp_profile, init_temp_profile
from Stics_soil_temperature.layers_temp import model_layers_temp
from Stics_soil_temperature.canopy_temp_avg import model_canopy_temp_avg
from Stics_soil_temperature.update import model_update

#%%CyML Model Begin%%
def model_soil_temp(min_temp:float,
         max_temp:float,
         prev_temp_profile:'Array[float]',
         prev_canopy_temp:float,
         min_air_temp:float,
         air_temp_day1:float,
         layer_thick:'Array[int]',
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
                 * name: temp_profile
                               ** description : current soil profile temperature (for 1 cm layers)
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 50.0
                               ** min : -50.0
                               ** unit : degC
                 * name: layer_temp
                               ** description : soil layers temperature
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
                 * name: prev_canopy_temp
                               ** description : previous crop temperature
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 50.0
                               ** min : 0.0
                               ** unit : degC
                 * name: prev_temp_profile
                               ** description : previous soil temperature profile (for 1 cm layers)
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 1
                               ** max : 50.0
                               ** min : -50.0
                               ** unit : degC
    """

    temp_amp:float
    temp_profile:'array[float]'
    layer_temp:'array[float]'
    canopy_temp_avg:float
    temp_amp = model_temp_amp(min_temp, max_temp)
    canopy_temp_avg = model_canopy_temp_avg(min_canopy_temp, max_canopy_temp)
    temp_profile = model_temp_profile(temp_amp, prev_temp_profile, prev_canopy_temp, min_air_temp, air_temp_day1, layer_thick)
    layer_temp = model_layers_temp(temp_profile, layer_thick)
    (prev_canopy_temp, prev_temp_profile) = model_update(canopy_temp_avg, temp_profile)
    return (temp_amp, temp_profile, layer_temp, canopy_temp_avg, prev_canopy_temp, prev_temp_profile)
#%%CyML Model End%%

#%%CyML Init Begin%%
def init_soil_temp(min_temp:float,
         max_temp:float,
         min_air_temp:float,
         air_temp_day1:float,
         layer_thick:'Array[int]',
         min_canopy_temp:float,
         max_canopy_temp:float):
    prev_temp_profile:'array[float]'
    prev_canopy_temp:float
    temp_amp:float
    temp_profile:'array[float]'
    layer_temp:'array[float]'
    canopy_temp_avg:float
    (temp_amp, prev_temp_profile, prev_canopy_temp) = init_temp_profile(min_air_temp, air_temp_day1, layer_thick)
    return (temp_amp, prev_temp_profile, prev_canopy_temp, temp_profile, canopy_temp_avg)
#%%CyML Init End%%