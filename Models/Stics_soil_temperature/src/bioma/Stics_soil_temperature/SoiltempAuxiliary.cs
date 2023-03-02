
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace Soiltemp.DomainClass
{
    public class SoiltempAuxiliary : ICloneable, IDomainClass
    {
        private double _therm_diff;
        private double _temp_wave_freq;
        private ParametersIO _parametersIO;

        public SoiltempAuxiliary()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SoiltempAuxiliary(SoiltempAuxiliary toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                _therm_diff = toCopy._therm_diff;
                _temp_wave_freq = toCopy._temp_wave_freq;
            }
        }

        public double therm_diff
        {
            get { return this._therm_diff; }
            set { this._therm_diff= value; } 
        }
        public double temp_wave_freq
        {
            get { return this._temp_wave_freq; }
            set { this._temp_wave_freq= value; } 
        }

        public string Description
        {
            get { return "SoiltempAuxiliary of the component";}
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
             _therm_diff = default(double);
             _temp_wave_freq = default(double);
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