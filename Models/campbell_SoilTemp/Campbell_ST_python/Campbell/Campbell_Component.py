# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from Campbell.campbell import model_campbell

#%%CyML Model Begin%%
def model_SoilTemperatureCampbell(NLAYR: int,
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
    """
    #%%CyML Compute Begin%%
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
    heatStorage) = model_campbell(
       NLAYR, THICK ,BD ,
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
       soilTemp)

    #%%CyML Compute End%%
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