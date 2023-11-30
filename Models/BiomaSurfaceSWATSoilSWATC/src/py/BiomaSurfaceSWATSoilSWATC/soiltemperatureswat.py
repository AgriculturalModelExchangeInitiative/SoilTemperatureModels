# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Init Begin%%
def init_soiltemperatureswat(VolumetricWaterContent:'Array[float]',
         LayerThickness:'Array[float]',
         LagCoefficient:float,
         AirTemperatureAnnualAverage:float,
         BulkDensity:'Array[float]',
         SoilProfileDepth:float):
    SoilTemperatureByLayers:'array[float]'
    i:int
    SoilTemperatureByLayers = array('f', [0.0]*len(LayerThickness))
    for i in range(0 , len(LayerThickness) , 1):
        SoilTemperatureByLayers[i] = float(15)
    return SoilTemperatureByLayers
#%%CyML Init End%%

#%%CyML Model Begin%%
def model_soiltemperatureswat(VolumetricWaterContent:'Array[float]',
         SurfaceSoilTemperature:float,
         LayerThickness:'Array[float]',
         LagCoefficient:float,
         SoilTemperatureByLayers:'Array[float]',
         AirTemperatureAnnualAverage:float,
         BulkDensity:'Array[float]',
         SoilProfileDepth:float):
    """
     - Name: SoilTemperatureSWAT -Version: 001, -Time step: 1
     - Description:
                 * Title: SoilTemperatureSWAT model
                 * Authors: simone.bregaglio
                 * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
                 * Institution: University Of Milan
                 * ExtendedDescription: Strategy for the calculation of soil temperature with SWAT method. Reference: Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf
                 * ShortDescription: Strategy for the calculation of soil temperature with SWAT method
     - inputs:
                 * name: VolumetricWaterContent
                               ** description : Volumetric soil water content
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 0.8
                               ** min : 0
                               ** default : 0.25
                               ** unit : m3 m-3
                 * name: SurfaceSoilTemperature
                               ** description : Average surface soil temperature
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 60
                               ** min : -60
                               ** default : 25
                               ** unit : degC
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
                 * name: LagCoefficient
                               ** description : Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 1
                               ** min : 0
                               ** default : 0.8
                               ** unit : dimensionless
                 * name: SoilTemperatureByLayers
                               ** description : Soil temperature of each layer
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** default : 15
                               ** unit : degC
                 * name: AirTemperatureAnnualAverage
                               ** description : Annual average air temperature
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 50
                               ** min : -40
                               ** default : 15
                               ** unit : degC
                 * name: BulkDensity
                               ** description : Bulk density
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 1.8
                               ** min : 0.9
                               ** default : 1.3
                               ** unit : t m-3
                 * name: SoilProfileDepth
                               ** description : Soil profile depth
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 50
                               ** min : 0
                               ** default : 3
                               ** unit : m
     - outputs:
                 * name: SoilTemperatureByLayers
                               ** description : Soil temperature of each layer
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** unit : degC
    """

    i:int
    _SoilProfileDepthmm:float
    _TotalWaterContentmm:float
    _MaximumDumpingDepth:float
    _DumpingDepth:float
    _ScalingFactor:float
    _DepthBottom:float
    _RatioCenter:float
    _DepthFactor:float
    _DepthCenterLayer:float
    _SoilProfileDepthmm = SoilProfileDepth * 1000
    _TotalWaterContentmm = float(0)
    for i in range(0 , len(LayerThickness) , 1):
        _TotalWaterContentmm = _TotalWaterContentmm + (VolumetricWaterContent[i] * LayerThickness[i])
    _TotalWaterContentmm = _TotalWaterContentmm * 1000
    _MaximumDumpingDepth = float(0)
    _DumpingDepth = float(0)
    _ScalingFactor = float(0)
    _DepthBottom = float(0)
    _RatioCenter = float(0)
    _DepthFactor = float(0)
    _DepthCenterLayer = LayerThickness[0] * 1000 / 2
    _MaximumDumpingDepth = 1000 + (2500 * BulkDensity[0] / (BulkDensity[0] + (686 * exp(-5.63 * BulkDensity[0]))))
    _ScalingFactor = _TotalWaterContentmm / ((0.356 - (0.144 * BulkDensity[0])) * _SoilProfileDepthmm)
    _DumpingDepth = _MaximumDumpingDepth * exp(log(500 / _MaximumDumpingDepth) * pow((1 - _ScalingFactor) / (1 + _ScalingFactor), 2))
    _RatioCenter = _DepthCenterLayer / _DumpingDepth
    _DepthFactor = _RatioCenter / (_RatioCenter + exp(-0.867 - (2.078 * _RatioCenter)))
    SoilTemperatureByLayers[0] = LagCoefficient * SoilTemperatureByLayers[0] + ((1 - LagCoefficient) * (_DepthFactor * (AirTemperatureAnnualAverage - SurfaceSoilTemperature) + SurfaceSoilTemperature))
    for i in range(1 , len(LayerThickness) , 1):
        _DepthBottom = _DepthBottom + (LayerThickness[(i - 1)] * 1000)
        _DepthCenterLayer = _DepthBottom + (LayerThickness[i] * 1000 / 2)
        _MaximumDumpingDepth = 1000 + (2500 * BulkDensity[i] / (BulkDensity[i] + (686 * exp(-5.63 * BulkDensity[i]))))
        _ScalingFactor = _TotalWaterContentmm / ((0.356 - (0.144 * BulkDensity[i])) * _SoilProfileDepthmm)
        _DumpingDepth = _MaximumDumpingDepth * exp(log(500 / _MaximumDumpingDepth) * pow((1 - _ScalingFactor) / (1 + _ScalingFactor), 2))
        _RatioCenter = _DepthCenterLayer / _DumpingDepth
        _DepthFactor = _RatioCenter / (_RatioCenter + exp(-0.867 - (2.078 * _RatioCenter)))
        SoilTemperatureByLayers[i] = LagCoefficient * SoilTemperatureByLayers[i] + ((1 - LagCoefficient) * (_DepthFactor * (AirTemperatureAnnualAverage - SurfaceSoilTemperature) + SurfaceSoilTemperature))
    return SoilTemperatureByLayers
#%%CyML Model End%%