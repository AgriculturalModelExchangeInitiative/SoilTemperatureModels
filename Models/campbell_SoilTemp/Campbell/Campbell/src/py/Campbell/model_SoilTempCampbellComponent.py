# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from Campbell.campbell import model_campbell

def model_model_soiltempcampbell(NLAYR:int,
         THICK:'Array[float]',
         DEPTH:'Array[float]',
         CONSTANT_TEMPdepth:float,
         BD:'Array[float]',
         T2M:float,
         TMAX:float,
         TMIN:float,
         TAV:float,
         TAMP:float,
         XLAT:float,
         CLAY:'Array[float]',
         SW:'Array[float]',
         DOY:int,
         airPressure:float,
         canopyHeight:float,
         SALB:float,
         SRAD:float,
         ESP:float,
         ES:float,
         EOAD:float,
         soilTemp:'Array[float]',
         newTemperature:'Array[float]',
         minSoilTemp:'Array[float]',
         maxSoilTemp:'Array[float]',
         aveSoilTemp:'Array[float]',
         morningSoilTemp:'Array[float]',
         thermalCondPar1:'Array[float]',
         thermalCondPar2:'Array[float]',
         thermalCondPar3:'Array[float]',
         thermalCondPar4:'Array[float]',
         thermalConductivity:'Array[float]',
         thermalConductance:'Array[float]',
         heatStorage:'Array[float]',
         volSpecHeatSoil:'Array[float]',
         maxTempYesterday:float,
         minTempYesterday:float,
         instrumentHeight:float,
         boundaryLayerConductanceSource:str,
         netRadiationSource:str,
         windSpeed:float,
         SLCARB:'Array[float]',
         SLROCK:'Array[float]',
         SLSILT:'Array[float]',
         SLSAND:'Array[float]',
         _boundaryLayerConductance:float):
    (soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp, morningSoilTemp, newTemperature, maxTempYesterday, minTempYesterday, thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, thermalConductivity, thermalConductance, heatStorage, volSpecHeatSoil, _boundaryLayerConductance, THICK, DEPTH, BD, CLAY, SLROCK, SLCARB, SLSAND, SLSILT) = model_campbell(NLAYR, THICK, DEPTH, CONSTANT_TEMPdepth, BD, T2M, TMAX, TMIN, TAV, TAMP, XLAT, CLAY, SW, DOY, airPressure, canopyHeight, SALB, SRAD, ESP, ES, EOAD, soilTemp, newTemperature, minSoilTemp, maxSoilTemp, aveSoilTemp, morningSoilTemp, thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, thermalConductivity, thermalConductance, heatStorage, volSpecHeatSoil, maxTempYesterday, minTempYesterday, instrumentHeight, boundaryLayerConductanceSource, netRadiationSource, windSpeed, SLCARB, SLROCK, SLSILT, SLSAND, _boundaryLayerConductance)
    return (soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp, morningSoilTemp, newTemperature, maxTempYesterday, minTempYesterday, thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, thermalConductivity, thermalConductance, heatStorage, volSpecHeatSoil, _boundaryLayerConductance, THICK, DEPTH, BD, CLAY, SLROCK, SLCARB, SLSAND, SLSILT)