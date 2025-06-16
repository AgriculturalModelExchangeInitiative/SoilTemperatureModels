#include "SurfaceTemperatureSWAT.h"
#include "SoilTemperatureSWAT.h"

namespace BiomaSurfaceSWATSoilSWATC {
class SurfaceSWATSoilSWATCComponent
{
private:
    std::vector<double> BulkDensity;
    double AirTemperatureAnnualAverage{15};
    double SoilProfileDepth{3};
    double LagCoefficient{0.8};
    std::vector<double> LayerThickness;
public:
    SurfaceSWATSoilSWATCComponent();

    SurfaceSWATSoilSWATCComponent(SurfaceSWATSoilSWATCComponent& copy);

    void Calculate_Model(SurfaceSWATSoilSWATCState &s, SurfaceSWATSoilSWATCState &s1, SurfaceSWATSoilSWATCRate &r, SurfaceSWATSoilSWATCAuxiliary &a, SurfaceSWATSoilSWATCExogenous &ex);

    void Init(SurfaceSWATSoilSWATCState &s, SurfaceSWATSoilSWATCState &s1, SurfaceSWATSoilSWATCRate &r, SurfaceSWATSoilSWATCAuxiliary &a, SurfaceSWATSoilSWATCExogenous &ex);

    std::vector<double> & getBulkDensity();
    void setBulkDensity(const std::vector<double> &  _BulkDensity);

    double getAirTemperatureAnnualAverage();
    void setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage);

    double getSoilProfileDepth();
    void setSoilProfileDepth(double _SoilProfileDepth);

    double getLagCoefficient();
    void setLagCoefficient(double _LagCoefficient);

    std::vector<double> & getLayerThickness();
    void setLayerThickness(const std::vector<double> &  _LayerThickness);

    SurfaceTemperatureSWAT _SurfaceTemperatureSWAT;
    SoilTemperatureSWAT _SoilTemperatureSWAT;

};
}