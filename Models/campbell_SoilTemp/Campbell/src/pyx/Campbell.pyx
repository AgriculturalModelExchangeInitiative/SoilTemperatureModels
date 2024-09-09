import numpy
from math import *

def init_campbell(int NLAYR,
                  float THICK[NLAYR],
                  float BD[NLAYR],
                  float TMAX,
                  float TMIN,
                  float TAV,
                  float TAMP,
                  float XLAT,
                  float CLAY[NLAYR],
                  float SW[NLAYR],
                  float DEPTH[NLAYR],
                  int DOY,
                  float canopyHeight,
                  float SALB,
                  float SRAD,
                  float ESP,
                  float ES,
                  float EOAD,
                  float ESAD):
    cdef float airPressure
    cdef floatarray soilTemp
    cdef float thermalCondPar1[NLAYR]
    cdef float thermalCondPar2[NLAYR]
    cdef float thermalCondPar3[NLAYR]
    cdef float thermalCondPar4[NLAYR]
    cdef float maxTempYesterday
    cdef float minTempYesterday
    airPressure = 0.0
    thermalCondPar1 = array('f', [0.0]*NLAYR)
    thermalCondPar2 = array('f', [0.0]*NLAYR)
    thermalCondPar3 = array('f', [0.0]*NLAYR)
    thermalCondPar4 = array('f', [0.0]*NLAYR)
    maxTempYesterday = 0.0
    minTempYesterday = 0.0
    cdef float thickness[]
    cdef float depth[]
    cdef float bulkDensity[]
    cdef float soilWater[]
    cdef float clay[]
    cdef float volSpecHeatSoil[]
    cdef float InitialValues[]
    cdef float soilRoughnessHeight 
    cdef float AltitudeMetres 
    cdef int NUM_PHANTOM_NODES 
    cdef float CONSTANT_TEMPdepth 
    cdef int AIRnode 
    cdef int SURFACEnode 
    cdef int TOPSOILnode 
    cdef float sumThickness 
    cdef float BelowProfileDepth 
    cdef float thicknessForPhantomNodes 
    cdef float ave_temp 
    cdef int I 
    cdef int numNodes 
    cdef int firstPhantomNode 
    cdef int layer 
    cdef int node 
    cdef float surfaceT 
    soilRoughnessHeight=57.0
    AltitudeMetres=18.0
    NUM_PHANTOM_NODES=5
    CONSTANT_TEMPdepth=10.0
    AIRnode=0
    SURFACEnode=1
    TOPSOILnode=2
    canopyHeight=max(canopyHeight, soilRoughnessHeight) * 0.001
    airPressure=101325.0 * pow((1.0 - (2.25577e-5 * AltitudeMetres)), 5.25588) * 0.01
    numNodes=NLAYR + NUM_PHANTOM_NODES
    thickness=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    thickness[:len(THICK)]=THICK
    sumThickness=0.0
    for I in range(0 , NLAYR , 1):
        sumThickness=sumThickness + thickness[I]
    BelowProfileDepth=max(CONSTANT_TEMPdepth * 1000.0 - sumThickness, 1.0 * 1000.0)
    thicknessForPhantomNodes=BelowProfileDepth * 2.0 / NUM_PHANTOM_NODES
    firstPhantomNode=NLAYR
    for I in range(firstPhantomNode , firstPhantomNode + NUM_PHANTOM_NODES , 1):
        thickness[I]=thicknessForPhantomNodes
    depth=[0.0] * (numNodes + 1 + 1)
    depth[:min(numNodes + 1 + 1, len(DEPTH))]=DEPTH
    depth[AIRnode]=0.0
    depth[SURFACEnode]=0.0
    depth[TOPSOILnode]=0.5 * thickness[1] * 0.001
    for node in range(TOPSOILnode , numNodes , 1):
        sumThickness=0.0
        for I in range(1 , node , 1):
            sumThickness=sumThickness + thickness[I]
        depth[node + 1]=(sumThickness + (0.5 * thickness[node])) * 0.001
    bulkDensity=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    bulkDensity[:min(NLAYR + 1 + NUM_PHANTOM_NODES, len(BD))]=BD
    bulkDensity[numNodes - 1]=bulkDensity[NLAYR]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES , 1):
        bulkDensity[layer]=bulkDensity[NLAYR]
    soilWater=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    soilWater[:min(NLAYR + 1 + NUM_PHANTOM_NODES, len(SW))]=SW
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES , 1):
        soilWater[layer]=soilWater[NLAYR]
    clay=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1 , NLAYR + 1 , 1):
        clay[layer]=CLAY[layer - 1]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES , 1):
        clay[layer]=clay[NLAYR]
    maxSoilTemp=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    minSoilTemp=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    aveSoilTemp=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    volSpecHeatSoil=[0.0] * (numNodes + 1)
    soilTemp=[0.0] * (numNodes + 1 + 1)
    morningSoilTemp=[0.0] * (numNodes + 1 + 1)
    tempNew=[0.0] * (numNodes + 1 + 1)
    thermalConductivity=[0.0] * (numNodes + 1)
    heatStorage=[0.0] * (numNodes + 1)
    thermalConductance=[0.0] * (numNodes + 1 + 1)
    (thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4)=doThermalConductivityCoeffs(NLAYR, numNodes, bulkDensity, clay)
    soilTemp=CalcSoilTemp(soilTemp, thickness, TAV, TAMP, DOY, XLAT)
    InitialValues=[0.0] * NLAYR
    InitialValues[:NLAYR]=soilTemp[TOPSOILnode:]
    ave_temp=(TMAX + TMIN) * 0.5
    surfaceT=(1.0 - SALB) * (ave_temp + ((TMAX - ave_temp) * sqrt(max(SRAD, 0.1) * 23.8846 / 800.0))) + (SALB * ave_temp)
    soilTemp[SURFACEnode]=surfaceT
    for I in range(numNodes + 1 , len(soilTemp) , 1):
        soilTemp[I]=TAV
    tempNew[:numNodes + 1 + 1]=soilTemp
    minTempYesterday=TMIN
    maxTempYesterday=TMAX
    return  airPressure, soilTemp, thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, maxTempYesterday, minTempYesterday

