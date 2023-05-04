      PROGRAM ASKEE

      USE Stempmod

      IMPLICIT NONE
      CHARACTER(65)   ANS,RNMODE,BLANK,UPCASE,ISWWAT
      CHARACTER*6   ERRKEY,FINDCH,TRNARG
      CHARACTER*30  FILEIO
      
      INTEGER :: NL = 20
      REAL ABD, ALBEDO, ATOT, B, CUMDPT 
      REAL DP, FX, HDAY, ICWD, PESW, MSALB, SRAD, SRFTEMP 
      REAL TAMP, TAV, TAVG, TBD, TMAX, XLAT, WW
      REAL TDL, TLL, TSW
      REAL TMA(5)
      REAL, DIMENSION(20) :: BD, DLAYR, DLI, DS, DSI, DSMID, DUL, LL, &
     &      ST, SW, SWI
     
      INTEGER DOY, DYNAMIC, I, L, NLAYR

      PARAMETER (ERRKEY = 'ASKEE ')      
      PARAMETER (BLANK  = ' ')




      DOY = 100
      ISWWAT = 'Y'
      NL=20
      BD    = 1.6
      DLAYR = 10.0
      DS(1) = 10.0
      DS(2) = 20.0 
      DS(3) = 30.0 
      DS(4) = 40.0 
      DUL   = 0.3 
      LL    = 0.2 
      NLAYR = 4 
      MSALB = 0.13
      
      SRAD    = 20.0 
      SW      = 0.2
      TAVG    = 25.0
      TMAX    = 30.0
      XLAT    = 28.0
      TAV     = 20.0
      TAMP    = 10.0

      WRITE(*,*) 'TAVG', TAVG
      CALL init_stemp(NL, &
        ISWWAT, &
        BD, &
        DLAYR, &
        DS, &
        DUL, &
        LL, &
        NLAYR, &
        MSALB, &
        SRAD, &
        SW, &
        TAVG, &
        TMAX, &
        XLAT, &
        TAV, &
        TAMP, &
        DOY, &
        CUMDPT, &
        DSMID, &
        TDL, &
        TMA, &
        ATOT, &
        SRFTEMP, &
        ST, HDAY)
        WRITE(*,*) 'TAVG', TAVG

            call model_stemp(NL, &
        ISWWAT, &
        BD, &
        DLAYR, &
        DS, &
        DUL, &
        LL, &
        NLAYR, &
        MSALB, &
        SRAD, &
        SW, &
        TAVG, &
        TMAX, &
        XLAT, &
        TAV, &
        TAMP, &
        CUMDPT, &
        DSMID, &
        TDL, &
        TMA, &
        ATOT, &
        SRFTEMP, &
        ST, &
        DOY, &
        HDAY)
      
      
      END PROGRAM ASKEE

!===========================================================================
! Variable listing
! ---------------------------------
! BLANK   Blank character 
! CONTROL Composite variable containing variables related to control and/or 
!           timing of simulation.  The structure of the variable 
!           (ControlType) is defined in ModuleDefs.for. 
!===========================================================================
