from . import STEMP_Component
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_SRFTEMP = df[vardata.loc[vardata["Variables"]=="SRFTEMP","Data columns"].iloc[0]].to_list()
    t_TAMP = df[vardata.loc[vardata["Variables"]=="TAMP","Data columns"].iloc[0]].to_list()
    t_HDAY = df[vardata.loc[vardata["Variables"]=="HDAY","Data columns"].iloc[0]].to_list()
    t_TMA = df[vardata.loc[vardata["Variables"]=="TMA","Data columns"].iloc[0]].to_list()
    t_CUMDPT = df[vardata.loc[vardata["Variables"]=="CUMDPT","Data columns"].iloc[0]].to_list()
    t_ATOT = df[vardata.loc[vardata["Variables"]=="ATOT","Data columns"].iloc[0]].to_list()
    t_TDL = df[vardata.loc[vardata["Variables"]=="TDL","Data columns"].iloc[0]].to_list()
    t_SRAD = df[vardata.loc[vardata["Variables"]=="SRAD","Data columns"].iloc[0]].to_list()
    t_TAV = df[vardata.loc[vardata["Variables"]=="TAV","Data columns"].iloc[0]].to_list()
    t_TMAX = df[vardata.loc[vardata["Variables"]=="TMAX","Data columns"].iloc[0]].to_list()
    t_TAVG = df[vardata.loc[vardata["Variables"]=="TAVG","Data columns"].iloc[0]].to_list()
    t_DOY = df[vardata.loc[vardata["Variables"]=="DOY","Data columns"].iloc[0]].to_list()
    t_DSMID = df[vardata.loc[vardata["Variables"]=="DSMID","Data columns"].iloc[0]].to_list()
    t_ST = df[vardata.loc[vardata["Variables"]=="ST","Data columns"].iloc[0]].to_list()

    #parameters
    XLAT = params.loc[params["name"]=="XLAT", "value"].iloc[0]
    ISWWAT = params.loc[params["name"]=="ISWWAT", "value"].iloc[0]
    NLAYR = params.loc[params["name"]=="NLAYR", "value"].iloc[0]
    DUL = params.loc[params["name"]=="DUL", "value"].iloc[0]
    DS = params.loc[params["name"]=="DS", "value"].iloc[0]
    LL = params.loc[params["name"]=="LL", "value"].iloc[0]
    BD = params.loc[params["name"]=="BD", "value"].iloc[0]
    MSALB = params.loc[params["name"]=="MSALB", "value"].iloc[0]
    NL = params.loc[params["name"]=="NL", "value"].iloc[0]
    DLAYR = params.loc[params["name"]=="DLAYR", "value"].iloc[0]
    SW = params.loc[params["name"]=="SW", "value"].iloc[0]

    #initialization

    #outputs
    output_names = ["CUMDPT","DSMID","TDL","TMA","ATOT","SRFTEMP","ST"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        SRFTEMP = t_SRFTEMP[i]
        TAMP = t_TAMP[i]
        HDAY = t_HDAY[i]
        TMA = t_TMA[i]
        CUMDPT = t_CUMDPT[i]
        ATOT = t_ATOT[i]
        TDL = t_TDL[i]
        SRAD = t_SRAD[i]
        TAV = t_TAV[i]
        TMAX = t_TMAX[i]
        TAVG = t_TAVG[i]
        DOY = t_DOY[i]
        DSMID = t_DSMID[i]
        ST = t_ST[i]
        CUMDPT,DSMID,TDL,TMA,ATOT,SRFTEMP,ST= STEMP_Component.model_stemp_(SRFTEMP,TAMP,XLAT,HDAY,TMA,CUMDPT,ISWWAT,NLAYR,ATOT,DUL,TDL,SRAD,DS,LL,TAV,TMAX,TAVG,BD,DOY,DSMID,MSALB,NL,DLAYR,ST,SW)

        df_out.loc[i] = [CUMDPT,DSMID,TDL,TMA,ATOT,SRFTEMP,ST]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out