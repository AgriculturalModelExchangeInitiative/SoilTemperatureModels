# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from DSSAT_ST_standalone.stemp import model_stemp

#%%CyML Model Begin%%
def model_stemp_(DSMID:'Array[float]',
         TAVG:float,
         ST:'Array[float]',
         TMAX:float,
         TAV:float,
         DLAYR:'Array[float]',
         CUMDPT:float,
         SW:'Array[float]',
         TAMP:float,
         NLAYR:int,
         DOY:int,
         LL:'Array[float]',
         TMA:'Array[float]',
         ISWWAT:str,
         DUL:'Array[float]',
         BD:'Array[float]',
         SRFTEMP:float,
         DS:'Array[float]',
         NL:int,
         XLAT:float,
         SRAD:float,
         MSALB:float,
         ATOT:float):
    """
     - Name: STEMP_ -Version:  1.0, -Time step:  1
     - Description:
                 * Title: STEMP_ model
                 * Authors: DSSAT 
                 * Reference: https://doi.org/10.2134/agronj1994.00021962008600060014x
                 * Institution: DSSAT Florida
                 * ExtendedDescription: None
                 * ShortDescription: Determines soil temperature by layer
     - inputs:
                 * name: DSMID
                               ** description : Depth to midpoint of soil layer L
                               ** inputtype : variable
                               ** variablecategory : state
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
                 * name: ST
                               ** description : Soil temperature in soil layer L
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: TMAX
                               ** description : Maximum daily temperature
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
                 * name: DLAYR
                               ** description : Thickness of soil layer L
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm
                 * name: CUMDPT
                               ** description : Cumulative depth of soil profile
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : mm
                 * name: SW
                               ** description : Volumetric soil water content in layer L
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm3 [water] / cm3 [soil]
                 * name: TAMP
                               ** description : Amplitude of temperature function used to calculate soil temperatures
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: NLAYR
                               ** description : Actual number of soil layers
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : dimensionless
                 * name: DOY
                               ** description : Current day of simulation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : d
                 * name: LL
                               ** description : Volumetric soil water content in soil layer L at lower limit
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm3 [water] / cm3 [soil]
                 * name: TMA
                               ** description : Array of previous 5 days of average soil temperatures
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: ISWWAT
                               ** description : Water simulation control switch
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : STRING
                               ** max : 
                               ** min : 
                               ** default : Y
                               ** unit : dimensionless
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
                 * name: SRFTEMP
                               ** description : Temperature of soil surface litter
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: DS
                               ** description : Cumulative depth in soil layer L
                               ** inputtype : parameter
                               ** parametercategory : soil
                               ** datatype : DOUBLEARRAY
                               ** len : NL
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
                 * name: XLAT
                               ** description : Latitude
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
                 * name: SRAD
                               ** description : Solar radiation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : MJ/m2-d
                 * name: MSALB
                               ** description : Soil albedo with mulch and soil water effects
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : dimensionless
                 * name: ATOT
                               ** description : Sum of TMA array (last 5 days soil temperature)
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : degC
     - outputs:
                 * name: CUMDPT
                               ** description : Cumulative depth of soil profile
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : mm
                 * name: DSMID
                               ** description : Depth to midpoint of soil layer L
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** unit : cm
                 * name: TMA
                               ** description : Array of previous 5 days of average soil temperatures
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** unit : degC
                 * name: ATOT
                               ** description : Sum of TMA array (last 5 days soil temperature)
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : degC
                 * name: SRFTEMP
                               ** description : Temperature of soil surface litter
                               ** datatype : DOUBLE
                               ** variablecategory : state
                               ** max : 
                               ** min : 
                               ** unit : degC
                 * name: ST
                               ** description : Soil temperature in soil layer L
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : NL
                               ** max : 
                               ** min : 
                               ** unit : degC
    """

    (CUMDPT, DSMID, TMA, ATOT, SRFTEMP, ST) = model_stemp(NL, ISWWAT, BD, DLAYR, DS, DUL, LL, NLAYR, MSALB, SRAD, SW, TAVG, TMAX, XLAT, TAV, TAMP, CUMDPT, DSMID, TMA, ATOT, SRFTEMP, ST, DOY)
    return (CUMDPT, DSMID, TMA, ATOT, SRFTEMP, ST)
#%%CyML Model End%%