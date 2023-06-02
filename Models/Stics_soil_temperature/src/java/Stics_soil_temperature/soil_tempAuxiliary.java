import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class soil_tempAuxiliary
{
    private Double temp_wave_freq;
    private Double therm_diff;
    
    public soil_tempAuxiliary() { }
    
    public soil_tempAuxiliary(soil_tempAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.temp_wave_freq = toCopy.gettemp_wave_freq();
            this.therm_diff = toCopy.gettherm_diff();
        }
    }
    public Double gettemp_wave_freq()
    { return temp_wave_freq; }

    public void settemp_wave_freq(Double _temp_wave_freq)
    { this.temp_wave_freq= _temp_wave_freq; } 
    
    public Double gettherm_diff()
    { return therm_diff; }

    public void settherm_diff(Double _therm_diff)
    { this.therm_diff= _therm_diff; } 
    
}