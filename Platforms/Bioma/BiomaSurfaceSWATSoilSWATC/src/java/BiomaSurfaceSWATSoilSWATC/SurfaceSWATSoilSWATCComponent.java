public class SurfaceSWATSoilSWATCComponent
{
    
    public SurfaceSWATSoilSWATCComponent() { }

    SurfaceTemperatureSWAT _SurfaceTemperatureSWAT = new SurfaceTemperatureSWAT();
    SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();

    public Double getLagCoefficient()
    { return _Soiltemperatureswat.getLagCoefficient(); }
    public void setLagCoefficient(Double LagCoefficient)
    { _Soiltemperatureswat.setLagCoefficient(LagCoefficient); } 
    public void  Calculate_surfaceswatsoilswatc(SurfaceSWATSoilSWATCState s, SurfaceSWATSoilSWATCState s1, SurfaceSWATSoilSWATCRate r, SurfaceSWATSoilSWATCAuxiliary a, SurfaceSWATSoilSWATCExogenous ex)
    {
        _Surfacetemperatureswat.Calculate_surfacetemperatureswat(s, s1, r, a, ex);
        _Soiltemperatureswat.Calculate_soiltemperatureswat(s, s1, r, a, ex);
    }
    private Double LagCoefficient;
    public SurfaceSWATSoilSWATCComponent(SurfaceSWATSoilSWATCComponent toCopy) // copy constructor 
    {
        this.LagCoefficient = toCopy.getLagCoefficient();

    }
}