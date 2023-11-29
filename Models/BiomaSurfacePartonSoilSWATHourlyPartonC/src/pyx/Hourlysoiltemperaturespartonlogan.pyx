import numpy
from math import *

def model_hourlysoiltemperaturespartonlogan(float SoilTemperatureByLayersHourly[],
                                            float HourOfSunrise,
                                            float HourOfSunset,
                                            float DayLength,
                                            float SoilTemperatureMinimum[],
                                            float SoilTemperatureMaximum[]):
    """
    HourlySoilTemperaturesPartonLogan model
    Author: simone.bregaglio
    Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
    Institution: University Of Milan
    ExtendedDescription: Strategy for the calculation of hourly soil temperature. Reference: Parton, W.J.  and  Logan, J.A.,  1981. A model for diurnal variation  in soil  and  air temperature. Agric. Meteorol., 23: 205-216.
    ShortDescription: Strategy for the calculation of hourly soil temperature
    """

    cdef int h 
    cdef int i 
    cdef float TemperatureAtSunset 
    for i in range(0 , len(SoilTemperatureMinimum) , 1):
        for h in range(0 , 24 , 1):
            if h >= int(HourOfSunrise) and h <= int(HourOfSunset):
                SoilTemperatureByLayersHourly[i * 24 + h]=SoilTemperatureMinimum[i] + ((SoilTemperatureMaximum[i] - SoilTemperatureMinimum[i]) * sin(pi * (h - 12 + (DayLength / 2)) / (DayLength + (2 * 1.8))))
        TemperatureAtSunset=SoilTemperatureByLayersHourly[i + int(HourOfSunset)]
        for h in range(0 , 24 , 1):
            if h > int(HourOfSunset):
                SoilTemperatureByLayersHourly[i + h]=(SoilTemperatureMinimum[i] - (TemperatureAtSunset * exp(-(24 - DayLength) / 2.2)) + ((TemperatureAtSunset - SoilTemperatureMinimum[i]) * exp(-(h - HourOfSunset) / 2.2))) / (1 - exp(-(24 - DayLength) / 2.2))
            elif h <= int(HourOfSunrise):
                SoilTemperatureByLayersHourly[i + h]=(SoilTemperatureMinimum[i] - (TemperatureAtSunset * exp(-(24 - DayLength) / 2.2)) + ((TemperatureAtSunset - SoilTemperatureMinimum[i]) * exp(-(h + 24 - HourOfSunset) / 2.2))) / (1 - exp(-(24 - DayLength) / 2.2))
    return  SoilTemperatureByLayersHourly



