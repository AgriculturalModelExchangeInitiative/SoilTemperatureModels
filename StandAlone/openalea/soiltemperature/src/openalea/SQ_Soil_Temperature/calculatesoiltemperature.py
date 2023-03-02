# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_calculatesoiltemperature(deepLayerT:float,
         lambda_:float,
         heatFlux:float,
         meanTAir:float,
         minTAir:float,
         deepLayerT_t1:float,
         maxTAir:float):
    """
     - Name: CalculateSoilTemperature -Version: 001, -Time step: 1
     - Description:
                 * Title: CalculateSoilTemperature model
                 * Authors: loic.manceau@inra.fr
                 * Reference: ('http://biomamodelling.org',)
                 * Institution: INRA
                 * ExtendedDescription: Calculation of minimum and maximum Soil temperature, Further used in shoot temperature estimate.
                 * ShortDescription: None
     - inputs:
                 * name: deepLayerT
                               ** description : Temperature of the last soil layer
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 80
                               ** min : -30
                               ** default : 20
                               ** unit : °C
                 * name: lambda_
                               ** description : Latente heat of water vaporization at 20°C
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 2.454
                               ** unit : MJ.kg-1
                 * name: heatFlux
                               ** description : Soil Heat Flux from Energy Balance Component
                               ** inputtype : variable
                               ** variablecategory : rate
                               ** datatype : DOUBLE
                               ** max : 100
                               ** min : 0
                               ** default : 50
                               ** unit : g m-2 d-1
                 * name: meanTAir
                               ** description : Mean Air Temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 80
                               ** min : -30
                               ** default : 22
                               ** unit : °C
                 * name: minTAir
                               ** description : Minimum Air Temperature from Weather files
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 80
                               ** min : -30
                               ** default : 20
                               ** unit : °C
                 * name: deepLayerT_t1
                               ** description : Temperature of the last soil layer
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 80
                               ** min : -30
                               ** default : 20
                               ** unit : °C
                 * name: maxTAir
                               ** description : Maximum Air Temperature from Weather Files
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 80
                               ** min : -30
                               ** default : 25
                               ** unit : °C
     - outputs:
                 * name: deepLayerT_t1
                               ** description : Temperature of the last soil layer
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 80
                               ** min : -30
                               ** unit : °C
                 * name: maxTSoil
                               ** description : Maximum Soil Temperature
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 80
                               ** min : -30
                               ** unit : °C
                 * name: minTSoil
                               ** description : Minimum Soil Temperature
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 80
                               ** min : -30
                               ** unit : °C
    """

    maxTSoil:float
    minTSoil:float
    if maxTAir == float(-999) and minTAir == float(999):
        minTSoil = float(999)
        maxTSoil = float(-999)
        deepLayerT_t1 = 0.0
    else:
        minTSoil = SoilMinimumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT)
        maxTSoil = SoilMaximumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT_t1)
        deepLayerT_t1 = UpdateTemperature(minTSoil, maxTSoil, deepLayerT)
    return (deepLayerT_t1, maxTSoil, minTSoil)
#%%CyML Model End%%

def SoilTempB(weatherMinTemp:float,
         deepTemperature:float):
    return (weatherMinTemp + deepTemperature) / 2.0

def SoilTempA(weatherMaxTemp:float,
         weatherMeanTemp:float,
         soilHeatFlux:float,
         lambda_:float):
    TempAdjustment:float
    SoilAvailableEnergy:float
    TempAdjustment = -0.5 * weatherMeanTemp + 4.0 if weatherMeanTemp < 8.0 else float(0)
    SoilAvailableEnergy = soilHeatFlux * lambda_ / 1000
    return weatherMaxTemp + (11.2 * (1.0 - exp(-0.07 * (SoilAvailableEnergy - 5.5)))) + TempAdjustment

def SoilMinimumTemperature(weatherMaxTemp:float,
         weatherMeanTemp:float,
         weatherMinTemp:float,
         soilHeatFlux:float,
         lambda_:float,
         deepTemperature:float):
    return min(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature))

def SoilMaximumTemperature(weatherMaxTemp:float,
         weatherMeanTemp:float,
         weatherMinTemp:float,
         soilHeatFlux:float,
         lambda_:float,
         deepTemperature:float):
    return max(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature))

def UpdateTemperature(minSoilTemp:float,
         maxSoilTemp:float,
         Temperature:float):
    meanTemp:float
    meanTemp = (minSoilTemp + maxSoilTemp) / 2.0
    Temperature = (9.0 * Temperature + meanTemp) / 10.0
    return Temperature