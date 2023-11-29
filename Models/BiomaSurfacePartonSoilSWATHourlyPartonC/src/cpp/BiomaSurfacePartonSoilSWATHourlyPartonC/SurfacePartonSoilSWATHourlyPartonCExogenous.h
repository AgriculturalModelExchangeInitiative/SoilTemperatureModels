#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace BiomaSurfacePartonSoilSWATHourlyPartonC {
class SurfacePartonSoilSWATHourlyPartonCExogenous
{
    private:
        double AirTemperatureMaximum ;
        double GlobalSolarRadiation ;
        double AirTemperatureMinimum ;
        double DayLength ;
        double HourOfSunrise ;
        double HourOfSunset ;
    public:
        SurfacePartonSoilSWATHourlyPartonCExogenous();
        double getAirTemperatureMaximum();
        void setAirTemperatureMaximum(double _AirTemperatureMaximum);
        double getGlobalSolarRadiation();
        void setGlobalSolarRadiation(double _GlobalSolarRadiation);
        double getAirTemperatureMinimum();
        void setAirTemperatureMinimum(double _AirTemperatureMinimum);
        double getDayLength();
        void setDayLength(double _DayLength);
        double getHourOfSunrise();
        void setHourOfSunrise(double _HourOfSunrise);
        double getHourOfSunset();
        void setHourOfSunset(double _HourOfSunset);

};
}
