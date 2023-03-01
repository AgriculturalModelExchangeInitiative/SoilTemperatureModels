
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace STEMP_.DomainClass
{
    public class STEMP_Exogenous : ICloneable, IDomainClass
    {
        private double _TAVG;
        private double _TMAX;
        private double _TAV;
        private double _TAMP;
        private int _DOY;
        private double _SRAD;
        private ParametersIO _parametersIO;

        public STEMP_Exogenous()
        {
            _parametersIO = new ParametersIO(this);
        }

        public STEMP_Exogenous(STEMP_Exogenous toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                _TAVG = toCopy._TAVG;
                _TMAX = toCopy._TMAX;
                _TAV = toCopy._TAV;
                _TAMP = toCopy._TAMP;
                _DOY = toCopy._DOY;
                _SRAD = toCopy._SRAD;
            }
        }

        public double TAVG
        {
            get { return this._TAVG; }
            set { this._TAVG= value; } 
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
        public double TAMP
        {
            get { return this._TAMP; }
            set { this._TAMP= value; } 
        }
        public int DOY
        {
            get { return this._DOY; }
            set { this._DOY= value; } 
        }
        public double SRAD
        {
            get { return this._SRAD; }
            set { this._SRAD= value; } 
        }

        public string Description
        {
            get { return "STEMP_Exogenous of the component";}
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
             _TAVG = default(double);
             _TMAX = default(double);
             _TAV = default(double);
             _TAMP = default(double);
             _DOY = default(int);
             _SRAD = default(double);
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