using System;
using System.Collections.Generic;
using System.Linq;
using SQCrop2ML_SurfaceSWATSoilSWATC.DomainClass;
using SQCrop2ML_SurfaceSWATSoilSWATC.Strategies;

namespace SiriusModel.Model.SurfaceSWATSoilSWATC
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

        public double[] SoilTemperatureByLayers{ get { return s.SoilTemperatureByLayers;}} 
     
        public double SurfaceSoilTemperature{ get { return a.SurfaceSoilTemperature;}} 
     

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
            surfaceswatsoilswatcComponent.BulkDensity = BulkDensity;
            surfaceswatsoilswatcComponent.AirTemperatureAnnualAverage = AirTemperatureAnnualAverage;
            surfaceswatsoilswatcComponent.SoilProfileDepth = SoilProfileDepth;
            surfaceswatsoilswatcComponent.LagCoefficient = LagCoefficient;
            surfaceswatsoilswatcComponent.LayerThickness = LayerThickness;
        }

        public void EstimateSurfaceSWATSoilSWATC(double AboveGroundBiomass, double AirTemperatureMaximum, double AirTemperatureMinimum, double GlobalSolarRadiation, double WaterEquivalentOfSnowPack, double Albedo, double[] VolumetricWaterContent)
        {
            a.AboveGroundBiomass = AboveGroundBiomass;
            a.AirTemperatureMaximum = AirTemperatureMaximum;
            a.AirTemperatureMinimum = AirTemperatureMinimum;
            a.GlobalSolarRadiation = GlobalSolarRadiation;
            a.WaterEquivalentOfSnowPack = WaterEquivalentOfSnowPack;
            a.Albedo = Albedo;
            a.VolumetricWaterContent = VolumetricWaterContent;
            surfaceswatsoilswatcComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}