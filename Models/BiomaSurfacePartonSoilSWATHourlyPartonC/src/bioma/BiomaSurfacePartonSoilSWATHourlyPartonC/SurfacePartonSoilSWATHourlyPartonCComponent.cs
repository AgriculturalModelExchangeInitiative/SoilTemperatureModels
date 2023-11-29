
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using CRA.ModelLayer.MetadataTypes;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.Strategy;
using System.Reflection;
using VarInfo=CRA.ModelLayer.Core.VarInfo;
using Preconditions=CRA.ModelLayer.Core.Preconditions;
using CRA.AgroManagement;       

using SurfacePartonSoilSWATHourlyPartonC.DomainClass;
namespace SurfacePartonSoilSWATHourlyPartonC.Strategies
{
    public class SurfacePartonSoilSWATHourlyPartonCComponent : IStrategySurfacePartonSoilSWATHourlyPartonC
    {
        public SurfacePartonSoilSWATHourlyPartonCComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_SoilTemperatureSWAT, "BulkDensity");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_VolumetricHeatCapacityKluitenberg, "BulkDensity");
            _parameters0_0.Add(v2);
            VarInfo v3 = new CompositeStrategyVarInfo(_ThermalConductivitySIMULAT, "BulkDensity");
            _parameters0_0.Add(v3);
            VarInfo v4 = new CompositeStrategyVarInfo(_SoilTemperatureSWAT, "SoilProfileDepth");
            _parameters0_0.Add(v4);
            VarInfo v5 = new CompositeStrategyVarInfo(_SoilTemperatureSWAT, "AirTemperatureAnnualAverage");
            _parameters0_0.Add(v5);
            VarInfo v6 = new CompositeStrategyVarInfo(_SoilTemperatureSWAT, "LagCoefficient");
            _parameters0_0.Add(v6);
            VarInfo v7 = new CompositeStrategyVarInfo(_SoilTemperatureSWAT, "LayerThickness");
            _parameters0_0.Add(v7);
            VarInfo v8 = new CompositeStrategyVarInfo(_RangeOfSoilTemperaturesDAYCENT, "LayerThickness");
            _parameters0_0.Add(v8);
            VarInfo v9 = new CompositeStrategyVarInfo(_VolumetricHeatCapacityKluitenberg, "Clay");
            _parameters0_0.Add(v9);
            VarInfo v10 = new CompositeStrategyVarInfo(_ThermalConductivitySIMULAT, "Clay");
            _parameters0_0.Add(v10);
            VarInfo v11 = new CompositeStrategyVarInfo(_VolumetricHeatCapacityKluitenberg, "Silt");
            _parameters0_0.Add(v11);
            VarInfo v12 = new CompositeStrategyVarInfo(_ThermalDiffu, "layersNumber");
            _parameters0_0.Add(v12);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd1.PropertyName = "AirTemperatureMaximum";
            pd1.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMaximum);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd2.PropertyName = "GlobalSolarRadiation";
            pd2.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.GlobalSolarRadiation).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.GlobalSolarRadiation);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd3.PropertyName = "AirTemperatureMinimum";
            pd3.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMinimum);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd4.PropertyName = "AboveGroundBiomass";
            pd4.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.AboveGroundBiomass).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.AboveGroundBiomass);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd5.PropertyName = "DayLength";
            pd5.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.DayLength).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.DayLength);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd6.PropertyName = "VolumetricWaterContent";
            pd6.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.VolumetricWaterContent).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.VolumetricWaterContent);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd7.PropertyName = "OrganicMatter";
            pd7.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.OrganicMatter).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.OrganicMatter);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd8.PropertyName = "Sand";
            pd8.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.Sand).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.Sand);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd9.PropertyName = "HourOfSunrise";
            pd9.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunrise).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunrise);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd10.PropertyName = "HourOfSunset";
            pd10.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunset).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunset);
            _inputs0_0.Add(pd10);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd11.PropertyName = "SurfaceSoilTemperature";
            pd11.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceSoilTemperature).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceSoilTemperature);
            _outputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd12.PropertyName = "SurfaceTemperatureMinimum";
            pd12.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
            _outputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd13.PropertyName = "SurfaceTemperatureMaximum";
            pd13.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
            _outputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd14.PropertyName = "SoilTemperatureByLayers";
            pd14.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayers).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayers);
            _outputs0_0.Add(pd14);
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd15.PropertyName = "HeatCapacity";
            pd15.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity);
            _outputs0_0.Add(pd15);
            PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd16.PropertyName = "ThermalConductivity";
            pd16.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalConductivity).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalConductivity);
            _outputs0_0.Add(pd16);
            PropertyDescription pd17 = new PropertyDescription();
            pd17.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd17.PropertyName = "ThermalDiffusivity";
            pd17.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity).ValueType.TypeForCurrentValue;
            pd17.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity);
            _outputs0_0.Add(pd17);
            PropertyDescription pd18 = new PropertyDescription();
            pd18.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd18.PropertyName = "SoilTemperatureRangeByLayers";
            pd18.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureRangeByLayers).ValueType.TypeForCurrentValue;
            pd18.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureRangeByLayers);
            _outputs0_0.Add(pd18);
            PropertyDescription pd19 = new PropertyDescription();
            pd19.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd19.PropertyName = "SoilTemperatureMinimum";
            pd19.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd19.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMinimum);
            _outputs0_0.Add(pd19);
            PropertyDescription pd20 = new PropertyDescription();
            pd20.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd20.PropertyName = "SoilTemperatureMaximum";
            pd20.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd20.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMaximum);
            _outputs0_0.Add(pd20);
            PropertyDescription pd21 = new PropertyDescription();
            pd21.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd21.PropertyName = "SoilTemperatureByLayersHourly";
            pd21.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayersHourly).ValueType.TypeForCurrentValue;
            pd21.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayersHourly);
            _outputs0_0.Add(pd21);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(SurfacePartonSoilSWATHourlyPartonC.Strategies.SurfaceTemperatureParton).FullName);
            lAssStrat0_0.Add(typeof(SurfacePartonSoilSWATHourlyPartonC.Strategies.SoilTemperatureSWAT).FullName);
            lAssStrat0_0.Add(typeof(SurfacePartonSoilSWATHourlyPartonC.Strategies.VolumetricHeatCapacityKluitenberg).FullName);
            lAssStrat0_0.Add(typeof(SurfacePartonSoilSWATHourlyPartonC.Strategies.ThermalConductivitySIMULAT).FullName);
            lAssStrat0_0.Add(typeof(SurfacePartonSoilSWATHourlyPartonC.Strategies.ThermalDiffu).FullName);
            lAssStrat0_0.Add(typeof(SurfacePartonSoilSWATHourlyPartonC.Strategies.RangeOfSoilTemperaturesDAYCENT).FullName);
            lAssStrat0_0.Add(typeof(SurfacePartonSoilSWATHourlyPartonC.Strategies.HourlySoilTemperaturesPartonLogan).FullName);
            mo0_0.AssociatedStrategies = lAssStrat0_0;
            _modellingOptionsManager = new ModellingOptionsManager(mo0_0);
            SetStaticParametersVarInfoDefinitions();
            SetPublisherData();
        }

        public string Description
        {
            get { return "" ;}
        }

        public string URL
        {
            get { return "" ;}
        }

        public string Domain
        {
            get { return "";}
        }

        public string ModelType
        {
            get { return "";}
        }

        public bool IsContext
        {
            get { return false;}
        }

        public IList<int> TimeStep
        {
            get
            {
                IList<int> ts = new List<int>();
                return ts;
            }
        }

        private  PublisherData _pd;
        public PublisherData PublisherData
        {
            get { return _pd;} 
        }

        private  void SetPublisherData()
        {
            _pd = new CRA.ModelLayer.MetadataTypes.PublisherData();
            _pd.Add("Creator", "simone.bregaglio@unimi.it");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "Universiy Of Milan "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState), typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState), typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate), typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary), typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous)};
        }

        public double[] BulkDensity
        {
            get
            {
                 return _SoilTemperatureSWAT.BulkDensity; 
            }
            set
            {
                _SoilTemperatureSWAT.BulkDensity = value;
                _VolumetricHeatCapacityKluitenberg.BulkDensity = value;
                _ThermalConductivitySIMULAT.BulkDensity = value;
            }
        }
        public double SoilProfileDepth
        {
            get
            {
                 return _SoilTemperatureSWAT.SoilProfileDepth; 
            }
            set
            {
                _SoilTemperatureSWAT.SoilProfileDepth = value;
            }
        }
        public double AirTemperatureAnnualAverage
        {
            get
            {
                 return _SoilTemperatureSWAT.AirTemperatureAnnualAverage; 
            }
            set
            {
                _SoilTemperatureSWAT.AirTemperatureAnnualAverage = value;
            }
        }
        public double LagCoefficient
        {
            get
            {
                 return _SoilTemperatureSWAT.LagCoefficient; 
            }
            set
            {
                _SoilTemperatureSWAT.LagCoefficient = value;
            }
        }
        public double[] LayerThickness
        {
            get
            {
                 return _SoilTemperatureSWAT.LayerThickness; 
            }
            set
            {
                _SoilTemperatureSWAT.LayerThickness = value;
                _RangeOfSoilTemperaturesDAYCENT.LayerThickness = value;
            }
        }
        public double[] Clay
        {
            get
            {
                 return _VolumetricHeatCapacityKluitenberg.Clay; 
            }
            set
            {
                _VolumetricHeatCapacityKluitenberg.Clay = value;
                _ThermalConductivitySIMULAT.Clay = value;
            }
        }
        public double[] Silt
        {
            get
            {
                 return _VolumetricHeatCapacityKluitenberg.Silt; 
            }
            set
            {
                _VolumetricHeatCapacityKluitenberg.Silt = value;
            }
        }
        public int layersNumber
        {
            get
            {
                 return _ThermalDiffu.layersNumber; 
            }
            set
            {
                _ThermalDiffu.layersNumber = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _SurfaceTemperatureParton.SetParametersDefaultValue();
            _SoilTemperatureSWAT.SetParametersDefaultValue();
            _VolumetricHeatCapacityKluitenberg.SetParametersDefaultValue();
            _ThermalConductivitySIMULAT.SetParametersDefaultValue();
            _ThermalDiffu.SetParametersDefaultValue();
            _RangeOfSoilTemperaturesDAYCENT.SetParametersDefaultValue();
            _HourlySoilTemperaturesPartonLogan.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            BulkDensityVarInfo.Name = "BulkDensity";
            BulkDensityVarInfo.Description = "Bulk density";
            BulkDensityVarInfo.MaxValue = -1D;
            BulkDensityVarInfo.MinValue = -1D;
            BulkDensityVarInfo.DefaultValue = -1D;
            BulkDensityVarInfo.Units = "t m-3";
            BulkDensityVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            SoilProfileDepthVarInfo.Name = "SoilProfileDepth";
            SoilProfileDepthVarInfo.Description = "Soil profile depth";
            SoilProfileDepthVarInfo.MaxValue = 50;
            SoilProfileDepthVarInfo.MinValue = 0;
            SoilProfileDepthVarInfo.DefaultValue = 3;
            SoilProfileDepthVarInfo.Units = "m";
            SoilProfileDepthVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            AirTemperatureAnnualAverageVarInfo.Name = "AirTemperatureAnnualAverage";
            AirTemperatureAnnualAverageVarInfo.Description = "Annual average air temperature";
            AirTemperatureAnnualAverageVarInfo.MaxValue = 50;
            AirTemperatureAnnualAverageVarInfo.MinValue = -40;
            AirTemperatureAnnualAverageVarInfo.DefaultValue = 15;
            AirTemperatureAnnualAverageVarInfo.Units = "degC";
            AirTemperatureAnnualAverageVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            LagCoefficientVarInfo.Name = "LagCoefficient";
            LagCoefficientVarInfo.Description = "Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature";
            LagCoefficientVarInfo.MaxValue = 1;
            LagCoefficientVarInfo.MinValue = 0;
            LagCoefficientVarInfo.DefaultValue = 0.8;
            LagCoefficientVarInfo.Units = "dimensionless";
            LagCoefficientVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            LayerThicknessVarInfo.Name = "LayerThickness";
            LayerThicknessVarInfo.Description = "Soil layer thickness";
            LayerThicknessVarInfo.MaxValue = -1D;
            LayerThicknessVarInfo.MinValue = -1D;
            LayerThicknessVarInfo.DefaultValue = -1D;
            LayerThicknessVarInfo.Units = "m";
            LayerThicknessVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            ClayVarInfo.Name = "Clay";
            ClayVarInfo.Description = "Clay content of soil layer";
            ClayVarInfo.MaxValue = -1D;
            ClayVarInfo.MinValue = -1D;
            ClayVarInfo.DefaultValue = -1D;
            ClayVarInfo.Units = "";
            ClayVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            SiltVarInfo.Name = "Silt";
            SiltVarInfo.Description = "Silt content of soil layer";
            SiltVarInfo.MaxValue = -1D;
            SiltVarInfo.MinValue = -1D;
            SiltVarInfo.DefaultValue = -1D;
            SiltVarInfo.Units = "";
            SiltVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            layersNumberVarInfo.Name = "layersNumber";
            layersNumberVarInfo.Description = "Number of layersl";
            layersNumberVarInfo.MaxValue = 300;
            layersNumberVarInfo.MinValue = 0;
            layersNumberVarInfo.DefaultValue = 10;
            layersNumberVarInfo.Units = "dimensionless";
            layersNumberVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
        }

        public static VarInfo BulkDensityVarInfo
        {
            get { return SurfacePartonSoilSWATHourlyPartonC.Strategies.SoilTemperatureSWAT.BulkDensityVarInfo;} 
        }

        public static VarInfo SoilProfileDepthVarInfo
        {
            get { return SurfacePartonSoilSWATHourlyPartonC.Strategies.SoilTemperatureSWAT.SoilProfileDepthVarInfo;} 
        }

        public static VarInfo AirTemperatureAnnualAverageVarInfo
        {
            get { return SurfacePartonSoilSWATHourlyPartonC.Strategies.SoilTemperatureSWAT.AirTemperatureAnnualAverageVarInfo;} 
        }

        public static VarInfo LagCoefficientVarInfo
        {
            get { return SurfacePartonSoilSWATHourlyPartonC.Strategies.SoilTemperatureSWAT.LagCoefficientVarInfo;} 
        }

        public static VarInfo LayerThicknessVarInfo
        {
            get { return SurfacePartonSoilSWATHourlyPartonC.Strategies.SoilTemperatureSWAT.LayerThicknessVarInfo;} 
        }

        public static VarInfo ClayVarInfo
        {
            get { return SurfacePartonSoilSWATHourlyPartonC.Strategies.VolumetricHeatCapacityKluitenberg.ClayVarInfo;} 
        }

        public static VarInfo SiltVarInfo
        {
            get { return SurfacePartonSoilSWATHourlyPartonC.Strategies.VolumetricHeatCapacityKluitenberg.SiltVarInfo;} 
        }

        public static VarInfo layersNumberVarInfo
        {
            get { return SurfacePartonSoilSWATHourlyPartonC.Strategies.ThermalDiffu.layersNumberVarInfo;} 
        }

        public string TestPostConditions(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceSoilTemperature.CurrentValue=a.SurfaceSoilTemperature;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum.CurrentValue=a.SurfaceTemperatureMinimum;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum.CurrentValue=a.SurfaceTemperatureMaximum;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayers.CurrentValue=s.SoilTemperatureByLayers;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity.CurrentValue=s.HeatCapacity;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalConductivity.CurrentValue=a.ThermalConductivity;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity.CurrentValue=s.ThermalDiffusivity;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureRangeByLayers.CurrentValue=a.SoilTemperatureRangeByLayers;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMinimum.CurrentValue=a.SoilTemperatureMinimum;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMaximum.CurrentValue=a.SoilTemperatureMaximum;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayersHourly.CurrentValue=s.SoilTemperatureByLayersHourly;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r19 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceSoilTemperature);
                if(r19.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceSoilTemperature.ValueType)){prc.AddCondition(r19);}
                RangeBasedCondition r20 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
                if(r20.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum.ValueType)){prc.AddCondition(r20);}
                RangeBasedCondition r21 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
                if(r21.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum.ValueType)){prc.AddCondition(r21);}
                RangeBasedCondition r22 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayers);
                if(r22.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayers.ValueType)){prc.AddCondition(r22);}
                RangeBasedCondition r23 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity);
                if(r23.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity.ValueType)){prc.AddCondition(r23);}
                RangeBasedCondition r24 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalConductivity);
                if(r24.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalConductivity.ValueType)){prc.AddCondition(r24);}
                RangeBasedCondition r25 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity);
                if(r25.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity.ValueType)){prc.AddCondition(r25);}
                RangeBasedCondition r26 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureRangeByLayers);
                if(r26.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureRangeByLayers.ValueType)){prc.AddCondition(r26);}
                RangeBasedCondition r27 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMinimum);
                if(r27.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMinimum.ValueType)){prc.AddCondition(r27);}
                RangeBasedCondition r28 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMaximum);
                if(r28.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMaximum.ValueType)){prc.AddCondition(r28);}
                RangeBasedCondition r29 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayersHourly);
                if(r29.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayersHourly.ValueType)){prc.AddCondition(r29);}

                string ret = "";
                ret += _SurfaceTemperatureParton.TestPostConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _SoilTemperatureSWAT.TestPostConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _VolumetricHeatCapacityKluitenberg.TestPostConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _ThermalConductivitySIMULAT.TestPostConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _ThermalDiffu.TestPostConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _RangeOfSoilTemperaturesDAYCENT.TestPostConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _HourlySoilTemperaturesPartonLogan.TestPostConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .SurfacePartonSoilSWATHourlyPartonC, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMaximum.CurrentValue=ex.AirTemperatureMaximum;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.GlobalSolarRadiation.CurrentValue=ex.GlobalSolarRadiation;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMinimum.CurrentValue=ex.AirTemperatureMinimum;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.AboveGroundBiomass.CurrentValue=a.AboveGroundBiomass;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.DayLength.CurrentValue=ex.DayLength;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.VolumetricWaterContent.CurrentValue=a.VolumetricWaterContent;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.OrganicMatter.CurrentValue=a.OrganicMatter;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.Sand.CurrentValue=a.Sand;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunrise.CurrentValue=ex.HourOfSunrise;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunset.CurrentValue=ex.HourOfSunset;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMaximum);
                if(r1.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMaximum.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.GlobalSolarRadiation);
                if(r2.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.GlobalSolarRadiation.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMinimum);
                if(r3.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMinimum.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.AboveGroundBiomass);
                if(r4.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.AboveGroundBiomass.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.DayLength);
                if(r5.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.DayLength.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.VolumetricWaterContent);
                if(r6.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.VolumetricWaterContent.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.OrganicMatter);
                if(r7.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.OrganicMatter.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.Sand);
                if(r8.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.Sand.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunrise);
                if(r9.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunrise.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunset);
                if(r10.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunset.ValueType)){prc.AddCondition(r10);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("BulkDensity")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SoilProfileDepth")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("AirTemperatureAnnualAverage")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LagCoefficient")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LayerThickness")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("Clay")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("Silt")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("layersNumber")));
                string ret = "";
                ret += _SurfaceTemperatureParton.TestPreConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _SoilTemperatureSWAT.TestPreConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _VolumetricHeatCapacityKluitenberg.TestPreConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _ThermalConductivitySIMULAT.TestPreConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _ThermalDiffu.TestPreConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _RangeOfSoilTemperaturesDAYCENT.TestPreConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _HourlySoilTemperaturesPartonLogan.TestPreConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .SurfacePartonSoilSWATHourlyPartonC, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SurfacePartonSoilSWATHourlyPartonC, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        SurfaceTemperatureParton _SurfaceTemperatureParton = new SurfaceTemperatureParton();
        SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();
        VolumetricHeatCapacityKluitenberg _VolumetricHeatCapacityKluitenberg = new VolumetricHeatCapacityKluitenberg();
        ThermalConductivitySIMULAT _ThermalConductivitySIMULAT = new ThermalConductivitySIMULAT();
        ThermalDiffu _ThermalDiffu = new ThermalDiffu();
        RangeOfSoilTemperaturesDAYCENT _RangeOfSoilTemperaturesDAYCENT = new RangeOfSoilTemperaturesDAYCENT();
        HourlySoilTemperaturesPartonLogan _HourlySoilTemperaturesPartonLogan = new HourlySoilTemperaturesPartonLogan();

        private void EstimateOfAssociatedClasses(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex)
        {
            _surfacetemperatureparton.Estimate(s,s1, r, a, ex);
            _volumetricheatcapacitykluitenberg.Estimate(s,s1, r, a, ex);
            _thermalconductivitysimulat.Estimate(s,s1, r, a, ex);
            _soiltemperatureswat.Estimate(s,s1, r, a, ex);
            _thermaldiffu.Estimate(s,s1, r, a, ex);
            _rangeofsoiltemperaturesdaycent.Estimate(s,s1, r, a, ex);
            _hourlysoiltemperaturespartonlogan.Estimate(s,s1, r, a, ex);
        }

        public SurfacePartonSoilSWATHourlyPartonCComponent(SurfacePartonSoilSWATHourlyPartonCComponent toCopy): this() // copy constructor 
        {
                
            for (int i = 0; i < toCopy._BulkDensity.Length; i++)
            { BulkDensity[i] = toCopy.BulkDensity[i]; }
    
                SoilProfileDepth = toCopy.SoilProfileDepth;
                AirTemperatureAnnualAverage = toCopy.AirTemperatureAnnualAverage;
                LagCoefficient = toCopy.LagCoefficient;
                
            for (int i = 0; i < toCopy._LayerThickness.Length; i++)
            { LayerThickness[i] = toCopy.LayerThickness[i]; }
    
                
            for (int i = 0; i < toCopy._Clay.Length; i++)
            { Clay[i] = toCopy.Clay[i]; }
    
                
            for (int i = 0; i < toCopy._Silt.Length; i++)
            { Silt[i] = toCopy.Silt[i]; }
    
                layersNumber = toCopy.layersNumber;
        }
    }
}