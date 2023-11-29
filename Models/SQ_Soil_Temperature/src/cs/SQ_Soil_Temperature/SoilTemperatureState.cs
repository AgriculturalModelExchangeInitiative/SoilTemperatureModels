using System;
using System.Collections.Generic;
public class SoilTemperatureState 
{
    private double _minTSoil;
    private double _deepLayerT;
    private double _maxTSoil;
    private double[] _hourlySoilT = new double[24];
    
        public SoilTemperatureState() { }
    
    
    public SoilTemperatureState(SoilTemperatureState toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    minTSoil = toCopy.minTSoil;
    deepLayerT = toCopy.deepLayerT;
    maxTSoil = toCopy.maxTSoil;
    hourlySoilT = new double[24];
            for (int i = 0; i < 24; i++)
            { hourlySoilT[i] = toCopy.hourlySoilT[i]; }
    
    }
    }
    public double minTSoil
        {
            get { return this._minTSoil; }
            set { this._minTSoil= value; } 
        }
    public double deepLayerT
        {
            get { return this._deepLayerT; }
            set { this._deepLayerT= value; } 
        }
    public double maxTSoil
        {
            get { return this._maxTSoil; }
            set { this._maxTSoil= value; } 
        }
    public double[] hourlySoilT
        {
            get { return this._hourlySoilT; }
            set { this._hourlySoilT= value; } 
        }
}