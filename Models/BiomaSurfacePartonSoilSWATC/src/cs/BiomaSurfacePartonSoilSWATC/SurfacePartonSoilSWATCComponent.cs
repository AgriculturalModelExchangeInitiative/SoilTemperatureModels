public class SurfacePartonSoilSWATCComponent
{
    
        public SurfacePartonSoilSWATCComponent() { }
    

    //Declaration of the associated strategies
    SurfaceTemperatureParton _SurfaceTemperatureParton = new SurfaceTemperatureParton();
    SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();

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

    public void  CalculateModel(SurfacePartonSoilSWATCState s, SurfacePartonSoilSWATCState s1, SurfacePartonSoilSWATCRate r, SurfacePartonSoilSWATCAuxiliary a, SurfacePartonSoilSWATCExogenous ex)
    {
        _SurfaceTemperatureParton.CalculateModel(s,s1, r, a, ex);
        _SoilTemperatureSWAT.CalculateModel(s,s1, r, a, ex);
    }
    
    public SurfacePartonSoilSWATCComponent(SurfacePartonSoilSWATCComponent toCopy): this() // copy constructor 
    {

        AirTemperatureAnnualAverage = toCopy.AirTemperatureAnnualAverage;
        
            for (int i = 0; i < 100; i++)
            { BulkDensity[i] = toCopy.BulkDensity[i]; }
    
        
            for (int i = 0; i < 100; i++)
            { LayerThickness[i] = toCopy.LayerThickness[i]; }
    
        LagCoefficient = toCopy.LagCoefficient;
        SoilProfileDepth = toCopy.SoilProfileDepth;
    }
}