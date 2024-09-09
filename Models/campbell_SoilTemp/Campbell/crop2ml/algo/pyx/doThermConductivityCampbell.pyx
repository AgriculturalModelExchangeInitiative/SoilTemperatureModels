def doThermConductivityCampbell(floatarray soilW,
         floatarray thermalCondPar1,
         floatarray thermalCondPar2,
         floatarray thermalCondPar3,
         floatarray thermalCondPar4,
         floatarray thermalConductivity,
         floatarray thickness,
         floatarray depth,
         int numNodes):
    cdef float thermCondLayers[]
    cdef int layer = 1
    for layer in range(1 , numNodes + 1 , 1):
        cdef float temp = pow(thermalCondPar3[layer] * soilW[layer], 4) * -1.0
        thermCondLayers[layer]=thermalCondPar1[layer] + (thermalCondPar2[layer] * soilW[layer]) - ((thermalCondPar1[layer] - thermalCondPar4[layer]) * exp(temp))
    thermalConductivity=mapLayer2Node(thermCondLayers, thermalConductivity, thickness, depth, numNodes)
    return thermalConductivity

def mapLayer2Node(floatarray layerArray,
         floatarray nodeArray,
         floatarray thickness,
         floatarray depth,
         int numNodes):
    cdef int SURFACEnode = 1
    cdef float M2MM = 1000.0
    cdef int node = 0
    cdef int i = 0
    cdef int layer 
    for node in range(SURFACEnode , numNodes + 1 , 1):
        layer=node - 1
        cdef float depthLayerAbove = 0.0
        if layer >= 1:
            for i in range(1 , layer + 1 , 1):
                depthLayerAbove+=thickness[i]
        cdef float d1 = depthLayerAbove - (depth[node] * M2MM)
        cdef float d2 = depth[(node + 1)] * M2MM - depthLayerAbove
        cdef float dSum = d1 + d2
        if dSum != 0.0:
            nodeArray[node]=layerArray[layer] * d1 / dSum + (layerArray[(layer + 1)] * d2 / dSum)
        else:
            nodeArray[node]=0
    return nodeArray
