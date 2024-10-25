def doThermalConductivityCoeffs(int nbLayers,
         int numNodes,
         floatlist BDApsim,
         floatlist CLAYApsim):
    cdef floatlist  thermalCondPar1
    cdef floatlist  thermalCondPar2
    cdef floatlist  thermalCondPar3
    cdef floatlist  thermalCondPar4
    cdef int layer 
    cdef int element 
    thermalCondPar1=[0.0]
    thermalCondPar2=[0.0]
    thermalCondPar3=[0.0]
    thermalCondPar4=[0.0]
    for layer in range(0 , numNodes + 1 , 1):
        thermalCondPar1.append(0.0)
        thermalCondPar2.append(0.0)
        thermalCondPar3.append(0.0)
        thermalCondPar4.append(0.0)
    for layer in range(1 , nbLayers + 2 , 1):
        element=layer
        thermalCondPar1[element]=0.65 - (0.78 * BDApsim[layer]) + (0.6 * pow(BDApsim[layer], 2))
        thermalCondPar2[element]=1.06 * BDApsim[layer]
        thermalCondPar3[element]=Divide(2.6, sqrt(CLAYApsim[layer]), 0.0)
        thermalCondPar3[element]=1.0 + thermalCondPar3[element]
        thermalCondPar4[element]=0.03 + (0.1 * pow(BDApsim[layer], 2))
    return (thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4)

def Divide(float val1,
         float val2,
         float errVal):
    cdef float returnValue = errVal
    if val2 != 0.0:
        returnValue=val1 / val2
    return returnValue
