
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass
{
    public class SurfacePartonSoilSWATHourlyPartonCRateVarInfo : IVarInfoClass
    {

        static SurfacePartonSoilSWATHourlyPartonCRateVarInfo()
        {
            SurfacePartonSoilSWATHourlyPartonCRateVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SurfacePartonSoilSWATHourlyPartonCRate Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SurfacePartonSoilSWATHourlyPartonCRate";}
        }

        static void DescribeVariables()
        {
        }

    }
}