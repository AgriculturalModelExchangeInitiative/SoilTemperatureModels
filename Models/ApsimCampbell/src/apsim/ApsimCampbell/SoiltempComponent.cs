using Models.Core;
using Models.Utilities;
using System; 
namespace Models.Crop2ML;
     

/// <summary>
///  Soiltemp component
/// </summary>
public class SoiltempComponent 
{

    /// <summary>
    ///  constructor of Soiltemp component
    /// </summary>
    public SoiltempComponent() {}

    //Declaration of the associated strategies
    SoilTemperature _SoilTemperature = new SoilTemperature();

    /// <summary>
    /// Gets and sets the Thickness of soil layers (mm)
    /// </summary>
    [Description("Thickness of soil layers (mm)")] 
    [Units("mm")] 
    public double[] Thickness
    {
        get
        {
             return _SoilTemperature.Thickness; 
        }
        set
        {
            _SoilTemperature.Thickness = value;
        }
    }

    /// <summary>
    /// Gets and sets the Number of iterations to calculate atmosphere boundary layer conductance
    /// </summary>
    [Description("Number of iterations to calculate atmosphere boundary layer conductance")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the Parameter 3 for computing thermal conductivity of soil solids
    /// </summary>
    [Description("Parameter 3 for computing thermal conductivity of soil solids")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the Default instrument height
    /// </summary>
    [Description("Default instrument height")] 
    [Units("m")] 
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

    /// <summary>
    /// Gets and sets the Latent heat of vapourisation for water
    /// </summary>
    [Description("Latent heat of vapourisation for water")] 
    [Units("miJ/kg")] 
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

    /// <summary>
    /// Gets and sets the The index of the node in the atmosphere (aboveground)
    /// </summary>
    [Description("The index of the node in the atmosphere (aboveground)")] 
    [Units("")] 
    public double airNode
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

    /// <summary>
    /// Gets and sets the ps
    /// </summary>
    [Description("ps")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the Time of maximum temperature
    /// </summary>
    [Description("Time of maximum temperature")] 
    [Units("minutes")] 
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

    /// <summary>
    /// Gets and sets the Flag whether net radiation is calculated or gotten from input
    /// </summary>
    [Description("Flag whether net radiation is calculated or gotten from input")] 
    [Units("m")] 
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

    /// <summary>
    /// Gets and sets the The index of the first node within the soil (top layer)
    /// </summary>
    [Description("The index of the first node within the soil (top layer)")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the missing value
    /// </summary>
    [Description("missing value")] 
    [Units("m")] 
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

    /// <summary>
    /// Gets and sets the Particle density of organic matter
    /// </summary>
    [Description("Particle density of organic matter")] 
    [Units("Mg/m3")] 
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

    /// <summary>
    /// Gets and sets the Bulk density
    /// </summary>
    [Description("Bulk density")] 
    [Units("g/cc")] 
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

    /// <summary>
    /// Gets and sets the Soil layer thickness
    /// </summary>
    [Description("Soil layer thickness")] 
    [Units("mm")] 
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

    /// <summary>
    /// Gets and sets the Height of soil roughness
    /// </summary>
    [Description("Height of soil roughness")] 
    [Units("mm")] 
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

    /// <summary>
    /// Gets and sets the The number of phantom nodes below the soil profile
    /// </summary>
    [Description("The number of phantom nodes below the soil profile")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the Parameter 4 for computing thermal conductivity of soil solids
    /// </summary>
    [Description("Parameter 4 for computing thermal conductivity of soil solids")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the Depths of nodes
    /// </summary>
    [Description("Depths of nodes")] 
    [Units("mm")] 
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

    /// <summary>
    /// Gets and sets the The index of the node on the soil surface (depth = 0)
    /// </summary>
    [Description("The index of the node on the soil surface (depth = 0)")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the Flag whether boundary layer conductance is calculated or gotten from inpu
    /// </summary>
    [Description("Flag whether boundary layer conductance is calculated or gotten from inpu")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the Parameter 2 for computing thermal conductivity of soil solids
    /// </summary>
    [Description("Parameter 2 for computing thermal conductivity of soil solids")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the Soil depth to constant temperature
    /// </summary>
    [Description("Soil depth to constant temperature")] 
    [Units("mm")] 
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

    /// <summary>
    /// Gets and sets the Boundary layer conductance, if constant
    /// </summary>
    [Description("Boundary layer conductance, if constant")] 
    [Units("K/W")] 
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

    /// <summary>
    /// Gets and sets the Forward/backward differencing coefficient
    /// </summary>
    [Description("Forward/backward differencing coefficient")] 
    [Units("0-1")] 
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

    /// <summary>
    /// Gets and sets the Roughness element height of bare soil
    /// </summary>
    [Description("Roughness element height of bare soil")] 
    [Units("mm")] 
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

    /// <summary>
    /// Gets and sets the The Stefan-Boltzmann constant
    /// </summary>
    [Description("The Stefan-Boltzmann constant")] 
    [Units("W/m2/K4")] 
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

    /// <summary>
    /// Gets and sets the Initial soil temperature
    /// </summary>
    [Description("Initial soil temperature")] 
    [Units("oC")] 
    public double[] InitialValues
    {
        get
        {
             return _SoilTemperature.InitialValues; 
        }
        set
        {
            _SoilTemperature.InitialValues = value;
        }
    }

    /// <summary>
    /// Gets and sets the Parameter 1 for computing thermal conductivity of soil solids
    /// </summary>
    [Description("Parameter 1 for computing thermal conductivity of soil solids")] 
    [Units("")] 
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

    /// <summary>
    /// Gets and sets the soilConstituentNames
    /// </summary>
    [Description("soilConstituentNames")] 
    [Units("m")] 
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

    /// <summary>
    /// Algorithm of Soiltemp component
    /// </summary>
    public void CalculateModel(SoiltempState s,SoiltempState s1,SoiltempRate r,SoiltempAuxiliary a,SoiltempExogenous ex)
    {
        _SoilTemperature.CalculateModel(s,s1, r, a, ex);
    }

    /// <summary>
    /// Initialization of Soiltemp component
    /// </summary>
    public void Init(SoiltempState s, SoiltempState s1, SoiltempRate r, SoiltempAuxiliary a, SoiltempExogenous ex)
    {
        _SoilTemperature.Init(s, s1, r, a, ex);
    }

    /// <summary>
    /// constructor copy of Soiltemp component
    /// </summary>
    /// <param name="toCopy"></param>
    public SoiltempComponent(SoiltempComponent toCopy): this() // copy constructor 
    {
            
            for (int i = 0; i < toCopy.Thickness.Length; i++)
                { Thickness[i] = toCopy.Thickness[i]; }
    
            numIterationsForBoundaryLayerConductance = toCopy.numIterationsForBoundaryLayerConductance;
            
            for (int i = 0; i < toCopy.thermCondPar3.Length; i++)
                { thermCondPar3[i] = toCopy.thermCondPar3[i]; }
    
            defaultInstrumentHeight = toCopy.defaultInstrumentHeight;
            latentHeatOfVapourisation = toCopy.latentHeatOfVapourisation;
            airNode = toCopy.airNode;
            ps = toCopy.ps;
            defaultTimeOfMaximumTemperature = toCopy.defaultTimeOfMaximumTemperature;
            netRadiationSource = toCopy.netRadiationSource;
            topsoilNode = toCopy.topsoilNode;
            MissingValue = toCopy.MissingValue;
            pom = toCopy.pom;
            
            for (int i = 0; i < toCopy.physical_BD.Length; i++)
                { physical_BD[i] = toCopy.physical_BD[i]; }
    
            
            for (int i = 0; i < toCopy.physical_Thickness.Length; i++)
                { physical_Thickness[i] = toCopy.physical_Thickness[i]; }
    
            soilRoughnessHeight = toCopy.soilRoughnessHeight;
            numPhantomNodes = toCopy.numPhantomNodes;
            
            for (int i = 0; i < toCopy.thermCondPar4.Length; i++)
                { thermCondPar4[i] = toCopy.thermCondPar4[i]; }
    
            
            for (int i = 0; i < toCopy.nodeDepth.Length; i++)
                { nodeDepth[i] = toCopy.nodeDepth[i]; }
    
            surfaceNode = toCopy.surfaceNode;
            boundarLayerConductanceSource = toCopy.boundarLayerConductanceSource;
            
            for (int i = 0; i < toCopy.thermCondPar2.Length; i++)
                { thermCondPar2[i] = toCopy.thermCondPar2[i]; }
    
            DepthToConstantTemperature = toCopy.DepthToConstantTemperature;
            constantBoundaryLayerConductance = toCopy.constantBoundaryLayerConductance;
            nu = toCopy.nu;
            bareSoilRoughness = toCopy.bareSoilRoughness;
            stefanBoltzmannConstant = toCopy.stefanBoltzmannConstant;
            
            for (int i = 0; i < toCopy.InitialValues.Length; i++)
                { InitialValues[i] = toCopy.InitialValues[i]; }
    
            
            for (int i = 0; i < toCopy.thermCondPar1.Length; i++)
                { thermCondPar1[i] = toCopy.thermCondPar1[i]; }
    
            
            for (int i = 0; i < 8; i++)
                { soilConstituentNames[i] = toCopy.soilConstituentNames[i]; }
    
    }
}