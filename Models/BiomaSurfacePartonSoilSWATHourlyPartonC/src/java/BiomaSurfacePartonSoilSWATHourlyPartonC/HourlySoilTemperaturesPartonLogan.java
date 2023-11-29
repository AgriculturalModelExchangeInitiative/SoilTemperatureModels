import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class HourlySoilTemperaturesPartonLogan
{
    
    public HourlySoilTemperaturesPartonLogan() { }
    public void  Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a,  SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        //- Name: HourlySoilTemperaturesPartonLogan -Version: 001, -Time step: 1
        //- Description:
    //            * Title: HourlySoilTemperaturesPartonLogan model
    //            * Authors: simone.bregaglio
    //            * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
    //            * Institution: University Of Milan
    //            * ExtendedDescription: Strategy for the calculation of hourly soil temperature. Reference: Parton, W.J.  and  Logan, J.A.,  1981. A model for diurnal variation  in soil  and  air temperature. Agric. Meteorol., 23: 205-216.
    //            * ShortDescription: Strategy for the calculation of hourly soil temperature
        //- inputs:
    //            * name: SoilTemperatureByLayersHourly
    //                          ** description : Hourly soil temperature by layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 50
    //                          ** min : -50
    //                          ** default : 15
    //                          ** unit : degC
    //            * name: HourOfSunrise
    //                          ** description : Hour of sunrise
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 24
    //                          ** min : 0
    //                          ** default : 6
    //                          ** unit : h
    //            * name: HourOfSunset
    //                          ** description : Hour of sunset
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 24
    //                          ** min : 0
    //                          ** default : 17
    //                          ** unit : h
    //            * name: DayLength
    //                          ** description : Length of the day
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 24
    //                          ** min : 0
    //                          ** default : 10
    //                          ** unit : h
    //            * name: SoilTemperatureMinimum
    //                          ** description : Minimum soil temperature by layers
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 15
    //                          ** unit : degC
    //            * name: SoilTemperatureMaximum
    //                          ** description : Maximum soil temperature by layers
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 15
    //                          ** unit : degC
        //- outputs:
    //            * name: SoilTemperatureByLayersHourly
    //                          ** description : Hourly soil temperature by layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 50
    //                          ** min : -50
    //                          ** unit : degC
        Double [] SoilTemperatureByLayersHourly = s.getSoilTemperatureByLayersHourly();
        Double HourOfSunrise = ex.getHourOfSunrise();
        Double HourOfSunset = ex.getHourOfSunset();
        Double DayLength = ex.getDayLength();
        Double [] SoilTemperatureMinimum = a.getSoilTemperatureMinimum();
        Double [] SoilTemperatureMaximum = a.getSoilTemperatureMaximum();
        Integer h;
        Integer i;
        Double TemperatureAtSunset;
        for (i=0 ; i!=SoilTemperatureMinimum.length ; i+=1)
        {
            for (h=0 ; h!=24 ; h+=1)
            {
                if (h >= (int)(HourOfSunrise) && h <= (int)(HourOfSunset))
                {
                    SoilTemperatureByLayersHourly[i * 24 + h] = SoilTemperatureMinimum[i] + ((SoilTemperatureMaximum[i] - SoilTemperatureMinimum[i]) * Math.sin(Math.PI * (h - 12 + (DayLength / 2)) / (DayLength + (2 * 1.8d))));
                }
            }
            TemperatureAtSunset = SoilTemperatureByLayersHourly[i + (int)(HourOfSunset)];
            for (h=0 ; h!=24 ; h+=1)
            {
                if (h > (int)(HourOfSunset))
                {
                    SoilTemperatureByLayersHourly[i + h] = (SoilTemperatureMinimum[i] - (TemperatureAtSunset * Math.exp(-(24 - DayLength) / 2.2d)) + ((TemperatureAtSunset - SoilTemperatureMinimum[i]) * Math.exp(-(h - HourOfSunset) / 2.2d))) / (1 - Math.exp(-(24 - DayLength) / 2.2d));
                }
                else if ( h <= (int)(HourOfSunrise))
                {
                    SoilTemperatureByLayersHourly[i + h] = (SoilTemperatureMinimum[i] - (TemperatureAtSunset * Math.exp(-(24 - DayLength) / 2.2d)) + ((TemperatureAtSunset - SoilTemperatureMinimum[i]) * Math.exp(-(h + 24 - HourOfSunset) / 2.2d))) / (1 - Math.exp(-(24 - DayLength) / 2.2d));
                }
            }
        }
        s.setSoilTemperatureByLayersHourly(SoilTemperatureByLayersHourly);
    }
}