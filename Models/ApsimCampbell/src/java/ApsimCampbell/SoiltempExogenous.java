import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SoiltempExogenous
{
    private double weather_MaxT;
    private double weather_Radn;
    private double microClimate_CanopyHeight;
    private double weather_MinT;
    private Double [] physical_ParticleSizeClay;
    private double weather_Wind;
    private Double [] physical_ParticleSizeSand;
    private double waterBalance_Eos;
    private double weather_MeanT;
    private double weather_Latitude;
    private double weather_Amp;
    private double timestep;
    private double waterBalance_Salb;
    private Double [] physical_ParticleSizeSilt;
    private Integer clock_Today_DayOfYear;
    private double waterBalance_Eo;
    private Double [] waterBalance_SW;
    private double waterBalance_Es;
    private double weather_Tav;
    private Double [] physical_Rocks;
    private double weather_AirPressure;
    private Double [] organic_Carbon;
    
    public SoiltempExogenous() { }
    
    public SoiltempExogenous(SoiltempExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.weather_MaxT = toCopy.getweather_MaxT();
            this.weather_Radn = toCopy.getweather_Radn();
            this.microClimate_CanopyHeight = toCopy.getmicroClimate_CanopyHeight();
            this.weather_MinT = toCopy.getweather_MinT();
            physical_ParticleSizeClay = new Double[toCopy.getphysical_ParticleSizeClay().length];
        for (int i = 0; i < toCopy.getphysical_ParticleSizeClay().length; i++)
        {
            physical_ParticleSizeClay[i] = toCopy.getphysical_ParticleSizeClay()[i];
        }
            this.weather_Wind = toCopy.getweather_Wind();
            physical_ParticleSizeSand = new Double[toCopy.getphysical_ParticleSizeSand().length];
        for (int i = 0; i < toCopy.getphysical_ParticleSizeSand().length; i++)
        {
            physical_ParticleSizeSand[i] = toCopy.getphysical_ParticleSizeSand()[i];
        }
            this.waterBalance_Eos = toCopy.getwaterBalance_Eos();
            this.weather_MeanT = toCopy.getweather_MeanT();
            this.weather_Latitude = toCopy.getweather_Latitude();
            this.weather_Amp = toCopy.getweather_Amp();
            this.timestep = toCopy.gettimestep();
            this.waterBalance_Salb = toCopy.getwaterBalance_Salb();
            physical_ParticleSizeSilt = new Double[toCopy.getphysical_ParticleSizeSilt().length];
        for (int i = 0; i < toCopy.getphysical_ParticleSizeSilt().length; i++)
        {
            physical_ParticleSizeSilt[i] = toCopy.getphysical_ParticleSizeSilt()[i];
        }
            this.clock_Today_DayOfYear = toCopy.getclock_Today_DayOfYear();
            this.waterBalance_Eo = toCopy.getwaterBalance_Eo();
            waterBalance_SW = new Double[toCopy.getwaterBalance_SW().length];
        for (int i = 0; i < toCopy.getwaterBalance_SW().length; i++)
        {
            waterBalance_SW[i] = toCopy.getwaterBalance_SW()[i];
        }
            this.waterBalance_Es = toCopy.getwaterBalance_Es();
            this.weather_Tav = toCopy.getweather_Tav();
            physical_Rocks = new Double[toCopy.getphysical_Rocks().length];
        for (int i = 0; i < toCopy.getphysical_Rocks().length; i++)
        {
            physical_Rocks[i] = toCopy.getphysical_Rocks()[i];
        }
            this.weather_AirPressure = toCopy.getweather_AirPressure();
            organic_Carbon = new Double[toCopy.getorganic_Carbon().length];
        for (int i = 0; i < toCopy.getorganic_Carbon().length; i++)
        {
            organic_Carbon[i] = toCopy.getorganic_Carbon()[i];
        }
        }
    }
    public double getweather_MaxT()
    { return weather_MaxT; }

    public void setweather_MaxT(double _weather_MaxT)
    { this.weather_MaxT= _weather_MaxT; } 
    
    public double getweather_Radn()
    { return weather_Radn; }

    public void setweather_Radn(double _weather_Radn)
    { this.weather_Radn= _weather_Radn; } 
    
    public double getmicroClimate_CanopyHeight()
    { return microClimate_CanopyHeight; }

    public void setmicroClimate_CanopyHeight(double _microClimate_CanopyHeight)
    { this.microClimate_CanopyHeight= _microClimate_CanopyHeight; } 
    
    public double getweather_MinT()
    { return weather_MinT; }

    public void setweather_MinT(double _weather_MinT)
    { this.weather_MinT= _weather_MinT; } 
    
    public Double [] getphysical_ParticleSizeClay()
    { return physical_ParticleSizeClay; }

    public void setphysical_ParticleSizeClay(Double [] _physical_ParticleSizeClay)
    { this.physical_ParticleSizeClay= _physical_ParticleSizeClay; } 
    
    public double getweather_Wind()
    { return weather_Wind; }

    public void setweather_Wind(double _weather_Wind)
    { this.weather_Wind= _weather_Wind; } 
    
    public Double [] getphysical_ParticleSizeSand()
    { return physical_ParticleSizeSand; }

    public void setphysical_ParticleSizeSand(Double [] _physical_ParticleSizeSand)
    { this.physical_ParticleSizeSand= _physical_ParticleSizeSand; } 
    
    public double getwaterBalance_Eos()
    { return waterBalance_Eos; }

    public void setwaterBalance_Eos(double _waterBalance_Eos)
    { this.waterBalance_Eos= _waterBalance_Eos; } 
    
    public double getweather_MeanT()
    { return weather_MeanT; }

    public void setweather_MeanT(double _weather_MeanT)
    { this.weather_MeanT= _weather_MeanT; } 
    
    public double getweather_Latitude()
    { return weather_Latitude; }

    public void setweather_Latitude(double _weather_Latitude)
    { this.weather_Latitude= _weather_Latitude; } 
    
    public double getweather_Amp()
    { return weather_Amp; }

    public void setweather_Amp(double _weather_Amp)
    { this.weather_Amp= _weather_Amp; } 
    
    public double gettimestep()
    { return timestep; }

    public void settimestep(double _timestep)
    { this.timestep= _timestep; } 
    
    public double getwaterBalance_Salb()
    { return waterBalance_Salb; }

    public void setwaterBalance_Salb(double _waterBalance_Salb)
    { this.waterBalance_Salb= _waterBalance_Salb; } 
    
    public Double [] getphysical_ParticleSizeSilt()
    { return physical_ParticleSizeSilt; }

    public void setphysical_ParticleSizeSilt(Double [] _physical_ParticleSizeSilt)
    { this.physical_ParticleSizeSilt= _physical_ParticleSizeSilt; } 
    
    public Integer getclock_Today_DayOfYear()
    { return clock_Today_DayOfYear; }

    public void setclock_Today_DayOfYear(Integer _clock_Today_DayOfYear)
    { this.clock_Today_DayOfYear= _clock_Today_DayOfYear; } 
    
    public double getwaterBalance_Eo()
    { return waterBalance_Eo; }

    public void setwaterBalance_Eo(double _waterBalance_Eo)
    { this.waterBalance_Eo= _waterBalance_Eo; } 
    
    public Double [] getwaterBalance_SW()
    { return waterBalance_SW; }

    public void setwaterBalance_SW(Double [] _waterBalance_SW)
    { this.waterBalance_SW= _waterBalance_SW; } 
    
    public double getwaterBalance_Es()
    { return waterBalance_Es; }

    public void setwaterBalance_Es(double _waterBalance_Es)
    { this.waterBalance_Es= _waterBalance_Es; } 
    
    public double getweather_Tav()
    { return weather_Tav; }

    public void setweather_Tav(double _weather_Tav)
    { this.weather_Tav= _weather_Tav; } 
    
    public Double [] getphysical_Rocks()
    { return physical_Rocks; }

    public void setphysical_Rocks(Double [] _physical_Rocks)
    { this.physical_Rocks= _physical_Rocks; } 
    
    public double getweather_AirPressure()
    { return weather_AirPressure; }

    public void setweather_AirPressure(double _weather_AirPressure)
    { this.weather_AirPressure= _weather_AirPressure; } 
    
    public Double [] getorganic_Carbon()
    { return organic_Carbon; }

    public void setorganic_Carbon(Double [] _organic_Carbon)
    { this.organic_Carbon= _organic_Carbon; } 
    
}