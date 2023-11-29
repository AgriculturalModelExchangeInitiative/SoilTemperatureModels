import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfacePartonSoilSWATHourlyPartonCExogenous
{
    private Double AirTemperatureMaximum;
    private Double GlobalSolarRadiation;
    private Double AirTemperatureMinimum;
    private Double DayLength;
    private Double HourOfSunrise;
    private Double HourOfSunset;
    
    public SurfacePartonSoilSWATHourlyPartonCExogenous() { }
    
    public SurfacePartonSoilSWATHourlyPartonCExogenous(SurfacePartonSoilSWATHourlyPartonCExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.AirTemperatureMaximum = toCopy.getAirTemperatureMaximum();
            this.GlobalSolarRadiation = toCopy.getGlobalSolarRadiation();
            this.AirTemperatureMinimum = toCopy.getAirTemperatureMinimum();
            this.DayLength = toCopy.getDayLength();
            this.HourOfSunrise = toCopy.getHourOfSunrise();
            this.HourOfSunset = toCopy.getHourOfSunset();
        }
    }
    public Double getAirTemperatureMaximum()
    { return AirTemperatureMaximum; }

    public void setAirTemperatureMaximum(Double _AirTemperatureMaximum)
    { this.AirTemperatureMaximum= _AirTemperatureMaximum; } 
    
    public Double getGlobalSolarRadiation()
    { return GlobalSolarRadiation; }

    public void setGlobalSolarRadiation(Double _GlobalSolarRadiation)
    { this.GlobalSolarRadiation= _GlobalSolarRadiation; } 
    
    public Double getAirTemperatureMinimum()
    { return AirTemperatureMinimum; }

    public void setAirTemperatureMinimum(Double _AirTemperatureMinimum)
    { this.AirTemperatureMinimum= _AirTemperatureMinimum; } 
    
    public Double getDayLength()
    { return DayLength; }

    public void setDayLength(Double _DayLength)
    { this.DayLength= _DayLength; } 
    
    public Double getHourOfSunrise()
    { return HourOfSunrise; }

    public void setHourOfSunrise(Double _HourOfSunrise)
    { this.HourOfSunrise= _HourOfSunrise; } 
    
    public Double getHourOfSunset()
    { return HourOfSunset; }

    public void setHourOfSunset(Double _HourOfSunset)
    { this.HourOfSunset= _HourOfSunset; } 
    
}