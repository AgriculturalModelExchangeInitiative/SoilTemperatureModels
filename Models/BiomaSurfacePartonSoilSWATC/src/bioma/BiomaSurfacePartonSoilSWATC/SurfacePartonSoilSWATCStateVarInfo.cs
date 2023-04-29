
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfacePartonSoilSWATC.DomainClass
{
    public class SurfacePartonSoilSWATCStateVarInfo : IVarInfoClass
    {
        static VarInfo _AboveGroundBiomass = new VarInfo();
        static VarInfo _VolumetricWaterContent = new VarInfo();
        static VarInfo _LayerThickness = new VarInfo();
        static VarInfo _BulkDensity = new VarInfo();
        static VarInfo _SoilProfileDepth = new VarInfo();
        static VarInfo _SurfaceSoilTemperature = new VarInfo();
        static VarInfo _SoilTemperatureByLayers = new VarInfo();

        static SurfacePartonSoilSWATCStateVarInfo()
        {
            SurfacePartonSoilSWATCStateVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SurfacePartonSoilSWATCState Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SurfacePartonSoilSWATCState";}
        }

        public static  VarInfo AboveGroundBiomass
        {
            get { return _AboveGroundBiomass;}
        }

        public static  VarInfo VolumetricWaterContent
        {
            get { return _VolumetricWaterContent;}
        }

        public static  VarInfo LayerThickness
        {
            get { return _LayerThickness;}
        }

        public static  VarInfo BulkDensity
        {
            get { return _BulkDensity;}
        }

        public static  VarInfo SoilProfileDepth
        {
            get { return _SoilProfileDepth;}
        }

        public static  VarInfo SurfaceSoilTemperature
        {
            get { return _SurfaceSoilTemperature;}
        }

        public static  VarInfo SoilTemperatureByLayers
        {
            get { return _SoilTemperatureByLayers;}
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

            _VolumetricWaterContent.Name = "VolumetricWaterContent";
            _VolumetricWaterContent.Description = "Volumetric soil water content";
            _VolumetricWaterContent.MaxValue = -1D;
            _VolumetricWaterContent.MinValue = -1D;
            _VolumetricWaterContent.DefaultValue = -1D;
            _VolumetricWaterContent.Units = "m3 m-3";
            _VolumetricWaterContent.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _LayerThickness.Name = "LayerThickness";
            _LayerThickness.Description = "Soil layer thickness";
            _LayerThickness.MaxValue = -1D;
            _LayerThickness.MinValue = -1D;
            _LayerThickness.DefaultValue = -1D;
            _LayerThickness.Units = "m";
            _LayerThickness.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _BulkDensity.Name = "BulkDensity";
            _BulkDensity.Description = "Bulk density";
            _BulkDensity.MaxValue = -1D;
            _BulkDensity.MinValue = -1D;
            _BulkDensity.DefaultValue = -1D;
            _BulkDensity.Units = "t m-3";
            _BulkDensity.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _SoilProfileDepth.Name = "SoilProfileDepth";
            _SoilProfileDepth.Description = "Soil profile depth";
            _SoilProfileDepth.MaxValue = 50;
            _SoilProfileDepth.MinValue = 0;
            _SoilProfileDepth.DefaultValue = 3;
            _SoilProfileDepth.Units = "m";
            _SoilProfileDepth.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _SurfaceSoilTemperature.Name = "SurfaceSoilTemperature";
            _SurfaceSoilTemperature.Description = "Average surface soil temperature";
            _SurfaceSoilTemperature.MaxValue = 60;
            _SurfaceSoilTemperature.MinValue = -60;
            _SurfaceSoilTemperature.DefaultValue = -1D;
            _SurfaceSoilTemperature.Units = "Â°C";
            _SurfaceSoilTemperature.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _SoilTemperatureByLayers.Name = "SoilTemperatureByLayers";
            _SoilTemperatureByLayers.Description = "Soil temperature of each layer";
            _SoilTemperatureByLayers.MaxValue = -1D;
            _SoilTemperatureByLayers.MinValue = -1D;
            _SoilTemperatureByLayers.DefaultValue = -1D;
            _SoilTemperatureByLayers.Units = "Â°C";
            _SoilTemperatureByLayers.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

        }

    }
}