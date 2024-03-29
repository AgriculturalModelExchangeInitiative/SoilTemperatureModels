import numpy
from math import *

def init_rangeofsoiltemperaturesdaycent(float LayerThickness[]):
    cdef float SoilTemperatureRangeByLayers[]
    cdef float SoilTemperatureMinimum[]
    cdef float SoilTemperatureMaximum[]
    SoilTemperatureRangeByLayers = None
    SoilTemperatureMinimum = None
    SoilTemperatureMaximum = None
    SoilTemperatureRangeByLayers=array('f', [0.0]*len(LayerThickness))
    SoilTemperatureMaximum=array('f', [0.0]*len(LayerThickness))
    SoilTemperatureMinimum=array('f', [0.0]*len(LayerThickness))
    return  SoilTemperatureRangeByLayers, SoilTemperatureMinimum, SoilTemperatureMaximum

def model_rangeofsoiltemperaturesdaycent(float LayerThickness[],
                                         float SurfaceTemperatureMinimum,
                                         float ThermalDiffusivity[],
                                         float SoilTemperatureByLayers[],
                                         float SurfaceTemperatureMaximum,
                                         float SoilTemperatureRangeByLayers[],
                                         float SoilTemperatureMinimum[],
                                         float SoilTemperatureMaximum[]):
    """
    RangeOfSoilTemperaturesDAYCENT model
    Author: simone.bregaglio
    Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
    Institution: University Of Milan
    ExtendedDescription: Strategy for the calculation of soil thermal conductivity.Reference: DAYCENT model written in C code
    ShortDescription: Strategy for the calculation of soil thermal conductivity
    """

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
    return  SoilTemperatureRangeByLayers, SoilTemperatureMinimum, SoilTemperatureMaximum



