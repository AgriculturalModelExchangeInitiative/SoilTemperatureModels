
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass
{
    public class SurfacePartonSoilSWATHourlyPartonCStateVarInfo : IVarInfoClass
    {
        static VarInfo _SoilTemperatureByLayers = new VarInfo();
        static VarInfo _HeatCapacity = new VarInfo();
        static VarInfo _ThermalDiffusivity = new VarInfo();
        static VarInfo _SoilTemperatureByLayersHourly = new VarInfo();

        static SurfacePartonSoilSWATHourlyPartonCStateVarInfo()
        {
            SurfacePartonSoilSWATHourlyPartonCStateVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SurfacePartonSoilSWATHourlyPartonCState Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SurfacePartonSoilSWATHourlyPartonCState";}
        }

        public static  VarInfo SoilTemperatureByLayers
        {
            get { return _SoilTemperatureByLayers;}
        }

        public static  VarInfo HeatCapacity
        {
            get { return _HeatCapacity;}
        }

        public static  VarInfo ThermalDiffusivity
        {
            get { return _ThermalDiffusivity;}
        }

        public static  VarInfo SoilTemperatureByLayersHourly
        {
            get { return _SoilTemperatureByLayersHourly;}
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

            _HeatCapacity.Name = "HeatCapacity";
            _HeatCapacity.Description = "Volumetric specific heat of soil";
            _HeatCapacity.MaxValue = -1D;
            _HeatCapacity.MinValue = -1D;
            _HeatCapacity.DefaultValue = -1D;
            _HeatCapacity.Units = "MJ m-3";
            _HeatCapacity.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _ThermalDiffusivity.Name = "ThermalDiffusivity";
            _ThermalDiffusivity.Description = "Thermal diffusivity of soil layer";
            _ThermalDiffusivity.MaxValue = -1D;
            _ThermalDiffusivity.MinValue = -1D;
            _ThermalDiffusivity.DefaultValue = -1D;
            _ThermalDiffusivity.Units = "mm s-1";
            _ThermalDiffusivity.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _SoilTemperatureByLayersHourly.Name = "SoilTemperatureByLayersHourly";
            _SoilTemperatureByLayersHourly.Description = "Hourly soil temperature by layers";
            _SoilTemperatureByLayersHourly.MaxValue = -1D;
            _SoilTemperatureByLayersHourly.MinValue = -1D;
            _SoilTemperatureByLayersHourly.DefaultValue = -1D;
            _SoilTemperatureByLayersHourly.Units = "degC";
            _SoilTemperatureByLayersHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

        }

    }
}