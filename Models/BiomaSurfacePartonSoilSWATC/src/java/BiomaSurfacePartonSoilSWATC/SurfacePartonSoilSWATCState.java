import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class SurfacePartonSoilSWATCState
{
    private Double AboveGroundBiomass;
    private Double [] VolumetricWaterContent;
    private Double [] LayerThickness;
    private Double [] BulkDensity;
    private Double SoilProfileDepth;
    private Double SurfaceSoilTemperature;
    private Double [] SoilTemperatureByLayers;
    
    public SurfacePartonSoilSWATCState() { }
    
    public SurfacePartonSoilSWATCState(SurfacePartonSoilSWATCState toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.AboveGroundBiomass = toCopy.getAboveGroundBiomass();
            VolumetricWaterContent = new Double[toCopy.getVolumetricWaterContent().length];
        for (int i = 0; i < toCopy.getVolumetricWaterContent().length; i++)
        {
            VolumetricWaterContent[i] = toCopy.getVolumetricWaterContent()[i];
        }
            LayerThickness = new Double[toCopy.getLayerThickness().length];
        for (int i = 0; i < toCopy.getLayerThickness().length; i++)
        {
            LayerThickness[i] = toCopy.getLayerThickness()[i];
        }
            BulkDensity = new Double[toCopy.getBulkDensity().length];
        for (int i = 0; i < toCopy.getBulkDensity().length; i++)
        {
            BulkDensity[i] = toCopy.getBulkDensity()[i];
        }
            this.SoilProfileDepth = toCopy.getSoilProfileDepth();
            this.SurfaceSoilTemperature = toCopy.getSurfaceSoilTemperature();
            SoilTemperatureByLayers = new Double[toCopy.getSoilTemperatureByLayers().length];
        for (int i = 0; i < toCopy.getSoilTemperatureByLayers().length; i++)
        {
            SoilTemperatureByLayers[i] = toCopy.getSoilTemperatureByLayers()[i];
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
    
    public Double [] getLayerThickness()
    { return LayerThickness; }

    public void setLayerThickness(Double [] _LayerThickness)
    { this.LayerThickness= _LayerThickness; } 
    
    public Double [] getBulkDensity()
    { return BulkDensity; }

    public void setBulkDensity(Double [] _BulkDensity)
    { this.BulkDensity= _BulkDensity; } 
    
    public Double getSoilProfileDepth()
    { return SoilProfileDepth; }

    public void setSoilProfileDepth(Double _SoilProfileDepth)
    { this.SoilProfileDepth= _SoilProfileDepth; } 
    
    public Double getSurfaceSoilTemperature()
    { return SurfaceSoilTemperature; }

    public void setSurfaceSoilTemperature(Double _SurfaceSoilTemperature)
    { this.SurfaceSoilTemperature= _SurfaceSoilTemperature; } 
    
    public Double [] getSoilTemperatureByLayers()
    { return SoilTemperatureByLayers; }

    public void setSoilTemperatureByLayers(Double [] _SoilTemperatureByLayers)
    { this.SoilTemperatureByLayers= _SoilTemperatureByLayers; } 
    
}