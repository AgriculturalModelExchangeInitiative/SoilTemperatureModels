
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace STEMP_.DomainClass
{
    public class STEMP_State : ICloneable, IDomainClass
    {
        private double _SRFTEMP;
        private double _HDAY;
        private double[] _TMA = new double[5];
        private double _CUMDPT;
        private double _ATOT;
        private double _TDL;
        private double[] _DSMID = new double[NL];
        private double[] _ST = new double[NL];
        private ParametersIO _parametersIO;

        public STEMP_State()
        {
            _parametersIO = new ParametersIO(this);
        }

        public STEMP_State(STEMP_State toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                SRFTEMP = toCopy.SRFTEMP;
                HDAY = toCopy.HDAY;
                TMA = new double[5];
            for (int i = 0; i < 5; i++)
            { TMA[i] = toCopy.TMA[i]; }
    
                CUMDPT = toCopy.CUMDPT;
                ATOT = toCopy.ATOT;
                TDL = toCopy.TDL;
                DSMID = new double[NL];
            for (int i = 0; i < NL; i++)
            { DSMID[i] = toCopy.DSMID[i]; }
    
                ST = new double[NL];
            for (int i = 0; i < NL; i++)
            { ST[i] = toCopy.ST[i]; }
    
            }
        }

        public double SRFTEMP
        {
            get { return this._SRFTEMP; }
            set { this._SRFTEMP= value; } 
        }
        public double HDAY
        {
            get { return this._HDAY; }
            set { this._HDAY= value; } 
        }
        public double[] TMA
        {
            get { return this._TMA; }
            set { this._TMA= value; } 
        }
        public double CUMDPT
        {
            get { return this._CUMDPT; }
            set { this._CUMDPT= value; } 
        }
        public double ATOT
        {
            get { return this._ATOT; }
            set { this._ATOT= value; } 
        }
        public double TDL
        {
            get { return this._TDL; }
            set { this._TDL= value; } 
        }
        public double[] DSMID
        {
            get { return this._DSMID; }
            set { this._DSMID= value; } 
        }
        public double[] ST
        {
            get { return this._ST; }
            set { this._ST= value; } 
        }

        public string Description
        {
            get { return "STEMP_State of the component";}
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
             _SRFTEMP = default(double);
             _HDAY = default(double);
             _TMA = new double[5];
             _CUMDPT = default(double);
             _ATOT = default(double);
             _TDL = default(double);
             _DSMID = new double[NL];
             _ST = new double[NL];
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