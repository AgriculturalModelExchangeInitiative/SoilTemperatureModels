cdef int i 
cdef float _DepthBottom 
cdef float _DepthCenterLayer 
cdef float SurfaceDiurnalRange 
_DepthBottom=float(0)
_DepthCenterLayer=float(0)
SurfaceDiurnalRange=SurfaceTemperatureMaximum - SurfaceTemperatureMinimum
for i in range(0 , len(SoilTemperatureByLayers) , 1):
    if i == 0:
        _DepthCenterLayer=LayerThickness[0] * 100 / 2
        SoilTemperatureRangeByLayers[0]=SurfaceDiurnalRange * exp(-_DepthCenterLayer * pow(0.00005 / ThermalDiffusivity[0], 0.5))
        SoilTemperatureMaximum[0]=SoilTemperatureByLayers[0] + (SoilTemperatureRangeByLayers[0] / 2)
        SoilTemperatureMinimum[0]=SoilTemperatureByLayers[0] - (SoilTemperatureRangeByLayers[0] / 2)
    else:
        _DepthBottom=_DepthBottom + (LayerThickness[(i - 1)] * 100)
        _DepthCenterLayer=_DepthBottom + (LayerThickness[i] * 100 / 2)
        SoilTemperatureRangeByLayers[i]=SurfaceDiurnalRange * exp(-_DepthCenterLayer * pow(0.00005 / ThermalDiffusivity[i], 0.5))
        SoilTemperatureMaximum[i]=SoilTemperatureByLayers[i] + (SoilTemperatureRangeByLayers[i] / 2)
        SoilTemperatureMinimum[i]=SoilTemperatureByLayers[i] - (SoilTemperatureRangeByLayers[i] / 2)