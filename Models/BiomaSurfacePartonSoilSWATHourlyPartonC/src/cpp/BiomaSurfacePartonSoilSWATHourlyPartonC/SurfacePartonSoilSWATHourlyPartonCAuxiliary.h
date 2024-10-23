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
        std::vector<double> Sand ;
        std::vector<double> OrganicMatter ;
        double SurfaceSoilTemperature ;
        double SurfaceTemperatureMinimum ;
        double SurfaceTemperatureMaximum ;
    public:
        SurfacePartonSoilSWATHourlyPartonCAuxiliary();
        double getAboveGroundBiomass();
        void setAboveGroundBiomass(double _AboveGroundBiomass);
        std::vector<double> & getSand();
        void setSand(const std::vector<double> &  _Sand);
        std::vector<double> & getOrganicMatter();
        void setOrganicMatter(const std::vector<double> &  _OrganicMatter);
        double getSurfaceSoilTemperature();
        void setSurfaceSoilTemperature(double _SurfaceSoilTemperature);
        double getSurfaceTemperatureMinimum();
        void setSurfaceTemperatureMinimum(double _SurfaceTemperatureMinimum);
        double getSurfaceTemperatureMaximum();
        void setSurfaceTemperatureMaximum(double _SurfaceTemperatureMaximum);

};
}
