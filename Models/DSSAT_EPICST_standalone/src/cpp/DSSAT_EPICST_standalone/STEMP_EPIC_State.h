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
        int NDays ;
        vector<int> WetDay ;
        double TDL ;
        double X2_PREV ;
        vector<double> DSMID ;
        vector<double> TMA ;
        double SRFTEMP ;
        vector<double> ST ;
        double CUMDPT ;
    public:
        STEMP_EPIC_State();
        int getNDays();
        void setNDays(int _NDays);
        vector<int> & getWetDay();
        void setWetDay(const vector<int> &  _WetDay);
        double getTDL();
        void setTDL(double _TDL);
        double getX2_PREV();
        void setX2_PREV(double _X2_PREV);
        vector<double> & getDSMID();
        void setDSMID(const vector<double> &  _DSMID);
        vector<double> & getTMA();
        void setTMA(const vector<double> &  _TMA);
        double getSRFTEMP();
        void setSRFTEMP(double _SRFTEMP);
        vector<double> & getST();
        void setST(const vector<double> &  _ST);
        double getCUMDPT();
        void setCUMDPT(double _CUMDPT);

};
#endif