from . import SoilTemperatureComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_deepLayerT = df[vardata.loc[vardata["Variables"]=="deepLayerT","Data columns"].iloc[0]].to_list()
    t_heatFlux = df[vardata.loc[vardata["Variables"]=="heatFlux","Data columns"].iloc[0]].to_list()
    t_meanTAir = df[vardata.loc[vardata["Variables"]=="meanTAir","Data columns"].iloc[0]].to_list()
    t_minTAir = df[vardata.loc[vardata["Variables"]=="minTAir","Data columns"].iloc[0]].to_list()
    t_maxTAir = df[vardata.loc[vardata["Variables"]=="maxTAir","Data columns"].iloc[0]].to_list()
    t_dayLength = df[vardata.loc[vardata["Variables"]=="dayLength","Data columns"].iloc[0]].to_list()

    #parameters
    lambda_ = params.loc[params["name"]=="lambda_", "value"].iloc[0]
    a = params.loc[params["name"]=="a", "value"].iloc[0]
    b = params.loc[params["name"]=="b", "value"].iloc[0]
    c = params.loc[params["name"]=="c", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["deepLayerT_t1","maxTSoil","minTSoil","hourlySoilT"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        deepLayerT = t_deepLayerT[i]
        heatFlux = t_heatFlux[i]
        meanTAir = t_meanTAir[i]
        minTAir = t_minTAir[i]
        maxTAir = t_maxTAir[i]
        dayLength = t_dayLength[i]
        deepLayerT_t1,maxTSoil,minTSoil,hourlySoilT= SoilTemperatureComponent.model_soiltemperature(deepLayerT,lambda_,heatFlux,meanTAir,minTAir,maxTAir,a,b,c,dayLength)

        df_out.loc[i] = [deepLayerT_t1,maxTSoil,minTSoil,hourlySoilT]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out