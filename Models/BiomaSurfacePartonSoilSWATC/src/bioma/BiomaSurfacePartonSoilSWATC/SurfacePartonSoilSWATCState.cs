
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfacePartonSoilSWATC.DomainClass
{
    public class SurfacePartonSoilSWATCState : ICloneable, IDomainClass
    {
        private double _AboveGroundBiomass;
        private double[] _LayerThickness;
        private double[] _VolumetricWaterContent;
        private double _SoilProfileDepth;
        private double[] _BulkDensity;
        private double _SurfaceSoilTemperature;
        private double[] _SoilTemperatureByLayers;
        private ParametersIO _parametersIO;

        public SurfacePartonSoilSWATCState()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SurfacePartonSoilSWATCState(SurfacePartonSoilSWATCState toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                _AboveGroundBiomass = toCopy._AboveGroundBiomass;
                LayerThickness = new double[toCopy._LayerThickness.Length];
            for (int i = 0; i < toCopy._LayerThickness.Length; i++)
            { _LayerThickness[i] = toCopy._LayerThickness[i]; }
    
                VolumetricWaterContent = new double[toCopy._VolumetricWaterContent.Length];
            for (int i = 0; i < toCopy._VolumetricWaterContent.Length; i++)
            { _VolumetricWaterContent[i] = toCopy._VolumetricWaterContent[i]; }
    
                _SoilProfileDepth = toCopy._SoilProfileDepth;
                BulkDensity = new double[toCopy._BulkDensity.Length];
            for (int i = 0; i < toCopy._BulkDensity.Length; i++)
            { _BulkDensity[i] = toCopy._BulkDensity[i]; }
    
                _SurfaceSoilTemperature = toCopy._SurfaceSoilTemperature;
                SoilTemperatureByLayers = new double[toCopy._SoilTemperatureByLayers.Length];
            for (int i = 0; i < toCopy._SoilTemperatureByLayers.Length; i++)
            { _SoilTemperatureByLayers[i] = toCopy._SoilTemperatureByLayers[i]; }
    
            }
        }

        public double AboveGroundBiomass
        {
            get { return this._AboveGroundBiomass; }
            set { this._AboveGroundBiomass= value; } 
        }
        public double[] LayerThickness
        {
            get { return this._LayerThickness; }
            set { this._LayerThickness= value; } 
        }
        public double[] VolumetricWaterContent
        {
            get { return this._VolumetricWaterContent; }
            set { this._VolumetricWaterContent= value; } 
        }
        public double SoilProfileDepth
        {
            get { return this._SoilProfileDepth; }
            set { this._SoilProfileDepth= value; } 
        }
        public double[] BulkDensity
        {
            get { return this._BulkDensity; }
            set { this._BulkDensity= value; } 
        }
        public double SurfaceSoilTemperature
        {
            get { return this._SurfaceSoilTemperature; }
            set { this._SurfaceSoilTemperature= value; } 
        }
        public double[] SoilTemperatureByLayers
        {
            get { return this._SoilTemperatureByLayers; }
            set { this._SoilTemperatureByLayers= value; } 
        }

        public string Description
        {
            get { return "SurfacePartonSoilSWATCState of the component";}
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
             _LayerThickness = new double[];
             _VolumetricWaterContent = new double[];
             _SoilProfileDepth = default(double);
             _BulkDensity = new double[];
             _SurfaceSoilTemperature = default(double);
             _SoilTemperatureByLayers = new double[];
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