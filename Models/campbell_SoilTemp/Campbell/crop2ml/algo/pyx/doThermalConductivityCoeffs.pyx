def doThermalConductivityCoeffs(int nbLayers,
         int numNodes,
         floatarray bulkDensity,
         floatarray clay):
    cdef float thermCondPar1[]
    cdef float thermCondPar2[]
    cdef float thermCondPar3[]
    cdef float thermCondPar4[]
    cdef int layer 
    cdef int element 
    thermCondPar1=0.0 * (numNodes + 1)
    thermCondPar2=0.0 * (numNodes + 1)
    thermCondPar3=0.0 * (numNodes + 1)
    thermCondPar4=0.0 * (numNodes + 1)
    for layer in range(1 , nbLayers + 2 , 1):
        element=layer
        thermCondPar1[element]=0.65 - (0.78 * bulkDensity[layer]) + (0.6 * pow(bulkDensity[layer], 2))
        thermCondPar2[element]=1.06 * bulkDensity[layer]
        thermCondPar3[element]=Divide(2.6, sqrt(clay[layer]), 0.0)
        thermCondPar3[element]=1.0 + thermCondPar3[element]
        thermCondPar4[element]=0.03 + (0.1 * pow(bulkDensity[layer], 2))
    return (thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4)

def Divide(float val1,
         float val2,
         float errVal):
    cdef float returnValue = errVal
    if val2 != 0.0:
        returnValue=val1 / val2
    return returnValue
