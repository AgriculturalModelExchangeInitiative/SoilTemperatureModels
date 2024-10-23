#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace DSSAT_ST_standalone {
class STEMP_State
{
    private:
        double HDAY ;
        double SRFTEMP ;
        std::vector<double> ST ;
        std::vector<double> TMA ;
        double TDL ;
        double CUMDPT ;
        double ATOT ;
        std::vector<double> DSMID ;
    public:
        STEMP_State();
        double getHDAY();
        void setHDAY(double _HDAY);
        double getSRFTEMP();
        void setSRFTEMP(double _SRFTEMP);
        std::vector<double> & getST();
        void setST(const std::vector<double> &  _ST);
        std::vector<double> & getTMA();
        void setTMA(const std::vector<double> &  _TMA);
        double getTDL();
        void setTDL(double _TDL);
        double getCUMDPT();
        void setCUMDPT(double _CUMDPT);
        double getATOT();
        void setATOT(double _ATOT);
        std::vector<double> & getDSMID();
        void setDSMID(const std::vector<double> &  _DSMID);

};
}
