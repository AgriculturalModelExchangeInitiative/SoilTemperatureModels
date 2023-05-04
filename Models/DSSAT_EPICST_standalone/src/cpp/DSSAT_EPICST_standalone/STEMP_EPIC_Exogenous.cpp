#include "STEMP_EPIC_Exogenous.h"

STEMP_EPIC_Exogenous::STEMP_EPIC_Exogenous() { }

double STEMP_EPIC_Exogenous::getTAVG() {return this-> TAVG; }
double STEMP_EPIC_Exogenous::getTAV() {return this-> TAV; }
double STEMP_EPIC_Exogenous::getTMAX() {return this-> TMAX; }
double STEMP_EPIC_Exogenous::getBIOMAS() {return this-> BIOMAS; }
double STEMP_EPIC_Exogenous::getSNOW() {return this-> SNOW; }
double STEMP_EPIC_Exogenous::getTMIN() {return this-> TMIN; }
double STEMP_EPIC_Exogenous::getDEPIR() {return this-> DEPIR; }
double STEMP_EPIC_Exogenous::getTAMP() {return this-> TAMP; }
double STEMP_EPIC_Exogenous::getMULCHMASS() {return this-> MULCHMASS; }
double STEMP_EPIC_Exogenous::getRAIN() {return this-> RAIN; }

void STEMP_EPIC_Exogenous::setTAVG(double _TAVG) { this->TAVG = _TAVG; }
void STEMP_EPIC_Exogenous::setTAV(double _TAV) { this->TAV = _TAV; }
void STEMP_EPIC_Exogenous::setTMAX(double _TMAX) { this->TMAX = _TMAX; }
void STEMP_EPIC_Exogenous::setBIOMAS(double _BIOMAS) { this->BIOMAS = _BIOMAS; }
void STEMP_EPIC_Exogenous::setSNOW(double _SNOW) { this->SNOW = _SNOW; }
void STEMP_EPIC_Exogenous::setTMIN(double _TMIN) { this->TMIN = _TMIN; }
void STEMP_EPIC_Exogenous::setDEPIR(double _DEPIR) { this->DEPIR = _DEPIR; }
void STEMP_EPIC_Exogenous::setTAMP(double _TAMP) { this->TAMP = _TAMP; }
void STEMP_EPIC_Exogenous::setMULCHMASS(double _MULCHMASS) { this->MULCHMASS = _MULCHMASS; }
void STEMP_EPIC_Exogenous::setRAIN(double _RAIN) { this->RAIN = _RAIN; }