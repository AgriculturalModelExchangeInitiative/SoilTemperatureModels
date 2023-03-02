
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace Soiltemp.DomainClass
{
    public class SoiltempStateVarInfo : IVarInfoClass
    {
        static VarInfo _prev_temp_profile = new VarInfo();
        static VarInfo _temp_amp = new VarInfo();
        static VarInfo _therm_amp = new VarInfo();
        static VarInfo _temp_profile = new VarInfo();

        static SoiltempStateVarInfo()
        {
            SoiltempStateVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SoiltempState Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SoiltempState";}
        }

        public static  VarInfo prev_temp_profile
        {
            get { return _prev_temp_profile;}
        }

        public static  VarInfo temp_amp
        {
            get { return _temp_amp;}
        }

        public static  VarInfo therm_amp
        {
            get { return _therm_amp;}
        }

        public static  VarInfo temp_profile
        {
            get { return _temp_profile;}
        }

        static void DescribeVariables()
        {
            _prev_temp_profile.Name = "prev_temp_profile";
            _prev_temp_profile.Description = "previous soil temperature profile ";
            _prev_temp_profile.MaxValue = -1D;
            _prev_temp_profile.MinValue = -1D;
            _prev_temp_profile.DefaultValue = -1D;
            _prev_temp_profile.Units = "degC";
            _prev_temp_profile.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _temp_amp.Name = "temp_amp";
            _temp_amp.Description = "current temperature amplitude";
            _temp_amp.MaxValue = 100.0;
            _temp_amp.MinValue = 0.0;
            _temp_amp.DefaultValue = -1D;
            _temp_amp.Units = "degC";
            _temp_amp.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _therm_amp.Name = "therm_amp";
            _therm_amp.Description = "thermal amplitude";
            _therm_amp.MaxValue = -1D;
            _therm_amp.MinValue = -1D;
            _therm_amp.DefaultValue = -1D;
            _therm_amp.Units = "radians cm-2";
            _therm_amp.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _temp_profile.Name = "temp_profile";
            _temp_profile.Description = "current soil profile temperature ";
            _temp_profile.MaxValue = -1D;
            _temp_profile.MinValue = -1D;
            _temp_profile.DefaultValue = -1D;
            _temp_profile.Units = "degC";
            _temp_profile.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

        }

    }
}