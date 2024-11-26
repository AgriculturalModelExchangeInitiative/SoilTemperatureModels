import numpy
from math import *

def model_temp_amp(float min_temp,
                   float max_temp):
    """
    temp_amp model
    Author: None
    Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    Institution: INRAE
    ExtendedDescription: None
    ShortDescription: None
    """

    cdef float temp_amp
    temp_amp=max_temp - min_temp
    return  temp_amp



