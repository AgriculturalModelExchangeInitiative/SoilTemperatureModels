
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
            v1.Description = "Latitude";
            v1.Id = 0;
            v1.MaxValue = -1D;
            v1.MinValue = -1D;
            v1.Name = "weather_Latitude";
            v1.Size = 1;
            v1.Units = "deg";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = -1D;
            v2.Description = "Soil layer thickness";
            v2.Id = 0;
            v2.MaxValue = -1D;
            v2.MinValue = -1D;
            v2.Name = "physical_Thickness";
            v2.Size = 1;
            v2.Units = "mm";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v2);
            VarInfo v3 = new VarInfo();
            v3.DefaultValue = -1D;
            v3.Description = "Bulk density";
            v3.Id = 0;
            v3.MaxValue = -1D;
            v3.MinValue = -1D;
            v3.Name = "physical_BD";
            v3.Size = 1;
            v3.Units = "g/cc";
            v3.URL = "";
            v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v3.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v3);
            VarInfo v4 = new VarInfo();
            v4.DefaultValue = -1D;
            v4.Description = "ps";
            v4.Id = 0;
            v4.MaxValue = -1D;
            v4.MinValue = -1D;
            v4.Name = "ps";
            v4.Size = 1;
            v4.Units = "";
            v4.URL = "";
            v4.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v4.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v4);
            VarInfo v5 = new VarInfo();
            v5.DefaultValue = -1D;
            v5.Description = "Initial soil temperature";
            v5.Id = 0;
            v5.MaxValue = -1D;
            v5.MinValue = -1D;
            v5.Name = "pInitialValues";
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
            v7.DefaultValue = 24.0 * 60.0 * 60.0;
            v7.Description = "Internal time-step (minutes)";
            v7.Id = 0;
            v7.MaxValue = -1D;
            v7.MinValue = -1D;
            v7.Name = "timestep";
            v7.Size = 1;
            v7.Units = "minutes";
            v7.URL = "";
            v7.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v7.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v7);
            VarInfo v8 = new VarInfo();
            v8.DefaultValue = 2465000;
            v8.Description = "Latent heat of vapourisation for water";
            v8.Id = 0;
            v8.MaxValue = -1D;
            v8.MinValue = -1D;
            v8.Name = "latentHeatOfVapourisation";
            v8.Size = 1;
            v8.Units = "miJ/kg";
            v8.URL = "";
            v8.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v8.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v8);
            VarInfo v9 = new VarInfo();
            v9.DefaultValue = 0.0000000567;
            v9.Description = "The Stefan-Boltzmann constant";
            v9.Id = 0;
            v9.MaxValue = -1D;
            v9.MinValue = -1D;
            v9.Name = "stefanBoltzmannConstant";
            v9.Size = 1;
            v9.Units = "W/m2/K4";
            v9.URL = "";
            v9.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v9.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v9);
            VarInfo v10 = new VarInfo();
            v10.DefaultValue = 0;
            v10.Description = "The index of the node in the atmosphere (aboveground)";
            v10.Id = 0;
            v10.MaxValue = -1D;
            v10.MinValue = -1D;
            v10.Name = "airNode";
            v10.Size = 1;
            v10.Units = "";
            v10.URL = "";
            v10.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v10.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v10);
            VarInfo v11 = new VarInfo();
            v11.DefaultValue = 1;
            v11.Description = "The index of the node on the soil surface (depth = 0)";
            v11.Id = 0;
            v11.MaxValue = -1D;
            v11.MinValue = -1D;
            v11.Name = "surfaceNode";
            v11.Size = 1;
            v11.Units = "";
            v11.URL = "";
            v11.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v11.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v11);
            VarInfo v12 = new VarInfo();
            v12.DefaultValue = 2;
            v12.Description = "The index of the first node within the soil (top layer)";
            v12.Id = 0;
            v12.MaxValue = -1D;
            v12.MinValue = -1D;
            v12.Name = "topsoilNode";
            v12.Size = 1;
            v12.Units = "";
            v12.URL = "";
            v12.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v12.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v12);
            VarInfo v13 = new VarInfo();
            v13.DefaultValue = 5;
            v13.Description = "The number of phantom nodes below the soil profile";
            v13.Id = 0;
            v13.MaxValue = -1D;
            v13.MinValue = -1D;
            v13.Name = "numPhantomNodes";
            v13.Size = 1;
            v13.Units = "";
            v13.URL = "";
            v13.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v13.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v13);
            VarInfo v14 = new VarInfo();
            v14.DefaultValue = 20;
            v14.Description = "Boundary layer conductance, if constant";
            v14.Id = 0;
            v14.MaxValue = -1D;
            v14.MinValue = -1D;
            v14.Name = "constantBoundaryLayerConductance";
            v14.Size = 1;
            v14.Units = "K/W";
            v14.URL = "";
            v14.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v14.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v14);
            VarInfo v15 = new VarInfo();
            v15.DefaultValue = 1;
            v15.Description = "Number of iterations to calculate atmosphere boundary layer conductance";
            v15.Id = 0;
            v15.MaxValue = -1D;
            v15.MinValue = -1D;
            v15.Name = "numIterationsForBoundaryLayerConductance";
            v15.Size = 1;
            v15.Units = "";
            v15.URL = "";
            v15.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v15.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v15);
            VarInfo v16 = new VarInfo();
            v16.DefaultValue = 14.0;
            v16.Description = "Time of maximum temperature";
            v16.Id = 0;
            v16.MaxValue = -1D;
            v16.MinValue = -1D;
            v16.Name = "defaultTimeOfMaximumTemperature";
            v16.Size = 1;
            v16.Units = "minutes";
            v16.URL = "";
            v16.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v16.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v16);
            VarInfo v17 = new VarInfo();
            v17.DefaultValue = 1.2;
            v17.Description = "Default instrument height";
            v17.Id = 0;
            v17.MaxValue = -1D;
            v17.MinValue = -1D;
            v17.Name = "defaultInstrumentHeight";
            v17.Size = 1;
            v17.Units = "m";
            v17.URL = "";
            v17.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v17.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v17);
            VarInfo v18 = new VarInfo();
            v18.DefaultValue = 57;
            v18.Description = "Roughness element height of bare soil";
            v18.Id = 0;
            v18.MaxValue = -1D;
            v18.MinValue = -1D;
            v18.Name = "bareSoilRoughness";
            v18.Size = 1;
            v18.Units = "mm";
            v18.URL = "";
            v18.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v18.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v18);
            VarInfo v19 = new VarInfo();
            v19.DefaultValue = -1D;
            v19.Description = "Depths of nodes";
            v19.Id = 0;
            v19.MaxValue = -1D;
            v19.MinValue = -1D;
            v19.Name = "nodeDepth";
            v19.Size = 1;
            v19.Units = "mm";
            v19.URL = "";
            v19.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v19.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v19);
            VarInfo v20 = new VarInfo();
            v20.DefaultValue = -1D;
            v20.Description = "Parameter 1 for computing thermal conductivity of soil solids";
            v20.Id = 0;
            v20.MaxValue = -1D;
            v20.MinValue = -1D;
            v20.Name = "thermCondPar1";
            v20.Size = 1;
            v20.Units = "";
            v20.URL = "";
            v20.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v20.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v20);
            VarInfo v21 = new VarInfo();
            v21.DefaultValue = -1D;
            v21.Description = "Parameter 2 for computing thermal conductivity of soil solids";
            v21.Id = 0;
            v21.MaxValue = -1D;
            v21.MinValue = -1D;
            v21.Name = "thermCondPar2";
            v21.Size = 1;
            v21.Units = "";
            v21.URL = "";
            v21.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v21.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v21);
            VarInfo v22 = new VarInfo();
            v22.DefaultValue = -1D;
            v22.Description = "Parameter 3 for computing thermal conductivity of soil solids";
            v22.Id = 0;
            v22.MaxValue = -1D;
            v22.MinValue = -1D;
            v22.Name = "thermCondPar3";
            v22.Size = 1;
            v22.Units = "";
            v22.URL = "";
            v22.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v22.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v22);
            VarInfo v23 = new VarInfo();
            v23.DefaultValue = -1D;
            v23.Description = "Parameter 4 for computing thermal conductivity of soil solids";
            v23.Id = 0;
            v23.MaxValue = -1D;
            v23.MinValue = -1D;
            v23.Name = "thermCondPar4";
            v23.Size = 1;
            v23.Units = "";
            v23.URL = "";
            v23.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v23.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v23);
            VarInfo v24 = new VarInfo();
            v24.DefaultValue = -1D;
            v24.Description = "Particle density of organic matter";
            v24.Id = 0;
            v24.MaxValue = -1D;
            v24.MinValue = -1D;
            v24.Name = "pom";
            v24.Size = 1;
            v24.Units = "Mg/m3";
            v24.URL = "";
            v24.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v24.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v24);
            VarInfo v25 = new VarInfo();
            v25.DefaultValue = 0;
            v25.Description = "Height of soil roughness";
            v25.Id = 0;
            v25.MaxValue = -1D;
            v25.MinValue = -1D;
            v25.Name = "soilRoughnessHeight";
            v25.Size = 1;
            v25.Units = "mm";
            v25.URL = "";
            v25.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v25.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v25);
            VarInfo v26 = new VarInfo();
            v26.DefaultValue = 0.6;
            v26.Description = "Forward/backward differencing coefficient";
            v26.Id = 0;
            v26.MaxValue = -1D;
            v26.MinValue = -1D;
            v26.Name = "nu";
            v26.Size = 1;
            v26.Units = "0-1";
            v26.URL = "";
            v26.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v26.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v26);
            VarInfo v27 = new VarInfo();
            v27.DefaultValue = -1D;
            v27.Description = "Flag whether boundary layer conductance is calculated or gotten from inpu";
            v27.Id = 0;
            v27.MaxValue = -1D;
            v27.MinValue = -1D;
            v27.Name = "boundarLayerConductanceSource";
            v27.Size = 1;
            v27.Units = "";
            v27.URL = "";
            v27.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v27.ValueType = VarInfoValueTypes.GetInstanceForName("String");
            _parameters0_0.Add(v27);
            VarInfo v28 = new VarInfo();
            v28.DefaultValue = -1D;
            v28.Description = "Flag whether net radiation is calculated or gotten from input";
            v28.Id = 0;
            v28.MaxValue = -1D;
            v28.MinValue = -1D;
            v28.Name = "netRadiationSource";
            v28.Size = 1;
            v28.Units = "m";
            v28.URL = "";
            v28.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v28.ValueType = VarInfoValueTypes.GetInstanceForName("String");
            _parameters0_0.Add(v28);
            VarInfo v29 = new VarInfo();
            v29.DefaultValue = 99999;
            v29.Description = "missing value";
            v29.Id = 0;
            v29.MaxValue = -1D;
            v29.MinValue = -1D;
            v29.Name = "MissingValue";
            v29.Size = 1;
            v29.Units = "m";
            v29.URL = "";
            v29.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v29.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v29);
            VarInfo v30 = new VarInfo();
            v30.DefaultValue = -1D;
            v30.Description = "soilConstituentNames";
            v30.Id = 0;
            v30.MaxValue = -1D;
            v30.MinValue = -1D;
            v30.Name = "soilConstituentNames";
            v30.Size = 1;
            v30.Units = "m";
            v30.URL = "";
            v30.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v30.ValueType = VarInfoValueTypes.GetInstanceForName("StringInteger");
            _parameters0_0.Add(v30);
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
            pd8.PropertyName = "weather_Radn";
            pd8.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd9.PropertyName = "clock_Today_DayOfYear";
            pd9.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd10.PropertyName = "microClimate_CanopyHeight";
            pd10.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight);
            _inputs0_0.Add(pd10);
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd11.PropertyName = "physical_Rocks";
            pd11.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks);
            _inputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd12.PropertyName = "physical_ParticleSizeSand";
            pd12.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand);
            _inputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd13.PropertyName = "physical_ParticleSizeSilt";
            pd13.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt);
            _inputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd14.PropertyName = "physical_ParticleSizeClay";
            pd14.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay);
            _inputs0_0.Add(pd14);
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd15.PropertyName = "organic_Carbon";
            pd15.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon);
            _inputs0_0.Add(pd15);
            PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd16.PropertyName = "waterBalance_SW";
            pd16.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW);
            _inputs0_0.Add(pd16);
            PropertyDescription pd17 = new PropertyDescription();
            pd17.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd17.PropertyName = "waterBalance_Eos";
            pd17.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos).ValueType.TypeForCurrentValue;
            pd17.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos);
            _inputs0_0.Add(pd17);
            PropertyDescription pd18 = new PropertyDescription();
            pd18.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd18.PropertyName = "waterBalance_Eo";
            pd18.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo).ValueType.TypeForCurrentValue;
            pd18.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo);
            _inputs0_0.Add(pd18);
            PropertyDescription pd19 = new PropertyDescription();
            pd19.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd19.PropertyName = "waterBalance_Es";
            pd19.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es).ValueType.TypeForCurrentValue;
            pd19.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es);
            _inputs0_0.Add(pd19);
            PropertyDescription pd20 = new PropertyDescription();
            pd20.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd20.PropertyName = "waterBalance_Salb";
            pd20.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb).ValueType.TypeForCurrentValue;
            pd20.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb);
            _inputs0_0.Add(pd20);
            PropertyDescription pd21 = new PropertyDescription();
            pd21.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd21.PropertyName = "InitialValues";
            pd21.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues).ValueType.TypeForCurrentValue;
            pd21.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues);
            _inputs0_0.Add(pd21);
            PropertyDescription pd22 = new PropertyDescription();
            pd22.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd22.PropertyName = "doInitialisationStuff";
            pd22.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff).ValueType.TypeForCurrentValue;
            pd22.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff);
            _inputs0_0.Add(pd22);
            PropertyDescription pd23 = new PropertyDescription();
            pd23.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd23.PropertyName = "internalTimeStep";
            pd23.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep).ValueType.TypeForCurrentValue;
            pd23.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep);
            _inputs0_0.Add(pd23);
            PropertyDescription pd24 = new PropertyDescription();
            pd24.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd24.PropertyName = "timeOfDaySecs";
            pd24.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs).ValueType.TypeForCurrentValue;
            pd24.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs);
            _inputs0_0.Add(pd24);
            PropertyDescription pd25 = new PropertyDescription();
            pd25.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd25.PropertyName = "numNodes";
            pd25.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.numNodes).ValueType.TypeForCurrentValue;
            pd25.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.numNodes);
            _inputs0_0.Add(pd25);
            PropertyDescription pd26 = new PropertyDescription();
            pd26.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd26.PropertyName = "numLayers";
            pd26.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.numLayers).ValueType.TypeForCurrentValue;
            pd26.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.numLayers);
            _inputs0_0.Add(pd26);
            PropertyDescription pd27 = new PropertyDescription();
            pd27.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd27.PropertyName = "volSpecHeatSoil";
            pd27.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil).ValueType.TypeForCurrentValue;
            pd27.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil);
            _inputs0_0.Add(pd27);
            PropertyDescription pd28 = new PropertyDescription();
            pd28.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd28.PropertyName = "soilTemp";
            pd28.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp).ValueType.TypeForCurrentValue;
            pd28.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp);
            _inputs0_0.Add(pd28);
            PropertyDescription pd29 = new PropertyDescription();
            pd29.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd29.PropertyName = "morningSoilTemp";
            pd29.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp).ValueType.TypeForCurrentValue;
            pd29.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp);
            _inputs0_0.Add(pd29);
            PropertyDescription pd30 = new PropertyDescription();
            pd30.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd30.PropertyName = "heatStorage";
            pd30.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage).ValueType.TypeForCurrentValue;
            pd30.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage);
            _inputs0_0.Add(pd30);
            PropertyDescription pd31 = new PropertyDescription();
            pd31.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd31.PropertyName = "thermalConductance";
            pd31.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance).ValueType.TypeForCurrentValue;
            pd31.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance);
            _inputs0_0.Add(pd31);
            PropertyDescription pd32 = new PropertyDescription();
            pd32.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd32.PropertyName = "thermalConductivity";
            pd32.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity).ValueType.TypeForCurrentValue;
            pd32.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity);
            _inputs0_0.Add(pd32);
            PropertyDescription pd33 = new PropertyDescription();
            pd33.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd33.PropertyName = "boundaryLayerConductance";
            pd33.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance).ValueType.TypeForCurrentValue;
            pd33.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance);
            _inputs0_0.Add(pd33);
            PropertyDescription pd34 = new PropertyDescription();
            pd34.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd34.PropertyName = "newTemperature";
            pd34.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature).ValueType.TypeForCurrentValue;
            pd34.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature);
            _inputs0_0.Add(pd34);
            PropertyDescription pd35 = new PropertyDescription();
            pd35.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd35.PropertyName = "airTemperature";
            pd35.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature).ValueType.TypeForCurrentValue;
            pd35.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature);
            _inputs0_0.Add(pd35);
            PropertyDescription pd36 = new PropertyDescription();
            pd36.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd36.PropertyName = "maxTempYesterday";
            pd36.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday).ValueType.TypeForCurrentValue;
            pd36.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday);
            _inputs0_0.Add(pd36);
            PropertyDescription pd37 = new PropertyDescription();
            pd37.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd37.PropertyName = "minTempYesterday";
            pd37.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday).ValueType.TypeForCurrentValue;
            pd37.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday);
            _inputs0_0.Add(pd37);
            PropertyDescription pd38 = new PropertyDescription();
            pd38.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd38.PropertyName = "soilWater";
            pd38.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater).ValueType.TypeForCurrentValue;
            pd38.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater);
            _inputs0_0.Add(pd38);
            PropertyDescription pd39 = new PropertyDescription();
            pd39.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd39.PropertyName = "minSoilTemp";
            pd39.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp).ValueType.TypeForCurrentValue;
            pd39.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp);
            _inputs0_0.Add(pd39);
            PropertyDescription pd40 = new PropertyDescription();
            pd40.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd40.PropertyName = "maxSoilTemp";
            pd40.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp).ValueType.TypeForCurrentValue;
            pd40.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp);
            _inputs0_0.Add(pd40);
            PropertyDescription pd41 = new PropertyDescription();
            pd41.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd41.PropertyName = "aveSoilTemp";
            pd41.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp).ValueType.TypeForCurrentValue;
            pd41.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp);
            _inputs0_0.Add(pd41);
            PropertyDescription pd42 = new PropertyDescription();
            pd42.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd42.PropertyName = "aveSoilWater";
            pd42.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater).ValueType.TypeForCurrentValue;
            pd42.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater);
            _inputs0_0.Add(pd42);
            PropertyDescription pd43 = new PropertyDescription();
            pd43.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd43.PropertyName = "thickness";
            pd43.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.thickness).ValueType.TypeForCurrentValue;
            pd43.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.thickness);
            _inputs0_0.Add(pd43);
            PropertyDescription pd44 = new PropertyDescription();
            pd44.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd44.PropertyName = "bulkDensity";
            pd44.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity).ValueType.TypeForCurrentValue;
            pd44.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity);
            _inputs0_0.Add(pd44);
            PropertyDescription pd45 = new PropertyDescription();
            pd45.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd45.PropertyName = "rocks";
            pd45.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.rocks).ValueType.TypeForCurrentValue;
            pd45.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.rocks);
            _inputs0_0.Add(pd45);
            PropertyDescription pd46 = new PropertyDescription();
            pd46.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd46.PropertyName = "carbon";
            pd46.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.carbon).ValueType.TypeForCurrentValue;
            pd46.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.carbon);
            _inputs0_0.Add(pd46);
            PropertyDescription pd47 = new PropertyDescription();
            pd47.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd47.PropertyName = "sand";
            pd47.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.sand).ValueType.TypeForCurrentValue;
            pd47.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.sand);
            _inputs0_0.Add(pd47);
            PropertyDescription pd48 = new PropertyDescription();
            pd48.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd48.PropertyName = "silt";
            pd48.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.silt).ValueType.TypeForCurrentValue;
            pd48.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.silt);
            _inputs0_0.Add(pd48);
            PropertyDescription pd49 = new PropertyDescription();
            pd49.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd49.PropertyName = "clay";
            pd49.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.clay).ValueType.TypeForCurrentValue;
            pd49.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.clay);
            _inputs0_0.Add(pd49);
            PropertyDescription pd50 = new PropertyDescription();
            pd50.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd50.PropertyName = "instrumentHeight";
            pd50.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight).ValueType.TypeForCurrentValue;
            pd50.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight);
            _inputs0_0.Add(pd50);
            PropertyDescription pd51 = new PropertyDescription();
            pd51.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd51.PropertyName = "netRadiation";
            pd51.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation).ValueType.TypeForCurrentValue;
            pd51.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation);
            _inputs0_0.Add(pd51);
            PropertyDescription pd52 = new PropertyDescription();
            pd52.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd52.PropertyName = "canopyHeight";
            pd52.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight).ValueType.TypeForCurrentValue;
            pd52.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight);
            _inputs0_0.Add(pd52);
            PropertyDescription pd53 = new PropertyDescription();
            pd53.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd53.PropertyName = "instrumHeight";
            pd53.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight).ValueType.TypeForCurrentValue;
            pd53.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight);
            _inputs0_0.Add(pd53);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd54 = new PropertyDescription();
            pd54.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd54.PropertyName = "heatStorage";
            pd54.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage).ValueType.TypeForCurrentValue;
            pd54.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage);
            _outputs0_0.Add(pd54);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd55 = new PropertyDescription();
            pd55.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd55.PropertyName = "instrumentHeight";
            pd55.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight).ValueType.TypeForCurrentValue;
            pd55.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight);
            _outputs0_0.Add(pd55);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd56 = new PropertyDescription();
            pd56.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd56.PropertyName = "canopyHeight";
            pd56.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight).ValueType.TypeForCurrentValue;
            pd56.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight);
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
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd71 = new PropertyDescription();
            pd71.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd71.PropertyName = "airTemperature";
            pd71.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature).ValueType.TypeForCurrentValue;
            pd71.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature);
            _outputs0_0.Add(pd71);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd72 = new PropertyDescription();
            pd72.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd72.PropertyName = "internalTimeStep";
            pd72.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep).ValueType.TypeForCurrentValue;
            pd72.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep);
            _outputs0_0.Add(pd72);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd73 = new PropertyDescription();
            pd73.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd73.PropertyName = "timeOfDaySecs";
            pd73.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs).ValueType.TypeForCurrentValue;
            pd73.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs);
            _outputs0_0.Add(pd73);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd74 = new PropertyDescription();
            pd74.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd74.PropertyName = "netRadiation";
            pd74.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation).ValueType.TypeForCurrentValue;
            pd74.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation);
            _outputs0_0.Add(pd74);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd75 = new PropertyDescription();
            pd75.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd75.PropertyName = "InitialValues";
            pd75.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues).ValueType.TypeForCurrentValue;
            pd75.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues);
            _outputs0_0.Add(pd75);
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

        public double weather_Latitude
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("weather_Latitude");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'weather_Latitude' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("weather_Latitude");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'weather_Latitude' not found in strategy 'SoilTemperature'");
            }
        }
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
        public double[] pInitialValues
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("pInitialValues");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'pInitialValues' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("pInitialValues");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'pInitialValues' not found in strategy 'SoilTemperature'");
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
        public double timestep
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("timestep");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'timestep' not found (or found null) in strategy 'SoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("timestep");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'timestep' not found in strategy 'SoilTemperature'");
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
        public int airNode
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("airNode");
                if (vi != null && vi.CurrentValue!=null) return (int)vi.CurrentValue ;
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

            weather_LatitudeVarInfo.Name = "weather_Latitude";
            weather_LatitudeVarInfo.Description = "Latitude";
            weather_LatitudeVarInfo.MaxValue = -1D;
            weather_LatitudeVarInfo.MinValue = -1D;
            weather_LatitudeVarInfo.DefaultValue = -1D;
            weather_LatitudeVarInfo.Units = "deg";
            weather_LatitudeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

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

            pInitialValuesVarInfo.Name = "pInitialValues";
            pInitialValuesVarInfo.Description = "Initial soil temperature";
            pInitialValuesVarInfo.MaxValue = -1D;
            pInitialValuesVarInfo.MinValue = -1D;
            pInitialValuesVarInfo.DefaultValue = -1D;
            pInitialValuesVarInfo.Units = "oC";
            pInitialValuesVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            DepthToConstantTemperatureVarInfo.Name = "DepthToConstantTemperature";
            DepthToConstantTemperatureVarInfo.Description = "Soil depth to constant temperature";
            DepthToConstantTemperatureVarInfo.MaxValue = -1D;
            DepthToConstantTemperatureVarInfo.MinValue = -1D;
            DepthToConstantTemperatureVarInfo.DefaultValue = 10000;
            DepthToConstantTemperatureVarInfo.Units = "mm";
            DepthToConstantTemperatureVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            timestepVarInfo.Name = "timestep";
            timestepVarInfo.Description = "Internal time-step (minutes)";
            timestepVarInfo.MaxValue = -1D;
            timestepVarInfo.MinValue = -1D;
            timestepVarInfo.DefaultValue = 24.0 * 60.0 * 60.0;
            timestepVarInfo.Units = "minutes";
            timestepVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

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
            airNodeVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

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

        private static VarInfo _weather_LatitudeVarInfo = new VarInfo();
        public static VarInfo weather_LatitudeVarInfo
        {
            get { return _weather_LatitudeVarInfo;} 
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

        private static VarInfo _pInitialValuesVarInfo = new VarInfo();
        public static VarInfo pInitialValuesVarInfo
        {
            get { return _pInitialValuesVarInfo;} 
        }

        private static VarInfo _DepthToConstantTemperatureVarInfo = new VarInfo();
        public static VarInfo DepthToConstantTemperatureVarInfo
        {
            get { return _DepthToConstantTemperatureVarInfo;} 
        }

        private static VarInfo _timestepVarInfo = new VarInfo();
        public static VarInfo timestepVarInfo
        {
            get { return _timestepVarInfo;} 
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
                Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues.CurrentValue=s.InitialValues;
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
                RangeBasedCondition r8 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn);
                if(r8.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.weather_Radn.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear);
                if(r9.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.clock_Today_DayOfYear.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight);
                if(r10.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.microClimate_CanopyHeight.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks);
                if(r11.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_Rocks.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand);
                if(r12.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSand.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt);
                if(r13.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeSilt.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay);
                if(r14.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.physical_ParticleSizeClay.ValueType)){prc.AddCondition(r14);}
                RangeBasedCondition r15 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon);
                if(r15.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.organic_Carbon.ValueType)){prc.AddCondition(r15);}
                RangeBasedCondition r16 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW);
                if(r16.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_SW.ValueType)){prc.AddCondition(r16);}
                RangeBasedCondition r17 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos);
                if(r17.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eos.ValueType)){prc.AddCondition(r17);}
                RangeBasedCondition r18 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo);
                if(r18.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Eo.ValueType)){prc.AddCondition(r18);}
                RangeBasedCondition r19 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es);
                if(r19.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Es.ValueType)){prc.AddCondition(r19);}
                RangeBasedCondition r20 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb);
                if(r20.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.waterBalance_Salb.ValueType)){prc.AddCondition(r20);}
                RangeBasedCondition r21 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues);
                if(r21.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.InitialValues.ValueType)){prc.AddCondition(r21);}
                RangeBasedCondition r22 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff);
                if(r22.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.doInitialisationStuff.ValueType)){prc.AddCondition(r22);}
                RangeBasedCondition r23 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep);
                if(r23.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.internalTimeStep.ValueType)){prc.AddCondition(r23);}
                RangeBasedCondition r24 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs);
                if(r24.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.timeOfDaySecs.ValueType)){prc.AddCondition(r24);}
                RangeBasedCondition r25 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.numNodes);
                if(r25.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.numNodes.ValueType)){prc.AddCondition(r25);}
                RangeBasedCondition r26 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.numLayers);
                if(r26.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.numLayers.ValueType)){prc.AddCondition(r26);}
                RangeBasedCondition r27 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil);
                if(r27.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.volSpecHeatSoil.ValueType)){prc.AddCondition(r27);}
                RangeBasedCondition r28 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp);
                if(r28.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.soilTemp.ValueType)){prc.AddCondition(r28);}
                RangeBasedCondition r29 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp);
                if(r29.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.morningSoilTemp.ValueType)){prc.AddCondition(r29);}
                RangeBasedCondition r30 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage);
                if(r30.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.heatStorage.ValueType)){prc.AddCondition(r30);}
                RangeBasedCondition r31 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance);
                if(r31.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductance.ValueType)){prc.AddCondition(r31);}
                RangeBasedCondition r32 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity);
                if(r32.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.thermalConductivity.ValueType)){prc.AddCondition(r32);}
                RangeBasedCondition r33 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance);
                if(r33.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.boundaryLayerConductance.ValueType)){prc.AddCondition(r33);}
                RangeBasedCondition r34 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature);
                if(r34.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.newTemperature.ValueType)){prc.AddCondition(r34);}
                RangeBasedCondition r35 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature);
                if(r35.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.airTemperature.ValueType)){prc.AddCondition(r35);}
                RangeBasedCondition r36 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday);
                if(r36.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.maxTempYesterday.ValueType)){prc.AddCondition(r36);}
                RangeBasedCondition r37 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday);
                if(r37.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.minTempYesterday.ValueType)){prc.AddCondition(r37);}
                RangeBasedCondition r38 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater);
                if(r38.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.soilWater.ValueType)){prc.AddCondition(r38);}
                RangeBasedCondition r39 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp);
                if(r39.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.minSoilTemp.ValueType)){prc.AddCondition(r39);}
                RangeBasedCondition r40 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp);
                if(r40.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.maxSoilTemp.ValueType)){prc.AddCondition(r40);}
                RangeBasedCondition r41 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp);
                if(r41.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilTemp.ValueType)){prc.AddCondition(r41);}
                RangeBasedCondition r42 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater);
                if(r42.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.aveSoilWater.ValueType)){prc.AddCondition(r42);}
                RangeBasedCondition r43 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.thickness);
                if(r43.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.thickness.ValueType)){prc.AddCondition(r43);}
                RangeBasedCondition r44 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity);
                if(r44.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.bulkDensity.ValueType)){prc.AddCondition(r44);}
                RangeBasedCondition r45 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.rocks);
                if(r45.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.rocks.ValueType)){prc.AddCondition(r45);}
                RangeBasedCondition r46 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.carbon);
                if(r46.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.carbon.ValueType)){prc.AddCondition(r46);}
                RangeBasedCondition r47 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.sand);
                if(r47.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.sand.ValueType)){prc.AddCondition(r47);}
                RangeBasedCondition r48 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.silt);
                if(r48.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.silt.ValueType)){prc.AddCondition(r48);}
                RangeBasedCondition r49 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.clay);
                if(r49.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.clay.ValueType)){prc.AddCondition(r49);}
                RangeBasedCondition r50 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight);
                if(r50.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.instrumentHeight.ValueType)){prc.AddCondition(r50);}
                RangeBasedCondition r51 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation);
                if(r51.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.netRadiation.ValueType)){prc.AddCondition(r51);}
                RangeBasedCondition r52 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight);
                if(r52.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.canopyHeight.ValueType)){prc.AddCondition(r52);}
                RangeBasedCondition r53 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight);
                if(r53.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.instrumHeight.ValueType)){prc.AddCondition(r53);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("weather_Latitude")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("physical_Thickness")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("physical_BD")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("ps")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("pInitialValues")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DepthToConstantTemperature")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("timestep")));
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
            double[] nodeDepth_loc = nodeDepth;
            double[] thermCondPar1_loc = thermCondPar1;
            double[] thermCondPar2_loc = thermCondPar2;
            double[] thermCondPar3_loc = thermCondPar3;
            double[] thermCondPar4_loc = thermCondPar4;
            double soilRoughnessHeight_loc = soilRoughnessHeight;
            double[] InitialValues = null ;
            bool doInitialisationStuff = false;
            double internalTimeStep = 0.0;
            double timeOfDaySecs = 0.0;
            int numNodes = 0;
            int numLayers = 0;
            double[] volSpecHeatSoil = null ;
            double[] soilTemp = null ;
            double[] morningSoilTemp = null ;
            double[] heatStorage = null ;
            double[] thermalConductance = null ;
            double[] thermalConductivity = null ;
            double boundaryLayerConductance = 0.0;
            double[] newTemperature = null ;
            double airTemperature = 0.0;
            double maxTempYesterday = 0.0;
            double minTempYesterday = 0.0;
            double[] soilWater = null ;
            double[] minSoilTemp = null ;
            double[] maxSoilTemp = null ;
            double[] aveSoilTemp = null ;
            double[] aveSoilWater = null ;
            double[] thickness = null ;
            double[] bulkDensity = null ;
            double[] rocks = null ;
            double[] carbon = null ;
            double[] sand = null ;
            double[] silt = null ;
            double[] clay = null ;
            double instrumentHeight = 0.0;
            double netRadiation = 0.0;
            double canopyHeight = 0.0;
            double instrumHeight = 0.0;
            doInitialisationStuff = true;
            instrumentHeight = getIniVariables(instrumentHeight, instrumHeight, defaultInstrumentHeight);
            getProfileVariables(ref heatStorage, ref minSoilTemp, ref bulkDensity, ref numNodes, physical_BD, ref maxSoilTemp, waterBalance_SW, organic_Carbon, physical_Rocks, ref nodeDepth_loc, topsoilNode, ref newTemperature, surfaceNode, ref soilWater, ref thermalConductance, ref thermalConductivity, ref sand, ref carbon, ref thickness, numPhantomNodes, physical_ParticleSizeSand, ref rocks, ref clay, physical_ParticleSizeSilt, airNode, physical_ParticleSizeClay, ref soilTemp, ref numLayers, physical_Thickness, ref silt, ref volSpecHeatSoil, ref aveSoilTemp, ref morningSoilTemp, DepthToConstantTemperature, MissingValue);
            readParam(bareSoilRoughness, ref newTemperature, ref soilRoughnessHeight_loc, ref soilTemp, ref thermCondPar2_loc, numLayers, bulkDensity, numNodes, ref thermCondPar3_loc, ref thermCondPar4_loc, clay, ref thermCondPar1_loc, weather_Tav, clock_Today_DayOfYear, surfaceNode, weather_Amp, thickness, weather_Latitude);
            InitialValues = pInitialValues;
            nodeDepth = nodeDepth_loc;
            thermCondPar1 = thermCondPar1_loc;
            thermCondPar2 = thermCondPar2_loc;
            thermCondPar3 = thermCondPar3_loc;
            thermCondPar4 = thermCondPar4_loc;
            soilRoughnessHeight = soilRoughnessHeight_loc;
            s.InitialValues= InitialValues;
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
            double[] InitialValues = s.InitialValues;
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
            getOtherVariables(numLayers, numNodes, ref soilWater, ref instrumentHeight, soilRoughnessHeight, waterBalance_SW, microClimate_CanopyHeight, ref canopyHeight);
            if (doInitialisationStuff)
            {
                if (ValuesInArray(InitialValues, MissingValue))
                {
                    soilTemp = new double[numNodes + 1 + 1];
                     Array.ConstrainedCopy(InitialValues, 0, soilTemp, topsoilNode, InitialValues.Length);
                }
                else
                {
                    soilTemp = calcSoilTemperature(soilTemp, weather_Tav, clock_Today_DayOfYear, surfaceNode, numNodes, weather_Amp, thickness, weather_Latitude);
                    InitialValues = new double[numLayers];
                     Array.ConstrainedCopy(soilTemp, topsoilNode, InitialValues, 0, numLayers);
                }
                soilTemp[airNode] = weather_MeanT;
                soilTemp[surfaceNode] = calcSurfaceTemperature(weather_MeanT, weather_MaxT, waterBalance_Salb, weather_Radn);
                for (i=numNodes + 1 ; i!=soilTemp.Length ; i+=1)
                {
                    soilTemp[i] = weather_Tav;
                }
                soilTemp.CopyTo(newTemperature, 0);
                maxTempYesterday = weather_MaxT;
                minTempYesterday = weather_MinT;
                doInitialisationStuff = false;
            }
            doProcess(ref timeOfDaySecs, ref netRadiation, ref minSoilTemp, ref maxSoilTemp, numIterationsForBoundaryLayerConductance, timestep, ref boundaryLayerConductance, ref maxTempYesterday, airNode, ref soilTemp, ref airTemperature, ref newTemperature, weather_MaxT, ref internalTimeStep, boundarLayerConductanceSource, ref thermalConductivity, ref minTempYesterday, ref aveSoilTemp, ref morningSoilTemp, weather_MeanT, constantBoundaryLayerConductance, weather_MinT, clock_Today_DayOfYear, weather_Radn, weather_Latitude, soilConstituentNames, numNodes, ref volSpecHeatSoil, soilWater, nodeDepth, thickness, surfaceNode, MissingValue, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay, defaultTimeOfMaximumTemperature, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, stefanBoltzmannConstant, weather_AirPressure, weather_Wind, instrumentHeight, canopyHeight, ref heatStorage, netRadiationSource, latentHeatOfVapourisation, waterBalance_Es, ref thermalConductance, nu);
            s.InitialValues= InitialValues;
            s.doInitialisationStuff= doInitialisationStuff;
            s.internalTimeStep= internalTimeStep;
            s.timeOfDaySecs= timeOfDaySecs;
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
            s.instrumentHeight= instrumentHeight;
            s.netRadiation= netRadiation;
            s.canopyHeight= canopyHeight;
        }
        public static double getIniVariables(double instrumentHeight, double instrumHeight, double defaultInstrumentHeight)
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
        public static void  getProfileVariables(ref double[] heatStorage, ref double[] minSoilTemp, ref double[] bulkDensity, ref int numNodes, double[] physical_BD, ref double[] maxSoilTemp, double[] waterBalance_SW, double[] organic_Carbon, double[] physical_Rocks, ref double[] nodeDepth, int topsoilNode, ref double[] newTemperature, int surfaceNode, ref double[] soilWater, ref double[] thermalConductance, ref double[] thermalConductivity, ref double[] sand, ref double[] carbon, ref double[] thickness, int numPhantomNodes, double[] physical_ParticleSizeSand, ref double[] rocks, ref double[] clay, double[] physical_ParticleSizeSilt, int airNode, double[] physical_ParticleSizeClay, ref double[] soilTemp, ref int numLayers, double[] physical_Thickness, ref double[] silt, ref double[] volSpecHeatSoil, ref double[] aveSoilTemp, ref double[] morningSoilTemp, double DepthToConstantTemperature, double MissingValue)
        {
            int layer;
            int node;
            int i;
            double belowProfileDepth;
            double thicknessForPhantomNodes;
            int firstPhantomNode;
            double[] oldDepth = null ;
            double[] oldBulkDensity = null ;
            double[] oldSoilWater = null ;
            numLayers = physical_Thickness.Length;
            numNodes = numLayers + numPhantomNodes;
            thickness = new double[numLayers + numPhantomNodes + 1];
            physical_Thickness.CopyTo(thickness, 1);
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
                 Array.ConstrainedCopy(oldDepth, 0, nodeDepth, 0, Math.Min(numNodes + 1 + 1, oldDepth.Length));
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
                 Array.ConstrainedCopy(oldBulkDensity, 0, bulkDensity, 0, Math.Min(numLayers + 1 + numPhantomNodes, oldBulkDensity.Length));
            }
            physical_BD.CopyTo(bulkDensity, 1);
            bulkDensity[numNodes] = bulkDensity[numLayers];
            for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
            {
                bulkDensity[layer] = bulkDensity[numLayers];
            }
            oldSoilWater = soilWater;
            soilWater = new double[numLayers + 1 + numPhantomNodes];
            if (oldSoilWater != null)
            {
                 Array.ConstrainedCopy(oldSoilWater, 0, soilWater, 0, Math.Min(numLayers + 1 + numPhantomNodes, oldSoilWater.Length));
            }
            if (waterBalance_SW != null)
            {
                for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
                {
                    soilWater[layer] = Divide(waterBalance_SW[(layer - 1)] * thickness[(layer - 1)], thickness[layer], (double)(0));
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
        public static void  doThermalConductivityCoeffs(ref double[] thermCondPar2, int numLayers, double[] bulkDensity, int numNodes, ref double[] thermCondPar3, ref double[] thermCondPar4, double[] clay, ref double[] thermCondPar1)
        {
            int layer;
            double[] oldGC1 = null ;
            double[] oldGC2 = null ;
            double[] oldGC3 = null ;
            double[] oldGC4 = null ;
            int element;
            oldGC1 = thermCondPar1;
            thermCondPar1 = new double[numNodes + 1];
            if (oldGC1 != null)
            {
                 Array.ConstrainedCopy(oldGC1, 0, thermCondPar1, 0, Math.Min(numNodes + 1, oldGC1.Length));
            }
            oldGC2 = thermCondPar2;
            thermCondPar2 = new double[numNodes + 1];
            if (oldGC2 != null)
            {
                 Array.ConstrainedCopy(oldGC2, 0, thermCondPar2, 0, Math.Min(numNodes + 1, oldGC2.Length));
            }
            oldGC3 = thermCondPar3;
            thermCondPar3 = new double[numNodes + 1];
            if (oldGC3 != null)
            {
                 Array.ConstrainedCopy(oldGC3, 0, thermCondPar3, 0, Math.Min(numNodes + 1, oldGC3.Length));
            }
            oldGC4 = thermCondPar4;
            thermCondPar4 = new double[numNodes + 1];
            if (oldGC4 != null)
            {
                 Array.ConstrainedCopy(oldGC4, 0, thermCondPar4, 0, Math.Min(numNodes + 1, oldGC4.Length));
            }
            for (layer=1 ; layer!=numLayers + 1 + 1 ; layer+=1)
            {
                element = layer;
                thermCondPar1[element] = 0.65 - (0.78 * bulkDensity[layer]) + (0.6 * Math.Pow(bulkDensity[layer], 2));
                thermCondPar2[element] = 1.06 * bulkDensity[layer];
                thermCondPar3[element] = 1.0 + Divide(2.6, Math.Sqrt(clay[layer]), (double)(0));
                thermCondPar4[element] = 0.03 + (0.1 * Math.Pow(bulkDensity[layer], 2));
            }
        }
        public static void  readParam(double bareSoilRoughness, ref double[] newTemperature, ref double soilRoughnessHeight, ref double[] soilTemp, ref double[] thermCondPar2, int numLayers, double[] bulkDensity, int numNodes, ref double[] thermCondPar3, ref double[] thermCondPar4, double[] clay, ref double[] thermCondPar1, double weather_Tav, int clock_Today_DayOfYear, int surfaceNode, double weather_Amp, double[] thickness, double weather_Latitude)
        {
            doThermalConductivityCoeffs(ref thermCondPar2, numLayers, bulkDensity, numNodes, ref thermCondPar3, ref thermCondPar4, clay, ref thermCondPar1);
            soilTemp = calcSoilTemperature(soilTemp, weather_Tav, clock_Today_DayOfYear, surfaceNode, numNodes, weather_Amp, thickness, weather_Latitude);
            soilTemp.CopyTo(newTemperature, 0);
            soilRoughnessHeight = bareSoilRoughness;
        }
        public static void  getOtherVariables(int numLayers, int numNodes, ref double[] soilWater, ref double instrumentHeight, double soilRoughnessHeight, double[] waterBalance_SW, double microClimate_CanopyHeight, ref double canopyHeight)
        {
            waterBalance_SW.CopyTo(soilWater, 1);
            soilWater[numNodes] = soilWater[numLayers];
            canopyHeight = Math.Max(microClimate_CanopyHeight, soilRoughnessHeight) / 1000.0;
            instrumentHeight = Math.Max(instrumentHeight, canopyHeight + 0.5);
        }
        public static double volumetricFractionOrganicMatter(int layer, double[] carbon, double[] bulkDensity, double pom)
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
        public static double volumetricFractionWater(int layer, double[] soilWater, double[] carbon, double[] bulkDensity, double pom)
        {
            return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom)) * soilWater[layer];
        }
        public static double volumetricFractionClay(int layer, double[] bulkDensity, double ps, double[] clay, double[] carbon, double pom, double[] rocks)
        {
            return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * clay[layer] / 100.0 * bulkDensity[layer] / ps;
        }
        public static double volumetricFractionSilt(int layer, double[] bulkDensity, double[] silt, double ps, double[] carbon, double pom, double[] rocks)
        {
            return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * silt[layer] / 100.0 * bulkDensity[layer] / ps;
        }
        public static double volumetricFractionSand(int layer, double[] bulkDensity, double[] sand, double ps, double[] carbon, double pom, double[] rocks)
        {
            return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * sand[layer] / 100.0 * bulkDensity[layer] / ps;
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
        public static double volumetricFractionAir(int layer, double[] rocks, double[] carbon, double[] bulkDensity, double pom, double[] sand, double ps, double[] silt, double[] clay, double[] soilWater)
        {
            return 1.0 - volumetricFractionRocks(layer, rocks) - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks) - volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks) - volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks) - volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) - volumetricFractionIce(layer);
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
        public static double[] mapLayer2Node(double[] layerArray, double[] nodeArray, double[] nodeDepth, int numNodes, double[] thickness, int surfaceNode, double MissingValue)
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
                nodeArray[node] = Divide(layerArray[layer] * d1, dSum, (double)(0)) + Divide(layerArray[(layer + 1)] * d2, dSum, (double)(0));
            }
            return nodeArray;
        }
        public static double ThermalConductance(string name, int layer, double[] rocks, double[] bulkDensity, double[] sand, double ps, double[] carbon, double pom, double[] silt, double[] clay)
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
                result = Math.Pow(thermalConductanceRocks, volumetricFractionRocks(layer, rocks)) * Math.Pow(thermalConductanceSand, volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks)) + Math.Pow(thermalConductanceSilt, volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + Math.Pow(thermalConductanceClay, volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks));
            }
            result = volumetricSpecificHeat(name, layer);
            return result;
        }
        public static double shapeFactor(string name, int layer, double[] soilWater, double[] carbon, double[] bulkDensity, double pom, double[] rocks, double[] sand, double ps, double[] silt, double[] clay)
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
                result = 0.333 - (0.333 * volumetricFractionIce(layer) / (volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater)));
                return result;
            }
            else if ( name == "Air")
            {
                result = 0.333 - (0.333 * volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater) / (volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater)));
                return result;
            }
            else if ( name == "Minerals")
            {
                result = shapeFactorRocks * volumetricFractionRocks(layer, rocks) + (shapeFactorSand * volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks)) + (shapeFactorSilt * volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + (shapeFactorClay * volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks));
            }
            result = volumetricSpecificHeat(name, layer);
            return result;
        }
        public static void  doUpdate(int numInterationsPerDay, double timeOfDaySecs, ref double boundaryLayerConductance, ref double[] minSoilTemp, int airNode, ref double[] soilTemp, double[] newTemperature, int numNodes, int surfaceNode, double internalTimeStep, ref double[] maxSoilTemp, ref double[] aveSoilTemp, double[] thermalConductivity)
        {
            int node;
            newTemperature.CopyTo(soilTemp, 0);
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
                aveSoilTemp[node] = aveSoilTemp[node] + Divide(soilTemp[node], (double)(numInterationsPerDay), (double)(0));
            }
            boundaryLayerConductance = boundaryLayerConductance + Divide(thermalConductivity[airNode], (double)(numInterationsPerDay), (double)(0));
        }
        public static void  doThomas(ref double[] newTemps, double netRadiation, ref double[] heatStorage, double waterBalance_Eos, int numNodes, double timestep, string netRadiationSource, double latentHeatOfVapourisation, double[] nodeDepth, double waterBalance_Es, int airNode, double[] soilTemp, int surfaceNode, double internalTimeStep, ref double[] thermalConductance, double[] thermalConductivity, double nu, double[] volSpecHeatSoil)
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
                heatStorage[node] = Divide(volSpecHeatSoil[node] * volumeOfSoilAtNode, internalTimeStep, (double)(0));
                elementLength = nodeDepth[node + 1] - nodeDepth[node];
                thermalConductance[node] = Divide(thermalConductivity[node], elementLength, (double)(0));
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
                radnNet = Divide(netRadiation * 1000000.0, internalTimeStep, (double)(0));
            }
            else if ( netRadiationSource == "eos")
            {
                radnNet = Divide(waterBalance_Eos * latentHeatOfVapourisation, timestep, (double)(0));
            }
            latentHeatFlux = Divide(waterBalance_Es * latentHeatOfVapourisation, timestep, (double)(0));
            soilSurfaceHeatFlux = sensibleHeatFlux + radnNet - latentHeatFlux;
            d[surfaceNode] = d[surfaceNode] + soilSurfaceHeatFlux;
            d[numNodes] = d[numNodes] + (nu * thermalConductance[numNodes] * newTemps[(numNodes + 1)]);
            for (node=surfaceNode ; node!=numNodes - 1 + 1 ; node+=1)
            {
                c[node] = Divide(c[node], b[node], (double)(0));
                d[node] = Divide(d[node], b[node], (double)(0));
                b[node + 1] = b[node + 1] - (a[(node + 1)] * c[node]);
                d[node + 1] = d[node + 1] - (a[(node + 1)] * d[node]);
            }
            newTemps[numNodes] = Divide(d[numNodes], b[numNodes], (double)(0));
            for (node=numNodes - 1 ; node!=surfaceNode - 1 ; node+=-1)
            {
                newTemps[node] = d[node] - (c[node] * newTemps[(node + 1)]);
            }
        }
        public static double getBoundaryLayerConductance(ref double[] TNew_zb, double weather_AirPressure, double stefanBoltzmannConstant, double waterBalance_Eos, double weather_Wind, double airTemperature, int surfaceNode, double waterBalance_Eo, double instrumentHeight, double canopyHeight)
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
                frictionVelocity = Divide(weather_Wind * vonKarmanConstant, Math.Log(Divide(instrumentHeight - d + roughnessFactorMomentum, roughnessFactorMomentum, (double)(0))) + stabilityCorrectionMomentum, (double)(0));
                boundaryLayerCond = Divide(SpecificHeatAir * vonKarmanConstant * frictionVelocity, Math.Log(Divide(instrumentHeight - d + roughnessFactorHeat, roughnessFactorHeat, (double)(0))) + stabilityCorrectionHeat, (double)(0));
                boundaryLayerCond = boundaryLayerCond + radiativeConductance;
                heatFluxDensity = boundaryLayerCond * (surfaceTemperature - airTemperature);
                stabilityParammeter = Divide(-vonKarmanConstant * instrumentHeight * gravitationalConstant * heatFluxDensity, SpecificHeatAir * kelvinT(airTemperature) * Math.Pow(frictionVelocity, 3.0), (double)(0));
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
        public static double interpolateNetRadiation(double solarRadn, double cloudFr, double cva, double waterBalance_Eo, double waterBalance_Eos, double waterBalance_Salb, double[] soilTemp, double airTemperature, int surfaceNode, double internalTimeStep, double stefanBoltzmannConstant)
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
            PenetrationConstant = Divide(Math.Max(0.1, waterBalance_Eos), Math.Max(0.1, waterBalance_Eo), (double)(0));
            lwRinSoil = longWaveRadn(emissivityAtmos, airTemperature, stefanBoltzmannConstant) * PenetrationConstant * w2MJ;
            lwRoutSoil = longWaveRadn(surfaceEmissivity, soilTemp[surfaceNode], stefanBoltzmannConstant) * PenetrationConstant * w2MJ;
            lwRnetSoil = lwRinSoil - lwRoutSoil;
            swRin = solarRadn;
            swRout = waterBalance_Salb * solarRadn;
            swRnetSoil = (swRin - swRout) * PenetrationConstant;
            return swRnetSoil + lwRnetSoil;
        }
        public static double interpolateTemperature(double timeHours, double minTempYesterday, double maxTempYesterday, double weather_MeanT, double weather_MaxT, double weather_MinT, double defaultTimeOfMaximumTemperature)
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
        public static double[] doThermalConductivity(string[] soilConstituentNames, int numNodes, double[] soilWater, double[] thermalConductivity, double[] carbon, double[] bulkDensity, double pom, double[] rocks, double[] sand, double ps, double[] silt, double[] clay, double[] nodeDepth, double[] thickness, int surfaceNode, double MissingValue)
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
                foreach(string constituentName_cyml in soilConstituentNames)
                {
                    constituentName = constituentName_cyml;
                    shapeFactorConstituent = shapeFactor(constituentName, node, soilWater, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay);
                    thermalConductanceConstituent = ThermalConductance(constituentName, node, rocks, bulkDensity, sand, ps, carbon, pom, silt, clay);
                    thermalConductanceWater = ThermalConductance("Water", node, rocks, bulkDensity, sand, ps, carbon, pom, silt, clay);
                    k = 2.0 / 3.0 * Math.Pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0))), -1) + (1.0 / 3.0 * Math.Pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0) * (1 - (2 * shapeFactorConstituent)))), -1));
                    numerator = numerator + (thermalConductanceConstituent * soilWater[node] * k);
                    denominator = denominator + (soilWater[node] * k);
                }
                thermCondLayers[node] = numerator / denominator;
            }
            thermalConductivity = mapLayer2Node(thermCondLayers, thermalConductivity, nodeDepth, numNodes, thickness, surfaceNode, MissingValue);
            return thermalConductivity;
        }
        public static double[] doVolumetricSpecificHeat(string[] soilConstituentNames, int numNodes, double[] volSpecHeatSoil, double[] soilWater, double[] nodeDepth, double[] thickness, int surfaceNode, double MissingValue)
        {
            int node;
            string constituentName;
            double[] volspecHeatSoil_ =  new double [numNodes + 1];
            for (node=1 ; node!=numNodes + 1 ; node+=1)
            {
                volspecHeatSoil_[node] = (double)(0);
                foreach(string constituentName_cyml in soilConstituentNames)
                {
                    constituentName = constituentName_cyml;
                    if (!new List<string>{"Minerals"}.Contains(constituentName))
                    {
                        volspecHeatSoil_[node] = volspecHeatSoil_[node] + (volumetricSpecificHeat(constituentName, node) * 1000000.0 * soilWater[node]);
                    }
                }
            }
            volSpecHeatSoil = mapLayer2Node(volspecHeatSoil_, volSpecHeatSoil, nodeDepth, numNodes, thickness, surfaceNode, MissingValue);
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
        public static void  doNetRadiation(ref double[] solarRadn, ref double cloudFr, ref double cva, int ITERATIONSperDAY, double weather_MinT, int clock_Today_DayOfYear, double weather_Radn, double weather_Latitude)
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
            TSTEPS2RAD = Divide(2.0 * Math.PI, (double)(ITERATIONSperDAY), (double)(0));
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
            fr = Divide(Math.Max(weather_Radn, 0.1), psr, (double)(0));
            cloudFr = 2.33 - (3.33 * fr);
            cloudFr = Math.Min(Math.Max(cloudFr, 0.0), 1.0);
            for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
            {
                solarRadn[timestepNumber] = Math.Max(weather_Radn, 0.1) * Divide(m1[timestepNumber], m1Tot, (double)(0));
            }
            cva = Math.Exp((31.3716 - (6014.79 / kelvinT(weather_MinT)) - (0.00792495 * kelvinT(weather_MinT)))) / kelvinT(weather_MinT);
        }
        public static void  doProcess(ref double timeOfDaySecs, ref double netRadiation, ref double[] minSoilTemp, ref double[] maxSoilTemp, int numIterationsForBoundaryLayerConductance, double timestep, ref double boundaryLayerConductance, ref double maxTempYesterday, int airNode, ref double[] soilTemp, ref double airTemperature, ref double[] newTemperature, double weather_MaxT, ref double internalTimeStep, string boundarLayerConductanceSource, ref double[] thermalConductivity, ref double minTempYesterday, ref double[] aveSoilTemp, ref double[] morningSoilTemp, double weather_MeanT, double constantBoundaryLayerConductance, double weather_MinT, int clock_Today_DayOfYear, double weather_Radn, double weather_Latitude, string[] soilConstituentNames, int numNodes, ref double[] volSpecHeatSoil, double[] soilWater, double[] nodeDepth, double[] thickness, int surfaceNode, double MissingValue, double[] carbon, double[] bulkDensity, double pom, double[] rocks, double[] sand, double ps, double[] silt, double[] clay, double defaultTimeOfMaximumTemperature, double waterBalance_Eo, double waterBalance_Eos, double waterBalance_Salb, double stefanBoltzmannConstant, double weather_AirPressure, double weather_Wind, double instrumentHeight, double canopyHeight, ref double[] heatStorage, string netRadiationSource, double latentHeatOfVapourisation, double waterBalance_Es, ref double[] thermalConductance, double nu)
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
            doNetRadiation(ref solarRadn, ref cloudFr, ref cva, interactionsPerDay, weather_MinT, clock_Today_DayOfYear, weather_Radn, weather_Latitude);
            minSoilTemp = Zero(minSoilTemp);
            maxSoilTemp = Zero(maxSoilTemp);
            aveSoilTemp = Zero(aveSoilTemp);
            boundaryLayerConductance = 0.0;
            internalTimeStep = Math.Round(timestep / interactionsPerDay);
            volSpecHeatSoil = doVolumetricSpecificHeat(soilConstituentNames, numNodes, volSpecHeatSoil, soilWater, nodeDepth, thickness, surfaceNode, MissingValue);
            thermalConductivity = doThermalConductivity(soilConstituentNames, numNodes, soilWater, thermalConductivity, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay, nodeDepth, thickness, surfaceNode, MissingValue);
            for (timeStepIteration=1 ; timeStepIteration!=interactionsPerDay + 1 ; timeStepIteration+=1)
            {
                timeOfDaySecs = internalTimeStep * (double)(timeStepIteration);
                if (timestep < (24.0 * 60.0 * 60.0))
                {
                    airTemperature = weather_MeanT;
                }
                else
                {
                    airTemperature = interpolateTemperature(timeOfDaySecs / 3600.0, minTempYesterday, maxTempYesterday, weather_MeanT, weather_MaxT, weather_MinT, defaultTimeOfMaximumTemperature);
                }
                newTemperature[airNode] = airTemperature;
                netRadiation = interpolateNetRadiation(solarRadn[timeStepIteration], cloudFr, cva, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, soilTemp, airTemperature, surfaceNode, internalTimeStep, stefanBoltzmannConstant);
                if (boundarLayerConductanceSource == "constant")
                {
                    thermalConductivity[airNode] = constantBoundaryLayerConductance;
                }
                else if ( boundarLayerConductanceSource == "calc")
                {
                    thermalConductivity[airNode] = getBoundaryLayerConductance(ref newTemperature, weather_AirPressure, stefanBoltzmannConstant, waterBalance_Eos, weather_Wind, airTemperature, surfaceNode, waterBalance_Eo, instrumentHeight, canopyHeight);
                    for (iteration=1 ; iteration!=numIterationsForBoundaryLayerConductance + 1 ; iteration+=1)
                    {
                        doThomas(ref newTemperature, netRadiation, ref heatStorage, waterBalance_Eos, numNodes, timestep, netRadiationSource, latentHeatOfVapourisation, nodeDepth, waterBalance_Es, airNode, soilTemp, surfaceNode, internalTimeStep, ref thermalConductance, thermalConductivity, nu, volSpecHeatSoil);
                        thermalConductivity[airNode] = getBoundaryLayerConductance(ref newTemperature, weather_AirPressure, stefanBoltzmannConstant, waterBalance_Eos, weather_Wind, airTemperature, surfaceNode, waterBalance_Eo, instrumentHeight, canopyHeight);
                    }
                }
                doThomas(ref newTemperature, netRadiation, ref heatStorage, waterBalance_Eos, numNodes, timestep, netRadiationSource, latentHeatOfVapourisation, nodeDepth, waterBalance_Es, airNode, soilTemp, surfaceNode, internalTimeStep, ref thermalConductance, thermalConductivity, nu, volSpecHeatSoil);
                doUpdate(interactionsPerDay, timeOfDaySecs, ref boundaryLayerConductance, ref minSoilTemp, airNode, ref soilTemp, newTemperature, numNodes, surfaceNode, internalTimeStep, ref maxSoilTemp, ref aveSoilTemp, thermalConductivity);
                if (Math.Abs(timeOfDaySecs - (5.0 * 3600.0)) <= (Math.Min(timeOfDaySecs, 5.0 * 3600.0) * 0.0001))
                {
                    soilTemp.CopyTo(morningSoilTemp, 0);
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
        public static double[] calcSoilTemperature(double[] soilTempIO, double weather_Tav, int clock_Today_DayOfYear, int surfaceNode, int numNodes, double weather_Amp, double[] thickness, double weather_Latitude)
        {
            int nodes;
            double[] cumulativeDepth = null ;
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
             Array.ConstrainedCopy(soilTemp, 0, soilTempIO, surfaceNode, numNodes);
            return soilTempIO;
        }
        public static double calcSurfaceTemperature(double weather_MeanT, double weather_MaxT, double waterBalance_Salb, double weather_Radn)
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