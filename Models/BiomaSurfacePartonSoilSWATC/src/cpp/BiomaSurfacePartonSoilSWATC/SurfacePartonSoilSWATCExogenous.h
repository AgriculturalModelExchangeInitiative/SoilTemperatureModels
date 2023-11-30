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
        double DayLength ;
        double GlobalSolarRadiation ;
        double AboveGroundBiomass ;
        double AirTemperatureMinimum ;
        double AirTemperatureMaximum ;
        std::vector<double> VolumetricWaterContent ;
    public:
        SurfacePartonSoilSWATCExogenous();
        double getDayLength();
        void setDayLength(double _DayLength);
        double getGlobalSolarRadiation();
        void setGlobalSolarRadiation(double _GlobalSolarRadiation);
        double getAboveGroundBiomass();
        void setAboveGroundBiomass(double _AboveGroundBiomass);
        double getAirTemperatureMinimum();
        void setAirTemperatureMinimum(double _AirTemperatureMinimum);
        double getAirTemperatureMaximum();
        void setAirTemperatureMaximum(double _AirTemperatureMaximum);
        std::vector<double> & getVolumetricWaterContent();
        void setVolumetricWaterContent(const std::vector<double> &  _VolumetricWaterContent);

};
}
