
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
            VarInfo v1 = new CompositeStrategyVarInfo(_SoilTemperatureSWAT, "LagCoefficient");
            _parameters0_0.Add(v1);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd1.PropertyName = "GlobalSolarRadiation";
            pd1.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.GlobalSolarRadiation).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.GlobalSolarRadiation);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd2.PropertyName = "DayLength";
            pd2.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.DayLength).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.DayLength);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd3.PropertyName = "AboveGroundBiomass";
            pd3.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.AboveGroundBiomass).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.AboveGroundBiomass);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd4.PropertyName = "AirTemperatureMinimum";
            pd4.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMinimum);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd5.PropertyName = "AirTemperatureMaximum";
            pd5.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMaximum);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd6.PropertyName = "VolumetricWaterContent";
            pd6.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.VolumetricWaterContent).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.VolumetricWaterContent);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd7.PropertyName = "BulkDensity";
            pd7.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.BulkDensity).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.BulkDensity);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd8.PropertyName = "LayerThickness";
            pd8.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.LayerThickness).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.LayerThickness);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd9.PropertyName = "AirTemperatureAnnualAverage";
            pd9.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureAnnualAverage).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureAnnualAverage);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd10.PropertyName = "SoilProfileDepth";
            pd10.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilProfileDepth).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilProfileDepth);
            _inputs0_0.Add(pd10);
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd11.PropertyName = "Sand";
            pd11.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.Sand).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.Sand);
            _inputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd12.PropertyName = "OrganicMatter";
            pd12.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.OrganicMatter).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.OrganicMatter);
            _inputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd13.PropertyName = "Clay";
            pd13.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.Clay).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.Clay);
            _inputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd14.PropertyName = "Silt";
            pd14.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.Silt).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.Silt);
            _inputs0_0.Add(pd14);
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd15.PropertyName = "HourOfSunrise";
            pd15.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunrise).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunrise);
            _inputs0_0.Add(pd15);
            PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous);
            pd16.PropertyName = "HourOfSunset";
            pd16.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunset).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunset);
            _inputs0_0.Add(pd16);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd17 = new PropertyDescription();
            pd17.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd17.PropertyName = "SurfaceSoilTemperature";
            pd17.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SurfaceSoilTemperature).ValueType.TypeForCurrentValue;
            pd17.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SurfaceSoilTemperature);
            _outputs0_0.Add(pd17);
            PropertyDescription pd18 = new PropertyDescription();
            pd18.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd18.PropertyName = "SurfaceTemperatureMinimum";
            pd18.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd18.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
            _outputs0_0.Add(pd18);
            PropertyDescription pd19 = new PropertyDescription();
            pd19.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd19.PropertyName = "SurfaceTemperatureMaximum";
            pd19.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd19.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
            _outputs0_0.Add(pd19);
            PropertyDescription pd20 = new PropertyDescription();
            pd20.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd20.PropertyName = "SoilTemperatureByLayers";
            pd20.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayers).ValueType.TypeForCurrentValue;
            pd20.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayers);
            _outputs0_0.Add(pd20);
            PropertyDescription pd21 = new PropertyDescription();
            pd21.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd21.PropertyName = "HeatCapacity";
            pd21.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity).ValueType.TypeForCurrentValue;
            pd21.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity);
            _outputs0_0.Add(pd21);
            PropertyDescription pd22 = new PropertyDescription();
            pd22.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd22.PropertyName = "ThermalConductivity";
            pd22.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalConductivity).ValueType.TypeForCurrentValue;
            pd22.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalConductivity);
            _outputs0_0.Add(pd22);
            PropertyDescription pd23 = new PropertyDescription();
            pd23.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd23.PropertyName = "ThermalDiffusivity";
            pd23.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity).ValueType.TypeForCurrentValue;
            pd23.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity);
            _outputs0_0.Add(pd23);
            PropertyDescription pd24 = new PropertyDescription();
            pd24.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd24.PropertyName = "SoilTemperatureRangeByLayers";
            pd24.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureRangeByLayers).ValueType.TypeForCurrentValue;
            pd24.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureRangeByLayers);
            _outputs0_0.Add(pd24);
            PropertyDescription pd25 = new PropertyDescription();
            pd25.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd25.PropertyName = "SoilTemperatureMinimum";
            pd25.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd25.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMinimum);
            _outputs0_0.Add(pd25);
            PropertyDescription pd26 = new PropertyDescription();
            pd26.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd26.PropertyName = "SoilTemperatureMaximum";
            pd26.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd26.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMaximum);
            _outputs0_0.Add(pd26);
            PropertyDescription pd27 = new PropertyDescription();
            pd27.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd27.PropertyName = "SoilTemperatureByLayersHourly";
            pd27.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayersHourly).ValueType.TypeForCurrentValue;
            pd27.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayersHourly);
            _outputs0_0.Add(pd27);
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

            LagCoefficientVarInfo.Name = "LagCoefficient";
            LagCoefficientVarInfo.Description = "Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature";
            LagCoefficientVarInfo.MaxValue = 1;
            LagCoefficientVarInfo.MinValue = 0;
            LagCoefficientVarInfo.DefaultValue = 0.8;
            LagCoefficientVarInfo.Units = "dimensionless";
            LagCoefficientVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        public static VarInfo LagCoefficientVarInfo
        {
            get { return SurfacePartonSoilSWATHourlyPartonC.Strategies.SoilTemperatureSWAT.LagCoefficientVarInfo;} 
        }

        public string TestPostConditions(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SurfaceSoilTemperature.CurrentValue=s.SurfaceSoilTemperature;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum.CurrentValue=a.SurfaceTemperatureMinimum;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum.CurrentValue=a.SurfaceTemperatureMaximum;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayers.CurrentValue=s.SoilTemperatureByLayers;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity.CurrentValue=s.HeatCapacity;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalConductivity.CurrentValue=s.ThermalConductivity;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity.CurrentValue=s.ThermalDiffusivity;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureRangeByLayers.CurrentValue=s.SoilTemperatureRangeByLayers;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMinimum.CurrentValue=s.SoilTemperatureMinimum;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMaximum.CurrentValue=s.SoilTemperatureMaximum;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayersHourly.CurrentValue=s.SoilTemperatureByLayersHourly;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r18 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SurfaceSoilTemperature);
                if(r18.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SurfaceSoilTemperature.ValueType)){prc.AddCondition(r18);}
                RangeBasedCondition r19 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
                if(r19.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum.ValueType)){prc.AddCondition(r19);}
                RangeBasedCondition r20 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
                if(r20.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum.ValueType)){prc.AddCondition(r20);}
                RangeBasedCondition r21 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayers);
                if(r21.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayers.ValueType)){prc.AddCondition(r21);}
                RangeBasedCondition r22 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity);
                if(r22.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity.ValueType)){prc.AddCondition(r22);}
                RangeBasedCondition r23 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalConductivity);
                if(r23.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalConductivity.ValueType)){prc.AddCondition(r23);}
                RangeBasedCondition r24 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity);
                if(r24.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity.ValueType)){prc.AddCondition(r24);}
                RangeBasedCondition r25 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureRangeByLayers);
                if(r25.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureRangeByLayers.ValueType)){prc.AddCondition(r25);}
                RangeBasedCondition r26 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMinimum);
                if(r26.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMinimum.ValueType)){prc.AddCondition(r26);}
                RangeBasedCondition r27 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMaximum);
                if(r27.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMaximum.ValueType)){prc.AddCondition(r27);}
                RangeBasedCondition r28 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayersHourly);
                if(r28.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureByLayersHourly.ValueType)){prc.AddCondition(r28);}

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
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.GlobalSolarRadiation.CurrentValue=ex.GlobalSolarRadiation;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.DayLength.CurrentValue=ex.DayLength;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.AboveGroundBiomass.CurrentValue=s.AboveGroundBiomass;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMinimum.CurrentValue=ex.AirTemperatureMinimum;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMaximum.CurrentValue=ex.AirTemperatureMaximum;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.VolumetricWaterContent.CurrentValue=s.VolumetricWaterContent;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.BulkDensity.CurrentValue=s.BulkDensity;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.LayerThickness.CurrentValue=s.LayerThickness;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureAnnualAverage.CurrentValue=ex.AirTemperatureAnnualAverage;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilProfileDepth.CurrentValue=s.SoilProfileDepth;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.Sand.CurrentValue=s.Sand;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.OrganicMatter.CurrentValue=s.OrganicMatter;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.Clay.CurrentValue=s.Clay;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.Silt.CurrentValue=s.Silt;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunrise.CurrentValue=ex.HourOfSunrise;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunset.CurrentValue=ex.HourOfSunset;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.GlobalSolarRadiation);
                if(r1.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.GlobalSolarRadiation.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.DayLength);
                if(r2.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.DayLength.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.AboveGroundBiomass);
                if(r3.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.AboveGroundBiomass.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMinimum);
                if(r4.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMinimum.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMaximum);
                if(r5.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureMaximum.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.VolumetricWaterContent);
                if(r6.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.VolumetricWaterContent.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.BulkDensity);
                if(r7.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.BulkDensity.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.LayerThickness);
                if(r8.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.LayerThickness.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureAnnualAverage);
                if(r9.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.AirTemperatureAnnualAverage.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilProfileDepth);
                if(r10.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilProfileDepth.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.Sand);
                if(r11.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.Sand.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.OrganicMatter);
                if(r12.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.OrganicMatter.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.Clay);
                if(r13.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.Clay.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.Silt);
                if(r14.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.Silt.ValueType)){prc.AddCondition(r14);}
                RangeBasedCondition r15 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunrise);
                if(r15.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunrise.ValueType)){prc.AddCondition(r15);}
                RangeBasedCondition r16 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunset);
                if(r16.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenousVarInfo.HourOfSunset.ValueType)){prc.AddCondition(r16);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LagCoefficient")));
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
                LagCoefficient = toCopy.LagCoefficient;
        }
    }
}