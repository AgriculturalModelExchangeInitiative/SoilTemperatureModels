
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfaceSWATSoilSWATC.DomainClass
{
    public class SurfaceSWATSoilSWATCExogenous : ICloneable, IDomainClass
    {
        private double _AirTemperatureMaximum;
        private double _AirTemperatureMinimum;
        private double _GlobalSolarRadiation;
        private double _WaterEquivalentOfSnowPack;
        private double _Albedo;
        private double[] _VolumetricWaterContent;
        private ParametersIO _parametersIO;

        public SurfaceSWATSoilSWATCExogenous()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SurfaceSWATSoilSWATCExogenous(SurfaceSWATSoilSWATCExogenous toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                AirTemperatureMaximum = toCopy.AirTemperatureMaximum;
                AirTemperatureMinimum = toCopy.AirTemperatureMinimum;
                GlobalSolarRadiation = toCopy.GlobalSolarRadiation;
                WaterEquivalentOfSnowPack = toCopy.WaterEquivalentOfSnowPack;
                Albedo = toCopy.Albedo;
                VolumetricWaterContent = new double[toCopy.VolumetricWaterContent.Length];
            for (int i = 0; i < toCopy.VolumetricWaterContent.Length; i++)
            { VolumetricWaterContent[i] = toCopy.VolumetricWaterContent[i]; }
    
            }
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
        public double Albedo
        {
            get { return this._Albedo; }
            set { this._Albedo= value; } 
        }
        public double[] VolumetricWaterContent
        {
            get { return this._VolumetricWaterContent; }
            set { this._VolumetricWaterContent= value; } 
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
             _AirTemperatureMaximum = default(double);
             _AirTemperatureMinimum = default(double);
             _GlobalSolarRadiation = default(double);
             _WaterEquivalentOfSnowPack = default(double);
             _Albedo = default(double);
             _VolumetricWaterContent = default(double[]);
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