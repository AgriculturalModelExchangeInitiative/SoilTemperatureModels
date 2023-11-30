import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfacePartonSoilSWATCExogenous
{
    private double DayLength;
    private double GlobalSolarRadiation;
    private double AboveGroundBiomass;
    private double AirTemperatureMinimum;
    private double AirTemperatureMaximum;
    private Double [] VolumetricWaterContent;
    
    public SurfacePartonSoilSWATCExogenous() { }
    
    public SurfacePartonSoilSWATCExogenous(SurfacePartonSoilSWATCExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.DayLength = toCopy.getDayLength();
            this.GlobalSolarRadiation = toCopy.getGlobalSolarRadiation();
            this.AboveGroundBiomass = toCopy.getAboveGroundBiomass();
            this.AirTemperatureMinimum = toCopy.getAirTemperatureMinimum();
            this.AirTemperatureMaximum = toCopy.getAirTemperatureMaximum();
            VolumetricWaterContent = new Double[toCopy.getVolumetricWaterContent().length];
        for (int i = 0; i < toCopy.getVolumetricWaterContent().length; i++)
        {
            VolumetricWaterContent[i] = toCopy.getVolumetricWaterContent()[i];
        }
        }
    }
    public double getDayLength()
    { return DayLength; }

    public void setDayLength(double _DayLength)
    { this.DayLength= _DayLength; } 
    
    public double getGlobalSolarRadiation()
    { return GlobalSolarRadiation; }

    public void setGlobalSolarRadiation(double _GlobalSolarRadiation)
    { this.GlobalSolarRadiation= _GlobalSolarRadiation; } 
    
    public double getAboveGroundBiomass()
    { return AboveGroundBiomass; }

    public void setAboveGroundBiomass(double _AboveGroundBiomass)
    { this.AboveGroundBiomass= _AboveGroundBiomass; } 
    
    public double getAirTemperatureMinimum()
    { return AirTemperatureMinimum; }

    public void setAirTemperatureMinimum(double _AirTemperatureMinimum)
    { this.AirTemperatureMinimum= _AirTemperatureMinimum; } 
    
    public double getAirTemperatureMaximum()
    { return AirTemperatureMaximum; }

    public void setAirTemperatureMaximum(double _AirTemperatureMaximum)
    { this.AirTemperatureMaximum= _AirTemperatureMaximum; } 
    
    public Double [] getVolumetricWaterContent()
    { return VolumetricWaterContent; }

    public void setVolumetricWaterContent(Double [] _VolumetricWaterContent)
    { this.VolumetricWaterContent= _VolumetricWaterContent; } 
    
}