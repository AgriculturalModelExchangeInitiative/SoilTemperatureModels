
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitysoil_temp.DomainClass
{
    public class soil_tempAuxiliary : ICloneable, IDomainClass
    {
        private double _temp_wave_freq;
        private double _therm_diff;
        private ParametersIO _parametersIO;

        public soil_tempAuxiliary()
        {
            _parametersIO = new ParametersIO(this);
        }

        public soil_tempAuxiliary(soil_tempAuxiliary toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                temp_wave_freq = toCopy.temp_wave_freq;
                therm_diff = toCopy.therm_diff;
            }
        }

        public double temp_wave_freq
        {
            get { return this._temp_wave_freq; }
            set { this._temp_wave_freq= value; } 
        }
        public double therm_diff
        {
            get { return this._therm_diff; }
            set { this._therm_diff= value; } 
        }

        public string Description
        {
            get { return "soil_tempAuxiliary of the component";}
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
             _temp_wave_freq = default(double);
             _therm_diff = default(double);
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