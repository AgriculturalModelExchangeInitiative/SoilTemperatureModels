import numpy
from math import *

def init_campbell(int NLAYR,
                  float THICK[NLAYR],
                  float DEPTH[NLAYR],
                  float CONSTANT_TEMPdepth,
                  float BD[NLAYR],
                  float T2M,
                  float TMAX,
                  float TMIN,
                  float TAV,
                  float TAMP,
                  float XLAT,
                  float CLAY[NLAYR],
                  float SW[NLAYR],
                  int DOY,
                  float canopyHeight,
                  float SALB,
                  float SRAD,
                  float ESP,
                  float ES,
                  float EOAD,
                  float instrumentHeight,
                  str boundaryLayerConductanceSource,
                  str netRadiationSource,
                  float windSpeed):
    cdef float airPressure = 1010.0
    cdef float soilTemp[NLAYR]
    cdef float newTemperature[NLAYR]
    cdef float minSoilTemp[NLAYR]
    cdef float maxSoilTemp[NLAYR]
    cdef float aveSoilTemp[NLAYR]
    cdef float morningSoilTemp[NLAYR]
    cdef float thermalCondPar1[NLAYR]
    cdef float thermalCondPar2[NLAYR]
    cdef float thermalCondPar3[NLAYR]
    cdef float thermalCondPar4[NLAYR]
    cdef float thermalConductivity[NLAYR]
    cdef float thermalConductance[NLAYR]
    cdef float heatStorage[NLAYR]
    cdef float volSpecHeatSoil[NLAYR]
    cdef float maxTempYesterday
    cdef float minTempYesterday
    cdef float SLCARB[NLAYR]
    cdef float SLROCK[NLAYR]
    cdef float SLSILT[NLAYR]
    cdef float SLSAND[NLAYR]
    cdef float _boundaryLayerConductance
    soilTemp = array('f', [0.0]*NLAYR)
    newTemperature = array('f', [0.0]*NLAYR)
    minSoilTemp = array('f', [0.0]*NLAYR)
    maxSoilTemp = array('f', [0.0]*NLAYR)
    aveSoilTemp = array('f', [0.0]*NLAYR)
    morningSoilTemp = array('f', [0.0]*NLAYR)
    thermalCondPar1 = array('f', [0.0]*NLAYR)
    thermalCondPar2 = array('f', [0.0]*NLAYR)
    thermalCondPar3 = array('f', [0.0]*NLAYR)
    thermalCondPar4 = array('f', [0.0]*NLAYR)
    thermalConductivity = array('f', [0.0]*NLAYR)
    thermalConductance = array('f', [0.0]*NLAYR)
    heatStorage = array('f', [0.0]*NLAYR)
    volSpecHeatSoil = array('f', [0.0]*NLAYR)
    maxTempYesterday = 0.0
    minTempYesterday = 0.0
    SLCARB = array('f', [0.0]*NLAYR)
    SLROCK = array('f', [0.0]*NLAYR)
    SLSILT = array('f', [0.0]*NLAYR)
    SLSAND = array('f', [0.0]*NLAYR)
    _boundaryLayerConductance = 0.0
    cdef float heatCapacity[]
    cdef float thickness[]
    cdef float depth[]
    cdef float bulkDensity[]
    cdef float soilWater[]
    cdef float clay[]
    cdef float carbon[]
    cdef float rocks[]
    cdef float sand[]
    cdef float silt[]
    cdef float soilRoughnessHeight 
    cdef float defaultInstrumentHeight 
    cdef float AltitudeMetres 
    cdef int NUM_PHANTOM_NODES 
    cdef int AIRnode 
    cdef int SURFACEnode 
    cdef int TOPSOILnode 
    cdef float sumThickness 
    cdef float BelowProfileDepth 
    cdef float thicknessForPhantomNodes 
    cdef float ave_temp 
    cdef int i 
    cdef int numNodes 
    cdef int firstPhantomNode 
    cdef int layer 
    cdef int node 
    cdef float surfaceT 
    soilRoughnessHeight=57.0
    defaultInstrumentHeight=1.2
    AltitudeMetres=18.0
    NUM_PHANTOM_NODES=5
    AIRnode=0
    SURFACEnode=1
    TOPSOILnode=2
    if instrumentHeight > 0.00001:
        instrumentHeight=instrumentHeight
    else:
        instrumentHeight=defaultInstrumentHeight
    numNodes=NLAYR + NUM_PHANTOM_NODES
    thickness=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    thickness[1:len(THICK)]=THICK
    sumThickness=0.0
    for i in range(1 , NLAYR + 1 , 1):
        sumThickness=sumThickness + thickness[i]
    BelowProfileDepth=max(CONSTANT_TEMPdepth - sumThickness, 1000.0)
    thicknessForPhantomNodes=BelowProfileDepth * 2.0 / NUM_PHANTOM_NODES
    firstPhantomNode=NLAYR
    for i in range(firstPhantomNode , firstPhantomNode + NUM_PHANTOM_NODES , 1):
        thickness[i]=thicknessForPhantomNodes
    depth=[0.0] * (numNodes + 1 + 1)
    depth[AIRnode]=0.0
    depth[SURFACEnode]=0.0
    depth[TOPSOILnode]=0.5 * thickness[1] / 1000.0
    for node in range(TOPSOILnode , numNodes + 1 , 1):
        sumThickness=0.0
        for i in range(1 , node , 1):
            sumThickness=sumThickness + thickness[i]
        depth[node + 1]=(sumThickness + (0.5 * thickness[node])) / 1000.0
    bulkDensity=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    bulkDensity[:min(NLAYR + 1 + NUM_PHANTOM_NODES, len(BD))]=BD
    for layer in range(1 , NLAYR + 1 , 1):
        bulkDensity[layer]=BD[layer - 1]
    bulkDensity[numNodes]=bulkDensity[NLAYR]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
        bulkDensity[layer]=bulkDensity[NLAYR]
    soilWater=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    soilWater[:min(NLAYR + 1 + NUM_PHANTOM_NODES, len(SW))]=SW
    for layer in range(1 , NLAYR + 1 , 1):
        soilWater[layer]=SW[layer - 1]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
        soilWater[layer]=soilWater[NLAYR]
    carbon=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1 , NLAYR + 1 , 1):
        carbon[layer]=SLCARB[layer - 1]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
        carbon[layer]=carbon[NLAYR]
    rocks=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1 , NLAYR + 1 , 1):
        rocks[layer]=SLROCK[layer - 1]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
        rocks[layer]=rocks[NLAYR]
    sand=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1 , NLAYR + 1 , 1):
        sand[layer]=SLSAND[layer - 1]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
        sand[layer]=sand[NLAYR]
    silt=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1 , NLAYR + 1 , 1):
        silt[layer]=SLSILT[layer - 1]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
        silt[layer]=silt[NLAYR]
    clay=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1 , NLAYR + 1 , 1):
        clay[layer]=CLAY[layer - 1]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
        clay[layer]=clay[NLAYR]
    maxSoilTemp=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    minSoilTemp=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    aveSoilTemp=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    volSpecHeatSoil=[0.0] * (numNodes + 1)
    soilTemp=[0.0] * (numNodes + 1 + 1)
    morningSoilTemp=[0.0] * (numNodes + 1 + 1)
    newTemperature=[0.0] * (numNodes + 1 + 1)
    thermalConductivity=[0.0] * (numNodes + 1)
    heatStorage=[0.0] * (numNodes + 1)
    thermalConductance=[0.0] * (numNodes + 1 + 1)
    (thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4)=doThermalConductivityCoeffs(NLAYR, numNodes, bulkDensity, clay)
    newTemperature=CalcSoilTemp(soilTemp, thickness, TAV, TAMP, DOY, XLAT, numNodes)
    soilWater[numNodes]=soilWater[NLAYR]
    instrumentHeight=max(instrumentHeight, canopyHeight + 0.5)
    soilTemp=CalcSoilTemp(soilTemp, thickness, TAV, TAMP, DOY, XLAT, numNodes)
    soilTemp[AIRnode]=T2M
    surfaceT=(1.0 - SALB) * (T2M + ((TMAX - T2M) * sqrt(max(SRAD, 0.1) * 23.8846 / 800.0))) + (SALB * T2M)
    soilTemp[SURFACEnode]=surfaceT
    for i in range(numNodes + 1 , len(soilTemp) , 1):
        soilTemp[i]=TAV
    for i in range(0 , len(soilTemp) , 1):
        newTemperature[i]=soilTemp[i]
    maxTempYesterday=TMAX
    minTempYesterday=TMIN
    return  airPressure, soilTemp, newTemperature, minSoilTemp, maxSoilTemp, aveSoilTemp, morningSoilTemp, thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, thermalConductivity, thermalConductance, heatStorage, volSpecHeatSoil, maxTempYesterday, minTempYesterday, SLCARB, SLROCK, SLSILT, SLSAND, _boundaryLayerConductance

