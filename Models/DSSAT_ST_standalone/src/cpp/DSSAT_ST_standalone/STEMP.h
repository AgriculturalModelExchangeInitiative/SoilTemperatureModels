#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "STEMP_State.h"
#include "STEMP_Rate.h"
#include "STEMP_Auxiliary.h"
#include "STEMP_Exogenous.h"
using namespace std;
class STEMP
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
        double MSALB ;
        vector<double> SW ;
        double XLAT ;
    public:
        STEMP();
        void  Calculate_Model(STEMP_State& s, STEMP_State& s1, STEMP_Rate& r, STEMP_Auxiliary& a, STEMP_Exogenous& ex);
        void  Init(STEMP_State& s,STEMP_State& s1, STEMP_Rate& r, STEMP_Auxiliary& a, STEMP_Exogenous& ex);
        tuple<double,vector<double> ,double,vector<double> > SOILT(int NL,double ALBEDO,double B,double CUMDPT,int DOY,double DP,double HDAY,int NLAYR,double PESW,double SRAD,double TAMP,double TAV,double TAVG,double TMAX,double WW,vector<double>  DSMID,double ATOT,vector<double>  TMA);
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
        double getMSALB();
        void setMSALB(double _MSALB);
        vector<double> & getSW();
        void setSW(const vector<double> &  _SW);
        double getXLAT();
        void setXLAT(double _XLAT);

};