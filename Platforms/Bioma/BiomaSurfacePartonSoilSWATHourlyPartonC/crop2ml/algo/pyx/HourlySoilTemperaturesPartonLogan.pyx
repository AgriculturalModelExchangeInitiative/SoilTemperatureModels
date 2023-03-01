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