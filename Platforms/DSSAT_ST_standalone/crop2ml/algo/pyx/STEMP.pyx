cdef int I , L 
cdef float ABD , ALBEDO , B 
cdef float DP , FX , HDAY , PESW 
cdef float TBD , WW 
cdef float TDL , TLL , TSW 
TBD=0.0
TLL=0.0
TSW=0.0
TDL=0.0
for L in range(1 , NLAYR + 1 , 1):
    TBD=TBD + (BD[(L - 1)] * DLAYR[(L - 1)])
    TDL=TDL + (DUL[(L - 1)] * DLAYR[(L - 1)])
    TLL=TLL + (LL[(L - 1)] * DLAYR[(L - 1)])
    TSW=TSW + (SW[(L - 1)] * DLAYR[(L - 1)])
#CHP
ABD=TBD / DS[(NLAYR - 1)]
FX=ABD / (ABD + (686.0 * exp(-(5.63 * ABD))))
#DP in mm
DP=1000.0 + (2500.0 * FX)
#vol. fraction
WW=0.356 - (0.144 * ABD)
B=log(500.0 / DP)
ALBEDO=MSALB
if ISWWAT == "Y":
    #cm
    PESW=max(0.0, TSW - TLL)
else:
    #If water not being simulated, use DUL as water content
    #cm
    PESW=max(0.0, TDL - TLL)
(ATOT, TMA, SRFTEMP, ST)=SOILT(NL, ALBEDO, B, CUMDPT, DOY, DP, HDAY, NLAYR, PESW, SRAD, TAMP, TAV, TAVG, TMAX, WW, DSMID, ATOT, TMA)
#-----------------------------------------------------------------------
