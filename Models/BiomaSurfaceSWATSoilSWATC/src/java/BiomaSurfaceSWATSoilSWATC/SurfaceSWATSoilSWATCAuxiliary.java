import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfaceSWATSoilSWATCAuxiliary
{
    private Double AboveGroundBiomass;
    private Double [] VolumetricWaterContent;
    private Double SurfaceSoilTemperature;
    
    public SurfaceSWATSoilSWATCAuxiliary() { }
    
    public SurfaceSWATSoilSWATCAuxiliary(SurfaceSWATSoilSWATCAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.AboveGroundBiomass = toCopy.getAboveGroundBiomass();
            VolumetricWaterContent = new Double[toCopy.getVolumetricWaterContent().length];
        for (int i = 0; i < toCopy.getVolumetricWaterContent().length; i++)
        {
            VolumetricWaterContent[i] = toCopy.getVolumetricWaterContent()[i];
        }
            this.SurfaceSoilTemperature = toCopy.getSurfaceSoilTemperature();
            this.SurfaceSoilTemperature = toCopy.getSurfaceSoilTemperature();
        }
    }
    public Double getAboveGroundBiomass()
    { return AboveGroundBiomass; }

    public void setAboveGroundBiomass(Double _AboveGroundBiomass)
    { this.AboveGroundBiomass= _AboveGroundBiomass; } 
    
    public Double [] getVolumetricWaterContent()
    { return VolumetricWaterContent; }

    public void setVolumetricWaterContent(Double [] _VolumetricWaterContent)
    { this.VolumetricWaterContent= _VolumetricWaterContent; } 
    
    public Double getSurfaceSoilTemperature()
    { return SurfaceSoilTemperature; }

    public void setSurfaceSoilTemperature(Double _SurfaceSoilTemperature)
    { this.SurfaceSoilTemperature= _SurfaceSoilTemperature; } 
    
}