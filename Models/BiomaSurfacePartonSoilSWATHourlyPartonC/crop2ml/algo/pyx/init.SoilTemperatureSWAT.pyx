cdef int i 
SoilTemperatureByLayers=array('f', [0.0]*len(LayerThickness))
for i in range(0 , len(LayerThickness) , 1):
    SoilTemperatureByLayers[i]=float(15)