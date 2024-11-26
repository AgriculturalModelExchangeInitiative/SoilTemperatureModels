public class Model_SoilTempCampbellComponent
{
    
    public Model_SoilTempCampbellComponent() { }

    Campbell _Campbell = new Campbell();

    public Integer getNLAYR()
    { return _Campbell.getNLAYR(); }
    public void setNLAYR(Integer _NLAYR){
    _Campbell.setNLAYR(_NLAYR);
    }

    public Double [] getTHICK()
    { return _Campbell.getTHICK(); }
    public void setTHICK(Double [] _THICK){
    _Campbell.setTHICK(_THICK);
    }

    public Double [] getBD()
    { return _Campbell.getBD(); }
    public void setBD(Double [] _BD){
    _Campbell.setBD(_BD);
    }

    public Double [] getSLCARB()
    { return _Campbell.getSLCARB(); }
    public void setSLCARB(Double [] _SLCARB){
    _Campbell.setSLCARB(_SLCARB);
    }

    public Double [] getCLAY()
    { return _Campbell.getCLAY(); }
    public void setCLAY(Double [] _CLAY){
    _Campbell.setCLAY(_CLAY);
    }

    public Double [] getSLROCK()
    { return _Campbell.getSLROCK(); }
    public void setSLROCK(Double [] _SLROCK){
    _Campbell.setSLROCK(_SLROCK);
    }

    public Double [] getSLSILT()
    { return _Campbell.getSLSILT(); }
    public void setSLSILT(Double [] _SLSILT){
    _Campbell.setSLSILT(_SLSILT);
    }

    public Double [] getSLSAND()
    { return _Campbell.getSLSAND(); }
    public void setSLSAND(Double [] _SLSAND){
    _Campbell.setSLSAND(_SLSAND);
    }

    public Double [] getSW()
    { return _Campbell.getSW(); }
    public void setSW(Double [] _SW){
    _Campbell.setSW(_SW);
    }

    public double getCONSTANT_TEMPdepth()
    { return _Campbell.getCONSTANT_TEMPdepth(); }
    public void setCONSTANT_TEMPdepth(double _CONSTANT_TEMPdepth){
    _Campbell.setCONSTANT_TEMPdepth(_CONSTANT_TEMPdepth);
    }

    public double getTAV()
    { return _Campbell.getTAV(); }
    public void setTAV(double _TAV){
    _Campbell.setTAV(_TAV);
    }

    public double getTAMP()
    { return _Campbell.getTAMP(); }
    public void setTAMP(double _TAMP){
    _Campbell.setTAMP(_TAMP);
    }

    public double getXLAT()
    { return _Campbell.getXLAT(); }
    public void setXLAT(double _XLAT){
    _Campbell.setXLAT(_XLAT);
    }

    public double getSALB()
    { return _Campbell.getSALB(); }
    public void setSALB(double _SALB){
    _Campbell.setSALB(_SALB);
    }

    public double getinstrumentHeight()
    { return _Campbell.getinstrumentHeight(); }
    public void setinstrumentHeight(double _instrumentHeight){
    _Campbell.setinstrumentHeight(_instrumentHeight);
    }

    public String getboundaryLayerConductanceSource()
    { return _Campbell.getboundaryLayerConductanceSource(); }
    public void setboundaryLayerConductanceSource(String _boundaryLayerConductanceSource){
    _Campbell.setboundaryLayerConductanceSource(_boundaryLayerConductanceSource);
    }

    public String getnetRadiationSource()
    { return _Campbell.getnetRadiationSource(); }
    public void setnetRadiationSource(String _netRadiationSource){
    _Campbell.setnetRadiationSource(_netRadiationSource);
    }
    public void  Calculate_Model(Model_SoilTempCampbellState s, Model_SoilTempCampbellState s1, Model_SoilTempCampbellRate r, Model_SoilTempCampbellAuxiliary a, Model_SoilTempCampbellExogenous ex)
    {
        _Campbell.Calculate_Model(s, s1, r, a, ex);
    }
    private Integer NLAYR;
    private Double [] THICK;
    private Double [] BD;
    private Double [] SLCARB;
    private Double [] CLAY;
    private Double [] SLROCK;
    private Double [] SLSILT;
    private Double [] SLSAND;
    private Double [] SW;
    private double CONSTANT_TEMPdepth;
    private double TAV;
    private double TAMP;
    private double XLAT;
    private double SALB;
    private double instrumentHeight;
    private String boundaryLayerConductanceSource;
    private String netRadiationSource;
    public Model_SoilTempCampbellComponent(Model_SoilTempCampbellComponent toCopy) // copy constructor 
    {
        this.NLAYR = toCopy.getNLAYR();
        
        for (int i = 0; i < toCopy.getTHICK().length; i++)
        {
            THICK[i] = toCopy.getTHICK()[i];
        }
        
        for (int i = 0; i < toCopy.getBD().length; i++)
        {
            BD[i] = toCopy.getBD()[i];
        }
        
        for (int i = 0; i < toCopy.getSLCARB().length; i++)
        {
            SLCARB[i] = toCopy.getSLCARB()[i];
        }
        
        for (int i = 0; i < toCopy.getCLAY().length; i++)
        {
            CLAY[i] = toCopy.getCLAY()[i];
        }
        
        for (int i = 0; i < toCopy.getSLROCK().length; i++)
        {
            SLROCK[i] = toCopy.getSLROCK()[i];
        }
        
        for (int i = 0; i < toCopy.getSLSILT().length; i++)
        {
            SLSILT[i] = toCopy.getSLSILT()[i];
        }
        
        for (int i = 0; i < toCopy.getSLSAND().length; i++)
        {
            SLSAND[i] = toCopy.getSLSAND()[i];
        }
        
        for (int i = 0; i < toCopy.getSW().length; i++)
        {
            SW[i] = toCopy.getSW()[i];
        }
        this.CONSTANT_TEMPdepth = toCopy.getCONSTANT_TEMPdepth();
        this.TAV = toCopy.getTAV();
        this.TAMP = toCopy.getTAMP();
        this.XLAT = toCopy.getXLAT();
        this.SALB = toCopy.getSALB();
        this.instrumentHeight = toCopy.getinstrumentHeight();
        this.boundaryLayerConductanceSource = toCopy.getboundaryLayerConductanceSource();
        this.netRadiationSource = toCopy.getnetRadiationSource();

    }
}