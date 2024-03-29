public class SoilTemperatureComponent
{
    
        public SoilTemperatureComponent() { }
    

    //Declaration of the associated strategies
    CalculateSoilTemperature _CalculateSoilTemperature = new CalculateSoilTemperature();
    CalculateHourlySoilTemperature _CalculateHourlySoilTemperature = new CalculateHourlySoilTemperature();

    public double lambda_
    {
        get
        {
             return _CalculateSoilTemperature.lambda_; 
        }
        set
        {
            _CalculateSoilTemperature.lambda_ = value;
        }
    }
    public double b
    {
        get
        {
             return _CalculateHourlySoilTemperature.b; 
        }
        set
        {
            _CalculateHourlySoilTemperature.b = value;
        }
    }
    public double c
    {
        get
        {
             return _CalculateHourlySoilTemperature.c; 
        }
        set
        {
            _CalculateHourlySoilTemperature.c = value;
        }
    }
    public double a
    {
        get
        {
             return _CalculateHourlySoilTemperature.a; 
        }
        set
        {
            _CalculateHourlySoilTemperature.a = value;
        }
    }

    public void  CalculateModel(SoilTemperatureState s, SoilTemperatureState s1, SoilTemperatureRate r, SoilTemperatureAuxiliary a, SoilTemperatureExogenous ex)
    {
        _CalculateSoilTemperature.CalculateModel(s,s1, r, a, ex);
        _CalculateHourlySoilTemperature.CalculateModel(s,s1, r, a, ex);
    }
    
    public SoilTemperatureComponent(SoilTemperatureComponent toCopy): this() // copy constructor 
    {

        lambda_ = toCopy.lambda_;
        b = toCopy.b;
        c = toCopy.c;
        a = toCopy.a;
    }
}