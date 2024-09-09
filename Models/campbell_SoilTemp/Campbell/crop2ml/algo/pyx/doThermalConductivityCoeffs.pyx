def doThermalConductivityCoeffs(int nbLayers,
         int numNodes,
         floatarray bulkDensity,
         floatarray clay):
    cdef float thermalCondPar1[]
    cdef float thermalCondPar2[]
    cdef float thermalCondPar3[]
    cdef float thermalCondPar4[]
    cdef int layer 
    cdef int element 
    thermalCondPar1=[0.0] * (numNodes + 1)
    thermalCondPar2=[0.0] * (numNodes + 1)
    thermalCondPar3=[0.0] * (numNodes + 1)
    thermalCondPar4=[0.0] * (numNodes + 1)
    for layer in range(1 , nbLayers + 2 , 1):
        element=layer
        thermalCondPar1[element]=0.65 - (0.78 * bulkDensity[layer]) + (0.6 * pow(bulkDensity[layer], 2))
        thermalCondPar2[element]=1.06 * bulkDensity[layer]
        thermalCondPar3[element]=Divide(2.6, sqrt(clay[layer]), 0.0)
        thermalCondPar3[element]=1.0 + thermalCondPar3[element]
        thermalCondPar4[element]=0.03 + (0.1 * pow(bulkDensity[layer], 2))
    return (thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4)

def Divide(float val1,
         float val2,
         float errVal):
    cdef float returnValue = errVal
    if val2 != 0.0:
        returnValue=val1 / val2
    return returnValue
