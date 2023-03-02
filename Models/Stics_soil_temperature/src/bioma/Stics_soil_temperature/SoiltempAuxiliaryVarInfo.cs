
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace Soiltemp.DomainClass
{
    public class SoiltempAuxiliaryVarInfo : IVarInfoClass
    {
        static VarInfo _therm_diff = new VarInfo();
        static VarInfo _temp_wave_freq = new VarInfo();

        static SoiltempAuxiliaryVarInfo()
        {
            SoiltempAuxiliaryVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SoiltempAuxiliary Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SoiltempAuxiliary";}
        }

        public static  VarInfo therm_diff
        {
            get { return _therm_diff;}
        }

        public static  VarInfo temp_wave_freq
        {
            get { return _temp_wave_freq;}
        }

        static void DescribeVariables()
        {
            _therm_diff.Name = "therm_diff";
            _therm_diff.Description = "soil thermal diffusivity";
            _therm_diff.MaxValue = 1.0e-1;
            _therm_diff.MinValue = 0.0;
            _therm_diff.DefaultValue = 5.37e-3;
            _therm_diff.Units = "cm2 s-1";
            _therm_diff.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _temp_wave_freq.Name = "temp_wave_freq";
            _temp_wave_freq.Description = "angular frequency of the diurnal temperature sine wave";
            _temp_wave_freq.MaxValue = -1D;
            _temp_wave_freq.MinValue = 0.0;
            _temp_wave_freq.DefaultValue = 7.272e-5;
            _temp_wave_freq.Units = "radians s-1";
            _temp_wave_freq.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

        }

    }
}