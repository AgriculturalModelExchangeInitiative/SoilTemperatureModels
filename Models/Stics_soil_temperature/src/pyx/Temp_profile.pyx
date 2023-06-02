import numpy 
from math import *
def init_temp_profile(float temp_amp,
                      float min_air_temp,
                      float air_temp_day1,
                      int layer_thick[]):
    cdef float prev_temp_profile[]
    cdef float prev_canopy_temp
    prev_temp_profile = None
    prev_canopy_temp = 0.0
    cdef int soil_depth 
    soil_depth=sum(layer_thick)
    prev_temp_profile.allocate(soil_depth)
    prev_temp_profile=[air_temp_day1]*(soil_depth)
    prev_canopy_temp=air_temp_day1
    return  prev_temp_profile, prev_canopy_temp
def model_temp_profile(float temp_amp,
                       float prev_temp_profile[],
                       float prev_canopy_temp,
                       float min_air_temp,
                       float air_temp_day1,
                       int layer_thick[]):
    """

    tempprofile model
    Author: None
    Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    Institution: INRAE
    ExtendedDescription: None
    ShortDescription: None

    """
    cdef float temp_profile[]
    cdef int z , n 
    cdef floatlist  vexp
    cdef float therm_diff = 5.37e-3
    cdef float temp_freq = 7.272e-5
    cdef float therm_amp 
    n=len(prev_temp_profile)
    temp_profile.allocate(n)
    #if (.NOT. ALLOCATED(temp_profile)) then
    vexp.allocate(n)
    #end if
    #if (.NOT. ALLOCATED(vexp)) then
    #end if
    therm_amp=sqrt(temp_freq / 2 / therm_diff)
    for z in range(1 , n + 1 , 1):
        vexp[z - 1]=exp(-(z * therm_amp))
    for z in range(1 , n + 1 , 1):
        temp_profile[z - 1]=prev_temp_profile[z - 1] - (vexp[(z - 1)] * (prev_canopy_temp - min_air_temp)) + (0.1 * (prev_canopy_temp - prev_temp_profile[z - 1])) + (temp_amp * vexp[(z - 1)] / 2)
    return  temp_profile


