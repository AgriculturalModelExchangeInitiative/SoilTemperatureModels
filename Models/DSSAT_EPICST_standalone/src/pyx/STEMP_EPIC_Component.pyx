from datetime import datetime
from math import *
from DSSAT_EPICST_standalone.stemp_epic import model_stemp_epic
def model_stemp_epic_(float TAV,
      float RAIN,
      float DUL[NL],
      int WetDay[30],
      float SRFTEMP,
      int NDays,
      float BIOMAS,
      int NL,
      int NLAYR,
      float ST[NL],
      float SNOW,
      float TMA[5],
      float DS[NL],
      str ISWWAT,
      float BD[NL],
      float TAVG,
      float LL[NL],
      float DEPIR,
      float DLAYR[NL],
      float TDL,
      float MULCHMASS,
      float TMAX,
      float TMIN,
      float X2_PREV,
      float DSMID[NL],
      float TAMP,
      float CUMDPT,
      float SW[NL]):
    CUMDPT, DSMID, TDL, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST = model_stemp_epic( NL,ISWWAT,BD,DLAYR,DS,DUL,LL,NLAYR,TAMP,RAIN,SW,TAVG,TMAX,TMIN,TAV,CUMDPT,DSMID,TDL,TMA,NDays,WetDay,X2_PREV,SRFTEMP,ST,DEPIR,BIOMAS,MULCHMASS,SNOW)
    return CUMDPT, DSMID, TDL, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST