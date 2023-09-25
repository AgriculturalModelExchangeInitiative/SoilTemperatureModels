using System;
using System.Collections.Generic;
using System.Linq;
class soil_tempWrapper
{
    private soil_tempState s;
    private soil_tempState s1;
    private soil_tempRate r;
    private soil_tempAuxiliary a;
    private soil_tempExogenous ex;
    private soil_tempComponent soil_tempComponent;

    public soil_tempWrapper()
    {
        s = new soil_tempState();
        r = new soil_tempRate();
        a = new soil_tempAuxiliary();
        ex = new soil_tempExogenous();
        soil_tempComponent = new soil_tempComponent();
        loadParameters();
    }

        double air_temp_day1;
    int[] layer_thick =  new int [100];

    public double[] prev_temp_profile{ get { return s.prev_temp_profile;}} 
     
    public double prev_canopy_temp{ get { return s.prev_canopy_temp;}} 
     
    public double temp_amp{ get { return s.temp_amp;}} 
     
    public double[] temp_profile{ get { return s.temp_profile;}} 
     
    public double[] layer_temp{ get { return s.layer_temp;}} 
     
    public double canopy_temp_avg{ get { return s.canopy_temp_avg;}} 
     

    public soil_tempWrapper(soil_tempWrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new soil_tempState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new soil_tempRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new soil_tempAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new soil_tempExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            soil_tempComponent = (toCopy.soil_tempComponent != null) ? new soil_tempComponent(toCopy.soil_tempComponent) : null;
        }
    }

    public void Init(){
        soil_tempComponent.Init(s, r, a);
        loadParameters();
    }

    private void loadParameters()
    {
        soil_tempComponent.air_temp_day1 = air_temp_day1;
        soil_tempComponent.layer_thick = layer_thick;
    }

    public void Estimatesoil_temp(double min_temp, double max_temp, double min_air_temp, double min_canopy_temp, double max_canopy_temp)
    {
        a.min_temp = min_temp;
        a.max_temp = max_temp;
        a.min_air_temp = min_air_temp;
        a.min_canopy_temp = min_canopy_temp;
        a.max_canopy_temp = max_canopy_temp;
        soil_tempComponent.CalculateModel(s,s1, r, a, ex);
    }

}