//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:2.0.50727.5477
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

/// This class was created from file C:\Users\Diprove\Desktop\Reimplementazione\SoilT\UNIMI.SoilT_perSoilBorne\UNIMI.SoilT\DataStructure\SoilTemperatureStates.xml
/// DCC - Domain Class Coder, http://agsys.cra-cin.it/tools , see Applications, DCC
namespace UNIMI.SoilT.Interfaces
{
    using System;
    using CRA.ModelLayer;
    using CRA.ModelLayer.Core;
    
    
    /// <summary>StatesVarInfoClasses contain the attributes for each variable in the domain class RainData. Attributes are valorized via the static constructor. The data-type VarInfo causes  a dependency to the assembly CRA.ModelLayer.dll</summary>
    public class StatesVarInfo : IVarInfoClass
    {

        #region Private fields
        //static VarInfo _Layers = new VarInfo();
        // new layers as array - begin
        static VarInfo _HeatCapacity = new VarInfo();

        static VarInfo _SoilTemperatureByLayers = new VarInfo();

        static VarInfo _TemperatureConductance = new VarInfo();

        static VarInfo _LayerThickness = new VarInfo();

        static VarInfo _Clay = new VarInfo();

        static VarInfo _BulkDensity = new VarInfo();

        static VarInfo _VolumetricWaterContent = new VarInfo();

        static VarInfo _SoilTemperatureByLayersHourly = new VarInfo();

        static VarInfo _SoilTemperaturePreviousDay = new VarInfo();

        static VarInfo _SoilTemperatureRangeByLayers = new VarInfo();

        static VarInfo _SoilTemperatureMaximum = new VarInfo();

        static VarInfo _SoilTemperatureMinimum = new VarInfo();

        static VarInfo _Sand = new VarInfo();

        static VarInfo _Silt = new VarInfo();

        static VarInfo _OrganicMatter = new VarInfo();

        static VarInfo _VolumetricWaterContentAtSaturation = new VarInfo();

        static VarInfo _ThermalConductivity = new VarInfo();

        static VarInfo _ThermalDiffusivity = new VarInfo();
        // new layers as array - end

        static VarInfo _SurfaceSoilTemperature = new VarInfo();
        
        static VarInfo _SoilProfileDepth = new VarInfo();
        #endregion
        
        /// <summary>Constructor</summary>
        static StatesVarInfo()
        {
            StatesVarInfo.DescribeVariables();
        }
        
        #region IVarInfoClass members
        /// <summary>Domain Class description</summary>
        public virtual  string Description
        {
            get
            {
                return "State variables of SoilT component ";
            }
        }
        
        /// <summary>Reference to the ontology</summary>
        public  string URL
        {
            get
            {
                return "http://";
            }
        }
        
        /// <summary>Value domain class of reference</summary>
        public  string DomainClassOfReference
        {
            get
            {
                return "States";
            }
        }
        #endregion

        #region Public properties
        // new type - begin
        /// <summary>Volumetric specific heat of soil</summary>
        public static VarInfo HeatCapacity
        {
            get
            {
                return _HeatCapacity;
            }
        }

        /// <summary>Soil temperature of each layer</summary>
        public static VarInfo SoilTemperatureByLayers
        {
            get
            {
                return _SoilTemperatureByLayers;
            }
        }

        /// <summary>Temperature conductance</summary>
        public static VarInfo TemperatureConductance
        {
            get
            {
                return _TemperatureConductance;
            }
        }

        /// <summary>Soil layer thickness</summary>
        public static VarInfo LayerThickness
        {
            get
            {
                return _LayerThickness;
            }
        }

        /// <summary>Clay content of soil layer</summary>
        public static VarInfo Clay
        {
            get
            {
                return _Clay;
            }
        }

        /// <summary>Bulk density</summary>
        public static VarInfo BulkDensity
        {
            get
            {
                return _BulkDensity;
            }
        }

        /// <summary>Volumetric soil water content</summary>
        public static VarInfo VolumetricWaterContent
        {
            get
            {
                return _VolumetricWaterContent;
            }
        }

