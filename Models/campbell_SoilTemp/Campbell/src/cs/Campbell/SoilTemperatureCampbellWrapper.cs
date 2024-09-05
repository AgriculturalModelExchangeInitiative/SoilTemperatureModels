using System;
using System.Collections.Generic;
using System.Linq;
class SoilTemperatureCampbellWrapper
{
    private SoilTemperatureCampbellState s;
    private SoilTemperatureCampbellState s1;
    private SoilTemperatureCampbellRate r;
    private SoilTemperatureCampbellAuxiliary a;
    private SoilTemperatureCampbellExogenous ex;
    private SoilTemperatureCampbellComponent soiltemperaturecampbellComponent;

    public SoilTemperatureCampbellWrapper()
    {
        s = new SoilTemperatureCampbellState();
        r = new SoilTemperatureCampbellRate();
        a = new SoilTemperatureCampbellAuxiliary();
        ex = new SoilTemperatureCampbellExogenous();
        soiltemperaturecampbellComponent = new SoilTemperatureCampbellComponent();
        loadParameters();
    }

    

    public double[] soilTemp{ get { return s.soilTemp;}} 
     
    public double[] maxSoilTemp{ get { return s.maxSoilTemp;}} 
     
    public double[] aveSoilTemp{ get { return s.aveSoilTemp;}} 
     
    public double[] morningSoilTemp{ get { return s.morningSoilTemp;}} 
     
    public double[] tempNew{ get { return s.tempNew;}} 
     
    public double[] heatCapacity{ get { return s.heatCapacity;}} 
     
    public double[] thermalConductivity{ get { return s.thermalConductivity;}} 
     
    public double[] thermalConductance{ get { return s.thermalConductance;}} 
     
    public double[] heatStorage{ get { return s.heatStorage;}} 
     
    public double[] minSoilTemp{ get { return a.minSoilTemp;}} 
     

    public SoilTemperatureCampbellWrapper(SoilTemperatureCampbellWrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new SoilTemperatureCampbellState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new SoilTemperatureCampbellRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new SoilTemperatureCampbellAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new SoilTemperatureCampbellExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            soiltemperaturecampbellComponent = (toCopy.soiltemperaturecampbellComponent != null) ? new SoilTemperatureCampbellComponent(toCopy.soiltemperaturecampbellComponent) : null;
        }
    }

    public void Init(){
        setExogenous();
        loadParameters();
        soiltemperaturecampbellComponent.Init(s, s1, r, a, ex);
    }

    private void loadParameters()
    {
    }

    private void setExogenous()
    {
        ex.EOAD = null; // To be modified
        ex.TMAX = null; // To be modified
        ex.TAV = null; // To be modified
        ex.SW = null; // To be modified
        ex.ESAD = null; // To be modified
        ex.canopyHeight = null; // To be modified
        ex.DOY = null; // To be modified
        ex.SRAD = null; // To be modified
        ex.ESP = null; // To be modified
        ex.TMIN = null; // To be modified
    }

    public void EstimateSoilTemperatureCampbell(double EOAD, double TMAX, double TAV, double[] SW, double ESAD, double canopyHeight, double DOY, double SRAD, double ESP, double TMIN)
    {
        a.EOAD = EOAD;
        a.TMAX = TMAX;
        a.TAV = TAV;
        a.SW = SW;
        a.ESAD = ESAD;
        a.canopyHeight = canopyHeight;
        a.DOY = DOY;
        a.SRAD = SRAD;
        a.ESP = ESP;
        a.TMIN = TMIN;
        soiltemperaturecampbellComponent.CalculateModel(s,s1, r, a, ex);
    }

}