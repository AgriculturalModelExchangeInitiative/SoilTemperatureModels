public class SurfacePartonSoilSWATHourlyPartonCComponent
{
    
        public SurfacePartonSoilSWATHourlyPartonCComponent() { }
    

    //Declaration of the associated strategies
    SurfaceTemperatureParton _SurfaceTemperatureParton = new SurfaceTemperatureParton();
    SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();
    VolumetricHeatCapacityKluitenberg _VolumetricHeatCapacityKluitenberg = new VolumetricHeatCapacityKluitenberg();
    ThermalConductivitySIMULAT _ThermalConductivitySIMULAT = new ThermalConductivitySIMULAT();
    ThermalDiffu _ThermalDiffu = new ThermalDiffu();
    RangeOfSoilTemperaturesDAYCENT _RangeOfSoilTemperaturesDAYCENT = new RangeOfSoilTemperaturesDAYCENT();
    HourlySoilTemperaturesPartonLogan _HourlySoilTemperaturesPartonLogan = new HourlySoilTemperaturesPartonLogan();

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

    public void  CalculateModel(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        _surfacetemperatureparton.CalculateModel(s,s1, r, a, ex);
        _volumetricheatcapacitykluitenberg.CalculateModel(s,s1, r, a, ex);
        _thermalconductivitysimulat.CalculateModel(s,s1, r, a, ex);
        _soiltemperatureswat.CalculateModel(s,s1, r, a, ex);
        _thermaldiffu.CalculateModel(s,s1, r, a, ex);
        _rangeofsoiltemperaturesdaycent.CalculateModel(s,s1, r, a, ex);
        _hourlysoiltemperaturespartonlogan.CalculateModel(s,s1, r, a, ex);
    }
    
    public SurfacePartonSoilSWATHourlyPartonCComponent(SurfacePartonSoilSWATHourlyPartonCComponent toCopy): this() // copy constructor 
    {

        LagCoefficient = toCopy.LagCoefficient;
    }
}