import numpy
from math import *

def init_soiltemperature(float weather_MinT,
                         float weather_MaxT,
                         float weather_MeanT,
                         float weather_Tav,
                         float weather_Amp,
                         float weather_AirPressure,
                         float weather_Wind,
                         float weather_Latitude,
                         float weather_Radn,
                         int clock_Today_DayOfYear,
                         float microClimate_CanopyHeight,
                         float physical_Thickness[],
                         float physical_BD[],
                         float ps,
                         float physical_Rocks[],
                         float physical_ParticleSizeSand[],
                         float physical_ParticleSizeSilt[],
                         float physical_ParticleSizeClay[],
                         float organic_Carbon[],
                         float waterBalance_SW[],
                         float waterBalance_Eos,
                         float waterBalance_Eo,
                         float waterBalance_Es,
                         float waterBalance_Salb,
                         float pInitialValues[],
                         float DepthToConstantTemperature,
                         float timestep,
                         float latentHeatOfVapourisation,
                         float stefanBoltzmannConstant,
                         int airNode,
                         int surfaceNode,
                         int topsoilNode,
                         int numPhantomNodes,
                         float constantBoundaryLayerConductance,
                         int numIterationsForBoundaryLayerConductance,
                         float defaultTimeOfMaximumTemperature,
                         float defaultInstrumentHeight,
                         float bareSoilRoughness,
                         float nodeDepth[],
                         float thermCondPar1[],
                         float thermCondPar2[],
                         float thermCondPar3[],
                         float thermCondPar4[],
                         float pom,
                         float soilRoughnessHeight,
                         float nu,
                         str boundarLayerConductanceSource,
                         str netRadiationSource,
                         float MissingValue,
                         str soilConstituentNames[8]):
    cdef float InitialValues[]
    cdef bool doInitialisationStuff = False
    cdef float internalTimeStep = 0.0
    cdef float timeOfDaySecs = 0.0
    cdef int numNodes = 0
    cdef int numLayers = 0
    cdef float volSpecHeatSoil[]
    cdef float soilTemp[]
    cdef float morningSoilTemp[]
    cdef float heatStorage[]
    cdef float thermalConductance[]
    cdef float thermalConductivity[]
    cdef float boundaryLayerConductance = 0.0
    cdef float newTemperature[]
    cdef float airTemperature = 0.0
    cdef float maxTempYesterday = 0.0
    cdef float minTempYesterday = 0.0
    cdef float soilWater[]
    cdef float minSoilTemp[]
    cdef float maxSoilTemp[]
    cdef float aveSoilTemp[]
    cdef float aveSoilWater[]
    cdef float thickness[]
    cdef float bulkDensity[]
    cdef float rocks[]
    cdef float carbon[]
    cdef float sand[]
    cdef float silt[]
    cdef float clay[]
    cdef float instrumentHeight = 0.0
    cdef float netRadiation = 0.0
    cdef float canopyHeight = 0.0
    cdef float instrumHeight = 0.0
    InitialValues = None
    volSpecHeatSoil = None
    soilTemp = None
    morningSoilTemp = None
    heatStorage = None
    thermalConductance = None
    thermalConductivity = None
    newTemperature = None
    soilWater = None
    minSoilTemp = None
    maxSoilTemp = None
    aveSoilTemp = None
    aveSoilWater = None
    thickness = None
    bulkDensity = None
    rocks = None
    carbon = None
    sand = None
    silt = None
    clay = None
    doInitialisationStuff=True
    instrumentHeight=getIniVariables(instrumentHeight, instrumHeight, defaultInstrumentHeight)
    (heatStorage, minSoilTemp, bulkDensity, maxSoilTemp, nodeDepth, newTemperature, soilWater, thermalConductance, thermalConductivity, sand, carbon, thickness, rocks, clay, soilTemp, silt, volSpecHeatSoil, aveSoilTemp, morningSoilTemp, numNodes, numLayers)=getProfileVariables(heatStorage, minSoilTemp, bulkDensity, numNodes, physical_BD, maxSoilTemp, waterBalance_SW, organic_Carbon, physical_Rocks, nodeDepth, topsoilNode, newTemperature, surfaceNode, soilWater, thermalConductance, thermalConductivity, sand, carbon, thickness, numPhantomNodes, physical_ParticleSizeSand, rocks, clay, physical_ParticleSizeSilt, airNode, physical_ParticleSizeClay, soilTemp, numLayers, physical_Thickness, silt, volSpecHeatSoil, aveSoilTemp, morningSoilTemp, DepthToConstantTemperature, MissingValue)
    (newTemperature, soilTemp, thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1, soilRoughnessHeight)=readParam(bareSoilRoughness, newTemperature, soilRoughnessHeight, soilTemp, thermCondPar2, numLayers, bulkDensity, numNodes, thermCondPar3, thermCondPar4, clay, thermCondPar1, weather_Tav, clock_Today_DayOfYear, surfaceNode, weather_Amp, thickness, weather_Latitude)
    InitialValues=pInitialValues
    return  InitialValues, doInitialisationStuff, internalTimeStep, timeOfDaySecs, numNodes, numLayers, nodeDepth, thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4, volSpecHeatSoil, soilTemp, morningSoilTemp, heatStorage, thermalConductance, thermalConductivity, boundaryLayerConductance, newTemperature, airTemperature, maxTempYesterday, minTempYesterday, soilWater, minSoilTemp, maxSoilTemp, aveSoilTemp, aveSoilWater, thickness, bulkDensity, rocks, carbon, sand, silt, clay, soilRoughnessHeight, instrumentHeight, netRadiation, canopyHeight, instrumHeight

