
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitysoil_temp.DomainClass
{
    public class soil_tempRate : ICloneable, IDomainClass
    {
        private ParametersIO _parametersIO;

        public soil_tempRate()
        {
            _parametersIO = new ParametersIO(this);
        }

        public soil_tempRate(soil_tempRate toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
            }
        }

        public string Description
        {
            get { return "soil_tempRate of the component";}
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