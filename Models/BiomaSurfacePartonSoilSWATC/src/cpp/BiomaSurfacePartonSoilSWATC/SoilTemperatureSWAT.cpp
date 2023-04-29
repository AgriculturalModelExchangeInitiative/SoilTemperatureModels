#ifndef _SOILTEMPERATURESWAT_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include <numeric>
#include <algorithm>
#include <array>
#include <map>
#include <tuple>
#include "SoilTemperatureSWAT.h"
using namespace std;

SoilTemperatureSWAT::SoilTemperatureSWAT() { }
double SoilTemperatureSWAT::getLagCoefficient() {return this-> LagCoefficient; }
void SoilTemperatureSWAT::setLagCoefficient(double _LagCoefficient) { this->LagCoefficient = _LagCoefficient; }
void SoilTemperatureSWAT::Calculate_Model(SurfacePartonSoilSWATCState& s, SurfacePartonSoilSWATCState& s1, SurfacePartonSoilSWATCRate& r, SurfacePartonSoilSWATCAuxiliary& a, SurfacePartonSoilSWATCExogenous& ex)
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
    //            * name: AirTemperatureAnnualAverage
    //                          ** description : Annual average air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50
    //                          ** min : -40
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
    //            * name: SoilProfileDepth
    //                          ** description : Soil profile depth
    //                          ** inputtype : variable
    //                          ** variablecategory : state
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
    //                          ** unit : Â°C
    vector<double>  VolumetricWaterContent = s.getVolumetricWaterContent();
    double SurfaceSoilTemperature = s.getSurfaceSoilTemperature();
    vector<double>  LayerThickness = s.getLayerThickness();
    vector<double>  SoilTemperatureByLayers = s.getSoilTemperatureByLayers();
    double AirTemperatureAnnualAverage = ex.getAirTemperatureAnnualAverage();
    vector<double>  BulkDensity = s.getBulkDensity();
    double SoilProfileDepth = s.getSoilProfileDepth();
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
    _TotalWaterContentmm = float(0);
    for (i=0 ; i!=LayerThickness.size() ; i+=1)
    {
        _TotalWaterContentmm = _TotalWaterContentmm + (VolumetricWaterContent[i] * LayerThickness[i]);
    }
    _TotalWaterContentmm = _TotalWaterContentmm * 1000;
    _MaximumDumpingDepth = float(0);
    _DumpingDepth = float(0);
    _ScalingFactor = float(0);
    _DepthBottom = float(0);
    _RatioCenter = float(0);
    _DepthFactor = float(0);
    _DepthCenterLayer = LayerThickness[0] * 1000 / 2;
    _MaximumDumpingDepth = 1000 + (2500 * BulkDensity[0] / (BulkDensity[0] + (686 * exp(-5.63 * BulkDensity[0]))));
    _ScalingFactor = _TotalWaterContentmm / ((0.356 - (0.144 * BulkDensity[0])) * _SoilProfileDepthmm);
    _DumpingDepth = _MaximumDumpingDepth * exp(log(500 / _MaximumDumpingDepth) * pow((1 - _ScalingFactor) / (1 + _ScalingFactor), 2));
    _RatioCenter = _DepthCenterLayer / _DumpingDepth;
    _DepthFactor = _RatioCenter / (_RatioCenter + exp(-0.867 - (2.078 * _RatioCenter)));
    SoilTemperatureByLayers[0] = LagCoefficient * SoilTemperatureByLayers[0] + ((1 - LagCoefficient) * (_DepthFactor * (AirTemperatureAnnualAverage - SurfaceSoilTemperature) + SurfaceSoilTemperature));
    for (i=1 ; i!=LayerThickness.size() ; i+=1)
    {
        _DepthBottom = _DepthBottom + (LayerThickness[(i - 1)] * 1000);
        _DepthCenterLayer = _DepthBottom + (LayerThickness[i] * 1000 / 2);
        _MaximumDumpingDepth = 1000 + (2500 * BulkDensity[i] / (BulkDensity[i] + (686 * exp(-5.63 * BulkDensity[i]))));
        _ScalingFactor = _TotalWaterContentmm / ((0.356 - (0.144 * BulkDensity[i])) * _SoilProfileDepthmm);
        _DumpingDepth = _MaximumDumpingDepth * exp(log(500 / _MaximumDumpingDepth) * pow((1 - _ScalingFactor) / (1 + _ScalingFactor), 2));
        _RatioCenter = _DepthCenterLayer / _DumpingDepth;
        _DepthFactor = _RatioCenter / (_RatioCenter + exp(-0.867 - (2.078 * _RatioCenter)));
        SoilTemperatureByLayers[i] = LagCoefficient * SoilTemperatureByLayers[i] + ((1 - LagCoefficient) * (_DepthFactor * (AirTemperatureAnnualAverage - SurfaceSoilTemperature) + SurfaceSoilTemperature));
    }
    s.setSoilTemperatureByLayers(SoilTemperatureByLayers);
}
#endif