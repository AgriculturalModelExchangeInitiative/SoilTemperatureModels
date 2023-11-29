#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace BiomaSurfacePartonSoilSWATHourlyPartonC {
class SurfacePartonSoilSWATHourlyPartonCAuxiliary
{
    private:
        double AboveGroundBiomass ;
        std::vector<double> VolumetricWaterContent ;
        std::vector<double> OrganicMatter ;
        std::vector<double> Sand ;
        double SurfaceSoilTemperature ;
        double SurfaceTemperatureMinimum ;
        double SurfaceTemperatureMaximum ;
        std::vector<double> ThermalConductivity ;
        std::vector<double> SoilTemperatureRangeByLayers ;
        std::vector<double> SoilTemperatureMinimum ;
        std::vector<double> SoilTemperatureMaximum ;
    public:
        SurfacePartonSoilSWATHourlyPartonCAuxiliary();
        double getAboveGroundBiomass();
        void setAboveGroundBiomass(double _AboveGroundBiomass);
        std::vector<double> & getVolumetricWaterContent();
        void setVolumetricWaterContent(const std::vector<double> &  _VolumetricWaterContent);
        std::vector<double> & getOrganicMatter();
        void setOrganicMatter(const std::vector<double> &  _OrganicMatter);
        std::vector<double> & getSand();
        void setSand(const std::vector<double> &  _Sand);
        double getSurfaceSoilTemperature();
        void setSurfaceSoilTemperature(double _SurfaceSoilTemperature);
        double getSurfaceTemperatureMinimum();
        void setSurfaceTemperatureMinimum(double _SurfaceTemperatureMinimum);
        double getSurfaceTemperatureMaximum();
        void setSurfaceTemperatureMaximum(double _SurfaceTemperatureMaximum);
        std::vector<double> & getThermalConductivity();
        void setThermalConductivity(const std::vector<double> &  _ThermalConductivity);
        std::vector<double> & getSoilTemperatureRangeByLayers();
        void setSoilTemperatureRangeByLayers(const std::vector<double> &  _SoilTemperatureRangeByLayers);
        std::vector<double> & getSoilTemperatureMinimum();
        void setSoilTemperatureMinimum(const std::vector<double> &  _SoilTemperatureMinimum);
        std::vector<double> & getSoilTemperatureMaximum();
        void setSoilTemperatureMaximum(const std::vector<double> &  _SoilTemperatureMaximum);

};
}
