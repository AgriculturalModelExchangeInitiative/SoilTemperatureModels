MODULE Stempmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE init_stemp(NL, &
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
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        INTEGER, INTENT(IN) :: NL
        CHARACTER(65), INTENT(IN) :: ISWWAT
        REAL , DIMENSION(NL ), INTENT(IN) :: BD
        REAL , DIMENSION(NL ), INTENT(IN) :: DLAYR
        REAL , DIMENSION(NL ), INTENT(IN) :: DS
        REAL , DIMENSION(NL ), INTENT(IN) :: DUL
        REAL , DIMENSION(NL ), INTENT(IN) :: LL
        INTEGER, INTENT(IN) :: NLAYR
        REAL, INTENT(IN) :: MSALB
        REAL, INTENT(IN) :: SRAD
        REAL , DIMENSION(NL ), INTENT(IN) :: SW
        REAL, INTENT(IN) :: TAVG
        REAL, INTENT(IN) :: TMAX
        REAL, INTENT(IN) :: XLAT
        REAL, INTENT(IN) :: TAV
        REAL, INTENT(IN) :: TAMP
        INTEGER, INTENT(IN) :: DOY
        REAL, INTENT(OUT) :: CUMDPT
        REAL , DIMENSION(NL ), INTENT(OUT) :: DSMID
        REAL, INTENT(OUT) :: TDL
        REAL , DIMENSION(5 ), INTENT(OUT) :: TMA
        REAL, INTENT(OUT) :: ATOT
        REAL, INTENT(OUT) :: SRFTEMP
        REAL , DIMENSION(NL ), INTENT(OUT) :: ST
        REAL, INTENT(OUT) :: HDAY
        INTEGER:: I
        INTEGER:: L
        REAL:: ABD
        REAL:: ALBEDO
        REAL:: B
        REAL:: DP
        REAL:: FX
        REAL:: PESW
        REAL:: TBD
        REAL:: WW
        REAL:: TLL
        REAL:: TSW
        REAL , DIMENSION(NL ):: DLI
        REAL , DIMENSION(NL ):: DSI
        REAL , DIMENSION(NL ):: SWI
        CUMDPT = 0.0
        DSMID = 0.0
        TDL = 0.0
        TMA = 0.0
        ATOT = 0.0
        SRFTEMP = 0.0
        ST = 0.0
        HDAY = 0.0
        SWI = SW
        DSI = DS
        WRITE(*,*) "XLAT", XLAT
        WRITE(*,*) "TAVG", TAVG

        IF(XLAT .LT. 0.0) THEN
            HDAY = 20.0
        ELSE
            HDAY = 200.0
        WRITE(*,*) HDAY
        END IF
        TBD = 0.0
        TLL = 0.0
        TSW = 0.0
        TDL = 0.0
        CUMDPT = 0.0
        DO L = 1 , NLAYR + 1-1, 1
            IF(L .EQ. 1) THEN
                DLI(L - 1+1) = DSI(L - 1+1)
            ELSE
                DLI(L - 1+1) = DSI(L - 1+1) - DSI(L - 1 - 1+1)
            END IF
            DSMID(L - 1+1) = CUMDPT + (DLI((L - 1)+1) * 5.0)
            CUMDPT = CUMDPT + (DLI((L - 1)+1) * 10.0)
            TBD = TBD + (BD((L - 1)+1) * DLI((L - 1)+1))
            TLL = TLL + (LL((L - 1)+1) * DLI((L - 1)+1))
            TSW = TSW + (SWI((L - 1)+1) * DLI((L - 1)+1))
            TDL = TDL + (DUL((L - 1)+1) * DLI((L - 1)+1))
        END DO
        WRITE(*,*) TDL
        IF(ISWWAT .EQ. 'Y') THEN
            PESW = MAX(0.0, TSW - TLL)
        ELSE
            PESW = MAX(0.0, TDL - TLL)
        END IF
        ABD = TBD / DSI((NLAYR - 1)+1)
        FX = ABD / (ABD + (686.0 * EXP((-5.63 * ABD))))
        DP = 1000.0 + (2500.0 * FX)
        WW = 0.356 - (0.144 * ABD)
        B = LOG(500.0 / DP)
        ALBEDO = MSALB
        DO I = 1 , 5 , 1
            TMA(I) = NINT(TAVG * 10000.) / 10000.
        END DO

        WRITE(*,*) (TMA(L),L=1,NLAYR)
        ATOT = TMA((1 - 1)+1) * 5.0
        DO L = 1 , NLAYR + 1-1, 1
            ST(L - 1+1) = TAVG
        END DO
        DO I = 1 , 8 + 1-1, 1
            call SOILT(NL, ALBEDO, B, CUMDPT, DOY, DP, HDAY, NLAYR, PESW, SRAD,  &
                    TAMP, TAV, TAVG, TMAX, WW, DSMID, ATOT, TMA,SRFTEMP,ST)
        END DO
         WRITE(*,*) SRFTEMP, (ST(L),L=1,NLAYR)
    END SUBROUTINE init_stemp

    SUBROUTINE model_stemp(NL, &
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
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        INTEGER, INTENT(IN) :: NL
        CHARACTER(65), INTENT(IN) :: ISWWAT
        REAL , DIMENSION(NL ), INTENT(IN) :: BD
        REAL , DIMENSION(NL ), INTENT(IN) :: DLAYR
        REAL , DIMENSION(NL ), INTENT(IN) :: DS
        REAL , DIMENSION(NL ), INTENT(IN) :: DUL
        REAL , DIMENSION(NL ), INTENT(IN) :: LL
        INTEGER, INTENT(IN) :: NLAYR
        REAL, INTENT(IN) :: MSALB
        REAL, INTENT(IN) :: SRAD
        REAL , DIMENSION(NL ), INTENT(IN) :: SW
        REAL, INTENT(IN) :: TAVG
        REAL, INTENT(IN) :: TMAX
        REAL, INTENT(IN) :: XLAT
        REAL, INTENT(IN) :: TAV
        REAL, INTENT(IN) :: TAMP
        REAL, INTENT(INOUT) :: CUMDPT
        REAL , DIMENSION(NL ), INTENT(INOUT) :: DSMID
        REAL, INTENT(INOUT) :: TDL
        REAL , DIMENSION(NL ), INTENT(INOUT) :: TMA
        REAL, INTENT(INOUT) :: ATOT
        REAL, INTENT(INOUT) :: SRFTEMP
        REAL , DIMENSION(NL ), INTENT(INOUT) :: ST
        INTEGER, INTENT(IN) :: DOY
        REAL, INTENT(IN) :: HDAY
        INTEGER:: L
        REAL:: ABD
        REAL:: ALBEDO
        REAL:: B
        REAL:: DP
        REAL:: FX
        REAL:: PESW
        REAL:: TBD
        REAL:: WW
        REAL:: TLL
        REAL:: TSW
    
        TBD = 0.0
        TLL = 0.0
        TSW = 0.0
        DO L = 1 , NLAYR + 1-1, 1
            TBD = TBD + (BD((L - 1)+1) * DLAYR((L - 1)+1))
            TDL = TDL + (DUL((L - 1)+1) * DLAYR((L - 1)+1))
            TLL = TLL + (LL((L - 1)+1) * DLAYR((L - 1)+1))
            TSW = TSW + (SW((L - 1)+1) * DLAYR((L - 1)+1))
        END DO
        ABD = TBD / DS((NLAYR - 1)+1)
        FX = ABD / (ABD + (686.0 * EXP((-5.63 * ABD))))
        DP = 1000.0 + (2500.0 * FX)
        WW = 0.356 - (0.144 * ABD)
        B = LOG(500.0 / DP)
        ALBEDO = MSALB
        IF(ISWWAT .EQ. 'Y') THEN
            PESW = MAX(0.0, TSW - TLL)
        ELSE
            PESW = MAX(0.0, TDL - TLL)
        END IF
        call SOILT(NL, ALBEDO, B, CUMDPT, DOY, DP, HDAY, NLAYR, PESW, SRAD,  &
                TAMP, TAV, TAVG, TMAX, WW, DSMID, ATOT, TMA,SRFTEMP,ST)
        WRITE(*,*) SRFTEMP, (ST(L),L=1,NLAYR)
    END SUBROUTINE model_stemp

    SUBROUTINE SOILT(NL, &
        ALBEDO, &
        B, &
        CUMDPT, &
        DOY, &
        DP, &
        HDAY, &
        NLAYR, &
        PESW, &
        SRAD, &
        TAMP, &
        TAV, &
        TAVG, &
        TMAX, &
        WW, &
        DSMID, &
        ATOT, &
        TMA, &
        SRFTEMP, &
        ST)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        INTEGER, INTENT(IN) :: NL
        REAL, INTENT(IN) :: ALBEDO
        REAL, INTENT(IN) :: B
        REAL, INTENT(IN) :: CUMDPT
        INTEGER, INTENT(IN) :: DOY
        REAL, INTENT(IN) :: DP
        REAL, INTENT(IN) :: HDAY
        INTEGER, INTENT(IN) :: NLAYR
        REAL, INTENT(IN) :: PESW
        REAL, INTENT(IN) :: SRAD
        REAL, INTENT(IN) :: TAMP
        REAL, INTENT(IN) :: TAV
        REAL, INTENT(IN) :: TAVG
        REAL, INTENT(IN) :: TMAX
        REAL, INTENT(IN) :: WW
        REAL , DIMENSION(NL ), INTENT(IN) :: DSMID
        REAL, INTENT(INOUT) :: ATOT
        REAL , DIMENSION(5 ), INTENT(INOUT) :: TMA
        INTEGER:: K
        INTEGER:: L
        REAL:: ALX
        REAL:: DD
        REAL:: DT
        REAL:: FX
        REAL, INTENT(OUT) :: SRFTEMP
        REAL:: TA
        REAL:: WC
        REAL:: ZD
        REAL , DIMENSION(NL ), INTENT(OUT) :: ST
        ALX = (REAL(DOY) - HDAY) * 0.0174
        ATOT = ATOT - TMA(5 - 1+1)
        DO K = 5 , 2 - 1+1, -1
            TMA(K - 1+1) = TMA(K - 1 - 1+1)
        END DO
        TMA(1 - 1+1) = (1.0 - ALBEDO) * (TAVG + ((TMAX - TAVG) * SQRT(SRAD *  &
                0.03))) + (ALBEDO * TMA((1 - 1)+1))
        TMA(1 - 1+1) = INT(TMA((1 - 1)+1) * 10000.) / 10000.
        ATOT = ATOT + TMA(1 - 1+1)
        WC = MAX(0.01, PESW) / (WW * CUMDPT) * 10.0
        FX = EXP(B *  (((1.0 - WC) / (1.0 + WC)) ** 2))
        DD = FX * DP
        TA = TAV + (TAMP * COS(ALX) / 2.0)
        DT = ATOT / 5.0 - TA
        DO L = 1 , NLAYR + 1-1, 1
            ZD = -DSMID((L - 1)+1) / DD
            ST(L - 1+1) = TAV + ((TAMP / 2.0 * COS((ALX + ZD)) + DT) * EXP(ZD))
            ST(L - 1+1) = INT(ST((L - 1)+1) * 1000.) / 1000.
        END DO
        SRFTEMP = TAV + (TAMP / 2. * COS(ALX) + DT)
    END SUBROUTINE SOILT

END MODULE
