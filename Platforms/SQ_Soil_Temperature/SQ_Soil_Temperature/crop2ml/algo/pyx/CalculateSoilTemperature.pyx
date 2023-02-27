if maxTAir == float(-999) and minTAir == float(999):
    minTSoil=float(999)
    maxTSoil=float(-999)
    deepLayerT_t1=0.0
else:
    minTSoil=SoilMinimumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT)
    maxTSoil=SoilMaximumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT_t1)
    deepLayerT_t1=UpdateTemperature(minTSoil, maxTSoil, deepLayerT)