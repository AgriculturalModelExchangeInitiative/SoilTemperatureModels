
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

using SiriusQualityModel_SoilTempCampbell.DomainClass;
namespace SiriusQualityModel_SoilTempCampbell.Strategies
{
    public class Model_SoilTempCampbellComponent : IStrategySiriusQualityModel_SoilTempCampbell
    {
        public Model_SoilTempCampbellComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'NLAYR'}, "NLAYR");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'THICK'}, "THICK");
            _parameters0_0.Add(v2);
            VarInfo v3 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'BD'}, "BD");
            _parameters0_0.Add(v3);
            VarInfo v4 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'SLCARB'}, "SLCARB");
            _parameters0_0.Add(v4);
            VarInfo v5 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'CLAY'}, "CLAY");
            _parameters0_0.Add(v5);
            VarInfo v6 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'SLROCK'}, "SLROCK");
            _parameters0_0.Add(v6);
            VarInfo v7 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'SLSILT'}, "SLSILT");
            _parameters0_0.Add(v7);
            VarInfo v8 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'SLSAND'}, "SLSAND");
            _parameters0_0.Add(v8);
            VarInfo v9 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'SW'}, "SW");
            _parameters0_0.Add(v9);
            VarInfo v10 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'CONSTANT_TEMPdepth'}, "CONSTANT_TEMPdepth");
            _parameters0_0.Add(v10);
            VarInfo v11 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'TAV'}, "TAV");
            _parameters0_0.Add(v11);
            VarInfo v12 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'TAMP'}, "TAMP");
            _parameters0_0.Add(v12);
            VarInfo v13 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'XLAT'}, "XLAT");
            _parameters0_0.Add(v13);
            VarInfo v14 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'SALB'}, "SALB");
            _parameters0_0.Add(v14);
            VarInfo v15 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'instrumentHeight'}, "instrumentHeight");
            _parameters0_0.Add(v15);
            VarInfo v16 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'boundaryLayerConductanceSource'}, "boundaryLayerConductanceSource");
            _parameters0_0.Add(v16);
            VarInfo v17 = new CompositeStrategyVarInfo(_{'modu': 'Campbell', 'var': 'netRadiationSource'}, "netRadiationSource");
            _parameters0_0.Add(v17);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd1.PropertyName = "THICKApsim";
            pd1.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.THICKApsim).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.THICKApsim);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd2.PropertyName = "DEPTHApsim";
            pd2.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.DEPTHApsim).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.DEPTHApsim);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd3.PropertyName = "BDApsim";
            pd3.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.BDApsim).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.BDApsim);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous);
            pd4.PropertyName = "T2M";
            pd4.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.T2M).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.T2M);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous);
            pd5.PropertyName = "TMAX";
            pd5.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.TMAX).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.TMAX);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous);
            pd6.PropertyName = "TMIN";
            pd6.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.TMIN).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.TMIN);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd7.PropertyName = "CLAYApsim";
            pd7.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.CLAYApsim).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.CLAYApsim);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd8.PropertyName = "SWApsim";
            pd8.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SWApsim).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SWApsim);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous);
            pd9.PropertyName = "DOY";
            pd9.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.DOY).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.DOY);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous);
            pd10.PropertyName = "airPressure";
            pd10.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.airPressure).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.airPressure);
            _inputs0_0.Add(pd10);
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous);
            pd11.PropertyName = "canopyHeight";
            pd11.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.canopyHeight).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.canopyHeight);
            _inputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous);
            pd12.PropertyName = "SRAD";
            pd12.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.SRAD).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.SRAD);
            _inputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous);
            pd13.PropertyName = "ESP";
            pd13.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.ESP).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.ESP);
            _inputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous);
            pd14.PropertyName = "ES";
            pd14.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.ES).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.ES);
            _inputs0_0.Add(pd14);
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous);
            pd15.PropertyName = "EOAD";
            pd15.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.EOAD).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.EOAD);
            _inputs0_0.Add(pd15);
            PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd16.PropertyName = "soilTemp";
            pd16.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.soilTemp).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.soilTemp);
            _inputs0_0.Add(pd16);
            PropertyDescription pd17 = new PropertyDescription();
            pd17.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd17.PropertyName = "newTemperature";
            pd17.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.newTemperature).ValueType.TypeForCurrentValue;
            pd17.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.newTemperature);
            _inputs0_0.Add(pd17);
            PropertyDescription pd18 = new PropertyDescription();
            pd18.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd18.PropertyName = "minSoilTemp";
            pd18.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minSoilTemp).ValueType.TypeForCurrentValue;
            pd18.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minSoilTemp);
            _inputs0_0.Add(pd18);
            PropertyDescription pd19 = new PropertyDescription();
            pd19.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd19.PropertyName = "maxSoilTemp";
            pd19.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxSoilTemp).ValueType.TypeForCurrentValue;
            pd19.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxSoilTemp);
            _inputs0_0.Add(pd19);
            PropertyDescription pd20 = new PropertyDescription();
            pd20.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd20.PropertyName = "aveSoilTemp";
            pd20.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.aveSoilTemp).ValueType.TypeForCurrentValue;
            pd20.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.aveSoilTemp);
            _inputs0_0.Add(pd20);
            PropertyDescription pd21 = new PropertyDescription();
            pd21.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd21.PropertyName = "morningSoilTemp";
            pd21.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.morningSoilTemp).ValueType.TypeForCurrentValue;
            pd21.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.morningSoilTemp);
            _inputs0_0.Add(pd21);
            PropertyDescription pd22 = new PropertyDescription();
            pd22.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd22.PropertyName = "thermalCondPar1";
            pd22.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar1).ValueType.TypeForCurrentValue;
            pd22.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar1);
            _inputs0_0.Add(pd22);
            PropertyDescription pd23 = new PropertyDescription();
            pd23.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd23.PropertyName = "thermalCondPar2";
            pd23.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar2).ValueType.TypeForCurrentValue;
            pd23.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar2);
            _inputs0_0.Add(pd23);
            PropertyDescription pd24 = new PropertyDescription();
            pd24.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd24.PropertyName = "thermalCondPar3";
            pd24.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar3).ValueType.TypeForCurrentValue;
            pd24.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar3);
            _inputs0_0.Add(pd24);
            PropertyDescription pd25 = new PropertyDescription();
            pd25.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd25.PropertyName = "thermalCondPar4";
            pd25.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar4).ValueType.TypeForCurrentValue;
            pd25.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar4);
            _inputs0_0.Add(pd25);
            PropertyDescription pd26 = new PropertyDescription();
            pd26.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd26.PropertyName = "thermalConductivity";
            pd26.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductivity).ValueType.TypeForCurrentValue;
            pd26.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductivity);
            _inputs0_0.Add(pd26);
            PropertyDescription pd27 = new PropertyDescription();
            pd27.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd27.PropertyName = "thermalConductance";
            pd27.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductance).ValueType.TypeForCurrentValue;
            pd27.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductance);
            _inputs0_0.Add(pd27);
            PropertyDescription pd28 = new PropertyDescription();
            pd28.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd28.PropertyName = "heatStorage";
            pd28.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.heatStorage).ValueType.TypeForCurrentValue;
            pd28.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.heatStorage);
            _inputs0_0.Add(pd28);
            PropertyDescription pd29 = new PropertyDescription();
            pd29.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd29.PropertyName = "volSpecHeatSoil";
            pd29.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.volSpecHeatSoil).ValueType.TypeForCurrentValue;
            pd29.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.volSpecHeatSoil);
            _inputs0_0.Add(pd29);
            PropertyDescription pd30 = new PropertyDescription();
            pd30.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd30.PropertyName = "maxTempYesterday";
            pd30.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxTempYesterday).ValueType.TypeForCurrentValue;
            pd30.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxTempYesterday);
            _inputs0_0.Add(pd30);
            PropertyDescription pd31 = new PropertyDescription();
            pd31.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd31.PropertyName = "minTempYesterday";
            pd31.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minTempYesterday).ValueType.TypeForCurrentValue;
            pd31.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minTempYesterday);
            _inputs0_0.Add(pd31);
            PropertyDescription pd32 = new PropertyDescription();
            pd32.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous);
            pd32.PropertyName = "windSpeed";
            pd32.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.windSpeed).ValueType.TypeForCurrentValue;
            pd32.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.windSpeed);
            _inputs0_0.Add(pd32);
            PropertyDescription pd33 = new PropertyDescription();
            pd33.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd33.PropertyName = "SLCARBApsim";
            pd33.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLCARBApsim).ValueType.TypeForCurrentValue;
            pd33.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLCARBApsim);
            _inputs0_0.Add(pd33);
            PropertyDescription pd34 = new PropertyDescription();
            pd34.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd34.PropertyName = "SLROCKApsim";
            pd34.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLROCKApsim).ValueType.TypeForCurrentValue;
            pd34.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLROCKApsim);
            _inputs0_0.Add(pd34);
            PropertyDescription pd35 = new PropertyDescription();
            pd35.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd35.PropertyName = "SLSILTApsim";
            pd35.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSILTApsim).ValueType.TypeForCurrentValue;
            pd35.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSILTApsim);
            _inputs0_0.Add(pd35);
            PropertyDescription pd36 = new PropertyDescription();
            pd36.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd36.PropertyName = "SLSANDApsim";
            pd36.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSANDApsim).ValueType.TypeForCurrentValue;
            pd36.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSANDApsim);
            _inputs0_0.Add(pd36);
            PropertyDescription pd37 = new PropertyDescription();
            pd37.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd37.PropertyName = "_boundaryLayerConductance";
            pd37.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo._boundaryLayerConductance).ValueType.TypeForCurrentValue;
            pd37.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo._boundaryLayerConductance);
            _inputs0_0.Add(pd37);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd38 = new PropertyDescription();
            pd38.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd38.PropertyName = "soilTemp";
            pd38.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.soilTemp).ValueType.TypeForCurrentValue;
            pd38.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.soilTemp);
            _outputs0_0.Add(pd38);
            PropertyDescription pd39 = new PropertyDescription();
            pd39.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd39.PropertyName = "minSoilTemp";
            pd39.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minSoilTemp).ValueType.TypeForCurrentValue;
            pd39.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minSoilTemp);
            _outputs0_0.Add(pd39);
            PropertyDescription pd40 = new PropertyDescription();
            pd40.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd40.PropertyName = "maxSoilTemp";
            pd40.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxSoilTemp).ValueType.TypeForCurrentValue;
            pd40.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxSoilTemp);
            _outputs0_0.Add(pd40);
            PropertyDescription pd41 = new PropertyDescription();
            pd41.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd41.PropertyName = "aveSoilTemp";
            pd41.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.aveSoilTemp).ValueType.TypeForCurrentValue;
            pd41.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.aveSoilTemp);
            _outputs0_0.Add(pd41);
            PropertyDescription pd42 = new PropertyDescription();
            pd42.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd42.PropertyName = "morningSoilTemp";
            pd42.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.morningSoilTemp).ValueType.TypeForCurrentValue;
            pd42.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.morningSoilTemp);
            _outputs0_0.Add(pd42);
            PropertyDescription pd43 = new PropertyDescription();
            pd43.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd43.PropertyName = "newTemperature";
            pd43.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.newTemperature).ValueType.TypeForCurrentValue;
            pd43.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.newTemperature);
            _outputs0_0.Add(pd43);
            PropertyDescription pd44 = new PropertyDescription();
            pd44.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd44.PropertyName = "maxTempYesterday";
            pd44.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxTempYesterday).ValueType.TypeForCurrentValue;
            pd44.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxTempYesterday);
            _outputs0_0.Add(pd44);
            PropertyDescription pd45 = new PropertyDescription();
            pd45.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd45.PropertyName = "minTempYesterday";
            pd45.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minTempYesterday).ValueType.TypeForCurrentValue;
            pd45.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minTempYesterday);
            _outputs0_0.Add(pd45);
            PropertyDescription pd46 = new PropertyDescription();
            pd46.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd46.PropertyName = "thermalCondPar1";
            pd46.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar1).ValueType.TypeForCurrentValue;
            pd46.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar1);
            _outputs0_0.Add(pd46);
            PropertyDescription pd47 = new PropertyDescription();
            pd47.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd47.PropertyName = "thermalCondPar2";
            pd47.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar2).ValueType.TypeForCurrentValue;
            pd47.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar2);
            _outputs0_0.Add(pd47);
            PropertyDescription pd48 = new PropertyDescription();
            pd48.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd48.PropertyName = "thermalCondPar3";
            pd48.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar3).ValueType.TypeForCurrentValue;
            pd48.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar3);
            _outputs0_0.Add(pd48);
            PropertyDescription pd49 = new PropertyDescription();
            pd49.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd49.PropertyName = "thermalCondPar4";
            pd49.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar4).ValueType.TypeForCurrentValue;
            pd49.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar4);
            _outputs0_0.Add(pd49);
            PropertyDescription pd50 = new PropertyDescription();
            pd50.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd50.PropertyName = "thermalConductivity";
            pd50.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductivity).ValueType.TypeForCurrentValue;
            pd50.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductivity);
            _outputs0_0.Add(pd50);
            PropertyDescription pd51 = new PropertyDescription();
            pd51.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd51.PropertyName = "thermalConductance";
            pd51.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductance).ValueType.TypeForCurrentValue;
            pd51.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductance);
            _outputs0_0.Add(pd51);
            PropertyDescription pd52 = new PropertyDescription();
            pd52.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd52.PropertyName = "heatStorage";
            pd52.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.heatStorage).ValueType.TypeForCurrentValue;
            pd52.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.heatStorage);
            _outputs0_0.Add(pd52);
            PropertyDescription pd53 = new PropertyDescription();
            pd53.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd53.PropertyName = "volSpecHeatSoil";
            pd53.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.volSpecHeatSoil).ValueType.TypeForCurrentValue;
            pd53.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.volSpecHeatSoil);
            _outputs0_0.Add(pd53);
            PropertyDescription pd54 = new PropertyDescription();
            pd54.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd54.PropertyName = "_boundaryLayerConductance";
            pd54.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo._boundaryLayerConductance).ValueType.TypeForCurrentValue;
            pd54.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo._boundaryLayerConductance);
            _outputs0_0.Add(pd54);
            PropertyDescription pd55 = new PropertyDescription();
            pd55.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd55.PropertyName = "THICKApsim";
            pd55.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.THICKApsim).ValueType.TypeForCurrentValue;
            pd55.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.THICKApsim);
            _outputs0_0.Add(pd55);
            PropertyDescription pd56 = new PropertyDescription();
            pd56.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd56.PropertyName = "DEPTHApsim";
            pd56.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.DEPTHApsim).ValueType.TypeForCurrentValue;
            pd56.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.DEPTHApsim);
            _outputs0_0.Add(pd56);
            PropertyDescription pd57 = new PropertyDescription();
            pd57.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd57.PropertyName = "BDApsim";
            pd57.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.BDApsim).ValueType.TypeForCurrentValue;
            pd57.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.BDApsim);
            _outputs0_0.Add(pd57);
            PropertyDescription pd58 = new PropertyDescription();
            pd58.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd58.PropertyName = "SWApsim";
            pd58.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SWApsim).ValueType.TypeForCurrentValue;
            pd58.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SWApsim);
            _outputs0_0.Add(pd58);
            PropertyDescription pd59 = new PropertyDescription();
            pd59.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd59.PropertyName = "CLAYApsim";
            pd59.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.CLAYApsim).ValueType.TypeForCurrentValue;
            pd59.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.CLAYApsim);
            _outputs0_0.Add(pd59);
            PropertyDescription pd60 = new PropertyDescription();
            pd60.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd60.PropertyName = "SLROCKApsim";
            pd60.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLROCKApsim).ValueType.TypeForCurrentValue;
            pd60.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLROCKApsim);
            _outputs0_0.Add(pd60);
            PropertyDescription pd61 = new PropertyDescription();
            pd61.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd61.PropertyName = "SLCARBApsim";
            pd61.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLCARBApsim).ValueType.TypeForCurrentValue;
            pd61.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLCARBApsim);
            _outputs0_0.Add(pd61);
            PropertyDescription pd62 = new PropertyDescription();
            pd62.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd62.PropertyName = "SLSANDApsim";
            pd62.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSANDApsim).ValueType.TypeForCurrentValue;
            pd62.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSANDApsim);
            _outputs0_0.Add(pd62);
            PropertyDescription pd63 = new PropertyDescription();
            pd63.DomainClassType = typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState);
            pd63.PropertyName = "SLSILTApsim";
            pd63.PropertyType = (SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSILTApsim).ValueType.TypeForCurrentValue;
            pd63.PropertyVarInfo =(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSILTApsim);
            _outputs0_0.Add(pd63);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(SiriusQualityModel_SoilTempCampbell.Strategies.Campbell).FullName);
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
            return new List<Type>() {  typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState), typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState), typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellRate), typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellAuxiliary), typeof(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous)};
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
        public double[] SLCARB
        {
            get
            {
                 return _Campbell.SLCARB; 
            }
            set
            {
                _Campbell.SLCARB = value;
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
        public double[] SLROCK
        {
            get
            {
                 return _Campbell.SLROCK; 
            }
            set
            {
                _Campbell.SLROCK = value;
            }
        }
        public double[] SLSILT
        {
            get
            {
                 return _Campbell.SLSILT; 
            }
            set
            {
                _Campbell.SLSILT = value;
            }
        }
        public double[] SLSAND
        {
            get
            {
                 return _Campbell.SLSAND; 
            }
            set
            {
                _Campbell.SLSAND = value;
            }
        }
        public double[] SW
        {
            get
            {
                 return _Campbell.SW; 
            }
            set
            {
                _Campbell.SW = value;
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
        public double TAV
        {
            get
            {
                 return _Campbell.TAV; 
            }
            set
            {
                _Campbell.TAV = value;
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
            _Campbell.SetParametersDefaultValue();
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
            THICKVarInfo.Description = "Soil layer thickness of layers";
            THICKVarInfo.MaxValue = -1D;
            THICKVarInfo.MinValue = -1D;
            THICKVarInfo.DefaultValue = -1D;
            THICKVarInfo.Units = "mm";
            THICKVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            BDVarInfo.Name = "BD";
            BDVarInfo.Description = "bd (soil bulk density)";
            BDVarInfo.MaxValue = -1D;
            BDVarInfo.MinValue = -1D;
            BDVarInfo.DefaultValue = -1D;
            BDVarInfo.Units = "g/cm3             uri :";
            BDVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            SLCARBVarInfo.Name = "SLCARB";
            SLCARBVarInfo.Description = "Volumetric fraction of organic matter in the soil";
            SLCARBVarInfo.MaxValue = -1D;
            SLCARBVarInfo.MinValue = -1D;
            SLCARBVarInfo.DefaultValue = -1D;
            SLCARBVarInfo.Units = "";
            SLCARBVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            CLAYVarInfo.Name = "CLAY";
            CLAYVarInfo.Description = "Proportion of CLAY in each layer of profile";
            CLAYVarInfo.MaxValue = -1D;
            CLAYVarInfo.MinValue = -1D;
            CLAYVarInfo.DefaultValue = -1D;
            CLAYVarInfo.Units = "";
            CLAYVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            SLROCKVarInfo.Name = "SLROCK";
            SLROCKVarInfo.Description = "Volumetric fraction of rocks in the soil";
            SLROCKVarInfo.MaxValue = -1D;
            SLROCKVarInfo.MinValue = -1D;
            SLROCKVarInfo.DefaultValue = -1D;
            SLROCKVarInfo.Units = "";
            SLROCKVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            SLSILTVarInfo.Name = "SLSILT";
            SLSILTVarInfo.Description = "Volumetric fraction of silt in the soil";
            SLSILTVarInfo.MaxValue = -1D;
            SLSILTVarInfo.MinValue = -1D;
            SLSILTVarInfo.DefaultValue = -1D;
            SLSILTVarInfo.Units = "";
            SLSILTVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            SLSANDVarInfo.Name = "SLSAND";
            SLSANDVarInfo.Description = "Volumetric fraction of sand in the soil";
            SLSANDVarInfo.MaxValue = -1D;
            SLSANDVarInfo.MinValue = -1D;
            SLSANDVarInfo.DefaultValue = -1D;
            SLSANDVarInfo.Units = "";
            SLSANDVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            SWVarInfo.Name = "SW";
            SWVarInfo.Description = "volumetric water content";
            SWVarInfo.MaxValue = -1D;
            SWVarInfo.MinValue = -1D;
            SWVarInfo.DefaultValue = -1D;
            SWVarInfo.Units = "cc water / cc soil";
            SWVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            CONSTANT_TEMPdepthVarInfo.Name = "CONSTANT_TEMPdepth";
            CONSTANT_TEMPdepthVarInfo.Description = "Depth of constant temperature";
            CONSTANT_TEMPdepthVarInfo.MaxValue = -1D;
            CONSTANT_TEMPdepthVarInfo.MinValue = -1D;
            CONSTANT_TEMPdepthVarInfo.DefaultValue = 1000.0;
            CONSTANT_TEMPdepthVarInfo.Units = "mm";
            CONSTANT_TEMPdepthVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            TAVVarInfo.Name = "TAV";
            TAVVarInfo.Description = "Average annual air temperature";
            TAVVarInfo.MaxValue = 60;
            TAVVarInfo.MinValue = -60;
            TAVVarInfo.DefaultValue = -1D;
            TAVVarInfo.Units = "";
            TAVVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

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
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'NLAYR'}.NLAYRVarInfo;} 
        }

        public static VarInfo THICKVarInfo
        {
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'THICK'}.THICKVarInfo;} 
        }

        public static VarInfo BDVarInfo
        {
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'BD'}.BDVarInfo;} 
        }

        public static VarInfo SLCARBVarInfo
        {
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'SLCARB'}.SLCARBVarInfo;} 
        }

        public static VarInfo CLAYVarInfo
        {
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'CLAY'}.CLAYVarInfo;} 
        }

        public static VarInfo SLROCKVarInfo
        {
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'SLROCK'}.SLROCKVarInfo;} 
        }

        public static VarInfo SLSILTVarInfo
        {
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'SLSILT'}.SLSILTVarInfo;} 
        }

        public static VarInfo SLSANDVarInfo
        {
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'SLSAND'}.SLSANDVarInfo;} 
        }

        public static VarInfo SWVarInfo
        {
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'SW'}.SWVarInfo;} 
        }

        public static VarInfo CONSTANT_TEMPdepthVarInfo
        {
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'CONSTANT_TEMPdepth'}.CONSTANT_TEMPdepthVarInfo;} 
        }

        public static VarInfo TAVVarInfo
        {
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'TAV'}.TAVVarInfo;} 
        }

        public static VarInfo TAMPVarInfo
        {
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'TAMP'}.TAMPVarInfo;} 
        }

        public static VarInfo XLATVarInfo
        {
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'XLAT'}.XLATVarInfo;} 
        }

        public static VarInfo SALBVarInfo
        {
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'SALB'}.SALBVarInfo;} 
        }

        public static VarInfo instrumentHeightVarInfo
        {
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'instrumentHeight'}.instrumentHeightVarInfo;} 
        }

        public static VarInfo boundaryLayerConductanceSourceVarInfo
        {
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'boundaryLayerConductanceSource'}.boundaryLayerConductanceSourceVarInfo;} 
        }

        public static VarInfo netRadiationSourceVarInfo
        {
            get { return SiriusQualityModel_SoilTempCampbell.Strategies.{'modu': 'Campbell', 'var': 'netRadiationSource'}.netRadiationSourceVarInfo;} 
        }

        public string TestPostConditions(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState s,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState s1,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellRate r,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellAuxiliary a,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.soilTemp.CurrentValue=s.soilTemp;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minSoilTemp.CurrentValue=s.minSoilTemp;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxSoilTemp.CurrentValue=s.maxSoilTemp;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.aveSoilTemp.CurrentValue=s.aveSoilTemp;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.morningSoilTemp.CurrentValue=s.morningSoilTemp;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.newTemperature.CurrentValue=s.newTemperature;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxTempYesterday.CurrentValue=s.maxTempYesterday;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minTempYesterday.CurrentValue=s.minTempYesterday;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar1.CurrentValue=s.thermalCondPar1;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar2.CurrentValue=s.thermalCondPar2;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar3.CurrentValue=s.thermalCondPar3;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar4.CurrentValue=s.thermalCondPar4;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductivity.CurrentValue=s.thermalConductivity;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductance.CurrentValue=s.thermalConductance;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.heatStorage.CurrentValue=s.heatStorage;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.volSpecHeatSoil.CurrentValue=s.volSpecHeatSoil;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo._boundaryLayerConductance.CurrentValue=s._boundaryLayerConductance;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.THICKApsim.CurrentValue=s.THICKApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.DEPTHApsim.CurrentValue=s.DEPTHApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.BDApsim.CurrentValue=s.BDApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SWApsim.CurrentValue=s.SWApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.CLAYApsim.CurrentValue=s.CLAYApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLROCKApsim.CurrentValue=s.SLROCKApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLCARBApsim.CurrentValue=s.SLCARBApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSANDApsim.CurrentValue=s.SLSANDApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSILTApsim.CurrentValue=s.SLSILTApsim;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r55 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.soilTemp);
                if(r55.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.soilTemp.ValueType)){prc.AddCondition(r55);}
                RangeBasedCondition r56 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minSoilTemp);
                if(r56.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minSoilTemp.ValueType)){prc.AddCondition(r56);}
                RangeBasedCondition r57 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxSoilTemp);
                if(r57.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxSoilTemp.ValueType)){prc.AddCondition(r57);}
                RangeBasedCondition r58 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.aveSoilTemp);
                if(r58.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.aveSoilTemp.ValueType)){prc.AddCondition(r58);}
                RangeBasedCondition r59 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.morningSoilTemp);
                if(r59.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.morningSoilTemp.ValueType)){prc.AddCondition(r59);}
                RangeBasedCondition r60 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.newTemperature);
                if(r60.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.newTemperature.ValueType)){prc.AddCondition(r60);}
                RangeBasedCondition r61 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxTempYesterday);
                if(r61.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxTempYesterday.ValueType)){prc.AddCondition(r61);}
                RangeBasedCondition r62 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minTempYesterday);
                if(r62.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minTempYesterday.ValueType)){prc.AddCondition(r62);}
                RangeBasedCondition r63 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar1);
                if(r63.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar1.ValueType)){prc.AddCondition(r63);}
                RangeBasedCondition r64 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar2);
                if(r64.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar2.ValueType)){prc.AddCondition(r64);}
                RangeBasedCondition r65 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar3);
                if(r65.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar3.ValueType)){prc.AddCondition(r65);}
                RangeBasedCondition r66 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar4);
                if(r66.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar4.ValueType)){prc.AddCondition(r66);}
                RangeBasedCondition r67 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductivity);
                if(r67.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductivity.ValueType)){prc.AddCondition(r67);}
                RangeBasedCondition r68 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductance);
                if(r68.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductance.ValueType)){prc.AddCondition(r68);}
                RangeBasedCondition r69 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.heatStorage);
                if(r69.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.heatStorage.ValueType)){prc.AddCondition(r69);}
                RangeBasedCondition r70 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.volSpecHeatSoil);
                if(r70.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.volSpecHeatSoil.ValueType)){prc.AddCondition(r70);}
                RangeBasedCondition r71 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo._boundaryLayerConductance);
                if(r71.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo._boundaryLayerConductance.ValueType)){prc.AddCondition(r71);}
                RangeBasedCondition r72 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.THICKApsim);
                if(r72.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.THICKApsim.ValueType)){prc.AddCondition(r72);}
                RangeBasedCondition r73 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.DEPTHApsim);
                if(r73.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.DEPTHApsim.ValueType)){prc.AddCondition(r73);}
                RangeBasedCondition r74 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.BDApsim);
                if(r74.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.BDApsim.ValueType)){prc.AddCondition(r74);}
                RangeBasedCondition r75 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SWApsim);
                if(r75.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SWApsim.ValueType)){prc.AddCondition(r75);}
                RangeBasedCondition r76 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.CLAYApsim);
                if(r76.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.CLAYApsim.ValueType)){prc.AddCondition(r76);}
                RangeBasedCondition r77 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLROCKApsim);
                if(r77.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLROCKApsim.ValueType)){prc.AddCondition(r77);}
                RangeBasedCondition r78 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLCARBApsim);
                if(r78.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLCARBApsim.ValueType)){prc.AddCondition(r78);}
                RangeBasedCondition r79 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSANDApsim);
                if(r79.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSANDApsim.ValueType)){prc.AddCondition(r79);}
                RangeBasedCondition r80 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSILTApsim);
                if(r80.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSILTApsim.ValueType)){prc.AddCondition(r80);}

                string ret = "";
                ret += _Campbell.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualityModel_SoilTempCampbell.Strategies.Model_SoilTempCampbell");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.Model_SoilTempCampbell, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState s,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState s1,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellRate r,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellAuxiliary a,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.THICKApsim.CurrentValue=s.THICKApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.DEPTHApsim.CurrentValue=s.DEPTHApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.BDApsim.CurrentValue=s.BDApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.T2M.CurrentValue=ex.T2M;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.TMAX.CurrentValue=ex.TMAX;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.TMIN.CurrentValue=ex.TMIN;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.CLAYApsim.CurrentValue=s.CLAYApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SWApsim.CurrentValue=s.SWApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.DOY.CurrentValue=ex.DOY;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.airPressure.CurrentValue=ex.airPressure;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.canopyHeight.CurrentValue=ex.canopyHeight;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.SRAD.CurrentValue=ex.SRAD;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.ESP.CurrentValue=ex.ESP;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.ES.CurrentValue=ex.ES;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.EOAD.CurrentValue=ex.EOAD;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.soilTemp.CurrentValue=s.soilTemp;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.newTemperature.CurrentValue=s.newTemperature;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minSoilTemp.CurrentValue=s.minSoilTemp;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxSoilTemp.CurrentValue=s.maxSoilTemp;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.aveSoilTemp.CurrentValue=s.aveSoilTemp;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.morningSoilTemp.CurrentValue=s.morningSoilTemp;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar1.CurrentValue=s.thermalCondPar1;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar2.CurrentValue=s.thermalCondPar2;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar3.CurrentValue=s.thermalCondPar3;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar4.CurrentValue=s.thermalCondPar4;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductivity.CurrentValue=s.thermalConductivity;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductance.CurrentValue=s.thermalConductance;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.heatStorage.CurrentValue=s.heatStorage;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.volSpecHeatSoil.CurrentValue=s.volSpecHeatSoil;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxTempYesterday.CurrentValue=s.maxTempYesterday;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minTempYesterday.CurrentValue=s.minTempYesterday;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.windSpeed.CurrentValue=ex.windSpeed;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLCARBApsim.CurrentValue=s.SLCARBApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLROCKApsim.CurrentValue=s.SLROCKApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSILTApsim.CurrentValue=s.SLSILTApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSANDApsim.CurrentValue=s.SLSANDApsim;
                SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo._boundaryLayerConductance.CurrentValue=s._boundaryLayerConductance;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.THICKApsim);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.THICKApsim.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.DEPTHApsim);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.DEPTHApsim.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.BDApsim);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.BDApsim.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.T2M);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.T2M.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.TMAX);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.TMAX.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.TMIN);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.TMIN.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.CLAYApsim);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.CLAYApsim.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SWApsim);
                if(r8.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SWApsim.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.DOY);
                if(r9.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.DOY.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.airPressure);
                if(r10.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.airPressure.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.canopyHeight);
                if(r11.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.canopyHeight.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.SRAD);
                if(r12.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.SRAD.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.ESP);
                if(r13.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.ESP.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.ES);
                if(r14.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.ES.ValueType)){prc.AddCondition(r14);}
                RangeBasedCondition r15 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.EOAD);
                if(r15.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.EOAD.ValueType)){prc.AddCondition(r15);}
                RangeBasedCondition r16 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.soilTemp);
                if(r16.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.soilTemp.ValueType)){prc.AddCondition(r16);}
                RangeBasedCondition r17 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.newTemperature);
                if(r17.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.newTemperature.ValueType)){prc.AddCondition(r17);}
                RangeBasedCondition r18 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minSoilTemp);
                if(r18.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minSoilTemp.ValueType)){prc.AddCondition(r18);}
                RangeBasedCondition r19 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxSoilTemp);
                if(r19.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxSoilTemp.ValueType)){prc.AddCondition(r19);}
                RangeBasedCondition r20 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.aveSoilTemp);
                if(r20.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.aveSoilTemp.ValueType)){prc.AddCondition(r20);}
                RangeBasedCondition r21 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.morningSoilTemp);
                if(r21.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.morningSoilTemp.ValueType)){prc.AddCondition(r21);}
                RangeBasedCondition r22 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar1);
                if(r22.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar1.ValueType)){prc.AddCondition(r22);}
                RangeBasedCondition r23 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar2);
                if(r23.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar2.ValueType)){prc.AddCondition(r23);}
                RangeBasedCondition r24 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar3);
                if(r24.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar3.ValueType)){prc.AddCondition(r24);}
                RangeBasedCondition r25 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar4);
                if(r25.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalCondPar4.ValueType)){prc.AddCondition(r25);}
                RangeBasedCondition r26 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductivity);
                if(r26.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductivity.ValueType)){prc.AddCondition(r26);}
                RangeBasedCondition r27 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductance);
                if(r27.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.thermalConductance.ValueType)){prc.AddCondition(r27);}
                RangeBasedCondition r28 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.heatStorage);
                if(r28.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.heatStorage.ValueType)){prc.AddCondition(r28);}
                RangeBasedCondition r29 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.volSpecHeatSoil);
                if(r29.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.volSpecHeatSoil.ValueType)){prc.AddCondition(r29);}
                RangeBasedCondition r30 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxTempYesterday);
                if(r30.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.maxTempYesterday.ValueType)){prc.AddCondition(r30);}
                RangeBasedCondition r31 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minTempYesterday);
                if(r31.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.minTempYesterday.ValueType)){prc.AddCondition(r31);}
                RangeBasedCondition r32 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.windSpeed);
                if(r32.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenousVarInfo.windSpeed.ValueType)){prc.AddCondition(r32);}
                RangeBasedCondition r33 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLCARBApsim);
                if(r33.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLCARBApsim.ValueType)){prc.AddCondition(r33);}
                RangeBasedCondition r34 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLROCKApsim);
                if(r34.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLROCKApsim.ValueType)){prc.AddCondition(r34);}
                RangeBasedCondition r35 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSILTApsim);
                if(r35.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSILTApsim.ValueType)){prc.AddCondition(r35);}
                RangeBasedCondition r36 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSANDApsim);
                if(r36.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo.SLSANDApsim.ValueType)){prc.AddCondition(r36);}
                RangeBasedCondition r37 = new RangeBasedCondition(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo._boundaryLayerConductance);
                if(r37.ApplicableVarInfoValueTypes.Contains( SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellStateVarInfo._boundaryLayerConductance.ValueType)){prc.AddCondition(r37);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("NLAYR")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("THICK")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("BD")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SLCARB")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("CLAY")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SLROCK")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SLSILT")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SLSAND")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SW")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("CONSTANT_TEMPdepth")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("TAV")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("TAMP")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("XLAT")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SALB")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("instrumentHeight")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("boundaryLayerConductanceSource")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("netRadiationSource")));
                string ret = "";
                ret += _Campbell.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualityModel_SoilTempCampbell.Strategies.Model_SoilTempCampbell");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.Model_SoilTempCampbell, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState s,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState s1,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellRate r,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellAuxiliary a,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualityModel_SoilTempCampbell, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState s,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState s1,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellRate r,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellAuxiliary a,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        Campbell _Campbell = new Campbell();

        private void EstimateOfAssociatedClasses(SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState s,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellState s1,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellRate r,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellAuxiliary a,SiriusQualityModel_SoilTempCampbell.DomainClass.Model_SoilTempCampbellExogenous ex)
        {
            _Campbell.Estimate(s,s1, r, a, ex);
        }

        public Model_SoilTempCampbellComponent(Model_SoilTempCampbellComponent toCopy): this() // copy constructor 
        {
                    NLAYR = toCopy.NLAYR;
                    
            for (int i = 0; i < NLAYR; i++)
                { THICK[i] = toCopy.THICK[i]; }
    
                    
            for (int i = 0; i < NLAYR; i++)
                { BD[i] = toCopy.BD[i]; }
    
                    
            for (int i = 0; i < NLAYR; i++)
                { SLCARB[i] = toCopy.SLCARB[i]; }
    
                    
            for (int i = 0; i < NLAYR; i++)
                { CLAY[i] = toCopy.CLAY[i]; }
    
                    
            for (int i = 0; i < NLAYR; i++)
                { SLROCK[i] = toCopy.SLROCK[i]; }
    
                    
            for (int i = 0; i < NLAYR; i++)
                { SLSILT[i] = toCopy.SLSILT[i]; }
    
                    
            for (int i = 0; i < NLAYR; i++)
                { SLSAND[i] = toCopy.SLSAND[i]; }
    
                    
            for (int i = 0; i < NLAYR; i++)
                { SW[i] = toCopy.SW[i]; }
    
                    CONSTANT_TEMPdepth = toCopy.CONSTANT_TEMPdepth;
                    TAV = toCopy.TAV;
                    TAMP = toCopy.TAMP;
                    XLAT = toCopy.XLAT;
                    SALB = toCopy.SALB;
                    instrumentHeight = toCopy.instrumentHeight;
                    boundaryLayerConductanceSource = toCopy.boundaryLayerConductanceSource;
                    netRadiationSource = toCopy.netRadiationSource;
                }
            }
        }