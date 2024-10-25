using Models.Core;
using Models.Utilities;
using System; 
namespace Models.Crop2ML;
     

/// <summary>
///  Model_SoilTempCampbell component
/// </summary>
public class Model_SoilTempCampbellComponent 
{

    /// <summary>
    ///  constructor of Model_SoilTempCampbell component
    /// </summary>
    public Model_SoilTempCampbellComponent() {}

    //Declaration of the associated strategies
    Campbell _Campbell = new Campbell();

    /// <summary>
    /// Gets and sets the number of soil layers in profile
    /// </summary>
    [Description("number of soil layers in profile")] 
    [Units("dimensionless")] 
    public int NLAYR
    {
        get
        {
             return _Campbell.NLAYR; 
        }
        set
        {
            _Campbell.NLAYR = value;
        }
    }

    /// <summary>
    /// Gets and sets the Soil layer thickness of layers
    /// </summary>
    [Description("Soil layer thickness of layers")] 
    [Units("mm")] 
    public double[] THICK
    {
        get
        {
             return _Campbell.THICK; 
        }
        set
        {
            _Campbell.THICK = value;
        }
    }

    /// <summary>
    /// Gets and sets the bd (soil bulk density)
    /// </summary>
    [Description("bd (soil bulk density)")] 
    [Units("g/cm3             uri :")] 
    public double[] BD
    {
        get
        {
             return _Campbell.BD; 
        }
        set
        {
            _Campbell.BD = value;
        }
    }

    /// <summary>
    /// Gets and sets the Volumetric fraction of organic matter in the soil
    /// </summary>
    [Description("Volumetric fraction of organic matter in the soil")] 
    [Units("")] 
    public double[] SLCARB
    {
        get
        {
             return _Campbell.SLCARB; 
        }
        set
        {
            _Campbell.SLCARB = value;
        }
    }

    /// <summary>
    /// Gets and sets the Proportion of CLAY in each layer of profile
    /// </summary>
    [Description("Proportion of CLAY in each layer of profile")] 
    [Units("")] 
    public double[] CLAY
    {
        get
        {
             return _Campbell.CLAY; 
        }
        set
        {
            _Campbell.CLAY = value;
        }
    }

    /// <summary>
    /// Gets and sets the Volumetric fraction of rocks in the soil
    /// </summary>
    [Description("Volumetric fraction of rocks in the soil")] 
    [Units("")] 
    public double[] SLROCK
    {
        get
        {
             return _Campbell.SLROCK; 
        }
        set
        {
            _Campbell.SLROCK = value;
        }
    }

    /// <summary>
    /// Gets and sets the Volumetric fraction of silt in the soil
    /// </summary>
    [Description("Volumetric fraction of silt in the soil")] 
    [Units("")] 
    public double[] SLSILT
    {
        get
        {
             return _Campbell.SLSILT; 
        }
        set
        {
            _Campbell.SLSILT = value;
        }
    }

    /// <summary>
    /// Gets and sets the Volumetric fraction of sand in the soil
    /// </summary>
    [Description("Volumetric fraction of sand in the soil")] 
    [Units("")] 
    public double[] SLSAND
    {
        get
        {
             return _Campbell.SLSAND; 
        }
        set
        {
            _Campbell.SLSAND = value;
        }
    }

    /// <summary>
    /// Gets and sets the volumetric water content
    /// </summary>
    [Description("volumetric water content")] 
    [Units("cc water / cc soil")] 
    public double[] SW
    {
        get
        {
             return _Campbell.SW; 
        }
        set
        {
            _Campbell.SW = value;
        }
    }

    /// <summary>
    /// Gets and sets the Depth of constant temperature
    /// </summary>
    [Description("Depth of constant temperature")] 
    [Units("mm")] 
    public double CONSTANT_TEMPdepth
    {
        get
        {
             return _Campbell.CONSTANT_TEMPdepth; 
        }
        set
        {
            _Campbell.CONSTANT_TEMPdepth = value;
        }
    }

    /// <summary>
    /// Gets and sets the Average annual air temperature
    /// </summary>
    [Description("Average annual air temperature")] 
    [Units("")] 
    public double TAV
    {
        get
        {
             return _Campbell.TAV; 
        }
        set
        {
            _Campbell.TAV = value;
        }
    }

    /// <summary>
    /// Gets and sets the Amplitude air temperature
    /// </summary>
    [Description("Amplitude air temperature")] 
    [Units("")] 
    public double TAMP
    {
        get
        {
             return _Campbell.TAMP; 
        }
        set
        {
            _Campbell.TAMP = value;
        }
    }

