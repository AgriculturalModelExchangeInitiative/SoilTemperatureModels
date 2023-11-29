import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class SurfaceTemperatureSWAT
{
    
    public SurfaceTemperatureSWAT() { }
    public void  Calculate_Model(SurfaceSWATSoilSWATCState s, SurfaceSWATSoilSWATCState s1, SurfaceSWATSoilSWATCRate r, SurfaceSWATSoilSWATCAuxiliary a,  SurfaceSWATSoilSWATCExogenous ex)
    {
        //- Name: SurfaceTemperatureSWAT -Version: 001, -Time step: 1
        //- Description:
    //            * Title: SurfaceTemperatureSWAT model
    //            * Authors: simone.bregaglio
    //            * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
    //            * Institution: University Of Milan
    //            * ExtendedDescription: Strategy for the calculation of surface soil temperature with SWAT method. Reference: Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf
    //            * ShortDescription: Strategy for the calculation of surface soil temperature with SWAT method
        //- inputs:
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
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 15
    //                          ** unit : 
    //            * name: AirTemperatureMaximum
    //                          ** description : Maximum daily air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -40
    //                          ** default : 15
    //                          ** unit : 
    //            * name: AirTemperatureMinimum
    //                          ** description : Minimum daily air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50
    //                          ** min : -60
    //                          ** default : 5
    //                          ** unit : 
    //            * name: Albedo
    //                          ** description : Albedo of soil
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0.2
    //                          ** unit : unitless
    //            * name: AboveGroundBiomass
    //                          ** description : Above ground biomass
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
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
        //- outputs:
    //            * name: SurfaceSoilTemperature
    //                          ** description : Average surface soil temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : auxiliary
    //                          ** max : 60
    //                          ** min : -60
    //                          ** unit : degC
        Double GlobalSolarRadiation = ex.getGlobalSolarRadiation();
        Double [] SoilTemperatureByLayers = a.getSoilTemperatureByLayers();
        Double AirTemperatureMaximum = ex.getAirTemperatureMaximum();
        Double AirTemperatureMinimum = ex.getAirTemperatureMinimum();
        Double Albedo = ex.getAlbedo();
        Double AboveGroundBiomass = a.getAboveGroundBiomass();
        Double WaterEquivalentOfSnowPack = ex.getWaterEquivalentOfSnowPack();
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
        a.setSurfaceSoilTemperature(SurfaceSoilTemperature);
    }
}