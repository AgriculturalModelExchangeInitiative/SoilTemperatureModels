# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Init Begin%%
def init_rangeofsoiltemperaturesdaycent(LayerThickness:'Array[float]'):
    SoilTemperatureRangeByLayers:'array[float]'
    SoilTemperatureMinimum:'array[float]'
    SoilTemperatureMaximum:'array[float]'
    SoilTemperatureRangeByLayers = None
    SoilTemperatureMinimum = None
    SoilTemperatureMaximum = None
    SoilTemperatureRangeByLayers = array('f', [0.0]*len(LayerThickness))
    SoilTemperatureMaximum = array('f', [0.0]*len(LayerThickness))
    SoilTemperatureMinimum = array('f', [0.0]*len(LayerThickness))
    return (SoilTemperatureRangeByLayers, SoilTemperatureMinimum, SoilTemperatureMaximum)
#%%CyML Init End%%

#%%CyML Model Begin%%
def model_rangeofsoiltemperaturesdaycent(LayerThickness:'Array[float]',
         SurfaceTemperatureMinimum:float,
         ThermalDiffusivity:'Array[float]',
         SoilTemperatureByLayers:'Array[float]',
         SurfaceTemperatureMaximum:float,
         SoilTemperatureRangeByLayers:'Array[float]',
         SoilTemperatureMinimum:'Array[float]',
         SoilTemperatureMaximum:'Array[float]'):
    """
     - Name: RangeOfSoilTemperaturesDAYCENT -Version: 001, -Time step: 1
     - Description:
                 * Title: RangeOfSoilTemperaturesDAYCENT model
                 * Authors: simone.bregaglio
                 * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
                 * Institution: University Of Milan
                 * ExtendedDescription: Strategy for the calculation of soil thermal conductivity.Reference: DAYCENT model written in C code
                 * ShortDescription: Strategy for the calculation of soil thermal conductivity
     - inputs:
                 * name: LayerThickness
                               ** description : Soil layer thickness
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 3
                               ** min : 0.005
                               ** default : 0.05
                               ** unit : m
                 * name: SurfaceTemperatureMinimum
                               ** description : Minimum surface soil temperature
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 60
                               ** min : -60
                               ** default : 10
                               ** unit : degC
                 * name: ThermalDiffusivity
                               ** description : Thermal diffusivity of soil layer
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 1
                               ** min : 0
                               ** default : 0.0025
                               ** unit : mm s-1
                 * name: SoilTemperatureByLayers
                               ** description : Soil temperature of each layer
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** default : 15
                               ** unit : degC
                 * name: SurfaceTemperatureMaximum
                               ** description : Maximum surface soil temperature
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 60
                               ** min : -60
                               ** default : 25
                               ** unit : degC
                 * name: SoilTemperatureRangeByLayers
                               ** description : Soil temperature range by layers
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 50
                               ** min : 0
                               ** default : 
                               ** unit : degC
                 * name: SoilTemperatureMinimum
                               ** description : Minimum soil temperature by layers
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** default : 
                               ** unit : degC
                 * name: SoilTemperatureMaximum
                               ** description : Maximum soil temperature by layers
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** default : 
                               ** unit : degC
     - outputs:
                 * name: SoilTemperatureRangeByLayers
                               ** description : Soil temperature range by layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 50
                               ** min : 0
                               ** unit : degC
                 * name: SoilTemperatureMinimum
                               ** description : Minimum soil temperature by layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** unit : degC
                 * name: SoilTemperatureMaximum
                               ** description : Maximum soil temperature by layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** unit : degC
    """

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
    return (SoilTemperatureRangeByLayers, SoilTemperatureMinimum, SoilTemperatureMaximum)
#%%CyML Model End%%