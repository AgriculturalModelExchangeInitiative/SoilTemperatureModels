#include "SurfacePartonSoilSWATCAuxiliary.h"

SurfacePartonSoilSWATCAuxiliary::SurfacePartonSoilSWATCAuxiliary() { }

vector<double> & SurfacePartonSoilSWATCAuxiliary::getVolumetricWaterContent() {return this-> VolumetricWaterContent; }
double SurfacePartonSoilSWATCAuxiliary::getSurfaceTemperatureMinimum() {return this-> SurfaceTemperatureMinimum; }
double SurfacePartonSoilSWATCAuxiliary::getSurfaceTemperatureMaximum() {return this-> SurfaceTemperatureMaximum; }
double SurfacePartonSoilSWATCAuxiliary::getSurfaceSoilTemperature() {return this-> SurfaceSoilTemperature; }

void SurfacePartonSoilSWATCAuxiliary::setVolumetricWaterContent(vector<double> const & _VolumetricWaterContent){
    this->VolumetricWaterContent = _VolumetricWaterContent;
}
void SurfacePartonSoilSWATCAuxiliary::setSurfaceTemperatureMinimum(double _SurfaceTemperatureMinimum) { this->SurfaceTemperatureMinimum = _SurfaceTemperatureMinimum; }
void SurfacePartonSoilSWATCAuxiliary::setSurfaceTemperatureMaximum(double _SurfaceTemperatureMaximum) { this->SurfaceTemperatureMaximum = _SurfaceTemperatureMaximum; }
void SurfacePartonSoilSWATCAuxiliary::setSurfaceSoilTemperature(double _SurfaceSoilTemperature) { this->SurfaceSoilTemperature = _SurfaceSoilTemperature; }