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
#include "CalculateHourlySoilTemperature.h"
using namespace SQ_Soil_Temperature;
CalculateHourlySoilTemperature::CalculateHourlySoilTemperature() {}
double CalculateHourlySoilTemperature::getb() { return this->b; }
double CalculateHourlySoilTemperature::geta() { return this->a; }
double CalculateHourlySoilTemperature::getc() { return this->c; }
void CalculateHourlySoilTemperature::setb(double _b) { this->b = _b; }
void CalculateHourlySoilTemperature::seta(double _a) { this->a = _a; }
void CalculateHourlySoilTemperature::setc(double _c) { this->c = _c; }
void CalculateHourlySoilTemperature::Calculate_Model(SoilTemperatureState &s, SoilTemperatureState &s1, SoilTemperatureRate &r, SoilTemperatureAuxiliary &a_, SoilTemperatureExogenous &ex)
{
    //- Name: CalculateHourlySoilTemperature -Version: 001, -Time step: 1
    //- Description:
    //            * Title: CalculateHourlySoilTemperature model
    //            * Authors: loic.manceau@inra.fr
    //            * Reference: ('http://biomamodelling.org',)
    //            * Institution: INRA
    //            * ExtendedDescription: Calculate Soil temperature on a hourly basis.Parton, W.J. and Logan, J.A., 1981. A model for diurnal variation in soil and air temperature. Agric. Meteorol., 23: 205-216
    //            * ShortDescription: None
    //- inputs:
    //            * name: minTSoil
    //                          ** description : Minimum Soil Temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 20
    //                          ** unit : Â°C
    //            * name: dayLength
    //                          ** description : Length of the day
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 24
    //                          ** min : 0
    //                          ** default : 12
    //                          ** unit : hour
    //            * name: b
    //                          ** description : Delay between sunrise and time when minimum temperature is reached
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 10
    //                          ** min : 0
    //                          ** default : 1.81
    //                          ** unit : Hour
    //            * name: a
    //                          ** description : Delay between sunset and time when maximum temperature is reached
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 10
    //                          ** min : 0
    //                          ** default : 0.5
    //                          ** unit : Hour
    //            * name: maxTSoil
    //                          ** description : Maximum Soil Temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 20
    //                          ** unit : Â°C
    //            * name: c
    //                          ** description : Nighttime temperature coefficient
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 10
    //                          ** min : 0
    //                          ** default : 0.49
    //                          ** unit : Dpmensionless
    //- outputs:
    //            * name: hourlySoilT
    //                          ** description : Hourly Soil Temperature
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 24
    //                          ** max : 80
    //                          ** min : -30
    //                          ** unit : Â°C
    s.hourlySoilT = std::vector<double>(24);
    int i;
    if (s.maxTSoil == float(-999) && s.minTSoil == float(999))
    {
        for (i=0 ; i!=12 ; i+=1)
        {
            s.hourlySoilT[i] = float(999);
        }
        for (i=12 ; i!=24 ; i+=1)
        {
            s.hourlySoilT[i] = float(-999);
        }
    }
    else
    {
        for (i=0 ; i!=24 ; i+=1)
        {
            s.hourlySoilT[i] = 0.0;
        }
        s.hourlySoilT = getHourlySoilSurfaceTemperature(s.maxTSoil, s.minTSoil, ex.dayLength, b, a, c);
    }
}
std::vector<double>  CalculateHourlySoilTemperature::getHourlySoilSurfaceTemperature(double TMax, double TMin, double ady, double b, double a, double c)
{
    int i;
    std::vector<double> result(24);
    double ahou;
    double ani;
    double bb;
    double be;
    double bbd;
    double ddy;
    double tsn;
    ahou = M_PI * (ady / 24.0);
    ani = 24 - ady;
    bb = 12 - (ady / 2) + c;
    be = 12 + (ady / 2);
    for (i=0 ; i!=24 ; i+=1)
    {
        if (i >= int(bb) && i <= int(be))
        {
            result[i] = (TMax - TMin) * std::sin(3.14 * (i - bb) / (ady + (2 * a))) + TMin;
        }
        else
        {
            if (i > int(be))
            {
                bbd = i - be;
            }
            else
            {
                bbd = 24 + be + i;
            }
            ddy = ady - c;
            tsn = (TMax - TMin) * std::sin(3.14 * ddy / (ady + (2 * a))) + TMin;
            result[i] = TMin + ((tsn - TMin) * std::exp(-b * bbd / ani));
        }
    }
    return result;
}