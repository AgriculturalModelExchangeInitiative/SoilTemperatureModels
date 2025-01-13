def volumetricFractionOrganicMatter(int layer,
         float pom,
         floatarray carbon,
         floatarray bulkDensity):
    return carbon[layer] / 100.0 * 2.5 * bulkDensity[layer] / pom

def volumetricFractionRocks(int layer,
         floatarray rocks):
    return rocks[layer] / 100.0

def volumetricFractionIce(int layer):
    return 0.0

def volumetricFractionWater(int layer,
         floatarray soilWater,
         float pom,
         floatarray carbon,
         floatarray bulkDensity):
    return (1 - volumetricFractionOrganicMatter(layer, pom, carbon, bulkDensity)) * soilWater[layer]

def volumetricFractionClay(int layer,
         floatarray clay,
         float ps,
         floatarray bulkDensity,
         float pom,
         floatarray carbon,
         floatarray rocks):
    return (1 - volumetricFractionOrganicMatter(layer, pom, carbon, bulkDensity) - volumetricFractionRocks(layer, rocks)) * clay[layer] / 100.0 * bulkDensity[layer] / ps

def volumetricFractionSilt(int layer,
         floatarray silt,
         float ps,
         floatarray bulkDensity,
         float pom,
         floatarray carbon,
         floatarray rocks):
    return (1 - volumetricFractionOrganicMatter(layer, pom, carbon, bulkDensity) - volumetricFractionRocks(layer, rocks)) * silt[layer] / 100.0 * bulkDensity[layer] / ps

def volumetricFractionSand(int layer,
         floatarray sand,
         float ps,
         floatarray bulkDensity,
         float pom,
         floatarray carbon,
         floatarray rocks):
    return (1 - volumetricFractionOrganicMatter(layer, pom, carbon, bulkDensity) - volumetricFractionRocks(layer, rocks)) * sand[layer] / 100.0 * bulkDensity[layer] / ps

def kelvinT(float celciusT):
    cdef float celciusToKelvin 
    celciusToKelvin=273.18
    return celciusT + celciusToKelvin

def Divide(float value1,
         float value2,
         float errVal):
    if value2 != float(0):
        return value1 / value2
    return errVal

def Sum(floatarray values,
         int startIndex,
         int endIndex,
         float MissingValue):
    cdef float value 
    cdef float result 
    cdef int index 
    result=0.0
    index=-1
    for value in values:
        index=index + 1
        if index >= startIndex and value != MissingValue:
            result+=value
        if index == endIndex:
            break
    return result

def volumetricSpecificHeat(str name,
         int layer):
    cdef float specificHeatRocks 
    cdef float specificHeatOM 
    cdef float specificHeatSand 
    cdef float specificHeatSilt 
    cdef float specificHeatClay 
    cdef float specificHeatWater 
    cdef float specificHeatIce 
    cdef float specificHeatAir 
    cdef float result 
    specificHeatRocks=7.7
    specificHeatOM=0.25
    specificHeatSand=7.7
    specificHeatSilt=2.74
    specificHeatClay=2.92
    specificHeatWater=0.57
    specificHeatIce=2.18
    specificHeatAir=0.025
    result=0.0
    if name == "Rocks":
        result=specificHeatRocks
    elif name == "OrganicMatter":
        result=specificHeatOM
    elif name == "Sand":
        result=specificHeatSand
    elif name == "Silt":
        result=specificHeatSilt
    elif name == "Clay":
        result=specificHeatClay
    elif name == "Water":
        result=specificHeatWater
    elif name == "Ice":
        result=specificHeatIce
    elif name == "Air":
        result=specificHeatAir
    return result

def volumetricFractionAir(int layer,
         floatarray rocks,
         float pom,
         floatarray carbon,
         floatarray bulkDensity,
         floatarray sand,
         float ps,
         floatarray silt,
         floatarray clay,
         floatarray soilWater):
    return 1.0 - volumetricFractionRocks(layer, rocks) - volumetricFractionOrganicMatter(layer, pom, carbon, bulkDensity) - volumetricFractionSand(layer, sand, ps, bulkDensity, pom, carbon, rocks) - volumetricFractionSilt(layer, silt, ps, bulkDensity, pom, carbon, rocks) - volumetricFractionClay(layer, clay, ps, bulkDensity, pom, carbon, rocks) - volumetricFractionWater(layer, soilWater, pom, carbon, bulkDensity) - volumetricFractionIce(layer)

