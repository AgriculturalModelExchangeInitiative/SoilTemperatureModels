import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class soil_tempState
{
    private Double temp_amp;
    private Double [] temp_profile;
    private Double [] layer_temp;
    private Double canopy_temp_avg;
    private Double [] prev_temp_profile;
    
    public soil_tempState() { }
    
    public soil_tempState(soil_tempState toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.temp_amp = toCopy.gettemp_amp();
            temp_profile = new Double[toCopy.gettemp_profile().length];
        for (int i = 0; i < toCopy.gettemp_profile().length; i++)
        {
            temp_profile[i] = toCopy.gettemp_profile()[i];
        }
            layer_temp = new Double[toCopy.getlayer_temp().length];
        for (int i = 0; i < toCopy.getlayer_temp().length; i++)
        {
            layer_temp[i] = toCopy.getlayer_temp()[i];
        }
            this.canopy_temp_avg = toCopy.getcanopy_temp_avg();
            prev_temp_profile = new Double[1];
        for (int i = 0; i < 1; i++)
        {
            prev_temp_profile[i] = toCopy.getprev_temp_profile()[i];
        }
        }
    }
    public Double gettemp_amp()
    { return temp_amp; }

    public void settemp_amp(Double _temp_amp)
    { this.temp_amp= _temp_amp; } 
    
    public Double [] gettemp_profile()
    { return temp_profile; }

    public void settemp_profile(Double [] _temp_profile)
    { this.temp_profile= _temp_profile; } 
    
    public Double [] getlayer_temp()
    { return layer_temp; }

    public void setlayer_temp(Double [] _layer_temp)
    { this.layer_temp= _layer_temp; } 
    
    public Double getcanopy_temp_avg()
    { return canopy_temp_avg; }

    public void setcanopy_temp_avg(Double _canopy_temp_avg)
    { this.canopy_temp_avg= _canopy_temp_avg; } 
    
    public Double [] getprev_temp_profile()
    { return prev_temp_profile; }

    public void setprev_temp_profile(Double [] _prev_temp_profile)
    { this.prev_temp_profile= _prev_temp_profile; } 
    
}