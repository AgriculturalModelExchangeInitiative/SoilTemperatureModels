#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace BiomaSurfacePartonSoilSWATHourlyPartonC {
class SurfacePartonSoilSWATHourlyPartonCState
{
    private:
        std::vector<double> SoilTemperatureByLayers ;
        std::vector<double> HeatCapacity ;
        std::vector<double> ThermalDiffusivity ;
        std::vector<double> SoilTemperatureByLayersHourly ;
    public:
        SurfacePartonSoilSWATHourlyPartonCState();
        std::vector<double> & getSoilTemperatureByLayers();
        void setSoilTemperatureByLayers(const std::vector<double> &  _SoilTemperatureByLayers);
        std::vector<double> & getHeatCapacity();
        void setHeatCapacity(const std::vector<double> &  _HeatCapacity);
        std::vector<double> & getThermalDiffusivity();
        void setThermalDiffusivity(const std::vector<double> &  _ThermalDiffusivity);
        std::vector<double> & getSoilTemperatureByLayersHourly();
        void setSoilTemperatureByLayersHourly(const std::vector<double> &  _SoilTemperatureByLayersHourly);

};
}
