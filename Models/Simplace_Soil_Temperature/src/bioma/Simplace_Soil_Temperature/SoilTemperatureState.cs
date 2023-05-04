
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SoilTemperature.DomainClass
{
    public class SoilTemperatureState : ICloneable, IDomainClass
    {
        private double _Albedo;
        private double _SnowWaterContent;
        private double _SoilSurfaceTemperature;
        private int _AgeOfSnow;
        private double[] _rSoilTempArrayRate;
        private double[] _pSoilLayerDepth;
        private double[] _SoilTempArray;
        private ParametersIO _parametersIO;

        public SoilTemperatureState()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SoilTemperatureState(SoilTemperatureState toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                Albedo = toCopy.Albedo;
                SnowWaterContent = toCopy.SnowWaterContent;
                SoilSurfaceTemperature = toCopy.SoilSurfaceTemperature;
                AgeOfSnow = toCopy.AgeOfSnow;
                rSoilTempArrayRate = new double[toCopy.rSoilTempArrayRate.Length];
            for (int i = 0; i < toCopy.rSoilTempArrayRate.Length; i++)
            { rSoilTempArrayRate[i] = toCopy.rSoilTempArrayRate[i]; }
    
                pSoilLayerDepth = new double[toCopy.pSoilLayerDepth.Length];
            for (int i = 0; i < toCopy.pSoilLayerDepth.Length; i++)
            { pSoilLayerDepth[i] = toCopy.pSoilLayerDepth[i]; }
    
                SoilTempArray = new double[toCopy.SoilTempArray.Length];
            for (int i = 0; i < toCopy.SoilTempArray.Length; i++)
            { SoilTempArray[i] = toCopy.SoilTempArray[i]; }
    
            }
        }

        public double Albedo
        {
            get { return this._Albedo; }
            set { this._Albedo= value; } 
        }
        public double SnowWaterContent
        {
            get { return this._SnowWaterContent; }
            set { this._SnowWaterContent= value; } 
        }
        public double SoilSurfaceTemperature
        {
            get { return this._SoilSurfaceTemperature; }
            set { this._SoilSurfaceTemperature= value; } 
        }
        public int AgeOfSnow
        {
            get { return this._AgeOfSnow; }
            set { this._AgeOfSnow= value; } 
        }
        public double[] rSoilTempArrayRate
        {
            get { return this._rSoilTempArrayRate; }
            set { this._rSoilTempArrayRate= value; } 
        }
        public double[] pSoilLayerDepth
        {
            get { return this._pSoilLayerDepth; }
            set { this._pSoilLayerDepth= value; } 
        }
        public double[] SoilTempArray
        {
            get { return this._SoilTempArray; }
            set { this._SoilTempArray= value; } 
        }

        public string Description
        {
            get { return "SoilTemperatureState of the component";}
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
             _SnowWaterContent = default(double);
             _SoilSurfaceTemperature = default(double);
             _AgeOfSnow = default(int);
             _rSoilTempArrayRate = default(double[]);
             _pSoilLayerDepth = default(double[]);
             _SoilTempArray = default(double[]);
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