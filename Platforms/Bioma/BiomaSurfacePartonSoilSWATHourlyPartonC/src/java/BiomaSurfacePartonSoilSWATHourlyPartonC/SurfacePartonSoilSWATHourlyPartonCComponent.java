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

    public Double getLagCoefficient()
    { return _Soiltemperatureswat.getLagCoefficient(); }
    public void setLagCoefficient(Double LagCoefficient)
    { _Soiltemperatureswat.setLagCoefficient(LagCoefficient); } 
    public void  Calculate_surfacepartonsoilswathourlypartonc(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        _Surfacetemperatureparton.Calculate_surfacetemperatureparton(s, s1, r, a, ex);
        _Volumetricheatcapacitykluitenberg.Calculate_volumetricheatcapacitykluitenberg(s, s1, r, a, ex);
        _Thermalconductivitysimulat.Calculate_thermalconductivitysimulat(s, s1, r, a, ex);
        _Soiltemperatureswat.Calculate_soiltemperatureswat(s, s1, r, a, ex);
        _Thermaldiffu.Calculate_thermaldiffu(s, s1, r, a, ex);
        _Rangeofsoiltemperaturesdaycent.Calculate_rangeofsoiltemperaturesdaycent(s, s1, r, a, ex);
        _Hourlysoiltemperaturespartonlogan.Calculate_hourlysoiltemperaturespartonlogan(s, s1, r, a, ex);
    }
    private Double LagCoefficient;
    public SurfacePartonSoilSWATHourlyPartonCComponent(SurfacePartonSoilSWATHourlyPartonCComponent toCopy) // copy constructor 
    {
        this.LagCoefficient = toCopy.getLagCoefficient();

    }
}