def airDensity(float temperature,
         float AirPressure):
    cdef float MWair 
    cdef float RGAS 
    cdef float HPA2PA 
    MWair=0.02897
    RGAS=8.3143
    HPA2PA=100.0
    return Divide(MWair * AirPressure * HPA2PA, kelvinT(temperature) * RGAS, 0.0)

def longWaveRadn(float emissivity,
         float tDegC,
         float stefanBoltzmannConstant):
    return stefanBoltzmannConstant * emissivity * pow(kelvinT(tDegC), 4)

def mapLayer2Node(floatarray layerArray,
         floatarray nodeArray,
         int surfaceNode,
         floatarray thickness,
         int numNodes,
         floatarray nodeDepth,
         float MissingValue):
    cdef int node 
    cdef int layer 
    cdef float depthLayerAbove 
    cdef float d1 
    cdef float d2 
    cdef float dSum 
    for node in range(surfaceNode , numNodes + 1 , 1):
        layer=node - 1
        depthLayerAbove=Sum(thickness, 1, layer, MissingValue) if layer >= 1 else 0.0
        d1=depthLayerAbove - (nodeDepth[node] * 1000.0)
        d2=nodeDepth[(node + 1)] * 1000.0 - depthLayerAbove
        dSum=d1 + d2
        nodeArray[node]=Divide(layerArray[layer] * d1, dSum, 0) + Divide(layerArray[(layer + 1)] * d2, dSum, 0)
    return nodeArray

def ThermalConductance(str name,
         int layer,
         floatarray rocks,
         floatarray sand,
         float ps,
         floatarray bulkDensity,
         float pom,
         floatarray carbon,
         floatarray silt,
         floatarray clay):
    cdef float thermalConductanceRocks 
    cdef float thermalConductanceOM 
    cdef float thermalConductanceSand 
    cdef float thermalConductanceSilt 
    cdef float thermalConductanceClay 
    cdef float thermalConductanceWater 
    cdef float thermalConductanceIce 
    cdef float thermalConductanceAir 
    cdef float result 
    thermalConductanceRocks=0.182
    thermalConductanceOM=2.50
    thermalConductanceSand=0.182
    thermalConductanceSilt=2.39
    thermalConductanceClay=1.39
    thermalConductanceWater=4.18
    thermalConductanceIce=1.73
    thermalConductanceAir=0.0012
    result=0.0
    if name == "Rocks":
        result=thermalConductanceRocks
    elif name == "OrganicMatter":
        result=thermalConductanceOM
    elif name == "Sand":
        result=thermalConductanceSand
    elif name == "Silt":
        result=thermalConductanceSilt
    elif name == "Clay":
        result=thermalConductanceClay
    elif name == "Water":
        result=thermalConductanceWater
    elif name == "Ice":
        result=thermalConductanceIce
    elif name == "Air":
        result=thermalConductanceAir
    elif name == "Minerals":
        result=pow(thermalConductanceRocks, volumetricFractionRocks(layer, rocks)) * pow(thermalConductanceSand, volumetricFractionSand(layer, sand, ps, bulkDensity, pom, carbon, rocks)) + pow(thermalConductanceSilt, volumetricFractionSilt(layer, silt, ps, bulkDensity, pom, carbon, rocks)) + pow(thermalConductanceClay, volumetricFractionClay(layer, clay, ps, bulkDensity, pom, carbon, rocks))
    result=volumetricSpecificHeat(name, layer)
    return result

