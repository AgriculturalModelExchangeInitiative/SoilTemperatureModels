#include "STEMP_Exogenous.h"

STEMP_Exogenous::STEMP_Exogenous() { }

double STEMP_Exogenous::getTAMP() {return this-> TAMP; }
double STEMP_Exogenous::getSRAD() {return this-> SRAD; }
double STEMP_Exogenous::getTAV() {return this-> TAV; }
double STEMP_Exogenous::getTMAX() {return this-> TMAX; }
double STEMP_Exogenous::getTAVG() {return this-> TAVG; }
int STEMP_Exogenous::getDOY() {return this-> DOY; }

void STEMP_Exogenous::setTAMP(double _TAMP) { this->TAMP = _TAMP; }
void STEMP_Exogenous::setSRAD(double _SRAD) { this->SRAD = _SRAD; }
void STEMP_Exogenous::setTAV(double _TAV) { this->TAV = _TAV; }
void STEMP_Exogenous::setTMAX(double _TMAX) { this->TMAX = _TMAX; }
void STEMP_Exogenous::setTAVG(double _TAVG) { this->TAVG = _TAVG; }
void STEMP_Exogenous::setDOY(int _DOY) { this->DOY = _DOY; }