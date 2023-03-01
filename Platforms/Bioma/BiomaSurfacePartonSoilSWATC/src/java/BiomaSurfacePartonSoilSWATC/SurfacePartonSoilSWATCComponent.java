public class SurfacePartonSoilSWATCComponent
{
    
    public SurfacePartonSoilSWATCComponent() { }

    SurfaceTemperatureParton _SurfaceTemperatureParton = new SurfaceTemperatureParton();
    SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();

    public Double getLagCoefficient()
    { return _Soiltemperatureswat.getLagCoefficient(); }
    public void setLagCoefficient(Double LagCoefficient)
    { _Soiltemperatureswat.setLagCoefficient(LagCoefficient); } 
    public void  Calculate_surfacepartonsoilswatc(SurfacePartonSoilSWATCState s, SurfacePartonSoilSWATCState s1, SurfacePartonSoilSWATCRate r, SurfacePartonSoilSWATCAuxiliary a, SurfacePartonSoilSWATCExogenous ex)
    {
        _Surfacetemperatureparton.Calculate_surfacetemperatureparton(s, s1, r, a, ex);
        _Soiltemperatureswat.Calculate_soiltemperatureswat(s, s1, r, a, ex);
    }
    private Double LagCoefficient;
    public SurfacePartonSoilSWATCComponent(SurfacePartonSoilSWATCComponent toCopy) // copy constructor 
    {
        this.LagCoefficient = toCopy.getLagCoefficient();

    }
}