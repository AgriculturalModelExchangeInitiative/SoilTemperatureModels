
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "STEMP_State.h"
#include "STEMP_Rate.h"
#include "STEMP_Auxiliary.h"
#include "STEMP_Exogenous.h"
namespace DSSAT_ST_standalone {
class STEMP
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
        double MSALB ;
        std::vector<double> SW ;
        double XLAT ;
    public:
        STEMP();
        void Calculate_Model(STEMP_State &s, STEMP_State &s1, STEMP_Rate &r, STEMP_Auxiliary &a, STEMP_Exogenous &ex);
        void Init(STEMP_State &s, STEMP_State &s1, STEMP_Rate &r, STEMP_Auxiliary &a, STEMP_Exogenous &ex);
        std::tuple<double,std::vector<double> ,double,std::vector<double> > SOILT(int NL, double ALBEDO, double B, double CUMDPT, int DOY, double DP, double HDAY, int NLAYR, double PESW, double SRAD, double TAMP, double TAV, double TAVG, double TMAX, double WW, std::vector<double>  DSMID, double ATOT, std::vector<double>  TMA);
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
        double getMSALB();
        void setMSALB(double _MSALB);
        std::vector<double> & getSW();
        void setSW(const std::vector<double> &  _SW);
        double getXLAT();
        void setXLAT(double _XLAT);

};
}
