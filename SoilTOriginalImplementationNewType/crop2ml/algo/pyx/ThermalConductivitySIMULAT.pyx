cdef int i 
cdef float Aterm 
cdef float Bterm 
cdef float Cterm 
cdef float Dterm 
cdef float Eterm 
Aterm=float(0)
Bterm=float(0)
Cterm=float(0)
Dterm=float(0)
Eterm=float(4)
for i in range(0 , len(VolumetricWaterContent) , 1):
    Aterm=0.65 - (0.78 * BulkDensity[i]) + (0.6 * pow(BulkDensity[i], 2))
    Bterm=1.06 * BulkDensity[i] * VolumetricWaterContent[i]
    Cterm=1 + (2.6 * sqrt(Clay[i] / 100))
    Dterm=0.03 + (0.1 * pow(BulkDensity[i], 2))
    ThermalConductivity[i]=Aterm + (Bterm * VolumetricWaterContent[i]) - ((Aterm - Dterm) * pow(exp(-(Cterm * VolumetricWaterContent[i])), Eterm))