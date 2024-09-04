from math import isnan, isinf, pi, sqrt, sin, exp
from array import array 

def init_campbell(NLAYR: int,
    THICK: 'Array[float]',
    BD: 'Array[float]',
    TMAX: float,
    TMIN: float,
    TAV: float,
    TAMP: float,
    XLAT: float,
    CLAY: 'Array[float]',
    SW: 'Array[float]',
    DEPTH: 'Array[float]',
    DOY: float,
    canopyHeight: float,
    SALB: float,
    SRAD: float,
    ESP: float,
    EOAD: float,
    ESAD: float,
    soilTemp: 'Array[float]'):
 
    #constants
    soilRoughnessHeight: float = 57.0
    AltitudeMetres: float = 18.0
    NUM_PHANTOM_NODES: int = 5
    CONSTANT_TEMPdepth: float = 10.0
    AIRnode: int = 0
    SURFACEnode: int = 1
    TOPSOILnode: int = 2

    SALB = SALB
    canopyHeight = max(canopyHeight, soilRoughnessHeight) * 0.001
    airPressure = 101325.0 * (1.0 - 2.25577e-5 * AltitudeMetres) ** 5.25588 * 0.01
    NLAYR = NLAYR
    numNodes = NLAYR + NUM_PHANTOM_NODES

    thickness = [0.0] * (NLAYR + 1 + NUM_PHANTOM_NODES)
    thickness[:len(THICK)] = THICK
    sumThickness = sum(thickness[1:NLAYR + 1])
    BelowProfileDepth = max(CONSTANT_TEMPdepth * 1000.0 - sumThickness, 1.0 * 1000.0)

    thicknessForPhantomNodes = BelowProfileDepth * 2.0 / NUM_PHANTOM_NODES
    firstPhantomNode = NLAYR
    for i in range(firstPhantomNode, firstPhantomNode + NUM_PHANTOM_NODES):
        thickness[i] = thicknessForPhantomNodes

    depth = array('f', [0.0]*(numNodes + 1 + 1))
    depth[:min(numNodes + 1 + 1, len(dpth))] = dpth
    depth[AIRnode] = 0.0
    depth[SURFACEnode] = 0.0
    depth[TOPSOILnode] = 0.5 * thickness[1] * 0.001

    for node in range(TOPSOILnode, numNodes):
        sumThickness = sum(thickness[1:node])
        depth[node + 1] = (sumThickness + 0.5 * thickness[node]) * 0.001

    # Bulk Density
    bulkDensity = array('f', [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES))
    bulkDensity[:min(NLAYR + 1 + NUM_PHANTOM_NODES, len(bd))] = bd
    bulkDensity[numNodes - 1] = bulkDensity[NLAYR]
    for layer in range(NLAYR + 1, NLAYR + NUM_PHANTOM_NODES):
        bulkDensity[layer] = bulkDensity[NLAYR]

    # Soil Water
    soilWater = array('f', [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES))
    soilWater[:min(NLAYR + 1 + NUM_PHANTOM_NODES, len(sw))] = sw
    for layer in range(NLAYR + 1, NLAYR + NUM_PHANTOM_NODES):
        soilWater[layer] = soilWater[NLAYR]

    # Clay
    clay = array('f', [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES))
    for layer in range(1, NLAYR + 1):
        clay[layer] = cla[layer - 1]
    for layer in range(NLAYR + 1, NLAYR + NUM_PHANTOM_NODES):
        clay[layer] = clay[NLAYR]

    maxSoilTemp = array('f', [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES))
    minSoilTemp = array('f', [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES))
    aveSoilTemp = array('f', [0.0]*(NLAYR + 1 + NUM_PHANTOM_NODES))
    volSpecHeatSoil = array('f', [0.0]*(numNodes + 1))
    soilTemp = array('f', [0.0]*(numNodes + 1 + 1))
    morningSoilTemp = array('f', [0.0]*(numNodes + 1 + 1))
    tempNew = array('f', [0.0]*(numNodes + 1 + 1))
    thermalConductivity = array('f', [0.0]*(numNodes + 1))
    heatStorage = array('f', [0.0]*(numNodes + 1))
    thermalConductance = array('f', [0.0]*(numNodes + 1 + 1))

    thermCondPar1,thermCondPar2,thermCondPar3,thermCondPar4 = doThermalConductivityCoeffs(NLAYR, numNodes, bulkDensity, clay)
    soilTemp = CalcSoilTemp(soilTemp, thickness, TAV, TAMP, DOY, XLAT)
    #tempNew = list(soilTemp)

    InitialValues = array('f', [0.0]*(NLAYR))
    InitialValues = list(soilTemp[TOPSOILnode:TOPSOILnode + NLAYR])

    ave_temp = (TMAX + TMIN) * 0.5
    surfaceT = (1.0 - SALB) * (ave_temp + (TMAX - ave_temp) * math.sqrt(max(SRAD, 0.1) * 23.8846 / 800.0)) + SALB * ave_temp
    soilTemp[SURFACEnode] = surfaceT

    for i in range(numNodes + 1, len(soilTemp)):
        soilTemp[i] = TAV

    #np.copyto(tempNew, soilTemp)

    minTempYesterday = TMIN
    maxTempYesterday = TMAX



def doThermalConductivityCoeffs(nbLayers:int, 
                                numNodes:int,
                                bulkDensity: 'Array[float]',
                                 clay: 'Array[float]'):

    thermCondPar1 = array('f', [0.0]*(numNodes + 1))
    thermCondPar2 = array('f', [0.0]*(numNodes + 1))
    thermCondPar3 = array('f', [0.0]*(numNodes + 1))
    thermCondPar4 = array('f', [0.0]*(numNodes + 1))

    for layer in range(1, nbLayers + 2):
        element = layer
        thermCondPar1[element] = 0.65 - 0.78 * bulkDensity[layer] + 0.6 * bulkDensity[layer] ** 2
        thermCondPar2[element] = 1.06 * bulkDensity[layer]
        thermCondPar3[element] = 1.0 + Divide(2.6, math.sqrt(clay[layer], 0))
        thermCondPar4[element] = 0.03 + 0.1 * bulkDensity[layer] ** 2

        return thermCondPar1,thermCondPar2,thermCondPar3,thermCondPar4


def CalcSoilTemp(soilTempIO: 'Array[float]',
                 thickness: 'Array[float]',
                tav:float,
                tamp:float, 
                doy:int, 
                latitude:float):

    cumulativeDepth = array('f', [0.0]*(len(thickness)))
    if len(thickness) > 0:
        cumulativeDepth[0] = thickness[0]
        for Layer in range(1, len(thickness)):
            cumulativeDepth[Layer] = thickness[Layer] + cumulativeDepth[Layer - 1]

    w = 2 * math.pi / (365.25 * 24 * 3600)
    dh = 0.6
    zd = math.sqrt(2 * dh / w)
    offset = 0.25
    if latitude > 0.0:
        offset = -0.25

    soilTemp = array('f', [0.0]*(numNodes + 2))
    for nodes in range(1, numNodes + 1):
        soilTemp[nodes] = tav + tamp * math.exp(-1 * cumulativeDepth[nodes] / zd) * math.sin((doy / 365.0 + offset) * 
                                                                                             2.0 * math.pi - cumulativeDepth[nodes] / zd)

    soilTempIO[SURFACEnode:SURFACEnode + numNodes] = soilTemp[0:numNodes]
    return soilTempIO


def Divide(val1, val2, errVal):
    returnValue = val1 / val2
    if isinf(returnValue) or isnan(returnValue):    
        return errVal
    return returnValue
