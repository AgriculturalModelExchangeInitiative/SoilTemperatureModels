from datetime import datetime
from math import *
from ApsimCampbell.soiltemperature import model_soiltemperature, init_soiltemperature
def model_soiltemp(float netRadiation,
      float aveSoilWater[],
      float bulkDensity[],
      float waterBalance_Eo,
      float thermCondPar1[],
      int topsoilNode,
      int surfaceNode,
      float internalTimeStep,
      float thermalConductance[],
      float thickness[],
      int numPhantomNodes,
      str soilConstituentNames[8],
      bool doInitialisationStuff,
      float maxTempYesterday,
      float waterBalance_Salb,
      float physical_Thickness[],
      float MissingValue,
      float timeOfDaySecs,
      int numNodes,
      float timestep,
      float organic_Carbon[],
      float waterBalance_Es,
      float weather_Wind,
      float soilWater[],
      float soilRoughnessHeight,
      float physical_ParticleSizeSand[],
      int numIterationsForBoundaryLayerConductance,
      float clay[],
      float weather_AirPressure,
      float soilTemp[],
      int clock_Today_DayOfYear,
      float silt[],
      float defaultTimeOfMaximumTemperature,
      float pom,
      float DepthToConstantTemperature,
      float microClimate_CanopyHeight,
      float constantBoundaryLayerConductance,
      float waterBalance_Eos,
      float instrumentHeight,
      float thermCondPar4[],
      float waterBalance_SW[],
      float weather_Amp,
      float nodeDepth[],
      float nu,
      float sand[],
      float pInitialValues[],
      float weather_MinT,
      float ps,
      str netRadiationSource,
      float weather_Radn,
      int airNode,
      int numLayers,
      float volSpecHeatSoil[],
      float instrumHeight,
      float canopyHeight,
      float heatStorage[],
      float minSoilTemp[],
      float bareSoilRoughness,
      float thermCondPar2[],
      float defaultInstrumentHeight,
      float maxSoilTemp[],
      float physical_BD[],
      float latentHeatOfVapourisation,
      float weather_Latitude,
      float physical_Rocks[],
      float stefanBoltzmannConstant,
      float weather_Tav,
      float newTemperature[],
      float airTemperature,
      float weather_MaxT,
      str boundarLayerConductanceSource,
      float thermalConductivity[],
      float minTempYesterday,
      float carbon[],
      float weather_MeanT,
      float rocks[],
      float InitialValues[],
      float thermCondPar3[],
      float physical_ParticleSizeSilt[],
      float boundaryLayerConductance,
      float physical_ParticleSizeClay[],
      float aveSoilTemp[],
      float morningSoilTemp[]):
    heatStorage, instrumentHeight, canopyHeight, minSoilTemp, maxSoilTemp, aveSoilTemp, volSpecHeatSoil, soilTemp, morningSoilTemp, newTemperature, thermalConductivity, thermalConductance, boundaryLayerConductance, soilWater, doInitialisationStuff, maxTempYesterday, minTempYesterday, airTemperature, internalTimeStep, timeOfDaySecs, netRadiation, InitialValues = model_soiltemperature(weather_MinT,weather_MaxT,weather_MeanT,weather_Tav,weather_Amp,weather_AirPressure,weather_Wind,weather_Latitude,weather_Radn,clock_Today_DayOfYear,microClimate_CanopyHeight,physical_Thickness,physical_BD,ps,physical_Rocks,physical_ParticleSizeSand,physical_ParticleSizeSilt,physical_ParticleSizeClay,organic_Carbon,waterBalance_SW,waterBalance_Eos,waterBalance_Eo,waterBalance_Es,waterBalance_Salb,InitialValues,pInitialValues,DepthToConstantTemperature,timestep,latentHeatOfVapourisation,stefanBoltzmannConstant,airNode,surfaceNode,topsoilNode,numPhantomNodes,constantBoundaryLayerConductance,numIterationsForBoundaryLayerConductance,defaultTimeOfMaximumTemperature,defaultInstrumentHeight,bareSoilRoughness,doInitialisationStuff,internalTimeStep,timeOfDaySecs,numNodes,numLayers,nodeDepth,thermCondPar1,thermCondPar2,thermCondPar3,thermCondPar4,volSpecHeatSoil,soilTemp,morningSoilTemp,heatStorage,thermalConductance,thermalConductivity,boundaryLayerConductance,newTemperature,airTemperature,maxTempYesterday,minTempYesterday,soilWater,minSoilTemp,maxSoilTemp,aveSoilTemp,aveSoilWater,thickness,bulkDensity,rocks,carbon,sand,pom,silt,clay,soilRoughnessHeight,instrumentHeight,netRadiation,canopyHeight,instrumHeight,nu,boundarLayerConductanceSource,netRadiationSource,MissingValue,soilConstituentNames)

    return (heatStorage, instrumentHeight, canopyHeight, minSoilTemp, maxSoilTemp, aveSoilTemp, volSpecHeatSoil, soilTemp, morningSoilTemp, newTemperature, thermalConductivity, thermalConductance, boundaryLayerConductance, soilWater, doInitialisationStuff, maxTempYesterday, minTempYesterday, airTemperature, internalTimeStep, timeOfDaySecs, netRadiation, InitialValues)

