

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
    ///Class HourlySoilTemperaturesPartonLogan
    /// Strategy for the calculation of hourly soil temperature. Reference: Parton, W.J.  and  Logan, J.A.,  1981. A model for diurnal variation  in soil  and  air temperature. Agric. Meteorol., 23: 205-216.
    /// </summary>
    public class HourlySoilTemperaturesPartonLogan : IStrategySoilT
    {

        #region Constructor

        public HourlySoilTemperaturesPartonLogan()
        {

            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            mo0_0.Parameters = _parameters0_0;
            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(UNIMI.SoilT.Interfaces.Exogenous);
            pd1.PropertyName = "HourOfSunrise";
            pd1.PropertyType = ((UNIMI.SoilT.Interfaces.ExogenousVarInfo.HourOfSunrise)).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo = (UNIMI.SoilT.Interfaces.ExogenousVarInfo.HourOfSunrise);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(UNIMI.SoilT.Interfaces.Exogenous);
            pd2.PropertyName = "DayLength";
            pd2.PropertyType = ((UNIMI.SoilT.Interfaces.ExogenousVarInfo.DayLength)).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo = (UNIMI.SoilT.Interfaces.ExogenousVarInfo.DayLength);
            _inputs0_0.Add(pd2);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            pd4.PropertyName = "SoilTemperatureMaximum";
            pd4.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMaximum)).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMaximum);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            pd5.PropertyName = "SoilTemperatureMinimum";
            pd5.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMinimum)).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMinimum);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(UNIMI.SoilT.Interfaces.Exogenous);
            pd6.PropertyName = "HourOfSunset";
            pd6.PropertyType = ((UNIMI.SoilT.Interfaces.ExogenousVarInfo.HourOfSunset)).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo = (UNIMI.SoilT.Interfaces.ExogenousVarInfo.HourOfSunset);
            _inputs0_0.Add(pd6);
            mo0_0.Inputs = _inputs0_0;
            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
            pd7.PropertyName = "SoilTemperatureByLayersHourly";
            pd7.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureByLayersHourly)).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureByLayersHourly);
            _outputs0_0.Add(pd7);
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
            get { return "Strategy for the calculation of hourly soil temperature. Reference: Parton, W.J.  and  Logan, J.A.,  1981. A model for diurnal variation  in soil  and  air temperature. Agric. Meteorol., 23: 205-216."; }
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

                int numberOfLayer = states.SoilTemperatureByLayersHourly.Length;

                for (int i = 0; i < numberOfLayer; i++)
                {
                    UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureByLayersHourly.CurrentValue = states.SoilTemperatureByLayersHourly;
                    RangeBasedCondition r6 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureByLayersHourly);
                    if (r6.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureByLayersHourly.ValueType)) { prc.AddCondition(r6); }
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

                UNIMI.SoilT.Interfaces.ExogenousVarInfo.HourOfSunrise.CurrentValue = exogenous.HourOfSunrise;
                UNIMI.SoilT.Interfaces.ExogenousVarInfo.DayLength.CurrentValue = exogenous.DayLength;
                UNIMI.SoilT.Interfaces.ExogenousVarInfo.HourOfSunset.CurrentValue = exogenous.HourOfSunset;

                //Create the collection of the conditions to test
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions();

                int numberOfLayer = states.SoilTemperatureMaximum.Length;

                for (int i = 0; i < numberOfLayer; i++)
                {
                    UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMaximum.CurrentValue = states.SoilTemperatureMaximum;
                    UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMinimum.CurrentValue = states.SoilTemperatureMinimum;
                    RangeBasedCondition r4 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMaximum);
                    if (r4.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMaximum.ValueType)) { prc.AddCondition(r4); }
                    RangeBasedCondition r5 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMinimum);
                    if (r5.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.SoilTemperatureMinimum.ValueType)) { prc.AddCondition(r5); }
                }

                RangeBasedCondition r1 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.ExogenousVarInfo.HourOfSunrise);
                if (r1.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.ExogenousVarInfo.HourOfSunrise.ValueType)) { prc.AddCondition(r1); }
                RangeBasedCondition r2 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.ExogenousVarInfo.DayLength);
                if (r2.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.ExogenousVarInfo.DayLength.ValueType)) { prc.AddCondition(r2); }
                RangeBasedCondition r3 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.ExogenousVarInfo.HourOfSunset);
                if (r3.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.ExogenousVarInfo.HourOfSunset.ValueType)) { prc.AddCondition(r3); }



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


            //foreach (LayerStates layer in states.Layers)
            for (int i = 0; i < states.SoilTemperatureMinimum.Length; i++)
            {
                for (int h = 0; h < 24; h++)
                {
                    if (h >= exogenous.HourOfSunrise && h <= exogenous.HourOfSunset)
                    {
                        //layer.SoilTemperatureByLayersHourly[h] = layer.SoilTemperatureMinimum +
                        //                                         (layer.SoilTemperatureMaximum -
                        //                                          layer.SoilTemperatureMinimum) *
                        //                                         Math.Sin((Math.PI * (h - 12 + (exogenous.DayLength / 2))) /
                        //                                                  (exogenous.DayLength + 2 * 1.8));
                        states.SoilTemperatureByLayersHourly[i * 24 + h] = states.SoilTemperatureMinimum[i] +
                                                                 (states.SoilTemperatureMaximum[i] -
                                                                  states.SoilTemperatureMinimum[i]) *
                                                                 Math.Sin((Math.PI * (h - 12 + (exogenous.DayLength / 2))) /
                                                                          (exogenous.DayLength + 2 * 1.8));
                    }
                }
                //double TemperatureAtSunset = layer.SoilTemperatureByLayersHourly[
                //    Convert.ToInt32(Math.Truncate(exogenous.HourOfSunset))];
                double TemperatureAtSunset = states.SoilTemperatureByLayersHourly[i + (int)exogenous.HourOfSunset];
                for (int h = 0; h < 24; h++)
                {
                    if (h > exogenous.HourOfSunset)
                    {

                        //layer.SoilTemperatureByLayersHourly[h] = (layer.SoilTemperatureMinimum -
                        //                                          TemperatureAtSunset *
                        //                                              Math.Exp(-(24 - exogenous.DayLength) / 2.2) +
                        //                                             (TemperatureAtSunset - layer.SoilTemperatureMinimum)
                        //                                          * Math.Exp(-(h - exogenous.HourOfSunset) / 2.2)) /
                        //                                         (1 - Math.Exp(-(24 - exogenous.DayLength) / 2.2));
                        states.SoilTemperatureByLayersHourly[i + h] = (states.SoilTemperatureMinimum[i] -
                                                                  TemperatureAtSunset *
                                                                      Math.Exp(-(24 - exogenous.DayLength) / 2.2) +
                                                                     (TemperatureAtSunset - states.SoilTemperatureMinimum[i])
                                                                  * Math.Exp(-(h - exogenous.HourOfSunset) / 2.2)) /
                                                                 (1 - Math.Exp(-(24 - exogenous.DayLength) / 2.2));
                    }
                    else if (h <= exogenous.HourOfSunrise)
                    {
                        //layer.SoilTemperatureByLayersHourly[h] = (layer.SoilTemperatureMinimum -
                        //                                         TemperatureAtSunset *
                        //                                             Math.Exp(-(24 - exogenous.DayLength) / 2.2) +
                        //                                            (TemperatureAtSunset - layer.SoilTemperatureMinimum)
                        //                                         * Math.Exp(-(h + 24 - exogenous.HourOfSunset) / 2.2)) /
                        //                                        (1 - Math.Exp(-(24 - exogenous.DayLength) / 2.2));
                        states.SoilTemperatureByLayersHourly[i + h] = (states.SoilTemperatureMinimum[i] -
                                                                 TemperatureAtSunset *
                                                                     Math.Exp(-(24 - exogenous.DayLength) / 2.2) +
                                                                    (TemperatureAtSunset - states.SoilTemperatureMinimum[i])
                                                                 * Math.Exp(-(h + 24 - exogenous.HourOfSunset) / 2.2)) /
                                                                (1 - Math.Exp(-(24 - exogenous.DayLength) / 2.2));
                    }

                }
            }

            


            //End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
            //PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section1 
        }



        #endregion


        //GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section2
        //Code written below will not be overwritten by a future code generation

        //End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
        //PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section2 
    }
}
