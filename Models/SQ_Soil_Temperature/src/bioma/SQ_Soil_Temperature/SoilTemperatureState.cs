
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SoilTemperature.DomainClass
{
    public class SoilTemperatureState : ICloneable, IDomainClass
    {
        private double _minTSoil;
        private double _deepLayerT;
        private double _maxTSoil;
        private double[] _hourlySoilT = new double[24];
        private ParametersIO _parametersIO;

        public SoilTemperatureState()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SoilTemperatureState(SoilTemperatureState toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                minTSoil = toCopy.minTSoil;
                deepLayerT = toCopy.deepLayerT;
                maxTSoil = toCopy.maxTSoil;
                hourlySoilT = new double[24];
            for (int i = 0; i < 24; i++)
            { hourlySoilT[i] = toCopy.hourlySoilT[i]; }
    
            }
        }

        public double minTSoil
        {
            get { return this._minTSoil; }
            set { this._minTSoil= value; } 
        }
        public double deepLayerT
        {
            get { return this._deepLayerT; }
            set { this._deepLayerT= value; } 
        }
        public double maxTSoil
        {
            get { return this._maxTSoil; }
            set { this._maxTSoil= value; } 
        }
        public double[] hourlySoilT
        {
            get { return this._hourlySoilT; }
            set { this._hourlySoilT= value; } 
        }

        public string Description
        {
            get { return "SoilTemperatureState of the component";}
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
             _minTSoil = default(double);
             _deepLayerT = default(double);
             _maxTSoil = default(double);
             _hourlySoilT = new double[24];
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