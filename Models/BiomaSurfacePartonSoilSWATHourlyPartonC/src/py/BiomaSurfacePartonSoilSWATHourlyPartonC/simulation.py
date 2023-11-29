from . import SurfacePartonSoilSWATHourlyPartonCComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_AirTemperatureMaximum = df[vardata.loc[vardata["Variables"]=="AirTemperatureMaximum","Data columns"].iloc[0]].to_list()
    t_GlobalSolarRadiation = df[vardata.loc[vardata["Variables"]=="GlobalSolarRadiation","Data columns"].iloc[0]].to_list()
    t_AirTemperatureMinimum = df[vardata.loc[vardata["Variables"]=="AirTemperatureMinimum","Data columns"].iloc[0]].to_list()
    t_AboveGroundBiomass = df[vardata.loc[vardata["Variables"]=="AboveGroundBiomass","Data columns"].iloc[0]].to_list()
    t_DayLength = df[vardata.loc[vardata["Variables"]=="DayLength","Data columns"].iloc[0]].to_list()
    t_VolumetricWaterContent = df[vardata.loc[vardata["Variables"]=="VolumetricWaterContent","Data columns"].iloc[0]].to_list()
    t_OrganicMatter = df[vardata.loc[vardata["Variables"]=="OrganicMatter","Data columns"].iloc[0]].to_list()
    t_Sand = df[vardata.loc[vardata["Variables"]=="Sand","Data columns"].iloc[0]].to_list()
    t_HourOfSunrise = df[vardata.loc[vardata["Variables"]=="HourOfSunrise","Data columns"].iloc[0]].to_list()
    t_HourOfSunset = df[vardata.loc[vardata["Variables"]=="HourOfSunset","Data columns"].iloc[0]].to_list()

    #parameters
    BulkDensity = params.loc[params["name"]=="BulkDensity", "value"].iloc[0]
    SoilProfileDepth = params.loc[params["name"]=="SoilProfileDepth", "value"].iloc[0]
    AirTemperatureAnnualAverage = params.loc[params["name"]=="AirTemperatureAnnualAverage", "value"].iloc[0]
    LagCoefficient = params.loc[params["name"]=="LagCoefficient", "value"].iloc[0]
    LayerThickness = params.loc[params["name"]=="LayerThickness", "value"].iloc[0]
    Clay = params.loc[params["name"]=="Clay", "value"].iloc[0]
    Silt = params.loc[params["name"]=="Silt", "value"].iloc[0]
    layersNumber = params.loc[params["name"]=="layersNumber", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["SurfaceSoilTemperature","SurfaceTemperatureMinimum","SurfaceTemperatureMaximum","SoilTemperatureByLayers","HeatCapacity","ThermalConductivity","ThermalDiffusivity","SoilTemperatureRangeByLayers","SoilTemperatureMinimum","SoilTemperatureMaximum","SoilTemperatureByLayersHourly"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        AirTemperatureMaximum = t_AirTemperatureMaximum[i]
        GlobalSolarRadiation = t_GlobalSolarRadiation[i]
        AirTemperatureMinimum = t_AirTemperatureMinimum[i]
        AboveGroundBiomass = t_AboveGroundBiomass[i]
        DayLength = t_DayLength[i]
        VolumetricWaterContent = t_VolumetricWaterContent[i]
        OrganicMatter = t_OrganicMatter[i]
        Sand = t_Sand[i]
        HourOfSunrise = t_HourOfSunrise[i]
        HourOfSunset = t_HourOfSunset[i]
        SurfaceSoilTemperature,SurfaceTemperatureMinimum,SurfaceTemperatureMaximum,SoilTemperatureByLayers,HeatCapacity,ThermalConductivity,ThermalDiffusivity,SoilTemperatureRangeByLayers,SoilTemperatureMinimum,SoilTemperatureMaximum,SoilTemperatureByLayersHourly= SurfacePartonSoilSWATHourlyPartonCComponent.model_surfacepartonsoilswathourlypartonc(AirTemperatureMaximum,GlobalSolarRadiation,AirTemperatureMinimum,AboveGroundBiomass,DayLength,BulkDensity,SoilProfileDepth,AirTemperatureAnnualAverage,LagCoefficient,VolumetricWaterContent,LayerThickness,OrganicMatter,Clay,Sand,Silt,layersNumber,HourOfSunrise,HourOfSunset)

        df_out.loc[i] = [SurfaceSoilTemperature,SurfaceTemperatureMinimum,SurfaceTemperatureMaximum,SoilTemperatureByLayers,HeatCapacity,ThermalConductivity,ThermalDiffusivity,SoilTemperatureRangeByLayers,SoilTemperatureMinimum,SoilTemperatureMaximum,SoilTemperatureByLayersHourly]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out