import numpy
from math import *

def model_calculatehourlysoiltemperature(float minTSoil,
                                         float dayLength,
                                         float b,
                                         float a,
                                         float maxTSoil,
                                         float c):
    """
    CalculateHourlySoilTemperature model
    Author: loic.manceau@inra.fr
    Reference: ('http://biomamodelling.org',)
    Institution: INRA
    ExtendedDescription: Calculate Soil temperature on a hourly basis.Parton, W.J. and Logan, J.A., 1981. A model for diurnal variation in soil and air temperature. Agric. Meteorol., 23: 205-216
    ShortDescription: None
    """

    cdef float hourlySoilT[24]
    cdef int i 
    if maxTSoil == float(-999) and minTSoil == float(999):
        for i in range(0 , 12 , 1):
            hourlySoilT[i]=float(999)
        for i in range(12 , 24 , 1):
            hourlySoilT[i]=float(-999)
    else:
        for i in range(0 , 24 , 1):
            hourlySoilT[i]=0.0
        hourlySoilT=getHourlySoilSurfaceTemperature(maxTSoil, minTSoil, dayLength, b, a, c)
    return  hourlySoilT



def getHourlySoilSurfaceTemperature(float TMax,
         float TMin,
         float ady,
         float b,
         float a,
         float c):
    cdef int i 
    cdef float result[24]
    cdef float ahou 
    cdef float ani 
    cdef float bb 
    cdef float be 
    cdef float bbd 
    cdef float ddy 
    cdef float tsn 
    ahou=pi * (ady / 24.0)
    ani=24 - ady
    bb=12 - (ady / 2) + c
    be=12 + (ady / 2)
    for i in range(0 , 24 , 1):
        if i >= int(bb) and i <= int(be):
            result[i]=(TMax - TMin) * sin(3.14 * (i - bb) / (ady + (2 * a))) + TMin
        else:
            if i > int(be):
                bbd=i - be
            else:
                bbd=24 + be + i
            ddy=ady - c
            tsn=(TMax - TMin) * sin(3.14 * ddy / (ady + (2 * a))) + TMin
            result[i]=TMin + ((tsn - TMin) * exp(-b * bbd / ani))
    return result


