
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfacePartonSoilSWATC.DomainClass
{
    public class SurfacePartonSoilSWATCExogenous : ICloneable, IDomainClass
    {
        private double _AboveGroundBiomass;
        private double _DayLength;
        private double _AirTemperatureMinimum;
        private double _GlobalSolarRadiation;
        private double _AirTemperatureMaximum;
        private ParametersIO _parametersIO;

        public SurfacePartonSoilSWATCExogenous()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SurfacePartonSoilSWATCExogenous(SurfacePartonSoilSWATCExogenous toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                AboveGroundBiomass = toCopy.AboveGroundBiomass;
                DayLength = toCopy.DayLength;
                AirTemperatureMinimum = toCopy.AirTemperatureMinimum;
                GlobalSolarRadiation = toCopy.GlobalSolarRadiation;
                AirTemperatureMaximum = toCopy.AirTemperatureMaximum;
            }
        }

        public double AboveGroundBiomass
        {
            get { return this._AboveGroundBiomass; }
            set { this._AboveGroundBiomass= value; } 
        }
        public double DayLength
        {
            get { return this._DayLength; }
            set { this._DayLength= value; } 
        }
        public double AirTemperatureMinimum
        {
            get { return this._AirTemperatureMinimum; }
            set { this._AirTemperatureMinimum= value; } 
        }
        public double GlobalSolarRadiation
        {
            get { return this._GlobalSolarRadiation; }
            set { this._GlobalSolarRadiation= value; } 
        }
        public double AirTemperatureMaximum
        {
            get { return this._AirTemperatureMaximum; }
            set { this._AirTemperatureMaximum= value; } 
        }

        public string Description
        {
            get { return "SurfacePartonSoilSWATCExogenous of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public virtual IDictionary<string, PropertyInfo> PropertiesDescription
        {
            get { return _parametersIO.GetCachedProperties(typeof(IDomainClass));}
        }

        public virtual Boolean ClearValues()
        {
             _AboveGroundBiomass = default(double);
             _DayLength = default(double);
             _AirTemperatureMinimum = default(double);
             _GlobalSolarRadiation = default(double);
             _AirTemperatureMaximum = default(double);
            return true;
        }

        public virtual Object Clone()
        {
            IDomainClass myclass = (IDomainClass) this.MemberwiseClone();
            _parametersIO.PopulateClonedCopy(myclass);
            return myclass;
        }
    }
}