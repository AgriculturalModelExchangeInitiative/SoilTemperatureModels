#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace BiomaSurfacePartonSoilSWATC {
class SurfacePartonSoilSWATCExogenous
{
    private:
        double AboveGroundBiomass ;
        double DayLength ;
        double AirTemperatureMinimum ;
        double GlobalSolarRadiation ;
        double AirTemperatureMaximum ;
    public:
        SurfacePartonSoilSWATCExogenous();
        double getAboveGroundBiomass();
        void setAboveGroundBiomass(double _AboveGroundBiomass);
        double getDayLength();
        void setDayLength(double _DayLength);
        double getAirTemperatureMinimum();
        void setAirTemperatureMinimum(double _AirTemperatureMinimum);
        double getGlobalSolarRadiation();
        void setGlobalSolarRadiation(double _GlobalSolarRadiation);
        double getAirTemperatureMaximum();
        void setAirTemperatureMaximum(double _AirTemperatureMaximum);

};
}
