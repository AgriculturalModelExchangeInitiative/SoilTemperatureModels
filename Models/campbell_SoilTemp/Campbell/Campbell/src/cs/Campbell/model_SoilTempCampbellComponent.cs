public class Model_SoilTempCampbellComponent
{
    
    /// <summary>
    /// Constructor of the model_SoilTempCampbellComponent component")
    /// </summary>  
    public model_SoilTempCampbellComponent() { }
    

    //Declaration of the associated strategies
    Campbell _Campbell = new Campbell();

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

    public void  CalculateModel(model_SoilTempCampbellState s, model_SoilTempCampbellState s1, model_SoilTempCampbellRate r, model_SoilTempCampbellAuxiliary a, model_SoilTempCampbellExogenous ex)
    {
        _Campbell.CalculateModel(s,s1, r, a, ex);
    }
    
    public model_SoilTempCampbellComponent(model_SoilTempCampbellComponent toCopy): this() // copy constructor 
    {

            NLAYR = toCopy.NLAYR;
            CONSTANT_TEMPdepth = toCopy.CONSTANT_TEMPdepth;
            TAMP = toCopy.TAMP;
            XLAT = toCopy.XLAT;
            SALB = toCopy.SALB;
            instrumentHeight = toCopy.instrumentHeight;
            boundaryLayerConductanceSource = toCopy.boundaryLayerConductanceSource;
            netRadiationSource = toCopy.netRadiationSource;
            }
        }