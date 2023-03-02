
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfacePartonSoilSWATHourlyPartonC.DomainClass
{
    public class SurfacePartonSoilSWATHourlyPartonCAuxiliary : ICloneable, IDomainClass
    {
        private double _SurfaceTemperatureMaximum;
        private double _SurfaceTemperatureMinimum;
        private ParametersIO _parametersIO;

        public SurfacePartonSoilSWATHourlyPartonCAuxiliary()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SurfacePartonSoilSWATHourlyPartonCAuxiliary(SurfacePartonSoilSWATHourlyPartonCAuxiliary toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                _SurfaceTemperatureMaximum = toCopy._SurfaceTemperatureMaximum;
                _SurfaceTemperatureMinimum = toCopy._SurfaceTemperatureMinimum;
            }
        }

        public double SurfaceTemperatureMaximum
        {
            get { return this._SurfaceTemperatureMaximum; }
            set { this._SurfaceTemperatureMaximum= value; } 
        }
        public double SurfaceTemperatureMinimum
        {
            get { return this._SurfaceTemperatureMinimum; }
            set { this._SurfaceTemperatureMinimum= value; } 
        }

        public string Description
        {
            get { return "SurfacePartonSoilSWATHourlyPartonCAuxiliary of the component";}
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
             _SurfaceTemperatureMaximum = default(double);
             _SurfaceTemperatureMinimum = default(double);
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