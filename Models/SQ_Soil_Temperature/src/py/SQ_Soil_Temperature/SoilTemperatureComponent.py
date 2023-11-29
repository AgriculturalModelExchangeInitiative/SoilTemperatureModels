# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from SQ_Soil_Temperature.calculatesoiltemperature import model_calculatesoiltemperature
from SQ_Soil_Temperature.calculatehourlysoiltemperature import model_calculatehourlysoiltemperature

#%%CyML Model Begin%%
def model_soiltemperature(meanTAir:float,
         minTAir:float,
         lambda_:float,
         meanAnnualAirTemp:float,
         heatFlux:float,
         maxTAir:float,
         b:float,
         c:float,
         a:float,
         dayLength:float):
    """
     - Name: SoilTemperature -Version: 001, -Time step: 1
     - Description:
                 * Title: SoilTemperature model
                 * Authors: loic.manceau@inra.fr
                 * Reference: ('http://biomamodelling.org',)
                 * Institution: INRA
                 * ExtendedDescription: Composite Class for soil temperature
                 * ShortDescription: None
     - inputs:
                 * name: meanTAir
                               ** description : Mean Air Temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 80
                               ** min : -30
                               ** default : 22
                               ** unit : Â°C
                 * name: minTAir
                               ** description : Minimum Air Temperature from Weather files
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 80
                               ** min : -30
                               ** default : 20
                               ** unit : Â°C
                 * name: lambda_
                               ** description : Latente heat of water vaporization at 20Â°C
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 2.454
                               ** unit : MJ.kg-1
                 * name: meanAnnualAirTemp
                               ** description : Annual Mean Air Temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 80
                               ** min : -30
                               ** default : 22
                               ** unit : Â°C
                 * name: heatFlux
                               ** description : Soil Heat Flux from Energy Balance Component
                               ** inputtype : variable
                               ** variablecategory : rate
                               ** datatype : DOUBLE
                               ** max : 100
                               ** min : 0
                               ** default : 50
                               ** unit : g m-2 d-1
                 * name: maxTAir
                               ** description : Maximum Air Temperature from Weather Files
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 80
                               ** min : -30
                               ** default : 25
                               ** unit : Â°C
                 * name: b
                               ** description : Delay between sunrise and time when minimum temperature is reached
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 1.81
                               ** unit : Hour
                 * name: c
                               ** description : Nighttime temperature coefficient
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 0.49
                               ** unit : Dpmensionless
                 * name: a
                               ** description : Delay between sunset and time when maximum temperature is reached
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 10
                               ** min : 0
                               ** default : 0.5
                               ** unit : Hour
                 * name: dayLength
                               ** description : Length of the day
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 24
                               ** min : 0
                               ** default : 12
                               ** unit : hour
     - outputs:
                 * name: minTSoil
                               ** description : Minimum Soil Temperature
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 80
                               ** min : -30
                               ** unit : Â°C
                 * name: deepLayerT
                               ** description : Temperature of the last soil layer
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 80
                               ** min : -30
                               ** unit : Â°C
                 * name: maxTSoil
                               ** description : Maximum Soil Temperature
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 80
                               ** min : -30
                               ** unit : Â°C
                 * name: hourlySoilT
                               ** description : Hourly Soil Temperature
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 24
                               ** max : 80
                               ** min : -30
                               ** unit : Â°C
    """

    deepLayerT:float
    minTSoil:float
    maxTSoil:float
    hourlySoilT:'array[float]' = array('f',[0.0]*24)
    (minTSoil, deepLayerT, maxTSoil) = model_calculatesoiltemperature(meanTAir, minTAir, lambda_, deepLayerT, meanAnnualAirTemp, heatFlux, maxTAir)
    hourlySoilT = model_calculatehourlysoiltemperature(minTSoil, dayLength, b, a, maxTSoil, c)
    return (minTSoil, deepLayerT, maxTSoil, hourlySoilT)
#%%CyML Model End%%