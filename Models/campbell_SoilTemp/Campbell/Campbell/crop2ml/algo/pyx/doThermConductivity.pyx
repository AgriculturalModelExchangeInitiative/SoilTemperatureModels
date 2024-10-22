def doThermConductivity(floatarray soilW,
         floatarray carbon,
         floatarray rocks,
         floatarray sand,
         floatarray silt,
         floatarray clay,
         floatarray bulkDensity,
         floatarray thermalConductivity,
         floatarray thickness,
         floatarray depth,
         int numNodes,
         strarray constituents):
    cdef float thermCondLayers[]
    cdef int node = 1
    cdef int constituent = 1
    cdef float temp 
    cdef float numerator 
    cdef float denominator 
    cdef float shapeFactorConstituent 
    cdef float thermalConductanceConstituent 
    cdef float thermalConductanceWater 
    cdef float k 
    for node in range(1 , numNodes + 1 , 1):
        numerator=0.0
        denominator=0.0
        for constituent in range(0 , len(constituents) , 1):
            shapeFactorConstituent=shapeFactor(constituents[constituent], rocks, carbon, sand, silt, clay, soilW, bulkDensity, node)
            thermalConductanceConstituent=ThermalConductance(constituents[constituent])
            thermalConductanceWater=ThermalConductance(Water)
            k=2.0 / 3.0 * pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0))), -1) + (1.0 / 3.0 * pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0) * (1.0 - (2.0 * shapeFactorConstituent)))), -1))
            numerator=numerator + (thermalConductanceConstituent * soilW[node] * k)
            denominator=denominator + (soilW[node] * k)
        thermCondLayers[node]=numerator / denominator
    thermalConductivity=mapLayer2Node(thermCondLayers, thermalConductivity, thickness, depth, numNodes)
    return thermalConductivity

def shapeFactor(str name,
         floatarray rocks,
         floatarray carbon,
         floatarray sand,
         floatarray silt,
         floatarray clay,
         floatarray soilWater,
         floatarray bulkDensity,
         int layer):
    cdef float shapeFactorRocks = 0.182
    cdef float shapeFactorOM = 0.5
    cdef float shapeFactorSand = 0.182
    cdef float shapeFactorSilt = 0.125
    cdef float shapeFactorClay = 0.007755
    cdef float shapeFactorWater = 1.0
    cdef float result = 0.0
    if name == Rocks:
        result=shapeFactorRocks
    elif name == OrganicMatter:
        result=shapeFactorOM
    elif name == Sand:
        result=shapeFactorSand
    elif name == Silt:
        result=shapeFactorSilt
    elif name == Clay:
        result=shapeFactorClay
    elif name == Water:
        result=shapeFactorWater
    elif name == Ice:
        result=0.333 - (0.333 * 0.0 / (volumetricFractionWater(soilWater, carbon, bulkDensity, layer) + 0.0 + volumetricFractionAir(rocks, carbon, sand, silt, clay, soilWater, bulkDensity, layer)))
        return result
    elif name == Air:
        result=0.333 - (0.333 * volumetricFractionAir(rocks, carbon, sand, silt, clay, soilWater, bulkDensity, layer) / (volumetricFractionWater(soilWater, carbon, bulkDensity, layer) + 0.0 + volumetricFractionAir(rocks, carbon, sand, silt, clay, soilWater, bulkDensity, layer)))
        return result
    elif name == Minerals:
        result=shapeFactorRocks * volumetricFractionRocks(rocks, layer) + (shapeFactorSand * volumetricFractionSand(sand, rocks, carbon, bulkDensity, layer)) + (shapeFactorSilt * volumetricFractionSilt(silt, rocks, carbon, bulkDensity, layer)) + (shapeFactorClay * volumetricFractionClay(clay, rocks, carbon, bulkDensity, layer))
    result=volumetricSpecificHeat(name)
    return result

def ThermalConductance(str name):
    cdef float thermal_conductance_rocks = 0.182
    cdef float thermal_conductance_om = 2.50
    cdef float thermal_conductance_sand = 0.182
    cdef float thermal_conductance_silt = 2.39
    cdef float thermal_conductance_clay = 1.39
    cdef float thermal_conductance_water = 4.18
    cdef float thermal_conductance_ice = 1.73
    cdef float thermal_conductance_air = 0.0012
    cdef float result = 0.0
    if name == Rocks:
        result=thermal_conductance_rocks
    elif name == OrganicMatter:
        result=thermal_conductance_om
    elif name == Sand:
        result=thermal_conductance_sand
    elif name == Silt:
        result=thermal_conductance_silt
    elif name == Clay:
        result=thermal_conductance_clay
    elif name == Water:
        result=thermal_conductance_water
    elif name == Ice:
        result=thermal_conductance_ice
    elif name == Air:
        result=thermal_conductance_air
    result=volumetricSpecificHeat(name)
    return result

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

def volumetricFractionWater(floatarray soilWater,
         floatarray carbon,
         floatarray bulkDensity,
         int layer):
    cdef float res = (1.0 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer)) * soilWater[layer]
    return res

def volumetricFractionAir(floatarray rocks,
         floatarray carbon,
         floatarray sand,
         floatarray silt,
         floatarray clay,
         floatarray soilWater,
         floatarray bulkDensity,
         int layer):
    cdef float res = 1.0 - volumetricFractionRocks(rocks, layer) - volumetricFractionOrganicMatter(carbon, bulkDensity, layer) - volumetricFractionSand(sand, rocks, carbon, bulkDensity, layer) - volumetricFractionSilt(silt, rocks, carbon, bulkDensity, layer) - volumetricFractionClay(clay, rocks, carbon, bulkDensity, layer) - volumetricFractionWater(soilWater, carbon, bulkDensity, layer) - 0.0
    return res

def volumetricFractionRocks(floatarray rocks,
         int layer):
    cdef float res = rocks[layer] / 100.0
    return res

def volumetricFractionSand(floatarray sand,
         floatarray rocks,
         floatarray carbon,
         floatarray bulkDensity,
         int layer):
    cdef float ps = 2.63
    cdef float res = (1.0 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer) - volumetricFractionRocks(rocks, layer)) * sand[layer] / 100.0 * bulkDensity[layer] / ps
    return res

def volumetricFractionSilt(floatarray silt,
         floatarray rocks,
         floatarray carbon,
         floatarray bulkDensity,
         int layer):
    cdef float ps = 2.63
    cdef float res = (1.0 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer) - volumetricFractionRocks(rocks, layer)) * silt[layer] / 100.0 * bulkDensity[layer] / ps
    return res

def volumetricFractionClay(floatarray clay,
         floatarray rocks,
         floatarray carbon,
         floatarray bulkDensity,
         int layer):
    cdef float ps = 2.63
    cdef float res = (1.0 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer) - volumetricFractionRocks(rocks, layer)) * clay[layer] / 100.0 * bulkDensity[layer] / ps
    return res

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

def volumetricFractionOrganicMatter(floatarray carbon,
         floatarray bulkDensity,
         int layer):
    cdef float pom = 1.3
    cdef float res = carbon[layer] / 100.0 * 2.5 * bulkDensity[layer] / pom
    return res
