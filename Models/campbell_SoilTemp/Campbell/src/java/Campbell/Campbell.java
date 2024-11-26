import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class Campbell
{
    public void Init(Model_SoilTempCampbellState s, Model_SoilTempCampbellState s1, Model_SoilTempCampbellRate r, Model_SoilTempCampbellAuxiliary a,  Model_SoilTempCampbellExogenous ex)
    {
        doThermalConductivityCoeffs zz_doThermalConductivityCoeffs;
        CalcSoilTemp zz_CalcSoilTemp;
        double T2M = ex.getT2M();
        double TMAX = ex.getTMAX();
        double TMIN = ex.getTMIN();
        Integer DOY = ex.getDOY();
        double airPressure = ex.getairPressure();
        double canopyHeight = ex.getcanopyHeight();
        double SRAD = ex.getSRAD();
        double ESP = ex.getESP();
        double ES = ex.getES();
        double EOAD = ex.getEOAD();
        double windSpeed = ex.getwindSpeed();
        List<Double> THICKApsim = new ArrayList<>(Arrays.asList());
        List<Double> DEPTHApsim = new ArrayList<>(Arrays.asList());
        List<Double> BDApsim = new ArrayList<>(Arrays.asList());
        List<Double> CLAYApsim = new ArrayList<>(Arrays.asList());
        List<Double> SWApsim = new ArrayList<>(Arrays.asList());
        List<Double> soilTemp = new ArrayList<>(Arrays.asList());
        List<Double> newTemperature = new ArrayList<>(Arrays.asList());
        List<Double> minSoilTemp = new ArrayList<>(Arrays.asList());
        List<Double> maxSoilTemp = new ArrayList<>(Arrays.asList());
        List<Double> aveSoilTemp = new ArrayList<>(Arrays.asList());
        List<Double> morningSoilTemp = new ArrayList<>(Arrays.asList());
        List<Double> thermalCondPar1 = new ArrayList<>(Arrays.asList());
        List<Double> thermalCondPar2 = new ArrayList<>(Arrays.asList());
        List<Double> thermalCondPar3 = new ArrayList<>(Arrays.asList());
        List<Double> thermalCondPar4 = new ArrayList<>(Arrays.asList());
        List<Double> thermalConductivity = new ArrayList<>(Arrays.asList());
        List<Double> thermalConductance = new ArrayList<>(Arrays.asList());
        List<Double> heatStorage = new ArrayList<>(Arrays.asList());
        List<Double> volSpecHeatSoil = new ArrayList<>(Arrays.asList());
        double maxTempYesterday;
        double minTempYesterday;
        List<Double> SLCARBApsim = new ArrayList<>(Arrays.asList());
        List<Double> SLROCKApsim = new ArrayList<>(Arrays.asList());
        List<Double> SLSILTApsim = new ArrayList<>(Arrays.asList());
        List<Double> SLSANDApsim = new ArrayList<>(Arrays.asList());
        double _boundaryLayerConductance;
        THICKApsim = new ArrayList<>(Arrays.asList());
        DEPTHApsim = new ArrayList<>(Arrays.asList());
        BDApsim = new ArrayList<>(Arrays.asList());
        CLAYApsim = new ArrayList<>(Arrays.asList());
        SWApsim = new ArrayList<>(Arrays.asList());
        soilTemp = new ArrayList<>(Arrays.asList());
        newTemperature = new ArrayList<>(Arrays.asList());
        minSoilTemp = new ArrayList<>(Arrays.asList());
        maxSoilTemp = new ArrayList<>(Arrays.asList());
        aveSoilTemp = new ArrayList<>(Arrays.asList());
        morningSoilTemp = new ArrayList<>(Arrays.asList());
        thermalCondPar1 = new ArrayList<>(Arrays.asList());
        thermalCondPar2 = new ArrayList<>(Arrays.asList());
        thermalCondPar3 = new ArrayList<>(Arrays.asList());
        thermalCondPar4 = new ArrayList<>(Arrays.asList());
        thermalConductivity = new ArrayList<>(Arrays.asList());
        thermalConductance = new ArrayList<>(Arrays.asList());
        heatStorage = new ArrayList<>(Arrays.asList());
        volSpecHeatSoil = new ArrayList<>(Arrays.asList());
        maxTempYesterday = 0.0d;
        minTempYesterday = 0.0d;
        SLCARBApsim = new ArrayList<>(Arrays.asList());
        SLROCKApsim = new ArrayList<>(Arrays.asList());
        SLSILTApsim = new ArrayList<>(Arrays.asList());
        SLSANDApsim = new ArrayList<>(Arrays.asList());
        _boundaryLayerConductance = 0.0d;
        List<Double> heatCapacity = new ArrayList<>(Arrays.asList());
        double soilRoughnessHeight;
        double defaultInstrumentHeight;
        double AltitudeMetres;
        Integer NUM_PHANTOM_NODES;
        Integer AIRnode;
        Integer SURFACEnode;
        Integer TOPSOILnode;
        double sumThickness;
        double BelowProfileDepth;
        double thicknessForPhantomNodes;
        double ave_temp;
        Integer I;
        Integer numNodes;
        Integer firstPhantomNode;
        Integer layer;
        Integer node;
        double surfaceT;
        soilRoughnessHeight = 0.057d;
        defaultInstrumentHeight = 1.2d;
        AltitudeMetres = 18.0d;
        NUM_PHANTOM_NODES = 5;
        AIRnode = 0;
        SURFACEnode = 1;
        TOPSOILnode = 2;
        if (instrumentHeight > 0.00001d)
        {
            instrumentHeight = instrumentHeight;
        }
        else
        {
            instrumentHeight = defaultInstrumentHeight;
        }
        numNodes = NLAYR + NUM_PHANTOM_NODES;
        THICKApsim.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            THICKApsim.set(layer,THICK[layer - 1]);
        }
        sumThickness = 0.0d;
        for (I=1 ; I!=NLAYR + 1 ; I+=1)
        {
            sumThickness = sumThickness + THICKApsim.get(I);
        }
        BelowProfileDepth = Math.max(CONSTANT_TEMPdepth - sumThickness, 1000.0d);
        thicknessForPhantomNodes = BelowProfileDepth * 2.0d / NUM_PHANTOM_NODES;
        firstPhantomNode = NLAYR;
        for (I=firstPhantomNode ; I!=firstPhantomNode + NUM_PHANTOM_NODES ; I+=1)
        {
            THICKApsim.set(I,thicknessForPhantomNodes);
        }DEPTHApsim.fill(numNodes + 1 + 1, 0.0d);
        DEPTHApsim.set(AIRnode,0.0d);
        DEPTHApsim.set(SURFACEnode,0.0d);
        DEPTHApsim.set(TOPSOILnode,0.5d * THICKApsim.get(1) / 1000.0d);
        for (node=TOPSOILnode ; node!=numNodes + 1 ; node+=1)
        {
            sumThickness = 0.0d;
            for (I=1 ; I!=node ; I+=1)
            {
                sumThickness = sumThickness + THICKApsim.get(I);
            }
            DEPTHApsim.set(node + 1,(sumThickness + (0.5d * THICKApsim.get(node))) / 1000.0d);
        }BDApsim.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            BDApsim.set(layer,BD[layer - 1]);
        }
        BDApsim.set(numNodes,BDApsim.get(NLAYR));
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            BDApsim.set(layer,BDApsim.get(NLAYR));
        }SWApsim.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            SWApsim.set(layer,SW[layer - 1]);
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SWApsim.set(layer,SWApsim.get((NLAYR - 1)) * THICKApsim.get((NLAYR - 1)) / THICKApsim.get(NLAYR));
        }SLCARBApsim.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            SLCARBApsim.set(layer,SLCARB[layer - 1]);
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SLCARBApsim.set(layer,SLCARBApsim.get(NLAYR));
        }SLROCKApsim.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            SLROCKApsim.set(layer,SLROCK[layer - 1]);
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SLROCKApsim.set(layer,SLROCKApsim.get(NLAYR));
        }SLSANDApsim.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            SLSANDApsim.set(layer,SLSAND[layer - 1]);
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SLSANDApsim.set(layer,SLSANDApsim.get(NLAYR));
        }SLSILTApsim.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            SLSILTApsim.set(layer,SLSILT[layer - 1]);
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SLSILTApsim.set(layer,SLSILTApsim.get(NLAYR));
        }CLAYApsim.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            CLAYApsim.set(layer,CLAY[layer - 1]);
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            CLAYApsim.set(layer,CLAYApsim.get(NLAYR));
        }maxSoilTemp.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);minSoilTemp.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);aveSoilTemp.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);volSpecHeatSoil.fill(numNodes + 1, 0.0d);soilTemp.fill(numNodes + 1 + 1, 0.0d);morningSoilTemp.fill(numNodes + 1 + 1, 0.0d);newTemperature.fill(numNodes + 1 + 1, 0.0d);thermalConductivity.fill(numNodes + 1, 0.0d);heatStorage.fill(numNodes + 1, 0.0d);thermalConductance.fill(numNodes + 1 + 1, 0.0d);
        zz_doThermalConductivityCoeffs = Calculate_doThermalConductivityCoeffs(NLAYR, numNodes, BDApsim, CLAYApsim);
        thermalCondPar1 = zz_doThermalConductivityCoeffs.getthermalCondPar1();
        thermalCondPar2 = zz_doThermalConductivityCoeffs.getthermalCondPar2();
        thermalCondPar3 = zz_doThermalConductivityCoeffs.getthermalCondPar3();
        thermalCondPar4 = zz_doThermalConductivityCoeffs.getthermalCondPar4();
        newTemperature = CalcSoilTemp(THICKApsim, TAV, TAMP, DOY, XLAT, numNodes);
        canopyHeight = Math.max(canopyHeight, soilRoughnessHeight);
        instrumentHeight = Math.max(instrumentHeight, canopyHeight + 0.5d);
        soilTemp = CalcSoilTemp(THICKApsim, TAV, TAMP, DOY, XLAT, numNodes);
        soilTemp.set(AIRnode,T2M);
        surfaceT = (1.0d - SALB) * (T2M + ((TMAX - T2M) * Math.sqrt(Math.max(SRAD, 0.1d) * 23.8846d / 800.0d))) + (SALB * T2M);
        soilTemp.set(SURFACEnode,surfaceT);
        for (I=numNodes + 1 ; I!=soilTemp.size() ; I+=1)
        {
            soilTemp.set(I,TAV);
        }
        for (I=0 ; I!=soilTemp.size() ; I+=1)
        {
            newTemperature.set(I,soilTemp.get(I));
        }
        maxTempYesterday = TMAX;
        minTempYesterday = TMIN;
        s.setTHICKApsim(THICKApsim);
        s.setDEPTHApsim(DEPTHApsim);
        s.setBDApsim(BDApsim);
        s.setCLAYApsim(CLAYApsim);
        s.setSWApsim(SWApsim);
        s.setsoilTemp(soilTemp);
        s.setnewTemperature(newTemperature);
        s.setminSoilTemp(minSoilTemp);
        s.setmaxSoilTemp(maxSoilTemp);
        s.setaveSoilTemp(aveSoilTemp);
        s.setmorningSoilTemp(morningSoilTemp);
        s.setthermalCondPar1(thermalCondPar1);
        s.setthermalCondPar2(thermalCondPar2);
        s.setthermalCondPar3(thermalCondPar3);
        s.setthermalCondPar4(thermalCondPar4);
        s.setthermalConductivity(thermalConductivity);
        s.setthermalConductance(thermalConductance);
        s.setheatStorage(heatStorage);
        s.setvolSpecHeatSoil(volSpecHeatSoil);
        s.setmaxTempYesterday(maxTempYesterday);
        s.setminTempYesterday(minTempYesterday);
        s.setSLCARBApsim(SLCARBApsim);
        s.setSLROCKApsim(SLROCKApsim);
        s.setSLSILTApsim(SLSILTApsim);
        s.setSLSANDApsim(SLSANDApsim);
        s.set_boundaryLayerConductance(_boundaryLayerConductance);
    }
    private Integer NLAYR;
    public Integer getNLAYR()
    { return NLAYR; }

    public void setNLAYR(Integer _NLAYR)
    { this.NLAYR= _NLAYR; } 
    
    private Double [] THICK;
    public Double [] getTHICK()
    { return THICK; }

    public void setTHICK(Double [] _THICK)
    { this.THICK= _THICK; } 
    
    private Double [] BD;
    public Double [] getBD()
    { return BD; }

    public void setBD(Double [] _BD)
    { this.BD= _BD; } 
    
    private Double [] SLCARB;
    public Double [] getSLCARB()
    { return SLCARB; }

    public void setSLCARB(Double [] _SLCARB)
    { this.SLCARB= _SLCARB; } 
    
    private Double [] CLAY;
    public Double [] getCLAY()
    { return CLAY; }

    public void setCLAY(Double [] _CLAY)
    { this.CLAY= _CLAY; } 
    
    private Double [] SLROCK;
    public Double [] getSLROCK()
    { return SLROCK; }

    public void setSLROCK(Double [] _SLROCK)
    { this.SLROCK= _SLROCK; } 
    
    private Double [] SLSILT;
    public Double [] getSLSILT()
    { return SLSILT; }

    public void setSLSILT(Double [] _SLSILT)
    { this.SLSILT= _SLSILT; } 
    
    private Double [] SLSAND;
    public Double [] getSLSAND()
    { return SLSAND; }

    public void setSLSAND(Double [] _SLSAND)
    { this.SLSAND= _SLSAND; } 
    
    private Double [] SW;
    public Double [] getSW()
    { return SW; }

    public void setSW(Double [] _SW)
    { this.SW= _SW; } 
    
    private double CONSTANT_TEMPdepth;
    public double getCONSTANT_TEMPdepth()
    { return CONSTANT_TEMPdepth; }

    public void setCONSTANT_TEMPdepth(double _CONSTANT_TEMPdepth)
    { this.CONSTANT_TEMPdepth= _CONSTANT_TEMPdepth; } 
    
    private double TAV;
    public double getTAV()
    { return TAV; }

    public void setTAV(double _TAV)
    { this.TAV= _TAV; } 
    
    private double TAMP;
    public double getTAMP()
    { return TAMP; }

    public void setTAMP(double _TAMP)
    { this.TAMP= _TAMP; } 
    
    private double XLAT;
    public double getXLAT()
    { return XLAT; }

    public void setXLAT(double _XLAT)
    { this.XLAT= _XLAT; } 
    
    private double SALB;
    public double getSALB()
    { return SALB; }

    public void setSALB(double _SALB)
    { this.SALB= _SALB; } 
    
    private double instrumentHeight;
    public double getinstrumentHeight()
    { return instrumentHeight; }

    public void setinstrumentHeight(double _instrumentHeight)
    { this.instrumentHeight= _instrumentHeight; } 
    
    private String boundaryLayerConductanceSource;
    public String getboundaryLayerConductanceSource()
    { return boundaryLayerConductanceSource; }

    public void setboundaryLayerConductanceSource(String _boundaryLayerConductanceSource)
    { this.boundaryLayerConductanceSource= _boundaryLayerConductanceSource; } 
    
    private String netRadiationSource;
    public String getnetRadiationSource()
    { return netRadiationSource; }

    public void setnetRadiationSource(String _netRadiationSource)
    { this.netRadiationSource= _netRadiationSource; } 
    
    public Campbell() { }
    public void  Calculate_Model(Model_SoilTempCampbellState s, Model_SoilTempCampbellState s1, Model_SoilTempCampbellRate r, Model_SoilTempCampbellAuxiliary a,  Model_SoilTempCampbellExogenous ex)
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
        doNetRadiation zz_doNetRadiation;
        Zero zz_Zero;
        doVolumetricSpecificHeat zz_doVolumetricSpecificHeat;
        doThermConductivity zz_doThermConductivity;
        InterpTemp zz_InterpTemp;
        RadnNetInterpolate zz_RadnNetInterpolate;
        boundaryLayerConductanceF zz_boundaryLayerConductanceF;
        doThomas zz_doThomas;
        doUpdate zz_doUpdate;
        List<Double> THICKApsim = s.getTHICKApsim();
        List<Double> DEPTHApsim = s.getDEPTHApsim();
        List<Double> BDApsim = s.getBDApsim();
        double T2M = ex.getT2M();
        double TMAX = ex.getTMAX();
        double TMIN = ex.getTMIN();
        List<Double> CLAYApsim = s.getCLAYApsim();
        List<Double> SWApsim = s.getSWApsim();
        Integer DOY = ex.getDOY();
        double airPressure = ex.getairPressure();
        double canopyHeight = ex.getcanopyHeight();
        double SRAD = ex.getSRAD();
        double ESP = ex.getESP();
        double ES = ex.getES();
        double EOAD = ex.getEOAD();
        List<Double> soilTemp = s.getsoilTemp();
        List<Double> newTemperature = s.getnewTemperature();
        List<Double> minSoilTemp = s.getminSoilTemp();
        List<Double> maxSoilTemp = s.getmaxSoilTemp();
        List<Double> aveSoilTemp = s.getaveSoilTemp();
        List<Double> morningSoilTemp = s.getmorningSoilTemp();
        List<Double> thermalCondPar1 = s.getthermalCondPar1();
        List<Double> thermalCondPar2 = s.getthermalCondPar2();
        List<Double> thermalCondPar3 = s.getthermalCondPar3();
        List<Double> thermalCondPar4 = s.getthermalCondPar4();
        List<Double> thermalConductivity = s.getthermalConductivity();
        List<Double> thermalConductance = s.getthermalConductance();
        List<Double> heatStorage = s.getheatStorage();
        List<Double> volSpecHeatSoil = s.getvolSpecHeatSoil();
        double maxTempYesterday = s.getmaxTempYesterday();
        double minTempYesterday = s.getminTempYesterday();
        double windSpeed = ex.getwindSpeed();
        List<Double> SLCARBApsim = s.getSLCARBApsim();
        List<Double> SLROCKApsim = s.getSLROCKApsim();
        List<Double> SLSILTApsim = s.getSLSILTApsim();
        List<Double> SLSANDApsim = s.getSLSANDApsim();
        double _boundaryLayerConductance = s.get_boundaryLayerConductance();
        Integer AIRnode;
        Integer SURFACEnode;
        Integer TOPSOILnode;
        Integer ITERATIONSperDAY;
        Integer NUM_PHANTOM_NODES;
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
        Integer BoundaryLayerConductanceIterations;
        Integer numNodes;
        String[] soilConstituentNames ;
        Integer timeStepIteration;
        double netRadiation;
        double constantBoundaryLayerConductance;
        double precision;
        double cva;
        double cloudFr;
        List<Double> solarRadn = new ArrayList<>(Arrays.asList());
        Integer layer;
        double timeOfDaySecs;
        double airTemperature;
        Integer iteration;
        double tMean;
        double internalTimeStep;
        AIRnode = 0;
        SURFACEnode = 1;
        TOPSOILnode = 2;
        ITERATIONSperDAY = 48;
        NUM_PHANTOM_NODES = 5;
        DAYhrs = 24.0d;
        MIN2SEC = 60.0d;
        HR2MIN = 60.0d;
        SEC2HR = 1.0d / (HR2MIN * MIN2SEC);
        DAYmins = DAYhrs * HR2MIN;
        DAYsecs = DAYmins * MIN2SEC;
        PA2HPA = 1.0d / 100.0d;
        MJ2J = 1000000.0d;
        J2MJ = 1.0d / MJ2J;
        tempStepSec = 24.0d * 60.0d * 60.0d;
        soilRoughnessHeight = 0.057d;
        BoundaryLayerConductanceIterations = 1;
        numNodes = NLAYR + NUM_PHANTOM_NODES;
        soilConstituentNames = new ArrayList<>(Arrays.asList("Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"));
        timeStepIteration = 1;
        constantBoundaryLayerConductance = 20.0d;
        layer = 0;
        canopyHeight = Math.max(canopyHeight, soilRoughnessHeight);
        cva = 0.0d;
        cloudFr = 0.0d;
        solarRadn = new ArrayList<>(Arrays.asList(0.0d));
        for (layer=0 ; layer!=50 ; layer+=1)
        {
            solarRadn.add(0.0d);
        }
        zz_doNetRadiation = Calculate_doNetRadiation(solarRadn, cloudFr, cva, ITERATIONSperDAY, DOY, SRAD, TMIN, XLAT);
        solarRadn = zz_doNetRadiation.getsolarRadn();
        cloudFr = zz_doNetRadiation.getcloudFr();
        cva = zz_doNetRadiation.getcva();
        minSoilTemp = Zero(minSoilTemp);
        maxSoilTemp = Zero(maxSoilTemp);
        aveSoilTemp = Zero(aveSoilTemp);
        _boundaryLayerConductance = 0.0d;
        internalTimeStep = tempStepSec / (double)(ITERATIONSperDAY);
        volSpecHeatSoil = doVolumetricSpecificHeat(volSpecHeatSoil, SWApsim, numNodes, soilConstituentNames, THICKApsim, DEPTHApsim);
        thermalConductivity = doThermConductivity(SWApsim, SLCARBApsim, SLROCKApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, BDApsim, thermalConductivity, THICKApsim, DEPTHApsim, numNodes, soilConstituentNames);
        for (timeStepIteration=1 ; timeStepIteration!=ITERATIONSperDAY + 1 ; timeStepIteration+=1)
        {
            timeOfDaySecs = internalTimeStep * (double)(timeStepIteration);
            if (tempStepSec < (24.0d * 60.0d * 60.0d))
            {
                tMean = T2M;
            }
            else
            {
                tMean = InterpTemp(timeOfDaySecs * SEC2HR, TMAX, TMIN, T2M, maxTempYesterday, minTempYesterday);
            }
            newTemperature.set(AIRnode,tMean);
            netRadiation = RadnNetInterpolate(internalTimeStep, solarRadn.get(timeStepIteration), cloudFr, cva, ESP, EOAD, tMean, SALB, soilTemp);
            if (boundaryLayerConductanceSource == "constant")
            {
                thermalConductivity.set(AIRnode,constantBoundaryLayerConductance);
            }
            else if ( boundaryLayerConductanceSource == "calc")
            {
                thermalConductivity.set(AIRnode,boundaryLayerConductanceF(newTemperature, tMean, ESP, EOAD, airPressure, canopyHeight, windSpeed, instrumentHeight));
                for (iteration=1 ; iteration!=BoundaryLayerConductanceIterations + 1 ; iteration+=1)
                {
                    newTemperature = doThomas(newTemperature, soilTemp, thermalConductivity, thermalConductance, DEPTHApsim, volSpecHeatSoil, internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource);
                    thermalConductivity.set(AIRnode,boundaryLayerConductanceF(newTemperature, tMean, ESP, EOAD, airPressure, canopyHeight, windSpeed, instrumentHeight));
                }
            }
            newTemperature = doThomas(newTemperature, soilTemp, thermalConductivity, thermalConductance, DEPTHApsim, volSpecHeatSoil, internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource);
            zz_doUpdate = Calculate_doUpdate(newTemperature, soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp, thermalConductivity, _boundaryLayerConductance, ITERATIONSperDAY, timeOfDaySecs, internalTimeStep, numNodes);
            soilTemp = zz_doUpdate.getsoilTemp();
            _boundaryLayerConductance = zz_doUpdate.getboundaryLayerConductance();
            precision = Math.min(timeOfDaySecs, 5.0d * 3600.0d) * 0.0001d;
            if (Math.abs(timeOfDaySecs - (5.0d * 3600.0d)) <= precision)
            {
                for (layer=0 ; layer!=soilTemp.size() ; layer+=1)
                {
                    morningSoilTemp.set(layer,soilTemp.get(layer));
                }
            }
        }
        minTempYesterday = TMIN;
        maxTempYesterday = TMAX;
        s.setTHICKApsim(THICKApsim);
        s.setDEPTHApsim(DEPTHApsim);
        s.setBDApsim(BDApsim);
        s.setCLAYApsim(CLAYApsim);
        s.setSWApsim(SWApsim);
        s.setsoilTemp(soilTemp);
        s.setnewTemperature(newTemperature);
        s.setminSoilTemp(minSoilTemp);
        s.setmaxSoilTemp(maxSoilTemp);
        s.setaveSoilTemp(aveSoilTemp);
        s.setmorningSoilTemp(morningSoilTemp);
        s.setthermalCondPar1(thermalCondPar1);
        s.setthermalCondPar2(thermalCondPar2);
        s.setthermalCondPar3(thermalCondPar3);
        s.setthermalCondPar4(thermalCondPar4);
        s.setthermalConductivity(thermalConductivity);
        s.setthermalConductance(thermalConductance);
        s.setheatStorage(heatStorage);
        s.setvolSpecHeatSoil(volSpecHeatSoil);
        s.setmaxTempYesterday(maxTempYesterday);
        s.setminTempYesterday(minTempYesterday);
        s.setSLCARBApsim(SLCARBApsim);
        s.setSLROCKApsim(SLROCKApsim);
        s.setSLSILTApsim(SLSILTApsim);
        s.setSLSANDApsim(SLSANDApsim);
        s.set_boundaryLayerConductance(_boundaryLayerConductance);
    }
    public doNetRadiation Calculate_doNetRadiation (List<Double> solarRadn, double cloudFr, double cva, Integer ITERATIONSperDAY, Integer doy, double rad, double tmin, double latitude)
    {
        List<Double> m1 = new ArrayList<>(Arrays.asList());
        Integer lay;
        solarRadn.fill(ITERATIONSperDAY + 1, 0.0d);
        double piVal = 3.141592653589793;
        double TSTEPS2RAD = 1.0;
        double SOLARconst = 1.0;
        double solarDeclination = 1.0;
        m1 = new ArrayList<>(Arrays.asList(0.0d));
        for (lay=0 ; lay!=ITERATIONSperDAY + 1 ; lay+=1)
        {
            m1.add(0.0d);
        }
        TSTEPS2RAD = Divide(2.0d * piVal, (double)(ITERATIONSperDAY), 0.0d);
        SOLARconst = 1360.0d;
        solarDeclination = 0.3985d * Math.sin((4.869d + (doy * 2.0d * piVal / 365.25d) + (0.03345d * Math.sin((6.224d + (doy * 2.0d * piVal / 365.25d))))));
        double cD = Math.sqrt(1.0d - (solarDeclination * solarDeclination));
        double m1Tot = 0.0;
        double psr;
        Integer timestepNumber = 1;
        double fr;
        double scalar;
        for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
        {
            m1.set(timestepNumber,(solarDeclination * Math.sin(latitude * piVal / 180.0d) + (cD * Math.cos(latitude * piVal / 180.0d) * Math.cos(TSTEPS2RAD * ((double)(timestepNumber) - ((double)(ITERATIONSperDAY) / 2.0d))))) * 24.0d / (double)(ITERATIONSperDAY));
            if (m1.get(timestepNumber) > 0.0d)
            {
                m1Tot = m1Tot + m1.get(timestepNumber);
            }
            else
            {
                m1.set(timestepNumber,0.0d);
            }
        }
        psr = m1Tot * SOLARconst * 3600.0d / 1000000.0d;
        fr = Divide(Math.max(rad, 0.1d), psr, 0.0d);
        cloudFr = 2.33d - (3.33d * fr);
        cloudFr = Math.min(Math.max(cloudFr, 0.0d), 1.0d);
        scalar = Math.max(rad, 0.1d);
        for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
        {
            solarRadn.set(timestepNumber,scalar * Divide(m1.get(timestepNumber), m1Tot, 0.0d));
        }
        double kelvinTemp = kelvinT(tmin);
        cva = Math.exp((31.3716d - (6014.79d / kelvinTemp) - (0.00792495d * kelvinTemp))) / kelvinTemp;
        return new doNetRadiation(solarRadn, cloudFr, cva);
    }
    public static double Divide(double val1, double val2, double errVal)
    {
        double returnValue = errVal;
        if (val2 != 0.0d)
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
    public static List<Double> Zero(List<Double> arr)
    {
        Integer I = 0;
        for (I=0 ; I!=arr.size() ; I+=1)
        {
            arr.set(I,0.d);
        }
        return arr;
    }
    public static List<Double> doVolumetricSpecificHeat(List<Double> volSpecLayer, List<Double> soilW, Integer numNodes, String [] constituents, List<Double> THICKApsim, List<Double> DEPTHApsim)
    {
        List<Double> volSpecHeatSoil = new ArrayList<>(Arrays.asList());
        volSpecHeatSoil = new ArrayList<>(Arrays.asList(0.0d));
        Integer node;
        for (node=0 ; node!=numNodes + 1 ; node+=1)
        {
            volSpecHeatSoil.add(0.0d);
        }
        Integer constituent;
        for (node=1 ; node!=numNodes + 1 ; node+=1)
        {
            volSpecHeatSoil.set(node,0.0d);
            for (constituent=0 ; constituent!=constituents.length ; constituent+=1)
            {
                volSpecHeatSoil.set(node,volSpecHeatSoil.get(node) + (volumetricSpecificHeat(constituents[constituent]) * 1000000.0d * soilW.get(node)));
            }
        }
        volSpecLayer = mapLayer2Node(volSpecHeatSoil, volSpecLayer, THICKApsim, DEPTHApsim, numNodes);
        return volSpecLayer;
    }
    public static double volumetricSpecificHeat(String name)
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
    public static List<Double> mapLayer2Node(List<Double> layerArray, List<Double> nodeArray, List<Double> THICKApsim, List<Double> DEPTHApsim, Integer numNodes)
    {
        Integer SURFACEnode = 1;
        double depthLayerAbove;
        Integer node = 0;
        Integer I = 0;
        Integer layer;
        double d1;
        double d2;
        double dSum;
        for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
        {
            layer = node - 1;
            depthLayerAbove = 0.0d;
            if (layer >= 1)
            {
                for (I=1 ; I!=layer + 1 ; I+=1)
                {
                    depthLayerAbove = depthLayerAbove + THICKApsim.get(I);
                }
            }
            d1 = depthLayerAbove - (DEPTHApsim.get(node) * 1000.0d);
            d2 = DEPTHApsim.get((node + 1)) * 1000.0d - depthLayerAbove;
            dSum = d1 + d2;
            nodeArray.set(node,Divide(layerArray.get(layer) * d1, dSum, 0.0d) + Divide(layerArray.get((layer + 1)) * d2, dSum, 0.0d));
        }
        return nodeArray;
    }
    public static List<Double> doThermConductivity(List<Double> soilW, List<Double> SLCARBApsim, List<Double> SLROCKApsim, List<Double> SLSANDApsim, List<Double> SLSILTApsim, List<Double> CLAYApsim, List<Double> BDApsim, List<Double> thermalConductivity, List<Double> THICKApsim, List<Double> DEPTHApsim, Integer numNodes, String [] constituents)
    {
        List<Double> thermCondLayers = new ArrayList<>(Arrays.asList());
        thermCondLayers = new ArrayList<>(Arrays.asList(0.0d));
        Integer I;
        for (I=0 ; I!=numNodes + 1 ; I+=1)
        {
            thermCondLayers.add(0.0d);
        }
        Integer node = 1;
        Integer constituent = 1;
        double temp;
        double numerator;
        double denominator;
        double shapeFactorConstituent;
        double thermalConductanceConstituent;
        double thermalConductanceWater;
        double k;
        for (node=1 ; node!=numNodes + 1 ; node+=1)
        {
            numerator = 0.0d;
            denominator = 0.0d;
            for (constituent=0 ; constituent!=constituents.length ; constituent+=1)
            {
                shapeFactorConstituent = shapeFactor(constituents[constituent], SLROCKApsim, SLCARBApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, soilW, BDApsim, node);
                thermalConductanceConstituent = ThermalConductance(constituents[constituent]);
                thermalConductanceWater = ThermalConductance("Water");
                k = 2.0d / 3.0d * Math.pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0d))), -1) + (1.0d / 3.0d * Math.pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0d) * (1.0d - (2.0d * shapeFactorConstituent)))), -1));
                numerator = numerator + (thermalConductanceConstituent * soilW.get(node) * k);
                denominator = denominator + (soilW.get(node) * k);
            }
            thermCondLayers.set(node,numerator / denominator);
        }
        thermalConductivity = mapLayer2Node(thermCondLayers, thermalConductivity, THICKApsim, DEPTHApsim, numNodes);
        return thermalConductivity;
    }
    public static double shapeFactor(String name, List<Double> SLROCKApsim, List<Double> SLCARBApsim, List<Double> SLSANDApsim, List<Double> SLSILTApsim, List<Double> CLAYApsim, List<Double> SWApsim, List<Double> BDApsim, Integer layer)
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
            result = 0.333d - (0.333d * 0.0d / (volumetricFractionWater(SWApsim, SLCARBApsim, BDApsim, layer) + 0.0d + volumetricFractionAir(SLROCKApsim, SLCARBApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, SWApsim, BDApsim, layer)));
            return result;
        }
        else if ( name == "Air")
        {
            result = 0.333d - (0.333d * volumetricFractionAir(SLROCKApsim, SLCARBApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, SWApsim, BDApsim, layer) / (volumetricFractionWater(SWApsim, SLCARBApsim, BDApsim, layer) + 0.0d + volumetricFractionAir(SLROCKApsim, SLCARBApsim, SLSANDApsim, SLSILTApsim, CLAYApsim, SWApsim, BDApsim, layer)));
            return result;
        }
        else if ( name == "Minerals")
        {
            result = shapeFactorRocks * volumetricFractionRocks(SLROCKApsim, layer) + (shapeFactorSand * volumetricFractionSand(SLSANDApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer)) + (shapeFactorSilt * volumetricFractionSilt(SLSILTApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer)) + (shapeFactorClay * volumetricFractionClay(CLAYApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer));
        }
        result = volumetricSpecificHeat(name);
        return result;
    }
    public static double ThermalConductance(String name)
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
    public static double volumetricFractionWater(List<Double> SWApsim, List<Double> SLCARBApsim, List<Double> BDApsim, Integer layer)
    {
        double res = (1.0d - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer)) * SWApsim.get(layer);
        return res;
    }
    public static double volumetricFractionAir(List<Double> SLROCKApsim, List<Double> SLCARBApsim, List<Double> SLSANDApsim, List<Double> SLSILTApsim, List<Double> CLAYApsim, List<Double> SWApsim, List<Double> BDApsim, Integer layer)
    {
        double res = 1.0d - volumetricFractionRocks(SLROCKApsim, layer) - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionSand(SLSANDApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer) - volumetricFractionSilt(SLSILTApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer) - volumetricFractionClay(CLAYApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer) - volumetricFractionWater(SWApsim, SLCARBApsim, BDApsim, layer) - 0.0d;
        return res;
    }
    public static double volumetricFractionRocks(List<Double> SLROCKApsim, Integer layer)
    {
        double res = SLROCKApsim.get(layer) / 100.0d;
        return res;
    }
    public static double volumetricFractionSand(List<Double> SLSANDApsim, List<Double> SLROCKApsim, List<Double> SLCARBApsim, List<Double> BDApsim, Integer layer)
    {
        double ps = 2.63;
        double res = (1.0d - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionRocks(SLROCKApsim, layer)) * SLSANDApsim.get(layer) / 100.0d * BDApsim.get(layer) / ps;
        return res;
    }
    public static double volumetricFractionSilt(List<Double> SLSILTApsim, List<Double> SLROCKApsim, List<Double> SLCARBApsim, List<Double> BDApsim, Integer layer)
    {
        double ps = 2.63;
        double res = (1.0d - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionRocks(SLROCKApsim, layer)) * SLSILTApsim.get(layer) / 100.0d * BDApsim.get(layer) / ps;
        return res;
    }
    public static double volumetricFractionClay(List<Double> CLAYApsim, List<Double> SLROCKApsim, List<Double> SLCARBApsim, List<Double> BDApsim, Integer layer)
    {
        double ps = 2.63;
        double res = (1.0d - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionRocks(SLROCKApsim, layer)) * CLAYApsim.get(layer) / 100.0d * BDApsim.get(layer) / ps;
        return res;
    }
    public static double volumetricFractionOrganicMatter(List<Double> SLCARBApsim, List<Double> BDApsim, Integer layer)
    {
        double pom = 1.3;
        double res = SLCARBApsim.get(layer) / 100.0d * 2.5d * BDApsim.get(layer) / pom;
        return res;
    }
    public static double InterpTemp(double time_hours, double tmax, double tmin, double t2m, double max_temp_yesterday, double min_temp_yesterday)
    {
        double defaultTimeOfMaximumTemperature = 14.0;
        double midnight_temp;
        double t_scale;
        double piVal = 3.141592653589793;
        double time = time_hours / 24.0d;
        double max_t_time = defaultTimeOfMaximumTemperature / 24.0d;
        double min_t_time = max_t_time - 0.5d;
        double current_temp = 0.0;
        if (time < min_t_time)
        {
            midnight_temp = Math.sin((0.0d + 0.25d - max_t_time) * 2.0d * piVal) * (max_temp_yesterday - min_temp_yesterday) / 2.0d + ((max_temp_yesterday + min_temp_yesterday) / 2.0d);
            t_scale = (min_t_time - time) / min_t_time;
            if (t_scale > 1.0d)
            {
                t_scale = 1.0d;
            }
            else if ( t_scale < 0.0d)
            {
                t_scale = 0.0d;
            }
            current_temp = tmin + (t_scale * (midnight_temp - tmin));
            return current_temp;
        }
        else
        {
            current_temp = Math.sin((time + 0.25d - max_t_time) * 2.0d * piVal) * (tmax - tmin) / 2.0d + t2m;
            return current_temp;
        }
        return current_temp;
    }
    public static double RadnNetInterpolate(double internalTimeStep, double solarRadiation, double cloudFr, double cva, double potE, double potET, double tMean, double albedo, List<Double> soilTemp)
    {
        double EMISSIVITYsurface = 0.96;
        double w2MJ = internalTimeStep / 1000000.0d;
        Integer SURFACEnode = 1;
        double emissivityAtmos = (1 - (0.84d * cloudFr)) * 0.58d * Math.pow(cva, 1.0d / 7.0d) + (0.84d * cloudFr);
        double PenetrationConstant = Divide(Math.max(0.1d, potE), Math.max(0.1d, potET), 0.0d);
        double lwRinSoil = longWaveRadn(emissivityAtmos, tMean) * PenetrationConstant * w2MJ;
        double lwRoutSoil = longWaveRadn(EMISSIVITYsurface, soilTemp.get(SURFACEnode)) * PenetrationConstant * w2MJ;
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
        double res = STEFAN_BOLTZMANNconst * emissivity * Math.pow(kelvinTemp, 4);
        return res;
    }
    public static double boundaryLayerConductanceF(List<Double> TNew_zb, double tMean, double potE, double potET, double airPressure, double canopyHeight, double windSpeed, double instrumentHeight)
    {
        double VONK = 0.41;
        double GRAVITATIONALconst = 9.8;
        double specificHeatOfAir = 1010.0;
        double EMISSIVITYsurface = 0.98;
        Integer SURFACEnode = 1;
        double STEFAN_BOLTZMANNconst = 0.0000000567;
        double SpecificHeatAir = specificHeatOfAir * airDensity(tMean, airPressure);
        double RoughnessFacMomentum = 0.13d * canopyHeight;
        double RoughnessFacHeat = 0.2d * RoughnessFacMomentum;
        double d = 0.77d * canopyHeight;
        double SurfaceTemperature = TNew_zb.get(SURFACEnode);
        double PenetrationConstant = Math.max(0.1d, potE) / Math.max(0.1d, potET);
        double kelvinTemp = kelvinT(tMean);
        double radiativeConductance = 4.0d * STEFAN_BOLTZMANNconst * EMISSIVITYsurface * PenetrationConstant * Math.pow(kelvinTemp, 3);
        double FrictionVelocity = 0.0;
        double BoundaryLayerCond = 0.0;
        double StabilityParam = 0.0;
        double StabilityCorMomentum = 0.0;
        double StabilityCorHeat = 0.0;
        double HeatFluxDensity = 0.0;
        Integer iteration = 1;
        for (iteration=1 ; iteration!=4 ; iteration+=1)
        {
            FrictionVelocity = Divide(windSpeed * VONK, Math.log(Divide(instrumentHeight - d + RoughnessFacMomentum, RoughnessFacMomentum, 0.0d)) + StabilityCorMomentum, 0.0d);
            BoundaryLayerCond = Divide(SpecificHeatAir * VONK * FrictionVelocity, Math.log(Divide(instrumentHeight - d + RoughnessFacHeat, RoughnessFacHeat, 0.0d)) + StabilityCorHeat, 0.0d);
            BoundaryLayerCond = BoundaryLayerCond + radiativeConductance;
            HeatFluxDensity = BoundaryLayerCond * (SurfaceTemperature - tMean);
            StabilityParam = Divide(-VONK * instrumentHeight * GRAVITATIONALconst * HeatFluxDensity, SpecificHeatAir * kelvinTemp * Math.pow(FrictionVelocity, 3), 0.0d);
            if (StabilityParam > 0.0d)
            {
                StabilityCorHeat = 4.7d * StabilityParam;
                StabilityCorMomentum = StabilityCorHeat;
            }
            else
            {
                StabilityCorHeat = -2.0d * Math.log((1.0d + Math.sqrt(1.0d - (16.0d * StabilityParam))) / 2.0d);
                StabilityCorMomentum = 0.6d * StabilityCorHeat;
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
        double res = Divide(MWair * AirPressure * HPA2PA, kelvinTemp * RGAS, 0.0d);
        return res;
    }
    public static List<Double> doThomas(List<Double> newTemps, List<Double> soilTemp, List<Double> thermalConductivity, List<Double> thermalConductance, List<Double> DEPTHApsim, List<Double> volSpecHeatSoil, double gDt, double netRadiation, double potE, double actE, Integer numNodes, String netRadiationSource)
    {
        double nu = 0.6;
        Integer AIRnode = 0;
        Integer SURFACEnode = 1;
        double MJ2J = 1000000.0;
        double latentHeatOfVapourisation = 2465000.0;
        double tempStepSec = 24.0d * 60.0d * 60.0d;
        Integer I;
        List<Double> heatStorage = new ArrayList<>(Arrays.asList());
        heatStorage = new ArrayList<>(Arrays.asList(0.d));
        double VolSoilAtNode;
        double elementLength;
        double g = 1 - nu;
        double sensibleHeatFlux;
        double RadnNet;
        double LatentHeatFlux;
        double SoilSurfaceHeatFlux;
        List<Double> a = new ArrayList<>(Arrays.asList());
        List<Double> b = new ArrayList<>(Arrays.asList());
        List<Double> c = new ArrayList<>(Arrays.asList());
        List<Double> d = new ArrayList<>(Arrays.asList());
        a = new ArrayList<>(Arrays.asList(0.0d));
        b = new ArrayList<>(Arrays.asList(0.0d));
        c = new ArrayList<>(Arrays.asList(0.0d));
        d = new ArrayList<>(Arrays.asList(0.0d));
        for (I=0 ; I!=numNodes + 1 ; I+=1)
        {
            a.add(0.0d);
            b.add(0.0d);
            c.add(0.0d);
            d.add(0.0d);
            heatStorage.add(0.0d);
        }
        a.add(0.0d);thermalConductance.fill(numNodes + 1, 0.d);
        thermalConductance.set(AIRnode,thermalConductivity.get(AIRnode));
        Integer node = SURFACEnode;
        for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
        {
            VolSoilAtNode = 0.5d * (DEPTHApsim.get(node + 1) - DEPTHApsim.get(node - 1));
            heatStorage.set(node,Divide(volSpecHeatSoil.get(node) * VolSoilAtNode, gDt, 0.0d));
            elementLength = DEPTHApsim.get(node + 1) - DEPTHApsim.get(node);
            thermalConductance.set(node,Divide(thermalConductivity.get(node), elementLength, 0.0d));
        }
        for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
        {
            c.set(node,-nu * thermalConductance.get(node));
            a.set(node + 1,c.get(node));
            b.set(node,nu * (thermalConductance.get(node) + thermalConductance.get(node - 1)) + heatStorage.get(node));
            d.set(node,g * thermalConductance.get((node - 1)) * soilTemp.get((node - 1)) + ((heatStorage.get(node) - (g * (thermalConductance.get(node) + thermalConductance.get(node - 1)))) * soilTemp.get(node)) + (g * thermalConductance.get(node) * soilTemp.get((node + 1))));
        }
        a.set(SURFACEnode,0.0d);
        sensibleHeatFlux = nu * thermalConductance.get(AIRnode) * newTemps.get(AIRnode);
        RadnNet = 0.0d;
        if (netRadiationSource == "calc")
        {
            RadnNet = Divide(netRadiation * 1000000.0d, gDt, 0.0d);
        }
        else if ( netRadiationSource == "eos")
        {
            RadnNet = Divide(potE * latentHeatOfVapourisation, tempStepSec, 0.0d);
        }
        LatentHeatFlux = Divide(actE * latentHeatOfVapourisation, tempStepSec, 0.0d);
        SoilSurfaceHeatFlux = sensibleHeatFlux + RadnNet - LatentHeatFlux;
        d.set(SURFACEnode,d.get(SURFACEnode) + SoilSurfaceHeatFlux);
        d.set(numNodes,d.get(numNodes) + (nu * thermalConductance.get(numNodes) * newTemps.get((numNodes + 1))));
        for (node=SURFACEnode ; node!=numNodes ; node+=1)
        {
            c.set(node,Divide(c.get(node), b.get(node), 0.0d));
            d.set(node,Divide(d.get(node), b.get(node), 0.0d));
            b.set(node + 1,b.get(node + 1) - (a.get((node + 1)) * c.get(node)));
            d.set(node + 1,d.get(node + 1) - (a.get((node + 1)) * d.get(node)));
        }
        newTemps.set(numNodes,Divide(d.get(numNodes), b.get(numNodes), 0.0d));
        for (node=numNodes - 1 ; node!=SURFACEnode - 1 ; node+=-1)
        {
            newTemps.set(node,d.get(node) - (c.get(node) * newTemps.get((node + 1))));
        }
        return newTemps;
    }
    public doUpdate Calculate_doUpdate (List<Double> tempNew, List<Double> soilTemp, List<Double> minSoilTemp, List<Double> maxSoilTemp, List<Double> aveSoilTemp, List<Double> thermalConductivity, double boundaryLayerConductance, Integer IterationsPerDay, double timeOfDaySecs, double gDt, Integer numNodes)
    {
        Integer SURFACEnode = 1;
        Integer AIRnode = 0;
        Integer node = 1;
        for (node=0 ; node!=tempNew.size() ; node+=1)
        {
            soilTemp.set(node,tempNew.get(node));
        }
        if (timeOfDaySecs < (gDt * 1.2d))
        {
            for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
            {
                minSoilTemp.set(node,soilTemp.get(node));
                maxSoilTemp.set(node,soilTemp.get(node));
            }
        }
        for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
        {
            if (soilTemp.get(node) < minSoilTemp.get(node))
            {
                minSoilTemp.set(node,soilTemp.get(node));
            }
            else if ( soilTemp.get(node) > maxSoilTemp.get(node))
            {
                maxSoilTemp.set(node,soilTemp.get(node));
            }
            aveSoilTemp.set(node,aveSoilTemp.get(node) + Divide(soilTemp.get(node), (double)(IterationsPerDay), 0.0d));
        }
        boundaryLayerConductance = boundaryLayerConductance + Divide(thermalConductivity.get(AIRnode), (double)(IterationsPerDay), 0.0d);
        return new doUpdate(soilTemp, boundaryLayerConductance);
    }
    public doThermalConductivityCoeffs Calculate_doThermalConductivityCoeffs (Integer nbLayers, Integer numNodes, List<Double> BDApsim, List<Double> CLAYApsim)
    {
        List<Double> thermalCondPar1 = new ArrayList<>(Arrays.asList());
        List<Double> thermalCondPar2 = new ArrayList<>(Arrays.asList());
        List<Double> thermalCondPar3 = new ArrayList<>(Arrays.asList());
        List<Double> thermalCondPar4 = new ArrayList<>(Arrays.asList());
        Integer layer;
        Integer element;
        thermalCondPar1 = new ArrayList<>(Arrays.asList(0.0d));
        thermalCondPar2 = new ArrayList<>(Arrays.asList(0.0d));
        thermalCondPar3 = new ArrayList<>(Arrays.asList(0.0d));
        thermalCondPar4 = new ArrayList<>(Arrays.asList(0.0d));
        for (layer=0 ; layer!=numNodes + 1 ; layer+=1)
        {
            thermalCondPar1.add(0.0d);
            thermalCondPar2.add(0.0d);
            thermalCondPar3.add(0.0d);
            thermalCondPar4.add(0.0d);
        }
        for (layer=1 ; layer!=nbLayers + 2 ; layer+=1)
        {
            element = layer;
            thermalCondPar1.set(element,0.65d - (0.78d * BDApsim.get(layer)) + (0.6d * Math.pow(BDApsim.get(layer), 2)));
            thermalCondPar2.set(element,1.06d * BDApsim.get(layer));
            thermalCondPar3.set(element,Divide(2.6d, Math.sqrt(CLAYApsim.get(layer)), 0.0d));
            thermalCondPar3.set(element,1.0d + thermalCondPar3.get(element));
            thermalCondPar4.set(element,0.03d + (0.1d * Math.pow(BDApsim.get(layer), 2)));
        }
        return new doThermalConductivityCoeffs(thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4);
    }
    public static List<Double> CalcSoilTemp(List<Double> THICKApsim, double tav, double tamp, Integer doy, double latitude, Integer numNodes)
    {
        List<Double> cumulativeDepth = new ArrayList<>(Arrays.asList());
        List<Double> soilTempIO = new ArrayList<>(Arrays.asList());
        List<Double> soilTemperat = new ArrayList<>(Arrays.asList());
        Integer Layer;
        Integer nodes;
        double tempValue;
        double w;
        double dh;
        double zd;
        double offset;
        Integer SURFACEnode = 1;
        double piVal = 3.141592653589793;
        cumulativeDepth = new ArrayList<>(Arrays.asList(0.0d));
        for (Layer=0 ; Layer!=THICKApsim.size() ; Layer+=1)
        {
            cumulativeDepth.add(0.0d);
        }
        if (THICKApsim.size() > 0)
        {
            cumulativeDepth.set(0,THICKApsim.get(0));
            for (Layer=1 ; Layer!=THICKApsim.size() ; Layer+=1)
            {
                cumulativeDepth.set(Layer,THICKApsim.get(Layer) + cumulativeDepth.get(Layer - 1));
            }
        }
        w = piVal;
        w = 2.0d * w;
        w = w / (365.25d * 24.0d * 3600.0d);
        dh = 0.6d;
        zd = Math.sqrt(2 * dh / w);
        offset = 0.25d;
        if (latitude > 0.0d)
        {
            offset = -0.25d;
        }
        soilTemperat = new ArrayList<>(Arrays.asList(0.0d));
        soilTempIO = new ArrayList<>(Arrays.asList(0.0d));
        for (Layer=0 ; Layer!=numNodes + 1 ; Layer+=1)
        {
            soilTemperat.add(0.0d);
            soilTempIO.add(0.0d);
        }
        for (nodes=1 ; nodes!=numNodes + 1 ; nodes+=1)
        {
            soilTemperat.set(nodes,tav + (tamp * Math.exp(-1.0d * cumulativeDepth.get(nodes) / zd) * Math.sin(((doy / 365.0d + offset) * 2.0d * piVal - (cumulativeDepth.get(nodes) / zd)))));
        }
        for (Layer=SURFACEnode ; Layer!=numNodes + 1 ; Layer+=1)
        {
            soilTempIO.set(Layer,soilTemperat.get(Layer - 1));
        }
        return soilTempIO;
    }
}
final class doNetRadiation {
    private List<Double> solarRadn;
    public List<Double> getsolarRadn()
    { return solarRadn; }

    public void setsolarRadn(List<Double> _solarRadn)
    { this.solarRadn= _solarRadn; } 
    
    private double cloudFr;
    public double getcloudFr()
    { return cloudFr; }

    public void setcloudFr(double _cloudFr)
    { this.cloudFr= _cloudFr; } 
    
    private double cva;
    public double getcva()
    { return cva; }

    public void setcva(double _cva)
    { this.cva= _cva; } 
    
    public doNetRadiation(List<Double> solarRadn,double cloudFr,double cva)
    {
        this.solarRadn = solarRadn;
        this.cloudFr = cloudFr;
        this.cva = cva;
    }
}final class doUpdate {
    private List<Double> soilTemp;
    public List<Double> getsoilTemp()
    { return soilTemp; }

    public void setsoilTemp(List<Double> _soilTemp)
    { this.soilTemp= _soilTemp; } 
    
    private double boundaryLayerConductance;
    public double getboundaryLayerConductance()
    { return boundaryLayerConductance; }

    public void setboundaryLayerConductance(double _boundaryLayerConductance)
    { this.boundaryLayerConductance= _boundaryLayerConductance; } 
    
    public doUpdate(List<Double> soilTemp,double boundaryLayerConductance)
    {
        this.soilTemp = soilTemp;
        this.boundaryLayerConductance = boundaryLayerConductance;
    }
}final class doThermalConductivityCoeffs {
    private List<Double> thermalCondPar1;
    public List<Double> getthermalCondPar1()
    { return thermalCondPar1; }

    public void setthermalCondPar1(List<Double> _thermalCondPar1)
    { this.thermalCondPar1= _thermalCondPar1; } 
    
    private List<Double> thermalCondPar2;
    public List<Double> getthermalCondPar2()
    { return thermalCondPar2; }

    public void setthermalCondPar2(List<Double> _thermalCondPar2)
    { this.thermalCondPar2= _thermalCondPar2; } 
    
    private List<Double> thermalCondPar3;
    public List<Double> getthermalCondPar3()
    { return thermalCondPar3; }

    public void setthermalCondPar3(List<Double> _thermalCondPar3)
    { this.thermalCondPar3= _thermalCondPar3; } 
    
    private List<Double> thermalCondPar4;
    public List<Double> getthermalCondPar4()
    { return thermalCondPar4; }

    public void setthermalCondPar4(List<Double> _thermalCondPar4)
    { this.thermalCondPar4= _thermalCondPar4; } 
    
    public doThermalConductivityCoeffs(List<Double> thermalCondPar1,List<Double> thermalCondPar2,List<Double> thermalCondPar3,List<Double> thermalCondPar4)
    {
        this.thermalCondPar1 = thermalCondPar1;
        this.thermalCondPar2 = thermalCondPar2;
        this.thermalCondPar3 = thermalCondPar3;
        this.thermalCondPar4 = thermalCondPar4;
    }
}