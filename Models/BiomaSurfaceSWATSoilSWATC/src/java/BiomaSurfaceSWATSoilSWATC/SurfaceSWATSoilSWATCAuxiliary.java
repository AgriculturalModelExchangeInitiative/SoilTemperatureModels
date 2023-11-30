import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfaceSWATSoilSWATCAuxiliary
{
    private double AboveGroundBiomass;
    private double SurfaceSoilTemperature;
    
    public SurfaceSWATSoilSWATCAuxiliary() { }
    
    public SurfaceSWATSoilSWATCAuxiliary(SurfaceSWATSoilSWATCAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.AboveGroundBiomass = toCopy.getAboveGroundBiomass();
            this.SurfaceSoilTemperature = toCopy.getSurfaceSoilTemperature();
            this.SurfaceSoilTemperature = toCopy.getSurfaceSoilTemperature();
        }
    }
    public double getAboveGroundBiomass()
    { return AboveGroundBiomass; }

    public void setAboveGroundBiomass(double _AboveGroundBiomass)
    { this.AboveGroundBiomass= _AboveGroundBiomass; } 
    
    public double getSurfaceSoilTemperature()
    { return SurfaceSoilTemperature; }

    public void setSurfaceSoilTemperature(double _SurfaceSoilTemperature)
    { this.SurfaceSoilTemperature= _SurfaceSoilTemperature; } 
    
}