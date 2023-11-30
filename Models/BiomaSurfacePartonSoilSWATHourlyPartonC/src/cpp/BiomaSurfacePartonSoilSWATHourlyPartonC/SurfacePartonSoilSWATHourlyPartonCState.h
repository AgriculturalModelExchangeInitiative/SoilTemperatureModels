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
        std::vector<double> ThermalConductivity ;
        std::vector<double> ThermalDiffusivity ;
        std::vector<double> SoilTemperatureRangeByLayers ;
        std::vector<double> SoilTemperatureMinimum ;
        std::vector<double> SoilTemperatureMaximum ;
        std::vector<double> SoilTemperatureByLayersHourly ;
    public:
        SurfacePartonSoilSWATHourlyPartonCState();
        std::vector<double> & getSoilTemperatureByLayers();
        void setSoilTemperatureByLayers(const std::vector<double> &  _SoilTemperatureByLayers);
        std::vector<double> & getHeatCapacity();
        void setHeatCapacity(const std::vector<double> &  _HeatCapacity);
        std::vector<double> & getThermalConductivity();
        void setThermalConductivity(const std::vector<double> &  _ThermalConductivity);
        std::vector<double> & getThermalDiffusivity();
        void setThermalDiffusivity(const std::vector<double> &  _ThermalDiffusivity);
        std::vector<double> & getSoilTemperatureRangeByLayers();
        void setSoilTemperatureRangeByLayers(const std::vector<double> &  _SoilTemperatureRangeByLayers);
        std::vector<double> & getSoilTemperatureMinimum();
        void setSoilTemperatureMinimum(const std::vector<double> &  _SoilTemperatureMinimum);
        std::vector<double> & getSoilTemperatureMaximum();
        void setSoilTemperatureMaximum(const std::vector<double> &  _SoilTemperatureMaximum);
        std::vector<double> & getSoilTemperatureByLayersHourly();
        void setSoilTemperatureByLayersHourly(const std::vector<double> &  _SoilTemperatureByLayersHourly);

};
}
