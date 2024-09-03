# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Init Begin%%
def init_campbell(NLAYR: int,
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
#%%CyML Init End%%

def model_campbell(NLAYR: int,
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