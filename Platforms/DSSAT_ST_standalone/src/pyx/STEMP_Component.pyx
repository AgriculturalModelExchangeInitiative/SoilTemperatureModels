from datetime import datetime
from math import *
from DSSAT_ST_standalone.stemp import model_stemp
def model_stemp_(float DSMID[NL],
      float TAVG,
      float ST[NL],
      float TMAX,
      float TAV,
      float DLAYR[NL],
      float CUMDPT,
      float SW[NL],
      float TAMP,
      int NLAYR,
      int DOY,
      float LL[NL],
      float TMA[NL],
      str ISWWAT,
      float DUL[NL],
      float BD[NL],
      float SRFTEMP,
      float DS[NL],
      int NL,
      float XLAT,
      float SRAD,
      float MSALB,
      float ATOT):
    CUMDPT, DSMID, TMA, ATOT, SRFTEMP, ST = model_stemp( NL,ISWWAT,BD,DLAYR,DS,DUL,LL,NLAYR,MSALB,SRAD,SW,TAVG,TMAX,XLAT,TAV,TAMP,CUMDPT,DSMID,TMA,ATOT,SRFTEMP,ST,DOY)
    return CUMDPT, DSMID, TMA, ATOT, SRFTEMP, ST