def shapeFactor(str name,
         int layer,
         floatarray soilWater,
         float pom,
         floatarray carbon,
         floatarray bulkDensity,
         floatarray rocks,
         floatarray sand,
         float ps,
         floatarray silt,
         floatarray clay):
    cdef float shapeFactorRocks 
    cdef float shapeFactorOM 
    cdef float shapeFactorSand 
    cdef float shapeFactorSilt 
    cdef float shapeFactorClay 
    cdef float shapeFactorWater 
    cdef float result 
    shapeFactorRocks=0.182
    shapeFactorOM=0.5
    shapeFactorSand=0.182
    shapeFactorSilt=0.125
    shapeFactorClay=0.007755
    shapeFactorWater=1.0
    result=0.0
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
        result=0.333 - (0.333 * volumetricFractionIce(layer) / (volumetricFractionWater(layer, soilWater, pom, carbon, bulkDensity) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, pom, carbon, bulkDensity, sand, ps, silt, clay, soilWater)))
        return result
    elif name == "Air":
        result=0.333 - (0.333 * volumetricFractionAir(layer, rocks, pom, carbon, bulkDensity, sand, ps, silt, clay, soilWater) / (volumetricFractionWater(layer, soilWater, pom, carbon, bulkDensity) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, pom, carbon, bulkDensity, sand, ps, silt, clay, soilWater)))
        return result
    elif name == "Minerals":
        result=shapeFactorRocks * volumetricFractionRocks(layer, rocks) + (shapeFactorSand * volumetricFractionSand(layer, sand, ps, bulkDensity, pom, carbon, rocks)) + (shapeFactorSilt * volumetricFractionSilt(layer, silt, ps, bulkDensity, pom, carbon, rocks)) + (shapeFactorClay * volumetricFractionClay(layer, clay, ps, bulkDensity, pom, carbon, rocks))
    result=volumetricSpecificHeat(name, layer)
    return result

def doUpdate(int numInterationsPerDay,
         floatarray newTemperature,
         int surfaceNode,
         int numNodes,
         floatarray soilTemp,
         floatarray aveSoilTemp,
         float timeOfDaySecs,
         floatarray thermalConductivity,
         int airNode,
         float internalTimeStep,
         floatarray maxSoilTemp,
         floatarray minSoilTemp,
         float boundaryLayerConductance):
    cdef int node 
    soilTemp[0:0 + len(newTemperature)]=newTemperature
    if timeOfDaySecs < (internalTimeStep * 1.2):
        for node in range(surfaceNode , numNodes + 1 , 1):
            minSoilTemp[node]=soilTemp[node]
            maxSoilTemp[node]=soilTemp[node]
    for node in range(surfaceNode , numNodes + 1 , 1):
        if soilTemp[node] < minSoilTemp[node]:
            minSoilTemp[node]=soilTemp[node]
        elif soilTemp[node] > maxSoilTemp[node]:
            maxSoilTemp[node]=soilTemp[node]
        aveSoilTemp[node]+=Divide(soilTemp[node], numInterationsPerDay, 0)
    boundaryLayerConductance+=Divide(thermalConductivity[airNode], numInterationsPerDay, 0)
    return (soilTemp, aveSoilTemp, maxSoilTemp, minSoilTemp, boundaryLayerConductance)

