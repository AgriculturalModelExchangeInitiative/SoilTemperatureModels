
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfaceSWATSoilSWATC.DomainClass
{
    public class SurfaceSWATSoilSWATCExogenous : ICloneable, IDomainClass
    {
        private double _GlobalSolarRadiation;
        private double _AirTemperatureMaximum;
        private double _AirTemperatureMinimum;
        private double _Albedo;
        private double _WaterEquivalentOfSnowPack;
        private double _AirTemperatureAnnualAverage;
        private ParametersIO _parametersIO;

        public SurfaceSWATSoilSWATCExogenous()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SurfaceSWATSoilSWATCExogenous(SurfaceSWATSoilSWATCExogenous toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                _GlobalSolarRadiation = toCopy._GlobalSolarRadiation;
                _AirTemperatureMaximum = toCopy._AirTemperatureMaximum;
                _AirTemperatureMinimum = toCopy._AirTemperatureMinimum;
                _Albedo = toCopy._Albedo;
                _WaterEquivalentOfSnowPack = toCopy._WaterEquivalentOfSnowPack;
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
        public double Albedo
        {
            get { return this._Albedo; }
            set { this._Albedo= value; } 
        }
        public double WaterEquivalentOfSnowPack
        {
            get { return this._WaterEquivalentOfSnowPack; }
            set { this._WaterEquivalentOfSnowPack= value; } 
        }
        public double AirTemperatureAnnualAverage
        {
            get { return this._AirTemperatureAnnualAverage; }
            set { this._AirTemperatureAnnualAverage= value; } 
        }

        public string Description
        {
            get { return "SurfaceSWATSoilSWATCExogenous of the component";}
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
             _Albedo = default(double);
             _WaterEquivalentOfSnowPack = default(double);
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