def init_soiltemp(float weather_MinT,
                    float weather_MaxT,
                    float weather_MeanT,
                    float weather_Tav,
                    float weather_Amp,
                    float weather_AirPressure,
                    float weather_Wind,
                    float weather_Latitude,
                    float weather_Radn,
                    int clock_Today_DayOfYear,
                    float microClimate_CanopyHeight,
                    float physical_Thickness[],
                    float physical_BD[],
                    float ps,
                    float physical_Rocks[],
                    float physical_ParticleSizeSand[],
                    float physical_ParticleSizeSilt[],
                    float physical_ParticleSizeClay[],
                    float organic_Carbon[],
                    float waterBalance_SW[],
                    float waterBalance_Eos,
                    float waterBalance_Eo,
                    float waterBalance_Es,
                    float waterBalance_Salb,
                    float pInitialValues[],
                    float DepthToConstantTemperature,
                    float timestep,
                    float latentHeatOfVapourisation,
                    float stefanBoltzmannConstant,
                    int airNode,
                    int surfaceNode,
                    int topsoilNode,
                    int numPhantomNodes,
                    float constantBoundaryLayerConductance,
                    int numIterationsForBoundaryLayerConductance,
                    float defaultTimeOfMaximumTemperature,
                    float defaultInstrumentHeight,
                    float bareSoilRoughness,
                    float nodeDepth[],
                    float thermCondPar1[],
                    float thermCondPar2[],
                    float thermCondPar3[],
                    float thermCondPar4[],
                    float pom,
                    float soilRoughnessHeight,
                    float nu,
                    str boundarLayerConductanceSource,
                    str netRadiationSource,
                    float MissingValue,
                    str soilConstituentNames[8]):

    cdef float netRadiation
    cdef float aveSoilWater[]
    cdef float bulkDensity[]
    cdef float internalTimeStep
    cdef float thermalConductance[]
    cdef float thickness[]
    cdef bool doInitialisationStuff
    cdef float maxTempYesterday
    cdef float timeOfDaySecs
    cdef int numNodes
    cdef float soilWater[]
    cdef float clay[]
    cdef float soilTemp[]
    cdef float silt[]
    cdef float instrumentHeight
    cdef float sand[]
    cdef int numLayers
    cdef float volSpecHeatSoil[]
    cdef float instrumHeight
    cdef float canopyHeight
    cdef float heatStorage[]
    cdef float minSoilTemp[]
    cdef float maxSoilTemp[]
    cdef float newTemperature[]
    cdef float airTemperature
    cdef float thermalConductivity[]
    cdef float minTempYesterday
    cdef float carbon[]
    cdef float rocks[]
    cdef float InitialValues[]
    cdef float boundaryLayerConductance
    cdef float aveSoilTemp[]
    cdef float morningSoilTemp[]
    InitialValues, doInitialisationStuff, internalTimeStep, timeOfDaySecs, numNodes, numLayers, nodeDepth, thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4, volSpecHeatSoil, soilTemp, morningSoilTemp, heatStorage, thermalConductance, thermalConductivity, boundaryLayerConductance, newTemperature, airTemperature, maxTempYesterday, minTempYesterday, soilWater, minSoilTemp, maxSoilTemp, aveSoilTemp, aveSoilWater, thickness, bulkDensity, rocks, carbon, sand, silt, clay, soilRoughnessHeight, instrumentHeight, netRadiation, canopyHeight, instrumHeight = init_soiltemperature(weather_MinT, weather_MaxT, weather_MeanT, weather_Tav, weather_Amp, weather_AirPressure, weather_Wind, weather_Latitude, weather_Radn, clock_Today_DayOfYear, microClimate_CanopyHeight, physical_Thickness, physical_BD, ps, physical_Rocks, physical_ParticleSizeSand, physical_ParticleSizeSilt, physical_ParticleSizeClay, organic_Carbon, waterBalance_SW, waterBalance_Eos, waterBalance_Eo, waterBalance_Es, waterBalance_Salb, pInitialValues, DepthToConstantTemperature, timestep, latentHeatOfVapourisation, stefanBoltzmannConstant, airNode, surfaceNode, topsoilNode, numPhantomNodes, constantBoundaryLayerConductance, numIterationsForBoundaryLayerConductance, defaultTimeOfMaximumTemperature, defaultInstrumentHeight, bareSoilRoughness, nodeDepth, thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4, pom, soilRoughnessHeight, nu, boundarLayerConductanceSource, netRadiationSource, MissingValue, soilConstituentNames)
    return (InitialValues, doInitialisationStuff, internalTimeStep, timeOfDaySecs, numNodes, numLayers, nodeDepth, thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4, volSpecHeatSoil, soilTemp, morningSoilTemp, heatStorage, thermalConductance, thermalConductivity, boundaryLayerConductance, newTemperature, airTemperature, maxTempYesterday, minTempYesterday, soilWater, minSoilTemp, maxSoilTemp, aveSoilTemp, aveSoilWater, thickness, bulkDensity, rocks, carbon, sand, silt, clay, soilRoughnessHeight, instrumentHeight, netRadiation, canopyHeight, instrumHeight)
