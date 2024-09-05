using System;
using System.Collections.Generic;

public class SoilTemperatureCampbellAuxiliary 
{
    private double[] _minSoilTemp = new double[NLAYR];
    
    /// <summary>
    /// Constructor of the SoilTemperatureCampbellAuxiliary component")
    /// </summary>  
    public SoilTemperatureCampbellAuxiliary() { }
    
    
    public SoilTemperatureCampbellAuxiliary(SoilTemperatureCampbellAuxiliary toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    minSoilTemp = new double[NLAYR];
        for (int i = 0; i < NLAYR; i++)
        { minSoilTemp[i] = toCopy.minSoilTemp[i]; }
    
    }
    }
    public double[] minSoilTemp
    {
        get { return this._minSoilTemp; }
        set { this._minSoilTemp= value; } 
    }
}