public class SoilTemperatureComponent
{
    
    public SoilTemperatureComponent() { }

    SnowCoverCalculator _SnowCoverCalculator = new SnowCoverCalculator();
    STMPsimCalculator _STMPsimCalculator = new STMPsimCalculator();

    public Double getcCarbonContent()
    { return _SnowCoverCalculator.getcCarbonContent(); }
    public void setcCarbonContent(Double _cCarbonContent){
    _SnowCoverCalculator.setcCarbonContent(_cCarbonContent);
    }

    public Double [] getcSoilLayerDepth()
    { return _STMPsimCalculator.getcSoilLayerDepth(); }
    public void setcSoilLayerDepth(Double [] _cSoilLayerDepth){
    _STMPsimCalculator.setcSoilLayerDepth(_cSoilLayerDepth);
    }

    public Double getcFirstDayMeanTemp()
    { return _STMPsimCalculator.getcFirstDayMeanTemp(); }
    public void setcFirstDayMeanTemp(Double _cFirstDayMeanTemp){
    _STMPsimCalculator.setcFirstDayMeanTemp(_cFirstDayMeanTemp);
    }

    public Double getcAverageGroundTemperature()
    { return _STMPsimCalculator.getcAVT(); }
    public void setcAverageGroundTemperature(Double _cAverageGroundTemperature){
    _STMPsimCalculator.setcAVT(_cAverageGroundTemperature);
    }

    public Double getcAverageBulkDensity()
    { return _STMPsimCalculator.getcABD(); }
    public void setcAverageBulkDensity(Double _cAverageBulkDensity){
    _STMPsimCalculator.setcABD(_cAverageBulkDensity);
    }

    public Double getcDampingDepth()
    { return _STMPsimCalculator.getcDampingDepth(); }
    public void setcDampingDepth(Double _cDampingDepth){
    _STMPsimCalculator.setcDampingDepth(_cDampingDepth);
    }
    public void  Calculate_Model(SoilTemperatureState s, SoilTemperatureState s1, SoilTemperatureRate r, SoilTemperatureAuxiliary a, SoilTemperatureExogenous ex)
    {
        ex.setiTempMax(ex.getiAirTemperatureMax());
        ex.setiTempMin(ex.getiAirTemperatureMin());
        ex.setiRadiation(ex.getiGlobalSolarRadiation());
        ex.setiSoilTempArray(s.getSoilTempArray());
        _SnowCoverCalculator.Calculate_Model(s, s1, r, a, ex);
        ex.setiSoilSurfaceTemperature(s.getSoilSurfaceTemperature());
        _STMPsimCalculator.Calculate_Model(s, s1, r, a, ex);
    }
    private Double cCarbonContent;
    private Double [] cSoilLayerDepth;
    private Double cFirstDayMeanTemp;
    private Double cAverageGroundTemperature;
    private Double cAVT;
    private Double cAverageBulkDensity;
    private Double cABD;
    private Double cDampingDepth;
    public SoilTemperatureComponent(SoilTemperatureComponent toCopy) // copy constructor 
    {
        this.cCarbonContent = toCopy.getcCarbonContent();
        
        for (int i = 0; i < toCopy.getcSoilLayerDepth().length; i++)
        {
            cSoilLayerDepth[i] = toCopy.getcSoilLayerDepth()[i];
        }
        this.cFirstDayMeanTemp = toCopy.getcFirstDayMeanTemp();
        this.cAverageGroundTemperature = toCopy.getcAverageGroundTemperature();
        this.cAverageBulkDensity = toCopy.getcAverageBulkDensity();
        this.cDampingDepth = toCopy.getcDampingDepth();

    }
}