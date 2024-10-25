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
    double[] THICK =  new double [100];
    double[] BD =  new double [100];
    double[] SLCARB =  new double [100];
    double[] CLAY =  new double [100];
    double[] SLROCK =  new double [100];
    double[] SLSILT =  new double [100];
    double[] SLSAND =  new double [100];
    double[] SW =  new double [100];
    double CONSTANT_TEMPdepth;
    double TAV;
    double TAMP;
    double XLAT;
    double SALB;
    double instrumentHeight;
    string boundaryLayerConductanceSource;
    string netRadiationSource;

    public List<double> THICKApsim{ get { return s.THICKApsim;}} 
     
    public List<double> DEPTHApsim{ get { return s.DEPTHApsim;}} 
     
    public List<double> BDApsim{ get { return s.BDApsim;}} 
     
    public List<double> CLAYApsim{ get { return s.CLAYApsim;}} 
     
    public List<double> SWApsim{ get { return s.SWApsim;}} 
     
    public List<double> soilTemp{ get { return s.soilTemp;}} 
     
    public List<double> newTemperature{ get { return s.newTemperature;}} 
     
    public List<double> minSoilTemp{ get { return s.minSoilTemp;}} 
     
    public List<double> maxSoilTemp{ get { return s.maxSoilTemp;}} 
     
    public List<double> aveSoilTemp{ get { return s.aveSoilTemp;}} 
     
    public List<double> morningSoilTemp{ get { return s.morningSoilTemp;}} 
     
    public List<double> thermalCondPar1{ get { return s.thermalCondPar1;}} 
     
    public List<double> thermalCondPar2{ get { return s.thermalCondPar2;}} 
     
    public List<double> thermalCondPar3{ get { return s.thermalCondPar3;}} 
     
    public List<double> thermalCondPar4{ get { return s.thermalCondPar4;}} 
     
    public List<double> thermalConductivity{ get { return s.thermalConductivity;}} 
     
    public List<double> thermalConductance{ get { return s.thermalConductance;}} 
     
    public List<double> heatStorage{ get { return s.heatStorage;}} 
     
    public List<double> volSpecHeatSoil{ get { return s.volSpecHeatSoil;}} 
     
    public double maxTempYesterday{ get { return s.maxTempYesterday;}} 
     
    public double minTempYesterday{ get { return s.minTempYesterday;}} 
     
    public List<double> SLCARBApsim{ get { return s.SLCARBApsim;}} 
     
    public List<double> SLROCKApsim{ get { return s.SLROCKApsim;}} 
     
    public List<double> SLSILTApsim{ get { return s.SLSILTApsim;}} 
     
    public List<double> SLSANDApsim{ get { return s.SLSANDApsim;}} 
     
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
        model_soiltempcampbellComponent.THICK = null; // To be modified
        model_soiltempcampbellComponent.BD = null; // To be modified
        model_soiltempcampbellComponent.SLCARB = null; // To be modified
        model_soiltempcampbellComponent.CLAY = null; // To be modified
        model_soiltempcampbellComponent.SLROCK = null; // To be modified
        model_soiltempcampbellComponent.SLSILT = null; // To be modified
        model_soiltempcampbellComponent.SLSAND = null; // To be modified
        model_soiltempcampbellComponent.SW = null; // To be modified
        model_soiltempcampbellComponent.CONSTANT_TEMPdepth = null; // To be modified
        model_soiltempcampbellComponent.TAV = null; // To be modified
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
        ex.DOY = null; // To be modified
        ex.airPressure = null; // To be modified
        ex.canopyHeight = null; // To be modified
        ex.SRAD = null; // To be modified
        ex.ESP = null; // To be modified
        ex.ES = null; // To be modified
        ex.EOAD = null; // To be modified
        ex.windSpeed = null; // To be modified
    }

    public void EstimateModel_SoilTempCampbell(double T2M, double TMAX, double TMIN, int DOY, double airPressure, double canopyHeight, double SRAD, double ESP, double ES, double EOAD, double windSpeed)
    {
        a.T2M = T2M;
        a.TMAX = TMAX;
        a.TMIN = TMIN;
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