def model_campbell(int NLAYR,
                   float THICK[NLAYR],
                   float BD[NLAYR],
                   float TMAX,
                   float TMIN,
                   float TAV,
                   float TAMP,
                   float XLAT,
                   float CLAY[NLAYR],
                   float SW[NLAYR],
                   float DEPTH[NLAYR],
                   int DOY,
                   float airPressure,
                   float canopyHeight,
                   float SALB,
                   float SRAD,
                   float ESP,
                   float ES,
                   float EOAD,
                   float ESAD,
                   float soilTemp[NLAYR],
                   float thermalCondPar1[NLAYR],
                   float thermalCondPar2[NLAYR],
                   float thermalCondPar3[NLAYR],
                   float thermalCondPar4[NLAYR],
                   float maxTempYesterday,
                   float minTempYesterday):
    """
    SoilTemperature model from Campbell implemented in APSIM
    Author: None
    Reference: Campbell model (TODO)
    Institution: CIRAD and INRAE
    ExtendedDescription: TODO
    ShortDescription: TODO
    """

    cdef float minSoilTemp[NLAYR]
    cdef float maxSoilTemp[NLAYR]
    cdef float aveSoilTemp[NLAYR]
    cdef float morningSoilTemp[NLAYR]
    cdef float tempNew[NLAYR]
    cdef float heatCapacity[NLAYR]
    cdef float thermalConductivity[NLAYR]
    cdef float thermalConductance[NLAYR]
    cdef float heatStorage[NLAYR]
    cdef float volSpecHeatSoil[]
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
    cdef float cva 
    cdef float cloudFr 
    cdef float solarRadn[]
    cdef float _boundaryLayerConductance 
    cdef float gDt 
    cdef float soilWater[]
    cdef int copyLength 
    cdef int layer 
    cdef int numNodes 
    cdef int timeStepIteration 
    cdef float timeOfDaySecs 
    cdef float tMean 
    cdef float netRadiation 
    cdef int iteration 
    cdef float precision 
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
    tempStepSec=1440.0 * 60.0
    BoundaryLayerConductanceIterations=1
    cva=0.0
    cloudFr=0.0
    solarRadn=[0.] * 49
    (solarRadn, cloudFr, cva)=doNetRadiation(solarRadn, cloudFr, cva, ITERATIONSperDAY, DOY, SRAD, TMIN, XLAT)
    Zero(minSoilTemp)
    Zero(maxSoilTemp)
    Zero(aveSoilTemp)
    _boundaryLayerConductance=0.0
    gDt=tempStepSec / float(ITERATIONSperDAY)
    soilWater=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    copyLength=min(NLAYR + 1 + NUM_PHANTOM_NODES, len(SW))
    soilWater[:copyLength]=SW[:copyLength]
    layer=0
    for layer in range(NLAYR + 1 , NLAYR + 1 + NUM_PHANTOM_NODES + 1 , 1):
        soilWater[layer]=soilWater[NLAYR]
    numNodes=NLAYR + NUM_PHANTOM_NODES
    volSpecHeatSoil=doVolumetricSpecificHeat(soilWater, BD, NLAYR)
    thermalConductivity=doThermConductivityCampbell(soilWater, thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, thermalConductivity, THICK, DEPTH, numNodes)
    timeStepIteration=1
    for timeStepIteration in range(1 , ITERATIONSperDAY + 1 , 1):
        timeOfDaySecs=gDt * float(timeStepIteration)
        if tempStepSec < DAYsecs:
            tMean=0.5 * (TMAX + TMIN)
        else:
            tMean=InterpTemp(timeOfDaySecs * SEC2HR, TMAX, TMIN, maxTempYesterday, minTempYesterday)
        tempNew[AIRnode]=tMean
        netRadiation=RadnNetInterpolate(solarRadn[timeStepIteration], cloudFr, cva, ESAD, EOAD, tMean, SALB, gDt, soilTemp)
        thermalConductivity[AIRnode]=boundaryLayerConductanceF(tempNew, tMean, ESAD, EOAD, airPressure, canopyHeight)
        iteration=1
        for iteration in range(1 , BoundaryLayerConductanceIterations + 1 , 1):
            tempNew=doThomas(tempNew, soilTemp, thermalConductivity, DEPTH, volSpecHeatSoil, gDt, netRadiation, ES, numNodes)
            thermalConductivity[AIRnode]=boundaryLayerConductanceF(tempNew, tMean, potE, potET, airPressure, canopyHeight)
        tempNew=doThomas(tempNew, soilTemp, thermalConductivity, DEPTH, volSpecHeatSoil, gDt, netRadiation, ES, numNodes)
        (soilTemp, _boundaryLayerConductance)=doUpdate(tempNew, soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp, thermalConductivity, _boundaryLayerConductance, ITERATIONSperDAY, timeOfDaySecs, gDt, numNodes)
        precision=min(timeOfDaySecs, 5.0 * HR2MIN * MIN2SEC) * 0.0001
        if abs(timeOfDaySecs - (5.0 * HR2MIN * MIN2SEC)) <= precision:
            morningSoilTemp[]=soilTemp[]
        minTempYesterday=TMIN
        maxTempYesterday=TMAX
    return  soilTemp, maxTempYesterday, minTempYesterday, minSoilTemp, maxSoilTemp, aveSoilTemp, morningSoilTemp, tempNew, heatCapacity, thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, thermalConductivity, thermalConductance, heatStorage, airPressure



