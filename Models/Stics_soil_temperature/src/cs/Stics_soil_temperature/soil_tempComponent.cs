public class soil_tempComponent
{
    
        public soil_tempComponent() { }
    

    //Declaration of the associated strategies
    Temp_amp _Temp_amp = new Temp_amp();
    Temp_profile _Temp_profile = new Temp_profile();
    Layers_temp _Layers_temp = new Layers_temp();
    Canopy_temp_avg _Canopy_temp_avg = new Canopy_temp_avg();
    Update _Update = new Update();

    public double air_temp_day1
    {
        get
        {
             return _temp_profile.air_temp_day1; 
        }
        set
        {
            _temp_profile.air_temp_day1 = value;
        }
    }
    public int[] layer_thick
    {
        get
        {
             return _temp_profile.layer_thick; 
        }
        set
        {
            _temp_profile.layer_thick = value;
            _layers_temp.layer_thick = value;
        }
    }

    public void  CalculateModel(soil_tempState s, soil_tempState s1, soil_tempRate r, soil_tempAuxiliary a, soil_tempExogenous ex)
    {
        _Temp_amp.CalculateModel(s,s1, r, a, ex);
        _Canopy_temp_avg.CalculateModel(s,s1, r, a, ex);
        _Temp_profile.CalculateModel(s,s1, r, a, ex);
        _Layers_temp.CalculateModel(s,s1, r, a, ex);
        _Update.CalculateModel(s,s1, r, a, ex);
    }
    
    public soil_tempComponent(soil_tempComponent toCopy): this() // copy constructor 
    {

        air_temp_day1 = toCopy.air_temp_day1;
        
            for (int i = 0; i < 100; i++)
            { layer_thick[i] = toCopy.layer_thick[i]; }
    
    }
}