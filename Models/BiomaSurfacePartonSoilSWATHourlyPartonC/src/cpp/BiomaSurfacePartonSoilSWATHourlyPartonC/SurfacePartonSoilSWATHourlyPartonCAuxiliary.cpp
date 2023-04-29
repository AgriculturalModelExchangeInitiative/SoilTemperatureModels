#include "SurfacePartonSoilSWATHourlyPartonCAuxiliary.h"

SurfacePartonSoilSWATHourlyPartonCAuxiliary::SurfacePartonSoilSWATHourlyPartonCAuxiliary() { }

double SurfacePartonSoilSWATHourlyPartonCAuxiliary::getSurfaceTemperatureMinimum() {return this-> SurfaceTemperatureMinimum; }
double SurfacePartonSoilSWATHourlyPartonCAuxiliary::getSurfaceTemperatureMaximum() {return this-> SurfaceTemperatureMaximum; }

void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setSurfaceTemperatureMinimum(double _SurfaceTemperatureMinimum) { this->SurfaceTemperatureMinimum = _SurfaceTemperatureMinimum; }
void SurfacePartonSoilSWATHourlyPartonCAuxiliary::setSurfaceTemperatureMaximum(double _SurfaceTemperatureMaximum) { this->SurfaceTemperatureMaximum = _SurfaceTemperatureMaximum; }