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
///  This class encapsulates the soil_tempComponent
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class soil_tempWrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private soil_tempState s;
    private soil_tempState s1;
    private soil_tempRate r;
    private soil_tempAuxiliary a;
    private soil_tempExogenous ex;
    private soil_tempComponent soil_tempComponent;

    /// <summary>
    ///  The constructor of the Wrapper of the soil_tempComponent
    /// </summary>
    public soil_tempWrapper()
    {
        s = new soil_tempState();
        s1 = new soil_tempState();
        r = new soil_tempRate();
        a = new soil_tempAuxiliary();
        ex = new soil_tempExogenous();
        soil_tempComponent = new soil_tempComponent();
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
    ///  The Constructor copy of the wrapper of the soil_tempComponent
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public soil_tempWrapper(soil_tempWrapper toCopy, bool copyAll) 
    {
        s = (toCopy.s != null) ? new soil_tempState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new soil_tempRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new soil_tempAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new soil_tempExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            soil_tempComponent = (toCopy.soil_tempComponent != null) ? new soil_tempComponent(toCopy.soil_tempComponent) : null;
        }
    }

    /// <summary>
    ///  The Initialization method of the wrapper of the soil_tempComponent
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        soil_tempComponent.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the soil_tempComponent
    /// </summary>
    private void loadParameters()
    {
        soil_tempComponent.air_temp_day1 = null; // To be modified
        soil_tempComponent.layer_thick = null; // To be modified
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the soil_tempComponent
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