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
