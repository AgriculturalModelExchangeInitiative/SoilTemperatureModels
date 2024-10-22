using System;
using System.Collections.Generic;
using System.Linq;
public class Campbell
{
    public void Init(model_SoilTempCampbellState s, model_SoilTempCampbellState s1, model_SoilTempCampbellRate r, model_SoilTempCampbellAuxiliary a, model_SoilTempCampbellExogenous ex)
    {
        double T2M = ex.T2M;
        double TMAX = ex.TMAX;
        double TMIN = ex.TMIN;
        double TAV = ex.TAV;
        double[] SW = ex.SW;
        int DOY = ex.DOY;
        double canopyHeight = ex.canopyHeight;
        double SRAD = ex.SRAD;
        double ESP = ex.ESP;
        double ES = ex.ES;
        double EOAD = ex.EOAD;
        double windSpeed = ex.windSpeed;
        double airPressure = 1010.0;
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
        double[] SLCARB =  new double [NLAYR];
        double[] SLROCK =  new double [NLAYR];
        double[] SLSILT =  new double [NLAYR];
        double[] SLSAND =  new double [NLAYR];
        double _boundaryLayerConductance;
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
        SLCARB = new double[NLAYR];
        SLROCK = new double[NLAYR];
        SLSILT = new double[NLAYR];
        SLSAND = new double[NLAYR];
        _boundaryLayerConductance = 0.0;
        double[] heatCapacity ;
        double[] thickness ;
        double[] depth ;
        double[] bulkDensity ;
        double[] soilWater ;
        double[] clay ;
        double[] carbon ;
        double[] rocks ;
        double[] sand ;
        double[] silt ;
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
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){thickness[i] = 0.0;}
        thickness.ToList().GetRange(1,THICK.Length - 1) = THICK;
        sumThickness = 0.0;
        for (i=1 ; i!=NLAYR + 1 ; i+=1)
        {
            sumThickness = sumThickness + thickness[i];
        }
        BelowProfileDepth = Math.Max(CONSTANT_TEMPdepth - sumThickness, 1000.0);
        thicknessForPhantomNodes = BelowProfileDepth * 2.0 / NUM_PHANTOM_NODES;
        firstPhantomNode = NLAYR;
        for (i=firstPhantomNode ; i!=firstPhantomNode + NUM_PHANTOM_NODES ; i+=1)
        {
            thickness[i] = thicknessForPhantomNodes;
        }
        for (var i = 0; i < numNodes + 1 + 1; i++){depth[i] = 0.0;}
        depth[AIRnode] = 0.0;
        depth[SURFACEnode] = 0.0;
        depth[TOPSOILnode] = 0.5 * thickness[1] / 1000.0;
        for (node=TOPSOILnode ; node!=numNodes + 1 ; node+=1)
        {
            sumThickness = 0.0;
            for (i=1 ; i!=node ; i+=1)
            {
                sumThickness = sumThickness + thickness[i];
            }
            depth[node + 1] = (sumThickness + (0.5 * thickness[node])) / 1000.0;
        }
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){bulkDensity[i] = 0.0;}
        bulkDensity = BD;
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            bulkDensity[layer] = BD[layer - 1];
        }
        bulkDensity[numNodes] = bulkDensity[NLAYR];
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            bulkDensity[layer] = bulkDensity[NLAYR];
        }
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){soilWater[i] = 0.0;}
        soilWater = SW;
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            soilWater[layer] = SW[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            soilWater[layer] = soilWater[NLAYR];
        }
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){carbon[i] = 0.0;}
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            carbon[layer] = SLCARB[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            carbon[layer] = carbon[NLAYR];
        }
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){rocks[i] = 0.0;}
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            rocks[layer] = SLROCK[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            rocks[layer] = rocks[NLAYR];
        }
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){sand[i] = 0.0;}
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            sand[layer] = SLSAND[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            sand[layer] = sand[NLAYR];
        }
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){silt[i] = 0.0;}
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            silt[layer] = SLSILT[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            silt[layer] = silt[NLAYR];
        }
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){clay[i] = 0.0;}
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            clay[layer] = CLAY[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            clay[layer] = clay[NLAYR];
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
        doThermalConductivityCoeffs(NLAYR, numNodes, bulkDensity, clay, out thermalCondPar1, out thermalCondPar2, out thermalCondPar3, out thermalCondPar4);
        newTemperature = CalcSoilTemp(soilTemp, thickness, TAV, TAMP, DOY, XLAT, numNodes);
        soilWater[numNodes] = soilWater[NLAYR];
        instrumentHeight = Math.Max(instrumentHeight, canopyHeight + 0.5);
        soilTemp = CalcSoilTemp(soilTemp, thickness, TAV, TAMP, DOY, XLAT, numNodes);
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
        s.airPressure= airPressure;
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
        s.SLCARB= SLCARB;
        s.SLROCK= SLROCK;
        s.SLSILT= SLSILT;
        s.SLSAND= SLSAND;
        s._boundaryLayerConductance= _boundaryLayerConductance;
    }
    private int _NLAYR;
    public int NLAYR
    {
        get { return this._NLAYR; }
        set { this._NLAYR= value; } 
    }
    private double[] _THICK;
    public double[] THICK
    {
        get { return this._THICK; }
        set { this._THICK= value; } 
    }
    private double[] _DEPTH;
    public double[] DEPTH
    {
        get { return this._DEPTH; }
        set { this._DEPTH= value; } 
    }
    private double _CONSTANT_TEMPdepth;
    public double CONSTANT_TEMPdepth
    {
        get { return this._CONSTANT_TEMPdepth; }
        set { this._CONSTANT_TEMPdepth= value; } 
    }
    private double[] _BD;
    public double[] BD
    {
        get { return this._BD; }
        set { this._BD= value; } 
    }
    private double _TAMP;
    public double TAMP
    {
        get { return this._TAMP; }
        set { this._TAMP= value; } 
    }
    private double _XLAT;
    public double XLAT
    {
        get { return this._XLAT; }
        set { this._XLAT= value; } 
    }
    private double[] _CLAY;
    public double[] CLAY
    {
        get { return this._CLAY; }
        set { this._CLAY= value; } 
    }
    private double _SALB;
    public double SALB
    {
        get { return this._SALB; }
        set { this._SALB= value; } 
    }
    private double _instrumentHeight;
    public double instrumentHeight
    {
        get { return this._instrumentHeight; }
        set { this._instrumentHeight= value; } 
    }
    private string _boundaryLayerConductanceSource;
    public string boundaryLayerConductanceSource
    {
        get { return this._boundaryLayerConductanceSource; }
        set { this._boundaryLayerConductanceSource= value; } 
    }
    private string _netRadiationSource;
    public string netRadiationSource
    {
        get { return this._netRadiationSource; }
        set { this._netRadiationSource= value; } 
    }
    /// <summary>
    /// Constructor of the campbell component")
    /// </summary>  
    public campbell() { }
    
    public void  CalculateModel(model_SoilTempCampbellState s, model_SoilTempCampbellState s1, model_SoilTempCampbellRate r, model_SoilTempCampbellAuxiliary a, model_SoilTempCampbellExogenous ex)
    {
        //- Name: campbell -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: SoilTemperature model from Campbell implemented in APSIM
    //            * Authors: None
    //            * Reference: Campbell model (TODO)
    //            * Institution: CIRAD and INRAE
    //            * ExtendedDescription: TODO
    //            * ShortDescription: TODO
        //- inputs:
    //            * name: NLAYR
    //                          ** description : number of soil layers in profile
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 1
    //                          ** default : 10
    //                          ** unit : dimensionless
    //            * name: THICK
    //                          ** description : APSIM soil layer depths as thickness of layers
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 1
    //                          ** default : 50
    //                          ** unit : mm
    //            * name: DEPTH
    //                          ** description : APSIM node depths
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : m
    //            * name: CONSTANT_TEMPdepth
    //                          ** description : Depth of constant temperature
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 1000.0
    //                          ** unit : mm
    //            * name: BD
    //                          ** description : bd (soil bulk density) is name of the APSIM var for bulk density so set bulkDensity
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 1.4
    //                          ** unit : g/cm3
    //            * name: T2M
    //                          ** description : Mean daily Air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 
    //                          ** unit : 
    //            * name: TMAX
    //                          ** description : Max daily Air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 
    //                          ** unit : 
    //            * name: TMIN
    //                          ** description : Min daily Air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 
    //                          ** unit : 
    //            * name: TAV
    //                          ** description : Average daily Air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 
    //                          ** unit : 
    //            * name: TAMP
    //                          ** description : Amplitude air temperature
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 100
    //                          ** min : -100
    //                          ** default : 
    //                          ** unit : 
    //            * name: XLAT
    //                          ** description : Latitude
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: CLAY
    //                          ** description : Proportion of clay in each layer of profile
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 100
    //                          ** min : 0
    //                          ** default : 50
    //                          ** unit : 
    //            * name: SW
    //                          ** description : volumetric water content
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0.5
    //                          ** unit : cc water / cc soil
    //            * name: DOY
    //                          ** description : Day of year
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : INT
    //                          ** max : 366
    //                          ** min : 1
    //                          ** default : 1
    //                          ** unit : dimensionless
    //            * name: airPressure
    //                          ** description : Air pressure
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 1010
    //                          ** unit : hPA
    //            * name: canopyHeight
    //                          ** description : height of canopy above ground
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 0.057
    //                          ** unit : m
    //            * name: SALB
    //                          ** description : Soil albedo
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 
    //                          ** unit : dimensionless
    //            * name: SRAD
    //                          ** description : Solar radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 
    //                          ** unit : MJ/m2
    //            * name: ESP
    //                          ** description : Potential evaporation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 
    //                          ** unit : mm
    //            * name: ES
    //                          ** description : Actual evaporation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 
    //                          ** unit : mm
    //            * name: EOAD
    //                          ** description : Potential evapotranspiration
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 
    //                          ** unit : mm
    //            * name: soilTemp
    //                          ** description : Temperature at end of last time-step within a day - midnight in layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** default : 
    //                          ** unit : degC
    //            * name: newTemperature
    //                          ** description : Soil temperature at the end of one iteration
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** default : 
    //                          ** unit : degC
    //            * name: minSoilTemp
    //                          ** description : Minimum soil temperature in layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** default : 
    //                          ** unit : degC
    //            * name: maxSoilTemp
    //                          ** description : Maximum soil temperature in layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** default : 
    //                          ** unit : degC
    //            * name: aveSoilTemp
    //                          ** description : Temperature averaged over all time-steps within a day in layers.
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** default : 
    //                          ** unit : degC
    //            * name: morningSoilTemp
    //                          ** description : Temperature  in the morning in layers.
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** default : 
    //                          ** unit : degC
    //            * name: thermalCondPar1
    //                          ** description : thermal conductivity coeff in layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalCondPar2
    //                          ** description : thermal conductivity coeff in layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalCondPar3
    //                          ** description : thermal conductivity coeff in layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalCondPar4
    //                          ** description : thermal conductivity coeff in layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalConductivity
    //                          ** description : thermal conductivity in layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalConductance
    //                          ** description : Thermal conductance between layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : (W/m2/K)
    //            * name: heatStorage
    //                          ** description : Heat storage between layers (internal)
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : J/s/K
    //            * name: volSpecHeatSoil
    //                          ** description : Volumetric specific heat over the soil profile
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : J/K/m3
    //            * name: maxTempYesterday
    //                          ** description : Air max temperature from previous day
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 
    //                          ** unit : 
    //            * name: minTempYesterday
    //                          ** description : Air min temperature from previous day
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 
    //                          ** unit : 
    //            * name: instrumentHeight
    //                          ** description : Default instrument height
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0
    //                          ** default : 1.2
    //                          ** unit : m
    //            * name: boundaryLayerConductanceSource
    //                          ** description : Flag whether boundary layer conductance is calculated or gotten from input
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : STRING
    //                          ** max : 
    //                          ** min : 
    //                          ** default : calc
    //                          ** unit : dimensionless
    //            * name: netRadiationSource
    //                          ** description : Flag whether net radiation is calculated or gotten from input
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : STRING
    //                          ** max : 
    //                          ** min : 
    //                          ** default : calc
    //                          ** unit : dimensionless
    //            * name: windSpeed
    //                          ** description : Speed of wind
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0.0
    //                          ** default : 3.0
    //                          ** unit : m/s
    //            * name: SLCARB
    //                          ** description : Volumetric fraction of organic matter in the soil
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: SLROCK
    //                          ** description : Volumetric fraction of rocks in the soil
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: SLSILT
    //                          ** description : Volumetric fraction of silt in the soil
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: SLSAND
    //                          ** description : Volumetric fraction of sand in the soil
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: _boundaryLayerConductance
    //                          ** description : Boundary layer conductance
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : K/W
        //- outputs:
    //            * name: soilTemp
    //                          ** description : Temperature at end of last time-step within a day - midnight in layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** unit : degC
    //            * name: minSoilTemp
    //                          ** description : Minimum soil temperature in layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** unit : degC
    //            * name: maxSoilTemp
    //                          ** description : Maximum soil temperature in layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** unit : degC
    //            * name: aveSoilTemp
    //                          ** description : Temperature averaged over all time-steps within a day in layers.
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** unit : degC
    //            * name: morningSoilTemp
    //                          ** description : Temperature  in the morning in layers.
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** unit : degC
    //            * name: newTemperature
    //                          ** description : Soil temperature at the end of one iteration
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** unit : degC
    //            * name: maxTempYesterday
    //                          ** description : Air max temperature from previous day
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 60
    //                          ** min : -60
    //                          ** unit : 
    //            * name: minTempYesterday
    //                          ** description : Air min temperature from previous day
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 60
    //                          ** min : -60
    //                          ** unit : 
    //            * name: thermalCondPar1
    //                          ** description : thermal conductivity coeff in layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalCondPar2
    //                          ** description : thermal conductivity coeff in layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalCondPar3
    //                          ** description : thermal conductivity coeff in layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalCondPar4
    //                          ** description : thermal conductivity coeff in layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalConductivity
    //                          ** description : thermal conductivity in layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalConductance
    //                          ** description : Thermal conductance between layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : (W/m2/K)
    //            * name: heatStorage
    //                          ** description : Heat storage between layers (internal)
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : J/s/K
    //            * name: volSpecHeatSoil
    //                          ** description : Volumetric specific heat over the soil profile
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : J/K/m3
    //            * name: _boundaryLayerConductance
    //                          ** description : Boundary layer conductance
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : K/W
    //            * name: SLROCK
    //                          ** description : Volumetric fraction of rocks in the soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : 
    //            * name: SLCARB
    //                          ** description : Volumetric fraction of organic matter in the soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : 
    //            * name: SLSAND
    //                          ** description : Volumetric fraction of sand in the soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : 
    //            * name: SLSILT
    //                          ** description : Volumetric fraction of silt in the soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : 
    //            * name: airPressure
    //                          ** description : Air pressure
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : hPA
        double T2M = ex.T2M;
        double TMAX = ex.TMAX;
        double TMIN = ex.TMIN;
        double TAV = ex.TAV;
        double[] SW = ex.SW;
        int DOY = ex.DOY;
        double airPressure = s.airPressure;
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
        double[] SLCARB = s.SLCARB;
        double[] SLROCK = s.SLROCK;
        double[] SLSILT = s.SLSILT;
        double[] SLSAND = s.SLSAND;
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
        double[] soilWater ;
        int copyLength;
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
        soilConstituentNames = new string[]{"'Rocks'", "'OrganicMatter'", "'Sand'", "'Silt'", "'Clay'", "'Water'", "'Ice'", "'Air'"};
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
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){soilWater[i] = 0.0;}
        copyLength = Math.Min(NLAYR + 1 + NUM_PHANTOM_NODES, SW.Length);
        soilWater = SW;
        volSpecHeatSoil = doVolumetricSpecificHeat(volSpecHeatSoil, soilWater, numNodes, soilConstituentNames, THICK, DEPTH);
        thermalConductivity = doThermConductivity(soilWater, SLCARB, SLROCK, SLSAND, SLSILT, CLAY, BD, thermalConductivity, THICK, DEPTH, numNodes, soilConstituentNames);
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
            netRadiation = RadnNetInterpolate(internalTimeStep, solarRadn[timeStepIteration], cloudFr, cva, ESP, ES, tMean, SALB, soilTemp);
            if (boundaryLayerConductanceSource == "'constant'")
            {
                thermalConductivity[AIRnode] = constantBoundaryLayerConductance;
            }
            else if ( boundaryLayerConductanceSource == "'calc'")
            {
                thermalConductivity[AIRnode] = boundaryLayerConductanceF(newTemperature, T2M, ESP, ES, airPressure, canopyHeight, windSpeed, instrumentHeight);
                for (iteration=1 ; iteration!=BoundaryLayerConductanceIterations + 1 ; iteration+=1)
                {
                    newTemperature = doThomas(newTemperature, soilTemp, thermalConductivity, thermalConductance, DEPTH, volSpecHeatSoil, internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource);
                }
            }
            newTemperature = doThomas(newTemperature, soilTemp, thermalConductivity, thermalConductance, DEPTH, volSpecHeatSoil, internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource);
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
        s.airPressure= airPressure;
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
        s.SLCARB= SLCARB;
        s.SLROCK= SLROCK;
        s.SLSILT= SLSILT;
        s.SLSAND= SLSAND;
        s._boundaryLayerConductance= _boundaryLayerConductance;
    }
    public static void  doNetRadiation(ref double[] solarRadn, ref double cloudFr, ref double cva, int ITERATIONSperDAY, int doy, double rad, double tmin, double latitude)
    {
        double piVal = 3.1415;
        double TSTEPS2RAD = 1.0;
        double SOLARconst = 1.0;
        double solarDeclination = 1.0;
        TSTEPS2RAD = Divide(2.0 * piVal, (double)(ITERATIONSperDAY), 0.0);
        SOLARconst = 1360.0;
        solarDeclination = 0.3985 * Math.Sin((4.869 + (doy * 2.0 * piVal / 365.25) + (0.03345 * Math.Sin((6.224 + (doy * 2.0 * piVal / 365.25))))));
        double cD = Math.Sqrt(1.0 - (solarDeclination * solarDeclination));
        double[] m1 ;
        double m1Tot = 0.0;
        double psr;
        int timestepNumber = 1;
        double fr;
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
        for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
        {
            solarRadn[timestepNumber] = Math.Max(rad, 0.1) * Divide(m1[timestepNumber], m1Tot, 0.0);
        }
        double kelvinTemp = kelvinT(tmin);
        cva = Math.Exp((31.3716 - (6014.79 / kelvinTemp) - (0.00792495 * kelvinTemp))) / kelvinTemp;
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
    public static double[] doVolumetricSpecificHeat(double[] volSpecLayer, double[] soilW, int numNodes, string[] constituents, double[] thickness, double[] depth)
    {
        double[] volSpecHeatSoil ;
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
        volSpecLayer = mapLayer2Node(volSpecHeatSoil, volSpecLayer, thickness, depth, numNodes);
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
        if (name == "'Rocks'")
        {
            res = specificHeatRocks;
        }
        else if ( name == "'OrganicMatter'")
        {
            res = specificHeatOM;
        }
        else if ( name == "'Sand'")
        {
            res = specificHeatSand;
        }
        else if ( name == "'Silt'")
        {
            res = specificHeatSilt;
        }
        else if ( name == "'Clay'")
        {
            res = specificHeatClay;
        }
        else if ( name == "'Water'")
        {
            res = specificHeatWater;
        }
        else if ( name == "'Ice'")
        {
            res = specificHeatIce;
        }
        else if ( name == "'Air'")
        {
            res = specificHeatAir;
        }
        return res;
    }
    public static double[] mapLayer2Node(double[] layerArray, double[] nodeArray, double[] thickness, double[] depth, int numNodes)
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
                    depthLayerAbove = depthLayerAbove + thickness[i];
                }
            }
            d1 = depthLayerAbove - (depth[node] * 1000.0);
            d2 = depth[(node + 1)] * 1000.0 - depthLayerAbove;
            dSum = d1 + d2;
            nodeArray[node] = Divide(layerArray[layer] * d1, dSum, 0.0) + Divide(layerArray[(layer + 1)] * d2, dSum, 0.0);
        }
        return nodeArray;
    }
    public static double[] doThermConductivity(double[] soilW, double[] carbon, double[] rocks, double[] sand, double[] silt, double[] clay, double[] bulkDensity, double[] thermalConductivity, double[] thickness, double[] depth, int numNodes, string[] constituents)
    {
        double[] thermCondLayers ;
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
                shapeFactorConstituent = shapeFactor(constituents[constituent], rocks, carbon, sand, silt, clay, soilW, bulkDensity, node);
                thermalConductanceConstituent = ThermalConductance(constituents[constituent]);
                thermalConductanceWater = ThermalConductance("'Water'");
                k = 2.0 / 3.0 * Math.Pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0))), -1) + (1.0 / 3.0 * Math.Pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0) * (1.0 - (2.0 * shapeFactorConstituent)))), -1));
                numerator = numerator + (thermalConductanceConstituent * soilW[node] * k);
                denominator = denominator + (soilW[node] * k);
            }
            thermCondLayers[node] = numerator / denominator;
        }
        thermalConductivity = mapLayer2Node(thermCondLayers, thermalConductivity, thickness, depth, numNodes);
        return thermalConductivity;
    }
    public static double shapeFactor(string name, double[] rocks, double[] carbon, double[] sand, double[] silt, double[] clay, double[] soilWater, double[] bulkDensity, int layer)
    {
        double shapeFactorRocks = 0.182;
        double shapeFactorOM = 0.5;
        double shapeFactorSand = 0.182;
        double shapeFactorSilt = 0.125;
        double shapeFactorClay = 0.007755;
        double shapeFactorWater = 1.0;
        double result = 0.0;
        if (name == "'Rocks'")
        {
            result = shapeFactorRocks;
        }
        else if ( name == "'OrganicMatter'")
        {
            result = shapeFactorOM;
        }
        else if ( name == "'Sand'")
        {
            result = shapeFactorSand;
        }
        else if ( name == "'Silt'")
        {
            result = shapeFactorSilt;
        }
        else if ( name == "'Clay'")
        {
            result = shapeFactorClay;
        }
        else if ( name == "'Water'")
        {
            result = shapeFactorWater;
        }
        else if ( name == "'Ice'")
        {
            result = 0.333 - (0.333 * 0.0 / (volumetricFractionWater(soilWater, carbon, bulkDensity, layer) + 0.0 + volumetricFractionAir(rocks, carbon, sand, silt, clay, soilWater, bulkDensity, layer)));
            return result;
        }
        else if ( name == "'Air'")
        {
            result = 0.333 - (0.333 * volumetricFractionAir(rocks, carbon, sand, silt, clay, soilWater, bulkDensity, layer) / (volumetricFractionWater(soilWater, carbon, bulkDensity, layer) + 0.0 + volumetricFractionAir(rocks, carbon, sand, silt, clay, soilWater, bulkDensity, layer)));
            return result;
        }
        else if ( name == "'Minerals'")
        {
            result = shapeFactorRocks * volumetricFractionRocks(rocks, layer) + (shapeFactorSand * volumetricFractionSand(sand, rocks, carbon, bulkDensity, layer)) + (shapeFactorSilt * volumetricFractionSilt(silt, rocks, carbon, bulkDensity, layer)) + (shapeFactorClay * volumetricFractionClay(clay, rocks, carbon, bulkDensity, layer));
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
    public static double[] mapLayer2Node(double[] layerArray, double[] nodeArray, double[] thickness, double[] depth, int numNodes)
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
                    depthLayerAbove = depthLayerAbove + thickness[i];
                }
            }
            d1 = depthLayerAbove - (depth[node] * 1000.0);
            d2 = depth[(node + 1)] * 1000.0 - depthLayerAbove;
            dSum = d1 + d2;
            nodeArray[node] = Divide(layerArray[layer] * d1, dSum, 0.0) + Divide(layerArray[(layer + 1)] * d2, dSum, 0.0);
        }
        return nodeArray;
    }
    public static double volumetricFractionWater(double[] soilWater, double[] carbon, double[] bulkDensity, int layer)
    {
        double res = (1.0 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer)) * soilWater[layer];
        return res;
    }
    public static double volumetricFractionAir(double[] rocks, double[] carbon, double[] sand, double[] silt, double[] clay, double[] soilWater, double[] bulkDensity, int layer)
    {
        double res = 1.0 - volumetricFractionRocks(rocks, layer) - volumetricFractionOrganicMatter(carbon, bulkDensity, layer) - volumetricFractionSand(sand, rocks, carbon, bulkDensity, layer) - volumetricFractionSilt(silt, rocks, carbon, bulkDensity, layer) - volumetricFractionClay(clay, rocks, carbon, bulkDensity, layer) - volumetricFractionWater(soilWater, carbon, bulkDensity, layer) - 0.0;
        return res;
    }
    public static double volumetricFractionRocks(double[] rocks, int layer)
    {
        double res = rocks[layer] / 100.0;
        return res;
    }
    public static double volumetricFractionSand(double[] sand, double[] rocks, double[] carbon, double[] bulkDensity, int layer)
    {
        double ps = 2.63;
        double res = (1.0 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer) - volumetricFractionRocks(rocks, layer)) * sand[layer] / 100.0 * bulkDensity[layer] / ps;
        return res;
    }
    public static double volumetricFractionSilt(double[] silt, double[] rocks, double[] carbon, double[] bulkDensity, int layer)
    {
        double ps = 2.63;
        double res = (1.0 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer) - volumetricFractionRocks(rocks, layer)) * silt[layer] / 100.0 * bulkDensity[layer] / ps;
        return res;
    }
    public static double volumetricFractionClay(double[] clay, double[] rocks, double[] carbon, double[] bulkDensity, int layer)
    {
        double ps = 2.63;
        double res = (1.0 - volumetricFractionOrganicMatter(carbon, bulkDensity, layer) - volumetricFractionRocks(rocks, layer)) * clay[layer] / 100.0 * bulkDensity[layer] / ps;
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
        if (name == "'Rocks'")
        {
            res = specificHeatRocks;
        }
        else if ( name == "'OrganicMatter'")
        {
            res = specificHeatOM;
        }
        else if ( name == "'Sand'")
        {
            res = specificHeatSand;
        }
        else if ( name == "'Silt'")
        {
            res = specificHeatSilt;
        }
        else if ( name == "'Clay'")
        {
            res = specificHeatClay;
        }
        else if ( name == "'Water'")
        {
            res = specificHeatWater;
        }
        else if ( name == "'Ice'")
        {
            res = specificHeatIce;
        }
        else if ( name == "'Air'")
        {
            res = specificHeatAir;
        }
        return res;
    }
    public static double volumetricFractionOrganicMatter(double[] carbon, double[] bulkDensity, int layer)
    {
        double pom = 1.3;
        double res = carbon[layer] / 100.0 * 2.5 * bulkDensity[layer] / pom;
        return res;
    }
    public static double InterpTemp(double time_hours, double tmax, double tmin, double t2m, double max_temp_yesterday, double min_temp_yesterday)
    {
        double defaultTimeOfMaximumTemperature = 14.0;
        double midnight_temp;
        double t_scale;
        double piVal = 3.14;
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
    public static double RadnNetInterpolate(double internalTimeStep, double solarRadn, double cloudFr, double cva, double potE, double actE, double t2m, double albedo, double[] soilTemp)
    {
        double EMISSIVITYsurface = 0.96;
        double w2MJ = internalTimeStep / 1000000.0;
        int SURFACEnode = 1;
        double emissivityAtmos = (1 - (0.84 * cloudFr)) * 0.58 * Math.Pow(cva, 1.0 / 7.0) + (0.84 * cloudFr);
        double PenetrationConstant = Divide(Math.Max(0.1, potE), Math.Max(0.1, actE), 0.0);
        double lwRinSoil = longWaveRadn(emissivityAtmos, t2m) * PenetrationConstant * w2MJ;
        double lwRoutSoil = longWaveRadn(EMISSIVITYsurface, soilTemp[SURFACEnode]) * PenetrationConstant * w2MJ;
        double lwRnetSoil = lwRinSoil - lwRoutSoil;
        double swRin = solarRadn;
        double swRout = albedo * solarRadn;
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
    public static double boundaryLayerConductanceF(double[] TNew_zb, double t2M, double potE, double actE, double airPressure, double canopyHeight, double windSpeed, double instrumentHeight)
    {
        double VONK = 0.41;
        double GRAVITATIONALconst = 9.8;
        double specificHeatOfAir = 1010.0;
        double EMISSIVITYsurface = 0.98;
        int SURFACEnode = 1;
        double STEFAN_BOLTZMANNconst = 0.0000000567;
        double SpecificHeatAir = specificHeatOfAir * airDensity(t2M, airPressure);
        double RoughnessFacMomentum = 0.13 * canopyHeight;
        double RoughnessFacHeat = 0.2 * RoughnessFacMomentum;
        double d = 0.77 * canopyHeight;
        double SurfaceTemperature = TNew_zb[SURFACEnode];
        double PenetrationConstant = Math.Max(0.1, potE) / Math.Max(0.1, actE);
        double kelvinTemp = kelvinT(t2M);
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
            HeatFluxDensity = BoundaryLayerCond * (SurfaceTemperature - t2M);
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
    public static double[] doThomas(double[] newTemps, double[] soilTemp, double[] thermalConductivity, double[] thermalConductance, double[] depth, double[] volSpecHeatSoil, double gDt, double netRadiation, double potE, double actE, int numNodes, string netRadiationSource)
    {
        double nu = 0.6;
        int AIRnode = 0;
        int SURFACEnode = 1;
        double MJ2J = 1000000.0;
        double latentHeatOfVapourisation = 2465000.0;
        double tempStepSec = 24.0 * 60.0 * 60.0;
        double[] heatStorage ;
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
        for (var i = 0; i < numNodes + 1; i++){thermalConductance[i] = 0.0d;}
        thermalConductance[AIRnode] = thermalConductivity[AIRnode];
        int node = SURFACEnode;
        for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
        {
            VolSoilAtNode = 0.5 * (depth[node + 1] - depth[node - 1]);
            heatStorage[node] = Divide(volSpecHeatSoil[node] * VolSoilAtNode, gDt, 0.0);
            elementLength = depth[node + 1] - depth[node];
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
        if (netRadiationSource == "'calc'")
        {
            RadnNet = Divide(netRadiation * 1000000.0, gDt, 0.0);
        }
        else if ( netRadiationSource == "'eos'")
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
    public static void  doUpdate(double[] tempNew, ref double[] soilTemp, double[] minSoilTemp, double[] maxSoilTemp, double[] aveSoilTemp, double[] thermalConductivity, ref double boundaryLayerConductance, int IterationsPerDay, double timeOfDaySecs, double gDt, int numNodes)
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
    public static void  doThermalConductivityCoeffs(int nbLayers, int numNodes, double[] bulkDensity, double[] clay, out double[] thermalCondPar1, out double[] thermalCondPar2, out double[] thermalCondPar3, out double[] thermalCondPar4)
    {
        int layer;
        int element;
        for (var i = 0; i < numNodes + 1; i++){thermalCondPar1[i] = 0.0;}
        for (var i = 0; i < numNodes + 1; i++){thermalCondPar2[i] = 0.0;}
        for (var i = 0; i < numNodes + 1; i++){thermalCondPar3[i] = 0.0;}
        for (var i = 0; i < numNodes + 1; i++){thermalCondPar4[i] = 0.0;}
        for (layer=1 ; layer!=nbLayers + 2 ; layer+=1)
        {
            element = layer;
            thermalCondPar1[element] = 0.65 - (0.78 * bulkDensity[layer]) + (0.6 * Math.Pow(bulkDensity[layer], 2));
            thermalCondPar2[element] = 1.06 * bulkDensity[layer];
            thermalCondPar3[element] = Divide(2.6, Math.Sqrt(clay[layer]), 0.0);
            thermalCondPar3[element] = 1.0 + thermalCondPar3[element];
            thermalCondPar4[element] = 0.03 + (0.1 * Math.Pow(bulkDensity[layer], 2));
        }
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
    public static double[] CalcSoilTemp(double[] soilTempIO, double[] thickness, double tav, double tamp, int doy, double latitude, int numNodes)
    {
        double[] cumulativeDepth ;
        double[] soilTemp ;
        int Layer;
        int nodes;
        double tempValue;
        double w;
        double dh;
        double zd;
        double offset;
        int SURFACEnode = 1;
        double piVal = 3.14;
        for (var i = 0; i < thickness.Length; i++){cumulativeDepth[i] = 0.0;}
        if (thickness.Length > 0)
        {
            cumulativeDepth[0] = thickness[0];
            for (Layer=1 ; Layer!=thickness.Length ; Layer+=1)
            {
                cumulativeDepth[Layer] = thickness[Layer] + cumulativeDepth[Layer - 1];
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
        for (var i = 0; i < numNodes + 2; i++){soilTemp[i] = 0.0;}
        for (nodes=1 ; nodes!=numNodes + 1 ; nodes+=1)
        {
            soilTemp[nodes] = tav + (tamp * Math.Exp(-1.0 * cumulativeDepth[nodes] / zd) * Math.Sin(((doy / 365.0 + offset) * 2.0 * piVal - (cumulativeDepth[nodes] / zd))));
        }
        soilTempIO.ToList().GetRange(SURFACEnode,SURFACEnode + numNodes - SURFACEnode) = soilTemp.ToList().GetRange(0,numNodes - 0);
        return soilTempIO;
    }
}