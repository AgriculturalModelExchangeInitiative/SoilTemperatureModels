cdef float _AGB 
cdef float _AirTMax 
cdef float _AirTmin 
cdef float _SolarRad 
_AGB=AboveGroundBiomass / 10000
_AirTMax=AirTemperatureMaximum
_AirTmin=AirTemperatureMinimum
_SolarRad=GlobalSolarRadiation
if _AGB > 0.15:
    SurfaceTemperatureMaximum=_AirTMax + ((24 * (1 - exp(-0.038 * _SolarRad)) + (0.35 * _AirTMax)) * (exp(-4.8 * _AGB) - 0.13))
    SurfaceTemperatureMinimum=_AirTmin + (6 * _AGB) - 1.82
else:
    SurfaceTemperatureMaximum=AirTemperatureMaximum
    SurfaceTemperatureMinimum=AirTemperatureMinimum
SurfaceSoilTemperature=0.41 * SurfaceTemperatureMaximum + (0.59 * SurfaceTemperatureMinimum)
if DayLength != float(0):
    SurfaceSoilTemperature=DayLength / 24 * _AirTMax + ((1 - (DayLength / 24)) * _AirTmin)