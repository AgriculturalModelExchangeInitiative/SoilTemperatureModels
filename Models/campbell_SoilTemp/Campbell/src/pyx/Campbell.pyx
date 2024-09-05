import numpy
from math import *

def init_campbell(float TMAX,
                  float TMIN,
                  float TAV,
                  float SW[NLAYR],
                  float DOY,
                  float canopyHeight,
                  float SRAD,
                  float ESP,
                  float EOAD,
                  float ESAD):
    cdef floatarray soilTemp
    cdef float thickness[]
    cdef float depth[]
    cdef float bulkDensity[]
    cdef float soilWater[]
    cdef float clay[]
    cdef float volSpecHeatSoil[]
    cdef float thermCondPar1[]
    cdef float thermCondPar2[]
    cdef float thermCondPar3[]
    cdef float thermCondPar4[]
    cdef float soilRoughnessHeight 
    cdef float AltitudeMetres 
    cdef int NUM_PHANTOM_NODES 
    cdef float CONSTANT_TEMPdepth 
    cdef int AIRnode 
    cdef int SURFACEnode 
    cdef int TOPSOILnode 
    cdef float airPressure 
    cdef int numNodes 
    cdef float sumThickness 
    cdef int I 
    cdef float BelowProfileDepth 
    cdef float thicknessForPhantomNodes 
    cdef int firstPhantomNode 
    cdef int node 
    cdef int layer 
    cdef float InitialValues[]
    cdef float ave_temp 
    cdef float surfaceT 
    cdef float minTempYesterday 
    cdef float maxTempYesterday 
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
    thickness=0.0 * (NLAYR + 1 + NUM_PHANTOM_NODES)
    thickness[len(THICK)]=THICK
    sumThickness=0.0
    for I in range(0 , NLAYR , 1):
        sumThickness=sumThickness + thickness[I]
    BelowProfileDepth=max(CONSTANT_TEMPdepth * 1000.0 - sumThickness, 1.0 * 1000.0)
    thicknessForPhantomNodes=BelowProfileDepth * 2.0 / NUM_PHANTOM_NODES
    firstPhantomNode=NLAYR
    for I in range(firstPhantomNode , firstPhantomNode + NUM_PHANTOM_NODES , 1):
        thickness[]=thicknessForPhantomNodes
    depth=0.0 * (numNodes + 1 + 1)
    depth[min(numNodes + 1 + 1, len(DEPTH))]=DEPTH
    depth[AIRnode]=0.0
    depth[SURFACEnode]=0.0
    depth[TOPSOILnode]=0.5 * thickness[1] * 0.001
    for node in range(TOPSOILnode , numNodes , 1):
        sumThickness=0.0
        for I in range(1 , node , 1):
            sumThickness=sumThickness + thickness[I]
        depth[node + 1]=(sumThickness + (0.5 * thickness[node])) * 0.001
    bulkDensity=0.0 * (NLAYR + 1 + NUM_PHANTOM_NODES)
    bulkDensity[min(NLAYR + 1 + NUM_PHANTOM_NODES, len(BD))]=BD
    bulkDensity[numNodes - 1]=bulkDensity[NLAYR]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES , 1):
        bulkDensity[layer]=bulkDensity[NLAYR]
    soilWater=0.0 * (NLAYR + 1 + NUM_PHANTOM_NODES)
    soilWater[min(NLAYR + 1 + NUM_PHANTOM_NODES, len(SW))]=SW
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES , 1):
        soilWater[layer]=soilWater[NLAYR]
    clay=0.0 * (NLAYR + 1 + NUM_PHANTOM_NODES)
    for layer in range(1 , NLAYR + 1 , 1):
        clay[layer]=CLAY[layer - 1]
    for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES , 1):
        clay[layer]=clay[NLAYR]
    maxSoilTemp=0.0 * (NLAYR + 1 + NUM_PHANTOM_NODES)
    minSoilTemp=0.0 * (NLAYR + 1 + NUM_PHANTOM_NODES)
    aveSoilTemp=0.0 * (NLAYR + 1 + NUM_PHANTOM_NODES)
    volSpecHeatSoil=0.0 * (numNodes + 1)
    soilTemp=0.0 * (numNodes + 1 + 1)
    morningSoilTemp=0.0 * (numNodes + 1 + 1)
    tempNew=0.0 * (numNodes + 1 + 1)
    thermalConductivity=0.0 * (numNodes + 1)
    heatStorage=0.0 * (numNodes + 1)
    thermalConductance=0.0 * (numNodes + 1 + 1)
    (thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4)=doThermalConductivityCoeffs(NLAYR, numNodes, bulkDensity, clay)
    soilTemp=CalcSoilTemp(soilTemp, thickness, TAV, TAMP, DOY, XLAT)
    InitialValues=0.0 * NLAYR
    InitialValues[NLAYR]=soilTemp[TOPSOILnode]
    ave_temp=(TMAX + TMIN) * 0.5
    surfaceT=(1.0 - SALB) * (ave_temp + ((TMAX - ave_temp) * sqrt(max(SRAD, 0.1) * 23.8846 / 800.0))) + (SALB * ave_temp)
    soilTemp[SURFACEnode]=surfaceT
    for I in range(numNodes + 1 , len(soilTemp) , 1):
        soilTemp[I]=TAV
    tempNew[numNodes + 1 + 1]=soilTemp
    minTempYesterday=TMIN
    maxTempYesterday=TMAX
    return  soilTemp

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
                   float DOY,
                   float canopyHeight,
                   float SALB,
                   float SRAD,
                   float ESP,
                   float EOAD,
                   float ESAD,
                   float soilTemp[NLAYR]):
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
    soilTemp=compute(soilTemp, NLAYR)
    return  soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp, morningSoilTemp, tempNew, heatCapacity, thermalConductivity, thermalConductance, heatStorage



