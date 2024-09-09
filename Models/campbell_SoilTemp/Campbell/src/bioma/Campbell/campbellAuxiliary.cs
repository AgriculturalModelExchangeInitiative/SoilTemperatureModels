
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace campbell.DomainClass
                {
                    public class campbellAuxiliary : ICloneable, IDomainClass
                    {
                        private double[] _minSoilTemp;
                        private ParametersIO _parametersIO;

                        public campbellAuxiliary()
                        {
                            _parametersIO = new ParametersIO(this);
                        }

                        public campbellAuxiliary(campbellAuxiliary toCopy, bool copyAll) // copy constructor 
                        {
                            if (copyAll)
                            {
                                        minSoilTemp = new double[toCopy.minSoilTemp.Length];
            for (int i = 0; i < toCopy.minSoilTemp.Length; i++)
                { minSoilTemp[i] = toCopy.minSoilTemp[i]; }
    
                                    }
                                }

                                public double[] minSoilTemp
    {
        get { return this._minSoilTemp; }
        set { this._minSoilTemp= value; } 
    }

                                public string Description
                                {
                                    get { return "campbellAuxiliary of the component";}
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
                                     _minSoilTemp = new double[NLAYR];
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