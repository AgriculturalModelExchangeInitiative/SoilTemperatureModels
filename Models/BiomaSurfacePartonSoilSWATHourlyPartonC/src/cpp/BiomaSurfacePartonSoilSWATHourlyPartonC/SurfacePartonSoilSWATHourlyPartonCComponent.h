#include "SurfaceTemperatureParton.h"
#include "SoilTemperatureSWAT.h"
#include "VolumetricHeatCapacityKluitenberg.h"
#include "ThermalConductivitySIMULAT.h"
#include "ThermalDiffu.h"
#include "RangeOfSoilTemperaturesDAYCENT.h"
#include "HourlySoilTemperaturesPartonLogan.h"

namespace BiomaSurfacePartonSoilSWATHourlyPartonC {
class SurfacePartonSoilSWATHourlyPartonCComponent
{
    private:
        std::vector<double> BulkDensity ;
        double SoilProfileDepth ;
        double AirTemperatureAnnualAverage ;
        double LagCoefficient ;
        std::vector<double> LayerThickness ;
        std::vector<double> Clay ;
        std::vector<double> Silt ;
        int layersNumber ;
    public:
        SurfacePartonSoilSWATHourlyPartonCComponent();
        SurfacePartonSoilSWATHourlyPartonCComponent(SurfacePartonSoilSWATHourlyPartonCComponent& copy);
        void Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState &s, SurfacePartonSoilSWATHourlyPartonCState &s1, SurfacePartonSoilSWATHourlyPartonCRate &r, SurfacePartonSoilSWATHourlyPartonCAuxiliary &a, SurfacePartonSoilSWATHourlyPartonCExogenous &ex);
        void Init(SurfacePartonSoilSWATHourlyPartonCState &s, SurfacePartonSoilSWATHourlyPartonCState &s1, SurfacePartonSoilSWATHourlyPartonCRate &r, SurfacePartonSoilSWATHourlyPartonCAuxiliary &a, SurfacePartonSoilSWATHourlyPartonCExogenous &ex);
        std::vector<double> & getBulkDensity();
        void setBulkDensity(const std::vector<double> &  _BulkDensity);
        double getSoilProfileDepth();
        void setSoilProfileDepth(double _SoilProfileDepth);
        double getAirTemperatureAnnualAverage();
        void setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage);
        double getLagCoefficient();
        void setLagCoefficient(double _LagCoefficient);
        std::vector<double> & getLayerThickness();
        void setLayerThickness(const std::vector<double> &  _LayerThickness);
        std::vector<double> & getClay();
        void setClay(const std::vector<double> &  _Clay);
        std::vector<double> & getSilt();
        void setSilt(const std::vector<double> &  _Silt);
        int getlayersNumber();
        void setlayersNumber(int _layersNumber);

        SurfaceTemperatureParton _SurfaceTemperatureParton;
        SoilTemperatureSWAT _SoilTemperatureSWAT;
        VolumetricHeatCapacityKluitenberg _VolumetricHeatCapacityKluitenberg;
        ThermalConductivitySIMULAT _ThermalConductivitySIMULAT;
        ThermalDiffu _ThermalDiffu;
        RangeOfSoilTemperaturesDAYCENT _RangeOfSoilTemperaturesDAYCENT;
        HourlySoilTemperaturesPartonLogan _HourlySoilTemperaturesPartonLogan;

};
}