def doThomas(floatarray newTemps,
         int surfaceNode,
         floatarray thermalConductance,
         float nu,
         float timestep,
         floatarray soilTemp,
         float waterBalance_Eos,
         floatarray volSpecHeatSoil,
         floatarray heatStorage,
         float waterBalance_Es,
         floatarray thermalConductivity,
         floatarray nodeDepth,
         int numNodes,
         float latentHeatOfVapourisation,
         float netRadiation,
         int airNode,
         float internalTimeStep,
         str netRadiationSource):
    cdef int node 
    cdef float a[numNodes + 1 + 1]
    cdef float b[numNodes + 1]
    cdef float c[numNodes + 1]
    cdef float d[numNodes + 1]
    cdef float volumeOfSoilAtNode 
    cdef float elementLength 
    cdef float g 
    cdef float sensibleHeatFlux 
    cdef float radnNet 
    cdef float latentHeatFlux 
    cdef float soilSurfaceHeatFlux 
    thermalConductance[airNode]=thermalConductivity[airNode]
    for node in range(surfaceNode , numNodes + 1 , 1):
        volumeOfSoilAtNode=0.5 * (nodeDepth[node + 1] - nodeDepth[node - 1])
        heatStorage[node]=Divide(volSpecHeatSoil[node] * volumeOfSoilAtNode, internalTimeStep, 0)
        elementLength=nodeDepth[node + 1] - nodeDepth[node]
        thermalConductance[node]=Divide(thermalConductivity[node], elementLength, 0)
    g=1 - nu
    for node in range(surfaceNode , numNodes + 1 , 1):
        c[node]=-nu * thermalConductance[node]
        a[node + 1]=c[node]
        b[node]=nu * (thermalConductance[node] + thermalConductance[node - 1]) + heatStorage[node]
        d[node]=g * thermalConductance[(node - 1)] * soilTemp[(node - 1)] + ((heatStorage[node] - (g * (thermalConductance[node] + thermalConductance[node - 1]))) * soilTemp[node]) + (g * thermalConductance[node] * soilTemp[(node + 1)])
    a[surfaceNode]=0.0
    sensibleHeatFlux=nu * thermalConductance[airNode] * newTemps[airNode]
    radnNet=0.0
    if netRadiationSource == "calc":
        radnNet=Divide(netRadiation * 1000000.0, internalTimeStep, 0)
    elif netRadiationSource == "eos":
        radnNet=Divide(waterBalance_Eos * latentHeatOfVapourisation, timestep, 0)
    latentHeatFlux=Divide(waterBalance_Es * latentHeatOfVapourisation, timestep, 0)
    soilSurfaceHeatFlux=sensibleHeatFlux + radnNet - latentHeatFlux
    d[surfaceNode]+=soilSurfaceHeatFlux
    d[numNodes]+=nu * thermalConductance[numNodes] * newTemps[(numNodes + 1)]
    for node in range(surfaceNode , numNodes - 1 + 1 , 1):
        c[node]=Divide(c[node], b[node], 0)
        d[node]=Divide(d[node], b[node], 0)
        b[node + 1]-=a[(node + 1)] * c[node]
        d[node + 1]-=a[(node + 1)] * d[node]
    newTemps[numNodes]=Divide(d[numNodes], b[numNodes], 0)
    for node in range(numNodes - 1 , surfaceNode - 1 , -1):
        newTemps[node]=d[node] - (c[node] * newTemps[(node + 1)])
    return (newTemps, thermalConductance, heatStorage)

