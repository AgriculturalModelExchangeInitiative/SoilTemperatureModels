
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySurfaceSWATSoilSWATC.DomainClass
{
    public class SurfaceSWATSoilSWATCStateVarInfo : IVarInfoClass
    {
        static VarInfo _SoilTemperatureByLayers = new VarInfo();

        static SurfaceSWATSoilSWATCStateVarInfo()
        {
            SurfaceSWATSoilSWATCStateVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SurfaceSWATSoilSWATCState Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SurfaceSWATSoilSWATCState";}
        }

        public static  VarInfo SoilTemperatureByLayers
        {
            get { return _SoilTemperatureByLayers;}
        }

        static void DescribeVariables()
        {
            _SoilTemperatureByLayers.Name = "SoilTemperatureByLayers";
            _SoilTemperatureByLayers.Description = "Soil temperature of each layer";
            _SoilTemperatureByLayers.MaxValue = -1D;
            _SoilTemperatureByLayers.MinValue = -1D;
            _SoilTemperatureByLayers.DefaultValue = -1D;
            _SoilTemperatureByLayers.Units = "degC";
            _SoilTemperatureByLayers.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

        }

    }
}