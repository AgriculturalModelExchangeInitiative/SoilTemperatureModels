public class SoilTemperatureComponent
{
    
    /// <summary>
    /// Constructor of the SoilTemperatureComponent component")
    /// </summary>  
    public SoilTemperatureComponent() { }
    

    //Declaration of the associated strategies
    SnowCoverCalculator _SnowCoverCalculator = new SnowCoverCalculator();
    STMPsimCalculator _STMPsimCalculator = new STMPsimCalculator();

    public double cCarbonContent
    {
        get
        {
             return _SnowCoverCalculator.cCarbonContent; 
        }
        set
        {
            _SnowCoverCalculator.cCarbonContent = value;
        }
    }
    public double cAlbedo
    {
        get
        {
             return _SnowCoverCalculator.Albedo; 
        }
        set
        {
            _SnowCoverCalculator.Albedo = value;
        }
    }
    public int cInitialAgeOfSnow
    {
        get
        {
             return _SnowCoverCalculator.cInitialAgeOfSnow; 
        }
        set
        {
            _SnowCoverCalculator.cInitialAgeOfSnow = value;
        }
    }
    public double cInitialSnowWaterContent
    {
        get
        {
             return _SnowCoverCalculator.cInitialSnowWaterContent; 
        }
        set
        {
            _SnowCoverCalculator.cInitialSnowWaterContent = value;
        }
    }
    public double cSnowIsolationFactorA
    {
        get
        {
             return _SnowCoverCalculator.cSnowIsolationFactorA; 
        }
        set
        {
            _SnowCoverCalculator.cSnowIsolationFactorA = value;
        }
    }
    public double cSnowIsolationFactorB
    {
        get
        {
             return _SnowCoverCalculator.cSnowIsolationFactorB; 
        }
        set
        {
            _SnowCoverCalculator.cSnowIsolationFactorB = value;
        }
    }
    public double[] cSoilLayerDepth
    {
        get
        {
             return _STMPsimCalculator.cSoilLayerDepth; 
        }
        set
        {
            _STMPsimCalculator.cSoilLayerDepth = value;
        }
    }
    public double cFirstDayMeanTemp
    {
        get
        {
             return _STMPsimCalculator.cFirstDayMeanTemp; 
        }
        set
        {
            _STMPsimCalculator.cFirstDayMeanTemp = value;
        }
    }
    public double cAverageGroundTemperature
    {
        get
        {
             return _STMPsimCalculator.cAVT; 
        }
        set
        {
            _STMPsimCalculator.cAVT = value;
        }
    }
    public double cAverageBulkDensity
    {
        get
        {
             return _STMPsimCalculator.cABD; 
        }
        set
        {
            _STMPsimCalculator.cABD = value;
        }
    }
    public double cDampingDepth
    {
        get
        {
             return _STMPsimCalculator.cDampingDepth; 
        }
        set
        {
            _STMPsimCalculator.cDampingDepth = value;
        }
    }

    public void  CalculateModel(SoilTemperatureState s, SoilTemperatureState s1, SoilTemperatureRate r, SoilTemperatureAuxiliary a, SoilTemperatureExogenous ex)
    {
        ex.iTempMax = ex.iAirTemperatureMax;
        ex.iTempMin = ex.iAirTemperatureMin;
        ex.iRadiation = ex.iGlobalSolarRadiation;
        a.iSoilTempArray = s.SoilTempArray;
        _SnowCoverCalculator.CalculateModel(s,s1, r, a, ex);
        a.iSoilSurfaceTemperature = s.SoilSurfaceTemperature;
        _STMPsimCalculator.CalculateModel(s,s1, r, a, ex);
    }
    
    public SoilTemperatureComponent(SoilTemperatureComponent toCopy): this() // copy constructor 
    {

            cCarbonContent = toCopy.cCarbonContent;
            cAlbedo = toCopy.cAlbedo;
            cInitialAgeOfSnow = toCopy.cInitialAgeOfSnow;
            cInitialSnowWaterContent = toCopy.cInitialSnowWaterContent;
            cSnowIsolationFactorA = toCopy.cSnowIsolationFactorA;
            cSnowIsolationFactorB = toCopy.cSnowIsolationFactorB;
            
            for (int i = 0; i < 100; i++)
                { cSoilLayerDepth[i] = toCopy.cSoilLayerDepth[i]; }
    
            cFirstDayMeanTemp = toCopy.cFirstDayMeanTemp;
            cAverageGroundTemperature = toCopy.cAverageGroundTemperature;
            cAverageBulkDensity = toCopy.cAverageBulkDensity;
            cDampingDepth = toCopy.cDampingDepth;
            }
        }