def getBoundaryLayerConductance(floatarray TNew_zb,
         int surfaceNode,
         float instrumentHeight,
         float canopyHeight,
         float weather_AirPressure,
         float weather_Wind,
         float waterBalance_Eos,
         float waterBalance_Eo,
         float airTemperature,
         float stefanBoltzmannConstant):
    cdef int iteration 
    cdef float vonKarmanConstant 
    cdef float gravitationalConstant 
    cdef float specificHeatOfAir 
    cdef float surfaceEmissivity 
    cdef float SpecificHeatAir 
    cdef float roughnessFactorMomentum 
    cdef float roughnessFactorHeat 
    cdef float d 
    cdef float surfaceTemperature 
    cdef float diffusePenetrationConstant 
    cdef float radiativeConductance 
    cdef float frictionVelocity 
    cdef float boundaryLayerCond 
    cdef float stabilityParammeter 
    cdef float stabilityCorrectionMomentum 
    cdef float stabilityCorrectionHeat 
    cdef float heatFluxDensity 
    vonKarmanConstant=0.41
    gravitationalConstant=9.8
    specificHeatOfAir=1010.0
    surfaceEmissivity=0.98
    SpecificHeatAir=specificHeatOfAir * airDensity(airTemperature, weather_AirPressure)
    roughnessFactorMomentum=0.13 * canopyHeight
    roughnessFactorHeat=0.2 * roughnessFactorMomentum
    d=0.77 * canopyHeight
    surfaceTemperature=TNew_zb[surfaceNode]
    diffusePenetrationConstant=max(0.1, waterBalance_Eos) / max(0.1, waterBalance_Eo)
    radiativeConductance=4.0 * stefanBoltzmannConstant * surfaceEmissivity * diffusePenetrationConstant * pow(kelvinT(airTemperature), 3)
    frictionVelocity=0.0
    boundaryLayerCond=0.0
    stabilityParammeter=0.0
    stabilityCorrectionMomentum=0.0
    stabilityCorrectionHeat=0.0
    heatFluxDensity=0.0
    for iteration in range(1 , 3 + 1 , 1):
        frictionVelocity=Divide(weather_Wind * vonKarmanConstant, log(Divide(instrumentHeight - d + roughnessFactorMomentum, roughnessFactorMomentum, 0)) + stabilityCorrectionMomentum, 0)
        boundaryLayerCond=Divide(SpecificHeatAir * vonKarmanConstant * frictionVelocity, log(Divide(instrumentHeight - d + roughnessFactorHeat, roughnessFactorHeat, 0)) + stabilityCorrectionHeat, 0)
        boundaryLayerCond+=radiativeConductance
        heatFluxDensity=boundaryLayerCond * (surfaceTemperature - airTemperature)
        stabilityParammeter=Divide(-vonKarmanConstant * instrumentHeight * gravitationalConstant * heatFluxDensity, SpecificHeatAir * kelvinT(airTemperature) * pow(frictionVelocity, 3.0), 0)
        if stabilityParammeter > 0.0:
            stabilityCorrectionHeat=4.7 * stabilityParammeter
            stabilityCorrectionMomentum=stabilityCorrectionHeat
        else:
            stabilityCorrectionHeat=-2.0 * log((1.0 + sqrt(1.0 - (16.0 * stabilityParammeter))) / 2.0)
            stabilityCorrectionMomentum=0.6 * stabilityCorrectionHeat
    return (boundaryLayerCond, TNew_zb)

def interpolateNetRadiation(float solarRadn,
         float cloudFr,
         float cva,
         int surfaceNode,
         float waterBalance_Eos,
         float waterBalance_Eo,
         float airTemperature,
         float internalTimeStep,
         floatarray soilTemp,
         float waterBalance_Salb,
         float stefanBoltzmannConstant):
    cdef float surfaceEmissivity 
    cdef float w2MJ 
    cdef float emissivityAtmos 
    cdef float PenetrationConstant 
    cdef float lwRinSoil 
    cdef float lwRoutSoil 
    cdef float lwRnetSoil 
    cdef float swRin 
    cdef float swRout 
    cdef float swRnetSoil 
    surfaceEmissivity=0.96
    w2MJ=internalTimeStep / 1000000.0
    emissivityAtmos=(1 - (0.84 * cloudFr)) * 0.58 * pow(cva, 1.0 / 7.0) + (0.84 * cloudFr)
    PenetrationConstant=Divide(max(0.1, waterBalance_Eos), max(0.1, waterBalance_Eo), 0)
    lwRinSoil=longWaveRadn(emissivityAtmos, airTemperature, stefanBoltzmannConstant) * PenetrationConstant * w2MJ
    lwRoutSoil=longWaveRadn(surfaceEmissivity, soilTemp[surfaceNode], stefanBoltzmannConstant) * PenetrationConstant * w2MJ
    lwRnetSoil=lwRinSoil - lwRoutSoil
    swRin=solarRadn
    swRout=waterBalance_Salb * solarRadn
    swRnetSoil=(swRin - swRout) * PenetrationConstant
    return swRnetSoil + lwRnetSoil

def interpolateTemperature(float timeHours,
         float maxTempYesterday,
         float minTempYesterday,
         float weather_MinT,
         float defaultTimeOfMaximumTemperature,
         float weather_MeanT,
         float weather_MaxT):
    cdef float time 
    cdef float maxT_time 
    cdef float minT_time 
    cdef float midnightT 
    cdef float tScale 
    cdef float currentTemperature 
    time=timeHours / 24.0
    maxT_time=defaultTimeOfMaximumTemperature / 24.0
    minT_time=maxT_time - 0.5
    if time < minT_time:
        midnightT=sin((0.0 + 0.25 - maxT_time) * 2.0 * pi) * (maxTempYesterday - minTempYesterday) / 2.0 + ((maxTempYesterday + minTempYesterday) / 2.0)
        tScale=(minT_time - time) / minT_time
        if tScale > 1.0:
            tScale=1.0
        elif tScale < float(0):
            tScale=float(0)
        currentTemperature=weather_MinT + (tScale * (midnightT - weather_MinT))
        return currentTemperature
    else:
        currentTemperature=sin((time + 0.25 - maxT_time) * 2.0 * pi) * (weather_MaxT - weather_MinT) / 2.0 + weather_MeanT
        return currentTemperature

