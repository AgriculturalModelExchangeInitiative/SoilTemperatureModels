public class SoiltempComponent
{
    
        public SoiltempComponent() { }
    

    //Declaration of the associated strategies
    Temp_amp _Temp_amp = new Temp_amp();
    Therm_amp _Therm_amp = new Therm_amp();
    Temp_profile _Temp_profile = new Temp_profile();

    public void  CalculateModel(SoiltempState s, SoiltempState s1, SoiltempRate r, SoiltempAuxiliary a, SoiltempExogenous ex)
    {
        _therm_amp.CalculateModel(s,s1, r, a, ex);
        _temp_amp.CalculateModel(s,s1, r, a, ex);
        _temp_profile.CalculateModel(s,s1, r, a, ex);
    }
    
    public SoiltempComponent(SoiltempComponent toCopy): this() // copy constructor 
    {

    }
}