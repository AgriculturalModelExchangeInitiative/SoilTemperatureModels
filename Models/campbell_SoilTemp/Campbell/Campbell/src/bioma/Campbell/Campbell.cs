
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
using model_SoilTempCampbell.DomainClass;
namespace model_SoilTempCampbell.Strategies
{
    public class campbell : IStrategymodel_SoilTempCampbell
    {
        public campbell()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 10;
            v1.Description = "number of soil layers in profile";
            v1.Id = 0;
            v1.MaxValue = -1D;
            v1.MinValue = 1;
            v1.Name = "NLAYR";
            v1.Size = 1;
            v1.Units = "dimensionless";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v1);
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = 1000.0;
            v2.Description = "Depth of constant temperature";
            v2.Id = 0;
            v2.MaxValue = -1D;
            v2.MinValue = -1D;
            v2.Name = "CONSTANT_TEMPdepth";
            v2.Size = 1;
            v2.Units = "mm";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v2);
            VarInfo v3 = new VarInfo();
            v3.DefaultValue = -1D;
            v3.Description = "Amplitude air temperature";
            v3.Id = 0;
            v3.MaxValue = 100;
            v3.MinValue = -100;
            v3.Name = "TAMP";
            v3.Size = 1;
            v3.Units = "";
            v3.URL = "";
            v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v3.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v3);
            VarInfo v4 = new VarInfo();
            v4.DefaultValue = -1D;
            v4.Description = "Latitude";
            v4.Id = 0;
            v4.MaxValue = -1D;
            v4.MinValue = -1D;
            v4.Name = "XLAT";
            v4.Size = 1;
            v4.Units = "";
            v4.URL = "";
            v4.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v4.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v4);
            VarInfo v5 = new VarInfo();
            v5.DefaultValue = -1D;
            v5.Description = "Soil albedo";
            v5.Id = 0;
            v5.MaxValue = 1;
            v5.MinValue = 0;
            v5.Name = "SALB";
            v5.Size = 1;
            v5.Units = "dimensionless";
            v5.URL = "";
            v5.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v5.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v5);
            VarInfo v6 = new VarInfo();
            v6.DefaultValue = 1.2;
            v6.Description = "Default instrument height";
            v6.Id = 0;
            v6.MaxValue = -1D;
            v6.MinValue = 0;
            v6.Name = "instrumentHeight";
            v6.Size = 1;
            v6.Units = "m";
            v6.URL = "";
            v6.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v6.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v6);
            VarInfo v7 = new VarInfo();
            v7.DefaultValue = -1D;
            v7.Description = "Flag whether boundary layer conductance is calculated or gotten from input";
            v7.Id = 0;
            v7.MaxValue = -1D;
            v7.MinValue = -1D;
            v7.Name = "boundaryLayerConductanceSource";
            v7.Size = 1;
            v7.Units = "dimensionless";
            v7.URL = "";
            v7.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v7.ValueType = VarInfoValueTypes.GetInstanceForName("String");
            _parameters0_0.Add(v7);
            VarInfo v8 = new VarInfo();
            v8.DefaultValue = -1D;
            v8.Description = "Flag whether net radiation is calculated or gotten from input";
            v8.Id = 0;
            v8.MaxValue = -1D;
            v8.MinValue = -1D;
            v8.Name = "netRadiationSource";
            v8.Size = 1;
            v8.Units = "dimensionless";
            v8.URL = "";
            v8.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v8.ValueType = VarInfoValueTypes.GetInstanceForName("String");
            _parameters0_0.Add(v8);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd1.PropertyName = "THICK";
            pd1.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.THICK).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.THICK);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd2.PropertyName = "BD";
            pd2.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.BD).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.BD);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd3.PropertyName = "SLCARB";
            pd3.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLCARB).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLCARB);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd4.PropertyName = "CLAY";
            pd4.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.CLAY).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.CLAY);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd5.PropertyName = "SLROCK";
            pd5.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLROCK).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLROCK);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd6.PropertyName = "SLSILT";
            pd6.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLSILT).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLSILT);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd7.PropertyName = "SLSAND";
            pd7.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLSAND).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLSAND);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd8.PropertyName = "SW";
            pd8.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SW).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SW);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd9.PropertyName = "THICKApsim";
            pd9.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.THICKApsim).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.THICKApsim);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd10.PropertyName = "DEPTHApsim";
            pd10.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.DEPTHApsim).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.DEPTHApsim);
            _inputs0_0.Add(pd10);
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd11.PropertyName = "BDApsim";
            pd11.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.BDApsim).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.BDApsim);
            _inputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd12.PropertyName = "T2M";
            pd12.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.T2M).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.T2M);
            _inputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd13.PropertyName = "TMAX";
            pd13.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMAX).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMAX);
            _inputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd14.PropertyName = "TMIN";
            pd14.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMIN).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMIN);
            _inputs0_0.Add(pd14);
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd15.PropertyName = "TAV";
            pd15.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TAV).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TAV);
            _inputs0_0.Add(pd15);
            PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd16.PropertyName = "CLAYApsim";
            pd16.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.CLAYApsim).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.CLAYApsim);
            _inputs0_0.Add(pd16);
            PropertyDescription pd17 = new PropertyDescription();
            pd17.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd17.PropertyName = "SWApsim";
            pd17.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SWApsim).ValueType.TypeForCurrentValue;
            pd17.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SWApsim);
            _inputs0_0.Add(pd17);
            PropertyDescription pd18 = new PropertyDescription();
            pd18.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd18.PropertyName = "DOY";
            pd18.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.DOY).ValueType.TypeForCurrentValue;
            pd18.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.DOY);
            _inputs0_0.Add(pd18);
            PropertyDescription pd19 = new PropertyDescription();
            pd19.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd19.PropertyName = "airPressure";
            pd19.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.airPressure).ValueType.TypeForCurrentValue;
            pd19.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.airPressure);
            _inputs0_0.Add(pd19);
            PropertyDescription pd20 = new PropertyDescription();
            pd20.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd20.PropertyName = "canopyHeight";
            pd20.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.canopyHeight).ValueType.TypeForCurrentValue;
            pd20.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.canopyHeight);
            _inputs0_0.Add(pd20);
            PropertyDescription pd21 = new PropertyDescription();
            pd21.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd21.PropertyName = "SRAD";
            pd21.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SRAD).ValueType.TypeForCurrentValue;
            pd21.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SRAD);
            _inputs0_0.Add(pd21);
            PropertyDescription pd22 = new PropertyDescription();
            pd22.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd22.PropertyName = "ESP";
            pd22.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ESP).ValueType.TypeForCurrentValue;
            pd22.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ESP);
            _inputs0_0.Add(pd22);
            PropertyDescription pd23 = new PropertyDescription();
            pd23.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd23.PropertyName = "ES";
            pd23.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ES).ValueType.TypeForCurrentValue;
            pd23.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ES);
            _inputs0_0.Add(pd23);
            PropertyDescription pd24 = new PropertyDescription();
            pd24.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd24.PropertyName = "EOAD";
            pd24.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.EOAD).ValueType.TypeForCurrentValue;
            pd24.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.EOAD);
            _inputs0_0.Add(pd24);
            PropertyDescription pd25 = new PropertyDescription();
            pd25.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd25.PropertyName = "soilTemp";
            pd25.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp).ValueType.TypeForCurrentValue;
            pd25.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp);
            _inputs0_0.Add(pd25);
            PropertyDescription pd26 = new PropertyDescription();
            pd26.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd26.PropertyName = "newTemperature";
            pd26.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature).ValueType.TypeForCurrentValue;
            pd26.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature);
            _inputs0_0.Add(pd26);
            PropertyDescription pd27 = new PropertyDescription();
            pd27.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd27.PropertyName = "minSoilTemp";
            pd27.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp).ValueType.TypeForCurrentValue;
            pd27.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp);
            _inputs0_0.Add(pd27);
            PropertyDescription pd28 = new PropertyDescription();
            pd28.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd28.PropertyName = "maxSoilTemp";
            pd28.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp).ValueType.TypeForCurrentValue;
            pd28.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp);
            _inputs0_0.Add(pd28);
            PropertyDescription pd29 = new PropertyDescription();
            pd29.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd29.PropertyName = "aveSoilTemp";
            pd29.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp).ValueType.TypeForCurrentValue;
            pd29.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp);
            _inputs0_0.Add(pd29);
            PropertyDescription pd30 = new PropertyDescription();
            pd30.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd30.PropertyName = "morningSoilTemp";
            pd30.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp).ValueType.TypeForCurrentValue;
            pd30.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp);
            _inputs0_0.Add(pd30);
            PropertyDescription pd31 = new PropertyDescription();
            pd31.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd31.PropertyName = "thermalCondPar1";
            pd31.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1).ValueType.TypeForCurrentValue;
            pd31.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1);
            _inputs0_0.Add(pd31);
            PropertyDescription pd32 = new PropertyDescription();
            pd32.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd32.PropertyName = "thermalCondPar2";
            pd32.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2).ValueType.TypeForCurrentValue;
            pd32.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2);
            _inputs0_0.Add(pd32);
            PropertyDescription pd33 = new PropertyDescription();
            pd33.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd33.PropertyName = "thermalCondPar3";
            pd33.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3).ValueType.TypeForCurrentValue;
            pd33.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3);
            _inputs0_0.Add(pd33);
            PropertyDescription pd34 = new PropertyDescription();
            pd34.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd34.PropertyName = "thermalCondPar4";
            pd34.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4).ValueType.TypeForCurrentValue;
            pd34.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4);
            _inputs0_0.Add(pd34);
            PropertyDescription pd35 = new PropertyDescription();
            pd35.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd35.PropertyName = "thermalConductivity";
            pd35.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity).ValueType.TypeForCurrentValue;
            pd35.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity);
            _inputs0_0.Add(pd35);
            PropertyDescription pd36 = new PropertyDescription();
            pd36.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd36.PropertyName = "thermalConductance";
            pd36.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance).ValueType.TypeForCurrentValue;
            pd36.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance);
            _inputs0_0.Add(pd36);
            PropertyDescription pd37 = new PropertyDescription();
            pd37.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd37.PropertyName = "heatStorage";
            pd37.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage).ValueType.TypeForCurrentValue;
            pd37.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage);
            _inputs0_0.Add(pd37);
            PropertyDescription pd38 = new PropertyDescription();
            pd38.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd38.PropertyName = "volSpecHeatSoil";
            pd38.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil).ValueType.TypeForCurrentValue;
            pd38.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil);
            _inputs0_0.Add(pd38);
            PropertyDescription pd39 = new PropertyDescription();
            pd39.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd39.PropertyName = "maxTempYesterday";
            pd39.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday).ValueType.TypeForCurrentValue;
            pd39.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday);
            _inputs0_0.Add(pd39);
            PropertyDescription pd40 = new PropertyDescription();
            pd40.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd40.PropertyName = "minTempYesterday";
            pd40.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday).ValueType.TypeForCurrentValue;
            pd40.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday);
            _inputs0_0.Add(pd40);
            PropertyDescription pd41 = new PropertyDescription();
            pd41.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd41.PropertyName = "windSpeed";
            pd41.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.windSpeed).ValueType.TypeForCurrentValue;
            pd41.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.windSpeed);
            _inputs0_0.Add(pd41);
            PropertyDescription pd42 = new PropertyDescription();
            pd42.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd42.PropertyName = "SLCARBApsim";
            pd42.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARBApsim).ValueType.TypeForCurrentValue;
            pd42.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARBApsim);
            _inputs0_0.Add(pd42);
            PropertyDescription pd43 = new PropertyDescription();
            pd43.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd43.PropertyName = "SLROCKApsim";
            pd43.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCKApsim).ValueType.TypeForCurrentValue;
            pd43.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCKApsim);
            _inputs0_0.Add(pd43);
            PropertyDescription pd44 = new PropertyDescription();
            pd44.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd44.PropertyName = "SLSILTApsim";
            pd44.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILTApsim).ValueType.TypeForCurrentValue;
            pd44.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILTApsim);
            _inputs0_0.Add(pd44);
            PropertyDescription pd45 = new PropertyDescription();
            pd45.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd45.PropertyName = "SLSANDApsim";
            pd45.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSANDApsim).ValueType.TypeForCurrentValue;
            pd45.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSANDApsim);
            _inputs0_0.Add(pd45);
            PropertyDescription pd46 = new PropertyDescription();
            pd46.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd46.PropertyName = "_boundaryLayerConductance";
            pd46.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance).ValueType.TypeForCurrentValue;
            pd46.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance);
            _inputs0_0.Add(pd46);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd47 = new PropertyDescription();
            pd47.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd47.PropertyName = "soilTemp";
            pd47.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp).ValueType.TypeForCurrentValue;
            pd47.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp);
            _outputs0_0.Add(pd47);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd48 = new PropertyDescription();
            pd48.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd48.PropertyName = "minSoilTemp";
            pd48.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp).ValueType.TypeForCurrentValue;
            pd48.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp);
            _outputs0_0.Add(pd48);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd49 = new PropertyDescription();
            pd49.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd49.PropertyName = "maxSoilTemp";
            pd49.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp).ValueType.TypeForCurrentValue;
            pd49.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp);
            _outputs0_0.Add(pd49);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd50 = new PropertyDescription();
            pd50.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd50.PropertyName = "aveSoilTemp";
            pd50.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp).ValueType.TypeForCurrentValue;
            pd50.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp);
            _outputs0_0.Add(pd50);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd51 = new PropertyDescription();
            pd51.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd51.PropertyName = "morningSoilTemp";
            pd51.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp).ValueType.TypeForCurrentValue;
            pd51.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp);
            _outputs0_0.Add(pd51);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd52 = new PropertyDescription();
            pd52.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd52.PropertyName = "newTemperature";
            pd52.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature).ValueType.TypeForCurrentValue;
            pd52.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature);
            _outputs0_0.Add(pd52);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd53 = new PropertyDescription();
            pd53.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd53.PropertyName = "maxTempYesterday";
            pd53.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday).ValueType.TypeForCurrentValue;
            pd53.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday);
            _outputs0_0.Add(pd53);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd54 = new PropertyDescription();
            pd54.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd54.PropertyName = "minTempYesterday";
            pd54.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday).ValueType.TypeForCurrentValue;
            pd54.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday);
            _outputs0_0.Add(pd54);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd55 = new PropertyDescription();
            pd55.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd55.PropertyName = "thermalCondPar1";
            pd55.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1).ValueType.TypeForCurrentValue;
            pd55.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1);
            _outputs0_0.Add(pd55);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd56 = new PropertyDescription();
            pd56.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd56.PropertyName = "thermalCondPar2";
            pd56.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2).ValueType.TypeForCurrentValue;
            pd56.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2);
            _outputs0_0.Add(pd56);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd57 = new PropertyDescription();
            pd57.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd57.PropertyName = "thermalCondPar3";
            pd57.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3).ValueType.TypeForCurrentValue;
            pd57.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3);
            _outputs0_0.Add(pd57);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd58 = new PropertyDescription();
            pd58.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd58.PropertyName = "thermalCondPar4";
            pd58.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4).ValueType.TypeForCurrentValue;
            pd58.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4);
            _outputs0_0.Add(pd58);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd59 = new PropertyDescription();
            pd59.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd59.PropertyName = "thermalConductivity";
            pd59.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity).ValueType.TypeForCurrentValue;
            pd59.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity);
            _outputs0_0.Add(pd59);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd60 = new PropertyDescription();
            pd60.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd60.PropertyName = "thermalConductance";
            pd60.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance).ValueType.TypeForCurrentValue;
            pd60.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance);
            _outputs0_0.Add(pd60);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd61 = new PropertyDescription();
            pd61.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd61.PropertyName = "heatStorage";
            pd61.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage).ValueType.TypeForCurrentValue;
            pd61.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage);
            _outputs0_0.Add(pd61);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd62 = new PropertyDescription();
            pd62.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd62.PropertyName = "volSpecHeatSoil";
            pd62.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil).ValueType.TypeForCurrentValue;
            pd62.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil);
            _outputs0_0.Add(pd62);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd63 = new PropertyDescription();
            pd63.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd63.PropertyName = "_boundaryLayerConductance";
            pd63.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance).ValueType.TypeForCurrentValue;
            pd63.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance);
            _outputs0_0.Add(pd63);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd64 = new PropertyDescription();
            pd64.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd64.PropertyName = "THICKApsim";
            pd64.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.THICKApsim).ValueType.TypeForCurrentValue;
            pd64.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.THICKApsim);
            _outputs0_0.Add(pd64);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd65 = new PropertyDescription();
            pd65.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd65.PropertyName = "DEPTHApsim";
            pd65.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.DEPTHApsim).ValueType.TypeForCurrentValue;
            pd65.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.DEPTHApsim);
            _outputs0_0.Add(pd65);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd66 = new PropertyDescription();
            pd66.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd66.PropertyName = "BDApsim";
            pd66.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.BDApsim).ValueType.TypeForCurrentValue;
            pd66.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.BDApsim);
            _outputs0_0.Add(pd66);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd67 = new PropertyDescription();
            pd67.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd67.PropertyName = "SWApsim";
            pd67.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SWApsim).ValueType.TypeForCurrentValue;
            pd67.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SWApsim);
            _outputs0_0.Add(pd67);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd68 = new PropertyDescription();
            pd68.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd68.PropertyName = "CLAYApsim";
            pd68.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.CLAYApsim).ValueType.TypeForCurrentValue;
            pd68.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.CLAYApsim);
            _outputs0_0.Add(pd68);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd69 = new PropertyDescription();
            pd69.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd69.PropertyName = "SLROCKApsim";
            pd69.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCKApsim).ValueType.TypeForCurrentValue;
            pd69.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCKApsim);
            _outputs0_0.Add(pd69);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd70 = new PropertyDescription();
            pd70.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd70.PropertyName = "SLCARBApsim";
            pd70.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARBApsim).ValueType.TypeForCurrentValue;
            pd70.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARBApsim);
            _outputs0_0.Add(pd70);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd71 = new PropertyDescription();
            pd71.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd71.PropertyName = "SLSANDApsim";
            pd71.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSANDApsim).ValueType.TypeForCurrentValue;
            pd71.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSANDApsim);
            _outputs0_0.Add(pd71);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd72 = new PropertyDescription();
            pd72.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd72.PropertyName = "SLSILTApsim";
            pd72.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILTApsim).ValueType.TypeForCurrentValue;
            pd72.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILTApsim);
            _outputs0_0.Add(pd72);
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
            get { return "TODO" ;}
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
            _pd.Add("Creator", "None");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "CIRAD and INRAE "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState),  typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState), typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellRate), typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellAuxiliary), typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public int NLAYR
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("NLAYR");
                if (vi != null && vi.CurrentValue!=null) return (int)vi.CurrentValue ;
                else throw new Exception("Parameter 'NLAYR' not found (or found null) in strategy 'campbell'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("NLAYR");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'NLAYR' not found in strategy 'campbell'");
            }
        }
        public double CONSTANT_TEMPdepth
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("CONSTANT_TEMPdepth");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'CONSTANT_TEMPdepth' not found (or found null) in strategy 'campbell'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("CONSTANT_TEMPdepth");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'CONSTANT_TEMPdepth' not found in strategy 'campbell'");
            }
        }
        public double TAMP
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("TAMP");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'TAMP' not found (or found null) in strategy 'campbell'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("TAMP");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'TAMP' not found in strategy 'campbell'");
            }
        }
        public double XLAT
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("XLAT");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'XLAT' not found (or found null) in strategy 'campbell'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("XLAT");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'XLAT' not found in strategy 'campbell'");
            }
        }
        public double SALB
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("SALB");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'SALB' not found (or found null) in strategy 'campbell'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("SALB");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'SALB' not found in strategy 'campbell'");
            }
        }
        public double instrumentHeight
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("instrumentHeight");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'instrumentHeight' not found (or found null) in strategy 'campbell'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("instrumentHeight");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'instrumentHeight' not found in strategy 'campbell'");
            }
        }
        public string boundaryLayerConductanceSource
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("boundaryLayerConductanceSource");
                if (vi != null && vi.CurrentValue!=null) return (string)vi.CurrentValue ;
                else throw new Exception("Parameter 'boundaryLayerConductanceSource' not found (or found null) in strategy 'campbell'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("boundaryLayerConductanceSource");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'boundaryLayerConductanceSource' not found in strategy 'campbell'");
            }
        }
        public string netRadiationSource
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("netRadiationSource");
                if (vi != null && vi.CurrentValue!=null) return (string)vi.CurrentValue ;
                else throw new Exception("Parameter 'netRadiationSource' not found (or found null) in strategy 'campbell'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("netRadiationSource");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'netRadiationSource' not found in strategy 'campbell'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            NLAYRVarInfo.Name = "NLAYR";
            NLAYRVarInfo.Description = "number of soil layers in profile";
            NLAYRVarInfo.MaxValue = -1D;
            NLAYRVarInfo.MinValue = 1;
            NLAYRVarInfo.DefaultValue = 10;
            NLAYRVarInfo.Units = "dimensionless";
            NLAYRVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            CONSTANT_TEMPdepthVarInfo.Name = "CONSTANT_TEMPdepth";
            CONSTANT_TEMPdepthVarInfo.Description = "Depth of constant temperature";
            CONSTANT_TEMPdepthVarInfo.MaxValue = -1D;
            CONSTANT_TEMPdepthVarInfo.MinValue = -1D;
            CONSTANT_TEMPdepthVarInfo.DefaultValue = 1000.0;
            CONSTANT_TEMPdepthVarInfo.Units = "mm";
            CONSTANT_TEMPdepthVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            TAMPVarInfo.Name = "TAMP";
            TAMPVarInfo.Description = "Amplitude air temperature";
            TAMPVarInfo.MaxValue = 100;
            TAMPVarInfo.MinValue = -100;
            TAMPVarInfo.DefaultValue = -1D;
            TAMPVarInfo.Units = "";
            TAMPVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            XLATVarInfo.Name = "XLAT";
            XLATVarInfo.Description = "Latitude";
            XLATVarInfo.MaxValue = -1D;
            XLATVarInfo.MinValue = -1D;
            XLATVarInfo.DefaultValue = -1D;
            XLATVarInfo.Units = "";
            XLATVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            SALBVarInfo.Name = "SALB";
            SALBVarInfo.Description = "Soil albedo";
            SALBVarInfo.MaxValue = 1;
            SALBVarInfo.MinValue = 0;
            SALBVarInfo.DefaultValue = -1D;
            SALBVarInfo.Units = "dimensionless";
            SALBVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            instrumentHeightVarInfo.Name = "instrumentHeight";
            instrumentHeightVarInfo.Description = "Default instrument height";
            instrumentHeightVarInfo.MaxValue = -1D;
            instrumentHeightVarInfo.MinValue = 0;
            instrumentHeightVarInfo.DefaultValue = 1.2;
            instrumentHeightVarInfo.Units = "m";
            instrumentHeightVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            boundaryLayerConductanceSourceVarInfo.Name = "boundaryLayerConductanceSource";
            boundaryLayerConductanceSourceVarInfo.Description = "Flag whether boundary layer conductance is calculated or gotten from input";
            boundaryLayerConductanceSourceVarInfo.MaxValue = -1D;
            boundaryLayerConductanceSourceVarInfo.MinValue = -1D;
            boundaryLayerConductanceSourceVarInfo.DefaultValue = -1D;
            boundaryLayerConductanceSourceVarInfo.Units = "dimensionless";
            boundaryLayerConductanceSourceVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("String");

            netRadiationSourceVarInfo.Name = "netRadiationSource";
            netRadiationSourceVarInfo.Description = "Flag whether net radiation is calculated or gotten from input";
            netRadiationSourceVarInfo.MaxValue = -1D;
            netRadiationSourceVarInfo.MinValue = -1D;
            netRadiationSourceVarInfo.DefaultValue = -1D;
            netRadiationSourceVarInfo.Units = "dimensionless";
            netRadiationSourceVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("String");
        }

        private static VarInfo _NLAYRVarInfo = new VarInfo();
        public static VarInfo NLAYRVarInfo
        {
            get { return _NLAYRVarInfo;} 
        }

        private static VarInfo _CONSTANT_TEMPdepthVarInfo = new VarInfo();
        public static VarInfo CONSTANT_TEMPdepthVarInfo
        {
            get { return _CONSTANT_TEMPdepthVarInfo;} 
        }

        private static VarInfo _TAMPVarInfo = new VarInfo();
        public static VarInfo TAMPVarInfo
        {
            get { return _TAMPVarInfo;} 
        }

        private static VarInfo _XLATVarInfo = new VarInfo();
        public static VarInfo XLATVarInfo
        {
            get { return _XLATVarInfo;} 
        }

        private static VarInfo _SALBVarInfo = new VarInfo();
        public static VarInfo SALBVarInfo
        {
            get { return _SALBVarInfo;} 
        }

        private static VarInfo _instrumentHeightVarInfo = new VarInfo();
        public static VarInfo instrumentHeightVarInfo
        {
            get { return _instrumentHeightVarInfo;} 
        }

        private static VarInfo _boundaryLayerConductanceSourceVarInfo = new VarInfo();
        public static VarInfo boundaryLayerConductanceSourceVarInfo
        {
            get { return _boundaryLayerConductanceSourceVarInfo;} 
        }

        private static VarInfo _netRadiationSourceVarInfo = new VarInfo();
        public static VarInfo netRadiationSourceVarInfo
        {
            get { return _netRadiationSourceVarInfo;} 
        }

        public string TestPostConditions(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s1,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellRate r,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellAuxiliary a,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp.CurrentValue=s.soilTemp;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp.CurrentValue=s.minSoilTemp;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp.CurrentValue=s.maxSoilTemp;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp.CurrentValue=s.aveSoilTemp;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp.CurrentValue=s.morningSoilTemp;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature.CurrentValue=s.newTemperature;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday.CurrentValue=s.maxTempYesterday;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday.CurrentValue=s.minTempYesterday;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1.CurrentValue=s.thermalCondPar1;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2.CurrentValue=s.thermalCondPar2;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3.CurrentValue=s.thermalCondPar3;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4.CurrentValue=s.thermalCondPar4;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity.CurrentValue=s.thermalConductivity;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance.CurrentValue=s.thermalConductance;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage.CurrentValue=s.heatStorage;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil.CurrentValue=s.volSpecHeatSoil;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance.CurrentValue=s._boundaryLayerConductance;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.THICKApsim.CurrentValue=s.THICKApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.DEPTHApsim.CurrentValue=s.DEPTHApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.BDApsim.CurrentValue=s.BDApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SWApsim.CurrentValue=s.SWApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.CLAYApsim.CurrentValue=s.CLAYApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCKApsim.CurrentValue=s.SLROCKApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARBApsim.CurrentValue=s.SLCARBApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSANDApsim.CurrentValue=s.SLSANDApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILTApsim.CurrentValue=s.SLSILTApsim;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r55 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp);
                if(r55.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp.ValueType)){prc.AddCondition(r55);}
                RangeBasedCondition r56 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp);
                if(r56.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp.ValueType)){prc.AddCondition(r56);}
                RangeBasedCondition r57 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp);
                if(r57.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp.ValueType)){prc.AddCondition(r57);}
                RangeBasedCondition r58 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp);
                if(r58.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp.ValueType)){prc.AddCondition(r58);}
                RangeBasedCondition r59 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp);
                if(r59.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp.ValueType)){prc.AddCondition(r59);}
                RangeBasedCondition r60 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature);
                if(r60.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature.ValueType)){prc.AddCondition(r60);}
                RangeBasedCondition r61 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday);
                if(r61.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday.ValueType)){prc.AddCondition(r61);}
                RangeBasedCondition r62 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday);
                if(r62.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday.ValueType)){prc.AddCondition(r62);}
                RangeBasedCondition r63 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1);
                if(r63.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1.ValueType)){prc.AddCondition(r63);}
                RangeBasedCondition r64 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2);
                if(r64.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2.ValueType)){prc.AddCondition(r64);}
                RangeBasedCondition r65 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3);
                if(r65.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3.ValueType)){prc.AddCondition(r65);}
                RangeBasedCondition r66 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4);
                if(r66.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4.ValueType)){prc.AddCondition(r66);}
                RangeBasedCondition r67 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity);
                if(r67.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity.ValueType)){prc.AddCondition(r67);}
                RangeBasedCondition r68 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance);
                if(r68.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance.ValueType)){prc.AddCondition(r68);}
                RangeBasedCondition r69 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage);
                if(r69.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage.ValueType)){prc.AddCondition(r69);}
                RangeBasedCondition r70 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil);
                if(r70.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil.ValueType)){prc.AddCondition(r70);}
                RangeBasedCondition r71 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance);
                if(r71.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance.ValueType)){prc.AddCondition(r71);}
                RangeBasedCondition r72 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.THICKApsim);
                if(r72.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.THICKApsim.ValueType)){prc.AddCondition(r72);}
                RangeBasedCondition r73 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.DEPTHApsim);
                if(r73.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.DEPTHApsim.ValueType)){prc.AddCondition(r73);}
                RangeBasedCondition r74 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.BDApsim);
                if(r74.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.BDApsim.ValueType)){prc.AddCondition(r74);}
                RangeBasedCondition r75 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SWApsim);
                if(r75.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SWApsim.ValueType)){prc.AddCondition(r75);}
                RangeBasedCondition r76 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.CLAYApsim);
                if(r76.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.CLAYApsim.ValueType)){prc.AddCondition(r76);}
                RangeBasedCondition r77 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCKApsim);
                if(r77.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCKApsim.ValueType)){prc.AddCondition(r77);}
                RangeBasedCondition r78 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARBApsim);
                if(r78.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARBApsim.ValueType)){prc.AddCondition(r78);}
                RangeBasedCondition r79 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSANDApsim);
                if(r79.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSANDApsim.ValueType)){prc.AddCondition(r79);}
                RangeBasedCondition r80 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILTApsim);
                if(r80.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILTApsim.ValueType)){prc.AddCondition(r80);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".model_SoilTempCampbell, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s1,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellRate r,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellAuxiliary a,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.THICK.CurrentValue=ex.THICK;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.BD.CurrentValue=ex.BD;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLCARB.CurrentValue=ex.SLCARB;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.CLAY.CurrentValue=ex.CLAY;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLROCK.CurrentValue=ex.SLROCK;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLSILT.CurrentValue=ex.SLSILT;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLSAND.CurrentValue=ex.SLSAND;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SW.CurrentValue=ex.SW;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.THICKApsim.CurrentValue=s.THICKApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.DEPTHApsim.CurrentValue=s.DEPTHApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.BDApsim.CurrentValue=s.BDApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.T2M.CurrentValue=ex.T2M;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMAX.CurrentValue=ex.TMAX;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMIN.CurrentValue=ex.TMIN;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TAV.CurrentValue=ex.TAV;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.CLAYApsim.CurrentValue=s.CLAYApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SWApsim.CurrentValue=s.SWApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.DOY.CurrentValue=ex.DOY;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.airPressure.CurrentValue=ex.airPressure;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.canopyHeight.CurrentValue=ex.canopyHeight;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SRAD.CurrentValue=ex.SRAD;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ESP.CurrentValue=ex.ESP;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ES.CurrentValue=ex.ES;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.EOAD.CurrentValue=ex.EOAD;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp.CurrentValue=s.soilTemp;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature.CurrentValue=s.newTemperature;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp.CurrentValue=s.minSoilTemp;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp.CurrentValue=s.maxSoilTemp;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp.CurrentValue=s.aveSoilTemp;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp.CurrentValue=s.morningSoilTemp;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1.CurrentValue=s.thermalCondPar1;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2.CurrentValue=s.thermalCondPar2;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3.CurrentValue=s.thermalCondPar3;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4.CurrentValue=s.thermalCondPar4;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity.CurrentValue=s.thermalConductivity;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance.CurrentValue=s.thermalConductance;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage.CurrentValue=s.heatStorage;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil.CurrentValue=s.volSpecHeatSoil;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday.CurrentValue=s.maxTempYesterday;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday.CurrentValue=s.minTempYesterday;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.windSpeed.CurrentValue=ex.windSpeed;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARBApsim.CurrentValue=s.SLCARBApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCKApsim.CurrentValue=s.SLROCKApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILTApsim.CurrentValue=s.SLSILTApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSANDApsim.CurrentValue=s.SLSANDApsim;
                model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance.CurrentValue=s._boundaryLayerConductance;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.THICK);
                if(r1.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.THICK.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.BD);
                if(r2.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.BD.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLCARB);
                if(r3.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLCARB.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.CLAY);
                if(r4.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.CLAY.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLROCK);
                if(r5.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLROCK.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLSILT);
                if(r6.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLSILT.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLSAND);
                if(r7.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SLSAND.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SW);
                if(r8.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SW.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.THICKApsim);
                if(r9.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.THICKApsim.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.DEPTHApsim);
                if(r10.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.DEPTHApsim.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.BDApsim);
                if(r11.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.BDApsim.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.T2M);
                if(r12.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.T2M.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMAX);
                if(r13.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMAX.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMIN);
                if(r14.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMIN.ValueType)){prc.AddCondition(r14);}
                RangeBasedCondition r15 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TAV);
                if(r15.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TAV.ValueType)){prc.AddCondition(r15);}
                RangeBasedCondition r16 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.CLAYApsim);
                if(r16.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.CLAYApsim.ValueType)){prc.AddCondition(r16);}
                RangeBasedCondition r17 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SWApsim);
                if(r17.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SWApsim.ValueType)){prc.AddCondition(r17);}
                RangeBasedCondition r18 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.DOY);
                if(r18.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.DOY.ValueType)){prc.AddCondition(r18);}
                RangeBasedCondition r19 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.airPressure);
                if(r19.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.airPressure.ValueType)){prc.AddCondition(r19);}
                RangeBasedCondition r20 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.canopyHeight);
                if(r20.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.canopyHeight.ValueType)){prc.AddCondition(r20);}
                RangeBasedCondition r21 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SRAD);
                if(r21.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SRAD.ValueType)){prc.AddCondition(r21);}
                RangeBasedCondition r22 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ESP);
                if(r22.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ESP.ValueType)){prc.AddCondition(r22);}
                RangeBasedCondition r23 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ES);
                if(r23.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ES.ValueType)){prc.AddCondition(r23);}
                RangeBasedCondition r24 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.EOAD);
                if(r24.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.EOAD.ValueType)){prc.AddCondition(r24);}
                RangeBasedCondition r25 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp);
                if(r25.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp.ValueType)){prc.AddCondition(r25);}
                RangeBasedCondition r26 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature);
                if(r26.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature.ValueType)){prc.AddCondition(r26);}
                RangeBasedCondition r27 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp);
                if(r27.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp.ValueType)){prc.AddCondition(r27);}
                RangeBasedCondition r28 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp);
                if(r28.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp.ValueType)){prc.AddCondition(r28);}
                RangeBasedCondition r29 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp);
                if(r29.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp.ValueType)){prc.AddCondition(r29);}
                RangeBasedCondition r30 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp);
                if(r30.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp.ValueType)){prc.AddCondition(r30);}
                RangeBasedCondition r31 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1);
                if(r31.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1.ValueType)){prc.AddCondition(r31);}
                RangeBasedCondition r32 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2);
                if(r32.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2.ValueType)){prc.AddCondition(r32);}
                RangeBasedCondition r33 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3);
                if(r33.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3.ValueType)){prc.AddCondition(r33);}
                RangeBasedCondition r34 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4);
                if(r34.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4.ValueType)){prc.AddCondition(r34);}
                RangeBasedCondition r35 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity);
                if(r35.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity.ValueType)){prc.AddCondition(r35);}
                RangeBasedCondition r36 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance);
                if(r36.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance.ValueType)){prc.AddCondition(r36);}
                RangeBasedCondition r37 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage);
                if(r37.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage.ValueType)){prc.AddCondition(r37);}
                RangeBasedCondition r38 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil);
                if(r38.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil.ValueType)){prc.AddCondition(r38);}
                RangeBasedCondition r39 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday);
                if(r39.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday.ValueType)){prc.AddCondition(r39);}
                RangeBasedCondition r40 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday);
                if(r40.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday.ValueType)){prc.AddCondition(r40);}
                RangeBasedCondition r41 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.windSpeed);
                if(r41.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.windSpeed.ValueType)){prc.AddCondition(r41);}
                RangeBasedCondition r42 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARBApsim);
                if(r42.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARBApsim.ValueType)){prc.AddCondition(r42);}
                RangeBasedCondition r43 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCKApsim);
                if(r43.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCKApsim.ValueType)){prc.AddCondition(r43);}
                RangeBasedCondition r44 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILTApsim);
                if(r44.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILTApsim.ValueType)){prc.AddCondition(r44);}
                RangeBasedCondition r45 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSANDApsim);
                if(r45.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSANDApsim.ValueType)){prc.AddCondition(r45);}
                RangeBasedCondition r46 = new RangeBasedCondition(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance);
                if(r46.ApplicableVarInfoValueTypes.Contains( model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance.ValueType)){prc.AddCondition(r46);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("NLAYR")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("CONSTANT_TEMPdepth")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("TAMP")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("XLAT")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SALB")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("instrumentHeight")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("boundaryLayerConductanceSource")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("netRadiationSource")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".model_SoilTempCampbell, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s1,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellRate r,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellAuxiliary a,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component model_SoilTempCampbell, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        public void Init(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s, model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s1, model_SoilTempCampbell.DomainClass.model_SoilTempCampbellRate r, model_SoilTempCampbell.DomainClass.model_SoilTempCampbellAuxiliary a, model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous ex)
        {
            double[] THICK = ex.THICK = new double[NLAYR];
            double[] BD = ex.BD = new double[NLAYR];
            double[] SLCARB = ex.SLCARB = new double[NLAYR];
            double[] CLAY = ex.CLAY = new double[NLAYR];
            double[] SLROCK = ex.SLROCK = new double[NLAYR];
            double[] SLSILT = ex.SLSILT = new double[NLAYR];
            double[] SLSAND = ex.SLSAND = new double[NLAYR];
            double[] SW = ex.SW = new double[NLAYR];
            double T2M = ex.T2M;
            double TMAX = ex.TMAX;
            double TMIN = ex.TMIN;
            double TAV = ex.TAV;
            int DOY = ex.DOY;
            double airPressure = ex.airPressure;
            double canopyHeight = ex.canopyHeight;
            double SRAD = ex.SRAD;
            double ESP = ex.ESP;
            double ES = ex.ES;
            double EOAD = ex.EOAD;
            double windSpeed = ex.windSpeed;
            double[] THICKApsim ;
            double[] DEPTHApsim =  new double [NLAYR];
            double[] BDApsim ;
            double[] CLAYApsim ;
            double[] SWApsim ;
            double[] soilTemp =  new double [NLAYR];
            double[] newTemperature =  new double [NLAYR];
            double[] minSoilTemp =  new double [NLAYR];
            double[] maxSoilTemp =  new double [NLAYR];
            double[] aveSoilTemp =  new double [NLAYR];
            double[] morningSoilTemp =  new double [NLAYR];
            double[] thermalCondPar1 =  new double [NLAYR];
            double[] thermalCondPar2 =  new double [NLAYR];
            double[] thermalCondPar3 =  new double [NLAYR];
            double[] thermalCondPar4 =  new double [NLAYR];
            double[] thermalConductivity =  new double [NLAYR];
            double[] thermalConductance =  new double [NLAYR];
            double[] heatStorage =  new double [NLAYR];
            double[] volSpecHeatSoil =  new double [NLAYR];
            double maxTempYesterday;
            double minTempYesterday;
            double[] SLCARBApsim =  new double [NLAYR];
            double[] SLROCKApsim =  new double [NLAYR];
            double[] SLSILTApsim =  new double [NLAYR];
            double[] SLSANDApsim =  new double [NLAYR];
            double _boundaryLayerConductance;
            DEPTHApsim = new double[NLAYR];
            soilTemp = new double[NLAYR];
            newTemperature = new double[NLAYR];
            minSoilTemp = new double[NLAYR];
            maxSoilTemp = new double[NLAYR];
            aveSoilTemp = new double[NLAYR];
            morningSoilTemp = new double[NLAYR];
            thermalCondPar1 = new double[NLAYR];
            thermalCondPar2 = new double[NLAYR];
            thermalCondPar3 = new double[NLAYR];
            thermalCondPar4 = new double[NLAYR];
            thermalConductivity = new double[NLAYR];
            thermalConductance = new double[NLAYR];
            heatStorage = new double[NLAYR];
            volSpecHeatSoil = new double[NLAYR];
            maxTempYesterday = 0.0;
            minTempYesterday = 0.0;
            SLCARBApsim = new double[NLAYR];
            SLROCKApsim = new double[NLAYR];
            SLSILTApsim = new double[NLAYR];
            SLSANDApsim = new double[NLAYR];
            _boundaryLayerConductance = 0.0;
            double[] heatCapacity ;
            double soilRoughnessHeight;
            double defaultInstrumentHeight;
            double AltitudeMetres;
            int NUM_PHANTOM_NODES;
            int AIRnode;
            int SURFACEnode;
            int TOPSOILnode;
            double sumThickness;
            double BelowProfileDepth;
            double thicknessForPhantomNodes;
            double ave_temp;
            int i;
            int numNodes;
            int firstPhantomNode;
            int layer;
            int node;
            double surfaceT;
            soilRoughnessHeight = 57.0;
            defaultInstrumentHeight = 1.2;
            AltitudeMetres = 18.0;
            NUM_PHANTOM_NODES = 5;
            AIRnode = 0;
            SURFACEnode = 1;
            TOPSOILnode = 2;
            if (instrumentHeight > 0.00001)
            {
                instrumentHeight = instrumentHeight;
            }
            else
            {
                instrumentHeight = defaultInstrumentHeight;
            }
            numNodes = NLAYR + NUM_PHANTOM_NODES;
            for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){THICKApsim[i] = 0.0;}
            for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
            {
                THICKApsim[layer] = THICK[layer - 1];
            }
            sumThickness = 0.0;
            for (i=1 ; i!=NLAYR + 1 ; i+=1)
            {
                sumThickness = sumThickness + THICKApsim[i];
            }
            BelowProfileDepth = Math.Max(CONSTANT_TEMPdepth - sumThickness, 1000.0);
            thicknessForPhantomNodes = BelowProfileDepth * 2.0 / NUM_PHANTOM_NODES;
            firstPhantomNode = NLAYR;
            for (i=firstPhantomNode ; i!=firstPhantomNode + NUM_PHANTOM_NODES ; i+=1)
            {
                THICKApsim[i] = thicknessForPhantomNodes;
            }
            for (var i = 0; i < numNodes + 1 + 1; i++){DEPTHApsim[i] = 0.0;}
            DEPTHApsim[AIRnode] = 0.0;
            DEPTHApsim[SURFACEnode] = 0.0;
            DEPTHApsim[TOPSOILnode] = 0.5 * THICKApsim[1] / 1000.0;
            for (node=TOPSOILnode ; node!=numNodes + 1 ; node+=1)
            {
                sumThickness = 0.0;
                for (i=1 ; i!=node ; i+=1)
                {
                    sumThickness = sumThickness + THICKApsim[i];
                }
                DEPTHApsim[node + 1] = (sumThickness + (0.5 * THICKApsim[node])) / 1000.0;
            }
            for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){BDApsim[i] = 0.0;}
            for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
            {
                BDApsim[layer] = BD[layer - 1];
            }
            BDApsim[numNodes] = BDApsim[NLAYR];
            for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
            {
                BDApsim[layer] = BDApsim[NLAYR];
            }
            for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){SWApsim[i] = 0.0;}
            for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
            {
                SWApsim[layer] = SW[layer - 1];
            }
            for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
            {
                SWApsim[layer] = SWApsim[(NLAYR - 1)] * THICKApsim[(NLAYR - 1)] / THICKApsim[NLAYR];
            }
            for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){SLCARBApsim[i] = 0.0;}
            for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
            {
                SLCARBApsim[layer] = SLCARB[layer - 1];
            }
            for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
            {
                SLCARBApsim[layer] = SLCARBApsim[NLAYR];
            }
            for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){SLROCKApsim[i] = 0.0;}
            for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
            {
                SLROCKApsim[layer] = SLROCK[layer - 1];
            }
            for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
            {
                SLROCKApsim[layer] = SLROCKApsim[NLAYR];
            }
            for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){SLSANDApsim[i] = 0.0;}
            for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
            {
                SLSANDApsim[layer] = SLSAND[layer - 1];
            }
            for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
            {
                SLSANDApsim[layer] = SLSANDApsim[NLAYR];
            }
            for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){SLSILTApsim[i] = 0.0;}
            for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
            {
                SLSILTApsim[layer] = SLSILT[layer - 1];
            }
            for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
            {
                SLSILTApsim[layer] = SLSILTApsim[NLAYR];
            }
            for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){CLAYApsim[i] = 0.0;}
            for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
            {
                CLAYApsim[layer] = CLAY[layer - 1];
            }
            for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
            {
                CLAYApsim[layer] = CLAYApsim[NLAYR];
            }
            for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){maxSoilTemp[i] = 0.0;}
            for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){minSoilTemp[i] = 0.0;}
            for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){aveSoilTemp[i] = 0.0;}
            for (var i = 0; i < numNodes + 1; i++){volSpecHeatSoil[i] = 0.0;}
            for (var i = 0; i < numNodes + 1 + 1; i++){soilTemp[i] = 0.0;}
            for (var i = 0; i < numNodes + 1 + 1; i++){morningSoilTemp[i] = 0.0;}
            for (var i = 0; i < numNodes + 1 + 1; i++){newTemperature[i] = 0.0;}
            for (var i = 0; i < numNodes + 1; i++){thermalConductivity[i] = 0.0;}
            for (var i = 0; i < numNodes + 1; i++){heatStorage[i] = 0.0;}
            for (var i = 0; i < numNodes + 1 + 1; i++){thermalConductance[i] = 0.0;}
            doThermalConductivityCoeffs(NLAYR, numNodes, BDApsim, CLAYApsim, out thermalCondPar1, out thermalCondPar2, out thermalCondPar3, out thermalCondPar4);
            newTemperature = CalcSoilTemp(THICKApsim, TAV, TAMP, DOY, XLAT, numNodes);
            instrumentHeight = Math.Max(instrumentHeight, canopyHeight + 0.5);
            soilTemp = CalcSoilTemp(THICKApsim, TAV, TAMP, DOY, XLAT, numNodes);
            soilTemp[AIRnode] = T2M;
            surfaceT = (1.0 - SALB) * (T2M + ((TMAX - T2M) * Math.Sqrt(Math.Max(SRAD, 0.1) * 23.8846 / 800.0))) + (SALB * T2M);
            soilTemp[SURFACEnode] = surfaceT;
            for (i=numNodes + 1 ; i!=soilTemp.Length ; i+=1)
            {
                soilTemp[i] = TAV;
            }
            for (i=0 ; i!=soilTemp.Length ; i+=1)
            {
                newTemperature[i] = soilTemp[i];
            }
            maxTempYesterday = TMAX;
            minTempYesterday = TMIN;
            s.THICKApsim= THICKApsim;
            s.DEPTHApsim= DEPTHApsim;
            s.BDApsim= BDApsim;
            s.CLAYApsim= CLAYApsim;
            s.SWApsim= SWApsim;
            s.soilTemp= soilTemp;
            s.newTemperature= newTemperature;
            s.minSoilTemp= minSoilTemp;
            s.maxSoilTemp= maxSoilTemp;
            s.aveSoilTemp= aveSoilTemp;
            s.morningSoilTemp= morningSoilTemp;
            s.thermalCondPar1= thermalCondPar1;
            s.thermalCondPar2= thermalCondPar2;
            s.thermalCondPar3= thermalCondPar3;
            s.thermalCondPar4= thermalCondPar4;
            s.thermalConductivity= thermalConductivity;
            s.thermalConductance= thermalConductance;
            s.heatStorage= heatStorage;
            s.volSpecHeatSoil= volSpecHeatSoil;
            s.maxTempYesterday= maxTempYesterday;
            s.minTempYesterday= minTempYesterday;
            s.SLCARBApsim= SLCARBApsim;
            s.SLROCKApsim= SLROCKApsim;
            s.SLSILTApsim= SLSILTApsim;
            s.SLSANDApsim= SLSANDApsim;
            s._boundaryLayerConductance= _boundaryLayerConductance;
        }

        private void CalculateModel(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s, model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s1, model_SoilTempCampbell.DomainClass.model_SoilTempCampbellRate r, model_SoilTempCampbell.DomainClass.model_SoilTempCampbellAuxiliary a, model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous ex)
        {
            double[] THICK = ex.THICK;
            double[] BD = ex.BD;
            double[] SLCARB = ex.SLCARB;
            double[] CLAY = ex.CLAY;
            double[] SLROCK = ex.SLROCK;
            double[] SLSILT = ex.SLSILT;
            double[] SLSAND = ex.SLSAND;
            double[] SW = ex.SW;
            double[] THICKApsim = s.THICKApsim;
            double[] DEPTHApsim = s.DEPTHApsim;
            double[] BDApsim = s.BDApsim;
            double T2M = ex.T2M;
            double TMAX = ex.TMAX;
            double TMIN = ex.TMIN;
            double TAV = ex.TAV;
            double[] CLAYApsim = s.CLAYApsim;
            double[] SWApsim = s.SWApsim;
            int DOY = ex.DOY;
            double airPressure = ex.airPressure;
            double canopyHeight = ex.canopyHeight;
            double SRAD = ex.SRAD;
            double ESP = ex.ESP;
            double ES = ex.ES;
            double EOAD = ex.EOAD;
            double[] soilTemp = s.soilTemp;
            double[] newTemperature = s.newTemperature;
            double[] minSoilTemp = s.minSoilTemp;
            double[] maxSoilTemp = s.maxSoilTemp;
            double[] aveSoilTemp = s.aveSoilTemp;
            double[] morningSoilTemp = s.morningSoilTemp;
            double[] thermalCondPar1 = s.thermalCondPar1;
            double[] thermalCondPar2 = s.thermalCondPar2;
            double[] thermalCondPar3 = s.thermalCondPar3;
            double[] thermalCondPar4 = s.thermalCondPar4;
            double[] thermalConductivity = s.thermalConductivity;
            double[] thermalConductance = s.thermalConductance;
            double[] heatStorage = s.heatStorage;
            double[] volSpecHeatSoil = s.volSpecHeatSoil;
            double maxTempYesterday = s.maxTempYesterday;
            double minTempYesterday = s.minTempYesterday;
            double windSpeed = ex.windSpeed;
            double[] SLCARBApsim = s.SLCARBApsim;
            double[] SLROCKApsim = s.SLROCKApsim;
            double[] SLSILTApsim = s.SLSILTApsim;
            double[] SLSANDApsim = s.SLSANDApsim;
            double _boundaryLayerConductance = s._boundaryLayerConductance;
            int AIRnode;
            int SURFACEnode;
            int TOPSOILnode;
            int ITERATIONSperDAY;
            int NUM_PHANTOM_NODES;
            double DAYhrs;
            double MIN2SEC;
            double HR2MIN;
            double SEC2HR;
            double DAYmins;
            double DAYsecs;
            double PA2HPA;
            double MJ2J;
            double J2MJ;
            double tempStepSec;
            int BoundaryLayerConductanceIterations;
            int numNodes;
            string[] soilConstituentNames ;
            int timeStepIteration;
            double netRadiation;
            double constantBoundaryLayerConductance;
            double precision;
            double cva;
            double cloudFr;
            double[] solarRadn ;
            int layer;
            double timeOfDaySecs;
            double airTemperature;
            int iteration;
            double tMean;
            double internalTimeStep;
            AIRnode = 0;
            SURFACEnode = 1;
            TOPSOILnode = 2;
            ITERATIONSperDAY = 48;
            NUM_PHANTOM_NODES = 5;
            DAYhrs = 24.0;
            MIN2SEC = 60.0;
            HR2MIN = 60.0;
            SEC2HR = 1.0 / (HR2MIN * MIN2SEC);
            DAYmins = DAYhrs * HR2MIN;
            DAYsecs = DAYmins * MIN2SEC;
            PA2HPA = 1.0 / 100.0;
            MJ2J = 1000000.0;
            J2MJ = 1.0 / MJ2J;
            tempStepSec = 24.0 * 60.0 * 60.0;
            BoundaryLayerConductanceIterations = 1;
            numNodes = NLAYR + NUM_PHANTOM_NODES;
            soilConstituentNames = new string[]{"Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"};
            timeStepIteration = 1;
            constantBoundaryLayerConductance = 20.0;
            layer = 0;
            cva = 0.0;
            cloudFr = 0.0;
            for (var i = 0; i < 49; i++){solarRadn[i] = 0.0;}
            doNetRadiation(ref solarRadn, ref cloudFr, ref cva, ITERATIONSperDAY, DOY, SRAD, TMIN, XLAT);
            minSoilTemp = Zero(minSoilTemp);
            maxSoilTemp = Zero(maxSoilTemp);
            aveSoilTemp = Zero(aveSoilTemp);
            _boundaryLayerConductance = 0.0;
            internalTimeStep = tempStepSec / (double)(ITERATIONSperDAY);
            volSpecHeatSoil = doVolumetricSpecificHeat(volSpecHeatSoil, SWApsim, numNodes, soilConstituentNames, THICKApsim, DEPTHApsim);
            thermalConductivity = doThermConductivity(SWApsim, SLCARBApsim, SLROCKApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, BDApsim, thermalConductivity, THICKApsim, DEPTHApsim, numNodes, soilConstituentNames);
            for (timeStepIteration=1 ; timeStepIteration!=ITERATIONSperDAY + 1 ; timeStepIteration+=1)
            {
                timeOfDaySecs = internalTimeStep * (double)(timeStepIteration);
                if (tempStepSec < (24.0 * 60.0 * 60.0))
                {
                    tMean = T2M;
                }
                else
                {
                    tMean = InterpTemp(timeOfDaySecs * SEC2HR, TMAX, TMIN, T2M, maxTempYesterday, minTempYesterday);
                }
                newTemperature[AIRnode] = tMean;
                netRadiation = RadnNetInterpolate(internalTimeStep, solarRadn[timeStepIteration], cloudFr, cva, ESP, EOAD, tMean, SALB, soilTemp);
                if (boundaryLayerConductanceSource == "constant")
                {
                    thermalConductivity[AIRnode] = constantBoundaryLayerConductance;
                }
                else if ( boundaryLayerConductanceSource == "calc")
                {
                    thermalConductivity[AIRnode] = boundaryLayerConductanceF(newTemperature, tMean, ESP, EOAD, airPressure, canopyHeight, windSpeed, instrumentHeight);
                    for (iteration=1 ; iteration!=BoundaryLayerConductanceIterations + 1 ; iteration+=1)
                    {
                        newTemperature = doThomas(newTemperature, soilTemp, thermalConductivity, thermalConductance, DEPTHApsim, volSpecHeatSoil, internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource);
                        thermalConductivity[AIRnode] = boundaryLayerConductanceF(newTemperature, tMean, ESP, EOAD, airPressure, canopyHeight, windSpeed, instrumentHeight);
                    }
                }
                newTemperature = doThomas(newTemperature, soilTemp, thermalConductivity, thermalConductance, DEPTHApsim, volSpecHeatSoil, internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource);
                doUpdate(newTemperature, ref soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp, thermalConductivity, ref _boundaryLayerConductance, ITERATIONSperDAY, timeOfDaySecs, internalTimeStep, numNodes);
                precision = Math.Min(timeOfDaySecs, 5.0 * 3600.0) * 0.0001;
                if (Math.Abs(timeOfDaySecs - (5.0 * 3600.0)) <= precision)
                {
                    for (layer=0 ; layer!=soilTemp.Length ; layer+=1)
                    {
                        morningSoilTemp[layer] = soilTemp[layer];
                    }
                }
            }
            minTempYesterday = TMIN;
            maxTempYesterday = TMAX;
            s.THICKApsim= THICKApsim;
            s.DEPTHApsim= DEPTHApsim;
            s.BDApsim= BDApsim;
            s.CLAYApsim= CLAYApsim;
            s.SWApsim= SWApsim;
            s.soilTemp= soilTemp;
            s.newTemperature= newTemperature;
            s.minSoilTemp= minSoilTemp;
            s.maxSoilTemp= maxSoilTemp;
            s.aveSoilTemp= aveSoilTemp;
            s.morningSoilTemp= morningSoilTemp;
            s.thermalCondPar1= thermalCondPar1;
            s.thermalCondPar2= thermalCondPar2;
            s.thermalCondPar3= thermalCondPar3;
            s.thermalCondPar4= thermalCondPar4;
            s.thermalConductivity= thermalConductivity;
            s.thermalConductance= thermalConductance;
            s.heatStorage= heatStorage;
            s.volSpecHeatSoil= volSpecHeatSoil;
            s.maxTempYesterday= maxTempYesterday;
            s.minTempYesterday= minTempYesterday;
            s.SLCARBApsim= SLCARBApsim;
            s.SLROCKApsim= SLROCKApsim;
            s.SLSILTApsim= SLSILTApsim;
            s.SLSANDApsim= SLSANDApsim;
            s._boundaryLayerConductance= _boundaryLayerConductance;
        }

        public static Tuple<double[],double,double>  doNetRadiation(double[] solarRadn, double cloudFr, double cva, int ITERATIONSperDAY, int doy, double rad, double tmin, double latitude)
        {
            double piVal = 3.141592653589793;
            double TSTEPS2RAD = 1.0;
            double SOLARconst = 1.0;
            double solarDeclination = 1.0;
            double[] m1 ;
            for (var i = 0; i < ITERATIONSperDAY + 1; i++){m1[i] = 0.0;}
            TSTEPS2RAD = Divide(2.0 * piVal, (double)(ITERATIONSperDAY), 0.0);
            SOLARconst = 1360.0;
            solarDeclination = 0.3985 * Math.Sin((4.869 + (doy * 2.0 * piVal / 365.25) + (0.03345 * Math.Sin((6.224 + (doy * 2.0 * piVal / 365.25))))));
            double cD = Math.Sqrt(1.0 - (solarDeclination * solarDeclination));
            double m1Tot = 0.0;
            double psr;
            int timestepNumber = 1;
            double fr;
            double scalar;
            for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
            {
                m1[timestepNumber] = (solarDeclination * Math.Sin(latitude * piVal / 180.0) + (cD * Math.Cos(latitude * piVal / 180.0) * Math.Cos(TSTEPS2RAD * ((double)(timestepNumber) - ((double)(ITERATIONSperDAY) / 2.0))))) * 24.0 / (double)(ITERATIONSperDAY);
                if (m1[timestepNumber] > 0.0)
                {
                    m1Tot = m1Tot + m1[timestepNumber];
                }
                else
                {
                    m1[timestepNumber] = 0.0;
                }
            }
            psr = m1Tot * SOLARconst * 3600.0 / 1000000.0;
            fr = Divide(Math.Max(rad, 0.1), psr, 0.0);
            cloudFr = 2.33 - (3.33 * fr);
            cloudFr = Math.Min(Math.Max(cloudFr, 0.0), 1.0);
            scalar = Math.Max(rad, 0.1);
            for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
            {
                solarRadn[timestepNumber] = scalar * Divide(m1[timestepNumber], m1Tot, 0.0);
            }
            double kelvinTemp = kelvinT(tmin);
            cva = Math.Exp((31.3716 - (6014.79 / kelvinTemp) - (0.00792495 * kelvinTemp))) / kelvinTemp;
            return Tuple.Create(solarRadn, cloudFr, cva);
        }

        public static double Divide(double val1, double val2, double errVal)
        {
            double returnValue = errVal;
            if (val2 != 0.0)
            {
                returnValue = val1 / val2;
            }
            return returnValue;
        }

        public static double kelvinT(double celciusT)
        {
            double ZEROTkelvin = 273.18;
            double res = celciusT + ZEROTkelvin;
            return res;
        }

        public static double[] Zero(double[] arr)
        {
            int i = 0;
            for (i=0 ; i!=arr.Length ; i+=1)
            {
                arr[i] = 0.0d;
            }
            return arr;
        }

        public static double[] doVolumetricSpecificHeat(double[] volSpecLayer, double[] soilW, int numNodes, string[] constituents, double[] THICKApsim, double[] DEPTHApsim)
        {
            double[] volSpecHeatSoil ;
            for (var i = 0; i < numNodes + 1; i++){volSpecHeatSoil[i] = 0.0;}
            int node;
            int constituent;
            for (node=1 ; node!=numNodes + 1 ; node+=1)
            {
                volSpecHeatSoil[node] = 0.0;
                for (constituent=0 ; constituent!=constituents.Length ; constituent+=1)
                {
                    volSpecHeatSoil[node] = volSpecHeatSoil[node] + (volumetricSpecificHeat(constituents[constituent]) * 1000000.0 * soilW[node]);
                }
            }
            volSpecLayer = mapLayer2Node(volSpecHeatSoil, volSpecLayer, THICKApsim, DEPTHApsim, numNodes);
            return volSpecLayer;
        }

        public static double volumetricSpecificHeat(string name)
        {
            double specificHeatRocks = 7.7;
            double specificHeatOM = 0.25;
            double specificHeatSand = 7.7;
            double specificHeatSilt = 2.74;
            double specificHeatClay = 2.92;
            double specificHeatWater = 0.57;
            double specificHeatIce = 2.18;
            double specificHeatAir = 0.025;
            double res = 0.0;
            if (name == "Rocks")
            {
                res = specificHeatRocks;
            }
            else if ( name == "OrganicMatter")
            {
                res = specificHeatOM;
            }
            else if ( name == "Sand")
            {
                res = specificHeatSand;
            }
            else if ( name == "Silt")
            {
                res = specificHeatSilt;
            }
            else if ( name == "Clay")
            {
                res = specificHeatClay;
            }
            else if ( name == "Water")
            {
                res = specificHeatWater;
            }
            else if ( name == "Ice")
            {
                res = specificHeatIce;
            }
            else if ( name == "Air")
            {
                res = specificHeatAir;
            }
            return res;
        }

        public static double[] mapLayer2Node(double[] layerArray, double[] nodeArray, double[] THICKApsim, double[] DEPTHApsim, int numNodes)
        {
            int SURFACEnode = 1;
            double depthLayerAbove;
            int node = 0;
            int i = 0;
            int layer;
            double d1;
            double d2;
            double dSum;
            for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
            {
                layer = node - 1;
                depthLayerAbove = 0.0;
                if (layer >= 1)
                {
                    for (i=1 ; i!=layer + 1 ; i+=1)
                    {
                        depthLayerAbove = depthLayerAbove + THICKApsim[i];
                    }
                }
                d1 = depthLayerAbove - (DEPTHApsim[node] * 1000.0);
                d2 = DEPTHApsim[(node + 1)] * 1000.0 - depthLayerAbove;
                dSum = d1 + d2;
                nodeArray[node] = Divide(layerArray[layer] * d1, dSum, 0.0) + Divide(layerArray[(layer + 1)] * d2, dSum, 0.0);
            }
            return nodeArray;
        }

        public static double[] doThermConductivity(double[] soilW, double[] SLCARBApsim, double[] SLROCKApsim, double[] SLSANDApsim, double[] SLSILTApsim, double[] CLAYApsim, double[] BDApsim, double[] thermalConductivity, double[] THICKApsim, double[] DEPTHApsim, int numNodes, string[] constituents)
        {
            double[] thermCondLayers ;
            for (var i = 0; i < numNodes + 1; i++){thermCondLayers[i] = 0.0;}
            int node = 1;
            int constituent = 1;
            double temp;
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
                for (constituent=0 ; constituent!=constituents.Length ; constituent+=1)
                {
                    shapeFactorConstituent = shapeFactor(constituents[constituent], SLROCKApsim, SLCARBApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, soilW, BDApsim, node);
                    thermalConductanceConstituent = ThermalConductance(constituents[constituent]);
                    thermalConductanceWater = ThermalConductance("Water");
                    k = 2.0 / 3.0 * Math.Pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0))), -1) + (1.0 / 3.0 * Math.Pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0) * (1.0 - (2.0 * shapeFactorConstituent)))), -1));
                    numerator = numerator + (thermalConductanceConstituent * soilW[node] * k);
                    denominator = denominator + (soilW[node] * k);
                }
                thermCondLayers[node] = numerator / denominator;
            }
            thermalConductivity = mapLayer2Node(thermCondLayers, thermalConductivity, THICKApsim, DEPTHApsim, numNodes);
            return thermalConductivity;
        }

        public static double shapeFactor(string name, double[] SLROCKApsim, double[] SLCARBApsim, double[] SLSANDApsim, double[] SLSILTApsim, double[] CLAYApsim, double[] SWApsim, double[] BDApsim, int layer)
        {
            double shapeFactorRocks = 0.182;
            double shapeFactorOM = 0.5;
            double shapeFactorSand = 0.182;
            double shapeFactorSilt = 0.125;
            double shapeFactorClay = 0.007755;
            double shapeFactorWater = 1.0;
            double result = 0.0;
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
                result = 0.333 - (0.333 * 0.0 / (volumetricFractionWater(SWApsim, SLCARBApsim, BDApsim, layer) + 0.0 + volumetricFractionAir(SLROCKApsim, SLCARBApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, SWApsim, BDApsim, layer)));
                return result;
            }
            else if ( name == "Air")
            {
                result = 0.333 - (0.333 * volumetricFractionAir(SLROCKApsim, SLCARBApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, SWApsim, BDApsim, layer) / (volumetricFractionWater(SWApsim, SLCARBApsim, BDApsim, layer) + 0.0 + volumetricFractionAir(SLROCKApsim, SLCARBApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, SWApsim, BDApsim, layer)));
                return result;
            }
            else if ( name == "Minerals")
            {
                result = shapeFactorRocks * volumetricFractionRocks(SLROCKApsim, layer) + (shapeFactorSand * volumetricFractionSand(SLSANDApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer)) + (shapeFactorSilt * volumetricFractionSilt(SLSILTApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer)) + (shapeFactorClay * volumetricFractionClay(CLAYApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer));
            }
            result = volumetricSpecificHeat(name);
            return result;
        }

        public static double ThermalConductance(string name)
        {
            double thermal_conductance_rocks = 0.182;
            double thermal_conductance_om = 2.50;
            double thermal_conductance_sand = 0.182;
            double thermal_conductance_silt = 2.39;
            double thermal_conductance_clay = 1.39;
            double thermal_conductance_water = 4.18;
            double thermal_conductance_ice = 1.73;
            double thermal_conductance_air = 0.0012;
            double result = 0.0;
            if (name == "Rocks")
            {
                result = thermal_conductance_rocks;
            }
            else if ( name == "OrganicMatter")
            {
                result = thermal_conductance_om;
            }
            else if ( name == "Sand")
            {
                result = thermal_conductance_sand;
            }
            else if ( name == "Silt")
            {
                result = thermal_conductance_silt;
            }
            else if ( name == "Clay")
            {
                result = thermal_conductance_clay;
            }
            else if ( name == "Water")
            {
                result = thermal_conductance_water;
            }
            else if ( name == "Ice")
            {
                result = thermal_conductance_ice;
            }
            else if ( name == "Air")
            {
                result = thermal_conductance_air;
            }
            result = volumetricSpecificHeat(name);
            return result;
        }

        public static double[] mapLayer2Node(double[] layerArray, double[] nodeArray, double[] THICKApsim, double[] DEPTHApsim, int numNodes)
        {
            int SURFACEnode = 1;
            double depthLayerAbove;
            int node = 0;
            int i = 0;
            int layer;
            double d1;
            double d2;
            double dSum;
            for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
            {
                layer = node - 1;
                depthLayerAbove = 0.0;
                if (layer >= 1)
                {
                    for (i=1 ; i!=layer + 1 ; i+=1)
                    {
                        depthLayerAbove = depthLayerAbove + THICKApsim[i];
                    }
                }
                d1 = depthLayerAbove - (DEPTHApsim[node] * 1000.0);
                d2 = DEPTHApsim[(node + 1)] * 1000.0 - depthLayerAbove;
                dSum = d1 + d2;
                nodeArray[node] = Divide(layerArray[layer] * d1, dSum, 0.0) + Divide(layerArray[(layer + 1)] * d2, dSum, 0.0);
            }
            return nodeArray;
        }

        public static double volumetricFractionWater(double[] SWApsim, double[] SLCARBApsim, double[] BDApsim, int layer)
        {
            double res = (1.0 - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer)) * SWApsim[layer];
            return res;
        }

        public static double volumetricFractionAir(double[] SLROCKApsim, double[] SLCARBApsim, double[] SLSANDApsim, double[] SLSILTApsim, double[] CLAYApsim, double[] SWApsim, double[] BDApsim, int layer)
        {
            double res = 1.0 - volumetricFractionRocks(SLROCKApsim, layer) - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionSand(SLSANDApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer) - volumetricFractionSilt(SLSILTApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer) - volumetricFractionClay(CLAYApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer) - volumetricFractionWater(SWApsim, SLCARBApsim, BDApsim, layer) - 0.0;
            return res;
        }

        public static double volumetricFractionRocks(double[] SLROCKApsim, int layer)
        {
            double res = SLROCKApsim[layer] / 100.0;
            return res;
        }

        public static double volumetricFractionSand(double[] SLSANDApsim, double[] SLROCKApsim, double[] SLCARBApsim, double[] BDApsim, int layer)
        {
            double ps = 2.63;
            double res = (1.0 - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionRocks(SLROCKApsim, layer)) * SLSANDApsim[layer] / 100.0 * BDApsim[layer] / ps;
            return res;
        }

        public static double volumetricFractionSilt(double[] SLSILTApsim, double[] SLROCKApsim, double[] SLCARBApsim, double[] BDApsim, int layer)
        {
            double ps = 2.63;
            double res = (1.0 - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionRocks(SLROCKApsim, layer)) * SLSILTApsim[layer] / 100.0 * BDApsim[layer] / ps;
            return res;
        }

        public static double volumetricFractionClay(double[] CLAYApsim, double[] SLROCKApsim, double[] SLCARBApsim, double[] BDApsim, int layer)
        {
            double ps = 2.63;
            double res = (1.0 - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionRocks(SLROCKApsim, layer)) * CLAYApsim[layer] / 100.0 * BDApsim[layer] / ps;
            return res;
        }

        public static double volumetricSpecificHeat(string name)
        {
            double specificHeatRocks = 7.7;
            double specificHeatOM = 0.25;
            double specificHeatSand = 7.7;
            double specificHeatSilt = 2.74;
            double specificHeatClay = 2.92;
            double specificHeatWater = 0.57;
            double specificHeatIce = 2.18;
            double specificHeatAir = 0.025;
            double res = 0.0;
            if (name == "Rocks")
            {
                res = specificHeatRocks;
            }
            else if ( name == "OrganicMatter")
            {
                res = specificHeatOM;
            }
            else if ( name == "Sand")
            {
                res = specificHeatSand;
            }
            else if ( name == "Silt")
            {
                res = specificHeatSilt;
            }
            else if ( name == "Clay")
            {
                res = specificHeatClay;
            }
            else if ( name == "Water")
            {
                res = specificHeatWater;
            }
            else if ( name == "Ice")
            {
                res = specificHeatIce;
            }
            else if ( name == "Air")
            {
                res = specificHeatAir;
            }
            return res;
        }

        public static double volumetricFractionOrganicMatter(double[] SLCARBApsim, double[] BDApsim, int layer)
        {
            double pom = 1.3;
            double res = SLCARBApsim[layer] / 100.0 * 2.5 * BDApsim[layer] / pom;
            return res;
        }

        public static double InterpTemp(double time_hours, double tmax, double tmin, double t2m, double max_temp_yesterday, double min_temp_yesterday)
        {
            double defaultTimeOfMaximumTemperature = 14.0;
            double midnight_temp;
            double t_scale;
            double piVal = 3.141592653589793;
            double time = time_hours / 24.0;
            double max_t_time = defaultTimeOfMaximumTemperature / 24.0;
            double min_t_time = max_t_time - 0.5;
            double current_temp = 0.0;
            if (time < min_t_time)
            {
                midnight_temp = Math.Sin((0.0 + 0.25 - max_t_time) * 2.0 * piVal) * (max_temp_yesterday - min_temp_yesterday) / 2.0 + ((max_temp_yesterday + min_temp_yesterday) / 2.0);
                t_scale = (min_t_time - time) / min_t_time;
                if (t_scale > 1.0)
                {
                    t_scale = 1.0;
                }
                else if ( t_scale < 0.0)
                {
                    t_scale = 0.0;
                }
                current_temp = tmin + (t_scale * (midnight_temp - tmin));
                return current_temp;
            }
            else
            {
                current_temp = Math.Sin((time + 0.25 - max_t_time) * 2.0 * piVal) * (tmax - tmin) / 2.0 + t2m;
                return current_temp;
            }
            return current_temp;
        }

        public static double RadnNetInterpolate(double internalTimeStep, double solarRadiation, double cloudFr, double cva, double potE, double potET, double tMean, double albedo, double[] soilTemp)
        {
            double EMISSIVITYsurface = 0.96;
            double w2MJ = internalTimeStep / 1000000.0;
            int SURFACEnode = 1;
            double emissivityAtmos = (1 - (0.84 * cloudFr)) * 0.58 * Math.Pow(cva, 1.0 / 7.0) + (0.84 * cloudFr);
            double PenetrationConstant = Divide(Math.Max(0.1, potE), Math.Max(0.1, potET), 0.0);
            double lwRinSoil = longWaveRadn(emissivityAtmos, tMean) * PenetrationConstant * w2MJ;
            double lwRoutSoil = longWaveRadn(EMISSIVITYsurface, soilTemp[SURFACEnode]) * PenetrationConstant * w2MJ;
            double lwRnetSoil = lwRinSoil - lwRoutSoil;
            double swRin = solarRadiation;
            double swRout = albedo * solarRadiation;
            double swRnetSoil = (swRin - swRout) * PenetrationConstant;
            double total = swRnetSoil + lwRnetSoil;
            return total;
        }

        public static double Divide(double val1, double val2, double errVal)
        {
            double returnValue = errVal;
            if (val2 != 0.0)
            {
                returnValue = val1 / val2;
            }
            return returnValue;
        }

        public static double longWaveRadn(double emissivity, double tDegC)
        {
            double STEFAN_BOLTZMANNconst = 0.0000000567;
            double kelvinTemp = kelvinT(tDegC);
            double res = STEFAN_BOLTZMANNconst * emissivity * Math.Pow(kelvinTemp, 4);
            return res;
        }

        public static double boundaryLayerConductanceF(double[] TNew_zb, double tMean, double potE, double potET, double airPressure, double canopyHeight, double windSpeed, double instrumentHeight)
        {
            double VONK = 0.41;
            double GRAVITATIONALconst = 9.8;
            double specificHeatOfAir = 1010.0;
            double EMISSIVITYsurface = 0.98;
            int SURFACEnode = 1;
            double STEFAN_BOLTZMANNconst = 0.0000000567;
            double SpecificHeatAir = specificHeatOfAir * airDensity(tMean, airPressure);
            double RoughnessFacMomentum = 0.13 * canopyHeight;
            double RoughnessFacHeat = 0.2 * RoughnessFacMomentum;
            double d = 0.77 * canopyHeight;
            double SurfaceTemperature = TNew_zb[SURFACEnode];
            double PenetrationConstant = Math.Max(0.1, potE) / Math.Max(0.1, potET);
            double kelvinTemp = kelvinT(tMean);
            double radiativeConductance = 4.0 * STEFAN_BOLTZMANNconst * EMISSIVITYsurface * PenetrationConstant * Math.Pow(kelvinTemp, 3);
            double FrictionVelocity = 0.0;
            double BoundaryLayerCond = 0.0;
            double StabilityParam = 0.0;
            double StabilityCorMomentum = 0.0;
            double StabilityCorHeat = 0.0;
            double HeatFluxDensity = 0.0;
            int iteration = 1;
            for (iteration=1 ; iteration!=4 ; iteration+=1)
            {
                FrictionVelocity = Divide(windSpeed * VONK, Math.Log(Divide(instrumentHeight - d + RoughnessFacMomentum, RoughnessFacMomentum, 0.0)) + StabilityCorMomentum, 0.0);
                BoundaryLayerCond = Divide(SpecificHeatAir * VONK * FrictionVelocity, Math.Log(Divide(instrumentHeight - d + RoughnessFacHeat, RoughnessFacHeat, 0.0)) + StabilityCorHeat, 0.0);
                BoundaryLayerCond = BoundaryLayerCond + radiativeConductance;
                HeatFluxDensity = BoundaryLayerCond * (SurfaceTemperature - tMean);
                StabilityParam = Divide(-VONK * instrumentHeight * GRAVITATIONALconst * HeatFluxDensity, SpecificHeatAir * kelvinTemp * Math.Pow(FrictionVelocity, 3), 0.0);
                if (StabilityParam > 0.0)
                {
                    StabilityCorHeat = 4.7 * StabilityParam;
                    StabilityCorMomentum = StabilityCorHeat;
                }
                else
                {
                    StabilityCorHeat = -2.0 * Math.Log((1.0 + Math.Sqrt(1.0 - (16.0 * StabilityParam))) / 2.0);
                    StabilityCorMomentum = 0.6 * StabilityCorHeat;
                }
            }
            return BoundaryLayerCond;
        }

        public static double airDensity(double temperature, double AirPressure)
        {
            double MWair = 0.02897;
            double RGAS = 8.3143;
            double HPA2PA = 100.0;
            double kelvinTemp = kelvinT(temperature);
            double res = Divide(MWair * AirPressure * HPA2PA, kelvinTemp * RGAS, 0.0);
            return res;
        }

        public static double kelvinT(double celciusT)
        {
            double ZEROTkelvin = 273.18;
            double res = celciusT + ZEROTkelvin;
            return res;
        }

        public static double Divide(double val1, double val2, double errVal)
        {
            double returnValue = errVal;
            if (val2 != 0.0)
            {
                returnValue = val1 / val2;
            }
            return returnValue;
        }

        public static double kelvinT(double celciusT)
        {
            double ZEROTkelvin = 273.18;
            double res = celciusT + ZEROTkelvin;
            return res;
        }

        public static double Divide(double val1, double val2, double errVal)
        {
            double returnValue = errVal;
            if (val2 != 0.0)
            {
                returnValue = val1 / val2;
            }
            return returnValue;
        }

        public static double[] doThomas(double[] newTemps, double[] soilTemp, double[] thermalConductivity, double[] thermalConductance, double[] DEPTHApsim, double[] volSpecHeatSoil, double gDt, double netRadiation, double potE, double actE, int numNodes, string netRadiationSource)
        {
            double nu = 0.6;
            int AIRnode = 0;
            int SURFACEnode = 1;
            double MJ2J = 1000000.0;
            double latentHeatOfVapourisation = 2465000.0;
            double tempStepSec = 24.0 * 60.0 * 60.0;
            double[] heatStorage ;
            for (var i = 0; i < numNodes + 1; i++){heatStorage[i] = 0.0d;}
            double VolSoilAtNode;
            double elementLength;
            double g = 1 - nu;
            double sensibleHeatFlux;
            double RadnNet;
            double LatentHeatFlux;
            double SoilSurfaceHeatFlux;
            double[] a ;
            double[] b ;
            double[] c ;
            double[] d ;
            for (var i = 0; i < numNodes + 2; i++){a[i] = 0.0;}
            for (var i = 0; i < numNodes + 1; i++){b[i] = 0.0;}
            for (var i = 0; i < numNodes + 1; i++){c[i] = 0.0;}
            for (var i = 0; i < numNodes + 1; i++){d[i] = 0.0;}
            for (var i = 0; i < numNodes + 1; i++){thermalConductance[i] = 0.0d;}
            thermalConductance[AIRnode] = thermalConductivity[AIRnode];
            int node = SURFACEnode;
            for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
            {
                VolSoilAtNode = 0.5 * (DEPTHApsim[node + 1] - DEPTHApsim[node - 1]);
                heatStorage[node] = Divide(volSpecHeatSoil[node] * VolSoilAtNode, gDt, 0.0);
                elementLength = DEPTHApsim[node + 1] - DEPTHApsim[node];
                thermalConductance[node] = Divide(thermalConductivity[node], elementLength, 0.0);
            }
            for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
            {
                c[node] = -nu * thermalConductance[node];
                a[node + 1] = c[node];
                b[node] = nu * (thermalConductance[node] + thermalConductance[node - 1]) + heatStorage[node];
                d[node] = g * thermalConductance[(node - 1)] * soilTemp[(node - 1)] + ((heatStorage[node] - (g * (thermalConductance[node] + thermalConductance[node - 1]))) * soilTemp[node]) + (g * thermalConductance[node] * soilTemp[(node + 1)]);
            }
            a[SURFACEnode] = 0.0;
            sensibleHeatFlux = nu * thermalConductance[AIRnode] * newTemps[AIRnode];
            RadnNet = 0.0;
            if (netRadiationSource == "calc")
            {
                RadnNet = Divide(netRadiation * 1000000.0, gDt, 0.0);
            }
            else if ( netRadiationSource == "eos")
            {
                RadnNet = Divide(potE * latentHeatOfVapourisation, tempStepSec, 0.0);
            }
            LatentHeatFlux = Divide(actE * latentHeatOfVapourisation, tempStepSec, 0.0);
            SoilSurfaceHeatFlux = sensibleHeatFlux + RadnNet - LatentHeatFlux;
            d[SURFACEnode] = d[SURFACEnode] + SoilSurfaceHeatFlux;
            d[numNodes] = d[numNodes] + (nu * thermalConductance[numNodes] * newTemps[(numNodes + 1)]);
            for (node=SURFACEnode ; node!=numNodes ; node+=1)
            {
                c[node] = Divide(c[node], b[node], 0.0);
                d[node] = Divide(d[node], b[node], 0.0);
                b[node + 1] = b[node + 1] - (a[(node + 1)] * c[node]);
                d[node + 1] = d[node + 1] - (a[(node + 1)] * d[node]);
            }
            newTemps[numNodes] = Divide(d[numNodes], b[numNodes], 0.0);
            for (node=numNodes - 1 ; node!=SURFACEnode - 1 ; node+=-1)
            {
                newTemps[node] = d[node] - (c[node] * newTemps[(node + 1)]);
            }
            return newTemps;
        }

        public static double Divide(double val1, double val2, double errVal)
        {
            double returnValue = errVal;
            if (val2 != 0.0)
            {
                returnValue = val1 / val2;
            }
            return returnValue;
        }

        public static Tuple<double[],double>  doUpdate(double[] tempNew, double[] soilTemp, double[] minSoilTemp, double[] maxSoilTemp, double[] aveSoilTemp, double[] thermalConductivity, double boundaryLayerConductance, int IterationsPerDay, double timeOfDaySecs, double gDt, int numNodes)
        {
            int SURFACEnode = 1;
            int AIRnode = 0;
            int node = 1;
            for (node=0 ; node!=tempNew.Length ; node+=1)
            {
                soilTemp[node] = tempNew[node];
            }
            if (timeOfDaySecs < (gDt * 1.2))
            {
                for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
                {
                    minSoilTemp[node] = soilTemp[node];
                    maxSoilTemp[node] = soilTemp[node];
                }
            }
            for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
            {
                if (soilTemp[node] < minSoilTemp[node])
                {
                    minSoilTemp[node] = soilTemp[node];
                }
                else if ( soilTemp[node] > maxSoilTemp[node])
                {
                    maxSoilTemp[node] = soilTemp[node];
                }
                aveSoilTemp[node] = aveSoilTemp[node] + Divide(soilTemp[node], (double)(IterationsPerDay), 0.0);
            }
            boundaryLayerConductance = boundaryLayerConductance + Divide(thermalConductivity[AIRnode], (double)(IterationsPerDay), 0.0);
            return Tuple.Create(soilTemp, boundaryLayerConductance);
        }

        public static double Divide(double val1, double val2, double errVal)
        {
            double returnValue = errVal;
            if (val2 != 0.0)
            {
                returnValue = val1 / val2;
            }
            return returnValue;
        }

        public static Tuple<double[],double[],double[],double[]>  doThermalConductivityCoeffs(int nbLayers, int numNodes, double[] BDApsim, double[] CLAYApsim)
        {
            double[] thermalCondPar1 ;
            double[] thermalCondPar2 ;
            double[] thermalCondPar3 ;
            double[] thermalCondPar4 ;
            int layer;
            int element;
            for (var i = 0; i < numNodes + 1; i++){thermalCondPar1[i] = 0.0;}
            for (var i = 0; i < numNodes + 1; i++){thermalCondPar2[i] = 0.0;}
            for (var i = 0; i < numNodes + 1; i++){thermalCondPar3[i] = 0.0;}
            for (var i = 0; i < numNodes + 1; i++){thermalCondPar4[i] = 0.0;}
            for (layer=1 ; layer!=nbLayers + 2 ; layer+=1)
            {
                element = layer;
                thermalCondPar1[element] = 0.65 - (0.78 * BDApsim[layer]) + (0.6 * Math.Pow(BDApsim[layer], 2));
                thermalCondPar2[element] = 1.06 * BDApsim[layer];
                thermalCondPar3[element] = Divide(2.6, Math.Sqrt(CLAYApsim[layer]), 0.0);
                thermalCondPar3[element] = 1.0 + thermalCondPar3[element];
                thermalCondPar4[element] = 0.03 + (0.1 * Math.Pow(BDApsim[layer], 2));
            }
            return Tuple.Create(thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4);
        }

        public static double Divide(double val1, double val2, double errVal)
        {
            double returnValue = errVal;
            if (val2 != 0.0)
            {
                returnValue = val1 / val2;
            }
            return returnValue;
        }

        public static double[] CalcSoilTemp(double[] THICKApsim, double tav, double tamp, int doy, double latitude, int numNodes)
        {
            double[] cumulativeDepth ;
            double[] soilTempIO ;
            double[] soilTemperat ;
            int Layer;
            int nodes;
            double tempValue;
            double w;
            double dh;
            double zd;
            double offset;
            int SURFACEnode = 1;
            double piVal = 3.141592653589793;
            for (var i = 0; i < THICKApsim.Length; i++){cumulativeDepth[i] = 0.0;}
            if (THICKApsim.Length > 0)
            {
                cumulativeDepth[0] = THICKApsim[0];
                for (Layer=1 ; Layer!=THICKApsim.Length ; Layer+=1)
                {
                    cumulativeDepth[Layer] = THICKApsim[Layer] + cumulativeDepth[Layer - 1];
                }
            }
            w = piVal;
            w = 2.0 * w;
            w = w / (365.25 * 24.0 * 3600.0);
            dh = 0.6;
            zd = Math.Sqrt(2 * dh / w);
            offset = 0.25;
            if (latitude > 0.0)
            {
                offset = -0.25;
            }
            for (var i = 0; i < numNodes + 2; i++){soilTemperat[i] = 0.0;}
            for (var i = 0; i < numNodes + 1 + 1; i++){soilTempIO[i] = 0.0;}
            for (nodes=1 ; nodes!=numNodes + 1 ; nodes+=1)
            {
                soilTemperat[nodes] = tav + (tamp * Math.Exp(-1.0 * cumulativeDepth[nodes] / zd) * Math.Sin(((doy / 365.0 + offset) * 2.0 * piVal - (cumulativeDepth[nodes] / zd))));
            }
            for (Layer=SURFACEnode ; Layer!=numNodes + 1 ; Layer+=1)
            {
                soilTempIO[Layer] = soilTemperat[Layer - 1];
            }
            return soilTempIO;
        }

    }
}