#ifndef _STEMP_EPIC_State_
#define _STEMP_EPIC_State_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class STEMP_EPIC_State
{
    private:
        vector<double> ST ;
        vector<double> TMA ;
        double SRFTEMP ;
        int NDays ;
        vector<double> DSMID ;
        double CUMDPT ;
        double X2_PREV ;
        double TDL ;
        vector<int> WetDay ;
    public:
        STEMP_EPIC_State();
        vector<double> & getST();
        void setST(const vector<double> &  _ST);
        vector<double> & getTMA();
        void setTMA(const vector<double> &  _TMA);
        double getSRFTEMP();
        void setSRFTEMP(double _SRFTEMP);
        int getNDays();
        void setNDays(int _NDays);
        vector<double> & getDSMID();
        void setDSMID(const vector<double> &  _DSMID);
        double getCUMDPT();
        void setCUMDPT(double _CUMDPT);
        double getX2_PREV();
        void setX2_PREV(double _X2_PREV);
        double getTDL();
        void setTDL(double _TDL);
        vector<int> & getWetDay();
        void setWetDay(const vector<int> &  _WetDay);

};
#endif