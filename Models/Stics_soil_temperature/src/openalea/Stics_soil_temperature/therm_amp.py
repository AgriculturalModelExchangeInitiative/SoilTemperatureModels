# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_therm_amp(therm_diff:float,
         temp_wave_freq:float):
    """
     - Name: therm_amp -Version: 1.0, -Time step: 1
     - Description:
                 * Title: thermal amplitude calculation
                 * Authors: None
                 * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
                 * Institution: INRAE
                 * ExtendedDescription: None
                 * ShortDescription: None
     - inputs:
                 * name: therm_diff
                               ** description : soil thermal diffusivity
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 1.0e-1
                               ** min : 0.0
                               ** default : 5.37e-3
                               ** unit : cm2 s-1
                 * name: temp_wave_freq
                               ** description : angular frequency of the diurnal temperature sine wave
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0.0
                               ** default : 7.272e-5
                               ** unit : radians s-1
     - outputs:
                 * name: therm_amp
                               ** description : thermal amplitude
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : radians cm-2
    """

    therm_amp:float
    temp_freq:float
    temp_freq = temp_wave_freq
    therm_amp = sqrt(temp_freq / 2 / therm_diff)
    return therm_amp
#%%CyML Model End%%