def model_soiltemperature(float weather_MinT,
                          float weather_MaxT,
                          float weather_MeanT,
                          float weather_Tav,
                          float weather_Amp,
                          float weather_AirPressure,
                          float weather_Wind,
                          float weather_Latitude,
                          float weather_Radn,
                          int clock_Today_DayOfYear,
                          float microClimate_CanopyHeight,
                          float physical_Thickness[],
                          float physical_BD[],
                          float ps,
                          float physical_Rocks[],
                          float physical_ParticleSizeSand[],
                          float physical_ParticleSizeSilt[],
                          float physical_ParticleSizeClay[],
                          float organic_Carbon[],
                          float waterBalance_SW[],
                          float waterBalance_Eos,
                          float waterBalance_Eo,
                          float waterBalance_Es,
                          float waterBalance_Salb,
                          float InitialValues[],
                          float pInitialValues[],
                          float DepthToConstantTemperature,
                          float timestep,
                          float latentHeatOfVapourisation,
                          float stefanBoltzmannConstant,
                          int airNode,
                          int surfaceNode,
                          int topsoilNode,
                          int numPhantomNodes,
                          float constantBoundaryLayerConductance,
                          int numIterationsForBoundaryLayerConductance,
                          float defaultTimeOfMaximumTemperature,
                          float defaultInstrumentHeight,
                          float bareSoilRoughness,
                          bool doInitialisationStuff,
                          float internalTimeStep,
                          float timeOfDaySecs,
                          int numNodes,
                          int numLayers,
                          float nodeDepth[],
                          float thermCondPar1[],
                          float thermCondPar2[],
                          float thermCondPar3[],
                          float thermCondPar4[],
                          float volSpecHeatSoil[],
                          float soilTemp[],
                          float morningSoilTemp[],
                          float heatStorage[],
                          float thermalConductance[],
                          float thermalConductivity[],
                          float boundaryLayerConductance,
                          float newTemperature[],
                          float airTemperature,
                          float maxTempYesterday,
                          float minTempYesterday,
                          float soilWater[],
                          float minSoilTemp[],
                          float maxSoilTemp[],
                          float aveSoilTemp[],
                          float aveSoilWater[],
                          float thickness[],
                          float bulkDensity[],
                          float rocks[],
                          float carbon[],
                          float sand[],
                          float pom,
                          float silt[],
                          float clay[],
                          float soilRoughnessHeight,
                          float instrumentHeight,
                          float netRadiation,
                          float canopyHeight,
                          float instrumHeight,
                          float nu,
                          str boundarLayerConductanceSource,
                          str netRadiationSource,
                          float MissingValue,
                          str soilConstituentNames[8]):
    """
    SoilTemperature
    Author: APSIM
    Reference: None
    Institution: APSIM Initiative
    ExtendedDescription:  Soil Temperature 
    ShortDescription: Heat flux and temperatures over the surface and soil profile (based on Campbell, 1985)
    """

    cdef int i 
    (soilWater, instrumentHeight, canopyHeight)=getOtherVariables(numLayers, numNodes, soilWater, instrumentHeight, soilRoughnessHeight, waterBalance_SW, microClimate_CanopyHeight, canopyHeight)
    if doInitialisationStuff:
        if ValuesInArray(InitialValues, MissingValue):
            soilTemp=array('f', [0.0]*(numNodes + 1 + 1))
            soilTemp[topsoilNode:topsoilNode + len(InitialValues)]=InitialValues[0:0 + len(InitialValues)]
        else:
            soilTemp=calcSoilTemperature(soilTemp, weather_Tav, clock_Today_DayOfYear, surfaceNode, numNodes, weather_Amp, thickness, weather_Latitude)
            InitialValues=array('f', [0.0]*(numLayers))
            InitialValues[0:0 + numLayers]=soilTemp[topsoilNode:topsoilNode + numLayers]
        soilTemp[airNode]=weather_MeanT
        soilTemp[surfaceNode]=calcSurfaceTemperature(weather_MeanT, weather_MaxT, waterBalance_Salb, weather_Radn)
        for i in range(numNodes + 1 , len(soilTemp) , 1):
            soilTemp[i]=weather_Tav
        newTemperature[0:0 + len(soilTemp)]=soilTemp
        maxTempYesterday=weather_MaxT
        minTempYesterday=weather_MinT
        doInitialisationStuff=False
    (minSoilTemp, maxSoilTemp, soilTemp, newTemperature, thermalConductivity, aveSoilTemp, morningSoilTemp, volSpecHeatSoil, heatStorage, thermalConductance, timeOfDaySecs, netRadiation, airTemperature, internalTimeStep, minTempYesterday, boundaryLayerConductance, maxTempYesterday)=doProcess(timeOfDaySecs, netRadiation, minSoilTemp, maxSoilTemp, numIterationsForBoundaryLayerConductance, timestep, boundaryLayerConductance, maxTempYesterday, airNode, soilTemp, airTemperature, newTemperature, weather_MaxT, internalTimeStep, boundarLayerConductanceSource, thermalConductivity, minTempYesterday, aveSoilTemp, morningSoilTemp, weather_MeanT, constantBoundaryLayerConductance, weather_MinT, clock_Today_DayOfYear, weather_Radn, weather_Latitude, soilConstituentNames, numNodes, volSpecHeatSoil, soilWater, nodeDepth, thickness, surfaceNode, MissingValue, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay, defaultTimeOfMaximumTemperature, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, stefanBoltzmannConstant, weather_AirPressure, weather_Wind, instrumentHeight, canopyHeight, heatStorage, netRadiationSource, latentHeatOfVapourisation, waterBalance_Es, thermalConductance, nu)
    return  heatStorage, instrumentHeight, canopyHeight, minSoilTemp, maxSoilTemp, aveSoilTemp, volSpecHeatSoil, soilTemp, morningSoilTemp, newTemperature, thermalConductivity, thermalConductance, boundaryLayerConductance, soilWater, doInitialisationStuff, maxTempYesterday, minTempYesterday, airTemperature, internalTimeStep, timeOfDaySecs, netRadiation, InitialValues



def getIniVariables(float instrumentHeight,
         float instrumHeight,
         float defaultInstrumentHeight):
    if instrumHeight > 0.00001:
        instrumentHeight=instrumHeight
    else:
        instrumentHeight=defaultInstrumentHeight
    return instrumentHeight

def getProfileVariables(floatarray heatStorage,
         floatarray minSoilTemp,
         floatarray bulkDensity,
         int numNodes,
         floatarray physical_BD,
         floatarray maxSoilTemp,
         floatarray waterBalance_SW,
         floatarray organic_Carbon,
         floatarray physical_Rocks,
         floatarray nodeDepth,
         int topsoilNode,
         floatarray newTemperature,
         int surfaceNode,
         floatarray soilWater,
         floatarray thermalConductance,
         floatarray thermalConductivity,
         floatarray sand,
         floatarray carbon,
         floatarray thickness,
         int numPhantomNodes,
         floatarray physical_ParticleSizeSand,
         floatarray rocks,
         floatarray clay,
         floatarray physical_ParticleSizeSilt,
         int airNode,
         floatarray physical_ParticleSizeClay,
         floatarray soilTemp,
         int numLayers,
         floatarray physical_Thickness,
         floatarray silt,
         floatarray volSpecHeatSoil,
         floatarray aveSoilTemp,
         floatarray morningSoilTemp,
         float DepthToConstantTemperature,
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
            soilWater[layer]=Divide(waterBalance_SW[(layer - 1)] * thickness[(layer - 1)], thickness[layer], float(0))
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
    return (heatStorage, minSoilTemp, bulkDensity, maxSoilTemp, nodeDepth, newTemperature, soilWater, thermalConductance, thermalConductivity, sand, carbon, thickness, rocks, clay, soilTemp, silt, volSpecHeatSoil, aveSoilTemp, morningSoilTemp, numNodes, numLayers)

def doThermalConductivityCoeffs(floatarray thermCondPar2,
         int numLayers,
         floatarray bulkDensity,
         int numNodes,
         floatarray thermCondPar3,
         floatarray thermCondPar4,
         floatarray clay,
         floatarray thermCondPar1):
    cdef int layer 
    cdef float oldGC1[]
    cdef float oldGC2[]
    cdef float oldGC3[]
    cdef float oldGC4[]
    cdef int element 
    oldGC1=thermCondPar1
    thermCondPar1=array('f', [0.0]*(numNodes + 1))
    if oldGC1 is not None:
        thermCondPar1[0:min(numNodes + 1, len(oldGC1))]=oldGC1[0:min(numNodes + 1, len(oldGC1))]
    oldGC2=thermCondPar2
    thermCondPar2=array('f', [0.0]*(numNodes + 1))
    if oldGC2 is not None:
        thermCondPar2[0:min(numNodes + 1, len(oldGC2))]=oldGC2[0:min(numNodes + 1, len(oldGC2))]
    oldGC3=thermCondPar3
    thermCondPar3=array('f', [0.0]*(numNodes + 1))
    if oldGC3 is not None:
        thermCondPar3[0:min(numNodes + 1, len(oldGC3))]=oldGC3[0:min(numNodes + 1, len(oldGC3))]
    oldGC4=thermCondPar4
    thermCondPar4=array('f', [0.0]*(numNodes + 1))
    if oldGC4 is not None:
        thermCondPar4[0:min(numNodes + 1, len(oldGC4))]=oldGC4[0:min(numNodes + 1, len(oldGC4))]
    for layer in range(1 , numLayers + 1 + 1 , 1):
        element=layer
        thermCondPar1[element]=0.65 - (0.78 * bulkDensity[layer]) + (0.6 * pow(bulkDensity[layer], 2))
        thermCondPar2[element]=1.06 * bulkDensity[layer]
        thermCondPar3[element]=1.0 + Divide(2.6, sqrt(clay[layer]), float(0))
        thermCondPar4[element]=0.03 + (0.1 * pow(bulkDensity[layer], 2))
    return (thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1)


def readParam(float bareSoilRoughness,
         floatarray newTemperature,
         float soilRoughnessHeight,
         floatarray soilTemp,
         floatarray thermCondPar2,
         int numLayers,
         floatarray bulkDensity,
         int numNodes,
         floatarray thermCondPar3,
         floatarray thermCondPar4,
         floatarray clay,
         floatarray thermCondPar1,
         float weather_Tav,
         int clock_Today_DayOfYear,
         int surfaceNode,
         float weather_Amp,
         floatarray thickness,
         float weather_Latitude):
    (thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1)=doThermalConductivityCoeffs(thermCondPar2, numLayers, bulkDensity, numNodes, thermCondPar3, thermCondPar4, clay, thermCondPar1)
    soilTemp=calcSoilTemperature(soilTemp, weather_Tav, clock_Today_DayOfYear, surfaceNode, numNodes, weather_Amp, thickness, weather_Latitude)
    newTemperature[0:0 + len(soilTemp)]=soilTemp
    soilRoughnessHeight=bareSoilRoughness
    return (newTemperature, soilTemp, thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1, soilRoughnessHeight)

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

def volumetricFractionOrganicMatter(int layer,
         floatarray carbon,
         floatarray bulkDensity,
         float pom):
    return carbon[layer] / 100.0 * 2.5 * bulkDensity[layer] / pom


def volumetricFractionRocks(int layer,
         floatarray rocks):
    return rocks[layer] / 100.0


def volumetricFractionIce(int layer):
    return 0.0


def volumetricFractionWater(int layer,
         floatarray soilWater,
         floatarray carbon,
         floatarray bulkDensity,
         float pom):
    return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom)) * soilWater[layer]


def volumetricFractionClay(int layer,
         floatarray bulkDensity,
         float ps,
         floatarray clay,
         floatarray carbon,
         float pom,
         floatarray rocks):
    return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * clay[layer] / 100.0 * bulkDensity[layer] / ps


def volumetricFractionSilt(int layer,
         floatarray bulkDensity,
         floatarray silt,
         float ps,
         floatarray carbon,
         float pom,
         floatarray rocks):
    return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * silt[layer] / 100.0 * bulkDensity[layer] / ps


def volumetricFractionSand(int layer,
         floatarray bulkDensity,
         floatarray sand,
         float ps,
         floatarray carbon,
         float pom,
         floatarray rocks):
    return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * sand[layer] / 100.0 * bulkDensity[layer] / ps


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
         floatarray carbon,
         floatarray bulkDensity,
         float pom,
         floatarray sand,
         float ps,
         floatarray silt,
         floatarray clay,
         floatarray soilWater):
    return 1.0 - volumetricFractionRocks(layer, rocks) - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks) - volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks) - volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks) - volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) - volumetricFractionIce(layer)


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
         floatarray nodeDepth,
         int numNodes,
         floatarray thickness,
         int surfaceNode,
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
        nodeArray[node]=Divide(layerArray[layer] * d1, dSum, float(0)) + Divide(layerArray[(layer + 1)] * d2, dSum, float(0))
    return nodeArray


def ThermalConductance(str name,
         int layer,
         floatarray rocks,
         floatarray bulkDensity,
         floatarray sand,
         float ps,
         floatarray carbon,
         float pom,
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
        result=pow(thermalConductanceRocks, volumetricFractionRocks(layer, rocks)) * pow(thermalConductanceSand, volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks)) + pow(thermalConductanceSilt, volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + pow(thermalConductanceClay, volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks))
    result=volumetricSpecificHeat(name, layer)
    return result


def shapeFactor(str name,
         int layer,
         floatarray soilWater,
         floatarray carbon,
         floatarray bulkDensity,
         float pom,
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
        result=0.333 - (0.333 * volumetricFractionIce(layer) / (volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater)))
        return result
    elif name == "Air":
        result=0.333 - (0.333 * volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater) / (volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater)))
        return result
    elif name == "Minerals":
        result=shapeFactorRocks * volumetricFractionRocks(layer, rocks) + (shapeFactorSand * volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks)) + (shapeFactorSilt * volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + (shapeFactorClay * volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks))
    result=volumetricSpecificHeat(name, layer)
    return result


def doUpdate(int numInterationsPerDay,
         float timeOfDaySecs,
         float boundaryLayerConductance,
         floatarray minSoilTemp,
         int airNode,
         floatarray soilTemp,
         floatarray newTemperature,
         int numNodes,
         int surfaceNode,
         float internalTimeStep,
         floatarray maxSoilTemp,
         floatarray aveSoilTemp,
         floatarray thermalConductivity):
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
        aveSoilTemp[node]+=Divide(soilTemp[node], float(numInterationsPerDay), float(0))
    boundaryLayerConductance+=Divide(thermalConductivity[airNode], float(numInterationsPerDay), float(0))
    return (minSoilTemp, soilTemp, maxSoilTemp, aveSoilTemp, boundaryLayerConductance)


def doThomas(floatarray newTemps,
         float netRadiation,
         floatarray heatStorage,
         float waterBalance_Eos,
         int numNodes,
         float timestep,
         str netRadiationSource,
         float latentHeatOfVapourisation,
         floatarray nodeDepth,
         float waterBalance_Es,
         int airNode,
         floatarray soilTemp,
         int surfaceNode,
         float internalTimeStep,
         floatarray thermalConductance,
         floatarray thermalConductivity,
         float nu,
         floatarray volSpecHeatSoil):
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
        heatStorage[node]=Divide(volSpecHeatSoil[node] * volumeOfSoilAtNode, internalTimeStep, float(0))
        elementLength=nodeDepth[node + 1] - nodeDepth[node]
        thermalConductance[node]=Divide(thermalConductivity[node], elementLength, float(0))
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
        radnNet=Divide(netRadiation * 1000000.0, internalTimeStep, float(0))
    elif netRadiationSource == "eos":
        radnNet=Divide(waterBalance_Eos * latentHeatOfVapourisation, timestep, float(0))
    latentHeatFlux=Divide(waterBalance_Es * latentHeatOfVapourisation, timestep, float(0))
    soilSurfaceHeatFlux=sensibleHeatFlux + radnNet - latentHeatFlux
    d[surfaceNode]+=soilSurfaceHeatFlux
    d[numNodes]+=nu * thermalConductance[numNodes] * newTemps[(numNodes + 1)]
    for node in range(surfaceNode , numNodes - 1 + 1 , 1):
        c[node]=Divide(c[node], b[node], float(0))
        d[node]=Divide(d[node], b[node], float(0))
        b[node + 1]-=a[(node + 1)] * c[node]
        d[node + 1]-=a[(node + 1)] * d[node]
    newTemps[numNodes]=Divide(d[numNodes], b[numNodes], float(0))
    for node in range(numNodes - 1 , surfaceNode - 1 , -1):
        newTemps[node]=d[node] - (c[node] * newTemps[(node + 1)])
    return (newTemps, heatStorage, thermalConductance)


def getBoundaryLayerConductance(floatarray TNew_zb,
         float weather_AirPressure,
         float stefanBoltzmannConstant,
         float waterBalance_Eos,
         float weather_Wind,
         float airTemperature,
         int surfaceNode,
         float waterBalance_Eo,
         float instrumentHeight,
         float canopyHeight):
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
        frictionVelocity=Divide(weather_Wind * vonKarmanConstant, log(Divide(instrumentHeight - d + roughnessFactorMomentum, roughnessFactorMomentum, float(0))) + stabilityCorrectionMomentum, float(0))
        boundaryLayerCond=Divide(SpecificHeatAir * vonKarmanConstant * frictionVelocity, log(Divide(instrumentHeight - d + roughnessFactorHeat, roughnessFactorHeat, float(0))) + stabilityCorrectionHeat, float(0))
        boundaryLayerCond+=radiativeConductance
        heatFluxDensity=boundaryLayerCond * (surfaceTemperature - airTemperature)
        stabilityParammeter=Divide(-vonKarmanConstant * instrumentHeight * gravitationalConstant * heatFluxDensity, SpecificHeatAir * kelvinT(airTemperature) * pow(frictionVelocity, 3.0), float(0))
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
         float waterBalance_Eo,
         float waterBalance_Eos,
         float waterBalance_Salb,
         floatarray soilTemp,
         float airTemperature,
         int surfaceNode,
         float internalTimeStep,
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
    PenetrationConstant=Divide(max(0.1, waterBalance_Eos), max(0.1, waterBalance_Eo), float(0))
    lwRinSoil=longWaveRadn(emissivityAtmos, airTemperature, stefanBoltzmannConstant) * PenetrationConstant * w2MJ
    lwRoutSoil=longWaveRadn(surfaceEmissivity, soilTemp[surfaceNode], stefanBoltzmannConstant) * PenetrationConstant * w2MJ
    lwRnetSoil=lwRinSoil - lwRoutSoil
    swRin=solarRadn
    swRout=waterBalance_Salb * solarRadn
    swRnetSoil=(swRin - swRout) * PenetrationConstant
    return swRnetSoil + lwRnetSoil


def interpolateTemperature(float timeHours,
         float minTempYesterday,
         float maxTempYesterday,
         float weather_MeanT,
         float weather_MaxT,
         float weather_MinT,
         float defaultTimeOfMaximumTemperature):
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


def doThermalConductivity(strarray soilConstituentNames,
         int numNodes,
         floatarray soilWater,
         floatarray thermalConductivity,
         floatarray carbon,
         floatarray bulkDensity,
         float pom,
         floatarray rocks,
         floatarray sand,
         float ps,
         floatarray silt,
         floatarray clay,
         floatarray nodeDepth,
         floatarray thickness,
         int surfaceNode,
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
            shapeFactorConstituent=shapeFactor(constituentName, node, soilWater, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay)
            thermalConductanceConstituent=ThermalConductance(constituentName, node, rocks, bulkDensity, sand, ps, carbon, pom, silt, clay)
            thermalConductanceWater=ThermalConductance("Water", node, rocks, bulkDensity, sand, ps, carbon, pom, silt, clay)
            k=2.0 / 3.0 * pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0))), -1) + (1.0 / 3.0 * pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0) * (1 - (2 * shapeFactorConstituent)))), -1))
            numerator+=thermalConductanceConstituent * soilWater[node] * k
            denominator+=soilWater[node] * k
        thermCondLayers[node]=numerator / denominator
    thermalConductivity=mapLayer2Node(thermCondLayers, thermalConductivity, nodeDepth, numNodes, thickness, surfaceNode, MissingValue)
    return thermalConductivity


def doVolumetricSpecificHeat(strarray soilConstituentNames,
         int numNodes,
         floatarray volSpecHeatSoil,
         floatarray soilWater,
         floatarray nodeDepth,
         floatarray thickness,
         int surfaceNode,
         float MissingValue):
    cdef int node 
    cdef str constituentName 
    cdef float volspecHeatSoil_[numNodes + 1]
    for node in range(1 , numNodes + 1 , 1):
        volspecHeatSoil_[node]=float(0)
        for constituentName in soilConstituentNames:
            if constituentName not in ["Minerals"]:
                volspecHeatSoil_[node]+=volumetricSpecificHeat(constituentName, node) * 1000000.0 * soilWater[node]
    volSpecHeatSoil=mapLayer2Node(volspecHeatSoil_, volSpecHeatSoil, nodeDepth, numNodes, thickness, surfaceNode, MissingValue)
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
         float weather_MinT,
         int clock_Today_DayOfYear,
         float weather_Radn,
         float weather_Latitude):
    cdef int timestepNumber 
    cdef float TSTEPS2RAD 
    cdef float solarConstant 
    cdef float solarDeclination 
    cdef float cD 
    cdef float m1[ITERATIONSperDAY + 1]
    cdef float m1Tot 
    cdef float psr 
    cdef float fr 
    TSTEPS2RAD=Divide(2.0 * pi, float(ITERATIONSperDAY), float(0))
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
    fr=Divide(max(weather_Radn, 0.1), psr, float(0))
    cloudFr=2.33 - (3.33 * fr)
    cloudFr=min(max(cloudFr, 0.0), 1.0)
    for timestepNumber in range(1 , ITERATIONSperDAY + 1 , 1):
        solarRadn[timestepNumber]=max(weather_Radn, 0.1) * Divide(m1[timestepNumber], m1Tot, float(0))
    cva=exp((31.3716 - (6014.79 / kelvinT(weather_MinT)) - (0.00792495 * kelvinT(weather_MinT)))) / kelvinT(weather_MinT)
    return (solarRadn, cloudFr, cva)


def doProcess(float timeOfDaySecs,
         float netRadiation,
         floatarray minSoilTemp,
         floatarray maxSoilTemp,
         int numIterationsForBoundaryLayerConductance,
         float timestep,
         float boundaryLayerConductance,
         float maxTempYesterday,
         int airNode,
         floatarray soilTemp,
         float airTemperature,
         floatarray newTemperature,
         float weather_MaxT,
         float internalTimeStep,
         str boundarLayerConductanceSource,
         floatarray thermalConductivity,
         float minTempYesterday,
         floatarray aveSoilTemp,
         floatarray morningSoilTemp,
         float weather_MeanT,
         float constantBoundaryLayerConductance,
         float weather_MinT,
         int clock_Today_DayOfYear,
         float weather_Radn,
         float weather_Latitude,
         strarray soilConstituentNames,
         int numNodes,
         floatarray volSpecHeatSoil,
         floatarray soilWater,
         floatarray nodeDepth,
         floatarray thickness,
         int surfaceNode,
         float MissingValue,
         floatarray carbon,
         floatarray bulkDensity,
         float pom,
         floatarray rocks,
         floatarray sand,
         float ps,
         floatarray silt,
         floatarray clay,
         float defaultTimeOfMaximumTemperature,
         float waterBalance_Eo,
         float waterBalance_Eos,
         float waterBalance_Salb,
         float stefanBoltzmannConstant,
         float weather_AirPressure,
         float weather_Wind,
         float instrumentHeight,
         float canopyHeight,
         floatarray heatStorage,
         str netRadiationSource,
         float latentHeatOfVapourisation,
         float waterBalance_Es,
         floatarray thermalConductance,
         float nu):
    cdef int timeStepIteration 
    cdef int iteration 
    cdef int interactionsPerDay 
    cdef float cva 
    cdef float cloudFr 
    cdef float solarRadn[49]
    interactionsPerDay=48
    cva=0.0
    cloudFr=0.0
    (solarRadn, cloudFr, cva)=doNetRadiation(solarRadn, cloudFr, cva, interactionsPerDay, weather_MinT, clock_Today_DayOfYear, weather_Radn, weather_Latitude)
    minSoilTemp=Zero(minSoilTemp)
    maxSoilTemp=Zero(maxSoilTemp)
    aveSoilTemp=Zero(aveSoilTemp)
    boundaryLayerConductance=0.0
    internalTimeStep=round(timestep / interactionsPerDay)
    volSpecHeatSoil=doVolumetricSpecificHeat(soilConstituentNames, numNodes, volSpecHeatSoil, soilWater, nodeDepth, thickness, surfaceNode, MissingValue)
    thermalConductivity=doThermalConductivity(soilConstituentNames, numNodes, soilWater, thermalConductivity, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay, nodeDepth, thickness, surfaceNode, MissingValue)
    for timeStepIteration in range(1 , interactionsPerDay + 1 , 1):
        timeOfDaySecs=internalTimeStep * float(timeStepIteration)
        if timestep < (24.0 * 60.0 * 60.0):
            airTemperature=weather_MeanT
        else:
            airTemperature=interpolateTemperature(timeOfDaySecs / 3600.0, minTempYesterday, maxTempYesterday, weather_MeanT, weather_MaxT, weather_MinT, defaultTimeOfMaximumTemperature)
        newTemperature[airNode]=airTemperature
        netRadiation=interpolateNetRadiation(solarRadn[timeStepIteration], cloudFr, cva, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, soilTemp, airTemperature, surfaceNode, internalTimeStep, stefanBoltzmannConstant)
        if boundarLayerConductanceSource == "constant":
            thermalConductivity[airNode]=constantBoundaryLayerConductance
        elif boundarLayerConductanceSource == "calc":
            (thermalConductivity[airNode], newTemperature)=getBoundaryLayerConductance(newTemperature, weather_AirPressure, stefanBoltzmannConstant, waterBalance_Eos, weather_Wind, airTemperature, surfaceNode, waterBalance_Eo, instrumentHeight, canopyHeight)
            for iteration in range(1 , numIterationsForBoundaryLayerConductance + 1 , 1):
                (newTemperature, heatStorage, thermalConductance)=doThomas(newTemperature, netRadiation, heatStorage, waterBalance_Eos, numNodes, timestep, netRadiationSource, latentHeatOfVapourisation, nodeDepth, waterBalance_Es, airNode, soilTemp, surfaceNode, internalTimeStep, thermalConductance, thermalConductivity, nu, volSpecHeatSoil)
                (thermalConductivity[airNode], newTemperature)=getBoundaryLayerConductance(newTemperature, weather_AirPressure, stefanBoltzmannConstant, waterBalance_Eos, weather_Wind, airTemperature, surfaceNode, waterBalance_Eo, instrumentHeight, canopyHeight)
        (newTemperature, heatStorage, thermalConductance)=doThomas(newTemperature, netRadiation, heatStorage, waterBalance_Eos, numNodes, timestep, netRadiationSource, latentHeatOfVapourisation, nodeDepth, waterBalance_Es, airNode, soilTemp, surfaceNode, internalTimeStep, thermalConductance, thermalConductivity, nu, volSpecHeatSoil)
        (minSoilTemp, soilTemp, maxSoilTemp, aveSoilTemp, boundaryLayerConductance)=doUpdate(interactionsPerDay, timeOfDaySecs, boundaryLayerConductance, minSoilTemp, airNode, soilTemp, newTemperature, numNodes, surfaceNode, internalTimeStep, maxSoilTemp, aveSoilTemp, thermalConductivity)
        if abs(timeOfDaySecs - (5.0 * 3600.0)) <= (min(timeOfDaySecs, 5.0 * 3600.0) * 0.0001):
            morningSoilTemp[0:0 + len(soilTemp)]=soilTemp
    minTempYesterday=weather_MinT
    maxTempYesterday=weather_MaxT
    return (minSoilTemp, maxSoilTemp, soilTemp, newTemperature, thermalConductivity, aveSoilTemp, morningSoilTemp, volSpecHeatSoil, heatStorage, thermalConductance, timeOfDaySecs, netRadiation, airTemperature, internalTimeStep, minTempYesterday, boundaryLayerConductance, maxTempYesterday)

def ToCumThickness(floatarray Thickness):
    cdef int Layer 
    cdef float CumThickness[len(Thickness)]
    if len(Thickness) > 0:
        CumThickness[0]=Thickness[0]
        for Layer in range(1 , len(Thickness) , 1):
            CumThickness[Layer]=Thickness[Layer] + CumThickness[Layer - 1]
    return CumThickness


def calcSoilTemperature(floatarray soilTempIO,
         float weather_Tav,
         int clock_Today_DayOfYear,
         int surfaceNode,
         int numNodes,
         float weather_Amp,
         floatarray thickness,
         float weather_Latitude):
    cdef int nodes 
    cdef float cumulativeDepth[]
    cdef float w 
    cdef float dh 
    cdef float zd 
    cdef float offset 
    cdef float soilTemp[numNodes + 1 + 1]
    cumulativeDepth=ToCumThickness(thickness)
    w=2 * pi / (365.25 * 24 * 3600)
    dh=0.6
    zd=sqrt(2 * dh / w)
    offset=0.25
    if weather_Latitude > 0.0:
        offset=-0.25
    for nodes in range(1 , numNodes + 1 , 1):
        soilTemp[nodes]=weather_Tav + (weather_Amp * exp(-1 * cumulativeDepth[nodes] / zd) * sin(((clock_Today_DayOfYear / 365.0 + offset) * 2.0 * pi - (cumulativeDepth[nodes] / zd))))
    soilTempIO[surfaceNode:surfaceNode + numNodes]=soilTemp[0:0 + numNodes]
    return soilTempIO

def calcSurfaceTemperature(float weather_MeanT,
         float weather_MaxT,
         float waterBalance_Salb,
         float weather_Radn):
    cdef float surfaceT 
    surfaceT=(1.0 - waterBalance_Salb) * (weather_MeanT + ((weather_MaxT - weather_MeanT) * sqrt(max(weather_Radn, 0.1) * 23.8846 / 800.0))) + (waterBalance_Salb * weather_MeanT)
    return surfaceT

def ValuesInArray(floatarray Values,
         float MissingValue):
    cdef float Value 
    if Values is not None:
        for Value in Values:
            if Value != MissingValue and not isnan(Value):
                return True
    return False

