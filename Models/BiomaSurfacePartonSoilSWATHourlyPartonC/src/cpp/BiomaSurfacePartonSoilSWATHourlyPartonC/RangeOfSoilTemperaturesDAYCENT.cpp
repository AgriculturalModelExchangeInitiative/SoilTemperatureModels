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
#include "RangeOfSoilTemperaturesDAYCENT.h"
using namespace BiomaSurfacePartonSoilSWATHourlyPartonC;
RangeOfSoilTemperaturesDAYCENT::RangeOfSoilTemperaturesDAYCENT() {}
std::vector<double> & RangeOfSoilTemperaturesDAYCENT::getLayerThickness() { return this->LayerThickness; }
void RangeOfSoilTemperaturesDAYCENT::setLayerThickness(std::vector<double> const &_LayerThickness){
    this->LayerThickness = _LayerThickness;
}
void RangeOfSoilTemperaturesDAYCENT::Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState &s, SurfacePartonSoilSWATHourlyPartonCState &s1, SurfacePartonSoilSWATHourlyPartonCRate &r, SurfacePartonSoilSWATHourlyPartonCAuxiliary &a, SurfacePartonSoilSWATHourlyPartonCExogenous &ex)
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
    //- outputs:
    //            * name: SoilTemperatureRangeByLayers
    //                          ** description : Soil temperature range by layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : auxiliary
    //                          ** len : 
    //                          ** max : 50
    //                          ** min : 0
    //                          ** unit : degC
    //            * name: SoilTemperatureMinimum
    //                          ** description : Minimum soil temperature by layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : auxiliary
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** unit : 
    //            * name: SoilTemperatureMaximum
    //                          ** description : Maximum soil temperature by layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : auxiliary
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** unit : degC
    double SurfaceTemperatureMinimum = a.getSurfaceTemperatureMinimum();
    std::vector<double> & ThermalDiffusivity = a.getThermalDiffusivity();
    std::vector<double> & SoilTemperatureByLayers = a.getSoilTemperatureByLayers();
    double SurfaceTemperatureMaximum = a.getSurfaceTemperatureMaximum();
    std::vector<double> SoilTemperatureRangeByLayers;
    std::vector<double> SoilTemperatureMinimum;
    std::vector<double> SoilTemperatureMaximum;
    int i;
    double _DepthBottom;
    double _DepthCenterLayer;
    double SurfaceDiurnalRange;
    _DepthBottom = float(0);
    _DepthCenterLayer = float(0);
    SurfaceDiurnalRange = SurfaceTemperatureMaximum - SurfaceTemperatureMinimum;
    for (i=0 ; i!=SoilTemperatureByLayers.size() ; i+=1)
    {
        if (i == 0)
        {
            _DepthCenterLayer = LayerThickness[0] * 100 / 2;
            SoilTemperatureRangeByLayers[0] = SurfaceDiurnalRange * std::exp(-_DepthCenterLayer * std::pow(0.00005 / ThermalDiffusivity[0], 0.5));
            SoilTemperatureMaximum[0] = SoilTemperatureByLayers[0] + (SoilTemperatureRangeByLayers[0] / 2);
            SoilTemperatureMinimum[0] = SoilTemperatureByLayers[0] - (SoilTemperatureRangeByLayers[0] / 2);
        }
        else
        {
            _DepthBottom = _DepthBottom + (LayerThickness[(i - 1)] * 100);
            _DepthCenterLayer = _DepthBottom + (LayerThickness[i] * 100 / 2);
            SoilTemperatureRangeByLayers[i] = SurfaceDiurnalRange * std::exp(-_DepthCenterLayer * std::pow(0.00005 / ThermalDiffusivity[i], 0.5));
            SoilTemperatureMaximum[i] = SoilTemperatureByLayers[i] + (SoilTemperatureRangeByLayers[i] / 2);
            SoilTemperatureMinimum[i] = SoilTemperatureByLayers[i] - (SoilTemperatureRangeByLayers[i] / 2);
        }
    }
    a.setSoilTemperatureRangeByLayers(SoilTemperatureRangeByLayers);
    a.setSoilTemperatureMinimum(SoilTemperatureMinimum);
    a.setSoilTemperatureMaximum(SoilTemperatureMaximum);
}