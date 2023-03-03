from datetime import datetime
from math import *
from DSSAT_EPICST_standalone.stemp_epic import model_stemp_epic
def model_stemp_epic_(float SNOW,
      str ISWWAT,
      float CUMDPT,
      float TMAX,
      int NLAYR,
      float BIOMAS,
      float TAV,
      float TMIN,
      float DLAYR[NL],
      float TAMP,
      float DS[NL],
      float LL[NL],
      float BD[NL],
      float ST[NL],
      float SW[NL],
      float DUL[NL],
      float SRFTEMP,
      float TMA[5],
      float X2_PREV,
      float DSMID[NL],
      float RAIN,
      float TAVG,
      float DEPIR,
      int WetDay[30],
      int NL,
      int NDays,
      float MULCHMASS):
    CUMDPT, DSMID, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST = model_stemp_epic( NL,ISWWAT,BD,DLAYR,DS,DUL,LL,NLAYR,TAMP,RAIN,SW,TAVG,TMAX,TMIN,TAV,CUMDPT,DSMID,TMA,NDays,WetDay,X2_PREV,SRFTEMP,ST,DEPIR,BIOMAS,MULCHMASS,SNOW)
    return CUMDPT, DSMID, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST