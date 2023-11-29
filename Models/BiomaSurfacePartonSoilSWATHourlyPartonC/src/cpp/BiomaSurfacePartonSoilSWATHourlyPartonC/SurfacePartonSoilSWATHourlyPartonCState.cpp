#include "SurfacePartonSoilSWATHourlyPartonCState.h"
using namespace BiomaSurfacePartonSoilSWATHourlyPartonC;

SurfacePartonSoilSWATHourlyPartonCState::SurfacePartonSoilSWATHourlyPartonCState() {}

std::vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getSoilTemperatureByLayers() { return this->SoilTemperatureByLayers; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getHeatCapacity() { return this->HeatCapacity; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getThermalDiffusivity() { return this->ThermalDiffusivity; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getSoilTemperatureByLayersHourly() { return this->SoilTemperatureByLayersHourly; }

void SurfacePartonSoilSWATHourlyPartonCState::setSoilTemperatureByLayers(std::vector<double> const &_SoilTemperatureByLayers){
    this->SoilTemperatureByLayers = _SoilTemperatureByLayers;
}
void SurfacePartonSoilSWATHourlyPartonCState::setHeatCapacity(std::vector<double> const &_HeatCapacity){
    this->HeatCapacity = _HeatCapacity;
}
void SurfacePartonSoilSWATHourlyPartonCState::setThermalDiffusivity(std::vector<double> const &_ThermalDiffusivity){
    this->ThermalDiffusivity = _ThermalDiffusivity;
}
void SurfacePartonSoilSWATHourlyPartonCState::setSoilTemperatureByLayersHourly(std::vector<double> const &_SoilTemperatureByLayersHourly){
    this->SoilTemperatureByLayersHourly = _SoilTemperatureByLayersHourly;
}