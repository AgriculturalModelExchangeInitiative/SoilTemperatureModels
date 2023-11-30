import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfacePartonSoilSWATHourlyPartonCAuxiliary
{
    private double AboveGroundBiomass;
    private Double [] Sand;
    private Double [] OrganicMatter;
    private double SurfaceSoilTemperature;
    private double SurfaceTemperatureMinimum;
    private double SurfaceTemperatureMaximum;
    private Double [] SoilTemperatureMinimum;
    private Double [] SoilTemperatureMaximum;
    private Double [] ThermalDiffusivity;
    private Double [] SoilTemperatureByLayers;
    
    public SurfacePartonSoilSWATHourlyPartonCAuxiliary() { }
    
    public SurfacePartonSoilSWATHourlyPartonCAuxiliary(SurfacePartonSoilSWATHourlyPartonCAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.AboveGroundBiomass = toCopy.getAboveGroundBiomass();
            Sand = new Double[toCopy.getSand().length];
        for (int i = 0; i < toCopy.getSand().length; i++)
        {
            Sand[i] = toCopy.getSand()[i];
        }
            OrganicMatter = new Double[toCopy.getOrganicMatter().length];
        for (int i = 0; i < toCopy.getOrganicMatter().length; i++)
        {
            OrganicMatter[i] = toCopy.getOrganicMatter()[i];
        }
            this.SurfaceSoilTemperature = toCopy.getSurfaceSoilTemperature();
            this.SurfaceTemperatureMinimum = toCopy.getSurfaceTemperatureMinimum();
            this.SurfaceTemperatureMaximum = toCopy.getSurfaceTemperatureMaximum();
            this.SurfaceSoilTemperature = toCopy.getSurfaceSoilTemperature();
            this.SurfaceTemperatureMaximum = toCopy.getSurfaceTemperatureMaximum();
            this.SurfaceTemperatureMinimum = toCopy.getSurfaceTemperatureMinimum();
        }
    }
    public double getAboveGroundBiomass()
    { return AboveGroundBiomass; }

    public void setAboveGroundBiomass(double _AboveGroundBiomass)
    { this.AboveGroundBiomass= _AboveGroundBiomass; } 
    
    public Double [] getSand()
    { return Sand; }

    public void setSand(Double [] _Sand)
    { this.Sand= _Sand; } 

    public Double [] getSoilTemperatureMinimum()
    { return SoilTemperatureMinimum; }

    public void setSoilTemperatureMinimum(Double [] _SoilTemperatureMinimum)
    { this.SoilTemperatureMinimum= _SoilTemperatureMinimum; }


    public Double [] getSoilTemperatureMaximum()
    { return SoilTemperatureMaximum; }

    public void setSoilTemperatureMaximum(Double [] _SoilTemperatureMaximum)
    { this.SoilTemperatureMaximum= _SoilTemperatureMaximum; }
    
    public Double [] getOrganicMatter()
    { return OrganicMatter; }

    public void setOrganicMatter(Double [] _OrganicMatter)
    { this.OrganicMatter= _OrganicMatter; } 
    
    public double getSurfaceSoilTemperature()
    { return SurfaceSoilTemperature; }

    public void setSurfaceSoilTemperature(double _SurfaceSoilTemperature)
    { this.SurfaceSoilTemperature= _SurfaceSoilTemperature; } 
    
    public double getSurfaceTemperatureMinimum()
    { return SurfaceTemperatureMinimum; }

    public void setSurfaceTemperatureMinimum(double _SurfaceTemperatureMinimum)
    { this.SurfaceTemperatureMinimum= _SurfaceTemperatureMinimum; } 
    
    public double getSurfaceTemperatureMaximum()
    { return SurfaceTemperatureMaximum; }

    public void setSurfaceTemperatureMaximum(double _SurfaceTemperatureMaximum)
    { this.SurfaceTemperatureMaximum= _SurfaceTemperatureMaximum; } 

    public Double [] getThermalDiffusivity()
    { return ThermalDiffusivity; }

    public void setThermalDiffusivity(Double [] _ThermalDiffusivity)
    { this.Sand= _ThermalDiffusivity; } 

    public Double [] getSoilTemperatureByLayers()
    { return Sand; }

    public void setSoilTemperatureByLayers(Double [] _SoilTemperatureByLayers)
    { this.Sand= _SoilTemperatureByLayers; } 
    
}