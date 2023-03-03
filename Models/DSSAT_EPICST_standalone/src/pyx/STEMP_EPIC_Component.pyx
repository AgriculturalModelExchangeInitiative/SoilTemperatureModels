from datetime import datetime
from math import *
from DSSAT_EPICST_standalone.stemp_epic import model_stemp_epic
def model_stemp_epic_(float DUL[NL],
      float TAVG,
      float ST[NL],
      float TAV,
      float TMAX,
      float TMA[5],
      float SRFTEMP,
      str ISWWAT,
      float BIOMAS,
      float SNOW,
      float TMIN,
      float LL[NL],
      float DS[NL],
      float SW[NL],
      int NDays,
      float DEPIR,
      float DSMID[NL],
      float CUMDPT,
      float X2_PREV,
      float TAMP,
      float MULCHMASS,
      float BD[NL],
      float RAIN,
      int NLAYR,
      float TDL,
      int WetDay[30],
      int NL,
      float DLAYR[NL]):
    CUMDPT, DSMID, TDL, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST = model_stemp_epic( NL,ISWWAT,BD,DLAYR,DS,DUL,LL,NLAYR,TAMP,RAIN,SW,TAVG,TMAX,TMIN,TAV,CUMDPT,DSMID,TDL,TMA,NDays,WetDay,X2_PREV,SRFTEMP,ST,DEPIR,BIOMAS,MULCHMASS,SNOW)
    return CUMDPT, DSMID, TDL, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST