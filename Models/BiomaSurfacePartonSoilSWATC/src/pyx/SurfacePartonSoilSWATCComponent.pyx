from datetime import datetime
from math import *
from BiomaSurfacePartonSoilSWATC.surfacetemperatureparton import model_surfacetemperatureparton
from BiomaSurfacePartonSoilSWATC.soiltemperatureswat import model_soiltemperatureswat
def model_surfacepartonsoilswatc(float AboveGroundBiomass,
      float DayLength,
      float AirTemperatureMinimum,
      float GlobalSolarRadiation,
      float AirTemperatureMaximum,
      float BulkDensity[],
      float AirTemperatureAnnualAverage,
      float LagCoefficient,
      float LayerThickness[],
      float VolumetricWaterContent[],
      float SoilProfileDepth):
    cdef float SurfaceTemperatureMinimum
    cdef float SurfaceTemperatureMaximum
    cdef float SurfaceSoilTemperature
    cdef float SoilTemperatureByLayers[]
    SurfaceTemperatureMinimum, SurfaceTemperatureMaximum, SurfaceSoilTemperature = model_surfacetemperatureparton(DayLength,AirTemperatureMaximum,AirTemperatureMinimum,AboveGroundBiomass,GlobalSolarRadiation)
    SoilTemperatureByLayers = model_soiltemperatureswat(VolumetricWaterContent,SurfaceSoilTemperature,LayerThickness,LagCoefficient,SoilTemperatureByLayers,AirTemperatureAnnualAverage,BulkDensity,SoilProfileDepth)

    return SurfaceTemperatureMinimum, SurfaceTemperatureMaximum, SurfaceSoilTemperature, SoilTemperatureByLayers