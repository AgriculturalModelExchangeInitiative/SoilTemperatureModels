from datetime import datetime
from math import *
from DSSAT_ST_standalone.stemp import model_stemp, init_stemp
def model_stemp_(float TMAX,
      float MSALB,
      float HDAY,
      int NL,
      float SRFTEMP,
      float LL[NL],
      int NLAYR,
      float DS[NL],
      float ST[NL],
      float SRAD,
      float TAMP,
      float DLAYR[NL],
      float TMA[5],
      float TDL,
      str ISWWAT,
      float CUMDPT,
      float TAVG,
      float BD[NL],
      float SW[NL],
      float ATOT,
      float TAV,
      float XLAT,
      float DUL[NL],
      float DSMID[NL],
      int DOY):
    CUMDPT, DSMID, TDL, TMA, ATOT, SRFTEMP, ST = model_stemp(NL,ISWWAT,BD,DLAYR,DS,DUL,LL,NLAYR,MSALB,SRAD,SW,TAVG,TMAX,XLAT,TAV,TAMP,CUMDPT,DSMID,TDL,TMA,ATOT,SRFTEMP,ST,DOY,HDAY)

    return (CUMDPT, DSMID, TDL, TMA, ATOT, SRFTEMP, ST)

def init_stemp_(int NL,
                  str ISWWAT,
                  float BD[NL],
                  float DLAYR[NL],
                  float DS[NL],
                  float DUL[NL],
                  float LL[NL],
                  int NLAYR,
                  float MSALB,
                  float SRAD,
                  float SW[NL],
                  float TAVG,
                  float TMAX,
                  float XLAT,
                  float TAV,
                  float TAMP,
                  int DOY):

    cdef float HDAY
    cdef float SRFTEMP
    cdef float ST[NL]
    cdef float TMA[5]
    cdef float TDL
    cdef float CUMDPT
    cdef float ATOT
    cdef float DSMID[NL]
    CUMDPT, DSMID, TDL, TMA, ATOT, SRFTEMP, ST, HDAY = init_stemp(NL, ISWWAT, BD, DLAYR, DS, DUL, LL, NLAYR, MSALB, SRAD, SW, TAVG, TMAX, XLAT, TAV, TAMP, DOY)
    return (CUMDPT, DSMID, TDL, TMA, ATOT, SRFTEMP, ST, HDAY)
