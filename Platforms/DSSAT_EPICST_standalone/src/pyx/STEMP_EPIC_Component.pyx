from datetime import datetime
from math import *
from DSSAT_EPICST_standalone.stemp_epic import model_stemp_epic
def model_stemp_epic_(float DSMID[NL],
      float DEPIR,
      float LL[NL],
      float BD[NL],
      float X2_PREV,
      float CUMDPT,
      float SRFTEMP,
      str ISWWAT,
      float BIOMAS,
      float ST[NL],
      float SNOW,
      int NL,
      float RAIN,
      float TMAX,
      float TAV,
      float TAMP,
      float DS[NL],
      int NDays,
      float SW[NL],
      float TMIN,
      float MULCHMASS,
      float TDL,
      int NLAYR,
      float DUL[NL],
      float TMA[5],
      int WetDay[30],
      float TAVG,
      float DLAYR[NL]):
    SRFTEMP, NDays, TDL, WetDay, ST, TMA, X2_PREV = model_stemp_epic( NL,ISWWAT,BD,DLAYR,DS,DUL,LL,NLAYR,TAMP,RAIN,CUMDPT,DSMID,SW,TAVG,TMAX,TMIN,TAV,SRFTEMP,NDays,TDL,WetDay,ST,TMA,X2_PREV,DEPIR,BIOMAS,MULCHMASS,SNOW)
    return SRFTEMP, NDays, TDL, WetDay, ST, TMA, X2_PREV