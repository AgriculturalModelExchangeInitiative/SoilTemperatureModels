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
///  This class encapsulates the SurfacePartonSoilSWATHourlyPartonCComponent
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class SurfacePartonSoilSWATHourlyPartonCWrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private SurfacePartonSoilSWATHourlyPartonCState s;
    private SurfacePartonSoilSWATHourlyPartonCState s1;
    private SurfacePartonSoilSWATHourlyPartonCRate r;
    private SurfacePartonSoilSWATHourlyPartonCAuxiliary a;
    private SurfacePartonSoilSWATHourlyPartonCExogenous ex;
    private SurfacePartonSoilSWATHourlyPartonCComponent surfacepartonsoilswathourlypartoncComponent;

    /// <summary>
    ///  The constructor of the Wrapper of the SurfacePartonSoilSWATHourlyPartonCComponent
    /// </summary>
    public SurfacePartonSoilSWATHourlyPartonCWrapper()
    {
        s = new SurfacePartonSoilSWATHourlyPartonCState();
        s1 = new SurfacePartonSoilSWATHourlyPartonCState();
        r = new SurfacePartonSoilSWATHourlyPartonCRate();
        a = new SurfacePartonSoilSWATHourlyPartonCAuxiliary();
        ex = new SurfacePartonSoilSWATHourlyPartonCExogenous();
        surfacepartonsoilswathourlypartoncComponent = new SurfacePartonSoilSWATHourlyPartonCComponent();
    }

    /// <summary>
    ///  The get method of the Soil temperature of each layer output variable
    /// </summary>
    [Description("Soil temperature of each layer")]
    [Units("degC")]
    public double[] SoilTemperatureByLayers{ get { return s.SoilTemperatureByLayers;}} 
     

    /// <summary>
    ///  The get method of the Volumetric specific heat of soil output variable
    /// </summary>
    [Description("Volumetric specific heat of soil")]
    [Units("MJ m-3")]
    public double[] HeatCapacity{ get { return s.HeatCapacity;}} 
     

    /// <summary>
    ///  The get method of the Thermal conductivity of soil layer output variable
    /// </summary>
    [Description("Thermal conductivity of soil layer")]
    [Units("W m-1 K-1")]
    public double[] ThermalConductivity{ get { return s.ThermalConductivity;}} 
     

    /// <summary>
    ///  The get method of the Thermal diffusivity of soil layer output variable
    /// </summary>
    [Description("Thermal diffusivity of soil layer")]
    [Units("mm s-1")]
    public double[] ThermalDiffusivity{ get { return s.ThermalDiffusivity;}} 
     

    /// <summary>
    ///  The get method of the Soil temperature range by layers output variable
    /// </summary>
    [Description("Soil temperature range by layers")]
    [Units("degC")]
    public double[] SoilTemperatureRangeByLayers{ get { return s.SoilTemperatureRangeByLayers;}} 
     

    /// <summary>
    ///  The get method of the Minimum soil temperature by layers output variable
    /// </summary>
    [Description("Minimum soil temperature by layers")]
    [Units("degC")]
    public double[] SoilTemperatureMinimum{ get { return s.SoilTemperatureMinimum;}} 
     

    /// <summary>
    ///  The get method of the Maximum soil temperature by layers output variable
    /// </summary>
    [Description("Maximum soil temperature by layers")]
    [Units("degC")]
    public double[] SoilTemperatureMaximum{ get { return s.SoilTemperatureMaximum;}} 
     

    /// <summary>
    ///  The get method of the Hourly soil temperature by layers output variable
    /// </summary>
    [Description("Hourly soil temperature by layers")]
    [Units("degC")]
    public double[] SoilTemperatureByLayersHourly{ get { return s.SoilTemperatureByLayersHourly;}} 
     

    /// <summary>
    ///  The get method of the Average surface soil temperature output variable
    /// </summary>
    [Description("Average surface soil temperature")]
    [Units("degC")]
    public double SurfaceSoilTemperature{ get { return a.SurfaceSoilTemperature;}} 
     

    /// <summary>
    ///  The get method of the Minimum surface soil temperature output variable
    /// </summary>
    [Description("Minimum surface soil temperature")]
    [Units("")]
    public double SurfaceTemperatureMinimum{ get { return a.SurfaceTemperatureMinimum;}} 
     

    /// <summary>
    ///  The get method of the Maximum surface soil temperature output variable
    /// </summary>
    [Description("Maximum surface soil temperature")]
    [Units("degC             */")]
    public double SurfaceTemperatureMaximum{ get { return a.SurfaceTemperatureMaximum;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the SurfacePartonSoilSWATHourlyPartonCComponent
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public SurfacePartonSoilSWATHourlyPartonCWrapper(SurfacePartonSoilSWATHourlyPartonCWrapper toCopy, bool copyAll) 
    {
        s = (toCopy.s != null) ? new SurfacePartonSoilSWATHourlyPartonCState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new SurfacePartonSoilSWATHourlyPartonCRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new SurfacePartonSoilSWATHourlyPartonCAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new SurfacePartonSoilSWATHourlyPartonCExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            surfacepartonsoilswathourlypartoncComponent = (toCopy.surfacepartonsoilswathourlypartoncComponent != null) ? new SurfacePartonSoilSWATHourlyPartonCComponent(toCopy.surfacepartonsoilswathourlypartoncComponent) : null;
        }
    }

    /// <summary>
    ///  The Initialization method of the wrapper of the SurfacePartonSoilSWATHourlyPartonCComponent
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        surfacepartonsoilswathourlypartoncComponent.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the SurfacePartonSoilSWATHourlyPartonCComponent
    /// </summary>
    private void loadParameters()
    {
        surfacepartonsoilswathourlypartoncComponent.SoilProfileDepth = null; // To be modified
        surfacepartonsoilswathourlypartoncComponent.LagCoefficient = null; // To be modified
        surfacepartonsoilswathourlypartoncComponent.AirTemperatureAnnualAverage = null; // To be modified
        surfacepartonsoilswathourlypartoncComponent.LayerThickness = null; // To be modified
        surfacepartonsoilswathourlypartoncComponent.BulkDensity = null; // To be modified
        surfacepartonsoilswathourlypartoncComponent.Silt = null; // To be modified
        surfacepartonsoilswathourlypartoncComponent.Clay = null; // To be modified
        surfacepartonsoilswathourlypartoncComponent.layersNumber = null; // To be modified
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the SurfacePartonSoilSWATHourlyPartonCComponent
    /// </summary>
    private void setExogenous()
    {
        ex.AirTemperatureMinimum = null; // To be modified
        ex.DayLength = null; // To be modified
        ex.GlobalSolarRadiation = null; // To be modified
        ex.AirTemperatureMaximum = null; // To be modified
        ex.VolumetricWaterContent = null; // To be modified
        ex.HourOfSunset = null; // To be modified
        ex.HourOfSunrise = null; // To be modified
    }

    [EventSubscribe("Crop2MLProcess")]
    public void CalculateModel(object sender, EventArgs e)
    {
        if (clock.Today == clock.StartDate)
        {
            Init();
        }
        setExogenous();
        surfacepartonsoilswathourlypartoncComponent.CalculateModel(s,s1, r, a, ex);
    }

}