public class SurfacePartonSoilSWATCComponent
{
    
    public SurfacePartonSoilSWATCComponent() { }

    SurfaceTemperatureParton _SurfaceTemperatureParton = new SurfaceTemperatureParton();
    SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();

    public Double [] getLayerThickness()
    { return _SoilTemperatureSWAT.getLayerThickness(); }
    public void setLayerThickness(Double [] _LayerThickness){
    _SoilTemperatureSWAT.setLayerThickness(_LayerThickness);
    }

    public Double [] getBulkDensity()
    { return _SoilTemperatureSWAT.getBulkDensity(); }
    public void setBulkDensity(Double [] _BulkDensity){
    _SoilTemperatureSWAT.setBulkDensity(_BulkDensity);
    }

    public double getSoilProfileDepth()
    { return _SoilTemperatureSWAT.getSoilProfileDepth(); }
    public void setSoilProfileDepth(double _SoilProfileDepth){
    _SoilTemperatureSWAT.setSoilProfileDepth(_SoilProfileDepth);
    }

    public double getAirTemperatureAnnualAverage()
    { return _SoilTemperatureSWAT.getAirTemperatureAnnualAverage(); }
    public void setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage){
    _SoilTemperatureSWAT.setAirTemperatureAnnualAverage(_AirTemperatureAnnualAverage);
    }

    public double getLagCoefficient()
    { return _SoilTemperatureSWAT.getLagCoefficient(); }
    public void setLagCoefficient(double _LagCoefficient){
    _SoilTemperatureSWAT.setLagCoefficient(_LagCoefficient);
    }
    public void  Calculate_Model(SurfacePartonSoilSWATCState s, SurfacePartonSoilSWATCState s1, SurfacePartonSoilSWATCRate r, SurfacePartonSoilSWATCAuxiliary a, SurfacePartonSoilSWATCExogenous ex)
    {
        _SurfaceTemperatureParton.Calculate_Model(s, s1, r, a, ex);
        _SoilTemperatureSWAT.Calculate_Model(s, s1, r, a, ex);
    }
    private Double [] LayerThickness;
    private Double [] BulkDensity;
    private double SoilProfileDepth;
    private double AirTemperatureAnnualAverage;
    private double LagCoefficient;
    public SurfacePartonSoilSWATCComponent(SurfacePartonSoilSWATCComponent toCopy) // copy constructor 
    {
        
        for (int i = 0; i < toCopy.getLayerThickness().length; i++)
        {
            LayerThickness[i] = toCopy.getLayerThickness()[i];
        }
        
        for (int i = 0; i < toCopy.getBulkDensity().length; i++)
        {
            BulkDensity[i] = toCopy.getBulkDensity()[i];
        }
        this.SoilProfileDepth = toCopy.getSoilProfileDepth();
        this.AirTemperatureAnnualAverage = toCopy.getAirTemperatureAnnualAverage();
        this.LagCoefficient = toCopy.getLagCoefficient();

    }
}