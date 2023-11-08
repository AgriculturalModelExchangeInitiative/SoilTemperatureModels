using System;
using System.Collections.Generic;
using System.Linq;
public class SoilTemperature
{
    public void Init(SoilTemperatureCompState s, SoilTemperatureCompState s1, SoilTemperatureCompRate r, SoilTemperatureCompAuxiliary a, SoilTemperatureCompExogenous ex)
    {
        double soilSurfaceTemperature = 0.0;
        double[] soilTemperature =  new double [22];
        double[] V =  new double [22];
        double[] B =  new double [22];
        double[] volumeMatrix =  new double [22];
        double[] volumeMatrixOld =  new double [22];
        double[] matrixPrimaryDiagonal =  new double [22];
        double[] matrixSecondaryDiagonal =  new double [23];
        double[] heatConductivity =  new double [22];
        double[] heatConductivityMean =  new double [22];
        double[] heatCapacity =  new double [22];
        double[] solution =  new double [22];
        double[] matrixDiagonal =  new double [22];
        double[] matrixLowerTriangle =  new double [22];
        double[] heatFlow =  new double [22];
        soilTemperature = new double[22];
        V = new double[22];
        B = new double[22];
        volumeMatrix = new double[22];
        volumeMatrixOld = new double[22];
        matrixPrimaryDiagonal = new double[22];
        matrixSecondaryDiagonal = new double[23];
        heatConductivity = new double[22];
        heatConductivityMean = new double[22];
        heatCapacity = new double[22];
        solution = new double[22];
        matrixDiagonal = new double[22];
        matrixLowerTriangle = new double[22];
        heatFlow = new double[22];
        soilTemperature = new double[ noOfTempLayers];
        V = new double[ noOfTempLayers];
        volumeMatrix = new double[ noOfTempLayers];
        volumeMatrixOld = new double[ noOfTempLayers];
        B = new double[ noOfTempLayers];
        matrixPrimaryDiagonal = new double[ noOfTempLayers];
        matrixSecondaryDiagonal = new double[ noOfTempLayers + 1];
        heatConductivity = new double[ noOfTempLayers];
        heatConductivityMean = new double[ noOfTempLayers];
        heatCapacity = new double[ noOfTempLayers];
        solution = new double[ noOfTempLayers];
        matrixDiagonal = new double[ noOfTempLayers];
        matrixLowerTriangle = new double[ noOfTempLayers];
        heatFlow = new double[ noOfTempLayers];
        int i;
        for (i=0 ; i!=noOfSoilLayers ; i+=1)
        {
            soilTemperature[i] = (1.00d - ((double)(i) / noOfSoilLayers)) * initialSurfaceTemp + ((double)(i) / noOfSoilLayers * baseTemp);
        }
        int groundLayer;
        groundLayer = noOfTempLayers - 2;
        int bottomLayer;
        bottomLayer = noOfTempLayers - 1;
        layerThickness[groundLayer] = 2.00d * layerThickness[(groundLayer - 1)];
        layerThickness[bottomLayer] = 1.00d;
        soilTemperature[groundLayer] = (soilTemperature[groundLayer - 1] + baseTemp) * 0.50d;
        soilTemperature[bottomLayer] = baseTemp;
        V[0] = layerThickness[0];
        B[0] = 2.00d / layerThickness[0];
        double lti_1;
        double lti;
        for (i=1 ; i!=noOfTempLayers ; i+=1)
        {
            lti_1 = layerThickness[i - 1];
            lti = layerThickness[i];
            B[i] = 2.00d / (lti + lti_1);
            V[i] = lti * nTau;
        }
        double ts;
        ts = timeStep;
        double dw;
        dw = densityWater;
        double cw;
        cw = specificHeatCapacityWater;
        double dq;
        dq = quartzRawDensity;
        double cq;
        cq = specificHeatCapacityQuartz;
        double da;
        da = densityAir;
        double ca;
        ca = specificHeatCapacityAir;
        double dh;
        dh = densityHumus;
        double ch;
        ch = specificHeatCapacityHumus;
        double sbdi;
        double smi;
        double sati;
        double somi;
        for (i=0 ; i!=noOfSoilLayers ; i+=1)
        {
            sbdi = soilBulkDensity[i];
            smi = soilMoistureConst;
            heatConductivity[i] = (3.00d * (sbdi / 1000.00d) - 1.70d) * 0.0010d / (1.00d + ((11.50d - (5.00d * (sbdi / 1000.00d))) * Math.Exp(-50.00d * Math.Pow(smi / (sbdi / 1000.00d), 1.50d)))) * 86400.00d * ts * 100.00d * 4.1840d;
            sati = saturation[i];
            somi = soilOrganicMatter[i] / da * sbdi;
            heatCapacity[i] = smi * dw * cw + ((sati - smi) * da * ca) + (somi * dh * ch) + ((1.00d - sati - somi) * dq * cq);
        }
        heatCapacity[groundLayer] = heatCapacity[groundLayer - 1];
        heatCapacity[bottomLayer] = heatCapacity[groundLayer];
        heatConductivity[groundLayer] = heatConductivity[groundLayer - 1];
        heatConductivity[bottomLayer] = heatConductivity[groundLayer];
        soilSurfaceTemperature = initialSurfaceTemp;
        heatConductivityMean[0] = heatConductivity[0];
        double hci_1;
        double hci;
        for (i=1 ; i!=noOfTempLayers ; i+=1)
        {
            lti_1 = layerThickness[i - 1];
            lti = layerThickness[i];
            hci_1 = heatConductivity[i - 1];
            hci = heatConductivity[i];
            heatConductivityMean[i] = (lti_1 * hci_1 + (lti * hci)) / (lti + lti_1);
        }
        for (i=0 ; i!=noOfTempLayers ; i+=1)
        {
            volumeMatrix[i] = V[i] * heatCapacity[i];
            volumeMatrixOld[i] = volumeMatrix[i];
            matrixSecondaryDiagonal[i] = -B[i] * heatConductivityMean[i];
        }
        matrixSecondaryDiagonal[bottomLayer + 1] = 0.00d;
        for (i=0 ; i!=noOfTempLayers ; i+=1)
        {
            matrixPrimaryDiagonal[i] = volumeMatrix[i] - matrixSecondaryDiagonal[i] - matrixSecondaryDiagonal[i + 1];
        }
        s.soilSurfaceTemperature= soilSurfaceTemperature;
        s.soilTemperature= soilTemperature;
        s.V= V;
        s.B= B;
        s.volumeMatrix= volumeMatrix;
        s.volumeMatrixOld= volumeMatrixOld;
        s.matrixPrimaryDiagonal= matrixPrimaryDiagonal;
        s.matrixSecondaryDiagonal= matrixSecondaryDiagonal;
        s.heatConductivity= heatConductivity;
        s.heatConductivityMean= heatConductivityMean;
        s.heatCapacity= heatCapacity;
        s.solution= solution;
        s.matrixDiagonal= matrixDiagonal;
        s.matrixLowerTriangle= matrixLowerTriangle;
        s.heatFlow= heatFlow;
    }
    private double _timeStep;
    public double timeStep
        {
            get { return this._timeStep; }
            set { this._timeStep= value; } 
        }
    private double _soilMoistureConst;
    public double soilMoistureConst
        {
            get { return this._soilMoistureConst; }
            set { this._soilMoistureConst= value; } 
        }
    private double _baseTemp;
    public double baseTemp
        {
            get { return this._baseTemp; }
            set { this._baseTemp= value; } 
        }
    private double _initialSurfaceTemp;
    public double initialSurfaceTemp
        {
            get { return this._initialSurfaceTemp; }
            set { this._initialSurfaceTemp= value; } 
        }
    private double _densityAir;
    public double densityAir
        {
            get { return this._densityAir; }
            set { this._densityAir= value; } 
        }
    private double _specificHeatCapacityAir;
    public double specificHeatCapacityAir
        {
            get { return this._specificHeatCapacityAir; }
            set { this._specificHeatCapacityAir= value; } 
        }
    private double _densityHumus;
    public double densityHumus
        {
            get { return this._densityHumus; }
            set { this._densityHumus= value; } 
        }
    private double _specificHeatCapacityHumus;
    public double specificHeatCapacityHumus
        {
            get { return this._specificHeatCapacityHumus; }
            set { this._specificHeatCapacityHumus= value; } 
        }
    private double _densityWater;
    public double densityWater
        {
            get { return this._densityWater; }
            set { this._densityWater= value; } 
        }
    private double _specificHeatCapacityWater;
    public double specificHeatCapacityWater
        {
            get { return this._specificHeatCapacityWater; }
            set { this._specificHeatCapacityWater= value; } 
        }
    private double _quartzRawDensity;
    public double quartzRawDensity
        {
            get { return this._quartzRawDensity; }
            set { this._quartzRawDensity= value; } 
        }
    private double _specificHeatCapacityQuartz;
    public double specificHeatCapacityQuartz
        {
            get { return this._specificHeatCapacityQuartz; }
            set { this._specificHeatCapacityQuartz= value; } 
        }
    private double _nTau;
    public double nTau
        {
            get { return this._nTau; }
            set { this._nTau= value; } 
        }
    private int _noOfTempLayers;
    public int noOfTempLayers
        {
            get { return this._noOfTempLayers; }
            set { this._noOfTempLayers= value; } 
        }
    private int _noOfSoilLayers;
    public int noOfSoilLayers
        {
            get { return this._noOfSoilLayers; }
            set { this._noOfSoilLayers= value; } 
        }
    private double[] _layerThickness;
    public double[] layerThickness
        {
            get { return this._layerThickness; }
            set { this._layerThickness= value; } 
        }
    private double[] _soilBulkDensity;
    public double[] soilBulkDensity
        {
            get { return this._soilBulkDensity; }
            set { this._soilBulkDensity= value; } 
        }
    private double[] _saturation;
    public double[] saturation
        {
            get { return this._saturation; }
            set { this._saturation= value; } 
        }
    private double[] _soilOrganicMatter;
    public double[] soilOrganicMatter
        {
            get { return this._soilOrganicMatter; }
            set { this._soilOrganicMatter= value; } 
        }
        public SoilTemperature() { }
    
