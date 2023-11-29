
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfacePartonSoilSWATHourlyPartonC.DomainClass
{
    public class SurfacePartonSoilSWATHourlyPartonCExogenous : ICloneable, IDomainClass
    {
        private double _AirTemperatureMaximum;
        private double _GlobalSolarRadiation;
        private double _AirTemperatureMinimum;
        private double _DayLength;
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
                AirTemperatureMaximum = toCopy.AirTemperatureMaximum;
                GlobalSolarRadiation = toCopy.GlobalSolarRadiation;
                AirTemperatureMinimum = toCopy.AirTemperatureMinimum;
                DayLength = toCopy.DayLength;
                HourOfSunrise = toCopy.HourOfSunrise;
                HourOfSunset = toCopy.HourOfSunset;
            }
        }

        public double AirTemperatureMaximum
        {
            get { return this._AirTemperatureMaximum; }
            set { this._AirTemperatureMaximum= value; } 
        }
        public double GlobalSolarRadiation
        {
            get { return this._GlobalSolarRadiation; }
            set { this._GlobalSolarRadiation= value; } 
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
             _AirTemperatureMaximum = default(double);
             _GlobalSolarRadiation = default(double);
             _AirTemperatureMinimum = default(double);
             _DayLength = default(double);
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