    /// <summary>
    /// Gets and sets the Latitude
    /// </summary>
    [Description("Latitude")] 
    [Units("")] 
    public double XLAT
    {
        get
        {
             return _Campbell.XLAT; 
        }
        set
        {
            _Campbell.XLAT = value;
        }
    }

    /// <summary>
    /// Gets and sets the Soil albedo
    /// </summary>
    [Description("Soil albedo")] 
    [Units("dimensionless")] 
    public double SALB
    {
        get
        {
             return _Campbell.SALB; 
        }
        set
        {
            _Campbell.SALB = value;
        }
    }

    /// <summary>
    /// Gets and sets the Default instrument height
    /// </summary>
    [Description("Default instrument height")] 
    [Units("m")] 
    public double instrumentHeight
    {
        get
        {
             return _Campbell.instrumentHeight; 
        }
        set
        {
            _Campbell.instrumentHeight = value;
        }
    }

    /// <summary>
    /// Gets and sets the Flag whether boundary layer conductance is calculated or gotten from input
    /// </summary>
    [Description("Flag whether boundary layer conductance is calculated or gotten from input")] 
    [Units("dimensionless")] 
    public string boundaryLayerConductanceSource
    {
        get
        {
             return _Campbell.boundaryLayerConductanceSource; 
        }
        set
        {
            _Campbell.boundaryLayerConductanceSource = value;
        }
    }

    /// <summary>
    /// Gets and sets the Flag whether net radiation is calculated or gotten from input
    /// </summary>
    [Description("Flag whether net radiation is calculated or gotten from input")] 
    [Units("dimensionless")] 
    public string netRadiationSource
    {
        get
        {
             return _Campbell.netRadiationSource; 
        }
        set
        {
            _Campbell.netRadiationSource = value;
        }
    }

    /// <summary>
    /// Algorithm of Model_SoilTempCampbell component
    /// </summary>
    public void CalculateModel(Model_SoilTempCampbellState s,Model_SoilTempCampbellState s1,Model_SoilTempCampbellRate r,Model_SoilTempCampbellAuxiliary a,Model_SoilTempCampbellExogenous ex)
    {
        _Campbell.CalculateModel(s,s1, r, a, ex);
    }

    /// <summary>
    /// Initialization of Model_SoilTempCampbell component
    /// </summary>
    public void Init(Model_SoilTempCampbellState s, Model_SoilTempCampbellState s1, Model_SoilTempCampbellRate r, Model_SoilTempCampbellAuxiliary a, Model_SoilTempCampbellExogenous ex)
    {
        _Campbell.Init(s, s1, r, a, ex);
    }

    /// <summary>
    /// constructor copy of Model_SoilTempCampbell component
    /// </summary>
    /// <param name="toCopy"></param>
    public Model_SoilTempCampbellComponent(Model_SoilTempCampbellComponent toCopy): this() // copy constructor 
    {
            NLAYR = toCopy.NLAYR;
            
            for (int i = 0; i < NLAYR; i++)
                { THICK[i] = toCopy.THICK[i]; }
    
            
            for (int i = 0; i < NLAYR; i++)
                { BD[i] = toCopy.BD[i]; }
    
            
            for (int i = 0; i < NLAYR; i++)
                { SLCARB[i] = toCopy.SLCARB[i]; }
    
            
            for (int i = 0; i < NLAYR; i++)
                { CLAY[i] = toCopy.CLAY[i]; }
    
            
            for (int i = 0; i < NLAYR; i++)
                { SLROCK[i] = toCopy.SLROCK[i]; }
    
            
            for (int i = 0; i < NLAYR; i++)
                { SLSILT[i] = toCopy.SLSILT[i]; }
    
            
            for (int i = 0; i < NLAYR; i++)
                { SLSAND[i] = toCopy.SLSAND[i]; }
    
            
            for (int i = 0; i < NLAYR; i++)
                { SW[i] = toCopy.SW[i]; }
    
            CONSTANT_TEMPdepth = toCopy.CONSTANT_TEMPdepth;
            TAV = toCopy.TAV;
            TAMP = toCopy.TAMP;
            XLAT = toCopy.XLAT;
            SALB = toCopy.SALB;
            instrumentHeight = toCopy.instrumentHeight;
            boundaryLayerConductanceSource = toCopy.boundaryLayerConductanceSource;
            netRadiationSource = toCopy.netRadiationSource;
    }
}