
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
    public class SoilTemperature : IStrategySoiltemp
    {
        public SoilTemperature()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = -1D;
            v1.Description = "Soil layer thickness";
            v1.Id = 0;
            v1.MaxValue = -1D;
            v1.MinValue = -1D;
            v1.Name = "physical_Thickness";
            v1.Size = 1;
            v1.Units = "mm";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v1);
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = -1D;
            v2.Description = "Bulk density";
            v2.Id = 0;
            v2.MaxValue = -1D;
            v2.MinValue = -1D;
            v2.Name = "physical_BD";
            v2.Size = 1;
            v2.Units = "g/cc";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v2);
            VarInfo v3 = new VarInfo();
            v3.DefaultValue = -1D;
            v3.Description = "ps";
            v3.Id = 0;
            v3.MaxValue = -1D;
            v3.MinValue = -1D;
            v3.Name = "ps";
            v3.Size = 1;
            v3.Units = "";
            v3.URL = "";
            v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v3.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v3);
            VarInfo v4 = new VarInfo();
            v4.DefaultValue = -1D;
            v4.Description = "Thickness of soil layers (mm)";
            v4.Id = 0;
            v4.MaxValue = -1D;
            v4.MinValue = -1D;
            v4.Name = "Thickness";
            v4.Size = 1;
            v4.Units = "mm";
            v4.URL = "";
            v4.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v4.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v4);
            VarInfo v5 = new VarInfo();
            v5.DefaultValue = -1D;
            v5.Description = "Initial soil temperature";
            v5.Id = 0;
            v5.MaxValue = -1D;
            v5.MinValue = -1D;
            v5.Name = "InitialValues";
            v5.Size = 1;
            v5.Units = "oC";
            v5.URL = "";
            v5.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v5.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v5);
            VarInfo v6 = new VarInfo();
            v6.DefaultValue = 10000;
            v6.Description = "Soil depth to constant temperature";
            v6.Id = 0;
            v6.MaxValue = -1D;
            v6.MinValue = -1D;
            v6.Name = "DepthToConstantTemperature";
            v6.Size = 1;
            v6.Units = "mm";
            v6.URL = "";
            v6.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v6.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v6);
            VarInfo v7 = new VarInfo();
            v7.DefaultValue = 2465000;
            v7.Description = "Latent heat of vapourisation for water";
            v7.Id = 0;
            v7.MaxValue = -1D;
            v7.MinValue = -1D;
            v7.Name = "latentHeatOfVapourisation";
            v7.Size = 1;
            v7.Units = "miJ/kg";
            v7.URL = "";
            v7.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v7.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v7);
            VarInfo v8 = new VarInfo();
            v8.DefaultValue = 0.0000000567;
            v8.Description = "The Stefan-Boltzmann constant";
            v8.Id = 0;
            v8.MaxValue = -1D;
            v8.MinValue = -1D;
            v8.Name = "stefanBoltzmannConstant";
            v8.Size = 1;
            v8.Units = "W/m2/K4";
            v8.URL = "";
            v8.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v8.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v8);
            VarInfo v9 = new VarInfo();
            v9.DefaultValue = 0;
            v9.Description = "The index of the node in the atmosphere (aboveground)";
            v9.Id = 0;
            v9.MaxValue = -1D;
            v9.MinValue = -1D;
            v9.Name = "airNode";
            v9.Size = 1;
            v9.Units = "";
            v9.URL = "";
            v9.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v9.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v9);
            VarInfo v10 = new VarInfo();
            v10.DefaultValue = 1;
            v10.Description = "The index of the node on the soil surface (depth = 0)";
            v10.Id = 0;
            v10.MaxValue = -1D;
            v10.MinValue = -1D;
            v10.Name = "surfaceNode";
            v10.Size = 1;
            v10.Units = "";
            v10.URL = "";
            v10.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v10.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v10);
            VarInfo v11 = new VarInfo();
            v11.DefaultValue = 2;
            v11.Description = "The index of the first node within the soil (top layer)";
            v11.Id = 0;
            v11.MaxValue = -1D;
            v11.MinValue = -1D;
            v11.Name = "topsoilNode";
            v11.Size = 1;
            v11.Units = "";
            v11.URL = "";
            v11.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v11.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v11);
            VarInfo v12 = new VarInfo();
            v12.DefaultValue = 5;
            v12.Description = "The number of phantom nodes below the soil profile";
            v12.Id = 0;
            v12.MaxValue = -1D;
            v12.MinValue = -1D;
            v12.Name = "numPhantomNodes";
            v12.Size = 1;
            v12.Units = "";
            v12.URL = "";
            v12.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v12.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v12);
            VarInfo v13 = new VarInfo();
            v13.DefaultValue = 20;
            v13.Description = "Boundary layer conductance, if constant";
            v13.Id = 0;
            v13.MaxValue = -1D;
            v13.MinValue = -1D;
            v13.Name = "constantBoundaryLayerConductance";
            v13.Size = 1;
            v13.Units = "K/W";
            v13.URL = "";
            v13.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v13.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v13);
            VarInfo v14 = new VarInfo();
            v14.DefaultValue = 1;
            v14.Description = "Number of iterations to calculate atmosphere boundary layer conductance";
            v14.Id = 0;
            v14.MaxValue = -1D;
            v14.MinValue = -1D;
            v14.Name = "numIterationsForBoundaryLayerConductance";
            v14.Size = 1;
            v14.Units = "";
            v14.URL = "";
            v14.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v14.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v14);
            VarInfo v15 = new VarInfo();
            v15.DefaultValue = 14.0;
            v15.Description = "Time of maximum temperature";
            v15.Id = 0;
            v15.MaxValue = -1D;
            v15.MinValue = -1D;
            v15.Name = "defaultTimeOfMaximumTemperature";
            v15.Size = 1;
            v15.Units = "minutes";
            v15.URL = "";
            v15.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v15.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v15);
            VarInfo v16 = new VarInfo();
            v16.DefaultValue = 1.2;
            v16.Description = "Default instrument height";
            v16.Id = 0;
            v16.MaxValue = -1D;
            v16.MinValue = -1D;
            v16.Name = "defaultInstrumentHeight";
            v16.Size = 1;
            v16.Units = "m";
            v16.URL = "";
            v16.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v16.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v16);
            VarInfo v17 = new VarInfo();
            v17.DefaultValue = 57;
            v17.Description = "Roughness element height of bare soil";
            v17.Id = 0;
            v17.MaxValue = -1D;
            v17.MinValue = -1D;
            v17.Name = "bareSoilRoughness";
            v17.Size = 1;
            v17.Units = "mm";
            v17.URL = "";
            v17.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v17.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v17);
            VarInfo v18 = new VarInfo();
            v18.DefaultValue = -1D;
            v18.Description = "Depths of nodes";
            v18.Id = 0;
            v18.MaxValue = -1D;
            v18.MinValue = -1D;
            v18.Name = "nodeDepth";
            v18.Size = 1;
            v18.Units = "mm";
            v18.URL = "";
            v18.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v18.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v18);
            VarInfo v19 = new VarInfo();
            v19.DefaultValue = -1D;
            v19.Description = "Parameter 1 for computing thermal conductivity of soil solids";
            v19.Id = 0;
            v19.MaxValue = -1D;
            v19.MinValue = -1D;
            v19.Name = "thermCondPar1";
            v19.Size = 1;
            v19.Units = "";
            v19.URL = "";
            v19.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v19.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v19);
            VarInfo v20 = new VarInfo();
            v20.DefaultValue = -1D;
            v20.Description = "Parameter 2 for computing thermal conductivity of soil solids";
            v20.Id = 0;
            v20.MaxValue = -1D;
            v20.MinValue = -1D;
            v20.Name = "thermCondPar2";
            v20.Size = 1;
            v20.Units = "";
            v20.URL = "";
            v20.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v20.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v20);
            VarInfo v21 = new VarInfo();
            v21.DefaultValue = -1D;
            v21.Description = "Parameter 3 for computing thermal conductivity of soil solids";
            v21.Id = 0;
            v21.MaxValue = -1D;
            v21.MinValue = -1D;
            v21.Name = "thermCondPar3";
            v21.Size = 1;
            v21.Units = "";
            v21.URL = "";
            v21.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v21.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v21);
            VarInfo v22 = new VarInfo();
            v22.DefaultValue = -1D;
            v22.Description = "Parameter 4 for computing thermal conductivity of soil solids";
            v22.Id = 0;
            v22.MaxValue = -1D;
            v22.MinValue = -1D;
            v22.Name = "thermCondPar4";
            v22.Size = 1;
            v22.Units = "";
            v22.URL = "";
            v22.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v22.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v22);
            VarInfo v23 = new VarInfo();
            v23.DefaultValue = -1D;
            v23.Description = "Particle density of organic matter";
            v23.Id = 0;
            v23.MaxValue = -1D;
            v23.MinValue = -1D;
            v23.Name = "pom";
            v23.Size = 1;
            v23.Units = "Mg/m3";
            v23.URL = "";
            v23.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v23.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v23);
            VarInfo v24 = new VarInfo();
            v24.DefaultValue = 0;
            v24.Description = "Height of soil roughness";
            v24.Id = 0;
            v24.MaxValue = -1D;
            v24.MinValue = -1D;
            v24.Name = "soilRoughnessHeight";
            v24.Size = 1;
            v24.Units = "mm";
            v24.URL = "";
            v24.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v24.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v24);
            VarInfo v25 = new VarInfo();
            v25.DefaultValue = 0.6;
            v25.Description = "Forward/backward differencing coefficient";
            v25.Id = 0;
            v25.MaxValue = -1D;
            v25.MinValue = -1D;
            v25.Name = "nu";
            v25.Size = 1;
            v25.Units = "0-1";
            v25.URL = "";
            v25.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v25.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v25);
            VarInfo v26 = new VarInfo();
            v26.DefaultValue = -1D;
            v26.Description = "Flag whether boundary layer conductance is calculated or gotten from inpu";
            v26.Id = 0;
            v26.MaxValue = -1D;
            v26.MinValue = -1D;
            v26.Name = "boundarLayerConductanceSource";
            v26.Size = 1;
            v26.Units = "";
            v26.URL = "";
            v26.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v26.ValueType = VarInfoValueTypes.GetInstanceForName("String");
            _parameters0_0.Add(v26);
            VarInfo v27 = new VarInfo();
            v27.DefaultValue = -1D;
            v27.Description = "Flag whether net radiation is calculated or gotten from input";
            v27.Id = 0;
            v27.MaxValue = -1D;
            v27.MinValue = -1D;
            v27.Name = "netRadiationSource";
            v27.Size = 1;
            v27.Units = "m";
            v27.URL = "";
            v27.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v27.ValueType = VarInfoValueTypes.GetInstanceForName("String");
            _parameters0_0.Add(v27);
            VarInfo v28 = new VarInfo();
            v28.DefaultValue = 99999;
            v28.Description = "missing value";
            v28.Id = 0;
            v28.MaxValue = -1D;
            v28.MinValue = -1D;
            v28.Name = "MissingValue";
            v28.Size = 1;
            v28.Units = "m";
            v28.URL = "";
            v28.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v28.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v28);
            VarInfo v29 = new VarInfo();
            v29.DefaultValue = -1D;
            v29.Description = "soilConstituentNames";
            v29.Id = 0;
            v29.MaxValue = -1D;
            v29.MinValue = -1D;
            v29.Name = "soilConstituentNames";
            v29.Size = 1;
            v29.Units = "m";
            v29.URL = "";
            v29.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v29.ValueType = VarInfoValueTypes.GetInstanceForName("StringInteger");
            _parameters0_0.Add(v29);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd1.PropertyName = "weather_MinT";
            pd1.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MinT).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MinT);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd2.PropertyName = "weather_MaxT";
            pd2.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MaxT).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MaxT);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd3.PropertyName = "weather_MeanT";
            pd3.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MeanT).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MeanT);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd4.PropertyName = "weather_Tav";
            pd4.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Tav).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Tav);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd5.PropertyName = "weather_Amp";
            pd5.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Amp).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Amp);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd6.PropertyName = "weather_AirPressure";
            pd6.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_AirPressure).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_AirPressure);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd7.PropertyName = "weather_Wind";
            pd7.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Wind).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Wind);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd8.PropertyName = "weather_Latitude";
            pd8.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Latitude).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Latitude);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd9.PropertyName = "weather_Radn";
            pd9.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd10.PropertyName = "clock_Today_DayOfYear";
            pd10.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear);
            _inputs0_0.Add(pd10);
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd11.PropertyName = "microClimate_CanopyHeight";
            pd11.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight);
            _inputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd12.PropertyName = "physical_Rocks";
            pd12.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks);
            _inputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd13.PropertyName = "physical_ParticleSizeSand";
            pd13.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand);
            _inputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd14.PropertyName = "physical_ParticleSizeSilt";
            pd14.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt);
            _inputs0_0.Add(pd14);
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd15.PropertyName = "physical_ParticleSizeClay";
            pd15.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay);
            _inputs0_0.Add(pd15);
            PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd16.PropertyName = "organic_Carbon";
            pd16.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon);
            _inputs0_0.Add(pd16);
            PropertyDescription pd17 = new PropertyDescription();
            pd17.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd17.PropertyName = "waterBalance_SW";
            pd17.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW).ValueType.TypeForCurrentValue;
            pd17.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW);
            _inputs0_0.Add(pd17);
            PropertyDescription pd18 = new PropertyDescription();
            pd18.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd18.PropertyName = "waterBalance_Eos";
            pd18.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos).ValueType.TypeForCurrentValue;
            pd18.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos);
            _inputs0_0.Add(pd18);
            PropertyDescription pd19 = new PropertyDescription();
            pd19.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd19.PropertyName = "waterBalance_Eo";
            pd19.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo).ValueType.TypeForCurrentValue;
            pd19.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo);
            _inputs0_0.Add(pd19);
            PropertyDescription pd20 = new PropertyDescription();
            pd20.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd20.PropertyName = "waterBalance_Es";
            pd20.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es).ValueType.TypeForCurrentValue;
            pd20.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es);
            _inputs0_0.Add(pd20);
            PropertyDescription pd21 = new PropertyDescription();
            pd21.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd21.PropertyName = "waterBalance_Salb";
            pd21.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb).ValueType.TypeForCurrentValue;
            pd21.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb);
            _inputs0_0.Add(pd21);
            PropertyDescription pd22 = new PropertyDescription();
            pd22.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd22.PropertyName = "timestep";
            pd22.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.timestep).ValueType.TypeForCurrentValue;
            pd22.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.timestep);
            _inputs0_0.Add(pd22);
            PropertyDescription pd23 = new PropertyDescription();
            pd23.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd23.PropertyName = "doInitialisationStuff";
            pd23.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff).ValueType.TypeForCurrentValue;
            pd23.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff);
            _inputs0_0.Add(pd23);
            PropertyDescription pd24 = new PropertyDescription();
            pd24.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd24.PropertyName = "internalTimeStep";
            pd24.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep).ValueType.TypeForCurrentValue;
            pd24.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep);
            _inputs0_0.Add(pd24);
            PropertyDescription pd25 = new PropertyDescription();
            pd25.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd25.PropertyName = "timeOfDaySecs";
            pd25.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs).ValueType.TypeForCurrentValue;
            pd25.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs);
            _inputs0_0.Add(pd25);
            PropertyDescription pd26 = new PropertyDescription();
            pd26.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd26.PropertyName = "numNodes";
            pd26.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.numNodes).ValueType.TypeForCurrentValue;
            pd26.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.numNodes);
            _inputs0_0.Add(pd26);
            PropertyDescription pd27 = new PropertyDescription();
            pd27.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd27.PropertyName = "numLayers";
            pd27.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.numLayers).ValueType.TypeForCurrentValue;
            pd27.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.numLayers);
            _inputs0_0.Add(pd27);
            PropertyDescription pd28 = new PropertyDescription();
            pd28.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd28.PropertyName = "volSpecHeatSoil";
            pd28.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil).ValueType.TypeForCurrentValue;
            pd28.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil);
            _inputs0_0.Add(pd28);
            PropertyDescription pd29 = new PropertyDescription();
            pd29.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd29.PropertyName = "soilTemp";
            pd29.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp).ValueType.TypeForCurrentValue;
            pd29.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp);
            _inputs0_0.Add(pd29);
            PropertyDescription pd30 = new PropertyDescription();
            pd30.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd30.PropertyName = "morningSoilTemp";
            pd30.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp).ValueType.TypeForCurrentValue;
            pd30.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp);
            _inputs0_0.Add(pd30);
            PropertyDescription pd31 = new PropertyDescription();
            pd31.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd31.PropertyName = "heatStorage";
            pd31.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage).ValueType.TypeForCurrentValue;
            pd31.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage);
            _inputs0_0.Add(pd31);
            PropertyDescription pd32 = new PropertyDescription();
            pd32.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd32.PropertyName = "thermalConductance";
            pd32.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance).ValueType.TypeForCurrentValue;
            pd32.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance);
            _inputs0_0.Add(pd32);
            PropertyDescription pd33 = new PropertyDescription();
            pd33.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd33.PropertyName = "thermalConductivity";
            pd33.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity).ValueType.TypeForCurrentValue;
            pd33.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity);
            _inputs0_0.Add(pd33);
            PropertyDescription pd34 = new PropertyDescription();
            pd34.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd34.PropertyName = "boundaryLayerConductance";
            pd34.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance).ValueType.TypeForCurrentValue;
            pd34.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance);
            _inputs0_0.Add(pd34);
            PropertyDescription pd35 = new PropertyDescription();
            pd35.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd35.PropertyName = "newTemperature";
            pd35.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature).ValueType.TypeForCurrentValue;
            pd35.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature);
            _inputs0_0.Add(pd35);
            PropertyDescription pd36 = new PropertyDescription();
            pd36.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd36.PropertyName = "airTemperature";
            pd36.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature).ValueType.TypeForCurrentValue;
            pd36.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature);
            _inputs0_0.Add(pd36);
            PropertyDescription pd37 = new PropertyDescription();
            pd37.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd37.PropertyName = "maxTempYesterday";
            pd37.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday).ValueType.TypeForCurrentValue;
            pd37.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday);
            _inputs0_0.Add(pd37);
            PropertyDescription pd38 = new PropertyDescription();
            pd38.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd38.PropertyName = "minTempYesterday";
            pd38.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday).ValueType.TypeForCurrentValue;
            pd38.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday);
            _inputs0_0.Add(pd38);
            PropertyDescription pd39 = new PropertyDescription();
            pd39.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd39.PropertyName = "soilWater";
            pd39.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater).ValueType.TypeForCurrentValue;
            pd39.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater);
            _inputs0_0.Add(pd39);
            PropertyDescription pd40 = new PropertyDescription();
            pd40.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd40.PropertyName = "minSoilTemp";
            pd40.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp).ValueType.TypeForCurrentValue;
            pd40.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp);
            _inputs0_0.Add(pd40);
            PropertyDescription pd41 = new PropertyDescription();
            pd41.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd41.PropertyName = "maxSoilTemp";
            pd41.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp).ValueType.TypeForCurrentValue;
            pd41.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp);
            _inputs0_0.Add(pd41);
            PropertyDescription pd42 = new PropertyDescription();
            pd42.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd42.PropertyName = "aveSoilTemp";
            pd42.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp).ValueType.TypeForCurrentValue;
            pd42.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp);
            _inputs0_0.Add(pd42);
            PropertyDescription pd43 = new PropertyDescription();
            pd43.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd43.PropertyName = "aveSoilWater";
            pd43.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater).ValueType.TypeForCurrentValue;
            pd43.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater);
            _inputs0_0.Add(pd43);
            PropertyDescription pd44 = new PropertyDescription();
            pd44.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd44.PropertyName = "thickness";
            pd44.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.thickness).ValueType.TypeForCurrentValue;
            pd44.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.thickness);
            _inputs0_0.Add(pd44);
            PropertyDescription pd45 = new PropertyDescription();
            pd45.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd45.PropertyName = "bulkDensity";
            pd45.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity).ValueType.TypeForCurrentValue;
            pd45.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity);
            _inputs0_0.Add(pd45);
            PropertyDescription pd46 = new PropertyDescription();
            pd46.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd46.PropertyName = "rocks";
            pd46.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.rocks).ValueType.TypeForCurrentValue;
            pd46.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.rocks);
            _inputs0_0.Add(pd46);
            PropertyDescription pd47 = new PropertyDescription();
            pd47.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd47.PropertyName = "carbon";
            pd47.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.carbon).ValueType.TypeForCurrentValue;
            pd47.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.carbon);
            _inputs0_0.Add(pd47);
            PropertyDescription pd48 = new PropertyDescription();
            pd48.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd48.PropertyName = "sand";
            pd48.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.sand).ValueType.TypeForCurrentValue;
            pd48.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.sand);
            _inputs0_0.Add(pd48);
            PropertyDescription pd49 = new PropertyDescription();
            pd49.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd49.PropertyName = "silt";
            pd49.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.silt).ValueType.TypeForCurrentValue;
            pd49.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.silt);
            _inputs0_0.Add(pd49);
            PropertyDescription pd50 = new PropertyDescription();
            pd50.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd50.PropertyName = "clay";
            pd50.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.clay).ValueType.TypeForCurrentValue;
            pd50.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.clay);
            _inputs0_0.Add(pd50);
            PropertyDescription pd51 = new PropertyDescription();
            pd51.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd51.PropertyName = "instrumentHeight";
            pd51.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight).ValueType.TypeForCurrentValue;
            pd51.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight);
            _inputs0_0.Add(pd51);
            PropertyDescription pd52 = new PropertyDescription();
            pd52.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd52.PropertyName = "netRadiation";
            pd52.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation).ValueType.TypeForCurrentValue;
            pd52.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation);
            _inputs0_0.Add(pd52);
            PropertyDescription pd53 = new PropertyDescription();
            pd53.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd53.PropertyName = "canopyHeight";
            pd53.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight).ValueType.TypeForCurrentValue;
            pd53.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight);
            _inputs0_0.Add(pd53);
            PropertyDescription pd54 = new PropertyDescription();
            pd54.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd54.PropertyName = "instrumHeight";
            pd54.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight).ValueType.TypeForCurrentValue;
            pd54.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight);
            _inputs0_0.Add(pd54);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd55 = new PropertyDescription();
            pd55.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd55.PropertyName = "heatStorage";
            pd55.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage).ValueType.TypeForCurrentValue;
            pd55.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage);
            _outputs0_0.Add(pd55);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd56 = new PropertyDescription();
            pd56.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd56.PropertyName = "instrumentHeight";
            pd56.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight).ValueType.TypeForCurrentValue;
            pd56.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight);
            _outputs0_0.Add(pd56);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd57 = new PropertyDescription();
            pd57.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd57.PropertyName = "minSoilTemp";
            pd57.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp).ValueType.TypeForCurrentValue;
            pd57.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp);
            _outputs0_0.Add(pd57);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd58 = new PropertyDescription();
            pd58.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd58.PropertyName = "maxSoilTemp";
            pd58.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp).ValueType.TypeForCurrentValue;
            pd58.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp);
            _outputs0_0.Add(pd58);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd59 = new PropertyDescription();
            pd59.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd59.PropertyName = "aveSoilTemp";
            pd59.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp).ValueType.TypeForCurrentValue;
            pd59.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp);
            _outputs0_0.Add(pd59);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd60 = new PropertyDescription();
            pd60.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd60.PropertyName = "volSpecHeatSoil";
            pd60.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil).ValueType.TypeForCurrentValue;
            pd60.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil);
            _outputs0_0.Add(pd60);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd61 = new PropertyDescription();
            pd61.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd61.PropertyName = "soilTemp";
            pd61.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp).ValueType.TypeForCurrentValue;
            pd61.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp);
            _outputs0_0.Add(pd61);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd62 = new PropertyDescription();
            pd62.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd62.PropertyName = "morningSoilTemp";
            pd62.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp).ValueType.TypeForCurrentValue;
            pd62.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp);
            _outputs0_0.Add(pd62);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd63 = new PropertyDescription();
            pd63.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd63.PropertyName = "newTemperature";
            pd63.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature).ValueType.TypeForCurrentValue;
            pd63.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature);
            _outputs0_0.Add(pd63);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd64 = new PropertyDescription();
            pd64.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd64.PropertyName = "thermalConductivity";
            pd64.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity).ValueType.TypeForCurrentValue;
            pd64.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity);
            _outputs0_0.Add(pd64);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd65 = new PropertyDescription();
            pd65.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd65.PropertyName = "thermalConductance";
            pd65.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance).ValueType.TypeForCurrentValue;
            pd65.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance);
            _outputs0_0.Add(pd65);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd66 = new PropertyDescription();
            pd66.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd66.PropertyName = "boundaryLayerConductance";
            pd66.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance).ValueType.TypeForCurrentValue;
            pd66.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance);
            _outputs0_0.Add(pd66);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd67 = new PropertyDescription();
            pd67.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd67.PropertyName = "soilWater";
            pd67.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater).ValueType.TypeForCurrentValue;
            pd67.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater);
            _outputs0_0.Add(pd67);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd68 = new PropertyDescription();
            pd68.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd68.PropertyName = "doInitialisationStuff";
            pd68.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff).ValueType.TypeForCurrentValue;
            pd68.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff);
            _outputs0_0.Add(pd68);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd69 = new PropertyDescription();
            pd69.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd69.PropertyName = "maxTempYesterday";
            pd69.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday).ValueType.TypeForCurrentValue;
            pd69.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday);
            _outputs0_0.Add(pd69);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd70 = new PropertyDescription();
            pd70.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd70.PropertyName = "minTempYesterday";
            pd70.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday).ValueType.TypeForCurrentValue;
            pd70.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday);
            _outputs0_0.Add(pd70);
            mo0_0.Outputs=_outputs0_0;
            //Associated strategies
            List<string> lAssStrat0_0 = new List<string>();
            mo0_0.AssociatedStrategies = lAssStrat0_0;
            //Adding the modeling options to the modeling options manager
            _modellingOptionsManager = new ModellingOptionsManager(mo0_0);
            SetStaticParametersVarInfoDefinitions();
            SetPublisherData();

        }

        public string Description
        {
            get { return " Soil Temperature " ;}
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
            _pd.Add("Creator", "APSIM");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "APSIM Initiative "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(Soiltemp.DomainClass.SoiltempState),  typeof(Soiltemp.DomainClass.SoiltempState), typeof(Soiltemp.DomainClass.SoiltempRate), typeof(Soiltemp.DomainClass.SoiltempAuxiliary), typeof(Soiltemp.DomainClass.SoiltempExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public double[] physical_Thickness
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("physical_Thickness");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'physical_Thickness' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("physical_Thickness");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'physical_Thickness' not found in strategy 'SoilTemperature'");
            }
        }
        public double[] physical_BD
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("physical_BD");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'physical_BD' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("physical_BD");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'physical_BD' not found in strategy 'SoilTemperature'");
            }
        }
        public double ps
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("ps");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'ps' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("ps");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'ps' not found in strategy 'SoilTemperature'");
            }
        }
        public double[] Thickness
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("Thickness");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'Thickness' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("Thickness");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'Thickness' not found in strategy 'SoilTemperature'");
            }
        }
        public double[] InitialValues
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("InitialValues");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'InitialValues' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("InitialValues");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'InitialValues' not found in strategy 'SoilTemperature'");
            }
        }
        public double DepthToConstantTemperature
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("DepthToConstantTemperature");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'DepthToConstantTemperature' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("DepthToConstantTemperature");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'DepthToConstantTemperature' not found in strategy 'SoilTemperature'");
            }
        }
        public double latentHeatOfVapourisation
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("latentHeatOfVapourisation");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'latentHeatOfVapourisation' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("latentHeatOfVapourisation");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'latentHeatOfVapourisation' not found in strategy 'SoilTemperature'");
            }
        }
        public double stefanBoltzmannConstant
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("stefanBoltzmannConstant");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'stefanBoltzmannConstant' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("stefanBoltzmannConstant");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'stefanBoltzmannConstant' not found in strategy 'SoilTemperature'");
            }
        }
        public double airNode
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("airNode");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'airNode' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("airNode");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'airNode' not found in strategy 'SoilTemperature'");
            }
        }
        public int surfaceNode
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("surfaceNode");
                if (vi != null && vi.CurrentValue!=null) return (int)vi.CurrentValue ;
                else throw new Exception("Parameter 'surfaceNode' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("surfaceNode");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'surfaceNode' not found in strategy 'SoilTemperature'");
            }
        }
        public int topsoilNode
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("topsoilNode");
                if (vi != null && vi.CurrentValue!=null) return (int)vi.CurrentValue ;
                else throw new Exception("Parameter 'topsoilNode' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("topsoilNode");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'topsoilNode' not found in strategy 'SoilTemperature'");
            }
        }
        public int numPhantomNodes
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("numPhantomNodes");
                if (vi != null && vi.CurrentValue!=null) return (int)vi.CurrentValue ;
                else throw new Exception("Parameter 'numPhantomNodes' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("numPhantomNodes");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'numPhantomNodes' not found in strategy 'SoilTemperature'");
            }
        }
        public double constantBoundaryLayerConductance
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("constantBoundaryLayerConductance");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'constantBoundaryLayerConductance' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("constantBoundaryLayerConductance");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'constantBoundaryLayerConductance' not found in strategy 'SoilTemperature'");
            }
        }
        public int numIterationsForBoundaryLayerConductance
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("numIterationsForBoundaryLayerConductance");
                if (vi != null && vi.CurrentValue!=null) return (int)vi.CurrentValue ;
                else throw new Exception("Parameter 'numIterationsForBoundaryLayerConductance' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("numIterationsForBoundaryLayerConductance");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'numIterationsForBoundaryLayerConductance' not found in strategy 'SoilTemperature'");
            }
        }
        public double defaultTimeOfMaximumTemperature
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("defaultTimeOfMaximumTemperature");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'defaultTimeOfMaximumTemperature' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("defaultTimeOfMaximumTemperature");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'defaultTimeOfMaximumTemperature' not found in strategy 'SoilTemperature'");
            }
        }
        public double defaultInstrumentHeight
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("defaultInstrumentHeight");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'defaultInstrumentHeight' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("defaultInstrumentHeight");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'defaultInstrumentHeight' not found in strategy 'SoilTemperature'");
            }
        }
        public double bareSoilRoughness
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("bareSoilRoughness");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'bareSoilRoughness' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("bareSoilRoughness");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'bareSoilRoughness' not found in strategy 'SoilTemperature'");
            }
        }
        public double[] nodeDepth
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("nodeDepth");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'nodeDepth' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("nodeDepth");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'nodeDepth' not found in strategy 'SoilTemperature'");
            }
        }
        public double[] thermCondPar1
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("thermCondPar1");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'thermCondPar1' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("thermCondPar1");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'thermCondPar1' not found in strategy 'SoilTemperature'");
            }
        }
        public double[] thermCondPar2
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("thermCondPar2");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'thermCondPar2' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("thermCondPar2");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'thermCondPar2' not found in strategy 'SoilTemperature'");
            }
        }
        public double[] thermCondPar3
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("thermCondPar3");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'thermCondPar3' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("thermCondPar3");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'thermCondPar3' not found in strategy 'SoilTemperature'");
            }
        }
        public double[] thermCondPar4
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("thermCondPar4");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'thermCondPar4' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("thermCondPar4");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'thermCondPar4' not found in strategy 'SoilTemperature'");
            }
        }
        public double pom
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("pom");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'pom' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("pom");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'pom' not found in strategy 'SoilTemperature'");
            }
        }
        public double soilRoughnessHeight
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("soilRoughnessHeight");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'soilRoughnessHeight' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("soilRoughnessHeight");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'soilRoughnessHeight' not found in strategy 'SoilTemperature'");
            }
        }
        public double nu
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("nu");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'nu' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("nu");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'nu' not found in strategy 'SoilTemperature'");
            }
        }
        public string boundarLayerConductanceSource
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("boundarLayerConductanceSource");
                if (vi != null && vi.CurrentValue!=null) return (string)vi.CurrentValue ;
                else throw new Exception("Parameter 'boundarLayerConductanceSource' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("boundarLayerConductanceSource");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'boundarLayerConductanceSource' not found in strategy 'SoilTemperature'");
            }
        }
        public string netRadiationSource
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("netRadiationSource");
                if (vi != null && vi.CurrentValue!=null) return (string)vi.CurrentValue ;
                else throw new Exception("Parameter 'netRadiationSource' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("netRadiationSource");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'netRadiationSource' not found in strategy 'SoilTemperature'");
            }
        }
        public double MissingValue
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("MissingValue");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'MissingValue' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("MissingValue");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'MissingValue' not found in strategy 'SoilTemperature'");
            }
        }
        public string[] soilConstituentNames
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("soilConstituentNames");
                if (vi != null && vi.CurrentValue!=null) return (string[])vi.CurrentValue ;
                else throw new Exception("Parameter 'soilConstituentNames' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("soilConstituentNames");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'soilConstituentNames' not found in strategy 'SoilTemperature'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            physical_ThicknessVarInfo.Name = "physical_Thickness";
            physical_ThicknessVarInfo.Description = "Soil layer thickness";
            physical_ThicknessVarInfo.MaxValue = -1D;
            physical_ThicknessVarInfo.MinValue = -1D;
            physical_ThicknessVarInfo.DefaultValue = -1D;
            physical_ThicknessVarInfo.Units = "mm";
            physical_ThicknessVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            physical_BDVarInfo.Name = "physical_BD";
            physical_BDVarInfo.Description = "Bulk density";
            physical_BDVarInfo.MaxValue = -1D;
            physical_BDVarInfo.MinValue = -1D;
            physical_BDVarInfo.DefaultValue = -1D;
            physical_BDVarInfo.Units = "g/cc";
            physical_BDVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            psVarInfo.Name = "ps";
            psVarInfo.Description = "ps";
            psVarInfo.MaxValue = -1D;
            psVarInfo.MinValue = -1D;
            psVarInfo.DefaultValue = -1D;
            psVarInfo.Units = "";
            psVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            ThicknessVarInfo.Name = "Thickness";
            ThicknessVarInfo.Description = "Thickness of soil layers (mm)";
            ThicknessVarInfo.MaxValue = -1D;
            ThicknessVarInfo.MinValue = -1D;
            ThicknessVarInfo.DefaultValue = -1D;
            ThicknessVarInfo.Units = "mm";
            ThicknessVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            InitialValuesVarInfo.Name = "InitialValues";
            InitialValuesVarInfo.Description = "Initial soil temperature";
            InitialValuesVarInfo.MaxValue = -1D;
            InitialValuesVarInfo.MinValue = -1D;
            InitialValuesVarInfo.DefaultValue = -1D;
            InitialValuesVarInfo.Units = "oC";
            InitialValuesVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            DepthToConstantTemperatureVarInfo.Name = "DepthToConstantTemperature";
            DepthToConstantTemperatureVarInfo.Description = "Soil depth to constant temperature";
            DepthToConstantTemperatureVarInfo.MaxValue = -1D;
            DepthToConstantTemperatureVarInfo.MinValue = -1D;
            DepthToConstantTemperatureVarInfo.DefaultValue = 10000;
            DepthToConstantTemperatureVarInfo.Units = "mm";
            DepthToConstantTemperatureVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            latentHeatOfVapourisationVarInfo.Name = "latentHeatOfVapourisation";
            latentHeatOfVapourisationVarInfo.Description = "Latent heat of vapourisation for water";
            latentHeatOfVapourisationVarInfo.MaxValue = -1D;
            latentHeatOfVapourisationVarInfo.MinValue = -1D;
            latentHeatOfVapourisationVarInfo.DefaultValue = 2465000;
            latentHeatOfVapourisationVarInfo.Units = "miJ/kg";
            latentHeatOfVapourisationVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            stefanBoltzmannConstantVarInfo.Name = "stefanBoltzmannConstant";
            stefanBoltzmannConstantVarInfo.Description = "The Stefan-Boltzmann constant";
            stefanBoltzmannConstantVarInfo.MaxValue = -1D;
            stefanBoltzmannConstantVarInfo.MinValue = -1D;
            stefanBoltzmannConstantVarInfo.DefaultValue = 0.0000000567;
            stefanBoltzmannConstantVarInfo.Units = "W/m2/K4";
            stefanBoltzmannConstantVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            airNodeVarInfo.Name = "airNode";
            airNodeVarInfo.Description = "The index of the node in the atmosphere (aboveground)";
            airNodeVarInfo.MaxValue = -1D;
            airNodeVarInfo.MinValue = -1D;
            airNodeVarInfo.DefaultValue = 0;
            airNodeVarInfo.Units = "";
            airNodeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            surfaceNodeVarInfo.Name = "surfaceNode";
            surfaceNodeVarInfo.Description = "The index of the node on the soil surface (depth = 0)";
            surfaceNodeVarInfo.MaxValue = -1D;
            surfaceNodeVarInfo.MinValue = -1D;
            surfaceNodeVarInfo.DefaultValue = 1;
            surfaceNodeVarInfo.Units = "";
            surfaceNodeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            topsoilNodeVarInfo.Name = "topsoilNode";
            topsoilNodeVarInfo.Description = "The index of the first node within the soil (top layer)";
            topsoilNodeVarInfo.MaxValue = -1D;
            topsoilNodeVarInfo.MinValue = -1D;
            topsoilNodeVarInfo.DefaultValue = 2;
            topsoilNodeVarInfo.Units = "";
            topsoilNodeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            numPhantomNodesVarInfo.Name = "numPhantomNodes";
            numPhantomNodesVarInfo.Description = "The number of phantom nodes below the soil profile";
            numPhantomNodesVarInfo.MaxValue = -1D;
            numPhantomNodesVarInfo.MinValue = -1D;
            numPhantomNodesVarInfo.DefaultValue = 5;
            numPhantomNodesVarInfo.Units = "";
            numPhantomNodesVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            constantBoundaryLayerConductanceVarInfo.Name = "constantBoundaryLayerConductance";
            constantBoundaryLayerConductanceVarInfo.Description = "Boundary layer conductance, if constant";
            constantBoundaryLayerConductanceVarInfo.MaxValue = -1D;
            constantBoundaryLayerConductanceVarInfo.MinValue = -1D;
            constantBoundaryLayerConductanceVarInfo.DefaultValue = 20;
            constantBoundaryLayerConductanceVarInfo.Units = "K/W";
            constantBoundaryLayerConductanceVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

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

            defaultInstrumentHeightVarInfo.Name = "defaultInstrumentHeight";
            defaultInstrumentHeightVarInfo.Description = "Default instrument height";
            defaultInstrumentHeightVarInfo.MaxValue = -1D;
            defaultInstrumentHeightVarInfo.MinValue = -1D;
            defaultInstrumentHeightVarInfo.DefaultValue = 1.2;
            defaultInstrumentHeightVarInfo.Units = "m";
            defaultInstrumentHeightVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            bareSoilRoughnessVarInfo.Name = "bareSoilRoughness";
            bareSoilRoughnessVarInfo.Description = "Roughness element height of bare soil";
            bareSoilRoughnessVarInfo.MaxValue = -1D;
            bareSoilRoughnessVarInfo.MinValue = -1D;
            bareSoilRoughnessVarInfo.DefaultValue = 57;
            bareSoilRoughnessVarInfo.Units = "mm";
            bareSoilRoughnessVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            nodeDepthVarInfo.Name = "nodeDepth";
            nodeDepthVarInfo.Description = "Depths of nodes";
            nodeDepthVarInfo.MaxValue = -1D;
            nodeDepthVarInfo.MinValue = -1D;
            nodeDepthVarInfo.DefaultValue = -1D;
            nodeDepthVarInfo.Units = "mm";
            nodeDepthVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            thermCondPar1VarInfo.Name = "thermCondPar1";
            thermCondPar1VarInfo.Description = "Parameter 1 for computing thermal conductivity of soil solids";
            thermCondPar1VarInfo.MaxValue = -1D;
            thermCondPar1VarInfo.MinValue = -1D;
            thermCondPar1VarInfo.DefaultValue = -1D;
            thermCondPar1VarInfo.Units = "";
            thermCondPar1VarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            thermCondPar2VarInfo.Name = "thermCondPar2";
            thermCondPar2VarInfo.Description = "Parameter 2 for computing thermal conductivity of soil solids";
            thermCondPar2VarInfo.MaxValue = -1D;
            thermCondPar2VarInfo.MinValue = -1D;
            thermCondPar2VarInfo.DefaultValue = -1D;
            thermCondPar2VarInfo.Units = "";
            thermCondPar2VarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            thermCondPar3VarInfo.Name = "thermCondPar3";
            thermCondPar3VarInfo.Description = "Parameter 3 for computing thermal conductivity of soil solids";
            thermCondPar3VarInfo.MaxValue = -1D;
            thermCondPar3VarInfo.MinValue = -1D;
            thermCondPar3VarInfo.DefaultValue = -1D;
            thermCondPar3VarInfo.Units = "";
            thermCondPar3VarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            thermCondPar4VarInfo.Name = "thermCondPar4";
            thermCondPar4VarInfo.Description = "Parameter 4 for computing thermal conductivity of soil solids";
            thermCondPar4VarInfo.MaxValue = -1D;
            thermCondPar4VarInfo.MinValue = -1D;
            thermCondPar4VarInfo.DefaultValue = -1D;
            thermCondPar4VarInfo.Units = "";
            thermCondPar4VarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            pomVarInfo.Name = "pom";
            pomVarInfo.Description = "Particle density of organic matter";
            pomVarInfo.MaxValue = -1D;
            pomVarInfo.MinValue = -1D;
            pomVarInfo.DefaultValue = -1D;
            pomVarInfo.Units = "Mg/m3";
            pomVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            soilRoughnessHeightVarInfo.Name = "soilRoughnessHeight";
            soilRoughnessHeightVarInfo.Description = "Height of soil roughness";
            soilRoughnessHeightVarInfo.MaxValue = -1D;
            soilRoughnessHeightVarInfo.MinValue = -1D;
            soilRoughnessHeightVarInfo.DefaultValue = 0;
            soilRoughnessHeightVarInfo.Units = "mm";
            soilRoughnessHeightVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            nuVarInfo.Name = "nu";
            nuVarInfo.Description = "Forward/backward differencing coefficient";
            nuVarInfo.MaxValue = -1D;
            nuVarInfo.MinValue = -1D;
            nuVarInfo.DefaultValue = 0.6;
            nuVarInfo.Units = "0-1";
            nuVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            boundarLayerConductanceSourceVarInfo.Name = "boundarLayerConductanceSource";
            boundarLayerConductanceSourceVarInfo.Description = "Flag whether boundary layer conductance is calculated or gotten from inpu";
            boundarLayerConductanceSourceVarInfo.MaxValue = -1D;
            boundarLayerConductanceSourceVarInfo.MinValue = -1D;
            boundarLayerConductanceSourceVarInfo.DefaultValue = -1D;
            boundarLayerConductanceSourceVarInfo.Units = "";
            boundarLayerConductanceSourceVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("String");

            netRadiationSourceVarInfo.Name = "netRadiationSource";
            netRadiationSourceVarInfo.Description = "Flag whether net radiation is calculated or gotten from input";
            netRadiationSourceVarInfo.MaxValue = -1D;
            netRadiationSourceVarInfo.MinValue = -1D;
            netRadiationSourceVarInfo.DefaultValue = -1D;
            netRadiationSourceVarInfo.Units = "m";
            netRadiationSourceVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("String");

            MissingValueVarInfo.Name = "MissingValue";
            MissingValueVarInfo.Description = "missing value";
            MissingValueVarInfo.MaxValue = -1D;
            MissingValueVarInfo.MinValue = -1D;
            MissingValueVarInfo.DefaultValue = 99999;
            MissingValueVarInfo.Units = "m";
            MissingValueVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            soilConstituentNamesVarInfo.Name = "soilConstituentNames";
            soilConstituentNamesVarInfo.Description = "soilConstituentNames";
            soilConstituentNamesVarInfo.MaxValue = -1D;
            soilConstituentNamesVarInfo.MinValue = -1D;
            soilConstituentNamesVarInfo.DefaultValue = -1D;
            soilConstituentNamesVarInfo.Units = "m";
            soilConstituentNamesVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("StringInteger");
        }

        private static VarInfo _physical_ThicknessVarInfo = new VarInfo();
        public static VarInfo physical_ThicknessVarInfo
        {
            get { return _physical_ThicknessVarInfo;} 
        }

        private static VarInfo _physical_BDVarInfo = new VarInfo();
        public static VarInfo physical_BDVarInfo
        {
            get { return _physical_BDVarInfo;} 
        }

        private static VarInfo _psVarInfo = new VarInfo();
        public static VarInfo psVarInfo
        {
            get { return _psVarInfo;} 
        }

        private static VarInfo _ThicknessVarInfo = new VarInfo();
        public static VarInfo ThicknessVarInfo
        {
            get { return _ThicknessVarInfo;} 
        }

        private static VarInfo _InitialValuesVarInfo = new VarInfo();
        public static VarInfo InitialValuesVarInfo
        {
            get { return _InitialValuesVarInfo;} 
        }

        private static VarInfo _DepthToConstantTemperatureVarInfo = new VarInfo();
        public static VarInfo DepthToConstantTemperatureVarInfo
        {
            get { return _DepthToConstantTemperatureVarInfo;} 
        }

        private static VarInfo _latentHeatOfVapourisationVarInfo = new VarInfo();
        public static VarInfo latentHeatOfVapourisationVarInfo
        {
            get { return _latentHeatOfVapourisationVarInfo;} 
        }

        private static VarInfo _stefanBoltzmannConstantVarInfo = new VarInfo();
        public static VarInfo stefanBoltzmannConstantVarInfo
        {
            get { return _stefanBoltzmannConstantVarInfo;} 
        }

        private static VarInfo _airNodeVarInfo = new VarInfo();
        public static VarInfo airNodeVarInfo
        {
            get { return _airNodeVarInfo;} 
        }

        private static VarInfo _surfaceNodeVarInfo = new VarInfo();
        public static VarInfo surfaceNodeVarInfo
        {
            get { return _surfaceNodeVarInfo;} 
        }

        private static VarInfo _topsoilNodeVarInfo = new VarInfo();
        public static VarInfo topsoilNodeVarInfo
        {
            get { return _topsoilNodeVarInfo;} 
        }

        private static VarInfo _numPhantomNodesVarInfo = new VarInfo();
        public static VarInfo numPhantomNodesVarInfo
        {
            get { return _numPhantomNodesVarInfo;} 
        }

        private static VarInfo _constantBoundaryLayerConductanceVarInfo = new VarInfo();
        public static VarInfo constantBoundaryLayerConductanceVarInfo
        {
            get { return _constantBoundaryLayerConductanceVarInfo;} 
        }

        private static VarInfo _numIterationsForBoundaryLayerConductanceVarInfo = new VarInfo();
        public static VarInfo numIterationsForBoundaryLayerConductanceVarInfo
        {
            get { return _numIterationsForBoundaryLayerConductanceVarInfo;} 
        }

        private static VarInfo _defaultTimeOfMaximumTemperatureVarInfo = new VarInfo();
        public static VarInfo defaultTimeOfMaximumTemperatureVarInfo
        {
            get { return _defaultTimeOfMaximumTemperatureVarInfo;} 
        }

        private static VarInfo _defaultInstrumentHeightVarInfo = new VarInfo();
        public static VarInfo defaultInstrumentHeightVarInfo
        {
            get { return _defaultInstrumentHeightVarInfo;} 
        }

        private static VarInfo _bareSoilRoughnessVarInfo = new VarInfo();
        public static VarInfo bareSoilRoughnessVarInfo
        {
            get { return _bareSoilRoughnessVarInfo;} 
        }

        private static VarInfo _nodeDepthVarInfo = new VarInfo();
        public static VarInfo nodeDepthVarInfo
        {
            get { return _nodeDepthVarInfo;} 
        }

        private static VarInfo _thermCondPar1VarInfo = new VarInfo();
        public static VarInfo thermCondPar1VarInfo
        {
            get { return _thermCondPar1VarInfo;} 
        }

        private static VarInfo _thermCondPar2VarInfo = new VarInfo();
        public static VarInfo thermCondPar2VarInfo
        {
            get { return _thermCondPar2VarInfo;} 
        }

        private static VarInfo _thermCondPar3VarInfo = new VarInfo();
        public static VarInfo thermCondPar3VarInfo
        {
            get { return _thermCondPar3VarInfo;} 
        }

        private static VarInfo _thermCondPar4VarInfo = new VarInfo();
        public static VarInfo thermCondPar4VarInfo
        {
            get { return _thermCondPar4VarInfo;} 
        }

        private static VarInfo _pomVarInfo = new VarInfo();
        public static VarInfo pomVarInfo
        {
            get { return _pomVarInfo;} 
        }

        private static VarInfo _soilRoughnessHeightVarInfo = new VarInfo();
        public static VarInfo soilRoughnessHeightVarInfo
        {
            get { return _soilRoughnessHeightVarInfo;} 
        }

        private static VarInfo _nuVarInfo = new VarInfo();
        public static VarInfo nuVarInfo
        {
            get { return _nuVarInfo;} 
        }

        private static VarInfo _boundarLayerConductanceSourceVarInfo = new VarInfo();
        public static VarInfo boundarLayerConductanceSourceVarInfo
        {
            get { return _boundarLayerConductanceSourceVarInfo;} 
        }

        private static VarInfo _netRadiationSourceVarInfo = new VarInfo();
        public static VarInfo netRadiationSourceVarInfo
        {
            get { return _netRadiationSourceVarInfo;} 
        }

        private static VarInfo _MissingValueVarInfo = new VarInfo();
        public static VarInfo MissingValueVarInfo
        {
            get { return _MissingValueVarInfo;} 
        }

        private static VarInfo _soilConstituentNamesVarInfo = new VarInfo();
        public static VarInfo soilConstituentNamesVarInfo
        {
            get { return _soilConstituentNamesVarInfo;} 
        }

        public string TestPostConditions(Soiltemp.DomainClass.SoiltempState s,Soiltemp.DomainClass.SoiltempState s1,Soiltemp.DomainClass.SoiltempRate r,Soiltemp.DomainClass.SoiltempAuxiliary a,Soiltemp.DomainClass.SoiltempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage.CurrentValue=s.heatStorage;
                Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight.CurrentValue=s.instrumentHeight;
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
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r84 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage);
                if(r84.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage.ValueType)){prc.AddCondition(r84);}
                RangeBasedCondition r85 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight);
                if(r85.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight.ValueType)){prc.AddCondition(r85);}
                RangeBasedCondition r86 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp);
                if(r86.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp.ValueType)){prc.AddCondition(r86);}
                RangeBasedCondition r87 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp);
                if(r87.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp.ValueType)){prc.AddCondition(r87);}
                RangeBasedCondition r88 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp);
                if(r88.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp.ValueType)){prc.AddCondition(r88);}
                RangeBasedCondition r89 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil);
                if(r89.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil.ValueType)){prc.AddCondition(r89);}
                RangeBasedCondition r90 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp);
                if(r90.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp.ValueType)){prc.AddCondition(r90);}
                RangeBasedCondition r91 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp);
                if(r91.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp.ValueType)){prc.AddCondition(r91);}
                RangeBasedCondition r92 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature);
                if(r92.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature.ValueType)){prc.AddCondition(r92);}
                RangeBasedCondition r93 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity);
                if(r93.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity.ValueType)){prc.AddCondition(r93);}
                RangeBasedCondition r94 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance);
                if(r94.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance.ValueType)){prc.AddCondition(r94);}
                RangeBasedCondition r95 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance);
                if(r95.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance.ValueType)){prc.AddCondition(r95);}
                RangeBasedCondition r96 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater);
                if(r96.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater.ValueType)){prc.AddCondition(r96);}
                RangeBasedCondition r97 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff);
                if(r97.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff.ValueType)){prc.AddCondition(r97);}
                RangeBasedCondition r98 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday);
                if(r98.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday.ValueType)){prc.AddCondition(r98);}
                RangeBasedCondition r99 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday);
                if(r99.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday.ValueType)){prc.AddCondition(r99);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".Soiltemp, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(Soiltemp.DomainClass.SoiltempState s,Soiltemp.DomainClass.SoiltempState s1,Soiltemp.DomainClass.SoiltempRate r,Soiltemp.DomainClass.SoiltempAuxiliary a,Soiltemp.DomainClass.SoiltempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MinT.CurrentValue=ex.weather_MinT;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MaxT.CurrentValue=ex.weather_MaxT;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MeanT.CurrentValue=ex.weather_MeanT;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Tav.CurrentValue=ex.weather_Tav;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Amp.CurrentValue=ex.weather_Amp;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_AirPressure.CurrentValue=ex.weather_AirPressure;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Wind.CurrentValue=ex.weather_Wind;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Latitude.CurrentValue=ex.weather_Latitude;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn.CurrentValue=ex.weather_Radn;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear.CurrentValue=ex.clock_Today_DayOfYear;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight.CurrentValue=ex.microClimate_CanopyHeight;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks.CurrentValue=ex.physical_Rocks;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand.CurrentValue=ex.physical_ParticleSizeSand;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt.CurrentValue=ex.physical_ParticleSizeSilt;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay.CurrentValue=ex.physical_ParticleSizeClay;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon.CurrentValue=ex.organic_Carbon;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW.CurrentValue=ex.waterBalance_SW;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos.CurrentValue=ex.waterBalance_Eos;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo.CurrentValue=ex.waterBalance_Eo;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es.CurrentValue=ex.waterBalance_Es;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb.CurrentValue=ex.waterBalance_Salb;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.timestep.CurrentValue=ex.timestep;
                Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff.CurrentValue=s.doInitialisationStuff;
                Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep.CurrentValue=s.internalTimeStep;
                Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs.CurrentValue=s.timeOfDaySecs;
                Soiltemp.DomainClass.SoiltempStateVarInfo.numNodes.CurrentValue=s.numNodes;
                Soiltemp.DomainClass.SoiltempStateVarInfo.numLayers.CurrentValue=s.numLayers;
                Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil.CurrentValue=s.volSpecHeatSoil;
                Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp.CurrentValue=s.soilTemp;
                Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp.CurrentValue=s.morningSoilTemp;
                Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage.CurrentValue=s.heatStorage;
                Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance.CurrentValue=s.thermalConductance;
                Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity.CurrentValue=s.thermalConductivity;
                Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance.CurrentValue=s.boundaryLayerConductance;
                Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature.CurrentValue=s.newTemperature;
                Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature.CurrentValue=s.airTemperature;
                Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday.CurrentValue=s.maxTempYesterday;
                Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday.CurrentValue=s.minTempYesterday;
                Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater.CurrentValue=s.soilWater;
                Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp.CurrentValue=s.minSoilTemp;
                Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp.CurrentValue=s.maxSoilTemp;
                Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp.CurrentValue=s.aveSoilTemp;
                Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater.CurrentValue=s.aveSoilWater;
                Soiltemp.DomainClass.SoiltempStateVarInfo.thickness.CurrentValue=s.thickness;
                Soiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity.CurrentValue=s.bulkDensity;
                Soiltemp.DomainClass.SoiltempStateVarInfo.rocks.CurrentValue=s.rocks;
                Soiltemp.DomainClass.SoiltempStateVarInfo.carbon.CurrentValue=s.carbon;
                Soiltemp.DomainClass.SoiltempStateVarInfo.sand.CurrentValue=s.sand;
                Soiltemp.DomainClass.SoiltempStateVarInfo.silt.CurrentValue=s.silt;
                Soiltemp.DomainClass.SoiltempStateVarInfo.clay.CurrentValue=s.clay;
                Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight.CurrentValue=s.instrumentHeight;
                Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation.CurrentValue=s.netRadiation;
                Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight.CurrentValue=s.canopyHeight;
                Soiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight.CurrentValue=s.instrumHeight;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MinT);
                if(r1.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MinT.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MaxT);
                if(r2.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MaxT.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MeanT);
                if(r3.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_MeanT.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Tav);
                if(r4.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Tav.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Amp);
                if(r5.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Amp.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_AirPressure);
                if(r6.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_AirPressure.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Wind);
                if(r7.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Wind.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Latitude);
                if(r8.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Latitude.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn);
                if(r9.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear);
                if(r10.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight);
                if(r11.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks);
                if(r12.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand);
                if(r13.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt);
                if(r14.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt.ValueType)){prc.AddCondition(r14);}
                RangeBasedCondition r15 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay);
                if(r15.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay.ValueType)){prc.AddCondition(r15);}
                RangeBasedCondition r16 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon);
                if(r16.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon.ValueType)){prc.AddCondition(r16);}
                RangeBasedCondition r17 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW);
                if(r17.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW.ValueType)){prc.AddCondition(r17);}
                RangeBasedCondition r18 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos);
                if(r18.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos.ValueType)){prc.AddCondition(r18);}
                RangeBasedCondition r19 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo);
                if(r19.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo.ValueType)){prc.AddCondition(r19);}
                RangeBasedCondition r20 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es);
                if(r20.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es.ValueType)){prc.AddCondition(r20);}
                RangeBasedCondition r21 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb);
                if(r21.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb.ValueType)){prc.AddCondition(r21);}
                RangeBasedCondition r22 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.timestep);
                if(r22.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.timestep.ValueType)){prc.AddCondition(r22);}
                RangeBasedCondition r23 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff);
                if(r23.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff.ValueType)){prc.AddCondition(r23);}
                RangeBasedCondition r24 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep);
                if(r24.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep.ValueType)){prc.AddCondition(r24);}
                RangeBasedCondition r25 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs);
                if(r25.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs.ValueType)){prc.AddCondition(r25);}
                RangeBasedCondition r26 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.numNodes);
                if(r26.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.numNodes.ValueType)){prc.AddCondition(r26);}
                RangeBasedCondition r27 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.numLayers);
                if(r27.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.numLayers.ValueType)){prc.AddCondition(r27);}
                RangeBasedCondition r28 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil);
                if(r28.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil.ValueType)){prc.AddCondition(r28);}
                RangeBasedCondition r29 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp);
                if(r29.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp.ValueType)){prc.AddCondition(r29);}
                RangeBasedCondition r30 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp);
                if(r30.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp.ValueType)){prc.AddCondition(r30);}
                RangeBasedCondition r31 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage);
                if(r31.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage.ValueType)){prc.AddCondition(r31);}
                RangeBasedCondition r32 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance);
                if(r32.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance.ValueType)){prc.AddCondition(r32);}
                RangeBasedCondition r33 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity);
                if(r33.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity.ValueType)){prc.AddCondition(r33);}
                RangeBasedCondition r34 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance);
                if(r34.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance.ValueType)){prc.AddCondition(r34);}
                RangeBasedCondition r35 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature);
                if(r35.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature.ValueType)){prc.AddCondition(r35);}
                RangeBasedCondition r36 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature);
                if(r36.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature.ValueType)){prc.AddCondition(r36);}
                RangeBasedCondition r37 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday);
                if(r37.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday.ValueType)){prc.AddCondition(r37);}
                RangeBasedCondition r38 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday);
                if(r38.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday.ValueType)){prc.AddCondition(r38);}
                RangeBasedCondition r39 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater);
                if(r39.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater.ValueType)){prc.AddCondition(r39);}
                RangeBasedCondition r40 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp);
                if(r40.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp.ValueType)){prc.AddCondition(r40);}
                RangeBasedCondition r41 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp);
                if(r41.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp.ValueType)){prc.AddCondition(r41);}
                RangeBasedCondition r42 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp);
                if(r42.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp.ValueType)){prc.AddCondition(r42);}
                RangeBasedCondition r43 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater);
                if(r43.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater.ValueType)){prc.AddCondition(r43);}
                RangeBasedCondition r44 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.thickness);
                if(r44.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.thickness.ValueType)){prc.AddCondition(r44);}
                RangeBasedCondition r45 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity);
                if(r45.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity.ValueType)){prc.AddCondition(r45);}
                RangeBasedCondition r46 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.rocks);
                if(r46.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.rocks.ValueType)){prc.AddCondition(r46);}
                RangeBasedCondition r47 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.carbon);
                if(r47.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.carbon.ValueType)){prc.AddCondition(r47);}
                RangeBasedCondition r48 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.sand);
                if(r48.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.sand.ValueType)){prc.AddCondition(r48);}
                RangeBasedCondition r49 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.silt);
                if(r49.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.silt.ValueType)){prc.AddCondition(r49);}
                RangeBasedCondition r50 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.clay);
                if(r50.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.clay.ValueType)){prc.AddCondition(r50);}
                RangeBasedCondition r51 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight);
                if(r51.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight.ValueType)){prc.AddCondition(r51);}
                RangeBasedCondition r52 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation);
                if(r52.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation.ValueType)){prc.AddCondition(r52);}
                RangeBasedCondition r53 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight);
                if(r53.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight.ValueType)){prc.AddCondition(r53);}
                RangeBasedCondition r54 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight);
                if(r54.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight.ValueType)){prc.AddCondition(r54);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("physical_Thickness")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("physical_BD")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("ps")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("Thickness")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("InitialValues")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DepthToConstantTemperature")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("latentHeatOfVapourisation")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("stefanBoltzmannConstant")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("airNode")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("surfaceNode")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("topsoilNode")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("numPhantomNodes")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("constantBoundaryLayerConductance")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("numIterationsForBoundaryLayerConductance")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("defaultTimeOfMaximumTemperature")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("defaultInstrumentHeight")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("bareSoilRoughness")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("nodeDepth")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("thermCondPar1")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("thermCondPar2")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("thermCondPar3")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("thermCondPar4")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("pom")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("soilRoughnessHeight")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("nu")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("boundarLayerConductanceSource")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("netRadiationSource")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("MissingValue")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("soilConstituentNames")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".Soiltemp, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
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

        public void Init(Soiltemp.DomainClass.SoiltempState s, Soiltemp.DomainClass.SoiltempState s1, Soiltemp.DomainClass.SoiltempRate r, Soiltemp.DomainClass.SoiltempAuxiliary a, Soiltemp.DomainClass.SoiltempExogenous ex)
        {
            double weather_MinT = ex.weather_MinT;
            double weather_MaxT = ex.weather_MaxT;
            double weather_MeanT = ex.weather_MeanT;
            double weather_Tav = ex.weather_Tav;
            double weather_Amp = ex.weather_Amp;
            double weather_AirPressure = ex.weather_AirPressure;
            double weather_Wind = ex.weather_Wind;
            double weather_Latitude = ex.weather_Latitude;
            double weather_Radn = ex.weather_Radn;
            int clock_Today_DayOfYear = ex.clock_Today_DayOfYear;
            double microClimate_CanopyHeight = ex.microClimate_CanopyHeight;
            double[] physical_Rocks = ex.physical_Rocks;
            double[] physical_ParticleSizeSand = ex.physical_ParticleSizeSand;
            double[] physical_ParticleSizeSilt = ex.physical_ParticleSizeSilt;
            double[] physical_ParticleSizeClay = ex.physical_ParticleSizeClay;
            double[] organic_Carbon = ex.organic_Carbon;
            double[] waterBalance_SW = ex.waterBalance_SW;
            double waterBalance_Eos = ex.waterBalance_Eos;
            double waterBalance_Eo = ex.waterBalance_Eo;
            double waterBalance_Es = ex.waterBalance_Es;
            double waterBalance_Salb = ex.waterBalance_Salb;
            double timestep = ex.timestep;
            bool doInitialisationStuff = false;
            double internalTimeStep = 0.0;
            double timeOfDaySecs = 0.0;
            int numNodes = 0;
            int numLayers = 0;
            double[] volSpecHeatSoil ;
            double[] soilTemp ;
            double[] morningSoilTemp ;
            double[] heatStorage ;
            double[] thermalConductance ;
            double[] thermalConductivity ;
            double boundaryLayerConductance = 0.0;
            double[] newTemperature ;
            double airTemperature = 0.0;
            double maxTempYesterday = 0.0;
            double minTempYesterday = 0.0;
            double[] soilWater ;
            double[] minSoilTemp ;
            double[] maxSoilTemp ;
            double[] aveSoilTemp ;
            double[] aveSoilWater ;
            double[] thickness ;
            double[] bulkDensity ;
            double[] rocks ;
            double[] carbon ;
            double[] sand ;
            double[] silt ;
            double[] clay ;
            double instrumentHeight = 0.0;
            double netRadiation = 0.0;
            double canopyHeight = 0.0;
            double instrumHeight = 0.0;
            doInitialisationStuff = true;
            instrumentHeight = getIniVariables(instrumHeight, defaultInstrumentHeight, instrumentHeight);
            getProfileVariables(ref maxSoilTemp, ref minSoilTemp, topsoilNode, ref thermalConductance, physical_BD, ref soilTemp, ref carbon, physical_ParticleSizeSand, physical_Thickness, ref newTemperature, ref heatStorage, numPhantomNodes, ref soilWater, ref nodeDepth, ref volSpecHeatSoil, ref aveSoilTemp, surfaceNode, ref rocks, physical_Rocks, physical_ParticleSizeSilt, ref thermalConductivity, ref silt, ref sand, ref numNodes, organic_Carbon, ref morningSoilTemp, DepthToConstantTemperature, ref clay, ref thickness, ref bulkDensity, waterBalance_SW, airNode, physical_ParticleSizeClay, ref numLayers, MissingValue);
            readParam(ref soilTemp, ref soilRoughnessHeight, ref newTemperature, bareSoilRoughness, ref thermCondPar2, ref thermCondPar3, ref thermCondPar4, bulkDensity, ref thermCondPar1, numNodes, clay, numLayers, weather_Latitude, weather_Amp, clock_Today_DayOfYear, weather_Tav, surfaceNode, thickness);
            s.doInitialisationStuff= doInitialisationStuff;
            s.internalTimeStep= internalTimeStep;
            s.timeOfDaySecs= timeOfDaySecs;
            s.numNodes= numNodes;
            s.numLayers= numLayers;
            s.volSpecHeatSoil= volSpecHeatSoil;
            s.soilTemp= soilTemp;
            s.morningSoilTemp= morningSoilTemp;
            s.heatStorage= heatStorage;
            s.thermalConductance= thermalConductance;
            s.thermalConductivity= thermalConductivity;
            s.boundaryLayerConductance= boundaryLayerConductance;
            s.newTemperature= newTemperature;
            s.airTemperature= airTemperature;
            s.maxTempYesterday= maxTempYesterday;
            s.minTempYesterday= minTempYesterday;
            s.soilWater= soilWater;
            s.minSoilTemp= minSoilTemp;
            s.maxSoilTemp= maxSoilTemp;
            s.aveSoilTemp= aveSoilTemp;
            s.aveSoilWater= aveSoilWater;
            s.thickness= thickness;
            s.bulkDensity= bulkDensity;
            s.rocks= rocks;
            s.carbon= carbon;
            s.sand= sand;
            s.silt= silt;
            s.clay= clay;
            s.instrumentHeight= instrumentHeight;
            s.netRadiation= netRadiation;
            s.canopyHeight= canopyHeight;
            s.instrumHeight= instrumHeight;
        }
        private void CalculateModel(Soiltemp.DomainClass.SoiltempState s, Soiltemp.DomainClass.SoiltempState s1, Soiltemp.DomainClass.SoiltempRate r, Soiltemp.DomainClass.SoiltempAuxiliary a, Soiltemp.DomainClass.SoiltempExogenous ex)
        {
            double weather_MinT = ex.weather_MinT;
            double weather_MaxT = ex.weather_MaxT;
            double weather_MeanT = ex.weather_MeanT;
            double weather_Tav = ex.weather_Tav;
            double weather_Amp = ex.weather_Amp;
            double weather_AirPressure = ex.weather_AirPressure;
            double weather_Wind = ex.weather_Wind;
            double weather_Latitude = ex.weather_Latitude;
            double weather_Radn = ex.weather_Radn;
            int clock_Today_DayOfYear = ex.clock_Today_DayOfYear;
            double microClimate_CanopyHeight = ex.microClimate_CanopyHeight;
            double[] physical_Rocks = ex.physical_Rocks;
            double[] physical_ParticleSizeSand = ex.physical_ParticleSizeSand;
            double[] physical_ParticleSizeSilt = ex.physical_ParticleSizeSilt;
            double[] physical_ParticleSizeClay = ex.physical_ParticleSizeClay;
            double[] organic_Carbon = ex.organic_Carbon;
            double[] waterBalance_SW = ex.waterBalance_SW;
            double waterBalance_Eos = ex.waterBalance_Eos;
            double waterBalance_Eo = ex.waterBalance_Eo;
            double waterBalance_Es = ex.waterBalance_Es;
            double waterBalance_Salb = ex.waterBalance_Salb;
            double timestep = ex.timestep;
            bool doInitialisationStuff = s.doInitialisationStuff;
            double internalTimeStep = s.internalTimeStep;
            double timeOfDaySecs = s.timeOfDaySecs;
            int numNodes = s.numNodes;
            int numLayers = s.numLayers;
            double[] volSpecHeatSoil = s.volSpecHeatSoil;
            double[] soilTemp = s.soilTemp;
            double[] morningSoilTemp = s.morningSoilTemp;
            double[] heatStorage = s.heatStorage;
            double[] thermalConductance = s.thermalConductance;
            double[] thermalConductivity = s.thermalConductivity;
            double boundaryLayerConductance = s.boundaryLayerConductance;
            double[] newTemperature = s.newTemperature;
            double airTemperature = s.airTemperature;
            double maxTempYesterday = s.maxTempYesterday;
            double minTempYesterday = s.minTempYesterday;
            double[] soilWater = s.soilWater;
            double[] minSoilTemp = s.minSoilTemp;
            double[] maxSoilTemp = s.maxSoilTemp;
            double[] aveSoilTemp = s.aveSoilTemp;
            double[] aveSoilWater = s.aveSoilWater;
            double[] thickness = s.thickness;
            double[] bulkDensity = s.bulkDensity;
            double[] rocks = s.rocks;
            double[] carbon = s.carbon;
            double[] sand = s.sand;
            double[] silt = s.silt;
            double[] clay = s.clay;
            double instrumentHeight = s.instrumentHeight;
            double netRadiation = s.netRadiation;
            double canopyHeight = s.canopyHeight;
            double instrumHeight = s.instrumHeight;
            int i;
            getOtherVariables(ref soilWater, ref instrumentHeight, microClimate_CanopyHeight, waterBalance_SW, numNodes, ref canopyHeight, soilRoughnessHeight, numLayers);
            if (doInitialisationStuff)
            {
                if (ValuesInArray(InitialValues, MissingValue))
                {
                    soilTemp = new double[numNodes + 1 + 1];
                    soilTemp.ToList().GetRange(topsoilNode,topsoilNode + InitialValues.Length - topsoilNode) = InitialValues.ToList().GetRange(0,0 + InitialValues.Length - 0);
                }
                else
                {
                    soilTemp = calcSoilTemperature(soilTemp, weather_Latitude, weather_Amp, numNodes, clock_Today_DayOfYear, weather_Tav, surfaceNode, thickness);
                    InitialValues = new double[numLayers];
                    InitialValues.ToList().GetRange(0,0 + numLayers - 0) = soilTemp.ToList().GetRange(topsoilNode,topsoilNode + numLayers - topsoilNode);
                }
                soilTemp[airNode] = weather_MeanT;
                soilTemp[surfaceNode] = calcSurfaceTemperature(waterBalance_Salb, weather_MeanT, weather_Radn, weather_MaxT);
                for (i=numNodes + 1 ; i!=soilTemp.Length ; i+=1)
                {
                    soilTemp[i] = weather_Tav;
                }
                newTemperature.ToList().GetRange(0,0 + soilTemp.Length - 0) = soilTemp;
                maxTempYesterday = weather_MaxT;
                minTempYesterday = weather_MinT;
                doInitialisationStuff = false;
            }
            doProcess(ref maxSoilTemp, ref minSoilTemp, weather_MaxT, numIterationsForBoundaryLayerConductance, ref maxTempYesterday, ref thermalConductivity, ref timeOfDaySecs, ref soilTemp, weather_MeanT, ref morningSoilTemp, ref newTemperature, ref boundaryLayerConductance, constantBoundaryLayerConductance, ref airTemperature, timestep, weather_MinT, airNode, ref netRadiation, ref aveSoilTemp, ref minTempYesterday, ref internalTimeStep, boundarLayerConductanceSource, clock_Today_DayOfYear, weather_Latitude, weather_Radn, soilConstituentNames, soilWater, ref volSpecHeatSoil, numNodes, nodeDepth, surfaceNode, thickness, MissingValue, bulkDensity, carbon, pom, rocks, ps, sand, silt, clay, defaultTimeOfMaximumTemperature, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, stefanBoltzmannConstant, weather_AirPressure, instrumentHeight, weather_Wind, canopyHeight, netRadiationSource, ref thermalConductance, waterBalance_Es, ref heatStorage, latentHeatOfVapourisation, nu);
            s.doInitialisationStuff= doInitialisationStuff;
            s.volSpecHeatSoil= volSpecHeatSoil;
            s.soilTemp= soilTemp;
            s.morningSoilTemp= morningSoilTemp;
            s.heatStorage= heatStorage;
            s.thermalConductance= thermalConductance;
            s.thermalConductivity= thermalConductivity;
            s.boundaryLayerConductance= boundaryLayerConductance;
            s.newTemperature= newTemperature;
            s.maxTempYesterday= maxTempYesterday;
            s.minTempYesterday= minTempYesterday;
            s.soilWater= soilWater;
            s.minSoilTemp= minSoilTemp;
            s.maxSoilTemp= maxSoilTemp;
            s.aveSoilTemp= aveSoilTemp;
            s.instrumentHeight= instrumentHeight;
        }
        public static double getIniVariables(double instrumHeight, double defaultInstrumentHeight, double instrumentHeight)
        {
            if (instrumHeight > 0.00001)
            {
                instrumentHeight = instrumHeight;
            }
            else
            {
                instrumentHeight = defaultInstrumentHeight;
            }
            return instrumentHeight;
        }
        public static void  getProfileVariables(ref double[] maxSoilTemp, ref double[] minSoilTemp, int topsoilNode, ref double[] thermalConductance, double[] physical_BD, ref double[] soilTemp, ref double[] carbon, double[] physical_ParticleSizeSand, double[] physical_Thickness, ref double[] newTemperature, ref double[] heatStorage, int numPhantomNodes, ref double[] soilWater, ref double[] nodeDepth, ref double[] volSpecHeatSoil, ref double[] aveSoilTemp, int surfaceNode, ref double[] rocks, double[] physical_Rocks, double[] physical_ParticleSizeSilt, ref double[] thermalConductivity, ref double[] silt, ref double[] sand, ref int numNodes, double[] organic_Carbon, ref double[] morningSoilTemp, double DepthToConstantTemperature, ref double[] clay, ref double[] thickness, ref double[] bulkDensity, double[] waterBalance_SW, double airNode, double[] physical_ParticleSizeClay, ref int numLayers, double MissingValue)
        {
            int layer;
            int node;
            int i;
            double belowProfileDepth;
            double thicknessForPhantomNodes;
            int firstPhantomNode;
            double[] oldDepth ;
            double[] oldBulkDensity ;
            double[] oldSoilWater ;
            numLayers = physical_Thickness.Length;
            numNodes = numLayers + numPhantomNodes;
            thickness = new double[numLayers + numPhantomNodes + 1];
            thickness.ToList().GetRange(1,1 + physical_Thickness.Length - 1) = physical_Thickness;
            belowProfileDepth = Math.Max(DepthToConstantTemperature - Sum(thickness, 1, numLayers, MissingValue), 1000.0);
            thicknessForPhantomNodes = belowProfileDepth * 2.0 / numPhantomNodes;
            firstPhantomNode = numLayers;
            for (i=firstPhantomNode ; i!=firstPhantomNode + numPhantomNodes ; i+=1)
            {
                thickness[i] = thicknessForPhantomNodes;
            }
            oldDepth = nodeDepth;
            nodeDepth = new double[numNodes + 1 + 1];
            if (oldDepth != null)
            {
                nodeDepth.ToList().GetRange(0,Math.Min(numNodes + 1 + 1, oldDepth.Length) - 0) = oldDepth.ToList().GetRange(0,Math.Min(numNodes + 1 + 1, oldDepth.Length) - 0);
            }
            nodeDepth[airNode] = 0.0;
            nodeDepth[surfaceNode] = 0.0;
            nodeDepth[topsoilNode] = 0.5 * thickness[1] / 1000.0;
            for (node=topsoilNode ; node!=numNodes + 1 ; node+=1)
            {
                nodeDepth[node + 1] = (Sum(thickness, 1, node - 1, MissingValue) + (0.5 * thickness[node])) / 1000.0;
            }
            oldBulkDensity = bulkDensity;
            bulkDensity = new double[numLayers + 1 + numPhantomNodes];
            if (oldBulkDensity != null)
            {
                bulkDensity.ToList().GetRange(0,Math.Min(numLayers + 1 + numPhantomNodes, oldBulkDensity.Length) - 0) = oldBulkDensity.ToList().GetRange(0,Math.Min(numLayers + 1 + numPhantomNodes, oldBulkDensity.Length) - 0);
            }
            bulkDensity.ToList().GetRange(1,1 + physical_BD.Length - 1) = physical_BD;
            bulkDensity[numNodes] = bulkDensity[numLayers];
            for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
            {
                bulkDensity[layer] = bulkDensity[numLayers];
            }
            oldSoilWater = soilWater;
            soilWater = new double[numLayers + 1 + numPhantomNodes];
            if (oldSoilWater != null)
            {
                soilWater.ToList().GetRange(0,Math.Min(numLayers + 1 + numPhantomNodes, oldSoilWater.Length) - 0) = oldSoilWater.ToList().GetRange(0,Math.Min(numLayers + 1 + numPhantomNodes, oldSoilWater.Length) - 0);
            }
            if (waterBalance_SW != null)
            {
                for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
                {
                    soilWater[layer] = Divide(waterBalance_SW[(layer - 1)] * thickness[(layer - 1)], thickness[layer], 0);
                }
                for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
                {
                    soilWater[layer] = soilWater[numLayers];
                }
            }
            carbon = new double[numLayers + 1 + numPhantomNodes];
            for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
            {
                carbon[layer] = organic_Carbon[layer - 1];
            }
            for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
            {
                carbon[layer] = carbon[numLayers];
            }
            rocks = new double[numLayers + 1 + numPhantomNodes];
            for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
            {
                rocks[layer] = physical_Rocks[layer - 1];
            }
            for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
            {
                rocks[layer] = rocks[numLayers];
            }
            sand = new double[numLayers + 1 + numPhantomNodes];
            for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
            {
                sand[layer] = physical_ParticleSizeSand[layer - 1];
            }
            for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
            {
                sand[layer] = sand[numLayers];
            }
            silt = new double[numLayers + 1 + numPhantomNodes];
            for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
            {
                silt[layer] = physical_ParticleSizeSilt[layer - 1];
            }
            for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
            {
                silt[layer] = silt[numLayers];
            }
            clay = new double[numLayers + 1 + numPhantomNodes];
            for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
            {
                clay[layer] = physical_ParticleSizeClay[layer - 1];
            }
            for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
            {
                clay[layer] = clay[numLayers];
            }
            maxSoilTemp = new double[numLayers + 1 + numPhantomNodes];
            minSoilTemp = new double[numLayers + 1 + numPhantomNodes];
            aveSoilTemp = new double[numLayers + 1 + numPhantomNodes];
            volSpecHeatSoil = new double[numNodes + 1];
            soilTemp = new double[numNodes + 1 + 1];
            morningSoilTemp = new double[numNodes + 1 + 1];
            newTemperature = new double[numNodes + 1 + 1];
            thermalConductivity = new double[numNodes + 1];
            heatStorage = new double[numNodes + 1];
            thermalConductance = new double[numNodes + 1 + 1];
        }
        public static void  doThermalConductivityCoeffs(ref double[] thermCondPar2, ref double[] thermCondPar3, ref double[] thermCondPar4, double[] bulkDensity, ref double[] thermCondPar1, int numNodes, double[] clay, int numLayers)
        {
            int layer;
            double[] oldGC1 ;
            double[] oldGC2 ;
            double[] oldGC3 ;
            double[] oldGC4 ;
            int element;
            oldGC1 = thermCondPar1;
            thermCondPar1 = new double[numNodes + 1];
            if (oldGC1 != null)
            {
                thermCondPar1.ToList().GetRange(0,Math.Min(numNodes + 1, oldGC1.Length) - 0) = oldGC1.ToList().GetRange(0,Math.Min(numNodes + 1, oldGC1.Length) - 0);
            }
            oldGC2 = thermCondPar2;
            thermCondPar2 = new double[numNodes + 1];
            if (oldGC2 != null)
            {
                thermCondPar2.ToList().GetRange(0,Math.Min(numNodes + 1, oldGC2.Length) - 0) = oldGC2.ToList().GetRange(0,Math.Min(numNodes + 1, oldGC2.Length) - 0);
            }
            oldGC3 = thermCondPar3;
            thermCondPar3 = new double[numNodes + 1];
            if (oldGC3 != null)
            {
                thermCondPar3.ToList().GetRange(0,Math.Min(numNodes + 1, oldGC3.Length) - 0) = oldGC3.ToList().GetRange(0,Math.Min(numNodes + 1, oldGC3.Length) - 0);
            }
            oldGC4 = thermCondPar4;
            thermCondPar4 = new double[numNodes + 1];
            if (oldGC4 != null)
            {
                thermCondPar4.ToList().GetRange(0,Math.Min(numNodes + 1, oldGC4.Length) - 0) = oldGC4.ToList().GetRange(0,Math.Min(numNodes + 1, oldGC4.Length) - 0);
            }
            for (layer=1 ; layer!=numLayers + 1 + 1 ; layer+=1)
            {
                element = layer;
                thermCondPar1[element] = 0.65 - (0.78 * bulkDensity[layer]) + (0.6 * Math.Pow(bulkDensity[layer], 2));
                thermCondPar2[element] = 1.06 * bulkDensity[layer];
                thermCondPar3[element] = 1.0 + Divide(2.6, Math.Sqrt(clay[layer]), 0);
                thermCondPar4[element] = 0.03 + (0.1 * Math.Pow(bulkDensity[layer], 2));
            }
        }
        public static void  readParam(ref double[] soilTemp, ref double soilRoughnessHeight, ref double[] newTemperature, double bareSoilRoughness, ref double[] thermCondPar2, ref double[] thermCondPar3, ref double[] thermCondPar4, double[] bulkDensity, ref double[] thermCondPar1, int numNodes, double[] clay, int numLayers, double weather_Latitude, double weather_Amp, int clock_Today_DayOfYear, double weather_Tav, int surfaceNode, double[] thickness)
        {
            doThermalConductivityCoeffs(ref thermCondPar2, ref thermCondPar3, ref thermCondPar4, bulkDensity, ref thermCondPar1, numNodes, clay, numLayers);
            soilTemp = calcSoilTemperature(soilTemp, weather_Latitude, weather_Amp, numNodes, clock_Today_DayOfYear, weather_Tav, surfaceNode, thickness);
            newTemperature.ToList().GetRange(0,0 + soilTemp.Length - 0) = soilTemp;
            soilRoughnessHeight = bareSoilRoughness;
        }
        public static void  getOtherVariables(ref double[] soilWater, ref double instrumentHeight, double microClimate_CanopyHeight, double[] waterBalance_SW, int numNodes, ref double canopyHeight, double soilRoughnessHeight, int numLayers)
        {
            soilWater.ToList().GetRange(1,1 + waterBalance_SW.Length - 1) = waterBalance_SW;
            soilWater[numNodes] = soilWater[numLayers];
            canopyHeight = Math.Max(microClimate_CanopyHeight, soilRoughnessHeight) / 1000.0;
            instrumentHeight = Math.Max(instrumentHeight, canopyHeight + 0.5);
        }
        public static double volumetricFractionOrganicMatter(int layer, double[] bulkDensity, double[] carbon, double pom)
        {
            return carbon[layer] / 100.0 * 2.5 * bulkDensity[layer] / pom;
        }
        public static double volumetricFractionRocks(int layer, double[] rocks)
        {
            return rocks[layer] / 100.0;
        }
        public static double volumetricFractionIce(int layer)
        {
            return 0.0;
        }
        public static double volumetricFractionWater(int layer, double[] soilWater, double[] bulkDensity, double[] carbon, double pom)
        {
            return (1 - volumetricFractionOrganicMatter(layer, bulkDensity, carbon, pom)) * soilWater[layer];
        }
        public static double volumetricFractionClay(int layer, double[] bulkDensity, double[] clay, double ps, double[] carbon, double pom, double[] rocks)
        {
            return (1 - volumetricFractionOrganicMatter(layer, bulkDensity, carbon, pom) - volumetricFractionRocks(layer, rocks)) * clay[layer] / 100.0 * bulkDensity[layer] / ps;
        }
        public static double volumetricFractionSilt(int layer, double[] bulkDensity, double[] silt, double ps, double[] carbon, double pom, double[] rocks)
        {
            return (1 - volumetricFractionOrganicMatter(layer, bulkDensity, carbon, pom) - volumetricFractionRocks(layer, rocks)) * silt[layer] / 100.0 * bulkDensity[layer] / ps;
        }
        public static double volumetricFractionSand(int layer, double[] bulkDensity, double ps, double[] sand, double[] carbon, double pom, double[] rocks)
        {
            return (1 - volumetricFractionOrganicMatter(layer, bulkDensity, carbon, pom) - volumetricFractionRocks(layer, rocks)) * sand[layer] / 100.0 * bulkDensity[layer] / ps;
        }
        public static double kelvinT(double celciusT)
        {
            double celciusToKelvin;
            celciusToKelvin = 273.18;
            return celciusT + celciusToKelvin;
        }
        public static double Divide(double value1, double value2, double errVal)
        {
            if (value2 != (double)(0))
            {
                return value1 / value2;
            }
            return errVal;
        }
        public static double Sum(double[] values, int startIndex, int endIndex, double MissingValue)
        {
            double value;
            double result;
            int index;
            result = 0.0;
            index = -1;
            foreach(float value_cyml in values)
            {
                value = value_cyml;
                index = index + 1;
                if (index >= startIndex && value != MissingValue)
                {
                    result = result + value;
                }
                if (index == endIndex)
                {
                    break;
                }
            }
            return result;
        }
        public static double volumetricSpecificHeat(string name, int layer)
        {
            double specificHeatRocks;
            double specificHeatOM;
            double specificHeatSand;
            double specificHeatSilt;
            double specificHeatClay;
            double specificHeatWater;
            double specificHeatIce;
            double specificHeatAir;
            double result;
            specificHeatRocks = 7.7;
            specificHeatOM = 0.25;
            specificHeatSand = 7.7;
            specificHeatSilt = 2.74;
            specificHeatClay = 2.92;
            specificHeatWater = 0.57;
            specificHeatIce = 2.18;
            specificHeatAir = 0.025;
            result = 0.0;
            if (name == "Rocks")
            {
                result = specificHeatRocks;
            }
            else if ( name == "OrganicMatter")
            {
                result = specificHeatOM;
            }
            else if ( name == "Sand")
            {
                result = specificHeatSand;
            }
            else if ( name == "Silt")
            {
                result = specificHeatSilt;
            }
            else if ( name == "Clay")
            {
                result = specificHeatClay;
            }
            else if ( name == "Water")
            {
                result = specificHeatWater;
            }
            else if ( name == "Ice")
            {
                result = specificHeatIce;
            }
            else if ( name == "Air")
            {
                result = specificHeatAir;
            }
            return result;
        }
        public static double volumetricFractionAir(int layer, double[] rocks, double[] bulkDensity, double[] carbon, double pom, double ps, double[] sand, double[] silt, double[] clay, double[] soilWater)
        {
            return 1.0 - volumetricFractionRocks(layer, rocks) - volumetricFractionOrganicMatter(layer, bulkDensity, carbon, pom) - volumetricFractionSand(layer, bulkDensity, ps, sand, carbon, pom, rocks) - volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks) - volumetricFractionClay(layer, bulkDensity, clay, ps, carbon, pom, rocks) - volumetricFractionWater(layer, soilWater, bulkDensity, carbon, pom) - volumetricFractionIce(layer);
        }
        public static double airDensity(double temperature, double AirPressure)
        {
            double MWair;
            double RGAS;
            double HPA2PA;
            MWair = 0.02897;
            RGAS = 8.3143;
            HPA2PA = 100.0;
            return Divide(MWair * AirPressure * HPA2PA, kelvinT(temperature) * RGAS, 0.0);
        }
        public static double longWaveRadn(double emissivity, double tDegC, double stefanBoltzmannConstant)
        {
            return stefanBoltzmannConstant * emissivity * Math.Pow(kelvinT(tDegC), 4);
        }
        public static double[] mapLayer2Node(double[] layerArray, double[] nodeArray, int numNodes, double[] nodeDepth, int surfaceNode, double[] thickness, double MissingValue)
        {
            int node;
            int layer;
            double depthLayerAbove;
            double d1;
            double d2;
            double dSum;
            for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
            {
                layer = node - 1;
                depthLayerAbove = layer >= 1 ? Sum(thickness, 1, layer, MissingValue) : 0.0;
                d1 = depthLayerAbove - (nodeDepth[node] * 1000.0);
                d2 = nodeDepth[(node + 1)] * 1000.0 - depthLayerAbove;
                dSum = d1 + d2;
                nodeArray[node] = Divide(layerArray[layer] * d1, dSum, 0) + Divide(layerArray[(layer + 1)] * d2, dSum, 0);
            }
            return nodeArray;
        }
        public static double ThermalConductance(string name, int layer, double[] rocks, double[] bulkDensity, double ps, double[] sand, double[] carbon, double pom, double[] silt, double[] clay)
        {
            double thermalConductanceRocks;
            double thermalConductanceOM;
            double thermalConductanceSand;
            double thermalConductanceSilt;
            double thermalConductanceClay;
            double thermalConductanceWater;
            double thermalConductanceIce;
            double thermalConductanceAir;
            double result;
            thermalConductanceRocks = 0.182;
            thermalConductanceOM = 2.50;
            thermalConductanceSand = 0.182;
            thermalConductanceSilt = 2.39;
            thermalConductanceClay = 1.39;
            thermalConductanceWater = 4.18;
            thermalConductanceIce = 1.73;
            thermalConductanceAir = 0.0012;
            result = 0.0;
            if (name == "Rocks")
            {
                result = thermalConductanceRocks;
            }
            else if ( name == "OrganicMatter")
            {
                result = thermalConductanceOM;
            }
            else if ( name == "Sand")
            {
                result = thermalConductanceSand;
            }
            else if ( name == "Silt")
            {
                result = thermalConductanceSilt;
            }
            else if ( name == "Clay")
            {
                result = thermalConductanceClay;
            }
            else if ( name == "Water")
            {
                result = thermalConductanceWater;
            }
            else if ( name == "Ice")
            {
                result = thermalConductanceIce;
            }
            else if ( name == "Air")
            {
                result = thermalConductanceAir;
            }
            else if ( name == "Minerals")
            {
                result = Math.Pow(thermalConductanceRocks, volumetricFractionRocks(layer, rocks)) * Math.Pow(thermalConductanceSand, volumetricFractionSand(layer, bulkDensity, ps, sand, carbon, pom, rocks)) + Math.Pow(thermalConductanceSilt, volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + Math.Pow(thermalConductanceClay, volumetricFractionClay(layer, bulkDensity, clay, ps, carbon, pom, rocks));
            }
            result = volumetricSpecificHeat(name, layer);
            return result;
        }
        public static double shapeFactor(string name, int layer, double[] soilWater, double[] bulkDensity, double[] carbon, double pom, double[] rocks, double ps, double[] sand, double[] silt, double[] clay)
        {
            double shapeFactorRocks;
            double shapeFactorOM;
            double shapeFactorSand;
            double shapeFactorSilt;
            double shapeFactorClay;
            double shapeFactorWater;
            double result;
            shapeFactorRocks = 0.182;
            shapeFactorOM = 0.5;
            shapeFactorSand = 0.182;
            shapeFactorSilt = 0.125;
            shapeFactorClay = 0.007755;
            shapeFactorWater = 1.0;
            result = 0.0;
            if (name == "Rocks")
            {
                result = shapeFactorRocks;
            }
            else if ( name == "OrganicMatter")
            {
                result = shapeFactorOM;
            }
            else if ( name == "Sand")
            {
                result = shapeFactorSand;
            }
            else if ( name == "Silt")
            {
                result = shapeFactorSilt;
            }
            else if ( name == "Clay")
            {
                result = shapeFactorClay;
            }
            else if ( name == "Water")
            {
                result = shapeFactorWater;
            }
            else if ( name == "Ice")
            {
                result = 0.333 - (0.333 * volumetricFractionIce(layer) / (volumetricFractionWater(layer, soilWater, bulkDensity, carbon, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, bulkDensity, carbon, pom, ps, sand, silt, clay, soilWater)));
                return result;
            }
            else if ( name == "Air")
            {
                result = 0.333 - (0.333 * volumetricFractionAir(layer, rocks, bulkDensity, carbon, pom, ps, sand, silt, clay, soilWater) / (volumetricFractionWater(layer, soilWater, bulkDensity, carbon, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, bulkDensity, carbon, pom, ps, sand, silt, clay, soilWater)));
                return result;
            }
            else if ( name == "Minerals")
            {
                result = shapeFactorRocks * volumetricFractionRocks(layer, rocks) + (shapeFactorSand * volumetricFractionSand(layer, bulkDensity, ps, sand, carbon, pom, rocks)) + (shapeFactorSilt * volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + (shapeFactorClay * volumetricFractionClay(layer, bulkDensity, clay, ps, carbon, pom, rocks));
            }
            result = volumetricSpecificHeat(name, layer);
            return result;
        }
        public static void  doUpdate(int numInterationsPerDay, ref double[] maxSoilTemp, ref double[] minSoilTemp, double[] thermalConductivity, ref double[] soilTemp, double timeOfDaySecs, int numNodes, ref double boundaryLayerConductance, ref double[] aveSoilTemp, double airNode, double[] newTemperature, int surfaceNode, double internalTimeStep)
        {
            int node;
            soilTemp.ToList().GetRange(0,0 + newTemperature.Length - 0) = newTemperature;
            if (timeOfDaySecs < (internalTimeStep * 1.2))
            {
                for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
                {
                    minSoilTemp[node] = soilTemp[node];
                    maxSoilTemp[node] = soilTemp[node];
                }
            }
            for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
            {
                if (soilTemp[node] < minSoilTemp[node])
                {
                    minSoilTemp[node] = soilTemp[node];
                }
                else if ( soilTemp[node] > maxSoilTemp[node])
                {
                    maxSoilTemp[node] = soilTemp[node];
                }
                aveSoilTemp[node] = aveSoilTemp[node] + Divide(soilTemp[node], numInterationsPerDay, 0);
            }
            boundaryLayerConductance = boundaryLayerConductance + Divide(thermalConductivity[airNode], numInterationsPerDay, 0);
        }
        public static void  doThomas(ref double[] newTemps, string netRadiationSource, ref double[] thermalConductance, double waterBalance_Eos, double waterBalance_Es, double[] thermalConductivity, double[] soilTemp, int numNodes, double internalTimeStep, ref double[] heatStorage, double latentHeatOfVapourisation, double[] nodeDepth, double nu, double[] volSpecHeatSoil, double airNode, double netRadiation, int surfaceNode, double timestep)
        {
            int node;
            double[] a =  new double [numNodes + 1 + 1];
            double[] b =  new double [numNodes + 1];
            double[] c =  new double [numNodes + 1];
            double[] d =  new double [numNodes + 1];
            double volumeOfSoilAtNode;
            double elementLength;
            double g;
            double sensibleHeatFlux;
            double radnNet;
            double latentHeatFlux;
            double soilSurfaceHeatFlux;
            thermalConductance[airNode] = thermalConductivity[airNode];
            for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
            {
                volumeOfSoilAtNode = 0.5 * (nodeDepth[node + 1] - nodeDepth[node - 1]);
                heatStorage[node] = Divide(volSpecHeatSoil[node] * volumeOfSoilAtNode, internalTimeStep, 0);
                elementLength = nodeDepth[node + 1] - nodeDepth[node];
                thermalConductance[node] = Divide(thermalConductivity[node], elementLength, 0);
            }
            g = 1 - nu;
            for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
            {
                c[node] = -nu * thermalConductance[node];
                a[node + 1] = c[node];
                b[node] = nu * (thermalConductance[node] + thermalConductance[node - 1]) + heatStorage[node];
                d[node] = g * thermalConductance[(node - 1)] * soilTemp[(node - 1)] + ((heatStorage[node] - (g * (thermalConductance[node] + thermalConductance[node - 1]))) * soilTemp[node]) + (g * thermalConductance[node] * soilTemp[(node + 1)]);
            }
            a[surfaceNode] = 0.0;
            sensibleHeatFlux = nu * thermalConductance[airNode] * newTemps[airNode];
            radnNet = 0.0;
            if (netRadiationSource == "calc")
            {
                radnNet = Divide(netRadiation * 1000000.0, internalTimeStep, 0);
            }
            else if ( netRadiationSource == "eos")
            {
                radnNet = Divide(waterBalance_Eos * latentHeatOfVapourisation, timestep, 0);
            }
            latentHeatFlux = Divide(waterBalance_Es * latentHeatOfVapourisation, timestep, 0);
            soilSurfaceHeatFlux = sensibleHeatFlux + radnNet - latentHeatFlux;
            d[surfaceNode] = d[surfaceNode] + soilSurfaceHeatFlux;
            d[numNodes] = d[numNodes] + (nu * thermalConductance[numNodes] * newTemps[(numNodes + 1)]);
            for (node=surfaceNode ; node!=numNodes - 1 + 1 ; node+=1)
            {
                c[node] = Divide(c[node], b[node], 0);
                d[node] = Divide(d[node], b[node], 0);
                b[node + 1] = b[node + 1] - (a[(node + 1)] * c[node]);
                d[node + 1] = d[node + 1] - (a[(node + 1)] * d[node]);
            }
            newTemps[numNodes] = Divide(d[numNodes], b[numNodes], 0);
            for (node=numNodes - 1 ; node!=surfaceNode - 1 ; node+=-1)
            {
                newTemps[node] = d[node] - (c[node] * newTemps[(node + 1)]);
            }
        }
        public static double getBoundaryLayerConductance(ref double[] TNew_zb, double stefanBoltzmannConstant, double airTemperature, double waterBalance_Eos, double weather_AirPressure, double instrumentHeight, double waterBalance_Eo, double weather_Wind, double canopyHeight, int surfaceNode)
        {
            int iteration;
            double vonKarmanConstant;
            double gravitationalConstant;
            double specificHeatOfAir;
            double surfaceEmissivity;
            double SpecificHeatAir;
            double roughnessFactorMomentum;
            double roughnessFactorHeat;
            double d;
            double surfaceTemperature;
            double diffusePenetrationConstant;
            double radiativeConductance;
            double frictionVelocity;
            double boundaryLayerCond;
            double stabilityParammeter;
            double stabilityCorrectionMomentum;
            double stabilityCorrectionHeat;
            double heatFluxDensity;
            vonKarmanConstant = 0.41;
            gravitationalConstant = 9.8;
            specificHeatOfAir = 1010.0;
            surfaceEmissivity = 0.98;
            SpecificHeatAir = specificHeatOfAir * airDensity(airTemperature, weather_AirPressure);
            roughnessFactorMomentum = 0.13 * canopyHeight;
            roughnessFactorHeat = 0.2 * roughnessFactorMomentum;
            d = 0.77 * canopyHeight;
            surfaceTemperature = TNew_zb[surfaceNode];
            diffusePenetrationConstant = Math.Max(0.1, waterBalance_Eos) / Math.Max(0.1, waterBalance_Eo);
            radiativeConductance = 4.0 * stefanBoltzmannConstant * surfaceEmissivity * diffusePenetrationConstant * Math.Pow(kelvinT(airTemperature), 3);
            frictionVelocity = 0.0;
            boundaryLayerCond = 0.0;
            stabilityParammeter = 0.0;
            stabilityCorrectionMomentum = 0.0;
            stabilityCorrectionHeat = 0.0;
            heatFluxDensity = 0.0;
            for (iteration=1 ; iteration!=3 + 1 ; iteration+=1)
            {
                frictionVelocity = Divide(weather_Wind * vonKarmanConstant, Math.Log(Divide(instrumentHeight - d + roughnessFactorMomentum, roughnessFactorMomentum, 0)) + stabilityCorrectionMomentum, 0);
                boundaryLayerCond = Divide(SpecificHeatAir * vonKarmanConstant * frictionVelocity, Math.Log(Divide(instrumentHeight - d + roughnessFactorHeat, roughnessFactorHeat, 0)) + stabilityCorrectionHeat, 0);
                boundaryLayerCond = boundaryLayerCond + radiativeConductance;
                heatFluxDensity = boundaryLayerCond * (surfaceTemperature - airTemperature);
                stabilityParammeter = Divide(-vonKarmanConstant * instrumentHeight * gravitationalConstant * heatFluxDensity, SpecificHeatAir * kelvinT(airTemperature) * Math.Pow(frictionVelocity, 3.0), 0);
                if (stabilityParammeter > 0.0)
                {
                    stabilityCorrectionHeat = 4.7 * stabilityParammeter;
                    stabilityCorrectionMomentum = stabilityCorrectionHeat;
                }
                else
                {
                    stabilityCorrectionHeat = -2.0 * Math.Log((1.0 + Math.Sqrt(1.0 - (16.0 * stabilityParammeter))) / 2.0);
                    stabilityCorrectionMomentum = 0.6 * stabilityCorrectionHeat;
                }
            }
            return boundaryLayerCond;
        }
        public static double interpolateNetRadiation(double solarRadn, double cloudFr, double cva, double[] soilTemp, double airTemperature, double waterBalance_Eo, double waterBalance_Eos, double waterBalance_Salb, int surfaceNode, double internalTimeStep, double stefanBoltzmannConstant)
        {
            double surfaceEmissivity;
            double w2MJ;
            double emissivityAtmos;
            double PenetrationConstant;
            double lwRinSoil;
            double lwRoutSoil;
            double lwRnetSoil;
            double swRin;
            double swRout;
            double swRnetSoil;
            surfaceEmissivity = 0.96;
            w2MJ = internalTimeStep / 1000000.0;
            emissivityAtmos = (1 - (0.84 * cloudFr)) * 0.58 * Math.Pow(cva, 1.0 / 7.0) + (0.84 * cloudFr);
            PenetrationConstant = Divide(Math.Max(0.1, waterBalance_Eos), Math.Max(0.1, waterBalance_Eo), 0);
            lwRinSoil = longWaveRadn(emissivityAtmos, airTemperature, stefanBoltzmannConstant) * PenetrationConstant * w2MJ;
            lwRoutSoil = longWaveRadn(surfaceEmissivity, soilTemp[surfaceNode], stefanBoltzmannConstant) * PenetrationConstant * w2MJ;
            lwRnetSoil = lwRinSoil - lwRoutSoil;
            swRin = solarRadn;
            swRout = waterBalance_Salb * solarRadn;
            swRnetSoil = (swRin - swRout) * PenetrationConstant;
            return swRnetSoil + lwRnetSoil;
        }
        public static double interpolateTemperature(double timeHours, double defaultTimeOfMaximumTemperature, double weather_MeanT, double weather_MaxT, double maxTempYesterday, double minTempYesterday, double weather_MinT)
        {
            double time;
            double maxT_time;
            double minT_time;
            double midnightT;
            double tScale;
            double currentTemperature;
            time = timeHours / 24.0;
            maxT_time = defaultTimeOfMaximumTemperature / 24.0;
            minT_time = maxT_time - 0.5;
            if (time < minT_time)
            {
                midnightT = Math.Sin((0.0 + 0.25 - maxT_time) * 2.0 * Math.PI) * (maxTempYesterday - minTempYesterday) / 2.0 + ((maxTempYesterday + minTempYesterday) / 2.0);
                tScale = (minT_time - time) / minT_time;
                if (tScale > 1.0)
                {
                    tScale = 1.0;
                }
                else if ( tScale < (double)(0))
                {
                    tScale = (double)(0);
                }
                currentTemperature = weather_MinT + (tScale * (midnightT - weather_MinT));
                return currentTemperature;
            }
            else
            {
                currentTemperature = Math.Sin((time + 0.25 - maxT_time) * 2.0 * Math.PI) * (weather_MaxT - weather_MinT) / 2.0 + weather_MeanT;
                return currentTemperature;
            }
        }
        public static double[] doThermalConductivity(string[] soilConstituentNames, double[] soilWater, double[] thermalConductivity, int numNodes, double[] bulkDensity, double[] carbon, double pom, double[] rocks, double ps, double[] sand, double[] silt, double[] clay, double[] nodeDepth, int surfaceNode, double[] thickness, double MissingValue)
        {
            int node;
            string constituentName;
            double[] thermCondLayers =  new double [numNodes + 1];
            double numerator;
            double denominator;
            double shapeFactorConstituent;
            double thermalConductanceConstituent;
            double thermalConductanceWater;
            double k;
            for (node=1 ; node!=numNodes + 1 ; node+=1)
            {
                numerator = 0.0;
                denominator = 0.0;
                foreach(str constituentName_cyml in soilConstituentNames)
                {
                    constituentName = constituentName_cyml;
                    shapeFactorConstituent = shapeFactor(constituentName, node, soilWater, bulkDensity, carbon, pom, rocks, ps, sand, silt, clay);
                    thermalConductanceConstituent = ThermalConductance(constituentName, node, rocks, bulkDensity, ps, sand, carbon, pom, silt, clay);
                    thermalConductanceWater = ThermalConductance("Water", node, rocks, bulkDensity, ps, sand, carbon, pom, silt, clay);
                    k = 2.0 / 3.0 * Math.Pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0))), -1) + (1.0 / 3.0 * Math.Pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0) * (1 - (2 * shapeFactorConstituent)))), -1));
                    numerator = numerator + (thermalConductanceConstituent * soilWater[node] * k);
                    denominator = denominator + (soilWater[node] * k);
                }
                thermCondLayers[node] = numerator / denominator;
            }
            thermalConductivity = mapLayer2Node(thermCondLayers, thermalConductivity, numNodes, nodeDepth, surfaceNode, thickness, MissingValue);
            return thermalConductivity;
        }
        public static double[] doVolumetricSpecificHeat(string[] soilConstituentNames, double[] soilWater, double[] volSpecHeatSoil, int numNodes, double[] nodeDepth, int surfaceNode, double[] thickness, double MissingValue)
        {
            int node;
            string constituentName;
            double[] volspecHeatSoil_ =  new double [numNodes + 1];
            for (node=1 ; node!=numNodes + 1 ; node+=1)
            {
                volspecHeatSoil_[node] = (double)(0);
                foreach(str constituentName_cyml in soilConstituentNames)
                {
                    constituentName = constituentName_cyml;
                    if (!new List<string>{"Minerals"}.Contains(constituentName))
                    {
                        volspecHeatSoil_[node] = volspecHeatSoil_[node] + (volumetricSpecificHeat(constituentName, node) * 1000000.0 * soilWater[node]);
                    }
                }
            }
            volSpecHeatSoil = mapLayer2Node(volspecHeatSoil_, volSpecHeatSoil, numNodes, nodeDepth, surfaceNode, thickness, MissingValue);
            return volSpecHeatSoil;
        }
        public static double[] Zero(double[] arr)
        {
            int i;
            if (arr != null)
            {
                for (i=0 ; i!=arr.Length ; i+=1)
                {
                    arr[i] = (double)(0);
                }
            }
            return arr;
        }
        public static void  doNetRadiation(ref double[] solarRadn, ref double cloudFr, ref double cva, int ITERATIONSperDAY, int clock_Today_DayOfYear, double weather_Latitude, double weather_Radn, double weather_MinT)
        {
            int timestepNumber;
            double TSTEPS2RAD;
            double solarConstant;
            double solarDeclination;
            double cD;
            double[] m1 =  new double [ITERATIONSperDAY + 1];
            double m1Tot;
            double psr;
            double fr;
            TSTEPS2RAD = Divide(2.0 * Math.PI, (double)(ITERATIONSperDAY), 0);
            solarConstant = 1360.0;
            solarDeclination = 0.3985 * Math.Sin((4.869 + (clock_Today_DayOfYear * 2.0 * Math.PI / 365.25) + (0.03345 * Math.Sin((6.224 + (clock_Today_DayOfYear * 2.0 * Math.PI / 365.25))))));
            cD = Math.Sqrt(1.0 - (solarDeclination * solarDeclination));
            m1Tot = 0.0;
            for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
            {
                m1[timestepNumber] = (solarDeclination * Math.Sin(weather_Latitude * Math.PI / 180.0) + (cD * Math.Cos(weather_Latitude * Math.PI / 180.0) * Math.Cos(TSTEPS2RAD * (timestepNumber - (ITERATIONSperDAY / 2.0))))) * 24.0 / ITERATIONSperDAY;
                if (m1[timestepNumber] > 0.0)
                {
                    m1Tot = m1Tot + m1[timestepNumber];
                }
                else
                {
                    m1[timestepNumber] = 0.0;
                }
            }
            psr = m1Tot * solarConstant * 3600.0 / 1000000.0;
            fr = Divide(Math.Max(weather_Radn, 0.1), psr, 0);
            cloudFr = 2.33 - (3.33 * fr);
            cloudFr = Math.Min(Math.Max(cloudFr, 0.0), 1.0);
            for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
            {
                solarRadn[timestepNumber] = Math.Max(weather_Radn, 0.1) * Divide(m1[timestepNumber], m1Tot, 0);
            }
            cva = Math.Exp((31.3716 - (6014.79 / kelvinT(weather_MinT)) - (0.00792495 * kelvinT(weather_MinT)))) / kelvinT(weather_MinT);
        }
        public static void  doProcess(ref double[] maxSoilTemp, ref double[] minSoilTemp, double weather_MaxT, int numIterationsForBoundaryLayerConductance, ref double maxTempYesterday, ref double[] thermalConductivity, ref double timeOfDaySecs, ref double[] soilTemp, double weather_MeanT, ref double[] morningSoilTemp, ref double[] newTemperature, ref double boundaryLayerConductance, double constantBoundaryLayerConductance, ref double airTemperature, double timestep, double weather_MinT, double airNode, ref double netRadiation, ref double[] aveSoilTemp, ref double minTempYesterday, ref double internalTimeStep, string boundarLayerConductanceSource, int clock_Today_DayOfYear, double weather_Latitude, double weather_Radn, string[] soilConstituentNames, double[] soilWater, ref double[] volSpecHeatSoil, int numNodes, double[] nodeDepth, int surfaceNode, double[] thickness, double MissingValue, double[] bulkDensity, double[] carbon, double pom, double[] rocks, double ps, double[] sand, double[] silt, double[] clay, double defaultTimeOfMaximumTemperature, double waterBalance_Eo, double waterBalance_Eos, double waterBalance_Salb, double stefanBoltzmannConstant, double weather_AirPressure, double instrumentHeight, double weather_Wind, double canopyHeight, string netRadiationSource, ref double[] thermalConductance, double waterBalance_Es, ref double[] heatStorage, double latentHeatOfVapourisation, double nu)
        {
            int timeStepIteration;
            int iteration;
            int interactionsPerDay;
            double cva;
            double cloudFr;
            double[] solarRadn =  new double [49];
            interactionsPerDay = 48;
            cva = 0.0;
            cloudFr = 0.0;
            doNetRadiation(ref solarRadn, ref cloudFr, ref cva, interactionsPerDay, clock_Today_DayOfYear, weather_Latitude, weather_Radn, weather_MinT);
            minSoilTemp = Zero(minSoilTemp);
            maxSoilTemp = Zero(maxSoilTemp);
            aveSoilTemp = Zero(aveSoilTemp);
            boundaryLayerConductance = 0.0;
            internalTimeStep = Math.Round(timestep / interactionsPerDay);
            volSpecHeatSoil = doVolumetricSpecificHeat(soilConstituentNames, soilWater, volSpecHeatSoil, numNodes, nodeDepth, surfaceNode, thickness, MissingValue);
            thermalConductivity = doThermalConductivity(soilConstituentNames, soilWater, thermalConductivity, numNodes, bulkDensity, carbon, pom, rocks, ps, sand, silt, clay, nodeDepth, surfaceNode, thickness, MissingValue);
            for (timeStepIteration=1 ; timeStepIteration!=interactionsPerDay + 1 ; timeStepIteration+=1)
            {
                timeOfDaySecs = internalTimeStep * (double)(timeStepIteration);
                if (timestep < (24.0 * 60.0 * 60.0))
                {
                    airTemperature = weather_MeanT;
                }
                else
                {
                    airTemperature = interpolateTemperature(timeOfDaySecs / 3600.0, defaultTimeOfMaximumTemperature, weather_MeanT, weather_MaxT, maxTempYesterday, minTempYesterday, weather_MinT);
                }
                newTemperature[airNode] = airTemperature;
                netRadiation = interpolateNetRadiation(solarRadn[timeStepIteration], cloudFr, cva, soilTemp, airTemperature, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, surfaceNode, internalTimeStep, stefanBoltzmannConstant);
                if (boundarLayerConductanceSource == "constant")
                {
                    thermalConductivity[airNode] = constantBoundaryLayerConductance;
                }
                else if ( boundarLayerConductanceSource == "calc")
                {
                    thermalConductivity[airNode] = getBoundaryLayerConductance(ref newTemperature, stefanBoltzmannConstant, airTemperature, waterBalance_Eos, weather_AirPressure, instrumentHeight, waterBalance_Eo, weather_Wind, canopyHeight, surfaceNode);
                    for (iteration=1 ; iteration!=numIterationsForBoundaryLayerConductance + 1 ; iteration+=1)
                    {
                        doThomas(ref newTemperature, netRadiationSource, ref thermalConductance, waterBalance_Eos, waterBalance_Es, thermalConductivity, soilTemp, numNodes, internalTimeStep, ref heatStorage, latentHeatOfVapourisation, nodeDepth, nu, volSpecHeatSoil, airNode, netRadiation, surfaceNode, timestep);
                        thermalConductivity[airNode] = getBoundaryLayerConductance(ref newTemperature, stefanBoltzmannConstant, airTemperature, waterBalance_Eos, weather_AirPressure, instrumentHeight, waterBalance_Eo, weather_Wind, canopyHeight, surfaceNode);
                    }
                }
                doThomas(ref newTemperature, netRadiationSource, ref thermalConductance, waterBalance_Eos, waterBalance_Es, thermalConductivity, soilTemp, numNodes, internalTimeStep, ref heatStorage, latentHeatOfVapourisation, nodeDepth, nu, volSpecHeatSoil, airNode, netRadiation, surfaceNode, timestep);
                doUpdate(interactionsPerDay, ref maxSoilTemp, ref minSoilTemp, thermalConductivity, ref soilTemp, timeOfDaySecs, numNodes, ref boundaryLayerConductance, ref aveSoilTemp, airNode, newTemperature, surfaceNode, internalTimeStep);
                if (Math.Abs(timeOfDaySecs - (5.0 * 3600.0)) <= (Math.Min(timeOfDaySecs, 5.0 * 3600.0) * 0.0001))
                {
                    morningSoilTemp.ToList().GetRange(0,0 + soilTemp.Length - 0) = soilTemp;
                }
            }
            minTempYesterday = weather_MinT;
            maxTempYesterday = weather_MaxT;
        }
        public static double[] ToCumThickness(double[] Thickness)
        {
            int Layer;
            double[] CumThickness =  new double [Thickness.Length];
            if (Thickness.Length > 0)
            {
                CumThickness[0] = Thickness[0];
                for (Layer=1 ; Layer!=Thickness.Length ; Layer+=1)
                {
                    CumThickness[Layer] = Thickness[Layer] + CumThickness[Layer - 1];
                }
            }
            return CumThickness;
        }
        public static double[] calcSoilTemperature(double[] soilTempIO, double weather_Latitude, double weather_Amp, int numNodes, int clock_Today_DayOfYear, double weather_Tav, int surfaceNode, double[] thickness)
        {
            int nodes;
            double[] cumulativeDepth ;
            double w;
            double dh;
            double zd;
            double offset;
            double[] soilTemp =  new double [numNodes + 1 + 1];
            cumulativeDepth = ToCumThickness(thickness);
            w = 2 * Math.PI / (365.25 * 24 * 3600);
            dh = 0.6;
            zd = Math.Sqrt(2 * dh / w);
            offset = 0.25;
            if (weather_Latitude > 0.0)
            {
                offset = -0.25;
            }
            for (nodes=1 ; nodes!=numNodes + 1 ; nodes+=1)
            {
                soilTemp[nodes] = weather_Tav + (weather_Amp * Math.Exp(-1 * cumulativeDepth[nodes] / zd) * Math.Sin(((clock_Today_DayOfYear / 365.0 + offset) * 2.0 * Math.PI - (cumulativeDepth[nodes] / zd))));
            }
            soilTempIO.ToList().GetRange(surfaceNode,surfaceNode + numNodes - surfaceNode) = soilTemp.ToList().GetRange(0,0 + numNodes - 0);
            return soilTempIO;
        }
        public static double calcSurfaceTemperature(double waterBalance_Salb, double weather_MeanT, double weather_Radn, double weather_MaxT)
        {
            double surfaceT;
            surfaceT = (1.0 - waterBalance_Salb) * (weather_MeanT + ((weather_MaxT - weather_MeanT) * Math.Sqrt(Math.Max(weather_Radn, 0.1) * 23.8846 / 800.0))) + (waterBalance_Salb * weather_MeanT);
            return surfaceT;
        }
        public static bool ValuesInArray(double[] Values, double MissingValue)
        {
            double Value;
            if (Values != null)
            {
                foreach(float Value_cyml in Values)
                {
                    Value = Value_cyml;
                    if (Value != MissingValue && !double.IsNaN(Value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}