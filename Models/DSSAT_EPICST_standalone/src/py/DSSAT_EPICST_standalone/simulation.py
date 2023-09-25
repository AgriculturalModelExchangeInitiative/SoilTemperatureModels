from . import STEMP_EPIC_Component
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_TAV = df[vardata.loc[vardata["Variables"]=="TAV","Data columns"].iloc[0]].to_list()
    t_RAIN = df[vardata.loc[vardata["Variables"]=="RAIN","Data columns"].iloc[0]].to_list()
    t_WetDay = df[vardata.loc[vardata["Variables"]=="WetDay","Data columns"].iloc[0]].to_list()
    t_SRFTEMP = df[vardata.loc[vardata["Variables"]=="SRFTEMP","Data columns"].iloc[0]].to_list()
    t_NDays = df[vardata.loc[vardata["Variables"]=="NDays","Data columns"].iloc[0]].to_list()
    t_BIOMAS = df[vardata.loc[vardata["Variables"]=="BIOMAS","Data columns"].iloc[0]].to_list()
    t_ST = df[vardata.loc[vardata["Variables"]=="ST","Data columns"].iloc[0]].to_list()
    t_SNOW = df[vardata.loc[vardata["Variables"]=="SNOW","Data columns"].iloc[0]].to_list()
    t_TMA = df[vardata.loc[vardata["Variables"]=="TMA","Data columns"].iloc[0]].to_list()
    t_TAVG = df[vardata.loc[vardata["Variables"]=="TAVG","Data columns"].iloc[0]].to_list()
    t_DEPIR = df[vardata.loc[vardata["Variables"]=="DEPIR","Data columns"].iloc[0]].to_list()
    t_TDL = df[vardata.loc[vardata["Variables"]=="TDL","Data columns"].iloc[0]].to_list()
    t_MULCHMASS = df[vardata.loc[vardata["Variables"]=="MULCHMASS","Data columns"].iloc[0]].to_list()
    t_TMAX = df[vardata.loc[vardata["Variables"]=="TMAX","Data columns"].iloc[0]].to_list()
    t_TMIN = df[vardata.loc[vardata["Variables"]=="TMIN","Data columns"].iloc[0]].to_list()
    t_X2_PREV = df[vardata.loc[vardata["Variables"]=="X2_PREV","Data columns"].iloc[0]].to_list()
    t_DSMID = df[vardata.loc[vardata["Variables"]=="DSMID","Data columns"].iloc[0]].to_list()
    t_TAMP = df[vardata.loc[vardata["Variables"]=="TAMP","Data columns"].iloc[0]].to_list()
    t_CUMDPT = df[vardata.loc[vardata["Variables"]=="CUMDPT","Data columns"].iloc[0]].to_list()

    #parameters
    DUL = params.loc[params["name"]=="DUL", "value"].iloc[0]
    NL = params.loc[params["name"]=="NL", "value"].iloc[0]
    NLAYR = params.loc[params["name"]=="NLAYR", "value"].iloc[0]
    DS = params.loc[params["name"]=="DS", "value"].iloc[0]
    ISWWAT = params.loc[params["name"]=="ISWWAT", "value"].iloc[0]
    BD = params.loc[params["name"]=="BD", "value"].iloc[0]
    LL = params.loc[params["name"]=="LL", "value"].iloc[0]
    DLAYR = params.loc[params["name"]=="DLAYR", "value"].iloc[0]
    SW = params.loc[params["name"]=="SW", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["CUMDPT","DSMID","TDL","TMA","NDays","WetDay","X2_PREV","SRFTEMP","ST"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        TAV = t_TAV[i]
        RAIN = t_RAIN[i]
        WetDay = t_WetDay[i]
        SRFTEMP = t_SRFTEMP[i]
        NDays = t_NDays[i]
        BIOMAS = t_BIOMAS[i]
        ST = t_ST[i]
        SNOW = t_SNOW[i]
        TMA = t_TMA[i]
        TAVG = t_TAVG[i]
        DEPIR = t_DEPIR[i]
        TDL = t_TDL[i]
        MULCHMASS = t_MULCHMASS[i]
        TMAX = t_TMAX[i]
        TMIN = t_TMIN[i]
        X2_PREV = t_X2_PREV[i]
        DSMID = t_DSMID[i]
        TAMP = t_TAMP[i]
        CUMDPT = t_CUMDPT[i]
        CUMDPT,DSMID,TDL,TMA,NDays,WetDay,X2_PREV,SRFTEMP,ST= STEMP_EPIC_Component.model_stemp_epic_(TAV,RAIN,DUL,WetDay,SRFTEMP,NDays,BIOMAS,NL,NLAYR,ST,SNOW,TMA,DS,ISWWAT,BD,TAVG,LL,DEPIR,DLAYR,TDL,MULCHMASS,TMAX,TMIN,X2_PREV,DSMID,TAMP,CUMDPT,SW)

        df_out.loc[i] = [CUMDPT,DSMID,TDL,TMA,NDays,WetDay,X2_PREV,SRFTEMP,ST]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out