def doNetRadiation(floatarray solarRadn,
         float cloudFr,
         float cva,
         int ITERATIONSperDAY,
         int doy,
         float rad,
         float tmin,
         float latitude):
    cdef float DAYSinYear = 365.25
    cdef float DAYhrs = 24.0
    cdef float MIN2SEC = 60.0
    cdef float HR2MIN = 60.0
    cdef float SEC2HR = 1.0 / (HR2MIN * MIN2SEC)
    cdef float DAYmins = DAYhrs * HR2MIN
    cdef float DAYsecs = DAYmins * MIN2SEC
    cdef float PA2HPA = 1.0 / 100.0
    cdef float MJ2J = 1000000.0
    cdef float J2MJ = 1.0 / MJ2J
    cdef float DEG2RAD = pi / 180.0
    cdef float DOY2RAD = DEG2RAD * 360.0 / DAYSinYear
    cdef float TSTEPS2RAD = Divide(DEG2RAD * 360., float(ITERATIONSperDAY), 0.0)
    cdef float SOLARconst = 1360.0
    cdef float solarDeclination = 0.3985 * sin((4.869 + (doy * DOY2RAD) + (0.03345 * sin((6.224 + (doy * DOY2RAD))))))
    cdef float cD = sqrt(1.0 - (solarDeclination * solarDeclination))
    cdef float m1[]
    cdef float m1Tot = 0.0
    cdef float W2MJ 
    cdef float psr 
    cdef int timestepNumber = 1
    for timestepNumber in range(1 , ITERATIONSperDAY + 1 , 1):
        m1[timestepNumber]=(solarDeclination * sin(latitude * DEG2RAD) + (cD * cos(latitude * DEG2RAD) * cos(TSTEPS2RAD * (float(timestepNumber) - (float(ITERATIONSperDAY) / 2.0))))) * 24.0 / float(ITERATIONSperDAY)
        if m1[timestepNumber] > 0.0:
            m1Tot=m1Tot + m1[timestepNumber]
        else:
            m1[timestepNumber]=0.0
    W2MJ=HR2MIN * MIN2SEC * J2MJ
    psr=m1Tot * SOLARconst * W2MJ
    cdef float fr 
    fr=Divide(max(rad, 0.1), psr, 0.0)
    cloudFr=2.33 - (3.33 * fr)
    if cloudFr < 0.0:
        cloudFr=0.0
    elif cloudFr > 1.0:
        cloudFr=1.0
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
    return celciusT + ZEROTkelvin



