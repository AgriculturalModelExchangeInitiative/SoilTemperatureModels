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
#include "ThermalConductivitySIMULAT.h"
using namespace BiomaSurfacePartonSoilSWATHourlyPartonC;
void ThermalConductivitySIMULAT::Init(SurfacePartonSoilSWATHourlyPartonCState &s, SurfacePartonSoilSWATHourlyPartonCState &s1, SurfacePartonSoilSWATHourlyPartonCRate &r, SurfacePartonSoilSWATHourlyPartonCAuxiliary &a, SurfacePartonSoilSWATHourlyPartonCExogenous &ex)
{
    std::vector<double> & VolumetricWaterContent = ex.getVolumetricWaterContent();
    std::vector<double> ThermalConductivity;
    fill(ThermalConductivity.begin(),ThermalConductivity.end(), 0.0);
    s.setThermalConductivity(ThermalConductivity);
}
ThermalConductivitySIMULAT::ThermalConductivitySIMULAT() {}
std::vector<double> & ThermalConductivitySIMULAT::getBulkDensity() { return this->BulkDensity; }
std::vector<double> & ThermalConductivitySIMULAT::getClay() { return this->Clay; }
void ThermalConductivitySIMULAT::setBulkDensity(std::vector<double> const &_BulkDensity){
    this->BulkDensity = _BulkDensity;
}
void ThermalConductivitySIMULAT::setClay(std::vector<double> const &_Clay){
    this->Clay = _Clay;
}
void ThermalConductivitySIMULAT::Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState &s, SurfacePartonSoilSWATHourlyPartonCState &s1, SurfacePartonSoilSWATHourlyPartonCRate &r, SurfacePartonSoilSWATHourlyPartonCAuxiliary &a, SurfacePartonSoilSWATHourlyPartonCExogenous &ex)
{
    //- Name: ThermalConductivitySIMULAT -Version: 001, -Time step: 1
    //- Description:
    //            * Title: ThermalConductivitySIMULAT model
    //            * Authors: simone.bregaglio
    //            * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
    //            * Institution: University Of Milan
    //            * ExtendedDescription: Strategy for the calculation of thermal conductivity. Bristow, K.L., Thermal conductivity, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series
    //            * ShortDescription: Strategy for the calculation of thermal conductivity
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
    //            * name: Clay
    //                          ** description : Clay content of soil layer
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 100
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : 
    //            * name: ThermalConductivity
    //                          ** description : Thermal conductivity of soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 8
    //                          ** min : 0.025
    //                          ** default : 
    //                          ** unit : W m-1 K-1
    //- outputs:
    //            * name: ThermalConductivity
    //                          ** description : Thermal conductivity of soil layer
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 8
    //                          ** min : 0.025
    //                          ** unit : W m-1 K-1
    std::vector<double> & VolumetricWaterContent = ex.getVolumetricWaterContent();
    std::vector<double> & ThermalConductivity = s.getThermalConductivity();
    int i;
    double Aterm;
    double Bterm;
    double Cterm;
    double Dterm;
    double Eterm;
    Aterm = float(0);
    Bterm = float(0);
    Cterm = float(0);
    Dterm = float(0);
    Eterm = float(4);
    for (i=0 ; i!=VolumetricWaterContent.size() ; i+=1)
    {
        Aterm = 0.65 - (0.78 * BulkDensity[i]) + (0.6 * std::pow(BulkDensity[i], 2));
        Bterm = 1.06 * BulkDensity[i] * VolumetricWaterContent[i];
        Cterm = 1 + (2.6 * std::sqrt(Clay[i] / 100));
        Dterm = 0.03 + (0.1 * std::pow(BulkDensity[i], 2));
        ThermalConductivity[i] = Aterm + (Bterm * VolumetricWaterContent[i]) - ((Aterm - Dterm) * std::pow(std::exp(-(Cterm * VolumetricWaterContent[i])), Eterm));
    }
    s.setThermalConductivity(ThermalConductivity);
}