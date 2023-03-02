
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfacePartonSoilSWATC.DomainClass
{
    public class SurfacePartonSoilSWATCAuxiliaryVarInfo : IVarInfoClass
    {
        static VarInfo _SurfaceTemperatureMaximum = new VarInfo();
        static VarInfo _SurfaceTemperatureMinimum = new VarInfo();

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