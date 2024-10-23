
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySurfacePartonSoilSWATC.DomainClass
{
    public class SurfacePartonSoilSWATCAuxiliaryVarInfo : IVarInfoClass
    {
        static VarInfo _SurfaceTemperatureMinimum = new VarInfo();
        static VarInfo _SurfaceTemperatureMaximum = new VarInfo();
        static VarInfo _SurfaceSoilTemperature = new VarInfo();

        static SurfacePartonSoilSWATCAuxiliaryVarInfo()
        {
            SurfacePartonSoilSWATCAuxiliaryVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SurfacePartonSoilSWATCAuxiliary Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SurfacePartonSoilSWATCAuxiliary";}
        }

        public static  VarInfo SurfaceTemperatureMinimum
        {
            get { return _SurfaceTemperatureMinimum;}
        }

        public static  VarInfo SurfaceTemperatureMaximum
        {
            get { return _SurfaceTemperatureMaximum;}
        }

        public static  VarInfo SurfaceSoilTemperature
        {
            get { return _SurfaceSoilTemperature;}
        }

        static void DescribeVariables()
        {
            _SurfaceTemperatureMinimum.Name = "SurfaceTemperatureMinimum";
            _SurfaceTemperatureMinimum.Description = "Minimum surface soil temperature";
            _SurfaceTemperatureMinimum.MaxValue = 60;
            _SurfaceTemperatureMinimum.MinValue = -60;
            _SurfaceTemperatureMinimum.DefaultValue = -1D;
            _SurfaceTemperatureMinimum.Units = "degC";
            _SurfaceTemperatureMinimum.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _SurfaceTemperatureMaximum.Name = "SurfaceTemperatureMaximum";
            _SurfaceTemperatureMaximum.Description = "Maximum surface soil temperature";
            _SurfaceTemperatureMaximum.MaxValue = 60;
            _SurfaceTemperatureMaximum.MinValue = -60;
            _SurfaceTemperatureMaximum.DefaultValue = -1D;
            _SurfaceTemperatureMaximum.Units = "degC";
            _SurfaceTemperatureMaximum.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _SurfaceSoilTemperature.Name = "SurfaceSoilTemperature";
            _SurfaceSoilTemperature.Description = "Average surface soil temperature";
            _SurfaceSoilTemperature.MaxValue = 60;
            _SurfaceSoilTemperature.MinValue = -60;
            _SurfaceSoilTemperature.DefaultValue = -1D;
            _SurfaceSoilTemperature.Units = "degC";
            _SurfaceSoilTemperature.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

        }

    }
}