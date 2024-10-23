
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySurfaceSWATSoilSWATC.DomainClass
{
    public class SurfaceSWATSoilSWATCState : ICloneable, IDomainClass
    {
        private double[] _SoilTemperatureByLayers;
        private ParametersIO _parametersIO;

        public SurfaceSWATSoilSWATCState()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SurfaceSWATSoilSWATCState(SurfaceSWATSoilSWATCState toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                SoilTemperatureByLayers = new double[toCopy.SoilTemperatureByLayers.Length];
            for (int i = 0; i < toCopy.SoilTemperatureByLayers.Length; i++)
            { SoilTemperatureByLayers[i] = toCopy.SoilTemperatureByLayers[i]; }
    
            }
        }

        public double[] SoilTemperatureByLayers
        {
            get { return this._SoilTemperatureByLayers; }
            set { this._SoilTemperatureByLayers= value; } 
        }

        public string Description
        {
            get { return "SurfaceSWATSoilSWATCState of the component";}
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