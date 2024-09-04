import numpy as np

def init_campbell(nbLayers, thick, bd, tmax, tmin, cla, sw, dpth, tav, tamp, doy, canopHeight, SALB, rad, XLAT, AltitudeMetres):
    SALB = SALB
    canopyHeight = max(canopyHeight, soilRoughnessHeight) * 0.001
    airPressure = 101325.0 * (1.0 - 2.25577e-5 * AltitudeMetres) ** 5.25588 * 0.01
    numLayers = nbLayers
    numNodes = nbLayers + NUM_PHANTOM_NODES

    thickness = array('f', [0.0]*(numLayers + 1 + NUM_PHANTOM_NODES))
    thickness[:len(thick)] = thick
    sumThickness = sum(thickness[1:numLayers + 1])
    BelowProfileDepth = max(CONSTANT_TEMPdepth * 1000.0 - sumThickness, 1.0 * 1000.0)

    thicknessForPhantomNodes = BelowProfileDepth * 2.0 / NUM_PHANTOM_NODES
    firstPhantomNode = numLayers
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
    bulkDensity = array('f', [0.0]*(numLayers + 1 + NUM_PHANTOM_NODES)
    bulkDensity[:min(numLayers + 1 + NUM_PHANTOM_NODES, len(bd))] = bd
    bulkDensity[numNodes - 1] = bulkDensity[numLayers]
    for layer in range(numLayers + 1, numLayers + NUM_PHANTOM_NODES):
        bulkDensity[layer] = bulkDensity[numLayers]

    # Soil Water
    soilWater = array('f', [0.0]*(numLayers + 1 + NUM_PHANTOM_NODES)
    soilWater[:min(numLayers + 1 + NUM_PHANTOM_NODES, len(sw))] = sw
    for layer in range(numLayers + 1, numLayers + NUM_PHANTOM_NODES):
        soilWater[layer] = soilWater[numLayers]

    # Clay
    clay = array('f', [0.0]*(numLayers + 1 + NUM_PHANTOM_NODES)
    for layer in range(1, numLayers + 1):
        clay[layer] = cla[layer - 1]
    for layer in range(numLayers + 1, numLayers + NUM_PHANTOM_NODES):
        clay[layer] = clay[numLayers]

    maxSoilTemp = array('f', [0.0]*(numLayers + 1 + NUM_PHANTOM_NODES))
    minSoilTemp = array('f', [0.0]*(numLayers + 1 + NUM_PHANTOM_NODES))
    aveSoilTemp = array('f', [0.0]*(numLayers + 1 + NUM_PHANTOM_NODES))
    volSpecHeatSoil = array('f', [0.0]*(numNodes + 1))
    soilTemp = array('f', [0.0]*(numNodes + 1 + 1))
    morningSoilTemp = array('f', [0.0]*(numNodes + 1 + 1))
    tempNew = array('f', [0.0]*(numNodes + 1 + 1))
    thermalConductivity = array('f', [0.0]*(numNodes + 1))
    heatStorage = array('f', [0.0]*(numNodes + 1))
    thermalConductance = array('f', [0.0]*(numNodes + 1 + 1))

    doThermalConductivityCoeffs(nbLayers)
    latitude = XLAT
    CalcSoilTemp(tav, tamp, doy, latitude)
    np.copyto(tempNew, soilTemp)

    InitialValues = array('f', [0.0]*(numLayers))
    np.copyto(InitialValues, soilTemp[TOPSOILnode:TOPSOILnode + numLayers])

    ave_temp = (tmax + tmin) * 0.5
    surfaceT = (1.0 - albedo) * (ave_temp + (tmax - ave_temp) * np.sqrt(max(rad, 0.1) * 23.8846 / 800.0)) + albedo * ave_temp
    soilTemp[SURFACEnode] = surfaceT

    for i in range(numNodes + 1, len(soilTemp)):
        soilTemp[i] = tav

    np.copyto(tempNew, soilTemp)

    minTempYesterday = tmin
    maxTempYesterday = tmax



def doThermalConductivityCoeffs(nbLayers):

    thermCondPar1 = array('f', [0.0]*(numNodes + 1))
    thermCondPar2 = array('f', [0.0]*(numNodes + 1))
    thermCondPar3 = array('f', [0.0]*(numNodes + 1))
    thermCondPar4 = array('f', [0.0]*(numNodes + 1))

    for layer in range(1, int(nbLayers) + 2):
        element = layer
        thermCondPar1[element] = 0.65 - 0.78 * bulkDensity[layer] + 0.6 * bulkDensity[layer] ** 2
        thermCondPar2[element] = 1.06 * bulkDensity[layer]
        thermCondPar3[element] = 1.0 + Divide(2.6, np.sqrt(clay[layer], 0)
        thermCondPar4[element] = 0.03 + 0.1 * bulkDensity[layer] ** 2

def Divide(val1, val2, errVal):
    returnValue = val1 / val2
    if math.isinf(returnValue) or math.isnan(returnValue):    
        return errVal
    return returnValue
