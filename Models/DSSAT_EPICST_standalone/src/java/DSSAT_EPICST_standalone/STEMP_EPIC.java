import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class STEMP_EPIC
{
    public void Init(STEMP_EPIC_State s, STEMP_EPIC_State s1, STEMP_EPIC_Rate r, STEMP_EPIC_Auxiliary a,  STEMP_EPIC_Exogenous ex)
    {
        SOILT_EPIC zz_SOILT_EPIC;
        Double TAMP = ex.getTAMP();
        Double RAIN = ex.getRAIN();
        Double TAVG = ex.getTAVG();
        Double TMAX = ex.getTMAX();
        Double TMIN = ex.getTMIN();
        Double TAV = ex.getTAV();
        Double DEPIR = ex.getDEPIR();
        Double BIOMAS = ex.getBIOMAS();
        Double MULCHMASS = ex.getMULCHMASS();
        Double SNOW = ex.getSNOW();
        Double CUMDPT;
        Double[] DSMID =  new Double [NL];
        Double TDL;
        Double[] TMA =  new Double [5];
        Integer NDays;
        Integer[] WetDay =  new Integer [30];
        Double X2_PREV;
        Double SRFTEMP;
        Double[] ST =  new Double [NL];
        CUMDPT = 0.0d;
        Arrays.fill(DSMID, 0.0d);
        TDL = 0.0d;
        Arrays.fill(TMA, 0.0d);
        NDays = 0;
        Arrays.fill(WetDay, 0);
        X2_PREV = 0.0d;
        SRFTEMP = 0.0d;
        Arrays.fill(ST, 0.0d);
        Integer I;
        Integer L;
        Double ABD;
        Double B;
        Double DP;
        Double FX;
        Double PESW;
        Double TBD;
        Double WW;
        Double TLL;
        Double TSW;
        Double X2_AVG;
        Double WFT;
        Double BCV;
        Double CV;
        Double BCV1;
        Double BCV2;
        Double[] SWI =  new Double [NL];
        SWI = SW;
        TBD = 0.0d;
        TLL = 0.0d;
        TSW = 0.0d;
        TDL = 0.0d;
        CUMDPT = 0.0d;
        for (L=1 ; L!=NLAYR + 1 ; L+=1)
        {
            DSMID[L - 1] = CUMDPT + (DLAYR[(L - 1)] * 5.0d);
            CUMDPT = CUMDPT + (DLAYR[(L - 1)] * 10.0d);
            TBD = TBD + (BD[(L - 1)] * DLAYR[(L - 1)]);
            TLL = TLL + (LL[(L - 1)] * DLAYR[(L - 1)]);
            TSW = TSW + (SWI[(L - 1)] * DLAYR[(L - 1)]);
            TDL = TDL + (DUL[(L - 1)] * DLAYR[(L - 1)]);
        }
        if (ISWWAT == "Y")
        {
            PESW = Math.max(0.0d, TSW - TLL);
        }
        else
        {
            PESW = Math.max(0.0d, TDL - TLL);
        }
        ABD = TBD / DS[(NLAYR - 1)];
        FX = ABD / (ABD + (686.0d * Math.exp(-(5.63d * ABD))));
        DP = 1000.0d + (2500.0d * FX);
        WW = 0.356d - (0.144d * ABD);
        B = Math.log(500.0d / DP);
        for (I=1 ; I!=5 + 1 ; I+=1)
        {
            TMA[I - 1] = (int)(TAVG * 10000.d) / 10000.d;
        }
        X2_AVG = TMA[(1 - 1)] * 5.0d;
        for (L=1 ; L!=NLAYR + 1 ; L+=1)
        {
            ST[L - 1] = TAVG;
        }
        WFT = 0.1d;
        Arrays.fill(WetDay, 0);
        NDays = 0;
        CV = MULCHMASS / 1000.d;
        BCV1 = CV / (CV + Math.exp(5.3396d - (2.3951d * CV)));
        BCV2 = SNOW / (SNOW + Math.exp(2.303d - (0.2197d * SNOW)));
        BCV = Math.max(BCV1, BCV2);
        for (I=1 ; I!=8 + 1 ; I+=1)
        {
            zz_SOILT_EPIC = Calculate_SOILT_EPIC(NL, B, BCV, CUMDPT, DP, DSMID, NLAYR, PESW, TAV, TAVG, TMAX, TMIN, 0, WFT, WW, TMA, ST, X2_PREV);
            TMA = zz_SOILT_EPIC.getTMA();
            SRFTEMP = zz_SOILT_EPIC.getSRFTEMP();
            ST = zz_SOILT_EPIC.getST();
            X2_AVG = zz_SOILT_EPIC.getX2_AVG();
            X2_PREV = zz_SOILT_EPIC.getX2_PREV();
        }
        s.setCUMDPT(CUMDPT);
        s.setDSMID(DSMID);
        s.setTDL(TDL);
        s.setTMA(TMA);
        s.setNDays(NDays);
        s.setWetDay(WetDay);
        s.setX2_PREV(X2_PREV);
        s.setSRFTEMP(SRFTEMP);
        s.setST(ST);
    }
    private Integer NL;
    public Integer getNL()
    { return NL; }

    public void setNL(Integer _NL)
    { this.NL= _NL; } 
    
    private String ISWWAT;
    public String getISWWAT()
    { return ISWWAT; }

    public void setISWWAT(String _ISWWAT)
    { this.ISWWAT= _ISWWAT; } 
    
    private Double [] BD;
    public Double [] getBD()
    { return BD; }

    public void setBD(Double [] _BD)
    { this.BD= _BD; } 
    
    private Double [] DLAYR;
    public Double [] getDLAYR()
    { return DLAYR; }

    public void setDLAYR(Double [] _DLAYR)
    { this.DLAYR= _DLAYR; } 
    
    private Double [] DS;
    public Double [] getDS()
    { return DS; }

    public void setDS(Double [] _DS)
    { this.DS= _DS; } 
    
    private Double [] DUL;
    public Double [] getDUL()
    { return DUL; }

    public void setDUL(Double [] _DUL)
    { this.DUL= _DUL; } 
    
    private Double [] LL;
    public Double [] getLL()
    { return LL; }

    public void setLL(Double [] _LL)
    { this.LL= _LL; } 
    
    private Integer NLAYR;
    public Integer getNLAYR()
    { return NLAYR; }

    public void setNLAYR(Integer _NLAYR)
    { this.NLAYR= _NLAYR; } 
    
    private Double [] SW;
    public Double [] getSW()
    { return SW; }

    public void setSW(Double [] _SW)
    { this.SW= _SW; } 
    
    public STEMP_EPIC() { }
    public void  Calculate_stemp_epic(STEMP_EPIC_State s, STEMP_EPIC_State s1, STEMP_EPIC_Rate r, STEMP_EPIC_Auxiliary a,  STEMP_EPIC_Exogenous ex)
    {
        //- Name: STEMP_EPIC -Version:  1.0, -Time step:  1
        //- Description:
    //            * Title: Model of STEMP_EPIC
    //            * Authors: Kenneth N. Potter , Jimmy R. Williams 
    //            * Reference: https://doi.org/10.2134/agronj1994.00021962008600060014x
    //            * Institution: USDA-ARS, USDA-ARS
    //            * ExtendedDescription: None
    //            * ShortDescription: Determines soil temperature by layer test encore
        //- inputs:
    //            * name: NL
    //                          ** description : Number of soil layers
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : dimensionless
    //            * name: ISWWAT
    //                          ** description : Water simulation control switch (Y or N)
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : STRING
    //                          ** max : 
    //                          ** min : 
    //                          ** default : Y
    //                          ** unit : dimensionless
    //            * name: BD
    //                          ** description : Bulk density, soil layer NL
    //                          ** inputtype : parameter
    //                          ** parametercategory : soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : g [soil] / cm3 [soil]
    //            * name: DLAYR
    //                          ** description : Thickness of soil layer NL
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : cm
    //            * name: DS
    //                          ** description : Cumulative depth in soil layer NL
    //                          ** inputtype : parameter
    //                          ** parametercategory : soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : cm
    //            * name: DUL
    //                          ** description : Volumetric soil water content at Drained Upper Limit in soil layer L
    //                          ** inputtype : parameter
    //                          ** parametercategory : soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : cm3[water]/cm3[soil]
    //            * name: LL
    //                          ** description : Volumetric soil water content in soil layer NL at lower limit
    //                          ** inputtype : parameter
    //                          ** parametercategory : soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : cm3 [water] / cm3 [soil]
    //            * name: NLAYR
    //                          ** description : Actual number of soil layers
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : dimensionless
    //            * name: TAMP
    //                          ** description : Annual amplitude of the average air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : degC
    //            * name: RAIN
    //                          ** description : daily rainfall
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: SW
    //                          ** description : Volumetric soil water content in layer NL
    //                          ** inputtype : parameter
    //                          ** parametercategory : soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : cm3 [water] / cm3 [soil]
    //            * name: TAVG
    //                          ** description : Average daily temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : degC
    //            * name: TMAX
    //                          ** description : Maximum daily temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : degC
    //            * name: TMIN
    //                          ** description : Minimum Temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : degC
    //            * name: TAV
    //                          ** description : Average annual soil temperature, used with TAMP to calculate soil temperature.
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : degC
    //            * name: CUMDPT
    //                          ** description : Cumulative depth of soil profile
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: DSMID
    //                          ** description : Depth to midpoint of soil layer NL
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : cm
    //            * name: TDL
    //                          ** description : Total water content of soil at drained upper limit
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : cm
    //            * name: TMA
    //                          ** description : Array of previous 5 days of average soil temperatures.
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 5
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : degC
    //            * name: NDays
    //                          ** description : Number of days ...
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : day
    //            * name: WetDay
    //                          ** description : Wet Days
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : INTARRAY
    //                          ** len : 30
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : day
    //            * name: X2_PREV
    //                          ** description : Temperature of soil surface at precedent timestep
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : degC
    //            * name: SRFTEMP
    //                          ** description : Temperature of soil surface litter
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : degC
    //            * name: ST
    //                          ** description : Soil temperature in soil layer NL
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : degC
    //            * name: DEPIR
    //                          ** description : Depth of irrigation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: BIOMAS
    //                          ** description : Biomass
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : kg/ha
    //            * name: MULCHMASS
    //                          ** description : Mulch Mass
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : kg/ha
    //            * name: SNOW
    //                          ** description : Snow cover
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
        //- outputs:
    //            * name: CUMDPT
    //                          ** description : Cumulative depth of soil profile
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : mm
    //            * name: DSMID
    //                          ** description : Depth to midpoint of soil layer NL
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NL
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : cm
    //            * name: TDL
    //                          ** description : Total water content of soil at drained upper limit
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : cm
    //            * name: TMA
    //                          ** description : Array of previous 5 days of average soil temperatures.
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 5
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : degC
    //            * name: NDays
    //                          ** description : Number of days ...
    //                          ** datatype : INT
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : day
    //            * name: WetDay
    //                          ** description : Wet Days
    //                          ** datatype : INTARRAY
    //                          ** variablecategory : state
    //                          ** len : 30
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : day
    //            * name: X2_PREV
    //                          ** description : Temperature of soil surface at precedent timestep
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : degC
    //            * name: SRFTEMP
    //                          ** description : Temperature of soil surface litter
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : degC
    //            * name: ST
    //                          ** description : Soil temperature in soil layer NL
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NL
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : degC
        SOILT_EPIC zz_SOILT_EPIC;
        Double TAMP = ex.getTAMP();
        Double RAIN = ex.getRAIN();
        Double TAVG = ex.getTAVG();
        Double TMAX = ex.getTMAX();
        Double TMIN = ex.getTMIN();
        Double TAV = ex.getTAV();
        Double CUMDPT = s.getCUMDPT();
        Double [] DSMID = s.getDSMID();
        Double TDL = s.getTDL();
        Double [] TMA = s.getTMA();
        Integer NDays = s.getNDays();
        Integer [] WetDay = s.getWetDay();
        Double X2_PREV = s.getX2_PREV();
        Double SRFTEMP = s.getSRFTEMP();
        Double [] ST = s.getST();
        Double DEPIR = ex.getDEPIR();
        Double BIOMAS = ex.getBIOMAS();
        Double MULCHMASS = ex.getMULCHMASS();
        Double SNOW = ex.getSNOW();
        Integer I;
        Integer L;
        Integer NWetDays;
        Double ABD;
        Double B;
        Double DP;
        Double FX;
        Double PESW;
        Double TBD;
        Double WW;
        Double TLL;
        Double TSW;
        Double X2_AVG;
        Double WFT;
        Double BCV;
        Double CV;
        Double BCV1;
        Double BCV2;
        TBD = 0.0d;
        TLL = 0.0d;
        TSW = 0.0d;
        for (L=1 ; L!=NLAYR + 1 ; L+=1)
        {
            TBD = TBD + (BD[(L - 1)] * DLAYR[(L - 1)]);
            TDL = TDL + (DUL[(L - 1)] * DLAYR[(L - 1)]);
            TLL = TLL + (LL[(L - 1)] * DLAYR[(L - 1)]);
            TSW = TSW + (SW[(L - 1)] * DLAYR[(L - 1)]);
        }
        ABD = TBD / DS[(NLAYR - 1)];
        FX = ABD / (ABD + (686.0d * Math.exp(-(5.63d * ABD))));
        DP = 1000.0d + (2500.0d * FX);
        WW = 0.356d - (0.144d * ABD);
        B = Math.log(500.0d / DP);
        if (ISWWAT == "Y")
        {
            PESW = Math.max(0.0d, TSW - TLL);
        }
        else
        {
            PESW = Math.max(0.0d, TDL - TLL);
        }
        if (NDays == 30)
        {
            for (I=1 ; I!=29 + 1 ; I+=1)
            {
                WetDay[I - 1] = WetDay[I + 1 - 1];
            }
        }
        else
        {
            NDays = NDays + 1;
        }
        if (RAIN + DEPIR > 1.E-6d)
        {
            WetDay[NDays - 1] = 1;
        }
        else
        {
            WetDay[NDays - 1] = 0;
        }
        NWetDays = Arrays.stream(WetDay).mapToInt(Integer::intValue).sum();
        WFT = (double)(NWetDays) / (double)(NDays);
        CV = (BIOMAS + MULCHMASS) / 1000.d;
        BCV1 = CV / (CV + Math.exp(5.3396d - (2.3951d * CV)));
        BCV2 = SNOW / (SNOW + Math.exp(2.303d - (0.2197d * SNOW)));
        BCV = Math.max(BCV1, BCV2);
        zz_SOILT_EPIC = Calculate_SOILT_EPIC(NL, B, BCV, CUMDPT, DP, DSMID, NLAYR, PESW, TAV, TAVG, TMAX, TMIN, WetDay[NDays - 1], WFT, WW, TMA, ST, X2_PREV);
        TMA = zz_SOILT_EPIC.getTMA();
        SRFTEMP = zz_SOILT_EPIC.getSRFTEMP();
        ST = zz_SOILT_EPIC.getST();
        X2_AVG = zz_SOILT_EPIC.getX2_AVG();
        X2_PREV = zz_SOILT_EPIC.getX2_PREV();
        s.setCUMDPT(CUMDPT);
        s.setDSMID(DSMID);
        s.setTDL(TDL);
        s.setTMA(TMA);
        s.setNDays(NDays);
        s.setWetDay(WetDay);
        s.setX2_PREV(X2_PREV);
        s.setSRFTEMP(SRFTEMP);
        s.setST(ST);
    }
    public SOILT_EPIC Calculate_SOILT_EPIC (Integer NL, Double B, Double BCV, Double CUMDPT, Double DP, Double [] DSMID, Integer NLAYR, Double PESW, Double TAV, Double TAVG, Double TMAX, Double TMIN, Integer WetDay, Double WFT, Double WW, Double [] TMA, Double [] ST, Double X2_PREV)
    {
        Integer K;
        Integer L;
        Double DD;
        Double FX;
        Double SRFTEMP;
        Double WC;
        Double ZD;
        Double X1;
        Double X2;
        Double X3;
        Double F;
        Double X2_AVG;
        Double LAG;
        LAG = 0.5d;
        WC = Math.max(0.01d, PESW) / (WW * CUMDPT) * 10.0d;
        FX = Math.exp(B * Math.pow((1.0d - WC) / (1.0d + WC), 2));
        DD = FX * DP;
        if (WetDay > 0)
        {
            X2 = WFT * (TAVG - TMIN) + TMIN;
        }
        else
        {
            X2 = WFT * (TMAX - TAVG) + TAVG + 2.d;
        }
        TMA[1 - 1] = X2;
        for (K=5 ; K!=2 - 1 ; K+=-1)
        {
            TMA[K - 1] = TMA[K - 1 - 1];
        }
        X2_AVG = Arrays.stream(TMA).mapToDouble(Double::doubleValue).sum() / 5.0d;
        X3 = (1.d - BCV) * X2_AVG + (BCV * X2_PREV);
        SRFTEMP = Math.min(X2_AVG, X3);
        X1 = TAV - X3;
        for (L=1 ; L!=NLAYR + 1 ; L+=1)
        {
            ZD = DSMID[(L - 1)] / DD;
            F = ZD / (ZD + Math.exp(-.8669d - (2.0775d * ZD)));
            ST[L - 1] = LAG * ST[(L - 1)] + ((1.d - LAG) * (F * X1 + X3));
        }
        X2_PREV = X2_AVG;
        return new SOILT_EPIC(TMA, SRFTEMP, ST, X2_AVG, X2_PREV);
    }
}
final class SOILT_EPIC {
    private Double [] TMA;
    public Double [] getTMA()
    { return TMA; }

    public void setTMA(Double [] _TMA)
    { this.TMA= _TMA; } 
    
    private Double SRFTEMP;
    public Double getSRFTEMP()
    { return SRFTEMP; }

    public void setSRFTEMP(Double _SRFTEMP)
    { this.SRFTEMP= _SRFTEMP; } 
    
    private Double [] ST;
    public Double [] getST()
    { return ST; }

    public void setST(Double [] _ST)
    { this.ST= _ST; } 
    
    private Double X2_AVG;
    public Double getX2_AVG()
    { return X2_AVG; }

    public void setX2_AVG(Double _X2_AVG)
    { this.X2_AVG= _X2_AVG; } 
    
    private Double X2_PREV;
    public Double getX2_PREV()
    { return X2_PREV; }

    public void setX2_PREV(Double _X2_PREV)
    { this.X2_PREV= _X2_PREV; } 
    
    public SOILT_EPIC(Double [] TMA,Double SRFTEMP,Double [] ST,Double X2_AVG,Double X2_PREV)
    {
        this.TMA = TMA;
        this.SRFTEMP = SRFTEMP;
        this.ST = ST;
        this.X2_AVG = X2_AVG;
        this.X2_PREV = X2_PREV;
    }
}