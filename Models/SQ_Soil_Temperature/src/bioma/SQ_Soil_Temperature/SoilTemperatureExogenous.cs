
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
                _meanTAir = toCopy._meanTAir;
                _minTAir = toCopy._minTAir;
                _maxTAir = toCopy._maxTAir;
                _dayLength = toCopy._dayLength;
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