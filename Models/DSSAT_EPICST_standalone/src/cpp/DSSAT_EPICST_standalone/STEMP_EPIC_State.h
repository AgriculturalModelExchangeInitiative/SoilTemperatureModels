#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace DSSAT_EPICST_standalone {
class STEMP_EPIC_State
{
    private:
        std::vector<int> WetDay ;
        double SRFTEMP ;
        int NDays ;
        std::vector<double> ST ;
        std::vector<double> TMA ;
        double TDL ;
        double X2_PREV ;
        std::vector<double> DSMID ;
        double CUMDPT ;
    public:
        STEMP_EPIC_State();
        std::vector<int> & getWetDay();
        void setWetDay(const std::vector<int> &  _WetDay);
        double getSRFTEMP();
        void setSRFTEMP(double _SRFTEMP);
        int getNDays();
        void setNDays(int _NDays);
        std::vector<double> & getST();
        void setST(const std::vector<double> &  _ST);
        std::vector<double> & getTMA();
        void setTMA(const std::vector<double> &  _TMA);
        double getTDL();
        void setTDL(double _TDL);
        double getX2_PREV();
        void setX2_PREV(double _X2_PREV);
        std::vector<double> & getDSMID();
        void setDSMID(const std::vector<double> &  _DSMID);
        double getCUMDPT();
        void setCUMDPT(double _CUMDPT);

};
}
