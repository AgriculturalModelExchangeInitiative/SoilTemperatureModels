using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace SurfaceSWATSoilSWATC.DomainClass
{
    public interface IStrategySurfaceSWATSoilSWATC : IStrategy
    {
        void Estimate( SurfaceSWATSoilSWATCState s, SurfaceSWATSoilSWATCState s1, SurfaceSWATSoilSWATCRate r, SurfaceSWATSoilSWATCAuxiliary a, SurfaceSWATSoilSWATCExogenous ex);

        string TestPreConditions( SurfaceSWATSoilSWATCState s, SurfaceSWATSoilSWATCState s1, SurfaceSWATSoilSWATCRate r, SurfaceSWATSoilSWATCAuxiliary a, SurfaceSWATSoilSWATCExogenous ex, string callID);

        string TestPostConditions( SurfaceSWATSoilSWATCState s, SurfaceSWATSoilSWATCState s1, SurfaceSWATSoilSWATCRate r, SurfaceSWATSoilSWATCAuxiliary a, SurfaceSWATSoilSWATCExogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}