#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace DSSAT_ST_standalone {
class STEMP_Exogenous
{
    private:
        double TMAX ;
        double SRAD ;
        double TAMP ;
        double TAVG ;
        double TAV ;
        int DOY ;
    public:
        STEMP_Exogenous();
        double getTMAX();
        void setTMAX(double _TMAX);
        double getSRAD();
        void setSRAD(double _SRAD);
        double getTAMP();
        void setTAMP(double _TAMP);
        double getTAVG();
        void setTAVG(double _TAVG);
        double getTAV();
        void setTAV(double _TAV);
        int getDOY();
        void setDOY(int _DOY);

};
}
