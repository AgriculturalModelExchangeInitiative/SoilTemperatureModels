from datetime import datetime
from math import *
from BiomaSurfacePartonSoilSWATC.surfacetemperatureparton import model_surfacetemperatureparton
from BiomaSurfacePartonSoilSWATC.soiltemperatureswat import model_soiltemperatureswat
def model_surfacepartonsoilswatc(float AirTemperatureMinimum,
      float AirTemperatureMaximum,
      float AboveGroundBiomass,
      float DayLength,
      float GlobalSolarRadiation,
      float SoilProfileDepth,
      float AirTemperatureAnnualAverage,
      float BulkDensity[],
      float LayerThickness[],
      float LagCoefficient,
      float VolumetricWaterContent[],
      float SoilTemperatureByLayers[]):
    cdef float SurfaceTemperatureMinimum
    cdef float SurfaceTemperatureMaximum
    cdef float SurfaceSoilTemperature
    SurfaceTemperatureMinimum, SurfaceTemperatureMaximum, SurfaceSoilTemperature = model_surfacetemperatureparton(DayLength,AirTemperatureMaximum,AirTemperatureMinimum,AboveGroundBiomass,GlobalSolarRadiation)
    SoilTemperatureByLayers = model_soiltemperatureswat(VolumetricWaterContent,SurfaceSoilTemperature,LayerThickness,LagCoefficient,SoilTemperatureByLayers,AirTemperatureAnnualAverage,BulkDensity,SoilProfileDepth)

    return SurfaceTemperatureMinimum, SurfaceTemperatureMaximum, SurfaceSoilTemperature, SoilTemperatureByLayers