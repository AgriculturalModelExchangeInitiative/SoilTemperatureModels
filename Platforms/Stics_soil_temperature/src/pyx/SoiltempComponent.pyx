from datetime import datetime
from math import *
from Stics_soil_temperature.temp_amp import model_temp_amp
from Stics_soil_temperature.therm_amp import model_therm_amp
from Stics_soil_temperature.temp_profile import model_temp_profile
def model_soiltemp(float min_temp,
      float max_temp,
      float therm_diff,
      float temp_wave_freq,
      float min_air_temp,
      float prev_temp_profile[1],
      float prev_canopy_temp):
    cdef float temp_amp
    cdef float therm_amp
    cdef float temp_profile[]
    therm_amp = model_therm_amp( therm_diff,temp_wave_freq)
    temp_amp = model_temp_amp( min_temp,max_temp)
    temp_profile = model_temp_profile( temp_amp,therm_amp,prev_temp_profile,prev_canopy_temp,min_air_temp)
    return temp_amp, therm_amp, temp_profile