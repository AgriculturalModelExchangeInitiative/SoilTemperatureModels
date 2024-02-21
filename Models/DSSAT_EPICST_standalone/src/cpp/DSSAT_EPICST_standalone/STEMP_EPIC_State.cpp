#include "STEMP_EPIC_State.h"
using namespace DSSAT_EPICST_standalone;

STEMP_EPIC_State::STEMP_EPIC_State() {}

std::vector<int> & STEMP_EPIC_State::getWetDay() { return this->WetDay; }
double STEMP_EPIC_State::getSRFTEMP() { return this->SRFTEMP; }
int STEMP_EPIC_State::getNDays() { return this->NDays; }
std::vector<double> & STEMP_EPIC_State::getST() { return this->ST; }
std::vector<double> & STEMP_EPIC_State::getTMA() { return this->TMA; }
double STEMP_EPIC_State::getTDL() { return this->TDL; }
double STEMP_EPIC_State::getX2_PREV() { return this->X2_PREV; }
std::vector<double> & STEMP_EPIC_State::getDSMID() { return this->DSMID; }
double STEMP_EPIC_State::getCUMDPT() { return this->CUMDPT; }

void STEMP_EPIC_State::setWetDay(std::vector<int> const &_WetDay){
    this->WetDay = _WetDay;
}
void STEMP_EPIC_State::setSRFTEMP(double _SRFTEMP) { this->SRFTEMP = _SRFTEMP; }
void STEMP_EPIC_State::setNDays(int _NDays) { this->NDays = _NDays; }
void STEMP_EPIC_State::setST(std::vector<double> const &_ST){
    this->ST = _ST;
}
void STEMP_EPIC_State::setTMA(std::vector<double> const &_TMA){
    this->TMA = _TMA;
}
void STEMP_EPIC_State::setTDL(double _TDL) { this->TDL = _TDL; }
void STEMP_EPIC_State::setX2_PREV(double _X2_PREV) { this->X2_PREV = _X2_PREV; }
void STEMP_EPIC_State::setDSMID(std::vector<double> const &_DSMID){
    this->DSMID = _DSMID;
}
void STEMP_EPIC_State::setCUMDPT(double _CUMDPT) { this->CUMDPT = _CUMDPT; }