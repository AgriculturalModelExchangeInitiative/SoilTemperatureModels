using System;
using System.Collections.Generic;
using System.Linq;
public class HourlySoilTemperaturesPartonLogan
{
    
        public HourlySoilTemperaturesPartonLogan() { }
    
    public void  CalculateModel(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        //- Name: HourlySoilTemperaturesPartonLogan -Version: 001, -Time step: 1
        //- Description:
    //            * Title: HourlySoilTemperaturesPartonLogan model
    //            * Authors: simone.bregaglio@unimi.it
    //            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    //            * Institution: University Of Milan
    //            * ExtendedDescription: Strategy for the calculation of hourly soil temperature. Reference: Parton, W.J.  and  Logan, J.A.,  1981. A model for diurnal variation  in soil  and  air temperature. Agric. Meteorol., 23: 205-216.
    //            * ShortDescription: None
        //- inputs:
    //            * name: SoilTemperatureMinimum
    //                          ** description : Minimum soil temperature by layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 15
    //                          ** unit : Â°C
    //            * name: DayLength
    //                          ** description : Length of the day
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 24
    //                          ** min : 0
    //                          ** default : 10
    //                          ** unit : h
    //            * name: SoilTemperatureMaximum
    //                          ** description : Maximum soil temperature by layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 15
    //                          ** unit : Â°C
    //            * name: HourOfSunset
    //                          ** description : Hour of sunset
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 24
    //                          ** min : 0
    //                          ** default : 17
    //                          ** unit : h
    //            * name: SoilTemperatureByLayersHourly
    //                          ** description : Hourly soil temperature by layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 50
    //                          ** min : -50
    //                          ** default : 15
    //                          ** unit : Â°C
    //            * name: HourOfSunrise
    //                          ** description : Hour of sunrise
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 24
    //                          ** min : 0
    //                          ** default : 6
    //                          ** unit : h
        //- outputs:
    //            * name: SoilTemperatureByLayersHourly
    //                          ** description : Hourly soil temperature by layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 50
    //                          ** min : -50
    //                          ** unit : Â°C
        double[] SoilTemperatureMinimum = s.SoilTemperatureMinimum;
        double DayLength = ex.DayLength;
        double[] SoilTemperatureMaximum = s.SoilTemperatureMaximum;
        double HourOfSunset = ex.HourOfSunset;
        double[] SoilTemperatureByLayersHourly = s.SoilTemperatureByLayersHourly;
        double HourOfSunrise = ex.HourOfSunrise;
        int h;
        int i;
        double TemperatureAtSunset;
        for (i=0 ; i!=SoilTemperatureMinimum.Length ; i+=1)
        {
            for (h=0 ; h!=24 ; h+=1)
            {
                if (h >= (int)(HourOfSunrise) && h <= (int)(HourOfSunset))
                {
                    SoilTemperatureByLayersHourly[i * 24 + h] = SoilTemperatureMinimum[i] + ((SoilTemperatureMaximum[i] - SoilTemperatureMinimum[i]) * Math.Sin(Math.PI * (h - 12 + (DayLength / 2)) / (DayLength + (2 * 1.80d))));
                }
            }
            TemperatureAtSunset = SoilTemperatureByLayersHourly[i + (int)(HourOfSunset)];
            for (h=0 ; h!=24 ; h+=1)
            {
                if (h > (int)(HourOfSunset))
                {
                    SoilTemperatureByLayersHourly[i + h] = (SoilTemperatureMinimum[i] - (TemperatureAtSunset * Math.Exp(-(24 - DayLength) / 2.20d)) + ((TemperatureAtSunset - SoilTemperatureMinimum[i]) * Math.Exp(-(h - HourOfSunset) / 2.20d))) / (1 - Math.Exp(-(24 - DayLength) / 2.20d));
                }
                else if ( h <= (int)(HourOfSunrise))
                {
                    SoilTemperatureByLayersHourly[i + h] = (SoilTemperatureMinimum[i] - (TemperatureAtSunset * Math.Exp(-(24 - DayLength) / 2.20d)) + ((TemperatureAtSunset - SoilTemperatureMinimum[i]) * Math.Exp(-(h + 24 - HourOfSunset) / 2.20d))) / (1 - Math.Exp(-(24 - DayLength) / 2.20d));
                }
            }
        }
        s.SoilTemperatureByLayersHourly= SoilTemperatureByLayersHourly;
    }
}