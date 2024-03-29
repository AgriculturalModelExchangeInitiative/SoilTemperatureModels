//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

/// 
/// This class was created from file C:\CREA\V2\ModelComponents\Soil\SoilT\UNIMI.SoilT\bin\Debug\UNIMI.SoilT.dll
/// The tool used was: DCC - Domain Class Coder, http://components.biomamodelling.org/, DCC
/// 
/// Simone Bregaglio
/// simoneugomaria.bregaglio@crea.gov.it
/// CREA
/// crea.gov.it
/// 
/// 5/8/2017 10:54:18 AM
/// 
namespace UNIMI.SoilT.Strategies.Parameters
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using CRA.ModelLayer.Core;
    using CRA.ModelLayer.ParametersManagement;
    using System.IO;
    
    
    /// <summary>SurfacePartonSoilSWATHourlyPartonC Domain class contains the accessors to values and the code to load/write parameters from an XML file (MPE)</summary>
    [Serializable()]
    public class SurfacePartonSoilSWATHourlyPartonC_Parameters : ICloneable, IParameters
    {
        
        #region Private fields
        private string _ParameterKey;
        
        private double _LagCoefficient;
        #endregion
        
        #region Private field for properties
        private ParametersIO _parametersIO;
        #endregion
        
        #region Constructor
        /// <summary>No parameters constructor</summary>
        public SurfacePartonSoilSWATHourlyPartonC_Parameters()
        {
            _parametersIO = new ParametersIO(this);
            string filePath = Path.GetDirectoryName(Assembly.GetAssembly(this.GetType()).Location) + Path.DirectorySeparatorChar + "UNIMI.SoilT.Strategies.Composite_SurfacePartonSoilSWATHourlyPartonC.XML";
            XmlRW _xmlRW = new XmlRW(filePath);
            _parametersIO.Reader = _xmlRW;
            _parametersIO.Writer = _xmlRW;
        }
        #endregion
        
        #region Public properties
        /// <summary>Parameter key</summary>
        public string ParameterKey
        {
            get
            {
                return this._ParameterKey;
            }
            set
            {
                this._ParameterKey = value;
                if (ParameterClassPropertyValueSet != null)
                {
					ParameterClassPropertyValueSet("ParameterKey",value);
                }
            }
        }
        
        /// <summary>Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature</summary>
        public double LagCoefficient
        {
            get
            {
                return this._LagCoefficient;
            }
            set
            {
                this._LagCoefficient = value;
                if (ParameterClassPropertyValueSet != null)
                {
					ParameterClassPropertyValueSet("LagCoefficient",value);
                }
            }
        }
        #endregion
        
        #region IDomainClass members
        /// <summary>Domain Class description</summary>
        public virtual  string Description
        {
            get
            {
                return "Parameter class to load from XML for the SurfacePartonSoilSWATHourlyPartonC class - Composite strategy for the calculation of surface temperature with Parton's method and soil temperature with SWAT method. See also references of the associated strategies.";
            }
        }
        
        /// <summary>Domain Class URL</summary>
        public virtual  string URL
        {
            get
            {
                return "http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl";
            }
        }
        
        /// <summary>Domain Class Properties</summary>
        public virtual IDictionary<string, PropertyInfo> PropertiesDescription
        {
            get
            {
                return _parametersIO.GetCachedProperties(typeof(IDomainClass), typeof(IParameters));
            }
        }
        #endregion
        
        #region IParameters members
        /// <summary>The reader used to read parameters' definition and values</summary>
        public IValuesReader Reader
        {
            get
            {
                return _parametersIO.Reader;
            }
            set
            {
                _parametersIO.Reader = value;
            }
        }
        
        /// <summary>The writer used to write parameters' values</summary>
        public IValuesWriter Writer
        {
            get
            {
                return _parametersIO.Writer;
            }
            set
            {
                _parametersIO.Writer = value;
            }
        }
        
        /// <summary>Event launched when one of the values of the parameters is set.</summary>
        public event Action<string,object> ParameterClassPropertyValueSet;
        
        /// <summary>Clears the values of the properties of the domain class by using the default value for the type of each property (e.g '0' for numbers, 'the empty string' for strings, etc.)</summary>
        public virtual Boolean ClearValues()
        {
            _ParameterKey = default(System.String);
            _LagCoefficient = default(System.Double);
            // Returns true if everything is ok
            return true;
        }
        
        /// <summary>Save parameter values into the Writer</summary>
        public virtual string SaveParameters(string parametersKey)
        {
            return _parametersIO.SaveParameters(parametersKey);
        }
        
        /// <summary>Set parameter values at run time. It might be a sub-set of parameters.</summary>
        public virtual void SetParameters(IEnumerable<VarInfo> parametersVarInfoSource)
        {
            _parametersIO.SetParameters(parametersVarInfoSource);
        }
        #endregion
        
        #region Clone
        /// <summary>Implement ICloneable.Clone()</summary>
        public virtual Object Clone()
        {
            // Shallow copy by default
            IDomainClass myclass = (IDomainClass) this.MemberwiseClone();
            _parametersIO.PopulateClonedCopy(myclass);
            return myclass;
        }
        #endregion
    }
}
