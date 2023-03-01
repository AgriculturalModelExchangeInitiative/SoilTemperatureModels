using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_SurfacePartonSoilSWATC.DomainClass;
using Crop2ML_SurfacePartonSoilSWATC.Strategies;

namespace Model.Model.SurfacePartonSoilSWATC
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

        public double SurfaceSoilTemperature{ get { return s.SurfaceSoilTemperature;}} 
     
        public double[] SoilTemperatureByLayers{ get { return s.SoilTemperatureByLayers;}} 
     
        public double SurfaceTemperatureMaximum{ get { return a.SurfaceTemperatureMaximum;}} 
     
        public double SurfaceTemperatureMinimum{ get { return a.SurfaceTemperatureMinimum;}} 
     

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
            surfacepartonsoilswatcComponent.LagCoefficient = LagCoefficient;
        }

        public void EstimateSurfacePartonSoilSWATC(double GlobalSolarRadiation, double AirTemperatureMinimum, double DayLength, double AirTemperatureMaximum, double AirTemperatureAnnualAverage)
        {
            a.GlobalSolarRadiation = GlobalSolarRadiation;
            a.AirTemperatureMinimum = AirTemperatureMinimum;
            a.DayLength = DayLength;
            a.AirTemperatureMaximum = AirTemperatureMaximum;
            a.AirTemperatureAnnualAverage = AirTemperatureAnnualAverage;
            surfacepartonsoilswatcComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}