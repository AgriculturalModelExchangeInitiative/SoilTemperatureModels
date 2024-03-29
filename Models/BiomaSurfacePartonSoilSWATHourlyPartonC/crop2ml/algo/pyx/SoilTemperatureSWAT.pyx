cdef int i 
cdef float _SoilProfileDepthmm 
cdef float _TotalWaterContentmm 
cdef float _MaximumDumpingDepth 
cdef float _DumpingDepth 
cdef float _ScalingFactor 
cdef float _DepthBottom 
cdef float _RatioCenter 
cdef float _DepthFactor 
cdef float _DepthCenterLayer 
_SoilProfileDepthmm=SoilProfileDepth * 1000
_TotalWaterContentmm=float(0)
for i in range(0 , len(LayerThickness) , 1):
    _TotalWaterContentmm+=VolumetricWaterContent[i] * LayerThickness[i]
_TotalWaterContentmm=_TotalWaterContentmm * 1000
_MaximumDumpingDepth=float(0)
_DumpingDepth=float(0)
_ScalingFactor=float(0)
_DepthBottom=float(0)
_RatioCenter=float(0)
_DepthFactor=float(0)
_DepthCenterLayer=LayerThickness[0] * 1000 / 2
_MaximumDumpingDepth=1000 + (2500 * BulkDensity[0] / (BulkDensity[0] + (686 * exp(-5.63 * BulkDensity[0]))))
_ScalingFactor=_TotalWaterContentmm / ((0.356 - (0.144 * BulkDensity[0])) * _SoilProfileDepthmm)
_DumpingDepth=_MaximumDumpingDepth * exp(log(500 / _MaximumDumpingDepth) * pow((1 - _ScalingFactor) / (1 + _ScalingFactor), 2))
_RatioCenter=_DepthCenterLayer / _DumpingDepth
_DepthFactor=_RatioCenter / (_RatioCenter + exp(-0.867 - (2.078 * _RatioCenter)))
SoilTemperatureByLayers[0]=LagCoefficient * SoilTemperatureByLayers[0] + ((1 - LagCoefficient) * (_DepthFactor * (AirTemperatureAnnualAverage - SurfaceSoilTemperature) + SurfaceSoilTemperature))
for i in range(1 , len(LayerThickness) , 1):
    _DepthBottom=_DepthBottom + (LayerThickness[(i - 1)] * 1000)
    _DepthCenterLayer=_DepthBottom + (LayerThickness[i] * 1000 / 2)
    _MaximumDumpingDepth=1000 + (2500 * BulkDensity[i] / (BulkDensity[i] + (686 * exp(-5.63 * BulkDensity[i]))))
    _ScalingFactor=_TotalWaterContentmm / ((0.356 - (0.144 * BulkDensity[i])) * _SoilProfileDepthmm)
    _DumpingDepth=_MaximumDumpingDepth * exp(log(500 / _MaximumDumpingDepth) * pow((1 - _ScalingFactor) / (1 + _ScalingFactor), 2))
    _RatioCenter=_DepthCenterLayer / _DumpingDepth
    _DepthFactor=_RatioCenter / (_RatioCenter + exp(-0.867 - (2.078 * _RatioCenter)))
    SoilTemperatureByLayers[i]=LagCoefficient * SoilTemperatureByLayers[i] + ((1 - LagCoefficient) * (_DepthFactor * (AirTemperatureAnnualAverage - SurfaceSoilTemperature) + SurfaceSoilTemperature))