def doThermalConductivity(int numNodes,
         floatarray soilWater,
         floatarray thermalConductivity,
         strarray soilConstituentNames,
         float pom,
         floatarray carbon,
         floatarray bulkDensity,
         floatarray rocks,
         floatarray sand,
         float ps,
         floatarray silt,
         floatarray clay,
         int surfaceNode,
         floatarray thickness,
         floatarray nodeDepth,
         float MissingValue):
    cdef int node 
    cdef str constituentName 
    cdef float thermCondLayers[numNodes + 1]
    cdef float numerator 
    cdef float denominator 
    cdef float shapeFactorConstituent 
    cdef float thermalConductanceConstituent 
    cdef float thermalConductanceWater 
    cdef float k 
    for node in range(1 , numNodes + 1 , 1):
        numerator=0.0
        denominator=0.0
        for constituentName in soilConstituentNames:
            shapeFactorConstituent=shapeFactor(constituentName, node, soilWater, pom, carbon, bulkDensity, rocks, sand, ps, silt, clay)
            thermalConductanceConstituent=ThermalConductance(constituentName, node, rocks, sand, ps, bulkDensity, pom, carbon, silt, clay)
            thermalConductanceWater=ThermalConductance("Water", node, rocks, sand, ps, bulkDensity, pom, carbon, silt, clay)
            k=2.0 / 3.0 * pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0))), -1) + (1.0 / 3.0 * pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0) * (1 - (2 * shapeFactorConstituent)))), -1))
            numerator+=thermalConductanceConstituent * soilWater[node] * k
            denominator+=soilWater[node] * k
        thermCondLayers[node]=numerator / denominator
    thermalConductivity=mapLayer2Node(thermCondLayers, thermalConductivity, surfaceNode, thickness, numNodes, nodeDepth, MissingValue)
    return thermalConductivity

def doVolumetricSpecificHeat(int numNodes,
         floatarray soilWater,
         floatarray volSpecHeatSoil,
         strarray soilConstituentNames,
         int surfaceNode,
         floatarray thickness,
         floatarray nodeDepth,
         float MissingValue):
    cdef int node 
    cdef str constituentName 
    cdef float volspecHeatSoil_[numNodes + 1]
    for node in range(1 , numNodes + 1 , 1):
        volspecHeatSoil_[node]=float(0)
        for constituentName in soilConstituentNames:
            if constituentName not in ["Minerals"]:
                volspecHeatSoil_[node]+=volumetricSpecificHeat(constituentName, node) * 1000000.0 * soilWater[node]
    volSpecHeatSoil=mapLayer2Node(volspecHeatSoil_, volSpecHeatSoil, surfaceNode, thickness, numNodes, nodeDepth, MissingValue)
    return volSpecHeatSoil

def Zero(floatarray arr):
    cdef int i 
    if arr is not None:
        for i in range(0 , len(arr) , 1):
            arr[i]=float(0)
    return arr

