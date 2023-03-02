cdef float _Tavg 
cdef float _Hterm 
cdef float _Tbare 
cdef float _WeightingCover 
cdef float _WeightingSnow 
cdef float _WeightingActual 
_Tavg=(AirTemperatureMaximum + AirTemperatureMinimum) / 2
_Hterm=(GlobalSolarRadiation * (1 - Albedo) - 14) / 20
_Tbare=_Tavg + (_Hterm * (AirTemperatureMaximum - AirTemperatureMinimum) / 2)
_WeightingCover=AboveGroundBiomass / (AboveGroundBiomass + exp(7.563 - (0.0001297 * AboveGroundBiomass)))
_WeightingSnow=WaterEquivalentOfSnowPack / (WaterEquivalentOfSnowPack + exp(6.055 - (0.3002 * WaterEquivalentOfSnowPack)))
_WeightingActual=max(_WeightingCover, _WeightingSnow)
SurfaceSoilTemperature=_WeightingActual * SoilTemperatureByLayers[0] + ((1 - _WeightingActual) * _Tbare)