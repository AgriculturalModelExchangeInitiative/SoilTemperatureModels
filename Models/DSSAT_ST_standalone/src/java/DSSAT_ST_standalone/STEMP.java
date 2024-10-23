import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class STEMP
{
    public void Init(STEMP_State s, STEMP_State s1, STEMP_Rate r, STEMP_Auxiliary a,  STEMP_Exogenous ex)
    {
        SOILT zz_SOILT;
        Double SRAD = ex.getSRAD();
        Double TAVG = ex.getTAVG();
        Double TMAX = ex.getTMAX();
        Double TAV = ex.getTAV();
        Double TAMP = ex.getTAMP();
        Integer DOY = ex.getDOY();
        Double CUMDPT;
        Double[] DSMID =  new Double [NL];
        Double TDL;
        Double[] TMA =  new Double [5];
        Double ATOT;
        Double SRFTEMP;
        Double[] ST =  new Double [NL];
        Double HDAY;
        CUMDPT = 0.0d;
        DSMID= new Double[NL];
        Arrays.fill(DSMID, 0.0d);
        TDL = 0.0d;
        TMA= new Double[5];
        Arrays.fill(TMA, 0.0d);
        ATOT = 0.0d;
        SRFTEMP = 0.0d;
        ST= new Double[NL];
        Arrays.fill(ST, 0.0d);
        HDAY = 0.0d;
        Integer I;
        Integer L;
        Double ABD;
        Double ALBEDO;
        Double B;
        Double DP;
        Double FX;
        Double PESW;
        Double TBD;
        Double WW;
        Double TLL;
        Double TSW;
        Double[] DLI =  new Double [NL];
        Double[] DSI =  new Double [NL];
        Double[] SWI =  new Double [NL];
        SWI = SW;
        DSI = DS;
        if (XLAT < 0.0d)
        {
            HDAY = 20.0d;
        }
        else
        {
            HDAY = 200.0d;
        }
        TBD = 0.0d;
        TLL = 0.0d;
        TSW = 0.0d;
        TDL = 0.0d;
        CUMDPT = 0.0d;
        for (L=1 ; L!=NLAYR + 1 ; L+=1)
        {
            if (L == 1)
            {
                DLI[L - 1] = DSI[L - 1];
            }
            else
            {
                DLI[L - 1] = DSI[L - 1] - DSI[L - 1 - 1];
            }
            DSMID[L - 1] = CUMDPT + (DLI[(L - 1)] * 5.0d);
            CUMDPT = CUMDPT + (DLI[(L - 1)] * 10.0d);
            TBD = TBD + (BD[(L - 1)] * DLI[(L - 1)]);
            TLL = TLL + (LL[(L - 1)] * DLI[(L - 1)]);
            TSW = TSW + (SWI[(L - 1)] * DLI[(L - 1)]);
            TDL = TDL + (DUL[(L - 1)] * DLI[(L - 1)]);
        }
        if (ISWWAT == "Y")
        {
            PESW = Math.max(0.0d, TSW - TLL);
        }
        else
        {
            PESW = Math.max(0.0d, TDL - TLL);
        }
        ABD = TBD / DSI[(NLAYR - 1)];
        FX = ABD / (ABD + (686.0d * Math.exp(-(5.63d * ABD))));
        DP = 1000.0d + (2500.0d * FX);
        WW = 0.356d - (0.144d * ABD);
        B = Math.log(500.0d / DP);
        ALBEDO = MSALB;
        for (I=1 ; I!=5 + 1 ; I+=1)
        {
            TMA[I - 1] = (int)(TAVG * 10000.d) / 10000.d;
        }
        ATOT = TMA[(1 - 1)] * 5.0d;
        for (L=1 ; L!=NLAYR + 1 ; L+=1)
        {
            ST[L - 1] = TAVG;
        }
        for (I=1 ; I!=8 + 1 ; I+=1)
        {
            zz_SOILT = Calculate_SOILT(NL, ALBEDO, B, CUMDPT, DOY, DP, HDAY, NLAYR, PESW, SRAD, TAMP, TAV, TAVG, TMAX, WW, DSMID, ATOT, TMA);
            ATOT = zz_SOILT.getATOT();
            TMA = zz_SOILT.getTMA();
            SRFTEMP = zz_SOILT.getSRFTEMP();
            ST = zz_SOILT.getST();
        }
        s.setCUMDPT(CUMDPT);
        s.setDSMID(DSMID);
        s.setTDL(TDL);
        s.setTMA(TMA);
        s.setATOT(ATOT);
        s.setSRFTEMP(SRFTEMP);
        s.setST(ST);
        s.setHDAY(HDAY);
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
    
    private Double MSALB;
    public Double getMSALB()
    { return MSALB; }

    public void setMSALB(Double _MSALB)
    { this.MSALB= _MSALB; } 
    
    private Double [] SW;
    public Double [] getSW()
    { return SW; }

    public void setSW(Double [] _SW)
    { this.SW= _SW; } 
    
    private Double XLAT;
    public Double getXLAT()
    { return XLAT; }

    public void setXLAT(Double _XLAT)
    { this.XLAT= _XLAT; } 
    
    public STEMP() { }
    public void  Calculate_Model(STEMP_State s, STEMP_State s1, STEMP_Rate r, STEMP_Auxiliary a,  STEMP_Exogenous ex)
    {
        //- Name: STEMP -Version:  1.0, -Time step:  1
        //- Description:
    //            * Title: Model of STEMP
    //            * Authors: DSSAT 
    //            * Reference: https://doi.org/10.2134/agronj1994.00021962008600060014x
    //            * Institution: DSSAT Florida
    //            * ExtendedDescription: None
    //            * ShortDescription: Determines soil temperature by layer
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
    //                          ** description : Water simulation control switch
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
    //                          ** description : Thickness of soil layer L
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : cm
    //            * name: DS
    //                          ** description : Cumulative depth in soil layer L
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
    //                          ** description : Volumetric soil water content in soil layer L at lower limit
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
    //            * name: MSALB
    //                          ** description : Soil albedo with mulch and soil water effects
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : dimensionless
    //            * name: SRAD
    //                          ** description : Solar radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : MJ/m2-d
    //            * name: SW
    //                          ** description : Volumetric soil water content in layer L
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
    //            * name: XLAT
    //                          ** description : Latitude
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
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
    //            * name: TAMP
    //                          ** description : Amplitude of temperature function used to calculate soil temperatures
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
    //                          ** description : Depth to midpoint of soil layer L
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
    //                          ** description : Array of previous 5 days of average soil temperatures
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 5
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : degC
    //            * name: ATOT
    //                          ** description : Sum of TMA array (last 5 days soil temperature)
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
    //                          ** description : Soil temperature in soil layer L
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : degC
    //            * name: DOY
    //                          ** description : Current day of simulation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : d
    //            * name: HDAY
    //                          ** description : Haverst day
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : day
        //- outputs:
    //            * name: CUMDPT
    //                          ** description : Cumulative depth of soil profile
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : mm
    //            * name: DSMID
    //                          ** description : Depth to midpoint of soil layer L
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
    //                          ** description : Array of previous 5 days of average soil temperatures
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 5
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : degC
    //            * name: ATOT
    //                          ** description : Sum of TMA array (last 5 days soil temperature)
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
    //                          ** description : Soil temperature in soil layer L
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NL
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : degC
        SOILT zz_SOILT;
        Double SRAD = ex.getSRAD();
        Double TAVG = ex.getTAVG();
        Double TMAX = ex.getTMAX();
        Double TAV = ex.getTAV();
        Double TAMP = ex.getTAMP();
        Double CUMDPT = s.getCUMDPT();
        Double [] DSMID = s.getDSMID();
        Double TDL = s.getTDL();
        Double [] TMA = s.getTMA();
        Double ATOT = s.getATOT();
        Double SRFTEMP = s.getSRFTEMP();
        Double [] ST = s.getST();
        Integer DOY = ex.getDOY();
        Double HDAY = s.getHDAY();
        Integer L;
        Double ABD;
        Double ALBEDO;
        Double B;
        Double DP;
        Double FX;
        Double PESW;
        Double TBD;
        Double WW;
        Double TLL;
        Double TSW;
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
        ALBEDO = MSALB;
        if (ISWWAT == "Y")
        {
            PESW = Math.max(0.0d, TSW - TLL);
        }
        else
        {
            PESW = Math.max(0.0d, TDL - TLL);
        }
        zz_SOILT = Calculate_SOILT(NL, ALBEDO, B, CUMDPT, DOY, DP, HDAY, NLAYR, PESW, SRAD, TAMP, TAV, TAVG, TMAX, WW, DSMID, ATOT, TMA);
        ATOT = zz_SOILT.getATOT();
        TMA = zz_SOILT.getTMA();
        SRFTEMP = zz_SOILT.getSRFTEMP();
        ST = zz_SOILT.getST();
        s.setCUMDPT(CUMDPT);
        s.setDSMID(DSMID);
        s.setTDL(TDL);
        s.setTMA(TMA);
        s.setATOT(ATOT);
        s.setSRFTEMP(SRFTEMP);
        s.setST(ST);
    }
    public SOILT Calculate_SOILT (Integer NL, Double ALBEDO, Double B, Double CUMDPT, Integer DOY, Double DP, Double HDAY, Integer NLAYR, Double PESW, Double SRAD, Double TAMP, Double TAV, Double TAVG, Double TMAX, Double WW, Double [] DSMID, Double ATOT, Double [] TMA)
    {
        Integer K;
        Integer L;
        Double ALX;
        Double DD;
        Double DT;
        Double FX;
        Double SRFTEMP;
        Double TA;
        Double WC;
        Double ZD;
        Double[] ST =  new Double [NL];
        ALX = ((double)(DOY) - HDAY) * 0.0174d;
        ATOT = ATOT - TMA[5 - 1];
        for (K=5 ; K!=2 - 1 ; K+=-1)
        {
            TMA[K - 1] = TMA[K - 1 - 1];
        }
        TMA[1 - 1] = TAVG;
        TMA[1 - 1] = (int)(TMA[(1 - 1)] * 10000.d) / 10000.d;
        ATOT = ATOT + TMA[1 - 1];
        WC = Math.max(0.01d, PESW) / (WW * CUMDPT) * 10.0d;
        FX = Math.exp(B * Math.pow((1.0d - WC) / (1.0d + WC), 2));
        DD = FX * DP;
        TA = TAV + (TAMP * Math.cos(ALX) / 2.0d);
        DT = ATOT / 5.0d - TA;
        for (L=1 ; L!=NLAYR + 1 ; L+=1)
        {
            ZD = -(DSMID[(L - 1)] / DD);
            ST[L - 1] = TAV + ((TAMP / 2.0d * Math.cos((ALX + ZD)) + DT) * Math.exp(ZD));
            ST[L - 1] = (int)(ST[(L - 1)] * 1000.d) / 1000.d;
        }
        SRFTEMP = TAV + (TAMP / 2.d * Math.cos(ALX) + DT);
        return new SOILT(ATOT, TMA, SRFTEMP, ST);
    }
}
final class SOILT {
    private Double ATOT;
    public Double getATOT()
    { return ATOT; }

    public void setATOT(Double _ATOT)
    { this.ATOT= _ATOT; } 
    
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
    
    public SOILT(Double ATOT,Double [] TMA,Double SRFTEMP,Double [] ST)
    {
        this.ATOT = ATOT;
        this.TMA = TMA;
        this.SRFTEMP = SRFTEMP;
        this.ST = ST;
    }
}