using System;
using System.Collections.Generic;
using System.Linq;
public class SoilTemperatureSWAT
{
    private double _LagCoefficient;
    public double LagCoefficient
        {
            get { return this._LagCoefficient; }
            set { this._LagCoefficient= value; } 
        }
        public SoilTemperatureSWAT() { }
    
    public void  CalculateModel(SurfacePartonSoilSWATCState s, SurfacePartonSoilSWATCState s1, SurfacePartonSoilSWATCRate r, SurfacePartonSoilSWATCAuxiliary a, SurfacePartonSoilSWATCExogenous ex)
    {
        //- Name: SoilTemperatureSWAT -Version: 001, -Time step: 1
        //- Description:
    //            * Title: SoilTemperatureSWAT model
    //            * Authors: simone.bregaglio@unimi.it
    //            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    //            * Institution: University Of Milan
    //            * ExtendedDescription: Strategy for the calculation of soil temperature with SWAT method. Reference: Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf
    //            * ShortDescription: None
        //- inputs:
    //            * name: LayerThickness
    //                          ** description : Soil layer thickness
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 3
    //                          ** min : 0.005
    //                          ** default : 0.05
    //                          ** unit : m
    //            * name: VolumetricWaterContent
    //                          ** description : Volumetric soil water content
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 0.8
    //                          ** min : 0
    //                          ** default : 0.25
    //                          ** unit : m3 m-3
    //            * name: SurfaceSoilTemperature
    //                          ** description : Average surface soil temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 25
    //                          ** unit : Â°C
    //            * name: SoilProfileDepth
    //                          ** description : Soil profile depth
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 50
    //                          ** min : 0
    //                          ** default : 3
    //                          ** unit : m
    //            * name: AirTemperatureAnnualAverage
    //                          ** description : Annual average air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50
    //                          ** min : -40
    //                          ** default : 15
    //                          ** unit : Â°C
    //            * name: LagCoefficient
    //                          ** description : Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0.8
    //                          ** unit : dimensionless
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
    //            * name: BulkDensity
    //                          ** description : Bulk density
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 1.8
    //                          ** min : 0.9
    //                          ** default : 1.3
    //                          ** unit : t m-3
        //- outputs:
    //            * name: SoilTemperatureByLayers
    //                          ** description : Soil temperature of each layer
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** unit : Â°C
        double[] LayerThickness = s.LayerThickness;
        double[] VolumetricWaterContent = s.VolumetricWaterContent;
        double SurfaceSoilTemperature = s.SurfaceSoilTemperature;
        double SoilProfileDepth = s.SoilProfileDepth;
        double AirTemperatureAnnualAverage = ex.AirTemperatureAnnualAverage;
        double[] SoilTemperatureByLayers = s.SoilTemperatureByLayers;
        double[] BulkDensity = s.BulkDensity;
        int i;
        double _SoilProfileDepthmm;
        double _TotalWaterContentmm;
        double _MaximumDumpingDepth;
        double _DumpingDepth;
        double _ScalingFactor;
        double _DepthBottom;
        double _RatioCenter;
        double _DepthFactor;
        double _DepthCenterLayer;
        _SoilProfileDepthmm = SoilProfileDepth * 1000;
        _TotalWaterContentmm = (double)(0);
        for (i=0 ; i!=LayerThickness.Length ; i+=1)
        {
            _TotalWaterContentmm = _TotalWaterContentmm + (VolumetricWaterContent[i] * LayerThickness[i]);
        }
        _TotalWaterContentmm = _TotalWaterContentmm * 1000;
        _MaximumDumpingDepth = (double)(0);
        _DumpingDepth = (double)(0);
        _ScalingFactor = (double)(0);
        _DepthBottom = (double)(0);
        _RatioCenter = (double)(0);
        _DepthFactor = (double)(0);
        _DepthCenterLayer = LayerThickness[0] * 1000 / 2;
        _MaximumDumpingDepth = 1000 + (2500 * BulkDensity[0] / (BulkDensity[0] + (686 * Math.Exp(-5.630d * BulkDensity[0]))));
        _ScalingFactor = _TotalWaterContentmm / ((0.3560d - (0.1440d * BulkDensity[0])) * _SoilProfileDepthmm);
        _DumpingDepth = _MaximumDumpingDepth * Math.Exp(Math.Log(500 / _MaximumDumpingDepth) * Math.Pow((1 - _ScalingFactor) / (1 + _ScalingFactor), 2));
        _RatioCenter = _DepthCenterLayer / _DumpingDepth;
        _DepthFactor = _RatioCenter / (_RatioCenter + Math.Exp(-0.8670d - (2.0780d * _RatioCenter)));
        SoilTemperatureByLayers[0] = LagCoefficient * SoilTemperatureByLayers[0] + ((1 - LagCoefficient) * (_DepthFactor * (AirTemperatureAnnualAverage - SurfaceSoilTemperature) + SurfaceSoilTemperature));
        for (i=1 ; i!=LayerThickness.Length ; i+=1)
        {
            _DepthBottom = _DepthBottom + (LayerThickness[(i - 1)] * 1000);
            _DepthCenterLayer = _DepthBottom + (LayerThickness[i] * 1000 / 2);
            _MaximumDumpingDepth = 1000 + (2500 * BulkDensity[i] / (BulkDensity[i] + (686 * Math.Exp(-5.630d * BulkDensity[i]))));
            _ScalingFactor = _TotalWaterContentmm / ((0.3560d - (0.1440d * BulkDensity[i])) * _SoilProfileDepthmm);
            _DumpingDepth = _MaximumDumpingDepth * Math.Exp(Math.Log(500 / _MaximumDumpingDepth) * Math.Pow((1 - _ScalingFactor) / (1 + _ScalingFactor), 2));
            _RatioCenter = _DepthCenterLayer / _DumpingDepth;
            _DepthFactor = _RatioCenter / (_RatioCenter + Math.Exp(-0.8670d - (2.0780d * _RatioCenter)));
            SoilTemperatureByLayers[i] = LagCoefficient * SoilTemperatureByLayers[i] + ((1 - LagCoefficient) * (_DepthFactor * (AirTemperatureAnnualAverage - SurfaceSoilTemperature) + SurfaceSoilTemperature));
        }
        s.SoilTemperatureByLayers= SoilTemperatureByLayers;
    }
}