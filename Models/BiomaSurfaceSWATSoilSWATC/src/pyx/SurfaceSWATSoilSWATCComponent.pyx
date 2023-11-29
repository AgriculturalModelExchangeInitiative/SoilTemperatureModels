from datetime import datetime
from math import *
from BiomaSurfaceSWATSoilSWATC.surfacetemperatureswat import model_surfacetemperatureswat
from BiomaSurfaceSWATSoilSWATC.soiltemperatureswat import model_soiltemperatureswat
def model_surfaceswatsoilswatc(float AboveGroundBiomass,
      float Albedo,
      float AirTemperatureMinimum,
      float WaterEquivalentOfSnowPack,
      float GlobalSolarRadiation,
      float AirTemperatureMaximum,
      float AirTemperatureAnnualAverage,
      float SoilProfileDepth,
      float BulkDensity[],
      float VolumetricWaterContent[],
      float LayerThickness[],
      float LagCoefficient):
    cdef float SoilTemperatureByLayers[]
    cdef float SurfaceSoilTemperature
    SurfaceSoilTemperature = model_surfacetemperatureswat(GlobalSolarRadiation,SoilTemperatureByLayers,AirTemperatureMaximum,AirTemperatureMinimum,Albedo,AboveGroundBiomass,WaterEquivalentOfSnowPack)
    SoilTemperatureByLayers = model_soiltemperatureswat(VolumetricWaterContent,SurfaceSoilTemperature,LayerThickness,LagCoefficient,SoilTemperatureByLayers,AirTemperatureAnnualAverage,BulkDensity,SoilProfileDepth)

    return SurfaceSoilTemperature, SoilTemperatureByLayers