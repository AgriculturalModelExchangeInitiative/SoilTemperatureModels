using Models.Core;
using Models.Utilities;
using System; 
namespace Models.Crop2ML;
     

/// <summary>
///  SurfacePartonSoilSWATHourlyPartonC component
/// </summary>
public class SurfacePartonSoilSWATHourlyPartonCComponent 
{

    /// <summary>
    ///  constructor of SurfacePartonSoilSWATHourlyPartonC component
    /// </summary>
    public SurfacePartonSoilSWATHourlyPartonCComponent() {}

    //Declaration of the associated strategies
    SurfaceTemperatureParton _SurfaceTemperatureParton = new SurfaceTemperatureParton();
    SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();
    VolumetricHeatCapacityKluitenberg _VolumetricHeatCapacityKluitenberg = new VolumetricHeatCapacityKluitenberg();
    ThermalConductivitySIMULAT _ThermalConductivitySIMULAT = new ThermalConductivitySIMULAT();
    ThermalDiffu _ThermalDiffu = new ThermalDiffu();
    RangeOfSoilTemperaturesDAYCENT _RangeOfSoilTemperaturesDAYCENT = new RangeOfSoilTemperaturesDAYCENT();
    HourlySoilTemperaturesPartonLogan _HourlySoilTemperaturesPartonLogan = new HourlySoilTemperaturesPartonLogan();

    /// <summary>
    /// Gets and sets the Soil profile depth
    /// </summary>
    [Description("Soil profile depth")] 
    [Units("m")] 
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

    /// <summary>
    /// Gets and sets the Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature
    /// </summary>
    [Description("Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature")] 
    [Units("dimensionless")] 
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

    /// <summary>
    /// Gets and sets the Annual average air temperature
    /// </summary>
    [Description("Annual average air temperature")] 
    [Units("degC")] 
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

    /// <summary>
    /// Gets and sets the Soil layer thickness
    /// </summary>
    [Description("Soil layer thickness")] 
    [Units("m")] 
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

    /// <summary>
    /// Gets and sets the Bulk density
    /// </summary>
    [Description("Bulk density")] 
    [Units("t m-3")] 
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

    /// <summary>
    /// Gets and sets the Silt content of soil layer
    /// </summary>
    [Description("Silt content of soil layer")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the Clay content of soil layer
    /// </summary>
    [Description("Clay content of soil layer")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the Number of layersl
    /// </summary>
    [Description("Number of layersl")] 
    [Units("dimensionless")] 
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

    /// <summary>
    /// Algorithm of SurfacePartonSoilSWATHourlyPartonC component
    /// </summary>
    public void CalculateModel(SurfacePartonSoilSWATHourlyPartonCState s,SurfacePartonSoilSWATHourlyPartonCState s1,SurfacePartonSoilSWATHourlyPartonCRate r,SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        _SurfaceTemperatureParton.CalculateModel(s,s1, r, a, ex);
        _VolumetricHeatCapacityKluitenberg.CalculateModel(s,s1, r, a, ex);
        _ThermalConductivitySIMULAT.CalculateModel(s,s1, r, a, ex);
        _SoilTemperatureSWAT.CalculateModel(s,s1, r, a, ex);
        _ThermalDiffu.CalculateModel(s,s1, r, a, ex);
        _RangeOfSoilTemperaturesDAYCENT.CalculateModel(s,s1, r, a, ex);
        _HourlySoilTemperaturesPartonLogan.CalculateModel(s,s1, r, a, ex);
    }

    /// <summary>
    /// Initialization of SurfacePartonSoilSWATHourlyPartonC component
    /// </summary>
    public void Init(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        _SurfaceTemperatureParton.Init(s, s1, r, a, ex);
        _VolumetricHeatCapacityKluitenberg.Init(s, s1, r, a, ex);
        _ThermalConductivitySIMULAT.Init(s, s1, r, a, ex);
        _SoilTemperatureSWAT.Init(s, s1, r, a, ex);
        _ThermalDiffu.Init(s, s1, r, a, ex);
        _RangeOfSoilTemperaturesDAYCENT.Init(s, s1, r, a, ex);
        _HourlySoilTemperaturesPartonLogan.Init(s, s1, r, a, ex);
    }

    /// <summary>
    /// constructor copy of SurfacePartonSoilSWATHourlyPartonC component
    /// </summary>
    /// <param name="toCopy"></param>
    public SurfacePartonSoilSWATHourlyPartonCComponent(SurfacePartonSoilSWATHourlyPartonCComponent toCopy): this() // copy constructor 
    {
        SoilProfileDepth = toCopy.SoilProfileDepth;
        LagCoefficient = toCopy.LagCoefficient;
        AirTemperatureAnnualAverage = toCopy.AirTemperatureAnnualAverage;
        
        for (int i = 0; i < toCopy.LayerThickness.Length; i++)
        { LayerThickness[i] = toCopy.LayerThickness[i]; }
    
        
        for (int i = 0; i < toCopy.BulkDensity.Length; i++)
        { BulkDensity[i] = toCopy.BulkDensity[i]; }
    
        
        for (int i = 0; i < toCopy.Silt.Length; i++)
        { Silt[i] = toCopy.Silt[i]; }
    
        
        for (int i = 0; i < toCopy.Clay.Length; i++)
        { Clay[i] = toCopy.Clay[i]; }
    
        layersNumber = toCopy.layersNumber;
    }
}