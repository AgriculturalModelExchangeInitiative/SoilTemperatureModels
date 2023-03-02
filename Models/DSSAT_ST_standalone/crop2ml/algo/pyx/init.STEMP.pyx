cdef int I , L 
cdef float ABD , ALBEDO , B 
cdef float DP , FX , HDAY , PESW 
cdef float TBD , WW 
cdef float TDL , TLL , TSW 
cdef float DLI[NL], DSI[NL], SWI[NL]
SWI=SW
DSI=DS
if XLAT < 0.0:
    #DOY (hottest) for southern hemisphere
    HDAY=20.0
else:
    #DOY (hottest) for northern hemisphere
    HDAY=200.0
TBD=0.0
TLL=0.0
TSW=0.0
TDL=0.0
CUMDPT=0.0
for L in range(1 , NLAYR + 1 , 1):
    if L == 1:
        DLI[L - 1]=DSI[L - 1]
    else:
        DLI[L - 1]=DSI[L - 1] - DSI[L - 1 - 1]
    #mm depth to midpt of lyr
    DSMID[L - 1]=CUMDPT + (DLI[(L - 1)] * 5.0)
    #mm profile depth 
    CUMDPT=CUMDPT + (DLI[(L - 1)] * 10.0)
    #CHP
    TBD=TBD + (BD[(L - 1)] * DLI[(L - 1)])
    TLL=TLL + (LL[(L - 1)] * DLI[(L - 1)])
    TSW=TSW + (SWI[(L - 1)] * DLI[(L - 1)])
    TDL=TDL + (DUL[(L - 1)] * DLI[(L - 1)])
if ISWWAT == "Y":
    #cm
    PESW=max(0.0, TSW - TLL)
else:
    #If water not being simulated, use DUL as water content
    PESW=max(0.0, TDL - TLL)
#CHP
ABD=TBD / DSI[(NLAYR - 1)]
FX=ABD / (ABD + (686.0 * exp(-(5.63 * ABD))))
DP=1000.0 + (2500.0 * FX)
WW=0.356 - (0.144 * ABD)
B=log(500.0 / DP)
ALBEDO=MSALB
# CVF: difference in soil temperatures occur between different optimization
#     levels in compiled versions.
# Keep only 4 decimals. chp 06/03/03
#     Prevents differences between release & debug modes:
for I in range(1 , 5 + 1 , 1):
    #chp
    TMA[I - 1]=int(TAVG * 10000.) / 10000.
ATOT=TMA[(1 - 1)] * 5.0
for L in range(1 , NLAYR + 1 , 1):
    ST[L - 1]=TAVG
for I in range(1 , 8 + 1 , 1):
    (ATOT, TMA, SRFTEMP, ST)=SOILT(NL, ALBEDO, B, CUMDPT, DOY, DP, HDAY, NLAYR, PESW, SRAD, TAMP, TAV, TAVG, TMAX, WW, DSMID, ATOT, TMA)
