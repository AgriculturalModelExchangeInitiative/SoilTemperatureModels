def doThermConductivity(floatlist soilW,
         floatlist SLCARBApsim,
         floatlist SLROCKApsim,
         floatlist SLSANDApsim,
         floatlist SLSILTApsim,
         floatlist CLAYApsim,
         floatlist BDApsim,
         floatlist thermalConductivity,
         floatlist THICKApsim,
         floatlist DEPTHApsim,
         int numNodes,
         strarray constituents):
    cdef floatlist  thermCondLayers
    thermCondLayers=[0.0]
    cdef int I 
    for I in range(0 , numNodes + 1 , 1):
        thermCondLayers.append(0.0)
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
            shapeFactorConstituent=shapeFactor(constituents[constituent], SLROCKApsim, SLCARBApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, soilW, BDApsim, node)
            thermalConductanceConstituent=ThermalConductance(constituents[constituent])
            thermalConductanceWater=ThermalConductance("Water")
            k=2.0 / 3.0 * pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0))), -1) + (1.0 / 3.0 * pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0) * (1.0 - (2.0 * shapeFactorConstituent)))), -1))
            numerator=numerator + (thermalConductanceConstituent * soilW[node] * k)
            denominator=denominator + (soilW[node] * k)
        thermCondLayers[node]=numerator / denominator
    thermalConductivity=mapLayer2Node(thermCondLayers, thermalConductivity, THICKApsim, DEPTHApsim, numNodes)
    return thermalConductivity

def shapeFactor(str name,
         floatlist SLROCKApsim,
         floatlist SLCARBApsim,
         floatlist SLSANDApsim,
         floatlist SLSILTApsim,
         floatlist CLAYApsim,
         floatlist SWApsim,
         floatlist BDApsim,
         int layer):
    cdef float shapeFactorRocks = 0.182
    cdef float shapeFactorOM = 0.5
    cdef float shapeFactorSand = 0.182
    cdef float shapeFactorSilt = 0.125
    cdef float shapeFactorClay = 0.007755
    cdef float shapeFactorWater = 1.0
    cdef float result = 0.0
    if name == "Rocks":
        result=shapeFactorRocks
    elif name == "OrganicMatter":
        result=shapeFactorOM
    elif name == "Sand":
        result=shapeFactorSand
    elif name == "Silt":
        result=shapeFactorSilt
    elif name == "Clay":
        result=shapeFactorClay
    elif name == "Water":
        result=shapeFactorWater
    elif name == "Ice":
        result=0.333 - (0.333 * 0.0 / (volumetricFractionWater(SWApsim, SLCARBApsim, BDApsim, layer) + 0.0 + volumetricFractionAir(SLROCKApsim, SLCARBApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, SWApsim, BDApsim, layer)))
        return result
    elif name == "Air":
        result=0.333 - (0.333 * volumetricFractionAir(SLROCKApsim, SLCARBApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, SWApsim, BDApsim, layer) / (volumetricFractionWater(SWApsim, SLCARBApsim, BDApsim, layer) + 0.0 + volumetricFractionAir(SLROCKApsim, SLCARBApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, SWApsim, BDApsim, layer)))
        return result
    elif name == "Minerals":
        result=shapeFactorRocks * volumetricFractionRocks(SLROCKApsim, layer) + (shapeFactorSand * volumetricFractionSand(SLSANDApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer)) + (shapeFactorSilt * volumetricFractionSilt(SLSILTApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer)) + (shapeFactorClay * volumetricFractionClay(CLAYApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer))
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
    if name == "Rocks":
        result=thermal_conductance_rocks
    elif name == "OrganicMatter":
        result=thermal_conductance_om
    elif name == "Sand":
        result=thermal_conductance_sand
    elif name == "Silt":
        result=thermal_conductance_silt
    elif name == "Clay":
        result=thermal_conductance_clay
    elif name == "Water":
        result=thermal_conductance_water
    elif name == "Ice":
        result=thermal_conductance_ice
    elif name == "Air":
        result=thermal_conductance_air
    result=volumetricSpecificHeat(name)
    return result

def mapLayer2Node(floatlist layerArray,
         floatlist nodeArray,
         floatlist THICKApsim,
         floatlist DEPTHApsim,
         int numNodes):
    cdef int SURFACEnode = 1
    cdef float depthLayerAbove 
    cdef int node = 0
    cdef int I = 0
    cdef int layer 
    cdef float d1 
    cdef float d2 
    cdef float dSum 
    for node in range(SURFACEnode , numNodes + 1 , 1):
        layer=node - 1
        depthLayerAbove=0.0
        if layer >= 1:
            for I in range(1 , layer + 1 , 1):
                depthLayerAbove=depthLayerAbove + THICKApsim[I]
        d1=depthLayerAbove - (DEPTHApsim[node] * 1000.0)
        d2=DEPTHApsim[(node + 1)] * 1000.0 - depthLayerAbove
        dSum=d1 + d2
        nodeArray[node]=Divide(layerArray[layer] * d1, dSum, 0.0) + Divide(layerArray[(layer + 1)] * d2, dSum, 0.0)
    return nodeArray

def volumetricFractionWater(floatlist SWApsim,
         floatlist SLCARBApsim,
         floatlist BDApsim,
         int layer):
    cdef float res = (1.0 - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer)) * SWApsim[layer]
    return res

def volumetricFractionAir(floatlist SLROCKApsim,
         floatlist SLCARBApsim,
         floatlist SLSANDApsim,
         floatlist SLSILTApsim,
         floatlist CLAYApsim,
         floatlist SWApsim,
         floatlist BDApsim,
         int layer):
    cdef float res = 1.0 - volumetricFractionRocks(SLROCKApsim, layer) - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionSand(SLSANDApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer) - volumetricFractionSilt(SLSILTApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer) - volumetricFractionClay(CLAYApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer) - volumetricFractionWater(SWApsim, SLCARBApsim, BDApsim, layer) - 0.0
    return res

def volumetricFractionRocks(floatlist SLROCKApsim,
         int layer):
    cdef float res = SLROCKApsim[layer] / 100.0
    return res

def volumetricFractionSand(floatlist SLSANDApsim,
         floatlist SLROCKApsim,
         floatlist SLCARBApsim,
         floatlist BDApsim,
         int layer):
    cdef float ps = 2.63
    cdef float res = (1.0 - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionRocks(SLROCKApsim, layer)) * SLSANDApsim[layer] / 100.0 * BDApsim[layer] / ps
    return res

def volumetricFractionSilt(floatlist SLSILTApsim,
         floatlist SLROCKApsim,
         floatlist SLCARBApsim,
         floatlist BDApsim,
         int layer):
    cdef float ps = 2.63
    cdef float res = (1.0 - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionRocks(SLROCKApsim, layer)) * SLSILTApsim[layer] / 100.0 * BDApsim[layer] / ps
    return res

def volumetricFractionClay(floatlist CLAYApsim,
         floatlist SLROCKApsim,
         floatlist SLCARBApsim,
         floatlist BDApsim,
         int layer):
    cdef float ps = 2.63
    cdef float res = (1.0 - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionRocks(SLROCKApsim, layer)) * CLAYApsim[layer] / 100.0 * BDApsim[layer] / ps
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
    if name == "Rocks":
        res=specificHeatRocks
    elif name == "OrganicMatter":
        res=specificHeatOM
    elif name == "Sand":
        res=specificHeatSand
    elif name == "Silt":
        res=specificHeatSilt
    elif name == "Clay":
        res=specificHeatClay
    elif name == "Water":
        res=specificHeatWater
    elif name == "Ice":
        res=specificHeatIce
    elif name == "Air":
        res=specificHeatAir
    return res

def volumetricFractionOrganicMatter(floatlist SLCARBApsim,
         floatlist BDApsim,
         int layer):
    cdef float pom = 1.3
    cdef float res = SLCARBApsim[layer] / 100.0 * 2.5 * BDApsim[layer] / pom
    return res
