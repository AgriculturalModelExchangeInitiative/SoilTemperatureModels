def SoilMaximumTemperature(float weatherMaxTemp,
         float weatherMeanTemp,
         float weatherMinTemp,
         float soilHeatFlux,
         float lambda_,
         float deepTemperature):
    return max(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature))