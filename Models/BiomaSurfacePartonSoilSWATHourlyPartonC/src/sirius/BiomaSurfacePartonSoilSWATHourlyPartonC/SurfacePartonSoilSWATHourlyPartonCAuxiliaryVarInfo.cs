
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass
{
    public class SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo : IVarInfoClass
    {
        static VarInfo _AboveGroundBiomass = new VarInfo();
        static VarInfo _VolumetricWaterContent = new VarInfo();
        static VarInfo _OrganicMatter = new VarInfo();
        static VarInfo _Sand = new VarInfo();
        static VarInfo _SurfaceSoilTemperature = new VarInfo();
        static VarInfo _SurfaceTemperatureMinimum = new VarInfo();
        static VarInfo _SurfaceTemperatureMaximum = new VarInfo();
        static VarInfo _ThermalConductivity = new VarInfo();
        static VarInfo _SoilTemperatureRangeByLayers = new VarInfo();
        static VarInfo _SoilTemperatureMinimum = new VarInfo();
        static VarInfo _SoilTemperatureMaximum = new VarInfo();

        static SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo()
        {
            SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SurfacePartonSoilSWATHourlyPartonCAuxiliary Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SurfacePartonSoilSWATHourlyPartonCAuxiliary";}
        }

        public static  VarInfo AboveGroundBiomass
        {
            get { return _AboveGroundBiomass;}
        }

        public static  VarInfo VolumetricWaterContent
        {
            get { return _VolumetricWaterContent;}
        }

        public static  VarInfo OrganicMatter
        {
            get { return _OrganicMatter;}
        }

        public static  VarInfo Sand
        {
            get { return _Sand;}
        }

        public static  VarInfo SurfaceSoilTemperature
        {
            get { return _SurfaceSoilTemperature;}
        }

        public static  VarInfo SurfaceTemperatureMinimum
        {
            get { return _SurfaceTemperatureMinimum;}
        }

        public static  VarInfo SurfaceTemperatureMaximum
        {
            get { return _SurfaceTemperatureMaximum;}
        }

        public static  VarInfo ThermalConductivity
        {
            get { return _ThermalConductivity;}
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

            _OrganicMatter.Name = "OrganicMatter";
            _OrganicMatter.Description = "Organic matter content of soil layer";
            _OrganicMatter.MaxValue = -1D;
            _OrganicMatter.MinValue = -1D;
            _OrganicMatter.DefaultValue = -1D;
            _OrganicMatter.Units = "";
            _OrganicMatter.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _Sand.Name = "Sand";
            _Sand.Description = "Sand content of soil layer";
            _Sand.MaxValue = -1D;
            _Sand.MinValue = -1D;
            _Sand.DefaultValue = -1D;
            _Sand.Units = "";
            _Sand.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _SurfaceSoilTemperature.Name = "SurfaceSoilTemperature";
            _SurfaceSoilTemperature.Description = "Average surface soil temperature";
            _SurfaceSoilTemperature.MaxValue = 60;
            _SurfaceSoilTemperature.MinValue = -60;
            _SurfaceSoilTemperature.DefaultValue = -1D;
            _SurfaceSoilTemperature.Units = "degC";
            _SurfaceSoilTemperature.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _SurfaceTemperatureMinimum.Name = "SurfaceTemperatureMinimum";
            _SurfaceTemperatureMinimum.Description = "Minimum surface soil temperature";
            _SurfaceTemperatureMinimum.MaxValue = 60;
            _SurfaceTemperatureMinimum.MinValue = -60;
            _SurfaceTemperatureMinimum.DefaultValue = -1D;
            _SurfaceTemperatureMinimum.Units = "";
            _SurfaceTemperatureMinimum.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _SurfaceTemperatureMaximum.Name = "SurfaceTemperatureMaximum";
            _SurfaceTemperatureMaximum.Description = "Maximum surface soil temperature";
            _SurfaceTemperatureMaximum.MaxValue = 60;
            _SurfaceTemperatureMaximum.MinValue = -60;
            _SurfaceTemperatureMaximum.DefaultValue = -1D;
            _SurfaceTemperatureMaximum.Units = "degC             */";
            _SurfaceTemperatureMaximum.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _ThermalConductivity.Name = "ThermalConductivity";
            _ThermalConductivity.Description = "Thermal conductivity of soil layer";
            _ThermalConductivity.MaxValue = -1D;
            _ThermalConductivity.MinValue = -1D;
            _ThermalConductivity.DefaultValue = -1D;
            _ThermalConductivity.Units = "W m-1 K-1";
            _ThermalConductivity.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

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
            _SoilTemperatureMinimum.Units = "";
            _SoilTemperatureMinimum.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _SoilTemperatureMaximum.Name = "SoilTemperatureMaximum";
            _SoilTemperatureMaximum.Description = "Maximum soil temperature by layers";
            _SoilTemperatureMaximum.MaxValue = -1D;
            _SoilTemperatureMaximum.MinValue = -1D;
            _SoilTemperatureMaximum.DefaultValue = -1D;
            _SoilTemperatureMaximum.Units = "degC";
            _SoilTemperatureMaximum.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

        }

    }
}