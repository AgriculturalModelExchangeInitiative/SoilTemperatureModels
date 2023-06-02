
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySTEMP_EPIC_.DomainClass
{
    public class STEMP_EPIC_Rate : ICloneable, IDomainClass
    {
        private ParametersIO _parametersIO;

        public STEMP_EPIC_Rate()
        {
            _parametersIO = new ParametersIO(this);
        }

        public STEMP_EPIC_Rate(STEMP_EPIC_Rate toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
            }
        }

        public string Description
        {
            get { return "STEMP_EPIC_Rate of the component";}
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