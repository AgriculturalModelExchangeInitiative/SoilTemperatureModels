import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class SoilTemperatureCompState
{
    private Double [] V;
    private Double [] B;
    private Double [] volumeMatrix;
    private Double [] volumeMatrixOld;
    private Double [] matrixPrimaryDiagonal;
    private Double [] matrixSecondaryDiagonal;
    private Double [] heatConductivity;
    private Double [] heatConductivityMean;
    private Double [] heatCapacity;
    private Double [] solution;
    private Double [] matrixDiagonal;
    private Double [] matrixLowerTriangle;
    private Double [] heatFlow;
    private Double soilSurfaceTemperature;
    private Double [] soilTemperature;
    private Double noSnowSoilSurfaceTemperature;
    
    public SoilTemperatureCompState() { }
    
    public SoilTemperatureCompState(SoilTemperatureCompState toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            V = new Double[22];
        for (int i = 0; i < 22; i++)
        {
            V[i] = toCopy.getV()[i];
        }
            B = new Double[22];
        for (int i = 0; i < 22; i++)
        {
            B[i] = toCopy.getB()[i];
        }
            volumeMatrix = new Double[22];
        for (int i = 0; i < 22; i++)
        {
            volumeMatrix[i] = toCopy.getvolumeMatrix()[i];
        }
            volumeMatrixOld = new Double[22];
        for (int i = 0; i < 22; i++)
        {
            volumeMatrixOld[i] = toCopy.getvolumeMatrixOld()[i];
        }
            matrixPrimaryDiagonal = new Double[22];
        for (int i = 0; i < 22; i++)
        {
            matrixPrimaryDiagonal[i] = toCopy.getmatrixPrimaryDiagonal()[i];
        }
            matrixSecondaryDiagonal = new Double[23];
        for (int i = 0; i < 23; i++)
        {
            matrixSecondaryDiagonal[i] = toCopy.getmatrixSecondaryDiagonal()[i];
        }
            heatConductivity = new Double[22];
        for (int i = 0; i < 22; i++)
        {
            heatConductivity[i] = toCopy.getheatConductivity()[i];
        }
            heatConductivityMean = new Double[22];
        for (int i = 0; i < 22; i++)
        {
            heatConductivityMean[i] = toCopy.getheatConductivityMean()[i];
        }
            heatCapacity = new Double[22];
        for (int i = 0; i < 22; i++)
        {
            heatCapacity[i] = toCopy.getheatCapacity()[i];
        }
            solution = new Double[22];
        for (int i = 0; i < 22; i++)
        {
            solution[i] = toCopy.getsolution()[i];
        }
            matrixDiagonal = new Double[22];
        for (int i = 0; i < 22; i++)
        {
            matrixDiagonal[i] = toCopy.getmatrixDiagonal()[i];
        }
            matrixLowerTriangle = new Double[22];
        for (int i = 0; i < 22; i++)
        {
            matrixLowerTriangle[i] = toCopy.getmatrixLowerTriangle()[i];
        }
            heatFlow = new Double[22];
        for (int i = 0; i < 22; i++)
        {
            heatFlow[i] = toCopy.getheatFlow()[i];
        }
            this.soilSurfaceTemperature = toCopy.getsoilSurfaceTemperature();
            soilTemperature = new Double[22];
        for (int i = 0; i < 22; i++)
        {
            soilTemperature[i] = toCopy.getsoilTemperature()[i];
        }
            this.noSnowSoilSurfaceTemperature = toCopy.getnoSnowSoilSurfaceTemperature();
        }
    }
    public Double [] getV()
    { return V; }

    public void setV(Double [] _V)
    { this.V= _V; } 
    
    public Double [] getB()
    { return B; }

    public void setB(Double [] _B)
    { this.B= _B; } 
    
    public Double [] getvolumeMatrix()
    { return volumeMatrix; }

    public void setvolumeMatrix(Double [] _volumeMatrix)
    { this.volumeMatrix= _volumeMatrix; } 
    
    public Double [] getvolumeMatrixOld()
    { return volumeMatrixOld; }

    public void setvolumeMatrixOld(Double [] _volumeMatrixOld)
    { this.volumeMatrixOld= _volumeMatrixOld; } 
    
    public Double [] getmatrixPrimaryDiagonal()
    { return matrixPrimaryDiagonal; }

    public void setmatrixPrimaryDiagonal(Double [] _matrixPrimaryDiagonal)
    { this.matrixPrimaryDiagonal= _matrixPrimaryDiagonal; } 
    
    public Double [] getmatrixSecondaryDiagonal()
    { return matrixSecondaryDiagonal; }

    public void setmatrixSecondaryDiagonal(Double [] _matrixSecondaryDiagonal)
    { this.matrixSecondaryDiagonal= _matrixSecondaryDiagonal; } 
    
    public Double [] getheatConductivity()
    { return heatConductivity; }

    public void setheatConductivity(Double [] _heatConductivity)
    { this.heatConductivity= _heatConductivity; } 
    
    public Double [] getheatConductivityMean()
    { return heatConductivityMean; }

    public void setheatConductivityMean(Double [] _heatConductivityMean)
    { this.heatConductivityMean= _heatConductivityMean; } 
    
    public Double [] getheatCapacity()
    { return heatCapacity; }

    public void setheatCapacity(Double [] _heatCapacity)
    { this.heatCapacity= _heatCapacity; } 
    
    public Double [] getsolution()
    { return solution; }

    public void setsolution(Double [] _solution)
    { this.solution= _solution; } 
    
    public Double [] getmatrixDiagonal()
    { return matrixDiagonal; }

    public void setmatrixDiagonal(Double [] _matrixDiagonal)
    { this.matrixDiagonal= _matrixDiagonal; } 
    
    public Double [] getmatrixLowerTriangle()
    { return matrixLowerTriangle; }

    public void setmatrixLowerTriangle(Double [] _matrixLowerTriangle)
    { this.matrixLowerTriangle= _matrixLowerTriangle; } 
    
    public Double [] getheatFlow()
    { return heatFlow; }

    public void setheatFlow(Double [] _heatFlow)
    { this.heatFlow= _heatFlow; } 
    
    public Double getsoilSurfaceTemperature()
    { return soilSurfaceTemperature; }

    public void setsoilSurfaceTemperature(Double _soilSurfaceTemperature)
    { this.soilSurfaceTemperature= _soilSurfaceTemperature; } 
    
    public Double [] getsoilTemperature()
    { return soilTemperature; }

    public void setsoilTemperature(Double [] _soilTemperature)
    { this.soilTemperature= _soilTemperature; } 
    
    public Double getnoSnowSoilSurfaceTemperature()
    { return noSnowSoilSurfaceTemperature; }

    public void setnoSnowSoilSurfaceTemperature(Double _noSnowSoilSurfaceTemperature)
    { this.noSnowSoilSurfaceTemperature= _noSnowSoilSurfaceTemperature; } 
    
}