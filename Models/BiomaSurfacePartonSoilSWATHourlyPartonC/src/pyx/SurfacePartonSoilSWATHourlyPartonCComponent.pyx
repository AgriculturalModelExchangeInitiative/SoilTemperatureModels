from datetime import datetime
from math import *
from BiomaSurfacePartonSoilSWATHourlyPartonC.surfacetemperatureparton import model_surfacetemperatureparton
from BiomaSurfacePartonSoilSWATHourlyPartonC.soiltemperatureswat import model_soiltemperatureswat
from BiomaSurfacePartonSoilSWATHourlyPartonC.volumetricheatcapacitykluitenberg import model_volumetricheatcapacitykluitenberg
from BiomaSurfacePartonSoilSWATHourlyPartonC.thermalconductivitysimulat import model_thermalconductivitysimulat
from BiomaSurfacePartonSoilSWATHourlyPartonC.thermaldiffu import model_thermaldiffu
from BiomaSurfacePartonSoilSWATHourlyPartonC.rangeofsoiltemperaturesdaycent import model_rangeofsoiltemperaturesdaycent
from BiomaSurfacePartonSoilSWATHourlyPartonC.hourlysoiltemperaturespartonlogan import model_hourlysoiltemperaturespartonlogan
def model_surfacepartonsoilswathourlypartonc(float AirTemperatureMaximum,
      float GlobalSolarRadiation,
      float AirTemperatureMinimum,
      float AboveGroundBiomass,
      float DayLength,
      float BulkDensity[],
      float SoilProfileDepth,
      float AirTemperatureAnnualAverage,
      float LagCoefficient,
      float VolumetricWaterContent[],
      float LayerThickness[],
      float OrganicMatter[],
      float Clay[],
      float Sand[],
      float Silt[],
      int layersNumber,
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
    SurfaceSoilTemperature, SurfaceTemperatureMinimum, SurfaceTemperatureMaximum = model_surfacetemperatureparton(GlobalSolarRadiation,DayLength,AboveGroundBiomass,AirTemperatureMinimum,AirTemperatureMaximum)
    HeatCapacity = model_volumetricheatcapacitykluitenberg(VolumetricWaterContent,Sand,BulkDensity,OrganicMatter,HeatCapacity,Clay,Silt)
    ThermalConductivity = model_thermalconductivitysimulat(VolumetricWaterContent,BulkDensity,Clay)
    SoilTemperatureByLayers = model_soiltemperatureswat(VolumetricWaterContent,SurfaceSoilTemperature,LayerThickness,LagCoefficient,SoilTemperatureByLayers,AirTemperatureAnnualAverage,BulkDensity,SoilProfileDepth)
    ThermalDiffusivity = model_thermaldiffu(ThermalDiffusivity,ThermalConductivity,HeatCapacity,layersNumber)
    SoilTemperatureRangeByLayers, SoilTemperatureMinimum, SoilTemperatureMaximum = model_rangeofsoiltemperaturesdaycent(LayerThickness,SurfaceTemperatureMinimum,ThermalDiffusivity,SoilTemperatureByLayers,SurfaceTemperatureMaximum)
    SoilTemperatureByLayersHourly = model_hourlysoiltemperaturespartonlogan(SoilTemperatureByLayersHourly,HourOfSunrise,HourOfSunset,DayLength,SoilTemperatureMinimum,SoilTemperatureMaximum)

    return SurfaceSoilTemperature, SurfaceTemperatureMinimum, SurfaceTemperatureMaximum, SoilTemperatureByLayers, HeatCapacity, ThermalConductivity, ThermalDiffusivity, SoilTemperatureRangeByLayers, SoilTemperatureMinimum, SoilTemperatureMaximum, SoilTemperatureByLayersHourly