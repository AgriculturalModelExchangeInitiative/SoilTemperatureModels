using System;
using System.Collections.Generic;
using System.Linq;
class SoilTemperatureWrapper
{
    private SoilTemperatureState s;
    private SoilTemperatureState s1;
    private SoilTemperatureRate r;
    private SoilTemperatureAuxiliary a;
    private SoilTemperatureExogenous ex;
    private SoilTemperatureComponent soiltemperatureComponent;

    public SoilTemperatureWrapper()
    {
        s = new SoilTemperatureState();
        r = new SoilTemperatureRate();
        a = new SoilTemperatureAuxiliary();
        ex = new SoilTemperatureExogenous();
        soiltemperatureComponent = new SoilTemperatureComponent();
        loadParameters();
    }

        double cCarbonContent;
    double cAlbedo;
    int cInitialAgeOfSnow;
    double cInitialSnowWaterContent;
    double cSnowIsolationFactorA;
    double cSnowIsolationFactorB;
    double[] cSoilLayerDepth =  new double [100];
    double cFirstDayMeanTemp;
    double cAverageGroundTemperature;
    double cAverageBulkDensity;
    double cDampingDepth;

    public double SnowWaterContent{ get { return s.SnowWaterContent;}} 
     
    public double SoilSurfaceTemperature{ get { return s.SoilSurfaceTemperature;}} 
     
    public int AgeOfSnow{ get { return s.AgeOfSnow;}} 
     
    public double[] rSoilTempArrayRate{ get { return s.rSoilTempArrayRate;}} 
     
    public double[] SoilTempArray{ get { return s.SoilTempArray;}} 
     
    public double rSnowWaterContentRate{ get { return r.rSnowWaterContentRate;}} 
     
    public double rSoilSurfaceTemperatureRate{ get { return r.rSoilSurfaceTemperatureRate;}} 
     
    public int rAgeOfSnowRate{ get { return r.rAgeOfSnowRate;}} 
     
    public double SnowIsolationIndex{ get { return a.SnowIsolationIndex;}} 
     

    public SoilTemperatureWrapper(SoilTemperatureWrapper toCopy, bool copyAll) : this()
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

    public void Init(){
        setExogenous();
        loadParameters();
        soiltemperatureComponent.Init(s, s1, r, a, ex);
    }

    private void loadParameters()
    {
        soiltemperatureComponent.cCarbonContent = null; // To be modified
        soiltemperatureComponent.cAlbedo = null; // To be modified
        soiltemperatureComponent.cInitialAgeOfSnow = null; // To be modified
        soiltemperatureComponent.cInitialSnowWaterContent = null; // To be modified
        soiltemperatureComponent.cSnowIsolationFactorA = null; // To be modified
        soiltemperatureComponent.cSnowIsolationFactorB = null; // To be modified
        soiltemperatureComponent.cSoilLayerDepth = null; // To be modified
        soiltemperatureComponent.cFirstDayMeanTemp = null; // To be modified
        soiltemperatureComponent.cAverageGroundTemperature = null; // To be modified
        soiltemperatureComponent.cAverageBulkDensity = null; // To be modified
        soiltemperatureComponent.cDampingDepth = null; // To be modified
    }

    private void setExogenous()
    {
        ex.iAirTemperatureMax = null; // To be modified
        ex.iAirTemperatureMin = null; // To be modified
        ex.iGlobalSolarRadiation = null; // To be modified
        ex.iRAIN = null; // To be modified
        ex.iCropResidues = null; // To be modified
        ex.iPotentialSoilEvaporation = null; // To be modified
        ex.iLeafAreaIndex = null; // To be modified
        ex.iSoilWaterContent = null; // To be modified
    }

    public void EstimateSoilTemperature(double[] iSoilTempArray, double iSoilSurfaceTemperature, double iAirTemperatureMax, double iTempMax, double iAirTemperatureMin, double iTempMin, double iGlobalSolarRadiation, double iRadiation, double iRAIN, double iCropResidues, double iPotentialSoilEvaporation, double iLeafAreaIndex, double iSoilWaterContent)
    {
        a.iSoilTempArray = iSoilTempArray;
        a.iSoilSurfaceTemperature = iSoilSurfaceTemperature;
        a.iAirTemperatureMax = iAirTemperatureMax;
        a.iTempMax = iTempMax;
        a.iAirTemperatureMin = iAirTemperatureMin;
        a.iTempMin = iTempMin;
        a.iGlobalSolarRadiation = iGlobalSolarRadiation;
        a.iRadiation = iRadiation;
        a.iRAIN = iRAIN;
        a.iCropResidues = iCropResidues;
        a.iPotentialSoilEvaporation = iPotentialSoilEvaporation;
        a.iLeafAreaIndex = iLeafAreaIndex;
        a.iSoilWaterContent = iSoilWaterContent;
        soiltemperatureComponent.CalculateModel(s,s1, r, a, ex);
    }

}