using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_SurfacePartonSoilSWATHourlyPartonC.DomainClass;
using Crop2ML_SurfacePartonSoilSWATHourlyPartonC.Strategies;

namespace Model.Model.SurfacePartonSoilSWATHourlyPartonC
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

        public double SurfaceSoilTemperature{ get { return s.SurfaceSoilTemperature;}} 
     
        public double[] SoilTemperatureByLayers{ get { return s.SoilTemperatureByLayers;}} 
     
        public double[] HeatCapacity{ get { return s.HeatCapacity;}} 
     
        public double[] ThermalConductivity{ get { return s.ThermalConductivity;}} 
     
        public double[] ThermalDiffusivity{ get { return s.ThermalDiffusivity;}} 
     
        public double[] SoilTemperatureMinimum{ get { return s.SoilTemperatureMinimum;}} 
     
        public double[] SoilTemperatureRangeByLayers{ get { return s.SoilTemperatureRangeByLayers;}} 
     
        public double[] SoilTemperatureMaximum{ get { return s.SoilTemperatureMaximum;}} 
     
        public double[] SoilTemperatureByLayersHourly{ get { return s.SoilTemperatureByLayersHourly;}} 
     
        public double SurfaceTemperatureMaximum{ get { return a.SurfaceTemperatureMaximum;}} 
     
        public double SurfaceTemperatureMinimum{ get { return a.SurfaceTemperatureMinimum;}} 
     

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
            surfacepartonsoilswathourlypartoncComponent.LagCoefficient = LagCoefficient;
        }

        public void EstimateSurfacePartonSoilSWATHourlyPartonC(double DayLength, double AirTemperatureMinimum, double GlobalSolarRadiation, double AirTemperatureMaximum, double AirTemperatureAnnualAverage, double HourOfSunset, double HourOfSunrise)
        {
            a.DayLength = DayLength;
            a.AirTemperatureMinimum = AirTemperatureMinimum;
            a.GlobalSolarRadiation = GlobalSolarRadiation;
            a.AirTemperatureMaximum = AirTemperatureMaximum;
            a.AirTemperatureAnnualAverage = AirTemperatureAnnualAverage;
            a.HourOfSunset = HourOfSunset;
            a.HourOfSunrise = HourOfSunrise;
            surfacepartonsoilswathourlypartoncComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}