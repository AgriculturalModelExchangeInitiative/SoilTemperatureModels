public class SurfaceSWATSoilSWATCComponent
{
    
        public SurfaceSWATSoilSWATCComponent() { }
    

    //Declaration of the associated strategies
    SurfaceTemperatureSWAT _SurfaceTemperatureSWAT = new SurfaceTemperatureSWAT();
    SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();

    public double[] BulkDensity
    {
        get
        {
             return _SoilTemperatureSWAT.BulkDensity; 
        }
        set
        {
            _SoilTemperatureSWAT.BulkDensity = value;
        }
    }
    public double AirTemperatureAnnualAverage
    {
        get
        {
             return _SoilTemperatureSWAT.AirTemperatureAnnualAverage; 
        }
        set
        {
            _SoilTemperatureSWAT.AirTemperatureAnnualAverage = value;
        }
    }
    public double SoilProfileDepth
    {
        get
        {
             return _SoilTemperatureSWAT.SoilProfileDepth; 
        }
        set
        {
            _SoilTemperatureSWAT.SoilProfileDepth = value;
        }
    }
    public double LagCoefficient
    {
        get
        {
             return _SoilTemperatureSWAT.LagCoefficient; 
        }
        set
        {
            _SoilTemperatureSWAT.LagCoefficient = value;
        }
    }
    public double[] LayerThickness
    {
        get
        {
             return _SoilTemperatureSWAT.LayerThickness; 
        }
        set
        {
            _SoilTemperatureSWAT.LayerThickness = value;
        }
    }

    public void  CalculateModel(SurfaceSWATSoilSWATCState s, SurfaceSWATSoilSWATCState s1, SurfaceSWATSoilSWATCRate r, SurfaceSWATSoilSWATCAuxiliary a, SurfaceSWATSoilSWATCExogenous ex)
    {
        _SurfaceTemperatureSWAT.CalculateModel(s,s1, r, a, ex);
        _SoilTemperatureSWAT.CalculateModel(s,s1, r, a, ex);
    }
    
    public SurfaceSWATSoilSWATCComponent(SurfaceSWATSoilSWATCComponent toCopy): this() // copy constructor 
    {

        
            for (int i = 0; i < 100; i++)
            { BulkDensity[i] = toCopy.BulkDensity[i]; }
    
        AirTemperatureAnnualAverage = toCopy.AirTemperatureAnnualAverage;
        SoilProfileDepth = toCopy.SoilProfileDepth;
        LagCoefficient = toCopy.LagCoefficient;
        
            for (int i = 0; i < 100; i++)
            { LayerThickness[i] = toCopy.LayerThickness[i]; }
    
    }
}