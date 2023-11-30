import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class SoilTemperatureSWAT
{
    public void Init(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a,  SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        Double [] VolumetricWaterContent = ex.getVolumetricWaterContent();
        Double[] SoilTemperatureByLayers ;
        Integer i;
        SoilTemperatureByLayers= new Double[LayerThickness.length];
        Arrays.fill(SoilTemperatureByLayers, 0.0d);
        for (i=0 ; i!=LayerThickness.length ; i+=1)
        {
            SoilTemperatureByLayers[i] = (double)(15);
        }
        s.setSoilTemperatureByLayers(SoilTemperatureByLayers);
    }
    private Double [] LayerThickness;
    public Double [] getLayerThickness()
    { return LayerThickness; }

    public void setLayerThickness(Double [] _LayerThickness)
    { this.LayerThickness= _LayerThickness; } 
    
    private double LagCoefficient;
    public double getLagCoefficient()
    { return LagCoefficient; }

    public void setLagCoefficient(double _LagCoefficient)
    { this.LagCoefficient= _LagCoefficient; } 
    
    private double AirTemperatureAnnualAverage;
    public double getAirTemperatureAnnualAverage()
    { return AirTemperatureAnnualAverage; }

    public void setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage)
    { this.AirTemperatureAnnualAverage= _AirTemperatureAnnualAverage; } 
    
    private Double [] BulkDensity;
    public Double [] getBulkDensity()
    { return BulkDensity; }

    public void setBulkDensity(Double [] _BulkDensity)
    { this.BulkDensity= _BulkDensity; } 
    
    private double SoilProfileDepth;
    public double getSoilProfileDepth()
    { return SoilProfileDepth; }

    public void setSoilProfileDepth(double _SoilProfileDepth)
    { this.SoilProfileDepth= _SoilProfileDepth; } 
    
    public SoilTemperatureSWAT() { }
    public void  Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a,  SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        //- Name: SoilTemperatureSWAT -Version: 001, -Time step: 1
        //- Description:
    //            * Title: SoilTemperatureSWAT model
    //            * Authors: simone.bregaglio
    //            * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
    //            * Institution: University Of Milan
    //            * ExtendedDescription: Strategy for the calculation of soil temperature with SWAT method. Reference: Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf
    //            * ShortDescription: Strategy for the calculation of soil temperature with SWAT method
        //- inputs:
    //            * name: VolumetricWaterContent
    //                          ** description : Volumetric soil water content
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 0.8
    //                          ** min : 0
    //                          ** default : 0.25
    //                          ** unit : m3 m-3
    //            * name: SurfaceSoilTemperature
    //                          ** description : Average surface soil temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 25
    //                          ** unit : degC
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
    //                          ** unit : degC
    //            * name: AirTemperatureAnnualAverage
    //                          ** description : Annual average air temperature
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 50
    //                          ** min : -40
    //                          ** default : 15
    //                          ** unit : degC
    //            * name: BulkDensity
    //                          ** description : Bulk density
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 1.8
    //                          ** min : 0.9
    //                          ** default : 1.3
    //                          ** unit : t m-3
    //            * name: SoilProfileDepth
    //                          ** description : Soil profile depth
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 50
    //                          ** min : 0
    //                          ** default : 3
    //                          ** unit : m
        //- outputs:
    //            * name: SoilTemperatureByLayers
    //                          ** description : Soil temperature of each layer
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** unit : degC
        Double [] VolumetricWaterContent = ex.getVolumetricWaterContent();
        double SurfaceSoilTemperature = a.getSurfaceSoilTemperature();
        Double [] SoilTemperatureByLayers = s.getSoilTemperatureByLayers();
        Integer i;
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
        for (i=0 ; i!=LayerThickness.length ; i+=1)
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
        _MaximumDumpingDepth = 1000 + (2500 * BulkDensity[0] / (BulkDensity[0] + (686 * Math.exp(-5.63d * BulkDensity[0]))));
        _ScalingFactor = _TotalWaterContentmm / ((0.356d - (0.144d * BulkDensity[0])) * _SoilProfileDepthmm);
        _DumpingDepth = _MaximumDumpingDepth * Math.exp(Math.log(500 / _MaximumDumpingDepth) * Math.pow((1 - _ScalingFactor) / (1 + _ScalingFactor), 2));
        _RatioCenter = _DepthCenterLayer / _DumpingDepth;
        _DepthFactor = _RatioCenter / (_RatioCenter + Math.exp(-0.867d - (2.078d * _RatioCenter)));
        SoilTemperatureByLayers[0] = LagCoefficient * SoilTemperatureByLayers[0] + ((1 - LagCoefficient) * (_DepthFactor * (AirTemperatureAnnualAverage - SurfaceSoilTemperature) + SurfaceSoilTemperature));
        for (i=1 ; i!=LayerThickness.length ; i+=1)
        {
            _DepthBottom = _DepthBottom + (LayerThickness[(i - 1)] * 1000);
            _DepthCenterLayer = _DepthBottom + (LayerThickness[i] * 1000 / 2);
            _MaximumDumpingDepth = 1000 + (2500 * BulkDensity[i] / (BulkDensity[i] + (686 * Math.exp(-5.63d * BulkDensity[i]))));
            _ScalingFactor = _TotalWaterContentmm / ((0.356d - (0.144d * BulkDensity[i])) * _SoilProfileDepthmm);
            _DumpingDepth = _MaximumDumpingDepth * Math.exp(Math.log(500 / _MaximumDumpingDepth) * Math.pow((1 - _ScalingFactor) / (1 + _ScalingFactor), 2));
            _RatioCenter = _DepthCenterLayer / _DumpingDepth;
            _DepthFactor = _RatioCenter / (_RatioCenter + Math.exp(-0.867d - (2.078d * _RatioCenter)));
            SoilTemperatureByLayers[i] = LagCoefficient * SoilTemperatureByLayers[i] + ((1 - LagCoefficient) * (_DepthFactor * (AirTemperatureAnnualAverage - SurfaceSoilTemperature) + SurfaceSoilTemperature));
        }
        s.setSoilTemperatureByLayers(SoilTemperatureByLayers);
    }
}