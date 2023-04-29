from datetime import datetime
from math import *
from BiomaSurfacePartonSoilSWATHourlyPartonC.surfacetemperatureparton import model_surfacetemperatureparton
from BiomaSurfacePartonSoilSWATHourlyPartonC.soiltemperatureswat import model_soiltemperatureswat
from BiomaSurfacePartonSoilSWATHourlyPartonC.volumetricheatcapacitykluitenberg import model_volumetricheatcapacitykluitenberg
from BiomaSurfacePartonSoilSWATHourlyPartonC.thermalconductivitysimulat import model_thermalconductivitysimulat
from BiomaSurfacePartonSoilSWATHourlyPartonC.thermaldiffu import model_thermaldiffu
from BiomaSurfacePartonSoilSWATHourlyPartonC.rangeofsoiltemperaturesdaycent import model_rangeofsoiltemperaturesdaycent
from BiomaSurfacePartonSoilSWATHourlyPartonC.hourlysoiltemperaturespartonlogan import model_hourlysoiltemperaturespartonlogan
def model_surfacepartonsoilswathourlypartonc(float GlobalSolarRadiation,
      float DayLength,
      float AboveGroundBiomass,
      float AirTemperatureMinimum,
      float AirTemperatureMaximum,
      float VolumetricWaterContent[],
      float BulkDensity[],
      float LayerThickness[],
      float LagCoefficient,
      float AirTemperatureAnnualAverage,
      float SoilProfileDepth,
      float Sand[],
      float OrganicMatter[],
      float Clay[],
      float Silt[],
      float HourOfSunrise,
      float HourOfSunset):
    cdef float SurfaceSoilTemperature
    cdef float SurfaceTemperatureMinimum
    cdef float SurfaceTemperatureMaximum
    cdef float SoilTemperatureByLayers[]
    cdef float HeatCapacity[]
    cdef float ThermalConductivity[]
    cdef float ThermalDiffusivity[]
    cdef float SoilTemperatureRangeByLayers[]
    cdef float SoilTemperatureMinimum[]
    cdef float SoilTemperatureMaximum[]
    cdef float SoilTemperatureByLayersHourly[]
    SurfaceSoilTemperature, SurfaceTemperatureMinimum, SurfaceTemperatureMaximum = model_surfacetemperatureparton( GlobalSolarRadiation,DayLength,AboveGroundBiomass,AirTemperatureMinimum,AirTemperatureMaximum)
    HeatCapacity = model_volumetricheatcapacitykluitenberg( VolumetricWaterContent,Sand,BulkDensity,OrganicMatter,HeatCapacity,Clay,Silt)
    ThermalConductivity = model_thermalconductivitysimulat( VolumetricWaterContent,BulkDensity,Clay)
    SoilTemperatureByLayers = model_soiltemperatureswat( VolumetricWaterContent,SurfaceSoilTemperature,BulkDensity,LayerThickness,LagCoefficient,SoilTemperatureByLayers,AirTemperatureAnnualAverage,SoilProfileDepth)
    ThermalDiffusivity = model_thermaldiffu( ThermalDiffusivity,ThermalConductivity,HeatCapacity)
    SoilTemperatureRangeByLayers, SoilTemperatureMinimum, SoilTemperatureMaximum = model_rangeofsoiltemperaturesdaycent( LayerThickness,SurfaceTemperatureMinimum,ThermalDiffusivity,SoilTemperatureByLayers,SurfaceTemperatureMaximum)
    SoilTemperatureByLayersHourly = model_hourlysoiltemperaturespartonlogan( SoilTemperatureByLayersHourly,HourOfSunrise,HourOfSunset,DayLength,SoilTemperatureMinimum,SoilTemperatureMaximum)
    return SurfaceSoilTemperature, SurfaceTemperatureMinimum, SurfaceTemperatureMaximum, SoilTemperatureByLayers, HeatCapacity, ThermalConductivity, ThermalDiffusivity, SoilTemperatureRangeByLayers, SoilTemperatureMinimum, SoilTemperatureMaximum, SoilTemperatureByLayersHourly