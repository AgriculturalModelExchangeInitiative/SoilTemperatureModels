#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace DSSAT_EPICST_standalone {
struct STEMP_EPIC_Exogenous
{
    double TAV{0.0};
    double RAIN{0.0};
    double BIOMAS{0.0};
    double SNOW{0.0};
    double TAVG{0.0};
    double DEPIR{0.0};
    double MULCHMASS{0.0};
    double TMAX{0.0};
    double TMIN{0.0};
    double TAMP{0.0};
};
}