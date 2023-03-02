using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_SurfaceSWATSoilSWATC.DomainClass;
using Crop2ML_SurfaceSWATSoilSWATC.Strategies;

namespace Model.Model.SurfaceSWATSoilSWATC
{
    class SurfaceSWATSoilSWATCWrapper :  UniverseLink
    {
        private SurfaceSWATSoilSWATCState s;
        private SurfaceSWATSoilSWATCState s1;
        private SurfaceSWATSoilSWATCRate r;
        private SurfaceSWATSoilSWATCAuxiliary a;
        private SurfaceSWATSoilSWATCExogenous ex;
        private SurfaceSWATSoilSWATCComponent surfaceswatsoilswatcComponent;

        public SurfaceSWATSoilSWATCWrapper(Universe universe) : base(universe)
        {
            s = new SurfaceSWATSoilSWATCState();
            r = new SurfaceSWATSoilSWATCRate();
            a = new SurfaceSWATSoilSWATCAuxiliary();
            ex = new SurfaceSWATSoilSWATCExogenous();
            surfaceswatsoilswatcComponent = new SurfaceSWATSoilSWATC();
            loadParameters();
        }

        public double SurfaceSoilTemperature{ get { return s.SurfaceSoilTemperature;}} 
     
        public double[] SoilTemperatureByLayers{ get { return s.SoilTemperatureByLayers;}} 
     

        public SurfaceSWATSoilSWATCWrapper(Universe universe, SurfaceSWATSoilSWATCWrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new SurfaceSWATSoilSWATCState(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new SurfaceSWATSoilSWATCRate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new SurfaceSWATSoilSWATCAuxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new SurfaceSWATSoilSWATCExogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                surfaceswatsoilswatcComponent = (toCopy.surfaceswatsoilswatcComponent != null) ? new SurfaceSWATSoilSWATC(toCopy.surfaceswatsoilswatcComponent) : null;
            }
        }

        public void Init(){
            surfaceswatsoilswatcComponent.Init(s, r, a);
            loadParameters();
        }

        private void loadParameters()
        {
            surfaceswatsoilswatcComponent.LagCoefficient = LagCoefficient;
        }

        public void EstimateSurfaceSWATSoilSWATC(double AirTemperatureMinimum, double GlobalSolarRadiation, double WaterEquivalentOfSnowPack, double AirTemperatureMaximum, double Albedo, double AirTemperatureAnnualAverage)
        {
            a.AirTemperatureMinimum = AirTemperatureMinimum;
            a.GlobalSolarRadiation = GlobalSolarRadiation;
            a.WaterEquivalentOfSnowPack = WaterEquivalentOfSnowPack;
            a.AirTemperatureMaximum = AirTemperatureMaximum;
            a.Albedo = Albedo;
            a.AirTemperatureAnnualAverage = AirTemperatureAnnualAverage;
            surfaceswatsoilswatcComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}