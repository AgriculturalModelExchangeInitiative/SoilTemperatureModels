import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class SurfacePartonSoilSWATHourlyPartonCState
{
    private Double AboveGroundBiomass;
    private Double [] VolumetricWaterContent;
    private Double [] BulkDensity;
    private Double [] LayerThickness;
    private Double SoilProfileDepth;
    private Double [] Sand;
    private Double [] OrganicMatter;
    private Double [] Clay;
    private Double [] Silt;
    private Double SurfaceSoilTemperature;
    private Double [] SoilTemperatureByLayers;
    private Double [] HeatCapacity;
    private Double [] ThermalConductivity;
    private Double [] ThermalDiffusivity;
    private Double [] SoilTemperatureRangeByLayers;
    private Double [] SoilTemperatureMinimum;
    private Double [] SoilTemperatureMaximum;
    private Double [] SoilTemperatureByLayersHourly;
    
    public SurfacePartonSoilSWATHourlyPartonCState() { }
    
    public SurfacePartonSoilSWATHourlyPartonCState(SurfacePartonSoilSWATHourlyPartonCState toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.AboveGroundBiomass = toCopy.getAboveGroundBiomass();
            VolumetricWaterContent = new Double[toCopy.getVolumetricWaterContent().length];
        for (int i = 0; i < toCopy.getVolumetricWaterContent().length; i++)
        {
            VolumetricWaterContent[i] = toCopy.getVolumetricWaterContent()[i];
        }
            BulkDensity = new Double[toCopy.getBulkDensity().length];
        for (int i = 0; i < toCopy.getBulkDensity().length; i++)
        {
            BulkDensity[i] = toCopy.getBulkDensity()[i];
        }
            LayerThickness = new Double[toCopy.getLayerThickness().length];
        for (int i = 0; i < toCopy.getLayerThickness().length; i++)
        {
            LayerThickness[i] = toCopy.getLayerThickness()[i];
        }
            this.SoilProfileDepth = toCopy.getSoilProfileDepth();
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
            Clay = new Double[toCopy.getClay().length];
        for (int i = 0; i < toCopy.getClay().length; i++)
        {
            Clay[i] = toCopy.getClay()[i];
        }
            Silt = new Double[toCopy.getSilt().length];
        for (int i = 0; i < toCopy.getSilt().length; i++)
        {
            Silt[i] = toCopy.getSilt()[i];
        }
            this.SurfaceSoilTemperature = toCopy.getSurfaceSoilTemperature();
            SoilTemperatureByLayers = new Double[toCopy.getSoilTemperatureByLayers().length];
        for (int i = 0; i < toCopy.getSoilTemperatureByLayers().length; i++)
        {
            SoilTemperatureByLayers[i] = toCopy.getSoilTemperatureByLayers()[i];
        }
            HeatCapacity = new Double[toCopy.getHeatCapacity().length];
        for (int i = 0; i < toCopy.getHeatCapacity().length; i++)
        {
            HeatCapacity[i] = toCopy.getHeatCapacity()[i];
        }
            ThermalConductivity = new Double[toCopy.getThermalConductivity().length];
        for (int i = 0; i < toCopy.getThermalConductivity().length; i++)
        {
            ThermalConductivity[i] = toCopy.getThermalConductivity()[i];
        }
            ThermalDiffusivity = new Double[toCopy.getThermalDiffusivity().length];
        for (int i = 0; i < toCopy.getThermalDiffusivity().length; i++)
        {
            ThermalDiffusivity[i] = toCopy.getThermalDiffusivity()[i];
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
            SoilTemperatureByLayersHourly = new Double[toCopy.getSoilTemperatureByLayersHourly().length];
        for (int i = 0; i < toCopy.getSoilTemperatureByLayersHourly().length; i++)
        {
            SoilTemperatureByLayersHourly[i] = toCopy.getSoilTemperatureByLayersHourly()[i];
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
    
    public Double [] getBulkDensity()
    { return BulkDensity; }

    public void setBulkDensity(Double [] _BulkDensity)
    { this.BulkDensity= _BulkDensity; } 
    
    public Double [] getLayerThickness()
    { return LayerThickness; }

    public void setLayerThickness(Double [] _LayerThickness)
    { this.LayerThickness= _LayerThickness; } 
    
    public Double getSoilProfileDepth()
    { return SoilProfileDepth; }

    public void setSoilProfileDepth(Double _SoilProfileDepth)
    { this.SoilProfileDepth= _SoilProfileDepth; } 
    
    public Double [] getSand()
    { return Sand; }

    public void setSand(Double [] _Sand)
    { this.Sand= _Sand; } 
    
    public Double [] getOrganicMatter()
    { return OrganicMatter; }

    public void setOrganicMatter(Double [] _OrganicMatter)
    { this.OrganicMatter= _OrganicMatter; } 
    
    public Double [] getClay()
    { return Clay; }

    public void setClay(Double [] _Clay)
    { this.Clay= _Clay; } 
    
    public Double [] getSilt()
    { return Silt; }

    public void setSilt(Double [] _Silt)
    { this.Silt= _Silt; } 
    
    public Double getSurfaceSoilTemperature()
    { return SurfaceSoilTemperature; }

    public void setSurfaceSoilTemperature(Double _SurfaceSoilTemperature)
    { this.SurfaceSoilTemperature= _SurfaceSoilTemperature; } 
    
    public Double [] getSoilTemperatureByLayers()
    { return SoilTemperatureByLayers; }

    public void setSoilTemperatureByLayers(Double [] _SoilTemperatureByLayers)
    { this.SoilTemperatureByLayers= _SoilTemperatureByLayers; } 
    
    public Double [] getHeatCapacity()
    { return HeatCapacity; }

    public void setHeatCapacity(Double [] _HeatCapacity)
    { this.HeatCapacity= _HeatCapacity; } 
    
    public Double [] getThermalConductivity()
    { return ThermalConductivity; }

    public void setThermalConductivity(Double [] _ThermalConductivity)
    { this.ThermalConductivity= _ThermalConductivity; } 
    
    public Double [] getThermalDiffusivity()
    { return ThermalDiffusivity; }

    public void setThermalDiffusivity(Double [] _ThermalDiffusivity)
    { this.ThermalDiffusivity= _ThermalDiffusivity; } 
    
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
    
    public Double [] getSoilTemperatureByLayersHourly()
    { return SoilTemperatureByLayersHourly; }

    public void setSoilTemperatureByLayersHourly(Double [] _SoilTemperatureByLayersHourly)
    { this.SoilTemperatureByLayersHourly= _SoilTemperatureByLayersHourly; } 
    
}