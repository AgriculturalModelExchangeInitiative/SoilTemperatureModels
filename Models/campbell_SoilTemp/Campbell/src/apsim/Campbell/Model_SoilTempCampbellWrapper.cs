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
///  This class encapsulates the Model_SoilTempCampbellComponent
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class Model_SoilTempCampbellWrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private Model_SoilTempCampbellState s;
    private Model_SoilTempCampbellState s1;
    private Model_SoilTempCampbellRate r;
    private Model_SoilTempCampbellAuxiliary a;
    private Model_SoilTempCampbellExogenous ex;
    private Model_SoilTempCampbellComponent model_soiltempcampbellComponent;

    /// <summary>
    ///  The constructor of the Wrapper of the Model_SoilTempCampbellComponent
    /// </summary>
    public Model_SoilTempCampbellWrapper()
    {
        s = new Model_SoilTempCampbellState();
        s1 = new Model_SoilTempCampbellState();
        r = new Model_SoilTempCampbellRate();
        a = new Model_SoilTempCampbellAuxiliary();
        ex = new Model_SoilTempCampbellExogenous();
        model_soiltempcampbellComponent = new Model_SoilTempCampbellComponent();
    }

    /// <summary>
    ///  The get method of the APSIM soil layer depths of layers output variable
    /// </summary>
    [Description("APSIM soil layer depths of layers")]
    [Units("mm")]
    public List<double> THICKApsim{ get { return s.THICKApsim;}} 
     

    /// <summary>
    ///  The get method of the Apsim node depths output variable
    /// </summary>
    [Description("Apsim node depths")]
    [Units("m")]
    public List<double> DEPTHApsim{ get { return s.DEPTHApsim;}} 
     

    /// <summary>
    ///  The get method of the Apsim bd (soil bulk density) output variable
    /// </summary>
    [Description("Apsim bd (soil bulk density)")]
    [Units("g/cm3             uri :")]
    public List<double> BDApsim{ get { return s.BDApsim;}} 
     

    /// <summary>
    ///  The get method of the Apsim proportion of CLAY in each layer of profile output variable
    /// </summary>
    [Description("Apsim proportion of CLAY in each layer of profile")]
    [Units("")]
    public List<double> CLAYApsim{ get { return s.CLAYApsim;}} 
     

    /// <summary>
    ///  The get method of the Apsim volumetric water content output variable
    /// </summary>
    [Description("Apsim volumetric water content")]
    [Units("cc water / cc soil")]
    public List<double> SWApsim{ get { return s.SWApsim;}} 
     

    /// <summary>
    ///  The get method of the Temperature at end of last time-step within a day - midnight in layers output variable
    /// </summary>
    [Description("Temperature at end of last time-step within a day - midnight in layers")]
    [Units("degC")]
    public List<double> soilTemp{ get { return s.soilTemp;}} 
     

    /// <summary>
    ///  The get method of the Soil temperature at the end of one iteration output variable
    /// </summary>
    [Description("Soil temperature at the end of one iteration")]
    [Units("degC")]
    public List<double> newTemperature{ get { return s.newTemperature;}} 
     

    /// <summary>
    ///  The get method of the Minimum soil temperature in layers output variable
    /// </summary>
    [Description("Minimum soil temperature in layers")]
    [Units("degC")]
    public List<double> minSoilTemp{ get { return s.minSoilTemp;}} 
     

    /// <summary>
    ///  The get method of the Maximum soil temperature in layers output variable
    /// </summary>
    [Description("Maximum soil temperature in layers")]
    [Units("degC")]
    public List<double> maxSoilTemp{ get { return s.maxSoilTemp;}} 
     

    /// <summary>
    ///  The get method of the Temperature averaged over all time-steps within a day in layers. output variable
    /// </summary>
    [Description("Temperature averaged over all time-steps within a day in layers.")]
    [Units("degC")]
    public List<double> aveSoilTemp{ get { return s.aveSoilTemp;}} 
     

    /// <summary>
    ///  The get method of the Temperature  in the morning in layers. output variable
    /// </summary>
    [Description("Temperature  in the morning in layers.")]
    [Units("degC")]
    public List<double> morningSoilTemp{ get { return s.morningSoilTemp;}} 
     

    /// <summary>
    ///  The get method of the thermal conductivity coeff in layers output variable
    /// </summary>
    [Description("thermal conductivity coeff in layers")]
    [Units("(W/m2/K)")]
    public List<double> thermalCondPar1{ get { return s.thermalCondPar1;}} 
     

    /// <summary>
    ///  The get method of the thermal conductivity coeff in layers output variable
    /// </summary>
    [Description("thermal conductivity coeff in layers")]
    [Units("(W/m2/K)")]
    public List<double> thermalCondPar2{ get { return s.thermalCondPar2;}} 
     

    /// <summary>
    ///  The get method of the thermal conductivity coeff in layers output variable
    /// </summary>
    [Description("thermal conductivity coeff in layers")]
    [Units("(W/m2/K)")]
    public List<double> thermalCondPar3{ get { return s.thermalCondPar3;}} 
     

    /// <summary>
    ///  The get method of the thermal conductivity coeff in layers output variable
    /// </summary>
    [Description("thermal conductivity coeff in layers")]
    [Units("(W/m2/K)")]
    public List<double> thermalCondPar4{ get { return s.thermalCondPar4;}} 
     

    /// <summary>
    ///  The get method of the thermal conductivity in layers output variable
    /// </summary>
    [Description("thermal conductivity in layers")]
    [Units("(W/m2/K)")]
    public List<double> thermalConductivity{ get { return s.thermalConductivity;}} 
     

    /// <summary>
    ///  The get method of the Thermal conductance between layers output variable
    /// </summary>
    [Description("Thermal conductance between layers")]
    [Units("(W/m2/K)")]
    public List<double> thermalConductance{ get { return s.thermalConductance;}} 
     

    /// <summary>
    ///  The get method of the Heat storage between layers (internal) output variable
    /// </summary>
    [Description("Heat storage between layers (internal)")]
    [Units("J/s/K")]
    public List<double> heatStorage{ get { return s.heatStorage;}} 
     

    /// <summary>
    ///  The get method of the Volumetric specific heat over the soil profile output variable
    /// </summary>
    [Description("Volumetric specific heat over the soil profile")]
    [Units("J/K/m3")]
    public List<double> volSpecHeatSoil{ get { return s.volSpecHeatSoil;}} 
     

    /// <summary>
    ///  The get method of the Air max temperature from previous day output variable
    /// </summary>
    [Description("Air max temperature from previous day")]
    [Units("")]
    public double maxTempYesterday{ get { return s.maxTempYesterday;}} 
     

    /// <summary>
    ///  The get method of the Air min temperature from previous day output variable
    /// </summary>
    [Description("Air min temperature from previous day")]
    [Units("")]
    public double minTempYesterday{ get { return s.minTempYesterday;}} 
     

    /// <summary>
    ///  The get method of the Apsim volumetric fraction of organic matter in the soil output variable
    /// </summary>
    [Description("Apsim volumetric fraction of organic matter in the soil")]
    [Units("")]
    public List<double> SLCARBApsim{ get { return s.SLCARBApsim;}} 
     

    /// <summary>
    ///  The get method of the Apsim volumetric fraction of rocks in the soil output variable
    /// </summary>
    [Description("Apsim volumetric fraction of rocks in the soil")]
    [Units("")]
    public List<double> SLROCKApsim{ get { return s.SLROCKApsim;}} 
     

    /// <summary>
    ///  The get method of the Apsim volumetric fraction of silt in the soil output variable
    /// </summary>
    [Description("Apsim volumetric fraction of silt in the soil")]
    [Units("")]
    public List<double> SLSILTApsim{ get { return s.SLSILTApsim;}} 
     

    /// <summary>
    ///  The get method of the Apsim volumetric fraction of sand in the soil output variable
    /// </summary>
    [Description("Apsim volumetric fraction of sand in the soil")]
    [Units("")]
    public List<double> SLSANDApsim{ get { return s.SLSANDApsim;}} 
     

    /// <summary>
    ///  The get method of the Boundary layer conductance output variable
    /// </summary>
    [Description("Boundary layer conductance")]
    [Units("K/W")]
    public double _boundaryLayerConductance{ get { return s._boundaryLayerConductance;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the Model_SoilTempCampbellComponent
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public Model_SoilTempCampbellWrapper(Model_SoilTempCampbellWrapper toCopy, bool copyAll) 
    {
        s = (toCopy.s != null) ? new Model_SoilTempCampbellState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new Model_SoilTempCampbellRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new Model_SoilTempCampbellAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new Model_SoilTempCampbellExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            model_soiltempcampbellComponent = (toCopy.model_soiltempcampbellComponent != null) ? new Model_SoilTempCampbellComponent(toCopy.model_soiltempcampbellComponent) : null;
        }
    }

    /// <summary>
    ///  The Initialization method of the wrapper of the Model_SoilTempCampbellComponent
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        model_soiltempcampbellComponent.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the Model_SoilTempCampbellComponent
    /// </summary>
    private void loadParameters()
    {
        model_soiltempcampbellComponent.NLAYR = null; // To be modified
        model_soiltempcampbellComponent.THICK = null; // To be modified
        model_soiltempcampbellComponent.BD = null; // To be modified
        model_soiltempcampbellComponent.SLCARB = null; // To be modified
        model_soiltempcampbellComponent.CLAY = null; // To be modified
        model_soiltempcampbellComponent.SLROCK = null; // To be modified
        model_soiltempcampbellComponent.SLSILT = null; // To be modified
        model_soiltempcampbellComponent.SLSAND = null; // To be modified
        model_soiltempcampbellComponent.SW = null; // To be modified
        model_soiltempcampbellComponent.CONSTANT_TEMPdepth = null; // To be modified
        model_soiltempcampbellComponent.TAV = null; // To be modified
        model_soiltempcampbellComponent.TAMP = null; // To be modified
        model_soiltempcampbellComponent.XLAT = null; // To be modified
        model_soiltempcampbellComponent.SALB = null; // To be modified
        model_soiltempcampbellComponent.instrumentHeight = null; // To be modified
        model_soiltempcampbellComponent.boundaryLayerConductanceSource = null; // To be modified
        model_soiltempcampbellComponent.netRadiationSource = null; // To be modified
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the Model_SoilTempCampbellComponent
    /// </summary>
    private void setExogenous()
    {
        ex.T2M = null; // To be modified
        ex.TMAX = null; // To be modified
        ex.TMIN = null; // To be modified
        ex.DOY = null; // To be modified
        ex.airPressure = null; // To be modified
        ex.canopyHeight = null; // To be modified
        ex.SRAD = null; // To be modified
        ex.ESP = null; // To be modified
        ex.ES = null; // To be modified
        ex.EOAD = null; // To be modified
        ex.windSpeed = null; // To be modified
    }

    [EventSubscribe("Crop2MLProcess")]
    public void CalculateModel(object sender, EventArgs e)
    {
        if (clock.Today == clock.StartDate)
        {
            Init();
        }
        setExogenous();
        model_soiltempcampbellComponent.CalculateModel(s,s1, r, a, ex);
    }

}