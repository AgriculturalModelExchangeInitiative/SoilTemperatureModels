using System;
using System.Collections.Generic;
using System.Linq;
class CampbellWrapper
{
    private CampbellState s;
    private CampbellState s1;
    private CampbellRate r;
    private CampbellAuxiliary a;
    private CampbellExogenous ex;
    private CampbellComponent campbellComponent;

    public CampbellWrapper()
    {
        s = new CampbellState();
        r = new CampbellRate();
        a = new CampbellAuxiliary();
        ex = new CampbellExogenous();
        campbellComponent = new CampbellComponent();
        loadParameters();
    }

        string netRadiationSource;
    double instrumentHeight;
    double[] BD =  new double [100];
    double[] DEPTH =  new double [100];
    double SALB;
    double TAMP;
    int NLAYR;
    double[] THICK =  new double [100];
    double XLAT;
    double[] CLAY =  new double [100];
    string boundarLayerConductanceSource;

    public double[] soilTemp{ get { return s.soilTemp;}} 
     
    public double[] newTemperature{ get { return s.newTemperature;}} 
     
    public double[] maxSoilTemp{ get { return s.maxSoilTemp;}} 
     
    public double[] aveSoilTemp{ get { return s.aveSoilTemp;}} 
     
    public double[] morningSoilTemp{ get { return s.morningSoilTemp;}} 
     
    public double airPressure{ get { return s.airPressure;}} 
     
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
     
    public double[] minSoilTemp{ get { return a.minSoilTemp;}} 
     

    public CampbellWrapper(CampbellWrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new CampbellState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new CampbellRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new CampbellAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new CampbellExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            campbellComponent = (toCopy.campbellComponent != null) ? new CampbellComponent(toCopy.campbellComponent) : null;
        }
    }

    public void Init(){
        setExogenous();
        loadParameters();
        campbellComponent.Init(s, s1, r, a, ex);
    }

    private void loadParameters()
    {
        campbellComponent.netRadiationSource = null; // To be modified
        campbellComponent.instrumentHeight = null; // To be modified
        campbellComponent.BD = null; // To be modified
        campbellComponent.DEPTH = null; // To be modified
        campbellComponent.SALB = null; // To be modified
        campbellComponent.TAMP = null; // To be modified
        campbellComponent.NLAYR = null; // To be modified
        campbellComponent.THICK = null; // To be modified
        campbellComponent.XLAT = null; // To be modified
        campbellComponent.CLAY = null; // To be modified
        campbellComponent.boundarLayerConductanceSource = null; // To be modified
    }

    private void setExogenous()
    {
        ex.ESP = null; // To be modified
        ex.windSpeed = null; // To be modified
        ex.DOY = null; // To be modified
        ex.SW = null; // To be modified
        ex.canopyHeight = null; // To be modified
        ex.TMIN = null; // To be modified
        ex.TMAX = null; // To be modified
        ex.TAV = null; // To be modified
        ex.ES = null; // To be modified
        ex.EOAD = null; // To be modified
        ex.T2M = null; // To be modified
        ex.SRAD = null; // To be modified
    }

    public void EstimateCampbell(double ESP, double windSpeed, int DOY, double[] SW, double canopyHeight, double TMIN, double TMAX, double TAV, double ES, double EOAD, double T2M, double SRAD)
    {
        a.ESP = ESP;
        a.windSpeed = windSpeed;
        a.DOY = DOY;
        a.SW = SW;
        a.canopyHeight = canopyHeight;
        a.TMIN = TMIN;
        a.TMAX = TMAX;
        a.TAV = TAV;
        a.ES = ES;
        a.EOAD = EOAD;
        a.T2M = T2M;
        a.SRAD = SRAD;
        campbellComponent.CalculateModel(s,s1, r, a, ex);
    }

}