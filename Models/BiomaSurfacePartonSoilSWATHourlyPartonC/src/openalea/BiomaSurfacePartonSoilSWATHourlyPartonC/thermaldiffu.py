# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_thermaldiffu(ThermalConductivity:'Array[float]',
         ThermalDiffusivity:'Array[float]',
         HeatCapacity:'Array[float]'):
    """
     - Name: ThermalDiffu -Version: 001, -Time step: 1
     - Description:
                 * Title: ThermalDiffu model
                 * Authors: simone.bregaglio@unimi.it
                 * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
                 * Institution: University Of Milan
                 * ExtendedDescription: Strategy for the calculation of thermal diffusitivity. Bristow, K.L., Thermal conductivity, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series #5: Madison, Wisconsin. p. 1209-1226. Diekkruger, B. (1996) SIMULAT - Ein Modellsystem zur Berechnung der Wasser- und Stoffdynamik landwirtschaftlich genutzter Standorte (SIMULAT - a model system for the calculation of water and matter dynamics on agricultural sites, in German). In: Wasser- und Stoffdynamik in AgrarÃ´kosystemen, Sonderf.
                 * ShortDescription: None
     - inputs:
                 * name: ThermalConductivity
                               ** description : Thermal conductivity of soil layer
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 8
                               ** min : 0.025
                               ** default : 1
                               ** unit : W m-1 K-1
                 * name: ThermalDiffusivity
                               ** description : Thermal diffusivity of soil layer
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 1
                               ** min : 0
                               ** default : 0.0025
                               ** unit : mm s-1
                 * name: HeatCapacity
                               ** description : Volumetric specific heat of soil
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 300
                               ** min : 0
                               ** default : 20
                               ** unit : MJ m-3 Â°C-1
     - outputs:
                 * name: ThermalDiffusivity
                               ** description : Thermal diffusivity of soil layer
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 1
                               ** min : 0
                               ** unit : mm s-1
    """

    i:int
    for i in range(0 , len(ThermalDiffusivity) , 1):
        ThermalDiffusivity[i] = ThermalConductivity[i] / HeatCapacity[i] / 100
    return ThermalDiffusivity
#%%CyML Model End%%