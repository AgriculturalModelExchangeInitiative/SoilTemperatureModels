# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

from soiltemperature import model_soiltemperature
from nosnowsoilsurfacetemperature import model_nosnowsoilsurfacetemperature
from withsnowsoilsurfacetemperature import model_withsnowsoilsurfacetemperature

#%%CyML Model Begin%%
def model_soiltemperaturecomp(tmin:float,
         tmax:float,
         globrad:float,
         dampingFactor:float,
         soilCoverage:float,
         prevDaySoilSurfaceTemperature:float,
         soilSurfaceTemperatureBelowSnow:float,
         hasSnowCover:bool,
         timeStep:float,
         soilMoistureConst:float,
         baseTemp:float,
         initialSurfaceTemp:float,
         densityAir:float,
         specificHeatCapacityAir:float,
         densityHumus:float,
         specificHeatCapacityHumus:float,
         densityWater:float,
         specificHeatCapacityWater:float,
         quartzRawDensity:float,
         specificHeatCapacityQuartz:float,
         nTau:float,
         soilAlbedo:float,
         noOfTempLayers:int,
         noOfSoilLayers:int,
         layerThickness:List[float],
         soilBulkDensity:List[float],
         saturation:List[float],
         soilOrganicMatter:List[float],
         prevDaySoilTemperature:List[float],
         V:List[float],
         B:List[float],
         volumeMatrix:List[float],
         volumeMatrixOld:List[float],
         matrixPrimaryDiagonal:List[float],
         matrixSecondaryDiagonal:List[float],
         heatConductivity:List[float],
         heatConductivityMean:List[float],
         heatCapacity:List[float],
         solution:List[float],
         matrixDiagonal:List[float],
         matrixLowerTriangle:List[float],
         heatFlow:List[float]):
    """
     - Name: SoilTemperatureComp -Version: 1, -Time step: 1
     - Description:
                 * Title: SoilTemperature model
                 * Authors: Michael Berg-Mohnicke
                 * Reference: None
                 * Institution: ZALF e.V.
                 * ExtendedDescription: None
                 * ShortDescription: Calculates the soil temperature in all layers and soil surface temperature
     - inputs:
                 * name: tmin
                               ** description : the days min air temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 70
                               ** min : -50
                               ** default : 
                               ** unit : °C
                 * name: tmax
                               ** description : the days max air temperature
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 70
                               ** min : -50
                               ** default : 
                               ** unit : °C
                 * name: globrad
                               ** description : the days global radiation
                               ** inputtype : variable
                               ** variablecategory : exogenous
                               ** datatype : DOUBLE
                               ** max : 30
                               ** min : 0
                               ** default : 0
                               ** unit : MJ/m**2/d
                 * name: dampingFactor
                               ** description : dampingFactor
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.8
                               ** unit : dimensionless
                 * name: soilCoverage
                               ** description : soilCoverage
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 0.0
                               ** default : 0.0
                               ** unit : dimensionless
                 * name: prevDaySoilSurfaceTemperature
                               ** description : soilSurfaceTemperature of previous day
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : °C
                 * name: soilSurfaceTemperatureBelowSnow
                               ** description : soilSurfaceTemperature below snow cover
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.0
                               ** unit : °C
                 * name: hasSnowCover
                               ** description : is soil covered by snow
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : BOOLEAN
                               ** max : 
                               ** min : 
                               ** default : false
                               ** unit : dimensionless
                 * name: timeStep
                               ** description : timeStep
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 1.0
                               ** unit : dimensionless
                 * name: soilMoistureConst
                               ** description : initial soilmoisture
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.25
                               ** unit : m**3/m**3
                 * name: baseTemp
                               ** description : baseTemperature
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 9.5
                               ** unit : °C
                 * name: initialSurfaceTemp
                               ** description : initialSurfaceTemperature
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 10.0
                               ** unit : °C
                 * name: densityAir
                               ** description : DensityAir
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 1.25
                               ** unit : kg/m**3
                 * name: specificHeatCapacityAir
                               ** description : SpecificHeatCapacityAir
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 1005
                               ** unit : J/kg/K
                 * name: densityHumus
                               ** description : DensityHumus
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 1300
                               ** unit : kg/m**3
                 * name: specificHeatCapacityHumus
                               ** description : SpecificHeatCapacityHumus
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 1920
                               ** unit : J/kg/K
                 * name: densityWater
                               ** description : DensityWater
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 1000
                               ** unit : kg/m**3
                 * name: specificHeatCapacityWater
                               ** description : SpecificHeatCapacityWater
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 4192
                               ** unit : J/kg/K
                 * name: quartzRawDensity
                               ** description : QuartzRawDensity
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 2650
                               ** unit : kg/m**3
                 * name: specificHeatCapacityQuartz
                               ** description : SpecificHeatCapacityQuartz
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 750
                               ** unit : J/kg/K
                 * name: nTau
                               ** description : NTau
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.65
                               ** unit : ?
                 * name: soilAlbedo
                               ** description : SoilAlbedo
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** default : 0.7
                               ** unit : ?
                 * name: noOfTempLayers
                               ** description : noOfTempLayers=noOfSoilLayers+2
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 22
                               ** unit : dimensionless
                 * name: noOfSoilLayers
                               ** description : noOfSoilLayers
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : INT
                               ** max : 
                               ** min : 
                               ** default : 20
                               ** unit : dimensionless
                 * name: layerThickness
                               ** description : layerThickness
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLELIST
                               ** len : 22
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : m
                 * name: soilBulkDensity
                               ** description : bulkDensity
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : kg/m**3
                 * name: saturation
                               ** description : saturation
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : m**3/m**3
                 * name: soilOrganicMatter
                               ** description : soilOrganicMatter
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : m**3/m**3
                 * name: prevDaySoilTemperature
                               ** description : soilTemperature
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : °C
                 * name: V
                               ** description : V
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : °C
                 * name: B
                               ** description : B
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : °C
                 * name: volumeMatrix
                               ** description : volumeMatrix
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : °C
                 * name: volumeMatrixOld
                               ** description : volumeMatrixOld
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : °C
                 * name: matrixPrimaryDiagonal
                               ** description : matrixPrimaryDiagonal
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : °C
                 * name: matrixSecondaryDiagonal
                               ** description : matrixSecondaryDiagonal
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : °C
                 * name: heatConductivity
                               ** description : heatConductivity
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : °C
                 * name: heatConductivityMean
                               ** description : heatConductivityMean
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : °C
                 * name: heatCapacity
                               ** description : heatCapacity
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : °C
                 * name: solution
                               ** description : solution
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : °C
                 * name: matrixDiagonal
                               ** description : matrixDiagonal
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : °C
                 * name: matrixLowerTriangle
                               ** description : matrixLowerTriangle
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : °C
                 * name: heatFlow
                               ** description : heatFlow
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** default : 
                               ** unit : °C
     - outputs:
                 * name: soilSurfaceTemperature
                               ** description : soilSurfaceTemperature
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** max : 
                               ** min : 
                               ** unit : °C
                 * name: soilTemperature
                               ** description : soilTemperature next day
                               ** variablecategory : state
                               ** datatype : DOUBLELIST
                               ** len : 20
                               ** max : 
                               ** min : 
                               ** unit : °C
    """

    soilSurfaceTemperature:float
    soilTemperature:List[float] = []
    newSoilTemperature:List[float] = []
    noSnowSoilSurfaceTemperature:float
    soilTemperature = prevDaySoilTemperature
    soilSurfaceTemperature = model_nosnowsoilsurfacetemperature(tmin, tmax, globrad, soilCoverage, dampingFactor, prevDaySoilSurfaceTemperature)
    noSnowSoilSurfaceTemperature = soilSurfaceTemperature
    soilSurfaceTemperature = model_withsnowsoilsurfacetemperature(noSnowSoilSurfaceTemperature, soilSurfaceTemperatureBelowSnow, hasSnowCover)
    newSoilTemperature = model_soiltemperature(soilSurfaceTemperature, timeStep, soilMoistureConst, baseTemp, initialSurfaceTemp, densityAir, specificHeatCapacityAir, densityHumus, specificHeatCapacityHumus, densityWater, specificHeatCapacityWater, quartzRawDensity, specificHeatCapacityQuartz, nTau, soilAlbedo, noOfTempLayers, noOfSoilLayers, layerThickness, soilBulkDensity, saturation, soilOrganicMatter, soilTemperature, V, B, volumeMatrix, volumeMatrixOld, matrixPrimaryDiagonal, matrixSecondaryDiagonal, heatConductivity, heatConductivityMean, heatCapacity, solution, matrixDiagonal, matrixLowerTriangle, heatFlow)
    soilTemperature = newSoilTemperature
    return (soilSurfaceTemperature, soilTemperature)
#%%CyML Model End%%