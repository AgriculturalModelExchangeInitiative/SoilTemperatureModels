//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

/// 
/// This class was created from file C:\Users\mancealo\Documents\Sirius Quality\branches\TestSoil\Code\SiriusQuality-SoilTemperatureDomainClasses\XML\UNIMI.SoilT.Interfaces_Exogenous.xml
/// The tool used was: DCC - Domain Class Coder, http://components.biomamodelling.org/, DCC
/// 
/// Loic Manceau
/// loic.manceau@inra.fr
/// INRA
/// 
/// 
/// 5/8/2017 12:22:17 PM
/// 
namespace INRA.SiriusQualitySoilT.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using CRA.ModelLayer.Core;
    using CRA.ModelLayer.ParametersManagement;
    
    
    /// <summary>Exogenous Domain class contains the accessors to values</summary>
    [Serializable()]
    public class Exogenous : ICloneable, IDomainClass
    {
        
        #region Private fields
        private double _minTAir;
        
        private double _maxTAir;
        
        private double _meanTAir;
        
        private double _dayLength;

        private double _meanAnnualAirTemp;
        #endregion
        
        #region Private field for properties
        private ParametersIO _parametersIO;
        #endregion
        
        #region Constructor
        /// <summary>No parameters constructor</summary>
        public Exogenous()
        {
            _parametersIO = new ParametersIO(this);
        }

        public Exogenous(Exogenous toCopy)
        {
            _parametersIO = new ParametersIO(this);
            _minTAir = toCopy._minTAir;
            _maxTAir = toCopy._maxTAir;
            _meanTAir = toCopy._meanTAir;
            _dayLength = toCopy._dayLength;
            _meanAnnualAirTemp = toCopy._meanAnnualAirTemp;

        }

        #endregion
        
        #region Public properties
        /// <summary>Minimum Air Temperature from Weather files</summary>
        public double minTAir
        {
            get
            {
                return this._minTAir;
            }
            set
            {
                this._minTAir = value;
            }
        }
        
        /// <summary>Maximum Air Temperature from Weather Files</summary>
        public double maxTAir
        {
            get
            {
                return this._maxTAir;
            }
            set
            {
                this._maxTAir = value;
            }
        }
        
        /// <summary>Mean Air Temperature</summary>
        public double meanTAir
        {
            get
            {
                return this._meanTAir;
            }
            set
            {
                this._meanTAir = value;
            }
        }
        
        /// <summary>Length of the day</summary>
        public double dayLength
        {
            get
            {
                return this._dayLength;
            }
            set
            {
                this._dayLength = value;
            }
        }

        /// <summary>Annual Mean Air Temperature</summary>
        public double meanAnnualAirTemp
        {
            get
            {
                return this._meanAnnualAirTemp;
            }
            set
            {
                this._meanAnnualAirTemp = value;
            }
        }
        #endregion

        #region IDomainClass members
        /// <summary>Domain Class description</summary>
        public virtual  string Description
        {
            get
            {
                return "Exogenous of the SoilT component";
            }
        }
        
        /// <summary>Domain Class URL</summary>
        public virtual  string URL
        {
            get
            {
                return "http://";
            }
        }
        
        /// <summary>Domain Class Properties</summary>
        public virtual IDictionary<string, PropertyInfo> PropertiesDescription
        {
            get
            {
                return _parametersIO.GetCachedProperties(typeof(IDomainClass));
            }
        }
        #endregion
        
        /// <summary>Clears the values of the properties of the domain class by using the default value for the type of each property (e.g '0' for numbers, 'the empty string' for strings, etc.)</summary>
        public virtual Boolean ClearValues()
        {
            _minTAir = default(System.Double);
            _maxTAir = default(System.Double);
            _meanTAir = default(System.Double);
            _dayLength = default(System.Double);
            _meanAnnualAirTemp = default(System.Double);
            // Returns true if everything is ok
            return true;
        }
        
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
