from datetime import datetime
from math import *
from DSSAT_ST_standalone.stemp import model_stemp
def model_stemp_(float SRFTEMP,
      float TAMP,
      float XLAT,
      float HDAY,
      float TMA[5],
      float CUMDPT,
      str ISWWAT,
      int NLAYR,
      float ATOT,
      float DUL[NL],
      float TDL,
      float SRAD,
      float DS[NL],
      float LL[NL],
      float TAV,
      float TMAX,
      float TAVG,
      float BD[NL],
      int DOY,
      float DSMID[NL],
      float MSALB,
      int NL,
      float DLAYR[NL],
      float ST[NL],
      float SW[NL]):
    CUMDPT, DSMID, TDL, TMA, ATOT, SRFTEMP, ST = model_stemp( NL,ISWWAT,BD,DLAYR,DS,DUL,LL,NLAYR,MSALB,SRAD,SW,TAVG,TMAX,XLAT,TAV,TAMP,CUMDPT,DSMID,TDL,TMA,ATOT,SRFTEMP,ST,DOY,HDAY)
    return CUMDPT, DSMID, TDL, TMA, ATOT, SRFTEMP, ST