def model_campbell(int NLAYR,
                   float THICK[NLAYR],
                   float DEPTH[NLAYR],
                   float CONSTANT_TEMPdepth,
                   float BD[NLAYR],
                   float T2M,
                   float TMAX,
                   float TMIN,
                   float TAV,
                   float TAMP,
                   float XLAT,
                   float CLAY[NLAYR],
                   float SW[NLAYR],
                   int DOY,
                   float airPressure,
                   float canopyHeight,
                   float SALB,
                   float SRAD,
                   float ESP,
                   float ES,
                   float EOAD,
                   float soilTemp[NLAYR],
                   float newTemperature[NLAYR],
                   float minSoilTemp[NLAYR],
                   float maxSoilTemp[NLAYR],
                   float aveSoilTemp[NLAYR],
                   float morningSoilTemp[NLAYR],
                   float thermalCondPar1[NLAYR],
                   float thermalCondPar2[NLAYR],
                   float thermalCondPar3[NLAYR],
                   float thermalCondPar4[NLAYR],
                   float thermalConductivity[NLAYR],
                   float thermalConductance[NLAYR],
                   float heatStorage[NLAYR],
                   float volSpecHeatSoil[NLAYR],
                   float maxTempYesterday,
                   float minTempYesterday,
                   float instrumentHeight,
                   str boundaryLayerConductanceSource,
                   str netRadiationSource,
                   float windSpeed,
                   float SLCARB[NLAYR],
                   float SLROCK[NLAYR],
                   float SLSILT[NLAYR],
                   float SLSAND[NLAYR],
                   float _boundaryLayerConductance):
    """
    SoilTemperature model from Campbell implemented in APSIM
    Author: None
    Reference: Campbell model (TODO)
    Institution: CIRAD and INRAE
    ExtendedDescription: TODO
    ShortDescription: TODO
    """

    cdef int AIRnode 
    cdef int SURFACEnode 
    cdef int TOPSOILnode 
    cdef int ITERATIONSperDAY 
    cdef int NUM_PHANTOM_NODES 
    cdef float DAYhrs 
    cdef float MIN2SEC 
    cdef float HR2MIN 
    cdef float SEC2HR 
    cdef float DAYmins 
    cdef float DAYsecs 
    cdef float PA2HPA 
    cdef float MJ2J 
    cdef float J2MJ 
    cdef float tempStepSec 
    cdef int BoundaryLayerConductanceIterations 
    cdef int numNodes 
    cdef str soilConstituentNames[]
    cdef int timeStepIteration 
    cdef float netRadiation 
    cdef float constantBoundaryLayerConductance 
    cdef float precision 
    cdef float cva 
    cdef float cloudFr 
    cdef float solarRadn[]
    cdef int layer 
    cdef float timeOfDaySecs 
    cdef float airTemperature 
    cdef int iteration 
    cdef float tMean 
    cdef float internalTimeStep 
    cdef float soilWater[]
    cdef int copyLength 
    AIRnode=0
    SURFACEnode=1
    TOPSOILnode=2
    ITERATIONSperDAY=48
    NUM_PHANTOM_NODES=5
    DAYhrs=24.0
    MIN2SEC=60.0
    HR2MIN=60.0
    SEC2HR=1.0 / (HR2MIN * MIN2SEC)
    DAYmins=DAYhrs * HR2MIN
    DAYsecs=DAYmins * MIN2SEC
    PA2HPA=1.0 / 100.0
    MJ2J=1000000.0
    J2MJ=1.0 / MJ2J
    tempStepSec=24.0 * 60.0 * 60.0
    BoundaryLayerConductanceIterations=1
    numNodes=NLAYR + NUM_PHANTOM_NODES
    soilConstituentNames=["Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"]
    timeStepIteration=1
    constantBoundaryLayerConductance=20.0
    layer=0
    cva=0.0
    cloudFr=0.0
    solarRadn=[0.0] * 49
    (solarRadn, cloudFr, cva)=doNetRadiation(solarRadn, cloudFr, cva, ITERATIONSperDAY, DOY, SRAD, TMIN, XLAT)
    minSoilTemp=Zero(minSoilTemp)
    maxSoilTemp=Zero(maxSoilTemp)
    aveSoilTemp=Zero(aveSoilTemp)
    _boundaryLayerConductance=0.0
    internalTimeStep=tempStepSec / float(ITERATIONSperDAY)
    soilWater=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    copyLength=min(NLAYR + 1 + NUM_PHANTOM_NODES, len(SW) + 1)
    soilWater[:copyLength]=SW[:copyLength]
    volSpecHeatSoil=doVolumetricSpecificHeat(volSpecHeatSoil, soilWater, numNodes, soilConstituentNames, THICK, DEPTH)
    thermalConductivity=doThermConductivity(soilWater, SLCARB, SLROCK, SLSAND, SLSILT, CLAY, BD, thermalConductivity, THICK, DEPTH, numNodes, soilConstituentNames)
    for timeStepIteration in range(1 , ITERATIONSperDAY + 1 , 1):
        timeOfDaySecs=internalTimeStep * float(timeStepIteration)
        if tempStepSec < (24.0 * 60.0 * 60.0):
            tMean=T2M
        else:
            tMean=InterpTemp(timeOfDaySecs * SEC2HR, TMAX, TMIN, T2M, maxTempYesterday, minTempYesterday)
        newTemperature[AIRnode]=tMean
        netRadiation=RadnNetInterpolate(internalTimeStep, solarRadn[timeStepIteration], cloudFr, cva, ESP, EOAD, tMean, SALB, soilTemp)
        if boundaryLayerConductanceSource == "constant":
            thermalConductivity[AIRnode]=constantBoundaryLayerConductance
        elif boundaryLayerConductanceSource == "calc":
            thermalConductivity[AIRnode]=boundaryLayerConductanceF(newTemperature, tMean, ESP, EOAD, airPressure, canopyHeight, windSpeed, instrumentHeight)
            for iteration in range(1 , BoundaryLayerConductanceIterations + 1 , 1):
                newTemperature=doThomas(newTemperature, soilTemp, thermalConductivity, thermalConductance, DEPTH, volSpecHeatSoil, internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource)
                thermalConductivity[AIRnode]=boundaryLayerConductanceF(newTemperature, tMean, ESP, EOAD, airPressure, canopyHeight, windSpeed, instrumentHeight)
        newTemperature=doThomas(newTemperature, soilTemp, thermalConductivity, thermalConductance, DEPTH, volSpecHeatSoil, internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource)
        (soilTemp, _boundaryLayerConductance)=doUpdate(newTemperature, soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp, thermalConductivity, _boundaryLayerConductance, ITERATIONSperDAY, timeOfDaySecs, internalTimeStep, numNodes)
        precision=min(timeOfDaySecs, 5.0 * 3600.0) * 0.0001
        if abs(timeOfDaySecs - (5.0 * 3600.0)) <= precision:
            for layer in range(0 , len(soilTemp) , 1):
                morningSoilTemp[layer]=soilTemp[layer]
    minTempYesterday=TMIN
    maxTempYesterday=TMAX
    return  soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp, morningSoilTemp, newTemperature, maxTempYesterday, minTempYesterday, thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, thermalConductivity, thermalConductance, heatStorage, volSpecHeatSoil, _boundaryLayerConductance, SLROCK, SLCARB, SLSAND, SLSILT, airPressure



def doNetRadiation(floatarray solarRadn,
         float cloudFr,
         float cva,
         int ITERATIONSperDAY,
         int doy,
         float rad,
         float tmin,
         float latitude):
    cdef float _pi = 3.141592653589793
    cdef float TSTEPS2RAD = 1.0
    cdef float SOLARconst = 1.0
    cdef float solarDeclination = 1.0
    cdef float m1[]
    m1=[0.] * (ITERATIONSperDAY + 1)
    TSTEPS2RAD=Divide(2.0 * _pi, float(ITERATIONSperDAY), 0.0)
    SOLARconst=1360.0
    solarDeclination=0.3985 * sin((4.869 + (doy * 2.0 * _pi / 365.25) + (0.03345 * sin((6.224 + (doy * 2.0 * _pi / 365.25))))))
    cdef float cD = sqrt(1.0 - (solarDeclination * solarDeclination))
    cdef float m1Tot = 0.0
    cdef float psr 
    cdef int timestepNumber = 1
    cdef float fr 
    for timestepNumber in range(1 , ITERATIONSperDAY + 1 , 1):
        m1[timestepNumber]=(solarDeclination * sin(latitude * _pi / 180.0) + (cD * cos(latitude * _pi / 180.0) * cos(TSTEPS2RAD * (float(timestepNumber) - (float(ITERATIONSperDAY) / 2.0))))) * 24.0 / float(ITERATIONSperDAY)
        if m1[timestepNumber] > 0.0:
            m1Tot=m1Tot + m1[timestepNumber]
        else:
            m1[timestepNumber]=0.0
    psr=m1Tot * SOLARconst * 3600.0 / 1000000.0
    fr=Divide(max(rad, 0.1), psr, 0.0)
    cloudFr=2.33 - (3.33 * fr)
    cloudFr=min(max(cloudFr, 0.0), 1.0)
    for timestepNumber in range(1 , ITERATIONSperDAY + 1 , 1):
        solarRadn[timestepNumber]=max(rad, 0.1) * Divide(m1[timestepNumber], m1Tot, 0.0)
    cdef float kelvinTemp = kelvinT(tmin)
    cva=exp((31.3716 - (6014.79 / kelvinTemp) - (0.00792495 * kelvinTemp))) / kelvinTemp
    return (solarRadn, cloudFr, cva)

