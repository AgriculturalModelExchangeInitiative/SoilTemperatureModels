# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Init Begin%%
def init_soiltemperature(timeStep:float,
         soilMoistureConst:float,
         baseTemp:float,
         initialSurfaceTemp:float,
         densityAir:float,
         specificHeatCapacityAir:float,
         densityHumus:float,
         specificHeatCapacityHumus:float,
         densityWater:float,
         specificHeatCapacityWater:float,
         quartzRawDensity:float,
         specificHeatCapacityQuartz:float,
         nTau:float,
         noOfTempLayers:int,
         noOfSoilLayers:int,
         layerThickness:'Array[float]',
         soilBulkDensity:'Array[float]',
         saturation:'Array[float]',
         soilOrganicMatter:'Array[float]'):
    soilSurfaceTemperature:float = 0.0
    soilTemperature:'array[float]' = array('f',[0.0]*22)
    V:'array[float]' = array('f',[0.0]*22)
    B:'array[float]' = array('f',[0.0]*22)
    volumeMatrix:'array[float]' = array('f',[0.0]*22)
    volumeMatrixOld:'array[float]' = array('f',[0.0]*22)
    matrixPrimaryDiagonal:'array[float]' = array('f',[0.0]*22)
    matrixSecondaryDiagonal:'array[float]' = array('f',[0.0]*23)
    heatConductivity:'array[float]' = array('f',[0.0]*22)
    heatConductivityMean:'array[float]' = array('f',[0.0]*22)
    heatCapacity:'array[float]' = array('f',[0.0]*22)
    solution:'array[float]' = array('f',[0.0]*22)
    matrixDiagonal:'array[float]' = array('f',[0.0]*22)
    matrixLowerTriangle:'array[float]' = array('f',[0.0]*22)
    heatFlow:'array[float]' = array('f',[0.0]*22)
    soilTemperature = array('f', [0.0]*22)
    V = array('f', [0.0]*22)
    B = array('f', [0.0]*22)
    volumeMatrix = array('f', [0.0]*22)
    volumeMatrixOld = array('f', [0.0]*22)
    matrixPrimaryDiagonal = array('f', [0.0]*22)
    matrixSecondaryDiagonal = array('f', [0.0]*23)
    heatConductivity = array('f', [0.0]*22)
    heatConductivityMean = array('f', [0.0]*22)
    heatCapacity = array('f', [0.0]*22)
    solution = array('f', [0.0]*22)
    matrixDiagonal = array('f', [0.0]*22)
    matrixLowerTriangle = array('f', [0.0]*22)
    heatFlow = array('f', [0.0]*22)
    soilTemperature = array("f", [0] * noOfTempLayers)
    V = array("f", [0] * noOfTempLayers)
    volumeMatrix = array("f", [0] * noOfTempLayers)
    volumeMatrixOld = array("f", [0] * noOfTempLayers)
    B = array("f", [0] * noOfTempLayers)
    matrixPrimaryDiagonal = array("f", [0] * noOfTempLayers)
    matrixSecondaryDiagonal = array("f", [0] * (noOfTempLayers + 1))
    heatConductivity = array("f", [0] * noOfTempLayers)
    heatConductivityMean = array("f", [0] * noOfTempLayers)
    heatCapacity = array("f", [0] * noOfTempLayers)
    solution = array("f", [0] * noOfTempLayers)
    matrixDiagonal = array("f", [0] * noOfTempLayers)
    matrixLowerTriangle = array("f", [0] * noOfTempLayers)
    heatFlow = array("f", [0] * noOfTempLayers)
    i:int
    for i in range(0 , noOfSoilLayers , 1):
        soilTemperature[i] = (1.0 - (float(i) / noOfSoilLayers)) * initialSurfaceTemp + (float(i) / noOfSoilLayers * baseTemp)
    groundLayer:int
    groundLayer = noOfTempLayers - 2
    bottomLayer:int
    bottomLayer = noOfTempLayers - 1
    layerThickness[groundLayer] = 2.0 * layerThickness[(groundLayer - 1)]
    layerThickness[bottomLayer] = 1.0
    soilTemperature[groundLayer] = (soilTemperature[groundLayer - 1] + baseTemp) * 0.5
    soilTemperature[bottomLayer] = baseTemp
    V[0] = layerThickness[0]
    B[0] = 2.0 / layerThickness[0]
    lti_1:float
    lti:float
    for i in range(1 , noOfTempLayers , 1):
        lti_1 = layerThickness[i - 1]
        lti = layerThickness[i]
        B[i] = 2.0 / (lti + lti_1)
        V[i] = lti * nTau
    ts:float
    ts = timeStep
    dw:float
    dw = densityWater
    cw:float
    cw = specificHeatCapacityWater
    dq:float
    dq = quartzRawDensity
    cq:float
    cq = specificHeatCapacityQuartz
    da:float
    da = densityAir
    ca:float
    ca = specificHeatCapacityAir
    dh:float
    dh = densityHumus
    ch:float
    ch = specificHeatCapacityHumus
    sbdi:float
    smi:float
    sati:float
    somi:float
    for i in range(0 , noOfSoilLayers , 1):
        sbdi = soilBulkDensity[i]
        smi = soilMoistureConst
        heatConductivity[i] = (3.0 * (sbdi / 1000.0) - 1.7) * 0.001 / (1.0 + ((11.5 - (5.0 * (sbdi / 1000.0))) * exp(-50.0 * pow(smi / (sbdi / 1000.0), 1.5)))) * 86400.0 * ts * 100.0 * 4.184
        sati = saturation[i]
        somi = soilOrganicMatter[i] / da * sbdi
        heatCapacity[i] = smi * dw * cw + ((sati - smi) * da * ca) + (somi * dh * ch) + ((1.0 - sati - somi) * dq * cq)
    heatCapacity[groundLayer] = heatCapacity[groundLayer - 1]
    heatCapacity[bottomLayer] = heatCapacity[groundLayer]
    heatConductivity[groundLayer] = heatConductivity[groundLayer - 1]
    heatConductivity[bottomLayer] = heatConductivity[groundLayer]
    soilSurfaceTemperature = initialSurfaceTemp
    heatConductivityMean[0] = heatConductivity[0]
    hci_1:float
    hci:float
    for i in range(1 , noOfTempLayers , 1):
        lti_1 = layerThickness[i - 1]
        lti = layerThickness[i]
        hci_1 = heatConductivity[i - 1]
        hci = heatConductivity[i]
        heatConductivityMean[i] = (lti_1 * hci_1 + (lti * hci)) / (lti + lti_1)
    for i in range(0 , noOfTempLayers , 1):
        volumeMatrix[i] = V[i] * heatCapacity[i]
        volumeMatrixOld[i] = volumeMatrix[i]
        matrixSecondaryDiagonal[i] = -B[i] * heatConductivityMean[i]
    matrixSecondaryDiagonal[bottomLayer + 1] = 0.0
    for i in range(0 , noOfTempLayers , 1):
        matrixPrimaryDiagonal[i] = volumeMatrix[i] - matrixSecondaryDiagonal[i] - matrixSecondaryDiagonal[i + 1]
    return (soilSurfaceTemperature, soilTemperature, V, B, volumeMatrix, volumeMatrixOld, matrixPrimaryDiagonal, matrixSecondaryDiagonal, heatConductivity, heatConductivityMean, heatCapacity, solution, matrixDiagonal, matrixLowerTriangle, heatFlow)
