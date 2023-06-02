# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

import numpy

#%%CyML Model Begin%%
def model_layers_temp(temp_profile:'Array[float]',
         layer_thick:'Array[int]'):
    """
     - Name: layers_temp -Version: 1.0, -Time step: 1
     - Description:
                 * Title: layers mean temperature model
                 * Authors: None
                 * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
                 * Institution: INRAE
                 * ExtendedDescription: None
                 * ShortDescription: None
     - inputs:
                 * name: temp_profile
                               ** description : soil temperature profile
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLEARRAY
                               ** len : 
                               ** max : 50.0
                               ** min : -50.0
                               ** default : 0.0
                               ** unit : degC
                 * name: layer_thick
                               ** description : layers thickness
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INTARRAY
                               ** len : 
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : cm
     - outputs:
                 * name: layer_temp
                               ** description : soil layers temperature
                               ** datatype : DOUBLEARRAY
                               ** variablecategory : state
                               ** len : 
                               ** max : 50.0
                               ** min : -50.0
                               ** unit : degC
    """

    layer_temp:'array[float]'
    z:int
    layers_nb:int
    up_depth:List[int] = []
    layer_depth:List[int] = []
    depth_value:int
    layers_nb = get_layers_number(layer_thick)
    layer_temp = array("f", [0] * layers_nb)
    up_depth = array("f", [0] * (layers_nb + 1))
    layer_depth = array("f", [0] * layers_nb)
    up_depth = [0] * (layers_nb + 1)
    layer_depth = layer_thickness2depth(layer_thick)
    for z in range(1 , layers_nb + 1 , 1):
        depth_value = layer_depth[z - 1]
        up_depth[z + 1 - 1] = depth_value
    for z in range(1 , layers_nb + 1 , 1):
        layer_temp[z - 1] = sum(temp_profile[(up_depth[z - 1] + 1 - 1):up_depth[(z + 1 - 1)]]) / layer_thick[(z - 1)]
    return layer_temp
#%%CyML Model End%%

def layer_thickness2depth(layer_thick:'Array[int]'):
    layer_depth:List[int] = []
    layers_nb:int
    z:int
    layers_nb = len(layer_thick)
    layer_depth = array("f", [0] * layers_nb)
    layer_depth = [0] * layers_nb
    for z in range(1 , layers_nb + 1 , 1):
        if layer_thick[z - 1] != 0:
            layer_depth[z - 1] = sum(layer_thick[1 - 1:z])
    return layer_depth

def get_layers_number(layer_thick_or_depth:'Array[int]'):
    layers_number:int
    z:int
    layers_number = 0
    for z in range(1 , len(layer_thick_or_depth) + 1 , 1):
        if layer_thick_or_depth[z - 1] != 0:
            layers_number = layers_number + 1
    return layers_number