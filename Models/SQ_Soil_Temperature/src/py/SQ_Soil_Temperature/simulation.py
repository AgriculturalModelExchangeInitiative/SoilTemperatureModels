from . import SoilTemperatureComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_meanTAir = df[vardata.loc[vardata["Variables"]=="meanTAir","Data columns"].iloc[0]].to_list()
    t_minTAir = df[vardata.loc[vardata["Variables"]=="minTAir","Data columns"].iloc[0]].to_list()
    t_meanAnnualAirTemp = df[vardata.loc[vardata["Variables"]=="meanAnnualAirTemp","Data columns"].iloc[0]].to_list()
    t_heatFlux = df[vardata.loc[vardata["Variables"]=="heatFlux","Data columns"].iloc[0]].to_list()
    t_maxTAir = df[vardata.loc[vardata["Variables"]=="maxTAir","Data columns"].iloc[0]].to_list()
    t_dayLength = df[vardata.loc[vardata["Variables"]=="dayLength","Data columns"].iloc[0]].to_list()

    #parameters
    lambda_ = params.loc[params["name"]=="lambda_", "value"].iloc[0]
    b = params.loc[params["name"]=="b", "value"].iloc[0]
    c = params.loc[params["name"]=="c", "value"].iloc[0]
    a = params.loc[params["name"]=="a", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["minTSoil","deepLayerT","maxTSoil","hourlySoilT"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        meanTAir = t_meanTAir[i]
        minTAir = t_minTAir[i]
        meanAnnualAirTemp = t_meanAnnualAirTemp[i]
        heatFlux = t_heatFlux[i]
        maxTAir = t_maxTAir[i]
        dayLength = t_dayLength[i]
        minTSoil,deepLayerT,maxTSoil,hourlySoilT= SoilTemperatureComponent.model_soiltemperature(meanTAir,minTAir,lambda_,meanAnnualAirTemp,heatFlux,maxTAir,b,c,a,dayLength)

        df_out.loc[i] = [minTSoil,deepLayerT,maxTSoil,hourlySoilT]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out