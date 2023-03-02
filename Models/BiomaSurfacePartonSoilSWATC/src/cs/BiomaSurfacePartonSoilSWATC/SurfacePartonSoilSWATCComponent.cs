public class SurfacePartonSoilSWATCComponent
{
    
        public SurfacePartonSoilSWATCComponent() { }
    

    //Declaration of the associated strategies
    SurfaceTemperatureParton _SurfaceTemperatureParton = new SurfaceTemperatureParton();
    SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();

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

    public void  CalculateModel(SurfacePartonSoilSWATCState s, SurfacePartonSoilSWATCState s1, SurfacePartonSoilSWATCRate r, SurfacePartonSoilSWATCAuxiliary a, SurfacePartonSoilSWATCExogenous ex)
    {
        _surfacetemperatureparton.CalculateModel(s,s1, r, a, ex);
        _soiltemperatureswat.CalculateModel(s,s1, r, a, ex);
    }
    
    public SurfacePartonSoilSWATCComponent(SurfacePartonSoilSWATCComponent toCopy): this() // copy constructor 
    {

        LagCoefficient = toCopy.LagCoefficient;
    }
}