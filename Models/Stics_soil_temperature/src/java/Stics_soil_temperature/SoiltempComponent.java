public class SoiltempComponent
{
    
    public SoiltempComponent() { }

    Temp_amp _Temp_amp = new Temp_amp();
    Therm_amp _Therm_amp = new Therm_amp();
    Temp_profile _Temp_profile = new Temp_profile();

    public void  Calculate_soiltemp(SoiltempState s, SoiltempState s1, SoiltempRate r, SoiltempAuxiliary a, SoiltempExogenous ex)
    {
        _Temp_amp.Calculate_temp_amp(s, s1, r, a, ex);
        _Therm_amp.Calculate_therm_amp(s, s1, r, a, ex);
        _Temp_profile.Calculate_temp_profile(s, s1, r, a, ex);
    }
    
    public SoiltempComponent(SoiltempComponent toCopy) // copy constructor 
    {

    }
}