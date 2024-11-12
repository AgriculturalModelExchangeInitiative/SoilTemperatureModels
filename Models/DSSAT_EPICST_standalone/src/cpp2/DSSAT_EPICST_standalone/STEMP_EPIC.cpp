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
using namespace DSSAT_EPICST_standalone;
void STEMP_EPIC::Init(STEMP_EPIC_State &s, STEMP_EPIC_State &s1, STEMP_EPIC_Rate &r, STEMP_EPIC_Auxiliary &a, STEMP_EPIC_Exogenous &ex)
{
    s.DSMID = std::vector<double>(NL);
    s.TMA = std::vector<double>(5);
    s.WetDay = std::vector<int>(30);
    s.ST = std::vector<double>(NL);
    s.CUMDPT = 0.0;
    s.DSMID = std::move(std::vector<double>(NL, 0.0));
    s.TDL = 0.0;
    s.TMA = std::move(std::vector<double>(5, 0.0));
    s.NDays = 0;
    s.WetDay = std::move(std::vector<int>(30, 0));
    s.X2_PREV = 0.0;
    s.SRFTEMP = 0.0;
    s.ST = std::move(std::vector<double>(NL, 0.0));
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
    std::vector<double> SWI(NL);
    SWI = SW;
    TBD = 0.0;
    TLL = 0.0;
    TSW = 0.0;
    s.TDL = 0.0;
    s.CUMDPT = 0.0;
    for (L=1 ; L!=NLAYR + 1 ; L+=1)
    {
        s.DSMID[L - 1] = s.CUMDPT + (DLAYR[(L - 1)] * 5.0);
        s.CUMDPT = s.CUMDPT + (DLAYR[(L - 1)] * 10.0);
        TBD = TBD + (BD[(L - 1)] * DLAYR[(L - 1)]);
        TLL = TLL + (LL[(L - 1)] * DLAYR[(L - 1)]);
        TSW = TSW + (SWI[(L - 1)] * DLAYR[(L - 1)]);
        s.TDL = s.TDL + (DUL[(L - 1)] * DLAYR[(L - 1)]);
    }
    if (ISWWAT == "Y")
    {
        PESW = std::max(0.0, TSW - TLL);
    }
    else
    {
        PESW = std::max(0.0, s.TDL - TLL);
    }
    ABD = TBD / DS[(NLAYR - 1)];
    FX = ABD / (ABD + (686.0 * std::exp(-(5.63 * ABD))));
    DP = 1000.0 + (2500.0 * FX);
    WW = 0.356 - (0.144 * ABD);
    B = std::log(500.0 / DP);
    for (I=1 ; I!=5 + 1 ; I+=1)
    {
        s.TMA[I - 1] = int(ex.TAVG * 10000.) / 10000.;
    }
    X2_AVG = s.TMA[(1 - 1)] * 5.0;
    for (L=1 ; L!=NLAYR + 1 ; L+=1)
    {
        s.ST[L - 1] = ex.TAVG;
    }
    WFT = 0.1;
    s.WetDay.assign(30, 0);
    s.NDays = 0;
    CV = ex.MULCHMASS / 1000.;
    BCV1 = CV / (CV + std::exp(5.3396 - (2.3951 * CV)));
    BCV2 = ex.SNOW / (ex.SNOW + std::exp(2.303 - (0.2197 * ex.SNOW)));
    BCV = std::max(BCV1, BCV2);
    for (I=1 ; I!=8 + 1 ; I+=1)
    {
        tie(s.TMA, s.SRFTEMP, s.ST, X2_AVG, s.X2_PREV) = SOILT_EPIC(NL, B, BCV, s.CUMDPT, DP, s.DSMID, NLAYR, PESW, ex.TAV, ex.TAVG, ex.TMAX, ex.TMIN, 0, WFT, WW, s.TMA, s.ST, s.X2_PREV);
    }
}
STEMP_EPIC::STEMP_EPIC() {}
int STEMP_EPIC::getNL() { return this->NL; }
std::string STEMP_EPIC::getISWWAT() { return this->ISWWAT; }
std::vector<double> & STEMP_EPIC::getBD() { return this->BD; }
std::vector<double> & STEMP_EPIC::getDLAYR() { return this->DLAYR; }
std::vector<double> & STEMP_EPIC::getDS() { return this->DS; }
std::vector<double> & STEMP_EPIC::getDUL() { return this->DUL; }
std::vector<double> & STEMP_EPIC::getLL() { return this->LL; }
int STEMP_EPIC::getNLAYR() { return this->NLAYR; }
std::vector<double> & STEMP_EPIC::getSW() { return this->SW; }
void STEMP_EPIC::setNL(int _NL) { this->NL = _NL; }
void STEMP_EPIC::setISWWAT(std::string _ISWWAT) { this->ISWWAT = _ISWWAT; }
void STEMP_EPIC::setBD(std::vector<double> const &_BD){
    this->BD = _BD;
}
void STEMP_EPIC::setDLAYR(std::vector<double> const &_DLAYR){
    this->DLAYR = _DLAYR;
}
void STEMP_EPIC::setDS(std::vector<double> const &_DS){
    this->DS = _DS;
}
void STEMP_EPIC::setDUL(std::vector<double> const &_DUL){
    this->DUL = _DUL;
}
void STEMP_EPIC::setLL(std::vector<double> const &_LL){
    this->LL = _LL;
}
void STEMP_EPIC::setNLAYR(int _NLAYR) { this->NLAYR = _NLAYR; }
void STEMP_EPIC::setSW(std::vector<double> const &_SW){
    this->SW = _SW;
}
void STEMP_EPIC::Calculate_Model(STEMP_EPIC_State &s, STEMP_EPIC_State &s1, STEMP_EPIC_Rate &r, STEMP_EPIC_Auxiliary &a, STEMP_EPIC_Exogenous &ex)
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
        s.TDL = s.TDL + (DUL[(L - 1)] * DLAYR[(L - 1)]);
        TLL = TLL + (LL[(L - 1)] * DLAYR[(L - 1)]);
        TSW = TSW + (SW[(L - 1)] * DLAYR[(L - 1)]);
    }
    ABD = TBD / DS[(NLAYR - 1)];
    FX = ABD / (ABD + (686.0 * std::exp(-(5.63 * ABD))));
    DP = 1000.0 + (2500.0 * FX);
    WW = 0.356 - (0.144 * ABD);
    B = std::log(500.0 / DP);
    if (ISWWAT == "Y")
    {
        PESW = std::max(0.0, TSW - TLL);
    }
    else
    {
        PESW = std::max(0.0, s.TDL - TLL);
    }
    if (s.NDays == 30)
    {
        for (I=1 ; I!=29 + 1 ; I+=1)
        {
            s.WetDay[I - 1] = s.WetDay[I + 1 - 1];
        }
    }
    else
    {
        s.NDays = s.NDays + 1;
    }
    if (ex.RAIN + ex.DEPIR > 1.E-6)
    {
        s.WetDay[s.NDays - 1] = 1;
    }
    else
    {
        s.WetDay[s.NDays - 1] = 0;
    }
    NWetDays = accumulate(s.WetDay.begin(), s.WetDay.end(), 0);
    WFT = float(NWetDays) / float(s.NDays);
    CV = (ex.BIOMAS + ex.MULCHMASS) / 1000.;
    BCV1 = CV / (CV + std::exp(5.3396 - (2.3951 * CV)));
    BCV2 = ex.SNOW / (ex.SNOW + std::exp(2.303 - (0.2197 * ex.SNOW)));
    BCV = std::max(BCV1, BCV2);
    tie(s.TMA, s.SRFTEMP, s.ST, X2_AVG, s.X2_PREV) = SOILT_EPIC(NL, B, BCV, s.CUMDPT, DP, s.DSMID, NLAYR, PESW, ex.TAV, ex.TAVG, ex.TMAX, ex.TMIN, s.WetDay[s.NDays - 1], WFT, WW, s.TMA, s.ST, s.X2_PREV);
}
std::tuple<std::vector<double> ,double,std::vector<double> ,double,double> STEMP_EPIC::SOILT_EPIC(int NL, double B, double BCV, double CUMDPT, double DP, std::vector<double> DSMID, int NLAYR, double PESW, double TAV, double TAVG, double TMAX, double TMIN, int WetDay, double WFT, double WW, std::vector<double> TMA, std::vector<double> ST, double X2_PREV)
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
    WC = std::max(0.01, PESW) / (WW * CUMDPT) * 10.0;
    FX = std::exp(B * std::pow((1.0 - WC) / (1.0 + WC), 2));
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
    for (K=5 ; K!=2 - 1 ; K+=-1)
    {
        TMA[K - 1] = TMA[K - 1 - 1];
    }
    X2_AVG = accumulate(TMA.begin(), TMA.end(), 0.0) / 5.0;
    X3 = (1. - BCV) * X2_AVG + (BCV * X2_PREV);
    SRFTEMP = std::min(X2_AVG, X3);
    X1 = TAV - X3;
    for (L=1 ; L!=NLAYR + 1 ; L+=1)
    {
        ZD = DSMID[(L - 1)] / DD;
        F = ZD / (ZD + std::exp(-.8669 - (2.0775 * ZD)));
        ST[L - 1] = LAG * ST[(L - 1)] + ((1. - LAG) * (F * X1 + X3));
    }
    X2_PREV = X2_AVG;
    return make_tuple(TMA, SRFTEMP, ST, X2_AVG, X2_PREV);
}