from datetime import datetime
from math import *
from BiomaSurfacePartonSoilSWATC.surfacetemperatureparton import model_surfacetemperatureparton
from BiomaSurfacePartonSoilSWATC.soiltemperatureswat import model_soiltemperatureswat
def model_surfacepartonsoilswatc(float GlobalSolarRadiation,
      float AirTemperatureMinimum,
      float DayLength,
      float AboveGroundBiomass,
      float AirTemperatureMaximum,
      float LayerThickness[],
      float VolumetricWaterContent[],
      float SoilProfileDepth,
      float AirTemperatureAnnualAverage,
      float LagCoefficient,
      float BulkDensity[]):
    cdef float SurfaceTemperatureMaximum
    cdef float SurfaceTemperatureMinimum
    cdef float SurfaceSoilTemperature
    cdef float SoilTemperatureByLayers[]
    SurfaceSoilTemperature, SurfaceTemperatureMaximum, SurfaceTemperatureMinimum = model_surfacetemperatureparton( AboveGroundBiomass,GlobalSolarRadiation,AirTemperatureMinimum,SurfaceTemperatureMaximum,DayLength,SurfaceTemperatureMinimum,AirTemperatureMaximum)
    SoilTemperatureByLayers = model_soiltemperatureswat( LayerThickness,VolumetricWaterContent,SurfaceSoilTemperature,SoilProfileDepth,AirTemperatureAnnualAverage,LagCoefficient,SoilTemperatureByLayers,BulkDensity)
    return SurfaceSoilTemperature, SurfaceTemperatureMaximum, SurfaceTemperatureMinimum, SoilTemperatureByLayers