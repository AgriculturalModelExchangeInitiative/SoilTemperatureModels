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
///  This class encapsulates the SoilTemperatureComponent
/// </summary>
[Serializable]
[PresenterName("UserInterface.Presenters.PropertyPresenter")]
[ViewName("UserInterface.Views.PropertyView")]
[ValidParent(ParentType = typeof(Zone))]
class SoilTemperatureWrapper :  Model
{
    [Link] Clock clock = null;
    //[Link] Weather weather = null; // other links

    private SoilTemperatureState s;
    private SoilTemperatureState s1;
    private SoilTemperatureRate r;
    private SoilTemperatureAuxiliary a;
    private SoilTemperatureExogenous ex;
    private SoilTemperatureComponent soiltemperatureComponent;

    /// <summary>
    ///  The constructor of the Wrapper of the SoilTemperatureComponent
    /// </summary>
    public SoilTemperatureWrapper()
    {
        s = new SoilTemperatureState();
        s1 = new SoilTemperatureState();
        r = new SoilTemperatureRate();
        a = new SoilTemperatureAuxiliary();
        ex = new SoilTemperatureExogenous();
        soiltemperatureComponent = new SoilTemperatureComponent();
    }

    /// <summary>
    ///  The get method of the Snow water content output variable
    /// </summary>
    [Description("Snow water content")]
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/millimetre")]
    public double SnowWaterContent{ get { return s.SnowWaterContent;}} 
     

    /// <summary>
    ///  The get method of the Soil surface temperature output variable
    /// </summary>
    [Description("Soil surface temperature")]
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius")]
    public double SoilSurfaceTemperature{ get { return s.SoilSurfaceTemperature;}} 
     

    /// <summary>
    ///  The get method of the Age of snow output variable
    /// </summary>
    [Description("Age of snow")]
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/day")]
    public int AgeOfSnow{ get { return s.AgeOfSnow;}} 
     

    /// <summary>
    ///  The get method of the Array of daily temperature change output variable
    /// </summary>
    [Description("Array of daily temperature change")]
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius_per_day")]
    public double[] rSoilTempArrayRate{ get { return s.rSoilTempArrayRate;}} 
     

    /// <summary>
    ///  The get method of the Array of soil temperatures in layers  output variable
    /// </summary>
    [Description("Array of soil temperatures in layers ")]
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius")]
    public double[] SoilTempArray{ get { return s.SoilTempArray;}} 
     

    /// <summary>
    ///  The get method of the daily snow water content change rate output variable
    /// </summary>
    [Description("daily snow water content change rate")]
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day")]
    public double rSnowWaterContentRate{ get { return r.rSnowWaterContentRate;}} 
     

    /// <summary>
    ///  The get method of the daily soil surface temperature change rate output variable
    /// </summary>
    [Description("daily soil surface temperature change rate")]
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius_per_day")]
    public double rSoilSurfaceTemperatureRate{ get { return r.rSoilSurfaceTemperatureRate;}} 
     

    /// <summary>
    ///  The get method of the daily age of snow change rate output variable
    /// </summary>
    [Description("daily age of snow change rate")]
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/one")]
    public int rAgeOfSnowRate{ get { return r.rAgeOfSnowRate;}} 
     

    /// <summary>
    ///  The get method of the Snow isolation index output variable
    /// </summary>
    [Description("Snow isolation index")]
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/one")]
    public double SnowIsolationIndex{ get { return a.SnowIsolationIndex;}} 
     

    /// <summary>
    ///  The Constructor copy of the wrapper of the SoilTemperatureComponent
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public SoilTemperatureWrapper(SoilTemperatureWrapper toCopy, bool copyAll) 
    {
        s = (toCopy.s != null) ? new SoilTemperatureState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new SoilTemperatureRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new SoilTemperatureAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new SoilTemperatureExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            soiltemperatureComponent = (toCopy.soiltemperatureComponent != null) ? new SoilTemperatureComponent(toCopy.soiltemperatureComponent) : null;
        }
    }

    /// <summary>
    ///  The Initialization method of the wrapper of the SoilTemperatureComponent
    /// </summary>
    public void Init(){
        setExogenous();
        loadParameters();
        soiltemperatureComponent.Init(s, s1, r, a, ex);
    }

    /// <summary>
    ///  Load parameters of the wrapper of the SoilTemperatureComponent
    /// </summary>
    private void loadParameters()
    {
        soiltemperatureComponent.cCarbonContent = null; // To be modified
        soiltemperatureComponent.cAlbedo = null; // To be modified
        soiltemperatureComponent.cSoilLayerDepth = null; // To be modified
        soiltemperatureComponent.cFirstDayMeanTemp = null; // To be modified
        soiltemperatureComponent.cAverageGroundTemperature = null; // To be modified
        soiltemperatureComponent.cAverageBulkDensity = null; // To be modified
        soiltemperatureComponent.cDampingDepth = null; // To be modified
    }

    /// <summary>
    ///  Set exogenous variables of the wrapper of the SoilTemperatureComponent
    /// </summary>
    private void setExogenous()
    {
        ex.iAirTemperatureMax = null; // To be modified
        ex.iAirTemperatureMin = null; // To be modified
        ex.iGlobalSolarRadiation = null; // To be modified
        ex.iRAIN = null; // To be modified
        ex.iCropResidues = null; // To be modified
        ex.iPotentialSoilEvaporation = null; // To be modified
        ex.iLeafAreaIndex = null; // To be modified
        ex.SoilTempArray = null; // To be modified
        ex.iSoilWaterContent = null; // To be modified
    }

    [EventSubscribe("Crop2MLProcess")]
    public void CalculateModel(object sender, EventArgs e)
    {
        if (clock.Today == clock.StartDate)
        {
            Init();
        }
        setExogenous();
        soiltemperatureComponent.CalculateModel(s,s1, r, a, ex);
    }

}