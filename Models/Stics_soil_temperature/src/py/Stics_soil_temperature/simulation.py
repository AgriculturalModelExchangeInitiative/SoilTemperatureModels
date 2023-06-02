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
    t_temp_wave_freq = df[vardata.loc[vardata["Variables"]=="temp_wave_freq","Data columns"].iloc[0]].to_list()
    t_therm_diff = df[vardata.loc[vardata["Variables"]=="therm_diff","Data columns"].iloc[0]].to_list()
    t_min_air_temp = df[vardata.loc[vardata["Variables"]=="min_air_temp","Data columns"].iloc[0]].to_list()
    t_min_canopy_temp = df[vardata.loc[vardata["Variables"]=="min_canopy_temp","Data columns"].iloc[0]].to_list()
    t_max_canopy_temp = df[vardata.loc[vardata["Variables"]=="max_canopy_temp","Data columns"].iloc[0]].to_list()

    #parameters
    layer_thick = params.loc[params["name"]=="layer_thick", "value"].iloc[0]
    air_temp_day1 = params.loc[params["name"]=="air_temp_day1", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["temp_amp","therm_amp","temp_profile","canopy_temp_avg","layer_temp","prev_temp_profile","prev_canopy_temp"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        min_temp = t_min_temp[i]
        max_temp = t_max_temp[i]
        temp_wave_freq = t_temp_wave_freq[i]
        therm_diff = t_therm_diff[i]
        min_air_temp = t_min_air_temp[i]
        min_canopy_temp = t_min_canopy_temp[i]
        max_canopy_temp = t_max_canopy_temp[i]
        temp_amp,therm_amp,temp_profile,canopy_temp_avg,layer_temp,prev_temp_profile,prev_canopy_temp= soil_tempComponent.model_soil_temp(min_temp,max_temp,temp_wave_freq,therm_diff,layer_thick,min_air_temp,air_temp_day1,min_canopy_temp,max_canopy_temp)

        df_out.loc[i] = [temp_amp,therm_amp,temp_profile,canopy_temp_avg,layer_temp,prev_temp_profile,prev_canopy_temp]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out