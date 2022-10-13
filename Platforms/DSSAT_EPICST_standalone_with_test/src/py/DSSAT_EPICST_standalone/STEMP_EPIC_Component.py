# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from DSSAT_EPICST_standalone.stemp_epic import model_stemp_epic

#%%CyML Model Begin%%
def model_stemp_epic_(DS:'Array[float]',
         TAVG:float,
         TAV:float,
         ISWWAT:str,
         CUMDPT:float,
         DSMID:'Array[float]',
         LL:'Array[float]',
         DLAYR:'Array[float]',
         BD:'Array[float]',
         TMAX:float,
         TMA:'Array[float]',
         SW:'Array[float]',
         MULCHMASS:float,
         NLAYR:int,
         SNOW:float,
         BIOMAS:float,
         NDays:int,
         WetDay:'Array[int]',
         TDL:float,
         NL:int,
         DEPIR:float,
         DUL:'Array[float]',
         TMIN:float,
         ST:'Array[float]',
         X2_PREV:float,
         RAIN:float,
         TAMP:float,
         SRFTEMP:float):
    """
     - Name: STEMP_EPIC_ -Version:  1.0, -Time step:  1
     - Description:
                 * Title: STEMP_EPIC_ model
                 * Authors: Kenneth N. Potter , Jimmy R. Williams 
                 * Reference: https://doi.org/10.2134/agronj1994.00021962008600060014x
                 * Institution: USDA-ARS, USDA-ARS
                 * ExtendedDescription: None
                 * ShortDescription: Determines soil temperature by layer test encore
     - inputs:
                 * name: DS
                               ** description : Cumulative depth in soil layer NL
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm
                 * name: TAVG
                               ** description : Average daily temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: TAV
                               ** description : Average annual soil temperature, used with TAMP to calculate soil temperature.
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: ISWWAT
                               ** description : Water simulation control switch (Y or N)
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : STRING
                               ** max : 
                               ** min : 
                               ** default : Y
                               ** unit : dimensionless
                 * name: CUMDPT
                               ** description : Cumulative depth of soil profile
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: DSMID
                               ** description : Depth to midpoint of soil layer NL
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm
                 * name: LL
                               ** description : Volumetric soil water content in soil layer NL at lower limit
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm3 [water] / cm3 [soil]
                 * name: DLAYR
                               ** description : Thickness of soil layer NL
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm
                 * name: BD
                               ** description : Bulk density, soil layer NL
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : g [soil] / cm3 [soil]
                 * name: TMAX
                               ** description : Maximum daily temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: TMA
                               ** description : Array of previous 5 days of average soil temperatures.
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 5
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: SW
                               ** description : Volumetric soil water content in layer NL
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm3 [water] / cm3 [soil]
                 * name: MULCHMASS
                               ** description : Mulch Mass
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : kg/ha
                 * name: NLAYR
                               ** description : Actual number of soil layers
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : dimensionless
                 * name: SNOW
                               ** description : Snow cover
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: BIOMAS
                               ** description : Biomass
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : kg/ha
                 * name: NDays
                               ** description : Number of days ...
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : day
                 * name: WetDay
                               ** description : Wet Days
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : INTARRAY
                               ** len : 30
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : day
                 * name: TDL
                               ** description : Total water content of soil at drained upper limit
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm
                 * name: NL
                               ** description : Number of soil layers
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : dimensionless
                 * name: DEPIR
                               ** description : Depth of irrigation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: DUL
                               ** description : Volumetric soil water content at Drained Upper Limit in soil layer L
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm3[water]/cm3[soil]
                 * name: TMIN
                               ** description : Minimum Temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: ST
                               ** description : Soil temperature in soil layer NL
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: X2_PREV
                               ** description : Temperature of soil surface at precedent timestep
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: RAIN
                               ** description : daily rainfall
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: TAMP
                               ** description : Annual amplitude of the average air temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: SRFTEMP
                               ** description : Temperature of soil surface litter
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
     - outputs:
                 * name: SRFTEMP
                               ** description : Temperature of soil surface litter
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : degC
                 * name: NDays
                               ** description : Number of days ...
                               ** datatype : INT
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : day
                 * name: TDL
                               ** description : Total water content of soil at drained upper limit
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : cm
                 * name: WetDay
                               ** description : Wet Days
                               ** datatype : INTARRAY
                               ** variablecategory : state
                               ** len : 30
                               ** max : 
                               ** min : 
                               ** unit : day
                 * name: ST
                               ** description : Soil temperature in soil layer NL
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** unit : degC
                 * name: TMA
                               ** description : Array of previous 5 days of average soil temperatures.
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 5
                               ** max : 
                               ** min : 
                               ** unit : degC
                 * name: X2_PREV
                               ** description : Temperature of soil surface at precedent timestep
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : degC
    """

    (SRFTEMP, NDays, TDL, WetDay, ST, TMA, X2_PREV) = model_stemp_epic(NL, ISWWAT, BD, DLAYR, DS, DUL, LL, NLAYR, TAMP, RAIN, CUMDPT, DSMID, SW, TAVG, TMAX, TMIN, TAV, SRFTEMP, NDays, TDL, WetDay, ST, TMA, X2_PREV, DEPIR, BIOMAS, MULCHMASS, SNOW)
    return (SRFTEMP, NDays, TDL, WetDay, ST, TMA, X2_PREV)
#%%CyML Model End%%