def Zero(floatarray arr):
    cdef int i = 0
    for i in range(0 , len(arr) , 1):
        arr[i]=0.



def doVolumetricSpecificHeat(floatarray soilW,
         floatarray bulkDensity,
         int numLayers):
    cdef float SPECIFICbd = 2.65
    cdef float volSpecHeatClay = 2.39e6
    cdef float volSpecHeatWater = 4.18e6
    cdef float volSpecHeatSoil[]
    cdef int layer 
    for layer in range(1 , numLayers + 1 , 1):
        cdef float solidity = bulkDensity[layer] / SPECIFICbd
        volSpecHeatSoil[layer]=volSpecHeatClay * solidity + (volSpecHeatWater * soilW[layer])
    volSpecHeatSoil[0]=volSpecHeatSoil[1]
    return volSpecHeatSoil



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



def InterpTemp(float time_hours,
         float tmax,
         float tmin,
         float max_temp_yesterday,
         float min_temp_yesterday):
    cdef float DAYhrs = 24.0
    cdef float time = time_hours / DAYhrs
    cdef float max_t_time = tmax / DAYhrs
    cdef float min_t_time = max_t_time - 0.5
    cdef float current_temp 
    if time < min_t_time:
        cdef float midnight_temp = sin((0.0 + 0.25 - max_t_time) * 2.0 * pi) * (max_temp_yesterday - min_temp_yesterday) / 2.0 + ((max_temp_yesterday + min_temp_yesterday) / 2.0)
        cdef float t_scale = (min_t_time - time) / min_t_time
        t_scale=max(0, min(t_scale, 1))
        current_temp=tmin + (t_scale * (midnight_temp - tmin))
    else:
        current_temp=sin((time + 0.25 - max_t_time) * 2.0 * pi) * (tmax - tmin) / 2.0 + ((tmax + tmin) / 2.0)
    return current_temp



def RadnNetInterpolate(float solarRadn,
         float cloudFr,
         float cva,
         float potE,
         float potET,
         float tMean,
         float albedo,
         float gDt,
         floatarray soilTemp):
    cdef float EMISSIVITYsurface = 0.96
    cdef float MJ2J = 1000000.0
    cdef float J2MJ = 1.0 / MJ2J
    cdef int SURFACEnode = 1
    cdef float w2MJ = gDt * J2MJ
    cdef float emissivityAtmos = (1 - (0.84 * cloudFr)) * 0.58 * pow(cva, 1.0 / 7.0) + (0.84 * cloudFr)
    cdef float PenetrationConstant = Divide(max(0.1, potE), max(0.1, potET), 0.0)
    cdef float lwRinSoil = longWaveRadn(emissivityAtmos, tMean)
    lwRinSoil=lwRinSoil * PenetrationConstant * w2MJ
    cdef float lwRoutSoil = longWaveRadn(EMISSIVITYsurface, soilTemp[SURFACEnode]) * PenetrationConstant * w2MJ
    cdef float lwRnetSoil = lwRinSoil - lwRoutSoil
    cdef float swRin = solarRadn
    cdef float swRout = albedo * solarRadn
    cdef float swRnetSoil = (swRin - swRout) * PenetrationConstant
    return swRnetSoil + lwRnetSoil

