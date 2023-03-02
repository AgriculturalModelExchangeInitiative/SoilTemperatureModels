using System;
using System.Collections.Generic;
using System.Linq;
public class SurfaceTemperatureSWAT
{
    
        public SurfaceTemperatureSWAT() { }
    
    public void  CalculateModel(SurfaceSWATSoilSWATCState s, SurfaceSWATSoilSWATCState s1, SurfaceSWATSoilSWATCRate r, SurfaceSWATSoilSWATCAuxiliary a, SurfaceSWATSoilSWATCExogenous ex)
    {
        //- Name: SurfaceTemperatureSWAT -Version: 001, -Time step: 1
        //- Description:
    //            * Title: SurfaceTemperatureSWAT model
    //            * Authors: simone.bregaglio@unimi.it
    //            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    //            * Institution: University Of Milan
    //            * ExtendedDescription: Strategy for the calculation of surface soil temperature with SWAT method. Reference: Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf
    //            * ShortDescription: None
        //- inputs:
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
    //            * name: SoilTemperatureByLayers
    //                          ** description : Soil temperature of each layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 15
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
    //            * name: WaterEquivalentOfSnowPack
    //                          ** description : Water equivalent of snow pack
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 1000
    //                          ** min : 0
    //                          ** default : 10
    //                          ** unit : mm
    //            * name: AirTemperatureMaximum
    //                          ** description : Maximum daily air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -40
    //                          ** default : 15
    //                          ** unit : Â°C
    //            * name: Albedo
    //                          ** description : Albedo of soil
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0.2
    //                          ** unit : unitless
        //- outputs:
    //            * name: SurfaceSoilTemperature
    //                          ** description : Average surface soil temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 60
    //                          ** min : -60
    //                          ** unit : Â°C
        double AirTemperatureMinimum = ex.AirTemperatureMinimum;
        double GlobalSolarRadiation = ex.GlobalSolarRadiation;
        double[] SoilTemperatureByLayers = s.SoilTemperatureByLayers;
        double AboveGroundBiomass = s.AboveGroundBiomass;
        double WaterEquivalentOfSnowPack = ex.WaterEquivalentOfSnowPack;
        double AirTemperatureMaximum = ex.AirTemperatureMaximum;
        double Albedo = ex.Albedo;
        double SurfaceSoilTemperature;
        double _Tavg;
        double _Hterm;
        double _Tbare;
        double _WeightingCover;
        double _WeightingSnow;
        double _WeightingActual;
        _Tavg = (AirTemperatureMaximum + AirTemperatureMinimum) / 2;
        _Hterm = (GlobalSolarRadiation * (1 - Albedo) - 14) / 20;
        _Tbare = _Tavg + (_Hterm * (AirTemperatureMaximum - AirTemperatureMinimum) / 2);
        _WeightingCover = AboveGroundBiomass / (AboveGroundBiomass + Math.Exp(7.5630d - (0.00012970d * AboveGroundBiomass)));
        _WeightingSnow = WaterEquivalentOfSnowPack / (WaterEquivalentOfSnowPack + Math.Exp(6.0550d - (0.30020d * WaterEquivalentOfSnowPack)));
        _WeightingActual = Math.Max(_WeightingCover, _WeightingSnow);
        SurfaceSoilTemperature = _WeightingActual * SoilTemperatureByLayers[0] + ((1 - _WeightingActual) * _Tbare);
        s.SurfaceSoilTemperature= SurfaceSoilTemperature;
    }
}