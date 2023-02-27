from datetime import datetime
from math import *
from DSSAT_EPICST_standalone.stemp_epic import model_stemp_epic
def model_stemp_epic_(float DEPIR,
      int NLAYR,
      float SW[NL],
      float TAMP,
      int WetDay[30],
      int NDays,
      float X2_PREV,
      float TMIN,
      float SNOW,
      float DSMID[NL],
      float TDL,
      float ST[NL],
      str ISWWAT,
      float DUL[NL],
      float CUMDPT,
      float LL[NL],
      int NL,
      float BIOMAS,
      float TAV,
      float BD[NL],
      float TMA[5],
      float DLAYR[NL],
      float DS[NL],
      float SRFTEMP,
      float MULCHMASS,
      float RAIN,
      float TMAX,
      float TAVG):
    SRFTEMP, NDays, TDL, WetDay, ST, TMA, X2_PREV = model_stemp_epic( NL,ISWWAT,BD,DLAYR,DS,DUL,LL,NLAYR,TAMP,RAIN,CUMDPT,DSMID,SW,TAVG,TMAX,TMIN,TAV,SRFTEMP,NDays,TDL,WetDay,ST,TMA,X2_PREV,DEPIR,BIOMAS,MULCHMASS,SNOW)
    return SRFTEMP, NDays, TDL, WetDay, ST, TMA, X2_PREV