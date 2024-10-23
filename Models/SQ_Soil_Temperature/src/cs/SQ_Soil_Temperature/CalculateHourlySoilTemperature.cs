using System;
using System.Collections.Generic;
using System.Linq;
public class CalculateHourlySoilTemperature
{
    private double _b;
    public double b
        {
            get { return this._b; }
            set { this._b= value; } 
        }
    private double _a;
    public double a
        {
            get { return this._a; }
            set { this._a= value; } 
        }
    private double _c;
    public double c
        {
            get { return this._c; }
            set { this._c= value; } 
        }
        public CalculateHourlySoilTemperature() { }
    
    public void  CalculateModel(SoilTemperatureState s, SoilTemperatureState s1, SoilTemperatureRate r, SoilTemperatureAuxiliary a, SoilTemperatureExogenous ex)
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
        double minTSoil = s.minTSoil;
        double dayLength = ex.dayLength;
        double maxTSoil = s.maxTSoil;
        double[] hourlySoilT =  new double [24];
        int i;
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
                hourlySoilT[i] = 0.00d;
            }
            hourlySoilT = getHourlySoilSurfaceTemperature(maxTSoil, minTSoil, dayLength, b, a, c);
        }
        s.hourlySoilT= hourlySoilT;
    }
    public static double[] getHourlySoilSurfaceTemperature(double TMax, double TMin, double ady, double b, double a, double c)
    {
        int i;
        double[] result =  new double [24];
        double ahou;
        double ani;
        double bb;
        double be;
        double bbd;
        double ddy;
        double tsn;
        ahou = Math.PI * (ady / 24.00d);
        ani = 24 - ady;
        bb = 12 - (ady / 2) + c;
        be = 12 + (ady / 2);
        for (i=0 ; i!=24 ; i+=1)
        {
            if (i >= (int)(bb) && i <= (int)(be))
            {
                result[i] = (TMax - TMin) * Math.Sin(3.140d * (i - bb) / (ady + (2 * a))) + TMin;
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
                tsn = (TMax - TMin) * Math.Sin(3.140d * ddy / (ady + (2 * a))) + TMin;
                result[i] = TMin + ((tsn - TMin) * Math.Exp(-b * bbd / ani));
            }
        }
        return result;
    }
}