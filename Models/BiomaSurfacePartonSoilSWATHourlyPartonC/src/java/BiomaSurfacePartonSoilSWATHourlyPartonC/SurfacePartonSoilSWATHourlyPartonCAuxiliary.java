import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfacePartonSoilSWATHourlyPartonCAuxiliary
{
    private Double AboveGroundBiomass;
    private Double [] VolumetricWaterContent;
    private Double [] OrganicMatter;
    private Double [] Sand;
    private Double SurfaceSoilTemperature;
    private Double SurfaceTemperatureMinimum;
    private Double SurfaceTemperatureMaximum;
    private Double [] ThermalConductivity;
    private Double [] SoilTemperatureRangeByLayers;
    private Double [] SoilTemperatureMinimum;
    private Double [] SoilTemperatureMaximum;
    
    public SurfacePartonSoilSWATHourlyPartonCAuxiliary() { }
    
    public SurfacePartonSoilSWATHourlyPartonCAuxiliary(SurfacePartonSoilSWATHourlyPartonCAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.AboveGroundBiomass = toCopy.getAboveGroundBiomass();
            VolumetricWaterContent = new Double[toCopy.getVolumetricWaterContent().length];
        for (int i = 0; i < toCopy.getVolumetricWaterContent().length; i++)
        {
            VolumetricWaterContent[i] = toCopy.getVolumetricWaterContent()[i];
        }
            OrganicMatter = new Double[toCopy.getOrganicMatter().length];
        for (int i = 0; i < toCopy.getOrganicMatter().length; i++)
        {
            OrganicMatter[i] = toCopy.getOrganicMatter()[i];
        }
            Sand = new Double[toCopy.getSand().length];
        for (int i = 0; i < toCopy.getSand().length; i++)
        {
            Sand[i] = toCopy.getSand()[i];
        }
            this.SurfaceSoilTemperature = toCopy.getSurfaceSoilTemperature();
            this.SurfaceTemperatureMinimum = toCopy.getSurfaceTemperatureMinimum();
            this.SurfaceTemperatureMaximum = toCopy.getSurfaceTemperatureMaximum();
            ThermalConductivity = new Double[toCopy.getThermalConductivity().length];
        for (int i = 0; i < toCopy.getThermalConductivity().length; i++)
        {
            ThermalConductivity[i] = toCopy.getThermalConductivity()[i];
        }
            SoilTemperatureRangeByLayers = new Double[toCopy.getSoilTemperatureRangeByLayers().length];
        for (int i = 0; i < toCopy.getSoilTemperatureRangeByLayers().length; i++)
        {
            SoilTemperatureRangeByLayers[i] = toCopy.getSoilTemperatureRangeByLayers()[i];
        }
            SoilTemperatureMinimum = new Double[toCopy.getSoilTemperatureMinimum().length];
        for (int i = 0; i < toCopy.getSoilTemperatureMinimum().length; i++)
        {
            SoilTemperatureMinimum[i] = toCopy.getSoilTemperatureMinimum()[i];
        }
            SoilTemperatureMaximum = new Double[toCopy.getSoilTemperatureMaximum().length];
        for (int i = 0; i < toCopy.getSoilTemperatureMaximum().length; i++)
        {
            SoilTemperatureMaximum[i] = toCopy.getSoilTemperatureMaximum()[i];
        }
            this.SurfaceSoilTemperature = toCopy.getSurfaceSoilTemperature();
            this.SurfaceTemperatureMaximum = toCopy.getSurfaceTemperatureMaximum();
            this.SurfaceTemperatureMinimum = toCopy.getSurfaceTemperatureMinimum();
            ThermalConductivity = new Double[toCopy.getThermalConductivity().length];
        for (int i = 0; i < toCopy.getThermalConductivity().length; i++)
        {
            ThermalConductivity[i] = toCopy.getThermalConductivity()[i];
        }
            SoilTemperatureMaximum = new Double[toCopy.getSoilTemperatureMaximum().length];
        for (int i = 0; i < toCopy.getSoilTemperatureMaximum().length; i++)
        {
            SoilTemperatureMaximum[i] = toCopy.getSoilTemperatureMaximum()[i];
        }
            SoilTemperatureMinimum = new Double[toCopy.getSoilTemperatureMinimum().length];
        for (int i = 0; i < toCopy.getSoilTemperatureMinimum().length; i++)
        {
            SoilTemperatureMinimum[i] = toCopy.getSoilTemperatureMinimum()[i];
        }
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
    
    public Double [] getOrganicMatter()
    { return OrganicMatter; }

    public void setOrganicMatter(Double [] _OrganicMatter)
    { this.OrganicMatter= _OrganicMatter; } 
    
    public Double [] getSand()
    { return Sand; }

    public void setSand(Double [] _Sand)
    { this.Sand= _Sand; } 
    
    public Double getSurfaceSoilTemperature()
    { return SurfaceSoilTemperature; }

    public void setSurfaceSoilTemperature(Double _SurfaceSoilTemperature)
    { this.SurfaceSoilTemperature= _SurfaceSoilTemperature; } 
    
    public Double getSurfaceTemperatureMinimum()
    { return SurfaceTemperatureMinimum; }

    public void setSurfaceTemperatureMinimum(Double _SurfaceTemperatureMinimum)
    { this.SurfaceTemperatureMinimum= _SurfaceTemperatureMinimum; } 
    
    public Double getSurfaceTemperatureMaximum()
    { return SurfaceTemperatureMaximum; }

    public void setSurfaceTemperatureMaximum(Double _SurfaceTemperatureMaximum)
    { this.SurfaceTemperatureMaximum= _SurfaceTemperatureMaximum; } 
    
    public Double [] getThermalConductivity()
    { return ThermalConductivity; }

    public void setThermalConductivity(Double [] _ThermalConductivity)
    { this.ThermalConductivity= _ThermalConductivity; } 
    
    public Double [] getSoilTemperatureRangeByLayers()
    { return SoilTemperatureRangeByLayers; }

    public void setSoilTemperatureRangeByLayers(Double [] _SoilTemperatureRangeByLayers)
    { this.SoilTemperatureRangeByLayers= _SoilTemperatureRangeByLayers; } 
    
    public Double [] getSoilTemperatureMinimum()
    { return SoilTemperatureMinimum; }

    public void setSoilTemperatureMinimum(Double [] _SoilTemperatureMinimum)
    { this.SoilTemperatureMinimum= _SoilTemperatureMinimum; } 
    
    public Double [] getSoilTemperatureMaximum()
    { return SoilTemperatureMaximum; }

    public void setSoilTemperatureMaximum(Double [] _SoilTemperatureMaximum)
    { this.SoilTemperatureMaximum= _SoilTemperatureMaximum; } 
    
}