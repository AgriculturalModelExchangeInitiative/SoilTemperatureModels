using System;
using System.Collections.Generic;
using System.Linq;
using SQCrop2ML_SurfacePartonSoilSWATC.DomainClass;
using SQCrop2ML_SurfacePartonSoilSWATC.Strategies;

namespace SiriusModel.Model.SurfacePartonSoilSWATC
{
    class SurfacePartonSoilSWATCWrapper :  UniverseLink
    {
        private SurfacePartonSoilSWATCState s;
        private SurfacePartonSoilSWATCState s1;
        private SurfacePartonSoilSWATCRate r;
        private SurfacePartonSoilSWATCAuxiliary a;
        private SurfacePartonSoilSWATCExogenous ex;
        private SurfacePartonSoilSWATCComponent surfacepartonsoilswatcComponent;

        public SurfacePartonSoilSWATCWrapper(Universe universe) : base(universe)
        {
            s = new SurfacePartonSoilSWATCState();
            r = new SurfacePartonSoilSWATCRate();
            a = new SurfacePartonSoilSWATCAuxiliary();
            ex = new SurfacePartonSoilSWATCExogenous();
            surfacepartonsoilswatcComponent = new SurfacePartonSoilSWATC();
            loadParameters();
        }

        public double[] SoilTemperatureByLayers{ get { return s.SoilTemperatureByLayers;}} 
     
        public double SurfaceTemperatureMinimum{ get { return a.SurfaceTemperatureMinimum;}} 
     
        public double SurfaceTemperatureMaximum{ get { return a.SurfaceTemperatureMaximum;}} 
     
        public double SurfaceSoilTemperature{ get { return a.SurfaceSoilTemperature;}} 
     

        public SurfacePartonSoilSWATCWrapper(Universe universe, SurfacePartonSoilSWATCWrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new SurfacePartonSoilSWATCState(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new SurfacePartonSoilSWATCRate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new SurfacePartonSoilSWATCAuxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new SurfacePartonSoilSWATCExogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                surfacepartonsoilswatcComponent = (toCopy.surfacepartonsoilswatcComponent != null) ? new SurfacePartonSoilSWATC(toCopy.surfacepartonsoilswatcComponent) : null;
            }
        }

        public void Init(){
            surfacepartonsoilswatcComponent.Init(s, r, a);
            loadParameters();
        }

        private void loadParameters()
        {
            surfacepartonsoilswatcComponent.BulkDensity = BulkDensity;
            surfacepartonsoilswatcComponent.AirTemperatureAnnualAverage = AirTemperatureAnnualAverage;
            surfacepartonsoilswatcComponent.LagCoefficient = LagCoefficient;
            surfacepartonsoilswatcComponent.LayerThickness = LayerThickness;
            surfacepartonsoilswatcComponent.SoilProfileDepth = SoilProfileDepth;
        }

        public void EstimateSurfacePartonSoilSWATC(double[] VolumetricWaterContent, double AboveGroundBiomass, double DayLength, double AirTemperatureMinimum, double GlobalSolarRadiation, double AirTemperatureMaximum)
        {
            a.VolumetricWaterContent = VolumetricWaterContent;
            a.AboveGroundBiomass = AboveGroundBiomass;
            a.DayLength = DayLength;
            a.AirTemperatureMinimum = AirTemperatureMinimum;
            a.GlobalSolarRadiation = GlobalSolarRadiation;
            a.AirTemperatureMaximum = AirTemperatureMaximum;
            surfacepartonsoilswatcComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}