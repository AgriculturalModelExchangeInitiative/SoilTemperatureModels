
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
    public class model_SoilTempCampbellComponent : IStrategymodel_SoilTempCampbell
    {
        public model_SoilTempCampbellComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'NLAYR'}, "NLAYR");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'CONSTANT_TEMPdepth'}, "CONSTANT_TEMPdepth");
            _parameters0_0.Add(v2);
            VarInfo v3 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'TAMP'}, "TAMP");
            _parameters0_0.Add(v3);
            VarInfo v4 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'XLAT'}, "XLAT");
            _parameters0_0.Add(v4);
            VarInfo v5 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'SALB'}, "SALB");
            _parameters0_0.Add(v5);
            VarInfo v6 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'instrumentHeight'}, "instrumentHeight");
            _parameters0_0.Add(v6);
            VarInfo v7 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'boundaryLayerConductanceSource'}, "boundaryLayerConductanceSource");
            _parameters0_0.Add(v7);
            VarInfo v8 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'netRadiationSource'}, "netRadiationSource");
            _parameters0_0.Add(v8);
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
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd47 = new PropertyDescription();
            pd47.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd47.PropertyName = "soilTemp";
            pd47.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp).ValueType.TypeForCurrentValue;
            pd47.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp);
            _outputs0_0.Add(pd47);
            PropertyDescription pd48 = new PropertyDescription();
            pd48.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd48.PropertyName = "minSoilTemp";
            pd48.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp).ValueType.TypeForCurrentValue;
            pd48.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp);
            _outputs0_0.Add(pd48);
            PropertyDescription pd49 = new PropertyDescription();
            pd49.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd49.PropertyName = "maxSoilTemp";
            pd49.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp).ValueType.TypeForCurrentValue;
            pd49.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp);
            _outputs0_0.Add(pd49);
            PropertyDescription pd50 = new PropertyDescription();
            pd50.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd50.PropertyName = "aveSoilTemp";
            pd50.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp).ValueType.TypeForCurrentValue;
            pd50.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp);
            _outputs0_0.Add(pd50);
            PropertyDescription pd51 = new PropertyDescription();
            pd51.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd51.PropertyName = "morningSoilTemp";
            pd51.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp).ValueType.TypeForCurrentValue;
            pd51.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp);
            _outputs0_0.Add(pd51);
            PropertyDescription pd52 = new PropertyDescription();
            pd52.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd52.PropertyName = "newTemperature";
            pd52.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature).ValueType.TypeForCurrentValue;
            pd52.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature);
            _outputs0_0.Add(pd52);
            PropertyDescription pd53 = new PropertyDescription();
            pd53.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd53.PropertyName = "maxTempYesterday";
            pd53.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday).ValueType.TypeForCurrentValue;
            pd53.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday);
            _outputs0_0.Add(pd53);
            PropertyDescription pd54 = new PropertyDescription();
            pd54.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd54.PropertyName = "minTempYesterday";
            pd54.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday).ValueType.TypeForCurrentValue;
            pd54.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday);
            _outputs0_0.Add(pd54);
            PropertyDescription pd55 = new PropertyDescription();
            pd55.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd55.PropertyName = "thermalCondPar1";
            pd55.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1).ValueType.TypeForCurrentValue;
            pd55.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1);
            _outputs0_0.Add(pd55);
            PropertyDescription pd56 = new PropertyDescription();
            pd56.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd56.PropertyName = "thermalCondPar2";
            pd56.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2).ValueType.TypeForCurrentValue;
            pd56.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2);
            _outputs0_0.Add(pd56);
            PropertyDescription pd57 = new PropertyDescription();
            pd57.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd57.PropertyName = "thermalCondPar3";
            pd57.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3).ValueType.TypeForCurrentValue;
            pd57.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3);
            _outputs0_0.Add(pd57);
            PropertyDescription pd58 = new PropertyDescription();
            pd58.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd58.PropertyName = "thermalCondPar4";
            pd58.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4).ValueType.TypeForCurrentValue;
            pd58.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4);
            _outputs0_0.Add(pd58);
            PropertyDescription pd59 = new PropertyDescription();
            pd59.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd59.PropertyName = "thermalConductivity";
            pd59.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity).ValueType.TypeForCurrentValue;
            pd59.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity);
            _outputs0_0.Add(pd59);
            PropertyDescription pd60 = new PropertyDescription();
            pd60.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd60.PropertyName = "thermalConductance";
            pd60.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance).ValueType.TypeForCurrentValue;
            pd60.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance);
            _outputs0_0.Add(pd60);
            PropertyDescription pd61 = new PropertyDescription();
            pd61.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd61.PropertyName = "heatStorage";
            pd61.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage).ValueType.TypeForCurrentValue;
            pd61.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage);
            _outputs0_0.Add(pd61);
            PropertyDescription pd62 = new PropertyDescription();
            pd62.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd62.PropertyName = "volSpecHeatSoil";
            pd62.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil).ValueType.TypeForCurrentValue;
            pd62.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil);
            _outputs0_0.Add(pd62);
            PropertyDescription pd63 = new PropertyDescription();
            pd63.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd63.PropertyName = "_boundaryLayerConductance";
            pd63.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance).ValueType.TypeForCurrentValue;
            pd63.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance);
            _outputs0_0.Add(pd63);
            PropertyDescription pd64 = new PropertyDescription();
            pd64.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd64.PropertyName = "THICKApsim";
            pd64.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.THICKApsim).ValueType.TypeForCurrentValue;
            pd64.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.THICKApsim);
            _outputs0_0.Add(pd64);
            PropertyDescription pd65 = new PropertyDescription();
            pd65.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd65.PropertyName = "DEPTHApsim";
            pd65.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.DEPTHApsim).ValueType.TypeForCurrentValue;
            pd65.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.DEPTHApsim);
            _outputs0_0.Add(pd65);
            PropertyDescription pd66 = new PropertyDescription();
            pd66.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd66.PropertyName = "BDApsim";
            pd66.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.BDApsim).ValueType.TypeForCurrentValue;
            pd66.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.BDApsim);
            _outputs0_0.Add(pd66);
            PropertyDescription pd67 = new PropertyDescription();
            pd67.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd67.PropertyName = "SWApsim";
            pd67.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SWApsim).ValueType.TypeForCurrentValue;
            pd67.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SWApsim);
            _outputs0_0.Add(pd67);
            PropertyDescription pd68 = new PropertyDescription();
            pd68.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd68.PropertyName = "CLAYApsim";
            pd68.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.CLAYApsim).ValueType.TypeForCurrentValue;
            pd68.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.CLAYApsim);
            _outputs0_0.Add(pd68);
            PropertyDescription pd69 = new PropertyDescription();
            pd69.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd69.PropertyName = "SLROCKApsim";
            pd69.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCKApsim).ValueType.TypeForCurrentValue;
            pd69.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCKApsim);
            _outputs0_0.Add(pd69);
            PropertyDescription pd70 = new PropertyDescription();
            pd70.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd70.PropertyName = "SLCARBApsim";
            pd70.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARBApsim).ValueType.TypeForCurrentValue;
            pd70.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARBApsim);
            _outputs0_0.Add(pd70);
            PropertyDescription pd71 = new PropertyDescription();
            pd71.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd71.PropertyName = "SLSANDApsim";
            pd71.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSANDApsim).ValueType.TypeForCurrentValue;
            pd71.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSANDApsim);
            _outputs0_0.Add(pd71);
            PropertyDescription pd72 = new PropertyDescription();
            pd72.DomainClassType = typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd72.PropertyName = "SLSILTApsim";
            pd72.PropertyType = (model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILTApsim).ValueType.TypeForCurrentValue;
            pd72.PropertyVarInfo =(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILTApsim);
            _outputs0_0.Add(pd72);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(model_SoilTempCampbell.Strategies.campbell).FullName);
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
            return new List<Type>() {  typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState), typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState), typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellRate), typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellAuxiliary), typeof(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous)};
        }

        public int NLAYR
        {
            get
            {
                 return _Campbell.NLAYR; 
            }
            set
            {
                _Campbell.NLAYR = value;
            }
        }
        public double CONSTANT_TEMPdepth
        {
            get
            {
                 return _Campbell.CONSTANT_TEMPdepth; 
            }
            set
            {
                _Campbell.CONSTANT_TEMPdepth = value;
            }
        }
        public double TAMP
        {
            get
            {
                 return _Campbell.TAMP; 
            }
            set
            {
                _Campbell.TAMP = value;
            }
        }
        public double XLAT
        {
            get
            {
                 return _Campbell.XLAT; 
            }
            set
            {
                _Campbell.XLAT = value;
            }
        }
        public double SALB
        {
            get
            {
                 return _Campbell.SALB; 
            }
            set
            {
                _Campbell.SALB = value;
            }
        }
        public double instrumentHeight
        {
            get
            {
                 return _Campbell.instrumentHeight; 
            }
            set
            {
                _Campbell.instrumentHeight = value;
            }
        }
        public string boundaryLayerConductanceSource
        {
            get
            {
                 return _Campbell.boundaryLayerConductanceSource; 
            }
            set
            {
                _Campbell.boundaryLayerConductanceSource = value;
            }
        }
        public string netRadiationSource
        {
            get
            {
                 return _Campbell.netRadiationSource; 
            }
            set
            {
                _Campbell.netRadiationSource = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _campbell.SetParametersDefaultValue();
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

        public static VarInfo NLAYRVarInfo
        {
            get { return model_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'NLAYR'}.NLAYRVarInfo;} 
        }

        public static VarInfo CONSTANT_TEMPdepthVarInfo
        {
            get { return model_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'CONSTANT_TEMPdepth'}.CONSTANT_TEMPdepthVarInfo;} 
        }

        public static VarInfo TAMPVarInfo
        {
            get { return model_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'TAMP'}.TAMPVarInfo;} 
        }

        public static VarInfo XLATVarInfo
        {
            get { return model_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'XLAT'}.XLATVarInfo;} 
        }

        public static VarInfo SALBVarInfo
        {
            get { return model_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'SALB'}.SALBVarInfo;} 
        }

        public static VarInfo instrumentHeightVarInfo
        {
            get { return model_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'instrumentHeight'}.instrumentHeightVarInfo;} 
        }

        public static VarInfo boundaryLayerConductanceSourceVarInfo
        {
            get { return model_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'boundaryLayerConductanceSource'}.boundaryLayerConductanceSourceVarInfo;} 
        }

        public static VarInfo netRadiationSourceVarInfo
        {
            get { return model_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'netRadiationSource'}.netRadiationSourceVarInfo;} 
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

                string ret = "";
                ret += _campbell.TestPostConditions(s, s1, r, a, ex, " strategy model_SoilTempCampbell.Strategies.model_SoilTempCampbell");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .model_SoilTempCampbell, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
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
                string ret = "";
                ret += _campbell.TestPreConditions(s, s1, r, a, ex, " strategy model_SoilTempCampbell.Strategies.model_SoilTempCampbell");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .model_SoilTempCampbell, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
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

        private void CalculateModel(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s1,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellRate r,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellAuxiliary a,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        Campbell _Campbell = new Campbell();

        private void EstimateOfAssociatedClasses(model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s1,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellRate r,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellAuxiliary a,model_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous ex)
        {
            _campbell.Estimate(s,s1, r, a, ex);
        }

        public model_SoilTempCampbellComponent(model_SoilTempCampbellComponent toCopy): this() // copy constructor 
        {
                    NLAYR = toCopy.NLAYR;
                    CONSTANT_TEMPdepth = toCopy.CONSTANT_TEMPdepth;
                    TAMP = toCopy.TAMP;
                    XLAT = toCopy.XLAT;
                    SALB = toCopy.SALB;
                    instrumentHeight = toCopy.instrumentHeight;
                    boundaryLayerConductanceSource = toCopy.boundaryLayerConductanceSource;
                    netRadiationSource = toCopy.netRadiationSource;
                }
            }
        }