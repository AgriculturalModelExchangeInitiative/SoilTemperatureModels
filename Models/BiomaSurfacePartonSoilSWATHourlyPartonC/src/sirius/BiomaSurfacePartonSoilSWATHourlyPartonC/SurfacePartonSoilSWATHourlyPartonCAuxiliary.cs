
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass
{
    public class SurfacePartonSoilSWATHourlyPartonCAuxiliary : ICloneable, IDomainClass
    {
        private double _AboveGroundBiomass;
        private double[] _VolumetricWaterContent;
        private double[] _OrganicMatter;
        private double[] _Sand;
        private double _SurfaceSoilTemperature;
        private double _SurfaceTemperatureMinimum;
        private double _SurfaceTemperatureMaximum;
        private double[] _ThermalConductivity;
        private double[] _SoilTemperatureRangeByLayers;
        private double[] _SoilTemperatureMinimum;
        private double[] _SoilTemperatureMaximum;
        private ParametersIO _parametersIO;

        public SurfacePartonSoilSWATHourlyPartonCAuxiliary()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SurfacePartonSoilSWATHourlyPartonCAuxiliary(SurfacePartonSoilSWATHourlyPartonCAuxiliary toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                AboveGroundBiomass = toCopy.AboveGroundBiomass;
                VolumetricWaterContent = new double[toCopy.VolumetricWaterContent.Length];
            for (int i = 0; i < toCopy.VolumetricWaterContent.Length; i++)
            { VolumetricWaterContent[i] = toCopy.VolumetricWaterContent[i]; }
    
                OrganicMatter = new double[toCopy.OrganicMatter.Length];
            for (int i = 0; i < toCopy.OrganicMatter.Length; i++)
            { OrganicMatter[i] = toCopy.OrganicMatter[i]; }
    
                Sand = new double[toCopy.Sand.Length];
            for (int i = 0; i < toCopy.Sand.Length; i++)
            { Sand[i] = toCopy.Sand[i]; }
    
                SurfaceSoilTemperature = toCopy.SurfaceSoilTemperature;
                SurfaceTemperatureMinimum = toCopy.SurfaceTemperatureMinimum;
                SurfaceTemperatureMaximum = toCopy.SurfaceTemperatureMaximum;
                ThermalConductivity = new double[toCopy.ThermalConductivity.Length];
            for (int i = 0; i < toCopy.ThermalConductivity.Length; i++)
            { ThermalConductivity[i] = toCopy.ThermalConductivity[i]; }
    
                SoilTemperatureRangeByLayers = new double[toCopy.SoilTemperatureRangeByLayers.Length];
            for (int i = 0; i < toCopy.SoilTemperatureRangeByLayers.Length; i++)
            { SoilTemperatureRangeByLayers[i] = toCopy.SoilTemperatureRangeByLayers[i]; }
    
                SoilTemperatureMinimum = new double[toCopy.SoilTemperatureMinimum.Length];
            for (int i = 0; i < toCopy.SoilTemperatureMinimum.Length; i++)
            { SoilTemperatureMinimum[i] = toCopy.SoilTemperatureMinimum[i]; }
    
                SoilTemperatureMaximum = new double[toCopy.SoilTemperatureMaximum.Length];
            for (int i = 0; i < toCopy.SoilTemperatureMaximum.Length; i++)
            { SoilTemperatureMaximum[i] = toCopy.SoilTemperatureMaximum[i]; }
    
            }
        }

        public double AboveGroundBiomass
        {
            get { return this._AboveGroundBiomass; }
            set { this._AboveGroundBiomass= value; } 
        }
        public double[] VolumetricWaterContent
        {
            get { return this._VolumetricWaterContent; }
            set { this._VolumetricWaterContent= value; } 
        }
        public double[] OrganicMatter
        {
            get { return this._OrganicMatter; }
            set { this._OrganicMatter= value; } 
        }
        public double[] Sand
        {
            get { return this._Sand; }
            set { this._Sand= value; } 
        }
        public double SurfaceSoilTemperature
        {
            get { return this._SurfaceSoilTemperature; }
            set { this._SurfaceSoilTemperature= value; } 
        }
        public double SurfaceTemperatureMinimum
        {
            get { return this._SurfaceTemperatureMinimum; }
            set { this._SurfaceTemperatureMinimum= value; } 
        }
        public double SurfaceTemperatureMaximum
        {
            get { return this._SurfaceTemperatureMaximum; }
            set { this._SurfaceTemperatureMaximum= value; } 
        }
        public double[] ThermalConductivity
        {
            get { return this._ThermalConductivity; }
            set { this._ThermalConductivity= value; } 
        }
        public double[] SoilTemperatureRangeByLayers
        {
            get { return this._SoilTemperatureRangeByLayers; }
            set { this._SoilTemperatureRangeByLayers= value; } 
        }
        public double[] SoilTemperatureMinimum
        {
            get { return this._SoilTemperatureMinimum; }
            set { this._SoilTemperatureMinimum= value; } 
        }
        public double[] SoilTemperatureMaximum
        {
            get { return this._SoilTemperatureMaximum; }
            set { this._SoilTemperatureMaximum= value; } 
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
             _AboveGroundBiomass = default(double);
             _VolumetricWaterContent = new double[];
             _OrganicMatter = new double[];
             _Sand = new double[];
             _SurfaceSoilTemperature = default(double);
             _SurfaceTemperatureMinimum = default(double);
             _SurfaceTemperatureMaximum = default(double);
             _ThermalConductivity = new double[];
             _SoilTemperatureRangeByLayers = new double[];
             _SoilTemperatureMinimum = new double[];
             _SoilTemperatureMaximum = new double[];
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