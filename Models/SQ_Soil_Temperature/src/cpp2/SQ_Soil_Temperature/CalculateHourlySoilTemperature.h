
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "SoilTemperatureState.h"
#include "SoilTemperatureRate.h"
#include "SoilTemperatureAuxiliary.h"
#include "SoilTemperatureExogenous.h"
namespace SQ_Soil_Temperature {
class CalculateHourlySoilTemperature
{
private:
    double b{1.81};
    double a{0.5};
    double c{0.49};
public:
    CalculateHourlySoilTemperature();

    void Calculate_Model(SoilTemperatureState &s, SoilTemperatureState &s1, SoilTemperatureRate &r, SoilTemperatureAuxiliary &a, SoilTemperatureExogenous &ex);

    std::vector<double>  getHourlySoilSurfaceTemperature(double TMax, double TMin, double ady, double b, double a, double c);

    double getb();
    void setb(double _b);

    double geta();
    void seta(double _a);

    double getc();
    void setc(double _c);
};
}