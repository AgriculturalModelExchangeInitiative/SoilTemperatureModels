from . import SoilTemperatureComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_iAirTemperatureMax = df[vardata.loc[vardata["Variables"]=="iAirTemperatureMax","Data columns"].iloc[0]].to_list()
    t_iAirTemperatureMin = df[vardata.loc[vardata["Variables"]=="iAirTemperatureMin","Data columns"].iloc[0]].to_list()
    t_iGlobalSolarRadiation = df[vardata.loc[vardata["Variables"]=="iGlobalSolarRadiation","Data columns"].iloc[0]].to_list()
    t_iRAIN = df[vardata.loc[vardata["Variables"]=="iRAIN","Data columns"].iloc[0]].to_list()
    t_iCropResidues = df[vardata.loc[vardata["Variables"]=="iCropResidues","Data columns"].iloc[0]].to_list()
    t_iPotentialSoilEvaporation = df[vardata.loc[vardata["Variables"]=="iPotentialSoilEvaporation","Data columns"].iloc[0]].to_list()
    t_iLeafAreaIndex = df[vardata.loc[vardata["Variables"]=="iLeafAreaIndex","Data columns"].iloc[0]].to_list()
    t_SoilTempArray = df[vardata.loc[vardata["Variables"]=="SoilTempArray","Data columns"].iloc[0]].to_list()
    t_iSoilWaterContent = df[vardata.loc[vardata["Variables"]=="iSoilWaterContent","Data columns"].iloc[0]].to_list()
    t_pInternalAlbedo = df[vardata.loc[vardata["Variables"]=="pInternalAlbedo","Data columns"].iloc[0]].to_list()
    t_SnowWaterContent = df[vardata.loc[vardata["Variables"]=="SnowWaterContent","Data columns"].iloc[0]].to_list()
    t_SoilSurfaceTemperature = df[vardata.loc[vardata["Variables"]=="SoilSurfaceTemperature","Data columns"].iloc[0]].to_list()
    t_AgeOfSnow = df[vardata.loc[vardata["Variables"]=="AgeOfSnow","Data columns"].iloc[0]].to_list()
    t_rSoilTempArrayRate = df[vardata.loc[vardata["Variables"]=="rSoilTempArrayRate","Data columns"].iloc[0]].to_list()
    t_pSoilLayerDepth = df[vardata.loc[vardata["Variables"]=="pSoilLayerDepth","Data columns"].iloc[0]].to_list()

    #parameters
    cCarbonContent = params.loc[params["name"]=="cCarbonContent", "value"].iloc[0]
    cAlbedo = params.loc[params["name"]=="cAlbedo", "value"].iloc[0]
    cInitialAgeOfSnow = params.loc[params["name"]=="cInitialAgeOfSnow", "value"].iloc[0]
    cInitialSnowWaterContent = params.loc[params["name"]=="cInitialSnowWaterContent", "value"].iloc[0]
    cSnowIsolationFactorA = params.loc[params["name"]=="cSnowIsolationFactorA", "value"].iloc[0]
    cSnowIsolationFactorB = params.loc[params["name"]=="cSnowIsolationFactorB", "value"].iloc[0]
    cSoilLayerDepth = params.loc[params["name"]=="cSoilLayerDepth", "value"].iloc[0]
    cFirstDayMeanTemp = params.loc[params["name"]=="cFirstDayMeanTemp", "value"].iloc[0]
    cAverageGroundTemperature = params.loc[params["name"]=="cAverageGroundTemperature", "value"].iloc[0]
    cAverageBulkDensity = params.loc[params["name"]=="cAverageBulkDensity", "value"].iloc[0]
    cDampingDepth = params.loc[params["name"]=="cDampingDepth", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["SoilSurfaceTemperature","SnowIsolationIndex","SnowWaterContent","rSnowWaterContentRate","rSoilSurfaceTemperatureRate","rAgeOfSnowRate","AgeOfSnow","SoilTempArray","rSoilTempArrayRate"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        iAirTemperatureMax = t_iAirTemperatureMax[i]
        iAirTemperatureMin = t_iAirTemperatureMin[i]
        iGlobalSolarRadiation = t_iGlobalSolarRadiation[i]
        iRAIN = t_iRAIN[i]
        iCropResidues = t_iCropResidues[i]
        iPotentialSoilEvaporation = t_iPotentialSoilEvaporation[i]
        iLeafAreaIndex = t_iLeafAreaIndex[i]
        SoilTempArray = t_SoilTempArray[i]
        iSoilWaterContent = t_iSoilWaterContent[i]
        pInternalAlbedo = t_pInternalAlbedo[i]
        SnowWaterContent = t_SnowWaterContent[i]
        SoilSurfaceTemperature = t_SoilSurfaceTemperature[i]
        AgeOfSnow = t_AgeOfSnow[i]
        rSoilTempArrayRate = t_rSoilTempArrayRate[i]
        pSoilLayerDepth = t_pSoilLayerDepth[i]
        SoilSurfaceTemperature,SnowIsolationIndex,SnowWaterContent,rSnowWaterContentRate,rSoilSurfaceTemperatureRate,rAgeOfSnowRate,AgeOfSnow,SoilTempArray,rSoilTempArrayRate= SoilTemperatureComponent.model_soiltemperature(cCarbonContent,cAlbedo,cInitialAgeOfSnow,cInitialSnowWaterContent,cSnowIsolationFactorA,cSnowIsolationFactorB,iAirTemperatureMax,iAirTemperatureMin,iGlobalSolarRadiation,iRAIN,iCropResidues,iPotentialSoilEvaporation,iLeafAreaIndex,SoilTempArray,cSoilLayerDepth,cFirstDayMeanTemp,cAverageGroundTemperature,cAverageBulkDensity,cDampingDepth,iSoilWaterContent,pInternalAlbedo,SnowWaterContent,SoilSurfaceTemperature,AgeOfSnow,rSoilTempArrayRate,pSoilLayerDepth)

        df_out.loc[i] = [SoilSurfaceTemperature,SnowIsolationIndex,SnowWaterContent,rSnowWaterContentRate,rSoilSurfaceTemperatureRate,rAgeOfSnowRate,AgeOfSnow,SoilTempArray,rSoilTempArrayRate]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out