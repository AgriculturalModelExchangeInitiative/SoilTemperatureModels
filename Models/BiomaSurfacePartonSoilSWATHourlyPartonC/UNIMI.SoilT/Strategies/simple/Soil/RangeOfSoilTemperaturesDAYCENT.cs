

//Author:Simone Bregaglio simone.bregaglio@unimi.it
//Institution:University Of Milan
//Author of revision:Nicolò Frasso nicolo.frasso@unimi.it
//Date first release:12/1/2012
//Date of revision:

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
    ///Class RangeOfSoilTemperaturesDAYCENT
    /// Strategy for the calculation of soil thermal conductivity.Reference: DAYCENT model written in C code 
    /// </summary>
    public class RangeOfSoilTemperaturesDAYCENT : IStrategySoilT
    {

        #region Constructor

        public RangeOfSoilTemperaturesDAYCENT()
        {

            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            mo0_0.Parameters = _parameters0_0;
            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            //cyml PropertyDescription pd1 = new PropertyDescription();
            //cyml pd1.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            //cyml pd1.PropertyName = "Layers";
            //cyml pd1.PropertyType = typeof(List<UNIMI.SoilT.Interfaces.States>);
            //cyml pd1.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness);
            //cyml _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            pd2.PropertyName = "ThermalDiffusivity";
            pd2.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.ThermalDiffusivity)).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.ThermalDiffusivity);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(UNIMI.SoilT.Interfaces.AuxiliaryVarInfo);
            pd3.PropertyName = "SurfaceTemperatureMaximum";
            pd3.PropertyType = ((UNIMI.SoilT.Interfaces.AuxiliaryVarInfo.SurfaceTemperatureMaximum)).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo = (UNIMI.SoilT.Interfaces.AuxiliaryVarInfo.SurfaceTemperatureMaximum);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(UNIMI.SoilT.Interfaces.AuxiliaryVarInfo);
            pd4.PropertyName = "SurfaceTemperatureMinimum";
            pd4.PropertyType = ((UNIMI.SoilT.Interfaces.AuxiliaryVarInfo.SurfaceTemperatureMinimum)).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo = (UNIMI.SoilT.Interfaces.AuxiliaryVarInfo.SurfaceTemperatureMinimum);
            _inputs0_0.Add(pd4);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(UNIMI.SoilT.Interfaces.StatesVarInfo);
            pd8.PropertyName = "SoilTemperatureByLayers";
            pd8.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureByLayers)).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureByLayers);
            _inputs0_0.Add(pd8);
            
            mo0_0.Inputs = _inputs0_0;
            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            pd6.PropertyName = "SoilTemperatureRangeByLayers";
            pd6.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureRangeByLayers)).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureRangeByLayers);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            pd7.PropertyName = "SoilTemperatureMaximum";
            pd7.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMaximum)).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMaximum);
            _inputs0_0.Add(pd7);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            pd5.PropertyName = "SoilTemperatureMinimum";
            pd5.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMinimum)).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMinimum);
            _inputs0_0.Add(pd5);
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
            get { return "Strategy for the calculation of soil thermal conductivity.Reference: DAYCENT model written in C code "; }
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


        }

        //Parameters static VarInfo list 


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

                int numberOfLayer = states.SoilTemperatureByLayers.Length;

                for (int i = 0; i < numberOfLayer; i++)
                {
                    UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureRangeByLayers.CurrentValue = states.SoilTemperatureRangeByLayers;
                    UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMaximum.CurrentValue = states.SoilTemperatureMaximum;
                    UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMinimum.CurrentValue = states.SoilTemperatureMinimum;
                    RangeBasedCondition r3 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureRangeByLayers);
                    if (r3.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureRangeByLayers.ValueType)) { prc.AddCondition(r3); }
                    RangeBasedCondition r4 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMaximum);
                    if (r4.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMaximum.ValueType)) { prc.AddCondition(r4); }
                    RangeBasedCondition r5 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMinimum);
                    if (r5.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMinimum.ValueType)) { prc.AddCondition(r5); }
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

                UNIMI.SoilT.Interfaces.ExogenousVarInfo.HourOfSunset.CurrentValue = exogenous.HourOfSunset;

                //Create the collection of the conditions to test
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions();


                int numberOfLayer = states.SoilTemperatureByLayers.Length;

                for (int i = 0; i < numberOfLayer; i++)
                {
                    UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness.CurrentValue = states.LayerThickness;
                    UNIMI.SoilT.Interfaces.StatesVarInfo.ThermalDiffusivity.CurrentValue = states.ThermalDiffusivity;
                    RangeBasedCondition r1 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness);
                    if (r1.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.LayerThickness.ValueType)) { prc.AddCondition(r1); }
                    RangeBasedCondition r2 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.ThermalDiffusivity);
                    if (r2.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.ThermalDiffusivity.ValueType)) { prc.AddCondition(r2); }
                }



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

            double _DepthBottom = 0;
            double _DepthCenterLayer = 0;
            double SurfaceDiurnalRange = auxiliary.SurfaceTemperatureMaximum - auxiliary.SurfaceTemperatureMinimum;
            //two terms of the equation for range of soil temperature

          
            for (int i = 0; i < states.SoilTemperatureByLayers.Length; i++)
            {
                //The constant value of soil thermal diffusivity is used by DAYCENT model

                if (i == 0)
                {
                    //Conversion to cm
                    _DepthCenterLayer = states.LayerThickness[0] * 100 / 2;
                    states.SoilTemperatureRangeByLayers[0] =
                       SurfaceDiurnalRange * (Math.Exp(-_DepthCenterLayer * (Math.Pow(0.00005 / states.ThermalDiffusivity[0], 0.5))));
                    states.SoilTemperatureMaximum[0] = states.SoilTemperatureByLayers[0] +
                                                         (states.SoilTemperatureRangeByLayers[0] / 2);
                    states.SoilTemperatureMinimum[0] = states.SoilTemperatureByLayers[0] -
                                                         (states.SoilTemperatureRangeByLayers[0] / 2);

                }
                else
                {
                    //Conversion to cm
                    _DepthBottom = _DepthBottom + states.LayerThickness[i - 1] * 100;
                    _DepthCenterLayer = _DepthBottom + states.LayerThickness[i] * 100 / 2;
                    states.SoilTemperatureRangeByLayers[i] =
                      SurfaceDiurnalRange * (Math.Exp(-_DepthCenterLayer * (Math.Pow(0.00005 / states.ThermalDiffusivity[i], 0.5))));
                    states.SoilTemperatureMaximum[i] = states.SoilTemperatureByLayers[i] +
                                                         (states.SoilTemperatureRangeByLayers[i] / 2);
                    states.SoilTemperatureMinimum[i] = states.SoilTemperatureByLayers[i] -
                                                         (states.SoilTemperatureRangeByLayers[i] / 2);

                }

            }


            //End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
            //PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section1 
        }
    
		public void Init(UNIMI.SoilT.Interfaces.Rates rates,UNIMI.SoilT.Interfaces.States states,UNIMI.SoilT.Interfaces.Auxiliary auxiliary,UNIMI.SoilT.Interfaces.States states1,UNIMI.SoilT.Interfaces.Exogenous exogenous,UNIMI.SoilT.Interfaces.StatesExternal statesexternal,CRA.AgroManagement.ActEvents actevents)
		{

			states.SoilTemperatureRangeByLayers = new double[states.LayerThickness.Length];
            states.SoilTemperatureMaximum = new double[states.LayerThickness.Length];
            states.SoilTemperatureMinimum = new double[states.LayerThickness.Length];
        

		}



        #endregion


        //GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section2
        //Code written below will not be overwritten by a future code generation

        //End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
        //PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section2 
    }
}


