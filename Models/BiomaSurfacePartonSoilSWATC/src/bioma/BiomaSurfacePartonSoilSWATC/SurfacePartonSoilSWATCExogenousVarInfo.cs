
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfacePartonSoilSWATC.DomainClass
{
    public class SurfacePartonSoilSWATCExogenousVarInfo : IVarInfoClass
    {
        static VarInfo _DayLength = new VarInfo();
        static VarInfo _AirTemperatureMaximum = new VarInfo();
        static VarInfo _AirTemperatureMinimum = new VarInfo();
        static VarInfo _GlobalSolarRadiation = new VarInfo();
        static VarInfo _AirTemperatureAnnualAverage = new VarInfo();

        static SurfacePartonSoilSWATCExogenousVarInfo()
        {
            SurfacePartonSoilSWATCExogenousVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SurfacePartonSoilSWATCExogenous Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SurfacePartonSoilSWATCExogenous";}
        }

        public static  VarInfo DayLength
        {
            get { return _DayLength;}
        }

        public static  VarInfo AirTemperatureMaximum
        {
            get { return _AirTemperatureMaximum;}
        }

        public static  VarInfo AirTemperatureMinimum
        {
            get { return _AirTemperatureMinimum;}
        }

        public static  VarInfo GlobalSolarRadiation
        {
            get { return _GlobalSolarRadiation;}
        }

        public static  VarInfo AirTemperatureAnnualAverage
        {
            get { return _AirTemperatureAnnualAverage;}
        }

        static void DescribeVariables()
        {
            _DayLength.Name = "DayLength";
            _DayLength.Description = "Length of the day";
            _DayLength.MaxValue = 24;
            _DayLength.MinValue = 0;
            _DayLength.DefaultValue = 10;
            _DayLength.Units = "h";
            _DayLength.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _AirTemperatureMaximum.Name = "AirTemperatureMaximum";
            _AirTemperatureMaximum.Description = "Maximum daily air temperature";
            _AirTemperatureMaximum.MaxValue = 60;
            _AirTemperatureMaximum.MinValue = -40;
            _AirTemperatureMaximum.DefaultValue = 15;
            _AirTemperatureMaximum.Units = "Â°C";
            _AirTemperatureMaximum.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _AirTemperatureMinimum.Name = "AirTemperatureMinimum";
            _AirTemperatureMinimum.Description = "Minimum daily air temperature";
            _AirTemperatureMinimum.MaxValue = 50;
            _AirTemperatureMinimum.MinValue = -60;
            _AirTemperatureMinimum.DefaultValue = 5;
            _AirTemperatureMinimum.Units = "Â°C";
            _AirTemperatureMinimum.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _GlobalSolarRadiation.Name = "GlobalSolarRadiation";
            _GlobalSolarRadiation.Description = "Daily global solar radiation";
            _GlobalSolarRadiation.MaxValue = 50;
            _GlobalSolarRadiation.MinValue = 0;
            _GlobalSolarRadiation.DefaultValue = 15;
            _GlobalSolarRadiation.Units = "Mj m-2 d-1";
            _GlobalSolarRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _AirTemperatureAnnualAverage.Name = "AirTemperatureAnnualAverage";
            _AirTemperatureAnnualAverage.Description = "Annual average air temperature";
            _AirTemperatureAnnualAverage.MaxValue = 50;
            _AirTemperatureAnnualAverage.MinValue = -40;
            _AirTemperatureAnnualAverage.DefaultValue = 15;
            _AirTemperatureAnnualAverage.Units = "Â°C";
            _AirTemperatureAnnualAverage.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

        }

    }
}