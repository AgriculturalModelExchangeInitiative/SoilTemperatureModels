public class SoilTemperatureComponent
{
    
    public SoilTemperatureComponent() { }

    CalculateSoilTemperature _CalculateSoilTemperature = new CalculateSoilTemperature();
    CalculateHourlySoilTemperature _CalculateHourlySoilTemperature = new CalculateHourlySoilTemperature();

    public Double getlambda_()
    { return _CalculateSoilTemperature.getlambda_(); }
    public void setlambda_(Double _lambda_){
    _CalculateSoilTemperature.setlambda_(_lambda_);
    }

    public Double getb()
    { return _CalculateHourlySoilTemperature.getb(); }
    public void setb(Double _b){
    _CalculateHourlySoilTemperature.setb(_b);
    }

    public Double getc()
    { return _CalculateHourlySoilTemperature.getc(); }
    public void setc(Double _c){
    _CalculateHourlySoilTemperature.setc(_c);
    }

    public Double geta()
    { return _CalculateHourlySoilTemperature.geta(); }
    public void seta(Double _a){
    _CalculateHourlySoilTemperature.seta(_a);
    }
    public void  Calculate_Model(SoilTemperatureState s, SoilTemperatureState s1, SoilTemperatureRate r, SoilTemperatureAuxiliary a, SoilTemperatureExogenous ex)
    {
        _CalculateSoilTemperature.Calculate_Model(s, s1, r, a, ex);
        _CalculateHourlySoilTemperature.Calculate_Model(s, s1, r, a, ex);
    }
    private Double lambda_;
    private Double b;
    private Double c;
    private Double a;
    public SoilTemperatureComponent(SoilTemperatureComponent toCopy) // copy constructor 
    {
        this.lambda_ = toCopy.getlambda_();
        this.b = toCopy.getb();
        this.c = toCopy.getc();
        this.a = toCopy.geta();

    }
}