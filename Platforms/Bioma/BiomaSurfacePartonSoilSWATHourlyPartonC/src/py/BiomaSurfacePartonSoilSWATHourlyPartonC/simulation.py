from . import SurfacePartonSoilSWATHourlyPartonCComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_DayLength = df[vardata.loc[vardata["Variables"]=="DayLength","Data columns"].iloc[0]].to_list()
    t_AirTemperatureMinimum = df[vardata.loc[vardata["Variables"]=="AirTemperatureMinimum","Data columns"].iloc[0]].to_list()
    t_GlobalSolarRadiation = df[vardata.loc[vardata["Variables"]=="GlobalSolarRadiation","Data columns"].iloc[0]].to_list()
    t_AirTemperatureMaximum = df[vardata.loc[vardata["Variables"]=="AirTemperatureMaximum","Data columns"].iloc[0]].to_list()
    t_AboveGroundBiomass = df[vardata.loc[vardata["Variables"]=="AboveGroundBiomass","Data columns"].iloc[0]].to_list()
    t_SoilProfileDepth = df[vardata.loc[vardata["Variables"]=="SoilProfileDepth","Data columns"].iloc[0]].to_list()
    t_LayerThickness = df[vardata.loc[vardata["Variables"]=="LayerThickness","Data columns"].iloc[0]].to_list()
    t_VolumetricWaterContent = df[vardata.loc[vardata["Variables"]=="VolumetricWaterContent","Data columns"].iloc[0]].to_list()
    t_BulkDensity = df[vardata.loc[vardata["Variables"]=="BulkDensity","Data columns"].iloc[0]].to_list()
    t_AirTemperatureAnnualAverage = df[vardata.loc[vardata["Variables"]=="AirTemperatureAnnualAverage","Data columns"].iloc[0]].to_list()
    t_Silt = df[vardata.loc[vardata["Variables"]=="Silt","Data columns"].iloc[0]].to_list()
    t_OrganicMatter = df[vardata.loc[vardata["Variables"]=="OrganicMatter","Data columns"].iloc[0]].to_list()
    t_Sand = df[vardata.loc[vardata["Variables"]=="Sand","Data columns"].iloc[0]].to_list()
    t_Clay = df[vardata.loc[vardata["Variables"]=="Clay","Data columns"].iloc[0]].to_list()
    t_HourOfSunset = df[vardata.loc[vardata["Variables"]=="HourOfSunset","Data columns"].iloc[0]].to_list()
    t_HourOfSunrise = df[vardata.loc[vardata["Variables"]=="HourOfSunrise","Data columns"].iloc[0]].to_list()

    #parameters
    LagCoefficient = params.loc[params["name"]=="LagCoefficient", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["SurfaceSoilTemperature","SurfaceTemperatureMaximum","SurfaceTemperatureMinimum","SoilTemperatureByLayers","HeatCapacity","ThermalConductivity","ThermalDiffusivity","SoilTemperatureMinimum","SoilTemperatureRangeByLayers","SoilTemperatureMaximum","SoilTemperatureByLayersHourly"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        DayLength = t_DayLength[i]
        AirTemperatureMinimum = t_AirTemperatureMinimum[i]
        GlobalSolarRadiation = t_GlobalSolarRadiation[i]
        AirTemperatureMaximum = t_AirTemperatureMaximum[i]
        AboveGroundBiomass = t_AboveGroundBiomass[i]
        SoilProfileDepth = t_SoilProfileDepth[i]
        LayerThickness = t_LayerThickness[i]
        VolumetricWaterContent = t_VolumetricWaterContent[i]
        BulkDensity = t_BulkDensity[i]
        AirTemperatureAnnualAverage = t_AirTemperatureAnnualAverage[i]
        Silt = t_Silt[i]
        OrganicMatter = t_OrganicMatter[i]
        Sand = t_Sand[i]
        Clay = t_Clay[i]
        HourOfSunset = t_HourOfSunset[i]
        HourOfSunrise = t_HourOfSunrise[i]
        SurfaceSoilTemperature,SurfaceTemperatureMaximum,SurfaceTemperatureMinimum,SoilTemperatureByLayers,HeatCapacity,ThermalConductivity,ThermalDiffusivity,SoilTemperatureMinimum,SoilTemperatureRangeByLayers,SoilTemperatureMaximum,SoilTemperatureByLayersHourly= SurfacePartonSoilSWATHourlyPartonCComponent.model_surfacepartonsoilswathourlypartonc(DayLength,AirTemperatureMinimum,GlobalSolarRadiation,AirTemperatureMaximum,AboveGroundBiomass,SoilProfileDepth,LayerThickness,LagCoefficient,VolumetricWaterContent,BulkDensity,AirTemperatureAnnualAverage,Silt,OrganicMatter,Sand,Clay,HourOfSunset,HourOfSunrise)

        df_out.loc[i] = [SurfaceSoilTemperature,SurfaceTemperatureMaximum,SurfaceTemperatureMinimum,SoilTemperatureByLayers,HeatCapacity,ThermalConductivity,ThermalDiffusivity,SoilTemperatureMinimum,SoilTemperatureRangeByLayers,SoilTemperatureMaximum,SoilTemperatureByLayersHourly]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out