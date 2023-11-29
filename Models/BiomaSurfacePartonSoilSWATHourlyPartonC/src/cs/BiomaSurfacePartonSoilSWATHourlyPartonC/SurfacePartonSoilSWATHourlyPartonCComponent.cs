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

    public double[] BulkDensity
    {
        get
        {
             return _SoilTemperatureSWAT.BulkDensity; 
        }
        set
        {
            _SoilTemperatureSWAT.BulkDensity = value;
            _VolumetricHeatCapacityKluitenberg.BulkDensity = value;
            _ThermalConductivitySIMULAT.BulkDensity = value;
        }
    }
    public double SoilProfileDepth
    {
        get
        {
             return _SoilTemperatureSWAT.SoilProfileDepth; 
        }
        set
        {
            _SoilTemperatureSWAT.SoilProfileDepth = value;
        }
    }
    public double AirTemperatureAnnualAverage
    {
        get
        {
             return _SoilTemperatureSWAT.AirTemperatureAnnualAverage; 
        }
        set
        {
            _SoilTemperatureSWAT.AirTemperatureAnnualAverage = value;
        }
    }
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
    public double[] LayerThickness
    {
        get
        {
             return _SoilTemperatureSWAT.LayerThickness; 
        }
        set
        {
            _SoilTemperatureSWAT.LayerThickness = value;
            _RangeOfSoilTemperaturesDAYCENT.LayerThickness = value;
        }
    }
    public double[] Clay
    {
        get
        {
             return _VolumetricHeatCapacityKluitenberg.Clay; 
        }
        set
        {
            _VolumetricHeatCapacityKluitenberg.Clay = value;
            _ThermalConductivitySIMULAT.Clay = value;
        }
    }
    public double[] Silt
    {
        get
        {
             return _VolumetricHeatCapacityKluitenberg.Silt; 
        }
        set
        {
            _VolumetricHeatCapacityKluitenberg.Silt = value;
        }
    }
    public int layersNumber
    {
        get
        {
             return _ThermalDiffu.layersNumber; 
        }
        set
        {
            _ThermalDiffu.layersNumber = value;
        }
    }

    public void  CalculateModel(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        _SurfaceTemperatureParton.CalculateModel(s,s1, r, a, ex);
        _VolumetricHeatCapacityKluitenberg.CalculateModel(s,s1, r, a, ex);
        _ThermalConductivitySIMULAT.CalculateModel(s,s1, r, a, ex);
        _SoilTemperatureSWAT.CalculateModel(s,s1, r, a, ex);
        _ThermalDiffu.CalculateModel(s,s1, r, a, ex);
        _RangeOfSoilTemperaturesDAYCENT.CalculateModel(s,s1, r, a, ex);
        _HourlySoilTemperaturesPartonLogan.CalculateModel(s,s1, r, a, ex);
    }
    
    public SurfacePartonSoilSWATHourlyPartonCComponent(SurfacePartonSoilSWATHourlyPartonCComponent toCopy): this() // copy constructor 
    {

        
            for (int i = 0; i < 100; i++)
            { BulkDensity[i] = toCopy.BulkDensity[i]; }
    
        SoilProfileDepth = toCopy.SoilProfileDepth;
        AirTemperatureAnnualAverage = toCopy.AirTemperatureAnnualAverage;
        LagCoefficient = toCopy.LagCoefficient;
        
            for (int i = 0; i < 100; i++)
            { LayerThickness[i] = toCopy.LayerThickness[i]; }
    
        
            for (int i = 0; i < 100; i++)
            { Clay[i] = toCopy.Clay[i]; }
    
        
            for (int i = 0; i < 100; i++)
            { Silt[i] = toCopy.Silt[i]; }
    
        layersNumber = toCopy.layersNumber;
    }
}