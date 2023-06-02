using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_soil_temp.DomainClass;
using Crop2ML_soil_temp.Strategies;

namespace Model.Model.soil_temp
{
    class soil_tempWrapper :  UniverseLink
    {
        private soil_tempState s;
        private soil_tempState s1;
        private soil_tempRate r;
        private soil_tempAuxiliary a;
        private soil_tempExogenous ex;
        private soil_tempComponent soil_tempComponent;

        public soil_tempWrapper(Universe universe) : base(universe)
        {
            s = new soil_tempState();
            r = new soil_tempRate();
            a = new soil_tempAuxiliary();
            ex = new soil_tempExogenous();
            soil_tempComponent = new soil_temp();
            loadParameters();
        }

        public double temp_amp{ get { return s.temp_amp;}} 
     
        public double therm_amp{ get { return s.therm_amp;}} 
     
        public double[] temp_profile{ get { return s.temp_profile;}} 
     
        public double canopy_temp_avg{ get { return s.canopy_temp_avg;}} 
     
        public double[] layer_temp{ get { return s.layer_temp;}} 
     
        public double[] prev_temp_profile{ get { return s.prev_temp_profile;}} 
     
        public double prev_canopy_temp{ get { return ex.prev_canopy_temp;}} 
     

        public soil_tempWrapper(Universe universe, soil_tempWrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new soil_tempState(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new soil_tempRate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new soil_tempAuxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new soil_tempExogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                soil_tempComponent = (toCopy.soil_tempComponent != null) ? new soil_temp(toCopy.soil_tempComponent) : null;
            }
        }

        public void Init(){
            soil_tempComponent.Init(s, r, a);
            loadParameters();
        }

        private void loadParameters()
        {
            soil_tempComponent.layer_thick = layer_thick;
            soil_tempComponent.air_temp_day1 = air_temp_day1;
        }

        public void Estimatesoil_temp(double temp_wave_freq, double therm_diff, double min_temp, double max_temp, double min_air_temp, double min_canopy_temp, double max_canopy_temp)
        {
            a.temp_wave_freq = temp_wave_freq;
            a.therm_diff = therm_diff;
            a.min_temp = min_temp;
            a.max_temp = max_temp;
            a.min_air_temp = min_air_temp;
            a.min_canopy_temp = min_canopy_temp;
            a.max_canopy_temp = max_canopy_temp;
            soil_tempComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}