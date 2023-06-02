
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySTEMP_EPIC_.DomainClass
{
    public class STEMP_EPIC_Exogenous : ICloneable, IDomainClass
    {
        private double _RAIN;
        private double _DEPIR;
        private double _TMIN;
        private double _BIOMAS;
        private double _TAMP;
        private double _MULCHMASS;
        private double _TMAX;
        private double _TAV;
        private double _SNOW;
        private double _TAVG;
        private ParametersIO _parametersIO;

        public STEMP_EPIC_Exogenous()
        {
            _parametersIO = new ParametersIO(this);
        }

        public STEMP_EPIC_Exogenous(STEMP_EPIC_Exogenous toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                RAIN = toCopy.RAIN;
                DEPIR = toCopy.DEPIR;
                TMIN = toCopy.TMIN;
                BIOMAS = toCopy.BIOMAS;
                TAMP = toCopy.TAMP;
                MULCHMASS = toCopy.MULCHMASS;
                TMAX = toCopy.TMAX;
                TAV = toCopy.TAV;
                SNOW = toCopy.SNOW;
                TAVG = toCopy.TAVG;
            }
        }

        public double RAIN
        {
            get { return this._RAIN; }
            set { this._RAIN= value; } 
        }
        public double DEPIR
        {
            get { return this._DEPIR; }
            set { this._DEPIR= value; } 
        }
        public double TMIN
        {
            get { return this._TMIN; }
            set { this._TMIN= value; } 
        }
        public double BIOMAS
        {
            get { return this._BIOMAS; }
            set { this._BIOMAS= value; } 
        }
        public double TAMP
        {
            get { return this._TAMP; }
            set { this._TAMP= value; } 
        }
        public double MULCHMASS
        {
            get { return this._MULCHMASS; }
            set { this._MULCHMASS= value; } 
        }
        public double TMAX
        {
            get { return this._TMAX; }
            set { this._TMAX= value; } 
        }
        public double TAV
        {
            get { return this._TAV; }
            set { this._TAV= value; } 
        }
        public double SNOW
        {
            get { return this._SNOW; }
            set { this._SNOW= value; } 
        }
        public double TAVG
        {
            get { return this._TAVG; }
            set { this._TAVG= value; } 
        }

        public string Description
        {
            get { return "STEMP_EPIC_Exogenous of the component";}
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
             _RAIN = default(double);
             _DEPIR = default(double);
             _TMIN = default(double);
             _BIOMAS = default(double);
             _TAMP = default(double);
             _MULCHMASS = default(double);
             _TMAX = default(double);
             _TAV = default(double);
             _SNOW = default(double);
             _TAVG = default(double);
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