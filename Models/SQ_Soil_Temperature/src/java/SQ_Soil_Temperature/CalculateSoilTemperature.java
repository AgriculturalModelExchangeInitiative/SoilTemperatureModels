import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class CalculateSoilTemperature
{
    public void Init(SoilTemperatureState s, SoilTemperatureState s1, SoilTemperatureRate r, SoilTemperatureAuxiliary a,  SoilTemperatureExogenous ex)
    {
        Double meanTAir = ex.getmeanTAir();
        Double minTAir = ex.getminTAir();
        Double meanAnnualAirTemp = ex.getmeanAnnualAirTemp();
        Double maxTAir = ex.getmaxTAir();
        Double deepLayerT = 20.0;
        deepLayerT = meanAnnualAirTemp;
        s.setdeepLayerT(deepLayerT);
    }
    private Double lambda_;
    public Double getlambda_()
    { return lambda_; }

    public void setlambda_(Double _lambda_)
    { this.lambda_= _lambda_; } 
    
    public CalculateSoilTemperature() { }
    public void  Calculate_Model(SoilTemperatureState s, SoilTemperatureState s1, SoilTemperatureRate r, SoilTemperatureAuxiliary a,  SoilTemperatureExogenous ex)
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
    //            * name: meanTAir
    //                          ** description : Mean Air Temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 22
    //                          ** unit : Â°C
    //            * name: minTAir
    //                          ** description : Minimum Air Temperature from Weather files
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 20
    //                          ** unit : Â°C
    //            * name: lambda_
    //                          ** description : Latente heat of water vaporization at 20Â°C
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 10
    //                          ** min : 0
    //                          ** default : 2.454
    //                          ** unit : MJ.kg-1
    //            * name: deepLayerT
    //                          ** description : Temperature of the last soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 20
    //                          ** unit : Â°C
    //            * name: meanAnnualAirTemp
    //                          ** description : Annual Mean Air Temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 22
    //                          ** unit : Â°C
    //            * name: heatFlux
    //                          ** description : Soil Heat Flux from Energy Balance Component
    //                          ** inputtype : variable
    //                          ** variablecategory : rate
    //                          ** datatype : DOUBLE
    //                          ** max : 100
    //                          ** min : 0
    //                          ** default : 50
    //                          ** unit : g m-2 d-1
    //            * name: maxTAir
    //                          ** description : Maximum Air Temperature from Weather Files
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 25
    //                          ** unit : Â°C
        //- outputs:
    //            * name: minTSoil
    //                          ** description : Minimum Soil Temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 80
    //                          ** min : -30
    //                          ** unit : Â°C
    //            * name: deepLayerT
    //                          ** description : Temperature of the last soil layer
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 80
    //                          ** min : -30
    //                          ** unit : Â°C
    //            * name: maxTSoil
    //                          ** description : Maximum Soil Temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 80
    //                          ** min : -30
    //                          ** unit : Â°C
        SoilMinimumTemperature zz_SoilMinimumTemperature;
        SoilMaximumTemperature zz_SoilMaximumTemperature;
        UpdateTemperature zz_UpdateTemperature;
        Double meanTAir = ex.getmeanTAir();
        Double minTAir = ex.getminTAir();
        Double deepLayerT = s.getdeepLayerT();
        Double meanAnnualAirTemp = ex.getmeanAnnualAirTemp();
        Double heatFlux = r.getheatFlux();
        Double maxTAir = ex.getmaxTAir();
        Double minTSoil;
        Double maxTSoil;
        Double tmp;
        tmp = meanAnnualAirTemp;
        if (maxTAir == (double)(-999) && minTAir == (double)(999))
        {
            minTSoil = (double)(999);
            maxTSoil = (double)(-999);
            deepLayerT = 0.0d;
        }
        else
        {
            minTSoil = SoilMinimumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT);
            maxTSoil = SoilMaximumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT);
            deepLayerT = UpdateTemperature(minTSoil, maxTSoil, deepLayerT);
        }
        s.setdeepLayerT(deepLayerT);
        s.setminTSoil(minTSoil);
        s.setmaxTSoil(maxTSoil);
    }
    public static Double SoilTempB(Double weatherMinTemp, Double deepTemperature)
    {
        return (weatherMinTemp + deepTemperature) / 2.0d;
    }
    public static Double SoilTempA(Double weatherMaxTemp, Double weatherMeanTemp, Double soilHeatFlux, Double lambda_)
    {
        Double TempAdjustment;
        Double SoilAvailableEnergy;
        TempAdjustment = weatherMeanTemp < 8.0d ? -0.5d * weatherMeanTemp + 4.0d : (double)(0);
        SoilAvailableEnergy = soilHeatFlux * lambda_ / 1000;
        return weatherMaxTemp + (11.2d * (1.0d - Math.exp(-0.07d * (SoilAvailableEnergy - 5.5d)))) + TempAdjustment;
    }
    public static Double SoilMinimumTemperature(Double weatherMaxTemp, Double weatherMeanTemp, Double weatherMinTemp, Double soilHeatFlux, Double lambda_, Double deepTemperature)
    {
        return Math.min(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature));
    }
    public static Double SoilMaximumTemperature(Double weatherMaxTemp, Double weatherMeanTemp, Double weatherMinTemp, Double soilHeatFlux, Double lambda_, Double deepTemperature)
    {
        return Math.max(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature));
    }
    public static Double UpdateTemperature(Double minSoilTemp, Double maxSoilTemp, Double Temperature)
    {
        Double meanTemp;
        meanTemp = (minSoilTemp + maxSoilTemp) / 2.0d;
        Temperature = (9.0d * Temperature + meanTemp) / 10.0d;
        return Temperature;
    }
}