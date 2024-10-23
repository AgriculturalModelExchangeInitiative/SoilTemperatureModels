import numpy 
from math import *
def model_temp_profile(float temp_amp,
                       float therm_amp,
                       float prev_temp_profile[1],
                       float prev_canopy_temp,
                       float min_air_temp):
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
    cdef float vexp[]
    n=len(prev_temp_profile)
    temp_profile.allocate(n)
    #if (.NOT. ALLOCATED(temp_profile)) then
    vexp.allocate(n)
    #end if
    #if (.NOT. ALLOCATED(vexp)) then
    #end if
    for z in range(1 , n + 1 , 1):
        vexp[z - 1]=exp(-(z * therm_amp))
    for z in range(1 , n + 1 , 1):
        temp_profile[z - 1]=prev_temp_profile[z - 1] - (vexp[(z - 1)] * (prev_canopy_temp - min_air_temp)) + (0.1 * (prev_canopy_temp - prev_temp_profile[z - 1])) + (temp_amp * vexp[(z - 1)] / 2)
    # Updating prev_temp_profile
    prev_temp_profile=temp_profile
    return  temp_profile


