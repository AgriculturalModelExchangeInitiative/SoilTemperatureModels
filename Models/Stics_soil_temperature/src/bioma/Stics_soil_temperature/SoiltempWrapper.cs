using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_Soiltemp.DomainClass;
using Crop2ML_Soiltemp.Strategies;

namespace Model.Model.Soiltemp
{
    class SoiltempWrapper :  UniverseLink
    {
        private SoiltempState s;
        private SoiltempState s1;
        private SoiltempRate r;
        private SoiltempAuxiliary a;
        private SoiltempExogenous ex;
        private SoiltempComponent soiltempComponent;

        public SoiltempWrapper(Universe universe) : base(universe)
        {
            s = new SoiltempState();
            r = new SoiltempRate();
            a = new SoiltempAuxiliary();
            ex = new SoiltempExogenous();
            soiltempComponent = new Soiltemp();
            loadParameters();
        }

        public double temp_amp{ get { return s.temp_amp;}} 
     
        public double therm_amp{ get { return s.therm_amp;}} 
     
        public double[] temp_profile{ get { return s.temp_profile;}} 
     

        public SoiltempWrapper(Universe universe, SoiltempWrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new SoiltempState(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new SoiltempRate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new SoiltempAuxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new SoiltempExogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                soiltempComponent = (toCopy.soiltempComponent != null) ? new Soiltemp(toCopy.soiltempComponent) : null;
            }
        }

        public void Init(){
            soiltempComponent.Init(s, r, a);
            loadParameters();
        }

        private void loadParameters()
        {
        }

        public void EstimateSoiltemp(double therm_diff, double temp_wave_freq, double max_temp, double min_temp, double prev_canopy_temp, double min_air_temp)
        {
            a.therm_diff = therm_diff;
            a.temp_wave_freq = temp_wave_freq;
            a.max_temp = max_temp;
            a.min_temp = min_temp;
            a.prev_canopy_temp = prev_canopy_temp;
            a.min_air_temp = min_air_temp;
            soiltempComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}