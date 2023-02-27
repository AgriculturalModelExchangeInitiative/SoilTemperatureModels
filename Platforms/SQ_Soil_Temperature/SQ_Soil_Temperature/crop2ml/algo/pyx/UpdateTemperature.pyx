def UpdateTemperature(float minSoilTemp,
         float maxSoilTemp,
         float Temperature):
    cdef float meanTemp 
    meanTemp=(minSoilTemp + maxSoilTemp) / 2.0
    Temperature=(9.0 * Temperature + meanTemp) / 10.0
    return Temperature