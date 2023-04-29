
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfacePartonSoilSWATHourlyPartonC.DomainClass
{
    public class SurfacePartonSoilSWATHourlyPartonCExogenous : ICloneable, IDomainClass
    {
        private double _GlobalSolarRadiation;
        private double _DayLength;
        private double _AirTemperatureMinimum;
        private double _AirTemperatureMaximum;
        private double _AirTemperatureAnnualAverage;
        private double _HourOfSunrise;
        private double _HourOfSunset;
        private ParametersIO _parametersIO;

        public SurfacePartonSoilSWATHourlyPartonCExogenous()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SurfacePartonSoilSWATHourlyPartonCExogenous(SurfacePartonSoilSWATHourlyPartonCExogenous toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                _GlobalSolarRadiation = toCopy._GlobalSolarRadiation;
                _DayLength = toCopy._DayLength;
                _AirTemperatureMinimum = toCopy._AirTemperatureMinimum;
                _AirTemperatureMaximum = toCopy._AirTemperatureMaximum;
                _AirTemperatureAnnualAverage = toCopy._AirTemperatureAnnualAverage;
                _HourOfSunrise = toCopy._HourOfSunrise;
                _HourOfSunset = toCopy._HourOfSunset;
            }
        }

        public double GlobalSolarRadiation
        {
            get { return this._GlobalSolarRadiation; }
            set { this._GlobalSolarRadiation= value; } 
        }
        public double DayLength
        {
            get { return this._DayLength; }
            set { this._DayLength= value; } 
        }
        public double AirTemperatureMinimum
        {
            get { return this._AirTemperatureMinimum; }
            set { this._AirTemperatureMinimum= value; } 
        }
        public double AirTemperatureMaximum
        {
            get { return this._AirTemperatureMaximum; }
            set { this._AirTemperatureMaximum= value; } 
        }
        public double AirTemperatureAnnualAverage
        {
            get { return this._AirTemperatureAnnualAverage; }
            set { this._AirTemperatureAnnualAverage= value; } 
        }
        public double HourOfSunrise
        {
            get { return this._HourOfSunrise; }
            set { this._HourOfSunrise= value; } 
        }
        public double HourOfSunset
        {
            get { return this._HourOfSunset; }
            set { this._HourOfSunset= value; } 
        }

        public string Description
        {
            get { return "SurfacePartonSoilSWATHourlyPartonCExogenous of the component";}
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
             _DayLength = default(double);
             _AirTemperatureMinimum = default(double);
             _AirTemperatureMaximum = default(double);
             _AirTemperatureAnnualAverage = default(double);
             _HourOfSunrise = default(double);
             _HourOfSunset = default(double);
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