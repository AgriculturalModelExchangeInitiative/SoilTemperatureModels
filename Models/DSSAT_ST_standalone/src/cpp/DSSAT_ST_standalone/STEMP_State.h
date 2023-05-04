#ifndef _STEMP_State_
#define _STEMP_State_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class STEMP_State
{
    private:
        double SRFTEMP ;
        double HDAY ;
        vector<double> TMA ;
        double CUMDPT ;
        double ATOT ;
        double TDL ;
        vector<double> DSMID ;
        vector<double> ST ;
    public:
        STEMP_State();
        double getSRFTEMP();
        void setSRFTEMP(double _SRFTEMP);
        double getHDAY();
        void setHDAY(double _HDAY);
        vector<double> & getTMA();
        void setTMA(const vector<double> &  _TMA);
        double getCUMDPT();
        void setCUMDPT(double _CUMDPT);
        double getATOT();
        void setATOT(double _ATOT);
        double getTDL();
        void setTDL(double _TDL);
        vector<double> & getDSMID();
        void setDSMID(const vector<double> &  _DSMID);
        vector<double> & getST();
        void setST(const vector<double> &  _ST);

};
#endif