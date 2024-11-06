using System;
using System.Collections.Generic;

public class SoilTemperatureAuxiliary 
{
    private double[] _SoilTempArray;
    private double[] _iSoilTempArray;
    private double _SnowIsolationIndex;
    private double _iSoilSurfaceTemperature;
    
    /// <summary>
    /// Constructor of the SoilTemperatureAuxiliary component")
    /// </summary>  
    public SoilTemperatureAuxiliary() { }
    
    
    public SoilTemperatureAuxiliary(SoilTemperatureAuxiliary toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            SoilTempArray = new double[toCopy.SoilTempArray.Length];
            for (int i = 0; i < toCopy.SoilTempArray.Length; i++)
                { SoilTempArray[i] = toCopy.SoilTempArray[i]; }
    
            iSoilTempArray = new double[toCopy.iSoilTempArray.Length];
            for (int i = 0; i < toCopy.iSoilTempArray.Length; i++)
                { iSoilTempArray[i] = toCopy.iSoilTempArray[i]; }
    
            SnowIsolationIndex = toCopy.SnowIsolationIndex;
            iSoilSurfaceTemperature = toCopy.iSoilSurfaceTemperature;
        }
    }
    public double[] SoilTempArray
    {
        get { return this._SoilTempArray; }
        set { this._SoilTempArray= value; } 
    }
    public double[] iSoilTempArray
    {
        get { return this._iSoilTempArray; }
        set { this._iSoilTempArray= value; } 
    }
    public double SnowIsolationIndex
    {
        get { return this._SnowIsolationIndex; }
        set { this._SnowIsolationIndex= value; } 
    }
    public double iSoilSurfaceTemperature
    {
        get { return this._iSoilSurfaceTemperature; }
        set { this._iSoilSurfaceTemperature= value; } 
    }
}