from datetime import datetime
from math import *
from Campbell.campbell import model_campbell
def model_campbell(float CONSTANT_TEMPdepth,
      float SRAD,
      float THICK[NLAYR],
      float TMIN,
      float TMAX,
      float TAV,
      float instrumentHeight,
      str boundaryLayerConductanceSource,
      float ESP,
      int DOY,
      str netRadiationSource,
      float SALB,
      int NLAYR,
      float BD[NLAYR],
      float windSpeed,
      float DEPTH[NLAYR],
      float XLAT,
      float ES,
      float T2M,
      float TAMP,
      float CLAY[NLAYR],
      float EOAD,
      float SW[NLAYR],
      float canopyHeight):
    cdef float airPressure
    cdef float soilTemp[NLAYR]
    cdef float newTemperature[NLAYR]
    cdef float minSoilTemp[NLAYR]
    cdef float maxSoilTemp[NLAYR]
    cdef float aveSoilTemp[NLAYR]
    cdef float morningSoilTemp[NLAYR]
    cdef float thermalCondPar1[NLAYR]
    cdef float thermalCondPar2[NLAYR]
    cdef float thermalCondPar3[NLAYR]
    cdef float thermalCondPar4[NLAYR]
    cdef float thermalConductivity[NLAYR]
    cdef float thermalConductance[NLAYR]
    cdef float heatStorage[NLAYR]
    cdef float volSpecHeatSoil[NLAYR]
    cdef float maxTempYesterday
    cdef float minTempYesterday
    cdef float SLCARB[NLAYR]
    cdef float SLROCK[NLAYR]
    cdef float SLSILT[NLAYR]
    cdef float SLSAND[NLAYR]
    cdef float _boundaryLayerConductance
    soilTemp, newTemperature, minSoilTemp, maxSoilTemp, aveSoilTemp, morningSoilTemp, airPressure, thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, thermalConductivity, thermalConductance, heatStorage, volSpecHeatSoil, maxTempYesterday, minTempYesterday, SLCARB, SLROCK, SLSILT, SLSAND, _boundaryLayerConductance = model_campbell(NLAYR,CONSTANT_TEMPdepth,THICK,DEPTH,BD,T2M,TMAX,TMIN,TAV,TAMP,XLAT,CLAY,SW,DOY,airPressure,canopyHeight,SALB,SRAD,ESP,ES,EOAD,soilTemp,newTemperature,minSoilTemp,maxSoilTemp,aveSoilTemp,morningSoilTemp,thermalCondPar1,thermalCondPar2,thermalCondPar3,thermalCondPar4,thermalConductivity,thermalConductance,heatStorage,volSpecHeatSoil,maxTempYesterday,minTempYesterday,instrumentHeight,boundaryLayerConductanceSource,netRadiationSource,windSpeed,SLCARB,SLROCK,SLSILT,SLSAND,_boundaryLayerConductance)

    return soilTemp, newTemperature, minSoilTemp, maxSoilTemp, aveSoilTemp, morningSoilTemp, airPressure, thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, thermalConductivity, thermalConductance, heatStorage, volSpecHeatSoil, maxTempYesterday, minTempYesterday, SLCARB, SLROCK, SLSILT, SLSAND, _boundaryLayerConductance