//%%CyML Description Begin%%
/*

     - Name: RangeOfSoilTemperaturesDAYCENT -Version: 001, -Time step: 1
     - Description:
                 * Title: RangeOfSoilTemperaturesDAYCENT model
                 * Authors: simone.bregaglio@unimi.it
                 * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
                 * Institution: University Of Milan
                 * ExtendedDescription: Strategy for the calculation of soil thermal conductivity.Reference: DAYCENT model written in C code 
                 * ShortDescription: Strategy for the calculation of soil thermal conductivity
     - inputs:
                 * name: LayerThickness
                               ** description : Soil layer thickness
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 3
                               ** min : 0.005
                               ** default : 0.05
                               ** unit : m
                 * name: SurfaceTemperatureMinimum
                               ** description : Minimum surface soil temperature
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 60
                               ** min : -60
                               ** default : 10
                               ** unit : degC
                 * name: ThermalDiffusivity
                               ** description : Thermal diffusivity of soil layer
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 1
                               ** min : 0
                               ** default : 0.0025
                               ** unit : mm s-1
                 * name: SoilTemperatureByLayers
                               ** description : Soil temperature of each layer
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** default : 15
                               ** unit : degC
                 * name: SurfaceTemperatureMaximum
                               ** description : Maximum surface soil temperature
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** max : 60
                               ** min : -60
                               ** default : 25
                               ** unit : degC
                 * name: SoilTemperatureRangeByLayers
                               ** description : Soil temperature range by layers
                               ** inputtype : variable
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** default :
                               ** len : 
                               ** max : 50
                               ** min : 0
                               ** unit : degC
                 * name: SoilTemperatureMinimum
                               ** description : Minimum soil temperature by layers
                               ** inputtype : variable
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** default :
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** unit : degC
                 * name: SoilTemperatureMaximum
                               ** description : Maximum soil temperature by layers
                               ** inputtype : variable
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** default :
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** unit : degC
     - outputs:
                 * name: SoilTemperatureRangeByLayers
                               ** description : Soil temperature range by layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 50
                               ** min : 0
                               ** unit : degC
                 * name: SoilTemperatureMinimum
                               ** description : Minimum soil temperature by layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** unit : degC
                 * name: SoilTemperatureMaximum
                               ** description : Maximum soil temperature by layers
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 60
                               ** min : -60
                               ** unit : degC


*/
//%%CyML Description End%%