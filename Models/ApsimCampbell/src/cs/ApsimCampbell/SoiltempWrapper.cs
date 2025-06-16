using System;
using System.Collections.Generic;
using System.Linq;
class SoiltempWrapper
{
    private SoiltempState s;
    private SoiltempState s1;
    private SoiltempRate r;
    private SoiltempAuxiliary a;
    private SoiltempExogenous ex;
    private SoiltempComponent soiltempComponent;

    public SoiltempWrapper()
    {
        s = new SoiltempState();
        r = new SoiltempRate();
        a = new SoiltempAuxiliary();
        ex = new SoiltempExogenous();
        soiltempComponent = new SoiltempComponent();
        loadParameters();
    }

        double[] thermCondPar1 =  new double [100];
    int topsoilNode;
    int surfaceNode;
    int numPhantomNodes;
    string[] soilConstituentNames =  new string [100];
    double[] physical_Thickness =  new double [100];
    double MissingValue;
    double timestep;
    double soilRoughnessHeight;
    int numIterationsForBoundaryLayerConductance;
    double defaultTimeOfMaximumTemperature;
    double pom;
    double DepthToConstantTemperature;
    double constantBoundaryLayerConductance;
    double[] thermCondPar4 =  new double [100];
    double[] nodeDepth =  new double [100];
    double nu;
    double[] pInitialValues =  new double [100];
    double ps;
    string netRadiationSource;
    int airNode;
    double bareSoilRoughness;
    double[] thermCondPar2 =  new double [100];
    double defaultInstrumentHeight;
    double[] physical_BD =  new double [100];
    double latentHeatOfVapourisation;
    double weather_Latitude;
    double stefanBoltzmannConstant;
    string boundarLayerConductanceSource;
    double[] thermCondPar3 =  new double [100];

    public double netRadiation{ get { return s.netRadiation;}} 
     
    public double internalTimeStep{ get { return s.internalTimeStep;}} 
     
    public double[] thermalConductance{ get { return s.thermalConductance;}} 
     
    public bool doInitialisationStuff{ get { return s.doInitialisationStuff;}} 
     
    public double maxTempYesterday{ get { return s.maxTempYesterday;}} 
     
    public double timeOfDaySecs{ get { return s.timeOfDaySecs;}} 
     
    public double[] soilWater{ get { return s.soilWater;}} 
     
    public double[] soilTemp{ get { return s.soilTemp;}} 
     
    public double instrumentHeight{ get { return s.instrumentHeight;}} 
     
    public double[] volSpecHeatSoil{ get { return s.volSpecHeatSoil;}} 
     
    public double canopyHeight{ get { return s.canopyHeight;}} 
     
    public double[] heatStorage{ get { return s.heatStorage;}} 
     
    public double[] minSoilTemp{ get { return s.minSoilTemp;}} 
     
    public double[] maxSoilTemp{ get { return s.maxSoilTemp;}} 
     
    public double[] newTemperature{ get { return s.newTemperature;}} 
     
    public double airTemperature{ get { return s.airTemperature;}} 
     
    public double[] thermalConductivity{ get { return s.thermalConductivity;}} 
     
    public double minTempYesterday{ get { return s.minTempYesterday;}} 
     
    public double[] InitialValues{ get { return s.InitialValues;}} 
     
    public double boundaryLayerConductance{ get { return s.boundaryLayerConductance;}} 
     
    public double[] aveSoilTemp{ get { return s.aveSoilTemp;}} 
     
    public double[] morningSoilTemp{ get { return s.morningSoilTemp;}} 
     

