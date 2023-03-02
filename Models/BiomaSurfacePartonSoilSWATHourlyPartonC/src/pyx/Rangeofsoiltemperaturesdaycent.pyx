import numpy 
from math import *
def model_rangeofsoiltemperaturesdaycent(float LayerThickness[],
                                         float SoilTemperatureByLayers[],
                                         float SurfaceTemperatureMaximum,
                                         float ThermalDiffusivity[],
                                         float SurfaceTemperatureMinimum):
    """

    RangeOfSoilTemperaturesDAYCENT model
    Author: simone.bregaglio@unimi.it
    Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    Institution: University Of Milan
    ExtendedDescription: Strategy for the calculation of soil thermal conductivity.Reference: DAYCENT model written in C code 
    ShortDescription: None

    """
    cdef float SoilTemperatureMinimum[]
    cdef float SoilTemperatureRangeByLayers[]
    cdef float SoilTemperatureMaximum[]
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
    return  SoilTemperatureMinimum, SoilTemperatureRangeByLayers, SoilTemperatureMaximum


