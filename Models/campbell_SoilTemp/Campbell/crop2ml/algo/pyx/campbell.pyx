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
