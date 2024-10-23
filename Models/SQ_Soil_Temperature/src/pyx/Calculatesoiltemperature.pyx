import numpy
from math import *

def init_calculatesoiltemperature(float meanTAir,
                                  float minTAir,
                                  float lambda_,
                                  float meanAnnualAirTemp,
                                  float maxTAir):
    cdef float deepLayerT = 20.0
    deepLayerT=meanAnnualAirTemp
    return  deepLayerT

def model_calculatesoiltemperature(float meanTAir,
                                   float minTAir,
                                   float lambda_,
                                   float deepLayerT,
                                   float meanAnnualAirTemp,
                                   float heatFlux,
                                   float maxTAir):
    """
    CalculateSoilTemperature model
    Author: loic.manceau@inra.fr
    Reference: ('http://biomamodelling.org',)
    Institution: INRA
    ExtendedDescription: Calculation of minimum and maximum Soil temperature, Further used in shoot temperature estimate.
    ShortDescription: None
    """

    cdef float minTSoil
    cdef float maxTSoil
    cdef float tmp 
    tmp=meanAnnualAirTemp
    if maxTAir == float(-999) and minTAir == float(999):
        minTSoil=float(999)
        maxTSoil=float(-999)
        deepLayerT=0.0
    else:
        minTSoil=SoilMinimumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT)
        maxTSoil=SoilMaximumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT)
        deepLayerT=UpdateTemperature(minTSoil, maxTSoil, deepLayerT)
    return  minTSoil, deepLayerT, maxTSoil



def SoilTempB(float weatherMinTemp,
         float deepTemperature):
    return (weatherMinTemp + deepTemperature) / 2.0

def SoilTempA(float weatherMaxTemp,
         float weatherMeanTemp,
         float soilHeatFlux,
         float lambda_):
    cdef float TempAdjustment 
    cdef float SoilAvailableEnergy 
    TempAdjustment=-0.5 * weatherMeanTemp + 4.0 if weatherMeanTemp < 8.0 else float(0)
    SoilAvailableEnergy=soilHeatFlux * lambda_ / 1000
    cdef float result
    result = weatherMaxTemp + (11.2 * (1.0 - exp(-0.07 * (SoilAvailableEnergy - 5.5)))) + TempAdjustment
    return result

def SoilMinimumTemperature(float weatherMaxTemp,
         float weatherMeanTemp,
         float weatherMinTemp,
         float soilHeatFlux,
         float lambda_,
         float deepTemperature):
    return min(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature))


def SoilTempB(float weatherMinTemp,
         float deepTemperature):
    return (weatherMinTemp + deepTemperature) / 2.0

def SoilTempA(float weatherMaxTemp,
         float weatherMeanTemp,
         float soilHeatFlux,
         float lambda_):
    cdef float TempAdjustment
    cdef float SoilAvailableEnergy
    TempAdjustment=-0.5 * weatherMeanTemp + 4.0 if weatherMeanTemp < 8.0 else float(0)
    SoilAvailableEnergy=soilHeatFlux * lambda_ / 1000
    cdef float result
    result = weatherMaxTemp + (11.2 * (1.0 - exp(-0.07 * (SoilAvailableEnergy - 5.5)))) + TempAdjustment
    return result

def SoilMaximumTemperature(float weatherMaxTemp,
         float weatherMeanTemp,
         float weatherMinTemp,
         float soilHeatFlux,
         float lambda_,
         float deepTemperature):
    return max(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature))


def UpdateTemperature(float minSoilTemp,
         float maxSoilTemp,
         float Temperature):
    cdef float meanTemp 
    meanTemp=(minSoilTemp + maxSoilTemp) / 2.0
    Temperature=(9.0 * Temperature + meanTemp) / 10.0
    return Temperature


