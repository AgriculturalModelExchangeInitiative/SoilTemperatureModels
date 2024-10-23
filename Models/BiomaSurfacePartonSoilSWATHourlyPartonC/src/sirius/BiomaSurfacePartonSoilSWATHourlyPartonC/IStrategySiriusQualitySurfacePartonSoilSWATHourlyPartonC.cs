using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass
{
    public interface IStrategySiriusQualitySurfacePartonSoilSWATHourlyPartonC : IStrategy
    {
        void Estimate( SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SurfacePartonSoilSWATHourlyPartonCExogenous ex);

        string TestPreConditions( SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SurfacePartonSoilSWATHourlyPartonCExogenous ex, string callID);

        string TestPostConditions( SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SurfacePartonSoilSWATHourlyPartonCExogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}