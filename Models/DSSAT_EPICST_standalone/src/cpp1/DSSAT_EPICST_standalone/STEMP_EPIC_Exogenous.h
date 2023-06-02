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
        double TAVG ;
        double TAV ;
        double TMAX ;
        double BIOMAS ;
        double SNOW ;
        double TMIN ;
        double DEPIR ;
        double TAMP ;
        double MULCHMASS ;
        double RAIN ;
    public:
        STEMP_EPIC_Exogenous();
        double getTAVG();
        void setTAVG(double _TAVG);
        double getTAV();
        void setTAV(double _TAV);
        double getTMAX();
        void setTMAX(double _TMAX);
        double getBIOMAS();
        void setBIOMAS(double _BIOMAS);
        double getSNOW();
        void setSNOW(double _SNOW);
        double getTMIN();
        void setTMIN(double _TMIN);
        double getDEPIR();
        void setDEPIR(double _DEPIR);
        double getTAMP();
        void setTAMP(double _TAMP);
        double getMULCHMASS();
        void setMULCHMASS(double _MULCHMASS);
        double getRAIN();
        void setRAIN(double _RAIN);

};
#endif