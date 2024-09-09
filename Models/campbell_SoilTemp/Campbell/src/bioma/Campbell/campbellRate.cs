
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace campbell.DomainClass
        {
            public class campbellRate : ICloneable, IDomainClass
            {
                private ParametersIO _parametersIO;

                public campbellRate()
                {
                    _parametersIO = new ParametersIO(this);
                }

                public campbellRate(campbellRate toCopy, bool copyAll) // copy constructor 
                {
                    if (copyAll)
                    {
                            }
                        }

                        public string Description
                        {
                            get { return "campbellRate of the component";}
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