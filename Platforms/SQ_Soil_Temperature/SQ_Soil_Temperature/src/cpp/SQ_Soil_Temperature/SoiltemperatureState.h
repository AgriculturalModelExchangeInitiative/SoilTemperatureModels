#ifndef _SoiltemperatureState_
#define _SoiltemperatureState_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class SoiltemperatureState
{
    private:
        double deepLayerT;
        double maxTSoil;
        double minTSoil;
        array<>&  hourlySoilT;
    public:
        SoiltemperatureState();
        double getdeepLayerT();
        void setdeepLayerT(double _deepLayerT);
        double getmaxTSoil();
        void setmaxTSoil(double _maxTSoil);
        double getminTSoil();
        void setminTSoil(double _minTSoil);
        array<>& & gethourlySoilT();
        void sethourlySoilT(array<>&  _hourlySoilT);

};
#endif