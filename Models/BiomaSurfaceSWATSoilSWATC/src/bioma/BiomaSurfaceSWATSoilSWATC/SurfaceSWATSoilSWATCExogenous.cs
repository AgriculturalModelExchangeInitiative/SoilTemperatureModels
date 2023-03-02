
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfaceSWATSoilSWATC.DomainClass
{
    public class SurfaceSWATSoilSWATCExogenous : ICloneable, IDomainClass
    {
        private double _AirTemperatureMinimum;
        private double _GlobalSolarRadiation;
        private double _WaterEquivalentOfSnowPack;
        private double _AirTemperatureMaximum;
        private double _Albedo;
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
                _AirTemperatureMinimum = toCopy._AirTemperatureMinimum;
                _GlobalSolarRadiation = toCopy._GlobalSolarRadiation;
                _WaterEquivalentOfSnowPack = toCopy._WaterEquivalentOfSnowPack;
                _AirTemperatureMaximum = toCopy._AirTemperatureMaximum;
                _Albedo = toCopy._Albedo;
                _AirTemperatureAnnualAverage = toCopy._AirTemperatureAnnualAverage;
            }
        }

        public double AirTemperatureMinimum
        {
            get { return this._AirTemperatureMinimum; }
            set { this._AirTemperatureMinimum= value; } 
        }
        public double GlobalSolarRadiation
        {
            get { return this._GlobalSolarRadiation; }
            set { this._GlobalSolarRadiation= value; } 
        }
        public double WaterEquivalentOfSnowPack
        {
            get { return this._WaterEquivalentOfSnowPack; }
            set { this._WaterEquivalentOfSnowPack= value; } 
        }
        public double AirTemperatureMaximum
        {
            get { return this._AirTemperatureMaximum; }
            set { this._AirTemperatureMaximum= value; } 
        }
        public double Albedo
        {
            get { return this._Albedo; }
            set { this._Albedo= value; } 
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
             _AirTemperatureMinimum = default(double);
             _GlobalSolarRadiation = default(double);
             _WaterEquivalentOfSnowPack = default(double);
             _AirTemperatureMaximum = default(double);
             _Albedo = default(double);
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