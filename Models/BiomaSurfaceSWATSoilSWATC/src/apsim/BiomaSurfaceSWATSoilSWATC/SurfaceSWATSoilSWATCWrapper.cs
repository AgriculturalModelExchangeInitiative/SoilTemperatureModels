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
///  This class encapsulates the SurfaceSWATSoilSWATCComponent
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class SurfaceSWATSoilSWATCWrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private SurfaceSWATSoilSWATCState s;
    private SurfaceSWATSoilSWATCState s1;
    private SurfaceSWATSoilSWATCRate r;
    private SurfaceSWATSoilSWATCAuxiliary a;
    private SurfaceSWATSoilSWATCExogenous ex;
    private SurfaceSWATSoilSWATCComponent surfaceswatsoilswatcComponent;

    /// <summary>
    ///  The constructor of the Wrapper of the SurfaceSWATSoilSWATCComponent
    /// </summary>
    public SurfaceSWATSoilSWATCWrapper()
    {
        s = new SurfaceSWATSoilSWATCState();
        s1 = new SurfaceSWATSoilSWATCState();
        r = new SurfaceSWATSoilSWATCRate();
        a = new SurfaceSWATSoilSWATCAuxiliary();
        ex = new SurfaceSWATSoilSWATCExogenous();
        surfaceswatsoilswatcComponent = new SurfaceSWATSoilSWATCComponent();
    }

    /// <summary>
    ///  The get method of the Soil temperature of each layer output variable
    /// </summary>
    [Description("Soil temperature of each layer")]
    [Units("degC")]
    public double[] SoilTemperatureByLayers{ get { return s.SoilTemperatureByLayers;}} 
     

    /// <summary>
    ///  The get method of the Average surface soil temperature output variable
    /// </summary>
    [Description("Average surface soil temperature")]
    [Units("degC")]
    public double SurfaceSoilTemperature{ get { return a.SurfaceSoilTemperature;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the SurfaceSWATSoilSWATCComponent
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public SurfaceSWATSoilSWATCWrapper(SurfaceSWATSoilSWATCWrapper toCopy, bool copyAll) 
    {
        s = (toCopy.s != null) ? new SurfaceSWATSoilSWATCState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new SurfaceSWATSoilSWATCRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new SurfaceSWATSoilSWATCAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new SurfaceSWATSoilSWATCExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            surfaceswatsoilswatcComponent = (toCopy.surfaceswatsoilswatcComponent != null) ? new SurfaceSWATSoilSWATCComponent(toCopy.surfaceswatsoilswatcComponent) : null;
        }
    }

    /// <summary>
    ///  The Initialization method of the wrapper of the SurfaceSWATSoilSWATCComponent
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        surfaceswatsoilswatcComponent.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the SurfaceSWATSoilSWATCComponent
    /// </summary>
    private void loadParameters()
    {
        surfaceswatsoilswatcComponent.BulkDensity = null; // To be modified
        surfaceswatsoilswatcComponent.AirTemperatureAnnualAverage = null; // To be modified
        surfaceswatsoilswatcComponent.SoilProfileDepth = null; // To be modified
        surfaceswatsoilswatcComponent.LagCoefficient = null; // To be modified
        surfaceswatsoilswatcComponent.LayerThickness = null; // To be modified
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the SurfaceSWATSoilSWATCComponent
    /// </summary>
    private void setExogenous()
    {
        ex.AirTemperatureMaximum = null; // To be modified
        ex.AirTemperatureMinimum = null; // To be modified
        ex.GlobalSolarRadiation = null; // To be modified
        ex.WaterEquivalentOfSnowPack = null; // To be modified
        ex.Albedo = null; // To be modified
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
        surfaceswatsoilswatcComponent.CalculateModel(s,s1, r, a, ex);
    }

}