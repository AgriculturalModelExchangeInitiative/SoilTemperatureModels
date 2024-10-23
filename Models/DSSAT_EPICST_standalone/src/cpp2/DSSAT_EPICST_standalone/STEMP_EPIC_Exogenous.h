#ifndef _STEMP_EPIC_Exogenous_
#define _STEMP_EPIC_Exogenous_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class STEMP_EPIC_Exogenous
{
    private:
        double RAIN ;
        double DEPIR ;
        double TMIN ;
        double BIOMAS ;
        double TAMP ;
        double MULCHMASS ;
        double TMAX ;
        double TAV ;
        double SNOW ;
        double TAVG ;
    public:
        STEMP_EPIC_Exogenous();
        double getRAIN();
        void setRAIN(double _RAIN);
        double getDEPIR();
        void setDEPIR(double _DEPIR);
        double getTMIN();
        void setTMIN(double _TMIN);
        double getBIOMAS();
        void setBIOMAS(double _BIOMAS);
        double getTAMP();
        void setTAMP(double _TAMP);
        double getMULCHMASS();
        void setMULCHMASS(double _MULCHMASS);
        double getTMAX();
        void setTMAX(double _TMAX);
        double getTAV();
        void setTAV(double _TAV);
        double getSNOW();
        void setSNOW(double _SNOW);
        double getTAVG();
        void setTAVG(double _TAVG);

};
#endif