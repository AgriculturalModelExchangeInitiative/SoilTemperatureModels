using System;
using System.Collections.Generic;
public class Model_SoilTempCampbellState 
{
    private List<double> _THICKApsim = new List<double>();
    private List<double> _DEPTHApsim = new List<double>();
    private List<double> _BDApsim = new List<double>();
    private List<double> _CLAYApsim = new List<double>();
    private List<double> _SWApsim = new List<double>();
    private List<double> _soilTemp = new List<double>();
    private List<double> _newTemperature = new List<double>();
    private List<double> _minSoilTemp = new List<double>();
    private List<double> _maxSoilTemp = new List<double>();
    private List<double> _aveSoilTemp = new List<double>();
    private List<double> _morningSoilTemp = new List<double>();
    private List<double> _thermalCondPar1 = new List<double>();
    private List<double> _thermalCondPar2 = new List<double>();
    private List<double> _thermalCondPar3 = new List<double>();
    private List<double> _thermalCondPar4 = new List<double>();
    private List<double> _thermalConductivity = new List<double>();
    private List<double> _thermalConductance = new List<double>();
    private List<double> _heatStorage = new List<double>();
    private List<double> _volSpecHeatSoil = new List<double>();
    private double _maxTempYesterday;
    private double _minTempYesterday;
    private List<double> _SLCARBApsim = new List<double>();
    private List<double> _SLROCKApsim = new List<double>();
    private List<double> _SLSILTApsim = new List<double>();
    private List<double> _SLSANDApsim = new List<double>();
    private double __boundaryLayerConductance;
    
