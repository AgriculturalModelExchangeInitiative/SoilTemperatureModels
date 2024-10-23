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
        double AirTemperatureMinimum ;
        double DayLength ;
        double GlobalSolarRadiation ;
        double AirTemperatureMaximum ;
        std::vector<double> VolumetricWaterContent ;
        double HourOfSunset ;
        double HourOfSunrise ;
    public:
        SurfacePartonSoilSWATHourlyPartonCExogenous();
        double getAirTemperatureMinimum();
        void setAirTemperatureMinimum(double _AirTemperatureMinimum);
        double getDayLength();
        void setDayLength(double _DayLength);
        double getGlobalSolarRadiation();
        void setGlobalSolarRadiation(double _GlobalSolarRadiation);
        double getAirTemperatureMaximum();
        void setAirTemperatureMaximum(double _AirTemperatureMaximum);
        std::vector<double> & getVolumetricWaterContent();
        void setVolumetricWaterContent(const std::vector<double> &  _VolumetricWaterContent);
        double getHourOfSunset();
        void setHourOfSunset(double _HourOfSunset);
        double getHourOfSunrise();
        void setHourOfSunrise(double _HourOfSunrise);

};
}
