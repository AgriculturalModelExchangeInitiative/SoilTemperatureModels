from datetime import datetime
from math import *
from DSSAT_EPICST_standalone.stemp_epic import model_stemp_epic
def model_stemp_epic_(float DUL[NL],
      float DSMID[NL],
      float BD[NL],
      float DS[NL],
      str ISWWAT,
      float SNOW,
      float TDL,
      float LL[NL],
      int NL,
      int NLAYR,
      float SRFTEMP,
      float BIOMAS,
      float CUMDPT,
      float TMAX,
      float TAV,
      float DEPIR,
      float RAIN,
      float TAMP,
      float TMA[5],
      float MULCHMASS,
      int NDays,
      float TMIN,
      float SW[NL],
      float TAVG,
      float ST[NL],
      float DLAYR[NL],
      float X2_PREV,
      int WetDay[30]):
    CUMDPT, DSMID, TDL, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST = model_stemp_epic( NL,ISWWAT,BD,DLAYR,DS,DUL,LL,NLAYR,TAMP,RAIN,SW,TAVG,TMAX,TMIN,TAV,CUMDPT,DSMID,TDL,TMA,NDays,WetDay,X2_PREV,SRFTEMP,ST,DEPIR,BIOMAS,MULCHMASS,SNOW)
    return CUMDPT, DSMID, TDL, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST