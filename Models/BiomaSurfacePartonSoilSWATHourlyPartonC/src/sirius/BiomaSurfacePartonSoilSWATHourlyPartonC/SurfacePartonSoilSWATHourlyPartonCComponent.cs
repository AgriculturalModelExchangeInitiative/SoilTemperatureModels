
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

using SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass;
namespace SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies
{
    public class SurfacePartonSoilSWATHourlyPartonCComponent : IStrategySiriusQualitySurfacePartonSoilSWATHourlyPartonC
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
            pd1.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd1.PropertyName = "AirTemperatureMaximum";
            pd1.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMaximum);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd2.PropertyName = "GlobalSolarRadiation";
            pd2.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.GlobalSolarRadiation).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.GlobalSolarRadiation);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd3.PropertyName = "AirTemperatureMinimum";
            pd3.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMinimum);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd4.PropertyName = "AboveGroundBiomass";
            pd4.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.AboveGroundBiomass).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.AboveGroundBiomass);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd5.PropertyName = "DayLength";
            pd5.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.DayLength).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.DayLength);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd6.PropertyName = "VolumetricWaterContent";
            pd6.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.VolumetricWaterContent).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.VolumetricWaterContent);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd7.PropertyName = "OrganicMatter";
            pd7.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.OrganicMatter).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.OrganicMatter);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd8.PropertyName = "Sand";
            pd8.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.Sand).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.Sand);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd9.PropertyName = "HourOfSunrise";
            pd9.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunrise).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunrise);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd10.PropertyName = "HourOfSunset";
            pd10.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunset).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunset);
            _inputs0_0.Add(pd10);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd11.PropertyName = "SurfaceSoilTemperature";
            pd11.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceSoilTemperature).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceSoilTemperature);
            _outputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd12.PropertyName = "SurfaceTemperatureMinimum";
            pd12.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
            _outputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd13.PropertyName = "SurfaceTemperatureMaximum";
            pd13.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
            _outputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd14.PropertyName = "SoilTemperatureByLayers";
            pd14.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayers).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayers);
            _outputs0_0.Add(pd14);
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd15.PropertyName = "HeatCapacity";
            pd15.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity);
            _outputs0_0.Add(pd15);
            PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd16.PropertyName = "ThermalConductivity";
            pd16.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalConductivity).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalConductivity);
            _outputs0_0.Add(pd16);
            PropertyDescription pd17 = new PropertyDescription();
            pd17.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd17.PropertyName = "ThermalDiffusivity";
            pd17.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity).ValueType.TypeForCurrentValue;
            pd17.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity);
            _outputs0_0.Add(pd17);
            PropertyDescription pd18 = new PropertyDescription();
            pd18.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd18.PropertyName = "SoilTemperatureRangeByLayers";
            pd18.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureRangeByLayers).ValueType.TypeForCurrentValue;
            pd18.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureRangeByLayers);
            _outputs0_0.Add(pd18);
            PropertyDescription pd19 = new PropertyDescription();
            pd19.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd19.PropertyName = "SoilTemperatureMinimum";
            pd19.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd19.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMinimum);
            _outputs0_0.Add(pd19);
            PropertyDescription pd20 = new PropertyDescription();
            pd20.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd20.PropertyName = "SoilTemperatureMaximum";
            pd20.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd20.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMaximum);
            _outputs0_0.Add(pd20);
            PropertyDescription pd21 = new PropertyDescription();
            pd21.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd21.PropertyName = "SoilTemperatureByLayersHourly";
            pd21.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayersHourly).ValueType.TypeForCurrentValue;
            pd21.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayersHourly);
            _outputs0_0.Add(pd21);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SurfaceTemperatureParton).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SoilTemperatureSWAT).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.VolumetricHeatCapacityKluitenberg).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.ThermalConductivitySIMULAT).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.ThermalDiffu).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.RangeOfSoilTemperaturesDAYCENT).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.HourlySoilTemperaturesPartonLogan).FullName);
            mo0_0.AssociatedStrategies = lAssStrat0_0;
            _modellingOptionsManager = new ModellingOptionsManager(mo0_0);
            SetStaticParametersVarInfoDefinitions();
            SetPublisherData();
        }

        public string Description
        {
            get { return "Composite strategy for the calculation of surface temperature with Parton's method and soil temperature with SWAT method. See also references of the associated strategies." ;}
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
            return new List<Type>() {  typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState), typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState), typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate), typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary), typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous)};
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
            get { return SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SoilTemperatureSWAT.BulkDensityVarInfo;} 
        }

        public static VarInfo SoilProfileDepthVarInfo
        {
            get { return SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SoilTemperatureSWAT.SoilProfileDepthVarInfo;} 
        }

        public static VarInfo AirTemperatureAnnualAverageVarInfo
        {
            get { return SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SoilTemperatureSWAT.AirTemperatureAnnualAverageVarInfo;} 
        }

        public static VarInfo LagCoefficientVarInfo
        {
            get { return SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SoilTemperatureSWAT.LagCoefficientVarInfo;} 
        }

        public static VarInfo LayerThicknessVarInfo
        {
            get { return SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SoilTemperatureSWAT.LayerThicknessVarInfo;} 
        }

        public static VarInfo ClayVarInfo
        {
            get { return SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.VolumetricHeatCapacityKluitenberg.ClayVarInfo;} 
        }

        public static VarInfo SiltVarInfo
        {
            get { return SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.VolumetricHeatCapacityKluitenberg.SiltVarInfo;} 
        }

        public static VarInfo layersNumberVarInfo
        {
            get { return SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.ThermalDiffu.layersNumberVarInfo;} 
        }

        public string TestPostConditions(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceSoilTemperature.CurrentValue=a.SurfaceSoilTemperature;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum.CurrentValue=a.SurfaceTemperatureMinimum;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum.CurrentValue=a.SurfaceTemperatureMaximum;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayers.CurrentValue=s.SoilTemperatureByLayers;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity.CurrentValue=s.HeatCapacity;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalConductivity.CurrentValue=a.ThermalConductivity;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity.CurrentValue=s.ThermalDiffusivity;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureRangeByLayers.CurrentValue=a.SoilTemperatureRangeByLayers;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMinimum.CurrentValue=a.SoilTemperatureMinimum;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMaximum.CurrentValue=a.SoilTemperatureMaximum;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayersHourly.CurrentValue=s.SoilTemperatureByLayersHourly;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r19 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceSoilTemperature);
                if(r19.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceSoilTemperature.ValueType)){prc.AddCondition(r19);}
                RangeBasedCondition r20 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
                if(r20.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum.ValueType)){prc.AddCondition(r20);}
                RangeBasedCondition r21 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
                if(r21.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum.ValueType)){prc.AddCondition(r21);}
                RangeBasedCondition r22 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayers);
                if(r22.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayers.ValueType)){prc.AddCondition(r22);}
                RangeBasedCondition r23 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity);
                if(r23.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity.ValueType)){prc.AddCondition(r23);}
                RangeBasedCondition r24 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalConductivity);
                if(r24.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalConductivity.ValueType)){prc.AddCondition(r24);}
                RangeBasedCondition r25 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity);
                if(r25.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity.ValueType)){prc.AddCondition(r25);}
                RangeBasedCondition r26 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureRangeByLayers);
                if(r26.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureRangeByLayers.ValueType)){prc.AddCondition(r26);}
                RangeBasedCondition r27 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMinimum);
                if(r27.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMinimum.ValueType)){prc.AddCondition(r27);}
                RangeBasedCondition r28 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMaximum);
                if(r28.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureMaximum.ValueType)){prc.AddCondition(r28);}
                RangeBasedCondition r29 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayersHourly);
                if(r29.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayersHourly.ValueType)){prc.AddCondition(r29);}

                string ret = "";
                ret += _SurfaceTemperatureParton.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _SoilTemperatureSWAT.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _VolumetricHeatCapacityKluitenberg.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _ThermalConductivitySIMULAT.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _ThermalDiffu.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _RangeOfSoilTemperaturesDAYCENT.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _HourlySoilTemperaturesPartonLogan.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.SurfacePartonSoilSWATHourlyPartonC, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMaximum.CurrentValue=ex.AirTemperatureMaximum;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.GlobalSolarRadiation.CurrentValue=ex.GlobalSolarRadiation;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMinimum.CurrentValue=ex.AirTemperatureMinimum;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.AboveGroundBiomass.CurrentValue=a.AboveGroundBiomass;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.DayLength.CurrentValue=ex.DayLength;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.VolumetricWaterContent.CurrentValue=a.VolumetricWaterContent;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.OrganicMatter.CurrentValue=a.OrganicMatter;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.Sand.CurrentValue=a.Sand;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunrise.CurrentValue=ex.HourOfSunrise;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunset.CurrentValue=ex.HourOfSunset;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMaximum);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMaximum.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.GlobalSolarRadiation);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.GlobalSolarRadiation.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMinimum);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMinimum.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.AboveGroundBiomass);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.AboveGroundBiomass.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.DayLength);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.DayLength.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.VolumetricWaterContent);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.VolumetricWaterContent.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.OrganicMatter);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.OrganicMatter.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.Sand);
                if(r8.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.Sand.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunrise);
                if(r9.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunrise.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunset);
                if(r10.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunset.ValueType)){prc.AddCondition(r10);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("BulkDensity")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SoilProfileDepth")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("AirTemperatureAnnualAverage")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LagCoefficient")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LayerThickness")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("Clay")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("Silt")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("layersNumber")));
                string ret = "";
                ret += _SurfaceTemperatureParton.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _SoilTemperatureSWAT.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _VolumetricHeatCapacityKluitenberg.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _ThermalConductivitySIMULAT.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _ThermalDiffu.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _RangeOfSoilTemperaturesDAYCENT.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                ret += _HourlySoilTemperaturesPartonLogan.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies.SurfacePartonSoilSWATHourlyPartonC");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.SurfacePartonSoilSWATHourlyPartonC, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualitySurfacePartonSoilSWATHourlyPartonC, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex)
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

        private void EstimateOfAssociatedClasses(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex)
        {
            _SurfaceTemperatureParton.Estimate(s,s1, r, a, ex);
            _VolumetricHeatCapacityKluitenberg.Estimate(s,s1, r, a, ex);
            _ThermalConductivitySIMULAT.Estimate(s,s1, r, a, ex);
            _SoilTemperatureSWAT.Estimate(s,s1, r, a, ex);
            _ThermalDiffu.Estimate(s,s1, r, a, ex);
            _RangeOfSoilTemperaturesDAYCENT.Estimate(s,s1, r, a, ex);
            _HourlySoilTemperaturesPartonLogan.Estimate(s,s1, r, a, ex);
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