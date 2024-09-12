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
    if netRadiationSource == "'calc'":
        RadnNet=Divide(netRadiation * 1000000.0, gDt, 0.0)
    elif netRadiationSource == "'eos'":
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
