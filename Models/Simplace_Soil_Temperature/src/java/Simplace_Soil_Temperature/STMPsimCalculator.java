import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class STMPsimCalculator
{
    public void Init(SoilTemperatureState s, SoilTemperatureState s1, SoilTemperatureRate r, SoilTemperatureAuxiliary a,  SoilTemperatureExogenous ex)
    {
        double iSoilWaterContent = ex.getiSoilWaterContent();
        double iSoilSurfaceTemperature = ex.getiSoilSurfaceTemperature();
        Double[] SoilTempArray ;
        Double[] rSoilTempArrayRate ;
        Double[] pSoilLayerDepth ;
        double tProfileDepth;
        double additionalDepth;
        double firstAdditionalLayerHight;
        Integer layers;
        Double[] tStmp ;
        Double[] tStmpRate ;
        Double[] tz ;
        Integer i;
        double depth;
        tProfileDepth = cSoilLayerDepth[cSoilLayerDepth.length - 1];
        additionalDepth = cDampingDepth - tProfileDepth;
        firstAdditionalLayerHight = additionalDepth - (double)(Math.floor(additionalDepth));
        layers = (int)(Math.abs((double)((int) Math.ceil(additionalDepth)))) + cSoilLayerDepth.length;
        tStmp = new Double [layers];
        tStmpRate = new Double [layers];
        tz = new Double [layers];
        for (i=0 ; i!=tStmp.length ; i+=1)
        {
            if (i < cSoilLayerDepth.length)
            {
                depth = cSoilLayerDepth[i];
            }
            else
            {
                depth = tProfileDepth + firstAdditionalLayerHight + i - cSoilLayerDepth.length;
            }
            tz[i] = depth;
            tStmp[i] = (cFirstDayMeanTemp * (cDampingDepth - depth) + (cAVT * depth)) / cDampingDepth;
        }
        rSoilTempArrayRate = tStmpRate;
        SoilTempArray = tStmp;
        pSoilLayerDepth = tz;
        s.setSoilTempArray(SoilTempArray);
        s.setrSoilTempArrayRate(rSoilTempArrayRate);
        s.setpSoilLayerDepth(pSoilLayerDepth);
    }
    private Double [] cSoilLayerDepth;
    public Double [] getcSoilLayerDepth()
    { return cSoilLayerDepth; }

    public void setcSoilLayerDepth(Double [] _cSoilLayerDepth)
    { this.cSoilLayerDepth= _cSoilLayerDepth; } 
    
    private double cFirstDayMeanTemp;
    public double getcFirstDayMeanTemp()
    { return cFirstDayMeanTemp; }

    public void setcFirstDayMeanTemp(double _cFirstDayMeanTemp)
    { this.cFirstDayMeanTemp= _cFirstDayMeanTemp; } 
    
    private double cAVT;
    public double getcAVT()
    { return cAVT; }

    public void setcAVT(double _cAVT)
    { this.cAVT= _cAVT; } 
    
    private double cABD;
    public double getcABD()
    { return cABD; }

    public void setcABD(double _cABD)
    { this.cABD= _cABD; } 
    
    private double cDampingDepth;
    public double getcDampingDepth()
    { return cDampingDepth; }

    public void setcDampingDepth(double _cDampingDepth)
    { this.cDampingDepth= _cDampingDepth; } 
    
    public STMPsimCalculator() { }
    public void  Calculate_Model(SoilTemperatureState s, SoilTemperatureState s1, SoilTemperatureRate r, SoilTemperatureAuxiliary a,  SoilTemperatureExogenous ex)
    {
        //- Name: STMPsimCalculator -Version: 001, -Time step: 1
        //- Description:
    //            * Title: STMPsimCalculator model
    //            * Authors: Gunther Krauss
    //            * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    //            * Institution: INRES Pflanzenbau, Uni Bonn
    //            * ExtendedDescription: as given in the documentation
    //            * ShortDescription: None
        //- inputs:
    //            * name: cSoilLayerDepth
    //                          ** description : Depth of soil layer
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 20.0
    //                          ** min : 0.03
    //                          ** default : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
    //            * name: cFirstDayMeanTemp
    //                          ** description : Mean air temperature on first day
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 50.0
    //                          ** min : -40.0
    //                          ** default : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    //            * name: cAVT
    //                          ** description : Constant Temperature of deepest soil layer - use long term mean air temperature
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 20.0
    //                          ** min : -10.0
    //                          ** default : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    //            * name: cABD
    //                          ** description : Mean bulk density
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 4.0
    //                          ** min : 1.0
    //                          ** default : 2.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/tonne_per_cubic_metre
    //            * name: cDampingDepth
    //                          ** description : Initial value for damping depth of soil
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 20.0
    //                          ** min : 1.5
    //                          ** default : 6.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
    //            * name: iSoilWaterContent
    //                          ** description : Water content, sum of whole soil profile
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 20.0
    //                          ** min : 1.5
    //                          ** default : 5.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre
    //            * name: iSoilSurfaceTemperature
    //                          ** description : Temperature at soil surface
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 20.0
    //                          ** min : 1.5
    //                          ** default : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    //            * name: SoilTempArray
    //                          ** description : Array of soil temperatures in layers 
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 50.0
    //                          ** min : -40.0
    //                          ** default : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    //            * name: rSoilTempArrayRate
    //                          ** description : Array of daily temperature change
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 20
    //                          ** min : -20
    //                          ** default : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius_per_day
    //            * name: pSoilLayerDepth
    //                          ** description : Depth of soil layer plus additional depth
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 20.0
    //                          ** min : 0.03
    //                          ** default : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/metre
        //- outputs:
    //            * name: SoilTempArray
    //                          ** description : Array of soil temperatures in layers 
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 50.0
    //                          ** min : -40.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    //            * name: rSoilTempArrayRate
    //                          ** description : Array of daily temperature change
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 20
    //                          ** min : -20
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius_per_day
        double iSoilWaterContent = ex.getiSoilWaterContent();
        double iSoilSurfaceTemperature = ex.getiSoilSurfaceTemperature();
        Double [] SoilTempArray = s.getSoilTempArray();
        Double [] rSoilTempArrayRate = s.getrSoilTempArrayRate();
        Double [] pSoilLayerDepth = s.getpSoilLayerDepth();
        double XLAG;
        double XLG1;
        double DP;
        double WC;
        double DD;
        double Z1;
        Integer i;
        double ZD;
        double RATE;
        XLAG = .8d;
        XLG1 = 1 - XLAG;
        DP = 1 + (2.5d * cABD / (cABD + Math.exp(6.53d - (5.63d * cABD))));
        WC = 0.001d * iSoilWaterContent / ((.356d - (.144d * cABD)) * cSoilLayerDepth[(cSoilLayerDepth.length - 1)]);
        DD = Math.exp(Math.log(0.5d / DP) * ((1 - WC) / (1 + WC)) * 2) * DP;
        Z1 = (double)(0);
        for (i=0 ; i!=SoilTempArray.length ; i+=1)
        {
            ZD = 0.5d * (Z1 + pSoilLayerDepth[i]) / DD;
            RATE = ZD / (ZD + Math.exp(-.8669d - (2.0775d * ZD))) * (cAVT - iSoilSurfaceTemperature);
            RATE = XLG1 * (RATE + iSoilSurfaceTemperature - SoilTempArray[i]);
            Z1 = pSoilLayerDepth[i];
            rSoilTempArrayRate[i] = RATE;
            SoilTempArray[i] = SoilTempArray[i] + rSoilTempArrayRate[i];
        }
        s.setSoilTempArray(SoilTempArray);
        s.setrSoilTempArrayRate(rSoilTempArrayRate);
    }
}