public class SurfacePartonSoilSWATHourlyPartonCComponent
{
    
    public SurfacePartonSoilSWATHourlyPartonCComponent() { }

    SurfaceTemperatureParton _SurfaceTemperatureParton = new SurfaceTemperatureParton();
    SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();
    VolumetricHeatCapacityKluitenberg _VolumetricHeatCapacityKluitenberg = new VolumetricHeatCapacityKluitenberg();
    ThermalConductivitySIMULAT _ThermalConductivitySIMULAT = new ThermalConductivitySIMULAT();
    ThermalDiffu _ThermalDiffu = new ThermalDiffu();
    RangeOfSoilTemperaturesDAYCENT _RangeOfSoilTemperaturesDAYCENT = new RangeOfSoilTemperaturesDAYCENT();
    HourlySoilTemperaturesPartonLogan _HourlySoilTemperaturesPartonLogan = new HourlySoilTemperaturesPartonLogan();

    public Double [] getBulkDensity()
    { return _SoilTemperatureSWAT.getBulkDensity(); }
    public void setBulkDensity(Double [] _BulkDensity){
    _SoilTemperatureSWAT.setBulkDensity(_BulkDensity);
    _VolumetricHeatCapacityKluitenberg.setBulkDensity(_BulkDensity);
    _ThermalConductivitySIMULAT.setBulkDensity(_BulkDensity);
    }

    public Double getSoilProfileDepth()
    { return _SoilTemperatureSWAT.getSoilProfileDepth(); }
    public void setSoilProfileDepth(Double _SoilProfileDepth){
    _SoilTemperatureSWAT.setSoilProfileDepth(_SoilProfileDepth);
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
    _RangeOfSoilTemperaturesDAYCENT.setLayerThickness(_LayerThickness);
    }

    public Double [] getClay()
    { return _VolumetricHeatCapacityKluitenberg.getClay(); }
    public void setClay(Double [] _Clay){
    _VolumetricHeatCapacityKluitenberg.setClay(_Clay);
    _ThermalConductivitySIMULAT.setClay(_Clay);
    }

    public Double [] getSilt()
    { return _VolumetricHeatCapacityKluitenberg.getSilt(); }
    public void setSilt(Double [] _Silt){
    _VolumetricHeatCapacityKluitenberg.setSilt(_Silt);
    }

    public Integer getlayersNumber()
    { return _ThermalDiffu.getlayersNumber(); }
    public void setlayersNumber(Integer _layersNumber){
    _ThermalDiffu.setlayersNumber(_layersNumber);
    }
    public void  Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        _SurfaceTemperatureParton.Calculate_Model(s, s1, r, a, ex);
        _VolumetricHeatCapacityKluitenberg.Calculate_Model(s, s1, r, a, ex);
        _ThermalConductivitySIMULAT.Calculate_Model(s, s1, r, a, ex);
        _SoilTemperatureSWAT.Calculate_Model(s, s1, r, a, ex);
        _ThermalDiffu.Calculate_Model(s, s1, r, a, ex);
        _RangeOfSoilTemperaturesDAYCENT.Calculate_Model(s, s1, r, a, ex);
        _HourlySoilTemperaturesPartonLogan.Calculate_Model(s, s1, r, a, ex);
    }
    private Double [] BulkDensity;
    private Double SoilProfileDepth;
    private Double AirTemperatureAnnualAverage;
    private Double LagCoefficient;
    private Double [] LayerThickness;
    private Double [] Clay;
    private Double [] Silt;
    private Integer layersNumber;
    public SurfacePartonSoilSWATHourlyPartonCComponent(SurfacePartonSoilSWATHourlyPartonCComponent toCopy) // copy constructor 
    {
        
        for (int i = 0; i < toCopy.getBulkDensity().length; i++)
        {
            BulkDensity[i] = toCopy.getBulkDensity()[i];
        }
        this.SoilProfileDepth = toCopy.getSoilProfileDepth();
        this.AirTemperatureAnnualAverage = toCopy.getAirTemperatureAnnualAverage();
        this.LagCoefficient = toCopy.getLagCoefficient();
        
        for (int i = 0; i < toCopy.getLayerThickness().length; i++)
        {
            LayerThickness[i] = toCopy.getLayerThickness()[i];
        }
        
        for (int i = 0; i < toCopy.getClay().length; i++)
        {
            Clay[i] = toCopy.getClay()[i];
        }
        
        for (int i = 0; i < toCopy.getSilt().length; i++)
        {
            Silt[i] = toCopy.getSilt()[i];
        }
        this.layersNumber = toCopy.getlayersNumber();

    }
}