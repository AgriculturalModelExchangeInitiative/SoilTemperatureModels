#ifndef _STEMP_EPIC_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include <numeric>
#include <algorithm>
#include <array>
#include <map>
#include <tuple>
#include "STEMP_EPIC.h"
using namespace std;

void STEMP_EPIC::Init(STEMP_EPIC_State& s, STEMP_EPIC_State& s1, STEMP_EPIC_Rate& r, STEMP_EPIC_Auxiliary& a, STEMP_EPIC_Exogenous& ex)
{
    double TAVG = ex.getTAVG();
    double TMAX =  ex.getTMAX();
    double TMIN = ex.getTMIN();
    double TAV = ex.getTAV();
    double MULCHMASS =  ex.getMULCHMASS();
    double SNOW= ex.getSNOW();
    double CUMDPT;
    vector<double> DSMID(20);
    double TDL;
    vector<double> TMA(5);
    int NDays;
    vector<int> WetDay(30);
    double X2_PREV;
    double SRFTEMP;
    vector<double> ST(20);
    CUMDPT = 0.0;
    TDL = 0.0;
    NDays = 0;
    X2_PREV = 0.0;
    SRFTEMP = 0.0;
    fill(ST.begin(), ST.end(), 0.0);
    int I;
    int L;
    double ABD;
    double B;
    double DP;
    double FX;
    double PESW;
    double TBD;
    double WW;
    double TLL;
    double TSW;
    double X2_AVG;
    double WFT;
    double BCV;
    double CV;
    double BCV1;
    double BCV2;
    int NLAYR = 4;
    vector<double> SWI(20);
    SWI = SW;
    TBD = 0.0;
    TLL = 0.0;
    TSW = 0.0;
    TDL = 0.0;
    CUMDPT = 0.0;

    for (L=1 ; L!=NLAYR + 1 ; L+=1)
    {
        DSMID[L - 1] = CUMDPT + (DLAYR[(L - 1)] * 5.0);
        CUMDPT = CUMDPT + (DLAYR[(L - 1)] * 10.0);
        TBD = TBD + (BD[(L - 1)] * DLAYR[(L - 1)]);
        TLL = TLL + (LL[(L - 1)] * DLAYR[(L - 1)]);
        TSW = TSW + (SWI[(L - 1)] * DLAYR[(L - 1)]);
        TDL = TDL + (DUL[(L - 1)] * DLAYR[(L - 1)]);
    }

    if (ISWWAT == "Y")
    {
        PESW = max(0.0, TSW - TLL);
    }
    else
    {
        PESW = max(0.0, TDL - TLL);
    }

    ABD = TBD / DS[(NLAYR - 1)];
    FX = ABD / (ABD + (686.0 * exp(-(5.63 * ABD))));
    DP = 1000.0 + (2500.0 * FX);
    WW = 0.356 - (0.144 * ABD);
    B = log(500.0 / DP);
    for (I=1 ; I!=5 + 1 ; I+=1)
    {
        TMA[I - 1] = int(TAVG * 10000.) / 10000.;
    }
    std::cout <<TMA[0]<<" "<< TMA[1] << "  " <<TMA[2] <<"   "<< TMA[4]<< std::endl;
    X2_AVG = TMA[(1 - 1)] * 5.0;
    for (L=1 ; L!=NLAYR + 1 ; L+=1)
    {
        ST[L - 1] = TAVG;
    }
    WFT = 0.1;
    fill(WetDay.begin(), WetDay.end(), 0);
    NDays = 0;
    CV = MULCHMASS / 1000.;
    BCV1 = CV / (CV + exp(5.3396 - (2.3951 * CV)));
    BCV2 = SNOW / (SNOW + exp(2.303 - (0.2197 * SNOW)));
    BCV = max(BCV1, BCV2);

    for (I=1 ; I!=8 + 1 ; I+=1)
    {

        tie(TMA, SRFTEMP, ST, X2_AVG, X2_PREV) = SOILT_EPIC(NL, B, BCV, CUMDPT, DP, DSMID, NLAYR, PESW, TAV, TAVG, TMAX, TMIN, 0, WFT, WW, X2_PREV, TMA, ST);
    }
    std::cout <<SRFTEMP<< std::endl;
    s.setCUMDPT(CUMDPT);
    s.setDSMID(DSMID);
    s.setTDL(TDL);
    s.setTMA(TMA);
    s.setNDays(NDays);
    s.setWetDay(WetDay);
    s.setX2_PREV(X2_PREV);
    s.setSRFTEMP(SRFTEMP);
    s.setST(ST);
}
STEMP_EPIC::STEMP_EPIC() { }
int STEMP_EPIC::getNL() {return this-> NL; }
string STEMP_EPIC::getISWWAT() {return this-> ISWWAT; }
vector<double> & STEMP_EPIC::getBD() {return this-> BD; }
vector<double> & STEMP_EPIC::getDLAYR() {return this-> DLAYR; }
vector<double> & STEMP_EPIC::getDS() {return this-> DS; }
vector<double> & STEMP_EPIC::getDUL() {return this-> DUL; }
vector<double> & STEMP_EPIC::getLL() {return this-> LL; }
int STEMP_EPIC::getNLAYR() {return this-> NLAYR; }
vector<double> & STEMP_EPIC::getSW() {return this-> SW; }
void STEMP_EPIC::setNL(int _NL) { this->NL = _NL; }
void STEMP_EPIC::setISWWAT(string _ISWWAT) { this->ISWWAT = _ISWWAT; }
void STEMP_EPIC::setBD(vector<double> const & _BD){
    this->BD = _BD;
}
void STEMP_EPIC::setDLAYR(vector<double> const & _DLAYR){
    this->DLAYR = _DLAYR;
}
void STEMP_EPIC::setDS(vector<double> const & _DS){
    this->DS = _DS;
}
void STEMP_EPIC::setDUL(vector<double> const & _DUL){
    this->DUL = _DUL;
}
void STEMP_EPIC::setLL(vector<double> const & _LL){
    this->LL = _LL;
}
void STEMP_EPIC::setNLAYR(int _NLAYR) { this->NLAYR = _NLAYR; }
void STEMP_EPIC::setSW(vector<double> const & _SW){
    this->SW = _SW;
}
void STEMP_EPIC::Calculate_Model(STEMP_EPIC_State& s, STEMP_EPIC_State& s1, STEMP_EPIC_Rate& r, STEMP_EPIC_Auxiliary& a, STEMP_EPIC_Exogenous& ex)
{
    //- Name: STEMP_EPIC -Version:  1.0, -Time step:  1
    //- Description:
    //            * Title: Model of STEMP_EPIC
    //            * Authors: Kenneth N. Potter , Jimmy R. Williams
    //            * Reference: https://doi.org/10.2134/agronj1994.00021962008600060014x
    //            * Institution: USDA-ARS, USDA-ARS
    //            * ExtendedDescription: None
    //            * ShortDescription: Determines soil temperature by layer test encore
    //- inputs:
    //            * name: NL
    //                          ** description : Number of soil layers
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : dimensionless
    //            * name: ISWWAT
    //                          ** description : Water simulation control switch (Y or N)
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : STRING
    //                          ** max :
    //                          ** min :
    //                          ** default : Y
    //                          ** unit : dimensionless
    //            * name: BD
    //                          ** description : Bulk density, soil layer NL
    //                          ** inputtype : parameter
    //                          ** parametercategory : soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : g [soil] / cm3 [soil]
    //            * name: DLAYR
    //                          ** description : Thickness of soil layer NL
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : cm
    //            * name: DS
    //                          ** description : Cumulative depth in soil layer NL
    //                          ** inputtype : parameter
    //                          ** parametercategory : soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : cm
    //            * name: DUL
    //                          ** description : Volumetric soil water content at Drained Upper Limit in soil layer L
    //                          ** inputtype : parameter
    //                          ** parametercategory : soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : cm3[water]/cm3[soil]
    //            * name: LL
    //                          ** description : Volumetric soil water content in soil layer NL at lower limit
    //                          ** inputtype : parameter
    //                          ** parametercategory : soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : cm3 [water] / cm3 [soil]
    //            * name: NLAYR
    //                          ** description : Actual number of soil layers
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : dimensionless
    //            * name: TAMP
    //                          ** description : Annual amplitude of the average air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : degC
    //            * name: RAIN
    //                          ** description : daily rainfall
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : mm
    //            * name: SW
    //                          ** description : Volumetric soil water content in layer NL
    //                          ** inputtype : parameter
    //                          ** parametercategory : soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : cm3 [water] / cm3 [soil]
    //            * name: TAVG
    //                          ** description : Average daily temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : degC
    //            * name: TMAX
    //                          ** description : Maximum daily temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : degC
    //            * name: TMIN
    //                          ** description : Minimum Temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : degC
    //            * name: TAV
    //                          ** description : Average annual soil temperature, used with TAMP to calculate soil temperature.
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : degC
    //            * name: CUMDPT
    //                          ** description : Cumulative depth of soil profile
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : mm
    //            * name: DSMID
    //                          ** description : Depth to midpoint of soil layer NL
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : cm
    //            * name: TDL
    //                          ** description : Total water content of soil at drained upper limit
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : cm
    //            * name: TMA
    //                          ** description : Array of previous 5 days of average soil temperatures.
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 5
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : degC
    //            * name: NDays
    //                          ** description : Number of days ...
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : INT
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : day
    //            * name: WetDay
    //                          ** description : Wet Days
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : INTARRAY
    //                          ** len : 30
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : day
    //            * name: X2_PREV
    //                          ** description : Temperature of soil surface at precedent timestep
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : degC
    //            * name: SRFTEMP
    //                          ** description : Temperature of soil surface litter
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : degC
    //            * name: ST
    //                          ** description : Soil temperature in soil layer NL
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : degC
    //            * name: DEPIR
    //                          ** description : Depth of irrigation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : mm
    //            * name: BIOMAS
    //                          ** description : Biomass
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : kg/ha
    //            * name: MULCHMASS
    //                          ** description : Mulch Mass
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : kg/ha
    //            * name: SNOW
    //                          ** description : Snow cover
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max :
    //                          ** min :
    //                          ** default :
    //                          ** unit : mm
    //- outputs:
    //            * name: CUMDPT
    //                          ** description : Cumulative depth of soil profile
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max :
    //                          ** min :
    //                          ** unit : mm
    //            * name: DSMID
    //                          ** description : Depth to midpoint of soil layer NL
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NL
    //                          ** max :
    //                          ** min :
    //                          ** unit : cm
    //            * name: TDL
    //                          ** description : Total water content of soil at drained upper limit
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max :
    //                          ** min :
    //                          ** unit : cm
    //            * name: TMA
    //                          ** description : Array of previous 5 days of average soil temperatures.
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 5
    //                          ** max :
    //                          ** min :
    //                          ** unit : degC
    //            * name: NDays
    //                          ** description : Number of days ...
    //                          ** datatype : INT
    //                          ** variablecategory : state
    //                          ** max :
    //                          ** min :
    //                          ** unit : day
    //            * name: WetDay
    //                          ** description : Wet Days
    //                          ** datatype : INTARRAY
    //                          ** variablecategory : state
    //                          ** len : 30
    //                          ** max :
    //                          ** min :
    //                          ** unit : day
    //            * name: X2_PREV
    //                          ** description : Temperature of soil surface at precedent timestep
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max :
    //                          ** min :
    //                          ** unit : degC
    //            * name: SRFTEMP
    //                          ** description : Temperature of soil surface litter
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max :
    //                          ** min :
    //                          ** unit : degC
    //            * name: ST
    //                          ** description : Soil temperature in soil layer NL
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NL
    //                          ** max :
    //                          ** min :
    //                          ** unit : degC
    double RAIN = ex.getRAIN();
    double TAVG = ex.getTAVG();
    double TMAX = ex.getTMAX();
    double TMIN = ex.getTMIN();
    double TAV = ex.getTAV();
    double CUMDPT = s.getCUMDPT();
    vector<double>  DSMID = s.getDSMID();
    double TDL = s.getTDL();
    vector<double>  TMA = s.getTMA();
    int NDays = s.getNDays();
    vector<int>  WetDay = s.getWetDay();
    double X2_PREV = s.getX2_PREV();
    double SRFTEMP = s.getSRFTEMP();
    vector<double>  ST = s.getST();
    double DEPIR = ex.getDEPIR();
    double BIOMAS = ex.getBIOMAS();
    double MULCHMASS = ex.getMULCHMASS();
    double SNOW = ex.getSNOW();
    int I;
    int L;
    int NWetDays;
    double ABD;
    double B;
    double DP;
    double FX;
    double PESW;
    double TBD;
    double WW;
    double TLL;
    double TSW;
    double X2_AVG;
    double WFT;
    double BCV;
    double CV;
    double BCV1;
    double BCV2;
    TBD = 0.0;
    TLL = 0.0;
    TSW = 0.0;
    for (L=1 ; L!=NLAYR + 1 ; L+=1)
    {
        TBD = TBD + (BD[(L - 1)] * DLAYR[(L - 1)]);
        TDL = TDL + (DUL[(L - 1)] * DLAYR[(L - 1)]);
        TLL = TLL + (LL[(L - 1)] * DLAYR[(L - 1)]);
        TSW = TSW + (SW[(L - 1)] * DLAYR[(L - 1)]);
    }
    ABD = TBD / DS[(NLAYR - 1)];
    FX = ABD / (ABD + (686.0 * exp(-(5.63 * ABD))));
    DP = 1000.0 + (2500.0 * FX);
    WW = 0.356 - (0.144 * ABD);
    B = log(500.0 / DP);
    if (ISWWAT == "Y")
    {
        PESW = max(0.0, TSW - TLL);
    }
    else
    {
        PESW = max(0.0, TDL - TLL);
    }
    if (NDays == 30)
    {
        for (I=1 ; I!=29 + 1 ; I+=1)
        {
            WetDay[I - 1] = WetDay[I + 1 - 1];
        }
    }
    else
    {
        NDays = NDays + 1;
    }
    if (RAIN + DEPIR > 1.E-6)
    {
        WetDay[NDays - 1] = 1;
    }
    else
    {
        WetDay[NDays - 1] = 0;
    }
    NWetDays = accumulate(WetDay.begin(), WetDay.end(), decltype(WetDay)::value_type(0));
    WFT = float(NWetDays) / float(NDays);
    CV = (BIOMAS + MULCHMASS) / 1000.;
    BCV1 = CV / (CV + exp(5.3396 - (2.3951 * CV)));
    BCV2 = SNOW / (SNOW + exp(2.303 - (0.2197 * SNOW)));
    BCV = max(BCV1, BCV2);
    tie(TMA, SRFTEMP, ST, X2_AVG, X2_PREV) = SOILT_EPIC(NL, B, BCV, CUMDPT, DP, DSMID, NLAYR, PESW, TAV, TAVG, TMAX, TMIN, WetDay[NDays - 1], WFT, WW, X2_PREV, TMA, ST);
    s.setCUMDPT(CUMDPT);
    s.setDSMID(DSMID);
    s.setTDL(TDL);
    s.setTMA(TMA);
    s.setNDays(NDays);
    s.setWetDay(WetDay);
    s.setX2_PREV(X2_PREV);
    s.setSRFTEMP(SRFTEMP);
    s.setST(ST);
}
tuple<vector<double> ,double,vector<double> ,double,double> STEMP_EPIC:: SOILT_EPIC(int NL, double B, double BCV, double CUMDPT, double DP, const vector<double> DSMID, int NLAYR, double PESW, double TAV, double TAVG, double TMAX, double TMIN, int WetDay, double WFT, double WW, double X2_PREV, vector<double> TMA, vector<double> ST)
{
    int K;
    int L;
    double DD;
    double FX;
    double SRFTEMP;
    double WC;
    double ZD;
    double X1;
    double X2;
    double X3;
    double F;
    double X2_AVG;
    double LAG;
    LAG = 0.5;
    WC = max(0.01, PESW) / (WW * CUMDPT) * 10.0;
    FX = exp(B * pow((1.0 - WC) / (1.0 + WC), 2));
    DD = FX * DP;
    if (WetDay > 0)
    {
        X2 = WFT * (TAVG - TMIN) + TMIN;
    }
    else
    {
        X2 = WFT * (TMAX - TAVG) + TAVG + 2.;
    }
    TMA[1 - 1] = X2;
    std::cout <<X2<< std::endl;
    for (K=5 ; K!=2 - 1 ; K+=-1)
    {
        TMA[K - 1] = TMA[K - 1 - 1];
    }


    X2_AVG = accumulate(TMA.begin(), TMA.end(), decltype(TMA)::value_type(0)) / 5.0;
    X3 = (1. - BCV) * X2_AVG + (BCV * X2_PREV);
    SRFTEMP = min(X2_AVG, X3);
    X1 = TAV - X3;
    for (L=1 ; L!=NLAYR + 1 ; L+=1)
    {
        ZD = DSMID[(L - 1)] / DD;
        F = ZD / (ZD + exp(-.8669 - (2.0775 * ZD)));
        ST[L - 1] = LAG * ST[(L - 1)] + ((1. - LAG) * (F * X1 + X3));
    }
    X2_PREV = X2_AVG;
    return make_tuple(TMA, SRFTEMP, ST, X2_AVG, X2_PREV);
}
#endif
