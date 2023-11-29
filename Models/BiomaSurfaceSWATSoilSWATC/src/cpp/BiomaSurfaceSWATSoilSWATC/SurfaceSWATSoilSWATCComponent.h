#include "SurfaceTemperatureSWAT.h"
#include "SoilTemperatureSWAT.h"

namespace BiomaSurfaceSWATSoilSWATC {
class SurfaceSWATSoilSWATCComponent
{
    private:
        double AirTemperatureAnnualAverage ;
        double SoilProfileDepth ;
        std::vector<double> BulkDensity ;
        std::vector<double> LayerThickness ;
        double LagCoefficient ;
    public:
        SurfaceSWATSoilSWATCComponent();
        SurfaceSWATSoilSWATCComponent(SurfaceSWATSoilSWATCComponent& copy);
        void Calculate_Model(SurfaceSWATSoilSWATCState &s, SurfaceSWATSoilSWATCState &s1, SurfaceSWATSoilSWATCRate &r, SurfaceSWATSoilSWATCAuxiliary &a, SurfaceSWATSoilSWATCExogenous &ex);
        void Init(SurfaceSWATSoilSWATCState &s, SurfaceSWATSoilSWATCState &s1, SurfaceSWATSoilSWATCRate &r, SurfaceSWATSoilSWATCAuxiliary &a, SurfaceSWATSoilSWATCExogenous &ex);
        double getAirTemperatureAnnualAverage();
        void setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage);
        double getSoilProfileDepth();
        void setSoilProfileDepth(double _SoilProfileDepth);
        std::vector<double> & getBulkDensity();
        void setBulkDensity(const std::vector<double> &  _BulkDensity);
        std::vector<double> & getLayerThickness();
        void setLayerThickness(const std::vector<double> &  _LayerThickness);
        double getLagCoefficient();
        void setLagCoefficient(double _LagCoefficient);

        SurfaceTemperatureSWAT _SurfaceTemperatureSWAT;
        SoilTemperatureSWAT _SoilTemperatureSWAT;

};
}
