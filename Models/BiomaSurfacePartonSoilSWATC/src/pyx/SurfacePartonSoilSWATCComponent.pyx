from datetime import datetime
from math import *
from BiomaSurfacePartonSoilSWATC.surfacetemperatureparton import model_surfacetemperatureparton
from BiomaSurfacePartonSoilSWATC.soiltemperatureswat import model_soiltemperatureswat
def model_surfacepartonsoilswatc(float DayLength,
      float AboveGroundBiomass,
      float AirTemperatureMaximum,
      float GlobalSolarRadiation,
      float AirTemperatureMinimum,
      float AirTemperatureAnnualAverage,
      float VolumetricWaterContent[],
      float BulkDensity[],
      float LayerThickness[],
      float LagCoefficient,
      float SoilProfileDepth):
    cdef float SurfaceTemperatureMinimum
    cdef float SurfaceTemperatureMaximum
    cdef float SurfaceSoilTemperature
    cdef float SoilTemperatureByLayers[]
    SurfaceTemperatureMinimum, SurfaceTemperatureMaximum, SurfaceSoilTemperature = model_surfacetemperatureparton( DayLength,AirTemperatureMaximum,AirTemperatureMinimum,AboveGroundBiomass,GlobalSolarRadiation)
    SoilTemperatureByLayers = model_soiltemperatureswat( VolumetricWaterContent,SurfaceSoilTemperature,LayerThickness,LagCoefficient,SoilTemperatureByLayers,AirTemperatureAnnualAverage,BulkDensity,SoilProfileDepth)
    return SurfaceTemperatureMinimum, SurfaceTemperatureMaximum, SurfaceSoilTemperature, SoilTemperatureByLayers