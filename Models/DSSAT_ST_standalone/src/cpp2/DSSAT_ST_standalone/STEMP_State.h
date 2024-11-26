#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace DSSAT_ST_standalone {
struct STEMP_State
{
    double HDAY{0.0};
    double SRFTEMP{0.0};
    std::vector<double> ST;
    std::vector<double> TMA;
    double TDL{0.0};
    double CUMDPT{0.0};
    double ATOT{0.0};
    std::vector<double> DSMID;
};
}