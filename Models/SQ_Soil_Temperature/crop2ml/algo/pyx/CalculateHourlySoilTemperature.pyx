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