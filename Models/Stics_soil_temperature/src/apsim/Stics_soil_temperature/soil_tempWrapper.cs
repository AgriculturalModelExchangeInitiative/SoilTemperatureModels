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
///  This class encapsulates the Soil_tempComponent
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class Soil_tempWrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private Soil_tempState s;
    private Soil_tempState s1;
    private Soil_tempRate r;
    private Soil_tempAuxiliary a;
    private Soil_tempExogenous ex;
    private Soil_tempComponent soil_tempComponent;

    /// <summary>
    ///  The constructor of the Wrapper of the Soil_tempComponent
    /// </summary>
    public Soil_tempWrapper()
    {
        s = new Soil_tempState();
        s1 = new Soil_tempState();
        r = new Soil_tempRate();
        a = new Soil_tempAuxiliary();
        ex = new Soil_tempExogenous();
        soil_tempComponent = new Soil_tempComponent();
    }

    /// <summary>
    ///  The get method of the previous soil temperature profile (for 1 cm layers) output variable
    /// </summary>
    [Description("previous soil temperature profile (for 1 cm layers)")]
    [Units("degC")]
    public List<double> prev_temp_profile{ get { return s.prev_temp_profile;}} 
     

    /// <summary>
    ///  The get method of the previous crop temperature output variable
    /// </summary>
    [Description("previous crop temperature")]
    [Units("degC")]
    public double prev_canopy_temp{ get { return s.prev_canopy_temp;}} 
     

    /// <summary>
    ///  The get method of the current temperature amplitude output variable
    /// </summary>
    [Description("current temperature amplitude")]
    [Units("degC")]
    public double temp_amp{ get { return s.temp_amp;}} 
     

    /// <summary>
    ///  The get method of the current soil profile temperature (for 1 cm layers) output variable
    /// </summary>
    [Description("current soil profile temperature (for 1 cm layers)")]
    [Units("degC")]
    public List<double> temp_profile{ get { return s.temp_profile;}} 
     

    /// <summary>
    ///  The get method of the soil layers temperature output variable
    /// </summary>
    [Description("soil layers temperature")]
    [Units("degC")]
    public List<double> layer_temp{ get { return s.layer_temp;}} 
     

    /// <summary>
    ///  The get method of the current temperature amplitude output variable
    /// </summary>
    [Description("current temperature amplitude")]
    [Units("degC")]
    public double canopy_temp_avg{ get { return s.canopy_temp_avg;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the Soil_tempComponent
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public Soil_tempWrapper(Soil_tempWrapper toCopy, bool copyAll) 
    {
        s = (toCopy.s != null) ? new Soil_tempState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new Soil_tempRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new Soil_tempAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new Soil_tempExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            soil_tempComponent = (toCopy.soil_tempComponent != null) ? new Soil_tempComponent(toCopy.soil_tempComponent) : null;
        }
    }

    /// <summary>
    ///  The Initialization method of the wrapper of the Soil_tempComponent
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        soil_tempComponent.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the Soil_tempComponent
    /// </summary>
    private void loadParameters()
    {
        soil_tempComponent.air_temp_day1 = null; // To be modified
        soil_tempComponent.layer_thick = null; // To be modified
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the Soil_tempComponent
    /// </summary>
    private void setExogenous()
    {
        ex.min_temp = null; // To be modified
        ex.max_temp = null; // To be modified
        ex.min_air_temp = null; // To be modified
        ex.min_canopy_temp = null; // To be modified
        ex.max_canopy_temp = null; // To be modified
    }

    [EventSubscribe("Crop2MLProcess")]
    public void CalculateModel(object sender, EventArgs e)
    {
        if (clock.Today == clock.StartDate)
        {
            Init();
        }
        setExogenous();
        soil_tempComponent.CalculateModel(s,s1, r, a, ex);
    }

}