def Divide(float val1,
         float val2,
         float errVal):
    cdef float returnValue = errVal
    if val2 != 0.0:
        returnValue=val1 / val2
    return returnValue

def kelvinT(float celciusT):
    cdef float ZEROTkelvin = 273.18
    cdef float res = celciusT + ZEROTkelvin
    return res



def Zero(floatarray arr):
    cdef int i = 0
    for i in range(0 , len(arr) , 1):
        arr[i]=0.
    return arr



def doVolumetricSpecificHeat(floatarray volSpecLayer,
         floatarray soilW,
         int numNodes,
         strarray constituents,
         floatarray thickness,
         floatarray depth):
    cdef float volSpecHeatSoil[]
    volSpecHeatSoil=[0.0] * (numNodes + 1)
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
    thermCondLayers=[0.0] * (numNodes + 1)
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
            thermalConductanceWater=ThermalConductance("Water")
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
        result=0.333 - (0.333 * 0.0 / (volumetricFractionWater(soilWater, carbon, bulkDensity, layer) + 0.0 + volumetricFractionAir(rocks, carbon, sand, silt, clay, soilWater, bulkDensity, layer)))
        return result
    elif name == "Air":
        result=0.333 - (0.333 * volumetricFractionAir(rocks, carbon, sand, silt, clay, soilWater, bulkDensity, layer) / (volumetricFractionWater(soilWater, carbon, bulkDensity, layer) + 0.0 + volumetricFractionAir(rocks, carbon, sand, silt, clay, soilWater, bulkDensity, layer)))
        return result
    elif name == "Minerals":
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

