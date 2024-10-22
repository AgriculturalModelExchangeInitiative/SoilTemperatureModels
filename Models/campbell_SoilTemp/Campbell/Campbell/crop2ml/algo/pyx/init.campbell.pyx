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