def doNetRadiation(floatarray solarRadn,
         float cloudFr,
         float cva,
         int ITERATIONSperDAY,
         float weather_Latitude,
         int clock_Today_DayOfYear,
         float weather_MinT,
         float weather_Radn):
    cdef int timestepNumber 
    cdef float TSTEPS2RAD 
    cdef float solarConstant 
    cdef float solarDeclination 
    cdef float cD 
    cdef float m1[ITERATIONSperDAY + 1]
    cdef float m1Tot 
    cdef float psr 
    cdef float fr 
    TSTEPS2RAD=Divide(2.0 * pi, float(ITERATIONSperDAY), 0)
    solarConstant=1360.0
    solarDeclination=0.3985 * sin((4.869 + (clock_Today_DayOfYear * 2.0 * pi / 365.25) + (0.03345 * sin((6.224 + (clock_Today_DayOfYear * 2.0 * pi / 365.25))))))
    cD=sqrt(1.0 - (solarDeclination * solarDeclination))
    m1Tot=0.0
    for timestepNumber in range(1 , ITERATIONSperDAY + 1 , 1):
        m1[timestepNumber]=(solarDeclination * sin(weather_Latitude * pi / 180.0) + (cD * cos(weather_Latitude * pi / 180.0) * cos(TSTEPS2RAD * (timestepNumber - (ITERATIONSperDAY / 2.0))))) * 24.0 / ITERATIONSperDAY
        if m1[timestepNumber] > 0.0:
            m1Tot+=m1[timestepNumber]
        else:
            m1[timestepNumber]=0.0
    psr=m1Tot * solarConstant * 3600.0 / 1000000.0
    fr=Divide(max(weather_Radn, 0.1), psr, 0)
    cloudFr=2.33 - (3.33 * fr)
    cloudFr=min(max(cloudFr, 0.0), 1.0)
    for timestepNumber in range(1 , ITERATIONSperDAY + 1 , 1):
        solarRadn[timestepNumber]=max(weather_Radn, 0.1) * Divide(m1[timestepNumber], m1Tot, 0)
    cva=exp((31.3716 - (6014.79 / kelvinT(weather_MinT)) - (0.00792495 * kelvinT(weather_MinT)))) / kelvinT(weather_MinT)
    return (solarRadn, cloudFr, cva)

