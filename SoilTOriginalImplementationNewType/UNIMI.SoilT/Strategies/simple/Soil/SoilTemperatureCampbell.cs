

//Author:Simone Bregaglio simone.bregaglio@unimi.it
//Institution:University Of Milan
//Author of revision:Nicolò Frasso nicolo.frasso@unimi.it
//Date first release:12/1/2012
//Date of revision:4/10/2014

using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using CRA.ModelLayer.MetadataTypes;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.Strategy;
using System.Reflection;
using CRA.ModelLayer;

using UNIMI.SoilT.Interfaces;
using CRA.AgroManagement;
using CRA.AgroManagement.Impacts;
using CRA.AgroManagement.Rules;


//To make this project compile please add the reference to assembly: UNIMI.SoilT.Interfaces, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//To make this project compile please add the reference to assembly: CRA.ModelLayer.Core, Version=0.8.4692.22654, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: CRA.ModelLayer.MetadataTypes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: CRA.ModelLayer.Strategy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: EC.JRC.MARS.ParametersManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: CRA.AgroManagement, Version=0.8.0.0, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: CRA.ModelLayer.Core, Version=0.8.4657.21311, Culture=neutral, PublicKeyToken=null;

namespace UNIMI.SoilT.Strategies.Soil
{

    /// <summary>
    ///Class SoilTemperatureCampbell
    /// Campbel strategy - strategy. References: "Soil physics with basic" Gaylon S. Campbell Elsevier 1985.
    /// </summary>
    public class SoilTemperatureCampbell : IStrategySoilT
    {

        #region Constructor

