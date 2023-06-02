import numpy 
from math import *
def model_update(float canopy_temp_avg,
                 float temp_profile[]):
    """

    update soil temp model
    Author: None
    Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    Institution: INRAE
    ExtendedDescription: None
    ShortDescription: None

    """
    cdef float prev_temp_profile[1]
    cdef float prev_canopy_temp
    prev_canopy_temp=canopy_temp_avg
    prev_temp_profile=copy(temp_profile)
    return  prev_temp_profile, prev_canopy_temp


