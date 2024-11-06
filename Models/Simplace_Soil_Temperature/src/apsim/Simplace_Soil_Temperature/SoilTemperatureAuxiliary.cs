using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// auxiliary variables class of the SoilTemperature component
/// </summary>
public class SoilTemperatureAuxiliary
{
    private double[] _SoilTempArray;
    private double[] _iSoilTempArray;
    private double _SnowIsolationIndex;
    private double _iSoilSurfaceTemperature;

    /// <summary>
    /// Constructor SoilTemperatureAuxiliary domain class
    /// </summary>
    public SoilTemperatureAuxiliary() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
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

    /// <summary>
    /// Gets and sets the Soil Temp array of last day
    /// </summary>
    [Description("Soil Temp array of last day")] 
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius")] 
    public double[] SoilTempArray
    {
        get { return this._SoilTempArray; }
        set { this._SoilTempArray= value; } 
    }

    /// <summary>
    /// Gets and sets the Soil Temp array of last day
    /// </summary>
    [Description("Soil Temp array of last day")] 
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius")] 
    public double[] iSoilTempArray
    {
        get { return this._iSoilTempArray; }
        set { this._iSoilTempArray= value; } 
    }

    /// <summary>
    /// Gets and sets the Snow isolation index
    /// </summary>
    [Description("Snow isolation index")] 
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/one")] 
    public double SnowIsolationIndex
    {
        get { return this._SnowIsolationIndex; }
        set { this._SnowIsolationIndex= value; } 
    }

    /// <summary>
    /// Gets and sets the Temperature at soil surface
    /// </summary>
    [Description("Temperature at soil surface")] 
    [Units("http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius")] 
    public double iSoilSurfaceTemperature
    {
        get { return this._iSoilSurfaceTemperature; }
        set { this._iSoilSurfaceTemperature= value; } 
    }

}