#include "SurfacePartonSoilSWATCAuxiliary.h"

SurfacePartonSoilSWATCAuxiliary::SurfacePartonSoilSWATCAuxiliary() { }

double SurfacePartonSoilSWATCAuxiliary::getSurfaceTemperatureMinimum() {return this-> SurfaceTemperatureMinimum; }
double SurfacePartonSoilSWATCAuxiliary::getSurfaceTemperatureMaximum() {return this-> SurfaceTemperatureMaximum; }

void SurfacePartonSoilSWATCAuxiliary::setSurfaceTemperatureMinimum(double _SurfaceTemperatureMinimum) { this->SurfaceTemperatureMinimum = _SurfaceTemperatureMinimum; }
void SurfacePartonSoilSWATCAuxiliary::setSurfaceTemperatureMaximum(double _SurfaceTemperatureMaximum) { this->SurfaceTemperatureMaximum = _SurfaceTemperatureMaximum; }