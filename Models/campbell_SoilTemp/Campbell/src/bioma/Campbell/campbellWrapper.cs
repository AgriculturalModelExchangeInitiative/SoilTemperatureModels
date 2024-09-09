using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_campbell.DomainClass;
using Crop2ML_campbell.Strategies;

namespace Model.Model.campbell
{
    class campbellWrapper :  UniverseLink
    {
        private CampbellState s;
        private CampbellState s1;
        private CampbellRate r;
        private CampbellAuxiliary a;
        private CampbellExogenous ex;
        private CampbellComponent campbellComponent;

        public campbellWrapper(Universe universe) : base(universe)
        {
            s = new campbellState();
            r = new campbellRate();
            a = new campbellAuxiliary();
            ex = new campbellExogenous();
            campbellComponent = new campbell();
            loadParameters();
        }

        public double[] soilTemp{ get { return s.soilTemp;}} 
     
        public double maxTempYesterday{ get { return s.maxTempYesterday;}} 
     
        public double minTempYesterday{ get { return s.minTempYesterday;}} 
     
        public double[] maxSoilTemp{ get { return s.maxSoilTemp;}} 
     
        public double[] aveSoilTemp{ get { return s.aveSoilTemp;}} 
     
        public double[] morningSoilTemp{ get { return s.morningSoilTemp;}} 
     
        public double[] tempNew{ get { return s.tempNew;}} 
     
        public double[] heatCapacity{ get { return s.heatCapacity;}} 
     
        public double[] thermalCondPar1{ get { return s.thermalCondPar1;}} 
     
        public double[] thermalCondPar2{ get { return s.thermalCondPar2;}} 
     
        public double[] thermalCondPar3{ get { return s.thermalCondPar3;}} 
     
        public double[] thermalCondPar4{ get { return s.thermalCondPar4;}} 
     
        public double[] thermalConductivity{ get { return s.thermalConductivity;}} 
     
        public double[] thermalConductance{ get { return s.thermalConductance;}} 
     
        public double[] heatStorage{ get { return s.heatStorage;}} 
     
        public double airPressure{ get { return s.airPressure;}} 
     
        public double[] minSoilTemp{ get { return a.minSoilTemp;}} 
     

        public campbellWrapper(Universe universe, campbellWrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new campbellState(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new campbellRate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new campbellAuxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new campbellExogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                campbellComponent = (toCopy.campbellComponent != null) ? new campbell(toCopy.campbellComponent) : null;
            }
        }

        public void Init(){
            setExogenous();
            loadParameters();
            campbellComponent.Init(s, s1, r, a, ex);
        }

        private void loadParameters()
        {
            campbellComponent.TAMP = null; // To be modified
            campbellComponent.DEPTH = null; // To be modified
            campbellComponent.CLAY = null; // To be modified
            campbellComponent.SALB = null; // To be modified
            campbellComponent.BD = null; // To be modified
            campbellComponent.XLAT = null; // To be modified
            campbellComponent.THICK = null; // To be modified
            campbellComponent.NLAYR = null; // To be modified
        }

        public void EstimateCampbell(double SRAD, double TMIN, int DOY, double[] SW, double EOAD, double ESP, double TAV, double ESAD, double canopyHeight, double TMAX, double ES)
        {
            a.SRAD = SRAD;
            a.TMIN = TMIN;
            a.DOY = DOY;
            a.SW = SW;
            a.EOAD = EOAD;
            a.ESP = ESP;
            a.TAV = TAV;
            a.ESAD = ESAD;
            a.canopyHeight = canopyHeight;
            a.TMAX = TMAX;
            a.ES = ES;
            campbellComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}