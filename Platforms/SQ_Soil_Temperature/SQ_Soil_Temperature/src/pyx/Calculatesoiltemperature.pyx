import numpy 
from math import *
def model_calculatesoiltemperature(float deepLayerT,
                                   float lambda_,
                                   float heatFlux,
                                   float meanTAir,
                                   float minTAir,
                                   float deepLayerT_t1,
                                   float maxTAir):
    """

    CalculateSoilTemperature model
    Author: loic.manceau@inra.fr
    Reference: ('http://biomamodelling.org',)
    Institution: INRA
    ExtendedDescription: Calculation of minimum and maximum Soil temperature, Further used in shoot temperature estimate.
    ShortDescription: None

    """
    cdef float maxTSoil
    cdef float minTSoil
    if maxTAir == float(-999) and minTAir == float(999):
        minTSoil=float(999)
        maxTSoil=float(-999)
        deepLayerT_t1=0.0
    else:
        minTSoil=SoilMinimumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT)
        maxTSoil=SoilMaximumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT_t1)
        deepLayerT_t1=UpdateTemperature(minTSoil, maxTSoil, deepLayerT)
    return  deepLayerT_t1, maxTSoil, minTSoil


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
    return weatherMaxTemp + (11.2 * (1.0 - exp(-0.07 * (SoilAvailableEnergy - 5.5)))) + TempAdjustment

def SoilMinimumTemperature(float weatherMaxTemp,
         float weatherMeanTemp,
         float weatherMinTemp,
         float soilHeatFlux,
         float lambda_,
         float deepTemperature):
    return min(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature))


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


