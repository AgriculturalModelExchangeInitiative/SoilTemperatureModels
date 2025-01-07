using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_Soiltemp.DomainClass;
using Crop2ML_Soiltemp.Strategies;

namespace Model.Model.Soiltemp
{
    class SoiltempWrapper :  UniverseLink
    {
        private SoiltempState s;
        private SoiltempState s1;
        private SoiltempRate r;
        private SoiltempAuxiliary a;
        private SoiltempExogenous ex;
        private SoiltempComponent soiltempComponent;

        public SoiltempWrapper(Universe universe) : base(universe)
        {
            s = new SoiltempState();
            r = new SoiltempRate();
            a = new SoiltempAuxiliary();
            ex = new SoiltempExogenous();
            soiltempComponent = new Soiltemp();
            loadParameters();
        }

        public double[] thermalConductance{ get { return s.thermalConductance;}} 
     
        public double[] newTemperature{ get { return s.newTemperature;}} 
     
        public double instrumentHeight{ get { return s.instrumentHeight;}} 
     
        public double[] thermalConductivity{ get { return s.thermalConductivity;}} 
     
        public double[] minSoilTemp{ get { return s.minSoilTemp;}} 
     
        public double[] soilTemp{ get { return s.soilTemp;}} 
     
        public bool doInitialisationStuff{ get { return s.doInitialisationStuff;}} 
     
        public double boundaryLayerConductance{ get { return s.boundaryLayerConductance;}} 
     
        public double[] soilWater{ get { return s.soilWater;}} 
     
        public double maxTempYesterday{ get { return s.maxTempYesterday;}} 
     
        public double[] maxSoilTemp{ get { return s.maxSoilTemp;}} 
     
        public double[] heatStorage{ get { return s.heatStorage;}} 
     
        public double[] aveSoilTemp{ get { return s.aveSoilTemp;}} 
     
        public double minTempYesterday{ get { return s.minTempYesterday;}} 
     
        public double[] volSpecHeatSoil{ get { return s.volSpecHeatSoil;}} 
     
        public double[] morningSoilTemp{ get { return s.morningSoilTemp;}} 
     

        public SoiltempWrapper(Universe universe, SoiltempWrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new SoiltempState(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new SoiltempRate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new SoiltempAuxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new SoiltempExogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                soiltempComponent = (toCopy.soiltempComponent != null) ? new Soiltemp(toCopy.soiltempComponent) : null;
            }
        }

        public void Init(){
            setExogenous();
            loadParameters();
            soiltempComponent.Init(s, s1, r, a, ex);
        }

        private void loadParameters()
        {
            soiltempComponent.Thickness = null; // To be modified
            soiltempComponent.numIterationsForBoundaryLayerConductance = null; // To be modified
            soiltempComponent.thermCondPar3 = null; // To be modified
            soiltempComponent.defaultInstrumentHeight = null; // To be modified
            soiltempComponent.latentHeatOfVapourisation = null; // To be modified
            soiltempComponent.airNode = null; // To be modified
            soiltempComponent.ps = null; // To be modified
            soiltempComponent.defaultTimeOfMaximumTemperature = null; // To be modified
            soiltempComponent.netRadiationSource = null; // To be modified
            soiltempComponent.topsoilNode = null; // To be modified
            soiltempComponent.MissingValue = null; // To be modified
            soiltempComponent.pom = null; // To be modified
            soiltempComponent.physical_BD = null; // To be modified
            soiltempComponent.physical_Thickness = null; // To be modified
            soiltempComponent.soilRoughnessHeight = null; // To be modified
            soiltempComponent.numPhantomNodes = null; // To be modified
            soiltempComponent.thermCondPar4 = null; // To be modified
            soiltempComponent.nodeDepth = null; // To be modified
            soiltempComponent.surfaceNode = null; // To be modified
            soiltempComponent.boundarLayerConductanceSource = null; // To be modified
            soiltempComponent.thermCondPar2 = null; // To be modified
            soiltempComponent.DepthToConstantTemperature = null; // To be modified
            soiltempComponent.constantBoundaryLayerConductance = null; // To be modified
            soiltempComponent.nu = null; // To be modified
            soiltempComponent.bareSoilRoughness = null; // To be modified
            soiltempComponent.stefanBoltzmannConstant = null; // To be modified
            soiltempComponent.InitialValues = null; // To be modified
            soiltempComponent.thermCondPar1 = null; // To be modified
            soiltempComponent.soilConstituentNames = null; // To be modified
        }

        public void EstimateSoiltemp(double weather_MaxT, double weather_Radn, double microClimate_CanopyHeight, double weather_MinT, double[] physical_ParticleSizeClay, double weather_Wind, double[] physical_ParticleSizeSand, double waterBalance_Eos, double weather_MeanT, double weather_Latitude, double weather_Amp, double timestep, double waterBalance_Salb, double[] physical_ParticleSizeSilt, int clock_Today_DayOfYear, double waterBalance_Eo, double[] waterBalance_SW, double waterBalance_Es, double weather_Tav, double[] physical_Rocks, double weather_AirPressure, double[] organic_Carbon)
        {
            a.weather_MaxT = weather_MaxT;
            a.weather_Radn = weather_Radn;
            a.microClimate_CanopyHeight = microClimate_CanopyHeight;
            a.weather_MinT = weather_MinT;
            a.physical_ParticleSizeClay = physical_ParticleSizeClay;
            a.weather_Wind = weather_Wind;
            a.physical_ParticleSizeSand = physical_ParticleSizeSand;
            a.waterBalance_Eos = waterBalance_Eos;
            a.weather_MeanT = weather_MeanT;
            a.weather_Latitude = weather_Latitude;
            a.weather_Amp = weather_Amp;
            a.timestep = timestep;
            a.waterBalance_Salb = waterBalance_Salb;
            a.physical_ParticleSizeSilt = physical_ParticleSizeSilt;
            a.clock_Today_DayOfYear = clock_Today_DayOfYear;
            a.waterBalance_Eo = waterBalance_Eo;
            a.waterBalance_SW = waterBalance_SW;
            a.waterBalance_Es = waterBalance_Es;
            a.weather_Tav = weather_Tav;
            a.physical_Rocks = physical_Rocks;
            a.weather_AirPressure = weather_AirPressure;
            a.organic_Carbon = organic_Carbon;
            soiltempComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}