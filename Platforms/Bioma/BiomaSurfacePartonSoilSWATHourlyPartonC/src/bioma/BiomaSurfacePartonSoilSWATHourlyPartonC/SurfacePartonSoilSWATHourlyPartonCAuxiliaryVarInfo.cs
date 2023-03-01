
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfacePartonSoilSWATHourlyPartonC.DomainClass
{
    public class SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo : IVarInfoClass
    {
        static VarInfo _SurfaceTemperatureMaximum = new VarInfo();
        static VarInfo _SurfaceTemperatureMinimum = new VarInfo();

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

        public static  VarInfo SurfaceTemperatureMaximum
        {
            get { return _SurfaceTemperatureMaximum;}
        }

        public static  VarInfo SurfaceTemperatureMinimum
        {
            get { return _SurfaceTemperatureMinimum;}
        }

        static void DescribeVariables()
        {
            _SurfaceTemperatureMaximum.Name = "SurfaceTemperatureMaximum";
            _SurfaceTemperatureMaximum.Description = "Maximum surface soil temperature";
            _SurfaceTemperatureMaximum.MaxValue = 60;
            _SurfaceTemperatureMaximum.MinValue = -60;
            _SurfaceTemperatureMaximum.DefaultValue = -1D;
            _SurfaceTemperatureMaximum.Units = "Â°C";
            _SurfaceTemperatureMaximum.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _SurfaceTemperatureMinimum.Name = "SurfaceTemperatureMinimum";
            _SurfaceTemperatureMinimum.Description = "Minimum surface soil temperature";
            _SurfaceTemperatureMinimum.MaxValue = 60;
            _SurfaceTemperatureMinimum.MinValue = -60;
            _SurfaceTemperatureMinimum.DefaultValue = -1D;
            _SurfaceTemperatureMinimum.Units = "Â°C";
            _SurfaceTemperatureMinimum.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

        }

    }
}