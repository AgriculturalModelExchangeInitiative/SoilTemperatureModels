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
#include "SnowCoverCalculator.h"
using namespace Simplace_Soil_Temperature;
void SnowCoverCalculator::Init(SoilTemperatureState &s, SoilTemperatureState &s1, SoilTemperatureRate &r, SoilTemperatureAuxiliary &a, SoilTemperatureExogenous &ex)
{
    s.SnowWaterContent = 0.0;
    s.SoilSurfaceTemperature = 0.0;
    s.AgeOfSnow = 0;
    s.pInternalAlbedo = 0.0;
    double TMEAN;
    double TAMPL;
    double DST;
    if (Albedo == float(0))
    {
        s.pInternalAlbedo = 0.0226 * std::log10(cCarbonContent) + 0.1502;
    }
    else
    {
        s.pInternalAlbedo = Albedo;
    }
    TMEAN = 0.5 * (ex.iTempMax + ex.iTempMin);
    TAMPL = 0.5 * (ex.iTempMax - ex.iTempMin);
    DST = TMEAN + (TAMPL * (ex.iRadiation * (1 - s.pInternalAlbedo) - 14) / 20);
    s.SoilSurfaceTemperature = DST;
    s.AgeOfSnow = cInitialAgeOfSnow;
    s.SnowWaterContent = cInitialSnowWaterContent;
}
SnowCoverCalculator::SnowCoverCalculator() {}
double SnowCoverCalculator::getcCarbonContent() { return this->cCarbonContent; }
int SnowCoverCalculator::getcInitialAgeOfSnow() { return this->cInitialAgeOfSnow; }
double SnowCoverCalculator::getcInitialSnowWaterContent() { return this->cInitialSnowWaterContent; }
double SnowCoverCalculator::getAlbedo() { return this->Albedo; }
double SnowCoverCalculator::getcSnowIsolationFactorA() { return this->cSnowIsolationFactorA; }
double SnowCoverCalculator::getcSnowIsolationFactorB() { return this->cSnowIsolationFactorB; }
void SnowCoverCalculator::setcCarbonContent(double _cCarbonContent) { this->cCarbonContent = _cCarbonContent; }
void SnowCoverCalculator::setcInitialAgeOfSnow(int _cInitialAgeOfSnow) { this->cInitialAgeOfSnow = _cInitialAgeOfSnow; }
void SnowCoverCalculator::setcInitialSnowWaterContent(double _cInitialSnowWaterContent) { this->cInitialSnowWaterContent = _cInitialSnowWaterContent; }
void SnowCoverCalculator::setAlbedo(double _Albedo) { this->Albedo = _Albedo; }
void SnowCoverCalculator::setcSnowIsolationFactorA(double _cSnowIsolationFactorA) { this->cSnowIsolationFactorA = _cSnowIsolationFactorA; }
void SnowCoverCalculator::setcSnowIsolationFactorB(double _cSnowIsolationFactorB) { this->cSnowIsolationFactorB = _cSnowIsolationFactorB; }
void SnowCoverCalculator::Calculate_Model(SoilTemperatureState &s, SoilTemperatureState &s1, SoilTemperatureRate &r, SoilTemperatureAuxiliary &a, SoilTemperatureExogenous &ex)
{
    //- Name: SnowCoverCalculator -Version: 001, -Time step: 1
    //- Description:
    //            * Title: SnowCoverCalculator model
    //            * Authors: Gunther Krauss
    //            * Reference: ('http://www.simplace.net/doc/simplace_modules/',)
    //            * Institution: INRES Pflanzenbau, Uni Bonn
    //            * ExtendedDescription: as given in the documentation
    //            * ShortDescription: None
    //- inputs:
    //            * name: cCarbonContent
    //                          ** description : Carbon content of upper soil layer
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 20.0
    //                          ** min : 0.5
    //                          ** default : 0.5
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/percent
    //            * name: cInitialAgeOfSnow
    //                          ** description : Initial age of snow
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/percent
    //            * name: cInitialSnowWaterContent
    //                          ** description : Initial snow water content
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1500.0
    //                          ** min : 0.0
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/percent
    //            * name: Albedo
    //                          ** description : Albedo
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1.0
    //                          ** min : 0.0
    //                          ** default : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/one
    //            * name: pInternalAlbedo
    //                          ** description : Albedo privat
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 1.0
    //                          ** min : 0.0
    //                          ** default : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/one
    //            * name: cSnowIsolationFactorA
    //                          ** description : Static part of the snow isolation index calculation
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 10.0
    //                          ** min : 0.0
    //                          ** default : 2.3
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/one
    //            * name: cSnowIsolationFactorB
    //                          ** description : Dynamic part of the snow isolation index calculation
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1.0
    //                          ** min : 0.0
    //                          ** default : 0.22
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/one
    //            * name: iTempMax
    //                          ** description : Daily maximum air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50.0
    //                          ** min : -40.0
    //                          ** default : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    //            * name: iTempMin
    //                          ** description : Daily minimum air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50.0
    //                          ** min : -40.0
    //                          ** default : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    //            * name: iRadiation
    //                          ** description : Global Solar radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 2000.0
    //                          ** min : 0.0
    //                          ** default : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/megajoule_per_square_metre
    //            * name: iRAIN
    //                          ** description : Rain amount
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 60.0
    //                          ** min : 0.0
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre
    //            * name: iCropResidues
    //                          ** description : Crop residues plus above ground biomass
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 20000.0
    //                          ** min : 0.0
    //                          ** default : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/gram_per_square_metre
    //            * name: iPotentialSoilEvaporation
    //                          ** description : Potenial Evaporation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 12.0
    //                          ** min : 0.0
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre
    //            * name: iLeafAreaIndex
    //                          ** description : Leaf area index
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 10.0
    //                          ** min : 0.0
    //                          ** default : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/square_metre_per_square_metre
    //            * name: iSoilTempArray
    //                          ** description : Soil Temp array of last day
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 35.0
    //                          ** min : -15.0
    //                          ** default : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    //            * name: SnowWaterContent
    //                          ** description : Snow water content
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 1500.0
    //                          ** min : 0.0
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre
    //            * name: SoilSurfaceTemperature
    //                          ** description : Soil surface temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 70.0
    //                          ** min : -40.0
    //                          ** default : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    //            * name: AgeOfSnow
    //                          ** description : Age of snow
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/day
    //- outputs:
    //            * name: SnowWaterContent
    //                          ** description : Snow water content
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 1500.0
    //                          ** min : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre
    //            * name: SoilSurfaceTemperature
    //                          ** description : Soil surface temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 70.0
    //                          ** min : -40.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius
    //            * name: AgeOfSnow
    //                          ** description : Age of snow
    //                          ** datatype : INT
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/day
    //            * name: rSnowWaterContentRate
    //                          ** description : daily snow water content change rate
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : rate
    //                          ** max : 1500.0
    //                          ** min : -1500.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/millimetre_per_day
    //            * name: rSoilSurfaceTemperatureRate
    //                          ** description : daily soil surface temperature change rate
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : rate
    //                          ** max : 70.0
    //                          ** min : -40.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius_per_day
    //            * name: rAgeOfSnowRate
    //                          ** description : daily age of snow change rate
    //                          ** datatype : INT
    //                          ** variablecategory : rate
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/one
    //            * name: SnowIsolationIndex
    //                          ** description : Snow isolation index
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : auxiliary
    //                          ** max : 1.0
    //                          ** min : 0.0
    //                          ** unit : http://www.wurvoc.org/vocabularies/om-1.8/one
    double tiCropResidues;
    double tiSoilTempArray;
    double TMEAN;
    double TAMPL;
    double DST;
    double tSoilSurfaceTemperature;
    double tSnowIsolationIndex;
    double SNOWEVAPORATION;
    double SNOWMELT;
    double EAJ;
    double ageOfSnowFactor;
    double SNPKT;
    tiCropResidues = ex.iCropResidues * 10.0;
    tiSoilTempArray = a.iSoilTempArray[0];
    TMEAN = 0.5 * (ex.iTempMax + ex.iTempMin);
    TAMPL = 0.5 * (ex.iTempMax - ex.iTempMin);
    DST = TMEAN + (TAMPL * (ex.iRadiation * (1 - s.pInternalAlbedo) - 14) / 20);
    if (ex.iRAIN > float(0) && (tiSoilTempArray < float(1) || (s.SnowWaterContent > float(3) || s.SoilSurfaceTemperature < float(0))))
    {
        s.SnowWaterContent = s.SnowWaterContent + ex.iRAIN;
    }
    tSnowIsolationIndex = 1.0;
    if (tiCropResidues < float(10))
    {
        tSnowIsolationIndex = tiCropResidues / (tiCropResidues + std::exp(5.34 - (2.4 * tiCropResidues)));
    }
    if (s.SnowWaterContent < 1E-10)
    {
        tSnowIsolationIndex = tSnowIsolationIndex * 0.85;
        tSoilSurfaceTemperature = 0.5 * (DST + ((1 - tSnowIsolationIndex) * DST) + (tSnowIsolationIndex * tiSoilTempArray));
    }
    else
    {
        tSnowIsolationIndex = std::max(s.SnowWaterContent / (s.SnowWaterContent + std::exp(cSnowIsolationFactorA - (cSnowIsolationFactorB * s.SnowWaterContent))), tSnowIsolationIndex);
        tSoilSurfaceTemperature = (1 - tSnowIsolationIndex) * DST + (tSnowIsolationIndex * tiSoilTempArray);
    }
    if (s.SnowWaterContent == float(0) && !(ex.iRAIN > float(0) && tiSoilTempArray < float(1)))
    {
        s.SnowWaterContent = float(0);
    }
    else
    {
        EAJ = .5;
        if (s.SnowWaterContent < float(5))
        {
            EAJ = std::exp(-std::max((0.4 * ex.iLeafAreaIndex), (0.1 * (tiCropResidues + 0.1))));
        }
        SNOWEVAPORATION = ex.iPotentialSoilEvaporation * EAJ;
        ageOfSnowFactor = s.AgeOfSnow / (s.AgeOfSnow + std::exp(5.34 - (2.395 * s.AgeOfSnow)));
        SNPKT = .3333 * (2 * std::min(tSoilSurfaceTemperature, tiSoilTempArray) + ex.iTempMax);
        if (TMEAN > float(0))
        {
            SNOWMELT = std::max(double(0), std::sqrt(ex.iTempMax * ex.iRadiation) * (1.52 + (.54 * ageOfSnowFactor * SNPKT)));
        }
        else
        {
            SNOWMELT = float(0);
        }
        if (SNOWMELT + SNOWEVAPORATION > s.SnowWaterContent)
        {
            SNOWMELT = SNOWMELT / (SNOWMELT + SNOWEVAPORATION) * s.SnowWaterContent;
            SNOWEVAPORATION = SNOWEVAPORATION / (SNOWMELT + SNOWEVAPORATION) * s.SnowWaterContent;
        }
        s.SnowWaterContent = s.SnowWaterContent - (SNOWMELT + SNOWEVAPORATION);
        if (s.SnowWaterContent < float(0))
        {
            s.SnowWaterContent = float(0);
        }
        if (s.SnowWaterContent < float(5))
        {
            s.AgeOfSnow = 0;
        }
        else
        {
            s.AgeOfSnow = s.AgeOfSnow + 1;
        }
    }
    r.rSnowWaterContentRate = s.SnowWaterContent - s.SnowWaterContent;
    r.rSoilSurfaceTemperatureRate = tSoilSurfaceTemperature - s.SoilSurfaceTemperature;
    r.rAgeOfSnowRate = s.AgeOfSnow - s.AgeOfSnow;
    s.SoilSurfaceTemperature = tSoilSurfaceTemperature;
    a.SnowIsolationIndex = tSnowIsolationIndex;
}