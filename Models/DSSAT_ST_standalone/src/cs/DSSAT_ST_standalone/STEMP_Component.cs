public class STEMP_Component
{
    
        public STEMP_Component() { }
    

    //Declaration of the associated strategies
    STEMP _STEMP = new STEMP();

    public double MSALB
    {
        get
        {
             return _STEMP.MSALB; 
        }
        set
        {
            _STEMP.MSALB = value;
        }
    }
    public int NL
    {
        get
        {
             return _STEMP.NL; 
        }
        set
        {
            _STEMP.NL = value;
        }
    }
    public double[] LL
    {
        get
        {
             return _STEMP.LL; 
        }
        set
        {
            _STEMP.LL = value;
        }
    }
    public int NLAYR
    {
        get
        {
             return _STEMP.NLAYR; 
        }
        set
        {
            _STEMP.NLAYR = value;
        }
    }
    public double[] DS
    {
        get
        {
             return _STEMP.DS; 
        }
        set
        {
            _STEMP.DS = value;
        }
    }
    public double[] DLAYR
    {
        get
        {
             return _STEMP.DLAYR; 
        }
        set
        {
            _STEMP.DLAYR = value;
        }
    }
    public string ISWWAT
    {
        get
        {
             return _STEMP.ISWWAT; 
        }
        set
        {
            _STEMP.ISWWAT = value;
        }
    }
    public double[] BD
    {
        get
        {
             return _STEMP.BD; 
        }
        set
        {
            _STEMP.BD = value;
        }
    }
    public double[] SW
    {
        get
        {
             return _STEMP.SW; 
        }
        set
        {
            _STEMP.SW = value;
        }
    }
    public double XLAT
    {
        get
        {
             return _STEMP.XLAT; 
        }
        set
        {
            _STEMP.XLAT = value;
        }
    }
    public double[] DUL
    {
        get
        {
             return _STEMP.DUL; 
        }
        set
        {
            _STEMP.DUL = value;
        }
    }

    public void  CalculateModel(STEMP_State s, STEMP_State s1, STEMP_Rate r, STEMP_Auxiliary a, STEMP_Exogenous ex)
    {
        _STEMP.CalculateModel(s,s1, r, a, ex);
    }
    
    public STEMP_Component(STEMP_Component toCopy): this() // copy constructor 
    {

        MSALB = toCopy.MSALB;
        NL = toCopy.NL;
        
            for (int i = 0; i < 100; i++)
            { LL[i] = toCopy.LL[i]; }
    
        NLAYR = toCopy.NLAYR;
        
            for (int i = 0; i < 100; i++)
            { DS[i] = toCopy.DS[i]; }
    
        
            for (int i = 0; i < 100; i++)
            { DLAYR[i] = toCopy.DLAYR[i]; }
    
        ISWWAT = toCopy.ISWWAT;
        
            for (int i = 0; i < 100; i++)
            { BD[i] = toCopy.BD[i]; }
    
        
            for (int i = 0; i < 100; i++)
            { SW[i] = toCopy.SW[i]; }
    
        XLAT = toCopy.XLAT;
        
            for (int i = 0; i < 100; i++)
            { DUL[i] = toCopy.DUL[i]; }
    
    }
}