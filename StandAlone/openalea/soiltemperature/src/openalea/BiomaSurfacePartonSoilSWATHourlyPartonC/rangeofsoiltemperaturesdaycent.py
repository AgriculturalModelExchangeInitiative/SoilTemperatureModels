# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_rangeofsoiltemperaturesdaycent(LayerThickness:'Array[float]',
         SoilTemperatureByLayers:'Array[float]',
         SurfaceTemperatureMaximum:float,
         ThermalDiffusivity:'Array[float]',
         SurfaceTemperatureMinimum:float):
    """
     - Name: RangeOfSoilTemperaturesDAYCENT -Version: 001, -Time step: 1
     - Description:
                 * Title: RangeOfSoilTemperaturesDAYCENT model
                 * Authors: simone.bregaglio@unimi.it
                 * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
                 * Institution: University Of Milan
                 * ExtendedDescription: Strategy for the calculation of soil thermal conductivity.Reference: DAYCENT model written in C code 
                 * ShortDescription: None
     - inputs:
                 * name: LayerThickness
                               ** description : Soil layer thickness
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 3
                               ** min : 0.005
                               ** default : 0.05
                               ** unit : m
                 * name: SoilTemperatureByLayers
                               ** description : Soil temperature of each layer
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** default : 15
                               ** unit : Â°C
                 * name: SurfaceTemperatureMaximum
                               ** description : Maximum surface soil temperature
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 60
                               ** min : -60
                               ** default : 25
                               ** unit : Â°C
                 * name: ThermalDiffusivity
                               ** description : Thermal diffusivity of soil layer
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 1
                               ** min : 0
                               ** default : 0.0025
                               ** unit : mm s-1
                 * name: SurfaceTemperatureMinimum
                               ** description : Minimum surface soil temperature
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 60
                               ** min : -60
                               ** default : 10
                               ** unit : Â°C
     - outputs:
                 * name: SoilTemperatureMinimum
                               ** description : Minimum soil temperature by layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** unit : Â°C
                 * name: SoilTemperatureRangeByLayers
                               ** description : Soil temperature range by layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 50
                               ** min : 0
                               ** unit : Â°C
                 * name: SoilTemperatureMaximum
                               ** description : Maximum soil temperature by layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** unit : Â°C
    """

    SoilTemperatureMinimum:'array[float]'
    SoilTemperatureRangeByLayers:'array[float]'
    SoilTemperatureMaximum:'array[float]'
    i:int
    _DepthBottom:float
    _DepthCenterLayer:float
    SurfaceDiurnalRange:float
    _DepthBottom = float(0)
    _DepthCenterLayer = float(0)
    SurfaceDiurnalRange = SurfaceTemperatureMaximum - SurfaceTemperatureMinimum
    for i in range(0 , len(SoilTemperatureByLayers) , 1):
        if i == 0:
            _DepthCenterLayer = LayerThickness[0] * 100 / 2
            SoilTemperatureRangeByLayers[0] = SurfaceDiurnalRange * exp(-_DepthCenterLayer * pow(0.00005 / ThermalDiffusivity[0], 0.5))
            SoilTemperatureMaximum[0] = SoilTemperatureByLayers[0] + (SoilTemperatureRangeByLayers[0] / 2)
            SoilTemperatureMinimum[0] = SoilTemperatureByLayers[0] - (SoilTemperatureRangeByLayers[0] / 2)
        else:
            _DepthBottom = _DepthBottom + (LayerThickness[(i - 1)] * 100)
            _DepthCenterLayer = _DepthBottom + (LayerThickness[i] * 100 / 2)
            SoilTemperatureRangeByLayers[i] = SurfaceDiurnalRange * exp(-_DepthCenterLayer * pow(0.00005 / ThermalDiffusivity[i], 0.5))
            SoilTemperatureMaximum[i] = SoilTemperatureByLayers[i] + (SoilTemperatureRangeByLayers[i] / 2)
            SoilTemperatureMinimum[i] = SoilTemperatureByLayers[i] - (SoilTemperatureRangeByLayers[i] / 2)
    return (SoilTemperatureMinimum, SoilTemperatureRangeByLayers, SoilTemperatureMaximum)
#%%CyML Model End%%