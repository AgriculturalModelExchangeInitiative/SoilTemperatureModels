#include "SurfacePartonSoilSWATHourlyPartonCState.h"
using namespace BiomaSurfacePartonSoilSWATHourlyPartonC;

SurfacePartonSoilSWATHourlyPartonCState::SurfacePartonSoilSWATHourlyPartonCState() {}

std::vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getSoilTemperatureByLayers() { return this->SoilTemperatureByLayers; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getHeatCapacity() { return this->HeatCapacity; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getThermalConductivity() { return this->ThermalConductivity; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getThermalDiffusivity() { return this->ThermalDiffusivity; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getSoilTemperatureRangeByLayers() { return this->SoilTemperatureRangeByLayers; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getSoilTemperatureMinimum() { return this->SoilTemperatureMinimum; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getSoilTemperatureMaximum() { return this->SoilTemperatureMaximum; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getSoilTemperatureByLayersHourly() { return this->SoilTemperatureByLayersHourly; }

void SurfacePartonSoilSWATHourlyPartonCState::setSoilTemperatureByLayers(std::vector<double> const &_SoilTemperatureByLayers){
    this->SoilTemperatureByLayers = _SoilTemperatureByLayers;
}
void SurfacePartonSoilSWATHourlyPartonCState::setHeatCapacity(std::vector<double> const &_HeatCapacity){
    this->HeatCapacity = _HeatCapacity;
}
void SurfacePartonSoilSWATHourlyPartonCState::setThermalConductivity(std::vector<double> const &_ThermalConductivity){
    this->ThermalConductivity = _ThermalConductivity;
}
void SurfacePartonSoilSWATHourlyPartonCState::setThermalDiffusivity(std::vector<double> const &_ThermalDiffusivity){
    this->ThermalDiffusivity = _ThermalDiffusivity;
}
void SurfacePartonSoilSWATHourlyPartonCState::setSoilTemperatureRangeByLayers(std::vector<double> const &_SoilTemperatureRangeByLayers){
    this->SoilTemperatureRangeByLayers = _SoilTemperatureRangeByLayers;
}
void SurfacePartonSoilSWATHourlyPartonCState::setSoilTemperatureMinimum(std::vector<double> const &_SoilTemperatureMinimum){
    this->SoilTemperatureMinimum = _SoilTemperatureMinimum;
}
void SurfacePartonSoilSWATHourlyPartonCState::setSoilTemperatureMaximum(std::vector<double> const &_SoilTemperatureMaximum){
    this->SoilTemperatureMaximum = _SoilTemperatureMaximum;
}
void SurfacePartonSoilSWATHourlyPartonCState::setSoilTemperatureByLayersHourly(std::vector<double> const &_SoilTemperatureByLayersHourly){
    this->SoilTemperatureByLayersHourly = _SoilTemperatureByLayersHourly;
}