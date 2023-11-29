from . import SurfaceSWATSoilSWATCComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_AboveGroundBiomass = df[vardata.loc[vardata["Variables"]=="AboveGroundBiomass","Data columns"].iloc[0]].to_list()
    t_Albedo = df[vardata.loc[vardata["Variables"]=="Albedo","Data columns"].iloc[0]].to_list()
    t_AirTemperatureMinimum = df[vardata.loc[vardata["Variables"]=="AirTemperatureMinimum","Data columns"].iloc[0]].to_list()
    t_WaterEquivalentOfSnowPack = df[vardata.loc[vardata["Variables"]=="WaterEquivalentOfSnowPack","Data columns"].iloc[0]].to_list()
    t_GlobalSolarRadiation = df[vardata.loc[vardata["Variables"]=="GlobalSolarRadiation","Data columns"].iloc[0]].to_list()
    t_AirTemperatureMaximum = df[vardata.loc[vardata["Variables"]=="AirTemperatureMaximum","Data columns"].iloc[0]].to_list()
    t_VolumetricWaterContent = df[vardata.loc[vardata["Variables"]=="VolumetricWaterContent","Data columns"].iloc[0]].to_list()

    #parameters
    AirTemperatureAnnualAverage = params.loc[params["name"]=="AirTemperatureAnnualAverage", "value"].iloc[0]
    SoilProfileDepth = params.loc[params["name"]=="SoilProfileDepth", "value"].iloc[0]
    BulkDensity = params.loc[params["name"]=="BulkDensity", "value"].iloc[0]
    LayerThickness = params.loc[params["name"]=="LayerThickness", "value"].iloc[0]
    LagCoefficient = params.loc[params["name"]=="LagCoefficient", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["SurfaceSoilTemperature","SoilTemperatureByLayers"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        AboveGroundBiomass = t_AboveGroundBiomass[i]
        Albedo = t_Albedo[i]
        AirTemperatureMinimum = t_AirTemperatureMinimum[i]
        WaterEquivalentOfSnowPack = t_WaterEquivalentOfSnowPack[i]
        GlobalSolarRadiation = t_GlobalSolarRadiation[i]
        AirTemperatureMaximum = t_AirTemperatureMaximum[i]
        VolumetricWaterContent = t_VolumetricWaterContent[i]
        SurfaceSoilTemperature,SoilTemperatureByLayers= SurfaceSWATSoilSWATCComponent.model_surfaceswatsoilswatc(AboveGroundBiomass,Albedo,AirTemperatureMinimum,WaterEquivalentOfSnowPack,GlobalSolarRadiation,AirTemperatureMaximum,AirTemperatureAnnualAverage,SoilProfileDepth,BulkDensity,VolumetricWaterContent,LayerThickness,LagCoefficient)

        df_out.loc[i] = [SurfaceSoilTemperature,SoilTemperatureByLayers]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out