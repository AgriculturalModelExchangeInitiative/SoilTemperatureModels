#include "SurfaceTemperatureParton.h"
#include "SoilTemperatureSWAT.h"
using namespace std;

class SurfacePartonSoilSWATCComponent
{
    private:
        double LagCoefficient ;
    public:
        SurfacePartonSoilSWATCComponent();
        SurfacePartonSoilSWATCComponent(const SurfacePartonSoilSWATCComponent& copy);
        void  Calculate_Model(SurfacePartonSoilSWATCState& s, SurfacePartonSoilSWATCState& s1, SurfacePartonSoilSWATCRate& r, SurfacePartonSoilSWATCAuxiliary& a, SurfacePartonSoilSWATCExogenous& ex);
        void  Init(SurfacePartonSoilSWATCState& s,SurfacePartonSoilSWATCState& s1, SurfacePartonSoilSWATCRate& r, SurfacePartonSoilSWATCAuxiliary& a, SurfacePartonSoilSWATCExogenous& ex);
        double getLagCoefficient();
        void setLagCoefficient(double _LagCoefficient);

        SurfaceTemperatureParton _SurfaceTemperatureParton;
        SoilTemperatureSWAT _SoilTemperatureSWAT;

};