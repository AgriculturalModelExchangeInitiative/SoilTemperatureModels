#include "STEMP_State.h"
STEMP_State::STEMP_State() { }

double STEMP_State::getSRFTEMP() {return this-> SRFTEMP; }
double STEMP_State::getHDAY() {return this-> HDAY; }
vector<double> & STEMP_State::getTMA() {return this-> TMA; }
double STEMP_State::getCUMDPT() {return this-> CUMDPT; }
double STEMP_State::getATOT() {return this-> ATOT; }
double STEMP_State::getTDL() {return this-> TDL; }
vector<double> & STEMP_State::getDSMID() {return this-> DSMID; }
vector<double> & STEMP_State::getST() {return this-> ST; }

void STEMP_State::setSRFTEMP(double _SRFTEMP) { this->SRFTEMP = _SRFTEMP; }
void STEMP_State::setHDAY(double _HDAY) { this->HDAY = _HDAY; }
void STEMP_State::setTMA(vector<double> const & _TMA){
    this->TMA = _TMA;
}
void STEMP_State::setCUMDPT(double _CUMDPT) { this->CUMDPT = _CUMDPT; }
void STEMP_State::setATOT(double _ATOT) { this->ATOT = _ATOT; }
void STEMP_State::setTDL(double _TDL) { this->TDL = _TDL; }
void STEMP_State::setDSMID(vector<double> const & _DSMID){
    this->DSMID = _DSMID;
}
void STEMP_State::setST(vector<double> const & _ST){
    this->ST = _ST;
}