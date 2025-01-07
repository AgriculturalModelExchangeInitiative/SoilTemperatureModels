def getOtherVariables(floatarray soilWater,
         float instrumentHeight,
         float microClimate_CanopyHeight,
         floatarray waterBalance_SW,
         int numNodes,
         float canopyHeight,
         float soilRoughnessHeight,
         int numLayers):
    soilWater[1:1 + len(waterBalance_SW)]=waterBalance_SW
    soilWater[numNodes]=soilWater[numLayers]
    canopyHeight=max(microClimate_CanopyHeight, soilRoughnessHeight) / 1000.0
    instrumentHeight=max(instrumentHeight, canopyHeight + 0.5)
    return (soilWater, canopyHeight, instrumentHeight)