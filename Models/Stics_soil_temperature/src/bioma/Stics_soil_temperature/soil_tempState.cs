
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace soil_temp.DomainClass
{
    public class soil_tempState : ICloneable, IDomainClass
    {
        private double _temp_amp;
        private double _therm_amp;
        private double[] _temp_profile;
        private double _canopy_temp_avg;
        private double[] _layer_temp;
        private double[] _prev_temp_profile = new double[1];
        private ParametersIO _parametersIO;

        public soil_tempState()
        {
            _parametersIO = new ParametersIO(this);
        }

        public soil_tempState(soil_tempState toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                temp_amp = toCopy.temp_amp;
                therm_amp = toCopy.therm_amp;
                temp_profile = new double[toCopy.temp_profile.Length];
            for (int i = 0; i < toCopy.temp_profile.Length; i++)
            { temp_profile[i] = toCopy.temp_profile[i]; }
    
                canopy_temp_avg = toCopy.canopy_temp_avg;
                layer_temp = new double[toCopy.layer_temp.Length];
            for (int i = 0; i < toCopy.layer_temp.Length; i++)
            { layer_temp[i] = toCopy.layer_temp[i]; }
    
                prev_temp_profile = new double[1];
            for (int i = 0; i < 1; i++)
            { prev_temp_profile[i] = toCopy.prev_temp_profile[i]; }
    
            }
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
        public double canopy_temp_avg
        {
            get { return this._canopy_temp_avg; }
            set { this._canopy_temp_avg= value; } 
        }
        public double[] layer_temp
        {
            get { return this._layer_temp; }
            set { this._layer_temp= value; } 
        }
        public double[] prev_temp_profile
        {
            get { return this._prev_temp_profile; }
            set { this._prev_temp_profile= value; } 
        }

        public string Description
        {
            get { return "soil_tempState of the component";}
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
             _temp_amp = default(double);
             _therm_amp = default(double);
             _temp_profile = default(double[]);
             _canopy_temp_avg = default(double);
             _layer_temp = default(double[]);
             _prev_temp_profile = new double[1];
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