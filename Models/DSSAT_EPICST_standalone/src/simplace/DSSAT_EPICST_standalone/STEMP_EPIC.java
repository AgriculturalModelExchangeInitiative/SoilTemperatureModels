package net.simplace.sim.components.DSSAT_EPICST_standalone;
import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
import net.simplace.sim.model.FWSimComponent;
import net.simplace.sim.util.FWSimVarMap;
import net.simplace.sim.util.FWSimVariable;
import net.simplace.sim.util.FWSimVariable.CONTENT_TYPE;
import net.simplace.sim.util.FWSimVariable.DATA_TYPE;
import org.jdom2.Element;


public class STEMP_EPIC extends FWSimComponent
{
    private FWSimVariable<Integer> NL;
    private FWSimVariable<String> ISWWAT;
    private FWSimVariable<Double[]> BD;
    private FWSimVariable<Double[]> DLAYR;
    private FWSimVariable<Double[]> DS;
    private FWSimVariable<Double[]> DUL;
    private FWSimVariable<Double[]> LL;
    private FWSimVariable<Integer> NLAYR;
    private FWSimVariable<Double> TAMP;
    private FWSimVariable<Double> RAIN;
    private FWSimVariable<Double[]> SW;
    private FWSimVariable<Double> TAVG;
    private FWSimVariable<Double> TMAX;
    private FWSimVariable<Double> TMIN;
    private FWSimVariable<Double> TAV;
    private FWSimVariable<Double> CUMDPT;
    private FWSimVariable<Double[]> DSMID;
    private FWSimVariable<Double> TDL;
    private FWSimVariable<Double[]> TMA;
    private FWSimVariable<Integer> NDays;
    private FWSimVariable<Integer[]> WetDay;
    private FWSimVariable<Double> X2_PREV;
    private FWSimVariable<Double> SRFTEMP;
    private FWSimVariable<Double[]> ST;
    private FWSimVariable<Double> DEPIR;
    private FWSimVariable<Double> BIOMAS;
    private FWSimVariable<Double> MULCHMASS;
    private FWSimVariable<Double> SNOW;

    public STEMP_EPIC(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public STEMP_EPIC(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("NL", "Number of soil layers", DATA_TYPE.INT, CONTENT_TYPE.constant,"dimensionless", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("ISWWAT", "Water simulation control switch (Y or N)", DATA_TYPE.CHAR, CONTENT_TYPE.constant,"dimensionless", null, null, "Y", this));
        addVariable(FWSimVariable.createSimVariable("BD", "Bulk density, soil layer NL", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"g [soil] / cm3 [soil]", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("DLAYR", "Thickness of soil layer NL", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"cm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("DS", "Cumulative depth in soil layer NL", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"cm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("DUL", "Volumetric soil water content at Drained Upper Limit in soil layer L", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"cm3[water]/cm3[soil]", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("LL", "Volumetric soil water content in soil layer NL at lower limit", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"cm3 [water] / cm3 [soil]", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("NLAYR", "Actual number of soil layers", DATA_TYPE.INT, CONTENT_TYPE.constant,"dimensionless", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("TAMP", "Annual amplitude of the average air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("RAIN", "daily rainfall", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("SW", "Volumetric soil water content in layer NL", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"cm3 [water] / cm3 [soil]", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("TAVG", "Average daily temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("TMAX", "Maximum daily temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("TMIN", "Minimum Temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("TAV", "Average annual soil temperature, used with TAMP to calculate soil temperature.", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("CUMDPT", "Cumulative depth of soil profile", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("DSMID", "Depth to midpoint of soil layer NL", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"cm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("TDL", "Total water content of soil at drained upper limit", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"cm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("TMA", "Array of previous 5 days of average soil temperatures.", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("NDays", "Number of days ...", DATA_TYPE.INT, CONTENT_TYPE.state,"day", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("WetDay", "Wet Days", DATA_TYPE.INTARRAY, CONTENT_TYPE.state,"day", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("X2_PREV", "Temperature of soil surface at precedent timestep", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("SRFTEMP", "Temperature of soil surface litter", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("ST", "Soil temperature in soil layer NL", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("DEPIR", "Depth of irrigation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("BIOMAS", "Biomass", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"kg/ha", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("MULCHMASS", "Mulch Mass", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"kg/ha", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("SNOW", "Snow cover", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", null, null, null, this));

        return iFieldMap;
    }
    @Override
    protected void init()
    {
        SOILT_EPIC zz_SOILT_EPIC;
        Integer t_NL = NL.getValue();
        String t_ISWWAT = ISWWAT.getValue();
        Double [] t_BD = BD.getValue();
        Double [] t_DLAYR = DLAYR.getValue();
        Double [] t_DS = DS.getValue();
        Double [] t_DUL = DUL.getValue();
        Double [] t_LL = LL.getValue();
        Integer t_NLAYR = NLAYR.getValue();
        Double t_TAMP = TAMP.getValue();
        Double t_RAIN = RAIN.getValue();
        Double [] t_SW = SW.getValue();
        Double t_TAVG = TAVG.getValue();
        Double t_TMAX = TMAX.getValue();
        Double t_TMIN = TMIN.getValue();
        Double t_TAV = TAV.getValue();
        Double t_DEPIR = DEPIR.getValue();
        Double t_BIOMAS = BIOMAS.getValue();
        Double t_MULCHMASS = MULCHMASS.getValue();
        Double t_SNOW = SNOW.getValue();
        Double t_CUMDPT = CUMDPT.getDefault();
        Double [] t_DSMID = new Double[t_NL];
        Double t_TDL = TDL.getDefault();
        Double [] t_TMA = new Double[5];
        Integer t_NDays = NDays.getDefault();
        Integer [] t_WetDay = new Integer[30];
        Double t_X2_PREV = X2_PREV.getDefault();
        Double t_SRFTEMP = SRFTEMP.getDefault();
        Double [] t_ST = new Double[t_NL];
        t_CUMDPT = 0.0d;
        Arrays.fill(t_DSMID, 0.0d);
        t_TDL = 0.0d;
        Arrays.fill(t_TMA, 0.0d);
        t_NDays = 0;
        Arrays.fill(t_WetDay, 0);
        t_X2_PREV = 0.0d;
        t_SRFTEMP = 0.0d;
        Arrays.fill(t_ST, 0.0d);
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
        Double[] SWI = new Double[t_NL];
        SWI = t_SW;
        TBD = 0.0d;
        TLL = 0.0d;
        TSW = 0.0d;
        t_TDL = 0.0d;
        t_CUMDPT = 0.0d;
        for (L=1 ; L!=t_NLAYR + 1 ; L+=1)
        {
            t_DSMID[L - 1] = t_CUMDPT + (t_DLAYR[(L - 1)] * 5.0d);
            t_CUMDPT = t_CUMDPT + (t_DLAYR[(L - 1)] * 10.0d);
            TBD = TBD + (t_BD[(L - 1)] * t_DLAYR[(L - 1)]);
            TLL = TLL + (t_LL[(L - 1)] * t_DLAYR[(L - 1)]);
            TSW = TSW + (SWI[(L - 1)] * t_DLAYR[(L - 1)]);
            t_TDL = t_TDL + (t_DUL[(L - 1)] * t_DLAYR[(L - 1)]);
        }
        if (t_ISWWAT == "Y")
        {
            PESW = Math.max(0.0d, TSW - TLL);
        }
        else
        {
            PESW = Math.max(0.0d, t_TDL - TLL);
        }
        ABD = TBD / t_DS[(t_NLAYR - 1)];
        FX = ABD / (ABD + (686.0d * Math.exp(-(5.63d * ABD))));
        DP = 1000.0d + (2500.0d * FX);
        WW = 0.356d - (0.144d * ABD);
        B = Math.log(500.0d / DP);
        for (I=1 ; I!=5 + 1 ; I+=1)
        {
            t_TMA[I - 1] = (int)(t_TAVG * 10000.d) / 10000.d;
        }
        X2_AVG = t_TMA[(1 - 1)] * 5.0d;
        for (L=1 ; L!=t_NLAYR + 1 ; L+=1)
        {
            t_ST[L - 1] = t_TAVG;
        }
        WFT = 0.1d;
        Arrays.fill(t_WetDay, 0);
        t_NDays = 0;
        CV = t_MULCHMASS / 1000.d;
        BCV1 = CV / (CV + Math.exp(5.3396d - (2.3951d * CV)));
        BCV2 = t_SNOW / (t_SNOW + Math.exp(2.303d - (0.2197d * t_SNOW)));
        BCV = Math.max(BCV1, BCV2);
        for (I=1 ; I!=8 + 1 ; I+=1)
        {
            zz_SOILT_EPIC = Calculate_SOILT_EPIC(t_NL, B, BCV, t_CUMDPT, DP, t_DSMID, t_NLAYR, PESW, t_TAV, t_TAVG, t_TMAX, t_TMIN, 0, WFT, WW, t_TMA, t_ST, t_X2_PREV);
            t_TMA = zz_SOILT_EPIC.getTMA();
            t_SRFTEMP = zz_SOILT_EPIC.getSRFTEMP();
            t_ST = zz_SOILT_EPIC.getST();
            X2_AVG = zz_SOILT_EPIC.getX2_AVG();
            t_X2_PREV = zz_SOILT_EPIC.getX2_PREV();
        }
        CUMDPT.setValue(t_CUMDPT, this);
        DSMID.setValue(t_DSMID, this);
        TDL.setValue(t_TDL, this);
        TMA.setValue(t_TMA, this);
        NDays.setValue(t_NDays, this);
        WetDay.setValue(t_WetDay, this);
        X2_PREV.setValue(t_X2_PREV, this);
        SRFTEMP.setValue(t_SRFTEMP, this);
        ST.setValue(t_ST, this);
    }
    @Override
    protected void process()
    {
        SOILT_EPIC zz_SOILT_EPIC;
        Integer t_NL = NL.getValue();
        String t_ISWWAT = ISWWAT.getValue();
        Double [] t_BD = BD.getValue();
        Double [] t_DLAYR = DLAYR.getValue();
        Double [] t_DS = DS.getValue();
        Double [] t_DUL = DUL.getValue();
        Double [] t_LL = LL.getValue();
        Integer t_NLAYR = NLAYR.getValue();
        Double t_TAMP = TAMP.getValue();
        Double t_RAIN = RAIN.getValue();
        Double [] t_SW = SW.getValue();
        Double t_TAVG = TAVG.getValue();
        Double t_TMAX = TMAX.getValue();
        Double t_TMIN = TMIN.getValue();
        Double t_TAV = TAV.getValue();
        Double t_CUMDPT = CUMDPT.getValue();
        Double [] t_DSMID = new Double[t_NL];
        Double t_TDL = TDL.getValue();
        Double [] t_TMA = new Double[5];
        Integer t_NDays = NDays.getValue();
        Integer [] t_WetDay = new Integer[30];
        Double t_X2_PREV = X2_PREV.getValue();
        Double t_SRFTEMP = SRFTEMP.getValue();
        Double [] t_ST = new Double[t_NL];
        Double t_DEPIR = DEPIR.getValue();
        Double t_BIOMAS = BIOMAS.getValue();
        Double t_MULCHMASS = MULCHMASS.getValue();
        Double t_SNOW = SNOW.getValue();
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
        for (L=1 ; L!=t_NLAYR + 1 ; L+=1)
        {
            TBD = TBD + (t_BD[(L - 1)] * t_DLAYR[(L - 1)]);
            t_TDL = t_TDL + (t_DUL[(L - 1)] * t_DLAYR[(L - 1)]);
            TLL = TLL + (t_LL[(L - 1)] * t_DLAYR[(L - 1)]);
            TSW = TSW + (t_SW[(L - 1)] * t_DLAYR[(L - 1)]);
        }
        ABD = TBD / t_DS[(t_NLAYR - 1)];
        FX = ABD / (ABD + (686.0d * Math.exp(-(5.63d * ABD))));
        DP = 1000.0d + (2500.0d * FX);
        WW = 0.356d - (0.144d * ABD);
        B = Math.log(500.0d / DP);
        if (t_ISWWAT == "Y")
        {
            PESW = Math.max(0.0d, TSW - TLL);
        }
        else
        {
            PESW = Math.max(0.0d, t_TDL - TLL);
        }
        if (t_NDays == 30)
        {
            for (I=1 ; I!=29 + 1 ; I+=1)
            {
                t_WetDay[I - 1] = t_WetDay[I + 1 - 1];
            }
        }
        else
        {
            t_NDays = t_NDays + 1;
        }
        if (t_RAIN + t_DEPIR > 1.E-6d)
        {
            t_WetDay[t_NDays - 1] = 1;
        }
        else
        {
            t_WetDay[t_NDays - 1] = 0;
        }
        NWetDays = Arrays.stream(t_WetDay).mapToInt(Integer::intValue).sum();
        WFT = (double)(NWetDays) / (double)(t_NDays);
        CV = (t_BIOMAS + t_MULCHMASS) / 1000.d;
        BCV1 = CV / (CV + Math.exp(5.3396d - (2.3951d * CV)));
        BCV2 = t_SNOW / (t_SNOW + Math.exp(2.303d - (0.2197d * t_SNOW)));
        BCV = Math.max(BCV1, BCV2);
        zz_SOILT_EPIC = Calculate_SOILT_EPIC(t_NL, B, BCV, t_CUMDPT, DP, t_DSMID, t_NLAYR, PESW, t_TAV, t_TAVG, t_TMAX, t_TMIN, t_WetDay[t_NDays - 1], WFT, WW, t_TMA, t_ST, t_X2_PREV);
        t_TMA = zz_SOILT_EPIC.getTMA();
        t_SRFTEMP = zz_SOILT_EPIC.getSRFTEMP();
        t_ST = zz_SOILT_EPIC.getST();
        X2_AVG = zz_SOILT_EPIC.getX2_AVG();
        t_X2_PREV = zz_SOILT_EPIC.getX2_PREV();
        CUMDPT.setValue(t_CUMDPT, this);
        DSMID.setValue(t_DSMID, this);
        TDL.setValue(t_TDL, this);
        TMA.setValue(t_TMA, this);
        NDays.setValue(t_NDays, this);
        WetDay.setValue(t_WetDay, this);
        X2_PREV.setValue(t_X2_PREV, this);
        SRFTEMP.setValue(t_SRFTEMP, this);
        ST.setValue(t_ST, this);
    }
    public SOILT_EPIC Calculate_SOILT_EPIC (Integer t_NL, Double B, Double BCV, Double t_CUMDPT, Double DP, Double [] t_DSMID, Integer t_NLAYR, Double PESW, Double t_TAV, Double t_TAVG, Double t_TMAX, Double t_TMIN, Integer t_WetDay, Double WFT, Double WW, Double [] t_TMA, Double [] t_ST, Double t_X2_PREV)
    {
        Integer K;
        Integer L;
        Double DD;
        Double FX;
        Double t_SRFTEMP;
        Double WC;
        Double ZD;
        Double X1;
        Double X2;
        Double X3;
        Double F;
        Double X2_AVG;
        Double LAG;
        LAG = 0.5d;
        WC = Math.max(0.01d, PESW) / (WW * t_CUMDPT) * 10.0d;
        FX = Math.exp(B * Math.pow((1.0d - WC) / (1.0d + WC), 2));
        DD = FX * DP;
        if (t_WetDay > 0)
        {
            X2 = WFT * (t_TAVG - t_TMIN) + t_TMIN;
        }
        else
        {
            X2 = WFT * (t_TMAX - t_TAVG) + t_TAVG + 2.d;
        }
        t_TMA[1 - 1] = X2;
        for (K=5 ; K!=2 - 1 ; K+=-1)
        {
            t_TMA[K - 1] = t_TMA[K - 1 - 1];
        }
        X2_AVG = Arrays.stream(t_TMA).mapToDouble(Double::doubleValue).sum() / 5.0d;
        X3 = (1.d - BCV) * X2_AVG + (BCV * t_X2_PREV);
        t_SRFTEMP = Math.min(X2_AVG, X3);
        X1 = t_TAV - X3;
        for (L=1 ; L!=t_NLAYR + 1 ; L+=1)
        {
            ZD = t_DSMID[(L - 1)] / DD;
            F = ZD / (ZD + Math.exp(-.8669d - (2.0775d * ZD)));
            t_ST[L - 1] = LAG * t_ST[(L - 1)] + ((1.d - LAG) * (F * X1 + X3));
        }
        t_X2_PREV = X2_AVG;
        return new SOILT_EPIC(t_TMA, t_SRFTEMP, t_ST, X2_AVG, t_X2_PREV);
    }

    public HashMap<String, FWSimVariable<?>> fillTestVariables(int aParamIndex, TEST_STATE aDefineOrCheck)
    {
        return iFieldMap;
    }

    @Override
    protected FWSimComponent clone(FWSimVarMap aVarMap)
    {
        return new STEMP_EPIC(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
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