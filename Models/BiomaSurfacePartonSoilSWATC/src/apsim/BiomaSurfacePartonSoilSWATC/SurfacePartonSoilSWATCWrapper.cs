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
///  This class encapsulates the SurfacePartonSoilSWATCComponent
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class SurfacePartonSoilSWATCWrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private SurfacePartonSoilSWATCState s;
    private SurfacePartonSoilSWATCState s1;
    private SurfacePartonSoilSWATCRate r;
    private SurfacePartonSoilSWATCAuxiliary a;
    private SurfacePartonSoilSWATCExogenous ex;
    private SurfacePartonSoilSWATCComponent surfacepartonsoilswatcComponent;

    /// <summary>
    ///  The constructor of the Wrapper of the SurfacePartonSoilSWATCComponent
    /// </summary>
    public SurfacePartonSoilSWATCWrapper()
    {
        s = new SurfacePartonSoilSWATCState();
        s1 = new SurfacePartonSoilSWATCState();
        r = new SurfacePartonSoilSWATCRate();
        a = new SurfacePartonSoilSWATCAuxiliary();
        ex = new SurfacePartonSoilSWATCExogenous();
        surfacepartonsoilswatcComponent = new SurfacePartonSoilSWATCComponent();
    }

    /// <summary>
    ///  The get method of the Soil temperature of each layer output variable
    /// </summary>
    [Description("Soil temperature of each layer")]
    [Units("degC")]
    public double[] SoilTemperatureByLayers{ get { return s.SoilTemperatureByLayers;}} 
     

    /// <summary>
    ///  The get method of the Minimum surface soil temperature output variable
    /// </summary>
    [Description("Minimum surface soil temperature")]
    [Units("degC")]
    public double SurfaceTemperatureMinimum{ get { return a.SurfaceTemperatureMinimum;}} 
     

    /// <summary>
    ///  The get method of the Maximum surface soil temperature output variable
    /// </summary>
    [Description("Maximum surface soil temperature")]
    [Units("degC")]
    public double SurfaceTemperatureMaximum{ get { return a.SurfaceTemperatureMaximum;}} 
     

    /// <summary>
    ///  The get method of the Average surface soil temperature output variable
    /// </summary>
    [Description("Average surface soil temperature")]
    [Units("degC")]
    public double SurfaceSoilTemperature{ get { return a.SurfaceSoilTemperature;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the SurfacePartonSoilSWATCComponent
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public SurfacePartonSoilSWATCWrapper(SurfacePartonSoilSWATCWrapper toCopy, bool copyAll) 
    {
        s = (toCopy.s != null) ? new SurfacePartonSoilSWATCState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new SurfacePartonSoilSWATCRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new SurfacePartonSoilSWATCAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new SurfacePartonSoilSWATCExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            surfacepartonsoilswatcComponent = (toCopy.surfacepartonsoilswatcComponent != null) ? new SurfacePartonSoilSWATCComponent(toCopy.surfacepartonsoilswatcComponent) : null;
        }
    }

    /// <summary>
    ///  The Initialization method of the wrapper of the SurfacePartonSoilSWATCComponent
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        surfacepartonsoilswatcComponent.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the SurfacePartonSoilSWATCComponent
    /// </summary>
    private void loadParameters()
    {
        surfacepartonsoilswatcComponent.LayerThickness = null; // To be modified
        surfacepartonsoilswatcComponent.BulkDensity = null; // To be modified
        surfacepartonsoilswatcComponent.SoilProfileDepth = null; // To be modified
        surfacepartonsoilswatcComponent.AirTemperatureAnnualAverage = null; // To be modified
        surfacepartonsoilswatcComponent.LagCoefficient = null; // To be modified
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the SurfacePartonSoilSWATCComponent
    /// </summary>
    private void setExogenous()
    {
        ex.DayLength = null; // To be modified
        ex.GlobalSolarRadiation = null; // To be modified
        ex.AboveGroundBiomass = null; // To be modified
        ex.AirTemperatureMinimum = null; // To be modified
        ex.AirTemperatureMaximum = null; // To be modified
        ex.VolumetricWaterContent = null; // To be modified
    }

    [EventSubscribe("Crop2MLProcess")]
    public void CalculateModel(object sender, EventArgs e)
    {
        if (clock.Today == clock.StartDate)
        {
            Init();
        }
        setExogenous();
        surfacepartonsoilswatcComponent.CalculateModel(s,s1, r, a, ex);
    }

}