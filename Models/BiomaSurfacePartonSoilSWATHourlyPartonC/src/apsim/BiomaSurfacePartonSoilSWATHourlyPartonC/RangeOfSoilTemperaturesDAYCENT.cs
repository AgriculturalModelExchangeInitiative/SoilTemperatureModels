using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: RangeOfSoilTemperaturesDAYCENT -Version: 001, -Time step: 1
///- Description:
///            * Title: RangeOfSoilTemperaturesDAYCENT model
///            * Authors: simone.bregaglio
///            * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
///            * Institution: University Of Milan
///            * ExtendedDescription: Strategy for the calculation of soil thermal conductivity.Reference: DAYCENT model written in C code
///            * ShortDescription: Strategy for the calculation of soil thermal conductivity
///- inputs:
///            * name: LayerThickness
///                          ** description : Soil layer thickness
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 3
///                          ** min : 0.005
///                          ** default : 0.05
///                          ** unit : m
///            * name: SurfaceTemperatureMinimum
///                          ** description : Minimum surface soil temperature
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 60
///                          ** min : -60
///                          ** default : 10
///                          ** unit : degC
///            * name: ThermalDiffusivity
///                          ** description : Thermal diffusivity of soil layer
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 1
///                          ** min : 0
///                          ** default : 0.0025
///                          ** unit : mm s-1
///            * name: SoilTemperatureByLayers
///                          ** description : Soil temperature of each layer
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 60
///                          ** min : -60
///                          ** default : 15
///                          ** unit : degC
///            * name: SurfaceTemperatureMaximum
///                          ** description : Maximum surface soil temperature
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLE
///                          ** max : 60
///                          ** min : -60
///                          ** default : 25
///                          ** unit : degC
///            * name: SoilTemperatureRangeByLayers
///                          ** description : Soil temperature range by layers
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 50
///                          ** min : 0
///                          ** default : 
///                          ** unit : degC
///            * name: SoilTemperatureMinimum
///                          ** description : Minimum soil temperature by layers
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 60
///                          ** min : -60
///                          ** default : 
///                          ** unit : degC
///            * name: SoilTemperatureMaximum
///                          ** description : Maximum soil temperature by layers
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 60
///                          ** min : -60
///                          ** default : 
///                          ** unit : degC
///- outputs:
///            * name: SoilTemperatureRangeByLayers
///                          ** description : Soil temperature range by layers
///                          ** datatype : DOUBLEARRAY
///                          ** variablecategory : state
///                          ** len : 
///                          ** max : 50
///                          ** min : 0
///                          ** unit : degC
///            * name: SoilTemperatureMinimum
///                          ** description : Minimum soil temperature by layers
///                          ** datatype : DOUBLEARRAY
///                          ** variablecategory : state
///                          ** len : 
///                          ** max : 60
///                          ** min : -60
///                          ** unit : degC
///            * name: SoilTemperatureMaximum
///                          ** description : Maximum soil temperature by layers
///                          ** datatype : DOUBLEARRAY
///                          ** variablecategory : state
///                          ** len : 
///                          ** max : 60
///                          ** min : -60
///                          ** unit : degC
/// </summary>
public class RangeOfSoilTemperaturesDAYCENT
{

    /// <summary>
    /// initialization of the RangeOfSoilTemperaturesDAYCENT component
    /// </summary>
    public void Init(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        double[] SoilTemperatureRangeByLayers ;
        double[] SoilTemperatureMinimum ;
        double[] SoilTemperatureMaximum ;
        SoilTemperatureRangeByLayers = new double[LayerThickness.Length];
        SoilTemperatureMaximum = new double[LayerThickness.Length];
        SoilTemperatureMinimum = new double[LayerThickness.Length];
        s.SoilTemperatureRangeByLayers= SoilTemperatureRangeByLayers;
        s.SoilTemperatureMinimum= SoilTemperatureMinimum;
        s.SoilTemperatureMaximum= SoilTemperatureMaximum;
    }

    private double[] _LayerThickness;
    /// <summary>
    /// Gets and sets the Soil layer thickness
    /// </summary>
    [Description("Soil layer thickness")] 
    [Units("m")] 
    //[Crop2ML(datatype="DOUBLEARRAY", min=0.005, max=3, default=0.05, parametercategory=constant, inputtype="parameter")] 
    public double[] LayerThickness
    {
        get { return this._LayerThickness; }
        set { this._LayerThickness= value; } 
    }

    
    /// <summary>
    /// Constructor of the RangeOfSoilTemperaturesDAYCENT component")
    /// </summary>  
    public RangeOfSoilTemperaturesDAYCENT() { }
    
    /// <summary>
    /// Algorithm of the RangeOfSoilTemperaturesDAYCENT component
    /// </summary>
    public void  CalculateModel(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        double SurfaceTemperatureMinimum = a.SurfaceTemperatureMinimum;
        double[] ThermalDiffusivity = a.ThermalDiffusivity;
        double[] SoilTemperatureByLayers = a.SoilTemperatureByLayers;
        double SurfaceTemperatureMaximum = a.SurfaceTemperatureMaximum;
        double[] SoilTemperatureRangeByLayers = s.SoilTemperatureRangeByLayers;
        double[] SoilTemperatureMinimum = s.SoilTemperatureMinimum;
        double[] SoilTemperatureMaximum = s.SoilTemperatureMaximum;
        int i;
        double _DepthBottom;
        double _DepthCenterLayer;
        double SurfaceDiurnalRange;
        _DepthBottom = (double)(0);
        _DepthCenterLayer = (double)(0);
        SurfaceDiurnalRange = SurfaceTemperatureMaximum - SurfaceTemperatureMinimum;
        for (i=0 ; i!=SoilTemperatureByLayers.Length ; i+=1)
        {
            if (i == 0)
            {
                _DepthCenterLayer = LayerThickness[0] * 100 / 2;
                SoilTemperatureRangeByLayers[0] = SurfaceDiurnalRange * Math.Exp(-_DepthCenterLayer * Math.Pow(0.00005 / ThermalDiffusivity[0], 0.5));
                SoilTemperatureMaximum[0] = SoilTemperatureByLayers[0] + (SoilTemperatureRangeByLayers[0] / 2);
                SoilTemperatureMinimum[0] = SoilTemperatureByLayers[0] - (SoilTemperatureRangeByLayers[0] / 2);
            }
            else
            {
                _DepthBottom = _DepthBottom + (LayerThickness[(i - 1)] * 100);
                _DepthCenterLayer = _DepthBottom + (LayerThickness[i] * 100 / 2);
                SoilTemperatureRangeByLayers[i] = SurfaceDiurnalRange * Math.Exp(-_DepthCenterLayer * Math.Pow(0.00005 / ThermalDiffusivity[i], 0.5));
                SoilTemperatureMaximum[i] = SoilTemperatureByLayers[i] + (SoilTemperatureRangeByLayers[i] / 2);
                SoilTemperatureMinimum[i] = SoilTemperatureByLayers[i] - (SoilTemperatureRangeByLayers[i] / 2);
            }
        }
        s.SoilTemperatureRangeByLayers= SoilTemperatureRangeByLayers;
        s.SoilTemperatureMinimum= SoilTemperatureMinimum;
        s.SoilTemperatureMaximum= SoilTemperatureMaximum;
    }
}