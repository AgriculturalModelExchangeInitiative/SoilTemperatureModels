# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_thermaldiffu(ThermalDiffusivity:'Array[float]',
         ThermalConductivity:'Array[float]',
         HeatCapacity:'Array[float]',
         layersNumber:int):
    """
     - Name: ThermalDiffu -Version: 001, -Time step: 1
     - Description:
                 * Title: ThermalDiffu model
                 * Authors: simone.bregaglio
                 * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
                 * Institution: University Of Milan
                 * ExtendedDescription: Strategy for the calculation of thermal diffusitivity. Bristow, K.L., Thermal conductivity, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series
                 * ShortDescription: Strategy for the calculation of thermal diffusitivity
     - inputs:
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
                 * name: ThermalConductivity
                               ** description : Thermal conductivity of soil layer
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 8
                               ** min : 0.025
                               ** default : 1
                               ** unit : W m-1 K-1
                 * name: HeatCapacity
                               ** description : Volumetric specific heat of soil
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 300
                               ** min : 0
                               ** default : 20
                               ** unit : MJ m-3
                 * name: layersNumber
                               ** description : Number of layersl
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 300
                               ** min : 0
                               ** default : 10
                               ** unit : dimensionless
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
    for i in range(0 , layersNumber , 1):
        ThermalDiffusivity[i] = ThermalConductivity[i] / HeatCapacity[i] / 100
    return ThermalDiffusivity
#%%CyML Model End%%