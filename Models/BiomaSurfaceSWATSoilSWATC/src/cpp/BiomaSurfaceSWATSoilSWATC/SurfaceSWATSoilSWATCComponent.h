#include "SurfaceTemperatureSWAT.h"
#include "SoilTemperatureSWAT.h"
using namespace std;

class SurfaceSWATSoilSWATCComponent
{
    private:
        double LagCoefficient ;
    public:
        SurfaceSWATSoilSWATCComponent();
        SurfaceSWATSoilSWATCComponent(const SurfaceSWATSoilSWATCComponent& copy);
        void  Calculate_Model(SurfaceSWATSoilSWATCState& s, SurfaceSWATSoilSWATCState& s1, SurfaceSWATSoilSWATCRate& r, SurfaceSWATSoilSWATCAuxiliary& a, SurfaceSWATSoilSWATCExogenous& ex);
        void  Init(SurfaceSWATSoilSWATCState& s,SurfaceSWATSoilSWATCState& s1, SurfaceSWATSoilSWATCRate& r, SurfaceSWATSoilSWATCAuxiliary& a, SurfaceSWATSoilSWATCExogenous& ex);
        double getLagCoefficient();
        void setLagCoefficient(double _LagCoefficient);

        SurfaceTemperatureSWAT _SurfaceTemperatureSWAT;
        SoilTemperatureSWAT _SoilTemperatureSWAT;

};