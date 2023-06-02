#include "SoilTemperatureAuxiliary.h"

SoilTemperatureAuxiliary::SoilTemperatureAuxiliary() { }

double SoilTemperatureAuxiliary::getSnowIsolationIndex() {return this-> SnowIsolationIndex; }

void SoilTemperatureAuxiliary::setSnowIsolationIndex(double _SnowIsolationIndex) { this->SnowIsolationIndex = _SnowIsolationIndex; }