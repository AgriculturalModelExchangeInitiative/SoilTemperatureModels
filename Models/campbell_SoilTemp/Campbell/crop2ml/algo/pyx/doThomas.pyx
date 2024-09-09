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
