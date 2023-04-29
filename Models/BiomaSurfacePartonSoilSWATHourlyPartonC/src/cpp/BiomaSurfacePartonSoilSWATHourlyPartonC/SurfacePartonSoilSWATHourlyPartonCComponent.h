#include "SurfaceTemperatureParton.h"
#include "SoilTemperatureSWAT.h"
#include "VolumetricHeatCapacityKluitenberg.h"
#include "ThermalConductivitySIMULAT.h"
#include "ThermalDiffu.h"
#include "RangeOfSoilTemperaturesDAYCENT.h"
#include "HourlySoilTemperaturesPartonLogan.h"
using namespace std;

class SurfacePartonSoilSWATHourlyPartonCComponent
{
    private:
        double LagCoefficient ;
    public:
        SurfacePartonSoilSWATHourlyPartonCComponent();
        SurfacePartonSoilSWATHourlyPartonCComponent(const SurfacePartonSoilSWATHourlyPartonCComponent& copy);
        void  Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState& s, SurfacePartonSoilSWATHourlyPartonCState& s1, SurfacePartonSoilSWATHourlyPartonCRate& r, SurfacePartonSoilSWATHourlyPartonCAuxiliary& a, SurfacePartonSoilSWATHourlyPartonCExogenous& ex);
        void  Init(SurfacePartonSoilSWATHourlyPartonCState& s,SurfacePartonSoilSWATHourlyPartonCState& s1, SurfacePartonSoilSWATHourlyPartonCRate& r, SurfacePartonSoilSWATHourlyPartonCAuxiliary& a, SurfacePartonSoilSWATHourlyPartonCExogenous& ex);
        double getLagCoefficient();
        void setLagCoefficient(double _LagCoefficient);

        SurfaceTemperatureParton _SurfaceTemperatureParton;
        SoilTemperatureSWAT _SoilTemperatureSWAT;
        VolumetricHeatCapacityKluitenberg _VolumetricHeatCapacityKluitenberg;
        ThermalConductivitySIMULAT _ThermalConductivitySIMULAT;
        ThermalDiffu _ThermalDiffu;
        RangeOfSoilTemperaturesDAYCENT _RangeOfSoilTemperaturesDAYCENT;
        HourlySoilTemperaturesPartonLogan _HourlySoilTemperaturesPartonLogan;

};