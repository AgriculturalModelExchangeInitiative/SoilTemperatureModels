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
    TMA[1 - 1]=TAVG
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