    public SoiltempWrapper(SoiltempWrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new SoiltempState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new SoiltempRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new SoiltempAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new SoiltempExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            soiltempComponent = (toCopy.soiltempComponent != null) ? new SoiltempComponent(toCopy.soiltempComponent) : null;
        }
    }

    public void Init(){
        setExogenous();
        loadParameters();
        soiltempComponent.Init(s, s1, r, a, ex);
    }

    private void loadParameters()
    {
        soiltempComponent.thermCondPar1 = null; // To be modified
        soiltempComponent.topsoilNode = 2; 
        soiltempComponent.surfaceNode = 1; 
        soiltempComponent.numPhantomNodes = 5; 
        soiltempComponent.soilConstituentNames = {"Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"};
        soiltempComponent.physical_Thickness = null; // To be modified
        soiltempComponent.MissingValue = 99999; 
        soiltempComponent.timestep = 24.0 * 60.0 * 60.0; 
        soiltempComponent.soilRoughnessHeight = null; // To be modified
        soiltempComponent.numIterationsForBoundaryLayerConductance = 1; 
        soiltempComponent.defaultTimeOfMaximumTemperature = 14.0; 
        soiltempComponent.pom = null; // To be modified
        soiltempComponent.DepthToConstantTemperature = 10000; 
        soiltempComponent.constantBoundaryLayerConductance = 20; 
        soiltempComponent.thermCondPar4 = null; // To be modified
        soiltempComponent.nodeDepth = null; // To be modified
        soiltempComponent.nu = 0.6; 
        soiltempComponent.pInitialValues = null; // To be modified
        soiltempComponent.ps = null; // To be modified
        soiltempComponent.netRadiationSource = 'calc'
        soiltempComponent.airNode = 0; 
        soiltempComponent.bareSoilRoughness = 57; 
        soiltempComponent.thermCondPar2 = null; // To be modified
        soiltempComponent.defaultInstrumentHeight = 1.2; 
        soiltempComponent.physical_BD = null; // To be modified
        soiltempComponent.latentHeatOfVapourisation = 2465000; 
        soiltempComponent.weather_Latitude = null; // To be modified
        soiltempComponent.stefanBoltzmannConstant = 0.0000000567; 
        soiltempComponent.boundarLayerConductanceSource = 'calc'
        soiltempComponent.thermCondPar3 = null; // To be modified
    }

    private void setExogenous()
    {
        ex.waterBalance_Eo = null; // To be modified
        ex.waterBalance_Salb = null; // To be modified
        ex.organic_Carbon = null; // To be modified
        ex.waterBalance_Es = null; // To be modified
        ex.weather_Wind = null; // To be modified
        ex.physical_ParticleSizeSand = null; // To be modified
        ex.weather_AirPressure = null; // To be modified
        ex.clock_Today_DayOfYear = null; // To be modified
        ex.microClimate_CanopyHeight = null; // To be modified
        ex.waterBalance_Eos = null; // To be modified
        ex.waterBalance_SW = null; // To be modified
        ex.weather_Amp = null; // To be modified
        ex.weather_MinT = null; // To be modified
        ex.weather_Radn = null; // To be modified
        ex.physical_Rocks = null; // To be modified
        ex.weather_Tav = null; // To be modified
        ex.weather_MaxT = null; // To be modified
        ex.weather_MeanT = null; // To be modified
        ex.physical_ParticleSizeSilt = null; // To be modified
        ex.physical_ParticleSizeClay = null; // To be modified
    }

    public void EstimateSoiltemp(double waterBalance_Eo, double waterBalance_Salb, double[] organic_Carbon, double waterBalance_Es, double weather_Wind, double[] physical_ParticleSizeSand, double weather_AirPressure, int clock_Today_DayOfYear, double microClimate_CanopyHeight, double waterBalance_Eos, double[] waterBalance_SW, double weather_Amp, double weather_MinT, double weather_Radn, double[] physical_Rocks, double weather_Tav, double weather_MaxT, double weather_MeanT, double[] physical_ParticleSizeSilt, double[] physical_ParticleSizeClay)
    {
        ex.waterBalance_Eo = waterBalance_Eo;
        ex.waterBalance_Salb = waterBalance_Salb;
        ex.organic_Carbon = organic_Carbon;
        ex.waterBalance_Es = waterBalance_Es;
        ex.weather_Wind = weather_Wind;
        ex.physical_ParticleSizeSand = physical_ParticleSizeSand;
        ex.weather_AirPressure = weather_AirPressure;
        ex.clock_Today_DayOfYear = clock_Today_DayOfYear;
        ex.microClimate_CanopyHeight = microClimate_CanopyHeight;
        ex.waterBalance_Eos = waterBalance_Eos;
        ex.waterBalance_SW = waterBalance_SW;
        ex.weather_Amp = weather_Amp;
        ex.weather_MinT = weather_MinT;
        ex.weather_Radn = weather_Radn;
        ex.physical_Rocks = physical_Rocks;
        ex.weather_Tav = weather_Tav;
        ex.weather_MaxT = weather_MaxT;
        ex.weather_MeanT = weather_MeanT;
        ex.physical_ParticleSizeSilt = physical_ParticleSizeSilt;
        ex.physical_ParticleSizeClay = physical_ParticleSizeClay;
        soiltempComponent.CalculateModel(s,s1, r, a, ex);
    }

}