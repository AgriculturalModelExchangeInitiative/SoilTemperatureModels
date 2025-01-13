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

        double[] physical_BD =  new double [100];
    double ps;
    int airNode;
    double[] nodeDepth =  new double [100];
    int surfaceNode;
    double DepthToConstantTemperature;
    double[] thermCondPar2 =  new double [100];
    int numPhantomNodes;
    double[] physical_Thickness =  new double [100];
    double[] thermCondPar3 =  new double [100];
    double bareSoilRoughness;
    int topsoilNode;
    string[] soilConstituentNames =  new string [100];
    double defaultInstrumentHeight;
    string boundarLayerConductanceSource;
    double[] thermCondPar1 =  new double [100];
    double latentHeatOfVapourisation;
    double[] thermCondPar4 =  new double [100];
    double MissingValue;
    string netRadiationSource;
    double constantBoundaryLayerConductance;
    int numIterationsForBoundaryLayerConductance;
    double nu;
    double[] Thickness =  new double [100];
    double[] InitialValues =  new double [100];
    double pom;
    double soilRoughnessHeight;
    double defaultTimeOfMaximumTemperature;
    double stefanBoltzmannConstant;

    public double minTempYesterday{ get { return s.minTempYesterday;}} 
     
    public double[] minSoilTemp{ get { return s.minSoilTemp;}} 
     
    public double[] newTemperature{ get { return s.newTemperature;}} 
     
    public bool doInitialisationStuff{ get { return s.doInitialisationStuff;}} 
     
    public double[] morningSoilTemp{ get { return s.morningSoilTemp;}} 
     
    public double[] aveSoilTemp{ get { return s.aveSoilTemp;}} 
     
    public double[] soilWater{ get { return s.soilWater;}} 
     
    public double[] thermalConductivity{ get { return s.thermalConductivity;}} 
     
    public double[] soilTemp{ get { return s.soilTemp;}} 
     
    public double[] heatStorage{ get { return s.heatStorage;}} 
     
    public double instrumentHeight{ get { return s.instrumentHeight;}} 
     
    public double[] thermalConductance{ get { return s.thermalConductance;}} 
     
    public double maxTempYesterday{ get { return s.maxTempYesterday;}} 
     
    public double boundaryLayerConductance{ get { return s.boundaryLayerConductance;}} 
     
    public double[] maxSoilTemp{ get { return s.maxSoilTemp;}} 
     
    public double[] volSpecHeatSoil{ get { return s.volSpecHeatSoil;}} 
     

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
        soiltempComponent.physical_BD = null; // To be modified
        soiltempComponent.ps = null; // To be modified
        soiltempComponent.airNode = null; // To be modified
        soiltempComponent.nodeDepth = null; // To be modified
        soiltempComponent.surfaceNode = null; // To be modified
        soiltempComponent.DepthToConstantTemperature = null; // To be modified
        soiltempComponent.thermCondPar2 = null; // To be modified
        soiltempComponent.numPhantomNodes = null; // To be modified
        soiltempComponent.physical_Thickness = null; // To be modified
        soiltempComponent.thermCondPar3 = null; // To be modified
        soiltempComponent.bareSoilRoughness = null; // To be modified
        soiltempComponent.topsoilNode = null; // To be modified
        soiltempComponent.soilConstituentNames = null; // To be modified
        soiltempComponent.defaultInstrumentHeight = null; // To be modified
        soiltempComponent.boundarLayerConductanceSource = null; // To be modified
        soiltempComponent.thermCondPar1 = null; // To be modified
        soiltempComponent.latentHeatOfVapourisation = null; // To be modified
        soiltempComponent.thermCondPar4 = null; // To be modified
        soiltempComponent.MissingValue = null; // To be modified
        soiltempComponent.netRadiationSource = null; // To be modified
        soiltempComponent.constantBoundaryLayerConductance = null; // To be modified
        soiltempComponent.numIterationsForBoundaryLayerConductance = null; // To be modified
        soiltempComponent.nu = null; // To be modified
        soiltempComponent.Thickness = null; // To be modified
        soiltempComponent.InitialValues = null; // To be modified
        soiltempComponent.pom = null; // To be modified
        soiltempComponent.soilRoughnessHeight = null; // To be modified
        soiltempComponent.defaultTimeOfMaximumTemperature = null; // To be modified
        soiltempComponent.stefanBoltzmannConstant = null; // To be modified
    }

    private void setExogenous()
    {
        ex.weather_MaxT = null; // To be modified
        ex.waterBalance_SW = null; // To be modified
        ex.clock_Today_DayOfYear = null; // To be modified
        ex.weather_Radn = null; // To be modified
        ex.microClimate_CanopyHeight = null; // To be modified
        ex.weather_Latitude = null; // To be modified
        ex.weather_MeanT = null; // To be modified
        ex.physical_Rocks = null; // To be modified
        ex.waterBalance_Eo = null; // To be modified
        ex.timestep = null; // To be modified
        ex.weather_MinT = null; // To be modified
        ex.organic_Carbon = null; // To be modified
        ex.weather_Tav = null; // To be modified
        ex.physical_ParticleSizeSand = null; // To be modified
        ex.weather_AirPressure = null; // To be modified
        ex.waterBalance_Eos = null; // To be modified
        ex.waterBalance_Es = null; // To be modified
        ex.waterBalance_Salb = null; // To be modified
        ex.physical_ParticleSizeSilt = null; // To be modified
        ex.weather_Wind = null; // To be modified
        ex.weather_Amp = null; // To be modified
        ex.physical_ParticleSizeClay = null; // To be modified
    }

    public void EstimateSoiltemp(double weather_MaxT, double[] waterBalance_SW, int clock_Today_DayOfYear, double weather_Radn, double microClimate_CanopyHeight, double weather_Latitude, double weather_MeanT, double[] physical_Rocks, double waterBalance_Eo, double timestep, double weather_MinT, double[] organic_Carbon, double weather_Tav, double[] physical_ParticleSizeSand, double weather_AirPressure, double waterBalance_Eos, double waterBalance_Es, double waterBalance_Salb, double[] physical_ParticleSizeSilt, double weather_Wind, double weather_Amp, double[] physical_ParticleSizeClay)
    {
        ex.weather_MaxT = weather_MaxT;
        ex.waterBalance_SW = waterBalance_SW;
        ex.clock_Today_DayOfYear = clock_Today_DayOfYear;
        ex.weather_Radn = weather_Radn;
        ex.microClimate_CanopyHeight = microClimate_CanopyHeight;
        ex.weather_Latitude = weather_Latitude;
        ex.weather_MeanT = weather_MeanT;
        ex.physical_Rocks = physical_Rocks;
        ex.waterBalance_Eo = waterBalance_Eo;
        ex.timestep = timestep;
        ex.weather_MinT = weather_MinT;
        ex.organic_Carbon = organic_Carbon;
        ex.weather_Tav = weather_Tav;
        ex.physical_ParticleSizeSand = physical_ParticleSizeSand;
        ex.weather_AirPressure = weather_AirPressure;
        ex.waterBalance_Eos = waterBalance_Eos;
        ex.waterBalance_Es = waterBalance_Es;
        ex.waterBalance_Salb = waterBalance_Salb;
        ex.physical_ParticleSizeSilt = physical_ParticleSizeSilt;
        ex.weather_Wind = weather_Wind;
        ex.weather_Amp = weather_Amp;
        ex.physical_ParticleSizeClay = physical_ParticleSizeClay;
        soiltempComponent.CalculateModel(s,s1, r, a, ex);
    }

}