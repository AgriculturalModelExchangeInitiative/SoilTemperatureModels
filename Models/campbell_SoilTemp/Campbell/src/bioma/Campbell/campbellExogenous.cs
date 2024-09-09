
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace campbell.DomainClass
                        {
                            public class campbellExogenous : ICloneable, IDomainClass
                            {
                                private double _SRAD;
                                private double _TMIN;
                                private int _DOY;
                                private double[] _SW;
                                private double _EOAD;
                                private double _ESP;
                                private double _TAV;
                                private double _ESAD;
                                private double _canopyHeight;
                                private double _TMAX;
                                private double _ES;
                                private ParametersIO _parametersIO;

                                public campbellExogenous()
                                {
                                    _parametersIO = new ParametersIO(this);
                                }

                                public campbellExogenous(campbellExogenous toCopy, bool copyAll) // copy constructor 
                                {
                                    if (copyAll)
                                    {
                                                SRAD = toCopy.SRAD;
                                                TMIN = toCopy.TMIN;
                                                DOY = toCopy.DOY;
                                                SW = new double[toCopy.SW.Length];
            for (int i = 0; i < toCopy.SW.Length; i++)
                { SW[i] = toCopy.SW[i]; }
    
                                                EOAD = toCopy.EOAD;
                                                ESP = toCopy.ESP;
                                                TAV = toCopy.TAV;
                                                ESAD = toCopy.ESAD;
                                                canopyHeight = toCopy.canopyHeight;
                                                TMAX = toCopy.TMAX;
                                                ES = toCopy.ES;
                                            }
                                        }

                                        public double SRAD
    {
        get { return this._SRAD; }
        set { this._SRAD= value; } 
    }
                                        public double TMIN
    {
        get { return this._TMIN; }
        set { this._TMIN= value; } 
    }
                                        public int DOY
    {
        get { return this._DOY; }
        set { this._DOY= value; } 
    }
                                        public double[] SW
    {
        get { return this._SW; }
        set { this._SW= value; } 
    }
                                        public double EOAD
    {
        get { return this._EOAD; }
        set { this._EOAD= value; } 
    }
                                        public double ESP
    {
        get { return this._ESP; }
        set { this._ESP= value; } 
    }
                                        public double TAV
    {
        get { return this._TAV; }
        set { this._TAV= value; } 
    }
                                        public double ESAD
    {
        get { return this._ESAD; }
        set { this._ESAD= value; } 
    }
                                        public double canopyHeight
    {
        get { return this._canopyHeight; }
        set { this._canopyHeight= value; } 
    }
                                        public double TMAX
    {
        get { return this._TMAX; }
        set { this._TMAX= value; } 
    }
                                        public double ES
    {
        get { return this._ES; }
        set { this._ES= value; } 
    }

                                        public string Description
                                        {
                                            get { return "campbellExogenous of the component";}
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
                                             _SRAD = default(double);
                                             _TMIN = default(double);
                                             _DOY = default(int);
                                             _SW = new double[NLAYR];
                                             _EOAD = default(double);
                                             _ESP = default(double);
                                             _TAV = default(double);
                                             _ESAD = default(double);
                                             _canopyHeight = default(double);
                                             _TMAX = default(double);
                                             _ES = default(double);
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