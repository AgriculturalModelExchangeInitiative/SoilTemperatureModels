using System;
using System.Collections.Generic;
using System.Linq;
using SQCrop2ML_SurfacePartonSoilSWATHourlyPartonC.DomainClass;
using SQCrop2ML_SurfacePartonSoilSWATHourlyPartonC.Strategies;

namespace SiriusModel.Model.SurfacePartonSoilSWATHourlyPartonC
{
    class SurfacePartonSoilSWATHourlyPartonCWrapper :  UniverseLink
    {
        private SurfacePartonSoilSWATHourlyPartonCState s;
        private SurfacePartonSoilSWATHourlyPartonCState s1;
        private SurfacePartonSoilSWATHourlyPartonCRate r;
        private SurfacePartonSoilSWATHourlyPartonCAuxiliary a;
        private SurfacePartonSoilSWATHourlyPartonCExogenous ex;
        private SurfacePartonSoilSWATHourlyPartonCComponent surfacepartonsoilswathourlypartoncComponent;

        public SurfacePartonSoilSWATHourlyPartonCWrapper(Universe universe) : base(universe)
        {
            s = new SurfacePartonSoilSWATHourlyPartonCState();
            r = new SurfacePartonSoilSWATHourlyPartonCRate();
            a = new SurfacePartonSoilSWATHourlyPartonCAuxiliary();
            ex = new SurfacePartonSoilSWATHourlyPartonCExogenous();
            surfacepartonsoilswathourlypartoncComponent = new SurfacePartonSoilSWATHourlyPartonC();
            loadParameters();
        }

        public double[] SoilTemperatureByLayers{ get { return s.SoilTemperatureByLayers;}} 
     
        public double[] HeatCapacity{ get { return s.HeatCapacity;}} 
     
        public double[] ThermalDiffusivity{ get { return s.ThermalDiffusivity;}} 
     
        public double[] SoilTemperatureByLayersHourly{ get { return s.SoilTemperatureByLayersHourly;}} 
     
        public double SurfaceSoilTemperature{ get { return a.SurfaceSoilTemperature;}} 
     
        public double SurfaceTemperatureMinimum{ get { return a.SurfaceTemperatureMinimum;}} 
     
        public double SurfaceTemperatureMaximum{ get { return a.SurfaceTemperatureMaximum;}} 
     
        public double[] ThermalConductivity{ get { return a.ThermalConductivity;}} 
     
        public double[] SoilTemperatureRangeByLayers{ get { return a.SoilTemperatureRangeByLayers;}} 
     
        public double[] SoilTemperatureMinimum{ get { return a.SoilTemperatureMinimum;}} 
     
        public double[] SoilTemperatureMaximum{ get { return a.SoilTemperatureMaximum;}} 
     

        public SurfacePartonSoilSWATHourlyPartonCWrapper(Universe universe, SurfacePartonSoilSWATHourlyPartonCWrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new SurfacePartonSoilSWATHourlyPartonCState(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new SurfacePartonSoilSWATHourlyPartonCRate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new SurfacePartonSoilSWATHourlyPartonCAuxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new SurfacePartonSoilSWATHourlyPartonCExogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                surfacepartonsoilswathourlypartoncComponent = (toCopy.surfacepartonsoilswathourlypartoncComponent != null) ? new SurfacePartonSoilSWATHourlyPartonC(toCopy.surfacepartonsoilswathourlypartoncComponent) : null;
            }
        }

        public void Init(){
            surfacepartonsoilswathourlypartoncComponent.Init(s, r, a);
            loadParameters();
        }

        private void loadParameters()
        {
            surfacepartonsoilswathourlypartoncComponent.BulkDensity = BulkDensity;
            surfacepartonsoilswathourlypartoncComponent.SoilProfileDepth = SoilProfileDepth;
            surfacepartonsoilswathourlypartoncComponent.AirTemperatureAnnualAverage = AirTemperatureAnnualAverage;
            surfacepartonsoilswathourlypartoncComponent.LagCoefficient = LagCoefficient;
            surfacepartonsoilswathourlypartoncComponent.LayerThickness = LayerThickness;
            surfacepartonsoilswathourlypartoncComponent.Clay = Clay;
            surfacepartonsoilswathourlypartoncComponent.Silt = Silt;
            surfacepartonsoilswathourlypartoncComponent.layersNumber = layersNumber;
        }

        public void EstimateSurfacePartonSoilSWATHourlyPartonC(double AboveGroundBiomass, double[] VolumetricWaterContent, double[] OrganicMatter, double[] Sand, double AirTemperatureMaximum, double GlobalSolarRadiation, double AirTemperatureMinimum, double DayLength, double HourOfSunrise, double HourOfSunset)
        {
            a.AboveGroundBiomass = AboveGroundBiomass;
            a.VolumetricWaterContent = VolumetricWaterContent;
            a.OrganicMatter = OrganicMatter;
            a.Sand = Sand;
            a.AirTemperatureMaximum = AirTemperatureMaximum;
            a.GlobalSolarRadiation = GlobalSolarRadiation;
            a.AirTemperatureMinimum = AirTemperatureMinimum;
            a.DayLength = DayLength;
            a.HourOfSunrise = HourOfSunrise;
            a.HourOfSunset = HourOfSunset;
            surfacepartonsoilswathourlypartoncComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}