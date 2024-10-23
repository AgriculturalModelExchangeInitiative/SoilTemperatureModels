import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfacePartonSoilSWATCAuxiliary
{
    private double SurfaceTemperatureMinimum;
    private double SurfaceTemperatureMaximum;
    private double SurfaceSoilTemperature;
    
    public SurfacePartonSoilSWATCAuxiliary() { }
    
    public SurfacePartonSoilSWATCAuxiliary(SurfacePartonSoilSWATCAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.SurfaceTemperatureMinimum = toCopy.getSurfaceTemperatureMinimum();
            this.SurfaceTemperatureMaximum = toCopy.getSurfaceTemperatureMaximum();
            this.SurfaceSoilTemperature = toCopy.getSurfaceSoilTemperature();
            this.SurfaceSoilTemperature = toCopy.getSurfaceSoilTemperature();
        }
    }
    public double getSurfaceTemperatureMinimum()
    { return SurfaceTemperatureMinimum; }

    public void setSurfaceTemperatureMinimum(double _SurfaceTemperatureMinimum)
    { this.SurfaceTemperatureMinimum= _SurfaceTemperatureMinimum; } 
    
    public double getSurfaceTemperatureMaximum()
    { return SurfaceTemperatureMaximum; }

    public void setSurfaceTemperatureMaximum(double _SurfaceTemperatureMaximum)
    { this.SurfaceTemperatureMaximum= _SurfaceTemperatureMaximum; } 
    
    public double getSurfaceSoilTemperature()
    { return SurfaceSoilTemperature; }

    public void setSurfaceSoilTemperature(double _SurfaceSoilTemperature)
    { this.SurfaceSoilTemperature= _SurfaceSoilTemperature; } 
    
}