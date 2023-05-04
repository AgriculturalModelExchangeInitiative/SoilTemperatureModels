#ifndef _STEMP_Exogenous_
#define _STEMP_Exogenous_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class STEMP_Exogenous
{
    private:
        double TAMP ;
        double SRAD ;
        double TAV ;
        double TMAX ;
        double TAVG ;
        int DOY ;
    public:
        STEMP_Exogenous();
        double getTAMP();
        void setTAMP(double _TAMP);
        double getSRAD();
        void setSRAD(double _SRAD);
        double getTAV();
        void setTAV(double _TAV);
        double getTMAX();
        void setTMAX(double _TMAX);
        double getTAVG();
        void setTAVG(double _TAVG);
        int getDOY();
        void setDOY(int _DOY);

};
#endif