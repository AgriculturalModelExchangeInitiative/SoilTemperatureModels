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
volSpecHeatSoil=doVolumetricSpecificHeat(volSpecHeatSoil, SWApsim, numNodes, soilConstituentNames, THICKApsim, DEPTHApsim)
thermalConductivity=doThermConductivity(SWApsim, SLCARBApsim, SLROCKApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, BDApsim, thermalConductivity, THICKApsim, DEPTHApsim, numNodes, soilConstituentNames)
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
            newTemperature=doThomas(newTemperature, soilTemp, thermalConductivity, thermalConductance, DEPTHApsim, volSpecHeatSoil, internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource)
            thermalConductivity[AIRnode]=boundaryLayerConductanceF(newTemperature, tMean, ESP, EOAD, airPressure, canopyHeight, windSpeed, instrumentHeight)
    newTemperature=doThomas(newTemperature, soilTemp, thermalConductivity, thermalConductance, DEPTHApsim, volSpecHeatSoil, internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource)
    (soilTemp, _boundaryLayerConductance)=doUpdate(newTemperature, soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp, thermalConductivity, _boundaryLayerConductance, ITERATIONSperDAY, timeOfDaySecs, internalTimeStep, numNodes)
    precision=min(timeOfDaySecs, 5.0 * 3600.0) * 0.0001
    if abs(timeOfDaySecs - (5.0 * 3600.0)) <= precision:
        for layer in range(0 , len(soilTemp) , 1):
            morningSoilTemp[layer]=soilTemp[layer]
minTempYesterday=TMIN
maxTempYesterday=TMAX
