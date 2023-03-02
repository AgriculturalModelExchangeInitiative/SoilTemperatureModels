using System;
using System.Collections.Generic;
using System.Linq;
public class SurfaceTemperatureParton
{
    
        public SurfaceTemperatureParton() { }
    
    public void  CalculateModel(SurfacePartonSoilSWATCState s, SurfacePartonSoilSWATCState s1, SurfacePartonSoilSWATCRate r, SurfacePartonSoilSWATCAuxiliary a, SurfacePartonSoilSWATCExogenous ex)
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
    //            * name: AboveGroundBiomass
    //                          ** description : Above ground biomass
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : 0
    //                          ** default : 3
    //                          ** unit : Kg ha-1
    //            * name: GlobalSolarRadiation
    //                          ** description : Daily global solar radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50
    //                          ** min : 0
    //                          ** default : 15
    //                          ** unit : Mj m-2 d-1
    //            * name: AirTemperatureMinimum
    //                          ** description : Minimum daily air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50
    //                          ** min : -60
    //                          ** default : 5
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
    //            * name: DayLength
    //                          ** description : Length of the day
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 24
    //                          ** min : 0
    //                          ** default : 10
    //                          ** unit : h
    //            * name: SurfaceTemperatureMinimum
    //                          ** description : Minimum surface soil temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 10
    //                          ** unit : Â°C
    //            * name: AirTemperatureMaximum
    //                          ** description : Maximum daily air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -40
    //                          ** default : 15
    //                          ** unit : Â°C
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
        double AboveGroundBiomass = s.AboveGroundBiomass;
        double GlobalSolarRadiation = ex.GlobalSolarRadiation;
        double AirTemperatureMinimum = ex.AirTemperatureMinimum;
        double SurfaceTemperatureMaximum = a.SurfaceTemperatureMaximum;
        double DayLength = ex.DayLength;
        double SurfaceTemperatureMinimum = a.SurfaceTemperatureMinimum;
        double AirTemperatureMaximum = ex.AirTemperatureMaximum;
        double SurfaceSoilTemperature;
        double _AGB;
        double _AirTMax;
        double _AirTmin;
        double _SolarRad;
        _AGB = AboveGroundBiomass / 10000;
        _AirTMax = AirTemperatureMaximum;
        _AirTmin = AirTemperatureMinimum;
        _SolarRad = GlobalSolarRadiation;
        if (_AGB > 0.150d)
        {
            SurfaceTemperatureMaximum = _AirTMax + ((24 * (1 - Math.Exp(-0.0380d * _SolarRad)) + (0.350d * _AirTMax)) * (Math.Exp(-4.80d * _AGB) - 0.130d));
            SurfaceTemperatureMinimum = _AirTmin + (6 * _AGB) - 1.820d;
        }
        else
        {
            SurfaceTemperatureMaximum = AirTemperatureMaximum;
            SurfaceTemperatureMinimum = AirTemperatureMinimum;
        }
        SurfaceSoilTemperature = 0.410d * SurfaceTemperatureMaximum + (0.590d * SurfaceTemperatureMinimum);
        if (DayLength != (double)(0))
        {
            SurfaceSoilTemperature = DayLength / 24 * _AirTMax + ((1 - (DayLength / 24)) * _AirTmin);
        }
        a.SurfaceTemperatureMaximum= SurfaceTemperatureMaximum;
        a.SurfaceTemperatureMinimum= SurfaceTemperatureMinimum;
        s.SurfaceSoilTemperature= SurfaceSoilTemperature;
    }
}