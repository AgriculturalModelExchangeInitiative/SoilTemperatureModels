package net.simplace.usermodules.amei.DSSAT_ST_standalone;
import java.util.Arrays;
import java.util.HashMap;

import org.jdom2.Element;

import net.simplace.sim.model.FWSimComponent;
import net.simplace.sim.util.FWSimVarMap;
import net.simplace.sim.util.FWSimVariable;
import net.simplace.sim.util.FWSimVariable.CONTENT_TYPE;
import net.simplace.sim.util.FWSimVariable.DATA_TYPE;


public class STEMP extends FWSimComponent
{
    private FWSimVariable<Integer> NL;
    private FWSimVariable<String> ISWWAT;
    private FWSimVariable<Double[]> BD;
    private FWSimVariable<Double[]> DLAYR;
    private FWSimVariable<Double[]> DS;
    private FWSimVariable<Double[]> DUL;
    private FWSimVariable<Double[]> LL;
    private FWSimVariable<Integer> NLAYR;
    private FWSimVariable<Double> MSALB;
    private FWSimVariable<Double> SRAD;
    private FWSimVariable<Double[]> SW;
    private FWSimVariable<Double> TAVG;
    private FWSimVariable<Double> TMAX;
    private FWSimVariable<Double> XLAT;
    private FWSimVariable<Double> TAV;
    private FWSimVariable<Double> TAMP;
    private FWSimVariable<Double> CUMDPT;
    private FWSimVariable<Double[]> DSMID;
    private FWSimVariable<Double> TDL;
    private FWSimVariable<Double[]> TMA;
    private FWSimVariable<Double> ATOT;
    private FWSimVariable<Double> SRFTEMP;
    private FWSimVariable<Double[]> ST;
    private FWSimVariable<Integer> DOY;
    private FWSimVariable<Double> HDAY;

    public STEMP(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public STEMP(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("NL", "Number of soil layers", DATA_TYPE.INT, CONTENT_TYPE.constant,"dimensionless", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("ISWWAT", "Water simulation control switch", DATA_TYPE.CHAR, CONTENT_TYPE.constant,"dimensionless", null, null, "Y", this));
        addVariable(FWSimVariable.createSimVariable("BD", "Bulk density, soil layer NL", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"g [soil] / cm3 [soil]", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("DLAYR", "Thickness of soil layer L", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"cm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("DS", "Cumulative depth in soil layer L", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"cm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("DUL", "Volumetric soil water content at Drained Upper Limit in soil layer L", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"cm3[water]/cm3[soil]", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("LL", "Volumetric soil water content in soil layer L at lower limit", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"cm3 [water] / cm3 [soil]", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("NLAYR", "Actual number of soil layers", DATA_TYPE.INT, CONTENT_TYPE.constant,"dimensionless", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("MSALB", "Soil albedo with mulch and soil water effects", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"dimensionless", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("SRAD", "Solar radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"MJ/m2-d", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("SW", "Volumetric soil water content in layer L", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"cm3 [water] / cm3 [soil]", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("TAVG", "Average daily temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("TMAX", "Maximum daily temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("XLAT", "Latitude", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("TAV", "Average annual soil temperature, used with TAMP to calculate soil temperature.", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("TAMP", "Amplitude of temperature function used to calculate soil temperatures", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("CUMDPT", "Cumulative depth of soil profile", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("DSMID", "Depth to midpoint of soil layer L", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"cm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("TDL", "Total water content of soil at drained upper limit", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"cm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("TMA", "Array of previous 5 days of average soil temperatures", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("ATOT", "Sum of TMA array (last 5 days soil temperature)", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("SRFTEMP", "Temperature of soil surface litter", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("ST", "Soil temperature in soil layer L", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("DOY", "Current day of simulation", DATA_TYPE.INT, CONTENT_TYPE.input,"d", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("HDAY", "Haverst day", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"day", null, null, null, this));

        return iFieldMap;
    }
    @Override
    protected void init()
    {
        SOILT zz_SOILT;
        Integer t_NL = NL.getValue();
        String t_ISWWAT = ISWWAT.getValue();
        Double [] t_BD = BD.getValue();
        Double [] t_DLAYR = DLAYR.getValue();
        Double [] t_DS = DS.getValue();
        Double [] t_DUL = DUL.getValue();
        Double [] t_LL = LL.getValue();
        Integer t_NLAYR = NLAYR.getValue();
        Double t_MSALB = MSALB.getValue();
        Double t_SRAD = SRAD.getValue();
        Double [] t_SW = SW.getValue();
        Double t_TAVG = TAVG.getValue();
        Double t_TMAX = TMAX.getValue();
        Double t_XLAT = XLAT.getValue();
        Double t_TAV = TAV.getValue();
        Double t_TAMP = TAMP.getValue();
        Integer t_DOY = DOY.getValue();
        Double t_CUMDPT = CUMDPT.getDefault();
        Double [] t_DSMID = new Double[t_NL];
        Double t_TDL = TDL.getDefault();
        Double [] t_TMA = new Double[5];
        Double t_ATOT = ATOT.getDefault();
        Double t_SRFTEMP = SRFTEMP.getDefault();
        Double [] t_ST = new Double[t_NL];
        Double t_HDAY = HDAY.getDefault();
        t_CUMDPT = 0.0d;
        Arrays.fill(t_DSMID, 0.0d);
        t_TDL = 0.0d;
        Arrays.fill(t_TMA, 0.0d);
        t_ATOT = 0.0d;
        t_SRFTEMP = 0.0d;
        Arrays.fill(t_ST, 0.0d);
        t_HDAY = 0.0d;
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
        Double[] DLI = new Double[t_NL];
        Double[] DSI = new Double[t_NL];
        Double[] SWI = new Double[t_NL];
        SWI = t_SW;
        DSI = t_DS;
        if (t_XLAT < 0.0d)
        {
            t_HDAY = 20.0d;
        }
        else
        {
            t_HDAY = 200.0d;
        }
        TBD = 0.0d;
        TLL = 0.0d;
        TSW = 0.0d;
        t_TDL = 0.0d;
        t_CUMDPT = 0.0d;
        for (L=1 ; L!=t_NLAYR + 1 ; L+=1)
        {
            if (L == 1)
            {
                DLI[L - 1] = DSI[L - 1];
            }
            else
            {
                DLI[L - 1] = DSI[L - 1] - DSI[L - 1 - 1];
            }
            t_DSMID[L - 1] = t_CUMDPT + (DLI[(L - 1)] * 5.0d);
            t_CUMDPT = t_CUMDPT + (DLI[(L - 1)] * 10.0d);
            TBD = TBD + (t_BD[(L - 1)] * DLI[(L - 1)]);
            TLL = TLL + (t_LL[(L - 1)] * DLI[(L - 1)]);
            TSW = TSW + (SWI[(L - 1)] * DLI[(L - 1)]);
            t_TDL = t_TDL + (t_DUL[(L - 1)] * DLI[(L - 1)]);
        }
        if (t_ISWWAT == "Y")
        {
            PESW = Math.max(0.0d, TSW - TLL);
        }
        else
        {
            PESW = Math.max(0.0d, t_TDL - TLL);
        }
        ABD = TBD / DSI[(t_NLAYR - 1)];
        FX = ABD / (ABD + (686.0d * Math.exp(-(5.63d * ABD))));
        DP = 1000.0d + (2500.0d * FX);
        WW = 0.356d - (0.144d * ABD);
        B = Math.log(500.0d / DP);
        ALBEDO = t_MSALB;
        for (I=1 ; I!=5 + 1 ; I+=1)
        {
            t_TMA[I - 1] = (int)(t_TAVG * 10000.d) / 10000.d;
        }
        t_ATOT = t_TMA[(1 - 1)] * 5.0d;
        for (L=1 ; L!=t_NLAYR + 1 ; L+=1)
        {
            t_ST[L - 1] = t_TAVG;
        }
        for (I=1 ; I!=8 + 1 ; I+=1)
        {
            zz_SOILT = Calculate_SOILT(t_NL, ALBEDO, B, t_CUMDPT, t_DOY, DP, t_HDAY, t_NLAYR, PESW, t_SRAD, t_TAMP, t_TAV, t_TAVG, t_TMAX, WW, t_DSMID, t_ATOT, t_TMA, t_ST);
            t_ATOT = zz_SOILT.getATOT();
            t_TMA = zz_SOILT.getTMA();
            t_SRFTEMP = zz_SOILT.getSRFTEMP();
            t_ST = zz_SOILT.getST();
        }
        CUMDPT.setValue(t_CUMDPT, this);
        DSMID.setValue(t_DSMID, this);
        TDL.setValue(t_TDL, this);
        TMA.setValue(t_TMA, this);
        ATOT.setValue(t_ATOT, this);
        SRFTEMP.setValue(t_SRFTEMP, this);
        ST.setValue(t_ST, this);
        HDAY.setValue(t_HDAY, this);
    }
    @Override
    protected void process()
    {
        SOILT zz_SOILT;
        Integer t_NL = NL.getValue();
        String t_ISWWAT = ISWWAT.getValue();
        Double [] t_BD = BD.getValue();
        Double [] t_DLAYR = DLAYR.getValue();
        Double [] t_DS = DS.getValue();
        Double [] t_DUL = DUL.getValue();
        Double [] t_LL = LL.getValue();
        Integer t_NLAYR = NLAYR.getValue();
        Double t_MSALB = MSALB.getValue();
        Double t_SRAD = SRAD.getValue();
        Double [] t_SW = SW.getValue();
        Double t_TAVG = TAVG.getValue();
        Double t_TMAX = TMAX.getValue();
        Double t_XLAT = XLAT.getValue();
        Double t_TAV = TAV.getValue();
        Double t_TAMP = TAMP.getValue();
        Double t_CUMDPT = CUMDPT.getValue();
        Double [] t_DSMID = DSMID.getValue();
        Double t_TDL = TDL.getValue();
        Double [] t_TMA = TMA.getValue();
        Double t_ATOT = ATOT.getValue();
        Double t_SRFTEMP = SRFTEMP.getValue();
        Double [] t_ST = ST.getValue();
        Integer t_DOY = DOY.getValue();
        Double t_HDAY = HDAY.getValue();
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
        ALBEDO = t_MSALB;
        if (t_ISWWAT.equalsIgnoreCase("Y"))
        {
            PESW = Math.max(0.0d, TSW - TLL);
        }
        else
        {
            PESW = Math.max(0.0d, t_TDL - TLL);
        }
        zz_SOILT = Calculate_SOILT(t_NL, ALBEDO, B, t_CUMDPT, t_DOY, DP, t_HDAY, t_NLAYR, PESW, t_SRAD, t_TAMP, t_TAV, t_TAVG, t_TMAX, WW, t_DSMID, t_ATOT, t_TMA, t_ST);
        t_ATOT = zz_SOILT.getATOT();
        t_TMA = zz_SOILT.getTMA();
        t_SRFTEMP = zz_SOILT.getSRFTEMP();
        t_ST = zz_SOILT.getST();
        CUMDPT.setValue(t_CUMDPT, this);
        DSMID.setValue(t_DSMID, this);
        TDL.setValue(t_TDL, this);
        TMA.setValue(t_TMA, this);
        ATOT.setValue(t_ATOT, this);
        SRFTEMP.setValue(t_SRFTEMP, this);
        ST.setValue(t_ST, this);
    }
    public SOILT Calculate_SOILT (Integer t_NL, Double ALBEDO, Double B, Double t_CUMDPT, Integer t_DOY, Double DP, Double t_HDAY, Integer t_NLAYR, Double PESW, Double t_SRAD, Double t_TAMP, Double t_TAV, Double t_TAVG, Double t_TMAX, Double WW, Double [] t_DSMID, Double t_ATOT, Double [] t_TMA, Double[] t_ST)
    {
        Integer K;
        Integer L;
        Double ALX;
        Double DD;
        Double DT;
        Double FX;
        Double t_SRFTEMP;
        Double TA;
        Double WC;
        Double ZD;
        Double[] ST = new Double[t_NL];
        ALX = ((double)(t_DOY) - t_HDAY) * 0.0174d;
        t_ATOT = t_ATOT - t_TMA[5 - 1];
        for (K=5 ; K!=2 - 1 ; K+=-1)
        {
            t_TMA[K - 1] = t_TMA[K - 1 - 1];
        }
        t_TMA[1 - 1] = (1.0d - ALBEDO) * (t_TAVG + ((t_TMAX - t_TAVG) * Math.sqrt(t_SRAD * 0.03d))) + (ALBEDO * t_TMA[(1 - 1)]);
        t_TMA[1 - 1] = (int)(t_TMA[(1 - 1)] * 10000.d) / 10000.d;
        t_ATOT = t_ATOT + t_TMA[1 - 1];
        WC = Math.max(0.01d, PESW) / (WW * t_CUMDPT) * 10.0d;
        FX = Math.exp(B * Math.pow((1.0d - WC) / (1.0d + WC), 2));
        DD = FX * DP;
        TA = t_TAV + (t_TAMP * Math.cos(ALX) / 2.0d);
        DT = t_ATOT / 5.0d - TA;
        for (L=1 ; L!=t_NLAYR + 1 ; L+=1)
        {
            ZD = -(t_DSMID[(L - 1)] / DD);
            t_ST[L - 1] = t_TAV + ((t_TAMP / 2.0d * Math.cos((ALX + ZD)) + DT) * Math.exp(ZD));
            t_ST[L - 1] = (int)(t_ST[(L - 1)] * 1000.d) / 1000.d;
        }
        t_SRFTEMP = t_TAV + (t_TAMP / 2.d * Math.cos(ALX) + DT);
        return new SOILT(t_ATOT, t_TMA, t_SRFTEMP, t_ST);
    }

    public HashMap<String, FWSimVariable<?>> fillTestVariables(int aParamIndex, TEST_STATE aDefineOrCheck)
    {
        return iFieldMap;
    }

    @Override
    protected FWSimComponent clone(FWSimVarMap aVarMap)
    {
        return new STEMP(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
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