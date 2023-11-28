#include "SurfaceTemperatureParton.h"
#include "SoilTemperatureSWAT.h"
using namespace std;

class SurfacePartonSoilSWATCComponent
{
    private:
        double AirTemperatureAnnualAverage ;
        vector<double> BulkDensity ;
        vector<double> LayerThickness ;
        double LagCoefficient ;
        double SoilProfileDepth ;
    public:
        SurfacePartonSoilSWATCComponent();
        SurfacePartonSoilSWATCComponent(SurfacePartonSoilSWATCComponent& copy);
        void  Calculate_Model(SurfacePartonSoilSWATCState& s, SurfacePartonSoilSWATCState& s1, SurfacePartonSoilSWATCRate& r, SurfacePartonSoilSWATCAuxiliary& a, SurfacePartonSoilSWATCExogenous& ex);
        void  Init(SurfacePartonSoilSWATCState& s,SurfacePartonSoilSWATCState& s1, SurfacePartonSoilSWATCRate& r, SurfacePartonSoilSWATCAuxiliary& a, SurfacePartonSoilSWATCExogenous& ex);
        double getAirTemperatureAnnualAverage();
        void setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage);
        vector<double> & getBulkDensity();
        void setBulkDensity(const vector<double> &  _BulkDensity);
        vector<double> & getLayerThickness();
        void setLayerThickness(const vector<double> &  _LayerThickness);
        double getLagCoefficient();
        void setLagCoefficient(double _LagCoefficient);
        double getSoilProfileDepth();
        void setSoilProfileDepth(double _SoilProfileDepth);

        SurfaceTemperatureParton _SurfaceTemperatureParton;
        SoilTemperatureSWAT _SoilTemperatureSWAT;

};