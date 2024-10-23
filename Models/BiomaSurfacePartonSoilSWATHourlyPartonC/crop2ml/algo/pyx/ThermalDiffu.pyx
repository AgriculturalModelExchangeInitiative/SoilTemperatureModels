cdef int i 
for i in range(0 , layersNumber , 1):
    ThermalDiffusivity[i]=ThermalConductivity[i] / HeatCapacity[i] / 100