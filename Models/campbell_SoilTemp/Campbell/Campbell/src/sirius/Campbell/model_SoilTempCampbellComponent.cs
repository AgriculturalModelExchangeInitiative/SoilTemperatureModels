
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

using SiriusQualitymodel_SoilTempCampbell.DomainClass;
namespace SiriusQualitymodel_SoilTempCampbell.Strategies
{
    public class model_SoilTempCampbellComponent : IStrategySiriusQualitymodel_SoilTempCampbell
    {
        public model_SoilTempCampbellComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'NLAYR'}, "NLAYR");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'THICK'}, "THICK");
            _parameters0_0.Add(v2);
            VarInfo v3 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'DEPTH'}, "DEPTH");
            _parameters0_0.Add(v3);
            VarInfo v4 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'CONSTANT_TEMPdepth'}, "CONSTANT_TEMPdepth");
            _parameters0_0.Add(v4);
            VarInfo v5 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'BD'}, "BD");
            _parameters0_0.Add(v5);
            VarInfo v6 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'TAMP'}, "TAMP");
            _parameters0_0.Add(v6);
            VarInfo v7 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'XLAT'}, "XLAT");
            _parameters0_0.Add(v7);
            VarInfo v8 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'CLAY'}, "CLAY");
            _parameters0_0.Add(v8);
            VarInfo v9 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'SALB'}, "SALB");
            _parameters0_0.Add(v9);
            VarInfo v10 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'instrumentHeight'}, "instrumentHeight");
            _parameters0_0.Add(v10);
            VarInfo v11 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'boundaryLayerConductanceSource'}, "boundaryLayerConductanceSource");
            _parameters0_0.Add(v11);
            VarInfo v12 = new CompositeStrategyVarInfo(_{'modu': 'campbell', 'var': 'netRadiationSource'}, "netRadiationSource");
            _parameters0_0.Add(v12);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd1.PropertyName = "T2M";
            pd1.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.T2M).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.T2M);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd2.PropertyName = "TMAX";
            pd2.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMAX).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMAX);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd3.PropertyName = "TMIN";
            pd3.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMIN).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMIN);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd4.PropertyName = "TAV";
            pd4.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TAV).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TAV);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd5.PropertyName = "SW";
            pd5.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SW).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SW);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd6.PropertyName = "DOY";
            pd6.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.DOY).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.DOY);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd7.PropertyName = "airPressure";
            pd7.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.airPressure).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.airPressure);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd8.PropertyName = "canopyHeight";
            pd8.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.canopyHeight).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.canopyHeight);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd9.PropertyName = "SRAD";
            pd9.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SRAD).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SRAD);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd10.PropertyName = "ESP";
            pd10.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ESP).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ESP);
            _inputs0_0.Add(pd10);
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd11.PropertyName = "ES";
            pd11.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ES).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ES);
            _inputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd12.PropertyName = "EOAD";
            pd12.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.EOAD).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.EOAD);
            _inputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd13.PropertyName = "soilTemp";
            pd13.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp);
            _inputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd14.PropertyName = "newTemperature";
            pd14.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature);
            _inputs0_0.Add(pd14);
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd15.PropertyName = "minSoilTemp";
            pd15.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp);
            _inputs0_0.Add(pd15);
            PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd16.PropertyName = "maxSoilTemp";
            pd16.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp);
            _inputs0_0.Add(pd16);
            PropertyDescription pd17 = new PropertyDescription();
            pd17.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd17.PropertyName = "aveSoilTemp";
            pd17.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp).ValueType.TypeForCurrentValue;
            pd17.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp);
            _inputs0_0.Add(pd17);
            PropertyDescription pd18 = new PropertyDescription();
            pd18.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd18.PropertyName = "morningSoilTemp";
            pd18.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp).ValueType.TypeForCurrentValue;
            pd18.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp);
            _inputs0_0.Add(pd18);
            PropertyDescription pd19 = new PropertyDescription();
            pd19.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd19.PropertyName = "thermalCondPar1";
            pd19.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1).ValueType.TypeForCurrentValue;
            pd19.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1);
            _inputs0_0.Add(pd19);
            PropertyDescription pd20 = new PropertyDescription();
            pd20.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd20.PropertyName = "thermalCondPar2";
            pd20.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2).ValueType.TypeForCurrentValue;
            pd20.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2);
            _inputs0_0.Add(pd20);
            PropertyDescription pd21 = new PropertyDescription();
            pd21.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd21.PropertyName = "thermalCondPar3";
            pd21.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3).ValueType.TypeForCurrentValue;
            pd21.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3);
            _inputs0_0.Add(pd21);
            PropertyDescription pd22 = new PropertyDescription();
            pd22.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd22.PropertyName = "thermalCondPar4";
            pd22.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4).ValueType.TypeForCurrentValue;
            pd22.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4);
            _inputs0_0.Add(pd22);
            PropertyDescription pd23 = new PropertyDescription();
            pd23.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd23.PropertyName = "thermalConductivity";
            pd23.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity).ValueType.TypeForCurrentValue;
            pd23.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity);
            _inputs0_0.Add(pd23);
            PropertyDescription pd24 = new PropertyDescription();
            pd24.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd24.PropertyName = "thermalConductance";
            pd24.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance).ValueType.TypeForCurrentValue;
            pd24.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance);
            _inputs0_0.Add(pd24);
            PropertyDescription pd25 = new PropertyDescription();
            pd25.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd25.PropertyName = "heatStorage";
            pd25.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage).ValueType.TypeForCurrentValue;
            pd25.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage);
            _inputs0_0.Add(pd25);
            PropertyDescription pd26 = new PropertyDescription();
            pd26.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd26.PropertyName = "volSpecHeatSoil";
            pd26.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil).ValueType.TypeForCurrentValue;
            pd26.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil);
            _inputs0_0.Add(pd26);
            PropertyDescription pd27 = new PropertyDescription();
            pd27.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd27.PropertyName = "maxTempYesterday";
            pd27.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday).ValueType.TypeForCurrentValue;
            pd27.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday);
            _inputs0_0.Add(pd27);
            PropertyDescription pd28 = new PropertyDescription();
            pd28.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd28.PropertyName = "minTempYesterday";
            pd28.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday).ValueType.TypeForCurrentValue;
            pd28.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday);
            _inputs0_0.Add(pd28);
            PropertyDescription pd29 = new PropertyDescription();
            pd29.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous);
            pd29.PropertyName = "windSpeed";
            pd29.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.windSpeed).ValueType.TypeForCurrentValue;
            pd29.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.windSpeed);
            _inputs0_0.Add(pd29);
            PropertyDescription pd30 = new PropertyDescription();
            pd30.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd30.PropertyName = "SLCARB";
            pd30.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARB).ValueType.TypeForCurrentValue;
            pd30.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARB);
            _inputs0_0.Add(pd30);
            PropertyDescription pd31 = new PropertyDescription();
            pd31.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd31.PropertyName = "SLROCK";
            pd31.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCK).ValueType.TypeForCurrentValue;
            pd31.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCK);
            _inputs0_0.Add(pd31);
            PropertyDescription pd32 = new PropertyDescription();
            pd32.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd32.PropertyName = "SLSILT";
            pd32.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILT).ValueType.TypeForCurrentValue;
            pd32.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILT);
            _inputs0_0.Add(pd32);
            PropertyDescription pd33 = new PropertyDescription();
            pd33.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd33.PropertyName = "SLSAND";
            pd33.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSAND).ValueType.TypeForCurrentValue;
            pd33.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSAND);
            _inputs0_0.Add(pd33);
            PropertyDescription pd34 = new PropertyDescription();
            pd34.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd34.PropertyName = "_boundaryLayerConductance";
            pd34.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance).ValueType.TypeForCurrentValue;
            pd34.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance);
            _inputs0_0.Add(pd34);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd35 = new PropertyDescription();
            pd35.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd35.PropertyName = "soilTemp";
            pd35.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp).ValueType.TypeForCurrentValue;
            pd35.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp);
            _outputs0_0.Add(pd35);
            PropertyDescription pd36 = new PropertyDescription();
            pd36.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd36.PropertyName = "minSoilTemp";
            pd36.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp).ValueType.TypeForCurrentValue;
            pd36.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp);
            _outputs0_0.Add(pd36);
            PropertyDescription pd37 = new PropertyDescription();
            pd37.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd37.PropertyName = "maxSoilTemp";
            pd37.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp).ValueType.TypeForCurrentValue;
            pd37.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp);
            _outputs0_0.Add(pd37);
            PropertyDescription pd38 = new PropertyDescription();
            pd38.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd38.PropertyName = "aveSoilTemp";
            pd38.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp).ValueType.TypeForCurrentValue;
            pd38.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp);
            _outputs0_0.Add(pd38);
            PropertyDescription pd39 = new PropertyDescription();
            pd39.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd39.PropertyName = "morningSoilTemp";
            pd39.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp).ValueType.TypeForCurrentValue;
            pd39.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp);
            _outputs0_0.Add(pd39);
            PropertyDescription pd40 = new PropertyDescription();
            pd40.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd40.PropertyName = "newTemperature";
            pd40.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature).ValueType.TypeForCurrentValue;
            pd40.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature);
            _outputs0_0.Add(pd40);
            PropertyDescription pd41 = new PropertyDescription();
            pd41.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd41.PropertyName = "maxTempYesterday";
            pd41.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday).ValueType.TypeForCurrentValue;
            pd41.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday);
            _outputs0_0.Add(pd41);
            PropertyDescription pd42 = new PropertyDescription();
            pd42.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd42.PropertyName = "minTempYesterday";
            pd42.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday).ValueType.TypeForCurrentValue;
            pd42.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday);
            _outputs0_0.Add(pd42);
            PropertyDescription pd43 = new PropertyDescription();
            pd43.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd43.PropertyName = "thermalCondPar1";
            pd43.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1).ValueType.TypeForCurrentValue;
            pd43.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1);
            _outputs0_0.Add(pd43);
            PropertyDescription pd44 = new PropertyDescription();
            pd44.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd44.PropertyName = "thermalCondPar2";
            pd44.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2).ValueType.TypeForCurrentValue;
            pd44.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2);
            _outputs0_0.Add(pd44);
            PropertyDescription pd45 = new PropertyDescription();
            pd45.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd45.PropertyName = "thermalCondPar3";
            pd45.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3).ValueType.TypeForCurrentValue;
            pd45.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3);
            _outputs0_0.Add(pd45);
            PropertyDescription pd46 = new PropertyDescription();
            pd46.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd46.PropertyName = "thermalCondPar4";
            pd46.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4).ValueType.TypeForCurrentValue;
            pd46.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4);
            _outputs0_0.Add(pd46);
            PropertyDescription pd47 = new PropertyDescription();
            pd47.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd47.PropertyName = "thermalConductivity";
            pd47.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity).ValueType.TypeForCurrentValue;
            pd47.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity);
            _outputs0_0.Add(pd47);
            PropertyDescription pd48 = new PropertyDescription();
            pd48.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd48.PropertyName = "thermalConductance";
            pd48.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance).ValueType.TypeForCurrentValue;
            pd48.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance);
            _outputs0_0.Add(pd48);
            PropertyDescription pd49 = new PropertyDescription();
            pd49.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd49.PropertyName = "heatStorage";
            pd49.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage).ValueType.TypeForCurrentValue;
            pd49.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage);
            _outputs0_0.Add(pd49);
            PropertyDescription pd50 = new PropertyDescription();
            pd50.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd50.PropertyName = "volSpecHeatSoil";
            pd50.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil).ValueType.TypeForCurrentValue;
            pd50.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil);
            _outputs0_0.Add(pd50);
            PropertyDescription pd51 = new PropertyDescription();
            pd51.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd51.PropertyName = "_boundaryLayerConductance";
            pd51.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance).ValueType.TypeForCurrentValue;
            pd51.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance);
            _outputs0_0.Add(pd51);
            PropertyDescription pd52 = new PropertyDescription();
            pd52.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd52.PropertyName = "SLROCK";
            pd52.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCK).ValueType.TypeForCurrentValue;
            pd52.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCK);
            _outputs0_0.Add(pd52);
            PropertyDescription pd53 = new PropertyDescription();
            pd53.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd53.PropertyName = "SLCARB";
            pd53.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARB).ValueType.TypeForCurrentValue;
            pd53.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARB);
            _outputs0_0.Add(pd53);
            PropertyDescription pd54 = new PropertyDescription();
            pd54.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd54.PropertyName = "SLSAND";
            pd54.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSAND).ValueType.TypeForCurrentValue;
            pd54.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSAND);
            _outputs0_0.Add(pd54);
            PropertyDescription pd55 = new PropertyDescription();
            pd55.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd55.PropertyName = "SLSILT";
            pd55.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILT).ValueType.TypeForCurrentValue;
            pd55.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILT);
            _outputs0_0.Add(pd55);
            PropertyDescription pd56 = new PropertyDescription();
            pd56.DomainClassType = typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState);
            pd56.PropertyName = "airPressure";
            pd56.PropertyType = (SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.airPressure).ValueType.TypeForCurrentValue;
            pd56.PropertyVarInfo =(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.airPressure);
            _outputs0_0.Add(pd56);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(SiriusQualitymodel_SoilTempCampbell.Strategies.campbell).FullName);
            mo0_0.AssociatedStrategies = lAssStrat0_0;
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
            return new List<Type>() {  typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState), typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState), typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellRate), typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellAuxiliary), typeof(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous)};
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
        public double[] THICK
        {
            get
            {
                 return _Campbell.THICK; 
            }
            set
            {
                _Campbell.THICK = value;
            }
        }
        public double[] DEPTH
        {
            get
            {
                 return _Campbell.DEPTH; 
            }
            set
            {
                _Campbell.DEPTH = value;
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
        public double[] BD
        {
            get
            {
                 return _Campbell.BD; 
            }
            set
            {
                _Campbell.BD = value;
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
        public double[] CLAY
        {
            get
            {
                 return _Campbell.CLAY; 
            }
            set
            {
                _Campbell.CLAY = value;
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

            THICKVarInfo.Name = "THICK";
            THICKVarInfo.Description = "APSIM soil layer depths as thickness of layers";
            THICKVarInfo.MaxValue = -1D;
            THICKVarInfo.MinValue = -1D;
            THICKVarInfo.DefaultValue = -1D;
            THICKVarInfo.Units = "mm";
            THICKVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            DEPTHVarInfo.Name = "DEPTH";
            DEPTHVarInfo.Description = "APSIM node depths";
            DEPTHVarInfo.MaxValue = -1D;
            DEPTHVarInfo.MinValue = -1D;
            DEPTHVarInfo.DefaultValue = -1D;
            DEPTHVarInfo.Units = "m";
            DEPTHVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            CONSTANT_TEMPdepthVarInfo.Name = "CONSTANT_TEMPdepth";
            CONSTANT_TEMPdepthVarInfo.Description = "Depth of constant temperature";
            CONSTANT_TEMPdepthVarInfo.MaxValue = -1D;
            CONSTANT_TEMPdepthVarInfo.MinValue = -1D;
            CONSTANT_TEMPdepthVarInfo.DefaultValue = 1000.0;
            CONSTANT_TEMPdepthVarInfo.Units = "mm";
            CONSTANT_TEMPdepthVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            BDVarInfo.Name = "BD";
            BDVarInfo.Description = "bd (soil bulk density) is name of the APSIM var for bulk density so set bulkDensity";
            BDVarInfo.MaxValue = -1D;
            BDVarInfo.MinValue = -1D;
            BDVarInfo.DefaultValue = -1D;
            BDVarInfo.Units = "g/cm3";
            BDVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

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

            CLAYVarInfo.Name = "CLAY";
            CLAYVarInfo.Description = "Proportion of clay in each layer of profile";
            CLAYVarInfo.MaxValue = -1D;
            CLAYVarInfo.MinValue = -1D;
            CLAYVarInfo.DefaultValue = -1D;
            CLAYVarInfo.Units = "";
            CLAYVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

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
            get { return SiriusQualitymodel_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'NLAYR'}.NLAYRVarInfo;} 
        }

        public static VarInfo THICKVarInfo
        {
            get { return SiriusQualitymodel_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'THICK'}.THICKVarInfo;} 
        }

        public static VarInfo DEPTHVarInfo
        {
            get { return SiriusQualitymodel_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'DEPTH'}.DEPTHVarInfo;} 
        }

        public static VarInfo CONSTANT_TEMPdepthVarInfo
        {
            get { return SiriusQualitymodel_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'CONSTANT_TEMPdepth'}.CONSTANT_TEMPdepthVarInfo;} 
        }

        public static VarInfo BDVarInfo
        {
            get { return SiriusQualitymodel_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'BD'}.BDVarInfo;} 
        }

        public static VarInfo TAMPVarInfo
        {
            get { return SiriusQualitymodel_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'TAMP'}.TAMPVarInfo;} 
        }

        public static VarInfo XLATVarInfo
        {
            get { return SiriusQualitymodel_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'XLAT'}.XLATVarInfo;} 
        }

        public static VarInfo CLAYVarInfo
        {
            get { return SiriusQualitymodel_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'CLAY'}.CLAYVarInfo;} 
        }

        public static VarInfo SALBVarInfo
        {
            get { return SiriusQualitymodel_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'SALB'}.SALBVarInfo;} 
        }

        public static VarInfo instrumentHeightVarInfo
        {
            get { return SiriusQualitymodel_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'instrumentHeight'}.instrumentHeightVarInfo;} 
        }

        public static VarInfo boundaryLayerConductanceSourceVarInfo
        {
            get { return SiriusQualitymodel_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'boundaryLayerConductanceSource'}.boundaryLayerConductanceSourceVarInfo;} 
        }

        public static VarInfo netRadiationSourceVarInfo
        {
            get { return SiriusQualitymodel_SoilTempCampbell.Strategies.{'modu': 'campbell', 'var': 'netRadiationSource'}.netRadiationSourceVarInfo;} 
        }

        public string TestPostConditions(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s1,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellRate r,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellAuxiliary a,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp.CurrentValue=s.soilTemp;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp.CurrentValue=s.minSoilTemp;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp.CurrentValue=s.maxSoilTemp;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp.CurrentValue=s.aveSoilTemp;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp.CurrentValue=s.morningSoilTemp;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature.CurrentValue=s.newTemperature;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday.CurrentValue=s.maxTempYesterday;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday.CurrentValue=s.minTempYesterday;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1.CurrentValue=s.thermalCondPar1;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2.CurrentValue=s.thermalCondPar2;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3.CurrentValue=s.thermalCondPar3;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4.CurrentValue=s.thermalCondPar4;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity.CurrentValue=s.thermalConductivity;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance.CurrentValue=s.thermalConductance;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage.CurrentValue=s.heatStorage;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil.CurrentValue=s.volSpecHeatSoil;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance.CurrentValue=s._boundaryLayerConductance;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCK.CurrentValue=s.SLROCK;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARB.CurrentValue=s.SLCARB;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSAND.CurrentValue=s.SLSAND;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILT.CurrentValue=s.SLSILT;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.airPressure.CurrentValue=s.airPressure;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r47 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp);
                if(r47.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp.ValueType)){prc.AddCondition(r47);}
                RangeBasedCondition r48 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp);
                if(r48.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp.ValueType)){prc.AddCondition(r48);}
                RangeBasedCondition r49 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp);
                if(r49.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp.ValueType)){prc.AddCondition(r49);}
                RangeBasedCondition r50 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp);
                if(r50.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp.ValueType)){prc.AddCondition(r50);}
                RangeBasedCondition r51 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp);
                if(r51.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp.ValueType)){prc.AddCondition(r51);}
                RangeBasedCondition r52 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature);
                if(r52.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature.ValueType)){prc.AddCondition(r52);}
                RangeBasedCondition r53 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday);
                if(r53.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday.ValueType)){prc.AddCondition(r53);}
                RangeBasedCondition r54 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday);
                if(r54.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday.ValueType)){prc.AddCondition(r54);}
                RangeBasedCondition r55 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1);
                if(r55.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1.ValueType)){prc.AddCondition(r55);}
                RangeBasedCondition r56 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2);
                if(r56.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2.ValueType)){prc.AddCondition(r56);}
                RangeBasedCondition r57 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3);
                if(r57.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3.ValueType)){prc.AddCondition(r57);}
                RangeBasedCondition r58 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4);
                if(r58.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4.ValueType)){prc.AddCondition(r58);}
                RangeBasedCondition r59 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity);
                if(r59.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity.ValueType)){prc.AddCondition(r59);}
                RangeBasedCondition r60 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance);
                if(r60.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance.ValueType)){prc.AddCondition(r60);}
                RangeBasedCondition r61 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage);
                if(r61.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage.ValueType)){prc.AddCondition(r61);}
                RangeBasedCondition r62 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil);
                if(r62.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil.ValueType)){prc.AddCondition(r62);}
                RangeBasedCondition r63 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance);
                if(r63.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance.ValueType)){prc.AddCondition(r63);}
                RangeBasedCondition r64 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCK);
                if(r64.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCK.ValueType)){prc.AddCondition(r64);}
                RangeBasedCondition r65 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARB);
                if(r65.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARB.ValueType)){prc.AddCondition(r65);}
                RangeBasedCondition r66 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSAND);
                if(r66.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSAND.ValueType)){prc.AddCondition(r66);}
                RangeBasedCondition r67 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILT);
                if(r67.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILT.ValueType)){prc.AddCondition(r67);}
                RangeBasedCondition r68 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.airPressure);
                if(r68.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.airPressure.ValueType)){prc.AddCondition(r68);}

                string ret = "";
                ret += _campbell.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualitymodel_SoilTempCampbell.Strategies.model_SoilTempCampbell");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.model_SoilTempCampbell, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s1,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellRate r,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellAuxiliary a,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.T2M.CurrentValue=ex.T2M;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMAX.CurrentValue=ex.TMAX;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMIN.CurrentValue=ex.TMIN;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TAV.CurrentValue=ex.TAV;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SW.CurrentValue=ex.SW;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.DOY.CurrentValue=ex.DOY;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.airPressure.CurrentValue=s.airPressure;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.canopyHeight.CurrentValue=ex.canopyHeight;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SRAD.CurrentValue=ex.SRAD;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ESP.CurrentValue=ex.ESP;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ES.CurrentValue=ex.ES;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.EOAD.CurrentValue=ex.EOAD;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp.CurrentValue=s.soilTemp;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature.CurrentValue=s.newTemperature;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp.CurrentValue=s.minSoilTemp;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp.CurrentValue=s.maxSoilTemp;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp.CurrentValue=s.aveSoilTemp;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp.CurrentValue=s.morningSoilTemp;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1.CurrentValue=s.thermalCondPar1;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2.CurrentValue=s.thermalCondPar2;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3.CurrentValue=s.thermalCondPar3;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4.CurrentValue=s.thermalCondPar4;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity.CurrentValue=s.thermalConductivity;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance.CurrentValue=s.thermalConductance;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage.CurrentValue=s.heatStorage;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil.CurrentValue=s.volSpecHeatSoil;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday.CurrentValue=s.maxTempYesterday;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday.CurrentValue=s.minTempYesterday;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.windSpeed.CurrentValue=ex.windSpeed;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARB.CurrentValue=s.SLCARB;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCK.CurrentValue=s.SLROCK;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILT.CurrentValue=s.SLSILT;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSAND.CurrentValue=s.SLSAND;
                SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance.CurrentValue=s._boundaryLayerConductance;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.T2M);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.T2M.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMAX);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMAX.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMIN);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TMIN.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TAV);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.TAV.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SW);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SW.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.DOY);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.DOY.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.airPressure);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.airPressure.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.canopyHeight);
                if(r8.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.canopyHeight.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SRAD);
                if(r9.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.SRAD.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ESP);
                if(r10.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ESP.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ES);
                if(r11.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.ES.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.EOAD);
                if(r12.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.EOAD.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp);
                if(r13.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.soilTemp.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature);
                if(r14.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.newTemperature.ValueType)){prc.AddCondition(r14);}
                RangeBasedCondition r15 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp);
                if(r15.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minSoilTemp.ValueType)){prc.AddCondition(r15);}
                RangeBasedCondition r16 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp);
                if(r16.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxSoilTemp.ValueType)){prc.AddCondition(r16);}
                RangeBasedCondition r17 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp);
                if(r17.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.aveSoilTemp.ValueType)){prc.AddCondition(r17);}
                RangeBasedCondition r18 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp);
                if(r18.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.morningSoilTemp.ValueType)){prc.AddCondition(r18);}
                RangeBasedCondition r19 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1);
                if(r19.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar1.ValueType)){prc.AddCondition(r19);}
                RangeBasedCondition r20 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2);
                if(r20.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar2.ValueType)){prc.AddCondition(r20);}
                RangeBasedCondition r21 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3);
                if(r21.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar3.ValueType)){prc.AddCondition(r21);}
                RangeBasedCondition r22 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4);
                if(r22.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalCondPar4.ValueType)){prc.AddCondition(r22);}
                RangeBasedCondition r23 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity);
                if(r23.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductivity.ValueType)){prc.AddCondition(r23);}
                RangeBasedCondition r24 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance);
                if(r24.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.thermalConductance.ValueType)){prc.AddCondition(r24);}
                RangeBasedCondition r25 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage);
                if(r25.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.heatStorage.ValueType)){prc.AddCondition(r25);}
                RangeBasedCondition r26 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil);
                if(r26.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.volSpecHeatSoil.ValueType)){prc.AddCondition(r26);}
                RangeBasedCondition r27 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday);
                if(r27.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.maxTempYesterday.ValueType)){prc.AddCondition(r27);}
                RangeBasedCondition r28 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday);
                if(r28.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.minTempYesterday.ValueType)){prc.AddCondition(r28);}
                RangeBasedCondition r29 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.windSpeed);
                if(r29.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenousVarInfo.windSpeed.ValueType)){prc.AddCondition(r29);}
                RangeBasedCondition r30 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARB);
                if(r30.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLCARB.ValueType)){prc.AddCondition(r30);}
                RangeBasedCondition r31 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCK);
                if(r31.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLROCK.ValueType)){prc.AddCondition(r31);}
                RangeBasedCondition r32 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILT);
                if(r32.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSILT.ValueType)){prc.AddCondition(r32);}
                RangeBasedCondition r33 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSAND);
                if(r33.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo.SLSAND.ValueType)){prc.AddCondition(r33);}
                RangeBasedCondition r34 = new RangeBasedCondition(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance);
                if(r34.ApplicableVarInfoValueTypes.Contains( SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellStateVarInfo._boundaryLayerConductance.ValueType)){prc.AddCondition(r34);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("NLAYR")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("THICK")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DEPTH")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("CONSTANT_TEMPdepth")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("BD")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("TAMP")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("XLAT")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("CLAY")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SALB")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("instrumentHeight")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("boundaryLayerConductanceSource")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("netRadiationSource")));
                string ret = "";
                ret += _campbell.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualitymodel_SoilTempCampbell.Strategies.model_SoilTempCampbell");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.model_SoilTempCampbell, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s1,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellRate r,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellAuxiliary a,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualitymodel_SoilTempCampbell, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s1,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellRate r,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellAuxiliary a,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        Campbell _Campbell = new Campbell();

        private void EstimateOfAssociatedClasses(SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellState s1,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellRate r,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellAuxiliary a,SiriusQualitymodel_SoilTempCampbell.DomainClass.model_SoilTempCampbellExogenous ex)
        {
            _campbell.Estimate(s,s1, r, a, ex);
        }

        public model_SoilTempCampbellComponent(model_SoilTempCampbellComponent toCopy): this() // copy constructor 
        {
                    NLAYR = toCopy.NLAYR;
                    
            for (int i = 0; i < NLAYR; i++)
                { THICK[i] = toCopy.THICK[i]; }
    
                    
            for (int i = 0; i < NLAYR; i++)
                { DEPTH[i] = toCopy.DEPTH[i]; }
    
                    CONSTANT_TEMPdepth = toCopy.CONSTANT_TEMPdepth;
                    
            for (int i = 0; i < NLAYR; i++)
                { BD[i] = toCopy.BD[i]; }
    
                    TAMP = toCopy.TAMP;
                    XLAT = toCopy.XLAT;
                    
            for (int i = 0; i < NLAYR; i++)
                { CLAY[i] = toCopy.CLAY[i]; }
    
                    SALB = toCopy.SALB;
                    instrumentHeight = toCopy.instrumentHeight;
                    boundaryLayerConductanceSource = toCopy.boundaryLayerConductanceSource;
                    netRadiationSource = toCopy.netRadiationSource;
                }
            }
        }