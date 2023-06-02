
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySTEMP_EPIC_.DomainClass
{
    public class STEMP_EPIC_RateVarInfo : IVarInfoClass
    {

        static STEMP_EPIC_RateVarInfo()
        {
            STEMP_EPIC_RateVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "STEMP_EPIC_Rate Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "STEMP_EPIC_Rate";}
        }

        static void DescribeVariables()
        {
        }

    }
}