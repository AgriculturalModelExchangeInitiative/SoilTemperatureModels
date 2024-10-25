cdef floatlist  heatCapacity
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
cdef int I 
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
THICKApsim=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
for layer in range(1 , NLAYR + 1 , 1):
    THICKApsim[layer]=THICK[layer - 1]
sumThickness=0.0
for I in range(1 , NLAYR + 1 , 1):
    sumThickness=sumThickness + THICKApsim[I]
BelowProfileDepth=max(CONSTANT_TEMPdepth - sumThickness, 1000.0)
thicknessForPhantomNodes=BelowProfileDepth * 2.0 / NUM_PHANTOM_NODES
firstPhantomNode=NLAYR
for I in range(firstPhantomNode , firstPhantomNode + NUM_PHANTOM_NODES , 1):
    THICKApsim[I]=thicknessForPhantomNodes
DEPTHApsim=[0.0] * (numNodes + 1 + 1)
DEPTHApsim[AIRnode]=0.0
DEPTHApsim[SURFACEnode]=0.0
DEPTHApsim[TOPSOILnode]=0.5 * THICKApsim[1] / 1000.0
for node in range(TOPSOILnode , numNodes + 1 , 1):
    sumThickness=0.0
    for I in range(1 , node , 1):
        sumThickness=sumThickness + THICKApsim[I]
    DEPTHApsim[node + 1]=(sumThickness + (0.5 * THICKApsim[node])) / 1000.0
BDApsim=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
for layer in range(1 , NLAYR + 1 , 1):
    BDApsim[layer]=BD[layer - 1]
BDApsim[numNodes]=BDApsim[NLAYR]
for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
    BDApsim[layer]=BDApsim[NLAYR]
SWApsim=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
for layer in range(1 , NLAYR + 1 , 1):
    SWApsim[layer]=SW[layer - 1]
for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
    SWApsim[layer]=SWApsim[(NLAYR - 1)] * THICKApsim[(NLAYR - 1)] / THICKApsim[NLAYR]
SLCARBApsim=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
for layer in range(1 , NLAYR + 1 , 1):
    SLCARBApsim[layer]=SLCARB[layer - 1]
for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
    SLCARBApsim[layer]=SLCARBApsim[NLAYR]
SLROCKApsim=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
for layer in range(1 , NLAYR + 1 , 1):
    SLROCKApsim[layer]=SLROCK[layer - 1]
for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
    SLROCKApsim[layer]=SLROCKApsim[NLAYR]
SLSANDApsim=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
for layer in range(1 , NLAYR + 1 , 1):
    SLSANDApsim[layer]=SLSAND[layer - 1]
for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
    SLSANDApsim[layer]=SLSANDApsim[NLAYR]
SLSILTApsim=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
for layer in range(1 , NLAYR + 1 , 1):
    SLSILTApsim[layer]=SLSILT[layer - 1]
for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
    SLSILTApsim[layer]=SLSILTApsim[NLAYR]
CLAYApsim=[0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
for layer in range(1 , NLAYR + 1 , 1):
    CLAYApsim[layer]=CLAY[layer - 1]
for layer in range(NLAYR + 1 , NLAYR + NUM_PHANTOM_NODES + 1 , 1):
    CLAYApsim[layer]=CLAYApsim[NLAYR]
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
(thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4)=doThermalConductivityCoeffs(NLAYR, numNodes, BDApsim, CLAYApsim)
newTemperature=CalcSoilTemp(THICKApsim, TAV, TAMP, DOY, XLAT, numNodes)
instrumentHeight=max(instrumentHeight, canopyHeight + 0.5)
soilTemp=CalcSoilTemp(THICKApsim, TAV, TAMP, DOY, XLAT, numNodes)
soilTemp[AIRnode]=T2M
surfaceT=(1.0 - SALB) * (T2M + ((TMAX - T2M) * sqrt(max(SRAD, 0.1) * 23.8846 / 800.0))) + (SALB * T2M)
soilTemp[SURFACEnode]=surfaceT
for I in range(numNodes + 1 , len(soilTemp) , 1):
    soilTemp[I]=TAV
for I in range(0 , len(soilTemp) , 1):
    newTemperature[I]=soilTemp[I]
maxTempYesterday=TMAX
minTempYesterday=TMIN