        public SoilTemperatureCampbell()
        {

            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 20;
            v1.Description = "Thermal conductance between soil and atmosphere";
            v1.Id = 0;
            v1.MaxValue = 100;
            v1.MinValue = 0;
            v1.Name = "ThermalK";
            v1.Size = 1;
            v1.Units = "W/m2 °C";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = 0.6;
            v2.Description = "Weighting factor of time";
            v2.Id = 0;
            v2.MaxValue = 1;
            v2.MinValue = 0;
            v2.Name = "ETA";
            v2.Size = 1;
            v2.Units = "dimensionless";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v2);
            VarInfo v3 = new VarInfo();
            v3.DefaultValue = 3600;
            v3.Description = "Timestep in sec";
            v3.Id = 0;
            v3.MaxValue = 86400;
            v3.MinValue = 1;
            v3.Name = "Timestep";
            v3.Size = 1;
            v3.Units = "dimensionless";
            v3.URL = "";
            v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v3.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v3);
            VarInfo v4 = new VarInfo();
            v4.DefaultValue = 11;
            v4.Description = "Temperature of bottom of soil profile";
            v4.Id = 0;
            v4.MaxValue = 50;
            v4.MinValue = -50;
            v4.Name = "BottomTemperature";
            v4.Size = 1;
            v4.Units = "°C";
            v4.URL = "";
            v4.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v4.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v4);
            VarInfo v5 = new VarInfo();
            v5.DefaultValue = 6;
            v5.Description = "Depth of constant soil temperature";
            v5.Id = 0;
            v5.MaxValue = 10;
            v5.MinValue = 4;
            v5.Name = "DepthConstantSoilTemperature";
            v5.Size = 1;
            v5.Units = "m";
            v5.URL = "";
            v5.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v5.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v5);
            mo0_0.Parameters = _parameters0_0;
            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(UNIMI.SoilT.Interfaces.Exogenous);
            pd1.PropertyName = "LatentHeatFlux";
            pd1.PropertyType = ((UNIMI.SoilT.Interfaces.ExogenousVarInfo.LatentHeatFlux)).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo = (UNIMI.SoilT.Interfaces.ExogenousVarInfo.LatentHeatFlux);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(UNIMI.SoilT.Interfaces.Auxiliary);
            pd2.PropertyName = "SurfaceTemperatureMaximum";
            pd2.PropertyType = ((UNIMI.SoilT.Interfaces.AuxiliaryVarInfo.SurfaceTemperatureMaximum)).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo = (UNIMI.SoilT.Interfaces.AuxiliaryVarInfo.SurfaceTemperatureMaximum);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            pd3.PropertyName = "SurfaceSoilTemperature";
            pd3.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.SurfaceSoilTemperature)).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.SurfaceSoilTemperature);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            pd4.PropertyName = "BulkDensity";
            pd4.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.BulkDensity)).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.BulkDensity);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            pd5.PropertyName = "Clay";
            pd5.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.Clay)).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.Clay);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            pd6.PropertyName = "HeatCapacity";
            pd6.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.HeatCapacity)).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.HeatCapacity);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            pd7.PropertyName = "LayerThickness";
            pd7.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness)).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            pd8.PropertyName = "SoilTemperatureByLayers";
            pd8.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureByLayers)).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureByLayers);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            pd9.PropertyName = "TemperatureConductance";
            pd9.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.TemperatureConductance)).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.TemperatureConductance);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            pd10.PropertyName = "VolumetricWaterContent";
            pd10.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.VolumetricWaterContent)).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.VolumetricWaterContent);
            _inputs0_0.Add(pd10);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(UNIMI.SoilT.Interfaces.Rates);
            pd12.PropertyName = "SoilTemperatureByLayersChange";
            pd12.PropertyType = ((UNIMI.SoilT.Interfaces.RatesVarInfo.SoilTemperatureByLayersChange)).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo = (UNIMI.SoilT.Interfaces.RatesVarInfo.SoilTemperatureByLayersChange);
            _inputs0_0.Add(pd12);
            mo0_0.Inputs = _inputs0_0;
            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            pd11.PropertyName = "VolumetricWaterContent";
            pd11.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.VolumetricWaterContent)).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.VolumetricWaterContent);
            _outputs0_0.Add(pd11);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(UNIMI.SoilT.Interfaces.Rates);
            pd14.PropertyName = "SoilTemperatureByLayersChange";
            pd14.PropertyType = ((UNIMI.SoilT.Interfaces.RatesVarInfo.SoilTemperatureByLayersChange)).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo = (UNIMI.SoilT.Interfaces.RatesVarInfo.SoilTemperatureByLayersChange);
            _outputs0_0.Add(pd14);
            mo0_0.Outputs = _outputs0_0;
            //Associated strategies
            List<string> lAssStrat0_0 = new List<string>();
            mo0_0.AssociatedStrategies = lAssStrat0_0;
            //Adding the modeling options to the modeling options manager
            _modellingOptionsManager = new ModellingOptionsManager(mo0_0);

            SetStaticParametersVarInfoDefinitions();
            SetPublisherData();

        }

        #endregion

        #region Implementation of IAnnotatable

        /// <summary>
        /// Description of the model
        /// </summary>
        public string Description
        {
            get { return "Campbel strategy - strategy. References: Soil physics with basic Gaylon S. Campbell Elsevier 1985."; }
        }

        /// <summary>
        /// URL to access the description of the model
        /// </summary>
        public string URL
        {
            get { return "http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl"; }
        }


        #endregion

        #region Implementation of IStrategy

        /// <summary>
        /// Domain of the model.
        /// </summary>
        public string Domain
        {
            get { return "Soil"; }
        }

        /// <summary>
        /// Type of the model.
        /// </summary>
        public string ModelType
        {
            get { return "Soil"; }
        }

        /// <summary>
        /// Declare if the strategy is a ContextStrategy, that is, it contains logic to select a strategy at run time. 
        /// </summary>
        public bool IsContext
        {
            get { return false; }
        }

        /// <summary>
        /// Timestep to be used with this strategy
        /// </summary>
        public IList<int> TimeStep
        {
            get
            {
                IList<int> ts = new List<int>();

                return ts;
            }
        }


        #region Publisher Data

        private PublisherData _pd;
        private void SetPublisherData()
        {
            // Set publishers' data

            _pd = new CRA.ModelLayer.MetadataTypes.PublisherData();
            _pd.Add("Creator", "simone.bregaglio@unimi.it");
            _pd.Add("Date", "12/1/2012");
            _pd.Add("Publisher", "University Of Milan");
        }

        public PublisherData PublisherData
        {
            get { return _pd; }
        }

        #endregion

        #region ModellingOptionsManager

        private ModellingOptionsManager _modellingOptionsManager;

        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; }
        }

        #endregion

        /// <summary>
        /// Return the types of the domain classes used by the strategy
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() { typeof(UNIMI.SoilT.Interfaces.Rates), typeof(UNIMI.SoilT.Interfaces.States), typeof(UNIMI.SoilT.Interfaces.Auxiliary), typeof(UNIMI.SoilT.Interfaces.States), typeof(UNIMI.SoilT.Interfaces.Exogenous), typeof(UNIMI.SoilT.Interfaces.StatesExternal), typeof(CRA.AgroManagement.ActEvents) };
        }

        #endregion

        #region Instances of the parameters

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.


        public System.Double ThermalK
        {
            get
            {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("ThermalK");
                if (vi != null) return (System.Double)vi.CurrentValue;
                else throw new Exception("Parameter 'ThermalK' not found in strategy 'SoilTemperatureCampbell'");
            }
            set
            {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("ThermalK");
                if (vi != null) vi.CurrentValue = value;
                else throw new Exception("Parameter 'ThermalK' not found in strategy 'SoilTemperatureCampbell'");
            }
        }
        public System.Double ETA
        {
            get
            {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("ETA");
                if (vi != null) return (System.Double)vi.CurrentValue;
                else throw new Exception("Parameter 'ETA' not found in strategy 'SoilTemperatureCampbell'");
            }
            set
            {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("ETA");
                if (vi != null) vi.CurrentValue = value;
                else throw new Exception("Parameter 'ETA' not found in strategy 'SoilTemperatureCampbell'");
            }
        }
        public System.Double Timestep
        {
            get
            {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("Timestep");
                if (vi != null) return (System.Double)vi.CurrentValue;
                else throw new Exception("Parameter 'Timestep' not found in strategy 'SoilTemperatureCampbell'");
            }
            set
            {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("Timestep");
                if (vi != null) vi.CurrentValue = value;
                else throw new Exception("Parameter 'Timestep' not found in strategy 'SoilTemperatureCampbell'");
            }
        }
        public System.Double BottomTemperature
        {
            get
            {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("BottomTemperature");
                if (vi != null) return (System.Double)vi.CurrentValue;
                else throw new Exception("Parameter 'BottomTemperature' not found in strategy 'SoilTemperatureCampbell'");
            }
            set
            {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("BottomTemperature");
                if (vi != null) vi.CurrentValue = value;
                else throw new Exception("Parameter 'BottomTemperature' not found in strategy 'SoilTemperatureCampbell'");
            }
        }
        public System.Double DepthConstantSoilTemperature
        {
            get
            {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("DepthConstantSoilTemperature");
                if (vi != null) return (System.Double)vi.CurrentValue;
                else throw new Exception("Parameter 'DepthConstantSoilTemperature' not found in strategy 'SoilTemperatureCampbell'");
            }
            set
            {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("DepthConstantSoilTemperature");
                if (vi != null) vi.CurrentValue = value;
                else throw new Exception("Parameter 'DepthConstantSoilTemperature' not found in strategy 'SoilTemperatureCampbell'");
            }
        }

        // Getter and setters for the value of the parameters of a composite strategy


        #endregion


        #region Parameters initialization method

        /// <summary>
        /// Set parameter(s) current values to the default value
        /// </summary>
        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();


            //GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section5
            //Code written below will not be overwritten by a future code generation

            //Custom initialization of the parameter. E.g. initialization of the array dimensions of array parameters

            //End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
            //PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section5 
        }

        #endregion

        #region Static parameters VarInfo definition

        // Define the properties of the static VarInfo of the parameters
        private static void SetStaticParametersVarInfoDefinitions()
        {
            ThermalKVarInfo.Name = "ThermalK";
            ThermalKVarInfo.Description = " Thermal conductance between soil and atmosphere";
            ThermalKVarInfo.MaxValue = 100;
            ThermalKVarInfo.MinValue = 0;
            ThermalKVarInfo.DefaultValue = 20;
            ThermalKVarInfo.Units = "W/m2 °C";
            ThermalKVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

            ETAVarInfo.Name = "ETA";
            ETAVarInfo.Description = " Weighting factor of time";
            ETAVarInfo.MaxValue = 1;
            ETAVarInfo.MinValue = 0;
            ETAVarInfo.DefaultValue = 0.6;
            ETAVarInfo.Units = "dimensionless";
            ETAVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

            TimestepVarInfo.Name = "Timestep";
            TimestepVarInfo.Description = " Timestep in sec";
            TimestepVarInfo.MaxValue = 86400;
            TimestepVarInfo.MinValue = 1;
            TimestepVarInfo.DefaultValue = 3600;
            TimestepVarInfo.Units = "dimensionless";
            TimestepVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

            BottomTemperatureVarInfo.Name = "BottomTemperature";
            BottomTemperatureVarInfo.Description = " Temperature of bottom of soil profile";
            BottomTemperatureVarInfo.MaxValue = 50;
            BottomTemperatureVarInfo.MinValue = -50;
            BottomTemperatureVarInfo.DefaultValue = 11;
            BottomTemperatureVarInfo.Units = "°C";
            BottomTemperatureVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

            DepthConstantSoilTemperatureVarInfo.Name = "DepthConstantSoilTemperature";
            DepthConstantSoilTemperatureVarInfo.Description = " Depth of constant soil temperature";
            DepthConstantSoilTemperatureVarInfo.MaxValue = 10;
            DepthConstantSoilTemperatureVarInfo.MinValue = 4;
            DepthConstantSoilTemperatureVarInfo.DefaultValue = 6;
            DepthConstantSoilTemperatureVarInfo.Units = "m";
            DepthConstantSoilTemperatureVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");



        }

        //Parameters static VarInfo list 

        private static VarInfo _ThermalKVarInfo = new VarInfo();
        /// <summary> 
        ///ThermalK VarInfo definition
        /// </summary>
        public static VarInfo ThermalKVarInfo
        {
            get { return _ThermalKVarInfo; }
        }
        private static VarInfo _ETAVarInfo = new VarInfo();
        /// <summary> 
        ///ETA VarInfo definition
        /// </summary>
        public static VarInfo ETAVarInfo
        {
            get { return _ETAVarInfo; }
        }
        private static VarInfo _TimestepVarInfo = new VarInfo();
        /// <summary> 
        ///Timestep VarInfo definition
        /// </summary>
        public static VarInfo TimestepVarInfo
        {
            get { return _TimestepVarInfo; }
        }
        private static VarInfo _BottomTemperatureVarInfo = new VarInfo();
        /// <summary> 
        ///BottomTemperature VarInfo definition
        /// </summary>
        public static VarInfo BottomTemperatureVarInfo
        {
            get { return _BottomTemperatureVarInfo; }
        }
        private static VarInfo _DepthConstantSoilTemperatureVarInfo = new VarInfo();
        /// <summary> 
        ///DepthConstantSoilTemperature VarInfo definition
        /// </summary>
        public static VarInfo DepthConstantSoilTemperatureVarInfo
        {
            get { return _DepthConstantSoilTemperatureVarInfo; }
        }

        //Parameters static VarInfo list of the composite class


        #endregion

        #region pre/post conditions management

        /// <summary>
        /// Test to verify the postconditions
        /// </summary>
        public string TestPostConditions(UNIMI.SoilT.Interfaces.Rates rates, UNIMI.SoilT.Interfaces.States states, UNIMI.SoilT.Interfaces.Auxiliary auxiliary, UNIMI.SoilT.Interfaces.States states1, UNIMI.SoilT.Interfaces.Exogenous exogenous, UNIMI.SoilT.Interfaces.StatesExternal statesexternal, string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes				


                //Create the collection of the conditions to test
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions();

                int numberOfLayer = states.SoilTemperatureMinimum.Length;

                for (int i = 0; i < numberOfLayer; i++)
                {
                    UNIMI.SoilT.Interfaces.StatesVarInfo.HeatCapacity.CurrentValue = states1.HeatCapacity;
                    UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureByLayers.CurrentValue = states1.SoilTemperatureByLayers;
                    UNIMI.SoilT.Interfaces.StatesVarInfo.TemperatureConductance.CurrentValue = states1.TemperatureConductance;
                    RangeBasedCondition r3 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.HeatCapacity);
                    if (r3.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.HeatCapacity.ValueType)) { prc.AddCondition(r3); }
                    RangeBasedCondition r4 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureByLayers);
                    if (r4.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureByLayers.ValueType)) { prc.AddCondition(r4); }
                    RangeBasedCondition r5 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.TemperatureConductance);
                    if (r5.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.TemperatureConductance.ValueType)) { prc.AddCondition(r5); }
                }


                //GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section4
                //Code written below will not be overwritten by a future code generation



                //End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
                //PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section4 

                //Get the evaluation of postconditions
                string postConditionsResult = pre.VerifyPostconditions(prc, callID);
                //if we have errors, send it to the configured output 
                if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in component UNIMI.SoilT.Strategies.Soil, strategy " + this.GetType().Name); }
                return postConditionsResult;
            }
            catch (Exception exception)
            {
                //Uncomment the next line to use the trace
                //TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1001,	"Strategy: " + this.GetType().Name + " - Unhandled exception running post-conditions");

                string msg = "Component UNIMI.SoilT.Strategies.Soil, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        /// <summary>
        /// Test to verify the preconditions
        /// </summary>
        public string TestPreConditions(UNIMI.SoilT.Interfaces.Rates rates, UNIMI.SoilT.Interfaces.States states, UNIMI.SoilT.Interfaces.Auxiliary auxiliary, UNIMI.SoilT.Interfaces.States states1, UNIMI.SoilT.Interfaces.Exogenous exogenous, UNIMI.SoilT.Interfaces.StatesExternal statesexternal, string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the input properties of the domain classes				

                UNIMI.SoilT.Interfaces.ExogenousVarInfo.LatentHeatFlux.CurrentValue = exogenous.LatentHeatFlux;
                UNIMI.SoilT.Interfaces.AuxiliaryVarInfo.SurfaceTemperatureMaximum.CurrentValue = auxiliary.SurfaceTemperatureMaximum;
                UNIMI.SoilT.Interfaces.StatesVarInfo.SurfaceSoilTemperature.CurrentValue = states.SurfaceSoilTemperature;

                //Create the collection of the conditions to test
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions();

                int numberOfLayer = states.SoilTemperatureMinimum.Length;

                for (int i = 0; i < numberOfLayer; i++)
                {
                    UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness.CurrentValue = states.LayerThickness;
                    UNIMI.SoilT.Interfaces.StatesVarInfo.ThermalDiffusivity.CurrentValue = states.ThermalDiffusivity;
                    UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness.CurrentValue = states.LayerThickness;
                    UNIMI.SoilT.Interfaces.StatesVarInfo.ThermalDiffusivity.CurrentValue = states.ThermalDiffusivity;
                    UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness.CurrentValue = states.LayerThickness;
                    UNIMI.SoilT.Interfaces.StatesVarInfo.ThermalDiffusivity.CurrentValue = states.ThermalDiffusivity;
                    UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness.CurrentValue = states.LayerThickness;
                    RangeBasedCondition r1 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness);
                    if (r1.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness.ValueType)) { prc.AddCondition(r1); }
                    RangeBasedCondition r2 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.ThermalDiffusivity);
                    if (r2.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.ThermalDiffusivity.ValueType)) { prc.AddCondition(r2); }
                    RangeBasedCondition r13 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness);
                    if (r13.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness.ValueType)) { prc.AddCondition(r13); }
                    RangeBasedCondition r6 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.ThermalDiffusivity);
                    if (r6.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.ThermalDiffusivity.ValueType)) { prc.AddCondition(r6); }
                    RangeBasedCondition r7 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness);
                    if (r7.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness.ValueType)) { prc.AddCondition(r7); }
                    RangeBasedCondition r8 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.ThermalDiffusivity);
                    if (r8.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.ThermalDiffusivity.ValueType)) { prc.AddCondition(r8); }
                    RangeBasedCondition r9 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness);
                    if (r9.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness.ValueType)) { prc.AddCondition(r9); }
                }


                RangeBasedCondition r10 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.ExogenousVarInfo.LatentHeatFlux);
                if (r10.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.ExogenousVarInfo.LatentHeatFlux.ValueType)) { prc.AddCondition(r10); }
                RangeBasedCondition r11 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.AuxiliaryVarInfo.SurfaceTemperatureMaximum);
                if (r11.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.AuxiliaryVarInfo.SurfaceTemperatureMaximum.ValueType)) { prc.AddCondition(r11); }
                RangeBasedCondition r12 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.SurfaceSoilTemperature);
                if (r12.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.SurfaceSoilTemperature.ValueType)) { prc.AddCondition(r12); }
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("ThermalK")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("ETA")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("Timestep")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("BottomTemperature")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DepthConstantSoilTemperature")));



                //GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section3
                //Code written below will not be overwritten by a future code generation



                //End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
                //PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section3 

                //Get the evaluation of preconditions;					
                string preConditionsResult = pre.VerifyPreconditions(prc, callID);
                //if we have errors, send it to the configured output 
                if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component UNIMI.SoilT.Strategies.Soil, strategy " + this.GetType().Name); }
                return preConditionsResult;
            }
            catch (Exception exception)
            {
                //Uncomment the next line to use the trace
                //	TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1002,"Strategy: " + this.GetType().Name + " - Unhandled exception running pre-conditions");

                string msg = "Component UNIMI.SoilT.Strategies.Soil, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }


        #endregion



        #region Model

        /// <summary>
        /// Run the strategy to calculate the outputs. In case of error during the execution, the preconditions tests are executed.
        /// </summary>
        public void Estimate(UNIMI.SoilT.Interfaces.Rates rates, UNIMI.SoilT.Interfaces.States states, UNIMI.SoilT.Interfaces.Auxiliary auxiliary, UNIMI.SoilT.Interfaces.States states1, UNIMI.SoilT.Interfaces.Exogenous exogenous, UNIMI.SoilT.Interfaces.StatesExternal statesexternal, CRA.AgroManagement.ActEvents actevents)
        {



            //GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section1
            //Code written below will not be overwritten by a future code generation

            //	ipotesi temperatura media del suolo= temperatura media dell'aria ta


            double netRadiation = 0;
            double LatentHeatFlux = 0;
            double ta;
            double Tmax;

            // ' boundary layer conductance in W/m^2 K 'questo è il valore più critico
            double[] k;
            double kzero;
            //	am= differenza fra temperature media e max(o min) del suolo(=aria) nella giornata 
            double am;
            int step;

            //		tb = 10  'temperatura alla boundary inferiore

            //    'clay fraction
            double[] mc;

            double[] c1;
            double[] c2;
            double[] c3;
            double[] c4;
            double bd;

            //			outputs
            double flusso;
            double[] tn;
            double[] T;


            //			variabili matrice
            double[] a;
            double[] b;
            double[] c;
            double[] d;

            //'f moltiplica la variabile al tempo t+1 mentre g al tempo t
            //			per f=0.5 abbiamo lo schema di 2CRAnk-Nicholson
            //			per f=0 sovrastima il flusso
            //			per f=1 instabilità facile
            //			condizione di stabilità: deltat<capacità termica*deltaz^2/(2*lambda)

            double g;

            int lSize = states.LayerThickness.Length;
            double depthProfile = 0;
            int stratiAgg = 0;
            double[] layTbefore = new double[lSize];

            for (int i = 0; i < lSize; i++)
            {
                //depthProfile += oS.Layers[i].LayerThickness;
                depthProfile += states.LayerThickness[i];
            }

            while (depthProfile < DepthConstantSoilTemperature)
            {

                stratiAgg = stratiAgg + 1;
                depthProfile += 1;

            }

            //LayerStates[] lay = new LayerStates[stratiAgg];
            double[] layBulkDensity = new double[stratiAgg];
            double[] layClay = new double[stratiAgg];
            double[] layLayerThickness = new double[stratiAgg];
            double[] layVolumetricWaterContent = new double[stratiAgg];
            double[] layTemperatureConductance = new double[stratiAgg];
            double[] layHeatCapacity = new double[stratiAgg];
            double[] laySoilTemperatureByLayers = new double[stratiAgg];

            for (int i = 0; i < lSize; i++)
            {
                layTbefore[i] = states.SoilTemperatureByLayers[i];
            }

            for (int i = 0; i < stratiAgg; i++)
            {
                //lay[i] = new LayerStates();
                //layVolumetricWaterContent[i] = oS.Layers[lSize - 1].VolumetricWaterContent;
                layVolumetricWaterContent[i] = states.VolumetricWaterContent[lSize - 1];
                //layClay[i] = oS.Layers[lSize - 1].Clay / 100;
                layClay[i] = states.Clay[lSize - 1] / 100;
                //layBulkDensity[i] = oS.Layers[lSize - 1].BulkDensity;
                layBulkDensity[i] = states.BulkDensity[lSize - 1];
                layTemperatureConductance[i] = states.TemperatureConductance[lSize - 1];
                layHeatCapacity[i] = states.HeatCapacity[lSize - 1] / 1000;
                laySoilTemperatureByLayers[i] = states.SoilTemperatureByLayers[lSize - 1];

                layLayerThickness[i] = 1;
            }

            //		inizializzazione
            mc = new double[lSize + stratiAgg];
            c1 = new double[lSize + stratiAgg];
            c2 = new double[lSize + stratiAgg];
            c3 = new double[lSize + stratiAgg];
            c4 = new double[lSize + stratiAgg];
            a = new double[lSize + 1 + stratiAgg];
            b = new double[lSize + 1 + stratiAgg];
            c = new double[lSize + 1 + stratiAgg];
            d = new double[lSize + 1 + stratiAgg];
            k = new double[lSize + 1 + stratiAgg];
            tn = new double[lSize + 1 + stratiAgg];
            T = new double[lSize + 1 + stratiAgg];
            double tnzero;
            double Tzero;


            kzero = ThermalK;
            g = 1 - ETA;
            //Tmax = ex.AirTemperatureMaximum;
            //ta = (ex.AirTemperatureMaximum + ex.AirTemperatureMinimum) / 2;

            //Changed to maximum and minimum surface soil temperature
            Tmax = auxiliary.SurfaceTemperatureMaximum;
            ta = states.SurfaceSoilTemperature;

            netRadiation = exogenous.NetRadiation;
            LatentHeatFlux = exogenous.LatentHeatFlux;

            am = Tmax - ta;

            tn[lSize + stratiAgg] = BottomTemperature;

            for (int i = 0; i < lSize; i++)
            {
                T[i] = states.SoilTemperatureByLayers[i];
                tn[i] = states.SoilTemperatureByLayers[i];
                states.SoilTemperatureByLayers[i] = 0;
            }


            for (int i = 0; i < stratiAgg; i++)
            {
                T[i + lSize] = laySoilTemperatureByLayers[i];
                tn[i + lSize] = laySoilTemperatureByLayers[i];
                laySoilTemperatureByLayers[i] = 0;
            }

            Tzero = states.SoilTemperatureByLayers[0];
            tnzero = states.SoilTemperatureByLayers[0];




            for (int i = 0; i < lSize; i++)
            {
                //mc[i] = oS.Layers[i].Clay / 100;
                mc[i] = states.Clay[i] / 100;
                //bd = oS.Layers[i].BulkDensity;
                bd = states.BulkDensity[i];
                //		'stima i parametri per il calcolo di capacità termica e conduttanza
                //		vedi schema matriciale pag 30
                //				A=c1
                c1[i] = 0.65 - 0.78 * bd + 0.6 * bd * bd;
                //				B=c2*SWC
                c2[i] = 1.06 * bd;
                //				C=c3
                c3[i] = 1 + 2.6 / Math.Sqrt(mc[i]);
                //				D=c4
                c4[i] = 0.3 + 0.1 * bd * bd;

            }
            for (int i = 0; i < stratiAgg; i++)
            {
                mc[i] = layClay[i] / 100;
                bd = layBulkDensity[i];
                //		'stima i parametri per il calcolo di capacità termica e conduttanza
                //		vedi schema matriciale pag 30
                //				A=c1
                c1[i + lSize] = 0.65 - 0.78 * bd + 0.6 * bd * bd;
                //				B=c2*SWC
                c2[i + lSize] = 1.06 * bd;
                //				C=c3
                c3[i + lSize] = 1 + 2.6 / Math.Sqrt(mc[i + lSize]);
                //				D=c4
                c4[i + lSize] = 0.3 + 0.1 * bd * bd;

            }


            step = 86400 / (int)Timestep;


            //cyml double[,] tmp = new double[lSize + stratiAgg, step];
            //cymldouble[,] StepSoilTemperatureByLayers = new double[stratiAgg, step];


            //cymlfor (int i = 0; i < lSize; i++)
            //cyml{
                //cymlStepSoilTemperatureByLayers = tmp;
            //cyml}

            //	fine inizializzazione


            for (int i = 0; i < lSize; i++)
            {


                if (i > 0)
                {
                    //layers[i].HeatCapacity = ((2400000 * oS.Layers[i].BulkDensity / 2.65) +
                    //    (4180000 * oS.Layers[i].VolumetricWaterContent))
                    //    * ((oS.Layers[i - 1].LayerThickness + oS.Layers[i].LayerThickness) / (2 * Timestep));
                    states.HeatCapacity[i] = ((2400000 * states.BulkDensity[i] / 2.65) +
                        (4180000 * states.VolumetricWaterContent[i]))
                        * ((states.LayerThickness[i - 1] + states.LayerThickness[i]) / (2 * Timestep));
                }
                else
                {
                    //layers[i].HeatCapacity = ((2400000 * oS.Layers[i].BulkDensity / 2.65) +
                    //    (4180000 * oS.Layers[i].VolumetricWaterContent))
                    //    * ((oS.Layers[i].LayerThickness) / (2 * Timestep));
                    states.HeatCapacity[i] = ((2400000 * states.BulkDensity[i] / 2.65) +
                        (4180000 * states.VolumetricWaterContent[i]))
                        * ((states.LayerThickness[i]) / (2 * Timestep));
                }

                //layers[i].TemperatureConductance = (c1[i] + c2[i] * oS.Layers[i].VolumetricWaterContent -
                //    (c1[i] - c4[i]) * Math.Exp(-Math.Pow((c3[i] * oS.Layers[i].VolumetricWaterContent), 4)))
                //    / (oS.Layers[i].LayerThickness);
                states.TemperatureConductance[i] = (c1[i] + c2[i] * states.VolumetricWaterContent[i] -
                    (c1[i] - c4[i]) * Math.Exp(-Math.Pow((c3[i] * states.VolumetricWaterContent[i]), 4)))
                    / (states.LayerThickness[i]);

                k[i] = states.TemperatureConductance[i];

            }

            for (int i = 0; i < stratiAgg; i++)
            {


                if (i > 0)
                {
                    layHeatCapacity[i] = ((2400000 * layBulkDensity[i] / 2.65) +
                        (4180000 * layVolumetricWaterContent[i]))
                        * ((layLayerThickness[i - 1] + layLayerThickness[i]) / (2 * Timestep));
                }
                else
                {
                    //lay[i].HeatCapacity = ((2400000 * layBulkDensity[i] / 2.65) +
                    //    (4180000 * layVolumetricWaterContent[i]))
                    //    * ((oS.Layers[lSize - 1].LayerThickness) / (2 * Timestep));
                    layHeatCapacity[i] = ((2400000 * layBulkDensity[i] / 2.65) +
                        (4180000 * layVolumetricWaterContent[i]))
                        * ((states.LayerThickness[lSize - 1]) / (2 * Timestep));
                }

                layTemperatureConductance[i] = (c1[i + lSize] + c2[i + lSize] * layVolumetricWaterContent[i] -
                    (c1[i + lSize] - c4[i + lSize]) * Math.Exp(-Math.Pow((c3[i + lSize] * layVolumetricWaterContent[i]), 4)))
                    / (layLayerThickness[i]);

                k[i + lSize] = layTemperatureConductance[i];

            }

            for (long h = 0; h < step; h++)
            {
                tnzero = ta + am * Math.Sin(0.261799 * ((h * Timestep / 3600) - (6 * 3600 / Timestep)));

                for (int i = 0; i < lSize; i++)
                {
                    //		calcola i valori degli elementi di matrice


                    c[i] = -k[i] * ETA;
                    a[i + 1] = c[i];
                    if (i > 0)
                    {
                        b[i] = ETA * (k[i] + k[i - 1]) + states.HeatCapacity[i];

                        d[i] = g * k[i - 1] * T[i - 1]
                            + (states.HeatCapacity[i] - g * (k[i] + k[i - 1])) * T[i]
                            + g * k[i] * T[i + 1];

                    }
                    else
                    {
                        b[i] = ETA * (k[i] + kzero) + states.HeatCapacity[i];


                        d[i] = g * kzero * Tzero
                            + (states.HeatCapacity[i] - g * (k[i] + kzero)) * T[i]
                            + g * k[i] * T[i + 1];
                    }


                }
                for (int i = lSize; i < lSize + stratiAgg; i++)
                {
                    //		calcola i valori degli elementi di matrice


                    c[i] = -k[i] * ETA;
                    a[i + 1] = c[i];

                    b[i] = ETA * (k[i] + k[i - 1]) + layHeatCapacity[i - lSize];

                    d[i] = g * k[i - 1] * T[i - 1]
                        + (layHeatCapacity[i - lSize] - g * (k[i] + k[i - 1])) * T[i]
                        + g * k[i] * T[i + 1];

                }

                d[0] = d[0] + kzero * tnzero * ETA - netRadiation + LatentHeatFlux;
                d[lSize - 1 + stratiAgg] = d[stratiAgg + lSize - 1] + k[stratiAgg + lSize - 1] * ETA * tn[stratiAgg + lSize];

                //		'risolve la matrice tridiagonale col metodo di Thomas
                for (int i = 0; i < lSize - 1 + stratiAgg; i++)
                {
                    c[i] = c[i] / b[i];
                    d[i] = d[i] / b[i];
                    b[i + 1] = b[i + 1] - (a[i + 1] * c[i]);
                    d[i + 1] = d[i + 1] - (a[i + 1] * d[i]);
                }

                tn[lSize - 1 + stratiAgg] = d[lSize - 1 + stratiAgg] / b[lSize - 1 + stratiAgg];

                for (int i = lSize - 2 + stratiAgg; i > -1; i--)
                {
                    tn[i] = d[i] - c[i] * tn[i + 1];
                }

                //			W/m2
                flusso = kzero * (g * (Tzero - T[0]) + ETA * (tnzero - tn[0]));

                for (int i = lSize - 1; i > -1; i--)
                {
                    //cymlStepSoilTemperatureByLayers[i, h] = tn[i];
                    T[i] = tn[i];
                    states.SoilTemperatureByLayers[i] = states.SoilTemperatureByLayers[i] + tn[i];

                }
                for (int i = stratiAgg - 1; i > -1; i--)
                {
                    //cymlStepSoilTemperatureByLayers[i, h] = tn[i + lSize];
                    T[i + lSize] = tn[i + lSize];
                    laySoilTemperatureByLayers[i] = laySoilTemperatureByLayers[i] + tn[i + lSize];

                }
                T[lSize + stratiAgg] = tn[lSize + stratiAgg];
                Tzero = tnzero;

            }

            for (int i = 0; i < lSize; i++)
            {
                states.SoilTemperatureByLayers[i] = states.SoilTemperatureByLayers[i] / step;
                rates.SoilTemperatureByLayersChange[i] = states.SoilTemperatureByLayers[i] - layTbefore[i];
            }


            //End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
            //PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section1 
        }

        #endregion


        //GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section2
        //Code written below will not be overwritten by a future code generation

       

        #region - Bibliography -
        //riferimento bibliografico:"Soil physics with basic" Gaylon S. Campbell Elsevier 1985
        // conduttività termica lambda [W/m K]
        // flusso termico lungo z [W/m2]=-lambda(dT/dz)
        // equazione di continuità: C(dT/dt)=d(lambdadT/dz)/dz 
        //			dove C=capacità termica specifica del suolo [J/m3 k]

        // Ipotesi semplificativa: conduttività e capacità termiche costanti lungo z 
        //			allora dT/dt=Dd2T/dz2

        //				Al primo strato: D=D'+f*K*Tair-radiazione netta Rnet +latent heat flux LE

        #endregion

        //End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
        //PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section2 
    }
}
