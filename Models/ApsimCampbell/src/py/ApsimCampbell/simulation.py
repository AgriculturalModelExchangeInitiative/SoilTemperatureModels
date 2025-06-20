from . import SoiltempComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_netRadiation = df[vardata.loc[vardata["Variables"]=="netRadiation","Data columns"].iloc[0]].to_list()
    t_aveSoilWater = df[vardata.loc[vardata["Variables"]=="aveSoilWater","Data columns"].iloc[0]].to_list()
    t_bulkDensity = df[vardata.loc[vardata["Variables"]=="bulkDensity","Data columns"].iloc[0]].to_list()
    t_waterBalance_Eo = df[vardata.loc[vardata["Variables"]=="waterBalance_Eo","Data columns"].iloc[0]].to_list()
    t_internalTimeStep = df[vardata.loc[vardata["Variables"]=="internalTimeStep","Data columns"].iloc[0]].to_list()
    t_thermalConductance = df[vardata.loc[vardata["Variables"]=="thermalConductance","Data columns"].iloc[0]].to_list()
    t_thickness = df[vardata.loc[vardata["Variables"]=="thickness","Data columns"].iloc[0]].to_list()
    t_doInitialisationStuff = df[vardata.loc[vardata["Variables"]=="doInitialisationStuff","Data columns"].iloc[0]].to_list()
    t_maxTempYesterday = df[vardata.loc[vardata["Variables"]=="maxTempYesterday","Data columns"].iloc[0]].to_list()
    t_waterBalance_Salb = df[vardata.loc[vardata["Variables"]=="waterBalance_Salb","Data columns"].iloc[0]].to_list()
    t_timeOfDaySecs = df[vardata.loc[vardata["Variables"]=="timeOfDaySecs","Data columns"].iloc[0]].to_list()
    t_numNodes = df[vardata.loc[vardata["Variables"]=="numNodes","Data columns"].iloc[0]].to_list()
    t_organic_Carbon = df[vardata.loc[vardata["Variables"]=="organic_Carbon","Data columns"].iloc[0]].to_list()
    t_waterBalance_Es = df[vardata.loc[vardata["Variables"]=="waterBalance_Es","Data columns"].iloc[0]].to_list()
    t_weather_Wind = df[vardata.loc[vardata["Variables"]=="weather_Wind","Data columns"].iloc[0]].to_list()
    t_soilWater = df[vardata.loc[vardata["Variables"]=="soilWater","Data columns"].iloc[0]].to_list()
    t_physical_ParticleSizeSand = df[vardata.loc[vardata["Variables"]=="physical_ParticleSizeSand","Data columns"].iloc[0]].to_list()
    t_clay = df[vardata.loc[vardata["Variables"]=="clay","Data columns"].iloc[0]].to_list()
    t_weather_AirPressure = df[vardata.loc[vardata["Variables"]=="weather_AirPressure","Data columns"].iloc[0]].to_list()
    t_soilTemp = df[vardata.loc[vardata["Variables"]=="soilTemp","Data columns"].iloc[0]].to_list()
    t_clock_Today_DayOfYear = df[vardata.loc[vardata["Variables"]=="clock_Today_DayOfYear","Data columns"].iloc[0]].to_list()
    t_silt = df[vardata.loc[vardata["Variables"]=="silt","Data columns"].iloc[0]].to_list()
    t_microClimate_CanopyHeight = df[vardata.loc[vardata["Variables"]=="microClimate_CanopyHeight","Data columns"].iloc[0]].to_list()
    t_waterBalance_Eos = df[vardata.loc[vardata["Variables"]=="waterBalance_Eos","Data columns"].iloc[0]].to_list()
    t_instrumentHeight = df[vardata.loc[vardata["Variables"]=="instrumentHeight","Data columns"].iloc[0]].to_list()
    t_waterBalance_SW = df[vardata.loc[vardata["Variables"]=="waterBalance_SW","Data columns"].iloc[0]].to_list()
    t_weather_Amp = df[vardata.loc[vardata["Variables"]=="weather_Amp","Data columns"].iloc[0]].to_list()
    t_sand = df[vardata.loc[vardata["Variables"]=="sand","Data columns"].iloc[0]].to_list()
    t_weather_MinT = df[vardata.loc[vardata["Variables"]=="weather_MinT","Data columns"].iloc[0]].to_list()
    t_weather_Radn = df[vardata.loc[vardata["Variables"]=="weather_Radn","Data columns"].iloc[0]].to_list()
    t_numLayers = df[vardata.loc[vardata["Variables"]=="numLayers","Data columns"].iloc[0]].to_list()
    t_volSpecHeatSoil = df[vardata.loc[vardata["Variables"]=="volSpecHeatSoil","Data columns"].iloc[0]].to_list()
    t_instrumHeight = df[vardata.loc[vardata["Variables"]=="instrumHeight","Data columns"].iloc[0]].to_list()
    t_canopyHeight = df[vardata.loc[vardata["Variables"]=="canopyHeight","Data columns"].iloc[0]].to_list()
    t_heatStorage = df[vardata.loc[vardata["Variables"]=="heatStorage","Data columns"].iloc[0]].to_list()
    t_minSoilTemp = df[vardata.loc[vardata["Variables"]=="minSoilTemp","Data columns"].iloc[0]].to_list()
    t_maxSoilTemp = df[vardata.loc[vardata["Variables"]=="maxSoilTemp","Data columns"].iloc[0]].to_list()
    t_physical_Rocks = df[vardata.loc[vardata["Variables"]=="physical_Rocks","Data columns"].iloc[0]].to_list()
    t_weather_Tav = df[vardata.loc[vardata["Variables"]=="weather_Tav","Data columns"].iloc[0]].to_list()
    t_newTemperature = df[vardata.loc[vardata["Variables"]=="newTemperature","Data columns"].iloc[0]].to_list()
    t_airTemperature = df[vardata.loc[vardata["Variables"]=="airTemperature","Data columns"].iloc[0]].to_list()
    t_weather_MaxT = df[vardata.loc[vardata["Variables"]=="weather_MaxT","Data columns"].iloc[0]].to_list()
    t_thermalConductivity = df[vardata.loc[vardata["Variables"]=="thermalConductivity","Data columns"].iloc[0]].to_list()
    t_minTempYesterday = df[vardata.loc[vardata["Variables"]=="minTempYesterday","Data columns"].iloc[0]].to_list()
    t_carbon = df[vardata.loc[vardata["Variables"]=="carbon","Data columns"].iloc[0]].to_list()
    t_weather_MeanT = df[vardata.loc[vardata["Variables"]=="weather_MeanT","Data columns"].iloc[0]].to_list()
    t_rocks = df[vardata.loc[vardata["Variables"]=="rocks","Data columns"].iloc[0]].to_list()
    t_InitialValues = df[vardata.loc[vardata["Variables"]=="InitialValues","Data columns"].iloc[0]].to_list()
    t_physical_ParticleSizeSilt = df[vardata.loc[vardata["Variables"]=="physical_ParticleSizeSilt","Data columns"].iloc[0]].to_list()
    t_boundaryLayerConductance = df[vardata.loc[vardata["Variables"]=="boundaryLayerConductance","Data columns"].iloc[0]].to_list()
    t_physical_ParticleSizeClay = df[vardata.loc[vardata["Variables"]=="physical_ParticleSizeClay","Data columns"].iloc[0]].to_list()
    t_aveSoilTemp = df[vardata.loc[vardata["Variables"]=="aveSoilTemp","Data columns"].iloc[0]].to_list()
    t_morningSoilTemp = df[vardata.loc[vardata["Variables"]=="morningSoilTemp","Data columns"].iloc[0]].to_list()

    #parameters
    thermCondPar1 = params.loc[params["name"]=="thermCondPar1", "value"].iloc[0]
    topsoilNode = params.loc[params["name"]=="topsoilNode", "value"].iloc[0]
    surfaceNode = params.loc[params["name"]=="surfaceNode", "value"].iloc[0]
    numPhantomNodes = params.loc[params["name"]=="numPhantomNodes", "value"].iloc[0]
    soilConstituentNames = params.loc[params["name"]=="soilConstituentNames", "value"].iloc[0]
    physical_Thickness = params.loc[params["name"]=="physical_Thickness", "value"].iloc[0]
    MissingValue = params.loc[params["name"]=="MissingValue", "value"].iloc[0]
    timestep = params.loc[params["name"]=="timestep", "value"].iloc[0]
    soilRoughnessHeight = params.loc[params["name"]=="soilRoughnessHeight", "value"].iloc[0]
    numIterationsForBoundaryLayerConductance = params.loc[params["name"]=="numIterationsForBoundaryLayerConductance", "value"].iloc[0]
    defaultTimeOfMaximumTemperature = params.loc[params["name"]=="defaultTimeOfMaximumTemperature", "value"].iloc[0]
    pom = params.loc[params["name"]=="pom", "value"].iloc[0]
    DepthToConstantTemperature = params.loc[params["name"]=="DepthToConstantTemperature", "value"].iloc[0]
    constantBoundaryLayerConductance = params.loc[params["name"]=="constantBoundaryLayerConductance", "value"].iloc[0]
    thermCondPar4 = params.loc[params["name"]=="thermCondPar4", "value"].iloc[0]
    nodeDepth = params.loc[params["name"]=="nodeDepth", "value"].iloc[0]
    nu = params.loc[params["name"]=="nu", "value"].iloc[0]
    pInitialValues = params.loc[params["name"]=="pInitialValues", "value"].iloc[0]
    ps = params.loc[params["name"]=="ps", "value"].iloc[0]
    netRadiationSource = params.loc[params["name"]=="netRadiationSource", "value"].iloc[0]
    airNode = params.loc[params["name"]=="airNode", "value"].iloc[0]
    bareSoilRoughness = params.loc[params["name"]=="bareSoilRoughness", "value"].iloc[0]
    thermCondPar2 = params.loc[params["name"]=="thermCondPar2", "value"].iloc[0]
    defaultInstrumentHeight = params.loc[params["name"]=="defaultInstrumentHeight", "value"].iloc[0]
    physical_BD = params.loc[params["name"]=="physical_BD", "value"].iloc[0]
    latentHeatOfVapourisation = params.loc[params["name"]=="latentHeatOfVapourisation", "value"].iloc[0]
    weather_Latitude = params.loc[params["name"]=="weather_Latitude", "value"].iloc[0]
    stefanBoltzmannConstant = params.loc[params["name"]=="stefanBoltzmannConstant", "value"].iloc[0]
    boundarLayerConductanceSource = params.loc[params["name"]=="boundarLayerConductanceSource", "value"].iloc[0]
    thermCondPar3 = params.loc[params["name"]=="thermCondPar3", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["heatStorage","instrumentHeight","canopyHeight","minSoilTemp","maxSoilTemp","aveSoilTemp","volSpecHeatSoil","soilTemp","morningSoilTemp","newTemperature","thermalConductivity","thermalConductance","boundaryLayerConductance","soilWater","doInitialisationStuff","maxTempYesterday","minTempYesterday","airTemperature","internalTimeStep","timeOfDaySecs","netRadiation","InitialValues"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        netRadiation = t_netRadiation[i]
        aveSoilWater = t_aveSoilWater[i]
        bulkDensity = t_bulkDensity[i]
        waterBalance_Eo = t_waterBalance_Eo[i]
        internalTimeStep = t_internalTimeStep[i]
        thermalConductance = t_thermalConductance[i]
        thickness = t_thickness[i]
        doInitialisationStuff = t_doInitialisationStuff[i]
        maxTempYesterday = t_maxTempYesterday[i]
        waterBalance_Salb = t_waterBalance_Salb[i]
        timeOfDaySecs = t_timeOfDaySecs[i]
        numNodes = t_numNodes[i]
        organic_Carbon = t_organic_Carbon[i]
        waterBalance_Es = t_waterBalance_Es[i]
        weather_Wind = t_weather_Wind[i]
        soilWater = t_soilWater[i]
        physical_ParticleSizeSand = t_physical_ParticleSizeSand[i]
        clay = t_clay[i]
        weather_AirPressure = t_weather_AirPressure[i]
        soilTemp = t_soilTemp[i]
        clock_Today_DayOfYear = t_clock_Today_DayOfYear[i]
        silt = t_silt[i]
        microClimate_CanopyHeight = t_microClimate_CanopyHeight[i]
        waterBalance_Eos = t_waterBalance_Eos[i]
        instrumentHeight = t_instrumentHeight[i]
        waterBalance_SW = t_waterBalance_SW[i]
        weather_Amp = t_weather_Amp[i]
        sand = t_sand[i]
        weather_MinT = t_weather_MinT[i]
        weather_Radn = t_weather_Radn[i]
        numLayers = t_numLayers[i]
        volSpecHeatSoil = t_volSpecHeatSoil[i]
        instrumHeight = t_instrumHeight[i]
        canopyHeight = t_canopyHeight[i]
        heatStorage = t_heatStorage[i]
        minSoilTemp = t_minSoilTemp[i]
        maxSoilTemp = t_maxSoilTemp[i]
        physical_Rocks = t_physical_Rocks[i]
        weather_Tav = t_weather_Tav[i]
        newTemperature = t_newTemperature[i]
        airTemperature = t_airTemperature[i]
        weather_MaxT = t_weather_MaxT[i]
        thermalConductivity = t_thermalConductivity[i]
        minTempYesterday = t_minTempYesterday[i]
        carbon = t_carbon[i]
        weather_MeanT = t_weather_MeanT[i]
        rocks = t_rocks[i]
        InitialValues = t_InitialValues[i]
        physical_ParticleSizeSilt = t_physical_ParticleSizeSilt[i]
        boundaryLayerConductance = t_boundaryLayerConductance[i]
        physical_ParticleSizeClay = t_physical_ParticleSizeClay[i]
        aveSoilTemp = t_aveSoilTemp[i]
        morningSoilTemp = t_morningSoilTemp[i]
        heatStorage,instrumentHeight,canopyHeight,minSoilTemp,maxSoilTemp,aveSoilTemp,volSpecHeatSoil,soilTemp,morningSoilTemp,newTemperature,thermalConductivity,thermalConductance,boundaryLayerConductance,soilWater,doInitialisationStuff,maxTempYesterday,minTempYesterday,airTemperature,internalTimeStep,timeOfDaySecs,netRadiation,InitialValues= SoiltempComponent.model_soiltemp(netRadiation,aveSoilWater,bulkDensity,waterBalance_Eo,thermCondPar1,topsoilNode,surfaceNode,internalTimeStep,thermalConductance,thickness,numPhantomNodes,soilConstituentNames,doInitialisationStuff,maxTempYesterday,waterBalance_Salb,physical_Thickness,MissingValue,timeOfDaySecs,numNodes,timestep,organic_Carbon,waterBalance_Es,weather_Wind,soilWater,soilRoughnessHeight,physical_ParticleSizeSand,numIterationsForBoundaryLayerConductance,clay,weather_AirPressure,soilTemp,clock_Today_DayOfYear,silt,defaultTimeOfMaximumTemperature,pom,DepthToConstantTemperature,microClimate_CanopyHeight,constantBoundaryLayerConductance,waterBalance_Eos,instrumentHeight,thermCondPar4,waterBalance_SW,weather_Amp,nodeDepth,nu,sand,pInitialValues,weather_MinT,ps,netRadiationSource,weather_Radn,airNode,numLayers,volSpecHeatSoil,instrumHeight,canopyHeight,heatStorage,minSoilTemp,bareSoilRoughness,thermCondPar2,defaultInstrumentHeight,maxSoilTemp,physical_BD,latentHeatOfVapourisation,weather_Latitude,physical_Rocks,stefanBoltzmannConstant,weather_Tav,newTemperature,airTemperature,weather_MaxT,boundarLayerConductanceSource,thermalConductivity,minTempYesterday,carbon,weather_MeanT,rocks,InitialValues,thermCondPar3,physical_ParticleSizeSilt,boundaryLayerConductance,physical_ParticleSizeClay,aveSoilTemp,morningSoilTemp)

        df_out.loc[i] = [heatStorage,instrumentHeight,canopyHeight,minSoilTemp,maxSoilTemp,aveSoilTemp,volSpecHeatSoil,soilTemp,morningSoilTemp,newTemperature,thermalConductivity,thermalConductance,boundaryLayerConductance,soilWater,doInitialisationStuff,maxTempYesterday,minTempYesterday,airTemperature,internalTimeStep,timeOfDaySecs,netRadiation,InitialValues]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out