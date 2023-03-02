
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfaceSWATSoilSWATC.DomainClass
{
    public class SurfaceSWATSoilSWATCExogenousVarInfo : IVarInfoClass
    {
        static VarInfo _AirTemperatureMinimum = new VarInfo();
        static VarInfo _GlobalSolarRadiation = new VarInfo();
        static VarInfo _WaterEquivalentOfSnowPack = new VarInfo();
        static VarInfo _AirTemperatureMaximum = new VarInfo();
        static VarInfo _Albedo = new VarInfo();
        static VarInfo _AirTemperatureAnnualAverage = new VarInfo();

        static SurfaceSWATSoilSWATCExogenousVarInfo()
        {
            SurfaceSWATSoilSWATCExogenousVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SurfaceSWATSoilSWATCExogenous Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SurfaceSWATSoilSWATCExogenous";}
        }

        public static  VarInfo AirTemperatureMinimum
        {
            get { return _AirTemperatureMinimum;}
        }

        public static  VarInfo GlobalSolarRadiation
        {
            get { return _GlobalSolarRadiation;}
        }

        public static  VarInfo WaterEquivalentOfSnowPack
        {
            get { return _WaterEquivalentOfSnowPack;}
        }

        public static  VarInfo AirTemperatureMaximum
        {
            get { return _AirTemperatureMaximum;}
        }

        public static  VarInfo Albedo
        {
            get { return _Albedo;}
        }

        public static  VarInfo AirTemperatureAnnualAverage
        {
            get { return _AirTemperatureAnnualAverage;}
        }

        static void DescribeVariables()
        {
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

            _WaterEquivalentOfSnowPack.Name = "WaterEquivalentOfSnowPack";
            _WaterEquivalentOfSnowPack.Description = "Water equivalent of snow pack";
            _WaterEquivalentOfSnowPack.MaxValue = 1000;
            _WaterEquivalentOfSnowPack.MinValue = 0;
            _WaterEquivalentOfSnowPack.DefaultValue = 10;
            _WaterEquivalentOfSnowPack.Units = "mm";
            _WaterEquivalentOfSnowPack.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _AirTemperatureMaximum.Name = "AirTemperatureMaximum";
            _AirTemperatureMaximum.Description = "Maximum daily air temperature";
            _AirTemperatureMaximum.MaxValue = 60;
            _AirTemperatureMaximum.MinValue = -40;
            _AirTemperatureMaximum.DefaultValue = 15;
            _AirTemperatureMaximum.Units = "Â°C";
            _AirTemperatureMaximum.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _Albedo.Name = "Albedo";
            _Albedo.Description = "Albedo of soil";
            _Albedo.MaxValue = 1;
            _Albedo.MinValue = 0;
            _Albedo.DefaultValue = 0.2;
            _Albedo.Units = "unitless";
            _Albedo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

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