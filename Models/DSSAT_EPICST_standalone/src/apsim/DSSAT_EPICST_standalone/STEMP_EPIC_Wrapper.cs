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
///  This class encapsulates the STEMP_EPIC_Component
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class STEMP_EPIC_Wrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private STEMP_EPIC_State s;
    private STEMP_EPIC_State s1;
    private STEMP_EPIC_Rate r;
    private STEMP_EPIC_Auxiliary a;
    private STEMP_EPIC_Exogenous ex;
    private STEMP_EPIC_Component stemp_epic_Component;

    /// <summary>
    ///  The constructor of the Wrapper of the STEMP_EPIC_Component
    /// </summary>
    public STEMP_EPIC_Wrapper()
    {
        s = new STEMP_EPIC_State();
        s1 = new STEMP_EPIC_State();
        r = new STEMP_EPIC_Rate();
        a = new STEMP_EPIC_Auxiliary();
        ex = new STEMP_EPIC_Exogenous();
        stemp_epic_Component = new STEMP_EPIC_Component();
    }

    /// <summary>
    ///  The get method of the Wet Days output variable
    /// </summary>
    [Description("Wet Days")]
    [Units("day")]
    public int[] WetDay{ get { return s.WetDay;}} 
     

    /// <summary>
    ///  The get method of the Temperature of soil surface litter output variable
    /// </summary>
    [Description("Temperature of soil surface litter")]
    [Units("degC")]
    public double SRFTEMP{ get { return s.SRFTEMP;}} 
     

    /// <summary>
    ///  The get method of the Number of days ... output variable
    /// </summary>
    [Description("Number of days ...")]
    [Units("day")]
    public int NDays{ get { return s.NDays;}} 
     

    /// <summary>
    ///  The get method of the Soil temperature in soil layer NL output variable
    /// </summary>
    [Description("Soil temperature in soil layer NL")]
    [Units("degC")]
    public double[] ST{ get { return s.ST;}} 
     

    /// <summary>
    ///  The get method of the Array of previous 5 days of average soil temperatures. output variable
    /// </summary>
    [Description("Array of previous 5 days of average soil temperatures.")]
    [Units("degC")]
    public double[] TMA{ get { return s.TMA;}} 
     

    /// <summary>
    ///  The get method of the Total water content of soil at drained upper limit output variable
    /// </summary>
    [Description("Total water content of soil at drained upper limit")]
    [Units("cm")]
    public double TDL{ get { return s.TDL;}} 
     

    /// <summary>
    ///  The get method of the Temperature of soil surface at precedent timestep output variable
    /// </summary>
    [Description("Temperature of soil surface at precedent timestep")]
    [Units("degC")]
    public double X2_PREV{ get { return s.X2_PREV;}} 
     

    /// <summary>
    ///  The get method of the Depth to midpoint of soil layer NL output variable
    /// </summary>
    [Description("Depth to midpoint of soil layer NL")]
    [Units("cm")]
    public double[] DSMID{ get { return s.DSMID;}} 
     

    /// <summary>
    ///  The get method of the Cumulative depth of soil profile output variable
    /// </summary>
    [Description("Cumulative depth of soil profile")]
    [Units("mm")]
    public double CUMDPT{ get { return s.CUMDPT;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the STEMP_EPIC_Component
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public STEMP_EPIC_Wrapper(STEMP_EPIC_Wrapper toCopy, bool copyAll) 
    {
        s = (toCopy.s != null) ? new STEMP_EPIC_State(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new STEMP_EPIC_Rate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new STEMP_EPIC_Auxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new STEMP_EPIC_Exogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            stemp_epic_Component = (toCopy.stemp_epic_Component != null) ? new STEMP_EPIC_Component(toCopy.stemp_epic_Component) : null;
        }
    }

    /// <summary>
    ///  The Initialization method of the wrapper of the STEMP_EPIC_Component
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        stemp_epic_Component.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the STEMP_EPIC_Component
    /// </summary>
    private void loadParameters()
    {
        stemp_epic_Component.DUL = null; // To be modified
        stemp_epic_Component.NL = null; // To be modified
        stemp_epic_Component.NLAYR = null; // To be modified
        stemp_epic_Component.DS = null; // To be modified
        stemp_epic_Component.ISWWAT = null; // To be modified
        stemp_epic_Component.BD = null; // To be modified
        stemp_epic_Component.LL = null; // To be modified
        stemp_epic_Component.DLAYR = null; // To be modified
        stemp_epic_Component.SW = null; // To be modified
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the STEMP_EPIC_Component
    /// </summary>
    private void setExogenous()
    {
        ex.TAV = null; // To be modified
        ex.RAIN = null; // To be modified
        ex.BIOMAS = null; // To be modified
        ex.SNOW = null; // To be modified
        ex.TAVG = null; // To be modified
        ex.DEPIR = null; // To be modified
        ex.MULCHMASS = null; // To be modified
        ex.TMAX = null; // To be modified
        ex.TMIN = null; // To be modified
        ex.TAMP = null; // To be modified
    }

    [EventSubscribe("Crop2MLProcess")]
    public void CalculateModel(object sender, EventArgs e)
    {
        if (clock.Today == clock.StartDate)
        {
            Init();
        }
        setExogenous();
        stemp_epic_Component.CalculateModel(s,s1, r, a, ex);
    }

}