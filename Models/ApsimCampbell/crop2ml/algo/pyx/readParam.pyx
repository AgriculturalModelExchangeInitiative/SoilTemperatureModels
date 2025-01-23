def doThermalConductivityCoeffs(floatarray thermCondPar2,
         int numLayers,
         floatarray bulkDensity,
         int numNodes,
         floatarray thermCondPar3,
         floatarray thermCondPar4,
         floatarray clay,
         floatarray thermCondPar1):
    cdef int layer 
    cdef float oldGC1[]
    cdef float oldGC2[]
    cdef float oldGC3[]
    cdef float oldGC4[]
    cdef int element 
    oldGC1=thermCondPar1
    thermCondPar1=array('f', [0.0]*(numNodes + 1))
    if oldGC1 is not None:
        thermCondPar1[0:min(numNodes + 1, len(oldGC1))]=oldGC1[0:min(numNodes + 1, len(oldGC1))]
    oldGC2=thermCondPar2
    thermCondPar2=array('f', [0.0]*(numNodes + 1))
    if oldGC2 is not None:
        thermCondPar2[0:min(numNodes + 1, len(oldGC2))]=oldGC2[0:min(numNodes + 1, len(oldGC2))]
    oldGC3=thermCondPar3
    thermCondPar3=array('f', [0.0]*(numNodes + 1))
    if oldGC3 is not None:
        thermCondPar3[0:min(numNodes + 1, len(oldGC3))]=oldGC3[0:min(numNodes + 1, len(oldGC3))]
    oldGC4=thermCondPar4
    thermCondPar4=array('f', [0.0]*(numNodes + 1))
    if oldGC4 is not None:
        thermCondPar4[0:min(numNodes + 1, len(oldGC4))]=oldGC4[0:min(numNodes + 1, len(oldGC4))]
    for layer in range(1 , numLayers + 1 + 1 , 1):
        element=layer
        thermCondPar1[element]=0.65 - (0.78 * bulkDensity[layer]) + (0.6 * pow(bulkDensity[layer], 2))
        thermCondPar2[element]=1.06 * bulkDensity[layer]
        thermCondPar3[element]=1.0 + Divide(2.6, sqrt(clay[layer]), float(0))
        thermCondPar4[element]=0.03 + (0.1 * pow(bulkDensity[layer], 2))
    return (thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1)

def readParam(float bareSoilRoughness,
         floatarray newTemperature,
         float soilRoughnessHeight,
         floatarray soilTemp,
         floatarray thermCondPar2,
         int numLayers,
         floatarray bulkDensity,
         int numNodes,
         floatarray thermCondPar3,
         floatarray thermCondPar4,
         floatarray clay,
         floatarray thermCondPar1,
         float weather_Tav,
         int clock_Today_DayOfYear,
         int surfaceNode,
         float weather_Amp,
         floatarray thickness,
         float weather_Latitude):
    (thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1)=doThermalConductivityCoeffs(thermCondPar2, numLayers, bulkDensity, numNodes, thermCondPar3, thermCondPar4, clay, thermCondPar1)
    soilTemp=calcSoilTemperature(soilTemp, weather_Tav, clock_Today_DayOfYear, surfaceNode, numNodes, weather_Amp, thickness, weather_Latitude)
    newTemperature[0:0 + len(soilTemp)]=soilTemp
    soilRoughnessHeight=bareSoilRoughness
    return (newTemperature, soilTemp, thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1, soilRoughnessHeight)