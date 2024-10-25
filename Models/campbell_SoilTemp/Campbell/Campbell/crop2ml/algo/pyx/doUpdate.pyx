def doUpdate(floatlist tempNew,
         floatlist soilTemp,
         floatlist minSoilTemp,
         floatlist maxSoilTemp,
         floatlist aveSoilTemp,
         floatlist thermalConductivity,
         float boundaryLayerConductance,
         int IterationsPerDay,
         float timeOfDaySecs,
         float gDt,
         int numNodes):
    cdef int SURFACEnode = 1
    cdef int AIRnode = 0
    cdef int node = 1
    for node in range(0 , len(tempNew) , 1):
        soilTemp[node]=tempNew[node]
    if timeOfDaySecs < (gDt * 1.2):
        for node in range(SURFACEnode , numNodes + 1 , 1):
            minSoilTemp[node]=soilTemp[node]
            maxSoilTemp[node]=soilTemp[node]
    for node in range(SURFACEnode , numNodes + 1 , 1):
        if soilTemp[node] < minSoilTemp[node]:
            minSoilTemp[node]=soilTemp[node]
        elif soilTemp[node] > maxSoilTemp[node]:
            maxSoilTemp[node]=soilTemp[node]
        aveSoilTemp[node]=aveSoilTemp[node] + Divide(soilTemp[node], float(IterationsPerDay), 0.0)
    boundaryLayerConductance=boundaryLayerConductance + Divide(thermalConductivity[AIRnode], float(IterationsPerDay), 0.0)
    return (soilTemp, boundaryLayerConductance)

def Divide(float val1,
         float val2,
         float errVal):
    cdef float returnValue = errVal
    if val2 != 0.0:
        returnValue=val1 / val2
    return returnValue
