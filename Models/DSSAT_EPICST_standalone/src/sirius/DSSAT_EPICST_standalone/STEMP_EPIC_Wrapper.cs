using System;
using System.Collections.Generic;
using System.Linq;
using SQCrop2ML_STEMP_EPIC_.DomainClass;
using SQCrop2ML_STEMP_EPIC_.Strategies;

namespace SiriusModel.Model.STEMP_EPIC_
{
    class STEMP_EPIC_Wrapper :  UniverseLink
    {
        private STEMP_EPIC_State s;
        private STEMP_EPIC_State s1;
        private STEMP_EPIC_Rate r;
        private STEMP_EPIC_Auxiliary a;
        private STEMP_EPIC_Exogenous ex;
        private STEMP_EPIC_Component stemp_epic_Component;

        public STEMP_EPIC_Wrapper(Universe universe) : base(universe)
        {
            s = new STEMP_EPIC_State();
            r = new STEMP_EPIC_Rate();
            a = new STEMP_EPIC_Auxiliary();
            ex = new STEMP_EPIC_Exogenous();
            stemp_epic_Component = new STEMP_EPIC_();
            loadParameters();
        }

        public double[] TMA{ get { return s.TMA;}} 
     
        public double CUMDPT{ get { return s.CUMDPT;}} 
     
        public double[] ST{ get { return s.ST;}} 
     
        public double[] DSMID{ get { return s.DSMID;}} 
     
        public double SRFTEMP{ get { return s.SRFTEMP;}} 
     
        public int NDays{ get { return s.NDays;}} 
     
        public double X2_PREV{ get { return s.X2_PREV;}} 
     
        public int[] WetDay{ get { return s.WetDay;}} 
     

        public STEMP_EPIC_Wrapper(Universe universe, STEMP_EPIC_Wrapper toCopy, bool copyAll) : base(universe)
        {
            s = (toCopy.s != null) ? new STEMP_EPIC_State(toCopy.s, copyAll) : null;
            r = (toCopy.r != null) ? new STEMP_EPIC_Rate(toCopy.r, copyAll) : null;
            a = (toCopy.a != null) ? new STEMP_EPIC_Auxiliary(toCopy.a, copyAll) : null;
            ex = (toCopy.ex != null) ? new STEMP_EPIC_Exogenous(toCopy.ex, copyAll) : null;
            if (copyAll)
            {
                stemp_epic_Component = (toCopy.stemp_epic_Component != null) ? new STEMP_EPIC_(toCopy.stemp_epic_Component) : null;
            }
        }

        public void Init(){
            stemp_epic_Component.Init(s, r, a);
            loadParameters();
        }

        private void loadParameters()
        {
            stemp_epic_Component.DLAYR = DLAYR;
            stemp_epic_Component.ISWWAT = ISWWAT;
            stemp_epic_Component.NL = NL;
            stemp_epic_Component.SW = SW;
            stemp_epic_Component.BD = BD;
            stemp_epic_Component.NLAYR = NLAYR;
            stemp_epic_Component.DS = DS;
            stemp_epic_Component.DUL = DUL;
            stemp_epic_Component.LL = LL;
        }

        public void EstimateSTEMP_EPIC_(double SNOW, double TAMP, double DEPIR, double TMIN, double MULCHMASS, double TAVG, double TAV, double TMAX, double BIOMAS, double RAIN)
        {
            a.SNOW = SNOW;
            a.TAMP = TAMP;
            a.DEPIR = DEPIR;
            a.TMIN = TMIN;
            a.MULCHMASS = MULCHMASS;
            a.TAVG = TAVG;
            a.TAV = TAV;
            a.TMAX = TMAX;
            a.BIOMAS = BIOMAS;
            a.RAIN = RAIN;
            stemp_epic_Component.CalculateModel(s,s1, r, a, ex);
        }

    }

}