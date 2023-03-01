from datetime import datetime
from math import *
from DSSAT_EPICST_standalone.stemp_epic import model_stemp_epic
def model_stemp_epic_(float RAIN,
      float TAV,
      int NDays,
      float CUMDPT,
      float SRFTEMP,
      float DLAYR[NL],
      float SW[NL],
      int WetDay[30],
      float X2_PREV,
      float BD[NL],
      str ISWWAT,
      float TAVG,
      float MULCHMASS,
      float DS[NL],
      float DEPIR,
      float TMA[5],
      float DSMID[NL],
      float SNOW,
      float ST[NL],
      float TMAX,
      float BIOMAS,
      float DUL[NL],
      float TAMP,
      float LL[NL],
      int NL,
      float TMIN,
      int NLAYR):
    CUMDPT, DSMID, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST = model_stemp_epic( NL,ISWWAT,BD,DLAYR,DS,DUL,LL,NLAYR,TAMP,RAIN,SW,TAVG,TMAX,TMIN,TAV,CUMDPT,DSMID,TMA,NDays,WetDay,X2_PREV,SRFTEMP,ST,DEPIR,BIOMAS,MULCHMASS,SNOW)
    return CUMDPT, DSMID, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST
