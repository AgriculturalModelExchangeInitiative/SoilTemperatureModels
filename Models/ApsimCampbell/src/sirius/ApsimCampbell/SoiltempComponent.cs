
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

using SiriusQualitySoiltemp.DomainClass;
namespace SiriusQualitySoiltemp.Strategies
{
    public class SoiltempComponent : IStrategySiriusQualitySoiltemp
    {
        public SoiltempComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'Thickness'}, "Thickness");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'numIterationsForBoundaryLayerConductance'}, "numIterationsForBoundaryLayerConductance");
            _parameters0_0.Add(v2);
            VarInfo v3 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'thermCondPar3'}, "thermCondPar3");
            _parameters0_0.Add(v3);
            VarInfo v4 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'defaultInstrumentHeight'}, "defaultInstrumentHeight");
            _parameters0_0.Add(v4);
            VarInfo v5 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'latentHeatOfVapourisation'}, "latentHeatOfVapourisation");
            _parameters0_0.Add(v5);
            VarInfo v6 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'airNode'}, "airNode");
            _parameters0_0.Add(v6);
            VarInfo v7 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'ps'}, "ps");
            _parameters0_0.Add(v7);
            VarInfo v8 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'defaultTimeOfMaximumTemperature'}, "defaultTimeOfMaximumTemperature");
            _parameters0_0.Add(v8);
            VarInfo v9 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'netRadiationSource'}, "netRadiationSource");
            _parameters0_0.Add(v9);
            VarInfo v10 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'topsoilNode'}, "topsoilNode");
            _parameters0_0.Add(v10);
            VarInfo v11 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'MissingValue'}, "MissingValue");
            _parameters0_0.Add(v11);
            VarInfo v12 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'pom'}, "pom");
            _parameters0_0.Add(v12);
            VarInfo v13 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'physical_BD'}, "physical_BD");
            _parameters0_0.Add(v13);
            VarInfo v14 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'physical_Thickness'}, "physical_Thickness");
            _parameters0_0.Add(v14);
            VarInfo v15 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'soilRoughnessHeight'}, "soilRoughnessHeight");
            _parameters0_0.Add(v15);
            VarInfo v16 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'numPhantomNodes'}, "numPhantomNodes");
            _parameters0_0.Add(v16);
            VarInfo v17 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'thermCondPar4'}, "thermCondPar4");
            _parameters0_0.Add(v17);
            VarInfo v18 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'nodeDepth'}, "nodeDepth");
            _parameters0_0.Add(v18);
            VarInfo v19 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'surfaceNode'}, "surfaceNode");
            _parameters0_0.Add(v19);
            VarInfo v20 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'boundarLayerConductanceSource'}, "boundarLayerConductanceSource");
            _parameters0_0.Add(v20);
            VarInfo v21 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'thermCondPar2'}, "thermCondPar2");
            _parameters0_0.Add(v21);
            VarInfo v22 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'DepthToConstantTemperature'}, "DepthToConstantTemperature");
            _parameters0_0.Add(v22);
            VarInfo v23 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'constantBoundaryLayerConductance'}, "constantBoundaryLayerConductance");
            _parameters0_0.Add(v23);
            VarInfo v24 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'nu'}, "nu");
            _parameters0_0.Add(v24);
            VarInfo v25 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'bareSoilRoughness'}, "bareSoilRoughness");
            _parameters0_0.Add(v25);
            VarInfo v26 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'stefanBoltzmannConstant'}, "stefanBoltzmannConstant");
            _parameters0_0.Add(v26);
            VarInfo v27 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'InitialValues'}, "InitialValues");
            _parameters0_0.Add(v27);
            VarInfo v28 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'thermCondPar1'}, "thermCondPar1");
            _parameters0_0.Add(v28);
            VarInfo v29 = new CompositeStrategyVarInfo(_{'modu': 'SoilTemperature', 'var': 'soilConstituentNames'}, "soilConstituentNames");
            _parameters0_0.Add(v29);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd1.PropertyName = "thermalConductance";
            pd1.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd2.PropertyName = "weather_MaxT";
            pd2.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MaxT).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MaxT);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd3.PropertyName = "newTemperature";
            pd3.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.newTemperature).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.newTemperature);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd4.PropertyName = "instrumentHeight";
            pd4.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd5.PropertyName = "aveSoilWater";
            pd5.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd6.PropertyName = "thermalConductivity";
            pd6.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd7.PropertyName = "silt";
            pd7.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.silt).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.silt);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd8.PropertyName = "weather_Radn";
            pd8.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd9.PropertyName = "bulkDensity";
            pd9.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd10.PropertyName = "microClimate_CanopyHeight";
            pd10.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight);
            _inputs0_0.Add(pd10);
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd11.PropertyName = "weather_MinT";
            pd11.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MinT).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MinT);
            _inputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd12.PropertyName = "physical_ParticleSizeClay";
            pd12.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay);
            _inputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd13.PropertyName = "netRadiation";
            pd13.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.netRadiation).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.netRadiation);
            _inputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd14.PropertyName = "rocks";
            pd14.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.rocks).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.rocks);
            _inputs0_0.Add(pd14);
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd15.PropertyName = "numLayers";
            pd15.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.numLayers).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.numLayers);
            _inputs0_0.Add(pd15);
            PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd16.PropertyName = "minSoilTemp";
            pd16.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp);
            _inputs0_0.Add(pd16);
            PropertyDescription pd17 = new PropertyDescription();
            pd17.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd17.PropertyName = "instrumHeight";
            pd17.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight).ValueType.TypeForCurrentValue;
            pd17.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight);
            _inputs0_0.Add(pd17);
            PropertyDescription pd18 = new PropertyDescription();
            pd18.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd18.PropertyName = "soilTemp";
            pd18.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilTemp).ValueType.TypeForCurrentValue;
            pd18.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilTemp);
            _inputs0_0.Add(pd18);
            PropertyDescription pd19 = new PropertyDescription();
            pd19.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd19.PropertyName = "weather_Wind";
            pd19.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Wind).ValueType.TypeForCurrentValue;
            pd19.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Wind);
            _inputs0_0.Add(pd19);
            PropertyDescription pd20 = new PropertyDescription();
            pd20.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd20.PropertyName = "physical_ParticleSizeSand";
            pd20.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand).ValueType.TypeForCurrentValue;
            pd20.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand);
            _inputs0_0.Add(pd20);
            PropertyDescription pd21 = new PropertyDescription();
            pd21.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd21.PropertyName = "doInitialisationStuff";
            pd21.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff).ValueType.TypeForCurrentValue;
            pd21.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff);
            _inputs0_0.Add(pd21);
            PropertyDescription pd22 = new PropertyDescription();
            pd22.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd22.PropertyName = "canopyHeight";
            pd22.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight).ValueType.TypeForCurrentValue;
            pd22.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight);
            _inputs0_0.Add(pd22);
            PropertyDescription pd23 = new PropertyDescription();
            pd23.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd23.PropertyName = "boundaryLayerConductance";
            pd23.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance).ValueType.TypeForCurrentValue;
            pd23.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance);
            _inputs0_0.Add(pd23);
            PropertyDescription pd24 = new PropertyDescription();
            pd24.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd24.PropertyName = "soilWater";
            pd24.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilWater).ValueType.TypeForCurrentValue;
            pd24.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilWater);
            _inputs0_0.Add(pd24);
            PropertyDescription pd25 = new PropertyDescription();
            pd25.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd25.PropertyName = "waterBalance_Eos";
            pd25.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos).ValueType.TypeForCurrentValue;
            pd25.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos);
            _inputs0_0.Add(pd25);
            PropertyDescription pd26 = new PropertyDescription();
            pd26.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd26.PropertyName = "maxTempYesterday";
            pd26.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday).ValueType.TypeForCurrentValue;
            pd26.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday);
            _inputs0_0.Add(pd26);
            PropertyDescription pd27 = new PropertyDescription();
            pd27.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd27.PropertyName = "weather_MeanT";
            pd27.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MeanT).ValueType.TypeForCurrentValue;
            pd27.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MeanT);
            _inputs0_0.Add(pd27);
            PropertyDescription pd28 = new PropertyDescription();
            pd28.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd28.PropertyName = "clay";
            pd28.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.clay).ValueType.TypeForCurrentValue;
            pd28.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.clay);
            _inputs0_0.Add(pd28);
            PropertyDescription pd29 = new PropertyDescription();
            pd29.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd29.PropertyName = "thickness";
            pd29.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thickness).ValueType.TypeForCurrentValue;
            pd29.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thickness);
            _inputs0_0.Add(pd29);
            PropertyDescription pd30 = new PropertyDescription();
            pd30.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd30.PropertyName = "weather_Latitude";
            pd30.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Latitude).ValueType.TypeForCurrentValue;
            pd30.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Latitude);
            _inputs0_0.Add(pd30);
            PropertyDescription pd31 = new PropertyDescription();
            pd31.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd31.PropertyName = "weather_Amp";
            pd31.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Amp).ValueType.TypeForCurrentValue;
            pd31.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Amp);
            _inputs0_0.Add(pd31);
            PropertyDescription pd32 = new PropertyDescription();
            pd32.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd32.PropertyName = "timestep";
            pd32.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.timestep).ValueType.TypeForCurrentValue;
            pd32.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.timestep);
            _inputs0_0.Add(pd32);
            PropertyDescription pd33 = new PropertyDescription();
            pd33.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd33.PropertyName = "maxSoilTemp";
            pd33.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp).ValueType.TypeForCurrentValue;
            pd33.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp);
            _inputs0_0.Add(pd33);
            PropertyDescription pd34 = new PropertyDescription();
            pd34.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd34.PropertyName = "timeOfDaySecs";
            pd34.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs).ValueType.TypeForCurrentValue;
            pd34.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs);
            _inputs0_0.Add(pd34);
            PropertyDescription pd35 = new PropertyDescription();
            pd35.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd35.PropertyName = "carbon";
            pd35.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.carbon).ValueType.TypeForCurrentValue;
            pd35.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.carbon);
            _inputs0_0.Add(pd35);
            PropertyDescription pd36 = new PropertyDescription();
            pd36.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd36.PropertyName = "heatStorage";
            pd36.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.heatStorage).ValueType.TypeForCurrentValue;
            pd36.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.heatStorage);
            _inputs0_0.Add(pd36);
            PropertyDescription pd37 = new PropertyDescription();
            pd37.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd37.PropertyName = "aveSoilTemp";
            pd37.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp).ValueType.TypeForCurrentValue;
            pd37.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp);
            _inputs0_0.Add(pd37);
            PropertyDescription pd38 = new PropertyDescription();
            pd38.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd38.PropertyName = "waterBalance_Salb";
            pd38.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb).ValueType.TypeForCurrentValue;
            pd38.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb);
            _inputs0_0.Add(pd38);
            PropertyDescription pd39 = new PropertyDescription();
            pd39.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd39.PropertyName = "minTempYesterday";
            pd39.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday).ValueType.TypeForCurrentValue;
            pd39.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday);
            _inputs0_0.Add(pd39);
            PropertyDescription pd40 = new PropertyDescription();
            pd40.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd40.PropertyName = "physical_ParticleSizeSilt";
            pd40.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt).ValueType.TypeForCurrentValue;
            pd40.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt);
            _inputs0_0.Add(pd40);
            PropertyDescription pd41 = new PropertyDescription();
            pd41.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd41.PropertyName = "numNodes";
            pd41.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.numNodes).ValueType.TypeForCurrentValue;
            pd41.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.numNodes);
            _inputs0_0.Add(pd41);
            PropertyDescription pd42 = new PropertyDescription();
            pd42.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd42.PropertyName = "clock_Today_DayOfYear";
            pd42.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear).ValueType.TypeForCurrentValue;
            pd42.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear);
            _inputs0_0.Add(pd42);
            PropertyDescription pd43 = new PropertyDescription();
            pd43.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd43.PropertyName = "waterBalance_Eo";
            pd43.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo).ValueType.TypeForCurrentValue;
            pd43.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo);
            _inputs0_0.Add(pd43);
            PropertyDescription pd44 = new PropertyDescription();
            pd44.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd44.PropertyName = "waterBalance_SW";
            pd44.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW).ValueType.TypeForCurrentValue;
            pd44.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW);
            _inputs0_0.Add(pd44);
            PropertyDescription pd45 = new PropertyDescription();
            pd45.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd45.PropertyName = "waterBalance_Es";
            pd45.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es).ValueType.TypeForCurrentValue;
            pd45.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es);
            _inputs0_0.Add(pd45);
            PropertyDescription pd46 = new PropertyDescription();
            pd46.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd46.PropertyName = "weather_Tav";
            pd46.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Tav).ValueType.TypeForCurrentValue;
            pd46.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Tav);
            _inputs0_0.Add(pd46);
            PropertyDescription pd47 = new PropertyDescription();
            pd47.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd47.PropertyName = "volSpecHeatSoil";
            pd47.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil).ValueType.TypeForCurrentValue;
            pd47.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil);
            _inputs0_0.Add(pd47);
            PropertyDescription pd48 = new PropertyDescription();
            pd48.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd48.PropertyName = "physical_Rocks";
            pd48.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks).ValueType.TypeForCurrentValue;
            pd48.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks);
            _inputs0_0.Add(pd48);
            PropertyDescription pd49 = new PropertyDescription();
            pd49.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd49.PropertyName = "weather_AirPressure";
            pd49.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_AirPressure).ValueType.TypeForCurrentValue;
            pd49.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_AirPressure);
            _inputs0_0.Add(pd49);
            PropertyDescription pd50 = new PropertyDescription();
            pd50.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd50.PropertyName = "sand";
            pd50.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.sand).ValueType.TypeForCurrentValue;
            pd50.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.sand);
            _inputs0_0.Add(pd50);
            PropertyDescription pd51 = new PropertyDescription();
            pd51.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd51.PropertyName = "morningSoilTemp";
            pd51.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp).ValueType.TypeForCurrentValue;
            pd51.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp);
            _inputs0_0.Add(pd51);
            PropertyDescription pd52 = new PropertyDescription();
            pd52.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous);
            pd52.PropertyName = "organic_Carbon";
            pd52.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon).ValueType.TypeForCurrentValue;
            pd52.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon);
            _inputs0_0.Add(pd52);
            PropertyDescription pd53 = new PropertyDescription();
            pd53.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd53.PropertyName = "airTemperature";
            pd53.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.airTemperature).ValueType.TypeForCurrentValue;
            pd53.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.airTemperature);
            _inputs0_0.Add(pd53);
            PropertyDescription pd54 = new PropertyDescription();
            pd54.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd54.PropertyName = "internalTimeStep";
            pd54.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep).ValueType.TypeForCurrentValue;
            pd54.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep);
            _inputs0_0.Add(pd54);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd55 = new PropertyDescription();
            pd55.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd55.PropertyName = "heatStorage";
            pd55.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.heatStorage).ValueType.TypeForCurrentValue;
            pd55.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.heatStorage);
            _outputs0_0.Add(pd55);
            PropertyDescription pd56 = new PropertyDescription();
            pd56.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd56.PropertyName = "instrumentHeight";
            pd56.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight).ValueType.TypeForCurrentValue;
            pd56.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight);
            _outputs0_0.Add(pd56);
            PropertyDescription pd57 = new PropertyDescription();
            pd57.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd57.PropertyName = "minSoilTemp";
            pd57.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp).ValueType.TypeForCurrentValue;
            pd57.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp);
            _outputs0_0.Add(pd57);
            PropertyDescription pd58 = new PropertyDescription();
            pd58.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd58.PropertyName = "maxSoilTemp";
            pd58.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp).ValueType.TypeForCurrentValue;
            pd58.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp);
            _outputs0_0.Add(pd58);
            PropertyDescription pd59 = new PropertyDescription();
            pd59.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd59.PropertyName = "aveSoilTemp";
            pd59.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp).ValueType.TypeForCurrentValue;
            pd59.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp);
            _outputs0_0.Add(pd59);
            PropertyDescription pd60 = new PropertyDescription();
            pd60.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd60.PropertyName = "volSpecHeatSoil";
            pd60.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil).ValueType.TypeForCurrentValue;
            pd60.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil);
            _outputs0_0.Add(pd60);
            PropertyDescription pd61 = new PropertyDescription();
            pd61.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd61.PropertyName = "soilTemp";
            pd61.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilTemp).ValueType.TypeForCurrentValue;
            pd61.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilTemp);
            _outputs0_0.Add(pd61);
            PropertyDescription pd62 = new PropertyDescription();
            pd62.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd62.PropertyName = "morningSoilTemp";
            pd62.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp).ValueType.TypeForCurrentValue;
            pd62.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp);
            _outputs0_0.Add(pd62);
            PropertyDescription pd63 = new PropertyDescription();
            pd63.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd63.PropertyName = "newTemperature";
            pd63.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.newTemperature).ValueType.TypeForCurrentValue;
            pd63.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.newTemperature);
            _outputs0_0.Add(pd63);
            PropertyDescription pd64 = new PropertyDescription();
            pd64.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd64.PropertyName = "thermalConductivity";
            pd64.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity).ValueType.TypeForCurrentValue;
            pd64.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity);
            _outputs0_0.Add(pd64);
            PropertyDescription pd65 = new PropertyDescription();
            pd65.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd65.PropertyName = "thermalConductance";
            pd65.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance).ValueType.TypeForCurrentValue;
            pd65.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance);
            _outputs0_0.Add(pd65);
            PropertyDescription pd66 = new PropertyDescription();
            pd66.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd66.PropertyName = "boundaryLayerConductance";
            pd66.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance).ValueType.TypeForCurrentValue;
            pd66.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance);
            _outputs0_0.Add(pd66);
            PropertyDescription pd67 = new PropertyDescription();
            pd67.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd67.PropertyName = "soilWater";
            pd67.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilWater).ValueType.TypeForCurrentValue;
            pd67.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilWater);
            _outputs0_0.Add(pd67);
            PropertyDescription pd68 = new PropertyDescription();
            pd68.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd68.PropertyName = "doInitialisationStuff";
            pd68.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff).ValueType.TypeForCurrentValue;
            pd68.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff);
            _outputs0_0.Add(pd68);
            PropertyDescription pd69 = new PropertyDescription();
            pd69.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd69.PropertyName = "maxTempYesterday";
            pd69.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday).ValueType.TypeForCurrentValue;
            pd69.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday);
            _outputs0_0.Add(pd69);
            PropertyDescription pd70 = new PropertyDescription();
            pd70.DomainClassType = typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState);
            pd70.PropertyName = "minTempYesterday";
            pd70.PropertyType = (SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday).ValueType.TypeForCurrentValue;
            pd70.PropertyVarInfo =(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday);
            _outputs0_0.Add(pd70);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(SiriusQualitySoiltemp.Strategies.SoilTemperature).FullName);
            mo0_0.AssociatedStrategies = lAssStrat0_0;
            _modellingOptionsManager = new ModellingOptionsManager(mo0_0);
            SetStaticParametersVarInfoDefinitions();
            SetPublisherData();
        }

        public string Description
        {
            get { return "Soil Temperature" ;}
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
            return new List<Type>() {  typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState), typeof(SiriusQualitySoiltemp.DomainClass.SoiltempState), typeof(SiriusQualitySoiltemp.DomainClass.SoiltempRate), typeof(SiriusQualitySoiltemp.DomainClass.SoiltempAuxiliary), typeof(SiriusQualitySoiltemp.DomainClass.SoiltempExogenous)};
        }

        public double[] Thickness
        {
            get
            {
                 return _SoilTemperature.Thickness; 
            }
            set
            {
                _SoilTemperature.Thickness = value;
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
        public double airNode
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
        public double[] InitialValues
        {
            get
            {
                 return _SoilTemperature.InitialValues; 
            }
            set
            {
                _SoilTemperature.InitialValues = value;
            }
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

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _SoilTemperature.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            ThicknessVarInfo.Name = "Thickness";
            ThicknessVarInfo.Description = "Thickness of soil layers (mm)";
            ThicknessVarInfo.MaxValue = -1D;
            ThicknessVarInfo.MinValue = -1D;
            ThicknessVarInfo.DefaultValue = -1D;
            ThicknessVarInfo.Units = "mm";
            ThicknessVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            numIterationsForBoundaryLayerConductanceVarInfo.Name = "numIterationsForBoundaryLayerConductance";
            numIterationsForBoundaryLayerConductanceVarInfo.Description = "Number of iterations to calculate atmosphere boundary layer conductance";
            numIterationsForBoundaryLayerConductanceVarInfo.MaxValue = -1D;
            numIterationsForBoundaryLayerConductanceVarInfo.MinValue = -1D;
            numIterationsForBoundaryLayerConductanceVarInfo.DefaultValue = 1;
            numIterationsForBoundaryLayerConductanceVarInfo.Units = "";
            numIterationsForBoundaryLayerConductanceVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            thermCondPar3VarInfo.Name = "thermCondPar3";
            thermCondPar3VarInfo.Description = "Parameter 3 for computing thermal conductivity of soil solids";
            thermCondPar3VarInfo.MaxValue = -1D;
            thermCondPar3VarInfo.MinValue = -1D;
            thermCondPar3VarInfo.DefaultValue = -1D;
            thermCondPar3VarInfo.Units = "";
            thermCondPar3VarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            defaultInstrumentHeightVarInfo.Name = "defaultInstrumentHeight";
            defaultInstrumentHeightVarInfo.Description = "Default instrument height";
            defaultInstrumentHeightVarInfo.MaxValue = -1D;
            defaultInstrumentHeightVarInfo.MinValue = -1D;
            defaultInstrumentHeightVarInfo.DefaultValue = 1.2;
            defaultInstrumentHeightVarInfo.Units = "m";
            defaultInstrumentHeightVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            latentHeatOfVapourisationVarInfo.Name = "latentHeatOfVapourisation";
            latentHeatOfVapourisationVarInfo.Description = "Latent heat of vapourisation for water";
            latentHeatOfVapourisationVarInfo.MaxValue = -1D;
            latentHeatOfVapourisationVarInfo.MinValue = -1D;
            latentHeatOfVapourisationVarInfo.DefaultValue = 2465000;
            latentHeatOfVapourisationVarInfo.Units = "miJ/kg";
            latentHeatOfVapourisationVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            airNodeVarInfo.Name = "airNode";
            airNodeVarInfo.Description = "The index of the node in the atmosphere (aboveground)";
            airNodeVarInfo.MaxValue = -1D;
            airNodeVarInfo.MinValue = -1D;
            airNodeVarInfo.DefaultValue = 0;
            airNodeVarInfo.Units = "";
            airNodeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            psVarInfo.Name = "ps";
            psVarInfo.Description = "ps";
            psVarInfo.MaxValue = -1D;
            psVarInfo.MinValue = -1D;
            psVarInfo.DefaultValue = -1D;
            psVarInfo.Units = "";
            psVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            defaultTimeOfMaximumTemperatureVarInfo.Name = "defaultTimeOfMaximumTemperature";
            defaultTimeOfMaximumTemperatureVarInfo.Description = "Time of maximum temperature";
            defaultTimeOfMaximumTemperatureVarInfo.MaxValue = -1D;
            defaultTimeOfMaximumTemperatureVarInfo.MinValue = -1D;
            defaultTimeOfMaximumTemperatureVarInfo.DefaultValue = 14.0;
            defaultTimeOfMaximumTemperatureVarInfo.Units = "minutes";
            defaultTimeOfMaximumTemperatureVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            netRadiationSourceVarInfo.Name = "netRadiationSource";
            netRadiationSourceVarInfo.Description = "Flag whether net radiation is calculated or gotten from input";
            netRadiationSourceVarInfo.MaxValue = -1D;
            netRadiationSourceVarInfo.MinValue = -1D;
            netRadiationSourceVarInfo.DefaultValue = -1D;
            netRadiationSourceVarInfo.Units = "m";
            netRadiationSourceVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("String");

            topsoilNodeVarInfo.Name = "topsoilNode";
            topsoilNodeVarInfo.Description = "The index of the first node within the soil (top layer)";
            topsoilNodeVarInfo.MaxValue = -1D;
            topsoilNodeVarInfo.MinValue = -1D;
            topsoilNodeVarInfo.DefaultValue = 2;
            topsoilNodeVarInfo.Units = "";
            topsoilNodeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            MissingValueVarInfo.Name = "MissingValue";
            MissingValueVarInfo.Description = "missing value";
            MissingValueVarInfo.MaxValue = -1D;
            MissingValueVarInfo.MinValue = -1D;
            MissingValueVarInfo.DefaultValue = 99999;
            MissingValueVarInfo.Units = "m";
            MissingValueVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            pomVarInfo.Name = "pom";
            pomVarInfo.Description = "Particle density of organic matter";
            pomVarInfo.MaxValue = -1D;
            pomVarInfo.MinValue = -1D;
            pomVarInfo.DefaultValue = -1D;
            pomVarInfo.Units = "Mg/m3";
            pomVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            physical_BDVarInfo.Name = "physical_BD";
            physical_BDVarInfo.Description = "Bulk density";
            physical_BDVarInfo.MaxValue = -1D;
            physical_BDVarInfo.MinValue = -1D;
            physical_BDVarInfo.DefaultValue = -1D;
            physical_BDVarInfo.Units = "g/cc";
            physical_BDVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            physical_ThicknessVarInfo.Name = "physical_Thickness";
            physical_ThicknessVarInfo.Description = "Soil layer thickness";
            physical_ThicknessVarInfo.MaxValue = -1D;
            physical_ThicknessVarInfo.MinValue = -1D;
            physical_ThicknessVarInfo.DefaultValue = -1D;
            physical_ThicknessVarInfo.Units = "mm";
            physical_ThicknessVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            soilRoughnessHeightVarInfo.Name = "soilRoughnessHeight";
            soilRoughnessHeightVarInfo.Description = "Height of soil roughness";
            soilRoughnessHeightVarInfo.MaxValue = -1D;
            soilRoughnessHeightVarInfo.MinValue = -1D;
            soilRoughnessHeightVarInfo.DefaultValue = 0;
            soilRoughnessHeightVarInfo.Units = "mm";
            soilRoughnessHeightVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            numPhantomNodesVarInfo.Name = "numPhantomNodes";
            numPhantomNodesVarInfo.Description = "The number of phantom nodes below the soil profile";
            numPhantomNodesVarInfo.MaxValue = -1D;
            numPhantomNodesVarInfo.MinValue = -1D;
            numPhantomNodesVarInfo.DefaultValue = 5;
            numPhantomNodesVarInfo.Units = "";
            numPhantomNodesVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

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

            surfaceNodeVarInfo.Name = "surfaceNode";
            surfaceNodeVarInfo.Description = "The index of the node on the soil surface (depth = 0)";
            surfaceNodeVarInfo.MaxValue = -1D;
            surfaceNodeVarInfo.MinValue = -1D;
            surfaceNodeVarInfo.DefaultValue = 1;
            surfaceNodeVarInfo.Units = "";
            surfaceNodeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            boundarLayerConductanceSourceVarInfo.Name = "boundarLayerConductanceSource";
            boundarLayerConductanceSourceVarInfo.Description = "Flag whether boundary layer conductance is calculated or gotten from inpu";
            boundarLayerConductanceSourceVarInfo.MaxValue = -1D;
            boundarLayerConductanceSourceVarInfo.MinValue = -1D;
            boundarLayerConductanceSourceVarInfo.DefaultValue = -1D;
            boundarLayerConductanceSourceVarInfo.Units = "";
            boundarLayerConductanceSourceVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("String");

            thermCondPar2VarInfo.Name = "thermCondPar2";
            thermCondPar2VarInfo.Description = "Parameter 2 for computing thermal conductivity of soil solids";
            thermCondPar2VarInfo.MaxValue = -1D;
            thermCondPar2VarInfo.MinValue = -1D;
            thermCondPar2VarInfo.DefaultValue = -1D;
            thermCondPar2VarInfo.Units = "";
            thermCondPar2VarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

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

            nuVarInfo.Name = "nu";
            nuVarInfo.Description = "Forward/backward differencing coefficient";
            nuVarInfo.MaxValue = -1D;
            nuVarInfo.MinValue = -1D;
            nuVarInfo.DefaultValue = 0.6;
            nuVarInfo.Units = "0-1";
            nuVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            bareSoilRoughnessVarInfo.Name = "bareSoilRoughness";
            bareSoilRoughnessVarInfo.Description = "Roughness element height of bare soil";
            bareSoilRoughnessVarInfo.MaxValue = -1D;
            bareSoilRoughnessVarInfo.MinValue = -1D;
            bareSoilRoughnessVarInfo.DefaultValue = 57;
            bareSoilRoughnessVarInfo.Units = "mm";
            bareSoilRoughnessVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            stefanBoltzmannConstantVarInfo.Name = "stefanBoltzmannConstant";
            stefanBoltzmannConstantVarInfo.Description = "The Stefan-Boltzmann constant";
            stefanBoltzmannConstantVarInfo.MaxValue = -1D;
            stefanBoltzmannConstantVarInfo.MinValue = -1D;
            stefanBoltzmannConstantVarInfo.DefaultValue = 0.0000000567;
            stefanBoltzmannConstantVarInfo.Units = "W/m2/K4";
            stefanBoltzmannConstantVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            InitialValuesVarInfo.Name = "InitialValues";
            InitialValuesVarInfo.Description = "Initial soil temperature";
            InitialValuesVarInfo.MaxValue = -1D;
            InitialValuesVarInfo.MinValue = -1D;
            InitialValuesVarInfo.DefaultValue = -1D;
            InitialValuesVarInfo.Units = "oC";
            InitialValuesVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            thermCondPar1VarInfo.Name = "thermCondPar1";
            thermCondPar1VarInfo.Description = "Parameter 1 for computing thermal conductivity of soil solids";
            thermCondPar1VarInfo.MaxValue = -1D;
            thermCondPar1VarInfo.MinValue = -1D;
            thermCondPar1VarInfo.DefaultValue = -1D;
            thermCondPar1VarInfo.Units = "";
            thermCondPar1VarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            soilConstituentNamesVarInfo.Name = "soilConstituentNames";
            soilConstituentNamesVarInfo.Description = "soilConstituentNames";
            soilConstituentNamesVarInfo.MaxValue = -1D;
            soilConstituentNamesVarInfo.MinValue = -1D;
            soilConstituentNamesVarInfo.DefaultValue = -1D;
            soilConstituentNamesVarInfo.Units = "m";
            soilConstituentNamesVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("StringInteger");
        }

        public static VarInfo ThicknessVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'Thickness'}.ThicknessVarInfo;} 
        }

        public static VarInfo numIterationsForBoundaryLayerConductanceVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'numIterationsForBoundaryLayerConductance'}.numIterationsForBoundaryLayerConductanceVarInfo;} 
        }

        public static VarInfo thermCondPar3VarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'thermCondPar3'}.thermCondPar3VarInfo;} 
        }

        public static VarInfo defaultInstrumentHeightVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'defaultInstrumentHeight'}.defaultInstrumentHeightVarInfo;} 
        }

        public static VarInfo latentHeatOfVapourisationVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'latentHeatOfVapourisation'}.latentHeatOfVapourisationVarInfo;} 
        }

        public static VarInfo airNodeVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'airNode'}.airNodeVarInfo;} 
        }

        public static VarInfo psVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'ps'}.psVarInfo;} 
        }

        public static VarInfo defaultTimeOfMaximumTemperatureVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'defaultTimeOfMaximumTemperature'}.defaultTimeOfMaximumTemperatureVarInfo;} 
        }

        public static VarInfo netRadiationSourceVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'netRadiationSource'}.netRadiationSourceVarInfo;} 
        }

        public static VarInfo topsoilNodeVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'topsoilNode'}.topsoilNodeVarInfo;} 
        }

        public static VarInfo MissingValueVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'MissingValue'}.MissingValueVarInfo;} 
        }

        public static VarInfo pomVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'pom'}.pomVarInfo;} 
        }

        public static VarInfo physical_BDVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'physical_BD'}.physical_BDVarInfo;} 
        }

        public static VarInfo physical_ThicknessVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'physical_Thickness'}.physical_ThicknessVarInfo;} 
        }

        public static VarInfo soilRoughnessHeightVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'soilRoughnessHeight'}.soilRoughnessHeightVarInfo;} 
        }

        public static VarInfo numPhantomNodesVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'numPhantomNodes'}.numPhantomNodesVarInfo;} 
        }

        public static VarInfo thermCondPar4VarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'thermCondPar4'}.thermCondPar4VarInfo;} 
        }

        public static VarInfo nodeDepthVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'nodeDepth'}.nodeDepthVarInfo;} 
        }

        public static VarInfo surfaceNodeVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'surfaceNode'}.surfaceNodeVarInfo;} 
        }

        public static VarInfo boundarLayerConductanceSourceVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'boundarLayerConductanceSource'}.boundarLayerConductanceSourceVarInfo;} 
        }

        public static VarInfo thermCondPar2VarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'thermCondPar2'}.thermCondPar2VarInfo;} 
        }

        public static VarInfo DepthToConstantTemperatureVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'DepthToConstantTemperature'}.DepthToConstantTemperatureVarInfo;} 
        }

        public static VarInfo constantBoundaryLayerConductanceVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'constantBoundaryLayerConductance'}.constantBoundaryLayerConductanceVarInfo;} 
        }

        public static VarInfo nuVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'nu'}.nuVarInfo;} 
        }

        public static VarInfo bareSoilRoughnessVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'bareSoilRoughness'}.bareSoilRoughnessVarInfo;} 
        }

        public static VarInfo stefanBoltzmannConstantVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'stefanBoltzmannConstant'}.stefanBoltzmannConstantVarInfo;} 
        }

        public static VarInfo InitialValuesVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'InitialValues'}.InitialValuesVarInfo;} 
        }

        public static VarInfo thermCondPar1VarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'thermCondPar1'}.thermCondPar1VarInfo;} 
        }

        public static VarInfo soilConstituentNamesVarInfo
        {
            get { return SiriusQualitySoiltemp.Strategies.{'modu': 'SoilTemperature', 'var': 'soilConstituentNames'}.soilConstituentNamesVarInfo;} 
        }

        public string TestPostConditions(SiriusQualitySoiltemp.DomainClass.SoiltempState s,SiriusQualitySoiltemp.DomainClass.SoiltempState s1,SiriusQualitySoiltemp.DomainClass.SoiltempRate r,SiriusQualitySoiltemp.DomainClass.SoiltempAuxiliary a,SiriusQualitySoiltemp.DomainClass.SoiltempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.heatStorage.CurrentValue=s.heatStorage;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight.CurrentValue=s.instrumentHeight;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp.CurrentValue=s.minSoilTemp;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp.CurrentValue=s.maxSoilTemp;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp.CurrentValue=s.aveSoilTemp;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil.CurrentValue=s.volSpecHeatSoil;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilTemp.CurrentValue=s.soilTemp;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp.CurrentValue=s.morningSoilTemp;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.newTemperature.CurrentValue=s.newTemperature;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity.CurrentValue=s.thermalConductivity;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance.CurrentValue=s.thermalConductance;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance.CurrentValue=s.boundaryLayerConductance;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilWater.CurrentValue=s.soilWater;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff.CurrentValue=s.doInitialisationStuff;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday.CurrentValue=s.maxTempYesterday;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday.CurrentValue=s.minTempYesterday;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r84 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.heatStorage);
                if(r84.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.heatStorage.ValueType)){prc.AddCondition(r84);}
                RangeBasedCondition r85 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight);
                if(r85.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight.ValueType)){prc.AddCondition(r85);}
                RangeBasedCondition r86 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp);
                if(r86.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp.ValueType)){prc.AddCondition(r86);}
                RangeBasedCondition r87 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp);
                if(r87.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp.ValueType)){prc.AddCondition(r87);}
                RangeBasedCondition r88 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp);
                if(r88.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp.ValueType)){prc.AddCondition(r88);}
                RangeBasedCondition r89 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil);
                if(r89.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil.ValueType)){prc.AddCondition(r89);}
                RangeBasedCondition r90 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilTemp);
                if(r90.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilTemp.ValueType)){prc.AddCondition(r90);}
                RangeBasedCondition r91 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp);
                if(r91.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp.ValueType)){prc.AddCondition(r91);}
                RangeBasedCondition r92 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.newTemperature);
                if(r92.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.newTemperature.ValueType)){prc.AddCondition(r92);}
                RangeBasedCondition r93 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity);
                if(r93.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity.ValueType)){prc.AddCondition(r93);}
                RangeBasedCondition r94 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance);
                if(r94.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance.ValueType)){prc.AddCondition(r94);}
                RangeBasedCondition r95 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance);
                if(r95.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance.ValueType)){prc.AddCondition(r95);}
                RangeBasedCondition r96 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilWater);
                if(r96.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilWater.ValueType)){prc.AddCondition(r96);}
                RangeBasedCondition r97 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff);
                if(r97.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff.ValueType)){prc.AddCondition(r97);}
                RangeBasedCondition r98 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday);
                if(r98.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday.ValueType)){prc.AddCondition(r98);}
                RangeBasedCondition r99 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday);
                if(r99.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday.ValueType)){prc.AddCondition(r99);}

                string ret = "";
                ret += _SoilTemperature.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualitySoiltemp.Strategies.Soiltemp");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.Soiltemp, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualitySoiltemp.DomainClass.SoiltempState s,SiriusQualitySoiltemp.DomainClass.SoiltempState s1,SiriusQualitySoiltemp.DomainClass.SoiltempRate r,SiriusQualitySoiltemp.DomainClass.SoiltempAuxiliary a,SiriusQualitySoiltemp.DomainClass.SoiltempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance.CurrentValue=s.thermalConductance;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MaxT.CurrentValue=ex.weather_MaxT;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.newTemperature.CurrentValue=s.newTemperature;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight.CurrentValue=s.instrumentHeight;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater.CurrentValue=s.aveSoilWater;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity.CurrentValue=s.thermalConductivity;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.silt.CurrentValue=s.silt;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn.CurrentValue=ex.weather_Radn;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity.CurrentValue=s.bulkDensity;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight.CurrentValue=ex.microClimate_CanopyHeight;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MinT.CurrentValue=ex.weather_MinT;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay.CurrentValue=ex.physical_ParticleSizeClay;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.netRadiation.CurrentValue=s.netRadiation;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.rocks.CurrentValue=s.rocks;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.numLayers.CurrentValue=s.numLayers;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp.CurrentValue=s.minSoilTemp;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight.CurrentValue=s.instrumHeight;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilTemp.CurrentValue=s.soilTemp;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Wind.CurrentValue=ex.weather_Wind;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand.CurrentValue=ex.physical_ParticleSizeSand;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff.CurrentValue=s.doInitialisationStuff;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight.CurrentValue=s.canopyHeight;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance.CurrentValue=s.boundaryLayerConductance;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilWater.CurrentValue=s.soilWater;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos.CurrentValue=ex.waterBalance_Eos;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday.CurrentValue=s.maxTempYesterday;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MeanT.CurrentValue=ex.weather_MeanT;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.clay.CurrentValue=s.clay;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thickness.CurrentValue=s.thickness;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Latitude.CurrentValue=ex.weather_Latitude;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Amp.CurrentValue=ex.weather_Amp;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.timestep.CurrentValue=ex.timestep;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp.CurrentValue=s.maxSoilTemp;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs.CurrentValue=s.timeOfDaySecs;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.carbon.CurrentValue=s.carbon;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.heatStorage.CurrentValue=s.heatStorage;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp.CurrentValue=s.aveSoilTemp;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb.CurrentValue=ex.waterBalance_Salb;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday.CurrentValue=s.minTempYesterday;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt.CurrentValue=ex.physical_ParticleSizeSilt;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.numNodes.CurrentValue=s.numNodes;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear.CurrentValue=ex.clock_Today_DayOfYear;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo.CurrentValue=ex.waterBalance_Eo;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW.CurrentValue=ex.waterBalance_SW;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es.CurrentValue=ex.waterBalance_Es;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Tav.CurrentValue=ex.weather_Tav;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil.CurrentValue=s.volSpecHeatSoil;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks.CurrentValue=ex.physical_Rocks;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_AirPressure.CurrentValue=ex.weather_AirPressure;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.sand.CurrentValue=s.sand;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp.CurrentValue=s.morningSoilTemp;
                SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon.CurrentValue=ex.organic_Carbon;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.airTemperature.CurrentValue=s.airTemperature;
                SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep.CurrentValue=s.internalTimeStep;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MaxT);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MaxT.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.newTemperature);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.newTemperature.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.silt);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.silt.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn);
                if(r8.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity);
                if(r9.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight);
                if(r10.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MinT);
                if(r11.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MinT.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay);
                if(r12.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.netRadiation);
                if(r13.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.netRadiation.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.rocks);
                if(r14.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.rocks.ValueType)){prc.AddCondition(r14);}
                RangeBasedCondition r15 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.numLayers);
                if(r15.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.numLayers.ValueType)){prc.AddCondition(r15);}
                RangeBasedCondition r16 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp);
                if(r16.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp.ValueType)){prc.AddCondition(r16);}
                RangeBasedCondition r17 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight);
                if(r17.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight.ValueType)){prc.AddCondition(r17);}
                RangeBasedCondition r18 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilTemp);
                if(r18.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilTemp.ValueType)){prc.AddCondition(r18);}
                RangeBasedCondition r19 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Wind);
                if(r19.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Wind.ValueType)){prc.AddCondition(r19);}
                RangeBasedCondition r20 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand);
                if(r20.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand.ValueType)){prc.AddCondition(r20);}
                RangeBasedCondition r21 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff);
                if(r21.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff.ValueType)){prc.AddCondition(r21);}
                RangeBasedCondition r22 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight);
                if(r22.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight.ValueType)){prc.AddCondition(r22);}
                RangeBasedCondition r23 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance);
                if(r23.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance.ValueType)){prc.AddCondition(r23);}
                RangeBasedCondition r24 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilWater);
                if(r24.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.soilWater.ValueType)){prc.AddCondition(r24);}
                RangeBasedCondition r25 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos);
                if(r25.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos.ValueType)){prc.AddCondition(r25);}
                RangeBasedCondition r26 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday);
                if(r26.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday.ValueType)){prc.AddCondition(r26);}
                RangeBasedCondition r27 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MeanT);
                if(r27.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MeanT.ValueType)){prc.AddCondition(r27);}
                RangeBasedCondition r28 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.clay);
                if(r28.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.clay.ValueType)){prc.AddCondition(r28);}
                RangeBasedCondition r29 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thickness);
                if(r29.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.thickness.ValueType)){prc.AddCondition(r29);}
                RangeBasedCondition r30 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Latitude);
                if(r30.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Latitude.ValueType)){prc.AddCondition(r30);}
                RangeBasedCondition r31 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Amp);
                if(r31.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Amp.ValueType)){prc.AddCondition(r31);}
                RangeBasedCondition r32 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.timestep);
                if(r32.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.timestep.ValueType)){prc.AddCondition(r32);}
                RangeBasedCondition r33 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp);
                if(r33.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp.ValueType)){prc.AddCondition(r33);}
                RangeBasedCondition r34 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs);
                if(r34.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs.ValueType)){prc.AddCondition(r34);}
                RangeBasedCondition r35 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.carbon);
                if(r35.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.carbon.ValueType)){prc.AddCondition(r35);}
                RangeBasedCondition r36 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.heatStorage);
                if(r36.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.heatStorage.ValueType)){prc.AddCondition(r36);}
                RangeBasedCondition r37 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp);
                if(r37.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp.ValueType)){prc.AddCondition(r37);}
                RangeBasedCondition r38 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb);
                if(r38.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb.ValueType)){prc.AddCondition(r38);}
                RangeBasedCondition r39 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday);
                if(r39.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday.ValueType)){prc.AddCondition(r39);}
                RangeBasedCondition r40 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt);
                if(r40.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt.ValueType)){prc.AddCondition(r40);}
                RangeBasedCondition r41 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.numNodes);
                if(r41.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.numNodes.ValueType)){prc.AddCondition(r41);}
                RangeBasedCondition r42 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear);
                if(r42.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear.ValueType)){prc.AddCondition(r42);}
                RangeBasedCondition r43 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo);
                if(r43.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo.ValueType)){prc.AddCondition(r43);}
                RangeBasedCondition r44 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW);
                if(r44.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW.ValueType)){prc.AddCondition(r44);}
                RangeBasedCondition r45 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es);
                if(r45.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es.ValueType)){prc.AddCondition(r45);}
                RangeBasedCondition r46 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Tav);
                if(r46.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Tav.ValueType)){prc.AddCondition(r46);}
                RangeBasedCondition r47 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil);
                if(r47.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil.ValueType)){prc.AddCondition(r47);}
                RangeBasedCondition r48 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks);
                if(r48.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks.ValueType)){prc.AddCondition(r48);}
                RangeBasedCondition r49 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_AirPressure);
                if(r49.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.weather_AirPressure.ValueType)){prc.AddCondition(r49);}
                RangeBasedCondition r50 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.sand);
                if(r50.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.sand.ValueType)){prc.AddCondition(r50);}
                RangeBasedCondition r51 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp);
                if(r51.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp.ValueType)){prc.AddCondition(r51);}
                RangeBasedCondition r52 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon);
                if(r52.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon.ValueType)){prc.AddCondition(r52);}
                RangeBasedCondition r53 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.airTemperature);
                if(r53.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.airTemperature.ValueType)){prc.AddCondition(r53);}
                RangeBasedCondition r54 = new RangeBasedCondition(SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep);
                if(r54.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep.ValueType)){prc.AddCondition(r54);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("Thickness")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("numIterationsForBoundaryLayerConductance")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("thermCondPar3")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("defaultInstrumentHeight")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("latentHeatOfVapourisation")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("airNode")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("ps")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("defaultTimeOfMaximumTemperature")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("netRadiationSource")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("topsoilNode")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("MissingValue")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("pom")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("physical_BD")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("physical_Thickness")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("soilRoughnessHeight")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("numPhantomNodes")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("thermCondPar4")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("nodeDepth")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("surfaceNode")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("boundarLayerConductanceSource")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("thermCondPar2")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DepthToConstantTemperature")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("constantBoundaryLayerConductance")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("nu")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("bareSoilRoughness")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("stefanBoltzmannConstant")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("InitialValues")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("thermCondPar1")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("soilConstituentNames")));
                string ret = "";
                ret += _SoilTemperature.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualitySoiltemp.Strategies.Soiltemp");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.Soiltemp, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualitySoiltemp.DomainClass.SoiltempState s,SiriusQualitySoiltemp.DomainClass.SoiltempState s1,SiriusQualitySoiltemp.DomainClass.SoiltempRate r,SiriusQualitySoiltemp.DomainClass.SoiltempAuxiliary a,SiriusQualitySoiltemp.DomainClass.SoiltempExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualitySoiltemp, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SiriusQualitySoiltemp.DomainClass.SoiltempState s,SiriusQualitySoiltemp.DomainClass.SoiltempState s1,SiriusQualitySoiltemp.DomainClass.SoiltempRate r,SiriusQualitySoiltemp.DomainClass.SoiltempAuxiliary a,SiriusQualitySoiltemp.DomainClass.SoiltempExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        SoilTemperature _SoilTemperature = new SoilTemperature();

        private void EstimateOfAssociatedClasses(SiriusQualitySoiltemp.DomainClass.SoiltempState s,SiriusQualitySoiltemp.DomainClass.SoiltempState s1,SiriusQualitySoiltemp.DomainClass.SoiltempRate r,SiriusQualitySoiltemp.DomainClass.SoiltempAuxiliary a,SiriusQualitySoiltemp.DomainClass.SoiltempExogenous ex)
        {
            _SoilTemperature.Estimate(s,s1, r, a, ex);
        }

        public SoiltempComponent(SoiltempComponent toCopy): this() // copy constructor 
        {
                    
            for (int i = 0; i < toCopy.Thickness.Length; i++)
                { Thickness[i] = toCopy.Thickness[i]; }
    
                    numIterationsForBoundaryLayerConductance = toCopy.numIterationsForBoundaryLayerConductance;
                    
            for (int i = 0; i < toCopy.thermCondPar3.Length; i++)
                { thermCondPar3[i] = toCopy.thermCondPar3[i]; }
    
                    defaultInstrumentHeight = toCopy.defaultInstrumentHeight;
                    latentHeatOfVapourisation = toCopy.latentHeatOfVapourisation;
                    airNode = toCopy.airNode;
                    ps = toCopy.ps;
                    defaultTimeOfMaximumTemperature = toCopy.defaultTimeOfMaximumTemperature;
                    netRadiationSource = toCopy.netRadiationSource;
                    topsoilNode = toCopy.topsoilNode;
                    MissingValue = toCopy.MissingValue;
                    pom = toCopy.pom;
                    
            for (int i = 0; i < toCopy.physical_BD.Length; i++)
                { physical_BD[i] = toCopy.physical_BD[i]; }
    
                    
            for (int i = 0; i < toCopy.physical_Thickness.Length; i++)
                { physical_Thickness[i] = toCopy.physical_Thickness[i]; }
    
                    soilRoughnessHeight = toCopy.soilRoughnessHeight;
                    numPhantomNodes = toCopy.numPhantomNodes;
                    
            for (int i = 0; i < toCopy.thermCondPar4.Length; i++)
                { thermCondPar4[i] = toCopy.thermCondPar4[i]; }
    
                    
            for (int i = 0; i < toCopy.nodeDepth.Length; i++)
                { nodeDepth[i] = toCopy.nodeDepth[i]; }
    
                    surfaceNode = toCopy.surfaceNode;
                    boundarLayerConductanceSource = toCopy.boundarLayerConductanceSource;
                    
            for (int i = 0; i < toCopy.thermCondPar2.Length; i++)
                { thermCondPar2[i] = toCopy.thermCondPar2[i]; }
    
                    DepthToConstantTemperature = toCopy.DepthToConstantTemperature;
                    constantBoundaryLayerConductance = toCopy.constantBoundaryLayerConductance;
                    nu = toCopy.nu;
                    bareSoilRoughness = toCopy.bareSoilRoughness;
                    stefanBoltzmannConstant = toCopy.stefanBoltzmannConstant;
                    
            for (int i = 0; i < toCopy.InitialValues.Length; i++)
                { InitialValues[i] = toCopy.InitialValues[i]; }
    
                    
            for (int i = 0; i < toCopy.thermCondPar1.Length; i++)
                { thermCondPar1[i] = toCopy.thermCondPar1[i]; }
    
                    
            for (int i = 0; i < 8; i++)
                { soilConstituentNames[i] = toCopy.soilConstituentNames[i]; }
    
                }
            }
        }