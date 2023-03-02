cdef int i 
for i in range(0 , len(ThermalDiffusivity) , 1):
    ThermalDiffusivity[i]=ThermalConductivity[i] / HeatCapacity[i] / 100