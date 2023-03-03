from datetime import datetime
from math import *
from DSSAT_EPICST_standalone.stemp_epic import model_stemp_epic
def model_stemp_epic_(float DLAYR[NL],
      str ISWWAT,
      float TMA[5],
      float SNOW,
      float TAMP,
      float CUMDPT,
      float DEPIR,
      float TMIN,
      float ST[NL],
      int NL,
      float SW[NL],
      float DSMID[NL],
      float MULCHMASS,
      float TAVG,
      float BD[NL],
      int NLAYR,
      float TAV,
      float SRFTEMP,
      int NDays,
      float DS[NL],
      float TMAX,
      float DUL[NL],
      float BIOMAS,
      float X2_PREV,
      int WetDay[30],
      float LL[NL],
      float RAIN):
    CUMDPT, DSMID, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST = model_stemp_epic( NL,ISWWAT,BD,DLAYR,DS,DUL,LL,NLAYR,TAMP,RAIN,SW,TAVG,TMAX,TMIN,TAV,CUMDPT,DSMID,TMA,NDays,WetDay,X2_PREV,SRFTEMP,ST,DEPIR,BIOMAS,MULCHMASS,SNOW)
    return CUMDPT, DSMID, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST