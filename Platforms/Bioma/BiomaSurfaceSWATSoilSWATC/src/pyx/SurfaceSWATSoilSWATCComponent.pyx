from datetime import datetime
from math import *
from BiomaSurfaceSWATSoilSWATC.surfacetemperatureswat import model_surfacetemperatureswat
from BiomaSurfaceSWATSoilSWATC.soiltemperatureswat import model_soiltemperatureswat
def model_surfaceswatsoilswatc(float AirTemperatureMinimum,
      float GlobalSolarRadiation,
      float AboveGroundBiomass,
      float WaterEquivalentOfSnowPack,
      float AirTemperatureMaximum,
      float Albedo,
      float AirTemperatureAnnualAverage,
      float VolumetricWaterContent[],
      float BulkDensity[],
      float SoilProfileDepth,
      float LayerThickness[],
      float LagCoefficient):
    cdef float SoilTemperatureByLayers[]
    cdef float SurfaceSoilTemperature
    SurfaceSoilTemperature = model_surfacetemperatureswat( AirTemperatureMinimum,GlobalSolarRadiation,SoilTemperatureByLayers,AboveGroundBiomass,WaterEquivalentOfSnowPack,AirTemperatureMaximum,Albedo)
    SoilTemperatureByLayers = model_soiltemperatureswat( SoilTemperatureByLayers,AirTemperatureAnnualAverage,VolumetricWaterContent,BulkDensity,SoilProfileDepth,LayerThickness,LagCoefficient,SurfaceSoilTemperature)
    return SurfaceSoilTemperature, SoilTemperatureByLayers