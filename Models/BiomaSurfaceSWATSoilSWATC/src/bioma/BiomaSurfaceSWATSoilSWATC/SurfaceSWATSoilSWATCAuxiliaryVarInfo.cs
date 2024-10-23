
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfaceSWATSoilSWATC.DomainClass
{
    public class SurfaceSWATSoilSWATCAuxiliaryVarInfo : IVarInfoClass
    {
        static VarInfo _AboveGroundBiomass = new VarInfo();
        static VarInfo _SurfaceSoilTemperature = new VarInfo();

        static SurfaceSWATSoilSWATCAuxiliaryVarInfo()
        {
            SurfaceSWATSoilSWATCAuxiliaryVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SurfaceSWATSoilSWATCAuxiliary Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SurfaceSWATSoilSWATCAuxiliary";}
        }

        public static  VarInfo AboveGroundBiomass
        {
            get { return _AboveGroundBiomass;}
        }

        public static  VarInfo SurfaceSoilTemperature
        {
            get { return _SurfaceSoilTemperature;}
        }

        static void DescribeVariables()
        {
            _AboveGroundBiomass.Name = "AboveGroundBiomass";
            _AboveGroundBiomass.Description = "Above ground biomass";
            _AboveGroundBiomass.MaxValue = 60;
            _AboveGroundBiomass.MinValue = 0;
            _AboveGroundBiomass.DefaultValue = 3;
            _AboveGroundBiomass.Units = "Kg ha-1";
            _AboveGroundBiomass.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _SurfaceSoilTemperature.Name = "SurfaceSoilTemperature";
            _SurfaceSoilTemperature.Description = "Average surface soil temperature";
            _SurfaceSoilTemperature.MaxValue = 60;
            _SurfaceSoilTemperature.MinValue = -60;
            _SurfaceSoilTemperature.DefaultValue = -1D;
            _SurfaceSoilTemperature.Units = "degC";
            _SurfaceSoilTemperature.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

        }

    }
}