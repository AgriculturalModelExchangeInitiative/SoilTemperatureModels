#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace SQ_Soil_Temperature {
class SoilTemperatureExogenous
{
    private:
        double meanTAir ;
        double minTAir ;
        double meanAnnualAirTemp ;
        double maxTAir ;
        double dayLength ;
    public:
        SoilTemperatureExogenous();
        double getmeanTAir();
        void setmeanTAir(double _meanTAir);
        double getminTAir();
        void setminTAir(double _minTAir);
        double getmeanAnnualAirTemp();
        void setmeanAnnualAirTemp(double _meanAnnualAirTemp);
        double getmaxTAir();
        void setmaxTAir(double _maxTAir);
        double getdayLength();
        void setdayLength(double _dayLength);

};
}
