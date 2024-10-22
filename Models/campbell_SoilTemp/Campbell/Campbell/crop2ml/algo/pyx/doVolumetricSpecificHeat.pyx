def doVolumetricSpecificHeat(floatarray volSpecLayer,
         floatarray soilW,
         int numNodes,
         strarray constituents,
         floatarray thickness,
         floatarray depth):
    cdef float volSpecHeatSoil[]
    cdef int node 
    cdef int constituent 
    for node in range(1 , numNodes + 1 , 1):
        volSpecHeatSoil[node]=0.0
        for constituent in range(0 , len(constituents) , 1):
            volSpecHeatSoil[node]=volSpecHeatSoil[node] + (volumetricSpecificHeat(constituents[constituent]) * 1000000.0 * soilW[node])
    volSpecLayer=mapLayer2Node(volSpecHeatSoil, volSpecLayer, thickness, depth, numNodes)
    return volSpecLayer

def volumetricSpecificHeat(str name):
    cdef float specificHeatRocks = 7.7
    cdef float specificHeatOM = 0.25
    cdef float specificHeatSand = 7.7
    cdef float specificHeatSilt = 2.74
    cdef float specificHeatClay = 2.92
    cdef float specificHeatWater = 0.57
    cdef float specificHeatIce = 2.18
    cdef float specificHeatAir = 0.025
    cdef float res = 0.0
    if name == Rocks:
        res=specificHeatRocks
    elif name == OrganicMatter:
        res=specificHeatOM
    elif name == Sand:
        res=specificHeatSand
    elif name == Silt:
        res=specificHeatSilt
    elif name == Clay:
        res=specificHeatClay
    elif name == Water:
        res=specificHeatWater
    elif name == Ice:
        res=specificHeatIce
    elif name == Air:
        res=specificHeatAir
    return res

def mapLayer2Node(floatarray layerArray,
         floatarray nodeArray,
         floatarray thickness,
         floatarray depth,
         int numNodes):
    cdef int SURFACEnode = 1
    cdef float depthLayerAbove 
    cdef int node = 0
    cdef int i = 0
    cdef int layer 
    cdef float d1 
    cdef float d2 
    cdef float dSum 
    for node in range(SURFACEnode , numNodes + 1 , 1):
        layer=node - 1
        depthLayerAbove=0.0
        if layer >= 1:
            for i in range(1 , layer + 1 , 1):
                depthLayerAbove=depthLayerAbove + thickness[i]
        d1=depthLayerAbove - (depth[node] * 1000.0)
        d2=depth[(node + 1)] * 1000.0 - depthLayerAbove
        dSum=d1 + d2
        nodeArray[node]=Divide(layerArray[layer] * d1, dSum, 0.0) + Divide(layerArray[(layer + 1)] * d2, dSum, 0.0)
    return nodeArray