def Divide(float val1,
         float val2,
         float errVal):
    cdef float returnValue = errVal
    if val2 != 0.0:
        returnValue=val1 / val2
    return returnValue

def longWaveRadn(float emissivity,
         float tDegC):
    cdef float STEFAN_BOLTZMANNconst = 5.67e-8
    cdef float kelvinTemp = kelvinT(tDegC)
    cdef float res = STEFAN_BOLTZMANNconst * emissivity * pow(kelvinTemp, 4)
    return res



def boundaryLayerConductanceF(floatarray TNew_zb,
         float tMean,
         float potE,
         float potET,
         float airPressure,
         float canopyHeight):
    cdef float VONK = 0.41
    cdef float GRAVITATIONALconst = 9.8
    cdef float CAPP = 1010.0
    cdef float EMISSIVITYsurface = 0.98
    cdef int SURFACEnode = 1
    cdef float STEFAN_BOLTZMANNconst = 5.67e-8
    cdef float windSpeed = 259.2
    cdef float instrumentHeight = 1.2
    cdef float SpecificHeatAir = CAPP * RhoA(tMean, airPressure)
    cdef float RoughnessFacMomentum = 0.13 * canopyHeight
    cdef float RoughnessFacHeat = 0.2 * RoughnessFacMomentum
    cdef float d = 0.77 * canopyHeight
    cdef float SurfaceTemperature = TNew_zb[SURFACEnode]
    cdef float PenetrationConstant = max(0.1, potE) / max(0.1, potET)
    cdef float radiativeConductance = 4.0 * STEFAN_BOLTZMANNconst * EMISSIVITYsurface * PenetrationConstant * pow(kelvinT(tMean), 3)
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
        BoundaryLayerCond+=radiativeConductance
        HeatFluxDensity=BoundaryLayerCond * (SurfaceTemperature - tMean)
        StabilityParam=Divide(-VONK * instrumentHeight * GRAVITATIONALconst * HeatFluxDensity, SpecificHeatAir * kelvinT(tMean) * pow(FrictionVelocity, 3), 0.0)
        if StabilityParam > 0.0:
            StabilityCorHeat=4.7 * StabilityParam
            StabilityCorMomentum=StabilityCorHeat
        else:
            StabilityCorHeat=-2.0 * log((1.0 + sqrt(1.0 - (16.0 * StabilityParam))) / 2.0)
            StabilityCorMomentum=0.6 * StabilityCorHeat
    return BoundaryLayerCond

def RhoA(float temperature,
         float AirPressure):
    cdef float MWair = 0.02897
    cdef float RGAS = 8.3143
    cdef float HPA2PA = 100.0
    cdef float kelvinTemp = kelvinT(temperature)
    kelvinTemp=kelvinTemp * RGAS
    cdef float divide1 = MWair * AirPressure * HPA2PA
    cdef float res = Divide(MWair * AirPressure * HPA2PA, kelvinTemp, 0.0)
    return res

def kelvinT(float celciusT):
    cdef float ZEROTkelvin = 273.18
    return celciusT + ZEROTkelvin

def Divide(float val1,
         float val2,
         float errVal):
    cdef float returnValue = errVal
    if val2 != 0.0:
        returnValue=val1 / val2
    return returnValue

