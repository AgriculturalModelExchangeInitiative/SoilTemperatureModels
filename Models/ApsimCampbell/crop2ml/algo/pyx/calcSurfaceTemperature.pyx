def calcSurfaceTemperature(float weather_MeanT,
         float weather_MaxT,
         float waterBalance_Salb,
         float weather_Radn):
    cdef float surfaceT 
    surfaceT=(1.0 - waterBalance_Salb) * (weather_MeanT + ((weather_MaxT - weather_MeanT) * sqrt(max(weather_Radn, 0.1) * 23.8846 / 800.0))) + (waterBalance_Salb * weather_MeanT)
    return surfaceT