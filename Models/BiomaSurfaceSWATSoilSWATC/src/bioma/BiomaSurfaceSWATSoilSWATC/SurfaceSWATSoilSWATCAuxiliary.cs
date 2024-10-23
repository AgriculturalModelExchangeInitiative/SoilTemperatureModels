
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SurfaceSWATSoilSWATC.DomainClass
{
    public class SurfaceSWATSoilSWATCAuxiliary : ICloneable, IDomainClass
    {
        private double _AboveGroundBiomass;
        private double _SurfaceSoilTemperature;
        private ParametersIO _parametersIO;

        public SurfaceSWATSoilSWATCAuxiliary()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SurfaceSWATSoilSWATCAuxiliary(SurfaceSWATSoilSWATCAuxiliary toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                AboveGroundBiomass = toCopy.AboveGroundBiomass;
                SurfaceSoilTemperature = toCopy.SurfaceSoilTemperature;
            }
        }

        public double AboveGroundBiomass
        {
            get { return this._AboveGroundBiomass; }
            set { this._AboveGroundBiomass= value; } 
        }
        public double SurfaceSoilTemperature
        {
            get { return this._SurfaceSoilTemperature; }
            set { this._SurfaceSoilTemperature= value; } 
        }

        public string Description
        {
            get { return "SurfaceSWATSoilSWATCAuxiliary of the component";}
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
             _SurfaceSoilTemperature = default(double);
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