import numpy
from math import *

def init_stemp_epic(int NL,
                    str ISWWAT,
                    float BD[NL],
                    float DLAYR[NL],
                    float DS[NL],
                    float DUL[NL],
                    float LL[NL],
                    int NLAYR,
                    float TAMP,
                    float RAIN,
                    float SW[NL],
                    float TAVG,
                    float TMAX,
                    float TMIN,
                    float TAV,
                    float DEPIR,
                    float BIOMAS,
                    float MULCHMASS,
                    float SNOW):
    cdef float CUMDPT
    cdef float DSMID[NL]
    cdef float TDL
    cdef float TMA[5]
    cdef int NDays
    cdef int WetDay[30]
    cdef float X2_PREV
    cdef float SRFTEMP
    cdef float ST[NL]
    CUMDPT = 0.0
    DSMID = array('f', [0.0]*NL)
    TDL = 0.0
    TMA = array('f', [0.0]*5)
    NDays = 0
    WetDay = array('i', [0]*30)
    X2_PREV = 0.0
    SRFTEMP = 0.0
    ST = array('f', [0.0]*NL)
    cdef int I , L 
    cdef float ABD , B 
    cdef float DP , FX , PESW 
    cdef float TBD , WW 
    cdef float TLL , TSW 
    cdef float X2_AVG 
    cdef float WFT , BCV 
    cdef float CV , BCV1 , BCV2 
    cdef float SWI[NL]
    SWI=SW
    TBD=0.0
    TLL=0.0
    TSW=0.0
    TDL=0.0
    CUMDPT=0.0
    for L in range(1 , NLAYR + 1 , 1):
        #mm depth to midpt of lyr
        DSMID[L - 1]=CUMDPT + (DLAYR[(L - 1)] * 5.0)
        #mm profile depth 
        CUMDPT=CUMDPT + (DLAYR[(L - 1)] * 10.0)
        TBD=TBD + (BD[(L - 1)] * DLAYR[(L - 1)])
        TLL=TLL + (LL[(L - 1)] * DLAYR[(L - 1)])
        TSW=TSW + (SWI[(L - 1)] * DLAYR[(L - 1)])
        TDL=TDL + (DUL[(L - 1)] * DLAYR[(L - 1)])
    if ISWWAT == "Y":
        #cm
        PESW=max(0.0, TSW - TLL)
    else:
        #If water not being simulated, use DUL as water content
        PESW=max(0.0, TDL - TLL)
    #CHP
    ABD=TBD / DS[(NLAYR - 1)]
    FX=ABD / (ABD + (686.0 * exp(-(5.63 * ABD))))
    DP=1000.0 + (2500.0 * FX)
    WW=0.356 - (0.144 * ABD)
    B=log(500.0 / DP)
    for I in range(1 , 5 + 1 , 1):
        #chp
        TMA[I - 1]=int(TAVG * 10000.) / 10000.
    X2_AVG=TMA[(1 - 1)] * 5.0
    for L in range(1 , NLAYR + 1 , 1):
        ST[L - 1]=TAVG
    #       Save 30 day memory of:
    #       WFT = fraction of wet days (rainfall + irrigation)
    WFT=0.1
    WetDay=[0]*(30)
    NDays=0
    #       Soil cover function
    #t/ha
    CV=MULCHMASS / 1000.
    BCV1=CV / (CV + exp(5.3396 - (2.3951 * CV)))
    BCV2=SNOW / (SNOW + exp(2.303 - (0.2197 * SNOW)))
    BCV=max(BCV1, BCV2)
    for I in range(1 , 8 + 1 , 1):
        (TMA, SRFTEMP, ST, X2_AVG, X2_PREV)=SOILT_EPIC(NL, B, BCV, CUMDPT, DP, DSMID, NLAYR, PESW, TAV, TAVG, TMAX, TMIN, 0, WFT, WW, TMA, ST, X2_PREV)
    return  CUMDPT, DSMID, TDL, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST

