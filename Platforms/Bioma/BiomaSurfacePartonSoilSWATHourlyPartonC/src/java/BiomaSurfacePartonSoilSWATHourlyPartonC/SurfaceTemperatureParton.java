import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class SurfaceTemperatureParton
{
    
    public SurfaceTemperatureParton() { }
    public void  Calculate_surfacetemperatureparton(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a,  SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        //- Name: SurfaceTemperatureParton -Version: 001, -Time step: 1
        //- Description:
    //            * Title: SurfaceTemperatureParton model
    //            * Authors: simone.bregaglio@unimi.it
    //            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    //            * Institution: University Of Milan
    //            * ExtendedDescription: Strategy for the calculation of soil surface temperature with Parton's method. Reference: Parton, W. J. 1984. Predicting soil temperatures in a shortgrass steppe. Soil Science 138:93-101.
    //            * ShortDescription: None
        //- inputs:
    //            * name: DayLength
    //                          ** description : Length of the day
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 24
    //                          ** min : 0
    //                          ** default : 10
    //                          ** unit : h
    //            * name: AirTemperatureMinimum
    //                          ** description : Minimum daily air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50
    //                          ** min : -60
    //                          ** default : 5
    //                          ** unit : Â°C
    //            * name: GlobalSolarRadiation
    //                          ** description : Daily global solar radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50
    //                          ** min : 0
    //                          ** default : 15
    //                          ** unit : Mj m-2 d-1
    //            * name: AirTemperatureMaximum
    //                          ** description : Maximum daily air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -40
    //                          ** default : 15
    //                          ** unit : Â°C
    //            * name: SurfaceTemperatureMaximum
    //                          ** description : Maximum surface soil temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 25
    //                          ** unit : Â°C
    //            * name: SurfaceTemperatureMinimum
    //                          ** description : Minimum surface soil temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 10
    //                          ** unit : Â°C
    //            * name: AboveGroundBiomass
    //                          ** description : Above ground biomass
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : 0
    //                          ** default : 3
    //                          ** unit : Kg ha-1
        //- outputs:
    //            * name: SurfaceSoilTemperature
    //                          ** description : Average surface soil temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 60
    //                          ** min : -60
    //                          ** unit : Â°C
    //            * name: SurfaceTemperatureMaximum
    //                          ** description : Maximum surface soil temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : auxiliary
    //                          ** max : 60
    //                          ** min : -60
    //                          ** unit : Â°C
    //            * name: SurfaceTemperatureMinimum
    //                          ** description : Minimum surface soil temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : auxiliary
    //                          ** max : 60
    //                          ** min : -60
    //                          ** unit : Â°C
        Double DayLength = ex.getDayLength();
        Double AirTemperatureMinimum = ex.getAirTemperatureMinimum();
        Double GlobalSolarRadiation = ex.getGlobalSolarRadiation();
        Double AirTemperatureMaximum = ex.getAirTemperatureMaximum();
        Double SurfaceTemperatureMaximum = a.getSurfaceTemperatureMaximum();
        Double SurfaceTemperatureMinimum = a.getSurfaceTemperatureMinimum();
        Double AboveGroundBiomass = s.getAboveGroundBiomass();
        Double SurfaceSoilTemperature;
        Double _AGB;
        Double _AirTMax;
        Double _AirTmin;
        Double _SolarRad;
        _AGB = AboveGroundBiomass / 10000;
        _AirTMax = AirTemperatureMaximum;
        _AirTmin = AirTemperatureMinimum;
        _SolarRad = GlobalSolarRadiation;
        if (_AGB > 0.15d)
        {
            SurfaceTemperatureMaximum = _AirTMax + ((24 * (1 - Math.exp(-0.038d * _SolarRad)) + (0.35d * _AirTMax)) * (Math.exp(-4.8d * _AGB) - 0.13d));
            SurfaceTemperatureMinimum = _AirTmin + (6 * _AGB) - 1.82d;
        }
        else
        {
            SurfaceTemperatureMaximum = AirTemperatureMaximum;
            SurfaceTemperatureMinimum = AirTemperatureMinimum;
        }
        SurfaceSoilTemperature = 0.41d * SurfaceTemperatureMaximum + (0.59d * SurfaceTemperatureMinimum);
        if (DayLength != (double)(0))
        {
            SurfaceSoilTemperature = DayLength / 24 * _AirTMax + ((1 - (DayLength / 24)) * _AirTmin);
        }
        a.setSurfaceTemperatureMaximum(SurfaceTemperatureMaximum);
        a.setSurfaceTemperatureMinimum(SurfaceTemperatureMinimum);
        s.setSurfaceSoilTemperature(SurfaceSoilTemperature);
    }
}