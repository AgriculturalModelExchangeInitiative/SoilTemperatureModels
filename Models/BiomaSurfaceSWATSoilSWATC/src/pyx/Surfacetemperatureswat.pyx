import numpy 
from math import *
def model_surfacetemperatureswat(float GlobalSolarRadiation,
                                 float SoilTemperatureByLayers[],
                                 float AirTemperatureMaximum,
                                 float AirTemperatureMinimum,
                                 float Albedo,
                                 float AboveGroundBiomass,
                                 float WaterEquivalentOfSnowPack):
    """

    SurfaceTemperatureSWAT model
    Author: simone.bregaglio@unimi.it
    Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    Institution: University Of Milan
    ExtendedDescription: Strategy for the calculation of surface soil temperature with SWAT method. Reference: Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf
    ShortDescription: None

    """
    cdef float SurfaceSoilTemperature
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
    return  SurfaceSoilTemperature


