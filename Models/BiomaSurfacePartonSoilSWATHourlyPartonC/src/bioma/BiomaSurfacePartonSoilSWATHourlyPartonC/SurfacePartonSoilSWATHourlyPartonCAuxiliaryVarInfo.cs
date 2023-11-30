
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfacePartonSoilSWATHourlyPartonC.DomainClass
{
    public class SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo : IVarInfoClass
    {
        static VarInfo _AboveGroundBiomass = new VarInfo();
        static VarInfo _Sand = new VarInfo();
        static VarInfo _OrganicMatter = new VarInfo();
        static VarInfo _SurfaceSoilTemperature = new VarInfo();
        static VarInfo _SurfaceTemperatureMinimum = new VarInfo();
        static VarInfo _SurfaceTemperatureMaximum = new VarInfo();

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

        public static  VarInfo Sand
        {
            get { return _Sand;}
        }

        public static  VarInfo OrganicMatter
        {
            get { return _OrganicMatter;}
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

        static void DescribeVariables()
        {
            _AboveGroundBiomass.Name = "AboveGroundBiomass";
            _AboveGroundBiomass.Description = "Above ground biomass";
            _AboveGroundBiomass.MaxValue = 60;
            _AboveGroundBiomass.MinValue = 0;
            _AboveGroundBiomass.DefaultValue = 3;
            _AboveGroundBiomass.Units = "Kg ha-1";
            _AboveGroundBiomass.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _Sand.Name = "Sand";
            _Sand.Description = "Sand content of soil layer";
            _Sand.MaxValue = -1D;
            _Sand.MinValue = -1D;
            _Sand.DefaultValue = -1D;
            _Sand.Units = "";
            _Sand.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _OrganicMatter.Name = "OrganicMatter";
            _OrganicMatter.Description = "Organic matter content of soil layer";
            _OrganicMatter.MaxValue = -1D;
            _OrganicMatter.MinValue = -1D;
            _OrganicMatter.DefaultValue = -1D;
            _OrganicMatter.Units = "";
            _OrganicMatter.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

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

        }

    }
}