
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace STEMP_.DomainClass
{
    public class STEMP_AuxiliaryVarInfo : IVarInfoClass
    {

        static STEMP_AuxiliaryVarInfo()
        {
            STEMP_AuxiliaryVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "STEMP_Auxiliary Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "STEMP_Auxiliary";}
        }

        static void DescribeVariables()
        {
        }

    }
}