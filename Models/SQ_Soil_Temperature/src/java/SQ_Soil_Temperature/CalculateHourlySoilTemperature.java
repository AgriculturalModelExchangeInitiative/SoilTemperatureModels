import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class CalculateHourlySoilTemperature
{
    private Double b;
    public Double getb()
    { return b; }

    public void setb(Double _b)
    { this.b= _b; } 
    
    private Double a;
    public Double geta()
    { return a; }

    public void seta(Double _a)
    { this.a= _a; } 
    
    private Double c;
    public Double getc()
    { return c; }

    public void setc(Double _c)
    { this.c= _c; } 
    
    public CalculateHourlySoilTemperature() { }
    public void  Calculate_Model(SoilTemperatureState s, SoilTemperatureState s1, SoilTemperatureRate r, SoilTemperatureAuxiliary a,  SoilTemperatureExogenous ex)
    {
        //- Name: CalculateHourlySoilTemperature -Version: 001, -Time step: 1
        //- Description:
    //            * Title: CalculateHourlySoilTemperature model
    //            * Authors: loic.manceau@inra.fr
    //            * Reference: ('http://biomamodelling.org',)
    //            * Institution: INRA
    //            * ExtendedDescription: Calculate Soil temperature on a hourly basis.Parton, W.J. and Logan, J.A., 1981. A model for diurnal variation in soil and air temperature. Agric. Meteorol., 23: 205-216
    //            * ShortDescription: None
        //- inputs:
    //            * name: minTSoil
    //                          ** description : Minimum Soil Temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 20
    //                          ** unit : Â°C
    //            * name: dayLength
    //                          ** description : Length of the day
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 24
    //                          ** min : 0
    //                          ** default : 12
    //                          ** unit : hour
    //            * name: b
    //                          ** description : Delay between sunrise and time when minimum temperature is reached
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 10
    //                          ** min : 0
    //                          ** default : 1.81
    //                          ** unit : Hour
    //            * name: a
    //                          ** description : Delay between sunset and time when maximum temperature is reached
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 10
    //                          ** min : 0
    //                          ** default : 0.5
    //                          ** unit : Hour
    //            * name: maxTSoil
    //                          ** description : Maximum Soil Temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 20
    //                          ** unit : Â°C
    //            * name: c
    //                          ** description : Nighttime temperature coefficient
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 10
    //                          ** min : 0
    //                          ** default : 0.49
    //                          ** unit : Dpmensionless
        //- outputs:
    //            * name: hourlySoilT
    //                          ** description : Hourly Soil Temperature
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 24
    //                          ** max : 80
    //                          ** min : -30
    //                          ** unit : Â°C
        getHourlySoilSurfaceTemperature zz_getHourlySoilSurfaceTemperature;
        Double minTSoil = s.getminTSoil();
        Double dayLength = ex.getdayLength();
        Double maxTSoil = s.getmaxTSoil();
        Double[] hourlySoilT =  new Double [24];
        Integer i;
        if (maxTSoil == (double)(-999) && minTSoil == (double)(999))
        {
            for (i=0 ; i!=12 ; i+=1)
            {
                hourlySoilT[i] = (double)(999);
            }
            for (i=12 ; i!=24 ; i+=1)
            {
                hourlySoilT[i] = (double)(-999);
            }
        }
        else
        {
            for (i=0 ; i!=24 ; i+=1)
            {
                hourlySoilT[i] = 0.0d;
            }
            hourlySoilT = getHourlySoilSurfaceTemperature(maxTSoil, minTSoil, dayLength, b, a, c);
        }
        s.sethourlySoilT(hourlySoilT);
    }
    public static Double [] getHourlySoilSurfaceTemperature(Double TMax, Double TMin, Double ady, Double b, Double a, Double c)
    {
        Integer i;
        Double[] result =  new Double [24];
        Double ahou;
        Double ani;
        Double bb;
        Double be;
        Double bbd;
        Double ddy;
        Double tsn;
        ahou = Math.PI * (ady / 24.0d);
        ani = 24 - ady;
        bb = 12 - (ady / 2) + c;
        be = 12 + (ady / 2);
        for (i=0 ; i!=24 ; i+=1)
        {
            if (i >= (int)(bb) && i <= (int)(be))
            {
                result[i] = (TMax - TMin) * Math.sin(3.14d * (i - bb) / (ady + (2 * a))) + TMin;
            }
            else
            {
                if (i > (int)(be))
                {
                    bbd = i - be;
                }
                else
                {
                    bbd = 24 + be + i;
                }
                ddy = ady - c;
                tsn = (TMax - TMin) * Math.sin(3.14d * ddy / (ady + (2 * a))) + TMin;
                result[i] = TMin + ((tsn - TMin) * Math.exp(-b * bbd / ani));
            }
        }
        return result;
    }
}