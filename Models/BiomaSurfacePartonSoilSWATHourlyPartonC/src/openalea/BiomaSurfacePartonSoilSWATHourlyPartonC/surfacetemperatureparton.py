# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_surfacetemperatureparton(GlobalSolarRadiation:float,
         DayLength:float,
         AboveGroundBiomass:float,
         AirTemperatureMinimum:float,
         AirTemperatureMaximum:float):
    """
     - Name: SurfaceTemperatureParton -Version: 001, -Time step: 1
     - Description:
                 * Title: SurfaceTemperatureParton model
                 * Authors: simone.bregaglio
                 * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
                 * Institution: University Of Milan
                 * ExtendedDescription: Strategy for the calculation of soil surface temperature with Parton's method. Reference: Parton, W. J. 1984. Predicting soil temperatures in a shortgrass steppe. Soil Science 138:93-101.
                 * ShortDescription: Strategy for the calculation of soil surface temperature with Parton's method
     - inputs:
                 * name: GlobalSolarRadiation
                               ** description : Daily global solar radiation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 50
                               ** min : 0
                               ** default : 15
                               ** unit : Mj m-2 d-1
                 * name: DayLength
                               ** description : Length of the day
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 24
                               ** min : 0
                               ** default : 10
                               ** unit : h
                 * name: AboveGroundBiomass
                               ** description : Above ground biomass
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 60
                               ** min : 0
                               ** default : 3
                               ** unit : Kg ha-1
                 * name: AirTemperatureMinimum
                               ** description : Minimum daily air temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 50
                               ** min : -60
                               ** default : 5
                               ** unit : degC
                 * name: AirTemperatureMaximum
                               ** description : Maximum daily air temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 60
                               ** min : -40
                               ** default : 15
                               ** unit : degC
     - outputs:
                 * name: SurfaceSoilTemperature
                               ** description : Average surface soil temperature
                               ** datatype : DOUBLE
                               ** variablecategory : auxiliary
                               ** max : 60
                               ** min : -60
                               ** unit : degC
                 * name: SurfaceTemperatureMinimum
                               ** description : Minimum surface soil temperature
                               ** datatype : DOUBLE
                               ** variablecategory : auxiliary
                               ** max : 60
                               ** min : -60
                               ** unit : 
                 * name: SurfaceTemperatureMaximum
                               ** description : Maximum surface soil temperature
                               ** datatype : DOUBLE
                               ** variablecategory : auxiliary
                               ** max : 60
                               ** min : -60
                               ** unit : degC             */
    """

    SurfaceSoilTemperature:float
    SurfaceTemperatureMinimum:float
    SurfaceTemperatureMaximum:float
    _AGB:float
    _AirTMax:float
    _AirTmin:float
    _SolarRad:float
    _AGB = AboveGroundBiomass / 10000
    _AirTMax = AirTemperatureMaximum
    _AirTmin = AirTemperatureMinimum
    _SolarRad = GlobalSolarRadiation
    if _AGB > 0.15:
        SurfaceTemperatureMaximum = _AirTMax + ((24 * (1 - exp(-0.038 * _SolarRad)) + (0.35 * _AirTMax)) * (exp(-4.8 * _AGB) - 0.13))
        SurfaceTemperatureMinimum = _AirTmin + (6 * _AGB) - 1.82
    else:
        SurfaceTemperatureMaximum = AirTemperatureMaximum
        SurfaceTemperatureMinimum = AirTemperatureMinimum
    SurfaceSoilTemperature = 0.41 * SurfaceTemperatureMaximum + (0.59 * SurfaceTemperatureMinimum)
    if DayLength != float(0):
        SurfaceSoilTemperature = DayLength / 24 * _AirTMax + ((1 - (DayLength / 24)) * _AirTmin)
    return (SurfaceSoilTemperature, SurfaceTemperatureMinimum, SurfaceTemperatureMaximum)
#%%CyML Model End%%