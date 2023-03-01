using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace STEMP_EPIC_.DomainClass
{
    public interface IStrategySTEMP_EPIC_ : IStrategy
    {
        void Estimate( STEMP_EPIC_State s, STEMP_EPIC_State s1, STEMP_EPIC_Rate r, STEMP_EPIC_Auxiliary a, STEMP_EPIC_Exogenous ex);

        string TestPreConditions( STEMP_EPIC_State s, STEMP_EPIC_State s1, STEMP_EPIC_Rate r, STEMP_EPIC_Auxiliary a, STEMP_EPIC_Exogenous ex, string callID);

        string TestPostConditions( STEMP_EPIC_State s, STEMP_EPIC_State s1, STEMP_EPIC_Rate r, STEMP_EPIC_Auxiliary a, STEMP_EPIC_Exogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}