def doProcess(float minTempYesterday,
         float timestep,
         float weather_MaxT,
         float weather_MinT,
         int numIterationsForBoundaryLayerConductance,
         floatarray soilTemp,
         float maxTempYesterday,
         floatarray thermalConductivity,
         str boundarLayerConductanceSource,
         floatarray minSoilTemp,
         float boundaryLayerConductance,
         floatarray newTemperature,
         float weather_MeanT,
         floatarray morningSoilTemp,
         floatarray aveSoilTemp,
         float internalTimeStep,
         float airTemperature,
         float netRadiation,
         int airNode,
         float timeOfDaySecs,
         floatarray maxSoilTemp,
         float constantBoundaryLayerConductance,
         float weather_Latitude,
         int clock_Today_DayOfYear,
         float weather_Radn,
         int numNodes,
         floatarray soilWater,
         floatarray volSpecHeatSoil,
         strarray soilConstituentNames,
         int surfaceNode,
         floatarray thickness,
         floatarray nodeDepth,
         float MissingValue,
         float pom,
         floatarray carbon,
         floatarray bulkDensity,
         floatarray rocks,
         floatarray sand,
         float ps,
         floatarray silt,
         floatarray clay,
         float defaultTimeOfMaximumTemperature,
         float waterBalance_Eos,
         float waterBalance_Eo,
         float waterBalance_Salb,
         float stefanBoltzmannConstant,
         float instrumentHeight,
         float canopyHeight,
         float weather_AirPressure,
         float weather_Wind,
         floatarray thermalConductance,
         float nu,
         floatarray heatStorage,
         float waterBalance_Es,
         float latentHeatOfVapourisation,
         str netRadiationSource):
    cdef int timeStepIteration 
    cdef int iteration 
    cdef int interactionsPerDay 
    cdef float cva 
    cdef float cloudFr 
    cdef float solarRadn[49]
    interactionsPerDay=48
    cva=0.0
    cloudFr=0.0
    (solarRadn, cloudFr, cva)=doNetRadiation(solarRadn, cloudFr, cva, interactionsPerDay, weather_Latitude, clock_Today_DayOfYear, weather_MinT, weather_Radn)
    minSoilTemp=Zero(minSoilTemp)
    maxSoilTemp=Zero(maxSoilTemp)
    aveSoilTemp=Zero(aveSoilTemp)
    boundaryLayerConductance=0.0
    internalTimeStep=round(timestep / interactionsPerDay)
    volSpecHeatSoil=doVolumetricSpecificHeat(numNodes, soilWater, volSpecHeatSoil, soilConstituentNames, surfaceNode, thickness, nodeDepth, MissingValue)
    thermalConductivity=doThermalConductivity(numNodes, soilWater, thermalConductivity, soilConstituentNames, pom, carbon, bulkDensity, rocks, sand, ps, silt, clay, surfaceNode, thickness, nodeDepth, MissingValue)
    for timeStepIteration in range(1 , interactionsPerDay + 1 , 1):
        timeOfDaySecs=internalTimeStep * float(timeStepIteration)
        if timestep < (24.0 * 60.0 * 60.0):
            airTemperature=weather_MeanT
        else:
            airTemperature=interpolateTemperature(timeOfDaySecs / 3600.0, maxTempYesterday, minTempYesterday, weather_MinT, defaultTimeOfMaximumTemperature, weather_MeanT, weather_MaxT)
        newTemperature[airNode]=airTemperature
        netRadiation=interpolateNetRadiation(solarRadn[timeStepIteration], cloudFr, cva, surfaceNode, waterBalance_Eos, waterBalance_Eo, airTemperature, internalTimeStep, soilTemp, waterBalance_Salb, stefanBoltzmannConstant)
        if boundarLayerConductanceSource == "constant":
            thermalConductivity[airNode]=constantBoundaryLayerConductance
        elif boundarLayerConductanceSource == "calc":
            (thermalConductivity[airNode], newTemperature)=getBoundaryLayerConductance(newTemperature, surfaceNode, instrumentHeight, canopyHeight, weather_AirPressure, weather_Wind, waterBalance_Eos, waterBalance_Eo, airTemperature, stefanBoltzmannConstant)
            for iteration in range(1 , numIterationsForBoundaryLayerConductance + 1 , 1):
                (newTemperature, thermalConductance, heatStorage)=doThomas(newTemperature, surfaceNode, thermalConductance, nu, timestep, soilTemp, waterBalance_Eos, volSpecHeatSoil, heatStorage, waterBalance_Es, thermalConductivity, nodeDepth, numNodes, latentHeatOfVapourisation, netRadiation, airNode, internalTimeStep, netRadiationSource)
                (thermalConductivity[airNode], newTemperature)=getBoundaryLayerConductance(newTemperature, surfaceNode, instrumentHeight, canopyHeight, weather_AirPressure, weather_Wind, waterBalance_Eos, waterBalance_Eo, airTemperature, stefanBoltzmannConstant)
        (newTemperature, thermalConductance, heatStorage)=doThomas(newTemperature, surfaceNode, thermalConductance, nu, timestep, soilTemp, waterBalance_Eos, volSpecHeatSoil, heatStorage, waterBalance_Es, thermalConductivity, nodeDepth, numNodes, latentHeatOfVapourisation, netRadiation, airNode, internalTimeStep, netRadiationSource)
        (soilTemp, aveSoilTemp, maxSoilTemp, minSoilTemp, boundaryLayerConductance)=doUpdate(interactionsPerDay, newTemperature, surfaceNode, numNodes, soilTemp, aveSoilTemp, timeOfDaySecs, thermalConductivity, airNode, internalTimeStep, maxSoilTemp, minSoilTemp, boundaryLayerConductance)
        if abs(timeOfDaySecs - (5.0 * 3600.0)) <= (min(timeOfDaySecs, 5.0 * 3600.0) * 0.0001):
            morningSoilTemp[0:0 + len(soilTemp)]=soilTemp
    minTempYesterday=weather_MinT
    maxTempYesterday=weather_MaxT
    return (soilTemp, thermalConductivity, minSoilTemp, newTemperature, morningSoilTemp, aveSoilTemp, maxSoilTemp, volSpecHeatSoil, thermalConductance, heatStorage, minTempYesterday, maxTempYesterday, boundaryLayerConductance, netRadiation, timeOfDaySecs, internalTimeStep, airTemperature)