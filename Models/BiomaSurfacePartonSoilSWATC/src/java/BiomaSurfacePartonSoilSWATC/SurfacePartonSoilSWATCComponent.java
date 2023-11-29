public class SurfacePartonSoilSWATCComponent
{
    
    public SurfacePartonSoilSWATCComponent() { }

    SurfaceTemperatureParton _SurfaceTemperatureParton = new SurfaceTemperatureParton();
    SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();

    public Double [] getBulkDensity()
    { return _SoilTemperatureSWAT.getBulkDensity(); }
    public void setBulkDensity(Double [] _BulkDensity){
    _SoilTemperatureSWAT.setBulkDensity(_BulkDensity);
    }

    public Double getAirTemperatureAnnualAverage()
    { return _SoilTemperatureSWAT.getAirTemperatureAnnualAverage(); }
    public void setAirTemperatureAnnualAverage(Double _AirTemperatureAnnualAverage){
    _SoilTemperatureSWAT.setAirTemperatureAnnualAverage(_AirTemperatureAnnualAverage);
    }

    public Double getLagCoefficient()
    { return _SoilTemperatureSWAT.getLagCoefficient(); }
    public void setLagCoefficient(Double _LagCoefficient){
    _SoilTemperatureSWAT.setLagCoefficient(_LagCoefficient);
    }

    public Double [] getLayerThickness()
    { return _SoilTemperatureSWAT.getLayerThickness(); }
    public void setLayerThickness(Double [] _LayerThickness){
    _SoilTemperatureSWAT.setLayerThickness(_LayerThickness);
    }

    public Double getSoilProfileDepth()
    { return _SoilTemperatureSWAT.getSoilProfileDepth(); }
    public void setSoilProfileDepth(Double _SoilProfileDepth){
    _SoilTemperatureSWAT.setSoilProfileDepth(_SoilProfileDepth);
    }
    public void  Calculate_Model(SurfacePartonSoilSWATCState s, SurfacePartonSoilSWATCState s1, SurfacePartonSoilSWATCRate r, SurfacePartonSoilSWATCAuxiliary a, SurfacePartonSoilSWATCExogenous ex)
    {
        _SurfaceTemperatureParton.Calculate_Model(s, s1, r, a, ex);
        _SoilTemperatureSWAT.Calculate_Model(s, s1, r, a, ex);
    }
    private Double [] BulkDensity;
    private Double AirTemperatureAnnualAverage;
    private Double LagCoefficient;
    private Double [] LayerThickness;
    private Double SoilProfileDepth;
    public SurfacePartonSoilSWATCComponent(SurfacePartonSoilSWATCComponent toCopy) // copy constructor 
    {
        
        for (int i = 0; i < toCopy.getBulkDensity().length; i++)
        {
            BulkDensity[i] = toCopy.getBulkDensity()[i];
        }
        this.AirTemperatureAnnualAverage = toCopy.getAirTemperatureAnnualAverage();
        this.LagCoefficient = toCopy.getLagCoefficient();
        
        for (int i = 0; i < toCopy.getLayerThickness().length; i++)
        {
            LayerThickness[i] = toCopy.getLayerThickness()[i];
        }
        this.SoilProfileDepth = toCopy.getSoilProfileDepth();

    }
}