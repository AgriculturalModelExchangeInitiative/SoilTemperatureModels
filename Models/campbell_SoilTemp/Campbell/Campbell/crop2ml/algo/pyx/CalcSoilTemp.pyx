def CalcSoilTemp(floatarray thickness,
         float tav,
         float tamp,
         int doy,
         float latitude,
         int numNodes):
    cdef float cumulativeDepth[]
    cdef float soilTempIO[]
    cdef float soilTemperat[]
    cdef int Layer 
    cdef int nodes 
    cdef float tempValue 
    cdef float w 
    cdef float dh 
    cdef float zd 
    cdef float offset 
    cdef int SURFACEnode = 1
    cdef float piVal = 3.141592653589793
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
    soilTemperat=[0.0] * (numNodes + 2)
    soilTempIO=[0.0] * (numNodes + 1 + 1)
    for nodes in range(1 , numNodes + 1 , 1):
        soilTemperat[nodes]=tav + (tamp * exp(-1.0 * cumulativeDepth[nodes] / zd) * sin(((doy / 365.0 + offset) * 2.0 * piVal - (cumulativeDepth[nodes] / zd))))
    for Layer in range(SURFACEnode , numNodes + 1 , 1):
        soilTempIO[Layer]=soilTemperat[Layer - 1]
    return soilTempIO
