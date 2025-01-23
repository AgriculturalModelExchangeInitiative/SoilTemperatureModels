cdef int i 
(soilWater, instrumentHeight, canopyHeight)=getOtherVariables(numLayers, numNodes, soilWater, instrumentHeight, soilRoughnessHeight, waterBalance_SW, microClimate_CanopyHeight, canopyHeight)
if doInitialisationStuff:
    if ValuesInArray(InitialValues, MissingValue):
        soilTemp=array('f', [0.0]*(numNodes + 1 + 1))
        soilTemp[topsoilNode:topsoilNode + len(InitialValues)]=InitialValues[0:0 + len(InitialValues)]
    else:
        soilTemp=calcSoilTemperature(soilTemp, weather_Tav, clock_Today_DayOfYear, surfaceNode, numNodes, weather_Amp, thickness, weather_Latitude)
        InitialValues=array('f', [0.0]*(numLayers))
        InitialValues[0:0 + numLayers]=soilTemp[topsoilNode:topsoilNode + numLayers]
    soilTemp[airNode]=weather_MeanT
    soilTemp[surfaceNode]=calcSurfaceTemperature(weather_MeanT, weather_MaxT, waterBalance_Salb, weather_Radn)
    for i in range(numNodes + 1 , len(soilTemp) , 1):
        soilTemp[i]=weather_Tav
    newTemperature[0:0 + len(soilTemp)]=soilTemp
    maxTempYesterday=weather_MaxT
    minTempYesterday=weather_MinT
    doInitialisationStuff=False
(minSoilTemp, maxSoilTemp, soilTemp, newTemperature, thermalConductivity, aveSoilTemp, morningSoilTemp, volSpecHeatSoil, heatStorage, thermalConductance, timeOfDaySecs, netRadiation, airTemperature, internalTimeStep, minTempYesterday, boundaryLayerConductance, maxTempYesterday)=doProcess(timeOfDaySecs, netRadiation, minSoilTemp, maxSoilTemp, numIterationsForBoundaryLayerConductance, timestep, boundaryLayerConductance, maxTempYesterday, airNode, soilTemp, airTemperature, newTemperature, weather_MaxT, internalTimeStep, boundarLayerConductanceSource, thermalConductivity, minTempYesterday, aveSoilTemp, morningSoilTemp, weather_MeanT, constantBoundaryLayerConductance, weather_MinT, clock_Today_DayOfYear, weather_Radn, weather_Latitude, soilConstituentNames, numNodes, volSpecHeatSoil, soilWater, nodeDepth, thickness, surfaceNode, MissingValue, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay, defaultTimeOfMaximumTemperature, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, stefanBoltzmannConstant, weather_AirPressure, weather_Wind, instrumentHeight, canopyHeight, heatStorage, netRadiationSource, latentHeatOfVapourisation, waterBalance_Es, thermalConductance, nu)