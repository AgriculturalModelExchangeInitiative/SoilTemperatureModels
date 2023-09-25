
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitysoil_temp.DomainClass
{
    public class soil_tempExogenousVarInfo : IVarInfoClass
    {
        static VarInfo _min_temp = new VarInfo();
        static VarInfo _max_temp = new VarInfo();
        static VarInfo _min_air_temp = new VarInfo();
        static VarInfo _min_canopy_temp = new VarInfo();
        static VarInfo _max_canopy_temp = new VarInfo();

        static soil_tempExogenousVarInfo()
        {
            soil_tempExogenousVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "soil_tempExogenous Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "soil_tempExogenous";}
        }

        public static  VarInfo min_temp
        {
            get { return _min_temp;}
        }

        public static  VarInfo max_temp
        {
            get { return _max_temp;}
        }

        public static  VarInfo min_air_temp
        {
            get { return _min_air_temp;}
        }

        public static  VarInfo min_canopy_temp
        {
            get { return _min_canopy_temp;}
        }

        public static  VarInfo max_canopy_temp
        {
            get { return _max_canopy_temp;}
        }

        static void DescribeVariables()
        {
            _min_temp.Name = "min_temp";
            _min_temp.Description = "current minimum temperature";
            _min_temp.MaxValue = 50.0;
            _min_temp.MinValue = -50.0;
            _min_temp.DefaultValue = 0.0;
            _min_temp.Units = "degC";
            _min_temp.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _max_temp.Name = "max_temp";
            _max_temp.Description = "current maximum temperature";
            _max_temp.MaxValue = 50.0;
            _max_temp.MinValue = -50.0;
            _max_temp.DefaultValue = 0.0;
            _max_temp.Units = "degC";
            _max_temp.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _min_air_temp.Name = "min_air_temp";
            _min_air_temp.Description = "current minimum air temperature";
            _min_air_temp.MaxValue = 50.0;
            _min_air_temp.MinValue = -50.0;
            _min_air_temp.DefaultValue = -1D;
            _min_air_temp.Units = "degC";
            _min_air_temp.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _min_canopy_temp.Name = "min_canopy_temp";
            _min_canopy_temp.Description = "current minimum temperature";
            _min_canopy_temp.MaxValue = 50.0;
            _min_canopy_temp.MinValue = -50.0;
            _min_canopy_temp.DefaultValue = 0.0;
            _min_canopy_temp.Units = "degC";
            _min_canopy_temp.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _max_canopy_temp.Name = "max_canopy_temp";
            _max_canopy_temp.Description = "current maximum temperature";
            _max_canopy_temp.MaxValue = 50.0;
            _max_canopy_temp.MinValue = -50.0;
            _max_canopy_temp.DefaultValue = 0.0;
            _max_canopy_temp.Units = "degC";
            _max_canopy_temp.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

        }

    }
}