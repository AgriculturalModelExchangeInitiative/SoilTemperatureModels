from datetime import datetime
from math import *
from Stics_soil_temperature.temp_amp import model_temp_amp
from Stics_soil_temperature.temp_profile import model_temp_profile, init_temp_profile
from Stics_soil_temperature.layers_temp import model_layers_temp
from Stics_soil_temperature.canopy_temp_avg import model_canopy_temp_avg
from Stics_soil_temperature.update import model_update
def model_soil_temp(float min_temp,
      float max_temp,
      float prev_temp_profile[],
      float prev_canopy_temp,
      float min_air_temp,
      float air_temp_day1,
      int layer_thick[],
      float min_canopy_temp,
      float max_canopy_temp):
    cdef float temp_amp
    cdef float temp_profile[]
    cdef float layer_temp[]
    cdef float canopy_temp_avg
    temp_amp = model_temp_amp(min_temp,max_temp)
    canopy_temp_avg = model_canopy_temp_avg(min_canopy_temp,max_canopy_temp)
    temp_profile = model_temp_profile(temp_amp,prev_temp_profile,prev_canopy_temp,min_air_temp,air_temp_day1,layer_thick)
    layer_temp = model_layers_temp(temp_profile,layer_thick)
    prev_canopy_temp, prev_temp_profile = model_update(canopy_temp_avg,temp_profile)

    return (temp_amp, temp_profile, layer_temp, canopy_temp_avg, prev_canopy_temp, prev_temp_profile)

def init_soil_temp(float min_temp,
                     float max_temp,
                     float min_air_temp,
                     float air_temp_day1,
                     int layer_thick[],
                     float min_canopy_temp,
                     float max_canopy_temp):

    cdef float prev_temp_profile[]
    cdef float prev_canopy_temp
    cdef float temp_amp
    cdef float temp_profile[]
    cdef float layer_temp[]
    cdef float canopy_temp_avg
    temp_amp, prev_temp_profile, prev_canopy_temp = init_temp_profile(min_air_temp, air_temp_day1, layer_thick)
    return (temp_amp, prev_temp_profile, prev_canopy_temp, temp_profile, canopy_temp_avg)
