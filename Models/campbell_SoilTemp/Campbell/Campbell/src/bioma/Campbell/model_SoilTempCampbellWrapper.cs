using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_model_SoilTempCampbell.DomainClass;
using Crop2ML_model_SoilTempCampbell.Strategies;

namespace Model.Model.model_SoilTempCampbell
{
    class model_SoilTempCampbellWrapper :  UniverseLink
    {
        private Model_SoilTempCampbellState s;
        private Model_SoilTempCampbellState s1;
        private Model_SoilTempCampbellRate r;
        private Model_SoilTempCampbellAuxiliary a;
        private Model_SoilTempCampbellExogenous ex;
        private Model_SoilTempCampbellComponent model_soiltempcampbellComponent;

        public model_SoilTempCampbellWrapper(Universe universe) : base(universe)
        {
            s = new model_SoilTempCampbellState();
            r = new model_SoilTempCampbellRate();
            a = new model_SoilTempCampbellAuxiliary();
            ex = new model_SoilTempCampbellExogenous();
            model_soiltempcampbellComponent = new model_SoilTempCampbell();
            loadParameters();
        }

        public double[] THICKApsim{ get { return s.THICKApsim;}} 
     
        public double[] DEPTHApsim{ get { return s.DEPTHApsim;}} 
     
        public double[] BDApsim{ get { return s.BDApsim;}} 
     
        public double[] CLAYApsim{ get { return s.CLAYApsim;}} 
     
        public double[] SWApsim{ get { return s.SWApsim;}} 
     
        public double[] soilTemp{ get { return s.soilTemp;}} 
     
        public double[] newTemperature{ get { return s.newTemperature;}} 
     
        public double[] minSoilTemp{ get { return s.minSoilTemp;}} 
     
        public double[] maxSoilTemp{ get { return s.maxSoilTemp;}} 
     
        public double[] aveSoilTemp{ get { return s.aveSoilTemp;}} 
     
        public double[] morningSoilTemp{ get { return s.morningSoilTemp;}} 
     
        public double[] thermalCondPar1{ get { return s.thermalCondPar1;}} 
     
        public double[] thermalCondPar2{ get { return s.thermalCondPar2;}} 
     
        public double[] thermalCondPar3{ get { return s.thermalCondPar3;}} 
     
        public double[] thermalCondPar4{ get { return s.thermalCondPar4;}} 
     
        public double[] thermalConductivity{ get { return s.thermalConductivity;}} 
     
        public double[] thermalConductance{ get { return s.thermalConductance;}} 
     
        public double[] heatStorage{ get { return s.heatStorage;}} 
     
        public double[] volSpecHeatSoil{ get { return s.volSpecHeatSoil;}} 
     
        public double maxTempYesterday{ get { return s.maxTempYesterday;}} 
     
        public double minTempYesterday{ get { return s.minTempYesterday;}} 
     
        public double[] SLCARBApsim{ get { return s.SLCARBApsim;}} 
     
        public double[] SLROCKApsim{ get { return s.SLROCKApsim;}} 
     
        public double[] SLSILTApsim{ get { return s.SLSILTApsim;}} 
     
        public double[] SLSANDApsim{ get { return s.SLSANDApsim;}} 
     
        public double _boundaryLayerConductance{ get { return s._boundaryLayerConductance;}} 
     

        public model_SoilTempCampbellWrapper(Universe universe, model_SoilTempCampbellWrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new model_SoilTempCampbellState(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new model_SoilTempCampbellRate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new model_SoilTempCampbellAuxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new model_SoilTempCampbellExogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                model_soiltempcampbellComponent = (toCopy.model_soiltempcampbellComponent != null) ? new model_SoilTempCampbell(toCopy.model_soiltempcampbellComponent) : null;
            }
        }

        public void Init(){
            setExogenous();
            loadParameters();
            model_soiltempcampbellComponent.Init(s, s1, r, a, ex);
        }

        private void loadParameters()
        {
            model_soiltempcampbellComponent.NLAYR = null; // To be modified
            model_soiltempcampbellComponent.CONSTANT_TEMPdepth = null; // To be modified
            model_soiltempcampbellComponent.TAMP = null; // To be modified
            model_soiltempcampbellComponent.XLAT = null; // To be modified
            model_soiltempcampbellComponent.SALB = null; // To be modified
            model_soiltempcampbellComponent.instrumentHeight = null; // To be modified
            model_soiltempcampbellComponent.boundaryLayerConductanceSource = null; // To be modified
            model_soiltempcampbellComponent.netRadiationSource = null; // To be modified
        }

        public void EstimateModel_SoilTempCampbell(double[] THICK, double[] BD, double[] SLCARB, double[] CLAY, double[] SLROCK, double[] SLSILT, double[] SLSAND, double[] SW, double T2M, double TMAX, double TMIN, double TAV, int DOY, double airPressure, double canopyHeight, double SRAD, double ESP, double ES, double EOAD, double windSpeed)
        {
            a.THICK = THICK;
            a.BD = BD;
            a.SLCARB = SLCARB;
            a.CLAY = CLAY;
            a.SLROCK = SLROCK;
            a.SLSILT = SLSILT;
            a.SLSAND = SLSAND;
            a.SW = SW;
            a.T2M = T2M;
            a.TMAX = TMAX;
            a.TMIN = TMIN;
            a.TAV = TAV;
            a.DOY = DOY;
            a.airPressure = airPressure;
            a.canopyHeight = canopyHeight;
            a.SRAD = SRAD;
            a.ESP = ESP;
            a.ES = ES;
            a.EOAD = EOAD;
            a.windSpeed = windSpeed;
            model_soiltempcampbellComponent.CalculateModel(s,s1, r, a, ex);
        }

    }

}