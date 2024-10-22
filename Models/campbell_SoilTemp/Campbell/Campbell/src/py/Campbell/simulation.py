from . import model_SoilTempCampbellComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_T2M = df[vardata.loc[vardata["Variables"]=="T2M","Data columns"].iloc[0]].to_list()
    t_TMAX = df[vardata.loc[vardata["Variables"]=="TMAX","Data columns"].iloc[0]].to_list()
    t_TMIN = df[vardata.loc[vardata["Variables"]=="TMIN","Data columns"].iloc[0]].to_list()
    t_TAV = df[vardata.loc[vardata["Variables"]=="TAV","Data columns"].iloc[0]].to_list()
    t_SW = df[vardata.loc[vardata["Variables"]=="SW","Data columns"].iloc[0]].to_list()
    t_DOY = df[vardata.loc[vardata["Variables"]=="DOY","Data columns"].iloc[0]].to_list()
    t_airPressure = df[vardata.loc[vardata["Variables"]=="airPressure","Data columns"].iloc[0]].to_list()
    t_canopyHeight = df[vardata.loc[vardata["Variables"]=="canopyHeight","Data columns"].iloc[0]].to_list()
    t_SRAD = df[vardata.loc[vardata["Variables"]=="SRAD","Data columns"].iloc[0]].to_list()
    t_ESP = df[vardata.loc[vardata["Variables"]=="ESP","Data columns"].iloc[0]].to_list()
    t_ES = df[vardata.loc[vardata["Variables"]=="ES","Data columns"].iloc[0]].to_list()
    t_EOAD = df[vardata.loc[vardata["Variables"]=="EOAD","Data columns"].iloc[0]].to_list()
    t_soilTemp = df[vardata.loc[vardata["Variables"]=="soilTemp","Data columns"].iloc[0]].to_list()
    t_newTemperature = df[vardata.loc[vardata["Variables"]=="newTemperature","Data columns"].iloc[0]].to_list()
    t_minSoilTemp = df[vardata.loc[vardata["Variables"]=="minSoilTemp","Data columns"].iloc[0]].to_list()
    t_maxSoilTemp = df[vardata.loc[vardata["Variables"]=="maxSoilTemp","Data columns"].iloc[0]].to_list()
    t_aveSoilTemp = df[vardata.loc[vardata["Variables"]=="aveSoilTemp","Data columns"].iloc[0]].to_list()
    t_morningSoilTemp = df[vardata.loc[vardata["Variables"]=="morningSoilTemp","Data columns"].iloc[0]].to_list()
    t_thermalCondPar1 = df[vardata.loc[vardata["Variables"]=="thermalCondPar1","Data columns"].iloc[0]].to_list()
    t_thermalCondPar2 = df[vardata.loc[vardata["Variables"]=="thermalCondPar2","Data columns"].iloc[0]].to_list()
    t_thermalCondPar3 = df[vardata.loc[vardata["Variables"]=="thermalCondPar3","Data columns"].iloc[0]].to_list()
    t_thermalCondPar4 = df[vardata.loc[vardata["Variables"]=="thermalCondPar4","Data columns"].iloc[0]].to_list()
    t_thermalConductivity = df[vardata.loc[vardata["Variables"]=="thermalConductivity","Data columns"].iloc[0]].to_list()
    t_thermalConductance = df[vardata.loc[vardata["Variables"]=="thermalConductance","Data columns"].iloc[0]].to_list()
    t_heatStorage = df[vardata.loc[vardata["Variables"]=="heatStorage","Data columns"].iloc[0]].to_list()
    t_volSpecHeatSoil = df[vardata.loc[vardata["Variables"]=="volSpecHeatSoil","Data columns"].iloc[0]].to_list()
    t_maxTempYesterday = df[vardata.loc[vardata["Variables"]=="maxTempYesterday","Data columns"].iloc[0]].to_list()
    t_minTempYesterday = df[vardata.loc[vardata["Variables"]=="minTempYesterday","Data columns"].iloc[0]].to_list()
    t_windSpeed = df[vardata.loc[vardata["Variables"]=="windSpeed","Data columns"].iloc[0]].to_list()
    t_SLCARB = df[vardata.loc[vardata["Variables"]=="SLCARB","Data columns"].iloc[0]].to_list()
    t_SLROCK = df[vardata.loc[vardata["Variables"]=="SLROCK","Data columns"].iloc[0]].to_list()
    t_SLSILT = df[vardata.loc[vardata["Variables"]=="SLSILT","Data columns"].iloc[0]].to_list()
    t_SLSAND = df[vardata.loc[vardata["Variables"]=="SLSAND","Data columns"].iloc[0]].to_list()
    t__boundaryLayerConductance = df[vardata.loc[vardata["Variables"]=="_boundaryLayerConductance","Data columns"].iloc[0]].to_list()

    #parameters
    NLAYR = params.loc[params["name"]=="NLAYR", "value"].iloc[0]
    THICK = params.loc[params["name"]=="THICK", "value"].iloc[0]
    DEPTH = params.loc[params["name"]=="DEPTH", "value"].iloc[0]
    CONSTANT_TEMPdepth = params.loc[params["name"]=="CONSTANT_TEMPdepth", "value"].iloc[0]
    BD = params.loc[params["name"]=="BD", "value"].iloc[0]
    TAMP = params.loc[params["name"]=="TAMP", "value"].iloc[0]
    XLAT = params.loc[params["name"]=="XLAT", "value"].iloc[0]
    CLAY = params.loc[params["name"]=="CLAY", "value"].iloc[0]
    SALB = params.loc[params["name"]=="SALB", "value"].iloc[0]
    instrumentHeight = params.loc[params["name"]=="instrumentHeight", "value"].iloc[0]
    boundaryLayerConductanceSource = params.loc[params["name"]=="boundaryLayerConductanceSource", "value"].iloc[0]
    netRadiationSource = params.loc[params["name"]=="netRadiationSource", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["soilTemp","minSoilTemp","maxSoilTemp","aveSoilTemp","morningSoilTemp","newTemperature","maxTempYesterday","minTempYesterday","thermalCondPar1","thermalCondPar2","thermalCondPar3","thermalCondPar4","thermalConductivity","thermalConductance","heatStorage","volSpecHeatSoil","_boundaryLayerConductance","SLROCK","SLCARB","SLSAND","SLSILT","airPressure"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        T2M = t_T2M[i]
        TMAX = t_TMAX[i]
        TMIN = t_TMIN[i]
        TAV = t_TAV[i]
        SW = t_SW[i]
        DOY = t_DOY[i]
        airPressure = t_airPressure[i]
        canopyHeight = t_canopyHeight[i]
        SRAD = t_SRAD[i]
        ESP = t_ESP[i]
        ES = t_ES[i]
        EOAD = t_EOAD[i]
        soilTemp = t_soilTemp[i]
        newTemperature = t_newTemperature[i]
        minSoilTemp = t_minSoilTemp[i]
        maxSoilTemp = t_maxSoilTemp[i]
        aveSoilTemp = t_aveSoilTemp[i]
        morningSoilTemp = t_morningSoilTemp[i]
        thermalCondPar1 = t_thermalCondPar1[i]
        thermalCondPar2 = t_thermalCondPar2[i]
        thermalCondPar3 = t_thermalCondPar3[i]
        thermalCondPar4 = t_thermalCondPar4[i]
        thermalConductivity = t_thermalConductivity[i]
        thermalConductance = t_thermalConductance[i]
        heatStorage = t_heatStorage[i]
        volSpecHeatSoil = t_volSpecHeatSoil[i]
        maxTempYesterday = t_maxTempYesterday[i]
        minTempYesterday = t_minTempYesterday[i]
        windSpeed = t_windSpeed[i]
        SLCARB = t_SLCARB[i]
        SLROCK = t_SLROCK[i]
        SLSILT = t_SLSILT[i]
        SLSAND = t_SLSAND[i]
        _boundaryLayerConductance = t__boundaryLayerConductance[i]
        soilTemp,minSoilTemp,maxSoilTemp,aveSoilTemp,morningSoilTemp,newTemperature,maxTempYesterday,minTempYesterday,thermalCondPar1,thermalCondPar2,thermalCondPar3,thermalCondPar4,thermalConductivity,thermalConductance,heatStorage,volSpecHeatSoil,_boundaryLayerConductance,SLROCK,SLCARB,SLSAND,SLSILT,airPressure= model_SoilTempCampbellComponent.model_model_soiltempcampbell(NLAYR,THICK,DEPTH,CONSTANT_TEMPdepth,BD,T2M,TMAX,TMIN,TAV,TAMP,XLAT,CLAY,SW,DOY,airPressure,canopyHeight,SALB,SRAD,ESP,ES,EOAD,soilTemp,newTemperature,minSoilTemp,maxSoilTemp,aveSoilTemp,morningSoilTemp,thermalCondPar1,thermalCondPar2,thermalCondPar3,thermalCondPar4,thermalConductivity,thermalConductance,heatStorage,volSpecHeatSoil,maxTempYesterday,minTempYesterday,instrumentHeight,boundaryLayerConductanceSource,netRadiationSource,windSpeed,SLCARB,SLROCK,SLSILT,SLSAND,_boundaryLayerConductance)

        df_out.loc[i] = [soilTemp,minSoilTemp,maxSoilTemp,aveSoilTemp,morningSoilTemp,newTemperature,maxTempYesterday,minTempYesterday,thermalCondPar1,thermalCondPar2,thermalCondPar3,thermalCondPar4,thermalConductivity,thermalConductance,heatStorage,volSpecHeatSoil,_boundaryLayerConductance,SLROCK,SLCARB,SLSAND,SLSILT,airPressure]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out