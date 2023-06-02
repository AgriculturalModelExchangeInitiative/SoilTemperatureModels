public class Soil_tempComponent
{
    
    public Soil_tempComponent() { }

    Temp_amp _Temp_amp = new Temp_amp();
    Temp_profile _Temp_profile = new Temp_profile();
    Layers_temp _Layers_temp = new Layers_temp();
    Canopy_temp_avg _Canopy_temp_avg = new Canopy_temp_avg();
    Update _Update = new Update();

    public Integer [] getlayer_thick()
    { return _temp_profile.getlayer_thick(); }
    public void setlayer_thick(Integer [] _layer_thick){
    _temp_profile.setlayer_thick(_layer_thick);
    _layers_temp.setlayer_thick(_layer_thick);
    }

    public Double getair_temp_day1()
    { return _temp_profile.getair_temp_day1(); }
    public void setair_temp_day1(Double _air_temp_day1){
    _temp_profile.setair_temp_day1(_air_temp_day1);
    }
    public void  Calculate_Model(soil_tempState s, soil_tempState s1, soil_tempRate r, soil_tempAuxiliary a, soil_tempExogenous ex)
    {
        _Temp_amp.Calculate_Model(s, s1, r, a, ex);
        _Canopy_temp_avg.Calculate_Model(s, s1, r, a, ex);
        _Temp_profile.Calculate_Model(s, s1, r, a, ex);
        _Layers_temp.Calculate_Model(s, s1, r, a, ex);
        _Update.Calculate_Model(s, s1, r, a, ex);
    }
    private Integer [] layer_thick;
    private Double air_temp_day1;
    public soil_tempComponent(soil_tempComponent toCopy) // copy constructor 
    {
        
        for (int i = 0; i < toCopy.getlayer_thick().length; i++)
        {
            layer_thick[i] = toCopy.getlayer_thick()[i];
        }
        this.air_temp_day1 = toCopy.getair_temp_day1();

    }
}