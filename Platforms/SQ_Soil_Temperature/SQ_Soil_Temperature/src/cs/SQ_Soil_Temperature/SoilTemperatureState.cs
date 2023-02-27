using System;
using System.Collections.Generic;
public class SoilTemperatureState 
{
    private double _deepLayerT;
    private double _maxTSoil;
    private double _minTSoil;
    private double[] _hourlySoilT = new double[24];
    
        public SoilTemperatureState() { }
    
    
    public SoilTemperatureState(SoilTemperatureState toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    _deepLayerT = toCopy._deepLayerT;
    _maxTSoil = toCopy._maxTSoil;
    _minTSoil = toCopy._minTSoil;
    hourlySoilT = new double[24];
            for (int i = 0; i < 24; i++)
            { _hourlySoilT[i] = toCopy._hourlySoilT[i]; }
    
    }
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
    public double minTSoil
        {
            get { return this._minTSoil; }
            set { this._minTSoil= value; } 
        }
    public double[] hourlySoilT
        {
            get { return this._hourlySoilT; }
            set { this._hourlySoilT= value; } 
        }
}