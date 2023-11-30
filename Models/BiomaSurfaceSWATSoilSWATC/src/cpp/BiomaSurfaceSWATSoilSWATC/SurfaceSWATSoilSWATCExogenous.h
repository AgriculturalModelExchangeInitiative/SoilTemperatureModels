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
        double AirTemperatureMaximum ;
        double AirTemperatureMinimum ;
        double GlobalSolarRadiation ;
        double WaterEquivalentOfSnowPack ;
        double Albedo ;
        std::vector<double> VolumetricWaterContent ;
    public:
        SurfaceSWATSoilSWATCExogenous();
        double getAirTemperatureMaximum();
        void setAirTemperatureMaximum(double _AirTemperatureMaximum);
        double getAirTemperatureMinimum();
        void setAirTemperatureMinimum(double _AirTemperatureMinimum);
        double getGlobalSolarRadiation();
        void setGlobalSolarRadiation(double _GlobalSolarRadiation);
        double getWaterEquivalentOfSnowPack();
        void setWaterEquivalentOfSnowPack(double _WaterEquivalentOfSnowPack);
        double getAlbedo();
        void setAlbedo(double _Albedo);
        std::vector<double> & getVolumetricWaterContent();
        void setVolumetricWaterContent(const std::vector<double> &  _VolumetricWaterContent);

};
}
