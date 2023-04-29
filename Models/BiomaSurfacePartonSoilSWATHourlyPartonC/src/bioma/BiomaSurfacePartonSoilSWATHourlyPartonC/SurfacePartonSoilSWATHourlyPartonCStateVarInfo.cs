
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfacePartonSoilSWATHourlyPartonC.DomainClass
{
    public class SurfacePartonSoilSWATHourlyPartonCStateVarInfo : IVarInfoClass
    {
        static VarInfo _AboveGroundBiomass = new VarInfo();
        static VarInfo _VolumetricWaterContent = new VarInfo();
        static VarInfo _BulkDensity = new VarInfo();
        static VarInfo _LayerThickness = new VarInfo();
        static VarInfo _SoilProfileDepth = new VarInfo();
        static VarInfo _Sand = new VarInfo();
        static VarInfo _OrganicMatter = new VarInfo();
        static VarInfo _Clay = new VarInfo();
        static VarInfo _Silt = new VarInfo();
        static VarInfo _SurfaceSoilTemperature = new VarInfo();
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

        public static  VarInfo AboveGroundBiomass
        {
            get { return _AboveGroundBiomass;}
        }

        public static  VarInfo VolumetricWaterContent
        {
            get { return _VolumetricWaterContent;}
        }

        public static  VarInfo BulkDensity
        {
            get { return _BulkDensity;}
        }

        public static  VarInfo LayerThickness
        {
            get { return _LayerThickness;}
        }

        public static  VarInfo SoilProfileDepth
        {
            get { return _SoilProfileDepth;}
        }

        public static  VarInfo Sand
        {
            get { return _Sand;}
        }

        public static  VarInfo OrganicMatter
        {
            get { return _OrganicMatter;}
        }

        public static  VarInfo Clay
        {
            get { return _Clay;}
        }

        public static  VarInfo Silt
        {
            get { return _Silt;}
        }

        public static  VarInfo SurfaceSoilTemperature
        {
            get { return _SurfaceSoilTemperature;}
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
            _AboveGroundBiomass.Name = "AboveGroundBiomass";
            _AboveGroundBiomass.Description = "Above ground biomass";
            _AboveGroundBiomass.MaxValue = 60;
            _AboveGroundBiomass.MinValue = 0;
            _AboveGroundBiomass.DefaultValue = 3;
            _AboveGroundBiomass.Units = "Kg ha-1";
            _AboveGroundBiomass.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _VolumetricWaterContent.Name = "VolumetricWaterContent";
            _VolumetricWaterContent.Description = "Volumetric soil water content";
            _VolumetricWaterContent.MaxValue = -1D;
            _VolumetricWaterContent.MinValue = -1D;
            _VolumetricWaterContent.DefaultValue = -1D;
            _VolumetricWaterContent.Units = "m3 m-3";
            _VolumetricWaterContent.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _BulkDensity.Name = "BulkDensity";
            _BulkDensity.Description = "Bulk density";
            _BulkDensity.MaxValue = -1D;
            _BulkDensity.MinValue = -1D;
            _BulkDensity.DefaultValue = -1D;
            _BulkDensity.Units = "t m-3";
            _BulkDensity.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _LayerThickness.Name = "LayerThickness";
            _LayerThickness.Description = "Soil layer thickness";
            _LayerThickness.MaxValue = -1D;
            _LayerThickness.MinValue = -1D;
            _LayerThickness.DefaultValue = -1D;
            _LayerThickness.Units = "m";
            _LayerThickness.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _SoilProfileDepth.Name = "SoilProfileDepth";
            _SoilProfileDepth.Description = "Soil profile depth";
            _SoilProfileDepth.MaxValue = 50;
            _SoilProfileDepth.MinValue = 0;
            _SoilProfileDepth.DefaultValue = 3;
            _SoilProfileDepth.Units = "m";
            _SoilProfileDepth.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _Sand.Name = "Sand";
            _Sand.Description = "Sand content of soil layer";
            _Sand.MaxValue = -1D;
            _Sand.MinValue = -1D;
            _Sand.DefaultValue = -1D;
            _Sand.Units = "%";
            _Sand.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _OrganicMatter.Name = "OrganicMatter";
            _OrganicMatter.Description = "Organic matter content of soil layer";
            _OrganicMatter.MaxValue = -1D;
            _OrganicMatter.MinValue = -1D;
            _OrganicMatter.DefaultValue = -1D;
            _OrganicMatter.Units = "%";
            _OrganicMatter.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _Clay.Name = "Clay";
            _Clay.Description = "Clay content of soil layer";
            _Clay.MaxValue = -1D;
            _Clay.MinValue = -1D;
            _Clay.DefaultValue = -1D;
            _Clay.Units = "%";
            _Clay.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _Silt.Name = "Silt";
            _Silt.Description = "Silt content of soil layer";
            _Silt.MaxValue = -1D;
            _Silt.MinValue = -1D;
            _Silt.DefaultValue = -1D;
            _Silt.Units = "%";
            _Silt.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _SurfaceSoilTemperature.Name = "SurfaceSoilTemperature";
            _SurfaceSoilTemperature.Description = "Average surface soil temperature";
            _SurfaceSoilTemperature.MaxValue = 60;
            _SurfaceSoilTemperature.MinValue = -60;
            _SurfaceSoilTemperature.DefaultValue = -1D;
            _SurfaceSoilTemperature.Units = "Â°C";
            _SurfaceSoilTemperature.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _SoilTemperatureByLayers.Name = "SoilTemperatureByLayers";
            _SoilTemperatureByLayers.Description = "Soil temperature of each layer";
            _SoilTemperatureByLayers.MaxValue = -1D;
            _SoilTemperatureByLayers.MinValue = -1D;
            _SoilTemperatureByLayers.DefaultValue = -1D;
            _SoilTemperatureByLayers.Units = "Â°C";
            _SoilTemperatureByLayers.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _HeatCapacity.Name = "HeatCapacity";
            _HeatCapacity.Description = "Volumetric specific heat of soil";
            _HeatCapacity.MaxValue = -1D;
            _HeatCapacity.MinValue = -1D;
            _HeatCapacity.DefaultValue = -1D;
            _HeatCapacity.Units = "MJ m-3 Â°C-1";
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
            _SoilTemperatureRangeByLayers.Units = "Â°C";
            _SoilTemperatureRangeByLayers.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _SoilTemperatureMinimum.Name = "SoilTemperatureMinimum";
            _SoilTemperatureMinimum.Description = "Minimum soil temperature by layers";
            _SoilTemperatureMinimum.MaxValue = -1D;
            _SoilTemperatureMinimum.MinValue = -1D;
            _SoilTemperatureMinimum.DefaultValue = -1D;
            _SoilTemperatureMinimum.Units = "Â°C";
            _SoilTemperatureMinimum.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _SoilTemperatureMaximum.Name = "SoilTemperatureMaximum";
            _SoilTemperatureMaximum.Description = "Maximum soil temperature by layers";
            _SoilTemperatureMaximum.MaxValue = -1D;
            _SoilTemperatureMaximum.MinValue = -1D;
            _SoilTemperatureMaximum.DefaultValue = -1D;
            _SoilTemperatureMaximum.Units = "Â°C";
            _SoilTemperatureMaximum.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _SoilTemperatureByLayersHourly.Name = "SoilTemperatureByLayersHourly";
            _SoilTemperatureByLayersHourly.Description = "Hourly soil temperature by layers";
            _SoilTemperatureByLayersHourly.MaxValue = -1D;
            _SoilTemperatureByLayersHourly.MinValue = -1D;
            _SoilTemperatureByLayersHourly.DefaultValue = -1D;
            _SoilTemperatureByLayersHourly.Units = "Â°C";
            _SoilTemperatureByLayersHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

        }

    }
}