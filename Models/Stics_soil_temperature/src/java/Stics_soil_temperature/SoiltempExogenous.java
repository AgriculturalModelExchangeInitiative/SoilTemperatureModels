import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SoiltempExogenous
{
    private Double max_temp;
    private Double min_temp;
    private Double prev_canopy_temp;
    private Double min_air_temp;
    
    public SoiltempExogenous() { }
    
    public SoiltempExogenous(SoiltempExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.max_temp = toCopy.getmax_temp();
            this.min_temp = toCopy.getmin_temp();
            this.prev_canopy_temp = toCopy.getprev_canopy_temp();
            this.min_air_temp = toCopy.getmin_air_temp();
        }
    }
    public Double getmax_temp()
    { return max_temp; }

    public void setmax_temp(Double _max_temp)
    { this.max_temp= _max_temp; } 
    
    public Double getmin_temp()
    { return min_temp; }

    public void setmin_temp(Double _min_temp)
    { this.min_temp= _min_temp; } 
    
    public Double getprev_canopy_temp()
    { return prev_canopy_temp; }

    public void setprev_canopy_temp(Double _prev_canopy_temp)
    { this.prev_canopy_temp= _prev_canopy_temp; } 
    
    public Double getmin_air_temp()
    { return min_air_temp; }

    public void setmin_air_temp(Double _min_air_temp)
    { this.min_air_temp= _min_air_temp; } 
    
}