
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace STEMP_.DomainClass
{
    public class STEMP_RateVarInfo : IVarInfoClass
    {

        static STEMP_RateVarInfo()
        {
            STEMP_RateVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "STEMP_Rate Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "STEMP_Rate";}
        }

        static void DescribeVariables()
        {
        }

    }
}