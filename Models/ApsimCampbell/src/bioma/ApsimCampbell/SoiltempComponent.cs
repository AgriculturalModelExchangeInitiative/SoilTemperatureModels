
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using CRA.ModelLayer.MetadataTypes;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.Strategy;
using System.Reflection;
using VarInfo=CRA.ModelLayer.Core.VarInfo;
using Preconditions=CRA.ModelLayer.Core.Preconditions;
using CRA.AgroManagement;       

using Soiltemp.DomainClass;
namespace Soiltemp.Strategies
{
    public class SoiltempComponent : IStrategySoiltemp
    {
        public SoiltempComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'thermCondPar1'}, "thermCondPar1");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'topsoilNode'}, "topsoilNode");
            _parameters0_0.Add(v2);
            VarInfo v3 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'surfaceNode'}, "surfaceNode");
            _parameters0_0.Add(v3);
            VarInfo v4 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'numPhantomNodes'}, "numPhantomNodes");
            _parameters0_0.Add(v4);
            VarInfo v5 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'soilConstituentNames'}, "soilConstituentNames");
            _parameters0_0.Add(v5);
            VarInfo v6 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'physical_Thickness'}, "physical_Thickness");
            _parameters0_0.Add(v6);
            VarInfo v7 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'MissingValue'}, "MissingValue");
            _parameters0_0.Add(v7);
            VarInfo v8 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'timestep'}, "timestep");
            _parameters0_0.Add(v8);
            VarInfo v9 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'soilRoughnessHeight'}, "soilRoughnessHeight");
            _parameters0_0.Add(v9);
            VarInfo v10 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'numIterationsForBoundaryLayerConductance'}, "numIterationsForBoundaryLayerConductance");
            _parameters0_0.Add(v10);
            VarInfo v11 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'defaultTimeOfMaximumTemperature'}, "defaultTimeOfMaximumTemperature");
            _parameters0_0.Add(v11);
            VarInfo v12 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'pom'}, "pom");
            _parameters0_0.Add(v12);
            VarInfo v13 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'DepthToConstantTemperature'}, "DepthToConstantTemperature");
            _parameters0_0.Add(v13);
            VarInfo v14 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'constantBoundaryLayerConductance'}, "constantBoundaryLayerConductance");
            _parameters0_0.Add(v14);
            VarInfo v15 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'thermCondPar4'}, "thermCondPar4");
            _parameters0_0.Add(v15);
            VarInfo v16 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'nodeDepth'}, "nodeDepth");
            _parameters0_0.Add(v16);
            VarInfo v17 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'nu'}, "nu");
            _parameters0_0.Add(v17);
            VarInfo v18 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'pInitialValues'}, "pInitialValues");
            _parameters0_0.Add(v18);
            VarInfo v19 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'ps'}, "ps");
            _parameters0_0.Add(v19);
            VarInfo v20 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'netRadiationSource'}, "netRadiationSource");
            _parameters0_0.Add(v20);
            VarInfo v21 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'airNode'}, "airNode");
            _parameters0_0.Add(v21);
            VarInfo v22 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'bareSoilRoughness'}, "bareSoilRoughness");
            _parameters0_0.Add(v22);
            VarInfo v23 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'thermCondPar2'}, "thermCondPar2");
            _parameters0_0.Add(v23);
            VarInfo v24 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'defaultInstrumentHeight'}, "defaultInstrumentHeight");
            _parameters0_0.Add(v24);
            VarInfo v25 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'physical_BD'}, "physical_BD");
            _parameters0_0.Add(v25);
            VarInfo v26 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'latentHeatOfVapourisation'}, "latentHeatOfVapourisation");
            _parameters0_0.Add(v26);
            VarInfo v27 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'weather_Latitude'}, "weather_Latitude");
            _parameters0_0.Add(v27);
            VarInfo v28 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'stefanBoltzmannConstant'}, "stefanBoltzmannConstant");
            _parameters0_0.Add(v28);
            VarInfo v29 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'boundarLayerConductanceSource'}, "boundarLayerConductanceSource");
            _parameters0_0.Add(v29);
            VarInfo v30 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'thermCondPar3'}, "thermCondPar3");
            _parameters0_0.Add(v30);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd1.PropertyName = "netRadiation";
            pd1.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd2.PropertyName = "aveSoilWater";
            pd2.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd3.PropertyName = "bulkDensity";
            pd3.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd4.PropertyName = "waterBalance_Eo";
            pd4.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd5.PropertyName = "internalTimeStep";
            pd5.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd6.PropertyName = "thermalConductance";
            pd6.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd7.PropertyName = "thickness";
            pd7.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.thickness).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.thickness);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd8.PropertyName = "doInitialisationStuff";
            pd8.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd9.PropertyName = "maxTempYesterday";
            pd9.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd10.PropertyName = "waterBalance_Salb";
            pd10.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb);
            _inputs0_0.Add(pd10);
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd11.PropertyName = "timeOfDaySecs";
            pd11.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs);
            _inputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd12.PropertyName = "numNodes";
            pd12.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.numNodes).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.numNodes);
            _inputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd13.PropertyName = "organic_Carbon";
            pd13.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon);
            _inputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd14.PropertyName = "waterBalance_Es";
            pd14.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es);
            _inputs0_0.Add(pd14);
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd15.PropertyName = "weather_Wind";
            pd15.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Wind).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Wind);
            _inputs0_0.Add(pd15);
            PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd16.PropertyName = "soilWater";
            pd16.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater);
            _inputs0_0.Add(pd16);
            PropertyDescription pd17 = new PropertyDescription();
            pd17.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd17.PropertyName = "physical_ParticleSizeSand";
            pd17.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand).ValueType.TypeForCurrentValue;
            pd17.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand);
            _inputs0_0.Add(pd17);
            PropertyDescription pd18 = new PropertyDescription();
            pd18.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd18.PropertyName = "clay";
            pd18.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.clay).ValueType.TypeForCurrentValue;
            pd18.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.clay);
            _inputs0_0.Add(pd18);
            PropertyDescription pd19 = new PropertyDescription();
            pd19.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd19.PropertyName = "weather_AirPressure";
            pd19.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_AirPressure).ValueType.TypeForCurrentValue;
            pd19.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_AirPressure);
            _inputs0_0.Add(pd19);
            PropertyDescription pd20 = new PropertyDescription();
            pd20.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd20.PropertyName = "soilTemp";
            pd20.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp).ValueType.TypeForCurrentValue;
            pd20.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp);
            _inputs0_0.Add(pd20);
            PropertyDescription pd21 = new PropertyDescription();
            pd21.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd21.PropertyName = "clock_Today_DayOfYear";
            pd21.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear).ValueType.TypeForCurrentValue;
            pd21.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear);
            _inputs0_0.Add(pd21);
            PropertyDescription pd22 = new PropertyDescription();
            pd22.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd22.PropertyName = "silt";
            pd22.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.silt).ValueType.TypeForCurrentValue;
            pd22.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.silt);
            _inputs0_0.Add(pd22);
            PropertyDescription pd23 = new PropertyDescription();
            pd23.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd23.PropertyName = "microClimate_CanopyHeight";
            pd23.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight).ValueType.TypeForCurrentValue;
            pd23.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight);
            _inputs0_0.Add(pd23);
            PropertyDescription pd24 = new PropertyDescription();
            pd24.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd24.PropertyName = "waterBalance_Eos";
            pd24.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos).ValueType.TypeForCurrentValue;
            pd24.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos);
            _inputs0_0.Add(pd24);
            PropertyDescription pd25 = new PropertyDescription();
            pd25.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd25.PropertyName = "instrumentHeight";
            pd25.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight).ValueType.TypeForCurrentValue;
            pd25.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight);
            _inputs0_0.Add(pd25);
            PropertyDescription pd26 = new PropertyDescription();
            pd26.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd26.PropertyName = "waterBalance_SW";
            pd26.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW).ValueType.TypeForCurrentValue;
            pd26.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW);
            _inputs0_0.Add(pd26);
            PropertyDescription pd27 = new PropertyDescription();
            pd27.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd27.PropertyName = "weather_Amp";
            pd27.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Amp).ValueType.TypeForCurrentValue;
            pd27.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Amp);
            _inputs0_0.Add(pd27);
            PropertyDescription pd28 = new PropertyDescription();
            pd28.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd28.PropertyName = "sand";
            pd28.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.sand).ValueType.TypeForCurrentValue;
            pd28.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.sand);
            _inputs0_0.Add(pd28);
            PropertyDescription pd29 = new PropertyDescription();
            pd29.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd29.PropertyName = "weather_MinT";
            pd29.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MinT).ValueType.TypeForCurrentValue;
            pd29.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MinT);
            _inputs0_0.Add(pd29);
            PropertyDescription pd30 = new PropertyDescription();
            pd30.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd30.PropertyName = "weather_Radn";
            pd30.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn).ValueType.TypeForCurrentValue;
            pd30.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn);
            _inputs0_0.Add(pd30);
            PropertyDescription pd31 = new PropertyDescription();
            pd31.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd31.PropertyName = "numLayers";
            pd31.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.numLayers).ValueType.TypeForCurrentValue;
            pd31.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.numLayers);
            _inputs0_0.Add(pd31);
            PropertyDescription pd32 = new PropertyDescription();
            pd32.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd32.PropertyName = "volSpecHeatSoil";
            pd32.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil).ValueType.TypeForCurrentValue;
            pd32.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil);
            _inputs0_0.Add(pd32);
            PropertyDescription pd33 = new PropertyDescription();
            pd33.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd33.PropertyName = "instrumHeight";
            pd33.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight).ValueType.TypeForCurrentValue;
            pd33.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight);
            _inputs0_0.Add(pd33);
            PropertyDescription pd34 = new PropertyDescription();
            pd34.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd34.PropertyName = "canopyHeight";
            pd34.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight).ValueType.TypeForCurrentValue;
            pd34.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight);
            _inputs0_0.Add(pd34);
            PropertyDescription pd35 = new PropertyDescription();
            pd35.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd35.PropertyName = "heatStorage";
            pd35.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage).ValueType.TypeForCurrentValue;
            pd35.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage);
            _inputs0_0.Add(pd35);
            PropertyDescription pd36 = new PropertyDescription();
            pd36.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd36.PropertyName = "minSoilTemp";
            pd36.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp).ValueType.TypeForCurrentValue;
            pd36.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp);
            _inputs0_0.Add(pd36);
            PropertyDescription pd37 = new PropertyDescription();
            pd37.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd37.PropertyName = "maxSoilTemp";
            pd37.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp).ValueType.TypeForCurrentValue;
            pd37.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp);
            _inputs0_0.Add(pd37);
            PropertyDescription pd38 = new PropertyDescription();
            pd38.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd38.PropertyName = "physical_Rocks";
            pd38.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks).ValueType.TypeForCurrentValue;
            pd38.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks);
            _inputs0_0.Add(pd38);
            PropertyDescription pd39 = new PropertyDescription();
            pd39.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd39.PropertyName = "weather_Tav";
            pd39.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Tav).ValueType.TypeForCurrentValue;
            pd39.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Tav);
            _inputs0_0.Add(pd39);
            PropertyDescription pd40 = new PropertyDescription();
            pd40.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd40.PropertyName = "newTemperature";
            pd40.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature).ValueType.TypeForCurrentValue;
            pd40.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature);
            _inputs0_0.Add(pd40);
            PropertyDescription pd41 = new PropertyDescription();
            pd41.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd41.PropertyName = "airTemperature";
            pd41.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature).ValueType.TypeForCurrentValue;
            pd41.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature);
            _inputs0_0.Add(pd41);
            PropertyDescription pd42 = new PropertyDescription();
            pd42.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd42.PropertyName = "weather_MaxT";
            pd42.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MaxT).ValueType.TypeForCurrentValue;
            pd42.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MaxT);
            _inputs0_0.Add(pd42);
            PropertyDescription pd43 = new PropertyDescription();
            pd43.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd43.PropertyName = "thermalConductivity";
            pd43.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity).ValueType.TypeForCurrentValue;
            pd43.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity);
            _inputs0_0.Add(pd43);
            PropertyDescription pd44 = new PropertyDescription();
            pd44.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd44.PropertyName = "minTempYesterday";
            pd44.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday).ValueType.TypeForCurrentValue;
            pd44.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday);
            _inputs0_0.Add(pd44);
            PropertyDescription pd45 = new PropertyDescription();
            pd45.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd45.PropertyName = "carbon";
            pd45.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.carbon).ValueType.TypeForCurrentValue;
            pd45.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.carbon);
            _inputs0_0.Add(pd45);
            PropertyDescription pd46 = new PropertyDescription();
            pd46.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd46.PropertyName = "weather_MeanT";
            pd46.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MeanT).ValueType.TypeForCurrentValue;
            pd46.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MeanT);
            _inputs0_0.Add(pd46);
            PropertyDescription pd47 = new PropertyDescription();
            pd47.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd47.PropertyName = "rocks";
            pd47.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.rocks).ValueType.TypeForCurrentValue;
            pd47.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.rocks);
            _inputs0_0.Add(pd47);
            PropertyDescription pd48 = new PropertyDescription();
            pd48.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd48.PropertyName = "InitialValues";
            pd48.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues).ValueType.TypeForCurrentValue;
            pd48.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues);
            _inputs0_0.Add(pd48);
            PropertyDescription pd49 = new PropertyDescription();
            pd49.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd49.PropertyName = "physical_ParticleSizeSilt";
            pd49.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt).ValueType.TypeForCurrentValue;
            pd49.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt);
            _inputs0_0.Add(pd49);
            PropertyDescription pd50 = new PropertyDescription();
            pd50.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd50.PropertyName = "boundaryLayerConductance";
            pd50.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance).ValueType.TypeForCurrentValue;
            pd50.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance);
            _inputs0_0.Add(pd50);
            PropertyDescription pd51 = new PropertyDescription();
            pd51.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd51.PropertyName = "physical_ParticleSizeClay";
            pd51.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay).ValueType.TypeForCurrentValue;
            pd51.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay);
            _inputs0_0.Add(pd51);
            PropertyDescription pd52 = new PropertyDescription();
            pd52.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd52.PropertyName = "aveSoilTemp";
            pd52.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp).ValueType.TypeForCurrentValue;
            pd52.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp);
            _inputs0_0.Add(pd52);
            PropertyDescription pd53 = new PropertyDescription();
            pd53.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd53.PropertyName = "morningSoilTemp";
            pd53.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp).ValueType.TypeForCurrentValue;
            pd53.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp);
            _inputs0_0.Add(pd53);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd54 = new PropertyDescription();
            pd54.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd54.PropertyName = "heatStorage";
            pd54.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage).ValueType.TypeForCurrentValue;
            pd54.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage);
            _outputs0_0.Add(pd54);
            PropertyDescription pd55 = new PropertyDescription();
            pd55.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd55.PropertyName = "instrumentHeight";
            pd55.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight).ValueType.TypeForCurrentValue;
            pd55.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight);
            _outputs0_0.Add(pd55);
            PropertyDescription pd56 = new PropertyDescription();
            pd56.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd56.PropertyName = "canopyHeight";
            pd56.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight).ValueType.TypeForCurrentValue;
            pd56.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight);
            _outputs0_0.Add(pd56);
            PropertyDescription pd57 = new PropertyDescription();
            pd57.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd57.PropertyName = "minSoilTemp";
            pd57.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp).ValueType.TypeForCurrentValue;
            pd57.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp);
            _outputs0_0.Add(pd57);
            PropertyDescription pd58 = new PropertyDescription();
            pd58.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd58.PropertyName = "maxSoilTemp";
            pd58.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp).ValueType.TypeForCurrentValue;
            pd58.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp);
            _outputs0_0.Add(pd58);
            PropertyDescription pd59 = new PropertyDescription();
            pd59.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd59.PropertyName = "aveSoilTemp";
            pd59.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp).ValueType.TypeForCurrentValue;
            pd59.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp);
            _outputs0_0.Add(pd59);
            PropertyDescription pd60 = new PropertyDescription();
            pd60.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd60.PropertyName = "volSpecHeatSoil";
            pd60.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil).ValueType.TypeForCurrentValue;
            pd60.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil);
            _outputs0_0.Add(pd60);
            PropertyDescription pd61 = new PropertyDescription();
            pd61.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd61.PropertyName = "soilTemp";
            pd61.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp).ValueType.TypeForCurrentValue;
            pd61.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp);
            _outputs0_0.Add(pd61);
            PropertyDescription pd62 = new PropertyDescription();
            pd62.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd62.PropertyName = "morningSoilTemp";
            pd62.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp).ValueType.TypeForCurrentValue;
            pd62.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp);
            _outputs0_0.Add(pd62);
            PropertyDescription pd63 = new PropertyDescription();
            pd63.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd63.PropertyName = "newTemperature";
            pd63.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature).ValueType.TypeForCurrentValue;
            pd63.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature);
            _outputs0_0.Add(pd63);
            PropertyDescription pd64 = new PropertyDescription();
            pd64.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd64.PropertyName = "thermalConductivity";
            pd64.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity).ValueType.TypeForCurrentValue;
            pd64.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity);
            _outputs0_0.Add(pd64);
            PropertyDescription pd65 = new PropertyDescription();
            pd65.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd65.PropertyName = "thermalConductance";
            pd65.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance).ValueType.TypeForCurrentValue;
            pd65.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance);
            _outputs0_0.Add(pd65);
            PropertyDescription pd66 = new PropertyDescription();
            pd66.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd66.PropertyName = "boundaryLayerConductance";
            pd66.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance).ValueType.TypeForCurrentValue;
            pd66.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance);
            _outputs0_0.Add(pd66);
            PropertyDescription pd67 = new PropertyDescription();
            pd67.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd67.PropertyName = "soilWater";
            pd67.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater).ValueType.TypeForCurrentValue;
            pd67.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater);
            _outputs0_0.Add(pd67);
            PropertyDescription pd68 = new PropertyDescription();
            pd68.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd68.PropertyName = "doInitialisationStuff";
            pd68.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff).ValueType.TypeForCurrentValue;
            pd68.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff);
            _outputs0_0.Add(pd68);
            PropertyDescription pd69 = new PropertyDescription();
            pd69.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd69.PropertyName = "maxTempYesterday";
            pd69.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday).ValueType.TypeForCurrentValue;
            pd69.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday);
            _outputs0_0.Add(pd69);
            PropertyDescription pd70 = new PropertyDescription();
            pd70.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd70.PropertyName = "minTempYesterday";
            pd70.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday).ValueType.TypeForCurrentValue;
            pd70.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday);
            _outputs0_0.Add(pd70);
            PropertyDescription pd71 = new PropertyDescription();
            pd71.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd71.PropertyName = "airTemperature";
            pd71.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature).ValueType.TypeForCurrentValue;
            pd71.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature);
            _outputs0_0.Add(pd71);
            PropertyDescription pd72 = new PropertyDescription();
            pd72.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd72.PropertyName = "internalTimeStep";
            pd72.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep).ValueType.TypeForCurrentValue;
            pd72.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep);
            _outputs0_0.Add(pd72);
            PropertyDescription pd73 = new PropertyDescription();
            pd73.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd73.PropertyName = "timeOfDaySecs";
            pd73.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs).ValueType.TypeForCurrentValue;
            pd73.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs);
            _outputs0_0.Add(pd73);
            PropertyDescription pd74 = new PropertyDescription();
            pd74.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd74.PropertyName = "netRadiation";
            pd74.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation).ValueType.TypeForCurrentValue;
            pd74.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation);
            _outputs0_0.Add(pd74);
            PropertyDescription pd75 = new PropertyDescription();
            pd75.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd75.PropertyName = "InitialValues";
            pd75.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues).ValueType.TypeForCurrentValue;
            pd75.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues);
            _outputs0_0.Add(pd75);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(Soiltemp.Strategies.SoilTemperature).FullName);
            mo0_0.AssociatedStrategies = lAssStrat0_0;
            _modellingOptionsManager = new ModellingOptionsManager(mo0_0);
            SetStaticParametersVarInfoDefinitions();
            SetPublisherData();
        }

        public string Description
        {
            get { return "" ;}
        }

        public string URL
        {
            get { return "" ;}
        }

        public string Domain
        {
            get { return "";}
        }

        public string ModelType
        {
            get { return "";}
        }

        public bool IsContext
        {
            get { return false;}
        }

        public IList<int> TimeStep
        {
            get
            {
                IList<int> ts = new List<int>();
                return ts;
            }
        }

        private  PublisherData _pd;
        public PublisherData PublisherData
        {
            get { return _pd;} 
        }

        private  void SetPublisherData()
        {
            _pd = new CRA.ModelLayer.MetadataTypes.PublisherData();
            _pd.Add("Creator", "Cyrille");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "INRAE "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(Soiltemp.DomainClass.SoiltempState), typeof(Soiltemp.DomainClass.SoiltempState), typeof(Soiltemp.DomainClass.SoiltempRate), typeof(Soiltemp.DomainClass.SoiltempAuxiliary), typeof(Soiltemp.DomainClass.SoiltempExogenous)};
        }

        public double[] thermCondPar1
        {
            get
            {
                 return _SoilTemperature.thermCondPar1; 
            }
            set
            {
                _SoilTemperature.thermCondPar1 = value;
            }
        }
        public int topsoilNode
        {
            get
            {
                 return _SoilTemperature.topsoilNode; 
            }
            set
            {
                _SoilTemperature.topsoilNode = value;
            }
        }
        public int surfaceNode
        {
            get
            {
                 return _SoilTemperature.surfaceNode; 
            }
            set
            {
                _SoilTemperature.surfaceNode = value;
            }
        }
        public int numPhantomNodes
        {
            get
            {
                 return _SoilTemperature.numPhantomNodes; 
            }
            set
            {
                _SoilTemperature.numPhantomNodes = value;
            }
        }
        public string[] soilConstituentNames
        {
            get
            {
                 return _SoilTemperature.soilConstituentNames; 
            }
            set
            {
                _SoilTemperature.soilConstituentNames = value;
            }
        }
        public double[] physical_Thickness
        {
            get
            {
                 return _SoilTemperature.physical_Thickness; 
            }
            set
            {
                _SoilTemperature.physical_Thickness = value;
            }
        }
        public double MissingValue
        {
            get
            {
                 return _SoilTemperature.MissingValue; 
            }
            set
            {
                _SoilTemperature.MissingValue = value;
            }
        }
        public double timestep
        {
            get
            {
                 return _SoilTemperature.timestep; 
            }
            set
            {
                _SoilTemperature.timestep = value;
            }
        }
        public double soilRoughnessHeight
        {
            get
            {
                 return _SoilTemperature.soilRoughnessHeight; 
            }
            set
            {
                _SoilTemperature.soilRoughnessHeight = value;
            }
        }
        public int numIterationsForBoundaryLayerConductance
        {
            get
            {
                 return _SoilTemperature.numIterationsForBoundaryLayerConductance; 
            }
            set
            {
                _SoilTemperature.numIterationsForBoundaryLayerConductance = value;
            }
        }
        public double defaultTimeOfMaximumTemperature
        {
            get
            {
                 return _SoilTemperature.defaultTimeOfMaximumTemperature; 
            }
            set
            {
                _SoilTemperature.defaultTimeOfMaximumTemperature = value;
            }
        }
        public double pom
        {
            get
            {
                 return _SoilTemperature.pom; 
            }
            set
            {
                _SoilTemperature.pom = value;
            }
        }
        public double DepthToConstantTemperature
        {
            get
            {
                 return _SoilTemperature.DepthToConstantTemperature; 
            }
            set
            {
                _SoilTemperature.DepthToConstantTemperature = value;
            }
        }
        public double constantBoundaryLayerConductance
        {
            get
            {
                 return _SoilTemperature.constantBoundaryLayerConductance; 
            }
            set
            {
                _SoilTemperature.constantBoundaryLayerConductance = value;
            }
        }
        public double[] thermCondPar4
        {
            get
            {
                 return _SoilTemperature.thermCondPar4; 
            }
            set
            {
                _SoilTemperature.thermCondPar4 = value;
            }
        }
        public double[] nodeDepth
        {
            get
            {
                 return _SoilTemperature.nodeDepth; 
            }
            set
            {
                _SoilTemperature.nodeDepth = value;
            }
        }
        public double nu
        {
            get
            {
                 return _SoilTemperature.nu; 
            }
            set
            {
                _SoilTemperature.nu = value;
            }
        }
        public double[] pInitialValues
        {
            get
            {
                 return _SoilTemperature.pInitialValues; 
            }
            set
            {
                _SoilTemperature.pInitialValues = value;
            }
        }
        public double ps
        {
            get
            {
                 return _SoilTemperature.ps; 
            }
            set
            {
                _SoilTemperature.ps = value;
            }
        }
        public string netRadiationSource
        {
            get
            {
                 return _SoilTemperature.netRadiationSource; 
            }
            set
            {
                _SoilTemperature.netRadiationSource = value;
            }
        }
        public int airNode
        {
            get
            {
                 return _SoilTemperature.airNode; 
            }
            set
            {
                _SoilTemperature.airNode = value;
            }
        }
        public double bareSoilRoughness
        {
            get
            {
                 return _SoilTemperature.bareSoilRoughness; 
            }
            set
            {
                _SoilTemperature.bareSoilRoughness = value;
            }
        }
        public double[] thermCondPar2
        {
            get
            {
                 return _SoilTemperature.thermCondPar2; 
            }
            set
            {
                _SoilTemperature.thermCondPar2 = value;
            }
        }
        public double defaultInstrumentHeight
        {
            get
            {
                 return _SoilTemperature.defaultInstrumentHeight; 
            }
            set
            {
                _SoilTemperature.defaultInstrumentHeight = value;
            }
        }
        public double[] physical_BD
        {
            get
            {
                 return _SoilTemperature.physical_BD; 
            }
            set
            {
                _SoilTemperature.physical_BD = value;
            }
        }
        public double latentHeatOfVapourisation
        {
            get
            {
                 return _SoilTemperature.latentHeatOfVapourisation; 
            }
            set
            {
                _SoilTemperature.latentHeatOfVapourisation = value;
            }
        }
        public double weather_Latitude
        {
            get
            {
                 return _SoilTemperature.weather_Latitude; 
            }
            set
            {
                _SoilTemperature.weather_Latitude = value;
            }
        }
        public double stefanBoltzmannConstant
        {
            get
            {
                 return _SoilTemperature.stefanBoltzmannConstant; 
            }
            set
            {
                _SoilTemperature.stefanBoltzmannConstant = value;
            }
        }
        public string boundarLayerConductanceSource
        {
            get
            {
                 return _SoilTemperature.boundarLayerConductanceSource; 
            }
            set
            {
                _SoilTemperature.boundarLayerConductanceSource = value;
            }
        }
        public double[] thermCondPar3
        {
            get
            {
                 return _SoilTemperature.thermCondPar3; 
            }
            set
            {
                _SoilTemperature.thermCondPar3 = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _SoilTemperature.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            thermCondPar1VarInfo.Name = "thermCondPar1";
            thermCondPar1VarInfo.Description = "Parameter 1 for computing thermal conductivity of soil solids";
            thermCondPar1VarInfo.MaxValue = -1D;
            thermCondPar1VarInfo.MinValue = -1D;
            thermCondPar1VarInfo.DefaultValue = -1D;
            thermCondPar1VarInfo.Units = "";
            thermCondPar1VarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            topsoilNodeVarInfo.Name = "topsoilNode";
            topsoilNodeVarInfo.Description = "The index of the first node within the soil (top layer)";
            topsoilNodeVarInfo.MaxValue = -1D;
            topsoilNodeVarInfo.MinValue = -1D;
            topsoilNodeVarInfo.DefaultValue = 2;
            topsoilNodeVarInfo.Units = "";
            topsoilNodeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            surfaceNodeVarInfo.Name = "surfaceNode";
            surfaceNodeVarInfo.Description = "The index of the node on the soil surface (depth = 0)";
            surfaceNodeVarInfo.MaxValue = -1D;
            surfaceNodeVarInfo.MinValue = -1D;
            surfaceNodeVarInfo.DefaultValue = 1;
            surfaceNodeVarInfo.Units = "";
            surfaceNodeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            numPhantomNodesVarInfo.Name = "numPhantomNodes";
            numPhantomNodesVarInfo.Description = "The number of phantom nodes below the soil profile";
            numPhantomNodesVarInfo.MaxValue = -1D;
            numPhantomNodesVarInfo.MinValue = -1D;
            numPhantomNodesVarInfo.DefaultValue = 5;
            numPhantomNodesVarInfo.Units = "";
            numPhantomNodesVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            soilConstituentNamesVarInfo.Name = "soilConstituentNames";
            soilConstituentNamesVarInfo.Description = "soilConstituentNames";
            soilConstituentNamesVarInfo.MaxValue = -1D;
            soilConstituentNamesVarInfo.MinValue = -1D;
            soilConstituentNamesVarInfo.DefaultValue = -1D;
            soilConstituentNamesVarInfo.Units = "m";
            soilConstituentNamesVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("StringInteger");

            physical_ThicknessVarInfo.Name = "physical_Thickness";
            physical_ThicknessVarInfo.Description = "Soil layer thickness";
            physical_ThicknessVarInfo.MaxValue = -1D;
            physical_ThicknessVarInfo.MinValue = -1D;
            physical_ThicknessVarInfo.DefaultValue = -1D;
            physical_ThicknessVarInfo.Units = "mm";
            physical_ThicknessVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            MissingValueVarInfo.Name = "MissingValue";
            MissingValueVarInfo.Description = "missing value";
            MissingValueVarInfo.MaxValue = -1D;
            MissingValueVarInfo.MinValue = -1D;
            MissingValueVarInfo.DefaultValue = 99999;
            MissingValueVarInfo.Units = "m";
            MissingValueVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            timestepVarInfo.Name = "timestep";
            timestepVarInfo.Description = "Internal time-step (minutes)";
            timestepVarInfo.MaxValue = -1D;
            timestepVarInfo.MinValue = -1D;
            timestepVarInfo.DefaultValue = 24.0 * 60.0 * 60.0;
            timestepVarInfo.Units = "minutes";
            timestepVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            soilRoughnessHeightVarInfo.Name = "soilRoughnessHeight";
            soilRoughnessHeightVarInfo.Description = "Height of soil roughness";
            soilRoughnessHeightVarInfo.MaxValue = -1D;
            soilRoughnessHeightVarInfo.MinValue = -1D;
            soilRoughnessHeightVarInfo.DefaultValue = 0;
            soilRoughnessHeightVarInfo.Units = "mm";
            soilRoughnessHeightVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            numIterationsForBoundaryLayerConductanceVarInfo.Name = "numIterationsForBoundaryLayerConductance";
            numIterationsForBoundaryLayerConductanceVarInfo.Description = "Number of iterations to calculate atmosphere boundary layer conductance";
            numIterationsForBoundaryLayerConductanceVarInfo.MaxValue = -1D;
            numIterationsForBoundaryLayerConductanceVarInfo.MinValue = -1D;
            numIterationsForBoundaryLayerConductanceVarInfo.DefaultValue = 1;
            numIterationsForBoundaryLayerConductanceVarInfo.Units = "";
            numIterationsForBoundaryLayerConductanceVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            defaultTimeOfMaximumTemperatureVarInfo.Name = "defaultTimeOfMaximumTemperature";
            defaultTimeOfMaximumTemperatureVarInfo.Description = "Time of maximum temperature";
            defaultTimeOfMaximumTemperatureVarInfo.MaxValue = -1D;
            defaultTimeOfMaximumTemperatureVarInfo.MinValue = -1D;
            defaultTimeOfMaximumTemperatureVarInfo.DefaultValue = 14.0;
            defaultTimeOfMaximumTemperatureVarInfo.Units = "minutes";
            defaultTimeOfMaximumTemperatureVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            pomVarInfo.Name = "pom";
            pomVarInfo.Description = "Particle density of organic matter";
            pomVarInfo.MaxValue = -1D;
            pomVarInfo.MinValue = -1D;
            pomVarInfo.DefaultValue = -1D;
            pomVarInfo.Units = "Mg/m3";
            pomVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            DepthToConstantTemperatureVarInfo.Name = "DepthToConstantTemperature";
            DepthToConstantTemperatureVarInfo.Description = "Soil depth to constant temperature";
            DepthToConstantTemperatureVarInfo.MaxValue = -1D;
            DepthToConstantTemperatureVarInfo.MinValue = -1D;
            DepthToConstantTemperatureVarInfo.DefaultValue = 10000;
            DepthToConstantTemperatureVarInfo.Units = "mm";
            DepthToConstantTemperatureVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            constantBoundaryLayerConductanceVarInfo.Name = "constantBoundaryLayerConductance";
            constantBoundaryLayerConductanceVarInfo.Description = "Boundary layer conductance, if constant";
            constantBoundaryLayerConductanceVarInfo.MaxValue = -1D;
            constantBoundaryLayerConductanceVarInfo.MinValue = -1D;
            constantBoundaryLayerConductanceVarInfo.DefaultValue = 20;
            constantBoundaryLayerConductanceVarInfo.Units = "K/W";
            constantBoundaryLayerConductanceVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            thermCondPar4VarInfo.Name = "thermCondPar4";
            thermCondPar4VarInfo.Description = "Parameter 4 for computing thermal conductivity of soil solids";
            thermCondPar4VarInfo.MaxValue = -1D;
            thermCondPar4VarInfo.MinValue = -1D;
            thermCondPar4VarInfo.DefaultValue = -1D;
            thermCondPar4VarInfo.Units = "";
            thermCondPar4VarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            nodeDepthVarInfo.Name = "nodeDepth";
            nodeDepthVarInfo.Description = "Depths of nodes";
            nodeDepthVarInfo.MaxValue = -1D;
            nodeDepthVarInfo.MinValue = -1D;
            nodeDepthVarInfo.DefaultValue = -1D;
            nodeDepthVarInfo.Units = "mm";
            nodeDepthVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            nuVarInfo.Name = "nu";
            nuVarInfo.Description = "Forward/backward differencing coefficient";
            nuVarInfo.MaxValue = -1D;
            nuVarInfo.MinValue = -1D;
            nuVarInfo.DefaultValue = 0.6;
            nuVarInfo.Units = "0-1";
            nuVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            pInitialValuesVarInfo.Name = "pInitialValues";
            pInitialValuesVarInfo.Description = "Initial soil temperature";
            pInitialValuesVarInfo.MaxValue = -1D;
            pInitialValuesVarInfo.MinValue = -1D;
            pInitialValuesVarInfo.DefaultValue = -1D;
            pInitialValuesVarInfo.Units = "oC";
            pInitialValuesVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            psVarInfo.Name = "ps";
            psVarInfo.Description = "ps";
            psVarInfo.MaxValue = -1D;
            psVarInfo.MinValue = -1D;
            psVarInfo.DefaultValue = -1D;
            psVarInfo.Units = "";
            psVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            netRadiationSourceVarInfo.Name = "netRadiationSource";
            netRadiationSourceVarInfo.Description = "Flag whether net radiation is calculated or gotten from input";
            netRadiationSourceVarInfo.MaxValue = -1D;
            netRadiationSourceVarInfo.MinValue = -1D;
            netRadiationSourceVarInfo.DefaultValue = -1D;
            netRadiationSourceVarInfo.Units = "m";
            netRadiationSourceVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("String");

            airNodeVarInfo.Name = "airNode";
            airNodeVarInfo.Description = "The index of the node in the atmosphere (aboveground)";
            airNodeVarInfo.MaxValue = -1D;
            airNodeVarInfo.MinValue = -1D;
            airNodeVarInfo.DefaultValue = 0;
            airNodeVarInfo.Units = "";
            airNodeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            bareSoilRoughnessVarInfo.Name = "bareSoilRoughness";
            bareSoilRoughnessVarInfo.Description = "Roughness element height of bare soil";
            bareSoilRoughnessVarInfo.MaxValue = -1D;
            bareSoilRoughnessVarInfo.MinValue = -1D;
            bareSoilRoughnessVarInfo.DefaultValue = 57;
            bareSoilRoughnessVarInfo.Units = "mm";
            bareSoilRoughnessVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            thermCondPar2VarInfo.Name = "thermCondPar2";
            thermCondPar2VarInfo.Description = "Parameter 2 for computing thermal conductivity of soil solids";
            thermCondPar2VarInfo.MaxValue = -1D;
            thermCondPar2VarInfo.MinValue = -1D;
            thermCondPar2VarInfo.DefaultValue = -1D;
            thermCondPar2VarInfo.Units = "";
            thermCondPar2VarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            defaultInstrumentHeightVarInfo.Name = "defaultInstrumentHeight";
            defaultInstrumentHeightVarInfo.Description = "Default instrument height";
            defaultInstrumentHeightVarInfo.MaxValue = -1D;
            defaultInstrumentHeightVarInfo.MinValue = -1D;
            defaultInstrumentHeightVarInfo.DefaultValue = 1.2;
            defaultInstrumentHeightVarInfo.Units = "m";
            defaultInstrumentHeightVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            physical_BDVarInfo.Name = "physical_BD";
            physical_BDVarInfo.Description = "Bulk density";
            physical_BDVarInfo.MaxValue = -1D;
            physical_BDVarInfo.MinValue = -1D;
            physical_BDVarInfo.DefaultValue = -1D;
            physical_BDVarInfo.Units = "g/cc";
            physical_BDVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            latentHeatOfVapourisationVarInfo.Name = "latentHeatOfVapourisation";
            latentHeatOfVapourisationVarInfo.Description = "Latent heat of vapourisation for water";
            latentHeatOfVapourisationVarInfo.MaxValue = -1D;
            latentHeatOfVapourisationVarInfo.MinValue = -1D;
            latentHeatOfVapourisationVarInfo.DefaultValue = 2465000;
            latentHeatOfVapourisationVarInfo.Units = "miJ/kg";
            latentHeatOfVapourisationVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            weather_LatitudeVarInfo.Name = "weather_Latitude";
            weather_LatitudeVarInfo.Description = "Latitude";
            weather_LatitudeVarInfo.MaxValue = -1D;
            weather_LatitudeVarInfo.MinValue = -1D;
            weather_LatitudeVarInfo.DefaultValue = -1D;
            weather_LatitudeVarInfo.Units = "deg";
            weather_LatitudeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            stefanBoltzmannConstantVarInfo.Name = "stefanBoltzmannConstant";
            stefanBoltzmannConstantVarInfo.Description = "The Stefan-Boltzmann constant";
            stefanBoltzmannConstantVarInfo.MaxValue = -1D;
            stefanBoltzmannConstantVarInfo.MinValue = -1D;
            stefanBoltzmannConstantVarInfo.DefaultValue = 0.0000000567;
            stefanBoltzmannConstantVarInfo.Units = "W/m2/K4";
            stefanBoltzmannConstantVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            boundarLayerConductanceSourceVarInfo.Name = "boundarLayerConductanceSource";
            boundarLayerConductanceSourceVarInfo.Description = "Flag whether boundary layer conductance is calculated or gotten from inpu";
            boundarLayerConductanceSourceVarInfo.MaxValue = -1D;
            boundarLayerConductanceSourceVarInfo.MinValue = -1D;
            boundarLayerConductanceSourceVarInfo.DefaultValue = -1D;
            boundarLayerConductanceSourceVarInfo.Units = "";
            boundarLayerConductanceSourceVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("String");

            thermCondPar3VarInfo.Name = "thermCondPar3";
            thermCondPar3VarInfo.Description = "Parameter 3 for computing thermal conductivity of soil solids";
            thermCondPar3VarInfo.MaxValue = -1D;
            thermCondPar3VarInfo.MinValue = -1D;
            thermCondPar3VarInfo.DefaultValue = -1D;
            thermCondPar3VarInfo.Units = "";
            thermCondPar3VarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
        }

        public static VarInfo thermCondPar1VarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'thermCondPar1'}.thermCondPar1VarInfo;} 
        }

        public static VarInfo topsoilNodeVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'topsoilNode'}.topsoilNodeVarInfo;} 
        }

        public static VarInfo surfaceNodeVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'surfaceNode'}.surfaceNodeVarInfo;} 
        }

        public static VarInfo numPhantomNodesVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'numPhantomNodes'}.numPhantomNodesVarInfo;} 
        }

        public static VarInfo soilConstituentNamesVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'soilConstituentNames'}.soilConstituentNamesVarInfo;} 
        }

        public static VarInfo physical_ThicknessVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'physical_Thickness'}.physical_ThicknessVarInfo;} 
        }

        public static VarInfo MissingValueVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'MissingValue'}.MissingValueVarInfo;} 
        }

        public static VarInfo timestepVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'timestep'}.timestepVarInfo;} 
        }

        public static VarInfo soilRoughnessHeightVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'soilRoughnessHeight'}.soilRoughnessHeightVarInfo;} 
        }

        public static VarInfo numIterationsForBoundaryLayerConductanceVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'numIterationsForBoundaryLayerConductance'}.numIterationsForBoundaryLayerConductanceVarInfo;} 
        }

        public static VarInfo defaultTimeOfMaximumTemperatureVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'defaultTimeOfMaximumTemperature'}.defaultTimeOfMaximumTemperatureVarInfo;} 
        }

        public static VarInfo pomVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'pom'}.pomVarInfo;} 
        }

        public static VarInfo DepthToConstantTemperatureVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'DepthToConstantTemperature'}.DepthToConstantTemperatureVarInfo;} 
        }

        public static VarInfo constantBoundaryLayerConductanceVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'constantBoundaryLayerConductance'}.constantBoundaryLayerConductanceVarInfo;} 
        }

        public static VarInfo thermCondPar4VarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'thermCondPar4'}.thermCondPar4VarInfo;} 
        }

        public static VarInfo nodeDepthVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'nodeDepth'}.nodeDepthVarInfo;} 
        }

        public static VarInfo nuVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'nu'}.nuVarInfo;} 
        }

        public static VarInfo pInitialValuesVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'pInitialValues'}.pInitialValuesVarInfo;} 
        }

        public static VarInfo psVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'ps'}.psVarInfo;} 
        }

        public static VarInfo netRadiationSourceVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'netRadiationSource'}.netRadiationSourceVarInfo;} 
        }

        public static VarInfo airNodeVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'airNode'}.airNodeVarInfo;} 
        }

        public static VarInfo bareSoilRoughnessVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'bareSoilRoughness'}.bareSoilRoughnessVarInfo;} 
        }

        public static VarInfo thermCondPar2VarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'thermCondPar2'}.thermCondPar2VarInfo;} 
        }

        public static VarInfo defaultInstrumentHeightVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'defaultInstrumentHeight'}.defaultInstrumentHeightVarInfo;} 
        }

        public static VarInfo physical_BDVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'physical_BD'}.physical_BDVarInfo;} 
        }

        public static VarInfo latentHeatOfVapourisationVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'latentHeatOfVapourisation'}.latentHeatOfVapourisationVarInfo;} 
        }

        public static VarInfo weather_LatitudeVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'weather_Latitude'}.weather_LatitudeVarInfo;} 
        }

        public static VarInfo stefanBoltzmannConstantVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'stefanBoltzmannConstant'}.stefanBoltzmannConstantVarInfo;} 
        }

        public static VarInfo boundarLayerConductanceSourceVarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'boundarLayerConductanceSource'}.boundarLayerConductanceSourceVarInfo;} 
        }

        public static VarInfo thermCondPar3VarInfo
        {
            get { return Soiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'thermCondPar3'}.thermCondPar3VarInfo;} 
        }

        public string TestPostConditions(Soiltemp.DomainClass.SoiltempState s,Soiltemp.DomainClass.SoiltempState s1,Soiltemp.DomainClass.SoiltempRate r,Soiltemp.DomainClass.SoiltempAuxiliary a,Soiltemp.DomainClass.SoiltempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage.CurrentValue=s.heatStorage;
                Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight.CurrentValue=s.instrumentHeight;
                Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight.CurrentValue=s.canopyHeight;
                Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp.CurrentValue=s.minSoilTemp;
                Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp.CurrentValue=s.maxSoilTemp;
                Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp.CurrentValue=s.aveSoilTemp;
                Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil.CurrentValue=s.volSpecHeatSoil;
                Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp.CurrentValue=s.soilTemp;
                Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp.CurrentValue=s.morningSoilTemp;
                Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature.CurrentValue=s.newTemperature;
                Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity.CurrentValue=s.thermalConductivity;
                Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance.CurrentValue=s.thermalConductance;
                Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance.CurrentValue=s.boundaryLayerConductance;
                Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater.CurrentValue=s.soilWater;
                Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff.CurrentValue=s.doInitialisationStuff;
                Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday.CurrentValue=s.maxTempYesterday;
                Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday.CurrentValue=s.minTempYesterday;
                Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature.CurrentValue=s.airTemperature;
                Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep.CurrentValue=s.internalTimeStep;
                Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs.CurrentValue=s.timeOfDaySecs;
                Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation.CurrentValue=s.netRadiation;
                Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues.CurrentValue=s.InitialValues;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r84 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage);
                if(r84.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage.ValueType)){prc.AddCondition(r84);}
                RangeBasedCondition r85 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight);
                if(r85.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight.ValueType)){prc.AddCondition(r85);}
                RangeBasedCondition r86 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight);
                if(r86.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight.ValueType)){prc.AddCondition(r86);}
                RangeBasedCondition r87 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp);
                if(r87.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp.ValueType)){prc.AddCondition(r87);}
                RangeBasedCondition r88 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp);
                if(r88.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp.ValueType)){prc.AddCondition(r88);}
                RangeBasedCondition r89 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp);
                if(r89.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp.ValueType)){prc.AddCondition(r89);}
                RangeBasedCondition r90 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil);
                if(r90.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil.ValueType)){prc.AddCondition(r90);}
                RangeBasedCondition r91 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp);
                if(r91.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp.ValueType)){prc.AddCondition(r91);}
                RangeBasedCondition r92 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp);
                if(r92.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp.ValueType)){prc.AddCondition(r92);}
                RangeBasedCondition r93 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature);
                if(r93.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature.ValueType)){prc.AddCondition(r93);}
                RangeBasedCondition r94 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity);
                if(r94.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity.ValueType)){prc.AddCondition(r94);}
                RangeBasedCondition r95 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance);
                if(r95.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance.ValueType)){prc.AddCondition(r95);}
                RangeBasedCondition r96 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance);
                if(r96.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance.ValueType)){prc.AddCondition(r96);}
                RangeBasedCondition r97 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater);
                if(r97.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater.ValueType)){prc.AddCondition(r97);}
                RangeBasedCondition r98 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff);
                if(r98.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff.ValueType)){prc.AddCondition(r98);}
                RangeBasedCondition r99 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday);
                if(r99.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday.ValueType)){prc.AddCondition(r99);}
                RangeBasedCondition r100 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday);
                if(r100.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday.ValueType)){prc.AddCondition(r100);}
                RangeBasedCondition r101 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature);
                if(r101.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature.ValueType)){prc.AddCondition(r101);}
                RangeBasedCondition r102 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep);
                if(r102.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep.ValueType)){prc.AddCondition(r102);}
                RangeBasedCondition r103 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs);
                if(r103.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs.ValueType)){prc.AddCondition(r103);}
                RangeBasedCondition r104 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation);
                if(r104.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation.ValueType)){prc.AddCondition(r104);}
                RangeBasedCondition r105 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues);
                if(r105.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues.ValueType)){prc.AddCondition(r105);}

                string ret = "";
                ret += _SoilTemperature.TestPostConditions(s, s1, r, a, ex, " strategy Soiltemp.Strategies.Soiltemp");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .Soiltemp, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(Soiltemp.DomainClass.SoiltempState s,Soiltemp.DomainClass.SoiltempState s1,Soiltemp.DomainClass.SoiltempRate r,Soiltemp.DomainClass.SoiltempAuxiliary a,Soiltemp.DomainClass.SoiltempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation.CurrentValue=s.netRadiation;
                Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater.CurrentValue=s.aveSoilWater;
                Soiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity.CurrentValue=s.bulkDensity;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo.CurrentValue=ex.waterBalance_Eo;
                Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep.CurrentValue=s.internalTimeStep;
                Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance.CurrentValue=s.thermalConductance;
                Soiltemp.DomainClass.SoiltempStateVarInfo.thickness.CurrentValue=s.thickness;
                Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff.CurrentValue=s.doInitialisationStuff;
                Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday.CurrentValue=s.maxTempYesterday;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb.CurrentValue=ex.waterBalance_Salb;
                Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs.CurrentValue=s.timeOfDaySecs;
                Soiltemp.DomainClass.SoiltempStateVarInfo.numNodes.CurrentValue=s.numNodes;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon.CurrentValue=ex.organic_Carbon;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es.CurrentValue=ex.waterBalance_Es;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Wind.CurrentValue=ex.weather_Wind;
                Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater.CurrentValue=s.soilWater;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand.CurrentValue=ex.physical_ParticleSizeSand;
                Soiltemp.DomainClass.SoiltempStateVarInfo.clay.CurrentValue=s.clay;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_AirPressure.CurrentValue=ex.weather_AirPressure;
                Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp.CurrentValue=s.soilTemp;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear.CurrentValue=ex.clock_Today_DayOfYear;
                Soiltemp.DomainClass.SoiltempStateVarInfo.silt.CurrentValue=s.silt;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight.CurrentValue=ex.microClimate_CanopyHeight;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos.CurrentValue=ex.waterBalance_Eos;
                Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight.CurrentValue=s.instrumentHeight;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW.CurrentValue=ex.waterBalance_SW;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Amp.CurrentValue=ex.weather_Amp;
                Soiltemp.DomainClass.SoiltempStateVarInfo.sand.CurrentValue=s.sand;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MinT.CurrentValue=ex.weather_MinT;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn.CurrentValue=ex.weather_Radn;
                Soiltemp.DomainClass.SoiltempStateVarInfo.numLayers.CurrentValue=s.numLayers;
                Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil.CurrentValue=s.volSpecHeatSoil;
                Soiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight.CurrentValue=s.instrumHeight;
                Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight.CurrentValue=s.canopyHeight;
                Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage.CurrentValue=s.heatStorage;
                Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp.CurrentValue=s.minSoilTemp;
                Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp.CurrentValue=s.maxSoilTemp;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks.CurrentValue=ex.physical_Rocks;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Tav.CurrentValue=ex.weather_Tav;
                Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature.CurrentValue=s.newTemperature;
                Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature.CurrentValue=s.airTemperature;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MaxT.CurrentValue=ex.weather_MaxT;
                Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity.CurrentValue=s.thermalConductivity;
                Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday.CurrentValue=s.minTempYesterday;
                Soiltemp.DomainClass.SoiltempStateVarInfo.carbon.CurrentValue=s.carbon;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MeanT.CurrentValue=ex.weather_MeanT;
                Soiltemp.DomainClass.SoiltempStateVarInfo.rocks.CurrentValue=s.rocks;
                Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues.CurrentValue=s.InitialValues;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt.CurrentValue=ex.physical_ParticleSizeSilt;
                Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance.CurrentValue=s.boundaryLayerConductance;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay.CurrentValue=ex.physical_ParticleSizeClay;
                Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp.CurrentValue=s.aveSoilTemp;
                Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp.CurrentValue=s.morningSoilTemp;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation);
                if(r1.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater);
                if(r2.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity);
                if(r3.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo);
                if(r4.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep);
                if(r5.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance);
                if(r6.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.thickness);
                if(r7.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.thickness.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff);
                if(r8.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday);
                if(r9.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb);
                if(r10.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs);
                if(r11.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.numNodes);
                if(r12.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.numNodes.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon);
                if(r13.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es);
                if(r14.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es.ValueType)){prc.AddCondition(r14);}
                RangeBasedCondition r15 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Wind);
                if(r15.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Wind.ValueType)){prc.AddCondition(r15);}
                RangeBasedCondition r16 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater);
                if(r16.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater.ValueType)){prc.AddCondition(r16);}
                RangeBasedCondition r17 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand);
                if(r17.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand.ValueType)){prc.AddCondition(r17);}
                RangeBasedCondition r18 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.clay);
                if(r18.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.clay.ValueType)){prc.AddCondition(r18);}
                RangeBasedCondition r19 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_AirPressure);
                if(r19.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_AirPressure.ValueType)){prc.AddCondition(r19);}
                RangeBasedCondition r20 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp);
                if(r20.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp.ValueType)){prc.AddCondition(r20);}
                RangeBasedCondition r21 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear);
                if(r21.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear.ValueType)){prc.AddCondition(r21);}
                RangeBasedCondition r22 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.silt);
                if(r22.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.silt.ValueType)){prc.AddCondition(r22);}
                RangeBasedCondition r23 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight);
                if(r23.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight.ValueType)){prc.AddCondition(r23);}
                RangeBasedCondition r24 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos);
                if(r24.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos.ValueType)){prc.AddCondition(r24);}
                RangeBasedCondition r25 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight);
                if(r25.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight.ValueType)){prc.AddCondition(r25);}
                RangeBasedCondition r26 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW);
                if(r26.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW.ValueType)){prc.AddCondition(r26);}
                RangeBasedCondition r27 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Amp);
                if(r27.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Amp.ValueType)){prc.AddCondition(r27);}
                RangeBasedCondition r28 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.sand);
                if(r28.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.sand.ValueType)){prc.AddCondition(r28);}
                RangeBasedCondition r29 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MinT);
                if(r29.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MinT.ValueType)){prc.AddCondition(r29);}
                RangeBasedCondition r30 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn);
                if(r30.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn.ValueType)){prc.AddCondition(r30);}
                RangeBasedCondition r31 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.numLayers);
                if(r31.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.numLayers.ValueType)){prc.AddCondition(r31);}
                RangeBasedCondition r32 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil);
                if(r32.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil.ValueType)){prc.AddCondition(r32);}
                RangeBasedCondition r33 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight);
                if(r33.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight.ValueType)){prc.AddCondition(r33);}
                RangeBasedCondition r34 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight);
                if(r34.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight.ValueType)){prc.AddCondition(r34);}
                RangeBasedCondition r35 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage);
                if(r35.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage.ValueType)){prc.AddCondition(r35);}
                RangeBasedCondition r36 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp);
                if(r36.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp.ValueType)){prc.AddCondition(r36);}
                RangeBasedCondition r37 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp);
                if(r37.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp.ValueType)){prc.AddCondition(r37);}
                RangeBasedCondition r38 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks);
                if(r38.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks.ValueType)){prc.AddCondition(r38);}
                RangeBasedCondition r39 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Tav);
                if(r39.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Tav.ValueType)){prc.AddCondition(r39);}
                RangeBasedCondition r40 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature);
                if(r40.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature.ValueType)){prc.AddCondition(r40);}
                RangeBasedCondition r41 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature);
                if(r41.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature.ValueType)){prc.AddCondition(r41);}
                RangeBasedCondition r42 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MaxT);
                if(r42.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MaxT.ValueType)){prc.AddCondition(r42);}
                RangeBasedCondition r43 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity);
                if(r43.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity.ValueType)){prc.AddCondition(r43);}
                RangeBasedCondition r44 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday);
                if(r44.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday.ValueType)){prc.AddCondition(r44);}
                RangeBasedCondition r45 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.carbon);
                if(r45.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.carbon.ValueType)){prc.AddCondition(r45);}
                RangeBasedCondition r46 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MeanT);
                if(r46.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MeanT.ValueType)){prc.AddCondition(r46);}
                RangeBasedCondition r47 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.rocks);
                if(r47.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.rocks.ValueType)){prc.AddCondition(r47);}
                RangeBasedCondition r48 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues);
                if(r48.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues.ValueType)){prc.AddCondition(r48);}
                RangeBasedCondition r49 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt);
                if(r49.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt.ValueType)){prc.AddCondition(r49);}
                RangeBasedCondition r50 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance);
                if(r50.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance.ValueType)){prc.AddCondition(r50);}
                RangeBasedCondition r51 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay);
                if(r51.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay.ValueType)){prc.AddCondition(r51);}
                RangeBasedCondition r52 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp);
                if(r52.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp.ValueType)){prc.AddCondition(r52);}
                RangeBasedCondition r53 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp);
                if(r53.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp.ValueType)){prc.AddCondition(r53);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("thermCondPar1")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("topsoilNode")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("surfaceNode")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("numPhantomNodes")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("soilConstituentNames")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("physical_Thickness")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("MissingValue")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("timestep")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("soilRoughnessHeight")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("numIterationsForBoundaryLayerConductance")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("defaultTimeOfMaximumTemperature")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("pom")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DepthToConstantTemperature")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("constantBoundaryLayerConductance")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("thermCondPar4")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("nodeDepth")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("nu")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("pInitialValues")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("ps")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("netRadiationSource")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("airNode")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("bareSoilRoughness")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("thermCondPar2")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("defaultInstrumentHeight")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("physical_BD")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("latentHeatOfVapourisation")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("weather_Latitude")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("stefanBoltzmannConstant")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("boundarLayerConductanceSource")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("thermCondPar3")));
                string ret = "";
                ret += _SoilTemperature.TestPreConditions(s, s1, r, a, ex, " strategy Soiltemp.Strategies.Soiltemp");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .Soiltemp, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(Soiltemp.DomainClass.SoiltempState s,Soiltemp.DomainClass.SoiltempState s1,Soiltemp.DomainClass.SoiltempRate r,Soiltemp.DomainClass.SoiltempAuxiliary a,Soiltemp.DomainClass.SoiltempExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component Soiltemp, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(Soiltemp.DomainClass.SoiltempState s,Soiltemp.DomainClass.SoiltempState s1,Soiltemp.DomainClass.SoiltempRate r,Soiltemp.DomainClass.SoiltempAuxiliary a,Soiltemp.DomainClass.SoiltempExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        SoilTemperature _SoilTemperature = new SoilTemperature();

        private void EstimateOfAssociatedClasses(Soiltemp.DomainClass.SoiltempState s,Soiltemp.DomainClass.SoiltempState s1,Soiltemp.DomainClass.SoiltempRate r,Soiltemp.DomainClass.SoiltempAuxiliary a,Soiltemp.DomainClass.SoiltempExogenous ex)
        {
            _soiltemperature.Estimate(s,s1, r, a, ex);
        }

        public void Init(Soiltemp.DomainClass.SoiltempState s,Soiltemp.DomainClass.SoiltempState s1,Soiltemp.DomainClass.SoiltempRate r,Soiltemp.DomainClass.SoiltempAuxiliary a,Soiltemp.DomainClass.SoiltempExogenous ex)
        {
            Tuple.Create(s.InitialValues, s.doInitialisationStuff, s.internalTimeStep, s.timeOfDaySecs, s.numNodes, s.numLayers, nodeDepth, thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4, s.volSpecHeatSoil, s.soilTemp, s.morningSoilTemp, s.heatStorage, s.thermalConductance, s.thermalConductivity, s.boundaryLayerConductance, s.newTemperature, s.airTemperature, s.maxTempYesterday, s.minTempYesterday, s.soilWater, s.minSoilTemp, s.maxSoilTemp, s.aveSoilTemp, s.aveSoilWater, s.thickness, s.bulkDensity, s.rocks, s.carbon, s.sand, s.silt, s.clay, soilRoughnessHeight, s.instrumentHeight, s.netRadiation, s.canopyHeight, s.instrumHeight) = init_soiltemperature(ex.weather_MinT, ex.weather_MaxT, ex.weather_MeanT, ex.weather_Tav, ex.weather_Amp, ex.weather_AirPressure, ex.weather_Wind, weather_Latitude, ex.weather_Radn, ex.clock_Today_DayOfYear, ex.microClimate_CanopyHeight, physical_Thickness, physical_BD, ps, ex.physical_Rocks, ex.physical_ParticleSizeSand, ex.physical_ParticleSizeSilt, ex.physical_ParticleSizeClay, ex.organic_Carbon, ex.waterBalance_SW, ex.waterBalance_Eos, ex.waterBalance_Eo, ex.waterBalance_Es, ex.waterBalance_Salb, pInitialValues, DepthToConstantTemperature, timestep, latentHeatOfVapourisation, stefanBoltzmannConstant, airNode, surfaceNode, topsoilNode, numPhantomNodes, constantBoundaryLayerConductance, numIterationsForBoundaryLayerConductance, defaultTimeOfMaximumTemperature, defaultInstrumentHeight, bareSoilRoughness, nodeDepth, thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4, pom, soilRoughnessHeight, nu, boundarLayerConductanceSource, netRadiationSource, MissingValue, soilConstituentNames);
        }

        public void Init(SoiltempState s, SoiltempState s1, SoiltempRate r, SoiltempAuxiliary a, SoiltempExogenous ex)
        {
            _SoilTemperature.Init(s, s1, r, a, ex);
        }

        public SoiltempComponent(SoiltempComponent toCopy): this() // copy constructor 
        {
                
        for (int i = 0; i < toCopy.thermCondPar1.Length; i++)
            { thermCondPar1[i] = toCopy.thermCondPar1[i]; }
    
                topsoilNode = toCopy.topsoilNode;
                surfaceNode = toCopy.surfaceNode;
                numPhantomNodes = toCopy.numPhantomNodes;
                
        for (int i = 0; i < 8; i++)
            { soilConstituentNames[i] = toCopy.soilConstituentNames[i]; }
    
                
        for (int i = 0; i < toCopy.physical_Thickness.Length; i++)
            { physical_Thickness[i] = toCopy.physical_Thickness[i]; }
    
                MissingValue = toCopy.MissingValue;
                timestep = toCopy.timestep;
                soilRoughnessHeight = toCopy.soilRoughnessHeight;
                numIterationsForBoundaryLayerConductance = toCopy.numIterationsForBoundaryLayerConductance;
                defaultTimeOfMaximumTemperature = toCopy.defaultTimeOfMaximumTemperature;
                pom = toCopy.pom;
                DepthToConstantTemperature = toCopy.DepthToConstantTemperature;
                constantBoundaryLayerConductance = toCopy.constantBoundaryLayerConductance;
                
        for (int i = 0; i < toCopy.thermCondPar4.Length; i++)
            { thermCondPar4[i] = toCopy.thermCondPar4[i]; }
    
                
        for (int i = 0; i < toCopy.nodeDepth.Length; i++)
            { nodeDepth[i] = toCopy.nodeDepth[i]; }
    
                nu = toCopy.nu;
                
        for (int i = 0; i < toCopy.pInitialValues.Length; i++)
            { pInitialValues[i] = toCopy.pInitialValues[i]; }
    
                ps = toCopy.ps;
                netRadiationSource = toCopy.netRadiationSource;
                airNode = toCopy.airNode;
                bareSoilRoughness = toCopy.bareSoilRoughness;
                
        for (int i = 0; i < toCopy.thermCondPar2.Length; i++)
            { thermCondPar2[i] = toCopy.thermCondPar2[i]; }
    
                defaultInstrumentHeight = toCopy.defaultInstrumentHeight;
                
        for (int i = 0; i < toCopy.physical_BD.Length; i++)
            { physical_BD[i] = toCopy.physical_BD[i]; }
    
                latentHeatOfVapourisation = toCopy.latentHeatOfVapourisation;
                weather_Latitude = toCopy.weather_Latitude;
                stefanBoltzmannConstant = toCopy.stefanBoltzmannConstant;
                boundarLayerConductanceSource = toCopy.boundarLayerConductanceSource;
                
        for (int i = 0; i < toCopy.thermCondPar3.Length; i++)
            { thermCondPar3[i] = toCopy.thermCondPar3[i]; }
    
            }
        }
    }