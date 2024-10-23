from datetime import datetime
from math import *
from SQ_Soil_Temperature.calculatesoiltemperature import model_calculatesoiltemperature
from SQ_Soil_Temperature.calculatehourlysoiltemperature import model_calculatehourlysoiltemperature
def model_soiltemperature(float meanTAir,
      float minTAir,
      float lambda_,
      float meanAnnualAirTemp,
      float heatFlux,
      float maxTAir,
      float b,
      float c,
      float a,
      float dayLength):
    cdef float deepLayerT
    cdef float minTSoil
    cdef float maxTSoil
    cdef float hourlySoilT[24]
    minTSoil, deepLayerT, maxTSoil = model_calculatesoiltemperature(meanTAir,minTAir,lambda_,deepLayerT,meanAnnualAirTemp,heatFlux,maxTAir)
    hourlySoilT = model_calculatehourlysoiltemperature(minTSoil,dayLength,b,a,maxTSoil,c)

    return minTSoil, deepLayerT, maxTSoil, hourlySoilT