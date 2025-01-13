cdef int i 
(soilWater, instrumentHeight, canopyHeight)=getOtherVariables(instrumentHeight, soilRoughnessHeight, numNodes, canopyHeight, microClimate_CanopyHeight, soilWater, waterBalance_SW, numLayers)
if doInitialisationStuff:
    if ValuesInArray(InitialValues, MissingValue):
        soilTemp=array('f', [0.0]*(numNodes + 1 + 1))
        soilTemp[topsoilNode:topsoilNode + len(InitialValues)]=InitialValues[0:0 + len(InitialValues)]
    else:
        soilTemp=calcSoilTemperature(soilTemp, surfaceNode, weather_Amp, clock_Today_DayOfYear, weather_Tav, numNodes, thickness, weather_Latitude)
        InitialValues=array('f', [0.0]*(numLayers))
        InitialValues[0:0 + numLayers]=soilTemp[topsoilNode:topsoilNode + numLayers]
    soilTemp[airNode]=weather_MeanT
    soilTemp[surfaceNode]=calcSurfaceTemperature(weather_MaxT, weather_Radn, weather_MeanT, waterBalance_Salb)
    for i in range(numNodes + 1 , len(soilTemp) , 1):
        soilTemp[i]=weather_Tav
    newTemperature[0:0 + len(soilTemp)]=soilTemp
    maxTempYesterday=weather_MaxT
    minTempYesterday=weather_MinT
    doInitialisationStuff=False
(soilTemp, thermalConductivity, minSoilTemp, newTemperature, morningSoilTemp, aveSoilTemp, maxSoilTemp, volSpecHeatSoil, thermalConductance, heatStorage, minTempYesterday, maxTempYesterday, boundaryLayerConductance, netRadiation, timeOfDaySecs, internalTimeStep, airTemperature)=doProcess(minTempYesterday, timestep, weather_MaxT, weather_MinT, numIterationsForBoundaryLayerConductance, soilTemp, maxTempYesterday, thermalConductivity, boundarLayerConductanceSource, minSoilTemp, boundaryLayerConductance, newTemperature, weather_MeanT, morningSoilTemp, aveSoilTemp, internalTimeStep, airTemperature, netRadiation, airNode, timeOfDaySecs, maxSoilTemp, constantBoundaryLayerConductance, weather_Latitude, clock_Today_DayOfYear, weather_Radn, numNodes, soilWater, volSpecHeatSoil, soilConstituentNames, surfaceNode, thickness, nodeDepth, MissingValue, pom, carbon, bulkDensity, rocks, sand, ps, silt, clay, defaultTimeOfMaximumTemperature, waterBalance_Eos, waterBalance_Eo, waterBalance_Salb, stefanBoltzmannConstant, instrumentHeight, canopyHeight, weather_AirPressure, weather_Wind, thermalConductance, nu, heatStorage, waterBalance_Es, latentHeatOfVapourisation, netRadiationSource)