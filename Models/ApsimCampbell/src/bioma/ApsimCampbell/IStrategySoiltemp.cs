using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace Soiltemp.DomainClass
{
    public interface IStrategySoiltemp : IStrategy
    {
        void Estimate( SoiltempState s, SoiltempState s1, SoiltempRate r, SoiltempAuxiliary a, SoiltempExogenous ex);

        string TestPreConditions( SoiltempState s, SoiltempState s1, SoiltempRate r, SoiltempAuxiliary a, SoiltempExogenous ex, string callID);

        string TestPostConditions( SoiltempState s, SoiltempState s1, SoiltempRate r, SoiltempAuxiliary a, SoiltempExogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}