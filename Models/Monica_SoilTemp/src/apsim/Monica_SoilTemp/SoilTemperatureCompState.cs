using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// state variables class of the SoilTemperatureComp component
/// </summary>
public class SoilTemperatureCompState
{
    private double[] _V = new double[noOfTempLayers];
    private double[] _B = new double[noOfTempLayers];
    private double[] _volumeMatrix = new double[noOfTempLayers];
    private double[] _volumeMatrixOld = new double[noOfTempLayers];
    private double[] _matrixPrimaryDiagonal = new double[noOfTempLayers];
    private double[] _matrixSecondaryDiagonal = new double[noOfTempLayersPlus1];
    private double[] _heatConductivity = new double[noOfTempLayers];
    private double[] _heatConductivityMean = new double[noOfTempLayers];
    private double[] _heatCapacity = new double[noOfTempLayers];
    private double[] _solution = new double[noOfTempLayers];
    private double[] _matrixDiagonal = new double[noOfTempLayers];
    private double[] _matrixLowerTriangle = new double[noOfTempLayers];
    private double[] _heatFlow = new double[noOfTempLayers];
    private double _soilSurfaceTemperature;
    private double[] _soilTemperature = new double[22];
    private double _noSnowSoilSurfaceTemperature;

    /// <summary>
    /// Constructor SoilTemperatureCompState domain class
    /// </summary>
    public SoilTemperatureCompState() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public SoilTemperatureCompState(SoilTemperatureCompState toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            V = new double[noOfTempLayers];
        for (int i = 0; i < noOfTempLayers; i++)
        { V[i] = toCopy.V[i]; }
    
            B = new double[noOfTempLayers];
        for (int i = 0; i < noOfTempLayers; i++)
        { B[i] = toCopy.B[i]; }
    
            volumeMatrix = new double[noOfTempLayers];
        for (int i = 0; i < noOfTempLayers; i++)
        { volumeMatrix[i] = toCopy.volumeMatrix[i]; }
    
            volumeMatrixOld = new double[noOfTempLayers];
        for (int i = 0; i < noOfTempLayers; i++)
        { volumeMatrixOld[i] = toCopy.volumeMatrixOld[i]; }
    
            matrixPrimaryDiagonal = new double[noOfTempLayers];
        for (int i = 0; i < noOfTempLayers; i++)
        { matrixPrimaryDiagonal[i] = toCopy.matrixPrimaryDiagonal[i]; }
    
            matrixSecondaryDiagonal = new double[noOfTempLayersPlus1];
        for (int i = 0; i < noOfTempLayersPlus1; i++)
        { matrixSecondaryDiagonal[i] = toCopy.matrixSecondaryDiagonal[i]; }
    
            heatConductivity = new double[noOfTempLayers];
        for (int i = 0; i < noOfTempLayers; i++)
        { heatConductivity[i] = toCopy.heatConductivity[i]; }
    
            heatConductivityMean = new double[noOfTempLayers];
        for (int i = 0; i < noOfTempLayers; i++)
        { heatConductivityMean[i] = toCopy.heatConductivityMean[i]; }
    
            heatCapacity = new double[noOfTempLayers];
        for (int i = 0; i < noOfTempLayers; i++)
        { heatCapacity[i] = toCopy.heatCapacity[i]; }
    
            solution = new double[noOfTempLayers];
        for (int i = 0; i < noOfTempLayers; i++)
        { solution[i] = toCopy.solution[i]; }
    
            matrixDiagonal = new double[noOfTempLayers];
        for (int i = 0; i < noOfTempLayers; i++)
        { matrixDiagonal[i] = toCopy.matrixDiagonal[i]; }
    
            matrixLowerTriangle = new double[noOfTempLayers];
        for (int i = 0; i < noOfTempLayers; i++)
        { matrixLowerTriangle[i] = toCopy.matrixLowerTriangle[i]; }
    
            heatFlow = new double[noOfTempLayers];
        for (int i = 0; i < noOfTempLayers; i++)
        { heatFlow[i] = toCopy.heatFlow[i]; }
    
            soilSurfaceTemperature = toCopy.soilSurfaceTemperature;
            soilTemperature = new double[22];
        for (int i = 0; i < 22; i++)
        { soilTemperature[i] = toCopy.soilTemperature[i]; }
    
            noSnowSoilSurfaceTemperature = toCopy.noSnowSoilSurfaceTemperature;
        }
    }

    /// <summary>
    /// Gets and sets the V
    /// </summary>
    [Description("V")] 
    [Units("°C")] 
    public double[] V
    {
        get { return this._V; }
        set { this._V= value; } 
    }

    /// <summary>
    /// Gets and sets the B
    /// </summary>
    [Description("B")] 
    [Units("°C")] 
    public double[] B
    {
        get { return this._B; }
        set { this._B= value; } 
    }

    /// <summary>
    /// Gets and sets the volumeMatrix
    /// </summary>
    [Description("volumeMatrix")] 
    [Units("°C")] 
    public double[] volumeMatrix
    {
        get { return this._volumeMatrix; }
        set { this._volumeMatrix= value; } 
    }

    /// <summary>
    /// Gets and sets the volumeMatrixOld
    /// </summary>
    [Description("volumeMatrixOld")] 
    [Units("°C")] 
    public double[] volumeMatrixOld
    {
        get { return this._volumeMatrixOld; }
        set { this._volumeMatrixOld= value; } 
    }

    /// <summary>
    /// Gets and sets the matrixPrimaryDiagonal
    /// </summary>
    [Description("matrixPrimaryDiagonal")] 
    [Units("°C")] 
    public double[] matrixPrimaryDiagonal
    {
        get { return this._matrixPrimaryDiagonal; }
        set { this._matrixPrimaryDiagonal= value; } 
    }

    /// <summary>
    /// Gets and sets the matrixSecondaryDiagonal
    /// </summary>
    [Description("matrixSecondaryDiagonal")] 
    [Units("°C")] 
    public double[] matrixSecondaryDiagonal
    {
        get { return this._matrixSecondaryDiagonal; }
        set { this._matrixSecondaryDiagonal= value; } 
    }

    /// <summary>
    /// Gets and sets the heatConductivity
    /// </summary>
    [Description("heatConductivity")] 
    [Units("°C")] 
    public double[] heatConductivity
    {
        get { return this._heatConductivity; }
        set { this._heatConductivity= value; } 
    }

    /// <summary>
    /// Gets and sets the heatConductivityMean
    /// </summary>
    [Description("heatConductivityMean")] 
    [Units("°C")] 
    public double[] heatConductivityMean
    {
        get { return this._heatConductivityMean; }
        set { this._heatConductivityMean= value; } 
    }

    /// <summary>
    /// Gets and sets the heatCapacity
    /// </summary>
    [Description("heatCapacity")] 
    [Units("°C")] 
    public double[] heatCapacity
    {
        get { return this._heatCapacity; }
        set { this._heatCapacity= value; } 
    }

    /// <summary>
    /// Gets and sets the solution
    /// </summary>
    [Description("solution")] 
    [Units("°C")] 
    public double[] solution
    {
        get { return this._solution; }
        set { this._solution= value; } 
    }

    /// <summary>
    /// Gets and sets the matrixDiagonal
    /// </summary>
    [Description("matrixDiagonal")] 
    [Units("°C")] 
    public double[] matrixDiagonal
    {
        get { return this._matrixDiagonal; }
        set { this._matrixDiagonal= value; } 
    }

    /// <summary>
    /// Gets and sets the matrixLowerTriangle
    /// </summary>
    [Description("matrixLowerTriangle")] 
    [Units("°C")] 
    public double[] matrixLowerTriangle
    {
        get { return this._matrixLowerTriangle; }
        set { this._matrixLowerTriangle= value; } 
    }

    /// <summary>
    /// Gets and sets the heatFlow
    /// </summary>
    [Description("heatFlow")] 
    [Units("°C")] 
    public double[] heatFlow
    {
        get { return this._heatFlow; }
        set { this._heatFlow= value; } 
    }

    /// <summary>
    /// Gets and sets the soilSurfaceTemperature
    /// </summary>
    [Description("soilSurfaceTemperature")] 
    [Units("°C")] 
    public double soilSurfaceTemperature
    {
        get { return this._soilSurfaceTemperature; }
        set { this._soilSurfaceTemperature= value; } 
    }

    /// <summary>
    /// Gets and sets the soilTemperature next day
    /// </summary>
    [Description("soilTemperature next day")] 
    [Units("°C")] 
    public double[] soilTemperature
    {
        get { return this._soilTemperature; }
        set { this._soilTemperature= value; } 
    }

    /// <summary>
    /// Gets and sets the soilSurfaceTemperature without snow
    /// </summary>
    [Description("soilSurfaceTemperature without snow")] 
    [Units("°C")] 
    public double noSnowSoilSurfaceTemperature
    {
        get { return this._noSnowSoilSurfaceTemperature; }
        set { this._noSnowSoilSurfaceTemperature= value; } 
    }

}