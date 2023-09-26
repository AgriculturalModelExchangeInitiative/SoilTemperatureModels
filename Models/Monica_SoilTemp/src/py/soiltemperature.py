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
         soilAlbedo:float,
         noOfTempLayers:int,
         noOfSoilLayers:int,
         layerThickness:List[float],
         soilBulkDensity:List[float],
         saturation:List[float],
         soilOrganicMatter:List[float]):
    soilSurfaceTemperature:float = 0.0
    soilTemperature:List[float] = []
    V:List[float] = []
    B:List[float] = []
    volumeMatrix:List[float] = []
    volumeMatrixOld:List[float] = []
    matrixPrimaryDiagonal:List[float] = []
    matrixSecondaryDiagonal:List[float] = []
    heatConductivity:List[float] = []
    heatConductivityMean:List[float] = []
    heatCapacity:List[float] = []
    solution:List[float] = []
    matrixDiagonal:List[float] = []
    matrixLowerTriangle:List[float] = []
    heatFlow:List[float] = []
    soilTemperature = []
    V = []
    B = []
    volumeMatrix = []
    volumeMatrixOld = []
    matrixPrimaryDiagonal = []
    matrixSecondaryDiagonal = []
    heatConductivity = []
    heatConductivityMean = []
    heatCapacity = []
    solution = []
    matrixDiagonal = []
    matrixLowerTriangle = []
    heatFlow = []
    soilNols:int
    soilNols = noOfSoilLayers
    i:int
    for i in range(0 , soilNols , 1):
        soilTemperature[i] = (1.0 - (float(i) / soilNols)) * initialSurfaceTemp + (float(i) / soilNols * baseTemp)
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
         soilAlbedo:float,
         noOfTempLayers:int,
         noOfSoilLayers:int,
         layerThickness:List[float],
         soilBulkDensity:List[float],
         saturation:List[float],
         soilOrganicMatter:List[float],
         soilTemperature:List[float],
         V:List[float],
         B:List[float],
         volumeMatrix:List[float],
         volumeMatrixOld:List[float],
         matrixPrimaryDiagonal:List[float],
         matrixSecondaryDiagonal:List[float],
         heatConductivity:List[float],
         heatConductivityMean:List[float],
         heatCapacity:List[float],
         solution:List[float],
         matrixDiagonal:List[float],
         matrixLowerTriangle:List[float],
         heatFlow:List[float]):
    newSoilTemperature:List[float] = []
    groundLayer:int
    bottomLayer:int
    groundLayer = noOfTempLayers - 2
    bottomLayer = noOfTempLayers - 1
    heatFlow[0] = soilSurfaceTemperature * B[0] * heatConductivityMean[0]
    i:int
    for i in range(0 , noOfTempLayers , 1):
        solution[i] = (volumeMatrixOld[i] + ((volumeMatrix[i] - volumeMatrixOld[i]) / layerThickness[i])) * soilTemperature[i] + heatFlow[i]
    matrixDiagonal[0] = matrixPrimaryDiagonal[0]
    for i in range(0 , noOfTempLayers , 1):
        matrixLowerTriangle[i] = matrixSecondaryDiagonal[i] / matrixDiagonal[(i - 1)]
        matrixDiagonal[i] = matrixPrimaryDiagonal[i] - (matrixLowerTriangle[i] * matrixSecondaryDiagonal[i])
    for i in range(0 , noOfTempLayers , 1):
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
        newSoilTemperature[i] = soilTemperature[i]
    volumeMatrixOld[groundLayer] = volumeMatrix[groundLayer]
    volumeMatrixOld[bottomLayer] = volumeMatrix[bottomLayer]
    return newSoilTemperature