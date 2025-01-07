using System;
using System.Collections.Generic;
using System.Linq;
class Soil_tempWrapper
{
    private Soil_tempState s;
    private Soil_tempState s1;
    private Soil_tempRate r;
    private Soil_tempAuxiliary a;
    private Soil_tempExogenous ex;
    private Soil_tempComponent soil_tempComponent;

    public Soil_tempWrapper()
    {
        s = new Soil_tempState();
        r = new Soil_tempRate();
        a = new Soil_tempAuxiliary();
        ex = new Soil_tempExogenous();
        soil_tempComponent = new Soil_tempComponent();
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
     

    public Soil_tempWrapper(Soil_tempWrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new Soil_tempState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new Soil_tempRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new Soil_tempAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new Soil_tempExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            soil_tempComponent = (toCopy.soil_tempComponent != null) ? new Soil_tempComponent(toCopy.soil_tempComponent) : null;
        }
    }

    public void Init(){
        setExogenous();
        loadParameters();
        soil_tempComponent.Init(s, s1, r, a, ex);
    }

    private void loadParameters()
    {
        soil_tempComponent.air_temp_day1 = null; // To be modified
        soil_tempComponent.layer_thick = null; // To be modified
    }

    private void setExogenous()
    {
        ex.min_temp = null; // To be modified
        ex.max_temp = null; // To be modified
        ex.min_air_temp = null; // To be modified
        ex.min_canopy_temp = null; // To be modified
        ex.max_canopy_temp = null; // To be modified
    }

    public void EstimateSoil_temp(double min_temp, double max_temp, double min_air_temp, double min_canopy_temp, double max_canopy_temp)
    {
        a.min_temp = min_temp;
        a.max_temp = max_temp;
        a.min_air_temp = min_air_temp;
        a.min_canopy_temp = min_canopy_temp;
        a.max_canopy_temp = max_canopy_temp;
        soil_tempComponent.CalculateModel(s,s1, r, a, ex);
    }

}