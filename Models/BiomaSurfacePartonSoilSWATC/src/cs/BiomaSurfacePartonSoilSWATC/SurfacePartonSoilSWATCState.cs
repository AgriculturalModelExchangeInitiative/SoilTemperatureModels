using System;
using System.Collections.Generic;
public class SurfacePartonSoilSWATCState 
{
    private double[] _SoilTemperatureByLayers;
    
        public SurfacePartonSoilSWATCState() { }
    
    
    public SurfacePartonSoilSWATCState(SurfacePartonSoilSWATCState toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    SoilTemperatureByLayers = new double[toCopy.SoilTemperatureByLayers.Length];
            for (int i = 0; i < toCopy.SoilTemperatureByLayers.Length; i++)
            { SoilTemperatureByLayers[i] = toCopy.SoilTemperatureByLayers[i]; }
    
    }
    }
    public double[] SoilTemperatureByLayers
        {
            get { return this._SoilTemperatureByLayers; }
            set { this._SoilTemperatureByLayers= value; } 
        }
}