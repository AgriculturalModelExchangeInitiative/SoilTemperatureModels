import numpy 
from math import *
def model_therm_amp(float therm_diff,
                    float temp_wave_freq):
    """

    thermal amplitude calculation
    Author: None
    Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    Institution: INRAE
    ExtendedDescription: None
    ShortDescription: None

    """
    cdef float therm_amp
    cdef float temp_freq 
    temp_freq=temp_wave_freq
    #end if
    therm_amp=sqrt(temp_freq / 2 / therm_diff)
    return  therm_amp


