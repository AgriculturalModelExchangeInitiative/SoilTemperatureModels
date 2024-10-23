using System;
using System.Collections.Generic;
using System.Linq;
class Model_SoilTempCampbellWrapper
{
    private Model_SoilTempCampbellState s;
    private Model_SoilTempCampbellState s1;
    private Model_SoilTempCampbellRate r;
    private Model_SoilTempCampbellAuxiliary a;
    private Model_SoilTempCampbellExogenous ex;
    private Model_SoilTempCampbellComponent model_soiltempcampbellComponent;

    public Model_SoilTempCampbellWrapper()
    {
        s = new Model_SoilTempCampbellState();
        r = new Model_SoilTempCampbellRate();
        a = new Model_SoilTempCampbellAuxiliary();
        ex = new Model_SoilTempCampbellExogenous();
        model_soiltempcampbellComponent = new Model_SoilTempCampbellComponent();
        loadParameters();
    }

        int NLAYR;
    double CONSTANT_TEMPdepth;
    double TAMP;
    double XLAT;
    double SALB;
    double instrumentHeight;
    string boundaryLayerConductanceSource;
    string netRadiationSource;

    public double[] THICK{ get { return s.THICK;}} 
     
    public double[] DEPTH{ get { return s.DEPTH;}} 
     
    public double[] BD{ get { return s.BD;}} 
     
    public double[] CLAY{ get { return s.CLAY;}} 
     
    public double[] soilTemp{ get { return s.soilTemp;}} 
     
    public double[] newTemperature{ get { return s.newTemperature;}} 
     
    public double[] minSoilTemp{ get { return s.minSoilTemp;}} 
     
    public double[] maxSoilTemp{ get { return s.maxSoilTemp;}} 
     
    public double[] aveSoilTemp{ get { return s.aveSoilTemp;}} 
     
    public double[] morningSoilTemp{ get { return s.morningSoilTemp;}} 
     
    public double[] thermalCondPar1{ get { return s.thermalCondPar1;}} 
     
    public double[] thermalCondPar2{ get { return s.thermalCondPar2;}} 
     
    public double[] thermalCondPar3{ get { return s.thermalCondPar3;}} 
     
    public double[] thermalCondPar4{ get { return s.thermalCondPar4;}} 
     
    public double[] thermalConductivity{ get { return s.thermalConductivity;}} 
     
    public double[] thermalConductance{ get { return s.thermalConductance;}} 
     
    public double[] heatStorage{ get { return s.heatStorage;}} 
     
    public double[] volSpecHeatSoil{ get { return s.volSpecHeatSoil;}} 
     
    public double maxTempYesterday{ get { return s.maxTempYesterday;}} 
     
    public double minTempYesterday{ get { return s.minTempYesterday;}} 
     
    public double[] SLCARB{ get { return s.SLCARB;}} 
     
    public double[] SLROCK{ get { return s.SLROCK;}} 
     
    public double[] SLSILT{ get { return s.SLSILT;}} 
     
    public double[] SLSAND{ get { return s.SLSAND;}} 
     
    public double _boundaryLayerConductance{ get { return s._boundaryLayerConductance;}} 
     

    public Model_SoilTempCampbellWrapper(Model_SoilTempCampbellWrapper toCopy, bool copyAll) : this()
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

    public void Init(){
        setExogenous();
        loadParameters();
        model_soiltempcampbellComponent.Init(s, s1, r, a, ex);
    }

    private void loadParameters()
    {
        model_soiltempcampbellComponent.NLAYR = null; // To be modified
        model_soiltempcampbellComponent.CONSTANT_TEMPdepth = null; // To be modified
        model_soiltempcampbellComponent.TAMP = null; // To be modified
        model_soiltempcampbellComponent.XLAT = null; // To be modified
        model_soiltempcampbellComponent.SALB = null; // To be modified
        model_soiltempcampbellComponent.instrumentHeight = null; // To be modified
        model_soiltempcampbellComponent.boundaryLayerConductanceSource = null; // To be modified
        model_soiltempcampbellComponent.netRadiationSource = null; // To be modified
    }

    private void setExogenous()
    {
        ex.T2M = null; // To be modified
        ex.TMAX = null; // To be modified
        ex.TMIN = null; // To be modified
        ex.TAV = null; // To be modified
        ex.DOY = null; // To be modified
        ex.airPressure = null; // To be modified
        ex.canopyHeight = null; // To be modified
        ex.SRAD = null; // To be modified
        ex.ESP = null; // To be modified
        ex.ES = null; // To be modified
        ex.EOAD = null; // To be modified
        ex.windSpeed = null; // To be modified
    }

    public void EstimateModel_SoilTempCampbell(double T2M, double TMAX, double TMIN, double TAV, int DOY, double airPressure, double canopyHeight, double SRAD, double ESP, double ES, double EOAD, double windSpeed)
    {
        a.T2M = T2M;
        a.TMAX = TMAX;
        a.TMIN = TMIN;
        a.TAV = TAV;
        a.DOY = DOY;
        a.airPressure = airPressure;
        a.canopyHeight = canopyHeight;
        a.SRAD = SRAD;
        a.ESP = ESP;
        a.ES = ES;
        a.EOAD = EOAD;
        a.windSpeed = windSpeed;
        model_soiltempcampbellComponent.CalculateModel(s,s1, r, a, ex);
    }

}