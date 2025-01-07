def getProfileVariables(floatarray maxSoilTemp,
         floatarray minSoilTemp,
         int topsoilNode,
         floatarray thermalConductance,
         floatarray physical_BD,
         floatarray soilTemp,
         floatarray carbon,
         floatarray physical_ParticleSizeSand,
         floatarray physical_Thickness,
         floatarray newTemperature,
         floatarray heatStorage,
         int numPhantomNodes,
         floatarray soilWater,
         floatarray nodeDepth,
         floatarray volSpecHeatSoil,
         floatarray aveSoilTemp,
         int surfaceNode,
         floatarray rocks,
         floatarray physical_Rocks,
         floatarray physical_ParticleSizeSilt,
         floatarray thermalConductivity,
         floatarray silt,
         floatarray sand,
         int numNodes,
         floatarray organic_Carbon,
         floatarray morningSoilTemp,
         float DepthToConstantTemperature,
         floatarray clay,
         floatarray thickness,
         floatarray bulkDensity,
         floatarray waterBalance_SW,
         float airNode,
         floatarray physical_ParticleSizeClay,
         int numLayers,
         float MissingValue):
    cdef int layer 
    cdef int node 
    cdef int i 
    cdef float belowProfileDepth 
    cdef float thicknessForPhantomNodes 
    cdef int firstPhantomNode 
    cdef float oldDepth[]
    cdef float oldBulkDensity[]
    cdef float oldSoilWater[]
    numLayers=len(physical_Thickness)
    numNodes=numLayers + numPhantomNodes
    thickness=array('f', [0.0]*(numLayers + numPhantomNodes + 1))
    thickness[1:1 + len(physical_Thickness)]=physical_Thickness
    belowProfileDepth=max(DepthToConstantTemperature - Sum(thickness, 1, numLayers, MissingValue), 1000.0)
    thicknessForPhantomNodes=belowProfileDepth * 2.0 / numPhantomNodes
    firstPhantomNode=numLayers
    for i in range(firstPhantomNode , firstPhantomNode + numPhantomNodes , 1):
        thickness[i]=thicknessForPhantomNodes
    oldDepth=nodeDepth
    nodeDepth=array('f', [0.0]*(numNodes + 1 + 1))
    if oldDepth is not None:
        nodeDepth[0:min(numNodes + 1 + 1, len(oldDepth))]=oldDepth[0:min(numNodes + 1 + 1, len(oldDepth))]
    nodeDepth[airNode]=0.0
    nodeDepth[surfaceNode]=0.0
    nodeDepth[topsoilNode]=0.5 * thickness[1] / 1000.0
    for node in range(topsoilNode , numNodes + 1 , 1):
        nodeDepth[node + 1]=(Sum(thickness, 1, node - 1, MissingValue) + (0.5 * thickness[node])) / 1000.0
    oldBulkDensity=bulkDensity
    bulkDensity=array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    if oldBulkDensity is not None:
        bulkDensity[0:min(numLayers + 1 + numPhantomNodes, len(oldBulkDensity))]=oldBulkDensity[0:min(numLayers + 1 + numPhantomNodes, len(oldBulkDensity))]
    bulkDensity[1:1 + len(physical_BD)]=physical_BD
    bulkDensity[numNodes]=bulkDensity[numLayers]
    for layer in range(numLayers + 1 , numLayers + numPhantomNodes + 1 , 1):
        bulkDensity[layer]=bulkDensity[numLayers]
    oldSoilWater=soilWater
    soilWater=array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    if oldSoilWater is not None:
        soilWater[0:min(numLayers + 1 + numPhantomNodes, len(oldSoilWater))]=oldSoilWater[0:min(numLayers + 1 + numPhantomNodes, len(oldSoilWater))]
    if waterBalance_SW is not None:
        for layer in range(1 , numLayers + 1 , 1):
            soilWater[layer]=Divide(waterBalance_SW[(layer - 1)] * thickness[(layer - 1)], thickness[layer], 0)
        for layer in range(numLayers + 1 , numLayers + numPhantomNodes + 1 , 1):
            soilWater[layer]=soilWater[numLayers]
    carbon=array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    for layer in range(1 , numLayers + 1 , 1):
        carbon[layer]=organic_Carbon[layer - 1]
    for layer in range(numLayers + 1 , numLayers + numPhantomNodes + 1 , 1):
        carbon[layer]=carbon[numLayers]
    rocks=array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    for layer in range(1 , numLayers + 1 , 1):
        rocks[layer]=physical_Rocks[layer - 1]
    for layer in range(numLayers + 1 , numLayers + numPhantomNodes + 1 , 1):
        rocks[layer]=rocks[numLayers]
    sand=array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    for layer in range(1 , numLayers + 1 , 1):
        sand[layer]=physical_ParticleSizeSand[layer - 1]
    for layer in range(numLayers + 1 , numLayers + numPhantomNodes + 1 , 1):
        sand[layer]=sand[numLayers]
    silt=array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    for layer in range(1 , numLayers + 1 , 1):
        silt[layer]=physical_ParticleSizeSilt[layer - 1]
    for layer in range(numLayers + 1 , numLayers + numPhantomNodes + 1 , 1):
        silt[layer]=silt[numLayers]
    clay=array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    for layer in range(1 , numLayers + 1 , 1):
        clay[layer]=physical_ParticleSizeClay[layer - 1]
    for layer in range(numLayers + 1 , numLayers + numPhantomNodes + 1 , 1):
        clay[layer]=clay[numLayers]
    maxSoilTemp=array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    minSoilTemp=array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    aveSoilTemp=array('f', [0.0]*(numLayers + 1 + numPhantomNodes))
    volSpecHeatSoil=array('f', [0.0]*(numNodes + 1))
    soilTemp=array('f', [0.0]*(numNodes + 1 + 1))
    morningSoilTemp=array('f', [0.0]*(numNodes + 1 + 1))
    newTemperature=array('f', [0.0]*(numNodes + 1 + 1))
    thermalConductivity=array('f', [0.0]*(numNodes + 1))
    heatStorage=array('f', [0.0]*(numNodes + 1))
    thermalConductance=array('f', [0.0]*(numNodes + 1 + 1))
    return (maxSoilTemp, minSoilTemp, thermalConductance, soilTemp, carbon, newTemperature, heatStorage, soilWater, nodeDepth, volSpecHeatSoil, aveSoilTemp, rocks, thermalConductivity, silt, sand, morningSoilTemp, clay, thickness, bulkDensity, numNodes, numLayers)