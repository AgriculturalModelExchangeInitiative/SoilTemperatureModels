#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace Campbell {
class model_SoilTempCampbellState
{
    private:
        double airPressure ;
        std::vector<double> soilTemp ;
        std::vector<double> newTemperature ;
        std::vector<double> minSoilTemp ;
        std::vector<double> maxSoilTemp ;
        std::vector<double> aveSoilTemp ;
        std::vector<double> morningSoilTemp ;
        std::vector<double> thermalCondPar1 ;
        std::vector<double> thermalCondPar2 ;
        std::vector<double> thermalCondPar3 ;
        std::vector<double> thermalCondPar4 ;
        std::vector<double> thermalConductivity ;
        std::vector<double> thermalConductance ;
        std::vector<double> heatStorage ;
        std::vector<double> volSpecHeatSoil ;
        double maxTempYesterday ;
        double minTempYesterday ;
        std::vector<double> SLCARB ;
        std::vector<double> SLROCK ;
        std::vector<double> SLSILT ;
        std::vector<double> SLSAND ;
        double _boundaryLayerConductance ;
    public:
        model_SoilTempCampbellState();
        double getairPressure();
        void setairPressure(double _airPressure);
        std::vector<double> & getsoilTemp();
        void setsoilTemp(const std::vector<double> &  _soilTemp);
        std::vector<double> & getnewTemperature();
        void setnewTemperature(const std::vector<double> &  _newTemperature);
        std::vector<double> & getminSoilTemp();
        void setminSoilTemp(const std::vector<double> &  _minSoilTemp);
        std::vector<double> & getmaxSoilTemp();
        void setmaxSoilTemp(const std::vector<double> &  _maxSoilTemp);
        std::vector<double> & getaveSoilTemp();
        void setaveSoilTemp(const std::vector<double> &  _aveSoilTemp);
        std::vector<double> & getmorningSoilTemp();
        void setmorningSoilTemp(const std::vector<double> &  _morningSoilTemp);
        std::vector<double> & getthermalCondPar1();
        void setthermalCondPar1(const std::vector<double> &  _thermalCondPar1);
        std::vector<double> & getthermalCondPar2();
        void setthermalCondPar2(const std::vector<double> &  _thermalCondPar2);
        std::vector<double> & getthermalCondPar3();
        void setthermalCondPar3(const std::vector<double> &  _thermalCondPar3);
        std::vector<double> & getthermalCondPar4();
        void setthermalCondPar4(const std::vector<double> &  _thermalCondPar4);
        std::vector<double> & getthermalConductivity();
        void setthermalConductivity(const std::vector<double> &  _thermalConductivity);
        std::vector<double> & getthermalConductance();
        void setthermalConductance(const std::vector<double> &  _thermalConductance);
        std::vector<double> & getheatStorage();
        void setheatStorage(const std::vector<double> &  _heatStorage);
        std::vector<double> & getvolSpecHeatSoil();
        void setvolSpecHeatSoil(const std::vector<double> &  _volSpecHeatSoil);
        double getmaxTempYesterday();
        void setmaxTempYesterday(double _maxTempYesterday);
        double getminTempYesterday();
        void setminTempYesterday(double _minTempYesterday);
        std::vector<double> & getSLCARB();
        void setSLCARB(const std::vector<double> &  _SLCARB);
        std::vector<double> & getSLROCK();
        void setSLROCK(const std::vector<double> &  _SLROCK);
        std::vector<double> & getSLSILT();
        void setSLSILT(const std::vector<double> &  _SLSILT);
        std::vector<double> & getSLSAND();
        void setSLSAND(const std::vector<double> &  _SLSAND);
        double get_boundaryLayerConductance();
        void set_boundaryLayerConductance(double __boundaryLayerConductance);

};
}