    public void  CalculateModel(SoilTemperatureCompState s, SoilTemperatureCompState s1, SoilTemperatureCompRate r, SoilTemperatureCompAuxiliary a, SoilTemperatureCompExogenous ex)
    {
        //- Name: SoilTemperature -Version: 1, -Time step: 1
        //- Description:
    //            * Title: Model of soil temperature
    //            * Authors: Michael Berg-Mohnicke
    //            * Reference: None
    //            * Institution: ZALF e.V.
    //            * ExtendedDescription: None
    //            * ShortDescription: Calculates the soil temperature at all soil layers
        //- inputs:
    //            * name: soilSurfaceTemperature
    //                          ** description : current soilSurfaceTemperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -50
    //                          ** default : 0.0
    //                          ** unit : °C
    //            * name: timeStep
    //                          ** description : timeStep
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 1.0
    //                          ** unit : dimensionless
    //            * name: soilMoistureConst
    //                          ** description : initial soilmoisture
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.25
    //                          ** unit : m**3/m**3
    //            * name: baseTemp
    //                          ** description : baseTemperature
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 9.5
    //                          ** unit : °C
    //            * name: initialSurfaceTemp
    //                          ** description : initialSurfaceTemperature
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 10.0
    //                          ** unit : °C
    //            * name: densityAir
    //                          ** description : DensityAir
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 1.25
    //                          ** unit : kg/m**3
    //            * name: specificHeatCapacityAir
    //                          ** description : SpecificHeatCapacityAir
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 1005
    //                          ** unit : J/kg/K
    //            * name: densityHumus
    //                          ** description : DensityHumus
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 1300
    //                          ** unit : kg/m**3
    //            * name: specificHeatCapacityHumus
    //                          ** description : SpecificHeatCapacityHumus
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 1920
    //                          ** unit : J/kg/K
    //            * name: densityWater
    //                          ** description : DensityWater
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 1000
    //                          ** unit : kg/m**3
    //            * name: specificHeatCapacityWater
    //                          ** description : SpecificHeatCapacityWater
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 4192
    //                          ** unit : J/kg/K
    //            * name: quartzRawDensity
    //                          ** description : QuartzRawDensity
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 2650
    //                          ** unit : kg/m**3
    //            * name: specificHeatCapacityQuartz
    //                          ** description : SpecificHeatCapacityQuartz
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 750
    //                          ** unit : J/kg/K
    //            * name: nTau
    //                          ** description : NTau
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.65
    //                          ** unit : ?
    //            * name: noOfTempLayers
    //                          ** description : noOfTempLayers=noOfSoilLayers+2
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 22
    //                          ** unit : dimensionless
    //            * name: noOfSoilLayers
    //                          ** description : noOfSoilLayers
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 20
    //                          ** unit : dimensionless
    //            * name: layerThickness
    //                          ** description : layerThickness
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 22
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : m
    //            * name: soilBulkDensity
    //                          ** description : bulkDensity
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 20
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : kg/m**3
    //            * name: saturation
    //                          ** description : saturation
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 20
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : m**3/m**3
    //            * name: soilOrganicMatter
    //                          ** description : soilOrganicMatter
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 20
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : m**3/m**3
    //            * name: soilTemperature
    //                          ** description : soilTemperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 22
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : °C
    //            * name: V
    //                          ** description : V
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 22
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : °C
    //            * name: B
    //                          ** description : B
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 22
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : °C
    //            * name: volumeMatrix
    //                          ** description : volumeMatrix
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 22
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : °C
    //            * name: volumeMatrixOld
    //                          ** description : volumeMatrixOld
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 22
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : °C
    //            * name: matrixPrimaryDiagonal
    //                          ** description : matrixPrimaryDiagonal
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 22
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : °C
    //            * name: matrixSecondaryDiagonal
    //                          ** description : matrixSecondaryDiagonal
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 23
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : °C
    //            * name: heatConductivity
    //                          ** description : heatConductivity
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 22
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : °C
    //            * name: heatConductivityMean
    //                          ** description : heatConductivityMean
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 22
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : °C
    //            * name: heatCapacity
    //                          ** description : heatCapacity
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 22
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : °C
    //            * name: solution
    //                          ** description : solution
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 22
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : °C
    //            * name: matrixDiagonal
    //                          ** description : matrixDiagonal
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 22
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : °C
    //            * name: matrixLowerTriangle
    //                          ** description : matrixLowerTriangle
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 22
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : °C
    //            * name: heatFlow
    //                          ** description : heatFlow
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 22
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : °C
        //- outputs:
    //            * name: soilTemperature
    //                          ** description : soilTemperature next day
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 22
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : °C
        double soilSurfaceTemperature = s.soilSurfaceTemperature;
        double[] soilTemperature = s.soilTemperature;
        double[] V = s.V;
        double[] B = s.B;
        double[] volumeMatrix = s.volumeMatrix;
        double[] volumeMatrixOld = s.volumeMatrixOld;
        double[] matrixPrimaryDiagonal = s.matrixPrimaryDiagonal;
        double[] matrixSecondaryDiagonal = s.matrixSecondaryDiagonal;
        double[] heatConductivity = s.heatConductivity;
        double[] heatConductivityMean = s.heatConductivityMean;
        double[] heatCapacity = s.heatCapacity;
        double[] solution = s.solution;
        double[] matrixDiagonal = s.matrixDiagonal;
        double[] matrixLowerTriangle = s.matrixLowerTriangle;
        double[] heatFlow = s.heatFlow;
        int groundLayer;
        int bottomLayer;
        groundLayer = noOfTempLayers - 2;
        bottomLayer = noOfTempLayers - 1;
        heatFlow[0] = soilSurfaceTemperature * B[0] * heatConductivityMean[0];
        int i;
        for (i=0 ; i!=noOfTempLayers ; i+=1)
        {
            solution[i] = (volumeMatrixOld[i] + ((volumeMatrix[i] - volumeMatrixOld[i]) / layerThickness[i])) * soilTemperature[i] + heatFlow[i];
        }
        matrixDiagonal[0] = matrixPrimaryDiagonal[0];
        for (i=1 ; i!=noOfTempLayers ; i+=1)
        {
            matrixLowerTriangle[i] = matrixSecondaryDiagonal[i] / matrixDiagonal[(i - 1)];
            matrixDiagonal[i] = matrixPrimaryDiagonal[i] - (matrixLowerTriangle[i] * matrixSecondaryDiagonal[i]);
        }
        for (i=1 ; i!=noOfTempLayers ; i+=1)
        {
            solution[i] = solution[i] - (matrixLowerTriangle[i] * solution[(i - 1)]);
        }
        solution[bottomLayer] = solution[bottomLayer] / matrixDiagonal[bottomLayer];
        int j;
        int j_1;
        for (i=0 ; i!=bottomLayer ; i+=1)
        {
            j = bottomLayer - 1 - i;
            j_1 = j + 1;
            solution[j] = solution[j] / matrixDiagonal[j] - (matrixLowerTriangle[j_1] * solution[j_1]);
        }
        for (i=0 ; i!=noOfTempLayers ; i+=1)
        {
            soilTemperature[i] = solution[i];
        }
        for (i=0 ; i!=noOfSoilLayers ; i+=1)
        {
            volumeMatrixOld[i] = volumeMatrix[i];
        }
        volumeMatrixOld[groundLayer] = volumeMatrix[groundLayer];
        volumeMatrixOld[bottomLayer] = volumeMatrix[bottomLayer];
        s.soilTemperature= soilTemperature;
    }
}