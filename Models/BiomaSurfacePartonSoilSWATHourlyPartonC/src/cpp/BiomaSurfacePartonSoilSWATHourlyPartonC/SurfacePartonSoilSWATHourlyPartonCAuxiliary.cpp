#include "SurfacePartonSoilSWATHourlyPartonCAuxiliary.h"
using namespace BiomaSurfacePartonSoilSWATHourlyPartonC;


SurfacePartonSoilSWATHourlyPartonCAuxiliary::SurfacePartonSoilSWATHourlyPartonCAuxiliary() {}

double SurfacePartonSoilSWATHourlyPartonCAuxiliary::getAboveGroundBiomass() { return this->AboveGroundBiomass; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCAuxiliary::getVolumetricWaterContent() { return this->VolumetricWaterContent; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCAuxiliary::getOrganicMatter() { return this->OrganicMatter; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCAuxiliary::getSand() { return this->Sand; }
double SurfacePartonSoilSWATHourlyPartonCAuxiliary::getSurfaceSoilTemperature() { return this->SurfaceSoilTemperature; }
double SurfacePartonSoilSWATHourlyPartonCAuxiliary::getSurfaceTemperatureMinimum() { return this->SurfaceTemperatureMinimum; }
double SurfacePartonSoilSWATHourlyPartonCAuxiliary::getSurfaceTemperatureMaximum() { return this->SurfaceTemperatureMaximum; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCAuxiliary::getThermalConductivity() { return this->ThermalConductivity; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCAuxiliary::getSoilTemperatureRangeByLayers() { return this->SoilTemperatureRangeByLayers; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCAuxiliary::getSoilTemperatureMinimum() { return this->SoilTemperatureMinimum; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCAuxiliary::getSoilTemperatureMaximum() { return this->SoilTemperatureMaximum; }

void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setAboveGroundBiomass(double _AboveGroundBiomass) { this->AboveGroundBiomass = _AboveGroundBiomass; }
void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setVolumetricWaterContent(std::vector<double> const &_VolumetricWaterContent){
    this->VolumetricWaterContent = _VolumetricWaterContent;
}
void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setOrganicMatter(std::vector<double> const &_OrganicMatter){
    this->OrganicMatter = _OrganicMatter;
}
void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setSand(std::vector<double> const &_Sand){
    this->Sand = _Sand;
}
void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setSurfaceSoilTemperature(double _SurfaceSoilTemperature) { this->SurfaceSoilTemperature = _SurfaceSoilTemperature; }
void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setSurfaceTemperatureMinimum(double _SurfaceTemperatureMinimum) { this->SurfaceTemperatureMinimum = _SurfaceTemperatureMinimum; }
void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setSurfaceTemperatureMaximum(double _SurfaceTemperatureMaximum) { this->SurfaceTemperatureMaximum = _SurfaceTemperatureMaximum; }
void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setThermalConductivity(std::vector<double> const &_ThermalConductivity){
    this->ThermalConductivity = _ThermalConductivity;
}
void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setSoilTemperatureRangeByLayers(std::vector<double> const &_SoilTemperatureRangeByLayers){
    this->SoilTemperatureRangeByLayers = _SoilTemperatureRangeByLayers;
}
void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setSoilTemperatureMinimum(std::vector<double> const &_SoilTemperatureMinimum){
    this->SoilTemperatureMinimum = _SoilTemperatureMinimum;
}
void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setSoilTemperatureMaximum(std::vector<double> const &_SoilTemperatureMaximum){
    this->SoilTemperatureMaximum = _SoilTemperatureMaximum;
}