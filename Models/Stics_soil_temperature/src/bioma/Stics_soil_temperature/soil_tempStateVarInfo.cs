
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace soil_temp.DomainClass
{
    public class soil_tempStateVarInfo : IVarInfoClass
    {
        static VarInfo _temp_amp = new VarInfo();
        static VarInfo _therm_amp = new VarInfo();
        static VarInfo _temp_profile = new VarInfo();
        static VarInfo _canopy_temp_avg = new VarInfo();
        static VarInfo _layer_temp = new VarInfo();
        static VarInfo _prev_temp_profile = new VarInfo();

        static soil_tempStateVarInfo()
        {
            soil_tempStateVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "soil_tempState Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "soil_tempState";}
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

        public static  VarInfo canopy_temp_avg
        {
            get { return _canopy_temp_avg;}
        }

        public static  VarInfo layer_temp
        {
            get { return _layer_temp;}
        }

        public static  VarInfo prev_temp_profile
        {
            get { return _prev_temp_profile;}
        }

        static void DescribeVariables()
        {
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

            _canopy_temp_avg.Name = "canopy_temp_avg";
            _canopy_temp_avg.Description = "current temperature amplitude";
            _canopy_temp_avg.MaxValue = 100.0;
            _canopy_temp_avg.MinValue = 0.0;
            _canopy_temp_avg.DefaultValue = -1D;
            _canopy_temp_avg.Units = "degC";
            _canopy_temp_avg.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _layer_temp.Name = "layer_temp";
            _layer_temp.Description = "soil layers temperature";
            _layer_temp.MaxValue = -1D;
            _layer_temp.MinValue = -1D;
            _layer_temp.DefaultValue = -1D;
            _layer_temp.Units = "degC";
            _layer_temp.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _prev_temp_profile.Name = "prev_temp_profile";
            _prev_temp_profile.Description = "previous soil temperature profile ";
            _prev_temp_profile.MaxValue = -1D;
            _prev_temp_profile.MinValue = -1D;
            _prev_temp_profile.DefaultValue = -1D;
            _prev_temp_profile.Units = "degC";
            _prev_temp_profile.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

        }

    }
}