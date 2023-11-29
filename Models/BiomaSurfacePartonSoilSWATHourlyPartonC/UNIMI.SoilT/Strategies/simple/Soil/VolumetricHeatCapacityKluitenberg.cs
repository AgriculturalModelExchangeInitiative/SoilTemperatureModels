

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
    ///Class VolumetricHeatCapacityKluitenberg
    /// </summary>
    /// <summary>
    /// Strategy for the calculation of volumetric heat capacity.
    /// Kluitenberg, G.J., Heat capacity and specific heat, in Methods of Soil Analysis. Part 4. Physical 
    /// Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series 
    /// #5: Madison, Wisconsin. p. 1201-1208. 
    /// </summary>
    /// /// <author>
    /// Simone Bregaglio, simone.bregaglio@unimi.it, December 2012
    /// </author>
	public class VolumetricHeatCapacityKluitenberg : IStrategySoilT
	{

	#region Constructor

        public VolumetricHeatCapacityKluitenberg()
			{
				
				ModellingOptions mo0_0 = new ModellingOptions();
				//Parameters
				List<VarInfo> _parameters0_0 = new List<VarInfo>();
				mo0_0.Parameters=_parameters0_0;
				//Inputs
				List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd1 = new PropertyDescription();
				pd1.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
                pd1.PropertyName = "BulkDensity";
                pd1.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.BulkDensity)).ValueType.TypeForCurrentValue;
                pd1.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.BulkDensity);
				_inputs0_0.Add(pd1);
                PropertyDescription pd2 = new PropertyDescription();
                pd2.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
                pd2.PropertyName = "VolumetricWaterContent";
                pd2.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.VolumetricWaterContent)).ValueType.TypeForCurrentValue;
                pd2.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.VolumetricWaterContent);
                _inputs0_0.Add(pd2);
                PropertyDescription pd3 = new PropertyDescription();
                pd3.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
                pd3.PropertyName = "Sand";
                pd3.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.Sand)).ValueType.TypeForCurrentValue;
                pd3.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.Sand);
                _inputs0_0.Add(pd3);
                PropertyDescription pd4 = new PropertyDescription();
                pd4.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
                pd4.PropertyName = "Silt";
                pd4.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.Silt)).ValueType.TypeForCurrentValue;
                pd4.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.Silt);
                _inputs0_0.Add(pd4);
                PropertyDescription pd5 = new PropertyDescription();
                pd5.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
                pd5.PropertyName = "Clay";
                pd5.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.Clay)).ValueType.TypeForCurrentValue;
                pd5.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.Clay);
                _inputs0_0.Add(pd5);
                PropertyDescription pd6 = new PropertyDescription();
                pd6.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
                pd6.PropertyName = "OrganicMatter";
                pd6.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.OrganicMatter)).ValueType.TypeForCurrentValue;
                pd6.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.OrganicMatter);
                _inputs0_0.Add(pd6);
                mo0_0.Inputs=_inputs0_0;
				//Outputs
				List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
                PropertyDescription pd7 = new PropertyDescription();
                pd7.DomainClassType = typeof(UNIMI.SoilT.Interfaces.States);
                pd7.PropertyName = "HeatCapacity";
                pd7.PropertyType = ((UNIMI.SoilT.Interfaces.StatesVarInfo.HeatCapacity)).ValueType.TypeForCurrentValue;
                pd7.PropertyVarInfo = (UNIMI.SoilT.Interfaces.StatesVarInfo.HeatCapacity);
                _outputs0_0.Add(pd7);
				mo0_0.Outputs=_outputs0_0;
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
				get { return "Strategy for the calculation of soil thermal diffusivity. Reference: J.M.H.Hendrickx, H. Xie, B. Borchers, J.B.J. Harrison, 2008. Global Prediction of Thermal Soil Regimes. SPIE Proceedings Volume 6953 Detection and Sensing of Mines, Explosive Objects, and Obscured Targets XIII."; }
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
				get {  return "Soil"; }
			}

			/// <summary>
			/// Type of the model.
			/// </summary>
			public string ModelType
			{
				get { return "ThermalDiffusivity"; }
			}

			/// <summary>
			/// Declare if the strategy is a ContextStrategy, that is, it contains logic to select a strategy at run time. 
			/// </summary>
			public bool IsContext
			{
					get { return  false; }
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
			private  void SetPublisherData()
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
				return new List<Type>() {  typeof(UNIMI.SoilT.Interfaces.Rates),typeof(UNIMI.SoilT.Interfaces.States),typeof(UNIMI.SoilT.Interfaces.Auxiliary),typeof(UNIMI.SoilT.Interfaces.States),typeof(UNIMI.SoilT.Interfaces.Exogenous),typeof(UNIMI.SoilT.Interfaces.StatesExternal),typeof(CRA.AgroManagement.ActEvents) };
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
			public string TestPostConditions(UNIMI.SoilT.Interfaces.Rates rates,UNIMI.SoilT.Interfaces.States states,UNIMI.SoilT.Interfaces.Auxiliary auxiliary,UNIMI.SoilT.Interfaces.States states1,UNIMI.SoilT.Interfaces.Exogenous exogenous,UNIMI.SoilT.Interfaces.StatesExternal statesexternal, string callID)
			{
				try
				{
					//Set current values of the outputs to the static VarInfo representing the output properties of the domain classes				
					
					
					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();


                    int numberOfLayer = states.HeatCapacity.Length;

                    for (int i = 0; i < numberOfLayer; i++)
                    {
                        UNIMI.SoilT.Interfaces.StatesVarInfo.HeatCapacity.CurrentValue = states.HeatCapacity;
                        RangeBasedCondition r5 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.HeatCapacity);
                        if (r5.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.HeatCapacity.ValueType)) { prc.AddCondition(r5); }
                    }
					
                    
					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section4
					//Code written below will not be overwritten by a future code generation

        

					//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
					//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section4 

					//Get the evaluation of postconditions
					string postConditionsResult =pre.VerifyPostconditions(prc, callID);
					//if we have errors, send it to the configured output 
					if(!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in component UNIMI.SoilT.Strategies.Soil, strategy " + this.GetType().Name ); }
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
			public string TestPreConditions(UNIMI.SoilT.Interfaces.Rates rates,UNIMI.SoilT.Interfaces.States states,UNIMI.SoilT.Interfaces.Auxiliary auxiliary,UNIMI.SoilT.Interfaces.States states1,UNIMI.SoilT.Interfaces.Exogenous exogenous,UNIMI.SoilT.Interfaces.StatesExternal statesexternal, string callID)
			{
				try
				{
					//Set current values of the inputs to the static VarInfo representing the input properties of the domain classes				
					
					
					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();

                    int numberOfLayer = states.HeatCapacity.Length;

                    for (int i = 0; i < numberOfLayer; i++)
                    {
                        UNIMI.SoilT.Interfaces.StatesVarInfo.BulkDensity.CurrentValue = states.BulkDensity;
                        UNIMI.SoilT.Interfaces.StatesVarInfo.Sand.CurrentValue = states.Sand;
                        UNIMI.SoilT.Interfaces.StatesVarInfo.Clay.CurrentValue = states.Clay;
                        UNIMI.SoilT.Interfaces.StatesVarInfo.Silt.CurrentValue = states.Silt;
                        UNIMI.SoilT.Interfaces.StatesVarInfo.OrganicMatter.CurrentValue = states.OrganicMatter;
                        UNIMI.SoilT.Interfaces.StatesVarInfo.VolumetricWaterContent.CurrentValue = states.VolumetricWaterContent;
                        RangeBasedCondition r1 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.BulkDensity);
                        if (r1.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.BulkDensity.ValueType)) { prc.AddCondition(r1); }
                        RangeBasedCondition r2 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.Sand);
                        if (r2.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.Sand.ValueType)) { prc.AddCondition(r2); }
                        RangeBasedCondition r3 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.Clay);
                        if (r3.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.Clay.ValueType)) { prc.AddCondition(r3); }
                        RangeBasedCondition r4 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.Silt);
                        if (r4.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.Silt.ValueType)) { prc.AddCondition(r4); }
                        RangeBasedCondition r5 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.OrganicMatter);
                        if (r5.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.OrganicMatter.ValueType)) { prc.AddCondition(r5); }
                        RangeBasedCondition r6 = new RangeBasedCondition(UNIMI.SoilT.Interfaces.StatesVarInfo.VolumetricWaterContent);
                        if (r6.ApplicableVarInfoValueTypes.Contains(UNIMI.SoilT.Interfaces.StatesVarInfo.VolumetricWaterContent.ValueType)) { prc.AddCondition(r6); }
                    }

					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section3
					//Code written below will not be overwritten by a future code generation

        

					//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
					//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section3 
								
					//Get the evaluation of preconditions;					
					string preConditionsResult =pre.VerifyPreconditions(prc, callID);
					//if we have errors, send it to the configured output 
					if(!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component UNIMI.SoilT.Strategies.Soil, strategy " + this.GetType().Name ); }
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
			public void Estimate(UNIMI.SoilT.Interfaces.Rates rates,UNIMI.SoilT.Interfaces.States states,UNIMI.SoilT.Interfaces.Auxiliary auxiliary,UNIMI.SoilT.Interfaces.States states1,UNIMI.SoilT.Interfaces.Exogenous exogenous,UNIMI.SoilT.Interfaces.StatesExternal statesexternal,CRA.AgroManagement.ActEvents actevents)
			{
					
				

				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section1
				//Code written below will not be overwritten by a future code generation

                double SandFraction = 0;
                double SiltFraction = 0;
                double ClayFraction = 0;
                double FractionMinerals = 0;
                double OrganicMatterFraction = 0;

                //foreach (LayerStates layer in states.Layers)
				for (int i = 0; i < states.HeatCapacity.Length; i++)
                {
                    SandFraction = states.Sand[i] / (states.Sand[i] + states.Silt[i] + states.Clay[i] + states.OrganicMatter[i]);
                    SiltFraction = states.Silt[i] / (states.Sand[i] + states.Silt[i] + states.Clay[i] + states.OrganicMatter[i]);
                    ClayFraction = states.Clay[i] / (states.Sand[i] + states.Silt[i] + states.Clay[i] + states.OrganicMatter[i]);
                    FractionMinerals = SandFraction + SiltFraction + ClayFraction;

                    OrganicMatterFraction = states.OrganicMatter[i] / (states.Sand[i] + states.Silt[i] + states.Clay[i] + states.OrganicMatter[i]);

                    states.HeatCapacity[i] = states.BulkDensity[i] * 0.73 * FractionMinerals +
                                         (states.BulkDensity[i] * 1.9 * OrganicMatterFraction)
                                         + (4.18 * states.VolumetricWaterContent[i]);
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

//%%CyML Description Begin%%
/*

     - Name: VolumetricHeatCapacityKluitenberg -Version: 001, -Time step: 1
     - Description:
                 * Title: VolumetricHeatCapacityKluitenberg model
                 * Authors: simone.bregaglio@unimi.it
                 * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
                 * Institution: University Of Milan
                 * ExtendedDescription: Strategy for the calculation of soil thermal diffusivity. Reference: J.M.H.Hendrickx, H. Xie, B. Borchers, J.B.J. Harrison, 2008. Global Prediction of Thermal Soil Regimes. SPIE Proceedings Volume 6953 Detection and Sensing of Mines, Explosive Objects, and Obscured Targets XIII.
                 * ShortDescription: Strategy for the calculation of volumetric heat capacity. Kluitenberg, G.J., Heat capacity and specific heat, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series #5: Madison, Wisconsin. p. 1201-1208.
     - inputs:
                 * name: VolumetricWaterContent
                               ** description : Volumetric soil water content
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 0.8
                               ** min : 0
                               ** default : 0.25
                               ** unit : m3 m-3
                 * name: Sand
                               ** description : Sand content of soil layer
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 100
                               ** min : 0
                               ** default : 30
                               ** unit : %
                 * name: BulkDensity
                               ** description : Bulk density
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 1.8
                               ** min : 0.9
                               ** default : 1.3
                               ** unit : t m-3
                 * name: OrganicMatter
                               ** description : Organic matter content of soil layer
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 20
                               ** min : 0
                               ** default : 1.5
                               ** unit : %
                 * name: HeatCapacity
                               ** description : Volumetric specific heat of soil
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 300
                               ** min : 0
                               ** default : 20
                               ** unit : MJ m-3 Â°C-1
                 * name: Clay
                               ** description : Clay content of soil layer
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 100
                               ** min : 0
                               ** default : 0
                               ** unit : %
                 * name: Silt
                               ** description : Silt content of soil layer
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 100
                               ** min : 0
                               ** default : 20
                               ** unit : %
     - outputs:
                 * name: HeatCapacity
                               ** description : Volumetric specific heat of soil
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 300
                               ** min : 0
                               ** unit : MJ m-3 Â°C-1


*/
//%%CyML Description End%%