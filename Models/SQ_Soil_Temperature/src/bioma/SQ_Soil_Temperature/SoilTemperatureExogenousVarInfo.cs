
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SoilTemperature.DomainClass
{
    public class SoilTemperatureExogenousVarInfo : IVarInfoClass
    {
        static VarInfo _meanTAir = new VarInfo();
        static VarInfo _minTAir = new VarInfo();
        static VarInfo _meanAnnualAirTemp = new VarInfo();
        static VarInfo _maxTAir = new VarInfo();
        static VarInfo _dayLength = new VarInfo();

        static SoilTemperatureExogenousVarInfo()
        {
            SoilTemperatureExogenousVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SoilTemperatureExogenous Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SoilTemperatureExogenous";}
        }

        public static  VarInfo meanTAir
        {
            get { return _meanTAir;}
        }

        public static  VarInfo minTAir
        {
            get { return _minTAir;}
        }

        public static  VarInfo meanAnnualAirTemp
        {
            get { return _meanAnnualAirTemp;}
        }

        public static  VarInfo maxTAir
        {
            get { return _maxTAir;}
        }

        public static  VarInfo dayLength
        {
            get { return _dayLength;}
        }

        static void DescribeVariables()
        {
            _meanTAir.Name = "meanTAir";
            _meanTAir.Description = "Mean Air Temperature";
            _meanTAir.MaxValue = 80;
            _meanTAir.MinValue = -30;
            _meanTAir.DefaultValue = 22;
            _meanTAir.Units = "Â°C";
            _meanTAir.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _minTAir.Name = "minTAir";
            _minTAir.Description = "Minimum Air Temperature from Weather files";
            _minTAir.MaxValue = 80;
            _minTAir.MinValue = -30;
            _minTAir.DefaultValue = 20;
            _minTAir.Units = "Â°C";
            _minTAir.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _meanAnnualAirTemp.Name = "meanAnnualAirTemp";
            _meanAnnualAirTemp.Description = "Annual Mean Air Temperature";
            _meanAnnualAirTemp.MaxValue = 80;
            _meanAnnualAirTemp.MinValue = -30;
            _meanAnnualAirTemp.DefaultValue = 22;
            _meanAnnualAirTemp.Units = "Â°C";
            _meanAnnualAirTemp.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _maxTAir.Name = "maxTAir";
            _maxTAir.Description = "Maximum Air Temperature from Weather Files";
            _maxTAir.MaxValue = 80;
            _maxTAir.MinValue = -30;
            _maxTAir.DefaultValue = 25;
            _maxTAir.Units = "Â°C";
            _maxTAir.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _dayLength.Name = "dayLength";
            _dayLength.Description = "Length of the day";
            _dayLength.MaxValue = 24;
            _dayLength.MinValue = 0;
            _dayLength.DefaultValue = 12;
            _dayLength.Units = "hour";
            _dayLength.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

        }

    }
}