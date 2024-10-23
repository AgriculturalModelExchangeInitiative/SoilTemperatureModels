import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfacePartonSoilSWATHourlyPartonCExogenous
{
    private double AirTemperatureMinimum;
    private double DayLength;
    private double GlobalSolarRadiation;
    private double AirTemperatureMaximum;
    private Double [] VolumetricWaterContent;
    private double HourOfSunset;
    private double HourOfSunrise;
    
    public SurfacePartonSoilSWATHourlyPartonCExogenous() { }
    
    public SurfacePartonSoilSWATHourlyPartonCExogenous(SurfacePartonSoilSWATHourlyPartonCExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.AirTemperatureMinimum = toCopy.getAirTemperatureMinimum();
            this.DayLength = toCopy.getDayLength();
            this.GlobalSolarRadiation = toCopy.getGlobalSolarRadiation();
            this.AirTemperatureMaximum = toCopy.getAirTemperatureMaximum();
            VolumetricWaterContent = new Double[toCopy.getVolumetricWaterContent().length];
        for (int i = 0; i < toCopy.getVolumetricWaterContent().length; i++)
        {
            VolumetricWaterContent[i] = toCopy.getVolumetricWaterContent()[i];
        }
            this.HourOfSunset = toCopy.getHourOfSunset();
            this.HourOfSunrise = toCopy.getHourOfSunrise();
        }
    }
    public double getAirTemperatureMinimum()
    { return AirTemperatureMinimum; }

    public void setAirTemperatureMinimum(double _AirTemperatureMinimum)
    { this.AirTemperatureMinimum= _AirTemperatureMinimum; } 
    
    public double getDayLength()
    { return DayLength; }

    public void setDayLength(double _DayLength)
    { this.DayLength= _DayLength; } 
    
    public double getGlobalSolarRadiation()
    { return GlobalSolarRadiation; }

    public void setGlobalSolarRadiation(double _GlobalSolarRadiation)
    { this.GlobalSolarRadiation= _GlobalSolarRadiation; } 
    
    public double getAirTemperatureMaximum()
    { return AirTemperatureMaximum; }

    public void setAirTemperatureMaximum(double _AirTemperatureMaximum)
    { this.AirTemperatureMaximum= _AirTemperatureMaximum; } 
    
    public Double [] getVolumetricWaterContent()
    { return VolumetricWaterContent; }

    public void setVolumetricWaterContent(Double [] _VolumetricWaterContent)
    { this.VolumetricWaterContent= _VolumetricWaterContent; } 
    
    public double getHourOfSunset()
    { return HourOfSunset; }

    public void setHourOfSunset(double _HourOfSunset)
    { this.HourOfSunset= _HourOfSunset; } 
    
    public double getHourOfSunrise()
    { return HourOfSunrise; }

    public void setHourOfSunrise(double _HourOfSunrise)
    { this.HourOfSunrise= _HourOfSunrise; } 
    
}