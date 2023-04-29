#ifndef _THERMALDIFFU_
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
#include "ThermalDiffu.h"
using namespace std;

ThermalDiffu::ThermalDiffu() { }
void ThermalDiffu::Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState& s, SurfacePartonSoilSWATHourlyPartonCState& s1, SurfacePartonSoilSWATHourlyPartonCRate& r, SurfacePartonSoilSWATHourlyPartonCAuxiliary& a, SurfacePartonSoilSWATHourlyPartonCExogenous& ex)
{
    //- Name: ThermalDiffu -Version: 001, -Time step: 1
    //- Description:
    //            * Title: ThermalDiffu model
    //            * Authors: simone.bregaglio@unimi.it
    //            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    //            * Institution: University Of Milan
    //            * ExtendedDescription: Strategy for the calculation of thermal diffusitivity. Bristow, K.L., Thermal conductivity, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series #5: Madison, Wisconsin. p. 1209-1226. Diekkruger, B. (1996) SIMULAT - Ein Modellsystem zur Berechnung der Wasser- und Stoffdynamik landwirtschaftlich genutzter Standorte (SIMULAT - a model system for the calculation of water and matter dynamics on agricultural sites, in German). In: Wasser- und Stoffdynamik in AgrarÃ´kosystemen, Sonderf.
    //            * ShortDescription: None
    //- inputs:
    //            * name: ThermalDiffusivity
    //                          ** description : Thermal diffusivity of soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0.0025
    //                          ** unit : mm s-1
    //            * name: ThermalConductivity
    //                          ** description : Thermal conductivity of soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 8
    //                          ** min : 0.025
    //                          ** default : 1
    //                          ** unit : W m-1 K-1
    //            * name: HeatCapacity
    //                          ** description : Volumetric specific heat of soil
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 300
    //                          ** min : 0
    //                          ** default : 20
    //                          ** unit : MJ m-3 Â°C-1
    //- outputs:
    //            * name: ThermalDiffusivity
    //                          ** description : Thermal diffusivity of soil layer
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 1
    //                          ** min : 0
    //                          ** unit : mm s-1
    vector<double>  ThermalDiffusivity = s.getThermalDiffusivity();
    vector<double>  ThermalConductivity = s.getThermalConductivity();
    vector<double>  HeatCapacity = s.getHeatCapacity();
    int i;
    for (i=0 ; i!=ThermalDiffusivity.size() ; i+=1)
    {
        ThermalDiffusivity[i] = ThermalConductivity[i] / HeatCapacity[i] / 100;
    }
    s.setThermalDiffusivity(ThermalDiffusivity);
}
#endif