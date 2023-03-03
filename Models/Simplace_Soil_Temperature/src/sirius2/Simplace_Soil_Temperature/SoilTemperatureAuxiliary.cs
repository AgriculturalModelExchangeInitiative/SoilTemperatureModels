
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SiriusQualitySoilTemperature.DomainClass
{
    public class SoilTemperatureAuxiliary
    {
        private double _SnowIsolationIndex;
        public SoilTemperatureAuxiliary(SoilTemperatureAuxiliary toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                _SnowIsolationIndex = toCopy._SnowIsolationIndex;
            }
        }

        public double SnowIsolationIndex
        {
            get { return this._SnowIsolationIndex; }
            set { this._SnowIsolationIndex= value; } 
        }

        public virtual Boolean ClearValues()
        {
             _SnowIsolationIndex = default(double);
            return true;
        }

    }
}