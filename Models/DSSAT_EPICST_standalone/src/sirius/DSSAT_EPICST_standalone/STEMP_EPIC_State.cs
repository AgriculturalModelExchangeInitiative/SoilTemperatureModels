
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySTEMP_EPIC_.DomainClass
{
    public class STEMP_EPIC_State : ICloneable, IDomainClass
    {
        private double[] _TMA = new double[5];
        private double _CUMDPT;
        private double[] _ST = new double[NL];
        private double[] _DSMID = new double[NL];
        private double _SRFTEMP;
        private int _NDays;
        private double _X2_PREV;
        private int[] _WetDay = new int[30];
        private ParametersIO _parametersIO;

        public STEMP_EPIC_State()
        {
            _parametersIO = new ParametersIO(this);
        }

        public STEMP_EPIC_State(STEMP_EPIC_State toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                TMA = new double[5];
            for (int i = 0; i < 5; i++)
            { _TMA[i] = toCopy._TMA[i]; }
    
                _CUMDPT = toCopy._CUMDPT;
                ST = new double[NL];
            for (int i = 0; i < NL; i++)
            { _ST[i] = toCopy._ST[i]; }
    
                DSMID = new double[NL];
            for (int i = 0; i < NL; i++)
            { _DSMID[i] = toCopy._DSMID[i]; }
    
                _SRFTEMP = toCopy._SRFTEMP;
                _NDays = toCopy._NDays;
                _X2_PREV = toCopy._X2_PREV;
                WetDay = new int[30];
            for (int i = 0; i < 30; i++)
            { _WetDay[i] = toCopy._WetDay[i]; }
    
            }
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
        public double[] ST
        {
            get { return this._ST; }
            set { this._ST= value; } 
        }
        public double[] DSMID
        {
            get { return this._DSMID; }
            set { this._DSMID= value; } 
        }
        public double SRFTEMP
        {
            get { return this._SRFTEMP; }
            set { this._SRFTEMP= value; } 
        }
        public int NDays
        {
            get { return this._NDays; }
            set { this._NDays= value; } 
        }
        public double X2_PREV
        {
            get { return this._X2_PREV; }
            set { this._X2_PREV= value; } 
        }
        public int[] WetDay
        {
            get { return this._WetDay; }
            set { this._WetDay= value; } 
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
             _TMA = new double[5];
             _CUMDPT = default(double);
             _ST = new double[NL];
             _DSMID = new double[NL];
             _SRFTEMP = default(double);
             _NDays = default(int);
             _X2_PREV = default(double);
             _WetDay = new int[30];
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