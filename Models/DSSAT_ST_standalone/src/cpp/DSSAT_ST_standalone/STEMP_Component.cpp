#include "STEMP_Component.h"
using namespace DSSAT_ST_standalone;
STEMP_Component::STEMP_Component()
{
       
}


double STEMP_Component::getMSALB(){ return this->MSALB; }
int STEMP_Component::getNL(){ return this->NL; }
std::vector<double> & STEMP_Component::getLL(){ return this->LL; }
int STEMP_Component::getNLAYR(){ return this->NLAYR; }
std::vector<double> & STEMP_Component::getDS(){ return this->DS; }
std::vector<double> & STEMP_Component::getDLAYR(){ return this->DLAYR; }
std::string STEMP_Component::getISWWAT(){ return this->ISWWAT; }
std::vector<double> & STEMP_Component::getBD(){ return this->BD; }
std::vector<double> & STEMP_Component::getSW(){ return this->SW; }
double STEMP_Component::getXLAT(){ return this->XLAT; }
std::vector<double> & STEMP_Component::getDUL(){ return this->DUL; }

void STEMP_Component::setMSALB(double _MSALB)
{
    _STEMP.setMSALB(_MSALB);
}
void STEMP_Component::setNL(int _NL)
{
    _STEMP.setNL(_NL);
}
void STEMP_Component::setLL(const std::vector<double> & _LL)
{
    _STEMP.setLL(_LL);
}
void STEMP_Component::setNLAYR(int _NLAYR)
{
    _STEMP.setNLAYR(_NLAYR);
}
void STEMP_Component::setDS(const std::vector<double> & _DS)
{
    _STEMP.setDS(_DS);
}
void STEMP_Component::setDLAYR(const std::vector<double> & _DLAYR)
{
    _STEMP.setDLAYR(_DLAYR);
}
void STEMP_Component::setISWWAT(std::string _ISWWAT)
{
    _STEMP.setISWWAT(_ISWWAT);
}
void STEMP_Component::setBD(const std::vector<double> & _BD)
{
    _STEMP.setBD(_BD);
}
void STEMP_Component::setSW(const std::vector<double> & _SW)
{
    _STEMP.setSW(_SW);
}
void STEMP_Component::setXLAT(double _XLAT)
{
    _STEMP.setXLAT(_XLAT);
}
void STEMP_Component::setDUL(const std::vector<double> & _DUL)
{
    _STEMP.setDUL(_DUL);
}
void STEMP_Component::Calculate_Model(STEMP_State &s, STEMP_State &s1, STEMP_Rate &r, STEMP_Auxiliary &a, STEMP_Exogenous &ex)
{
    _STEMP.Calculate_Model(s, s1, r, a, ex);
}
STEMP_Component::STEMP_Component(STEMP_Component& toCopy)
{
    MSALB = toCopy.getMSALB();
    NL = toCopy.getNL();
    for (int i = 0; i < NL; i++)
{
    LL[i] = toCopy.getLL()[i];
}

    NLAYR = toCopy.getNLAYR();
    for (int i = 0; i < NL; i++)
{
    DS[i] = toCopy.getDS()[i];
}

    for (int i = 0; i < NL; i++)
{
    DLAYR[i] = toCopy.getDLAYR()[i];
}

    ISWWAT = toCopy.getISWWAT();
    for (int i = 0; i < NL; i++)
{
    BD[i] = toCopy.getBD()[i];
}

    for (int i = 0; i < NL; i++)
{
    SW[i] = toCopy.getSW()[i];
}

    XLAT = toCopy.getXLAT();
    for (int i = 0; i < NL; i++)
{
    DUL[i] = toCopy.getDUL()[i];
}

}