def volumetricFractionOrganicMatter(floatarray carbon,
         floatarray bulkDensity,
         int layer):
    cdef float pom = 1.3
    cdef float res = carbon[layer] / 100.0 * 2.5 * bulkDensity[layer] / pom
    return res



def InterpTemp(float time_hours,
         float tmax,
         float tmin,
         float t2m,
         float max_temp_yesterday,
         float min_temp_yesterday):
    cdef float defaultTimeOfMaximumTemperature = 14.0
    cdef float midnight_temp 
    cdef float t_scale 
    cdef float _pi = 3.141592653589793
    cdef float time = time_hours / 24.0
    cdef float max_t_time = defaultTimeOfMaximumTemperature / 24.0
    cdef float min_t_time = max_t_time - 0.5
    cdef float current_temp = 0.0
    if time < min_t_time:
        midnight_temp=sin((0.0 + 0.25 - max_t_time) * 2.0 * _pi) * (max_temp_yesterday - min_temp_yesterday) / 2.0 + ((max_temp_yesterday + min_temp_yesterday) / 2.0)
        t_scale=(min_t_time - time) / min_t_time
        if t_scale > 1.0:
            t_scale=1.0
        elif t_scale < 0.0:
            t_scale=0.0
        current_temp=tmin + (t_scale * (midnight_temp - tmin))
        return current_temp
    else:
        current_temp=sin((time + 0.25 - max_t_time) * 2.0 * _pi) * (tmax - tmin) / 2.0 + t2m
        return current_temp
    return current_temp



