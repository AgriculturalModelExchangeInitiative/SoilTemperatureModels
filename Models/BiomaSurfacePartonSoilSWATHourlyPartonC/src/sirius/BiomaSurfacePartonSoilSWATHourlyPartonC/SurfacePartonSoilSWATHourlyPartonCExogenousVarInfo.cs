
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass
{
    public class SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo : IVarInfoClass
    {
        static VarInfo _AirTemperatureMinimum = new VarInfo();
        static VarInfo _DayLength = new VarInfo();
        static VarInfo _GlobalSolarRadiation = new VarInfo();
        static VarInfo _AirTemperatureMaximum = new VarInfo();
        static VarInfo _VolumetricWaterContent = new VarInfo();
        static VarInfo _HourOfSunset = new VarInfo();
        static VarInfo _HourOfSunrise = new VarInfo();

        static SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo()
        {
            SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SurfacePartonSoilSWATHourlyPartonCExogenous Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SurfacePartonSoilSWATHourlyPartonCExogenous";}
        }

        public static  VarInfo AirTemperatureMinimum
        {
            get { return _AirTemperatureMinimum;}
        }

        public static  VarInfo DayLength
        {
            get { return _DayLength;}
        }

        public static  VarInfo GlobalSolarRadiation
        {
            get { return _GlobalSolarRadiation;}
        }

        public static  VarInfo AirTemperatureMaximum
        {
            get { return _AirTemperatureMaximum;}
        }

        public static  VarInfo VolumetricWaterContent
        {
            get { return _VolumetricWaterContent;}
        }

        public static  VarInfo HourOfSunset
        {
            get { return _HourOfSunset;}
        }

        public static  VarInfo HourOfSunrise
        {
            get { return _HourOfSunrise;}
        }

        static void DescribeVariables()
        {
            _AirTemperatureMinimum.Name = "AirTemperatureMinimum";
            _AirTemperatureMinimum.Description = "Minimum daily air temperature";
            _AirTemperatureMinimum.MaxValue = 50;
            _AirTemperatureMinimum.MinValue = -60;
            _AirTemperatureMinimum.DefaultValue = 5;
            _AirTemperatureMinimum.Units = "degC";
            _AirTemperatureMinimum.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _DayLength.Name = "DayLength";
            _DayLength.Description = "Length of the day";
            _DayLength.MaxValue = 24;
            _DayLength.MinValue = 0;
            _DayLength.DefaultValue = 10;
            _DayLength.Units = "h";
            _DayLength.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _GlobalSolarRadiation.Name = "GlobalSolarRadiation";
            _GlobalSolarRadiation.Description = "Daily global solar radiation";
            _GlobalSolarRadiation.MaxValue = 50;
            _GlobalSolarRadiation.MinValue = 0;
            _GlobalSolarRadiation.DefaultValue = 15;
            _GlobalSolarRadiation.Units = "Mj m-2 d-1";
            _GlobalSolarRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _AirTemperatureMaximum.Name = "AirTemperatureMaximum";
            _AirTemperatureMaximum.Description = "Maximum daily air temperature";
            _AirTemperatureMaximum.MaxValue = 60;
            _AirTemperatureMaximum.MinValue = -40;
            _AirTemperatureMaximum.DefaultValue = 15;
            _AirTemperatureMaximum.Units = "degC";
            _AirTemperatureMaximum.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _VolumetricWaterContent.Name = "VolumetricWaterContent";
            _VolumetricWaterContent.Description = "Volumetric soil water content";
            _VolumetricWaterContent.MaxValue = -1D;
            _VolumetricWaterContent.MinValue = -1D;
            _VolumetricWaterContent.DefaultValue = -1D;
            _VolumetricWaterContent.Units = "m3 m-3";
            _VolumetricWaterContent.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _HourOfSunset.Name = "HourOfSunset";
            _HourOfSunset.Description = "Hour of sunset";
            _HourOfSunset.MaxValue = 24;
            _HourOfSunset.MinValue = 0;
            _HourOfSunset.DefaultValue = 17;
            _HourOfSunset.Units = "h";
            _HourOfSunset.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _HourOfSunrise.Name = "HourOfSunrise";
            _HourOfSunrise.Description = "Hour of sunrise";
            _HourOfSunrise.MaxValue = 24;
            _HourOfSunrise.MinValue = 0;
            _HourOfSunrise.DefaultValue = 6;
            _HourOfSunrise.Units = "h";
            _HourOfSunrise.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

        }

    }
}