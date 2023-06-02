#ifndef _SoilTemperatureAuxiliary_
#define _SoilTemperatureAuxiliary_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class SoilTemperatureAuxiliary
{
    private:
        double SnowIsolationIndex ;
    public:
        SoilTemperatureAuxiliary();
        double getSnowIsolationIndex();
        void setSnowIsolationIndex(double _SnowIsolationIndex);

};
#endif