from datetime import datetime
from math import *
from SQ_Soil_Temperature.calculatesoiltemperature import model_calculatesoiltemperature
from SQ_Soil_Temperature.calculatehourlysoiltemperature import model_calculatehourlysoiltemperature
def model_soiltemperature(float deepLayerT,
      float lambda_,
      float heatFlux,
      float meanTAir,
      float minTAir,
      float maxTAir,
      float a,
      float b,
      float c,
      float dayLength):
    cdef float deepLayerT_t1
    cdef float maxTSoil
    cdef float minTSoil
    cdef float hourlySoilT[24]
    deepLayerT_t1, maxTSoil, minTSoil = model_calculatesoiltemperature( deepLayerT,lambda_,heatFlux,meanTAir,minTAir,deepLayerT_t1,maxTAir)
    hourlySoilT = model_calculatehourlysoiltemperature( c,dayLength,maxTSoil,b,a,minTSoil)
    return deepLayerT_t1, maxTSoil, minTSoil, hourlySoilT