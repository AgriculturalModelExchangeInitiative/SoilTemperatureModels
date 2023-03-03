using System;
using System.Collections.Generic;
using System.Linq;
using Crop2ML_STEMP_EPIC_.DomainClass;
using Crop2ML_STEMP_EPIC_.Strategies;

namespace Model.Model.STEMP_EPIC_
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

        public double CUMDPT{ get { return s.CUMDPT;}} 
     
        public double[] ST{ get { return s.ST;}} 
     
        public double SRFTEMP{ get { return s.SRFTEMP;}} 
     
        public double[] TMA{ get { return s.TMA;}} 
     
        public double X2_PREV{ get { return s.X2_PREV;}} 
     
        public double[] DSMID{ get { return s.DSMID;}} 
     
        public int[] WetDay{ get { return s.WetDay;}} 
     
        public int NDays{ get { return s.NDays;}} 
     

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
            stemp_epic_Component.ISWWAT = ISWWAT;
            stemp_epic_Component.NLAYR = NLAYR;
            stemp_epic_Component.DLAYR = DLAYR;
            stemp_epic_Component.DS = DS;
            stemp_epic_Component.LL = LL;
            stemp_epic_Component.BD = BD;
            stemp_epic_Component.SW = SW;
            stemp_epic_Component.DUL = DUL;
            stemp_epic_Component.NL = NL;
        }

        public void EstimateSTEMP_EPIC_(double SNOW, double TMAX, double BIOMAS, double TAV, double TMIN, double TAMP, double RAIN, double TAVG, double DEPIR, double MULCHMASS)
        {
            a.SNOW = SNOW;
            a.TMAX = TMAX;
            a.BIOMAS = BIOMAS;
            a.TAV = TAV;
            a.TMIN = TMIN;
            a.TAMP = TAMP;
            a.RAIN = RAIN;
            a.TAVG = TAVG;
            a.DEPIR = DEPIR;
            a.MULCHMASS = MULCHMASS;
            stemp_epic_Component.CalculateModel(s,s1, r, a, ex);
        }

    }

}