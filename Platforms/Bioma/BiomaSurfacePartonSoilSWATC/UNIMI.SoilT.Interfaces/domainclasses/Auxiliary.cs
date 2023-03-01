//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:2.0.50727.5477
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

/// This class was created from file C:\Users\Diprove\Desktop\Reimplementazione\SoilT\UNIMI.SoilT_perSoilBorne\UNIMI.SoilT\DataStructure\SoilTemperatureAuxiliary.xml
/// DCC - Domain Class Coder, http://agsys.cra-cin.it/tools , see Applications, DCC
// 
namespace UNIMI.SoilT.Interfaces
{
    using System;
    using System.Collections.Generic;
    using CRA.ModelLayer;
    using System.Reflection;
    using CRA.ModelLayer.ParametersManagement;
    using CRA.ModelLayer.Core;
    
    /// <summary>Auxiliary Domain class contains the accessors to values</summary>
    public class Auxiliary : ICloneable, IDomainClass
    {
        
        #region Private fields
        private double _SurfaceTemperatureMaximum;
        
        private double _SurfaceTemperatureMinimum;
        #endregion
        
        #region Private field for properties
        private ParametersIO _parametersIO;
        #endregion
        
        #region Constructor
        /// <summary>No parameters constructor</summary>
        public Auxiliary()
        {
            _parametersIO = new ParametersIO(this);
        }
        #endregion
        
        #region Public properties
        /// <summary>Maximum surface soil temperature</summary>
        public double SurfaceTemperatureMaximum
        {
            get
            {
                return this._SurfaceTemperatureMaximum;
            }
            set
            {
                this._SurfaceTemperatureMaximum = value;
            }
        }
        
        /// <summary>Minimum surface soil temperature</summary>
        public double SurfaceTemperatureMinimum
        {
            get
            {
                return this._SurfaceTemperatureMinimum;
            }
            set
            {
                this._SurfaceTemperatureMinimum = value;
            }
        }
        #endregion
        
        #region IDomainClass members
        /// <summary>Domain Class description</summary>
        public virtual  string Description
        {
            get
            {
                return "Auxiliary variables of SoilT component ";
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
            _SurfaceTemperatureMaximum = default(System.Double);
            _SurfaceTemperatureMinimum = default(System.Double);
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

        /// <summary>
        /// Initializes the structure.
        /// </summary>
        public void Initialize()
        {
            Initialize(false, 0);
        }

        /// <summary>
        /// Initializes the structure.
        /// </summary>
        /// <param name="resetLayersNumber"><c>true</c> if horizon list has
        /// to be initialized.</param>
        /// <param name="layersNumber">Number of layers to set.</param>
        public void Initialize(bool resetLayersNumber, int layersNumber)
        {
        }

        /// <summary>
        /// Initializes the structure properties to their default value.
        /// </summary>
        /// <param name="allValues"><c>true</c> if all values have to be set,
        /// <c>false</c> if only <c>NaN</c> or <c>null</c> values have to be set.</param>
        public void SetDefaultValues(bool allValues)
        {
        }
    }
}