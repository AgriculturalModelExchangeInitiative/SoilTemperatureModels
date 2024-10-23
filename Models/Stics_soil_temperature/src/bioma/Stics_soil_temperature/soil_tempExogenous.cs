
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace soil_temp.DomainClass
{
    public class soil_tempExogenous : ICloneable, IDomainClass
    {
        private double _min_temp;
        private double _max_temp;
        private double _min_air_temp;
        private double _min_canopy_temp;
        private double _max_canopy_temp;
        private ParametersIO _parametersIO;

        public soil_tempExogenous()
        {
            _parametersIO = new ParametersIO(this);
        }

        public soil_tempExogenous(soil_tempExogenous toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                min_temp = toCopy.min_temp;
                max_temp = toCopy.max_temp;
                min_air_temp = toCopy.min_air_temp;
                min_canopy_temp = toCopy.min_canopy_temp;
                max_canopy_temp = toCopy.max_canopy_temp;
            }
        }

        public double min_temp
    {
        get { return this._min_temp; }
        set { this._min_temp= value; } 
    }
        public double max_temp
    {
        get { return this._max_temp; }
        set { this._max_temp= value; } 
    }
        public double min_air_temp
    {
        get { return this._min_air_temp; }
        set { this._min_air_temp= value; } 
    }
        public double min_canopy_temp
    {
        get { return this._min_canopy_temp; }
        set { this._min_canopy_temp= value; } 
    }
        public double max_canopy_temp
    {
        get { return this._max_canopy_temp; }
        set { this._max_canopy_temp= value; } 
    }

        public string Description
        {
            get { return "soil_tempExogenous of the component";}
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
             _min_temp = default(double);
             _max_temp = default(double);
             _min_air_temp = default(double);
             _min_canopy_temp = default(double);
             _max_canopy_temp = default(double);
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