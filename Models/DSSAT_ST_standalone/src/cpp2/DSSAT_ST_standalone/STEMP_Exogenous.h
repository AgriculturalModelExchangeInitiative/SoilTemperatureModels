#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace DSSAT_ST_standalone {
struct STEMP_Exogenous
{
    double TMAX{0.0};
    double SRAD{0.0};
    double TAMP{0.0};
    double TAVG{0.0};
    double TAV{0.0};
    int DOY{0};
};
}