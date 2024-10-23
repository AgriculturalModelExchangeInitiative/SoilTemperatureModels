
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
using SiriusQualitysoil_temp.DomainClass;
namespace SiriusQualitysoil_temp.Strategies
{
    public class layers_temp : IStrategySiriusQualitysoil_temp
    {
        public layers_temp()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = -1D;
            v1.Description = "layers thickness";
            v1.Id = 0;
            v1.MaxValue = -1D;
            v1.MinValue = -1D;
            v1.Name = "layer_thick";
            v1.Size = 1;
            v1.Units = "cm";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayInteger");
            _parameters0_0.Add(v1);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualitysoil_temp.DomainClass.soil_tempState);
            pd1.PropertyName = "temp_profile";
            pd1.PropertyType = (SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.temp_profile).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.temp_profile);
            _inputs0_0.Add(pd1);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitysoil_temp.DomainClass.soil_tempState);
            pd2.PropertyName = "layer_temp";
            pd2.PropertyType = (SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.layer_temp).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.layer_temp);
            _outputs0_0.Add(pd2);
            mo0_0.Outputs=_outputs0_0;
            //Associated strategies
            List<string> lAssStrat0_0 = new List<string>();
            mo0_0.AssociatedStrategies = lAssStrat0_0;
            //Adding the modeling options to the modeling options manager
            _modellingOptionsManager = new ModellingOptionsManager(mo0_0);
            SetStaticParametersVarInfoDefinitions();
            SetPublisherData();

        }

        public string Description
        {
            
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
            _pd.Add("Creator", "None");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "INRAE "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(SiriusQualitysoil_temp.DomainClass.soil_tempState),  typeof(SiriusQualitysoil_temp.DomainClass.soil_tempState), typeof(SiriusQualitysoil_temp.DomainClass.soil_tempRate), typeof(SiriusQualitysoil_temp.DomainClass.soil_tempAuxiliary), typeof(SiriusQualitysoil_temp.DomainClass.soil_tempExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public int[] layer_thick
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("layer_thick");
                if (vi != null && vi.CurrentValue!=null) return (int[])vi.CurrentValue ;
                else throw new Exception("Parameter 'layer_thick' not found (or found null) in strategy 'layers_temp'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("layer_thick");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'layer_thick' not found in strategy 'layers_temp'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            layer_thickVarInfo.Name = "layer_thick";
            layer_thickVarInfo.Description = "layers thickness";
            layer_thickVarInfo.MaxValue = -1D;
            layer_thickVarInfo.MinValue = -1D;
            layer_thickVarInfo.DefaultValue = -1D;
            layer_thickVarInfo.Units = "cm";
            layer_thickVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayInteger");
        }

        private static VarInfo _layer_thickVarInfo = new VarInfo();
        public static VarInfo layer_thickVarInfo
        {
            get { return _layer_thickVarInfo;} 
        }

        public string TestPostConditions(SiriusQualitysoil_temp.DomainClass.soil_tempState s,SiriusQualitysoil_temp.DomainClass.soil_tempState s1,SiriusQualitysoil_temp.DomainClass.soil_tempRate r,SiriusQualitysoil_temp.DomainClass.soil_tempAuxiliary a,SiriusQualitysoil_temp.DomainClass.soil_tempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.layer_temp.CurrentValue=s.layer_temp;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.layer_temp);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.layer_temp.ValueType)){prc.AddCondition(r3);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.soil_temp, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualitysoil_temp.DomainClass.soil_tempState s,SiriusQualitysoil_temp.DomainClass.soil_tempState s1,SiriusQualitysoil_temp.DomainClass.soil_tempRate r,SiriusQualitysoil_temp.DomainClass.soil_tempAuxiliary a,SiriusQualitysoil_temp.DomainClass.soil_tempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.temp_profile.CurrentValue=s.temp_profile;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.temp_profile);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.temp_profile.ValueType)){prc.AddCondition(r1);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("layer_thick")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.soil_temp, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualitysoil_temp.DomainClass.soil_tempState s,SiriusQualitysoil_temp.DomainClass.soil_tempState s1,SiriusQualitysoil_temp.DomainClass.soil_tempRate r,SiriusQualitysoil_temp.DomainClass.soil_tempAuxiliary a,SiriusQualitysoil_temp.DomainClass.soil_tempExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualitysoil_temp, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SiriusQualitysoil_temp.DomainClass.soil_tempState s, SiriusQualitysoil_temp.DomainClass.soil_tempState s1, SiriusQualitysoil_temp.DomainClass.soil_tempRate r, SiriusQualitysoil_temp.DomainClass.soil_tempAuxiliary a, SiriusQualitysoil_temp.DomainClass.soil_tempExogenous ex)
        {
            List<double> temp_profile = s.temp_profile;
            List<double> layer_temp = new List<double>();
            int z;
            int layers_nb;
            List<int> up_depth = new List<int>();
            List<int> layer_depth = new List<int>();
            int depth_value;
            layers_nb = get_layers_number(layer_thick);
            layer_temp = new List<double>(layers_nb);
            up_depth = new List<int>(layers_nb + 1);
            layer_depth = new List<int>(layers_nb);
            for (var i = 0; i < layers_nb + 1; i++){up_depth.Add(0);}
            layer_depth = layer_thickness2depth(layer_thick);
            for (z=1 ; z!=layers_nb + 1 ; z+=1)
            {
                depth_value = layer_depth[z - 1];
                up_depth[z + 1 - 1] = depth_value;
            }
            for (z=1 ; z!=layers_nb + 1 ; z+=1)
            {
                layer_temp[z - 1] = temp_profile.GetRange((up_depth[z - 1] + 1 - 1),up_depth[(z + 1 - 1)] - (up_depth[z - 1] + 1 - 1)).Sum() / layer_thick[(z - 1)];
            }
            s.layer_temp= layer_temp;
        }

        public static int get_layers_number(int[] layer_thick_or_depth)
        {
            int layers_number;
            int z;
            layers_number = 0;
            for (z=1 ; z!=layer_thick_or_depth.Length + 1 ; z+=1)
            {
                if (layer_thick_or_depth[z - 1] != 0)
                {
                    layers_number = layers_number + 1;
                }
            }
            return layers_number;
        }

        public static List<int> layer_thickness2depth(int[] layer_thick)
        {
            List<int> layer_depth = new List<int>();
            int layers_nb;
            int z;
            layers_nb = layer_thick.Length;
            layer_depth = new List<int>(layers_nb);
            for (var i = 0; i < layers_nb; i++){layer_depth.Add(0);}
            for (z=1 ; z!=layers_nb + 1 ; z+=1)
            {
                if (layer_thick[z - 1] != 0)
                {
                    layer_depth[z - 1] = layer_thick.ToList().GetRange(1 - 1,z - 1 - 1).Sum();
                }
            }
            return layer_depth;
        }

    }
}