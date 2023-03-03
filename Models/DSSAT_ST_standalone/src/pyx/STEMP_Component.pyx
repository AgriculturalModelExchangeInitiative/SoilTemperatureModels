from datetime import datetime
from math import *
from DSSAT_ST_standalone.stemp import model_stemp
def model_stemp_(float DUL[NL],
      int NLAYR,
      float DSMID[NL],
      float XLAT,
      float TMA[NL],
      float TAV,
      float SRFTEMP,
      int DOY,
      int NL,
      float DS[NL],
      float CUMDPT,
      float MSALB,
      float SRAD,
      float TAVG,
      float BD[NL],
      float ATOT,
      str ISWWAT,
      float LL[NL],
      float ST[NL],
      float DLAYR[NL],
      float TMAX,
      float SW[NL],
      float TAMP,
      float TDL):
    CUMDPT, DSMID, TDL, TMA, ATOT, SRFTEMP, ST = model_stemp( NL,ISWWAT,BD,DLAYR,DS,DUL,LL,NLAYR,MSALB,SRAD,SW,TAVG,TMAX,XLAT,TAV,TAMP,CUMDPT,DSMID,TDL,TMA,ATOT,SRFTEMP,ST,DOY)
    return CUMDPT, DSMID, TDL, TMA, ATOT, SRFTEMP, ST