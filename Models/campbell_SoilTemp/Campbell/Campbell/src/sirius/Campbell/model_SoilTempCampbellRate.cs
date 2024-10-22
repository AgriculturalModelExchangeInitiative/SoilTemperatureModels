
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitymodel_SoilTempCampbell.DomainClass
        {
            public class model_SoilTempCampbellRate : ICloneable, IDomainClass
            {
                private ParametersIO _parametersIO;

                public model_SoilTempCampbellRate()
                {
                    _parametersIO = new ParametersIO(this);
                }

                public model_SoilTempCampbellRate(model_SoilTempCampbellRate toCopy, bool copyAll) // copy constructor 
                {
                    if (copyAll)
                    {
                            }
                        }

                        public string Description
                        {
                            get { return "model_SoilTempCampbellRate of the component";}
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