        /// <summary>Hourly soil temperature by layers</summary>
        public static VarInfo SoilTemperatureByLayersHourly
        {
            get
            {
                return _SoilTemperatureByLayersHourly;
            }
        }

        /// <summary>Last hourly temperature of the day</summary>
        public static VarInfo SoilTemperaturePreviousDay
        {
            get
            {
                return _SoilTemperaturePreviousDay;
            }
        }

        /// <summary>Soil temperature range by layers</summary>
        public static VarInfo SoilTemperatureRangeByLayers
        {
            get
            {
                return _SoilTemperatureRangeByLayers;
            }
        }

        /// <summary>Maximum soil temperature by layers</summary>
        public static VarInfo SoilTemperatureMaximum
        {
            get
            {
                return _SoilTemperatureMaximum;
            }
        }

        /// <summary>Minimum soil temperature by layers</summary>
        public static VarInfo SoilTemperatureMinimum
        {
            get
            {
                return _SoilTemperatureMinimum;
            }
        }

        /// <summary>Sand content of soil layer</summary>
        public static VarInfo Sand
        {
            get
            {
                return _Sand;
            }
        }

        /// <summary>Silt content of soil layer</summary>
        public static VarInfo Silt
        {
            get
            {
                return _Silt;
            }
        }

        /// <summary>Organic matter content of soil layer</summary>
        public static VarInfo OrganicMatter
        {
            get
            {
                return _OrganicMatter;
            }
        }

        /// <summary>Volumetric water content at saturation</summary>
        public static VarInfo VolumetricWaterContentAtSaturation
        {
            get
            {
                return _VolumetricWaterContentAtSaturation;
            }
        }

        /// <summary>Thermal conductivity of soil layer</summary>
        public static VarInfo ThermalConductivity
        {
            get
            {
                return _ThermalConductivity;
            }
        }

        /// <summary>Thermal diffusivity of soil layer</summary>
        public static VarInfo ThermalDiffusivity
        {
            get
            {
                return _ThermalDiffusivity;
            }
        }
        // new type - end
        ///// <summary>Soil layer states</summary>
        //public static  VarInfo Layers
        //{
        //    get
        //    {
        //        return  _Layers;
        //    }
        //}

        /// <summary>Average surface soil temperature</summary>
        public static  VarInfo SurfaceSoilTemperature
        {
            get
            {
                return  _SurfaceSoilTemperature;
            }
        }
        
        /// <summary>Soil profile depth</summary>
        public static  VarInfo SoilProfileDepth
        {
            get
            {
                return  _SoilProfileDepth;
            }
        }
        #endregion
        
