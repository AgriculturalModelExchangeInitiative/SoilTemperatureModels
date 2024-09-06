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
///  This class encapsulates the STEMP_Component
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class STEMP_Wrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private STEMP_State s;
    private STEMP_State s1;
    private STEMP_Rate r;
    private STEMP_Auxiliary a;
    private STEMP_Exogenous ex;
    private STEMP_Component stemp_Component;

    /// <summary>
    ///  The constructor of the Wrapper of the STEMP_Component
    /// </summary>
    public STEMP_Wrapper()
    {
        s = new STEMP_State();
        s1 = new STEMP_State();
        r = new STEMP_Rate();
        a = new STEMP_Auxiliary();
        ex = new STEMP_Exogenous();
        stemp_Component = new STEMP_Component();
    }

    /// <summary>
    ///  The get method of the Temperature of soil surface litter output variable
    /// </summary>
    [Description("Temperature of soil surface litter")]
    [Units("degC")]
    public double SRFTEMP{ get { return s.SRFTEMP;}} 
     

    /// <summary>
    ///  The get method of the Soil temperature in soil layer L output variable
    /// </summary>
    [Description("Soil temperature in soil layer L")]
    [Units("degC")]
    public double[] ST{ get { return s.ST;}} 
     

    /// <summary>
    ///  The get method of the Array of previous 5 days of average soil temperatures output variable
    /// </summary>
    [Description("Array of previous 5 days of average soil temperatures")]
    [Units("degC")]
    public double[] TMA{ get { return s.TMA;}} 
     

    /// <summary>
    ///  The get method of the Total water content of soil at drained upper limit output variable
    /// </summary>
    [Description("Total water content of soil at drained upper limit")]
    [Units("cm")]
    public double TDL{ get { return s.TDL;}} 
     

    /// <summary>
    ///  The get method of the Cumulative depth of soil profile output variable
    /// </summary>
    [Description("Cumulative depth of soil profile")]
    [Units("mm")]
    public double CUMDPT{ get { return s.CUMDPT;}} 
     

    /// <summary>
    ///  The get method of the Sum of TMA array (last 5 days soil temperature) output variable
    /// </summary>
    [Description("Sum of TMA array (last 5 days soil temperature)")]
    [Units("degC")]
    public double ATOT{ get { return s.ATOT;}} 
     

    /// <summary>
    ///  The get method of the Depth to midpoint of soil layer L output variable
    /// </summary>
    [Description("Depth to midpoint of soil layer L")]
    [Units("cm")]
    public double[] DSMID{ get { return s.DSMID;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the STEMP_Component
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public STEMP_Wrapper(STEMP_Wrapper toCopy, bool copyAll) 
    {
        s = (toCopy.s != null) ? new STEMP_State(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new STEMP_Rate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new STEMP_Auxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new STEMP_Exogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            stemp_Component = (toCopy.stemp_Component != null) ? new STEMP_Component(toCopy.stemp_Component) : null;
        }
    }

    /// <summary>
    ///  The Initialization method of the wrapper of the STEMP_Component
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        stemp_Component.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the STEMP_Component
    /// </summary>
    private void loadParameters()
    {
        stemp_Component.MSALB = null; // To be modified
        stemp_Component.NL = null; // To be modified
        stemp_Component.LL = null; // To be modified
        stemp_Component.NLAYR = null; // To be modified
        stemp_Component.DS = null; // To be modified
        stemp_Component.DLAYR = null; // To be modified
        stemp_Component.ISWWAT = null; // To be modified
        stemp_Component.BD = null; // To be modified
        stemp_Component.SW = null; // To be modified
        stemp_Component.XLAT = null; // To be modified
        stemp_Component.DUL = null; // To be modified
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the STEMP_Component
    /// </summary>
    private void setExogenous()
    {
        ex.TMAX = null; // To be modified
        ex.SRAD = null; // To be modified
        ex.TAMP = null; // To be modified
        ex.TAVG = null; // To be modified
        ex.TAV = null; // To be modified
        ex.DOY = null; // To be modified
    }

    [EventSubscribe("Crop2MLProcess")]
    public void CalculateModel(object sender, EventArgs e)
    {
        if (clock.Today == clock.StartDate)
        {
            Init();
        }
        setExogenous();
        stemp_Component.CalculateModel(s,s1, r, a, ex);
    }

}