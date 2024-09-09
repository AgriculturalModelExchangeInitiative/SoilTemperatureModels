using System;
using System.Collections.Generic;

public class CampbellAuxiliary 
{
    private double[] _minSoilTemp;
    
    /// <summary>
    /// Constructor of the campbellAuxiliary component")
    /// </summary>  
    public campbellAuxiliary() { }
    
    
    public campbellAuxiliary(campbellAuxiliary toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            minSoilTemp = new double[toCopy.minSoilTemp.Length];
            for (int i = 0; i < toCopy.minSoilTemp.Length; i++)
                { minSoilTemp[i] = toCopy.minSoilTemp[i]; }
    
        }
    }
    public double[] minSoilTemp
    {
        get { return this._minSoilTemp; }
        set { this._minSoilTemp= value; } 
    }
}