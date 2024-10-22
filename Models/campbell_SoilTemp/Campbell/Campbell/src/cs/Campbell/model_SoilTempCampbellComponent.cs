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
    public double[] DEPTH
    {
        get
        {
             return _Campbell.DEPTH; 
        }
        set
        {
            _Campbell.DEPTH = value;
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
            
            for (int i = 0; i < 100; i++)
                { THICK[i] = toCopy.THICK[i]; }
    
            
            for (int i = 0; i < 100; i++)
                { DEPTH[i] = toCopy.DEPTH[i]; }
    
            CONSTANT_TEMPdepth = toCopy.CONSTANT_TEMPdepth;
            
            for (int i = 0; i < 100; i++)
                { BD[i] = toCopy.BD[i]; }
    
            TAMP = toCopy.TAMP;
            XLAT = toCopy.XLAT;
            
            for (int i = 0; i < 100; i++)
                { CLAY[i] = toCopy.CLAY[i]; }
    
            SALB = toCopy.SALB;
            instrumentHeight = toCopy.instrumentHeight;
            boundaryLayerConductanceSource = toCopy.boundaryLayerConductanceSource;
            netRadiationSource = toCopy.netRadiationSource;
            }
        }