import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class SurfaceTemperatureSWAT
{
    
    public SurfaceTemperatureSWAT() { }
    public void  Calculate_surfacetemperatureswat(SurfaceSWATSoilSWATCState s, SurfaceSWATSoilSWATCState s1, SurfaceSWATSoilSWATCRate r, SurfaceSWATSoilSWATCAuxiliary a,  SurfaceSWATSoilSWATCExogenous ex)
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
        Double AirTemperatureMinimum = ex.getAirTemperatureMinimum();
        Double GlobalSolarRadiation = ex.getGlobalSolarRadiation();
        Double [] SoilTemperatureByLayers = s.getSoilTemperatureByLayers();
        Double AboveGroundBiomass = s.getAboveGroundBiomass();
        Double WaterEquivalentOfSnowPack = ex.getWaterEquivalentOfSnowPack();
        Double AirTemperatureMaximum = ex.getAirTemperatureMaximum();
        Double Albedo = ex.getAlbedo();
        Double SurfaceSoilTemperature;
        Double _Tavg;
        Double _Hterm;
        Double _Tbare;
        Double _WeightingCover;
        Double _WeightingSnow;
        Double _WeightingActual;
        _Tavg = (AirTemperatureMaximum + AirTemperatureMinimum) / 2;
        _Hterm = (GlobalSolarRadiation * (1 - Albedo) - 14) / 20;
        _Tbare = _Tavg + (_Hterm * (AirTemperatureMaximum - AirTemperatureMinimum) / 2);
        _WeightingCover = AboveGroundBiomass / (AboveGroundBiomass + Math.exp(7.563d - (0.0001297d * AboveGroundBiomass)));
        _WeightingSnow = WaterEquivalentOfSnowPack / (WaterEquivalentOfSnowPack + Math.exp(6.055d - (0.3002d * WaterEquivalentOfSnowPack)));
        _WeightingActual = Math.max(_WeightingCover, _WeightingSnow);
        SurfaceSoilTemperature = _WeightingActual * SoilTemperatureByLayers[0] + ((1 - _WeightingActual) * _Tbare);
        s.setSurfaceSoilTemperature(SurfaceSoilTemperature);
    }
}