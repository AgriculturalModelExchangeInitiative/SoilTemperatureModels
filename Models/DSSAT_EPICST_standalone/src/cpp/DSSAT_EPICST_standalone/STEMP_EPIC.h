#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "STEMP_EPIC_State.h"
#include "STEMP_EPIC_Rate.h"
#include "STEMP_EPIC_Auxiliary.h"
#include "STEMP_EPIC_Exogenous.h"
using namespace std;
class STEMP_EPIC
{
    private:
        int NL ;
        string ISWWAT ;
        vector<double> BD ;
        vector<double> DLAYR ;
        vector<double> DS ;
        vector<double> DUL ;
        vector<double> LL ;
        int NLAYR ;
        vector<double> SW ;
    public:
        STEMP_EPIC();
        void  Calculate_Model(STEMP_EPIC_State& s, STEMP_EPIC_State& s1, STEMP_EPIC_Rate& r, STEMP_EPIC_Auxiliary& a, STEMP_EPIC_Exogenous& ex);
        void  Init(STEMP_EPIC_State& s,STEMP_EPIC_State& s1, STEMP_EPIC_Rate& r, STEMP_EPIC_Auxiliary& a, STEMP_EPIC_Exogenous& ex);
        tuple<vector<double> ,double,vector<double> ,double,double> SOILT_EPIC(int NL,double B,double BCV,double CUMDPT,double DP,vector<double>  DSMID,int NLAYR,double PESW,double TAV,double TAVG,double TMAX,double TMIN,int WetDay,double WFT,double WW,vector<double>  TMA,vector<double>  ST,double X2_PREV);
        int getNL();
        void setNL(int _NL);
        string getISWWAT();
        void setISWWAT(string _ISWWAT);
        vector<double> & getBD();
        void setBD(const vector<double> &  _BD);
        vector<double> & getDLAYR();
        void setDLAYR(const vector<double> &  _DLAYR);
        vector<double> & getDS();
        void setDS(const vector<double> &  _DS);
        vector<double> & getDUL();
        void setDUL(const vector<double> &  _DUL);
        vector<double> & getLL();
        void setLL(const vector<double> &  _LL);
        int getNLAYR();
        void setNLAYR(int _NLAYR);
        vector<double> & getSW();
        void setSW(const vector<double> &  _SW);

};