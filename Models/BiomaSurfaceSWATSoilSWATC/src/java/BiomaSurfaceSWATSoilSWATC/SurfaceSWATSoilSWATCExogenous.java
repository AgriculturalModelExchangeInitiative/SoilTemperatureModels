import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfaceSWATSoilSWATCExogenous
{
    private double AirTemperatureMaximum;
    private double AirTemperatureMinimum;
    private double GlobalSolarRadiation;
    private double WaterEquivalentOfSnowPack;
    private double Albedo;
    private Double [] VolumetricWaterContent;
    
    public SurfaceSWATSoilSWATCExogenous() { }
    
    public SurfaceSWATSoilSWATCExogenous(SurfaceSWATSoilSWATCExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.AirTemperatureMaximum = toCopy.getAirTemperatureMaximum();
            this.AirTemperatureMinimum = toCopy.getAirTemperatureMinimum();
            this.GlobalSolarRadiation = toCopy.getGlobalSolarRadiation();
            this.WaterEquivalentOfSnowPack = toCopy.getWaterEquivalentOfSnowPack();
            this.Albedo = toCopy.getAlbedo();
            VolumetricWaterContent = new Double[toCopy.getVolumetricWaterContent().length];
        for (int i = 0; i < toCopy.getVolumetricWaterContent().length; i++)
        {
            VolumetricWaterContent[i] = toCopy.getVolumetricWaterContent()[i];
        }
        }
    }
    public double getAirTemperatureMaximum()
    { return AirTemperatureMaximum; }

    public void setAirTemperatureMaximum(double _AirTemperatureMaximum)
    { this.AirTemperatureMaximum= _AirTemperatureMaximum; } 
    
    public double getAirTemperatureMinimum()
    { return AirTemperatureMinimum; }

    public void setAirTemperatureMinimum(double _AirTemperatureMinimum)
    { this.AirTemperatureMinimum= _AirTemperatureMinimum; } 
    
    public double getGlobalSolarRadiation()
    { return GlobalSolarRadiation; }

    public void setGlobalSolarRadiation(double _GlobalSolarRadiation)
    { this.GlobalSolarRadiation= _GlobalSolarRadiation; } 
    
    public double getWaterEquivalentOfSnowPack()
    { return WaterEquivalentOfSnowPack; }

    public void setWaterEquivalentOfSnowPack(double _WaterEquivalentOfSnowPack)
    { this.WaterEquivalentOfSnowPack= _WaterEquivalentOfSnowPack; } 
    
    public double getAlbedo()
    { return Albedo; }

    public void setAlbedo(double _Albedo)
    { this.Albedo= _Albedo; } 
    
    public Double [] getVolumetricWaterContent()
    { return VolumetricWaterContent; }

    public void setVolumetricWaterContent(Double [] _VolumetricWaterContent)
    { this.VolumetricWaterContent= _VolumetricWaterContent; } 
    
}