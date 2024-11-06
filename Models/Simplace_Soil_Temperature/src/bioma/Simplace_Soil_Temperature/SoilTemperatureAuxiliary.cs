
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SoilTemperature.DomainClass
                {
                    public class SoilTemperatureAuxiliary : ICloneable, IDomainClass
                    {
                        private double[] _SoilTempArray;
                        private double[] _iSoilTempArray;
                        private double _SnowIsolationIndex;
                        private double _iSoilSurfaceTemperature;
                        private ParametersIO _parametersIO;

                        public SoilTemperatureAuxiliary()
                        {
                            _parametersIO = new ParametersIO(this);
                        }

                        public SoilTemperatureAuxiliary(SoilTemperatureAuxiliary toCopy, bool copyAll) // copy constructor 
                        {
                            if (copyAll)
                            {
                                        SoilTempArray = new double[toCopy.SoilTempArray.Length];
            for (int i = 0; i < toCopy.SoilTempArray.Length; i++)
                { SoilTempArray[i] = toCopy.SoilTempArray[i]; }
    
                                        iSoilTempArray = new double[toCopy.iSoilTempArray.Length];
            for (int i = 0; i < toCopy.iSoilTempArray.Length; i++)
                { iSoilTempArray[i] = toCopy.iSoilTempArray[i]; }
    
                                        SnowIsolationIndex = toCopy.SnowIsolationIndex;
                                        iSoilSurfaceTemperature = toCopy.iSoilSurfaceTemperature;
                                    }
                                }

                                public double[] SoilTempArray
    {
        get { return this._SoilTempArray; }
        set { this._SoilTempArray= value; } 
    }
                                public double[] iSoilTempArray
    {
        get { return this._iSoilTempArray; }
        set { this._iSoilTempArray= value; } 
    }
                                public double SnowIsolationIndex
    {
        get { return this._SnowIsolationIndex; }
        set { this._SnowIsolationIndex= value; } 
    }
                                public double iSoilSurfaceTemperature
    {
        get { return this._iSoilSurfaceTemperature; }
        set { this._iSoilSurfaceTemperature= value; } 
    }

                                public string Description
                                {
                                    get { return "SoilTemperatureAuxiliary of the component";}
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
                                     _SoilTempArray = default(double[]);
                                     _iSoilTempArray = default(double[]);
                                     _SnowIsolationIndex = default(double);
                                     _iSoilSurfaceTemperature = default(double);
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