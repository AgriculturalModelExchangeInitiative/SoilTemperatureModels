#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace Campbell {
class model_SoilTempCampbellExogenous
{
    private:
        double T2M ;
        double TMAX ;
        double TMIN ;
        double TAV ;
        std::vector<double> SW ;
        int DOY ;
        double canopyHeight ;
        double SRAD ;
        double ESP ;
        double ES ;
        double EOAD ;
        double windSpeed ;
    public:
        model_SoilTempCampbellExogenous();
        double getT2M();
        void setT2M(double _T2M);
        double getTMAX();
        void setTMAX(double _TMAX);
        double getTMIN();
        void setTMIN(double _TMIN);
        double getTAV();
        void setTAV(double _TAV);
        std::vector<double> & getSW();
        void setSW(const std::vector<double> &  _SW);
        int getDOY();
        void setDOY(int _DOY);
        double getcanopyHeight();
        void setcanopyHeight(double _canopyHeight);
        double getSRAD();
        void setSRAD(double _SRAD);
        double getESP();
        void setESP(double _ESP);
        double getES();
        void setES(double _ES);
        double getEOAD();
        void setEOAD(double _EOAD);
        double getwindSpeed();
        void setwindSpeed(double _windSpeed);

};
}
