from datetime import datetime
from math import *
from DSSAT_EPICST_standalone.stemp_epic import model_stemp_epic
def model_stemp_epic_(float MULCHMASS,
      float DLAYR[NL],
      float TAV,
      float TMAX,
      float SRFTEMP,
      int NL,
      float TAMP,
      float DS[NL],
      float BIOMAS,
      float DSMID[NL],
      float BD[NL],
      float SNOW,
      float TDL,
      str ISWWAT,
      float DUL[NL],
      float RAIN,
      float LL[NL],
      float CUMDPT,
      float TMA[5],
      float ST[NL],
      int WetDay[30],
      float SW[NL],
      int NDays,
      float X2_PREV,
      float DEPIR,
      float TAVG,
      int NLAYR,
      float TMIN):
    SRFTEMP, NDays, TDL, WetDay, ST, TMA, X2_PREV = model_stemp_epic( NL,ISWWAT,BD,DLAYR,DS,DUL,LL,NLAYR,TAMP,RAIN,CUMDPT,DSMID,SW,TAVG,TMAX,TMIN,TAV,SRFTEMP,NDays,TDL,WetDay,ST,TMA,X2_PREV,DEPIR,BIOMAS,MULCHMASS,SNOW)
    return SRFTEMP, NDays, TDL, WetDay, ST, TMA, X2_PREV