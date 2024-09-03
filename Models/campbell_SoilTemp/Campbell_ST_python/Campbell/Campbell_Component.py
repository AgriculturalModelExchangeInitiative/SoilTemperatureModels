# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from Campbell.campbell import model_campbell

#%%CyML Model Begin%%
def model_campbell_(NLAYR: int,
    THICK: 'Array[float]',
    BD: 'Array[float]',
    TMAX: float,
    TMIN: float,
    TAV: float,
    TAMP: float,
    XLAT: float,
    CLAY: 'Array[float]',
    SW: 'Array[float]',
    DEPTH: 'Array[float]',
    DOY: float,
    canopyHeight: float,
    SALB: float,
    SRAD: float,
    ESP: float,
    EOAD: float,
    ESAD: float,
    soilTemp: 'Array[float]'):
    """
    - Name: SoilTemperatureCampbell
    - Version: 1.0
    - Time step: 1
    - Description:
                * Title: SoilTemperature model from Campbell implemented in APSIM
                * Author: Teiki Raihauti and Christophe Pradal
                * Reference: Campbell model (TODO)
                * Institution: CIRAD and INRAE
                * ExtendedDescription: TODO
                * ShortDescription: TODO
    
    - inputs: 
         * name: NLAYR
               ** description : number of soil layers in profile
               ** inputtype : parameter
               ** variablecategory : constant
               ** datatype : INT
               ** max :
               ** min : 1
               ** default : 10
               ** unit : dimensionless
         * name: THICK
               ** description : APSIM soil layer depths as thickness of layers
               ** inputtype : parameter
               ** variablecategory : constant
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max :
               ** min : 1
               ** default : 5
                       ** unit : mm 
        * name: BD
               ** description : bd (soil bulk density) is name of the APSIM var for bulk density so set bulkDensity = bd later
               ** inputtype : parameter
               ** variablecategory : constant
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max :
               ** min : 1
               ** default : 
               ** unit : g/cm3
        * name: TMAX
               ** description : Max daily Air temperature
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 60
               ** min : -60
               ** default :
               ** unit : °C
        * name: TMIN
               ** description : Min daily Air temperature
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 60
               ** min : -60
               ** default :
               ** unit : °C
        * name: TAV
               ** description : Average daily Air temperature
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 60
               ** min : -60
               ** default :
               ** unit : °C
        * name: TAMP
               ** description : Amplitude air temperature
               ** inputtype : parameter
               ** variablecategory : constant
               ** datatype : DOUBLE
               ** max : 100
               ** min : -100
               ** default :
               ** unit : °C
        * name: XLAT
               ** description : Latitude
               ** inputtype : parameter
               ** variablecategory : constant
               ** datatype : DOUBLE
               ** max : 
               ** min :
               ** default :
               ** unit : °C
        * name: CLAY
               ** description : Proportion of clay in each layer of profile
               ** inputtype : parameter
               ** variablecategory : constant
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max : 1
               ** min : 0
               ** default : 0.5
               ** unit : dimensionless
        * name: SW
               ** description : volumetric water content
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max : 1
               ** min : 0
               ** default : 0.5
               ** unit : cc water / cc soil
        * name: DEPTH
               ** description : node depths
               ** inputtype : parameter
               ** variablecategory : constant
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max :
               ** min : 
               ** default :
               ** unit : m
        * name: DOY
               ** description : Day of year
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 366
               ** min : 0
               ** default : 0
               ** unit : dimensionless
        * name: canopyHeight
               ** description : height of canopy above ground
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 
               ** min : 0
               ** default : 0.057
               ** unit : m
        * name: SALB
               ** description : Soil albedo
               ** inputtype : parameter
               ** variablecategory : constant
               ** datatype : DOUBLE
               ** max : 1
               ** min : 0
               ** default : 
               ** unit : dimensionless
        * name: SRAD
               ** description : Radiation
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 
               ** min : 
               ** default : 
               ** unit : 
        * name: ESP
               ** description : Potential evaporation
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 
               ** min : 0
               ** default : 
               ** unit : mm
        * name: EOAD
               ** description : Potential evapotranspiration
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 
               ** min : 0
               ** default : 
               ** unit : mm
        * name: ESAD
               ** description : Actual evapotranspiration
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLE
               ** max : 
               ** min : 0
               ** default : 
               ** unit : mm
         * name: soilTemp
                ** description :  Temperature at end of last time-step within a day - midnight in layers
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** min : -60.
                ** max : 60.
                ** unit : degC
                ** uri : 

    - outputs: 
                * name: soilTemp
                            ** description :  Temperature at end of last time-step within a day - midnight in layers
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: minSoilTemp
                            ** description : Minimum soil temperature in layers
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: maxSoilTemp
                            ** description :  Maximum soil temperature in layers
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: aveSoilTemp
                            ** description : Temperature averaged over all time-steps within a day in layers.
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: morningSoilTemp
                            ** description : Temperature  in the morning in layers.
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: tempNew
                            ** description : Soil temperature at the end of one iteration
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: heatCapacity
                            ** description : Heat Capacity in layers
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : 
                            ** max : 
                            ** unit : J/m3/K/s
                            ** uri : 
                * name: thermalConductivity
                            ** description : thermal conductivity in layers
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : 
                            ** max : 
                            ** unit : (W/m2/K)
                            ** uri : 
                * name: thermalConductance
                            ** description : Thermal conductance between layers 
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : 
                            ** max : 
                            ** unit : 
                            ** uri : 
                * name: heatStorage
                            ** description : Heat storage between layers (internal)
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : 
                            ** max : 
                            ** unit : J/s/K
                            ** uri : 
    """
    soilTemp'array[float]'
    minSoilTemp:float
    maxSoilTemp:float
    aveSoilTemp:float
    morningSoilTemp'array[float]'
    tempNew'array[float]'
    heatCapacity'array[float]'
    thermalConductivity'array[float]'
    thermalConductance'array[float]'
    heatStorage'array[float]'
    (soilTemp,
    minSoilTemp,
    maxSoilTemp,
    aveSoilTemp,
    morningSoilTemp,
    tempNew,
    heatCapacity,
    thermalConductivity,
    thermalConductance,
    heatStorage) = model_campbell(NLAYR, THICK ,BD ,
    TMAX,
    TMIN,
    TAV,
    TAMP,
    XLAT,
    CLAY ,
    SW ,
    DEPTH ,
    DOY,
    canopyHeight,
    SALB,
    SRAD,
    ESP,
    EOAD,
    ESAD,
    soilTemp )
    return (soilTemp,
    minSoilTemp,
    maxSoilTemp,
    aveSoilTemp,
    morningSoilTemp,
    tempNew,
    heatCapacity,
    thermalConductivity,
    thermalConductance,
    heatStorage)
#%%CyML Model End%%