def compute(floatarray soilTemp,
         int NLAYR):
    cdef float soilTemp2[]
    cdef int i 
    for i in range(0 , NLAYR , 1):
        soilTemp2.append(float(i))
    return soilTemp2
