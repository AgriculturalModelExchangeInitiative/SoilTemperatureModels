public class SurfaceSWATSoilSWATCComponent
{
    
    public SurfaceSWATSoilSWATCComponent() { }

    SurfaceTemperatureSWAT _SurfaceTemperatureSWAT = new SurfaceTemperatureSWAT();
    SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();

    public Double [] getBulkDensity()
    { return _SoilTemperatureSWAT.getBulkDensity(); }
    public void setBulkDensity(Double [] _BulkDensity){
    _SoilTemperatureSWAT.setBulkDensity(_BulkDensity);
    }

    public double getAirTemperatureAnnualAverage()
    { return _SoilTemperatureSWAT.getAirTemperatureAnnualAverage(); }
    public void setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage){
    _SoilTemperatureSWAT.setAirTemperatureAnnualAverage(_AirTemperatureAnnualAverage);
    }

    public double getSoilProfileDepth()
    { return _SoilTemperatureSWAT.getSoilProfileDepth(); }
    public void setSoilProfileDepth(double _SoilProfileDepth){
    _SoilTemperatureSWAT.setSoilProfileDepth(_SoilProfileDepth);
    }

    public double getLagCoefficient()
    { return _SoilTemperatureSWAT.getLagCoefficient(); }
    public void setLagCoefficient(double _LagCoefficient){
    _SoilTemperatureSWAT.setLagCoefficient(_LagCoefficient);
    }

    public Double [] getLayerThickness()
    { return _SoilTemperatureSWAT.getLayerThickness(); }
    public void setLayerThickness(Double [] _LayerThickness){
    _SoilTemperatureSWAT.setLayerThickness(_LayerThickness);
    }
    public void  Calculate_Model(SurfaceSWATSoilSWATCState s, SurfaceSWATSoilSWATCState s1, SurfaceSWATSoilSWATCRate r, SurfaceSWATSoilSWATCAuxiliary a, SurfaceSWATSoilSWATCExogenous ex)
    {
        _SurfaceTemperatureSWAT.Calculate_Model(s, s1, r, a, ex);
        _SoilTemperatureSWAT.Calculate_Model(s, s1, r, a, ex);
    }
    private Double [] BulkDensity;
    private double AirTemperatureAnnualAverage;
    private double SoilProfileDepth;
    private double LagCoefficient;
    private Double [] LayerThickness;
    public SurfaceSWATSoilSWATCComponent(SurfaceSWATSoilSWATCComponent toCopy) // copy constructor 
    {
        
        for (int i = 0; i < toCopy.getBulkDensity().length; i++)
        {
            BulkDensity[i] = toCopy.getBulkDensity()[i];
        }
        this.AirTemperatureAnnualAverage = toCopy.getAirTemperatureAnnualAverage();
        this.SoilProfileDepth = toCopy.getSoilProfileDepth();
        this.LagCoefficient = toCopy.getLagCoefficient();
        
        for (int i = 0; i < toCopy.getLayerThickness().length; i++)
        {
            LayerThickness[i] = toCopy.getLayerThickness()[i];
        }

    }
}