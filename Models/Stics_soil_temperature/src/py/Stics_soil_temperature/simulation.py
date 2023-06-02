from . import soil_tempComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_min_temp = df[vardata.loc[vardata["Variables"]=="min_temp","Data columns"].iloc[0]].to_list()
    t_max_temp = df[vardata.loc[vardata["Variables"]=="max_temp","Data columns"].iloc[0]].to_list()
    t_prev_temp_profile = df[vardata.loc[vardata["Variables"]=="prev_temp_profile","Data columns"].iloc[0]].to_list()
    t_prev_canopy_temp = df[vardata.loc[vardata["Variables"]=="prev_canopy_temp","Data columns"].iloc[0]].to_list()
    t_min_air_temp = df[vardata.loc[vardata["Variables"]=="min_air_temp","Data columns"].iloc[0]].to_list()
    t_min_canopy_temp = df[vardata.loc[vardata["Variables"]=="min_canopy_temp","Data columns"].iloc[0]].to_list()
    t_max_canopy_temp = df[vardata.loc[vardata["Variables"]=="max_canopy_temp","Data columns"].iloc[0]].to_list()

    #parameters
    air_temp_day1 = params.loc[params["name"]=="air_temp_day1", "value"].iloc[0]
    layer_thick = params.loc[params["name"]=="layer_thick", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["temp_amp","temp_profile","layer_temp","canopy_temp_avg","prev_canopy_temp","prev_temp_profile"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        min_temp = t_min_temp[i]
        max_temp = t_max_temp[i]
        prev_temp_profile = t_prev_temp_profile[i]
        prev_canopy_temp = t_prev_canopy_temp[i]
        min_air_temp = t_min_air_temp[i]
        min_canopy_temp = t_min_canopy_temp[i]
        max_canopy_temp = t_max_canopy_temp[i]
        temp_amp,temp_profile,layer_temp,canopy_temp_avg,prev_canopy_temp,prev_temp_profile= soil_tempComponent.model_soil_temp(min_temp,max_temp,prev_temp_profile,prev_canopy_temp,min_air_temp,air_temp_day1,layer_thick,min_canopy_temp,max_canopy_temp)

        df_out.loc[i] = [temp_amp,temp_profile,layer_temp,canopy_temp_avg,prev_canopy_temp,prev_temp_profile]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out