
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SoilTemperature.DomainClass
{
    public class SoilTemperatureAuxiliaryVarInfo : IVarInfoClass
    {

        static SoilTemperatureAuxiliaryVarInfo()
        {
            SoilTemperatureAuxiliaryVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SoilTemperatureAuxiliary Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SoilTemperatureAuxiliary";}
        }

        static void DescribeVariables()
        {
        }

    }
}