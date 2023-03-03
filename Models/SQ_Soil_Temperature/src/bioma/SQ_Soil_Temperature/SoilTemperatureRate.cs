
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SoilTemperature.DomainClass
{
    public class SoilTemperatureRate : ICloneable, IDomainClass
    {
        private double _heatFlux;
        private ParametersIO _parametersIO;

        public SoilTemperatureRate()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SoilTemperatureRate(SoilTemperatureRate toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                _heatFlux = toCopy._heatFlux;
            }
        }

        public double heatFlux
        {
            get { return this._heatFlux; }
            set { this._heatFlux= value; } 
        }

        public string Description
        {
            get { return "SoilTemperatureRate of the component";}
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
             _heatFlux = default(double);
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