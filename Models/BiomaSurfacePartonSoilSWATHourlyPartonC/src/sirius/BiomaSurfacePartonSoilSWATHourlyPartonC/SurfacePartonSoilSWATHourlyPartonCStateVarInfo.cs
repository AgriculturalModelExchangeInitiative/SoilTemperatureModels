
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
        static VarInfo _ThermalConductivity = new VarInfo();
        static VarInfo _ThermalDiffusivity = new VarInfo();
        static VarInfo _SoilTemperatureRangeByLayers = new VarInfo();
        static VarInfo _SoilTemperatureMinimum = new VarInfo();
        static VarInfo _SoilTemperatureMaximum = new VarInfo();
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

        public static  VarInfo ThermalConductivity
        {
            get { return _ThermalConductivity;}
        }

        public static  VarInfo ThermalDiffusivity
        {
            get { return _ThermalDiffusivity;}
        }

        public static  VarInfo SoilTemperatureRangeByLayers
        {
            get { return _SoilTemperatureRangeByLayers;}
        }

        public static  VarInfo SoilTemperatureMinimum
        {
            get { return _SoilTemperatureMinimum;}
        }

        public static  VarInfo SoilTemperatureMaximum
        {
            get { return _SoilTemperatureMaximum;}
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

            _ThermalConductivity.Name = "ThermalConductivity";
            _ThermalConductivity.Description = "Thermal conductivity of soil layer";
            _ThermalConductivity.MaxValue = -1D;
            _ThermalConductivity.MinValue = -1D;
            _ThermalConductivity.DefaultValue = -1D;
            _ThermalConductivity.Units = "W m-1 K-1";
            _ThermalConductivity.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _ThermalDiffusivity.Name = "ThermalDiffusivity";
            _ThermalDiffusivity.Description = "Thermal diffusivity of soil layer";
            _ThermalDiffusivity.MaxValue = -1D;
            _ThermalDiffusivity.MinValue = -1D;
            _ThermalDiffusivity.DefaultValue = -1D;
            _ThermalDiffusivity.Units = "mm s-1";
            _ThermalDiffusivity.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _SoilTemperatureRangeByLayers.Name = "SoilTemperatureRangeByLayers";
            _SoilTemperatureRangeByLayers.Description = "Soil temperature range by layers";
            _SoilTemperatureRangeByLayers.MaxValue = -1D;
            _SoilTemperatureRangeByLayers.MinValue = -1D;
            _SoilTemperatureRangeByLayers.DefaultValue = -1D;
            _SoilTemperatureRangeByLayers.Units = "degC";
            _SoilTemperatureRangeByLayers.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _SoilTemperatureMinimum.Name = "SoilTemperatureMinimum";
            _SoilTemperatureMinimum.Description = "Minimum soil temperature by layers";
            _SoilTemperatureMinimum.MaxValue = -1D;
            _SoilTemperatureMinimum.MinValue = -1D;
            _SoilTemperatureMinimum.DefaultValue = -1D;
            _SoilTemperatureMinimum.Units = "degC";
            _SoilTemperatureMinimum.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _SoilTemperatureMaximum.Name = "SoilTemperatureMaximum";
            _SoilTemperatureMaximum.Description = "Maximum soil temperature by layers";
            _SoilTemperatureMaximum.MaxValue = -1D;
            _SoilTemperatureMaximum.MinValue = -1D;
            _SoilTemperatureMaximum.DefaultValue = -1D;
            _SoilTemperatureMaximum.Units = "degC";
            _SoilTemperatureMaximum.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

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