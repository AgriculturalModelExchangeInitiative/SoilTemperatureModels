
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace soil_temp.DomainClass
{
    public class soil_tempRateVarInfo : IVarInfoClass
    {

        static soil_tempRateVarInfo()
        {
            soil_tempRateVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "soil_tempRate Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "soil_tempRate";}
        }

        static void DescribeVariables()
        {
        }

    }
}