using APSIM.Shared.Utilities;
using Models.Climate;
using Models.Core;
using Models.Interfaces;
using Models.PMF;
using Models.Soils;
using Models.Surface;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Models.Crop2ML;

/// <summary>
///  This class encapsulates the SoiltempComponent
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class SoiltempWrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private SoiltempState s;
    private SoiltempState s1;
    private SoiltempRate r;
    private SoiltempAuxiliary a;
    private SoiltempExogenous ex;
    private SoiltempComponent soiltempComponent;

    /// <summary>
    ///  The constructor of the Wrapper of the SoiltempComponent
    /// </summary>
    public SoiltempWrapper()
    {
        s = new SoiltempState();
        s1 = new SoiltempState();
        r = new SoiltempRate();
        a = new SoiltempAuxiliary();
        ex = new SoiltempExogenous();
        soiltempComponent = new SoiltempComponent();
    }

    /// <summary>
    ///  The get method of the K, conductance of element between nodes output variable
    /// </summary>
    [Description("K, conductance of element between nodes")]
    [Units("W/K")]
    public double[] thermalConductance{ get { return s.thermalConductance;}} 
     

    /// <summary>
    ///  The get method of the Soil temperature at the end of this iteration output variable
    /// </summary>
    [Description("Soil temperature at the end of this iteration")]
    [Units("oC")]
    public double[] newTemperature{ get { return s.newTemperature;}} 
     

    /// <summary>
    ///  The get method of the Height of instruments above soil surface output variable
    /// </summary>
    [Description("Height of instruments above soil surface")]
    [Units("mm")]
    public double instrumentHeight{ get { return s.instrumentHeight;}} 
     

    /// <summary>
    ///  The get method of the Thermal conductivity output variable
    /// </summary>
    [Description("Thermal conductivity")]
    [Units("W.m/K")]
    public double[] thermalConductivity{ get { return s.thermalConductivity;}} 
     

    /// <summary>
    ///  The get method of the Minimum soil temperature output variable
    /// </summary>
    [Description("Minimum soil temperature")]
    [Units("oC")]
    public double[] minSoilTemp{ get { return s.minSoilTemp;}} 
     

    /// <summary>
    ///  The get method of the Soil temperature over the soil profile at morning output variable
    /// </summary>
    [Description("Soil temperature over the soil profile at morning")]
    [Units("oC")]
    public double[] soilTemp{ get { return s.soilTemp;}} 
     

    /// <summary>
    ///  The get method of the Flag whether initialisation is needed output variable
    /// </summary>
    [Description("Flag whether initialisation is needed")]
    [Units("mintes")]
    public bool doInitialisationStuff{ get { return s.doInitialisationStuff;}} 
     

    /// <summary>
    ///  The get method of the Average daily atmosphere boundary layer conductance output variable
    /// </summary>
    [Description("Average daily atmosphere boundary layer conductance")]
    [Units("")]
    public double boundaryLayerConductance{ get { return s.boundaryLayerConductance;}} 
     

    /// <summary>
    ///  The get method of the Volumetric water content of each soil layer output variable
    /// </summary>
    [Description("Volumetric water content of each soil layer")]
    [Units("mm3/mm3")]
    public double[] soilWater{ get { return s.soilWater;}} 
     

    /// <summary>
    ///  The get method of the Yesterday's maximum daily air temperature output variable
    /// </summary>
    [Description("Yesterday's maximum daily air temperature")]
    [Units("oC")]
    public double maxTempYesterday{ get { return s.maxTempYesterday;}} 
     

    /// <summary>
    ///  The get method of the Maximum soil temperature output variable
    /// </summary>
    [Description("Maximum soil temperature")]
    [Units("oC")]
    public double[] maxSoilTemp{ get { return s.maxSoilTemp;}} 
     

    /// <summary>
    ///  The get method of the CP, heat storage between nodes output variable
    /// </summary>
    [Description("CP, heat storage between nodes")]
    [Units("J/K")]
    public double[] heatStorage{ get { return s.heatStorage;}} 
     

    /// <summary>
    ///  The get method of the average soil temperature output variable
    /// </summary>
    [Description("average soil temperature")]
    [Units("oC")]
    public double[] aveSoilTemp{ get { return s.aveSoilTemp;}} 
     

    /// <summary>
    ///  The get method of the Yesterday's minimum daily air temperature output variable
    /// </summary>
    [Description("Yesterday's minimum daily air temperature")]
    [Units("oC")]
    public double minTempYesterday{ get { return s.minTempYesterday;}} 
     

    /// <summary>
    ///  The get method of the Volumetric specific heat over the soil profile output variable
    /// </summary>
    [Description("Volumetric specific heat over the soil profile")]
    [Units("J/K/m3")]
    public double[] volSpecHeatSoil{ get { return s.volSpecHeatSoil;}} 
     

    /// <summary>
    ///  The get method of the Soil temperature over the soil profile at morning output variable
    /// </summary>
    [Description("Soil temperature over the soil profile at morning")]
    [Units("oC")]
    public double[] morningSoilTemp{ get { return s.morningSoilTemp;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the SoiltempComponent
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public SoiltempWrapper(SoiltempWrapper toCopy, bool copyAll) 
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

    /// <summary>
    ///  The Initialization method of the wrapper of the SoiltempComponent
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        soiltempComponent.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the SoiltempComponent
    /// </summary>
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

    /// <summary>
    ///  Set exogenous variables of the wrapper of the SoiltempComponent
    /// </summary>
    private void setExogenous()
    {
        ex.weather_MaxT = null; // To be modified
        ex.weather_Radn = null; // To be modified
        ex.microClimate_CanopyHeight = null; // To be modified
        ex.weather_MinT = null; // To be modified
        ex.physical_ParticleSizeClay = null; // To be modified
        ex.weather_Wind = null; // To be modified
        ex.physical_ParticleSizeSand = null; // To be modified
        ex.waterBalance_Eos = null; // To be modified
        ex.weather_MeanT = null; // To be modified
        ex.weather_Latitude = null; // To be modified
        ex.weather_Amp = null; // To be modified
        ex.timestep = null; // To be modified
        ex.waterBalance_Salb = null; // To be modified
        ex.physical_ParticleSizeSilt = null; // To be modified
        ex.clock_Today_DayOfYear = null; // To be modified
        ex.waterBalance_Eo = null; // To be modified
        ex.waterBalance_SW = null; // To be modified
        ex.waterBalance_Es = null; // To be modified
        ex.weather_Tav = null; // To be modified
        ex.physical_Rocks = null; // To be modified
        ex.weather_AirPressure = null; // To be modified
        ex.organic_Carbon = null; // To be modified
    }

    [EventSubscribe("Crop2MLProcess")]
    public void CalculateModel(object sender, EventArgs e)
    {
        if (clock.Today == clock.StartDate)
        {
            Init();
        }
        setExogenous();
        soiltempComponent.CalculateModel(s,s1, r, a, ex);
    }

}