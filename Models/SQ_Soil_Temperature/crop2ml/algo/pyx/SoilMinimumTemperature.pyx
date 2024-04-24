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