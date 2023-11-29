#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace BiomaSurfaceSWATSoilSWATC {
class SurfaceSWATSoilSWATCExogenous
{
    private:
        double Albedo ;
        double AirTemperatureMinimum ;
        double WaterEquivalentOfSnowPack ;
        double GlobalSolarRadiation ;
        double AirTemperatureMaximum ;
    public:
        SurfaceSWATSoilSWATCExogenous();
        double getAlbedo();
        void setAlbedo(double _Albedo);
        double getAirTemperatureMinimum();
        void setAirTemperatureMinimum(double _AirTemperatureMinimum);
        double getWaterEquivalentOfSnowPack();
        void setWaterEquivalentOfSnowPack(double _WaterEquivalentOfSnowPack);
        double getGlobalSolarRadiation();
        void setGlobalSolarRadiation(double _GlobalSolarRadiation);
        double getAirTemperatureMaximum();
        void setAirTemperatureMaximum(double _AirTemperatureMaximum);

};
}
