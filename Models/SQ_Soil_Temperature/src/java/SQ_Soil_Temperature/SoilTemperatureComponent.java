public class SoilTemperatureComponent
{
    
    public SoilTemperatureComponent() { }

    CalculateSoilTemperature _CalculateSoilTemperature = new CalculateSoilTemperature();
    CalculateHourlySoilTemperature _CalculateHourlySoilTemperature = new CalculateHourlySoilTemperature();

    public Double getlambda_()
    { return _Calculatesoiltemperature.getlambda_(); }
    public void setlambda_(Double lambda_)
    { _Calculatesoiltemperature.setlambda_(lambda_); } 

    public Double geta()
    { return _Calculatehourlysoiltemperature.geta(); }
    public void seta(Double a)
    { _Calculatehourlysoiltemperature.seta(a); } 

    public Double getb()
    { return _Calculatehourlysoiltemperature.getb(); }
    public void setb(Double b)
    { _Calculatehourlysoiltemperature.setb(b); } 

    public Double getc()
    { return _Calculatehourlysoiltemperature.getc(); }
    public void setc(Double c)
    { _Calculatehourlysoiltemperature.setc(c); } 
    public void  Calculate_soiltemperature(SoilTemperatureState s, SoilTemperatureState s1, SoilTemperatureRate r, SoilTemperatureAuxiliary a, SoilTemperatureExogenous ex)
    {
        _Calculatesoiltemperature.Calculate_calculatesoiltemperature(s, s1, r, a, ex);
        _Calculatehourlysoiltemperature.Calculate_calculatehourlysoiltemperature(s, s1, r, a, ex);
    }
    private Double lambda_;
    private Double a;
    private Double b;
    private Double c;
    public SoilTemperatureComponent(SoilTemperatureComponent toCopy) // copy constructor 
    {
        this.lambda_ = toCopy.getlambda_();
        this.a = toCopy.geta();
        this.b = toCopy.getb();
        this.c = toCopy.getc();

    }
}