def kelvinT(float celciusT):
    cdef float ZEROTkelvin = 273.18
    return celciusT + ZEROTkelvin

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
         floatarray depth,
         floatarray volSpecHeatSoil,
         float gDt,
         float netRadiation,
         float actE,
         int numNodes):
    cdef float nu = 0.6
    cdef int AIRnode = 0
    cdef int SURFACEnode = 1
    cdef float gDt = 1.0
    cdef float MJ2J = 1000000.0
    cdef float LAMBDA = 2465000.0
    cdef float tempStepSec = 1440.0 * 60.0
    cdef float heatStorage[]
    cdef float a[]
    cdef float b[]
    cdef float c[]
    cdef float d[]
    thermalConductance=[0.] * (numNodes + 1)
    thermalConductance[AIRnode]=thermalConductivity[AIRnode]
    cdef int node = SURFACEnode
    for node in range(SURFACEnode , numNodes + 1 , 1):
        cdef float VolSoilAtNode = 0.5 * (depth[node + 1] - depth[node - 1])
        heatStorage[node]=volSpecHeatSoil[node] * VolSoilAtNode / gDt
        cdef float elementLength = depth[node + 1] - depth[node]
        thermalConductance[node]=thermalConductivity[node] / elementLength
    cdef float g = 1 - nu
    for node in range(SURFACEnode , numNodes + 1 , 1):
        c[node]=-nu * thermalConductance[node]
        a[node + 1]=c[node]
        b[node]=nu * (thermalConductance[node] + thermalConductance[node - 1]) + heatStorage[node]
        d[node]=g * thermalConductance[(node - 1)] * soilTemp[(node - 1)] + ((heatStorage[node] - (g * (thermalConductance[node] + thermalConductance[node - 1]))) * soilTemp[node]) + (g * thermalConductance[node] * soilTemp[(node + 1)])
    a[SURFACEnode]=0.0
    cdef float sensibleHeatFlux = nu * thermalConductance[AIRnode] * newTemps[AIRnode]
    cdef float RadnNet = netRadiation * MJ2J / gDt
    cdef float LatentHeatFlux = actE * LAMBDA / tempStepSec
    cdef float SoilSurfaceHeatFlux = sensibleHeatFlux + RadnNet - LatentHeatFlux
    d[SURFACEnode]+=SoilSurfaceHeatFlux
    d[numNodes]+=nu * thermalConductance[numNodes] * newTemps[(numNodes + 1)]
    for node in range(SURFACEnode , numNodes , 1):
        c[node]/=b[node]
        d[node]/=b[node]
        b[node + 1]-=a[(node + 1)] * c[node]
        d[node + 1]-=a[(node + 1)] * d[node]
    newTemps[numNodes]=d[numNodes] / b[numNodes]
    for node in range(numNodes - 1 , SURFACEnode - 1 , -1):
        newTemps[node]=d[node] - (c[node] * newTemps[(node + 1)])
    return newTemps



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
    soilTemp[]=tempNew[]
    if timeOfDaySecs < (gDt * 1.2):
        cdef int node = 1
        for node in range(SURFACEnode , numNodes + 1 , 1):
            minSoilTemp[node]=soilTemp[node]
            maxSoilTemp[node]=soilTemp[node]
    for node in range(SURFACEnode , numNodes + 1 , 1):
        if soilTemp[node] < minSoilTemp[node]:
            minSoilTemp[node]=soilTemp[node]
        elif soilTemp[node] > maxSoilTemp[node]:
            maxSoilTemp[node]=soilTemp[node]
        aveSoilTemp[node]+=soilTemp[node] / float(IterationsPerDay)
    boundaryLayerConductance+=Divide(thermalConductivity[AIRnode], float(IterationsPerDay), 0.0)
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
         float latitude):
    cdef float cumulativeDepth[]
    cdef float soilTemp[]
    cdef int Layer 
    cdef int nodes 
    cdef float tempValue 
    cdef float w 
    cdef float pi 
    cdef float dh 
    cdef float zd 
    cdef float offset 
    cumulativeDepth=[0.0] * len(thickness)
    if len(thickness) > 0:
        cumulativeDepth[0]=thickness[0]
        for Layer in range(1 , len(thickness) , 1):
            cumulativeDepth[Layer]=thickness[Layer] + cumulativeDepth[Layer - 1]
    w=pi
    w=2 * w
    w=w / (365.25 * 24.0 * 3600.0)
    dh=0.6
    zd=sqrt(2 * dh / w)
    offset=0.25
    if latitude > 0.0:
        offset=-0.25
    soilTemp=[0.0] * (numNodes + 2)
    for nodes in range(1 , numNodes + 1 , 1):
        soilTemp[nodes]=tav + tamp
        soilTemp[nodes]=soilTemp[nodes] * exp(-1 * cumulativeDepth[nodes] / zd)
        tempValue=pi
        tempValue=2.0 * tempValue - (cumulativeDepth[nodes] / zd)
        soilTemp[nodes]=soilTemp[nodes] * sin((doy / 365.0 + offset) * tempValue)
    soilTempIO[SURFACEnode:SURFACEnode + numNodes]=soilTemp[0:numNodes]
    return soilTempIO



