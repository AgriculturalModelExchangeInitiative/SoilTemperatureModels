using System;
using System.Collections.Generic;
using System.Linq;
public class Campbell
{
    public void Init(Model_SoilTempCampbellState s, Model_SoilTempCampbellState s1, Model_SoilTempCampbellRate r, Model_SoilTempCampbellAuxiliary a, Model_SoilTempCampbellExogenous ex)
    {
        double T2M = ex.T2M;
        double TMAX = ex.TMAX;
        double TMIN = ex.TMIN;
        int DOY = ex.DOY;
        double airPressure = ex.airPressure;
        double canopyHeight = ex.canopyHeight;
        double SRAD = ex.SRAD;
        double ESP = ex.ESP;
        double ES = ex.ES;
        double EOAD = ex.EOAD;
        double windSpeed = ex.windSpeed;
        List<double> THICKApsim = new List<double>();
        List<double> DEPTHApsim = new List<double>();
        List<double> BDApsim = new List<double>();
        List<double> CLAYApsim = new List<double>();
        List<double> SWApsim = new List<double>();
        List<double> soilTemp = new List<double>();
        List<double> newTemperature = new List<double>();
        List<double> minSoilTemp = new List<double>();
        List<double> maxSoilTemp = new List<double>();
        List<double> aveSoilTemp = new List<double>();
        List<double> morningSoilTemp = new List<double>();
        List<double> thermalCondPar1 = new List<double>();
        List<double> thermalCondPar2 = new List<double>();
        List<double> thermalCondPar3 = new List<double>();
        List<double> thermalCondPar4 = new List<double>();
        List<double> thermalConductivity = new List<double>();
        List<double> thermalConductance = new List<double>();
        List<double> heatStorage = new List<double>();
        List<double> volSpecHeatSoil = new List<double>();
        double maxTempYesterday;
        double minTempYesterday;
        List<double> SLCARBApsim = new List<double>();
        List<double> SLROCKApsim = new List<double>();
        List<double> SLSILTApsim = new List<double>();
        List<double> SLSANDApsim = new List<double>();
        double _boundaryLayerConductance;
        THICKApsim = new List<double>{};
        DEPTHApsim = new List<double>{};
        BDApsim = new List<double>{};
        CLAYApsim = new List<double>{};
        SWApsim = new List<double>{};
        soilTemp = new List<double>{};
        newTemperature = new List<double>{};
        minSoilTemp = new List<double>{};
        maxSoilTemp = new List<double>{};
        aveSoilTemp = new List<double>{};
        morningSoilTemp = new List<double>{};
        thermalCondPar1 = new List<double>{};
        thermalCondPar2 = new List<double>{};
        thermalCondPar3 = new List<double>{};
        thermalCondPar4 = new List<double>{};
        thermalConductivity = new List<double>{};
        thermalConductance = new List<double>{};
        heatStorage = new List<double>{};
        volSpecHeatSoil = new List<double>{};
        maxTempYesterday = 0.0;
        minTempYesterday = 0.0;
        SLCARBApsim = new List<double>{};
        SLROCKApsim = new List<double>{};
        SLSILTApsim = new List<double>{};
        SLSANDApsim = new List<double>{};
        _boundaryLayerConductance = 0.0;
        List<double> heatCapacity = new List<double>();
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
        int I;
        int numNodes;
        int firstPhantomNode;
        int layer;
        int node;
        double surfaceT;
        soilRoughnessHeight = 0.057;
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
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){THICKApsim.Add(0.0);}
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            THICKApsim[layer]=THICK[layer - 1];
        }
        sumThickness = 0.0;
        for (I=1 ; I!=NLAYR + 1 ; I+=1)
        {
            sumThickness = sumThickness + THICKApsim[I];
        }
        BelowProfileDepth = Math.Max(CONSTANT_TEMPdepth - sumThickness, 1000.0);
        thicknessForPhantomNodes = BelowProfileDepth * 2.0 / NUM_PHANTOM_NODES;
        firstPhantomNode = NLAYR;
        for (I=firstPhantomNode ; I!=firstPhantomNode + NUM_PHANTOM_NODES ; I+=1)
        {
            THICKApsim[I]=thicknessForPhantomNodes;
        }
        for (var i = 0; i < numNodes + 1 + 1; i++){DEPTHApsim.Add(0.0);}
        DEPTHApsim[AIRnode]=0.0;
        DEPTHApsim[SURFACEnode]=0.0;
        DEPTHApsim[TOPSOILnode]=0.5 * THICKApsim[1] / 1000.0;
        for (node=TOPSOILnode ; node!=numNodes + 1 ; node+=1)
        {
            sumThickness = 0.0;
            for (I=1 ; I!=node ; I+=1)
            {
                sumThickness = sumThickness + THICKApsim[I];
            }
            DEPTHApsim[node + 1]=(sumThickness + (0.5 * THICKApsim[node])) / 1000.0;
        }
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){BDApsim.Add(0.0);}
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            BDApsim[layer]=BD[layer - 1];
        }
        BDApsim[numNodes]=BDApsim[NLAYR];
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            BDApsim[layer]=BDApsim[NLAYR];
        }
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){SWApsim.Add(0.0);}
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            SWApsim[layer]=SW[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SWApsim[layer]=SWApsim[(NLAYR - 1)] * THICKApsim[(NLAYR - 1)] / THICKApsim[NLAYR];
        }
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){SLCARBApsim.Add(0.0);}
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            SLCARBApsim[layer]=SLCARB[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SLCARBApsim[layer]=SLCARBApsim[NLAYR];
        }
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){SLROCKApsim.Add(0.0);}
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            SLROCKApsim[layer]=SLROCK[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SLROCKApsim[layer]=SLROCKApsim[NLAYR];
        }
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){SLSANDApsim.Add(0.0);}
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            SLSANDApsim[layer]=SLSAND[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SLSANDApsim[layer]=SLSANDApsim[NLAYR];
        }
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){SLSILTApsim.Add(0.0);}
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            SLSILTApsim[layer]=SLSILT[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SLSILTApsim[layer]=SLSILTApsim[NLAYR];
        }
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){CLAYApsim.Add(0.0);}
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            CLAYApsim[layer]=CLAY[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            CLAYApsim[layer]=CLAYApsim[NLAYR];
        }
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){maxSoilTemp.Add(0.0);}
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){minSoilTemp.Add(0.0);}
        for (var i = 0; i < NLAYR + 1 + NUM_PHANTOM_NODES; i++){aveSoilTemp.Add(0.0);}
        for (var i = 0; i < numNodes + 1; i++){volSpecHeatSoil.Add(0.0);}
        for (var i = 0; i < numNodes + 1 + 1; i++){soilTemp.Add(0.0);}
        for (var i = 0; i < numNodes + 1 + 1; i++){morningSoilTemp.Add(0.0);}
        for (var i = 0; i < numNodes + 1 + 1; i++){newTemperature.Add(0.0);}
        for (var i = 0; i < numNodes + 1; i++){thermalConductivity.Add(0.0);}
        for (var i = 0; i < numNodes + 1; i++){heatStorage.Add(0.0);}
        for (var i = 0; i < numNodes + 1 + 1; i++){thermalConductance.Add(0.0);}
        doThermalConductivityCoeffs(NLAYR, numNodes, BDApsim, CLAYApsim, out thermalCondPar1, out thermalCondPar2, out thermalCondPar3, out thermalCondPar4);
        newTemperature = CalcSoilTemp(THICKApsim, TAV, TAMP, DOY, XLAT, numNodes);
        canopyHeight = Math.Max(canopyHeight, soilRoughnessHeight);
        instrumentHeight = Math.Max(instrumentHeight, canopyHeight + 0.5);
        soilTemp = CalcSoilTemp(THICKApsim, TAV, TAMP, DOY, XLAT, numNodes);
        soilTemp[AIRnode]=T2M;
        surfaceT = (1.0 - SALB) * (T2M + ((TMAX - T2M) * Math.Sqrt(Math.Max(SRAD, 0.1) * 23.8846 / 800.0))) + (SALB * T2M);
        soilTemp[SURFACEnode]=surfaceT;
        for (I=numNodes + 1 ; I!=soilTemp.Count ; I+=1)
        {
            soilTemp[I]=TAV;
        }
        for (I=0 ; I!=soilTemp.Count ; I+=1)
        {
            newTemperature[I]=soilTemp[I];
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
    private double[] _BD;
    public double[] BD
    {
        get { return this._BD; }
        set { this._BD= value; } 
    }
    private double[] _SLCARB;
    public double[] SLCARB
    {
        get { return this._SLCARB; }
        set { this._SLCARB= value; } 
    }
    private double[] _CLAY;
    public double[] CLAY
    {
        get { return this._CLAY; }
        set { this._CLAY= value; } 
    }
    private double[] _SLROCK;
    public double[] SLROCK
    {
        get { return this._SLROCK; }
        set { this._SLROCK= value; } 
    }
    private double[] _SLSILT;
    public double[] SLSILT
    {
        get { return this._SLSILT; }
        set { this._SLSILT= value; } 
    }
    private double[] _SLSAND;
    public double[] SLSAND
    {
        get { return this._SLSAND; }
        set { this._SLSAND= value; } 
    }
    private double[] _SW;
    public double[] SW
    {
        get { return this._SW; }
        set { this._SW= value; } 
    }
    private double _CONSTANT_TEMPdepth;
    public double CONSTANT_TEMPdepth
    {
        get { return this._CONSTANT_TEMPdepth; }
        set { this._CONSTANT_TEMPdepth= value; } 
    }
    private double _TAV;
    public double TAV
    {
        get { return this._TAV; }
        set { this._TAV= value; } 
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
    /// Constructor of the Campbell component")
    /// </summary>  
    public Campbell() { }
    
    public void  CalculateModel(Model_SoilTempCampbellState s, Model_SoilTempCampbellState s1, Model_SoilTempCampbellRate r, Model_SoilTempCampbellAuxiliary a, Model_SoilTempCampbellExogenous ex)
    {
        //- Name: Campbell -Version: 1.0, -Time step: 1
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
    //                          ** description : Soil layer thickness of layers
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 1
    //                          ** default : 
    //                          ** unit : mm
    //            * name: BD
    //                          ** description : bd (soil bulk density)
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : g/cm3             uri :
    //            * name: SLCARB
    //                          ** description : Volumetric fraction of organic matter in the soil
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: CLAY
    //                          ** description : Proportion of CLAY in each layer of profile
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 100
    //                          ** min : 0
    //                          ** default : 50
    //                          ** unit : 
    //            * name: SLROCK
    //                          ** description : Volumetric fraction of rocks in the soil
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: SLSILT
    //                          ** description : Volumetric fraction of silt in the soil
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: SLSAND
    //                          ** description : Volumetric fraction of sand in the soil
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: SW
    //                          ** description : volumetric water content
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 0.5
    //                          ** unit : cc water / cc soil
    //            * name: THICKApsim
    //                          ** description : APSIM soil layer depths of layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 
    //                          ** min : 1
    //                          ** default : 
    //                          ** unit : mm
    //            * name: DEPTHApsim
    //                          ** description : Apsim node depths
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
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
    //            * name: BDApsim
    //                          ** description : Apsim bd (soil bulk density)
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : g/cm3             uri :
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
    //                          ** description : Average annual air temperature
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
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
    //            * name: CLAYApsim
    //                          ** description : Apsim proportion of CLAY in each layer of profile
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 100
    //                          ** min : 0
    //                          ** default : 
    //                          ** unit : 
    //            * name: SWApsim
    //                          ** description : Apsim volumetric water content
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 1
    //                          ** min : 0
    //                          ** default : 
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
    //                          ** variablecategory : exogenous
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
    //                          ** datatype : DOUBLELIST
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** default : 
    //                          ** unit : degC
    //            * name: newTemperature
    //                          ** description : Soil temperature at the end of one iteration
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** default : 
    //                          ** unit : degC
    //            * name: minSoilTemp
    //                          ** description : Minimum soil temperature in layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** default : 
    //                          ** unit : degC
    //            * name: maxSoilTemp
    //                          ** description : Maximum soil temperature in layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** default : 
    //                          ** unit : degC
    //            * name: aveSoilTemp
    //                          ** description : Temperature averaged over all time-steps within a day in layers.
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** default : 
    //                          ** unit : degC
    //            * name: morningSoilTemp
    //                          ** description : Temperature  in the morning in layers.
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** default : 
    //                          ** unit : degC
    //            * name: thermalCondPar1
    //                          ** description : thermal conductivity coeff in layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalCondPar2
    //                          ** description : thermal conductivity coeff in layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalCondPar3
    //                          ** description : thermal conductivity coeff in layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalCondPar4
    //                          ** description : thermal conductivity coeff in layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalConductivity
    //                          ** description : thermal conductivity in layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalConductance
    //                          ** description : Thermal conductance between layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : (W/m2/K)
    //            * name: heatStorage
    //                          ** description : Heat storage between layers (internal)
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : J/s/K
    //            * name: volSpecHeatSoil
    //                          ** description : Volumetric specific heat over the soil profile
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
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
    //            * name: SLCARBApsim
    //                          ** description : Apsim volumetric fraction of organic matter in the soil
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: SLROCKApsim
    //                          ** description : Apsim volumetric fraction of rocks in the soil
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: SLSILTApsim
    //                          ** description : Apsim volumetric fraction of silt in the soil
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: SLSANDApsim
    //                          ** description : Apsim volumetric fraction of sand in the soil
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
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
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** unit : degC
    //            * name: minSoilTemp
    //                          ** description : Minimum soil temperature in layers
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** unit : degC
    //            * name: maxSoilTemp
    //                          ** description : Maximum soil temperature in layers
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** unit : degC
    //            * name: aveSoilTemp
    //                          ** description : Temperature averaged over all time-steps within a day in layers.
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** unit : degC
    //            * name: morningSoilTemp
    //                          ** description : Temperature  in the morning in layers.
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 60.
    //                          ** min : -60.
    //                          ** unit : degC
    //            * name: newTemperature
    //                          ** description : Soil temperature at the end of one iteration
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
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
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalCondPar2
    //                          ** description : thermal conductivity coeff in layers
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalCondPar3
    //                          ** description : thermal conductivity coeff in layers
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalCondPar4
    //                          ** description : thermal conductivity coeff in layers
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalConductivity
    //                          ** description : thermal conductivity in layers
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : (W/m2/K)
    //            * name: thermalConductance
    //                          ** description : Thermal conductance between layers
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : (W/m2/K)
    //            * name: heatStorage
    //                          ** description : Heat storage between layers (internal)
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : J/s/K
    //            * name: volSpecHeatSoil
    //                          ** description : Volumetric specific heat over the soil profile
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
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
    //            * name: THICKApsim
    //                          ** description : APSIM soil layer thickness of layers
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 1
    //                          ** unit : mm
    //            * name: DEPTHApsim
    //                          ** description : APSIM node depths
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : m
    //            * name: BDApsim
    //                          ** description : soil bulk density of APSIM
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : g/cm3             uri :
    //            * name: SWApsim
    //                          ** description : Apsim volumetric water content
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 1
    //                          ** min : 0
    //                          ** unit : cc water / cc soil
    //            * name: CLAYApsim
    //                          ** description : Proportion of clay in each layer of profile
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 100
    //                          ** min : 0
    //                          ** unit : 
    //            * name: SLROCKApsim
    //                          ** description : Volumetric fraction of rocks in the soil
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : 
    //            * name: SLCARBApsim
    //                          ** description : Volumetric fraction of organic matter in the soil
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : 
    //            * name: SLSANDApsim
    //                          ** description : Volumetric fraction of sand in the soil
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : 
    //            * name: SLSILTApsim
    //                          ** description : Volumetric fraction of silt in the soil
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : 
        List<double> THICKApsim = s.THICKApsim;
        List<double> DEPTHApsim = s.DEPTHApsim;
        List<double> BDApsim = s.BDApsim;
        double T2M = ex.T2M;
        double TMAX = ex.TMAX;
        double TMIN = ex.TMIN;
        List<double> CLAYApsim = s.CLAYApsim;
        List<double> SWApsim = s.SWApsim;
        int DOY = ex.DOY;
        double airPressure = ex.airPressure;
        double canopyHeight = ex.canopyHeight;
        double SRAD = ex.SRAD;
        double ESP = ex.ESP;
        double ES = ex.ES;
        double EOAD = ex.EOAD;
        List<double> soilTemp = s.soilTemp;
        List<double> newTemperature = s.newTemperature;
        List<double> minSoilTemp = s.minSoilTemp;
        List<double> maxSoilTemp = s.maxSoilTemp;
        List<double> aveSoilTemp = s.aveSoilTemp;
        List<double> morningSoilTemp = s.morningSoilTemp;
        List<double> thermalCondPar1 = s.thermalCondPar1;
        List<double> thermalCondPar2 = s.thermalCondPar2;
        List<double> thermalCondPar3 = s.thermalCondPar3;
        List<double> thermalCondPar4 = s.thermalCondPar4;
        List<double> thermalConductivity = s.thermalConductivity;
        List<double> thermalConductance = s.thermalConductance;
        List<double> heatStorage = s.heatStorage;
        List<double> volSpecHeatSoil = s.volSpecHeatSoil;
        double maxTempYesterday = s.maxTempYesterday;
        double minTempYesterday = s.minTempYesterday;
        double windSpeed = ex.windSpeed;
        List<double> SLCARBApsim = s.SLCARBApsim;
        List<double> SLROCKApsim = s.SLROCKApsim;
        List<double> SLSILTApsim = s.SLSILTApsim;
        List<double> SLSANDApsim = s.SLSANDApsim;
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
        double soilRoughnessHeight;
        int BoundaryLayerConductanceIterations;
        int numNodes;
        string[] soilConstituentNames ;
        int timeStepIteration;
        double netRadiation;
        double constantBoundaryLayerConductance;
        double precision;
        double cva;
        double cloudFr;
        List<double> solarRadn = new List<double>();
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
        soilRoughnessHeight = 0.057;
        BoundaryLayerConductanceIterations = 1;
        numNodes = NLAYR + NUM_PHANTOM_NODES;
        soilConstituentNames = new string[]{"Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"};
        timeStepIteration = 1;
        constantBoundaryLayerConductance = 20.0;
        layer = 0;
        canopyHeight = Math.Max(canopyHeight, soilRoughnessHeight);
        cva = 0.0;
        cloudFr = 0.0;
        solarRadn = new List<double>{0.0};
        for (layer=0 ; layer!=50 ; layer+=1)
        {
            solarRadn.Add(0.0);
        }
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
            newTemperature[AIRnode]=tMean;
            netRadiation = RadnNetInterpolate(internalTimeStep, solarRadn[timeStepIteration], cloudFr, cva, ESP, EOAD, tMean, SALB, soilTemp);
            if (boundaryLayerConductanceSource == "constant")
            {
                thermalConductivity[AIRnode]=constantBoundaryLayerConductance;
            }
            else if ( boundaryLayerConductanceSource == "calc")
            {
                thermalConductivity[AIRnode]=boundaryLayerConductanceF(newTemperature, tMean, ESP, EOAD, airPressure, canopyHeight, windSpeed, instrumentHeight);
                for (iteration=1 ; iteration!=BoundaryLayerConductanceIterations + 1 ; iteration+=1)
                {
                    newTemperature = doThomas(newTemperature, soilTemp, thermalConductivity, thermalConductance, DEPTHApsim, volSpecHeatSoil, internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource);
                    thermalConductivity[AIRnode]=boundaryLayerConductanceF(newTemperature, tMean, ESP, EOAD, airPressure, canopyHeight, windSpeed, instrumentHeight);
                }
            }
            newTemperature = doThomas(newTemperature, soilTemp, thermalConductivity, thermalConductance, DEPTHApsim, volSpecHeatSoil, internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource);
            doUpdate(newTemperature, ref soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp, thermalConductivity, ref _boundaryLayerConductance, ITERATIONSperDAY, timeOfDaySecs, internalTimeStep, numNodes);
            precision = Math.Min(timeOfDaySecs, 5.0 * 3600.0) * 0.0001;
            if (Math.Abs(timeOfDaySecs - (5.0 * 3600.0)) <= precision)
            {
                for (layer=0 ; layer!=soilTemp.Count ; layer+=1)
                {
                    morningSoilTemp[layer]=soilTemp[layer];
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
    public static void  doNetRadiation(ref List<double> solarRadn, ref double cloudFr, ref double cva, int ITERATIONSperDAY, int doy, double rad, double tmin, double latitude)
    {
        List<double> m1 = new List<double>();
        int lay;
        for (var i = 0; i < ITERATIONSperDAY + 1; i++){solarRadn.Add(0.0);}
        double piVal = 3.141592653589793;
        double TSTEPS2RAD = 1.0;
        double SOLARconst = 1.0;
        double solarDeclination = 1.0;
        m1 = new List<double>{0.0};
        for (lay=0 ; lay!=ITERATIONSperDAY + 1 ; lay+=1)
        {
            m1.Add(0.0);
        }
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
            m1[timestepNumber]=(solarDeclination * Math.Sin(latitude * piVal / 180.0) + (cD * Math.Cos(latitude * piVal / 180.0) * Math.Cos(TSTEPS2RAD * ((double)(timestepNumber) - ((double)(ITERATIONSperDAY) / 2.0))))) * 24.0 / (double)(ITERATIONSperDAY);
            if (m1[timestepNumber] > 0.0)
            {
                m1Tot = m1Tot + m1[timestepNumber];
            }
            else
            {
                m1[timestepNumber]=0.0;
            }
        }
        psr = m1Tot * SOLARconst * 3600.0 / 1000000.0;
        fr = Divide(Math.Max(rad, 0.1), psr, 0.0);
        cloudFr = 2.33 - (3.33 * fr);
        cloudFr = Math.Min(Math.Max(cloudFr, 0.0), 1.0);
        scalar = Math.Max(rad, 0.1);
        for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
        {
            solarRadn[timestepNumber]=scalar * Divide(m1[timestepNumber], m1Tot, 0.0);
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
    public static List<double> Zero(List<double> arr)
    {
        int I = 0;
        for (I=0 ; I!=arr.Count ; I+=1)
        {
            arr[I]=0.0d;
        }
        return arr;
    }
    public static List<double> doVolumetricSpecificHeat(List<double> volSpecLayer, List<double> soilW, int numNodes, string[] constituents, List<double> THICKApsim, List<double> DEPTHApsim)
    {
        List<double> volSpecHeatSoil = new List<double>();
        volSpecHeatSoil = new List<double>{0.0};
        int node;
        for (node=0 ; node!=numNodes + 1 ; node+=1)
        {
            volSpecHeatSoil.Add(0.0);
        }
        int constituent;
        for (node=1 ; node!=numNodes + 1 ; node+=1)
        {
            volSpecHeatSoil[node]=0.0;
            for (constituent=0 ; constituent!=constituents.Length ; constituent+=1)
            {
                volSpecHeatSoil[node]=volSpecHeatSoil[node] + (volumetricSpecificHeat(constituents[constituent]) * 1000000.0 * soilW[node]);
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
    public static List<double> mapLayer2Node(List<double> layerArray, List<double> nodeArray, List<double> THICKApsim, List<double> DEPTHApsim, int numNodes)
    {
        int SURFACEnode = 1;
        double depthLayerAbove;
        int node = 0;
        int I = 0;
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
                for (I=1 ; I!=layer + 1 ; I+=1)
                {
                    depthLayerAbove = depthLayerAbove + THICKApsim[I];
                }
            }
            d1 = depthLayerAbove - (DEPTHApsim[node] * 1000.0);
            d2 = DEPTHApsim[(node + 1)] * 1000.0 - depthLayerAbove;
            dSum = d1 + d2;
            nodeArray[node]=Divide(layerArray[layer] * d1, dSum, 0.0) + Divide(layerArray[(layer + 1)] * d2, dSum, 0.0);
        }
        return nodeArray;
    }
    public static List<double> doThermConductivity(List<double> soilW, List<double> SLCARBApsim, List<double> SLROCKApsim, List<double> SLSANDApsim, List<double> SLSILTApsim, List<double> CLAYApsim, List<double> BDApsim, List<double> thermalConductivity, List<double> THICKApsim, List<double> DEPTHApsim, int numNodes, string[] constituents)
    {
        List<double> thermCondLayers = new List<double>();
        thermCondLayers = new List<double>{0.0};
        int I;
        for (I=0 ; I!=numNodes + 1 ; I+=1)
        {
            thermCondLayers.Add(0.0);
        }
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
            thermCondLayers[node]=numerator / denominator;
        }
        thermalConductivity = mapLayer2Node(thermCondLayers, thermalConductivity, THICKApsim, DEPTHApsim, numNodes);
        return thermalConductivity;
    }
    public static double shapeFactor(string name, List<double> SLROCKApsim, List<double> SLCARBApsim, List<double> SLSANDApsim, List<double> SLSILTApsim, List<double> CLAYApsim, List<double> SWApsim, List<double> BDApsim, int layer)
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
    public static double volumetricFractionWater(List<double> SWApsim, List<double> SLCARBApsim, List<double> BDApsim, int layer)
    {
        double res = (1.0 - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer)) * SWApsim[layer];
        return res;
    }
    public static double volumetricFractionAir(List<double> SLROCKApsim, List<double> SLCARBApsim, List<double> SLSANDApsim, List<double> SLSILTApsim, List<double> CLAYApsim, List<double> SWApsim, List<double> BDApsim, int layer)
    {
        double res = 1.0 - volumetricFractionRocks(SLROCKApsim, layer) - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionSand(SLSANDApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer) - volumetricFractionSilt(SLSILTApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer) - volumetricFractionClay(CLAYApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer) - volumetricFractionWater(SWApsim, SLCARBApsim, BDApsim, layer) - 0.0;
        return res;
    }
    public static double volumetricFractionRocks(List<double> SLROCKApsim, int layer)
    {
        double res = SLROCKApsim[layer] / 100.0;
        return res;
    }
    public static double volumetricFractionSand(List<double> SLSANDApsim, List<double> SLROCKApsim, List<double> SLCARBApsim, List<double> BDApsim, int layer)
    {
        double ps = 2.63;
        double res = (1.0 - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionRocks(SLROCKApsim, layer)) * SLSANDApsim[layer] / 100.0 * BDApsim[layer] / ps;
        return res;
    }
    public static double volumetricFractionSilt(List<double> SLSILTApsim, List<double> SLROCKApsim, List<double> SLCARBApsim, List<double> BDApsim, int layer)
    {
        double ps = 2.63;
        double res = (1.0 - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionRocks(SLROCKApsim, layer)) * SLSILTApsim[layer] / 100.0 * BDApsim[layer] / ps;
        return res;
    }
    public static double volumetricFractionClay(List<double> CLAYApsim, List<double> SLROCKApsim, List<double> SLCARBApsim, List<double> BDApsim, int layer)
    {
        double ps = 2.63;
        double res = (1.0 - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionRocks(SLROCKApsim, layer)) * CLAYApsim[layer] / 100.0 * BDApsim[layer] / ps;
        return res;
    }
    public static double volumetricFractionOrganicMatter(List<double> SLCARBApsim, List<double> BDApsim, int layer)
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
    public static double RadnNetInterpolate(double internalTimeStep, double solarRadiation, double cloudFr, double cva, double potE, double potET, double tMean, double albedo, List<double> soilTemp)
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
    public static double longWaveRadn(double emissivity, double tDegC)
    {
        double STEFAN_BOLTZMANNconst = 0.0000000567;
        double kelvinTemp = kelvinT(tDegC);
        double res = STEFAN_BOLTZMANNconst * emissivity * Math.Pow(kelvinTemp, 4);
        return res;
    }
    public static double boundaryLayerConductanceF(List<double> TNew_zb, double tMean, double potE, double potET, double airPressure, double canopyHeight, double windSpeed, double instrumentHeight)
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
    public static List<double> doThomas(List<double> newTemps, List<double> soilTemp, List<double> thermalConductivity, List<double> thermalConductance, List<double> DEPTHApsim, List<double> volSpecHeatSoil, double gDt, double netRadiation, double potE, double actE, int numNodes, string netRadiationSource)
    {
        double nu = 0.6;
        int AIRnode = 0;
        int SURFACEnode = 1;
        double MJ2J = 1000000.0;
        double latentHeatOfVapourisation = 2465000.0;
        double tempStepSec = 24.0 * 60.0 * 60.0;
        int I;
        List<double> heatStorage = new List<double>();
        heatStorage = new List<double>{0.0d};
        double VolSoilAtNode;
        double elementLength;
        double g = 1 - nu;
        double sensibleHeatFlux;
        double RadnNet;
        double LatentHeatFlux;
        double SoilSurfaceHeatFlux;
        List<double> a = new List<double>();
        List<double> b = new List<double>();
        List<double> c = new List<double>();
        List<double> d = new List<double>();
        a = new List<double>{0.0};
        b = new List<double>{0.0};
        c = new List<double>{0.0};
        d = new List<double>{0.0};
        for (I=0 ; I!=numNodes + 1 ; I+=1)
        {
            a.Add(0.0);
            b.Add(0.0);
            c.Add(0.0);
            d.Add(0.0);
            heatStorage.Add(0.0);
        }
        a.Add(0.0);
        for (var i = 0; i < numNodes + 1; i++){thermalConductance.Add(0.0d);}
        thermalConductance[AIRnode]=thermalConductivity[AIRnode];
        int node = SURFACEnode;
        for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
        {
            VolSoilAtNode = 0.5 * (DEPTHApsim[node + 1] - DEPTHApsim[node - 1]);
            heatStorage[node]=Divide(volSpecHeatSoil[node] * VolSoilAtNode, gDt, 0.0);
            elementLength = DEPTHApsim[node + 1] - DEPTHApsim[node];
            thermalConductance[node]=Divide(thermalConductivity[node], elementLength, 0.0);
        }
        for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
        {
            c[node]=-nu * thermalConductance[node];
            a[node + 1]=c[node];
            b[node]=nu * (thermalConductance[node] + thermalConductance[node - 1]) + heatStorage[node];
            d[node]=g * thermalConductance[(node - 1)] * soilTemp[(node - 1)] + ((heatStorage[node] - (g * (thermalConductance[node] + thermalConductance[node - 1]))) * soilTemp[node]) + (g * thermalConductance[node] * soilTemp[(node + 1)]);
        }
        a[SURFACEnode]=0.0;
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
        d[SURFACEnode]=d[SURFACEnode] + SoilSurfaceHeatFlux;
        d[numNodes]=d[numNodes] + (nu * thermalConductance[numNodes] * newTemps[(numNodes + 1)]);
        for (node=SURFACEnode ; node!=numNodes ; node+=1)
        {
            c[node]=Divide(c[node], b[node], 0.0);
            d[node]=Divide(d[node], b[node], 0.0);
            b[node + 1]=b[node + 1] - (a[(node + 1)] * c[node]);
            d[node + 1]=d[node + 1] - (a[(node + 1)] * d[node]);
        }
        newTemps[numNodes]=Divide(d[numNodes], b[numNodes], 0.0);
        for (node=numNodes - 1 ; node!=SURFACEnode - 1 ; node+=-1)
        {
            newTemps[node]=d[node] - (c[node] * newTemps[(node + 1)]);
        }
        return newTemps;
    }
    public static void  doUpdate(List<double> tempNew, ref List<double> soilTemp, List<double> minSoilTemp, List<double> maxSoilTemp, List<double> aveSoilTemp, List<double> thermalConductivity, ref double boundaryLayerConductance, int IterationsPerDay, double timeOfDaySecs, double gDt, int numNodes)
    {
        int SURFACEnode = 1;
        int AIRnode = 0;
        int node = 1;
        for (node=0 ; node!=tempNew.Count ; node+=1)
        {
            soilTemp[node]=tempNew[node];
        }
        if (timeOfDaySecs < (gDt * 1.2))
        {
            for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
            {
                minSoilTemp[node]=soilTemp[node];
                maxSoilTemp[node]=soilTemp[node];
            }
        }
        for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
        {
            if (soilTemp[node] < minSoilTemp[node])
            {
                minSoilTemp[node]=soilTemp[node];
            }
            else if ( soilTemp[node] > maxSoilTemp[node])
            {
                maxSoilTemp[node]=soilTemp[node];
            }
            aveSoilTemp[node]=aveSoilTemp[node] + Divide(soilTemp[node], (double)(IterationsPerDay), 0.0);
        }
        boundaryLayerConductance = boundaryLayerConductance + Divide(thermalConductivity[AIRnode], (double)(IterationsPerDay), 0.0);
    }
    public static void  doThermalConductivityCoeffs(int nbLayers, int numNodes, List<double> BDApsim, List<double> CLAYApsim, out List<double> thermalCondPar1, out List<double> thermalCondPar2, out List<double> thermalCondPar3, out List<double> thermalCondPar4)
    {
         thermalCondPar1 = new List<double>();
         thermalCondPar2 = new List<double>();
         thermalCondPar3 = new List<double>();
         thermalCondPar4 = new List<double>();
        int layer;
        int element;
        thermalCondPar1 = new List<double>{0.0};
        thermalCondPar2 = new List<double>{0.0};
        thermalCondPar3 = new List<double>{0.0};
        thermalCondPar4 = new List<double>{0.0};
        for (layer=0 ; layer!=numNodes + 1 ; layer+=1)
        {
            thermalCondPar1.Add(0.0);
            thermalCondPar2.Add(0.0);
            thermalCondPar3.Add(0.0);
            thermalCondPar4.Add(0.0);
        }
        for (layer=1 ; layer!=nbLayers + 2 ; layer+=1)
        {
            element = layer;
            thermalCondPar1[element]=0.65 - (0.78 * BDApsim[layer]) + (0.6 * Math.Pow(BDApsim[layer], 2));
            thermalCondPar2[element]=1.06 * BDApsim[layer];
            thermalCondPar3[element]=Divide(2.6, Math.Sqrt(CLAYApsim[layer]), 0.0);
            thermalCondPar3[element]=1.0 + thermalCondPar3[element];
            thermalCondPar4[element]=0.03 + (0.1 * Math.Pow(BDApsim[layer], 2));
        }
    }
    public static List<double> CalcSoilTemp(List<double> THICKApsim, double tav, double tamp, int doy, double latitude, int numNodes)
    {
        List<double> cumulativeDepth = new List<double>();
        List<double> soilTempIO = new List<double>();
        List<double> soilTemperat = new List<double>();
        int Layer;
        int nodes;
        double tempValue;
        double w;
        double dh;
        double zd;
        double offset;
        int SURFACEnode = 1;
        double piVal = 3.141592653589793;
        cumulativeDepth = new List<double>{0.0};
        for (Layer=0 ; Layer!=THICKApsim.Count ; Layer+=1)
        {
            cumulativeDepth.Add(0.0);
        }
        if (THICKApsim.Count > 0)
        {
            cumulativeDepth[0]=THICKApsim[0];
            for (Layer=1 ; Layer!=THICKApsim.Count ; Layer+=1)
            {
                cumulativeDepth[Layer]=THICKApsim[Layer] + cumulativeDepth[Layer - 1];
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
        soilTemperat = new List<double>{0.0};
        soilTempIO = new List<double>{0.0};
        for (Layer=0 ; Layer!=numNodes + 1 ; Layer+=1)
        {
            soilTemperat.Add(0.0);
            soilTempIO.Add(0.0);
        }
        for (nodes=1 ; nodes!=numNodes + 1 ; nodes+=1)
        {
            soilTemperat[nodes]=tav + (tamp * Math.Exp(-1.0 * cumulativeDepth[nodes] / zd) * Math.Sin(((doy / 365.0 + offset) * 2.0 * piVal - (cumulativeDepth[nodes] / zd))));
        }
        for (Layer=SURFACEnode ; Layer!=numNodes + 1 ; Layer+=1)
        {
            soilTempIO[Layer]=soilTemperat[Layer - 1];
        }
        return soilTempIO;
    }
}