def compute(floatarray soilTemp,
         int NLAYR):
    cdef float soilTemp2[]
    cdef int i 
    for i in range(0 , NLAYR , 1):
        soilTemp2.append(float(i))
    return soilTemp2



def doThermalConductivityCoeffs(int nbLayers,
         int numNodes,
         floatarray bulkDensity,
         floatarray clay):
    cdef float thermCondPar1[]
    cdef float thermCondPar2[]
    cdef float thermCondPar3[]
    cdef float thermCondPar4[]
    cdef int layer 
    cdef int element 
    thermCondPar1=0.0 * (numNodes + 1)
    thermCondPar2=0.0 * (numNodes + 1)
    thermCondPar3=0.0 * (numNodes + 1)
    thermCondPar4=0.0 * (numNodes + 1)
    for layer in range(1 , nbLayers + 2 , 1):
        element=layer
        thermCondPar1[element]=0.65 - (0.78 * bulkDensity[layer]) + (0.6 * pow(bulkDensity[layer], 2))
        thermCondPar2[element]=1.06 * bulkDensity[layer]
        thermCondPar3[element]=Divide(2.6, sqrt(clay[layer]), 0.0)
        thermCondPar3[element]=1.0 + thermCondPar3[element]
        thermCondPar4[element]=0.03 + (0.1 * pow(bulkDensity[layer], 2))
    return (thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4)

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
    cumulativeDepth=0.0 * len(thickness)
    if len(thickness) > 0:
        cumulativeDepth[0]=thickness[0]
        for Layer in range(1 , len(thickness) , 1):
            cumulativeDepth[Layer]=thickness[Layer] + cumulativeDepth[Layer - 1]
    cdef float w 
    cdef float pi 
    pi=3.141592653589793
    w=pi
    w=2 * w
    w=w / (365.25 * 24.0 * 3600.0)
    cdef float dh 
    dh=0.6
    cdef float zd 
    zd=sqrt(2 * dh / w)
    cdef float offset = 0.25
    if latitude > 0.0:
        offset=-0.25
    soilTemp=0.0 * (numNodes + 2)
    for nodes in range(1 , numNodes + 1 , 1):
        soilTemp[nodes]=tav + tamp
        soilTemp[nodes]=soilTemp[nodes] * exp(-1 * cumulativeDepth[nodes] / zd)
        tempValue=pi
        tempValue=2.0 * tempValue - (cumulativeDepth[nodes] / zd)
        soilTemp[nodes]=soilTemp[nodes] * sin((doy / 365.0 + offset) * tempValue)
    soilTempIO[SURFACEnodeSURFACEnode + numNodes]=soilTemp[0numNodes]
    return soilTempIO



