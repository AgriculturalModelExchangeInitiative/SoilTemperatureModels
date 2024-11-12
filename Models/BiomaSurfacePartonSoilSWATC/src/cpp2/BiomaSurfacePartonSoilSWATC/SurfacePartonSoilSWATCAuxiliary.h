#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace BiomaSurfacePartonSoilSWATC {
struct SurfacePartonSoilSWATCAuxiliary
{
    double SurfaceTemperatureMinimum{0.0};
    double SurfaceTemperatureMaximum{0.0};
    double SurfaceSoilTemperature{0.0};
};
}