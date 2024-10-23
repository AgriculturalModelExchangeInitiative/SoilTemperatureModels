# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Init Begin%%
def init_thermalconductivitysimulat(VolumetricWaterContent:'Array[float]',
         BulkDensity:'Array[float]',
         Clay:'Array[float]'):
    ThermalConductivity:'array[float]'
    ThermalConductivity = None
    ThermalConductivity = array('f', [0.0]*len(VolumetricWaterContent))
    return ThermalConductivity
#%%CyML Init End%%

#%%CyML Model Begin%%
def model_thermalconductivitysimulat(VolumetricWaterContent:'Array[float]',
         BulkDensity:'Array[float]',
         Clay:'Array[float]',
         ThermalConductivity:'Array[float]'):
    """
     - Name: ThermalConductivitySIMULAT -Version: 001, -Time step: 1
     - Description:
                 * Title: ThermalConductivitySIMULAT model
                 * Authors: simone.bregaglio
                 * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
                 * Institution: University Of Milan
                 * ExtendedDescription: Strategy for the calculation of thermal conductivity. Bristow, K.L., Thermal conductivity, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series
                 * ShortDescription: Strategy for the calculation of thermal conductivity
     - inputs:
                 * name: VolumetricWaterContent
                               ** description : Volumetric soil water content
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 0.8
                               ** min : 0
                               ** default : 0.25
                               ** unit : m3 m-3
                 * name: BulkDensity
                               ** description : Bulk density
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 1.8
                               ** min : 0.9
                               ** default : 1.3
                               ** unit : t m-3
                 * name: Clay
                               ** description : Clay content of soil layer
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 100
                               ** min : 0
                               ** default : 0
                               ** unit : 
                 * name: ThermalConductivity
                               ** description : Thermal conductivity of soil layer
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 8
                               ** min : 0.025
                               ** default : 
                               ** unit : W m-1 K-1
     - outputs:
                 * name: ThermalConductivity
                               ** description : Thermal conductivity of soil layer
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 8
                               ** min : 0.025
                               ** unit : W m-1 K-1
    """

    i:int
    Aterm:float
    Bterm:float
    Cterm:float
    Dterm:float
    Eterm:float
    Aterm = float(0)
    Bterm = float(0)
    Cterm = float(0)
    Dterm = float(0)
    Eterm = float(4)
    for i in range(0 , len(VolumetricWaterContent) , 1):
        Aterm = 0.65 - (0.78 * BulkDensity[i]) + (0.6 * pow(BulkDensity[i], 2))
        Bterm = 1.06 * BulkDensity[i] * VolumetricWaterContent[i]
        Cterm = 1 + (2.6 * sqrt(Clay[i] / 100))
        Dterm = 0.03 + (0.1 * pow(BulkDensity[i], 2))
        ThermalConductivity[i] = Aterm + (Bterm * VolumetricWaterContent[i]) - ((Aterm - Dterm) * pow(exp(-(Cterm * VolumetricWaterContent[i])), Eterm))
    return ThermalConductivity
#%%CyML Model End%%