#%%CyML Init End%%

def model_soiltemperature(soilSurfaceTemperature:float,
         timeStep:float,
         soilMoistureConst:float,
         baseTemp:float,
         initialSurfaceTemp:float,
         densityAir:float,
         specificHeatCapacityAir:float,
         densityHumus:float,
         specificHeatCapacityHumus:float,
         densityWater:float,
         specificHeatCapacityWater:float,
         quartzRawDensity:float,
         specificHeatCapacityQuartz:float,
         nTau:float,
         noOfTempLayers:int,
         noOfSoilLayers:int,
         layerThickness:'Array[float]',
         soilBulkDensity:'Array[float]',
         saturation:'Array[float]',
         soilOrganicMatter:'Array[float]',
         soilTemperature:'Array[float]',
         V:'Array[float]',
         B:'Array[float]',
         volumeMatrix:'Array[float]',
         volumeMatrixOld:'Array[float]',
         matrixPrimaryDiagonal:'Array[float]',
         matrixSecondaryDiagonal:'Array[float]',
         heatConductivity:'Array[float]',
         heatConductivityMean:'Array[float]',
         heatCapacity:'Array[float]',
         solution:'Array[float]',
         matrixDiagonal:'Array[float]',
         matrixLowerTriangle:'Array[float]',
         heatFlow:'Array[float]'):
    groundLayer:int
    bottomLayer:int
    groundLayer = noOfTempLayers - 2
    bottomLayer = noOfTempLayers - 1
    heatFlow[0] = soilSurfaceTemperature * B[0] * heatConductivityMean[0]
    i:int
    for i in range(0 , noOfTempLayers , 1):
        solution[i] = (volumeMatrixOld[i] + ((volumeMatrix[i] - volumeMatrixOld[i]) / layerThickness[i])) * soilTemperature[i] + heatFlow[i]
    matrixDiagonal[0] = matrixPrimaryDiagonal[0]
    for i in range(1 , noOfTempLayers , 1):
        matrixLowerTriangle[i] = matrixSecondaryDiagonal[i] / matrixDiagonal[(i - 1)]
        matrixDiagonal[i] = matrixPrimaryDiagonal[i] - (matrixLowerTriangle[i] * matrixSecondaryDiagonal[i])
    for i in range(1 , noOfTempLayers , 1):
        solution[i] = solution[i] - (matrixLowerTriangle[i] * solution[(i - 1)])
    solution[bottomLayer] = solution[bottomLayer] / matrixDiagonal[bottomLayer]
    j:int
    j_1:int
    for i in range(0 , bottomLayer , 1):
        j = bottomLayer - 1 - i
        j_1 = j + 1
        solution[j] = solution[j] / matrixDiagonal[j] - (matrixLowerTriangle[j_1] * solution[j_1])
    for i in range(0 , noOfTempLayers , 1):
        soilTemperature[i] = solution[i]
    for i in range(0 , noOfSoilLayers , 1):
        volumeMatrixOld[i] = volumeMatrix[i]
    volumeMatrixOld[groundLayer] = volumeMatrix[groundLayer]
    volumeMatrixOld[bottomLayer] = volumeMatrix[bottomLayer]
    return soilTemperature