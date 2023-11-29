
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySurfaceSWATSoilSWATC.DomainClass
{
    public class SurfaceSWATSoilSWATCExogenous : ICloneable, IDomainClass
    {
        private double _Albedo;
        private double _AirTemperatureMinimum;
        private double _WaterEquivalentOfSnowPack;
        private double _GlobalSolarRadiation;
        private double _AirTemperatureMaximum;
        private ParametersIO _parametersIO;

        public SurfaceSWATSoilSWATCExogenous()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SurfaceSWATSoilSWATCExogenous(SurfaceSWATSoilSWATCExogenous toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                Albedo = toCopy.Albedo;
                AirTemperatureMinimum = toCopy.AirTemperatureMinimum;
                WaterEquivalentOfSnowPack = toCopy.WaterEquivalentOfSnowPack;
                GlobalSolarRadiation = toCopy.GlobalSolarRadiation;
                AirTemperatureMaximum = toCopy.AirTemperatureMaximum;
            }
        }

        public double Albedo
        {
            get { return this._Albedo; }
            set { this._Albedo= value; } 
        }
        public double AirTemperatureMinimum
        {
            get { return this._AirTemperatureMinimum; }
            set { this._AirTemperatureMinimum= value; } 
        }
        public double WaterEquivalentOfSnowPack
        {
            get { return this._WaterEquivalentOfSnowPack; }
            set { this._WaterEquivalentOfSnowPack= value; } 
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
             _Albedo = default(double);
             _AirTemperatureMinimum = default(double);
             _WaterEquivalentOfSnowPack = default(double);
             _GlobalSolarRadiation = default(double);
             _AirTemperatureMaximum = default(double);
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