import numpy
from math import *

def model_canopy_temp_avg(float min_canopy_temp,
                          float max_canopy_temp):
    """
    canopy_temp_avg model
    Author: None
    Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    Institution: INRAE
    ExtendedDescription: None
    ShortDescription: None
    """

    cdef float canopy_temp_avg
    canopy_temp_avg=(max_canopy_temp + min_canopy_temp) / 2
    return  canopy_temp_avg



