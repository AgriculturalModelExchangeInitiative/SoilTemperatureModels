
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySoilTemperature.DomainClass
{
    public class SoilTemperatureRateVarInfo : IVarInfoClass
    {
        static VarInfo _heatFlux = new VarInfo();

        static SoilTemperatureRateVarInfo()
        {
            SoilTemperatureRateVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SoilTemperatureRate Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SoilTemperatureRate";}
        }

        public static  VarInfo heatFlux
        {
            get { return _heatFlux;}
        }

        static void DescribeVariables()
        {
            _heatFlux.Name = "heatFlux";
            _heatFlux.Description = "Soil Heat Flux from Energy Balance Component";
            _heatFlux.MaxValue = 100;
            _heatFlux.MinValue = 0;
            _heatFlux.DefaultValue = 50;
            _heatFlux.Units = "g m-2 d-1";
            _heatFlux.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

        }

    }
}