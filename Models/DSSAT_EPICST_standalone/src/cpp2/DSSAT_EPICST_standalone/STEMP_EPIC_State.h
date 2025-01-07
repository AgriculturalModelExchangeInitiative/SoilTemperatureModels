#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace DSSAT_EPICST_standalone {
struct STEMP_EPIC_State
{
    std::vector<int> WetDay;
    double SRFTEMP{0.0};
    int NDays{0};
    std::vector<double> ST;
    std::vector<double> TMA;
    double TDL{0.0};
    double X2_PREV{0.0};
    std::vector<double> DSMID;
    double CUMDPT{0.0};
};
}