def model_stemp_epic(int NL,
                     str ISWWAT,
                     float BD[NL],
                     float DLAYR[NL],
                     float DS[NL],
                     float DUL[NL],
                     float LL[NL],
                     int NLAYR,
                     float TAMP,
                     float RAIN,
                     float SW[NL],
                     float TAVG,
                     float TMAX,
                     float TMIN,
                     float TAV,
                     float CUMDPT,
                     float DSMID[NL],
                     float TDL,
                     float TMA[5],
                     int NDays,
                     int WetDay[30],
                     float X2_PREV,
                     float SRFTEMP,
                     float ST[NL],
                     float DEPIR,
                     float BIOMAS,
                     float MULCHMASS,
                     float SNOW):
    """
    Model of STEMP_EPIC
    Author: Kenneth N. Potter , Jimmy R. Williams 
    Reference: https://doi.org/10.2134/agronj1994.00021962008600060014x
    Institution: USDA-ARS, USDA-ARS
    ExtendedDescription: None
    ShortDescription: Determines soil temperature by layer test encore
    """

    cdef int I , L 
    cdef int NWetDays 
    cdef float ABD , B 
    cdef float DP , FX , PESW 
    cdef float TBD , WW 
    cdef float TLL , TSW 
    cdef float X2_AVG 
    cdef float WFT , BCV 
    cdef float CV , BCV1 , BCV2 
    TBD=0.0
    TLL=0.0
    TSW=0.0
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
    if ISWWAT == "Y":
        #cm
        PESW=max(0.0, TSW - TLL)
    else:
        #If water not being simulated, use DUL as water content
        #cm
        PESW=max(0.0, TDL - TLL)
    #     Save 30 day memory of:
    #     WFT = fraction of wet days (rainfall + irrigation)
    if NDays == 30:
        for I in range(1 , 29 + 1 , 1):
            WetDay[I - 1]=WetDay[I + 1 - 1]
    else:
        NDays=NDays + 1
    if RAIN + DEPIR > 1.E-6:
        WetDay[NDays - 1]=1
    else:
        WetDay[NDays - 1]=0
    NWetDays=sum(WetDay)
    WFT=float(NWetDays) / float(NDays)
    #     Soil cover function
    #t/ha
    CV=(BIOMAS + MULCHMASS) / 1000.
    BCV1=CV / (CV + exp(5.3396 - (2.3951 * CV)))
    BCV2=SNOW / (SNOW + exp(2.303 - (0.2197 * SNOW)))
    BCV=max(BCV1, BCV2)
    (TMA, SRFTEMP, ST, X2_AVG, X2_PREV)=SOILT_EPIC(NL, B, BCV, CUMDPT, DP, DSMID, NLAYR, PESW, TAV, TAVG, TMAX, TMIN, WetDay[NDays - 1], WFT, WW, TMA, ST, X2_PREV)
    return  CUMDPT, DSMID, TDL, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST



def SOILT_EPIC(int NL,
         float B,
         float BCV,
         float CUMDPT,
         float DP,
         float DSMID[NL],
         int NLAYR,
         float PESW,
         float TAV,
         float TAVG,
         float TMAX,
         float TMIN,
         int WetDay,
         float WFT,
         float WW,
         float TMA[5],
         float ST[NL],
         float X2_PREV):
    cdef int K , L 
    cdef float DD , FX 
    cdef float SRFTEMP 
    cdef float WC , ZD 
    cdef float X1 , X2 , X3 , F , X2_AVG 
    cdef float LAG 
    LAG=0.5
    #-----------------------------------------------------------------------
    WC=max(0.01, PESW) / (WW * CUMDPT) * 10.0
    #     frac =              cm   / (    mm     ) * mm/cm
    #WC (ratio)
    #PESW (cm)
    #WW (dimensionless)
    #CUMDPT (mm)
    FX=exp(B * pow((1.0 - WC) / (1.0 + WC), 2))
    #DD in mm
    DD=FX * DP
    #=========================================================================
    #     Below this point - EPIC soil temperature routine differs from
    #       DSSAT original routine.
    #=========================================================================
    if WetDay > 0:
        #       Potter & Williams, 1994, Eqn. 2
        #       X2=WFT(MO)*(TX-TMN)+TMN
        X2=WFT * (TAVG - TMIN) + TMIN
    else:
        #       Eqn 1
        #       X2=WFT(MO)*(TMX-TX)+TX+2.*((ST0/15.)**2-1.)
        #       Removed ST0 factor for now.
        X2=WFT * (TMAX - TAVG) + TAVG + 2.
    TMA[1 - 1]=X2
    for K in range(5 , 2 - 1 , -1):
        TMA[K - 1]=TMA[K - 1 - 1]
    #Eqn 
    X2_AVG=sum(TMA) / 5.0
    #     Eqn 4
    #     X3=(1.-BCV)*X2+BCV*T(LID(2))
    X3=(1. - BCV) * X2_AVG + (BCV * X2_PREV)
    #     DST0=AMIN1(X2,X3)
    SRFTEMP=min(X2_AVG, X3)
    #     Eqn 6 (partial)
    #     X1=AVT-X3
    X1=TAV - X3
    for L in range(1 , NLAYR + 1 , 1):
        #Eqn 8
        ZD=DSMID[(L - 1)] / DD
        #       Eqn 7
        F=ZD / (ZD + exp(-.8669 - (2.0775 * ZD)))
        #       Eqn 6
        #       T(L)=PARM(15)*T(L)+XLG1*(F*X1+X3)
        ST[L - 1]=LAG * ST[(L - 1)] + ((1. - LAG) * (F * X1 + X3))
    X2_PREV=X2_AVG
    #=========================================================================
    #     old CSM code:
    #=========================================================================
    #
    #      TA = TAV + TAMP * COS(ALX) / 2.0
    #      DT = ATOT / 5.0 - TA
    #
    #      DO L = 1, NLAYR
    #        ZD    = -DSMID(L) / DD
    #        ST(L) = TAV + (TAMP / 2.0 * COS(ALX + ZD) + DT) * EXP(ZD)
    #        ST(L) = NINT(ST(L) * 1000.) / 1000.   !debug vs release fix
    #      END DO
    #
    #-----------------------------------------------------------------------
    return (TMA, SRFTEMP, ST, X2_AVG, X2_PREV)

