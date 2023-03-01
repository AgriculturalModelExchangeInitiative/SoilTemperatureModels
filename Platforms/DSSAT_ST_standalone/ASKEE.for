      PROGRAM ASKEE

      USE ModuleDefs

      IMPLICIT NONE
C-----------------------------------------------------------------------
      CHARACTER*1   ANS,RNMODE,BLANK,UPCASE,ISWWAT
      CHARACTER*6   ERRKEY,FINDCH,TRNARG
      CHARACTER*30  FILEIO
      
      REAL ABD, ALBEDO, ATOT, B, CUMDPT 
      REAL DP, FX, HDAY, ICWD, PESW, MSALB, SRAD, SRFTEMP 
      REAL TAMP, TAV, TAVG, TBD, TMAX, XLAT, WW
      REAL TDL, TLL, TSW
      REAL TMA(5)
      REAL, DIMENSION(NL) :: BD, DLAYR, DLI, DS, DSI, DSMID, DUL, LL, 
     &      ST, SW, SWI
     
      INTEGER DOY, DYNAMIC, I, L, NLAYR

      PARAMETER (ERRKEY = 'ASKEE ')      
      PARAMETER (BLANK  = ' ')

C     Define constructed variable types based on definitions in
C     ModuleDefs.for.

C     The variable "CONTROL" is of type "ControlType".
      TYPE (ControlType) CONTROL

C     The variable "ISWITCH" is of type "SwitchType".
      TYPE (SwitchType) ISWITCH
      
      TYPE (SoilType) SOILPROP
      

C*********************************************************************** 
C*********************************************************************** 
C     RUN INITIALIZATION
C***********************************************************************

      CONTROL % FILEIO  = FILEIO
      CONTROL % ERRCODE = 0
      CONTROL % DYNAMIC = 1
      CONTROL % RUN     = 1
      CONTROL % RNMODE  = 'B'
      CONTROL % YRDOY   = 2021100
      
      ISWITCH % ISWWAT = 'Y'
      
      SOILPROP % BD    = 1.6
      SOILPROP % DLAYR = 10.0
      SOILPROP % DS(1) = 10.0
      SOILPROP % DS(2) = 20.0 
      SOILPROP % DS(3) = 30.0 
      SOILPROP % DS(4) = 40.0 
      SOILPROP % DUL   = 0.3 
      SOILPROP % LL    = 0.2 
      SOILPROP % NLAYR = 4 
      SOILPROP % MSALB = 0.13
      
      SRAD    = 20.0 
      SW      = 0.2
      TAVG    = 25.0
      TMAX    = 30.0
      XLAT    = 28.0
      TAV     = 20.0
      TAMP    = 10.0

C*********************************************************************** 
C*********************************************************************** 
C     CALL SOIL TEMPERATURE SUBROUTINE
C***********************************************************************
      DO WHILE (CONTROL % DYNAMIC .LE. SEASEND)
        
          CALL STEMP(CONTROL, ISWITCH,  
     &      SOILPROP, SRAD, SW, TAVG, TMAX, XLAT, TAV, TAMP,!Input
     &      SRFTEMP, ST)                                    !Output
      
      
        CONTROL % DYNAMIC = CONTROL % DYNAMIC + 1
      ENDDO


      END PROGRAM ASKEE

!===========================================================================
! Variable listing
! ---------------------------------
! BLANK   Blank character 
! CONTROL Composite variable containing variables related to control and/or 
!           timing of simulation.  The structure of the variable 
!           (ControlType) is defined in ModuleDefs.for. 
!===========================================================================