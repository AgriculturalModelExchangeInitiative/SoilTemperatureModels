
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "STEMP_EPIC_State.h"
#include "STEMP_EPIC_Rate.h"
#include "STEMP_EPIC_Auxiliary.h"
#include "STEMP_EPIC_Exogenous.h"
namespace DSSAT_EPICST_standalone {
class STEMP_EPIC
{
    private:
        int NL ;
        std::string ISWWAT ;
        std::vector<double> BD ;
        std::vector<double> DLAYR ;
        std::vector<double> DS ;
        std::vector<double> DUL ;
        std::vector<double> LL ;
        int NLAYR ;
        std::vector<double> SW ;
    public:
        STEMP_EPIC();
        void Calculate_Model(STEMP_EPIC_State &s, STEMP_EPIC_State &s1, STEMP_EPIC_Rate &r, STEMP_EPIC_Auxiliary &a, STEMP_EPIC_Exogenous &ex);
        void Init(STEMP_EPIC_State &s, STEMP_EPIC_State &s1, STEMP_EPIC_Rate &r, STEMP_EPIC_Auxiliary &a, STEMP_EPIC_Exogenous &ex);
        std::tuple<std::vector<double> ,double,std::vector<double> ,double,double> SOILT_EPIC(int NL, double B, double BCV, double CUMDPT, double DP, std::vector<double>  DSMID, int NLAYR, double PESW, double TAV, double TAVG, double TMAX, double TMIN, int WetDay, double WFT, double WW, std::vector<double>  TMA, std::vector<double>  ST, double X2_PREV);
        int getNL();
        void setNL(int _NL);
        std::string getISWWAT();
        void setISWWAT(std::string _ISWWAT);
        std::vector<double> & getBD();
        void setBD(const std::vector<double> &  _BD);
        std::vector<double> & getDLAYR();
        void setDLAYR(const std::vector<double> &  _DLAYR);
        std::vector<double> & getDS();
        void setDS(const std::vector<double> &  _DS);
        std::vector<double> & getDUL();
        void setDUL(const std::vector<double> &  _DUL);
        std::vector<double> & getLL();
        void setLL(const std::vector<double> &  _LL);
        int getNLAYR();
        void setNLAYR(int _NLAYR);
        std::vector<double> & getSW();
        void setSW(const std::vector<double> &  _SW);

};
}
