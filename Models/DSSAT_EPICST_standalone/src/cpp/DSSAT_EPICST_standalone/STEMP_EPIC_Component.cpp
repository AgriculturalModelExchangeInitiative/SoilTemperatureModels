#include "STEMP_EPIC_Component.h"
using namespace DSSAT_EPICST_standalone;
STEMP_EPIC_Component::STEMP_EPIC_Component()
{
       
}


std::vector<double> & STEMP_EPIC_Component::getDUL(){ return this->DUL; }
int STEMP_EPIC_Component::getNL(){ return this->NL; }
int STEMP_EPIC_Component::getNLAYR(){ return this->NLAYR; }
std::vector<double> & STEMP_EPIC_Component::getDS(){ return this->DS; }
std::string STEMP_EPIC_Component::getISWWAT(){ return this->ISWWAT; }
std::vector<double> & STEMP_EPIC_Component::getBD(){ return this->BD; }
std::vector<double> & STEMP_EPIC_Component::getLL(){ return this->LL; }
std::vector<double> & STEMP_EPIC_Component::getDLAYR(){ return this->DLAYR; }
std::vector<double> & STEMP_EPIC_Component::getSW(){ return this->SW; }

void STEMP_EPIC_Component::setDUL(const std::vector<double> & _DUL)
{
    _STEMP_EPIC.setDUL(_DUL);
}
void STEMP_EPIC_Component::setNL(int _NL)
{
    _STEMP_EPIC.setNL(_NL);
}
void STEMP_EPIC_Component::setNLAYR(int _NLAYR)
{
    _STEMP_EPIC.setNLAYR(_NLAYR);
}
void STEMP_EPIC_Component::setDS(const std::vector<double> & _DS)
{
    _STEMP_EPIC.setDS(_DS);
}
void STEMP_EPIC_Component::setISWWAT(std::string _ISWWAT)
{
    _STEMP_EPIC.setISWWAT(_ISWWAT);
}
void STEMP_EPIC_Component::setBD(const std::vector<double> & _BD)
{
    _STEMP_EPIC.setBD(_BD);
}
void STEMP_EPIC_Component::setLL(const std::vector<double> & _LL)
{
    _STEMP_EPIC.setLL(_LL);
}
void STEMP_EPIC_Component::setDLAYR(const std::vector<double> & _DLAYR)
{
    _STEMP_EPIC.setDLAYR(_DLAYR);
}
void STEMP_EPIC_Component::setSW(const std::vector<double> & _SW)
{
    _STEMP_EPIC.setSW(_SW);
}
void STEMP_EPIC_Component::Calculate_Model(STEMP_EPIC_State &s, STEMP_EPIC_State &s1, STEMP_EPIC_Rate &r, STEMP_EPIC_Auxiliary &a, STEMP_EPIC_Exogenous &ex)
{
    _STEMP_EPIC.Calculate_Model(s, s1, r, a, ex);
}
STEMP_EPIC_Component::STEMP_EPIC_Component(STEMP_EPIC_Component& toCopy)
{
    for (int i = 0; i < NL; i++)
{
    DUL[i] = toCopy.getDUL()[i];
}

    NL = toCopy.getNL();
    NLAYR = toCopy.getNLAYR();
    for (int i = 0; i < NL; i++)
{
    DS[i] = toCopy.getDS()[i];
}

    ISWWAT = toCopy.getISWWAT();
    for (int i = 0; i < NL; i++)
{
    BD[i] = toCopy.getBD()[i];
}

    for (int i = 0; i < NL; i++)
{
    LL[i] = toCopy.getLL()[i];
}

    for (int i = 0; i < NL; i++)
{
    DLAYR[i] = toCopy.getDLAYR()[i];
}

    for (int i = 0; i < NL; i++)
{
    SW[i] = toCopy.getSW()[i];
}

}