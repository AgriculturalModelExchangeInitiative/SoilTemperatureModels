
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfaceSWATSoilSWATC.DomainClass
{
    public class SurfaceSWATSoilSWATCAuxiliaryVarInfo : IVarInfoClass
    {

        static SurfaceSWATSoilSWATCAuxiliaryVarInfo()
        {
            SurfaceSWATSoilSWATCAuxiliaryVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SurfaceSWATSoilSWATCAuxiliary Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SurfaceSWATSoilSWATCAuxiliary";}
        }

        static void DescribeVariables()
        {
        }

    }
}