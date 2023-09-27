from datetime import datetime
from math import *
from Monica_SoilTemp.soiltemperature import model_soiltemperature
from Monica_SoilTemp.nosnowsoilsurfacetemperature import model_nosnowsoilsurfacetemperature
from Monica_SoilTemp.withsnowsoilsurfacetemperature import model_withsnowsoilsurfacetemperature
def model_soiltemperaturecomp(float tmin,
      float tmax,
      float globrad,
      float dampingFactor,
      float soilCoverage,
      float prevDaySoilSurfaceTemperature,
      float soilSurfaceTemperatureBelowSnow,
      bool hasSnowCover,
      float timeStep,
      float soilMoistureConst,
      float baseTemp,
      float initialSurfaceTemp,
      float densityAir,
      float specificHeatCapacityAir,
      float densityHumus,
      float specificHeatCapacityHumus,
      float densityWater,
      float specificHeatCapacityWater,
      float quartzRawDensity,
      float specificHeatCapacityQuartz,
      float nTau,
      int noOfTempLayers,
      int noOfSoilLayers,
      float layerThickness[22],
      float soilBulkDensity[20],
      float saturation[20],
      float soilOrganicMatter[20],
      float prevDaySoilTemperature[22],
      float V[22],
      float B[22],
      float volumeMatrix[22],
      float volumeMatrixOld[22],
      float matrixPrimaryDiagonal[22],
      float matrixSecondaryDiagonal[23],
      float heatConductivity[22],
      float heatConductivityMean[22],
      float heatCapacity[22],
      float solution[22],
      float matrixDiagonal[22],
      float matrixLowerTriangle[22],
      float heatFlow[22]):
    cdef float soilSurfaceTemperature
    cdef float soilTemperature[22]
    cdef float noSnowSoilSurfaceTemperature
    soilTemperature = prevDaySoilTemperature 
    soilSurfaceTemperature = model_nosnowsoilsurfacetemperature(tmin,tmax,globrad,soilCoverage,dampingFactor,prevDaySoilSurfaceTemperature)
    noSnowSoilSurfaceTemperature = soilSurfaceTemperature
    soilSurfaceTemperature = model_withsnowsoilsurfacetemperature(noSnowSoilSurfaceTemperature,soilSurfaceTemperatureBelowSnow,hasSnowCover)
    soilTemperature = model_soiltemperature(soilSurfaceTemperature,timeStep,soilMoistureConst,baseTemp,initialSurfaceTemp,densityAir,specificHeatCapacityAir,densityHumus,specificHeatCapacityHumus,densityWater,specificHeatCapacityWater,quartzRawDensity,specificHeatCapacityQuartz,nTau,noOfTempLayers,noOfSoilLayers,layerThickness,soilBulkDensity,saturation,soilOrganicMatter,soilTemperature,V,B,volumeMatrix,volumeMatrixOld,matrixPrimaryDiagonal,matrixSecondaryDiagonal,heatConductivity,heatConductivityMean,heatCapacity,solution,matrixDiagonal,matrixLowerTriangle,heatFlow)

    return soilSurfaceTemperature, soilTemperature