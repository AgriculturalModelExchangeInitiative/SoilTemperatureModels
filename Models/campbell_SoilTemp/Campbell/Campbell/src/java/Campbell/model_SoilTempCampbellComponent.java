public class Model_SoilTempCampbellComponent
{
    
    public Model_SoilTempCampbellComponent() { }

    Campbell _Campbell = new Campbell();

    public Integer getNLAYR()
    { return _campbell.getNLAYR(); }
    public void setNLAYR(Integer _NLAYR){
    _campbell.setNLAYR(_NLAYR);
    }

    public Double [] getTHICK()
    { return _campbell.getTHICK(); }
    public void setTHICK(Double [] _THICK){
    _campbell.setTHICK(_THICK);
    }

    public Double [] getDEPTH()
    { return _campbell.getDEPTH(); }
    public void setDEPTH(Double [] _DEPTH){
    _campbell.setDEPTH(_DEPTH);
    }

    public double getCONSTANT_TEMPdepth()
    { return _campbell.getCONSTANT_TEMPdepth(); }
    public void setCONSTANT_TEMPdepth(double _CONSTANT_TEMPdepth){
    _campbell.setCONSTANT_TEMPdepth(_CONSTANT_TEMPdepth);
    }

    public Double [] getBD()
    { return _campbell.getBD(); }
    public void setBD(Double [] _BD){
    _campbell.setBD(_BD);
    }

    public double getTAMP()
    { return _campbell.getTAMP(); }
    public void setTAMP(double _TAMP){
    _campbell.setTAMP(_TAMP);
    }

    public double getXLAT()
    { return _campbell.getXLAT(); }
    public void setXLAT(double _XLAT){
    _campbell.setXLAT(_XLAT);
    }

    public Double [] getCLAY()
    { return _campbell.getCLAY(); }
    public void setCLAY(Double [] _CLAY){
    _campbell.setCLAY(_CLAY);
    }

    public double getSALB()
    { return _campbell.getSALB(); }
    public void setSALB(double _SALB){
    _campbell.setSALB(_SALB);
    }

    public double getinstrumentHeight()
    { return _campbell.getinstrumentHeight(); }
    public void setinstrumentHeight(double _instrumentHeight){
    _campbell.setinstrumentHeight(_instrumentHeight);
    }

    public String getboundaryLayerConductanceSource()
    { return _campbell.getboundaryLayerConductanceSource(); }
    public void setboundaryLayerConductanceSource(String _boundaryLayerConductanceSource){
    _campbell.setboundaryLayerConductanceSource(_boundaryLayerConductanceSource);
    }

    public String getnetRadiationSource()
    { return _campbell.getnetRadiationSource(); }
    public void setnetRadiationSource(String _netRadiationSource){
    _campbell.setnetRadiationSource(_netRadiationSource);
    }
    public void  Calculate_Model(model_SoilTempCampbellState s, model_SoilTempCampbellState s1, model_SoilTempCampbellRate r, model_SoilTempCampbellAuxiliary a, model_SoilTempCampbellExogenous ex)
    {
        _Campbell.Calculate_Model(s, s1, r, a, ex);
    }
    private Integer NLAYR;
    private Double [] THICK;
    private Double [] DEPTH;
    private double CONSTANT_TEMPdepth;
    private Double [] BD;
    private double TAMP;
    private double XLAT;
    private Double [] CLAY;
    private double SALB;
    private double instrumentHeight;
    private String boundaryLayerConductanceSource;
    private String netRadiationSource;
    public model_SoilTempCampbellComponent(model_SoilTempCampbellComponent toCopy) // copy constructor 
    {
        this.NLAYR = toCopy.getNLAYR();
        
        for (int i = 0; i < toCopy.getTHICK().length; i++)
        {
            THICK[i] = toCopy.getTHICK()[i];
        }
        
        for (int i = 0; i < toCopy.getDEPTH().length; i++)
        {
            DEPTH[i] = toCopy.getDEPTH()[i];
        }
        this.CONSTANT_TEMPdepth = toCopy.getCONSTANT_TEMPdepth();
        
        for (int i = 0; i < toCopy.getBD().length; i++)
        {
            BD[i] = toCopy.getBD()[i];
        }
        this.TAMP = toCopy.getTAMP();
        this.XLAT = toCopy.getXLAT();
        
        for (int i = 0; i < toCopy.getCLAY().length; i++)
        {
            CLAY[i] = toCopy.getCLAY()[i];
        }
        this.SALB = toCopy.getSALB();
        this.instrumentHeight = toCopy.getinstrumentHeight();
        this.boundaryLayerConductanceSource = toCopy.getboundaryLayerConductanceSource();
        this.netRadiationSource = toCopy.getnetRadiationSource();

    }
}