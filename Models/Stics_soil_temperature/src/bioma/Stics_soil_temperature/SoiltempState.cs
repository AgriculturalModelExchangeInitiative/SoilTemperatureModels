
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace Soiltemp.DomainClass
{
    public class SoiltempState : ICloneable, IDomainClass
    {
        private double[] _prev_temp_profile = new double[1];
        private double _temp_amp;
        private double _therm_amp;
        private double[] _temp_profile;
        private ParametersIO _parametersIO;

        public SoiltempState()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SoiltempState(SoiltempState toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                prev_temp_profile = new double[1];
            for (int i = 0; i < 1; i++)
            { _prev_temp_profile[i] = toCopy._prev_temp_profile[i]; }
    
                _temp_amp = toCopy._temp_amp;
                _therm_amp = toCopy._therm_amp;
                temp_profile = new double[toCopy._temp_profile.Length];
            for (int i = 0; i < toCopy._temp_profile.Length; i++)
            { _temp_profile[i] = toCopy._temp_profile[i]; }
    
            }
        }

        public double[] prev_temp_profile
        {
            get { return this._prev_temp_profile; }
            set { this._prev_temp_profile= value; } 
        }
        public double temp_amp
        {
            get { return this._temp_amp; }
            set { this._temp_amp= value; } 
        }
        public double therm_amp
        {
            get { return this._therm_amp; }
            set { this._therm_amp= value; } 
        }
        public double[] temp_profile
        {
            get { return this._temp_profile; }
            set { this._temp_profile= value; } 
        }

        public string Description
        {
            get { return "SoiltempState of the component";}
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
             _prev_temp_profile = new double[1];
             _temp_amp = default(double);
             _therm_amp = default(double);
             _temp_profile = new double[];
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