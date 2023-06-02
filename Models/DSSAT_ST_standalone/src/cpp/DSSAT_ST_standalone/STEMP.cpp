#ifndef _STEMP_
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
#include "STEMP.h"
using namespace std;

void STEMP::Init(STEMP_State& s, STEMP_State& s1, STEMP_Rate& r, STEMP_Auxiliary& a, STEMP_Exogenous& ex)
{
    double SRAD = ex.getSRAD();
    double TAVG = ex.getTAVG();
    double TMAX = ex.getTMAX();
    double TAV = ex.getTAV();
    double TAMP = ex.getTAMP();
    int DOY = ex.getDOY();
    double CUMDPT;
    vector<double> DSMID(NL);
    double TDL;
    vector<double> TMA(5);
    double ATOT;
    double SRFTEMP;
    vector<double> ST(NL);
    double HDAY;
    CUMDPT = 0.0;
    fill(DSMID.begin(),DSMID.end(), 0.0);
    TDL = 0.0;
    fill(TMA.begin(),TMA.end(), 0.0);
    ATOT = 0.0;
    SRFTEMP = 0.0;
    fill(ST.begin(),ST.end(), 0.0);
    HDAY = 0.0;
    int I;
    int L;
    double ABD;
    double ALBEDO;
    double B;
    double DP;
    double FX;
    double PESW;
    double TBD;
    double WW;
    double TLL;
    double TSW;
    vector<double> DLI(NL);
    vector<double> DSI(NL);
    vector<double> SWI(NL);
    SWI = SW;
    DSI = DS;
    if (XLAT < 0.0)
    {
        HDAY = 20.0;
    }
    else
    {
        HDAY = 200.0;
    }
    TBD = 0.0;
    TLL = 0.0;
    TSW = 0.0;
    TDL = 0.0;
    CUMDPT = 0.0;
    for (L=1 ; L!=NLAYR + 1 ; L+=1)
    {
        if (L == 1)
        {
            DLI[L - 1] = DSI[L - 1];
        }
        else
        {
            DLI[L - 1] = DSI[L - 1] - DSI[L - 1 - 1];
        }
        DSMID[L - 1] = CUMDPT + (DLI[(L - 1)] * 5.0);
        CUMDPT = CUMDPT + (DLI[(L - 1)] * 10.0);
        TBD = TBD + (BD[(L - 1)] * DLI[(L - 1)]);
        TLL = TLL + (LL[(L - 1)] * DLI[(L - 1)]);
        TSW = TSW + (SWI[(L - 1)] * DLI[(L - 1)]);
        TDL = TDL + (DUL[(L - 1)] * DLI[(L - 1)]);
    }
    if (ISWWAT == "Y")
    {
        PESW = max(0.0, TSW - TLL);
    }
    else
    {
        PESW = max(0.0, TDL - TLL);
    }
    ABD = TBD / DSI[(NLAYR - 1)];
    FX = ABD / (ABD + (686.0 * exp(-(5.63 * ABD))));
    DP = 1000.0 + (2500.0 * FX);
    WW = 0.356 - (0.144 * ABD);
    B = log(500.0 / DP);
    ALBEDO = MSALB;
    for (I=1 ; I!=5 + 1 ; I+=1)
    {
        TMA[I - 1] = int(TAVG * 10000.) / 10000.;
    }
    ATOT = TMA[(1 - 1)] * 5.0;
    for (L=1 ; L!=NLAYR + 1 ; L+=1)
    {
        ST[L - 1] = TAVG;
    }
    for (I=1 ; I!=8 + 1 ; I+=1)
    {
        tie(ATOT, TMA, SRFTEMP, ST) = SOILT(NL, ALBEDO, B, CUMDPT, DOY, DP, HDAY, NLAYR, PESW, SRAD, TAMP, TAV, TAVG, TMAX, WW, DSMID, ATOT, TMA);
    }
    s.setCUMDPT(CUMDPT);
    s.setDSMID(DSMID);
    s.setTDL(TDL);
    s.setTMA(TMA);
    s.setATOT(ATOT);
    s.setSRFTEMP(SRFTEMP);
    s.setST(ST);
    s.setHDAY(HDAY);
}
STEMP::STEMP() { }
int STEMP::getNL() {return this-> NL; }
string STEMP::getISWWAT() {return this-> ISWWAT; }
vector<double> & STEMP::getBD() {return this-> BD; }
vector<double> & STEMP::getDLAYR() {return this-> DLAYR; }
vector<double> & STEMP::getDS() {return this-> DS; }
vector<double> & STEMP::getDUL() {return this-> DUL; }
vector<double> & STEMP::getLL() {return this-> LL; }
int STEMP::getNLAYR() {return this-> NLAYR; }
double STEMP::getMSALB() {return this-> MSALB; }
vector<double> & STEMP::getSW() {return this-> SW; }
double STEMP::getXLAT() {return this-> XLAT; }
void STEMP::setNL(int _NL) { this->NL = _NL; }
void STEMP::setISWWAT(string _ISWWAT) { this->ISWWAT = _ISWWAT; }
void STEMP::setBD(vector<double> const & _BD){
    this->BD = _BD;
}
void STEMP::setDLAYR(vector<double> const & _DLAYR){
    this->DLAYR = _DLAYR;
}
void STEMP::setDS(vector<double> const & _DS){
    this->DS = _DS;
}
void STEMP::setDUL(vector<double> const & _DUL){
    this->DUL = _DUL;
}
void STEMP::setLL(vector<double> const & _LL){
    this->LL = _LL;
}
void STEMP::setNLAYR(int _NLAYR) { this->NLAYR = _NLAYR; }
void STEMP::setMSALB(double _MSALB) { this->MSALB = _MSALB; }
void STEMP::setSW(vector<double> const & _SW){
    this->SW = _SW;
}
void STEMP::setXLAT(double _XLAT) { this->XLAT = _XLAT; }
void STEMP::Calculate_Model(STEMP_State& s, STEMP_State& s1, STEMP_Rate& r, STEMP_Auxiliary& a, STEMP_Exogenous& ex)
{
    //- Name: STEMP -Version:  1.0, -Time step:  1
    //- Description:
    //            * Title: Model of STEMP
    //            * Authors: DSSAT 
    //            * Reference: https://doi.org/10.2134/agronj1994.00021962008600060014x
    //            * Institution: DSSAT Florida
    //            * ExtendedDescription: None
    //            * ShortDescription: Determines soil temperature by layer
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
    //                          ** description : Water simulation control switch
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
    //                          ** description : Thickness of soil layer L
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : cm
    //            * name: DS
    //                          ** description : Cumulative depth in soil layer L
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
    //                          ** description : Volumetric soil water content in soil layer L at lower limit
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
    //            * name: MSALB
    //                          ** description : Soil albedo with mulch and soil water effects
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : dimensionless
    //            * name: SRAD
    //                          ** description : Solar radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : MJ/m2-d
    //            * name: SW
    //                          ** description : Volumetric soil water content in layer L
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
    //            * name: XLAT
    //                          ** description : Latitude
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
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
    //            * name: TAMP
    //                          ** description : Amplitude of temperature function used to calculate soil temperatures
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
    //                          ** description : Depth to midpoint of soil layer L
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
    //                          ** description : Array of previous 5 days of average soil temperatures
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 5
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : degC
    //            * name: ATOT
    //                          ** description : Sum of TMA array (last 5 days soil temperature)
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
    //                          ** description : Soil temperature in soil layer L
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NL
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : degC
    //            * name: DOY
    //                          ** description : Current day of simulation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : d
    //            * name: HDAY
    //                          ** description : Haverst day
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : day
    //- outputs:
    //            * name: CUMDPT
    //                          ** description : Cumulative depth of soil profile
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : mm
    //            * name: DSMID
    //                          ** description : Depth to midpoint of soil layer L
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
    //                          ** description : Array of previous 5 days of average soil temperatures
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 5
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : degC
    //            * name: ATOT
    //                          ** description : Sum of TMA array (last 5 days soil temperature)
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
    //                          ** description : Soil temperature in soil layer L
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NL
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : degC
    double SRAD = ex.getSRAD();
    double TAVG = ex.getTAVG();
    double TMAX = ex.getTMAX();
    double TAV = ex.getTAV();
    double TAMP = ex.getTAMP();
    double CUMDPT = s.getCUMDPT();
    vector<double>  DSMID = s.getDSMID();
    double TDL = s.getTDL();
    vector<double>  TMA = s.getTMA();
    double ATOT = s.getATOT();
    double SRFTEMP = s.getSRFTEMP();
    vector<double>  ST = s.getST();
    int DOY = ex.getDOY();
    double HDAY = s.getHDAY();
    int L;
    double ABD;
    double ALBEDO;
    double B;
    double DP;
    double FX;
    double PESW;
    double TBD;
    double WW;
    double TLL;
    double TSW;
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
    ALBEDO = MSALB;
    if (ISWWAT == "Y")
    {
        PESW = max(0.0, TSW - TLL);
    }
    else
    {
        PESW = max(0.0, TDL - TLL);
    }
    tie(ATOT, TMA, SRFTEMP, ST) = SOILT(NL, ALBEDO, B, CUMDPT, DOY, DP, HDAY, NLAYR, PESW, SRAD, TAMP, TAV, TAVG, TMAX, WW, DSMID, ATOT, TMA);
    s.setCUMDPT(CUMDPT);
    s.setDSMID(DSMID);
    s.setTDL(TDL);
    s.setTMA(TMA);
    s.setATOT(ATOT);
    s.setSRFTEMP(SRFTEMP);
    s.setST(ST);
}
tuple<double,vector<double> ,double,vector<double> > STEMP:: SOILT(int NL, double ALBEDO, double B, double CUMDPT, int DOY, double DP, double HDAY, int NLAYR, double PESW, double SRAD, double TAMP, double TAV, double TAVG, double TMAX, double WW, vector<double> DSMID, double ATOT, vector<double> TMA)
{
    int K;
    int L;
    double ALX;
    double DD;
    double DT;
    double FX;
    double SRFTEMP;
    double TA;
    double WC;
    double ZD;
    vector<double> ST(NL);
    ALX = (float(DOY) - HDAY) * 0.0174;
    ATOT = ATOT - TMA[5 - 1];
    for (K=5 ; K!=2 - 1 ; K+=-1)
    {
        TMA[K - 1] = TMA[K - 1 - 1];
    }
    TMA[1 - 1] = (1.0 - ALBEDO) * (TAVG + ((TMAX - TAVG) * sqrt(SRAD * 0.03))) + (ALBEDO * TMA[(1 - 1)]);
    TMA[1 - 1] = int(TMA[(1 - 1)] * 10000.) / 10000.;
    ATOT = ATOT + TMA[1 - 1];
    WC = max(0.01, PESW) / (WW * CUMDPT) * 10.0;
    FX = exp(B * pow((1.0 - WC) / (1.0 + WC), 2));
    DD = FX * DP;
    TA = TAV + (TAMP * cos(ALX) / 2.0);
    DT = ATOT / 5.0 - TA;
    for (L=1 ; L!=NLAYR + 1 ; L+=1)
    {
        ZD = -(DSMID[(L - 1)] / DD);
        ST[L - 1] = TAV + ((TAMP / 2.0 * cos((ALX + ZD)) + DT) * exp(ZD));
        ST[L - 1] = int(ST[(L - 1)] * 1000.) / 1000.;
    }
    SRFTEMP = TAV + (TAMP / 2. * cos(ALX) + DT);
    return make_tuple(ATOT, TMA, SRFTEMP, ST);
}
#endif