
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SoilTemperatureComp.DomainClass
{
    public class SoilTemperatureCompState : ICloneable, IDomainClass
    {
        private double[] _V = new double[22];
        private double[] _B = new double[22];
        private double[] _volumeMatrix = new double[22];
        private double[] _volumeMatrixOld = new double[22];
        private double[] _matrixPrimaryDiagonal = new double[22];
        private double[] _matrixSecondaryDiagonal = new double[23];
        private double[] _heatConductivity = new double[22];
        private double[] _heatConductivityMean = new double[22];
        private double[] _heatCapacity = new double[22];
        private double[] _solution = new double[22];
        private double[] _matrixDiagonal = new double[22];
        private double[] _matrixLowerTriangle = new double[22];
        private double[] _heatFlow = new double[22];
        private double _soilSurfaceTemperature;
        private double[] _soilTemperature = new double[22];
        private double _noSnowSoilSurfaceTemperature;
        private ParametersIO _parametersIO;

        public SoilTemperatureCompState()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SoilTemperatureCompState(SoilTemperatureCompState toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                V = new double[22];
            for (int i = 0; i < 22; i++)
            { V[i] = toCopy.V[i]; }
    
                B = new double[22];
            for (int i = 0; i < 22; i++)
            { B[i] = toCopy.B[i]; }
    
                volumeMatrix = new double[22];
            for (int i = 0; i < 22; i++)
            { volumeMatrix[i] = toCopy.volumeMatrix[i]; }
    
                volumeMatrixOld = new double[22];
            for (int i = 0; i < 22; i++)
            { volumeMatrixOld[i] = toCopy.volumeMatrixOld[i]; }
    
                matrixPrimaryDiagonal = new double[22];
            for (int i = 0; i < 22; i++)
            { matrixPrimaryDiagonal[i] = toCopy.matrixPrimaryDiagonal[i]; }
    
                matrixSecondaryDiagonal = new double[23];
            for (int i = 0; i < 23; i++)
            { matrixSecondaryDiagonal[i] = toCopy.matrixSecondaryDiagonal[i]; }
    
                heatConductivity = new double[22];
            for (int i = 0; i < 22; i++)
            { heatConductivity[i] = toCopy.heatConductivity[i]; }
    
                heatConductivityMean = new double[22];
            for (int i = 0; i < 22; i++)
            { heatConductivityMean[i] = toCopy.heatConductivityMean[i]; }
    
                heatCapacity = new double[22];
            for (int i = 0; i < 22; i++)
            { heatCapacity[i] = toCopy.heatCapacity[i]; }
    
                solution = new double[22];
            for (int i = 0; i < 22; i++)
            { solution[i] = toCopy.solution[i]; }
    
                matrixDiagonal = new double[22];
            for (int i = 0; i < 22; i++)
            { matrixDiagonal[i] = toCopy.matrixDiagonal[i]; }
    
                matrixLowerTriangle = new double[22];
            for (int i = 0; i < 22; i++)
            { matrixLowerTriangle[i] = toCopy.matrixLowerTriangle[i]; }
    
                heatFlow = new double[22];
            for (int i = 0; i < 22; i++)
            { heatFlow[i] = toCopy.heatFlow[i]; }
    
                soilSurfaceTemperature = toCopy.soilSurfaceTemperature;
                soilTemperature = new double[22];
            for (int i = 0; i < 22; i++)
            { soilTemperature[i] = toCopy.soilTemperature[i]; }
    
                noSnowSoilSurfaceTemperature = toCopy.noSnowSoilSurfaceTemperature;
            }
        }

        public double[] V
        {
            get { return this._V; }
            set { this._V= value; } 
        }
        public double[] B
        {
            get { return this._B; }
            set { this._B= value; } 
        }
        public double[] volumeMatrix
        {
            get { return this._volumeMatrix; }
            set { this._volumeMatrix= value; } 
        }
        public double[] volumeMatrixOld
        {
            get { return this._volumeMatrixOld; }
            set { this._volumeMatrixOld= value; } 
        }
        public double[] matrixPrimaryDiagonal
        {
            get { return this._matrixPrimaryDiagonal; }
            set { this._matrixPrimaryDiagonal= value; } 
        }
        public double[] matrixSecondaryDiagonal
        {
            get { return this._matrixSecondaryDiagonal; }
            set { this._matrixSecondaryDiagonal= value; } 
        }
        public double[] heatConductivity
        {
            get { return this._heatConductivity; }
            set { this._heatConductivity= value; } 
        }
        public double[] heatConductivityMean
        {
            get { return this._heatConductivityMean; }
            set { this._heatConductivityMean= value; } 
        }
        public double[] heatCapacity
        {
            get { return this._heatCapacity; }
            set { this._heatCapacity= value; } 
        }
        public double[] solution
        {
            get { return this._solution; }
            set { this._solution= value; } 
        }
        public double[] matrixDiagonal
        {
            get { return this._matrixDiagonal; }
            set { this._matrixDiagonal= value; } 
        }
        public double[] matrixLowerTriangle
        {
            get { return this._matrixLowerTriangle; }
            set { this._matrixLowerTriangle= value; } 
        }
        public double[] heatFlow
        {
            get { return this._heatFlow; }
            set { this._heatFlow= value; } 
        }
        public double soilSurfaceTemperature
        {
            get { return this._soilSurfaceTemperature; }
            set { this._soilSurfaceTemperature= value; } 
        }
        public double[] soilTemperature
        {
            get { return this._soilTemperature; }
            set { this._soilTemperature= value; } 
        }
        public double noSnowSoilSurfaceTemperature
        {
            get { return this._noSnowSoilSurfaceTemperature; }
            set { this._noSnowSoilSurfaceTemperature= value; } 
        }

        public string Description
        {
            get { return "SoilTemperatureCompState of the component";}
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
             _V = new double[22];
             _B = new double[22];
             _volumeMatrix = new double[22];
             _volumeMatrixOld = new double[22];
             _matrixPrimaryDiagonal = new double[22];
             _matrixSecondaryDiagonal = new double[23];
             _heatConductivity = new double[22];
             _heatConductivityMean = new double[22];
             _heatCapacity = new double[22];
             _solution = new double[22];
             _matrixDiagonal = new double[22];
             _matrixLowerTriangle = new double[22];
             _heatFlow = new double[22];
             _soilSurfaceTemperature = default(double);
             _soilTemperature = new double[22];
             _noSnowSoilSurfaceTemperature = default(double);
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