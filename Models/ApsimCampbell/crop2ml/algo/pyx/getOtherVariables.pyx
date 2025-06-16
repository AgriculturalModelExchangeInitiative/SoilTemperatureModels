def getOtherVariables(int numLayers,
         int numNodes,
         floatarray soilWater,
         float instrumentHeight,
         float soilRoughnessHeight,
         floatarray waterBalance_SW,
         float microClimate_CanopyHeight,
         float canopyHeight):
    soilWater[1:1 + len(waterBalance_SW)]=waterBalance_SW
    soilWater[numNodes]=soilWater[numLayers]
    canopyHeight=max(microClimate_CanopyHeight, soilRoughnessHeight) / 1000.0
    instrumentHeight=max(instrumentHeight, canopyHeight + 0.5)
    return (soilWater, instrumentHeight, canopyHeight)