public class SurfaceSWATSoilSWATCComponent
{
    
    public SurfaceSWATSoilSWATCComponent() { }

    SurfaceTemperatureSWAT _SurfaceTemperatureSWAT = new SurfaceTemperatureSWAT();
    SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();

    public Double getAirTemperatureAnnualAverage()
    { return _SoilTemperatureSWAT.getAirTemperatureAnnualAverage(); }
    public void setAirTemperatureAnnualAverage(Double _AirTemperatureAnnualAverage){
    _SoilTemperatureSWAT.setAirTemperatureAnnualAverage(_AirTemperatureAnnualAverage);
    }

    public Double getSoilProfileDepth()
    { return _SoilTemperatureSWAT.getSoilProfileDepth(); }
    public void setSoilProfileDepth(Double _SoilProfileDepth){
    _SoilTemperatureSWAT.setSoilProfileDepth(_SoilProfileDepth);
    }

    public Double [] getBulkDensity()
    { return _SoilTemperatureSWAT.getBulkDensity(); }
    public void setBulkDensity(Double [] _BulkDensity){
    _SoilTemperatureSWAT.setBulkDensity(_BulkDensity);
    }

    public Double [] getLayerThickness()
    { return _SoilTemperatureSWAT.getLayerThickness(); }
    public void setLayerThickness(Double [] _LayerThickness){
    _SoilTemperatureSWAT.setLayerThickness(_LayerThickness);
    }

    public Double getLagCoefficient()
    { return _SoilTemperatureSWAT.getLagCoefficient(); }
    public void setLagCoefficient(Double _LagCoefficient){
    _SoilTemperatureSWAT.setLagCoefficient(_LagCoefficient);
    }
    public void  Calculate_Model(SurfaceSWATSoilSWATCState s, SurfaceSWATSoilSWATCState s1, SurfaceSWATSoilSWATCRate r, SurfaceSWATSoilSWATCAuxiliary a, SurfaceSWATSoilSWATCExogenous ex)
    {
        _SurfaceTemperatureSWAT.Calculate_Model(s, s1, r, a, ex);
        _SoilTemperatureSWAT.Calculate_Model(s, s1, r, a, ex);
    }
    private Double AirTemperatureAnnualAverage;
    private Double SoilProfileDepth;
    private Double [] BulkDensity;
    private Double [] LayerThickness;
    private Double LagCoefficient;
    public SurfaceSWATSoilSWATCComponent(SurfaceSWATSoilSWATCComponent toCopy) // copy constructor 
    {
        this.AirTemperatureAnnualAverage = toCopy.getAirTemperatureAnnualAverage();
        this.SoilProfileDepth = toCopy.getSoilProfileDepth();
        
        for (int i = 0; i < toCopy.getBulkDensity().length; i++)
        {
            BulkDensity[i] = toCopy.getBulkDensity()[i];
        }
        
        for (int i = 0; i < toCopy.getLayerThickness().length; i++)
        {
            LayerThickness[i] = toCopy.getLayerThickness()[i];
        }
        this.LagCoefficient = toCopy.getLagCoefficient();

    }
}