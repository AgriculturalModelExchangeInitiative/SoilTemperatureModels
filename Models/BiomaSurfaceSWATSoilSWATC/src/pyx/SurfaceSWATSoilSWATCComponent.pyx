from datetime import datetime
from math import *
from BiomaSurfaceSWATSoilSWATC.surfacetemperatureswat import model_surfacetemperatureswat
from BiomaSurfaceSWATSoilSWATC.soiltemperatureswat import model_soiltemperatureswat
def model_surfaceswatsoilswatc(float GlobalSolarRadiation,
      float AirTemperatureMaximum,
      float AirTemperatureMinimum,
      float Albedo,
      float AboveGroundBiomass,
      float WaterEquivalentOfSnowPack,
      float LagCoefficient,
      float AirTemperatureAnnualAverage,
      float BulkDensity[],
      float LayerThickness[],
      float VolumetricWaterContent[],
      float SoilProfileDepth):
    cdef float SoilTemperatureByLayers[]
    cdef float SurfaceSoilTemperature
    SurfaceSoilTemperature = model_surfacetemperatureswat( GlobalSolarRadiation,SoilTemperatureByLayers,AirTemperatureMaximum,AirTemperatureMinimum,Albedo,AboveGroundBiomass,WaterEquivalentOfSnowPack)
    SoilTemperatureByLayers = model_soiltemperatureswat( SoilTemperatureByLayers,LagCoefficient,AirTemperatureAnnualAverage,BulkDensity,LayerThickness,VolumetricWaterContent,SoilProfileDepth,SurfaceSoilTemperature)
    return SurfaceSoilTemperature, SoilTemperatureByLayers