        #region VarInfo values
        /// <summary>Set VarInfo values</summary>
        static void DescribeVariables()
        {
            ////   
            //_Layers.Name = "Layers";
            //_Layers.Description = "Soil layer states";
            //_Layers.MaxValue = 0;
            //_Layers.MinValue = 0;
            //_Layers.DefaultValue = 0;
            //_Layers.Units = "unitless";
            //_Layers.URL = "http://";
            //_Layers.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //
            _SurfaceSoilTemperature.Name = "SurfaceSoilTemperature";
            _SurfaceSoilTemperature.Description = "Average surface soil temperature";
            _SurfaceSoilTemperature.MaxValue = 60;
            _SurfaceSoilTemperature.MinValue = -60;
            _SurfaceSoilTemperature.DefaultValue = 25;
            _SurfaceSoilTemperature.Units = "°C";
            _SurfaceSoilTemperature.URL = "http://";
            _SurfaceSoilTemperature.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _SoilProfileDepth.Name = "SoilProfileDepth";
            _SoilProfileDepth.Description = "Soil profile depth";
            _SoilProfileDepth.MaxValue = 50;
            _SoilProfileDepth.MinValue = 0;
            _SoilProfileDepth.DefaultValue = 3;
            _SoilProfileDepth.Units = "m";
            _SoilProfileDepth.URL = "http://";
            _SoilProfileDepth.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            // new type - begin
            //   
            _HeatCapacity.Name = "HeatCapacity";
            _HeatCapacity.Description = "Volumetric specific heat of soil";
            _HeatCapacity.MaxValue = 300;
            _HeatCapacity.MinValue = 0;
            _HeatCapacity.DefaultValue = 20;
            _HeatCapacity.Units = "MJ m-3 °C-1";
            _HeatCapacity.URL = "http://";
            _HeatCapacity.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _SoilTemperatureByLayers.Name = "SoilTemperatureByLayers";
            _SoilTemperatureByLayers.Description = "Soil temperature of each layer";
            _SoilTemperatureByLayers.MaxValue = 60;
            _SoilTemperatureByLayers.MinValue = -60;
            _SoilTemperatureByLayers.DefaultValue = 15;
            _SoilTemperatureByLayers.Units = "°C";
            _SoilTemperatureByLayers.URL = "http://";
            _SoilTemperatureByLayers.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _TemperatureConductance.Name = "TemperatureConductance";
            _TemperatureConductance.Description = "Temperature conductance";
            _TemperatureConductance.MaxValue = 50;
            _TemperatureConductance.MinValue = 0;
            _TemperatureConductance.DefaultValue = 10;
            _TemperatureConductance.Units = "W m-1 °C-1";
            _TemperatureConductance.URL = "http://";
            _TemperatureConductance.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _LayerThickness.Name = "LayerThickness";
            _LayerThickness.Description = "Soil layer thickness";
            _LayerThickness.MaxValue = 3;
            _LayerThickness.MinValue = 0.005;
            _LayerThickness.DefaultValue = 0.05;
            _LayerThickness.Units = "m";
            _LayerThickness.URL = "http://";
            _LayerThickness.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _Clay.Name = "Clay";
            _Clay.Description = "Clay content of soil layer";
            _Clay.MaxValue = 100;
            _Clay.MinValue = 0;
            _Clay.DefaultValue = 0;
            _Clay.Units = "%";
            _Clay.URL = "http://";
            _Clay.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _BulkDensity.Name = "BulkDensity";
            _BulkDensity.Description = "Bulk density";
            _BulkDensity.MaxValue = 1.8;
            _BulkDensity.MinValue = 0.9;
            _BulkDensity.DefaultValue = 1.3;
            _BulkDensity.Units = "t m-3";
            _BulkDensity.URL = "http://";
            _BulkDensity.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _VolumetricWaterContent.Name = "VolumetricWaterContent";
            _VolumetricWaterContent.Description = "Volumetric soil water content";
            _VolumetricWaterContent.MaxValue = 0.8;
            _VolumetricWaterContent.MinValue = 0;
            _VolumetricWaterContent.DefaultValue = 0.25;
            _VolumetricWaterContent.Units = "m3 m-3";
            _VolumetricWaterContent.URL = "http://";
            _VolumetricWaterContent.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _SoilTemperatureByLayersHourly.Name = "SoilTemperatureByLayersHourly";
            _SoilTemperatureByLayersHourly.Description = "Hourly soil temperature by layers";
            _SoilTemperatureByLayersHourly.MaxValue = 50;
            _SoilTemperatureByLayersHourly.MinValue = -50;
            _SoilTemperatureByLayersHourly.DefaultValue = 15;
            _SoilTemperatureByLayersHourly.Units = "°C";
            _SoilTemperatureByLayersHourly.URL = "http://";
            _SoilTemperatureByLayersHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _SoilTemperaturePreviousDay.Name = "SoilTemperaturePreviousDay";
            _SoilTemperaturePreviousDay.Description = "Last hourly temperature of the day";
            _SoilTemperaturePreviousDay.MaxValue = 50;
            _SoilTemperaturePreviousDay.MinValue = -50;
            _SoilTemperaturePreviousDay.DefaultValue = 115;
            _SoilTemperaturePreviousDay.Units = "°C";
            _SoilTemperaturePreviousDay.URL = "http://";
            _SoilTemperaturePreviousDay.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _SoilTemperatureRangeByLayers.Name = "SoilTemperatureRangeByLayers";
            _SoilTemperatureRangeByLayers.Description = "Soil temperature range by layers";
            _SoilTemperatureRangeByLayers.MaxValue = 50;
            _SoilTemperatureRangeByLayers.MinValue = 0;
            _SoilTemperatureRangeByLayers.DefaultValue = 15;
            _SoilTemperatureRangeByLayers.Units = "°C";
            _SoilTemperatureRangeByLayers.URL = "http://";
            _SoilTemperatureRangeByLayers.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _SoilTemperatureMaximum.Name = "SoilTemperatureMaximum";
            _SoilTemperatureMaximum.Description = "Maximum soil temperature by layers";
            _SoilTemperatureMaximum.MaxValue = 60;
            _SoilTemperatureMaximum.MinValue = -60;
            _SoilTemperatureMaximum.DefaultValue = 15;
            _SoilTemperatureMaximum.Units = "°C";
            _SoilTemperatureMaximum.URL = "http://";
            _SoilTemperatureMaximum.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _SoilTemperatureMinimum.Name = "SoilTemperatureMinimum";
            _SoilTemperatureMinimum.Description = "Minimum soil temperature by layers";
            _SoilTemperatureMinimum.MaxValue = 60;
            _SoilTemperatureMinimum.MinValue = -60;
            _SoilTemperatureMinimum.DefaultValue = 15;
            _SoilTemperatureMinimum.Units = "°C";
            _SoilTemperatureMinimum.URL = "http://";
            _SoilTemperatureMinimum.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _Sand.Name = "Sand";
            _Sand.Description = "Sand content of soil layer";
            _Sand.MaxValue = 100;
            _Sand.MinValue = 0;
            _Sand.DefaultValue = 30;
            _Sand.Units = "%";
            _Sand.URL = "http://";
            _Sand.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _Silt.Name = "Silt";
            _Silt.Description = "Silt content of soil layer";
            _Silt.MaxValue = 100;
            _Silt.MinValue = 0;
            _Silt.DefaultValue = 20;
            _Silt.Units = "%";
            _Silt.URL = "http://";
            _Silt.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _OrganicMatter.Name = "OrganicMatter";
            _OrganicMatter.Description = "Organic matter content of soil layer";
            _OrganicMatter.MaxValue = 20;
            _OrganicMatter.MinValue = 0;
            _OrganicMatter.DefaultValue = 1.5;
            _OrganicMatter.Units = "%";
            _OrganicMatter.URL = "http://";
            _OrganicMatter.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _VolumetricWaterContentAtSaturation.Name = "VolumetricWaterContentAtSaturation";
            _VolumetricWaterContentAtSaturation.Description = "Volumetric water content at saturation";
            _VolumetricWaterContentAtSaturation.MaxValue = 1;
            _VolumetricWaterContentAtSaturation.MinValue = 0;
            _VolumetricWaterContentAtSaturation.DefaultValue = 0.8;
            _VolumetricWaterContentAtSaturation.Units = "m3 m-3";
            _VolumetricWaterContentAtSaturation.URL = "http://";
            _VolumetricWaterContentAtSaturation.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _ThermalConductivity.Name = "ThermalConductivity";
            _ThermalConductivity.Description = "Thermal conductivity of soil layer";
            _ThermalConductivity.MaxValue = 8;
            _ThermalConductivity.MinValue = 0.025;
            _ThermalConductivity.DefaultValue = 1;
            _ThermalConductivity.Units = "W m-1 K-1";
            _ThermalConductivity.URL = "http://";
            _ThermalConductivity.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _ThermalDiffusivity.Name = "ThermalDiffusivity";
            _ThermalDiffusivity.Description = "Thermal diffusivity of soil layer";
            _ThermalDiffusivity.MaxValue = 1;
            _ThermalDiffusivity.MinValue = 0;
            _ThermalDiffusivity.DefaultValue = 0.0025;
            _ThermalDiffusivity.Units = "mm s-1";
            _ThermalDiffusivity.URL = "http://";
            _ThermalDiffusivity.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            // new type - old
        }
        #endregion
    }
}