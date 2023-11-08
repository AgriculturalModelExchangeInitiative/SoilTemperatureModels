public class SoilTemperatureCompComponent
{
    
    public SoilTemperatureCompComponent() { }

    SoilTemperature _SoilTemperature = new SoilTemperature();
    NoSnowSoilSurfaceTemperature _NoSnowSoilSurfaceTemperature = new NoSnowSoilSurfaceTemperature();
    WithSnowSoilSurfaceTemperature _WithSnowSoilSurfaceTemperature = new WithSnowSoilSurfaceTemperature();

    public Double getdampingFactor()
    { return _NoSnowSoilSurfaceTemperature.getdampingFactor(); }
    public void setdampingFactor(Double _dampingFactor){
    _NoSnowSoilSurfaceTemperature.setdampingFactor(_dampingFactor);
    }

    public Double gettimeStep()
    { return _SoilTemperature.gettimeStep(); }
    public void settimeStep(Double _timeStep){
    _SoilTemperature.settimeStep(_timeStep);
    }

    public Double getsoilMoistureConst()
    { return _SoilTemperature.getsoilMoistureConst(); }
    public void setsoilMoistureConst(Double _soilMoistureConst){
    _SoilTemperature.setsoilMoistureConst(_soilMoistureConst);
    }

    public Double getbaseTemp()
    { return _SoilTemperature.getbaseTemp(); }
    public void setbaseTemp(Double _baseTemp){
    _SoilTemperature.setbaseTemp(_baseTemp);
    }

    public Double getinitialSurfaceTemp()
    { return _SoilTemperature.getinitialSurfaceTemp(); }
    public void setinitialSurfaceTemp(Double _initialSurfaceTemp){
    _SoilTemperature.setinitialSurfaceTemp(_initialSurfaceTemp);
    }

    public Double getdensityAir()
    { return _SoilTemperature.getdensityAir(); }
    public void setdensityAir(Double _densityAir){
    _SoilTemperature.setdensityAir(_densityAir);
    }

    public Double getspecificHeatCapacityAir()
    { return _SoilTemperature.getspecificHeatCapacityAir(); }
    public void setspecificHeatCapacityAir(Double _specificHeatCapacityAir){
    _SoilTemperature.setspecificHeatCapacityAir(_specificHeatCapacityAir);
    }

    public Double getdensityHumus()
    { return _SoilTemperature.getdensityHumus(); }
    public void setdensityHumus(Double _densityHumus){
    _SoilTemperature.setdensityHumus(_densityHumus);
    }

    public Double getspecificHeatCapacityHumus()
    { return _SoilTemperature.getspecificHeatCapacityHumus(); }
    public void setspecificHeatCapacityHumus(Double _specificHeatCapacityHumus){
    _SoilTemperature.setspecificHeatCapacityHumus(_specificHeatCapacityHumus);
    }

    public Double getdensityWater()
    { return _SoilTemperature.getdensityWater(); }
    public void setdensityWater(Double _densityWater){
    _SoilTemperature.setdensityWater(_densityWater);
    }

    public Double getspecificHeatCapacityWater()
    { return _SoilTemperature.getspecificHeatCapacityWater(); }
    public void setspecificHeatCapacityWater(Double _specificHeatCapacityWater){
    _SoilTemperature.setspecificHeatCapacityWater(_specificHeatCapacityWater);
    }

    public Double getquartzRawDensity()
    { return _SoilTemperature.getquartzRawDensity(); }
    public void setquartzRawDensity(Double _quartzRawDensity){
    _SoilTemperature.setquartzRawDensity(_quartzRawDensity);
    }

    public Double getspecificHeatCapacityQuartz()
    { return _SoilTemperature.getspecificHeatCapacityQuartz(); }
    public void setspecificHeatCapacityQuartz(Double _specificHeatCapacityQuartz){
    _SoilTemperature.setspecificHeatCapacityQuartz(_specificHeatCapacityQuartz);
    }

    public Double getnTau()
    { return _SoilTemperature.getnTau(); }
    public void setnTau(Double _nTau){
    _SoilTemperature.setnTau(_nTau);
    }

    public Integer getnoOfTempLayers()
    { return _SoilTemperature.getnoOfTempLayers(); }
    public void setnoOfTempLayers(Integer _noOfTempLayers){
    _SoilTemperature.setnoOfTempLayers(_noOfTempLayers);
    }

    public Integer getnoOfSoilLayers()
    { return _SoilTemperature.getnoOfSoilLayers(); }
    public void setnoOfSoilLayers(Integer _noOfSoilLayers){
    _SoilTemperature.setnoOfSoilLayers(_noOfSoilLayers);
    }

    public Double [] getlayerThickness()
    { return _SoilTemperature.getlayerThickness(); }
    public void setlayerThickness(Double [] _layerThickness){
    _SoilTemperature.setlayerThickness(_layerThickness);
    }

    public Double [] getsoilBulkDensity()
    { return _SoilTemperature.getsoilBulkDensity(); }
    public void setsoilBulkDensity(Double [] _soilBulkDensity){
    _SoilTemperature.setsoilBulkDensity(_soilBulkDensity);
    }

    public Double [] getsaturation()
    { return _SoilTemperature.getsaturation(); }
    public void setsaturation(Double [] _saturation){
    _SoilTemperature.setsaturation(_saturation);
    }

    public Double [] getsoilOrganicMatter()
    { return _SoilTemperature.getsoilOrganicMatter(); }
    public void setsoilOrganicMatter(Double [] _soilOrganicMatter){
    _SoilTemperature.setsoilOrganicMatter(_soilOrganicMatter);
    }
    public void  Calculate_Model(SoilTemperatureCompState s, SoilTemperatureCompState s1, SoilTemperatureCompRate r, SoilTemperatureCompAuxiliary a, SoilTemperatureCompExogenous ex)
    {
        _NoSnowSoilSurfaceTemperature.Calculate_Model(s, s1, r, a, ex);
        s.setnoSnowSoilSurfaceTemperature(s.getsoilSurfaceTemperature());
        _WithSnowSoilSurfaceTemperature.Calculate_Model(s, s1, r, a, ex);
        _SoilTemperature.Calculate_Model(s, s1, r, a, ex);
    }
    private Double dampingFactor;
    private Double timeStep;
    private Double soilMoistureConst;
    private Double baseTemp;
    private Double initialSurfaceTemp;
    private Double densityAir;
    private Double specificHeatCapacityAir;
    private Double densityHumus;
    private Double specificHeatCapacityHumus;
    private Double densityWater;
    private Double specificHeatCapacityWater;
    private Double quartzRawDensity;
    private Double specificHeatCapacityQuartz;
    private Double nTau;
    private Integer noOfTempLayers;
    private Integer noOfSoilLayers;
    private Double [] layerThickness;
    private Double [] soilBulkDensity;
    private Double [] saturation;
    private Double [] soilOrganicMatter;
    public SoilTemperatureCompComponent(SoilTemperatureCompComponent toCopy) // copy constructor 
    {
        this.dampingFactor = toCopy.getdampingFactor();
        this.timeStep = toCopy.gettimeStep();
        this.soilMoistureConst = toCopy.getsoilMoistureConst();
        this.baseTemp = toCopy.getbaseTemp();
        this.initialSurfaceTemp = toCopy.getinitialSurfaceTemp();
        this.densityAir = toCopy.getdensityAir();
        this.specificHeatCapacityAir = toCopy.getspecificHeatCapacityAir();
        this.densityHumus = toCopy.getdensityHumus();
        this.specificHeatCapacityHumus = toCopy.getspecificHeatCapacityHumus();
        this.densityWater = toCopy.getdensityWater();
        this.specificHeatCapacityWater = toCopy.getspecificHeatCapacityWater();
        this.quartzRawDensity = toCopy.getquartzRawDensity();
        this.specificHeatCapacityQuartz = toCopy.getspecificHeatCapacityQuartz();
        this.nTau = toCopy.getnTau();
        this.noOfTempLayers = toCopy.getnoOfTempLayers();
        this.noOfSoilLayers = toCopy.getnoOfSoilLayers();
        
        for (int i = 0; i < 22; i++)
        {
            layerThickness[i] = toCopy.getlayerThickness()[i];
        }
        
        for (int i = 0; i < 20; i++)
        {
            soilBulkDensity[i] = toCopy.getsoilBulkDensity()[i];
        }
        
        for (int i = 0; i < 20; i++)
        {
            saturation[i] = toCopy.getsaturation()[i];
        }
        
        for (int i = 0; i < 20; i++)
        {
            soilOrganicMatter[i] = toCopy.getsoilOrganicMatter()[i];
        }

    }
}