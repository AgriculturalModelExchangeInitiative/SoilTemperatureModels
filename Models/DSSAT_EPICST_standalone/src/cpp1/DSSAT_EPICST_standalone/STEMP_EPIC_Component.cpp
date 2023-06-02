#include "STEMP_EPIC_Component.h"

    STEMP_EPIC_Component::STEMP_EPIC_Component()
    {
           
    }
    

vector<double> & STEMP_EPIC_Component::getDUL() {return this-> DUL; }
string STEMP_EPIC_Component::getISWWAT() {return this-> ISWWAT; }
vector<double> & STEMP_EPIC_Component::getLL() {return this-> LL; }
vector<double> & STEMP_EPIC_Component::getDS() {return this-> DS; }
vector<double> & STEMP_EPIC_Component::getSW() {return this-> SW; }
vector<double> & STEMP_EPIC_Component::getBD() {return this-> BD; }
int STEMP_EPIC_Component::getNLAYR() {return this-> NLAYR; }
int STEMP_EPIC_Component::getNL() {return this-> NL; }
vector<double> & STEMP_EPIC_Component::getDLAYR() {return this-> DLAYR; }

void STEMP_EPIC_Component::setDUL(const vector<double> & _DUL)
{
    _STEMP_EPIC.setDUL(_DUL);
}
void STEMP_EPIC_Component::setISWWAT(string _ISWWAT)
{
    _STEMP_EPIC.setISWWAT(_ISWWAT);
}
void STEMP_EPIC_Component::setLL(const vector<double> & _LL)
{
    _STEMP_EPIC.setLL(_LL);
}
void STEMP_EPIC_Component::setDS(const vector<double> & _DS)
{
    _STEMP_EPIC.setDS(_DS);
}
void STEMP_EPIC_Component::setSW(const vector<double> & _SW)
{
    _STEMP_EPIC.setSW(_SW);
}
void STEMP_EPIC_Component::setBD(const vector<double> & _BD)
{
    _STEMP_EPIC.setBD(_BD);
}
void STEMP_EPIC_Component::setNLAYR(int _NLAYR)
{
    _STEMP_EPIC.setNLAYR(_NLAYR);
}
void STEMP_EPIC_Component::setNL(int _NL)
{
    _STEMP_EPIC.setNL(_NL);
}
void STEMP_EPIC_Component::setDLAYR(const vector<double> & _DLAYR)
{
    _STEMP_EPIC.setDLAYR(_DLAYR);
}
void STEMP_EPIC_Component::Calculate_Model(STEMP_EPIC_State& s, STEMP_EPIC_State& s1, STEMP_EPIC_Rate& r, STEMP_EPIC_Auxiliary& a, STEMP_EPIC_Exogenous& ex)
{
    _STEMP_EPIC.Calculate_Model(s, s1, r, a, ex);
}
STEMP_EPIC_Component::STEMP_EPIC_Component(const STEMP_EPIC_Component& toCopy)
{
    
        for (int i = 0; i < NL; i++)
        {
            DUL[i] = toCopy.DUL[i];
        }
    
    ISWWAT = toCopy.ISWWAT;
    
        for (int i = 0; i < NL; i++)
        {
            LL[i] = toCopy.LL[i];
        }
    
    
        for (int i = 0; i < NL; i++)
        {
            DS[i] = toCopy.DS[i];
        }
    
    
        for (int i = 0; i < NL; i++)
        {
            SW[i] = toCopy.SW[i];
        }
    
    
        for (int i = 0; i < NL; i++)
        {
            BD[i] = toCopy.BD[i];
        }
    
    NLAYR = toCopy.NLAYR;
    NL = toCopy.NL;
    
        for (int i = 0; i < NL; i++)
        {
            DLAYR[i] = toCopy.DLAYR[i];
        }
    
}