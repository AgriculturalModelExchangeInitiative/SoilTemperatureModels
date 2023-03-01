
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfaceSWATSoilSWATC.DomainClass
{
    public class SurfaceSWATSoilSWATCRateVarInfo : IVarInfoClass
    {

        static SurfaceSWATSoilSWATCRateVarInfo()
        {
            SurfaceSWATSoilSWATCRateVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SurfaceSWATSoilSWATCRate Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SurfaceSWATSoilSWATCRate";}
        }

        static void DescribeVariables()
        {
        }

    }
}