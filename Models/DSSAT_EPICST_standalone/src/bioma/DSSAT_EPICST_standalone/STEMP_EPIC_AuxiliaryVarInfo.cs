
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace STEMP_EPIC_.DomainClass
{
    public class STEMP_EPIC_AuxiliaryVarInfo : IVarInfoClass
    {

        static STEMP_EPIC_AuxiliaryVarInfo()
        {
            STEMP_EPIC_AuxiliaryVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "STEMP_EPIC_Auxiliary Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "STEMP_EPIC_Auxiliary";}
        }

        static void DescribeVariables()
        {
        }

    }
}