def RadnNetInterpolate(float internalTimeStep,
         float solarRadiation,
         float cloudFr,
         float cva,
         float potE,
         float potET,
         float tMean,
         float albedo,
         floatarray soilTemp):
    cdef float EMISSIVITYsurface = 0.96
    cdef float w2MJ = internalTimeStep / 1000000.0
    cdef int SURFACEnode = 1
    cdef float emissivityAtmos = (1 - (0.84 * cloudFr)) * 0.58 * pow(cva, 1.0 / 7.0) + (0.84 * cloudFr)
    cdef float PenetrationConstant = Divide(max(0.1, potE), max(0.1, potET), 0.0)
    cdef float lwRinSoil = longWaveRadn(emissivityAtmos, tMean) * PenetrationConstant * w2MJ
    cdef float lwRoutSoil = longWaveRadn(EMISSIVITYsurface, soilTemp[SURFACEnode]) * PenetrationConstant * w2MJ
    cdef float lwRnetSoil = lwRinSoil - lwRoutSoil
    cdef float swRin = solarRadiation
    cdef float swRout = albedo * solarRadiation
    cdef float swRnetSoil = (swRin - swRout) * PenetrationConstant
    cdef float total = swRnetSoil + lwRnetSoil
    return total

def Divide(float val1,
         float val2,
         float errVal):
    cdef float returnValue = errVal
    if val2 != 0.0:
        returnValue=val1 / val2
    return returnValue

def longWaveRadn(float emissivity,
         float tDegC):
    cdef float STEFAN_BOLTZMANNconst = 0.0000000567
    cdef float kelvinTemp = kelvinT(tDegC)
    cdef float res = STEFAN_BOLTZMANNconst * emissivity * pow(kelvinTemp, 4)
    return res



def boundaryLayerConductanceF(floatarray TNew_zb,
         float tMean,
         float potE,
         float potET,
         float airPressure,
         float canopyHeight,
         float windSpeed,
         float instrumentHeight):
    cdef float VONK = 0.41
    cdef float GRAVITATIONALconst = 9.8
    cdef float specificHeatOfAir = 1010.0
    cdef float EMISSIVITYsurface = 0.98
    cdef int SURFACEnode = 1
    cdef float STEFAN_BOLTZMANNconst = 0.0000000567
    cdef float SpecificHeatAir = specificHeatOfAir * airDensity(tMean, airPressure)
    cdef float RoughnessFacMomentum = 0.13 * canopyHeight
    cdef float RoughnessFacHeat = 0.2 * RoughnessFacMomentum
    cdef float d = 0.77 * canopyHeight
    cdef float SurfaceTemperature = TNew_zb[SURFACEnode]
    cdef float PenetrationConstant = max(0.1, potE) / max(0.1, potET)
    cdef float kelvinTemp = kelvinT(tMean)
    cdef float radiativeConductance = 4.0 * STEFAN_BOLTZMANNconst * EMISSIVITYsurface * PenetrationConstant * pow(kelvinTemp, 3)
    cdef float FrictionVelocity = 0.0
    cdef float BoundaryLayerCond = 0.0
    cdef float StabilityParam = 0.0
    cdef float StabilityCorMomentum = 0.0
    cdef float StabilityCorHeat = 0.0
    cdef float HeatFluxDensity = 0.0
    cdef int iteration = 1
    for iteration in range(1 , 4 , 1):
        FrictionVelocity=Divide(windSpeed * VONK, log(Divide(instrumentHeight - d + RoughnessFacMomentum, RoughnessFacMomentum, 0.0)) + StabilityCorMomentum, 0.0)
        BoundaryLayerCond=Divide(SpecificHeatAir * VONK * FrictionVelocity, log(Divide(instrumentHeight - d + RoughnessFacHeat, RoughnessFacHeat, 0.0)) + StabilityCorHeat, 0.0)
        BoundaryLayerCond=BoundaryLayerCond + radiativeConductance
        HeatFluxDensity=BoundaryLayerCond * (SurfaceTemperature - tMean)
        StabilityParam=Divide(-VONK * instrumentHeight * GRAVITATIONALconst * HeatFluxDensity, SpecificHeatAir * kelvinTemp * pow(FrictionVelocity, 3), 0.0)
        if StabilityParam > 0.0:
            StabilityCorHeat=4.7 * StabilityParam
            StabilityCorMomentum=StabilityCorHeat
        else:
            StabilityCorHeat=-2.0 * log((1.0 + sqrt(1.0 - (16.0 * StabilityParam))) / 2.0)
            StabilityCorMomentum=0.6 * StabilityCorHeat
    return BoundaryLayerCond

def airDensity(float temperature,
         float AirPressure):
    cdef float MWair = 0.02897
    cdef float RGAS = 8.3143
    cdef float HPA2PA = 100.0
    cdef float kelvinTemp = kelvinT(temperature)
    cdef float res = Divide(MWair * AirPressure * HPA2PA, kelvinTemp * RGAS, 0.0)
    return res

def kelvinT(float celciusT):
    cdef float ZEROTkelvin = 273.18
    cdef float res = celciusT + ZEROTkelvin
    return res