    /// <summary>
    /// Constructor of the Model_SoilTempCampbellState component")
    /// </summary>  
    public Model_SoilTempCampbellState() { }
    
    
    public Model_SoilTempCampbellState(Model_SoilTempCampbellState toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            THICKApsim = new List<double>();
            for (int i = 0; i < toCopy.THICKApsim.Count; i++)
                { THICKApsim.Add(toCopy.THICKApsim[i]); }
    
            DEPTHApsim = new List<double>();
            for (int i = 0; i < toCopy.DEPTHApsim.Count; i++)
                { DEPTHApsim.Add(toCopy.DEPTHApsim[i]); }
    
            BDApsim = new List<double>();
            for (int i = 0; i < toCopy.BDApsim.Count; i++)
                { BDApsim.Add(toCopy.BDApsim[i]); }
    
            CLAYApsim = new List<double>();
            for (int i = 0; i < toCopy.CLAYApsim.Count; i++)
                { CLAYApsim.Add(toCopy.CLAYApsim[i]); }
    
            SWApsim = new List<double>();
            for (int i = 0; i < toCopy.SWApsim.Count; i++)
                { SWApsim.Add(toCopy.SWApsim[i]); }
    
            soilTemp = new List<double>();
            for (int i = 0; i < toCopy.soilTemp.Count; i++)
                { soilTemp.Add(toCopy.soilTemp[i]); }
    
            newTemperature = new List<double>();
            for (int i = 0; i < toCopy.newTemperature.Count; i++)
                { newTemperature.Add(toCopy.newTemperature[i]); }
    
            minSoilTemp = new List<double>();
            for (int i = 0; i < toCopy.minSoilTemp.Count; i++)
                { minSoilTemp.Add(toCopy.minSoilTemp[i]); }
    
            maxSoilTemp = new List<double>();
            for (int i = 0; i < toCopy.maxSoilTemp.Count; i++)
                { maxSoilTemp.Add(toCopy.maxSoilTemp[i]); }
    
            aveSoilTemp = new List<double>();
            for (int i = 0; i < toCopy.aveSoilTemp.Count; i++)
                { aveSoilTemp.Add(toCopy.aveSoilTemp[i]); }
    
            morningSoilTemp = new List<double>();
            for (int i = 0; i < toCopy.morningSoilTemp.Count; i++)
                { morningSoilTemp.Add(toCopy.morningSoilTemp[i]); }
    
            thermalCondPar1 = new List<double>();
            for (int i = 0; i < toCopy.thermalCondPar1.Count; i++)
                { thermalCondPar1.Add(toCopy.thermalCondPar1[i]); }
    
            thermalCondPar2 = new List<double>();
            for (int i = 0; i < toCopy.thermalCondPar2.Count; i++)
                { thermalCondPar2.Add(toCopy.thermalCondPar2[i]); }
    
            thermalCondPar3 = new List<double>();
            for (int i = 0; i < toCopy.thermalCondPar3.Count; i++)
                { thermalCondPar3.Add(toCopy.thermalCondPar3[i]); }
    
            thermalCondPar4 = new List<double>();
            for (int i = 0; i < toCopy.thermalCondPar4.Count; i++)
                { thermalCondPar4.Add(toCopy.thermalCondPar4[i]); }
    
            thermalConductivity = new List<double>();
            for (int i = 0; i < toCopy.thermalConductivity.Count; i++)
                { thermalConductivity.Add(toCopy.thermalConductivity[i]); }
    
            thermalConductance = new List<double>();
            for (int i = 0; i < toCopy.thermalConductance.Count; i++)
                { thermalConductance.Add(toCopy.thermalConductance[i]); }
    
            heatStorage = new List<double>();
            for (int i = 0; i < toCopy.heatStorage.Count; i++)
                { heatStorage.Add(toCopy.heatStorage[i]); }
    
            volSpecHeatSoil = new List<double>();
            for (int i = 0; i < toCopy.volSpecHeatSoil.Count; i++)
                { volSpecHeatSoil.Add(toCopy.volSpecHeatSoil[i]); }
    
            maxTempYesterday = toCopy.maxTempYesterday;
            minTempYesterday = toCopy.minTempYesterday;
            SLCARBApsim = new List<double>();
            for (int i = 0; i < toCopy.SLCARBApsim.Count; i++)
                { SLCARBApsim.Add(toCopy.SLCARBApsim[i]); }
    
            SLROCKApsim = new List<double>();
            for (int i = 0; i < toCopy.SLROCKApsim.Count; i++)
                { SLROCKApsim.Add(toCopy.SLROCKApsim[i]); }
    
            SLSILTApsim = new List<double>();
            for (int i = 0; i < toCopy.SLSILTApsim.Count; i++)
                { SLSILTApsim.Add(toCopy.SLSILTApsim[i]); }
    
            SLSANDApsim = new List<double>();
            for (int i = 0; i < toCopy.SLSANDApsim.Count; i++)
                { SLSANDApsim.Add(toCopy.SLSANDApsim[i]); }
    
            _boundaryLayerConductance = toCopy._boundaryLayerConductance;
        }
    }
    public List<double> THICKApsim
    {
        get { return this._THICKApsim; }
        set { this._THICKApsim= value; } 
    }
    public List<double> DEPTHApsim
    {
        get { return this._DEPTHApsim; }
        set { this._DEPTHApsim= value; } 
    }
    public List<double> BDApsim
    {
        get { return this._BDApsim; }
        set { this._BDApsim= value; } 
    }
    public List<double> CLAYApsim
    {
        get { return this._CLAYApsim; }
        set { this._CLAYApsim= value; } 
    }
    public List<double> SWApsim
    {
        get { return this._SWApsim; }
        set { this._SWApsim= value; } 
    }
    public List<double> soilTemp
    {
        get { return this._soilTemp; }
        set { this._soilTemp= value; } 
    }
    public List<double> newTemperature
    {
        get { return this._newTemperature; }
        set { this._newTemperature= value; } 
    }
    public List<double> minSoilTemp
    {
        get { return this._minSoilTemp; }
        set { this._minSoilTemp= value; } 
    }
    public List<double> maxSoilTemp
    {
        get { return this._maxSoilTemp; }
        set { this._maxSoilTemp= value; } 
    }
    public List<double> aveSoilTemp
    {
        get { return this._aveSoilTemp; }
        set { this._aveSoilTemp= value; } 
    }
    public List<double> morningSoilTemp
    {
        get { return this._morningSoilTemp; }
        set { this._morningSoilTemp= value; } 
    }
    public List<double> thermalCondPar1
    {
        get { return this._thermalCondPar1; }
        set { this._thermalCondPar1= value; } 
    }
    public List<double> thermalCondPar2
    {
        get { return this._thermalCondPar2; }
        set { this._thermalCondPar2= value; } 
    }
    public List<double> thermalCondPar3
    {
        get { return this._thermalCondPar3; }
        set { this._thermalCondPar3= value; } 
    }
    public List<double> thermalCondPar4
    {
        get { return this._thermalCondPar4; }
        set { this._thermalCondPar4= value; } 
    }
    public List<double> thermalConductivity
    {
        get { return this._thermalConductivity; }
        set { this._thermalConductivity= value; } 
    }
    public List<double> thermalConductance
    {
        get { return this._thermalConductance; }
        set { this._thermalConductance= value; } 
    }
    public List<double> heatStorage
    {
        get { return this._heatStorage; }
        set { this._heatStorage= value; } 
    }
    public List<double> volSpecHeatSoil
    {
        get { return this._volSpecHeatSoil; }
        set { this._volSpecHeatSoil= value; } 
    }
    public double maxTempYesterday
    {
        get { return this._maxTempYesterday; }
        set { this._maxTempYesterday= value; } 
    }
    public double minTempYesterday
    {
        get { return this._minTempYesterday; }
        set { this._minTempYesterday= value; } 
    }
    public List<double> SLCARBApsim
    {
        get { return this._SLCARBApsim; }
        set { this._SLCARBApsim= value; } 
    }
    public List<double> SLROCKApsim
    {
        get { return this._SLROCKApsim; }
        set { this._SLROCKApsim= value; } 
    }
    public List<double> SLSILTApsim
    {
        get { return this._SLSILTApsim; }
        set { this._SLSILTApsim= value; } 
    }
    public List<double> SLSANDApsim
    {
        get { return this._SLSANDApsim; }
        set { this._SLSANDApsim= value; } 
    }
    public double _boundaryLayerConductance
    {
        get { return this.__boundaryLayerConductance; }
        set { this.__boundaryLayerConductance= value; } 
    }
}