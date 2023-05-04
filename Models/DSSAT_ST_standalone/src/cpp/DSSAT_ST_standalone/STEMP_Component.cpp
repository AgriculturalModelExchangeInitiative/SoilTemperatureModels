#include "STEMP_Component.h"

    STEMP_Component::STEMP_Component()
    {
           
    }
    

double STEMP_Component::getXLAT() {return this-> XLAT; }
string STEMP_Component::getISWWAT() {return this-> ISWWAT; }
int STEMP_Component::getNLAYR() {return this-> NLAYR; }
vector<double> & STEMP_Component::getDUL() {return this-> DUL; }
vector<double> & STEMP_Component::getDS() {return this-> DS; }
vector<double> & STEMP_Component::getLL() {return this-> LL; }
vector<double> & STEMP_Component::getBD() {return this-> BD; }
double STEMP_Component::getMSALB() {return this-> MSALB; }
int STEMP_Component::getNL() {return this-> NL; }
vector<double> & STEMP_Component::getDLAYR() {return this-> DLAYR; }
vector<double> & STEMP_Component::getSW() {return this-> SW; }

void STEMP_Component::setXLAT(double _XLAT)
{
    _STEMP.setXLAT(_XLAT);
}
void STEMP_Component::setISWWAT(string _ISWWAT)
{
    _STEMP.setISWWAT(_ISWWAT);
}
void STEMP_Component::setNLAYR(int _NLAYR)
{
    _STEMP.setNLAYR(_NLAYR);
}
void STEMP_Component::setDUL(const vector<double> & _DUL)
{
    _STEMP.setDUL(_DUL);
}
void STEMP_Component::setDS(const vector<double> & _DS)
{
    _STEMP.setDS(_DS);
}
void STEMP_Component::setLL(const vector<double> & _LL)
{
    _STEMP.setLL(_LL);
}
void STEMP_Component::setBD(const vector<double> & _BD)
{
    _STEMP.setBD(_BD);
}
void STEMP_Component::setMSALB(double _MSALB)
{
    _STEMP.setMSALB(_MSALB);
}
void STEMP_Component::setNL(int _NL)
{
    _STEMP.setNL(_NL);
}
void STEMP_Component::setDLAYR(const vector<double> & _DLAYR)
{
    _STEMP.setDLAYR(_DLAYR);
}
void STEMP_Component::setSW(const vector<double> & _SW)
{
    _STEMP.setSW(_SW);
}
void STEMP_Component::Calculate_Model(STEMP_State& s, STEMP_State& s1, STEMP_Rate& r, STEMP_Auxiliary& a, STEMP_Exogenous& ex)
{
    _STEMP.Calculate_Model(s, s1, r, a, ex);
}
STEMP_Component::STEMP_Component(const STEMP_Component& toCopy)
{
    XLAT = toCopy.XLAT;
    ISWWAT = toCopy.ISWWAT;
    NLAYR = toCopy.NLAYR;
    
        for (int i = 0; i < NL; i++)
        {
            DUL[i] = toCopy.DUL[i];
        }
    
    
        for (int i = 0; i < NL; i++)
        {
            DS[i] = toCopy.DS[i];
        }
    
    
        for (int i = 0; i < NL; i++)
        {
            LL[i] = toCopy.LL[i];
        }
    
    
        for (int i = 0; i < NL; i++)
        {
            BD[i] = toCopy.BD[i];
        }
    
    MSALB = toCopy.MSALB;
    NL = toCopy.NL;
    
        for (int i = 0; i < NL; i++)
        {
            DLAYR[i] = toCopy.DLAYR[i];
        }
    
    
        for (int i = 0; i < NL; i++)
        {
            SW[i] = toCopy.SW[i];
        }
    
}