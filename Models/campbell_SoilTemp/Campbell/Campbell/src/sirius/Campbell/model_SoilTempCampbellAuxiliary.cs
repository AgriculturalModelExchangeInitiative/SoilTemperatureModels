
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitymodel_SoilTempCampbell.DomainClass
                {
                    public class model_SoilTempCampbellAuxiliary : ICloneable, IDomainClass
                    {
                        private ParametersIO _parametersIO;

                        public model_SoilTempCampbellAuxiliary()
                        {
                            _parametersIO = new ParametersIO(this);
                        }

                        public model_SoilTempCampbellAuxiliary(model_SoilTempCampbellAuxiliary toCopy, bool copyAll) // copy constructor 
                        {
                            if (copyAll)
                            {
                                    }
                                }

                                public string Description
                                {
                                    get { return "model_SoilTempCampbellAuxiliary of the component";}
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