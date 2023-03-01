
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfacePartonSoilSWATC.DomainClass
{
    public class SurfacePartonSoilSWATCExogenous : ICloneable, IDomainClass
    {
        private double _GlobalSolarRadiation;
        private double _AirTemperatureMaximum;
        private double _AirTemperatureMinimum;
        private double _DayLength;
        private double _AirTemperatureAnnualAverage;
        private ParametersIO _parametersIO;

        public SurfacePartonSoilSWATCExogenous()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SurfacePartonSoilSWATCExogenous(SurfacePartonSoilSWATCExogenous toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                _GlobalSolarRadiation = toCopy._GlobalSolarRadiation;
                _AirTemperatureMaximum = toCopy._AirTemperatureMaximum;
                _AirTemperatureMinimum = toCopy._AirTemperatureMinimum;
                _DayLength = toCopy._DayLength;
                _AirTemperatureAnnualAverage = toCopy._AirTemperatureAnnualAverage;
            }
        }

        public double GlobalSolarRadiation
        {
            get { return this._GlobalSolarRadiation; }
            set { this._GlobalSolarRadiation= value; } 
        }
        public double AirTemperatureMaximum
        {
            get { return this._AirTemperatureMaximum; }
            set { this._AirTemperatureMaximum= value; } 
        }
        public double AirTemperatureMinimum
        {
            get { return this._AirTemperatureMinimum; }
            set { this._AirTemperatureMinimum= value; } 
        }
        public double DayLength
        {
            get { return this._DayLength; }
            set { this._DayLength= value; } 
        }
        public double AirTemperatureAnnualAverage
        {
            get { return this._AirTemperatureAnnualAverage; }
            set { this._AirTemperatureAnnualAverage= value; } 
        }

        public string Description
        {
            get { return "SurfacePartonSoilSWATCExogenous of the component";}
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
             _GlobalSolarRadiation = default(double);
             _AirTemperatureMaximum = default(double);
             _AirTemperatureMinimum = default(double);
             _DayLength = default(double);
             _AirTemperatureAnnualAverage = default(double);
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