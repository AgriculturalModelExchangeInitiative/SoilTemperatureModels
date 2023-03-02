
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SiriusQualitySoilTemperature.DomainClass
{
    public class SoilTemperatureRate
    {
        public SoilTemperatureRate(SoilTemperatureRate toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
            }
        }

        public virtual Boolean ClearValues()
        {
            return true;
        }

    }
}