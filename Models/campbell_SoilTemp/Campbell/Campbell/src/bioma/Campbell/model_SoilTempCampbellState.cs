
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace model_SoilTempCampbell.DomainClass
{
    public class model_SoilTempCampbellState : ICloneable, IDomainClass
    {
        private double[] _THICKApsim;
        private double[] _DEPTHApsim;
        private double[] _BDApsim;
        private double[] _CLAYApsim;
        private double[] _SWApsim;
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
        private double[] _SLCARBApsim;
        private double[] _SLROCKApsim;
        private double[] _SLSILTApsim;
        private double[] _SLSANDApsim;
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
                        THICKApsim = new double[toCopy.THICKApsim.Length];
            for (int i = 0; i < toCopy.THICKApsim.Length; i++)
                { THICKApsim[i] = toCopy.THICKApsim[i]; }
    
                        DEPTHApsim = new double[toCopy.DEPTHApsim.Length];
            for (int i = 0; i < toCopy.DEPTHApsim.Length; i++)
                { DEPTHApsim[i] = toCopy.DEPTHApsim[i]; }
    
                        BDApsim = new double[toCopy.BDApsim.Length];
            for (int i = 0; i < toCopy.BDApsim.Length; i++)
                { BDApsim[i] = toCopy.BDApsim[i]; }
    
                        CLAYApsim = new double[toCopy.CLAYApsim.Length];
            for (int i = 0; i < toCopy.CLAYApsim.Length; i++)
                { CLAYApsim[i] = toCopy.CLAYApsim[i]; }
    
                        SWApsim = new double[toCopy.SWApsim.Length];
            for (int i = 0; i < toCopy.SWApsim.Length; i++)
                { SWApsim[i] = toCopy.SWApsim[i]; }
    
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
                        SLCARBApsim = new double[toCopy.SLCARBApsim.Length];
            for (int i = 0; i < toCopy.SLCARBApsim.Length; i++)
                { SLCARBApsim[i] = toCopy.SLCARBApsim[i]; }
    
                        SLROCKApsim = new double[toCopy.SLROCKApsim.Length];
            for (int i = 0; i < toCopy.SLROCKApsim.Length; i++)
                { SLROCKApsim[i] = toCopy.SLROCKApsim[i]; }
    
                        SLSILTApsim = new double[toCopy.SLSILTApsim.Length];
            for (int i = 0; i < toCopy.SLSILTApsim.Length; i++)
                { SLSILTApsim[i] = toCopy.SLSILTApsim[i]; }
    
                        SLSANDApsim = new double[toCopy.SLSANDApsim.Length];
            for (int i = 0; i < toCopy.SLSANDApsim.Length; i++)
                { SLSANDApsim[i] = toCopy.SLSANDApsim[i]; }
    
                        _boundaryLayerConductance = toCopy._boundaryLayerConductance;
                    }
                }

                public double[] THICKApsim
    {
        get { return this._THICKApsim; }
        set { this._THICKApsim= value; } 
    }
                public double[] DEPTHApsim
    {
        get { return this._DEPTHApsim; }
        set { this._DEPTHApsim= value; } 
    }
                public double[] BDApsim
    {
        get { return this._BDApsim; }
        set { this._BDApsim= value; } 
    }
                public double[] CLAYApsim
    {
        get { return this._CLAYApsim; }
        set { this._CLAYApsim= value; } 
    }
                public double[] SWApsim
    {
        get { return this._SWApsim; }
        set { this._SWApsim= value; } 
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
                public double[] SLCARBApsim
    {
        get { return this._SLCARBApsim; }
        set { this._SLCARBApsim= value; } 
    }
                public double[] SLROCKApsim
    {
        get { return this._SLROCKApsim; }
        set { this._SLROCKApsim= value; } 
    }
                public double[] SLSILTApsim
    {
        get { return this._SLSILTApsim; }
        set { this._SLSILTApsim= value; } 
    }
                public double[] SLSANDApsim
    {
        get { return this._SLSANDApsim; }
        set { this._SLSANDApsim= value; } 
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
                     _THICKApsim = new double[NLAYR];
                     _DEPTHApsim = new double[NLAYR];
                     _BDApsim = new double[NLAYR];
                     _CLAYApsim = new double[NLAYR];
                     _SWApsim = new double[NLAYR];
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
                     _SLCARBApsim = new double[NLAYR];
                     _SLROCKApsim = new double[NLAYR];
                     _SLSILTApsim = new double[NLAYR];
                     _SLSANDApsim = new double[NLAYR];
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