
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace STEMP_EPIC_.DomainClass
{
    public class STEMP_EPIC_ExogenousVarInfo : IVarInfoClass
    {
        static VarInfo _RAIN = new VarInfo();
        static VarInfo _DEPIR = new VarInfo();
        static VarInfo _TMIN = new VarInfo();
        static VarInfo _BIOMAS = new VarInfo();
        static VarInfo _TAMP = new VarInfo();
        static VarInfo _MULCHMASS = new VarInfo();
        static VarInfo _TMAX = new VarInfo();
        static VarInfo _TAV = new VarInfo();
        static VarInfo _SNOW = new VarInfo();
        static VarInfo _TAVG = new VarInfo();

        static STEMP_EPIC_ExogenousVarInfo()
        {
            STEMP_EPIC_ExogenousVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "STEMP_EPIC_Exogenous Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "STEMP_EPIC_Exogenous";}
        }

        public static  VarInfo RAIN
        {
            get { return _RAIN;}
        }

        public static  VarInfo DEPIR
        {
            get { return _DEPIR;}
        }

        public static  VarInfo TMIN
        {
            get { return _TMIN;}
        }

        public static  VarInfo BIOMAS
        {
            get { return _BIOMAS;}
        }

        public static  VarInfo TAMP
        {
            get { return _TAMP;}
        }

        public static  VarInfo MULCHMASS
        {
            get { return _MULCHMASS;}
        }

        public static  VarInfo TMAX
        {
            get { return _TMAX;}
        }

        public static  VarInfo TAV
        {
            get { return _TAV;}
        }

        public static  VarInfo SNOW
        {
            get { return _SNOW;}
        }

        public static  VarInfo TAVG
        {
            get { return _TAVG;}
        }

        static void DescribeVariables()
        {
            _RAIN.Name = "RAIN";
            _RAIN.Description = "daily rainfall";
            _RAIN.MaxValue = -1D;
            _RAIN.MinValue = -1D;
            _RAIN.DefaultValue = -1D;
            _RAIN.Units = "mm";
            _RAIN.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _DEPIR.Name = "DEPIR";
            _DEPIR.Description = "Depth of irrigation";
            _DEPIR.MaxValue = -1D;
            _DEPIR.MinValue = -1D;
            _DEPIR.DefaultValue = -1D;
            _DEPIR.Units = "mm";
            _DEPIR.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _TMIN.Name = "TMIN";
            _TMIN.Description = "Minimum Temperature";
            _TMIN.MaxValue = -1D;
            _TMIN.MinValue = -1D;
            _TMIN.DefaultValue = -1D;
            _TMIN.Units = "degC";
            _TMIN.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _BIOMAS.Name = "BIOMAS";
            _BIOMAS.Description = "Biomass";
            _BIOMAS.MaxValue = -1D;
            _BIOMAS.MinValue = -1D;
            _BIOMAS.DefaultValue = -1D;
            _BIOMAS.Units = "kg/ha";
            _BIOMAS.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _TAMP.Name = "TAMP";
            _TAMP.Description = "Annual amplitude of the average air temperature";
            _TAMP.MaxValue = -1D;
            _TAMP.MinValue = -1D;
            _TAMP.DefaultValue = -1D;
            _TAMP.Units = "degC";
            _TAMP.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _MULCHMASS.Name = "MULCHMASS";
            _MULCHMASS.Description = "Mulch Mass";
            _MULCHMASS.MaxValue = -1D;
            _MULCHMASS.MinValue = -1D;
            _MULCHMASS.DefaultValue = -1D;
            _MULCHMASS.Units = "kg/ha";
            _MULCHMASS.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _TMAX.Name = "TMAX";
            _TMAX.Description = "Maximum daily temperature";
            _TMAX.MaxValue = -1D;
            _TMAX.MinValue = -1D;
            _TMAX.DefaultValue = -1D;
            _TMAX.Units = "degC";
            _TMAX.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _TAV.Name = "TAV";
            _TAV.Description = "Average annual soil temperature, used with TAMP to calculate soil temperature.";
            _TAV.MaxValue = -1D;
            _TAV.MinValue = -1D;
            _TAV.DefaultValue = -1D;
            _TAV.Units = "degC";
            _TAV.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _SNOW.Name = "SNOW";
            _SNOW.Description = "Snow cover";
            _SNOW.MaxValue = -1D;
            _SNOW.MinValue = -1D;
            _SNOW.DefaultValue = -1D;
            _SNOW.Units = "mm";
            _SNOW.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _TAVG.Name = "TAVG";
            _TAVG.Description = "Average daily temperature";
            _TAVG.MaxValue = -1D;
            _TAVG.MinValue = -1D;
            _TAVG.DefaultValue = -1D;
            _TAVG.Units = "degC";
            _TAVG.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

        }

    }
}