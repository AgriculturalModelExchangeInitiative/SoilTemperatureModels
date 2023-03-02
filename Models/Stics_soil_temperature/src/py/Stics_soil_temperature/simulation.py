from . import SoiltempComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_max_temp = df[vardata.loc[vardata["Variables"]=="max_temp","Data columns"].iloc[0]].to_list()
    t_min_temp = df[vardata.loc[vardata["Variables"]=="min_temp","Data columns"].iloc[0]].to_list()
    t_therm_diff = df[vardata.loc[vardata["Variables"]=="therm_diff","Data columns"].iloc[0]].to_list()
    t_temp_wave_freq = df[vardata.loc[vardata["Variables"]=="temp_wave_freq","Data columns"].iloc[0]].to_list()
    t_prev_temp_profile = df[vardata.loc[vardata["Variables"]=="prev_temp_profile","Data columns"].iloc[0]].to_list()
    t_prev_canopy_temp = df[vardata.loc[vardata["Variables"]=="prev_canopy_temp","Data columns"].iloc[0]].to_list()
    t_min_air_temp = df[vardata.loc[vardata["Variables"]=="min_air_temp","Data columns"].iloc[0]].to_list()

    #parameters

    #initialization

    #outputs
    output_names = ["temp_amp","therm_amp","temp_profile"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        max_temp = t_max_temp[i]
        min_temp = t_min_temp[i]
        therm_diff = t_therm_diff[i]
        temp_wave_freq = t_temp_wave_freq[i]
        prev_temp_profile = t_prev_temp_profile[i]
        prev_canopy_temp = t_prev_canopy_temp[i]
        min_air_temp = t_min_air_temp[i]
        temp_amp,therm_amp,temp_profile= SoiltempComponent.model_soiltemp(max_temp,min_temp,therm_diff,temp_wave_freq,prev_temp_profile,prev_canopy_temp,min_air_temp)

        df_out.loc[i] = [temp_amp,therm_amp,temp_profile]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out