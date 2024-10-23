
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SoilTemperature.DomainClass
{
    public class SoilTemperatureExogenous : ICloneable, IDomainClass
    {
        private double _meanTAir;
        private double _minTAir;
        private double _meanAnnualAirTemp;
        private double _maxTAir;
        private double _dayLength;
        private ParametersIO _parametersIO;

        public SoilTemperatureExogenous()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SoilTemperatureExogenous(SoilTemperatureExogenous toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                meanTAir = toCopy.meanTAir;
                minTAir = toCopy.minTAir;
                meanAnnualAirTemp = toCopy.meanAnnualAirTemp;
                maxTAir = toCopy.maxTAir;
                dayLength = toCopy.dayLength;
            }
        }

        public double meanTAir
        {
            get { return this._meanTAir; }
            set { this._meanTAir= value; } 
        }
        public double minTAir
        {
            get { return this._minTAir; }
            set { this._minTAir= value; } 
        }
        public double meanAnnualAirTemp
        {
            get { return this._meanAnnualAirTemp; }
            set { this._meanAnnualAirTemp= value; } 
        }
        public double maxTAir
        {
            get { return this._maxTAir; }
            set { this._maxTAir= value; } 
        }
        public double dayLength
        {
            get { return this._dayLength; }
            set { this._dayLength= value; } 
        }

        public string Description
        {
            get { return "SoilTemperatureExogenous of the component";}
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
             _meanTAir = default(double);
             _minTAir = default(double);
             _meanAnnualAirTemp = default(double);
             _maxTAir = default(double);
             _dayLength = default(double);
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