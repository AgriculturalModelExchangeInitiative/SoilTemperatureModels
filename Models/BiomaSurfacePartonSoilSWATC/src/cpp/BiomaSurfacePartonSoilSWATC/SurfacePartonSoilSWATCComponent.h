#include "SurfaceTemperatureParton.h"
#include "SoilTemperatureSWAT.h"

namespace BiomaSurfacePartonSoilSWATC {
class SurfacePartonSoilSWATCComponent
{
    private:
        std::vector<double> LayerThickness ;
        std::vector<double> BulkDensity ;
        double SoilProfileDepth ;
        double AirTemperatureAnnualAverage ;
        double LagCoefficient ;
    public:
        SurfacePartonSoilSWATCComponent();
        SurfacePartonSoilSWATCComponent(SurfacePartonSoilSWATCComponent& copy);
        void Calculate_Model(SurfacePartonSoilSWATCState &s, SurfacePartonSoilSWATCState &s1, SurfacePartonSoilSWATCRate &r, SurfacePartonSoilSWATCAuxiliary &a, SurfacePartonSoilSWATCExogenous &ex);
        void Init(SurfacePartonSoilSWATCState &s, SurfacePartonSoilSWATCState &s1, SurfacePartonSoilSWATCRate &r, SurfacePartonSoilSWATCAuxiliary &a, SurfacePartonSoilSWATCExogenous &ex);
        std::vector<double> & getLayerThickness();
        void setLayerThickness(const std::vector<double> &  _LayerThickness);
        std::vector<double> & getBulkDensity();
        void setBulkDensity(const std::vector<double> &  _BulkDensity);
        double getSoilProfileDepth();
        void setSoilProfileDepth(double _SoilProfileDepth);
        double getAirTemperatureAnnualAverage();
        void setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage);
        double getLagCoefficient();
        void setLagCoefficient(double _LagCoefficient);

        SurfaceTemperatureParton _SurfaceTemperatureParton;
        SoilTemperatureSWAT _SoilTemperatureSWAT;

};
}
