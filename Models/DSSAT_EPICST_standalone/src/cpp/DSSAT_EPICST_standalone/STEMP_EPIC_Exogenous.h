#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace DSSAT_EPICST_standalone {
class STEMP_EPIC_Exogenous
{
    private:
        double TAV ;
        double RAIN ;
        double BIOMAS ;
        double SNOW ;
        double TAVG ;
        double DEPIR ;
        double MULCHMASS ;
        double TMAX ;
        double TMIN ;
        double TAMP ;
    public:
        STEMP_EPIC_Exogenous();
        double getTAV();
        void setTAV(double _TAV);
        double getRAIN();
        void setRAIN(double _RAIN);
        double getBIOMAS();
        void setBIOMAS(double _BIOMAS);
        double getSNOW();
        void setSNOW(double _SNOW);
        double getTAVG();
        void setTAVG(double _TAVG);
        double getDEPIR();
        void setDEPIR(double _DEPIR);
        double getMULCHMASS();
        void setMULCHMASS(double _MULCHMASS);
        double getTMAX();
        void setTMAX(double _TMAX);
        double getTMIN();
        void setTMIN(double _TMIN);
        double getTAMP();
        void setTAMP(double _TAMP);

};
}
