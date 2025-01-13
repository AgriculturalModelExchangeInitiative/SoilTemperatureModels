def ToCumThickness(floatarray Thickness):
    cdef int Layer 
    cdef float CumThickness[len(Thickness)]
    if len(Thickness) > 0:
        CumThickness[0]=Thickness[0]
        for Layer in range(1 , len(Thickness) , 1):
            CumThickness[Layer]=Thickness[Layer] + CumThickness[Layer - 1]
    return CumThickness

def calcSoilTemperature(floatarray soilTempIO,
         int surfaceNode,
         float weather_Amp,
         int clock_Today_DayOfYear,
         float weather_Tav,
         int numNodes,
         floatarray thickness,
         float weather_Latitude):
    cdef int nodes 
    cdef float cumulativeDepth[]
    cdef float w 
    cdef float dh 
    cdef float zd 
    cdef float offset 
    cdef float soilTemp[numNodes + 1 + 1]
    cumulativeDepth=ToCumThickness(thickness)
    w=2 * pi / (365.25 * 24 * 3600)
    dh=0.6
    zd=sqrt(2 * dh / w)
    offset=0.25
    if weather_Latitude > 0.0:
        offset=-0.25
    for nodes in range(1 , numNodes + 1 , 1):
        soilTemp[nodes]=weather_Tav + (weather_Amp * exp(-1 * cumulativeDepth[nodes] / zd) * sin(((clock_Today_DayOfYear / 365.0 + offset) * 2.0 * pi - (cumulativeDepth[nodes] / zd))))
    soilTempIO[surfaceNode:surfaceNode + numNodes]=soilTemp[0:0 + numNodes]
    return soilTempIO