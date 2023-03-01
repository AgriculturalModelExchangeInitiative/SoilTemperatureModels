
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfacePartonSoilSWATC.DomainClass
{
    public class SurfacePartonSoilSWATCRateVarInfo : IVarInfoClass
    {

        static SurfacePartonSoilSWATCRateVarInfo()
        {
            SurfacePartonSoilSWATCRateVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SurfacePartonSoilSWATCRate Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SurfacePartonSoilSWATCRate";}
        }

        static void DescribeVariables()
        {
        }

    }
}