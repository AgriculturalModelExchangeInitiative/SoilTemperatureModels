from datetime import datetime
from math import *
from BiomaSurfaceSWATSoilSWATC.surfacetemperatureswat import model_surfacetemperatureswat
from BiomaSurfaceSWATSoilSWATC.soiltemperatureswat import model_soiltemperatureswat
def model_surfaceswatsoilswatc(float AirTemperatureMaximum,
      float AirTemperatureMinimum,
      float GlobalSolarRadiation,
      float AboveGroundBiomass,
      float WaterEquivalentOfSnowPack,
      float Albedo,
      float BulkDensity[],
      float AirTemperatureAnnualAverage,
      float VolumetricWaterContent[],
      float SoilProfileDepth,
      float LagCoefficient,
      float LayerThickness[]):
    cdef float SoilTemperatureByLayers[]
    cdef float SurfaceSoilTemperature
    SurfaceSoilTemperature = model_surfacetemperatureswat(GlobalSolarRadiation,SoilTemperatureByLayers,AirTemperatureMaximum,AirTemperatureMinimum,Albedo,AboveGroundBiomass,WaterEquivalentOfSnowPack)
    SoilTemperatureByLayers = model_soiltemperatureswat(VolumetricWaterContent,SurfaceSoilTemperature,LayerThickness,LagCoefficient,SoilTemperatureByLayers,AirTemperatureAnnualAverage,BulkDensity,SoilProfileDepth)

    return SurfaceSoilTemperature, SoilTemperatureByLayers