import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class SoilTemperatureState
{
    private Double minTSoil;
    private Double deepLayerT;
    private Double maxTSoil;
    private Double [] hourlySoilT;
    
    public SoilTemperatureState() { }
    
    public SoilTemperatureState(SoilTemperatureState toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.minTSoil = toCopy.getminTSoil();
            this.deepLayerT = toCopy.getdeepLayerT();
            this.maxTSoil = toCopy.getmaxTSoil();
            hourlySoilT = new Double[24];
        for (int i = 0; i < 24; i++)
        {
            hourlySoilT[i] = toCopy.gethourlySoilT()[i];
        }
        }
    }
    public Double getminTSoil()
    { return minTSoil; }

    public void setminTSoil(Double _minTSoil)
    { this.minTSoil= _minTSoil; } 
    
    public Double getdeepLayerT()
    { return deepLayerT; }

    public void setdeepLayerT(Double _deepLayerT)
    { this.deepLayerT= _deepLayerT; } 
    
    public Double getmaxTSoil()
    { return maxTSoil; }

    public void setmaxTSoil(Double _maxTSoil)
    { this.maxTSoil= _maxTSoil; } 
    
    public Double [] gethourlySoilT()
    { return hourlySoilT; }

    public void sethourlySoilT(Double [] _hourlySoilT)
    { this.hourlySoilT= _hourlySoilT; } 
    
}