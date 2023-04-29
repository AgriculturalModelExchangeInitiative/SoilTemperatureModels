from . import SurfacePartonSoilSWATCComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_DayLength = df[vardata.loc[vardata["Variables"]=="DayLength","Data columns"].iloc[0]].to_list()
    t_AirTemperatureMaximum = df[vardata.loc[vardata["Variables"]=="AirTemperatureMaximum","Data columns"].iloc[0]].to_list()
    t_AirTemperatureMinimum = df[vardata.loc[vardata["Variables"]=="AirTemperatureMinimum","Data columns"].iloc[0]].to_list()
    t_AboveGroundBiomass = df[vardata.loc[vardata["Variables"]=="AboveGroundBiomass","Data columns"].iloc[0]].to_list()
    t_GlobalSolarRadiation = df[vardata.loc[vardata["Variables"]=="GlobalSolarRadiation","Data columns"].iloc[0]].to_list()
    t_VolumetricWaterContent = df[vardata.loc[vardata["Variables"]=="VolumetricWaterContent","Data columns"].iloc[0]].to_list()
    t_LayerThickness = df[vardata.loc[vardata["Variables"]=="LayerThickness","Data columns"].iloc[0]].to_list()
    t_AirTemperatureAnnualAverage = df[vardata.loc[vardata["Variables"]=="AirTemperatureAnnualAverage","Data columns"].iloc[0]].to_list()
    t_BulkDensity = df[vardata.loc[vardata["Variables"]=="BulkDensity","Data columns"].iloc[0]].to_list()
    t_SoilProfileDepth = df[vardata.loc[vardata["Variables"]=="SoilProfileDepth","Data columns"].iloc[0]].to_list()

    #parameters
    LagCoefficient = params.loc[params["name"]=="LagCoefficient", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["SurfaceTemperatureMinimum","SurfaceTemperatureMaximum","SurfaceSoilTemperature","SoilTemperatureByLayers"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        DayLength = t_DayLength[i]
        AirTemperatureMaximum = t_AirTemperatureMaximum[i]
        AirTemperatureMinimum = t_AirTemperatureMinimum[i]
        AboveGroundBiomass = t_AboveGroundBiomass[i]
        GlobalSolarRadiation = t_GlobalSolarRadiation[i]
        VolumetricWaterContent = t_VolumetricWaterContent[i]
        LayerThickness = t_LayerThickness[i]
        AirTemperatureAnnualAverage = t_AirTemperatureAnnualAverage[i]
        BulkDensity = t_BulkDensity[i]
        SoilProfileDepth = t_SoilProfileDepth[i]
        SurfaceTemperatureMinimum,SurfaceTemperatureMaximum,SurfaceSoilTemperature,SoilTemperatureByLayers= SurfacePartonSoilSWATCComponent.model_surfacepartonsoilswatc(DayLength,AirTemperatureMaximum,AirTemperatureMinimum,AboveGroundBiomass,GlobalSolarRadiation,VolumetricWaterContent,LayerThickness,LagCoefficient,AirTemperatureAnnualAverage,BulkDensity,SoilProfileDepth)

        df_out.loc[i] = [SurfaceTemperatureMinimum,SurfaceTemperatureMaximum,SurfaceSoilTemperature,SoilTemperatureByLayers]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out