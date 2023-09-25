
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitysoil_temp.DomainClass
{
    public class soil_tempAuxiliaryVarInfo : IVarInfoClass
    {

        static soil_tempAuxiliaryVarInfo()
        {
            soil_tempAuxiliaryVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "soil_tempAuxiliary Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "soil_tempAuxiliary";}
        }

        static void DescribeVariables()
        {
        }

    }
}