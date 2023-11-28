#ifndef _SurfacePartonSoilSWATCState_
#define _SurfacePartonSoilSWATCState_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class SurfacePartonSoilSWATCState
{
    private:
        vector<double> SoilTemperatureByLayers ;
    public:
        SurfacePartonSoilSWATCState();
        vector<double> & getSoilTemperatureByLayers();
        void setSoilTemperatureByLayers(const vector<double> &  _SoilTemperatureByLayers);

};
#endif