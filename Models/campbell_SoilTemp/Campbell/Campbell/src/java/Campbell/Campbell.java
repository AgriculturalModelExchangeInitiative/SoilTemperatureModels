import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class Campbell
{
    public void Init(model_SoilTempCampbellState s, model_SoilTempCampbellState s1, model_SoilTempCampbellRate r, model_SoilTempCampbellAuxiliary a,  model_SoilTempCampbellExogenous ex)
    {
        doThermalConductivityCoeffs zz_doThermalConductivityCoeffs;
        CalcSoilTemp zz_CalcSoilTemp;
        Double [] THICK = ex.getTHICK();
        Double [] BD = ex.getBD();
        Double [] SLCARB = ex.getSLCARB();
        Double [] CLAY = ex.getCLAY();
        Double [] SLROCK = ex.getSLROCK();
        Double [] SLSILT = ex.getSLSILT();
        Double [] SLSAND = ex.getSLSAND();
        Double [] SW = ex.getSW();
        double T2M = ex.getT2M();
        double TMAX = ex.getTMAX();
        double TMIN = ex.getTMIN();
        double TAV = ex.getTAV();
        Integer DOY = ex.getDOY();
        double airPressure = ex.getairPressure();
        double canopyHeight = ex.getcanopyHeight();
        double SRAD = ex.getSRAD();
        double ESP = ex.getESP();
        double ES = ex.getES();
        double EOAD = ex.getEOAD();
        double windSpeed = ex.getwindSpeed();
        Double[] THICKApsim ;
        Double[] DEPTHApsim =  new Double [NLAYR];
        Double[] BDApsim ;
        Double[] CLAYApsim ;
        Double[] SWApsim ;
        Double[] soilTemp =  new Double [NLAYR];
        Double[] newTemperature =  new Double [NLAYR];
        Double[] minSoilTemp =  new Double [NLAYR];
        Double[] maxSoilTemp =  new Double [NLAYR];
        Double[] aveSoilTemp =  new Double [NLAYR];
        Double[] morningSoilTemp =  new Double [NLAYR];
        Double[] thermalCondPar1 =  new Double [NLAYR];
        Double[] thermalCondPar2 =  new Double [NLAYR];
        Double[] thermalCondPar3 =  new Double [NLAYR];
        Double[] thermalCondPar4 =  new Double [NLAYR];
        Double[] thermalConductivity =  new Double [NLAYR];
        Double[] thermalConductance =  new Double [NLAYR];
        Double[] heatStorage =  new Double [NLAYR];
        Double[] volSpecHeatSoil =  new Double [NLAYR];
        double maxTempYesterday;
        double minTempYesterday;
        Double[] SLCARBApsim =  new Double [NLAYR];
        Double[] SLROCKApsim =  new Double [NLAYR];
        Double[] SLSILTApsim =  new Double [NLAYR];
        Double[] SLSANDApsim =  new Double [NLAYR];
        double _boundaryLayerConductance;
        DEPTHApsim= new Double[NLAYR];
        Arrays.fill(DEPTHApsim, 0.0d);
        soilTemp= new Double[NLAYR];
        Arrays.fill(soilTemp, 0.0d);
        newTemperature= new Double[NLAYR];
        Arrays.fill(newTemperature, 0.0d);
        minSoilTemp= new Double[NLAYR];
        Arrays.fill(minSoilTemp, 0.0d);
        maxSoilTemp= new Double[NLAYR];
        Arrays.fill(maxSoilTemp, 0.0d);
        aveSoilTemp= new Double[NLAYR];
        Arrays.fill(aveSoilTemp, 0.0d);
        morningSoilTemp= new Double[NLAYR];
        Arrays.fill(morningSoilTemp, 0.0d);
        thermalCondPar1= new Double[NLAYR];
        Arrays.fill(thermalCondPar1, 0.0d);
        thermalCondPar2= new Double[NLAYR];
        Arrays.fill(thermalCondPar2, 0.0d);
        thermalCondPar3= new Double[NLAYR];
        Arrays.fill(thermalCondPar3, 0.0d);
        thermalCondPar4= new Double[NLAYR];
        Arrays.fill(thermalCondPar4, 0.0d);
        thermalConductivity= new Double[NLAYR];
        Arrays.fill(thermalConductivity, 0.0d);
        thermalConductance= new Double[NLAYR];
        Arrays.fill(thermalConductance, 0.0d);
        heatStorage= new Double[NLAYR];
        Arrays.fill(heatStorage, 0.0d);
        volSpecHeatSoil= new Double[NLAYR];
        Arrays.fill(volSpecHeatSoil, 0.0d);
        maxTempYesterday = 0.0d;
        minTempYesterday = 0.0d;
        SLCARBApsim= new Double[NLAYR];
        Arrays.fill(SLCARBApsim, 0.0d);
        SLROCKApsim= new Double[NLAYR];
        Arrays.fill(SLROCKApsim, 0.0d);
        SLSILTApsim= new Double[NLAYR];
        Arrays.fill(SLSILTApsim, 0.0d);
        SLSANDApsim= new Double[NLAYR];
        Arrays.fill(SLSANDApsim, 0.0d);
        _boundaryLayerConductance = 0.0d;
        Double[] heatCapacity ;
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
        Integer i;
        Integer numNodes;
        Integer firstPhantomNode;
        Integer layer;
        Integer node;
        double surfaceT;
        soilRoughnessHeight = 57.0d;
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
            THICKApsim[layer] = THICK[layer - 1];
        }
        sumThickness = 0.0d;
        for (i=1 ; i!=NLAYR + 1 ; i+=1)
        {
            sumThickness = sumThickness + THICKApsim[i];
        }
        BelowProfileDepth = Math.max(CONSTANT_TEMPdepth - sumThickness, 1000.0d);
        thicknessForPhantomNodes = BelowProfileDepth * 2.0d / NUM_PHANTOM_NODES;
        firstPhantomNode = NLAYR;
        for (i=firstPhantomNode ; i!=firstPhantomNode + NUM_PHANTOM_NODES ; i+=1)
        {
            THICKApsim[i] = thicknessForPhantomNodes;
        }DEPTHApsim.fill(numNodes + 1 + 1, 0.0d);
        DEPTHApsim[AIRnode] = 0.0d;
        DEPTHApsim[SURFACEnode] = 0.0d;
        DEPTHApsim[TOPSOILnode] = 0.5d * THICKApsim[1] / 1000.0d;
        for (node=TOPSOILnode ; node!=numNodes + 1 ; node+=1)
        {
            sumThickness = 0.0d;
            for (i=1 ; i!=node ; i+=1)
            {
                sumThickness = sumThickness + THICKApsim[i];
            }
            DEPTHApsim[node + 1] = (sumThickness + (0.5d * THICKApsim[node])) / 1000.0d;
        }BDApsim.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            BDApsim[layer] = BD[layer - 1];
        }
        BDApsim[numNodes] = BDApsim[NLAYR];
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            BDApsim[layer] = BDApsim[NLAYR];
        }SWApsim.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            SWApsim[layer] = SW[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SWApsim[layer] = SWApsim[(NLAYR - 1)] * THICKApsim[(NLAYR - 1)] / THICKApsim[NLAYR];
        }SLCARBApsim.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            SLCARBApsim[layer] = SLCARB[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SLCARBApsim[layer] = SLCARBApsim[NLAYR];
        }SLROCKApsim.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            SLROCKApsim[layer] = SLROCK[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SLROCKApsim[layer] = SLROCKApsim[NLAYR];
        }SLSANDApsim.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            SLSANDApsim[layer] = SLSAND[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SLSANDApsim[layer] = SLSANDApsim[NLAYR];
        }SLSILTApsim.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            SLSILTApsim[layer] = SLSILT[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SLSILTApsim[layer] = SLSILTApsim[NLAYR];
        }CLAYApsim.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);
        for (layer=1 ; layer!=NLAYR + 1 ; layer+=1)
        {
            CLAYApsim[layer] = CLAY[layer - 1];
        }
        for (layer=NLAYR + 1 ; layer!=NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            CLAYApsim[layer] = CLAYApsim[NLAYR];
        }maxSoilTemp.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);minSoilTemp.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);aveSoilTemp.fill(NLAYR + 1 + NUM_PHANTOM_NODES, 0.0d);volSpecHeatSoil.fill(numNodes + 1, 0.0d);soilTemp.fill(numNodes + 1 + 1, 0.0d);morningSoilTemp.fill(numNodes + 1 + 1, 0.0d);newTemperature.fill(numNodes + 1 + 1, 0.0d);thermalConductivity.fill(numNodes + 1, 0.0d);heatStorage.fill(numNodes + 1, 0.0d);thermalConductance.fill(numNodes + 1 + 1, 0.0d);
        zz_doThermalConductivityCoeffs = Calculate_doThermalConductivityCoeffs(NLAYR, numNodes, BDApsim, CLAYApsim);
        thermalCondPar1 = zz_doThermalConductivityCoeffs.getthermalCondPar1();
        thermalCondPar2 = zz_doThermalConductivityCoeffs.getthermalCondPar2();
        thermalCondPar3 = zz_doThermalConductivityCoeffs.getthermalCondPar3();
        thermalCondPar4 = zz_doThermalConductivityCoeffs.getthermalCondPar4();
        newTemperature = CalcSoilTemp(THICKApsim, TAV, TAMP, DOY, XLAT, numNodes);
        instrumentHeight = Math.max(instrumentHeight, canopyHeight + 0.5d);
        soilTemp = CalcSoilTemp(THICKApsim, TAV, TAMP, DOY, XLAT, numNodes);
        soilTemp[AIRnode] = T2M;
        surfaceT = (1.0d - SALB) * (T2M + ((TMAX - T2M) * Math.sqrt(Math.max(SRAD, 0.1d) * 23.8846d / 800.0d))) + (SALB * T2M);
        soilTemp[SURFACEnode] = surfaceT;
        for (i=numNodes + 1 ; i!=soilTemp.length ; i+=1)
        {
            soilTemp[i] = TAV;
        }
        for (i=0 ; i!=soilTemp.length ; i+=1)
        {
            newTemperature[i] = soilTemp[i];
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
    
    private double CONSTANT_TEMPdepth;
    public double getCONSTANT_TEMPdepth()
    { return CONSTANT_TEMPdepth; }

    public void setCONSTANT_TEMPdepth(double _CONSTANT_TEMPdepth)
    { this.CONSTANT_TEMPdepth= _CONSTANT_TEMPdepth; } 
    
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
    public void  Calculate_Model(model_SoilTempCampbellState s, model_SoilTempCampbellState s1, model_SoilTempCampbellRate r, model_SoilTempCampbellAuxiliary a,  model_SoilTempCampbellExogenous ex)
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
    //                          ** description : Soil layer depths as THICKApsim of layers
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 1
    //                          ** default : 50
    //                          ** unit : mm
    //            * name: BD
    //                          ** description : bd (soil bulk density)
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 1.4
    //                          ** unit : g/cm3             uri :
    //            * name: SLCARB
    //                          ** description : Volumetric fraction of organic matter in the soil
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: CLAY
    //                          ** description : Proportion of CLAYApsim in each layer of profile
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 100
    //                          ** min : 0
    //                          ** default : 50
    //                          ** unit : 
    //            * name: SLROCK
    //                          ** description : Volumetric fraction of SLROCKApsim in the soil
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: SLSILT
    //                          ** description : Volumetric fraction of SLSILTApsim in the soil
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: SLSAND
    //                          ** description : Volumetric fraction of SLSANDApsim in the soil
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
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
    //            * name: THICKApsim
    //                          ** description : APSIM soil layer depths as THICKApsim of layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 1
    //                          ** default : 50
    //                          ** unit : mm
    //            * name: DEPTHApsim
    //                          ** description : Apsim node depths
    //                          ** inputtype : variable
    //                          ** variablecategory : state
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
    //            * name: BDApsim
    //                          ** description : Apsim bd (soil bulk density)
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 1.4
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
    //            * name: CLAYApsim
    //                          ** description : Apsim proportion of CLAYApsim in each layer of profile
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 100
    //                          ** min : 0
    //                          ** default : 50
    //                          ** unit : 
    //            * name: SWApsim
    //                          ** description : Apsim volumetric water content
    //                          ** inputtype : variable
    //                          ** variablecategory : state
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
    //            * name: SLCARBApsim
    //                          ** description : Volumetric fraction of organic matter in the soil
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: SLROCKApsim
    //                          ** description : Volumetric fraction of SLROCKApsim in the soil
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: SLSILTApsim
    //                          ** description : Volumetric fraction of SLSILTApsim in the soil
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: SLSANDApsim
    //                          ** description : Apsim volumetric fraction of SLSANDApsim in the soil
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
    //            * name: THICKApsim
    //                          ** description : APSIM soil layer depths as THICKApsim of layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 1
    //                          ** unit : mm
    //            * name: DEPTHApsim
    //                          ** description : APSIM node depths
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : m
    //            * name: BDApsim
    //                          ** description : bd (soil bulk density) is name of the APSIM var for bulk density so set BDApsim
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : g/cm3             uri :
    //            * name: SWApsim
    //                          ** description : volumetric water content
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 1
    //                          ** min : 0
    //                          ** unit : cc water / cc soil
    //            * name: CLAYApsim
    //                          ** description : Proportion of CLAYApsim in each layer of profile
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 100
    //                          ** min : 0
    //                          ** unit : 
    //            * name: SLROCKApsim
    //                          ** description : Volumetric fraction of SLROCKApsim in the soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : 
    //            * name: SLCARBApsim
    //                          ** description : Volumetric fraction of organic matter in the soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : 
    //            * name: SLSANDApsim
    //                          ** description : Volumetric fraction of SLSANDApsim in the soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : 
    //            * name: SLSILTApsim
    //                          ** description : Volumetric fraction of SLSILTApsim in the soil
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : NLAYR
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
        Double [] THICK = ex.getTHICK();
        Double [] BD = ex.getBD();
        Double [] SLCARB = ex.getSLCARB();
        Double [] CLAY = ex.getCLAY();
        Double [] SLROCK = ex.getSLROCK();
        Double [] SLSILT = ex.getSLSILT();
        Double [] SLSAND = ex.getSLSAND();
        Double [] SW = ex.getSW();
        Double [] THICKApsim = s.getTHICKApsim();
        Double [] DEPTHApsim = s.getDEPTHApsim();
        Double [] BDApsim = s.getBDApsim();
        double T2M = ex.getT2M();
        double TMAX = ex.getTMAX();
        double TMIN = ex.getTMIN();
        double TAV = ex.getTAV();
        Double [] CLAYApsim = s.getCLAYApsim();
        Double [] SWApsim = s.getSWApsim();
        Integer DOY = ex.getDOY();
        double airPressure = ex.getairPressure();
        double canopyHeight = ex.getcanopyHeight();
        double SRAD = ex.getSRAD();
        double ESP = ex.getESP();
        double ES = ex.getES();
        double EOAD = ex.getEOAD();
        Double [] soilTemp = s.getsoilTemp();
        Double [] newTemperature = s.getnewTemperature();
        Double [] minSoilTemp = s.getminSoilTemp();
        Double [] maxSoilTemp = s.getmaxSoilTemp();
        Double [] aveSoilTemp = s.getaveSoilTemp();
        Double [] morningSoilTemp = s.getmorningSoilTemp();
        Double [] thermalCondPar1 = s.getthermalCondPar1();
        Double [] thermalCondPar2 = s.getthermalCondPar2();
        Double [] thermalCondPar3 = s.getthermalCondPar3();
        Double [] thermalCondPar4 = s.getthermalCondPar4();
        Double [] thermalConductivity = s.getthermalConductivity();
        Double [] thermalConductance = s.getthermalConductance();
        Double [] heatStorage = s.getheatStorage();
        Double [] volSpecHeatSoil = s.getvolSpecHeatSoil();
        double maxTempYesterday = s.getmaxTempYesterday();
        double minTempYesterday = s.getminTempYesterday();
        double windSpeed = ex.getwindSpeed();
        Double [] SLCARBApsim = s.getSLCARBApsim();
        Double [] SLROCKApsim = s.getSLROCKApsim();
        Double [] SLSILTApsim = s.getSLSILTApsim();
        Double [] SLSANDApsim = s.getSLSANDApsim();
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
        Integer BoundaryLayerConductanceIterations;
        Integer numNodes;
        String[] soilConstituentNames ;
        Integer timeStepIteration;
        double netRadiation;
        double constantBoundaryLayerConductance;
        double precision;
        double cva;
        double cloudFr;
        Double[] solarRadn ;
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
        BoundaryLayerConductanceIterations = 1;
        numNodes = NLAYR + NUM_PHANTOM_NODES;
        soilConstituentNames = new ArrayList<>(Arrays.asList("Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"));
        timeStepIteration = 1;
        constantBoundaryLayerConductance = 20.0d;
        layer = 0;
        cva = 0.0d;
        cloudFr = 0.0d;
        solarRadn.fill(49, 0.0d);
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
            newTemperature[AIRnode] = tMean;
            netRadiation = RadnNetInterpolate(internalTimeStep, solarRadn[timeStepIteration], cloudFr, cva, ESP, EOAD, tMean, SALB, soilTemp);
            if (boundaryLayerConductanceSource == "constant")
            {
                thermalConductivity[AIRnode] = constantBoundaryLayerConductance;
            }
            else if ( boundaryLayerConductanceSource == "calc")
            {
                thermalConductivity[AIRnode] = boundaryLayerConductanceF(newTemperature, tMean, ESP, EOAD, airPressure, canopyHeight, windSpeed, instrumentHeight);
                for (iteration=1 ; iteration!=BoundaryLayerConductanceIterations + 1 ; iteration+=1)
                {
                    newTemperature = doThomas(newTemperature, soilTemp, thermalConductivity, thermalConductance, DEPTHApsim, volSpecHeatSoil, internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource);
                    thermalConductivity[AIRnode] = boundaryLayerConductanceF(newTemperature, tMean, ESP, EOAD, airPressure, canopyHeight, windSpeed, instrumentHeight);
                }
            }
            newTemperature = doThomas(newTemperature, soilTemp, thermalConductivity, thermalConductance, DEPTHApsim, volSpecHeatSoil, internalTimeStep, netRadiation, ESP, ES, numNodes, netRadiationSource);
            zz_doUpdate = Calculate_doUpdate(newTemperature, soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp, thermalConductivity, _boundaryLayerConductance, ITERATIONSperDAY, timeOfDaySecs, internalTimeStep, numNodes);
            soilTemp = zz_doUpdate.getsoilTemp();
            _boundaryLayerConductance = zz_doUpdate.getboundaryLayerConductance();
            precision = Math.min(timeOfDaySecs, 5.0d * 3600.0d) * 0.0001d;
            if (Math.abs(timeOfDaySecs - (5.0d * 3600.0d)) <= precision)
            {
                for (layer=0 ; layer!=soilTemp.length ; layer+=1)
                {
                    morningSoilTemp[layer] = soilTemp[layer];
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
    public doNetRadiation Calculate_doNetRadiation (Double [] solarRadn, double cloudFr, double cva, Integer ITERATIONSperDAY, Integer doy, double rad, double tmin, double latitude)
    {
        double piVal = 3.141592653589793;
        double TSTEPS2RAD = 1.0;
        double SOLARconst = 1.0;
        double solarDeclination = 1.0;
        Double[] m1 ;
        m1.fill(ITERATIONSperDAY + 1, 0.0d);
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
            m1[timestepNumber] = (solarDeclination * Math.sin(latitude * piVal / 180.0d) + (cD * Math.cos(latitude * piVal / 180.0d) * Math.cos(TSTEPS2RAD * ((double)(timestepNumber) - ((double)(ITERATIONSperDAY) / 2.0d))))) * 24.0d / (double)(ITERATIONSperDAY);
            if (m1[timestepNumber] > 0.0d)
            {
                m1Tot = m1Tot + m1[timestepNumber];
            }
            else
            {
                m1[timestepNumber] = 0.0d;
            }
        }
        psr = m1Tot * SOLARconst * 3600.0d / 1000000.0d;
        fr = Divide(Math.max(rad, 0.1d), psr, 0.0d);
        cloudFr = 2.33d - (3.33d * fr);
        cloudFr = Math.min(Math.max(cloudFr, 0.0d), 1.0d);
        scalar = Math.max(rad, 0.1d);
        for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
        {
            solarRadn[timestepNumber] = scalar * Divide(m1[timestepNumber], m1Tot, 0.0d);
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
    public static Double [] Zero(Double [] arr)
    {
        Integer i = 0;
        for (i=0 ; i!=arr.length ; i+=1)
        {
            arr[i] = 0.d;
        }
        return arr;
    }
    public static Double [] doVolumetricSpecificHeat(Double [] volSpecLayer, Double [] soilW, Integer numNodes, String [] constituents, Double [] THICKApsim, Double [] DEPTHApsim)
    {
        Double[] volSpecHeatSoil ;
        volSpecHeatSoil.fill(numNodes + 1, 0.0d);
        Integer node;
        Integer constituent;
        for (node=1 ; node!=numNodes + 1 ; node+=1)
        {
            volSpecHeatSoil[node] = 0.0d;
            for (constituent=0 ; constituent!=constituents.length ; constituent+=1)
            {
                volSpecHeatSoil[node] = volSpecHeatSoil[node] + (volumetricSpecificHeat(constituents[constituent]) * 1000000.0d * soilW[node]);
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
    public static Double [] mapLayer2Node(Double [] layerArray, Double [] nodeArray, Double [] THICKApsim, Double [] DEPTHApsim, Integer numNodes)
    {
        Integer SURFACEnode = 1;
        double depthLayerAbove;
        Integer node = 0;
        Integer i = 0;
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
                for (i=1 ; i!=layer + 1 ; i+=1)
                {
                    depthLayerAbove = depthLayerAbove + THICKApsim[i];
                }
            }
            d1 = depthLayerAbove - (DEPTHApsim[node] * 1000.0d);
            d2 = DEPTHApsim[(node + 1)] * 1000.0d - depthLayerAbove;
            dSum = d1 + d2;
            nodeArray[node] = Divide(layerArray[layer] * d1, dSum, 0.0d) + Divide(layerArray[(layer + 1)] * d2, dSum, 0.0d);
        }
        return nodeArray;
    }
    public static Double [] doThermConductivity(Double [] soilW, Double [] SLCARBApsim, Double [] SLROCKApsim, Double [] SLSANDApsim, Double [] SLSILTApsim, Double [] CLAYApsim, Double [] BDApsim, Double [] thermalConductivity, Double [] THICKApsim, Double [] DEPTHApsim, Integer numNodes, String [] constituents)
    {
        Double[] thermCondLayers ;
        thermCondLayers.fill(numNodes + 1, 0.0d);
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
                numerator = numerator + (thermalConductanceConstituent * soilW[node] * k);
                denominator = denominator + (soilW[node] * k);
            }
            thermCondLayers[node] = numerator / denominator;
        }
        thermalConductivity = mapLayer2Node(thermCondLayers, thermalConductivity, THICKApsim, DEPTHApsim, numNodes);
        return thermalConductivity;
    }
    public static double shapeFactor(String name, Double [] SLROCKApsim, Double [] SLCARBApsim, Double [] SLSANDApsim, Double [] SLSILTApsim, Double [] CLAYApsim, Double [] SWApsim, Double [] BDApsim, Integer layer)
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
    public static Double [] mapLayer2Node(Double [] layerArray, Double [] nodeArray, Double [] THICKApsim, Double [] DEPTHApsim, Integer numNodes)
    {
        Integer SURFACEnode = 1;
        double depthLayerAbove;
        Integer node = 0;
        Integer i = 0;
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
                for (i=1 ; i!=layer + 1 ; i+=1)
                {
                    depthLayerAbove = depthLayerAbove + THICKApsim[i];
                }
            }
            d1 = depthLayerAbove - (DEPTHApsim[node] * 1000.0d);
            d2 = DEPTHApsim[(node + 1)] * 1000.0d - depthLayerAbove;
            dSum = d1 + d2;
            nodeArray[node] = Divide(layerArray[layer] * d1, dSum, 0.0d) + Divide(layerArray[(layer + 1)] * d2, dSum, 0.0d);
        }
        return nodeArray;
    }
    public static double volumetricFractionWater(Double [] SWApsim, Double [] SLCARBApsim, Double [] BDApsim, Integer layer)
    {
        double res = (1.0d - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer)) * SWApsim[layer];
        return res;
    }
    public static double volumetricFractionAir(Double [] SLROCKApsim, Double [] SLCARBApsim, Double [] SLSANDApsim, Double [] SLSILTApsim, Double [] CLAYApsim, Double [] SWApsim, Double [] BDApsim, Integer layer)
    {
        double res = 1.0d - volumetricFractionRocks(SLROCKApsim, layer) - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionSand(SLSANDApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer) - volumetricFractionSilt(SLSILTApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer) - volumetricFractionClay(CLAYApsim, SLROCKApsim, SLCARBApsim, BDApsim, layer) - volumetricFractionWater(SWApsim, SLCARBApsim, BDApsim, layer) - 0.0d;
        return res;
    }
    public static double volumetricFractionRocks(Double [] SLROCKApsim, Integer layer)
    {
        double res = SLROCKApsim[layer] / 100.0d;
        return res;
    }
    public static double volumetricFractionSand(Double [] SLSANDApsim, Double [] SLROCKApsim, Double [] SLCARBApsim, Double [] BDApsim, Integer layer)
    {
        double ps = 2.63;
        double res = (1.0d - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionRocks(SLROCKApsim, layer)) * SLSANDApsim[layer] / 100.0d * BDApsim[layer] / ps;
        return res;
    }
    public static double volumetricFractionSilt(Double [] SLSILTApsim, Double [] SLROCKApsim, Double [] SLCARBApsim, Double [] BDApsim, Integer layer)
    {
        double ps = 2.63;
        double res = (1.0d - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionRocks(SLROCKApsim, layer)) * SLSILTApsim[layer] / 100.0d * BDApsim[layer] / ps;
        return res;
    }
    public static double volumetricFractionClay(Double [] CLAYApsim, Double [] SLROCKApsim, Double [] SLCARBApsim, Double [] BDApsim, Integer layer)
    {
        double ps = 2.63;
        double res = (1.0d - volumetricFractionOrganicMatter(SLCARBApsim, BDApsim, layer) - volumetricFractionRocks(SLROCKApsim, layer)) * CLAYApsim[layer] / 100.0d * BDApsim[layer] / ps;
        return res;
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
    public static double volumetricFractionOrganicMatter(Double [] SLCARBApsim, Double [] BDApsim, Integer layer)
    {
        double pom = 1.3;
        double res = SLCARBApsim[layer] / 100.0d * 2.5d * BDApsim[layer] / pom;
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
    public static double RadnNetInterpolate(double internalTimeStep, double solarRadiation, double cloudFr, double cva, double potE, double potET, double tMean, double albedo, Double [] soilTemp)
    {
        double EMISSIVITYsurface = 0.96;
        double w2MJ = internalTimeStep / 1000000.0d;
        Integer SURFACEnode = 1;
        double emissivityAtmos = (1 - (0.84d * cloudFr)) * 0.58d * Math.pow(cva, 1.0d / 7.0d) + (0.84d * cloudFr);
        double PenetrationConstant = Divide(Math.max(0.1d, potE), Math.max(0.1d, potET), 0.0d);
        double lwRinSoil = longWaveRadn(emissivityAtmos, tMean) * PenetrationConstant * w2MJ;
        double lwRoutSoil = longWaveRadn(EMISSIVITYsurface, soilTemp[SURFACEnode]) * PenetrationConstant * w2MJ;
        double lwRnetSoil = lwRinSoil - lwRoutSoil;
        double swRin = solarRadiation;
        double swRout = albedo * solarRadiation;
        double swRnetSoil = (swRin - swRout) * PenetrationConstant;
        double total = swRnetSoil + lwRnetSoil;
        return total;
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
    public static double longWaveRadn(double emissivity, double tDegC)
    {
        double STEFAN_BOLTZMANNconst = 0.0000000567;
        double kelvinTemp = kelvinT(tDegC);
        double res = STEFAN_BOLTZMANNconst * emissivity * Math.pow(kelvinTemp, 4);
        return res;
    }
    public static double boundaryLayerConductanceF(Double [] TNew_zb, double tMean, double potE, double potET, double airPressure, double canopyHeight, double windSpeed, double instrumentHeight)
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
        double SurfaceTemperature = TNew_zb[SURFACEnode];
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
    public static double kelvinT(double celciusT)
    {
        double ZEROTkelvin = 273.18;
        double res = celciusT + ZEROTkelvin;
        return res;
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
    public static double Divide(double val1, double val2, double errVal)
    {
        double returnValue = errVal;
        if (val2 != 0.0d)
        {
            returnValue = val1 / val2;
        }
        return returnValue;
    }
    public static Double [] doThomas(Double [] newTemps, Double [] soilTemp, Double [] thermalConductivity, Double [] thermalConductance, Double [] DEPTHApsim, Double [] volSpecHeatSoil, double gDt, double netRadiation, double potE, double actE, Integer numNodes, String netRadiationSource)
    {
        double nu = 0.6;
        Integer AIRnode = 0;
        Integer SURFACEnode = 1;
        double MJ2J = 1000000.0;
        double latentHeatOfVapourisation = 2465000.0;
        double tempStepSec = 24.0d * 60.0d * 60.0d;
        Double[] heatStorage ;
        heatStorage.fill(numNodes + 1, 0.d);
        double VolSoilAtNode;
        double elementLength;
        double g = 1 - nu;
        double sensibleHeatFlux;
        double RadnNet;
        double LatentHeatFlux;
        double SoilSurfaceHeatFlux;
        Double[] a ;
        Double[] b ;
        Double[] c ;
        Double[] d ;
        a.fill(numNodes + 2, 0.0d);b.fill(numNodes + 1, 0.0d);c.fill(numNodes + 1, 0.0d);d.fill(numNodes + 1, 0.0d);thermalConductance.fill(numNodes + 1, 0.d);
        thermalConductance[AIRnode] = thermalConductivity[AIRnode];
        Integer node = SURFACEnode;
        for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
        {
            VolSoilAtNode = 0.5d * (DEPTHApsim[node + 1] - DEPTHApsim[node - 1]);
            heatStorage[node] = Divide(volSpecHeatSoil[node] * VolSoilAtNode, gDt, 0.0d);
            elementLength = DEPTHApsim[node + 1] - DEPTHApsim[node];
            thermalConductance[node] = Divide(thermalConductivity[node], elementLength, 0.0d);
        }
        for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
        {
            c[node] = -nu * thermalConductance[node];
            a[node + 1] = c[node];
            b[node] = nu * (thermalConductance[node] + thermalConductance[node - 1]) + heatStorage[node];
            d[node] = g * thermalConductance[(node - 1)] * soilTemp[(node - 1)] + ((heatStorage[node] - (g * (thermalConductance[node] + thermalConductance[node - 1]))) * soilTemp[node]) + (g * thermalConductance[node] * soilTemp[(node + 1)]);
        }
        a[SURFACEnode] = 0.0d;
        sensibleHeatFlux = nu * thermalConductance[AIRnode] * newTemps[AIRnode];
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
        d[SURFACEnode] = d[SURFACEnode] + SoilSurfaceHeatFlux;
        d[numNodes] = d[numNodes] + (nu * thermalConductance[numNodes] * newTemps[(numNodes + 1)]);
        for (node=SURFACEnode ; node!=numNodes ; node+=1)
        {
            c[node] = Divide(c[node], b[node], 0.0d);
            d[node] = Divide(d[node], b[node], 0.0d);
            b[node + 1] = b[node + 1] - (a[(node + 1)] * c[node]);
            d[node + 1] = d[node + 1] - (a[(node + 1)] * d[node]);
        }
        newTemps[numNodes] = Divide(d[numNodes], b[numNodes], 0.0d);
        for (node=numNodes - 1 ; node!=SURFACEnode - 1 ; node+=-1)
        {
            newTemps[node] = d[node] - (c[node] * newTemps[(node + 1)]);
        }
        return newTemps;
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
    public doUpdate Calculate_doUpdate (Double [] tempNew, Double [] soilTemp, Double [] minSoilTemp, Double [] maxSoilTemp, Double [] aveSoilTemp, Double [] thermalConductivity, double boundaryLayerConductance, Integer IterationsPerDay, double timeOfDaySecs, double gDt, Integer numNodes)
    {
        Integer SURFACEnode = 1;
        Integer AIRnode = 0;
        Integer node = 1;
        for (node=0 ; node!=tempNew.length ; node+=1)
        {
            soilTemp[node] = tempNew[node];
        }
        if (timeOfDaySecs < (gDt * 1.2d))
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
            aveSoilTemp[node] = aveSoilTemp[node] + Divide(soilTemp[node], (double)(IterationsPerDay), 0.0d);
        }
        boundaryLayerConductance = boundaryLayerConductance + Divide(thermalConductivity[AIRnode], (double)(IterationsPerDay), 0.0d);
        return new doUpdate(soilTemp, boundaryLayerConductance);
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
    public doThermalConductivityCoeffs Calculate_doThermalConductivityCoeffs (Integer nbLayers, Integer numNodes, Double [] BDApsim, Double [] CLAYApsim)
    {
        Double[] thermalCondPar1 ;
        Double[] thermalCondPar2 ;
        Double[] thermalCondPar3 ;
        Double[] thermalCondPar4 ;
        Integer layer;
        Integer element;
        thermalCondPar1.fill(numNodes + 1, 0.0d);thermalCondPar2.fill(numNodes + 1, 0.0d);thermalCondPar3.fill(numNodes + 1, 0.0d);thermalCondPar4.fill(numNodes + 1, 0.0d);
        for (layer=1 ; layer!=nbLayers + 2 ; layer+=1)
        {
            element = layer;
            thermalCondPar1[element] = 0.65d - (0.78d * BDApsim[layer]) + (0.6d * Math.pow(BDApsim[layer], 2));
            thermalCondPar2[element] = 1.06d * BDApsim[layer];
            thermalCondPar3[element] = Divide(2.6d, Math.sqrt(CLAYApsim[layer]), 0.0d);
            thermalCondPar3[element] = 1.0d + thermalCondPar3[element];
            thermalCondPar4[element] = 0.03d + (0.1d * Math.pow(BDApsim[layer], 2));
        }
        return new doThermalConductivityCoeffs(thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4);
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
    public static Double [] CalcSoilTemp(Double [] THICKApsim, double tav, double tamp, Integer doy, double latitude, Integer numNodes)
    {
        Double[] cumulativeDepth ;
        Double[] soilTempIO ;
        Double[] soilTemperat ;
        Integer Layer;
        Integer nodes;
        double tempValue;
        double w;
        double dh;
        double zd;
        double offset;
        Integer SURFACEnode = 1;
        double piVal = 3.141592653589793;
        cumulativeDepth.fill(THICKApsim.length, 0.0d);
        if (THICKApsim.length > 0)
        {
            cumulativeDepth[0] = THICKApsim[0];
            for (Layer=1 ; Layer!=THICKApsim.length ; Layer+=1)
            {
                cumulativeDepth[Layer] = THICKApsim[Layer] + cumulativeDepth[Layer - 1];
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
        }soilTemperat.fill(numNodes + 2, 0.0d);soilTempIO.fill(numNodes + 1 + 1, 0.0d);
        for (nodes=1 ; nodes!=numNodes + 1 ; nodes+=1)
        {
            soilTemperat[nodes] = tav + (tamp * Math.exp(-1.0d * cumulativeDepth[nodes] / zd) * Math.sin(((doy / 365.0d + offset) * 2.0d * piVal - (cumulativeDepth[nodes] / zd))));
        }
        for (Layer=SURFACEnode ; Layer!=numNodes + 1 ; Layer+=1)
        {
            soilTempIO[Layer] = soilTemperat[Layer - 1];
        }
        return soilTempIO;
    }
}
final class doNetRadiation {
    private Double [] solarRadn;
    public Double [] getsolarRadn()
    { return solarRadn; }

    public void setsolarRadn(Double [] _solarRadn)
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
    
    public doNetRadiation(Double [] solarRadn,double cloudFr,double cva)
    {
        this.solarRadn = solarRadn;
        this.cloudFr = cloudFr;
        this.cva = cva;
    }
}final class doUpdate {
    private Double [] soilTemp;
    public Double [] getsoilTemp()
    { return soilTemp; }

    public void setsoilTemp(Double [] _soilTemp)
    { this.soilTemp= _soilTemp; } 
    
    private double boundaryLayerConductance;
    public double getboundaryLayerConductance()
    { return boundaryLayerConductance; }

    public void setboundaryLayerConductance(double _boundaryLayerConductance)
    { this.boundaryLayerConductance= _boundaryLayerConductance; } 
    
    public doUpdate(Double [] soilTemp,double boundaryLayerConductance)
    {
        this.soilTemp = soilTemp;
        this.boundaryLayerConductance = boundaryLayerConductance;
    }
}final class doThermalConductivityCoeffs {
    private Double [] thermalCondPar1;
    public Double [] getthermalCondPar1()
    { return thermalCondPar1; }

    public void setthermalCondPar1(Double [] _thermalCondPar1)
    { this.thermalCondPar1= _thermalCondPar1; } 
    
    private Double [] thermalCondPar2;
    public Double [] getthermalCondPar2()
    { return thermalCondPar2; }

    public void setthermalCondPar2(Double [] _thermalCondPar2)
    { this.thermalCondPar2= _thermalCondPar2; } 
    
    private Double [] thermalCondPar3;
    public Double [] getthermalCondPar3()
    { return thermalCondPar3; }

    public void setthermalCondPar3(Double [] _thermalCondPar3)
    { this.thermalCondPar3= _thermalCondPar3; } 
    
    private Double [] thermalCondPar4;
    public Double [] getthermalCondPar4()
    { return thermalCondPar4; }

    public void setthermalCondPar4(Double [] _thermalCondPar4)
    { this.thermalCondPar4= _thermalCondPar4; } 
    
    public doThermalConductivityCoeffs(Double [] thermalCondPar1,Double [] thermalCondPar2,Double [] thermalCondPar3,Double [] thermalCondPar4)
    {
        this.thermalCondPar1 = thermalCondPar1;
        this.thermalCondPar2 = thermalCondPar2;
        this.thermalCondPar3 = thermalCondPar3;
        this.thermalCondPar4 = thermalCondPar4;
    }
}