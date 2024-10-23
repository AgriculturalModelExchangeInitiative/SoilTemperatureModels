import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class RangeOfSoilTemperaturesDAYCENT
{
    public void Init(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a,  SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        Double[] SoilTemperatureRangeByLayers ;
        Double[] SoilTemperatureMinimum ;
        Double[] SoilTemperatureMaximum ;
        SoilTemperatureRangeByLayers= new Double[LayerThickness.length];
        Arrays.fill(SoilTemperatureRangeByLayers, 0.0d);
        SoilTemperatureMaximum= new Double[LayerThickness.length];
        Arrays.fill(SoilTemperatureMaximum, 0.0d);
        SoilTemperatureMinimum= new Double[LayerThickness.length];
        Arrays.fill(SoilTemperatureMinimum, 0.0d);
        s.setSoilTemperatureRangeByLayers(SoilTemperatureRangeByLayers);
        s.setSoilTemperatureMinimum(SoilTemperatureMinimum);
        s.setSoilTemperatureMaximum(SoilTemperatureMaximum);
    }
    private Double [] LayerThickness;
    public Double [] getLayerThickness()
    { return LayerThickness; }

    public void setLayerThickness(Double [] _LayerThickness)
    { this.LayerThickness= _LayerThickness; } 
    
    public RangeOfSoilTemperaturesDAYCENT() { }
    public void  Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a,  SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        //- Name: RangeOfSoilTemperaturesDAYCENT -Version: 001, -Time step: 1
        //- Description:
    //            * Title: RangeOfSoilTemperaturesDAYCENT model
    //            * Authors: simone.bregaglio
    //            * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
    //            * Institution: University Of Milan
    //            * ExtendedDescription: Strategy for the calculation of soil thermal conductivity.Reference: DAYCENT model written in C code
    //            * ShortDescription: Strategy for the calculation of soil thermal conductivity
        //- inputs:
    //            * name: LayerThickness
    //                          ** description : Soil layer thickness
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 3
    //                          ** min : 0.005
    //                          ** default : 0.05
    //                          ** unit : m
    //            * name: SurfaceTemperatureMinimum
    //                          ** description : Minimum surface soil temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 10
    //                          ** unit : degC
    //            * name: ThermalDiffusivity
    //                          ** description : Thermal diffusivity of soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0.0025
    //                          ** unit : mm s-1
    //            * name: SoilTemperatureByLayers
    //                          ** description : Soil temperature of each layer
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 15
    //                          ** unit : degC
    //            * name: SurfaceTemperatureMaximum
    //                          ** description : Maximum surface soil temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 25
    //                          ** unit : degC
    //            * name: SoilTemperatureRangeByLayers
    //                          ** description : Soil temperature range by layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 50
    //                          ** min : 0
    //                          ** default : 
    //                          ** unit : degC
    //            * name: SoilTemperatureMinimum
    //                          ** description : Minimum soil temperature by layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 
    //                          ** unit : degC
    //            * name: SoilTemperatureMaximum
    //                          ** description : Maximum soil temperature by layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 
    //                          ** unit : degC
        //- outputs:
    //            * name: SoilTemperatureRangeByLayers
    //                          ** description : Soil temperature range by layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 50
    //                          ** min : 0
    //                          ** unit : degC
    //            * name: SoilTemperatureMinimum
    //                          ** description : Minimum soil temperature by layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** unit : degC
    //            * name: SoilTemperatureMaximum
    //                          ** description : Maximum soil temperature by layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** unit : degC
        double SurfaceTemperatureMinimum = a.getSurfaceTemperatureMinimum();
        Double [] ThermalDiffusivity = a.getThermalDiffusivity();
        Double [] SoilTemperatureByLayers = a.getSoilTemperatureByLayers();
        double SurfaceTemperatureMaximum = a.getSurfaceTemperatureMaximum();
        Double [] SoilTemperatureRangeByLayers = s.getSoilTemperatureRangeByLayers();
        Double [] SoilTemperatureMinimum = s.getSoilTemperatureMinimum();
        Double [] SoilTemperatureMaximum = s.getSoilTemperatureMaximum();
        Integer i;
        double _DepthBottom;
        double _DepthCenterLayer;
        double SurfaceDiurnalRange;
        _DepthBottom = (double)(0);
        _DepthCenterLayer = (double)(0);
        SurfaceDiurnalRange = SurfaceTemperatureMaximum - SurfaceTemperatureMinimum;
        for (i=0 ; i!=SoilTemperatureByLayers.length ; i+=1)
        {
            if (i == 0)
            {
                _DepthCenterLayer = LayerThickness[0] * 100 / 2;
                SoilTemperatureRangeByLayers[0] = SurfaceDiurnalRange * Math.exp(-_DepthCenterLayer * Math.pow(0.00005d / ThermalDiffusivity[0], 0.5d));
                SoilTemperatureMaximum[0] = SoilTemperatureByLayers[0] + (SoilTemperatureRangeByLayers[0] / 2);
                SoilTemperatureMinimum[0] = SoilTemperatureByLayers[0] - (SoilTemperatureRangeByLayers[0] / 2);
            }
            else
            {
                _DepthBottom = _DepthBottom + (LayerThickness[(i - 1)] * 100);
                _DepthCenterLayer = _DepthBottom + (LayerThickness[i] * 100 / 2);
                SoilTemperatureRangeByLayers[i] = SurfaceDiurnalRange * Math.exp(-_DepthCenterLayer * Math.pow(0.00005d / ThermalDiffusivity[i], 0.5d));
                SoilTemperatureMaximum[i] = SoilTemperatureByLayers[i] + (SoilTemperatureRangeByLayers[i] / 2);
                SoilTemperatureMinimum[i] = SoilTemperatureByLayers[i] - (SoilTemperatureRangeByLayers[i] / 2);
            }
        }
        s.setSoilTemperatureRangeByLayers(SoilTemperatureRangeByLayers);
        s.setSoilTemperatureMinimum(SoilTemperatureMinimum);
        s.setSoilTemperatureMaximum(SoilTemperatureMaximum);
    }
}