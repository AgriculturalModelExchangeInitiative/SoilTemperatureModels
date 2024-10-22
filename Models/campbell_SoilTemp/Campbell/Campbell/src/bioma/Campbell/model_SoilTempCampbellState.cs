
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace model_SoilTempCampbell.DomainClass
{
    public class model_SoilTempCampbellState : ICloneable, IDomainClass
    {
        private double _airPressure;
        private double[] _soilTemp;
        private double[] _newTemperature;
        private double[] _minSoilTemp;
        private double[] _maxSoilTemp;
        private double[] _aveSoilTemp;
        private double[] _morningSoilTemp;
        private double[] _thermalCondPar1;
        private double[] _thermalCondPar2;
        private double[] _thermalCondPar3;
        private double[] _thermalCondPar4;
        private double[] _thermalConductivity;
        private double[] _thermalConductance;
        private double[] _heatStorage;
        private double[] _volSpecHeatSoil;
        private double _maxTempYesterday;
        private double _minTempYesterday;
        private double[] _SLCARB;
        private double[] _SLROCK;
        private double[] _SLSILT;
        private double[] _SLSAND;
        private double __boundaryLayerConductance;
        private ParametersIO _parametersIO;

        public model_SoilTempCampbellState()
        {
            _parametersIO = new ParametersIO(this);
        }

        public model_SoilTempCampbellState(model_SoilTempCampbellState toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                        airPressure = toCopy.airPressure;
                        soilTemp = new double[toCopy.soilTemp.Length];
            for (int i = 0; i < toCopy.soilTemp.Length; i++)
                { soilTemp[i] = toCopy.soilTemp[i]; }
    
                        newTemperature = new double[toCopy.newTemperature.Length];
            for (int i = 0; i < toCopy.newTemperature.Length; i++)
                { newTemperature[i] = toCopy.newTemperature[i]; }
    
                        minSoilTemp = new double[toCopy.minSoilTemp.Length];
            for (int i = 0; i < toCopy.minSoilTemp.Length; i++)
                { minSoilTemp[i] = toCopy.minSoilTemp[i]; }
    
                        maxSoilTemp = new double[toCopy.maxSoilTemp.Length];
            for (int i = 0; i < toCopy.maxSoilTemp.Length; i++)
                { maxSoilTemp[i] = toCopy.maxSoilTemp[i]; }
    
                        aveSoilTemp = new double[toCopy.aveSoilTemp.Length];
            for (int i = 0; i < toCopy.aveSoilTemp.Length; i++)
                { aveSoilTemp[i] = toCopy.aveSoilTemp[i]; }
    
                        morningSoilTemp = new double[toCopy.morningSoilTemp.Length];
            for (int i = 0; i < toCopy.morningSoilTemp.Length; i++)
                { morningSoilTemp[i] = toCopy.morningSoilTemp[i]; }
    
                        thermalCondPar1 = new double[toCopy.thermalCondPar1.Length];
            for (int i = 0; i < toCopy.thermalCondPar1.Length; i++)
                { thermalCondPar1[i] = toCopy.thermalCondPar1[i]; }
    
                        thermalCondPar2 = new double[toCopy.thermalCondPar2.Length];
            for (int i = 0; i < toCopy.thermalCondPar2.Length; i++)
                { thermalCondPar2[i] = toCopy.thermalCondPar2[i]; }
    
                        thermalCondPar3 = new double[toCopy.thermalCondPar3.Length];
            for (int i = 0; i < toCopy.thermalCondPar3.Length; i++)
                { thermalCondPar3[i] = toCopy.thermalCondPar3[i]; }
    
                        thermalCondPar4 = new double[toCopy.thermalCondPar4.Length];
            for (int i = 0; i < toCopy.thermalCondPar4.Length; i++)
                { thermalCondPar4[i] = toCopy.thermalCondPar4[i]; }
    
                        thermalConductivity = new double[toCopy.thermalConductivity.Length];
            for (int i = 0; i < toCopy.thermalConductivity.Length; i++)
                { thermalConductivity[i] = toCopy.thermalConductivity[i]; }
    
                        thermalConductance = new double[toCopy.thermalConductance.Length];
            for (int i = 0; i < toCopy.thermalConductance.Length; i++)
                { thermalConductance[i] = toCopy.thermalConductance[i]; }
    
                        heatStorage = new double[toCopy.heatStorage.Length];
            for (int i = 0; i < toCopy.heatStorage.Length; i++)
                { heatStorage[i] = toCopy.heatStorage[i]; }
    
                        volSpecHeatSoil = new double[toCopy.volSpecHeatSoil.Length];
            for (int i = 0; i < toCopy.volSpecHeatSoil.Length; i++)
                { volSpecHeatSoil[i] = toCopy.volSpecHeatSoil[i]; }
    
                        maxTempYesterday = toCopy.maxTempYesterday;
                        minTempYesterday = toCopy.minTempYesterday;
                        SLCARB = new double[toCopy.SLCARB.Length];
            for (int i = 0; i < toCopy.SLCARB.Length; i++)
                { SLCARB[i] = toCopy.SLCARB[i]; }
    
                        SLROCK = new double[toCopy.SLROCK.Length];
            for (int i = 0; i < toCopy.SLROCK.Length; i++)
                { SLROCK[i] = toCopy.SLROCK[i]; }
    
                        SLSILT = new double[toCopy.SLSILT.Length];
            for (int i = 0; i < toCopy.SLSILT.Length; i++)
                { SLSILT[i] = toCopy.SLSILT[i]; }
    
                        SLSAND = new double[toCopy.SLSAND.Length];
            for (int i = 0; i < toCopy.SLSAND.Length; i++)
                { SLSAND[i] = toCopy.SLSAND[i]; }
    
                        _boundaryLayerConductance = toCopy._boundaryLayerConductance;
                    }
                }

                public double airPressure
    {
        get { return this._airPressure; }
        set { this._airPressure= value; } 
    }
                public double[] soilTemp
    {
        get { return this._soilTemp; }
        set { this._soilTemp= value; } 
    }
                public double[] newTemperature
    {
        get { return this._newTemperature; }
        set { this._newTemperature= value; } 
    }
                public double[] minSoilTemp
    {
        get { return this._minSoilTemp; }
        set { this._minSoilTemp= value; } 
    }
                public double[] maxSoilTemp
    {
        get { return this._maxSoilTemp; }
        set { this._maxSoilTemp= value; } 
    }
                public double[] aveSoilTemp
    {
        get { return this._aveSoilTemp; }
        set { this._aveSoilTemp= value; } 
    }
                public double[] morningSoilTemp
    {
        get { return this._morningSoilTemp; }
        set { this._morningSoilTemp= value; } 
    }
                public double[] thermalCondPar1
    {
        get { return this._thermalCondPar1; }
        set { this._thermalCondPar1= value; } 
    }
                public double[] thermalCondPar2
    {
        get { return this._thermalCondPar2; }
        set { this._thermalCondPar2= value; } 
    }
                public double[] thermalCondPar3
    {
        get { return this._thermalCondPar3; }
        set { this._thermalCondPar3= value; } 
    }
                public double[] thermalCondPar4
    {
        get { return this._thermalCondPar4; }
        set { this._thermalCondPar4= value; } 
    }
                public double[] thermalConductivity
    {
        get { return this._thermalConductivity; }
        set { this._thermalConductivity= value; } 
    }
                public double[] thermalConductance
    {
        get { return this._thermalConductance; }
        set { this._thermalConductance= value; } 
    }
                public double[] heatStorage
    {
        get { return this._heatStorage; }
        set { this._heatStorage= value; } 
    }
                public double[] volSpecHeatSoil
    {
        get { return this._volSpecHeatSoil; }
        set { this._volSpecHeatSoil= value; } 
    }
                public double maxTempYesterday
    {
        get { return this._maxTempYesterday; }
        set { this._maxTempYesterday= value; } 
    }
                public double minTempYesterday
    {
        get { return this._minTempYesterday; }
        set { this._minTempYesterday= value; } 
    }
                public double[] SLCARB
    {
        get { return this._SLCARB; }
        set { this._SLCARB= value; } 
    }
                public double[] SLROCK
    {
        get { return this._SLROCK; }
        set { this._SLROCK= value; } 
    }
                public double[] SLSILT
    {
        get { return this._SLSILT; }
        set { this._SLSILT= value; } 
    }
                public double[] SLSAND
    {
        get { return this._SLSAND; }
        set { this._SLSAND= value; } 
    }
                public double _boundaryLayerConductance
    {
        get { return this.__boundaryLayerConductance; }
        set { this.__boundaryLayerConductance= value; } 
    }

                public string Description
                {
                    get { return "model_SoilTempCampbellState of the component";}
                }

                public string URL
                {
                    get { return "http://" ;}
                }

                public virtual IDictionary<string, PropertyInfo> PropertiesDescription
                {
                    get { return _parametersIO.GetCachedProperties(typeof(IDomainClass));}
                }

                public virtual Boolean ClearValues()
                {
                     _airPressure = default(double);
                     _soilTemp = new double[NLAYR];
                     _newTemperature = new double[NLAYR];
                     _minSoilTemp = new double[NLAYR];
                     _maxSoilTemp = new double[NLAYR];
                     _aveSoilTemp = new double[NLAYR];
                     _morningSoilTemp = new double[NLAYR];
                     _thermalCondPar1 = new double[NLAYR];
                     _thermalCondPar2 = new double[NLAYR];
                     _thermalCondPar3 = new double[NLAYR];
                     _thermalCondPar4 = new double[NLAYR];
                     _thermalConductivity = new double[NLAYR];
                     _thermalConductance = new double[NLAYR];
                     _heatStorage = new double[NLAYR];
                     _volSpecHeatSoil = new double[NLAYR];
                     _maxTempYesterday = default(double);
                     _minTempYesterday = default(double);
                     _SLCARB = new double[NLAYR];
                     _SLROCK = new double[NLAYR];
                     _SLSILT = new double[NLAYR];
                     _SLSAND = new double[NLAYR];
                     __boundaryLayerConductance = default(double);
                    return true;
                }

                public virtual Object Clone()
                {
                    IDomainClass myclass = (IDomainClass) this.MemberwiseClone();
                    _parametersIO.PopulateClonedCopy(myclass);
                    return myclass;
                }
            }
        }