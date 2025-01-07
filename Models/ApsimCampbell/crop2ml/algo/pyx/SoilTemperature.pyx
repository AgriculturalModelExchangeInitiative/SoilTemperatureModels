cdef int i 
(soilWater, canopyHeight, instrumentHeight)=getOtherVariables(soilWater, instrumentHeight, microClimate_CanopyHeight, waterBalance_SW, numNodes, canopyHeight, soilRoughnessHeight, numLayers)
if doInitialisationStuff:
    if ValuesInArray(InitialValues, MissingValue):
        soilTemp=array('f', [0.0]*(numNodes + 1 + 1))
        soilTemp[topsoilNode:topsoilNode + len(InitialValues)]=InitialValues[0:0 + len(InitialValues)]
    else:
        soilTemp=calcSoilTemperature(soilTemp, weather_Latitude, weather_Amp, numNodes, clock_Today_DayOfYear, weather_Tav, surfaceNode, thickness)
        InitialValues=array('f', [0.0]*(numLayers))
        InitialValues[0:0 + numLayers]=soilTemp[topsoilNode:topsoilNode + numLayers]
    soilTemp[airNode]=weather_MeanT
    soilTemp[surfaceNode]=calcSurfaceTemperature(waterBalance_Salb, weather_MeanT, weather_Radn, weather_MaxT)
    for i in range(numNodes + 1 , len(soilTemp) , 1):
        soilTemp[i]=weather_Tav
    newTemperature[0:0 + len(soilTemp)]=soilTemp
    maxTempYesterday=weather_MaxT
    minTempYesterday=weather_MinT
    doInitialisationStuff=False
(maxSoilTemp, minSoilTemp, thermalConductivity, soilTemp, morningSoilTemp, newTemperature, aveSoilTemp, volSpecHeatSoil, thermalConductance, heatStorage, timeOfDaySecs, boundaryLayerConductance, minTempYesterday, maxTempYesterday, airTemperature, netRadiation, internalTimeStep)=doProcess(maxSoilTemp, minSoilTemp, weather_MaxT, numIterationsForBoundaryLayerConductance, maxTempYesterday, thermalConductivity, timeOfDaySecs, soilTemp, weather_MeanT, morningSoilTemp, newTemperature, boundaryLayerConductance, constantBoundaryLayerConductance, airTemperature, timestep, weather_MinT, airNode, netRadiation, aveSoilTemp, minTempYesterday, internalTimeStep, boundarLayerConductanceSource, clock_Today_DayOfYear, weather_Latitude, weather_Radn, soilConstituentNames, soilWater, volSpecHeatSoil, numNodes, nodeDepth, surfaceNode, thickness, MissingValue, bulkDensity, carbon, pom, rocks, ps, sand, silt, clay, defaultTimeOfMaximumTemperature, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, stefanBoltzmannConstant, weather_AirPressure, instrumentHeight, weather_Wind, canopyHeight, netRadiationSource, thermalConductance, waterBalance_Es, heatStorage, latentHeatOfVapourisation, nu)