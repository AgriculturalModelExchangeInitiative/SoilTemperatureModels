using System;
using System.Collections.Generic;
using System.Linq;
public class CalculateSoilTemperature
{
    private double _lambda_;
    public double lambda_
        {
            get { return this._lambda_; }
            set { this._lambda_= value; } 
        }
        public CalculateSoilTemperature() { }
    
    public void  CalculateModel(SoilTemperatureState s, SoilTemperatureState s1, SoilTemperatureRate r, SoilTemperatureAuxiliary a, SoilTemperatureExogenous ex)
    {
        //- Name: CalculateSoilTemperature -Version: 001, -Time step: 1
        //- Description:
    //            * Title: CalculateSoilTemperature model
    //            * Authors: loic.manceau@inra.fr
    //            * Reference: ('http://biomamodelling.org',)
    //            * Institution: INRA
    //            * ExtendedDescription: Calculation of minimum and maximum Soil temperature, Further used in shoot temperature estimate.
    //            * ShortDescription: None
        //- inputs:
    //            * name: deepLayerT
    //                          ** description : Temperature of the last soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 20
    //                          ** unit : °C
    //            * name: lambda_
    //                          ** description : Latente heat of water vaporization at 20°C
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 10
    //                          ** min : 0
    //                          ** default : 2.454
    //                          ** unit : MJ.kg-1
    //            * name: heatFlux
    //                          ** description : Soil Heat Flux from Energy Balance Component
    //                          ** inputtype : variable
    //                          ** variablecategory : rate
    //                          ** datatype : DOUBLE
    //                          ** max : 100
    //                          ** min : 0
    //                          ** default : 50
    //                          ** unit : g m-2 d-1
    //            * name: meanTAir
    //                          ** description : Mean Air Temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 22
    //                          ** unit : °C
    //            * name: minTAir
    //                          ** description : Minimum Air Temperature from Weather files
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 20
    //                          ** unit : °C
    //            * name: deepLayerT_t1
    //                          ** description : Temperature of the last soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 20
    //                          ** unit : °C
    //            * name: maxTAir
    //                          ** description : Maximum Air Temperature from Weather Files
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 25
    //                          ** unit : °C
        //- outputs:
    //            * name: deepLayerT_t1
    //                          ** description : Temperature of the last soil layer
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 80
    //                          ** min : -30
    //                          ** unit : °C
    //            * name: maxTSoil
    //                          ** description : Maximum Soil Temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 80
    //                          ** min : -30
    //                          ** unit : °C
    //            * name: minTSoil
    //                          ** description : Minimum Soil Temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 80
    //                          ** min : -30
    //                          ** unit : °C
        double deepLayerT = s.deepLayerT;
        double heatFlux = r.heatFlux;
        double meanTAir = ex.meanTAir;
        double minTAir = ex.minTAir;
        double deepLayerT_t1 = s1.deepLayerT;
        double maxTAir = ex.maxTAir;
        double maxTSoil;
        double minTSoil;
        if (maxTAir == (double)(-999) && minTAir == (double)(999))
        {
            minTSoil = (double)(999);
            maxTSoil = (double)(-999);
            deepLayerT_t1 = 0.0d;
        }
        else
        {
            minTSoil = SoilMinimumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT);
            maxTSoil = SoilMaximumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT_t1);
            deepLayerT_t1 = UpdateTemperature(minTSoil, maxTSoil, deepLayerT);
        }
        s.deepLayerT_t1= deepLayerT_t1;
        s.maxTSoil= maxTSoil;
        s.minTSoil= minTSoil;
    }
    public static double SoilTempB(double weatherMinTemp, double deepTemperature)
    {
        return (weatherMinTemp + deepTemperature) / 2.0d;
    }
    public static double SoilTempA(double weatherMaxTemp, double weatherMeanTemp, double soilHeatFlux, double lambda_)
    {
        double TempAdjustment;
        double SoilAvailableEnergy;
        TempAdjustment = weatherMeanTemp < 8.0d ? -0.5d * weatherMeanTemp + 4.0d : (double)(0);
        SoilAvailableEnergy = soilHeatFlux * lambda_ / 1000;
        return weatherMaxTemp + (11.2d * (1.0d - Math.Exp(-0.07d * (SoilAvailableEnergy - 5.5d)))) + TempAdjustment;
    }
    public static double SoilMinimumTemperature(double weatherMaxTemp, double weatherMeanTemp, double weatherMinTemp, double soilHeatFlux, double lambda_, double deepTemperature)
    {
        return Math.Min(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature));
    }
    public static double SoilMaximumTemperature(double weatherMaxTemp, double weatherMeanTemp, double weatherMinTemp, double soilHeatFlux, double lambda_, double deepTemperature)
    {
        return Math.Max(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature));
    }
    public static double UpdateTemperature(double minSoilTemp, double maxSoilTemp, double Temperature)
    {
        double meanTemp;
        meanTemp = (minSoilTemp + maxSoilTemp) / 2.0d;
        Temperature = (9.0d * Temperature + meanTemp) / 10.0d;
        return Temperature;
    }
}