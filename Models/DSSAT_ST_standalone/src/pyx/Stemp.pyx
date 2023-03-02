import numpy 
from math import *
def init_stemp(int NL,
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
    cdef float CUMDPT
    cdef float DSMID[NL]
    cdef float TMA[NL]
    cdef float ATOT
    cdef float SRFTEMP
    cdef float ST[NL]
    CUMDPT = 0.0
    DSMID = array('f', [0.0]*NL)
    TMA = array('f', [0.0]*NL)
    ATOT = 0.0
    SRFTEMP = 0.0
    ST = array('f', [0.0]*NL)
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
    return  CUMDPT, DSMID, TMA, ATOT, SRFTEMP, ST
def model_stemp(int NL,
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
                float CUMDPT,
                float DSMID[NL],
                float TMA[NL],
                float ATOT,
                float SRFTEMP,
                float ST[NL],
                int DOY):
    """

    Model of STEMP
    Author: DSSAT 
    Reference: https://doi.org/10.2134/agronj1994.00021962008600060014x
    Institution: DSSAT Florida
    ExtendedDescription: None
    ShortDescription: Determines soil temperature by layer

    """
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
    return  CUMDPT, DSMID, TMA, ATOT, SRFTEMP, ST


#=======================================================================
#%%CyML Model End%%
#=======================================================================
#  SOILT, Subroutine
#  Determines soil temperature by layer
#-----------------------------------------------------------------------
#  Revision history
#  02/09/1933 PWW Header revision and minor changes.
#  12/09/1999 CHP Revisions for modular format.
#  01/01/2000 AJG Added surface temperature for the CENTURY-based
#                SOM/soil-N module.
#  01/14/2005 CHP Added METMP = 3: Corrected water content in temp. eqn.
#  12/07/2008 CHP Removed METMP -- use only corrected water content
#-----------------------------------------------------------------------
#  Called : STEMP
#  Calls  : None
#=======================================================================

def SOILT(int NL,
         float ALBEDO,
         float B,
         float CUMDPT,
         int DOY,
         float DP,
         float HDAY,
         int NLAYR,
         float PESW,
         float SRAD,
         float TAMP,
         float TAV,
         float TAVG,
         float TMAX,
         float WW,
         float DSMID[NL],
         float ATOT,
         float TMA[5]):
    cdef int K , L 
    cdef float ALX , DD , DT , FX 
    cdef float SRFTEMP , TA 
    cdef float WC , ZD 
    cdef float ST[NL]
    #-----------------------------------------------------------------------
    ALX=(float(DOY) - HDAY) * 0.0174
    ATOT=ATOT - TMA[5 - 1]
    for K in range(5 , 2 - 1 , -1):
        TMA[K - 1]=TMA[K - 1 - 1]
    TMA[1 - 1]=(1.0 - ALBEDO) * (TAVG + ((TMAX - TAVG) * sqrt(SRAD * 0.03))) + (ALBEDO * TMA[(1 - 1)])
    #     Prevents differences between release & debug modes:
    #       Keep only 4 decimals. chp 06/03/03
    #chp 
    TMA[1 - 1]=int(TMA[(1 - 1)] * 10000.) / 10000.
    ATOT=ATOT + TMA[1 - 1]
    #-----------------------------------------------------------------------
    #      !Water content function - compare old and new
    #      SELECT CASE (METMP)
    #      CASE ('O')  !Old, uncorrected equation
    #        !OLD EQUATION (used in DSSAT v3.5 CROPGRO, SUBSTOR, CERES-Maize
    #         WC = AMAX1(0.01, PESW) / (WW * CUMDPT * 10.0) 
    #
    #      CASE ('E')  !Corrected method (EPIC)
    #        !NEW (CORRECTED) EQUATION
    #        !chp 11/24/2003 per GH and LAH
    WC=max(0.01, PESW) / (WW * CUMDPT) * 10.0
    #     frac =              cm   / (    mm     ) * mm/cm
    #WC (ratio)
    #PESW (cm)
    #WW (dimensionless)
    #CUMDPT (mm)
    #      END SELECT
    #-----------------------------------------------------------------------
    FX=exp(B * pow((1.0 - WC) / (1.0 + WC), 2))
    #DD in mm
    DD=FX * DP
    #     JWJ, GH 12/9/2008
    #     Checked damping depths against values from literature and 
    #       values are reasonable (after fix to WC equation).
    #     Hillel, D. 2004. Introduction to Environmental Soil Physics.
    #       Academic Press, San Diego, CA, USA.
    TA=TAV + (TAMP * cos(ALX) / 2.0)
    DT=ATOT / 5.0 - TA
    for L in range(1 , NLAYR + 1 , 1):
        ZD=-(DSMID[(L - 1)] / DD)
        ST[L - 1]=TAV + ((TAMP / 2.0 * cos((ALX + ZD)) + DT) * exp(ZD))
        #debug vs release fix
        ST[L - 1]=int(ST[(L - 1)] * 1000.) / 1000.
    #     Added: soil T for surface litter layer.
    #     NB: this should be done by adding array element 0 to ST(L). Now
    #     temporarily done differently.
    SRFTEMP=TAV + (TAMP / 2. * cos(ALX) + DT)
    #     Note: ETPHOT calculates TSRF(3), which is surface temperature by 
    #     canopy zone.  1=sunlit leaves.  2=shaded leaves.  3= soil.  Should
    #     we combine these variables?  At this time, only SRFTEMP is used
    #     elsewhere. - chp 11/27/01
    #-----------------------------------------------------------------------
    return (ATOT, TMA, SRFTEMP, ST)



