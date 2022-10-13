from datetime import datetime
from math import *
from DSSAT_EPICST_standalone.stemp_epic import model_stemp_epic
def model_stemp_epic_(float DS[NL],
      float TAVG,
      float TAV,
      str ISWWAT,
      float CUMDPT,
      float DSMID[NL],
      float LL[NL],
      float DLAYR[NL],
      float BD[NL],
      float TMAX,
      float TMA[5],
      float SW[NL],
      float MULCHMASS,
      int NLAYR,
      float SNOW,
      float BIOMAS,
      int NDays,
      int WetDay[30],
      float TDL,
      int NL,
      float DEPIR,
      float DUL[NL],
      float TMIN,
      float ST[NL],
      float X2_PREV,
      float RAIN,
      float TAMP,
      float SRFTEMP):
    SRFTEMP, NDays, TDL, WetDay, ST, TMA, X2_PREV = model_stemp_epic( NL,ISWWAT,BD,DLAYR,DS,DUL,LL,NLAYR,TAMP,RAIN,CUMDPT,DSMID,SW,TAVG,TMAX,TMIN,TAV,SRFTEMP,NDays,TDL,WetDay,ST,TMA,X2_PREV,DEPIR,BIOMAS,MULCHMASS,SNOW)
    return SRFTEMP, NDays, TDL, WetDay, ST, TMA, X2_PREV