
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace STEMP_EPIC_.DomainClass
{
    public class STEMP_EPIC_State : ICloneable, IDomainClass
    {
        private int _NDays;
        private int[] _WetDay = new int[30];
        private double _TDL;
        private double _X2_PREV;
        private double[] _DSMID = new double[NL];
        private double[] _TMA = new double[5];
        private double _SRFTEMP;
        private double[] _ST = new double[NL];
        private double _CUMDPT;
        private ParametersIO _parametersIO;

        public STEMP_EPIC_State()
        {
            _parametersIO = new ParametersIO(this);
        }

        public STEMP_EPIC_State(STEMP_EPIC_State toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                NDays = toCopy.NDays;
                WetDay = new int[30];
            for (int i = 0; i < 30; i++)
            { WetDay[i] = toCopy.WetDay[i]; }
    
                TDL = toCopy.TDL;
                X2_PREV = toCopy.X2_PREV;
                DSMID = new double[NL];
            for (int i = 0; i < NL; i++)
            { DSMID[i] = toCopy.DSMID[i]; }
    
                TMA = new double[5];
            for (int i = 0; i < 5; i++)
            { TMA[i] = toCopy.TMA[i]; }
    
                SRFTEMP = toCopy.SRFTEMP;
                ST = new double[NL];
            for (int i = 0; i < NL; i++)
            { ST[i] = toCopy.ST[i]; }
    
                CUMDPT = toCopy.CUMDPT;
            }
        }

        public int NDays
        {
            get { return this._NDays; }
            set { this._NDays= value; } 
        }
        public int[] WetDay
        {
            get { return this._WetDay; }
            set { this._WetDay= value; } 
        }
        public double TDL
        {
            get { return this._TDL; }
            set { this._TDL= value; } 
        }
        public double X2_PREV
        {
            get { return this._X2_PREV; }
            set { this._X2_PREV= value; } 
        }
        public double[] DSMID
        {
            get { return this._DSMID; }
            set { this._DSMID= value; } 
        }
        public double[] TMA
        {
            get { return this._TMA; }
            set { this._TMA= value; } 
        }
        public double SRFTEMP
        {
            get { return this._SRFTEMP; }
            set { this._SRFTEMP= value; } 
        }
        public double[] ST
        {
            get { return this._ST; }
            set { this._ST= value; } 
        }
        public double CUMDPT
        {
            get { return this._CUMDPT; }
            set { this._CUMDPT= value; } 
        }

        public string Description
        {
            get { return "STEMP_EPIC_State of the component";}
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
             _NDays = default(int);
             _WetDay = new int[30];
             _TDL = default(double);
             _X2_PREV = default(double);
             _DSMID = new double[NL];
             _TMA = new double[5];
             _SRFTEMP = default(double);
             _ST = new double[NL];
             _CUMDPT = default(double);
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