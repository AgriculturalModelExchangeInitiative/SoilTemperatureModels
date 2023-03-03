using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_SoilTemperature.DomainClass;
using Crop2ML_SoilTemperature.Strategies;

namespace Model.Model.SoilTemperature
{
    class SoilTemperatureWrapper :  UniverseLink
    {
        private SoilTemperatureState s;
        private SoilTemperatureState s1;
        private SoilTemperatureRate r;
        private SoilTemperatureAuxiliary a;
        private SoilTemperatureExogenous ex;
        private SoilTemperatureComponent soiltemperatureComponent;

        public SoilTemperatureWrapper(Universe universe) : base(universe)
        {
            s = new SoilTemperatureState();
            r = new SoilTemperatureRate();
            a = new SoilTemperatureAuxiliary();
            ex = new SoilTemperatureExogenous();
            soiltemperatureComponent = new SoilTemperature();
            loadParameters();
        }

        public double maxTSoil{ get { return s.maxTSoil;}} 
     
        public double minTSoil{ get { return s.minTSoil;}} 
     
        public double[] hourlySoilT{ get { return s.hourlySoilT;}} 
     

        public SoilTemperatureWrapper(Universe universe, SoilTemperatureWrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new SoilTemperatureState(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new SoilTemperatureRate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new SoilTemperatureAuxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new SoilTemperatureExogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                soiltemperatureComponent = (toCopy.soiltemperatureComponent != null) ? new SoilTemperature(toCopy.soiltemperatureComponent) : null;
            }
        }

        public void Init(){
            soiltemperatureComponent.Init(s, r, a);
            loadParameters();
        }

        private void loadParameters()
        {
            soiltemperatureComponent.lambda_ = lambda_;
            soiltemperatureComponent.a = a;
            soiltemperatureComponent.b = b;
            soiltemperatureComponent.c = c;
        }

        public void EstimateSoilTemperature(double meanTAir, double minTAir, double maxTAir, double dayLength)
        {
            a.meanTAir = meanTAir;
            a.minTAir = minTAir;
            a.maxTAir = maxTAir;
            a.dayLength = dayLength;
            soiltemperatureComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}