using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace SurfacePartonSoilSWATC.DomainClass
{
    public interface IStrategySurfacePartonSoilSWATC : IStrategy
    {
        void Estimate( SurfacePartonSoilSWATCState s, SurfacePartonSoilSWATCState s1, SurfacePartonSoilSWATCRate r, SurfacePartonSoilSWATCAuxiliary a, SurfacePartonSoilSWATCExogenous ex);

        string TestPreConditions( SurfacePartonSoilSWATCState s, SurfacePartonSoilSWATCState s1, SurfacePartonSoilSWATCRate r, SurfacePartonSoilSWATCAuxiliary a, SurfacePartonSoilSWATCExogenous ex, string callID);

        string TestPostConditions( SurfacePartonSoilSWATCState s, SurfacePartonSoilSWATCState s1, SurfacePartonSoilSWATCRate r, SurfacePartonSoilSWATCAuxiliary a, SurfacePartonSoilSWATCExogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}