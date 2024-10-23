#include "SurfacePartonSoilSWATHourlyPartonCAuxiliary.h"
using namespace BiomaSurfacePartonSoilSWATHourlyPartonC;


SurfacePartonSoilSWATHourlyPartonCAuxiliary::SurfacePartonSoilSWATHourlyPartonCAuxiliary() {}

double SurfacePartonSoilSWATHourlyPartonCAuxiliary::getAboveGroundBiomass() { return this->AboveGroundBiomass; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCAuxiliary::getSand() { return this->Sand; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCAuxiliary::getOrganicMatter() { return this->OrganicMatter; }
double SurfacePartonSoilSWATHourlyPartonCAuxiliary::getSurfaceSoilTemperature() { return this->SurfaceSoilTemperature; }
double SurfacePartonSoilSWATHourlyPartonCAuxiliary::getSurfaceTemperatureMinimum() { return this->SurfaceTemperatureMinimum; }
double SurfacePartonSoilSWATHourlyPartonCAuxiliary::getSurfaceTemperatureMaximum() { return this->SurfaceTemperatureMaximum; }

void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setAboveGroundBiomass(double _AboveGroundBiomass) { this->AboveGroundBiomass = _AboveGroundBiomass; }
void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setSand(std::vector<double> const &_Sand){
    this->Sand = _Sand;
}
void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setOrganicMatter(std::vector<double> const &_OrganicMatter){
    this->OrganicMatter = _OrganicMatter;
}
void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setSurfaceSoilTemperature(double _SurfaceSoilTemperature) { this->SurfaceSoilTemperature = _SurfaceSoilTemperature; }
void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setSurfaceTemperatureMinimum(double _SurfaceTemperatureMinimum) { this->SurfaceTemperatureMinimum = _SurfaceTemperatureMinimum; }
void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setSurfaceTemperatureMaximum(double _SurfaceTemperatureMaximum) { this->SurfaceTemperatureMaximum = _SurfaceTemperatureMaximum; }