from datetime import datetime
from math import *
from BiomaSurfacePartonSoilSWATHourlyPartonC.surfacetemperatureparton import model_surfacetemperatureparton
from BiomaSurfacePartonSoilSWATHourlyPartonC.soiltemperatureswat import model_soiltemperatureswat
from BiomaSurfacePartonSoilSWATHourlyPartonC.volumetricheatcapacitykluitenberg import model_volumetricheatcapacitykluitenberg
from BiomaSurfacePartonSoilSWATHourlyPartonC.thermalconductivitysimulat import model_thermalconductivitysimulat
from BiomaSurfacePartonSoilSWATHourlyPartonC.thermaldiffu import model_thermaldiffu
from BiomaSurfacePartonSoilSWATHourlyPartonC.rangeofsoiltemperaturesdaycent import model_rangeofsoiltemperaturesdaycent
from BiomaSurfacePartonSoilSWATHourlyPartonC.hourlysoiltemperaturespartonlogan import model_hourlysoiltemperaturespartonlogan
def model_surfacepartonsoilswathourlypartonc(float DayLength,
      float AirTemperatureMinimum,
      float GlobalSolarRadiation,
      float AirTemperatureMaximum,
      float AboveGroundBiomass,
      float SoilProfileDepth,
      float LayerThickness[],
      float LagCoefficient,
      float VolumetricWaterContent[],
      float BulkDensity[],
      float AirTemperatureAnnualAverage,
      float Silt[],
      float OrganicMatter[],
      float Sand[],
      float Clay[],
      float HourOfSunset,
      float HourOfSunrise):
    cdef float SurfaceTemperatureMaximum
    cdef float SurfaceTemperatureMinimum
    cdef float SurfaceSoilTemperature
    cdef float SoilTemperatureByLayers[]
    cdef float HeatCapacity[]
    cdef float ThermalConductivity[]
    cdef float ThermalDiffusivity[]
    cdef float SoilTemperatureMinimum[]
    cdef float SoilTemperatureRangeByLayers[]
    cdef float SoilTemperatureMaximum[]
    cdef float SoilTemperatureByLayersHourly[]
    SurfaceSoilTemperature, SurfaceTemperatureMaximum, SurfaceTemperatureMinimum = model_surfacetemperatureparton( DayLength,AirTemperatureMinimum,GlobalSolarRadiation,AirTemperatureMaximum,SurfaceTemperatureMaximum,SurfaceTemperatureMinimum,AboveGroundBiomass)
    HeatCapacity = model_volumetricheatcapacitykluitenberg( Silt,OrganicMatter,Sand,VolumetricWaterContent,BulkDensity,Clay,HeatCapacity)
    ThermalConductivity = model_thermalconductivitysimulat( VolumetricWaterContent,BulkDensity,Clay)
    SoilTemperatureByLayers = model_soiltemperatureswat( SoilProfileDepth,SurfaceSoilTemperature,LayerThickness,LagCoefficient,VolumetricWaterContent,SoilTemperatureByLayers,BulkDensity,AirTemperatureAnnualAverage)
    ThermalDiffusivity = model_thermaldiffu( ThermalConductivity,ThermalDiffusivity,HeatCapacity)
    SoilTemperatureMinimum, SoilTemperatureRangeByLayers, SoilTemperatureMaximum = model_rangeofsoiltemperaturesdaycent( LayerThickness,SoilTemperatureByLayers,SurfaceTemperatureMaximum,ThermalDiffusivity,SurfaceTemperatureMinimum)
    SoilTemperatureByLayersHourly = model_hourlysoiltemperaturespartonlogan( SoilTemperatureMinimum,DayLength,SoilTemperatureMaximum,HourOfSunset,SoilTemperatureByLayersHourly,HourOfSunrise)
    return SurfaceSoilTemperature, SurfaceTemperatureMaximum, SurfaceTemperatureMinimum, SoilTemperatureByLayers, HeatCapacity, ThermalConductivity, ThermalDiffusivity, SoilTemperatureMinimum, SoilTemperatureRangeByLayers, SoilTemperatureMaximum, SoilTemperatureByLayersHourly