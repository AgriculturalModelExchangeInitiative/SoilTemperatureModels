
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;     

using SiriusQualitySoilTemperature.DomainClass;
namespace SiriusQualitySoilTemperature.Strategies
{
    public class SoilTemperatureComponent 
    {
        public SoilTemperatureComponent()
        {
        }

        public double cCarbonContent
        {
            get
            {
                 return _SnowCoverCalculator.cCarbonContent; 
            }
            set
            {
                _SnowCoverCalculator.cCarbonContent = value;
            }
        }
        public double[] cSoilLayerDepth
        {
            get
            {
                 return _STMPsimCalculator.cSoilLayerDepth; 
            }
            set
            {
                _STMPsimCalculator.cSoilLayerDepth = value;
            }
        }
        public double cFirstDayMeanTemp
        {
            get
            {
                 return _STMPsimCalculator.cFirstDayMeanTemp; 
            }
            set
            {
                _STMPsimCalculator.cFirstDayMeanTemp = value;
            }
        }
        public double cAverageGroundTemperature
        {
            get
            {
                 return _STMPsimCalculator.cAverageGroundTemperature; 
            }
            set
            {
                _STMPsimCalculator.cAverageGroundTemperature = value;
            }
        }
        public double cAVT
        {
            get
            {
                 return _STMPsimCalculator.cAVT; 
            }
            set
            {
                _STMPsimCalculator.cAVT = value;
            }
        }
        public double cAverageBulkDensity
        {
            get
            {
                 return _STMPsimCalculator.cAverageBulkDensity; 
            }
            set
            {
                _STMPsimCalculator.cAverageBulkDensity = value;
            }
        }
        public double cABD
        {
            get
            {
                 return _STMPsimCalculator.cABD; 
            }
            set
            {
                _STMPsimCalculator.cABD = value;
            }
        }
        public double cDampingDepth
        {
            get
            {
                 return _STMPsimCalculator.cDampingDepth; 
            }
            set
            {
                _STMPsimCalculator.cDampingDepth = value;
            }
        }

        public void Estimate(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState s,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState s1,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureRate r,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureAuxiliary a,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualitySoilTemperature, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState s,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState s1,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureRate r,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureAuxiliary a,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        SnowCoverCalculator _SnowCoverCalculator = new SnowCoverCalculator();
        STMPsimCalculator _STMPsimCalculator = new STMPsimCalculator();

        private void EstimateOfAssociatedClasses(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState s,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState s1,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureRate r,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureAuxiliary a,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenous ex)
        {
            ex.iTempMax = ex.iAirTemperatureMax;
            ex.iTempMin = ex.iAirTemperatureMin;
            ex.iRadiation = ex.iGlobalSolarRadiation;
            ex.iSoilTempArray = s.SoilTempArray;
            cAVT = cAverageGroundTemperature;
            cABD = cAverageBulkDensity;
            _SnowCoverCalculator.Estimate(s,s1, r, a, ex);
            ex.iSoilSurfaceTemperature = s.SoilSurfaceTemperature;
            _STMPsimCalculator.Estimate(s,s1, r, a, ex);
        }

        public SoilTemperatureComponent(SoilTemperatureComponent toCopy): this() // copy constructor 
        {
                cCarbonContent = toCopy.cCarbonContent;
                
            for (int i = 0; i < toCopy._cSoilLayerDepth.Length; i++)
            { _cSoilLayerDepth[i] = toCopy._cSoilLayerDepth[i]; }
    
                cFirstDayMeanTemp = toCopy.cFirstDayMeanTemp;
                cAverageGroundTemperature = toCopy.cAverageGroundTemperature;
                cAVT = toCopy.cAVT;
                cAverageBulkDensity = toCopy.cAverageBulkDensity;
                cABD = toCopy.cABD;
                cDampingDepth = toCopy.cDampingDepth;
        }
    }
}