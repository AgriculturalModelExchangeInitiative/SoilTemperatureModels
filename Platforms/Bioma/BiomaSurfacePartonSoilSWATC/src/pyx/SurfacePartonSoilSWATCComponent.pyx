from datetime import datetime
from math import *
from BiomaSurfacePartonSoilSWATC.surfacetemperatureparton import model_surfacetemperatureparton
from BiomaSurfacePartonSoilSWATC.soiltemperatureswat import model_soiltemperatureswat
def model_surfacepartonsoilswatc(float GlobalSolarRadiation,
      float AboveGroundBiomass,
      float AirTemperatureMaximum,
      float AirTemperatureMinimum,
      float DayLength,
      float AirTemperatureAnnualAverage,
      float SoilProfileDepth,
      float LagCoefficient,
      float BulkDensity[],
      float VolumetricWaterContent[],
      float LayerThickness[]):
    cdef float SurfaceTemperatureMaximum
    cdef float SurfaceTemperatureMinimum
    cdef float SurfaceSoilTemperature
    cdef float SoilTemperatureByLayers[]
    SurfaceTemperatureMaximum, SurfaceTemperatureMinimum, SurfaceSoilTemperature = model_surfacetemperatureparton( SurfaceTemperatureMaximum,GlobalSolarRadiation,SurfaceTemperatureMinimum,AboveGroundBiomass,AirTemperatureMinimum,AirTemperatureMaximum,DayLength)
    SoilTemperatureByLayers = model_soiltemperatureswat( SoilTemperatureByLayers,SurfaceSoilTemperature,AirTemperatureAnnualAverage,SoilProfileDepth,LagCoefficient,BulkDensity,VolumetricWaterContent,LayerThickness)
    return SurfaceTemperatureMaximum, SurfaceTemperatureMinimum, SurfaceSoilTemperature, SoilTemperatureByLayers