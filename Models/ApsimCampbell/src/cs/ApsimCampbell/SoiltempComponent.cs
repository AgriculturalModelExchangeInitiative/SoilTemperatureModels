public class SoiltempComponent
{
    
    /// <summary>
    /// Constructor of the SoiltempComponent component")
    /// </summary>  
    public SoiltempComponent() { }
    

    //Declaration of the associated strategies
    SoilTemperature _SoilTemperature = new SoilTemperature();

    public double[] thermCondPar1
    {
        get
        {
             return _SoilTemperature.thermCondPar1; 
        }
        set
        {
            _SoilTemperature.thermCondPar1 = value;
        }
    }
    public int topsoilNode
    {
        get
        {
             return _SoilTemperature.topsoilNode; 
        }
        set
        {
            _SoilTemperature.topsoilNode = value;
        }
    }
    public int surfaceNode
    {
        get
        {
             return _SoilTemperature.surfaceNode; 
        }
        set
        {
            _SoilTemperature.surfaceNode = value;
        }
    }
    public int numPhantomNodes
    {
        get
        {
             return _SoilTemperature.numPhantomNodes; 
        }
        set
        {
            _SoilTemperature.numPhantomNodes = value;
        }
    }
    public string[] soilConstituentNames
    {
        get
        {
             return _SoilTemperature.soilConstituentNames; 
        }
        set
        {
            _SoilTemperature.soilConstituentNames = value;
        }
    }
    public double[] physical_Thickness
    {
        get
        {
             return _SoilTemperature.physical_Thickness; 
        }
        set
        {
            _SoilTemperature.physical_Thickness = value;
        }
    }
    public double MissingValue
    {
        get
        {
             return _SoilTemperature.MissingValue; 
        }
        set
        {
            _SoilTemperature.MissingValue = value;
        }
    }
    public double timestep
    {
        get
        {
             return _SoilTemperature.timestep; 
        }
        set
        {
            _SoilTemperature.timestep = value;
        }
    }
    public double soilRoughnessHeight
    {
        get
        {
             return _SoilTemperature.soilRoughnessHeight; 
        }
        set
        {
            _SoilTemperature.soilRoughnessHeight = value;
        }
    }
    public int numIterationsForBoundaryLayerConductance
    {
        get
        {
             return _SoilTemperature.numIterationsForBoundaryLayerConductance; 
        }
        set
        {
            _SoilTemperature.numIterationsForBoundaryLayerConductance = value;
        }
    }
    public double defaultTimeOfMaximumTemperature
    {
        get
        {
             return _SoilTemperature.defaultTimeOfMaximumTemperature; 
        }
        set
        {
            _SoilTemperature.defaultTimeOfMaximumTemperature = value;
        }
    }
    public double pom
    {
        get
        {
             return _SoilTemperature.pom; 
        }
        set
        {
            _SoilTemperature.pom = value;
        }
    }
    public double DepthToConstantTemperature
    {
        get
        {
             return _SoilTemperature.DepthToConstantTemperature; 
        }
        set
        {
            _SoilTemperature.DepthToConstantTemperature = value;
        }
    }
    public double constantBoundaryLayerConductance
    {
        get
        {
             return _SoilTemperature.constantBoundaryLayerConductance; 
        }
        set
        {
            _SoilTemperature.constantBoundaryLayerConductance = value;
        }
    }
    public double[] thermCondPar4
    {
        get
        {
             return _SoilTemperature.thermCondPar4; 
        }
        set
        {
            _SoilTemperature.thermCondPar4 = value;
        }
    }
    public double[] nodeDepth
    {
        get
        {
             return _SoilTemperature.nodeDepth; 
        }
        set
        {
            _SoilTemperature.nodeDepth = value;
        }
    }
    public double nu
    {
        get
        {
             return _SoilTemperature.nu; 
        }
        set
        {
            _SoilTemperature.nu = value;
        }
    }
    public double[] pInitialValues
    {
        get
        {
             return _SoilTemperature.pInitialValues; 
        }
        set
        {
            _SoilTemperature.pInitialValues = value;
        }
    }
    public double ps
    {
        get
        {
             return _SoilTemperature.ps; 
        }
        set
        {
            _SoilTemperature.ps = value;
        }
    }
    public string netRadiationSource
    {
        get
        {
             return _SoilTemperature.netRadiationSource; 
        }
        set
        {
            _SoilTemperature.netRadiationSource = value;
        }
    }
    public int airNode
    {
        get
        {
             return _SoilTemperature.airNode; 
        }
        set
        {
            _SoilTemperature.airNode = value;
        }
    }
    public double bareSoilRoughness
    {
        get
        {
             return _SoilTemperature.bareSoilRoughness; 
        }
        set
        {
            _SoilTemperature.bareSoilRoughness = value;
        }
    }
    public double[] thermCondPar2
    {
        get
        {
             return _SoilTemperature.thermCondPar2; 
        }
        set
        {
            _SoilTemperature.thermCondPar2 = value;
        }
    }
    public double defaultInstrumentHeight
    {
        get
        {
             return _SoilTemperature.defaultInstrumentHeight; 
        }
        set
        {
            _SoilTemperature.defaultInstrumentHeight = value;
        }
    }
    public double[] physical_BD
    {
        get
        {
             return _SoilTemperature.physical_BD; 
        }
        set
        {
            _SoilTemperature.physical_BD = value;
        }
    }
    public double latentHeatOfVapourisation
    {
        get
        {
             return _SoilTemperature.latentHeatOfVapourisation; 
        }
        set
        {
            _SoilTemperature.latentHeatOfVapourisation = value;
        }
    }
    public double weather_Latitude
    {
        get
        {
             return _SoilTemperature.weather_Latitude; 
        }
        set
        {
            _SoilTemperature.weather_Latitude = value;
        }
    }
    public double stefanBoltzmannConstant
    {
        get
        {
             return _SoilTemperature.stefanBoltzmannConstant; 
        }
        set
        {
            _SoilTemperature.stefanBoltzmannConstant = value;
        }
    }
    public string boundarLayerConductanceSource
    {
        get
        {
             return _SoilTemperature.boundarLayerConductanceSource; 
        }
        set
        {
            _SoilTemperature.boundarLayerConductanceSource = value;
        }
    }
    public double[] thermCondPar3
    {
        get
        {
             return _SoilTemperature.thermCondPar3; 
        }
        set
        {
            _SoilTemperature.thermCondPar3 = value;
        }
    }

    public void  CalculateModel(SoiltempState s, SoiltempState s1, SoiltempRate r, SoiltempAuxiliary a, SoiltempExogenous ex)
    {
        _SoilTemperature.CalculateModel(s,s1, r, a, ex);
    }
    
    public SoiltempComponent(SoiltempComponent toCopy): this() // copy constructor 
    {

        
        for (int i = 0; i < 100; i++)
            { thermCondPar1[i] = toCopy.thermCondPar1[i]; }
    
        topsoilNode = toCopy.topsoilNode;
        surfaceNode = toCopy.surfaceNode;
        numPhantomNodes = toCopy.numPhantomNodes;
        
        for (int i = 0; i < 100; i++)
            { soilConstituentNames[i] = toCopy.soilConstituentNames[i]; }
    
        
        for (int i = 0; i < 100; i++)
            { physical_Thickness[i] = toCopy.physical_Thickness[i]; }
    
        MissingValue = toCopy.MissingValue;
        timestep = toCopy.timestep;
        soilRoughnessHeight = toCopy.soilRoughnessHeight;
        numIterationsForBoundaryLayerConductance = toCopy.numIterationsForBoundaryLayerConductance;
        defaultTimeOfMaximumTemperature = toCopy.defaultTimeOfMaximumTemperature;
        pom = toCopy.pom;
        DepthToConstantTemperature = toCopy.DepthToConstantTemperature;
        constantBoundaryLayerConductance = toCopy.constantBoundaryLayerConductance;
        
        for (int i = 0; i < 100; i++)
            { thermCondPar4[i] = toCopy.thermCondPar4[i]; }
    
        
        for (int i = 0; i < 100; i++)
            { nodeDepth[i] = toCopy.nodeDepth[i]; }
    
        nu = toCopy.nu;
        
        for (int i = 0; i < 100; i++)
            { pInitialValues[i] = toCopy.pInitialValues[i]; }
    
        ps = toCopy.ps;
        netRadiationSource = toCopy.netRadiationSource;
        airNode = toCopy.airNode;
        bareSoilRoughness = toCopy.bareSoilRoughness;
        
        for (int i = 0; i < 100; i++)
            { thermCondPar2[i] = toCopy.thermCondPar2[i]; }
    
        defaultInstrumentHeight = toCopy.defaultInstrumentHeight;
        
        for (int i = 0; i < 100; i++)
            { physical_BD[i] = toCopy.physical_BD[i]; }
    
        latentHeatOfVapourisation = toCopy.latentHeatOfVapourisation;
        weather_Latitude = toCopy.weather_Latitude;
        stefanBoltzmannConstant = toCopy.stefanBoltzmannConstant;
        boundarLayerConductanceSource = toCopy.boundarLayerConductanceSource;
        
        for (int i = 0; i < 100; i++)
            { thermCondPar3[i] = toCopy.thermCondPar3[i]; }
    
    }
    

    

    /// <summary>
    /// Initialization of Soiltemp component
    /// </summary>

    public void Init(SoiltempState s, SoiltempState s1, SoiltempRate r, SoiltempAuxiliary a, SoiltempExogenous ex)
    {
        _SoilTemperature.Init(s,s1, r, a, ex);
    }
    
}