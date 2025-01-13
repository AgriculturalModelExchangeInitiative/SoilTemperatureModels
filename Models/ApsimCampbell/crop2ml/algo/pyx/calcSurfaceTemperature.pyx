def calcSurfaceTemperature(float weather_MaxT,
         float weather_Radn,
         float weather_MeanT,
         float waterBalance_Salb):
    cdef float surfaceT 
    surfaceT=(1.0 - waterBalance_Salb) * (weather_MeanT + ((weather_MaxT - weather_MeanT) * sqrt(max(weather_Radn, 0.1) * 23.8846 / 800.0))) + (waterBalance_Salb * weather_MeanT)
    return surfaceT