def Divide(float val1,
         float val2,
         float errVal):
    cdef float returnValue = errVal
    if val2 != 0.0:
        returnValue=val1 / val2
    return returnValue

def kelvinT(float celciusT):
    cdef float ZEROTkelvin = 273.18
    cdef float res = celciusT + ZEROTkelvin
    return res

def Divide(float val1,
         float val2,
         float errVal):
    cdef float returnValue = errVal
    if val2 != 0.0:
        returnValue=val1 / val2
    return returnValue



def doThomas(floatarray newTemps,
         floatarray soilTemp,
         floatarray thermalConductivity,
         floatarray thermalConductance,
         floatarray depth,
         floatarray volSpecHeatSoil,
         float gDt,
         float netRadiation,
         float potE,
         float actE,
         int numNodes,
         str netRadiationSource):
    cdef float nu = 0.6
    cdef int AIRnode = 0
    cdef int SURFACEnode = 1
    cdef float MJ2J = 1000000.0
    cdef float latentHeatOfVapourisation = 2465000.0
    cdef float tempStepSec = 24.0 * 60.0 * 60.0
    cdef float heatStorage[]
    heatStorage=[0.] * (numNodes + 1)
    cdef float VolSoilAtNode 
    cdef float elementLength 
    cdef float g = 1 - nu
    cdef float sensibleHeatFlux 
    cdef float RadnNet 
    cdef float LatentHeatFlux 
    cdef float SoilSurfaceHeatFlux 
    cdef float a[]
    cdef float b[]
    cdef float c[]
    cdef float d[]
    a=[0.0] * (numNodes + 2)
    b=[0.0] * (numNodes + 1)
    c=[0.0] * (numNodes + 1)
    d=[0.0] * (numNodes + 1)
    thermalConductance=[0.] * (numNodes + 1)
    thermalConductance[AIRnode]=thermalConductivity[AIRnode]
    cdef int node = SURFACEnode
    for node in range(SURFACEnode , numNodes + 1 , 1):
        VolSoilAtNode=0.5 * (depth[node + 1] - depth[node - 1])
        heatStorage[node]=Divide(volSpecHeatSoil[node] * VolSoilAtNode, gDt, 0.0)
        elementLength=depth[node + 1] - depth[node]
        thermalConductance[node]=Divide(thermalConductivity[node], elementLength, 0.0)
    for node in range(SURFACEnode , numNodes + 1 , 1):
        c[node]=-nu * thermalConductance[node]
        a[node + 1]=c[node]
        b[node]=nu * (thermalConductance[node] + thermalConductance[node - 1]) + heatStorage[node]
        d[node]=g * thermalConductance[(node - 1)] * soilTemp[(node - 1)] + ((heatStorage[node] - (g * (thermalConductance[node] + thermalConductance[node - 1]))) * soilTemp[node]) + (g * thermalConductance[node] * soilTemp[(node + 1)])
    a[SURFACEnode]=0.0
    sensibleHeatFlux=nu * thermalConductance[AIRnode] * newTemps[AIRnode]
    RadnNet=0.0
    if netRadiationSource == "calc":
        RadnNet=Divide(netRadiation * 1000000.0, gDt, 0.0)
    elif netRadiationSource == "eos":
        RadnNet=Divide(potE * latentHeatOfVapourisation, tempStepSec, 0.0)
    LatentHeatFlux=Divide(actE * latentHeatOfVapourisation, tempStepSec, 0.0)
    SoilSurfaceHeatFlux=sensibleHeatFlux + RadnNet - LatentHeatFlux
    d[SURFACEnode]=d[SURFACEnode] + SoilSurfaceHeatFlux
    d[numNodes]=d[numNodes] + (nu * thermalConductance[numNodes] * newTemps[(numNodes + 1)])
    for node in range(SURFACEnode , numNodes , 1):
        c[node]=Divide(c[node], b[node], 0.0)
        d[node]=Divide(d[node], b[node], 0.0)
        b[node + 1]=b[node + 1] - (a[(node + 1)] * c[node])
        d[node + 1]=d[node + 1] - (a[(node + 1)] * d[node])
    newTemps[numNodes]=Divide(d[numNodes], b[numNodes], 0.0)
    for node in range(numNodes - 1 , SURFACEnode - 1 , -1):
        newTemps[node]=d[node] - (c[node] * newTemps[(node + 1)])
    return newTemps

def Divide(float val1,
         float val2,
         float errVal):
    cdef float returnValue = errVal
    if val2 != 0.0:
        returnValue=val1 / val2
    return returnValue



def doUpdate(floatarray tempNew,
         floatarray soilTemp,
         floatarray minSoilTemp,
         floatarray maxSoilTemp,
         floatarray aveSoilTemp,
         floatarray thermalConductivity,
         float boundaryLayerConductance,
         int IterationsPerDay,
         float timeOfDaySecs,
         float gDt,
         int numNodes):
    cdef int SURFACEnode = 1
    cdef int AIRnode = 0
    cdef int node = 1
    for node in range(0 , len(tempNew) , 1):
        soilTemp[node]=tempNew[node]
    if timeOfDaySecs < (gDt * 1.2):
        for node in range(SURFACEnode , numNodes + 1 , 1):
            minSoilTemp[node]=soilTemp[node]
            maxSoilTemp[node]=soilTemp[node]
    for node in range(SURFACEnode , numNodes + 1 , 1):
        if soilTemp[node] < minSoilTemp[node]:
            minSoilTemp[node]=soilTemp[node]
        elif soilTemp[node] > maxSoilTemp[node]:
            maxSoilTemp[node]=soilTemp[node]
        aveSoilTemp[node]=aveSoilTemp[node] + Divide(soilTemp[node], float(IterationsPerDay), 0.0)
    boundaryLayerConductance=boundaryLayerConductance + Divide(thermalConductivity[AIRnode], float(IterationsPerDay), 0.0)
    return (soilTemp, boundaryLayerConductance)

def Divide(float val1,
         float val2,
         float errVal):
    cdef float returnValue = errVal
    if val2 != 0.0:
        returnValue=val1 / val2
    return returnValue



def doThermalConductivityCoeffs(int nbLayers,
         int numNodes,
         floatarray bulkDensity,
         floatarray clay):
    cdef float thermalCondPar1[]
    cdef float thermalCondPar2[]
    cdef float thermalCondPar3[]
    cdef float thermalCondPar4[]
    cdef int layer 
    cdef int element 
    thermalCondPar1=[0.0] * (numNodes + 1)
    thermalCondPar2=[0.0] * (numNodes + 1)
    thermalCondPar3=[0.0] * (numNodes + 1)
    thermalCondPar4=[0.0] * (numNodes + 1)
    for layer in range(1 , nbLayers + 2 , 1):
        element=layer
        thermalCondPar1[element]=0.65 - (0.78 * bulkDensity[layer]) + (0.6 * pow(bulkDensity[layer], 2))
        thermalCondPar2[element]=1.06 * bulkDensity[layer]
        thermalCondPar3[element]=Divide(2.6, sqrt(clay[layer]), 0.0)
        thermalCondPar3[element]=1.0 + thermalCondPar3[element]
        thermalCondPar4[element]=0.03 + (0.1 * pow(bulkDensity[layer], 2))
    return (thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4)

def Divide(float val1,
         float val2,
         float errVal):
    cdef float returnValue = errVal
    if val2 != 0.0:
        returnValue=val1 / val2
    return returnValue



def CalcSoilTemp(floatarray soilTempIO,
         floatarray thickness,
         float tav,
         float tamp,
         int doy,
         float latitude,
         int numNodes):
    cdef float cumulativeDepth[]
    cdef float soilTemp[]
    cdef int Layer 
    cdef int nodes 
    cdef float tempValue 
    cdef float w 
    cdef float dh 
    cdef float zd 
    cdef float offset 
    cdef int SURFACEnode = 1
    cdef float piVal = 3.14
    cumulativeDepth=[0.0] * len(thickness)
    if len(thickness) > 0:
        cumulativeDepth[0]=thickness[0]
        for Layer in range(1 , len(thickness) , 1):
            cumulativeDepth[Layer]=thickness[Layer] + cumulativeDepth[Layer - 1]
    w=piVal
    w=2.0 * w
    w=w / (365.25 * 24.0 * 3600.0)
    dh=0.6
    zd=sqrt(2 * dh / w)
    offset=0.25
    if latitude > 0.0:
        offset=-0.25
    soilTemp=[0.0] * (numNodes + 2)
    for nodes in range(1 , numNodes + 1 , 1):
        soilTemp[nodes]=tav + (tamp * exp(-1.0 * cumulativeDepth[nodes] / zd) * sin(((doy / 365.0 + offset) * 2.0 * piVal - (cumulativeDepth[nodes] / zd))))
    soilTempIO[SURFACEnode:SURFACEnode + numNodes]=soilTemp[0:numNodes]
    return soilTempIO



