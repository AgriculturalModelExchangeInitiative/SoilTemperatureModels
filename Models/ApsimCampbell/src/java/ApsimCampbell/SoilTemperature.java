import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class SoilTemperature
{
    public void Init(SoiltempState s, SoiltempState s1, SoiltempRate r, SoiltempAuxiliary a,  SoiltempExogenous ex)
    {
        getProfileVariables zz_getProfileVariables;
        readParam zz_readParam;
        double weather_MinT = ex.getweather_MinT();
        double weather_MaxT = ex.getweather_MaxT();
        double weather_MeanT = ex.getweather_MeanT();
        double weather_Tav = ex.getweather_Tav();
        double weather_Amp = ex.getweather_Amp();
        double weather_AirPressure = ex.getweather_AirPressure();
        double weather_Wind = ex.getweather_Wind();
        double weather_Radn = ex.getweather_Radn();
        Integer clock_Today_DayOfYear = ex.getclock_Today_DayOfYear();
        double microClimate_CanopyHeight = ex.getmicroClimate_CanopyHeight();
        Double [] physical_Rocks = ex.getphysical_Rocks();
        Double [] physical_ParticleSizeSand = ex.getphysical_ParticleSizeSand();
        Double [] physical_ParticleSizeSilt = ex.getphysical_ParticleSizeSilt();
        Double [] physical_ParticleSizeClay = ex.getphysical_ParticleSizeClay();
        Double [] organic_Carbon = ex.getorganic_Carbon();
        Double [] waterBalance_SW = ex.getwaterBalance_SW();
        double waterBalance_Eos = ex.getwaterBalance_Eos();
        double waterBalance_Eo = ex.getwaterBalance_Eo();
        double waterBalance_Es = ex.getwaterBalance_Es();
        double waterBalance_Salb = ex.getwaterBalance_Salb();
        Double[] InitialValues = null ;
        Boolean doInitialisationStuff = false;
        double internalTimeStep = 0.0;
        double timeOfDaySecs = 0.0;
        Integer numNodes = 0;
        Integer numLayers = 0;
        Double[] volSpecHeatSoil = null ;
        Double[] soilTemp = null ;
        Double[] morningSoilTemp = null ;
        Double[] heatStorage = null ;
        Double[] thermalConductance = null ;
        Double[] thermalConductivity = null ;
        double boundaryLayerConductance = 0.0;
        Double[] newTemperature = null ;
        double airTemperature = 0.0;
        double maxTempYesterday = 0.0;
        double minTempYesterday = 0.0;
        Double[] soilWater = null ;
        Double[] minSoilTemp = null ;
        Double[] maxSoilTemp = null ;
        Double[] aveSoilTemp = null ;
        Double[] aveSoilWater = null ;
        Double[] thickness = null ;
        Double[] bulkDensity = null ;
        Double[] rocks = null ;
        Double[] carbon = null ;
        Double[] sand = null ;
        Double[] silt = null ;
        Double[] clay = null ;
        double instrumentHeight = 0.0;
        double netRadiation = 0.0;
        double canopyHeight = 0.0;
        double instrumHeight = 0.0;
        doInitialisationStuff = true;
        instrumentHeight = getIniVariables(instrumentHeight, instrumHeight, defaultInstrumentHeight);
        zz_getProfileVariables = Calculate_getProfileVariables(heatStorage, minSoilTemp, bulkDensity, numNodes, physical_BD, maxSoilTemp, waterBalance_SW, organic_Carbon, physical_Rocks, nodeDepth, topsoilNode, newTemperature, surfaceNode, soilWater, thermalConductance, thermalConductivity, sand, carbon, thickness, numPhantomNodes, physical_ParticleSizeSand, rocks, clay, physical_ParticleSizeSilt, airNode, physical_ParticleSizeClay, soilTemp, numLayers, physical_Thickness, silt, volSpecHeatSoil, aveSoilTemp, morningSoilTemp, DepthToConstantTemperature, MissingValue);
        heatStorage = zz_getProfileVariables.getheatStorage();
        minSoilTemp = zz_getProfileVariables.getminSoilTemp();
        bulkDensity = zz_getProfileVariables.getbulkDensity();
        maxSoilTemp = zz_getProfileVariables.getmaxSoilTemp();
        nodeDepth = zz_getProfileVariables.getnodeDepth();
        newTemperature = zz_getProfileVariables.getnewTemperature();
        soilWater = zz_getProfileVariables.getsoilWater();
        thermalConductance = zz_getProfileVariables.getthermalConductance();
        thermalConductivity = zz_getProfileVariables.getthermalConductivity();
        sand = zz_getProfileVariables.getsand();
        carbon = zz_getProfileVariables.getcarbon();
        thickness = zz_getProfileVariables.getthickness();
        rocks = zz_getProfileVariables.getrocks();
        clay = zz_getProfileVariables.getclay();
        soilTemp = zz_getProfileVariables.getsoilTemp();
        silt = zz_getProfileVariables.getsilt();
        volSpecHeatSoil = zz_getProfileVariables.getvolSpecHeatSoil();
        aveSoilTemp = zz_getProfileVariables.getaveSoilTemp();
        morningSoilTemp = zz_getProfileVariables.getmorningSoilTemp();
        numNodes = zz_getProfileVariables.getnumNodes();
        numLayers = zz_getProfileVariables.getnumLayers();
        zz_readParam = Calculate_readParam(bareSoilRoughness, newTemperature, soilRoughnessHeight, soilTemp, thermCondPar2, numLayers, bulkDensity, numNodes, thermCondPar3, thermCondPar4, clay, thermCondPar1, weather_Tav, clock_Today_DayOfYear, surfaceNode, weather_Amp, thickness, weather_Latitude);
        newTemperature = zz_readParam.getnewTemperature();
        soilTemp = zz_readParam.getsoilTemp();
        thermCondPar2 = zz_readParam.getthermCondPar2();
        thermCondPar3 = zz_readParam.getthermCondPar3();
        thermCondPar4 = zz_readParam.getthermCondPar4();
        thermCondPar1 = zz_readParam.getthermCondPar1();
        soilRoughnessHeight = zz_readParam.getsoilRoughnessHeight();
        InitialValues = pInitialValues;
        s.setInitialValues(InitialValues);
        s.setdoInitialisationStuff(doInitialisationStuff);
        s.setinternalTimeStep(internalTimeStep);
        s.settimeOfDaySecs(timeOfDaySecs);
        s.setnumNodes(numNodes);
        s.setnumLayers(numLayers);
        s.setvolSpecHeatSoil(volSpecHeatSoil);
        s.setsoilTemp(soilTemp);
        s.setmorningSoilTemp(morningSoilTemp);
        s.setheatStorage(heatStorage);
        s.setthermalConductance(thermalConductance);
        s.setthermalConductivity(thermalConductivity);
        s.setboundaryLayerConductance(boundaryLayerConductance);
        s.setnewTemperature(newTemperature);
        s.setairTemperature(airTemperature);
        s.setmaxTempYesterday(maxTempYesterday);
        s.setminTempYesterday(minTempYesterday);
        s.setsoilWater(soilWater);
        s.setminSoilTemp(minSoilTemp);
        s.setmaxSoilTemp(maxSoilTemp);
        s.setaveSoilTemp(aveSoilTemp);
        s.setaveSoilWater(aveSoilWater);
        s.setthickness(thickness);
        s.setbulkDensity(bulkDensity);
        s.setrocks(rocks);
        s.setcarbon(carbon);
        s.setsand(sand);
        s.setsilt(silt);
        s.setclay(clay);
        s.setinstrumentHeight(instrumentHeight);
        s.setnetRadiation(netRadiation);
        s.setcanopyHeight(canopyHeight);
        s.setinstrumHeight(instrumHeight);
    }
    private double weather_Latitude;
    public double getweather_Latitude()
    { return weather_Latitude; }

    public void setweather_Latitude(double _weather_Latitude)
    { this.weather_Latitude= _weather_Latitude; } 
    
    private Double [] physical_Thickness;
    public Double [] getphysical_Thickness()
    { return physical_Thickness; }

    public void setphysical_Thickness(Double [] _physical_Thickness)
    { this.physical_Thickness= _physical_Thickness; } 
    
    private Double [] physical_BD;
    public Double [] getphysical_BD()
    { return physical_BD; }

    public void setphysical_BD(Double [] _physical_BD)
    { this.physical_BD= _physical_BD; } 
    
    private double ps;
    public double getps()
    { return ps; }

    public void setps(double _ps)
    { this.ps= _ps; } 
    
    private Double [] pInitialValues;
    public Double [] getpInitialValues()
    { return pInitialValues; }

    public void setpInitialValues(Double [] _pInitialValues)
    { this.pInitialValues= _pInitialValues; } 
    
    private double DepthToConstantTemperature;
    public double getDepthToConstantTemperature()
    { return DepthToConstantTemperature; }

    public void setDepthToConstantTemperature(double _DepthToConstantTemperature)
    { this.DepthToConstantTemperature= _DepthToConstantTemperature; } 
    
    private double timestep;
    public double gettimestep()
    { return timestep; }

    public void settimestep(double _timestep)
    { this.timestep= _timestep; } 
    
    private double latentHeatOfVapourisation;
    public double getlatentHeatOfVapourisation()
    { return latentHeatOfVapourisation; }

    public void setlatentHeatOfVapourisation(double _latentHeatOfVapourisation)
    { this.latentHeatOfVapourisation= _latentHeatOfVapourisation; } 
    
    private double stefanBoltzmannConstant;
    public double getstefanBoltzmannConstant()
    { return stefanBoltzmannConstant; }

    public void setstefanBoltzmannConstant(double _stefanBoltzmannConstant)
    { this.stefanBoltzmannConstant= _stefanBoltzmannConstant; } 
    
    private Integer airNode;
    public Integer getairNode()
    { return airNode; }

    public void setairNode(Integer _airNode)
    { this.airNode= _airNode; } 
    
    private Integer surfaceNode;
    public Integer getsurfaceNode()
    { return surfaceNode; }

    public void setsurfaceNode(Integer _surfaceNode)
    { this.surfaceNode= _surfaceNode; } 
    
    private Integer topsoilNode;
    public Integer gettopsoilNode()
    { return topsoilNode; }

    public void settopsoilNode(Integer _topsoilNode)
    { this.topsoilNode= _topsoilNode; } 
    
    private Integer numPhantomNodes;
    public Integer getnumPhantomNodes()
    { return numPhantomNodes; }

    public void setnumPhantomNodes(Integer _numPhantomNodes)
    { this.numPhantomNodes= _numPhantomNodes; } 
    
    private double constantBoundaryLayerConductance;
    public double getconstantBoundaryLayerConductance()
    { return constantBoundaryLayerConductance; }

    public void setconstantBoundaryLayerConductance(double _constantBoundaryLayerConductance)
    { this.constantBoundaryLayerConductance= _constantBoundaryLayerConductance; } 
    
    private Integer numIterationsForBoundaryLayerConductance;
    public Integer getnumIterationsForBoundaryLayerConductance()
    { return numIterationsForBoundaryLayerConductance; }

    public void setnumIterationsForBoundaryLayerConductance(Integer _numIterationsForBoundaryLayerConductance)
    { this.numIterationsForBoundaryLayerConductance= _numIterationsForBoundaryLayerConductance; } 
    
    private double defaultTimeOfMaximumTemperature;
    public double getdefaultTimeOfMaximumTemperature()
    { return defaultTimeOfMaximumTemperature; }

    public void setdefaultTimeOfMaximumTemperature(double _defaultTimeOfMaximumTemperature)
    { this.defaultTimeOfMaximumTemperature= _defaultTimeOfMaximumTemperature; } 
    
    private double defaultInstrumentHeight;
    public double getdefaultInstrumentHeight()
    { return defaultInstrumentHeight; }

    public void setdefaultInstrumentHeight(double _defaultInstrumentHeight)
    { this.defaultInstrumentHeight= _defaultInstrumentHeight; } 
    
    private double bareSoilRoughness;
    public double getbareSoilRoughness()
    { return bareSoilRoughness; }

    public void setbareSoilRoughness(double _bareSoilRoughness)
    { this.bareSoilRoughness= _bareSoilRoughness; } 
    
    private Double [] nodeDepth;
    public Double [] getnodeDepth()
    { return nodeDepth; }

    public void setnodeDepth(Double [] _nodeDepth)
    { this.nodeDepth= _nodeDepth; } 
    
    private Double [] thermCondPar1;
    public Double [] getthermCondPar1()
    { return thermCondPar1; }

    public void setthermCondPar1(Double [] _thermCondPar1)
    { this.thermCondPar1= _thermCondPar1; } 
    
    private Double [] thermCondPar2;
    public Double [] getthermCondPar2()
    { return thermCondPar2; }

    public void setthermCondPar2(Double [] _thermCondPar2)
    { this.thermCondPar2= _thermCondPar2; } 
    
    private Double [] thermCondPar3;
    public Double [] getthermCondPar3()
    { return thermCondPar3; }

    public void setthermCondPar3(Double [] _thermCondPar3)
    { this.thermCondPar3= _thermCondPar3; } 
    
    private Double [] thermCondPar4;
    public Double [] getthermCondPar4()
    { return thermCondPar4; }

    public void setthermCondPar4(Double [] _thermCondPar4)
    { this.thermCondPar4= _thermCondPar4; } 
    
    private double pom;
    public double getpom()
    { return pom; }

    public void setpom(double _pom)
    { this.pom= _pom; } 
    
    private double soilRoughnessHeight;
    public double getsoilRoughnessHeight()
    { return soilRoughnessHeight; }

    public void setsoilRoughnessHeight(double _soilRoughnessHeight)
    { this.soilRoughnessHeight= _soilRoughnessHeight; } 
    
    private double nu;
    public double getnu()
    { return nu; }

    public void setnu(double _nu)
    { this.nu= _nu; } 
    
    private String boundarLayerConductanceSource;
    public String getboundarLayerConductanceSource()
    { return boundarLayerConductanceSource; }

    public void setboundarLayerConductanceSource(String _boundarLayerConductanceSource)
    { this.boundarLayerConductanceSource= _boundarLayerConductanceSource; } 
    
    private String netRadiationSource;
    public String getnetRadiationSource()
    { return netRadiationSource; }

    public void setnetRadiationSource(String _netRadiationSource)
    { this.netRadiationSource= _netRadiationSource; } 
    
    private double MissingValue;
    public double getMissingValue()
    { return MissingValue; }

    public void setMissingValue(double _MissingValue)
    { this.MissingValue= _MissingValue; } 
    
    private String [] soilConstituentNames;
    public String [] getsoilConstituentNames()
    { return soilConstituentNames; }

    public void setsoilConstituentNames(String [] _soilConstituentNames)
    { this.soilConstituentNames= _soilConstituentNames; } 
    
    public SoilTemperature() { }
    public void  Calculate_Model(SoiltempState s, SoiltempState s1, SoiltempRate r, SoiltempAuxiliary a,  SoiltempExogenous ex)
    {
        //- Name: SoilTemperature -Version:  1.0, -Time step:  1
        //- Description:
    //            * Title: SoilTemperature
    //            * Authors: APSIM
    //            * Reference: None
    //            * Institution: APSIM Initiative
    //            * ExtendedDescription:  Soil Temperature 
    //            * ShortDescription: Heat flux and temperatures over the surface and soil profile (based on Campbell, 1985)
        //- inputs:
    //            * name: weather_MinT
    //                          ** description : Minimum temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: weather_MaxT
    //                          ** description : Maximum temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: weather_MeanT
    //                          ** description : Mean temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: weather_Tav
    //                          ** description : Annual average temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: weather_Amp
    //                          ** description : Annual average temperature amplitude
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: weather_AirPressure
    //                          ** description : Air pressure
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : hPa
    //            * name: weather_Wind
    //                          ** description : Wind speed
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : m/s
    //            * name: weather_Latitude
    //                          ** description : Latitude
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : deg
    //            * name: weather_Radn
    //                          ** description : Solar radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : MJ/m2/day
    //            * name: clock_Today_DayOfYear
    //                          ** description : Day of year
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : day number
    //            * name: microClimate_CanopyHeight
    //                          ** description : Canopy height
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: physical_Thickness
    //                          ** description : Soil layer thickness
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: physical_BD
    //                          ** description : Bulk density
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : g/cc
    //            * name: ps
    //                          ** description : ps
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: physical_Rocks
    //                          ** description : Rocks
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: physical_ParticleSizeSand
    //                          ** description : Particle size sand
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: physical_ParticleSizeSilt
    //                          ** description : Particle size silt
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: physical_ParticleSizeClay
    //                          ** description : Particle size clay
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: organic_Carbon
    //                          ** description : Total organic carbon
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: waterBalance_SW
    //                          ** description : Volumetric water content
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm/mm
    //            * name: waterBalance_Eos
    //                          ** description : Potential soil evaporation from soil surface
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: waterBalance_Eo
    //                          ** description : Potential soil evapotranspiration from soil surface
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: waterBalance_Es
    //                          ** description : Actual (realised) soil water evaporation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: waterBalance_Salb
    //                          ** description : Fraction of incoming radiation reflected from bare soil
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 0-1
    //            * name: InitialValues
    //                          ** description : Initial soil temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: pInitialValues
    //                          ** description : Initial soil temperature
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: DepthToConstantTemperature
    //                          ** description : Soil depth to constant temperature
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 10000
    //                          ** unit : mm
    //            * name: timestep
    //                          ** description : Internal time-step (minutes)
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 24.0 * 60.0 * 60.0
    //                          ** unit : minutes
    //            * name: latentHeatOfVapourisation
    //                          ** description : Latent heat of vapourisation for water
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 2465000
    //                          ** unit : miJ/kg
    //            * name: stefanBoltzmannConstant
    //                          ** description : The Stefan-Boltzmann constant
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0000000567
    //                          ** unit : W/m2/K4
    //            * name: airNode
    //                          ** description : The index of the node in the atmosphere (aboveground)
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : 
    //            * name: surfaceNode
    //                          ** description : The index of the node on the soil surface (depth = 0)
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 1
    //                          ** unit : 
    //            * name: topsoilNode
    //                          ** description : The index of the first node within the soil (top layer)
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 2
    //                          ** unit : 
    //            * name: numPhantomNodes
    //                          ** description : The number of phantom nodes below the soil profile
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 5
    //                          ** unit : 
    //            * name: constantBoundaryLayerConductance
    //                          ** description : Boundary layer conductance, if constant
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 20
    //                          ** unit : K/W
    //            * name: numIterationsForBoundaryLayerConductance
    //                          ** description : Number of iterations to calculate atmosphere boundary layer conductance
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** min : 
    //                          ** default : 1
    //                          ** unit : 
    //            * name: defaultTimeOfMaximumTemperature
    //                          ** description : Time of maximum temperature
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 14.0
    //                          ** unit : minutes
    //            * name: defaultInstrumentHeight
    //                          ** description : Default instrument height
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 1.2
    //                          ** unit : m
    //            * name: bareSoilRoughness
    //                          ** description : Roughness element height of bare soil
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 57
    //                          ** unit : mm
    //            * name: doInitialisationStuff
    //                          ** description : Flag whether initialisation is needed
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : BOOLEAN
    //                          ** max : 
    //                          ** min : 
    //                          ** default : false
    //                          ** unit : mintes
    //            * name: internalTimeStep
    //                          ** description : Internal time-step
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : sec
    //            * name: timeOfDaySecs
    //                          ** description : Time of day from midnight
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : sec
    //            * name: numNodes
    //                          ** description : Number of nodes over the soil profile
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : 
    //            * name: numLayers
    //                          ** description : Number of layers in the soil profile
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : 
    //            * name: nodeDepth
    //                          ** description : Depths of nodes
    //                          ** inputtype : parameter
    //                          ** parametercategory : private
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: thermCondPar1
    //                          ** description : Parameter 1 for computing thermal conductivity of soil solids
    //                          ** inputtype : parameter
    //                          ** parametercategory : private
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: thermCondPar2
    //                          ** description : Parameter 2 for computing thermal conductivity of soil solids
    //                          ** inputtype : parameter
    //                          ** parametercategory : private
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: thermCondPar3
    //                          ** description : Parameter 3 for computing thermal conductivity of soil solids
    //                          ** inputtype : parameter
    //                          ** parametercategory : private
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: thermCondPar4
    //                          ** description : Parameter 4 for computing thermal conductivity of soil solids
    //                          ** inputtype : parameter
    //                          ** parametercategory : private
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: volSpecHeatSoil
    //                          ** description : Volumetric specific heat over the soil profile
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : J/K/m3
    //            * name: soilTemp
    //                          ** description : Soil temperature over the soil profile at morning
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: morningSoilTemp
    //                          ** description : Soil temperature over the soil profile at morning
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: heatStorage
    //                          ** description : CP, heat storage between nodes
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : J/K
    //            * name: thermalConductance
    //                          ** description : K, conductance of element between nodes
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : W/K
    //            * name: thermalConductivity
    //                          ** description : Thermal conductivity
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : W.m/K
    //            * name: boundaryLayerConductance
    //                          ** description : Average daily atmosphere boundary layer conductance
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : 
    //            * name: newTemperature
    //                          ** description : Soil temperature at the end of this iteration
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: airTemperature
    //                          ** description : Air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : oC
    //            * name: maxTempYesterday
    //                          ** description : Yesterday's maximum daily air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : oC
    //            * name: minTempYesterday
    //                          ** description : Yesterday's minimum daily air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : oC
    //            * name: soilWater
    //                          ** description : Volumetric water content of each soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm3/mm3
    //            * name: minSoilTemp
    //                          ** description : Minimum soil temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: maxSoilTemp
    //                          ** description : Maximum soil temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: aveSoilTemp
    //                          ** description : average soil temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: aveSoilWater
    //                          ** description : Average soil temperaturer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: thickness
    //                          ** description : Thickness of each soil, includes phantom layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: bulkDensity
    //                          ** description : Soil bulk density, includes phantom layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : g/cm3
    //            * name: rocks
    //                          ** description : Volumetric fraction of rocks in each soil laye
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: carbon
    //                          ** description : Volumetric fraction of carbon (CHECK, OM?) in each soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: sand
    //                          ** description : Volumetric fraction of sand in each soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: pom
    //                          ** description : Particle density of organic matter
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : Mg/m3
    //            * name: silt
    //                          ** description : Volumetric fraction of silt in each soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: clay
    //                          ** description : Volumetric fraction of clay in each soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: soilRoughnessHeight
    //                          ** description : Height of soil roughness
    //                          ** inputtype : parameter
    //                          ** parametercategory : private
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : mm
    //            * name: instrumentHeight
    //                          ** description : Height of instruments above soil surface
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : mm
    //            * name: netRadiation
    //                          ** description : Net radiation per internal time-step
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : MJ
    //            * name: canopyHeight
    //                          ** description : Height of canopy above ground
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : mm
    //            * name: instrumHeight
    //                          ** description : Height of instruments above ground
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : mm
    //            * name: nu
    //                          ** description : Forward/backward differencing coefficient
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.6
    //                          ** unit : 0-1
    //            * name: boundarLayerConductanceSource
    //                          ** description : Flag whether boundary layer conductance is calculated or gotten from inpu
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : STRING
    //                          ** max : 
    //                          ** min : 
    //                          ** default : calc
    //                          ** unit : 
    //            * name: netRadiationSource
    //                          ** description : Flag whether net radiation is calculated or gotten from input
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : STRING
    //                          ** max : 
    //                          ** min : 
    //                          ** default : calc
    //                          ** unit : m
    //            * name: MissingValue
    //                          ** description : missing value
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 99999
    //                          ** unit : m
    //            * name: soilConstituentNames
    //                          ** description : soilConstituentNames
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : STRINGARRAY
    //                          ** len : 8
    //                          ** max : 
    //                          ** min : 
    //                          ** default : ["Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"]
    //                          ** unit : m
        //- outputs:
    //            * name: heatStorage
    //                          ** description : CP, heat storage between nodes
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : J/K
    //            * name: instrumentHeight
    //                          ** description : Height of instruments above soil surface
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : mm
    //            * name: canopyHeight
    //                          ** description : Height of canopy above ground
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : mm
    //            * name: minSoilTemp
    //                          ** description : Minimum soil temperature
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    //            * name: maxSoilTemp
    //                          ** description : Maximum soil temperature
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    //            * name: aveSoilTemp
    //                          ** description : average soil temperature
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    //            * name: volSpecHeatSoil
    //                          ** description : Volumetric specific heat over the soil profile
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : J/K/m3
    //            * name: soilTemp
    //                          ** description : Soil temperature over the soil profile at morning
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    //            * name: morningSoilTemp
    //                          ** description : Soil temperature over the soil profile at morning
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    //            * name: newTemperature
    //                          ** description : Soil temperature at the end of this iteration
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    //            * name: thermalConductivity
    //                          ** description : Thermal conductivity
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : W.m/K
    //            * name: thermalConductance
    //                          ** description : K, conductance of element between nodes
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : W/K
    //            * name: boundaryLayerConductance
    //                          ** description : Average daily atmosphere boundary layer conductance
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : 
    //            * name: soilWater
    //                          ** description : Volumetric water content of each soil layer
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : mm3/mm3
    //            * name: doInitialisationStuff
    //                          ** description : Flag whether initialisation is needed
    //                          ** variablecategory : state
    //                          ** datatype : BOOLEAN
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : 
    //            * name: maxTempYesterday
    //                          ** description : Yesterday's maximum daily air temperature (oC)
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    //            * name: minTempYesterday
    //                          ** description : Yesterday's minimum daily air temperature (oC)
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 
    //                          ** unit : oC
    //                          ** min : 
    //            * name: airTemperature
    //                          ** description : Air temperature
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    //            * name: internalTimeStep
    //                          ** description : Internal time-step
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : sec
    //            * name: timeOfDaySecs
    //                          ** description : Time of day from midnight
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : sec
    //            * name: netRadiation
    //                          ** description : Net radiation per internal time-step
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : MJ
    //            * name: InitialValues
    //                          ** description : Initial soil temperature
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
        getOtherVariables zz_getOtherVariables;
        doProcess zz_doProcess;
        double weather_MinT = ex.getweather_MinT();
        double weather_MaxT = ex.getweather_MaxT();
        double weather_MeanT = ex.getweather_MeanT();
        double weather_Tav = ex.getweather_Tav();
        double weather_Amp = ex.getweather_Amp();
        double weather_AirPressure = ex.getweather_AirPressure();
        double weather_Wind = ex.getweather_Wind();
        double weather_Radn = ex.getweather_Radn();
        Integer clock_Today_DayOfYear = ex.getclock_Today_DayOfYear();
        double microClimate_CanopyHeight = ex.getmicroClimate_CanopyHeight();
        Double [] physical_Rocks = ex.getphysical_Rocks();
        Double [] physical_ParticleSizeSand = ex.getphysical_ParticleSizeSand();
        Double [] physical_ParticleSizeSilt = ex.getphysical_ParticleSizeSilt();
        Double [] physical_ParticleSizeClay = ex.getphysical_ParticleSizeClay();
        Double [] organic_Carbon = ex.getorganic_Carbon();
        Double [] waterBalance_SW = ex.getwaterBalance_SW();
        double waterBalance_Eos = ex.getwaterBalance_Eos();
        double waterBalance_Eo = ex.getwaterBalance_Eo();
        double waterBalance_Es = ex.getwaterBalance_Es();
        double waterBalance_Salb = ex.getwaterBalance_Salb();
        Double [] InitialValues = s.getInitialValues();
        Boolean doInitialisationStuff = s.getdoInitialisationStuff();
        double internalTimeStep = s.getinternalTimeStep();
        double timeOfDaySecs = s.gettimeOfDaySecs();
        Integer numNodes = s.getnumNodes();
        Integer numLayers = s.getnumLayers();
        Double [] volSpecHeatSoil = s.getvolSpecHeatSoil();
        Double [] soilTemp = s.getsoilTemp();
        Double [] morningSoilTemp = s.getmorningSoilTemp();
        Double [] heatStorage = s.getheatStorage();
        Double [] thermalConductance = s.getthermalConductance();
        Double [] thermalConductivity = s.getthermalConductivity();
        double boundaryLayerConductance = s.getboundaryLayerConductance();
        Double [] newTemperature = s.getnewTemperature();
        double airTemperature = s.getairTemperature();
        double maxTempYesterday = s.getmaxTempYesterday();
        double minTempYesterday = s.getminTempYesterday();
        Double [] soilWater = s.getsoilWater();
        Double [] minSoilTemp = s.getminSoilTemp();
        Double [] maxSoilTemp = s.getmaxSoilTemp();
        Double [] aveSoilTemp = s.getaveSoilTemp();
        Double [] aveSoilWater = s.getaveSoilWater();
        Double [] thickness = s.getthickness();
        Double [] bulkDensity = s.getbulkDensity();
        Double [] rocks = s.getrocks();
        Double [] carbon = s.getcarbon();
        Double [] sand = s.getsand();
        Double [] silt = s.getsilt();
        Double [] clay = s.getclay();
        double instrumentHeight = s.getinstrumentHeight();
        double netRadiation = s.getnetRadiation();
        double canopyHeight = s.getcanopyHeight();
        double instrumHeight = s.getinstrumHeight();
        Integer i;
        zz_getOtherVariables = Calculate_getOtherVariables(numLayers, numNodes, soilWater, instrumentHeight, soilRoughnessHeight, waterBalance_SW, microClimate_CanopyHeight, canopyHeight);
        soilWater = zz_getOtherVariables.getsoilWater();
        instrumentHeight = zz_getOtherVariables.getinstrumentHeight();
        canopyHeight = zz_getOtherVariables.getcanopyHeight();
        if (doInitialisationStuff)
        {
            if (ValuesInArray(InitialValues, MissingValue))
            {
                soilTemp= new Double[numNodes + 1 + 1];
                Arrays.fill(soilTemp, 0.0d);
                 System.arraycopy(InitialValues, 0, soilTemp, topsoilNode, InitialValues.length);
            }
            else
            {
                soilTemp = calcSoilTemperature(soilTemp, weather_Tav, clock_Today_DayOfYear, surfaceNode, numNodes, weather_Amp, thickness, weather_Latitude);
                InitialValues= new Double[numLayers];
                Arrays.fill(InitialValues, 0.0d);
                 System.arraycopy(soilTemp, topsoilNode, InitialValues, 0, numLayers);
            }
            soilTemp[airNode] = weather_MeanT;
            soilTemp[surfaceNode] = calcSurfaceTemperature(weather_MeanT, weather_MaxT, waterBalance_Salb, weather_Radn);
            for (i=numNodes + 1 ; i!=soilTemp.length ; i+=1)
            {
                soilTemp[i] = weather_Tav;
            }
            System.arraycopy(soilTemp, 0, newTemperature, 0, soilTemp.length);
            maxTempYesterday = weather_MaxT;
            minTempYesterday = weather_MinT;
            doInitialisationStuff = false;
        }
        zz_doProcess = Calculate_doProcess(timeOfDaySecs, netRadiation, minSoilTemp, maxSoilTemp, numIterationsForBoundaryLayerConductance, timestep, boundaryLayerConductance, maxTempYesterday, airNode, soilTemp, airTemperature, newTemperature, weather_MaxT, internalTimeStep, boundarLayerConductanceSource, thermalConductivity, minTempYesterday, aveSoilTemp, morningSoilTemp, weather_MeanT, constantBoundaryLayerConductance, weather_MinT, clock_Today_DayOfYear, weather_Radn, weather_Latitude, soilConstituentNames, numNodes, volSpecHeatSoil, soilWater, nodeDepth, thickness, surfaceNode, MissingValue, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay, defaultTimeOfMaximumTemperature, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, stefanBoltzmannConstant, weather_AirPressure, weather_Wind, instrumentHeight, canopyHeight, heatStorage, netRadiationSource, latentHeatOfVapourisation, waterBalance_Es, thermalConductance, nu);
        minSoilTemp = zz_doProcess.getminSoilTemp();
        maxSoilTemp = zz_doProcess.getmaxSoilTemp();
        soilTemp = zz_doProcess.getsoilTemp();
        newTemperature = zz_doProcess.getnewTemperature();
        thermalConductivity = zz_doProcess.getthermalConductivity();
        aveSoilTemp = zz_doProcess.getaveSoilTemp();
        morningSoilTemp = zz_doProcess.getmorningSoilTemp();
        volSpecHeatSoil = zz_doProcess.getvolSpecHeatSoil();
        heatStorage = zz_doProcess.getheatStorage();
        thermalConductance = zz_doProcess.getthermalConductance();
        timeOfDaySecs = zz_doProcess.gettimeOfDaySecs();
        netRadiation = zz_doProcess.getnetRadiation();
        airTemperature = zz_doProcess.getairTemperature();
        internalTimeStep = zz_doProcess.getinternalTimeStep();
        minTempYesterday = zz_doProcess.getminTempYesterday();
        boundaryLayerConductance = zz_doProcess.getboundaryLayerConductance();
        maxTempYesterday = zz_doProcess.getmaxTempYesterday();
        s.setInitialValues(InitialValues);
        s.setdoInitialisationStuff(doInitialisationStuff);
        s.setinternalTimeStep(internalTimeStep);
        s.settimeOfDaySecs(timeOfDaySecs);
        s.setvolSpecHeatSoil(volSpecHeatSoil);
        s.setsoilTemp(soilTemp);
        s.setmorningSoilTemp(morningSoilTemp);
        s.setheatStorage(heatStorage);
        s.setthermalConductance(thermalConductance);
        s.setthermalConductivity(thermalConductivity);
        s.setboundaryLayerConductance(boundaryLayerConductance);
        s.setnewTemperature(newTemperature);
        s.setairTemperature(airTemperature);
        s.setmaxTempYesterday(maxTempYesterday);
        s.setminTempYesterday(minTempYesterday);
        s.setsoilWater(soilWater);
        s.setminSoilTemp(minSoilTemp);
        s.setmaxSoilTemp(maxSoilTemp);
        s.setaveSoilTemp(aveSoilTemp);
        s.setinstrumentHeight(instrumentHeight);
        s.setnetRadiation(netRadiation);
        s.setcanopyHeight(canopyHeight);
    }
    public static double getIniVariables(double instrumentHeight, double instrumHeight, double defaultInstrumentHeight)
    {
        if (instrumHeight > 0.00001d)
        {
            instrumentHeight = instrumHeight;
        }
        else
        {
            instrumentHeight = defaultInstrumentHeight;
        }
        return instrumentHeight;
    }
    public getProfileVariables Calculate_getProfileVariables (Double [] heatStorage, Double [] minSoilTemp, Double [] bulkDensity, Integer numNodes, Double [] physical_BD, Double [] maxSoilTemp, Double [] waterBalance_SW, Double [] organic_Carbon, Double [] physical_Rocks, Double [] nodeDepth, Integer topsoilNode, Double [] newTemperature, Integer surfaceNode, Double [] soilWater, Double [] thermalConductance, Double [] thermalConductivity, Double [] sand, Double [] carbon, Double [] thickness, Integer numPhantomNodes, Double [] physical_ParticleSizeSand, Double [] rocks, Double [] clay, Double [] physical_ParticleSizeSilt, Integer airNode, Double [] physical_ParticleSizeClay, Double [] soilTemp, Integer numLayers, Double [] physical_Thickness, Double [] silt, Double [] volSpecHeatSoil, Double [] aveSoilTemp, Double [] morningSoilTemp, double DepthToConstantTemperature, double MissingValue)
    {
        Integer layer;
        Integer node;
        Integer i;
        double belowProfileDepth;
        double thicknessForPhantomNodes;
        Integer firstPhantomNode;
        Double[] oldDepth = null ;
        Double[] oldBulkDensity = null ;
        Double[] oldSoilWater = null ;
        numLayers = physical_Thickness.length;
        numNodes = numLayers + numPhantomNodes;
        thickness= new Double[numLayers + numPhantomNodes + 1];
        Arrays.fill(thickness, 0.0d);
        System.arraycopy(physical_Thickness, 0, thickness, 1, physical_Thickness.length);
        belowProfileDepth = Math.max(DepthToConstantTemperature - Sum(thickness, 1, numLayers, MissingValue), 1000.0d);
        thicknessForPhantomNodes = belowProfileDepth * 2.0d / numPhantomNodes;
        firstPhantomNode = numLayers;
        for (i=firstPhantomNode ; i!=firstPhantomNode + numPhantomNodes ; i+=1)
        {
            thickness[i] = thicknessForPhantomNodes;
        }
        oldDepth = nodeDepth;
        nodeDepth= new Double[numNodes + 1 + 1];
        Arrays.fill(nodeDepth, 0.0d);
        if (oldDepth != null)
        {
             System.arraycopy(oldDepth, 0, nodeDepth, 0, Math.min(numNodes + 1 + 1, oldDepth.length));
        }
        nodeDepth[airNode] = 0.0d;
        nodeDepth[surfaceNode] = 0.0d;
        nodeDepth[topsoilNode] = 0.5d * thickness[1] / 1000.0d;
        for (node=topsoilNode ; node!=numNodes + 1 ; node+=1)
        {
            nodeDepth[node + 1] = (Sum(thickness, 1, node - 1, MissingValue) + (0.5d * thickness[node])) / 1000.0d;
        }
        oldBulkDensity = bulkDensity;
        bulkDensity= new Double[numLayers + 1 + numPhantomNodes];
        Arrays.fill(bulkDensity, 0.0d);
        if (oldBulkDensity != null)
        {
             System.arraycopy(oldBulkDensity, 0, bulkDensity, 0, Math.min(numLayers + 1 + numPhantomNodes, oldBulkDensity.length));
        }
        System.arraycopy(physical_BD, 0, bulkDensity, 1, physical_BD.length);
        bulkDensity[numNodes] = bulkDensity[numLayers];
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            bulkDensity[layer] = bulkDensity[numLayers];
        }
        oldSoilWater = soilWater;
        soilWater= new Double[numLayers + 1 + numPhantomNodes];
        Arrays.fill(soilWater, 0.0d);
        if (oldSoilWater != null)
        {
             System.arraycopy(oldSoilWater, 0, soilWater, 0, Math.min(numLayers + 1 + numPhantomNodes, oldSoilWater.length));
        }
        if (waterBalance_SW != null)
        {
            for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
            {
                soilWater[layer] = Divide(waterBalance_SW[(layer - 1)] * thickness[(layer - 1)], thickness[layer], (double)(0));
            }
            for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
            {
                soilWater[layer] = soilWater[numLayers];
            }
        }
        carbon= new Double[numLayers + 1 + numPhantomNodes];
        Arrays.fill(carbon, 0.0d);
        for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
        {
            carbon[layer] = organic_Carbon[layer - 1];
        }
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            carbon[layer] = carbon[numLayers];
        }
        rocks= new Double[numLayers + 1 + numPhantomNodes];
        Arrays.fill(rocks, 0.0d);
        for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
        {
            rocks[layer] = physical_Rocks[layer - 1];
        }
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            rocks[layer] = rocks[numLayers];
        }
        sand= new Double[numLayers + 1 + numPhantomNodes];
        Arrays.fill(sand, 0.0d);
        for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
        {
            sand[layer] = physical_ParticleSizeSand[layer - 1];
        }
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            sand[layer] = sand[numLayers];
        }
        silt= new Double[numLayers + 1 + numPhantomNodes];
        Arrays.fill(silt, 0.0d);
        for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
        {
            silt[layer] = physical_ParticleSizeSilt[layer - 1];
        }
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            silt[layer] = silt[numLayers];
        }
        clay= new Double[numLayers + 1 + numPhantomNodes];
        Arrays.fill(clay, 0.0d);
        for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
        {
            clay[layer] = physical_ParticleSizeClay[layer - 1];
        }
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            clay[layer] = clay[numLayers];
        }
        maxSoilTemp= new Double[numLayers + 1 + numPhantomNodes];
        Arrays.fill(maxSoilTemp, 0.0d);
        minSoilTemp= new Double[numLayers + 1 + numPhantomNodes];
        Arrays.fill(minSoilTemp, 0.0d);
        aveSoilTemp= new Double[numLayers + 1 + numPhantomNodes];
        Arrays.fill(aveSoilTemp, 0.0d);
        volSpecHeatSoil= new Double[numNodes + 1];
        Arrays.fill(volSpecHeatSoil, 0.0d);
        soilTemp= new Double[numNodes + 1 + 1];
        Arrays.fill(soilTemp, 0.0d);
        morningSoilTemp= new Double[numNodes + 1 + 1];
        Arrays.fill(morningSoilTemp, 0.0d);
        newTemperature= new Double[numNodes + 1 + 1];
        Arrays.fill(newTemperature, 0.0d);
        thermalConductivity= new Double[numNodes + 1];
        Arrays.fill(thermalConductivity, 0.0d);
        heatStorage= new Double[numNodes + 1];
        Arrays.fill(heatStorage, 0.0d);
        thermalConductance= new Double[numNodes + 1 + 1];
        Arrays.fill(thermalConductance, 0.0d);
        return new getProfileVariables(heatStorage, minSoilTemp, bulkDensity, maxSoilTemp, nodeDepth, newTemperature, soilWater, thermalConductance, thermalConductivity, sand, carbon, thickness, rocks, clay, soilTemp, silt, volSpecHeatSoil, aveSoilTemp, morningSoilTemp, numNodes, numLayers);
    }
    public doThermalConductivityCoeffs Calculate_doThermalConductivityCoeffs (Double [] thermCondPar2, Integer numLayers, Double [] bulkDensity, Integer numNodes, Double [] thermCondPar3, Double [] thermCondPar4, Double [] clay, Double [] thermCondPar1)
    {
        Integer layer;
        Double[] oldGC1 = null ;
        Double[] oldGC2 = null ;
        Double[] oldGC3 = null ;
        Double[] oldGC4 = null ;
        Integer element;
        oldGC1 = thermCondPar1;
        thermCondPar1= new Double[numNodes + 1];
        Arrays.fill(thermCondPar1, 0.0d);
        if (oldGC1 != null)
        {
             System.arraycopy(oldGC1, 0, thermCondPar1, 0, Math.min(numNodes + 1, oldGC1.length));
        }
        oldGC2 = thermCondPar2;
        thermCondPar2= new Double[numNodes + 1];
        Arrays.fill(thermCondPar2, 0.0d);
        if (oldGC2 != null)
        {
             System.arraycopy(oldGC2, 0, thermCondPar2, 0, Math.min(numNodes + 1, oldGC2.length));
        }
        oldGC3 = thermCondPar3;
        thermCondPar3= new Double[numNodes + 1];
        Arrays.fill(thermCondPar3, 0.0d);
        if (oldGC3 != null)
        {
             System.arraycopy(oldGC3, 0, thermCondPar3, 0, Math.min(numNodes + 1, oldGC3.length));
        }
        oldGC4 = thermCondPar4;
        thermCondPar4= new Double[numNodes + 1];
        Arrays.fill(thermCondPar4, 0.0d);
        if (oldGC4 != null)
        {
             System.arraycopy(oldGC4, 0, thermCondPar4, 0, Math.min(numNodes + 1, oldGC4.length));
        }
        for (layer=1 ; layer!=numLayers + 1 + 1 ; layer+=1)
        {
            element = layer;
            thermCondPar1[element] = 0.65d - (0.78d * bulkDensity[layer]) + (0.6d * Math.pow(bulkDensity[layer], 2));
            thermCondPar2[element] = 1.06d * bulkDensity[layer];
            thermCondPar3[element] = 1.0d + Divide(2.6d, Math.sqrt(clay[layer]), (double)(0));
            thermCondPar4[element] = 0.03d + (0.1d * Math.pow(bulkDensity[layer], 2));
        }
        return new doThermalConductivityCoeffs(thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1);
    }
    public readParam Calculate_readParam (double bareSoilRoughness, Double [] newTemperature, double soilRoughnessHeight, Double [] soilTemp, Double [] thermCondPar2, Integer numLayers, Double [] bulkDensity, Integer numNodes, Double [] thermCondPar3, Double [] thermCondPar4, Double [] clay, Double [] thermCondPar1, double weather_Tav, Integer clock_Today_DayOfYear, Integer surfaceNode, double weather_Amp, Double [] thickness, double weather_Latitude)
    {
        doThermalConductivityCoeffs zz_doThermalConductivityCoeffs;
        zz_doThermalConductivityCoeffs = Calculate_doThermalConductivityCoeffs(thermCondPar2, numLayers, bulkDensity, numNodes, thermCondPar3, thermCondPar4, clay, thermCondPar1);
        thermCondPar2 = zz_doThermalConductivityCoeffs.getthermCondPar2();
        thermCondPar3 = zz_doThermalConductivityCoeffs.getthermCondPar3();
        thermCondPar4 = zz_doThermalConductivityCoeffs.getthermCondPar4();
        thermCondPar1 = zz_doThermalConductivityCoeffs.getthermCondPar1();
        soilTemp = calcSoilTemperature(soilTemp, weather_Tav, clock_Today_DayOfYear, surfaceNode, numNodes, weather_Amp, thickness, weather_Latitude);
        System.arraycopy(soilTemp, 0, newTemperature, 0, soilTemp.length);
        soilRoughnessHeight = bareSoilRoughness;
        return new readParam(newTemperature, soilTemp, thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1, soilRoughnessHeight);
    }
    public getOtherVariables Calculate_getOtherVariables (Integer numLayers, Integer numNodes, Double [] soilWater, double instrumentHeight, double soilRoughnessHeight, Double [] waterBalance_SW, double microClimate_CanopyHeight, double canopyHeight)
    {
        System.arraycopy(waterBalance_SW, 0, soilWater, 1, waterBalance_SW.length);
        soilWater[numNodes] = soilWater[numLayers];
        canopyHeight = Math.max(microClimate_CanopyHeight, soilRoughnessHeight) / 1000.0d;
        instrumentHeight = Math.max(instrumentHeight, canopyHeight + 0.5d);
        return new getOtherVariables(soilWater, instrumentHeight, canopyHeight);
    }
    public static double volumetricFractionOrganicMatter(Integer layer, Double [] carbon, Double [] bulkDensity, double pom)
    {
        return carbon[layer] / 100.0d * 2.5d * bulkDensity[layer] / pom;
    }
    public static double volumetricFractionRocks(Integer layer, Double [] rocks)
    {
        return rocks[layer] / 100.0d;
    }
    public static double volumetricFractionIce(Integer layer)
    {
        return 0.0d;
    }
    public static double volumetricFractionWater(Integer layer, Double [] soilWater, Double [] carbon, Double [] bulkDensity, double pom)
    {
        return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom)) * soilWater[layer];
    }
    public static double volumetricFractionClay(Integer layer, Double [] bulkDensity, double ps, Double [] clay, Double [] carbon, double pom, Double [] rocks)
    {
        return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * clay[layer] / 100.0d * bulkDensity[layer] / ps;
    }
    public static double volumetricFractionSilt(Integer layer, Double [] bulkDensity, Double [] silt, double ps, Double [] carbon, double pom, Double [] rocks)
    {
        return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * silt[layer] / 100.0d * bulkDensity[layer] / ps;
    }
    public static double volumetricFractionSand(Integer layer, Double [] bulkDensity, Double [] sand, double ps, Double [] carbon, double pom, Double [] rocks)
    {
        return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * sand[layer] / 100.0d * bulkDensity[layer] / ps;
    }
    public static double kelvinT(double celciusT)
    {
        double celciusToKelvin;
        celciusToKelvin = 273.18d;
        return celciusT + celciusToKelvin;
    }
    public static double Divide(double value1, double value2, double errVal)
    {
        if (value2 != (double)(0))
        {
            return value1 / value2;
        }
        return errVal;
    }
    public static double Sum(Double [] values, Integer startIndex, Integer endIndex, double MissingValue)
    {
        double value;
        double result;
        Integer index;
        result = 0.0d;
        index = -1;
        for(Double value_cyml : values)
        {
            value = value_cyml;
            index = index + 1;
            if (index >= startIndex && value != MissingValue)
            {
                result = result + value;
            }
            if (index == endIndex)
            {
                break;
            }
        }
        return result;
    }
    public static double volumetricSpecificHeat(String name, Integer layer)
    {
        double specificHeatRocks;
        double specificHeatOM;
        double specificHeatSand;
        double specificHeatSilt;
        double specificHeatClay;
        double specificHeatWater;
        double specificHeatIce;
        double specificHeatAir;
        double result;
        specificHeatRocks = 7.7d;
        specificHeatOM = 0.25d;
        specificHeatSand = 7.7d;
        specificHeatSilt = 2.74d;
        specificHeatClay = 2.92d;
        specificHeatWater = 0.57d;
        specificHeatIce = 2.18d;
        specificHeatAir = 0.025d;
        result = 0.0d;
        if (name == "Rocks")
        {
            result = specificHeatRocks;
        }
        else if ( name == "OrganicMatter")
        {
            result = specificHeatOM;
        }
        else if ( name == "Sand")
        {
            result = specificHeatSand;
        }
        else if ( name == "Silt")
        {
            result = specificHeatSilt;
        }
        else if ( name == "Clay")
        {
            result = specificHeatClay;
        }
        else if ( name == "Water")
        {
            result = specificHeatWater;
        }
        else if ( name == "Ice")
        {
            result = specificHeatIce;
        }
        else if ( name == "Air")
        {
            result = specificHeatAir;
        }
        return result;
    }
    public static double volumetricFractionAir(Integer layer, Double [] rocks, Double [] carbon, Double [] bulkDensity, double pom, Double [] sand, double ps, Double [] silt, Double [] clay, Double [] soilWater)
    {
        return 1.0d - volumetricFractionRocks(layer, rocks) - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks) - volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks) - volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks) - volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) - volumetricFractionIce(layer);
    }
    public static double airDensity(double temperature, double AirPressure)
    {
        double MWair;
        double RGAS;
        double HPA2PA;
        MWair = 0.02897d;
        RGAS = 8.3143d;
        HPA2PA = 100.0d;
        return Divide(MWair * AirPressure * HPA2PA, kelvinT(temperature) * RGAS, 0.0d);
    }
    public static double longWaveRadn(double emissivity, double tDegC, double stefanBoltzmannConstant)
    {
        return stefanBoltzmannConstant * emissivity * Math.pow(kelvinT(tDegC), 4);
    }
    public static Double [] mapLayer2Node(Double [] layerArray, Double [] nodeArray, Double [] nodeDepth, Integer numNodes, Double [] thickness, Integer surfaceNode, double MissingValue)
    {
        Integer node;
        Integer layer;
        double depthLayerAbove;
        double d1;
        double d2;
        double dSum;
        for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
        {
            layer = node - 1;
            depthLayerAbove = layer >= 1 ? Sum(thickness, 1, layer, MissingValue) : 0.0d;
            d1 = depthLayerAbove - (nodeDepth[node] * 1000.0d);
            d2 = nodeDepth[(node + 1)] * 1000.0d - depthLayerAbove;
            dSum = d1 + d2;
            nodeArray[node] = Divide(layerArray[layer] * d1, dSum, (double)(0)) + Divide(layerArray[(layer + 1)] * d2, dSum, (double)(0));
        }
        return nodeArray;
    }
    public static double ThermalConductance(String name, Integer layer, Double [] rocks, Double [] bulkDensity, Double [] sand, double ps, Double [] carbon, double pom, Double [] silt, Double [] clay)
    {
        double thermalConductanceRocks;
        double thermalConductanceOM;
        double thermalConductanceSand;
        double thermalConductanceSilt;
        double thermalConductanceClay;
        double thermalConductanceWater;
        double thermalConductanceIce;
        double thermalConductanceAir;
        double result;
        thermalConductanceRocks = 0.182d;
        thermalConductanceOM = 2.50d;
        thermalConductanceSand = 0.182d;
        thermalConductanceSilt = 2.39d;
        thermalConductanceClay = 1.39d;
        thermalConductanceWater = 4.18d;
        thermalConductanceIce = 1.73d;
        thermalConductanceAir = 0.0012d;
        result = 0.0d;
        if (name == "Rocks")
        {
            result = thermalConductanceRocks;
        }
        else if ( name == "OrganicMatter")
        {
            result = thermalConductanceOM;
        }
        else if ( name == "Sand")
        {
            result = thermalConductanceSand;
        }
        else if ( name == "Silt")
        {
            result = thermalConductanceSilt;
        }
        else if ( name == "Clay")
        {
            result = thermalConductanceClay;
        }
        else if ( name == "Water")
        {
            result = thermalConductanceWater;
        }
        else if ( name == "Ice")
        {
            result = thermalConductanceIce;
        }
        else if ( name == "Air")
        {
            result = thermalConductanceAir;
        }
        else if ( name == "Minerals")
        {
            result = Math.pow(thermalConductanceRocks, volumetricFractionRocks(layer, rocks)) * Math.pow(thermalConductanceSand, volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks)) + Math.pow(thermalConductanceSilt, volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + Math.pow(thermalConductanceClay, volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks));
        }
        result = volumetricSpecificHeat(name, layer);
        return result;
    }
    public static double shapeFactor(String name, Integer layer, Double [] soilWater, Double [] carbon, Double [] bulkDensity, double pom, Double [] rocks, Double [] sand, double ps, Double [] silt, Double [] clay)
    {
        double shapeFactorRocks;
        double shapeFactorOM;
        double shapeFactorSand;
        double shapeFactorSilt;
        double shapeFactorClay;
        double shapeFactorWater;
        double result;
        shapeFactorRocks = 0.182d;
        shapeFactorOM = 0.5d;
        shapeFactorSand = 0.182d;
        shapeFactorSilt = 0.125d;
        shapeFactorClay = 0.007755d;
        shapeFactorWater = 1.0d;
        result = 0.0d;
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
            result = 0.333d - (0.333d * volumetricFractionIce(layer) / (volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater)));
            return result;
        }
        else if ( name == "Air")
        {
            result = 0.333d - (0.333d * volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater) / (volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater)));
            return result;
        }
        else if ( name == "Minerals")
        {
            result = shapeFactorRocks * volumetricFractionRocks(layer, rocks) + (shapeFactorSand * volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks)) + (shapeFactorSilt * volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + (shapeFactorClay * volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks));
        }
        result = volumetricSpecificHeat(name, layer);
        return result;
    }
    public doUpdate Calculate_doUpdate (Integer numInterationsPerDay, double timeOfDaySecs, double boundaryLayerConductance, Double [] minSoilTemp, Integer airNode, Double [] soilTemp, Double [] newTemperature, Integer numNodes, Integer surfaceNode, double internalTimeStep, Double [] maxSoilTemp, Double [] aveSoilTemp, Double [] thermalConductivity)
    {
        Integer node;
        System.arraycopy(newTemperature, 0, soilTemp, 0, newTemperature.length);
        if (timeOfDaySecs < (internalTimeStep * 1.2d))
        {
            for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
            {
                minSoilTemp[node] = soilTemp[node];
                maxSoilTemp[node] = soilTemp[node];
            }
        }
        for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
        {
            if (soilTemp[node] < minSoilTemp[node])
            {
                minSoilTemp[node] = soilTemp[node];
            }
            else if ( soilTemp[node] > maxSoilTemp[node])
            {
                maxSoilTemp[node] = soilTemp[node];
            }
            aveSoilTemp[node] = aveSoilTemp[node] + Divide(soilTemp[node], (double)(numInterationsPerDay), (double)(0));
        }
        boundaryLayerConductance = boundaryLayerConductance + Divide(thermalConductivity[airNode], (double)(numInterationsPerDay), (double)(0));
        return new doUpdate(minSoilTemp, soilTemp, maxSoilTemp, aveSoilTemp, boundaryLayerConductance);
    }
    public doThomas Calculate_doThomas (Double [] newTemps, double netRadiation, Double [] heatStorage, double waterBalance_Eos, Integer numNodes, double timestep, String netRadiationSource, double latentHeatOfVapourisation, Double [] nodeDepth, double waterBalance_Es, Integer airNode, Double [] soilTemp, Integer surfaceNode, double internalTimeStep, Double [] thermalConductance, Double [] thermalConductivity, double nu, Double [] volSpecHeatSoil)
    {
        Integer node;
        Double[] a =  new Double [numNodes + 1 + 1];
        Double[] b =  new Double [numNodes + 1];
        Double[] c =  new Double [numNodes + 1];
        Double[] d =  new Double [numNodes + 1];
        double volumeOfSoilAtNode;
        double elementLength;
        double g;
        double sensibleHeatFlux;
        double radnNet;
        double latentHeatFlux;
        double soilSurfaceHeatFlux;
        thermalConductance[airNode] = thermalConductivity[airNode];
        for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
        {
            volumeOfSoilAtNode = 0.5d * (nodeDepth[node + 1] - nodeDepth[node - 1]);
            heatStorage[node] = Divide(volSpecHeatSoil[node] * volumeOfSoilAtNode, internalTimeStep, (double)(0));
            elementLength = nodeDepth[node + 1] - nodeDepth[node];
            thermalConductance[node] = Divide(thermalConductivity[node], elementLength, (double)(0));
        }
        g = 1 - nu;
        for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
        {
            c[node] = -nu * thermalConductance[node];
            a[node + 1] = c[node];
            b[node] = nu * (thermalConductance[node] + thermalConductance[node - 1]) + heatStorage[node];
            d[node] = g * thermalConductance[(node - 1)] * soilTemp[(node - 1)] + ((heatStorage[node] - (g * (thermalConductance[node] + thermalConductance[node - 1]))) * soilTemp[node]) + (g * thermalConductance[node] * soilTemp[(node + 1)]);
        }
        a[surfaceNode] = 0.0d;
        sensibleHeatFlux = nu * thermalConductance[airNode] * newTemps[airNode];
        radnNet = 0.0d;
        if (netRadiationSource == "calc")
        {
            radnNet = Divide(netRadiation * 1000000.0d, internalTimeStep, (double)(0));
        }
        else if ( netRadiationSource == "eos")
        {
            radnNet = Divide(waterBalance_Eos * latentHeatOfVapourisation, timestep, (double)(0));
        }
        latentHeatFlux = Divide(waterBalance_Es * latentHeatOfVapourisation, timestep, (double)(0));
        soilSurfaceHeatFlux = sensibleHeatFlux + radnNet - latentHeatFlux;
        d[surfaceNode] = d[surfaceNode] + soilSurfaceHeatFlux;
        d[numNodes] = d[numNodes] + (nu * thermalConductance[numNodes] * newTemps[(numNodes + 1)]);
        for (node=surfaceNode ; node!=numNodes - 1 + 1 ; node+=1)
        {
            c[node] = Divide(c[node], b[node], (double)(0));
            d[node] = Divide(d[node], b[node], (double)(0));
            b[node + 1] = b[node + 1] - (a[(node + 1)] * c[node]);
            d[node + 1] = d[node + 1] - (a[(node + 1)] * d[node]);
        }
        newTemps[numNodes] = Divide(d[numNodes], b[numNodes], (double)(0));
        for (node=numNodes - 1 ; node!=surfaceNode - 1 ; node+=-1)
        {
            newTemps[node] = d[node] - (c[node] * newTemps[(node + 1)]);
        }
        return new doThomas(newTemps, heatStorage, thermalConductance);
    }
    public getBoundaryLayerConductance Calculate_getBoundaryLayerConductance (Double [] TNew_zb, double weather_AirPressure, double stefanBoltzmannConstant, double waterBalance_Eos, double weather_Wind, double airTemperature, Integer surfaceNode, double waterBalance_Eo, double instrumentHeight, double canopyHeight)
    {
        Integer iteration;
        double vonKarmanConstant;
        double gravitationalConstant;
        double specificHeatOfAir;
        double surfaceEmissivity;
        double SpecificHeatAir;
        double roughnessFactorMomentum;
        double roughnessFactorHeat;
        double d;
        double surfaceTemperature;
        double diffusePenetrationConstant;
        double radiativeConductance;
        double frictionVelocity;
        double boundaryLayerCond;
        double stabilityParammeter;
        double stabilityCorrectionMomentum;
        double stabilityCorrectionHeat;
        double heatFluxDensity;
        vonKarmanConstant = 0.41d;
        gravitationalConstant = 9.8d;
        specificHeatOfAir = 1010.0d;
        surfaceEmissivity = 0.98d;
        SpecificHeatAir = specificHeatOfAir * airDensity(airTemperature, weather_AirPressure);
        roughnessFactorMomentum = 0.13d * canopyHeight;
        roughnessFactorHeat = 0.2d * roughnessFactorMomentum;
        d = 0.77d * canopyHeight;
        surfaceTemperature = TNew_zb[surfaceNode];
        diffusePenetrationConstant = Math.max(0.1d, waterBalance_Eos) / Math.max(0.1d, waterBalance_Eo);
        radiativeConductance = 4.0d * stefanBoltzmannConstant * surfaceEmissivity * diffusePenetrationConstant * Math.pow(kelvinT(airTemperature), 3);
        frictionVelocity = 0.0d;
        boundaryLayerCond = 0.0d;
        stabilityParammeter = 0.0d;
        stabilityCorrectionMomentum = 0.0d;
        stabilityCorrectionHeat = 0.0d;
        heatFluxDensity = 0.0d;
        for (iteration=1 ; iteration!=3 + 1 ; iteration+=1)
        {
            frictionVelocity = Divide(weather_Wind * vonKarmanConstant, Math.log(Divide(instrumentHeight - d + roughnessFactorMomentum, roughnessFactorMomentum, (double)(0))) + stabilityCorrectionMomentum, (double)(0));
            boundaryLayerCond = Divide(SpecificHeatAir * vonKarmanConstant * frictionVelocity, Math.log(Divide(instrumentHeight - d + roughnessFactorHeat, roughnessFactorHeat, (double)(0))) + stabilityCorrectionHeat, (double)(0));
            boundaryLayerCond = boundaryLayerCond + radiativeConductance;
            heatFluxDensity = boundaryLayerCond * (surfaceTemperature - airTemperature);
            stabilityParammeter = Divide(-vonKarmanConstant * instrumentHeight * gravitationalConstant * heatFluxDensity, SpecificHeatAir * kelvinT(airTemperature) * Math.pow(frictionVelocity, 3.0d), (double)(0));
            if (stabilityParammeter > 0.0d)
            {
                stabilityCorrectionHeat = 4.7d * stabilityParammeter;
                stabilityCorrectionMomentum = stabilityCorrectionHeat;
            }
            else
            {
                stabilityCorrectionHeat = -2.0d * Math.log((1.0d + Math.sqrt(1.0d - (16.0d * stabilityParammeter))) / 2.0d);
                stabilityCorrectionMomentum = 0.6d * stabilityCorrectionHeat;
            }
        }
        return new getBoundaryLayerConductance(boundaryLayerCond, TNew_zb);
    }
    public static double interpolateNetRadiation(double solarRadn, double cloudFr, double cva, double waterBalance_Eo, double waterBalance_Eos, double waterBalance_Salb, Double [] soilTemp, double airTemperature, Integer surfaceNode, double internalTimeStep, double stefanBoltzmannConstant)
    {
        double surfaceEmissivity;
        double w2MJ;
        double emissivityAtmos;
        double PenetrationConstant;
        double lwRinSoil;
        double lwRoutSoil;
        double lwRnetSoil;
        double swRin;
        double swRout;
        double swRnetSoil;
        surfaceEmissivity = 0.96d;
        w2MJ = internalTimeStep / 1000000.0d;
        emissivityAtmos = (1 - (0.84d * cloudFr)) * 0.58d * Math.pow(cva, 1.0d / 7.0d) + (0.84d * cloudFr);
        PenetrationConstant = Divide(Math.max(0.1d, waterBalance_Eos), Math.max(0.1d, waterBalance_Eo), (double)(0));
        lwRinSoil = longWaveRadn(emissivityAtmos, airTemperature, stefanBoltzmannConstant) * PenetrationConstant * w2MJ;
        lwRoutSoil = longWaveRadn(surfaceEmissivity, soilTemp[surfaceNode], stefanBoltzmannConstant) * PenetrationConstant * w2MJ;
        lwRnetSoil = lwRinSoil - lwRoutSoil;
        swRin = solarRadn;
        swRout = waterBalance_Salb * solarRadn;
        swRnetSoil = (swRin - swRout) * PenetrationConstant;
        return swRnetSoil + lwRnetSoil;
    }
    public static double interpolateTemperature(double timeHours, double minTempYesterday, double maxTempYesterday, double weather_MeanT, double weather_MaxT, double weather_MinT, double defaultTimeOfMaximumTemperature)
    {
        double time;
        double maxT_time;
        double minT_time;
        double midnightT;
        double tScale;
        double currentTemperature;
        time = timeHours / 24.0d;
        maxT_time = defaultTimeOfMaximumTemperature / 24.0d;
        minT_time = maxT_time - 0.5d;
        if (time < minT_time)
        {
            midnightT = Math.sin((0.0d + 0.25d - maxT_time) * 2.0d * Math.PI) * (maxTempYesterday - minTempYesterday) / 2.0d + ((maxTempYesterday + minTempYesterday) / 2.0d);
            tScale = (minT_time - time) / minT_time;
            if (tScale > 1.0d)
            {
                tScale = 1.0d;
            }
            else if ( tScale < (double)(0))
            {
                tScale = (double)(0);
            }
            currentTemperature = weather_MinT + (tScale * (midnightT - weather_MinT));
            return currentTemperature;
        }
        else
        {
            currentTemperature = Math.sin((time + 0.25d - maxT_time) * 2.0d * Math.PI) * (weather_MaxT - weather_MinT) / 2.0d + weather_MeanT;
            return currentTemperature;
        }
    }
    public static Double [] doThermalConductivity(String [] soilConstituentNames, Integer numNodes, Double [] soilWater, Double [] thermalConductivity, Double [] carbon, Double [] bulkDensity, double pom, Double [] rocks, Double [] sand, double ps, Double [] silt, Double [] clay, Double [] nodeDepth, Double [] thickness, Integer surfaceNode, double MissingValue)
    {
        Integer node;
        String constituentName;
        Double[] thermCondLayers =  new Double [numNodes + 1];
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
            for(String constituentName_cyml : soilConstituentNames)
            {
                constituentName = constituentName_cyml;
                shapeFactorConstituent = shapeFactor(constituentName, node, soilWater, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay);
                thermalConductanceConstituent = ThermalConductance(constituentName, node, rocks, bulkDensity, sand, ps, carbon, pom, silt, clay);
                thermalConductanceWater = ThermalConductance("Water", node, rocks, bulkDensity, sand, ps, carbon, pom, silt, clay);
                k = 2.0d / 3.0d * Math.pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0d))), -1) + (1.0d / 3.0d * Math.pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0d) * (1 - (2 * shapeFactorConstituent)))), -1));
                numerator = numerator + (thermalConductanceConstituent * soilWater[node] * k);
                denominator = denominator + (soilWater[node] * k);
            }
            thermCondLayers[node] = numerator / denominator;
        }
        thermalConductivity = mapLayer2Node(thermCondLayers, thermalConductivity, nodeDepth, numNodes, thickness, surfaceNode, MissingValue);
        return thermalConductivity;
    }
    public static Double [] doVolumetricSpecificHeat(String [] soilConstituentNames, Integer numNodes, Double [] volSpecHeatSoil, Double [] soilWater, Double [] nodeDepth, Double [] thickness, Integer surfaceNode, double MissingValue)
    {
        Integer node;
        String constituentName;
        Double[] volspecHeatSoil_ =  new Double [numNodes + 1];
        for (node=1 ; node!=numNodes + 1 ; node+=1)
        {
            volspecHeatSoil_[node] = (double)(0);
            for(String constituentName_cyml : soilConstituentNames)
            {
                constituentName = constituentName_cyml;
                if (!new ArrayList<>(Arrays.asList("Minerals")).contains(constituentName))
                {
                    volspecHeatSoil_[node] = volspecHeatSoil_[node] + (volumetricSpecificHeat(constituentName, node) * 1000000.0d * soilWater[node]);
                }
            }
        }
        volSpecHeatSoil = mapLayer2Node(volspecHeatSoil_, volSpecHeatSoil, nodeDepth, numNodes, thickness, surfaceNode, MissingValue);
        return volSpecHeatSoil;
    }
    public static Double [] Zero(Double [] arr)
    {
        Integer i;
        if (arr != null)
        {
            for (i=0 ; i!=arr.length ; i+=1)
            {
                arr[i] = (double)(0);
            }
        }
        return arr;
    }
    public doNetRadiation Calculate_doNetRadiation (Double [] solarRadn, double cloudFr, double cva, Integer ITERATIONSperDAY, double weather_MinT, Integer clock_Today_DayOfYear, double weather_Radn, double weather_Latitude)
    {
        Integer timestepNumber;
        double TSTEPS2RAD;
        double solarConstant;
        double solarDeclination;
        double cD;
        Double[] m1 =  new Double [ITERATIONSperDAY + 1];
        double m1Tot;
        double psr;
        double fr;
        TSTEPS2RAD = Divide(2.0d * Math.PI, (double)(ITERATIONSperDAY), (double)(0));
        solarConstant = 1360.0d;
        solarDeclination = 0.3985d * Math.sin((4.869d + (clock_Today_DayOfYear * 2.0d * Math.PI / 365.25d) + (0.03345d * Math.sin((6.224d + (clock_Today_DayOfYear * 2.0d * Math.PI / 365.25d))))));
        cD = Math.sqrt(1.0d - (solarDeclination * solarDeclination));
        m1Tot = 0.0d;
        for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
        {
            m1[timestepNumber] = (solarDeclination * Math.sin(weather_Latitude * Math.PI / 180.0d) + (cD * Math.cos(weather_Latitude * Math.PI / 180.0d) * Math.cos(TSTEPS2RAD * (timestepNumber - (ITERATIONSperDAY / 2.0d))))) * 24.0d / ITERATIONSperDAY;
            if (m1[timestepNumber] > 0.0d)
            {
                m1Tot = m1Tot + m1[timestepNumber];
            }
            else
            {
                m1[timestepNumber] = 0.0d;
            }
        }
        psr = m1Tot * solarConstant * 3600.0d / 1000000.0d;
        fr = Divide(Math.max(weather_Radn, 0.1d), psr, (double)(0));
        cloudFr = 2.33d - (3.33d * fr);
        cloudFr = Math.min(Math.max(cloudFr, 0.0d), 1.0d);
        for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
        {
            solarRadn[timestepNumber] = Math.max(weather_Radn, 0.1d) * Divide(m1[timestepNumber], m1Tot, (double)(0));
        }
        cva = Math.exp((31.3716d - (6014.79d / kelvinT(weather_MinT)) - (0.00792495d * kelvinT(weather_MinT)))) / kelvinT(weather_MinT);
        return new doNetRadiation(solarRadn, cloudFr, cva);
    }
    public doProcess Calculate_doProcess (double timeOfDaySecs, double netRadiation, Double [] minSoilTemp, Double [] maxSoilTemp, Integer numIterationsForBoundaryLayerConductance, double timestep, double boundaryLayerConductance, double maxTempYesterday, Integer airNode, Double [] soilTemp, double airTemperature, Double [] newTemperature, double weather_MaxT, double internalTimeStep, String boundarLayerConductanceSource, Double [] thermalConductivity, double minTempYesterday, Double [] aveSoilTemp, Double [] morningSoilTemp, double weather_MeanT, double constantBoundaryLayerConductance, double weather_MinT, Integer clock_Today_DayOfYear, double weather_Radn, double weather_Latitude, String [] soilConstituentNames, Integer numNodes, Double [] volSpecHeatSoil, Double [] soilWater, Double [] nodeDepth, Double [] thickness, Integer surfaceNode, double MissingValue, Double [] carbon, Double [] bulkDensity, double pom, Double [] rocks, Double [] sand, double ps, Double [] silt, Double [] clay, double defaultTimeOfMaximumTemperature, double waterBalance_Eo, double waterBalance_Eos, double waterBalance_Salb, double stefanBoltzmannConstant, double weather_AirPressure, double weather_Wind, double instrumentHeight, double canopyHeight, Double [] heatStorage, String netRadiationSource, double latentHeatOfVapourisation, double waterBalance_Es, Double [] thermalConductance, double nu)
    {
        doNetRadiation zz_doNetRadiation;
        getBoundaryLayerConductance zz_getBoundaryLayerConductance;
        doThomas zz_doThomas;
        doUpdate zz_doUpdate;
        Integer timeStepIteration;
        Integer iteration;
        Integer interactionsPerDay;
        double cva;
        double cloudFr;
        Double[] solarRadn =  new Double [49];
        interactionsPerDay = 48;
        cva = 0.0d;
        cloudFr = 0.0d;
        zz_doNetRadiation = Calculate_doNetRadiation(solarRadn, cloudFr, cva, interactionsPerDay, weather_MinT, clock_Today_DayOfYear, weather_Radn, weather_Latitude);
        solarRadn = zz_doNetRadiation.getsolarRadn();
        cloudFr = zz_doNetRadiation.getcloudFr();
        cva = zz_doNetRadiation.getcva();
        minSoilTemp = Zero(minSoilTemp);
        maxSoilTemp = Zero(maxSoilTemp);
        aveSoilTemp = Zero(aveSoilTemp);
        boundaryLayerConductance = 0.0d;
        internalTimeStep = Math.round(timestep / interactionsPerDay);
        volSpecHeatSoil = doVolumetricSpecificHeat(soilConstituentNames, numNodes, volSpecHeatSoil, soilWater, nodeDepth, thickness, surfaceNode, MissingValue);
        thermalConductivity = doThermalConductivity(soilConstituentNames, numNodes, soilWater, thermalConductivity, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay, nodeDepth, thickness, surfaceNode, MissingValue);
        for (timeStepIteration=1 ; timeStepIteration!=interactionsPerDay + 1 ; timeStepIteration+=1)
        {
            timeOfDaySecs = internalTimeStep * (double)(timeStepIteration);
            if (timestep < (24.0d * 60.0d * 60.0d))
            {
                airTemperature = weather_MeanT;
            }
            else
            {
                airTemperature = interpolateTemperature(timeOfDaySecs / 3600.0d, minTempYesterday, maxTempYesterday, weather_MeanT, weather_MaxT, weather_MinT, defaultTimeOfMaximumTemperature);
            }
            newTemperature[airNode] = airTemperature;
            netRadiation = interpolateNetRadiation(solarRadn[timeStepIteration], cloudFr, cva, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, soilTemp, airTemperature, surfaceNode, internalTimeStep, stefanBoltzmannConstant);
            if (boundarLayerConductanceSource == "constant")
            {
                thermalConductivity[airNode] = constantBoundaryLayerConductance;
            }
            else if ( boundarLayerConductanceSource == "calc")
            {
                zz_getBoundaryLayerConductance = Calculate_getBoundaryLayerConductance(newTemperature, weather_AirPressure, stefanBoltzmannConstant, waterBalance_Eos, weather_Wind, airTemperature, surfaceNode, waterBalance_Eo, instrumentHeight, canopyHeight);
                thermalConductivity[airNode] = zz_getBoundaryLayerConductance.getboundaryLayerCond();
                newTemperature = zz_getBoundaryLayerConductance.getTNew_zb();
                for (iteration=1 ; iteration!=numIterationsForBoundaryLayerConductance + 1 ; iteration+=1)
                {
                    zz_doThomas = Calculate_doThomas(newTemperature, netRadiation, heatStorage, waterBalance_Eos, numNodes, timestep, netRadiationSource, latentHeatOfVapourisation, nodeDepth, waterBalance_Es, airNode, soilTemp, surfaceNode, internalTimeStep, thermalConductance, thermalConductivity, nu, volSpecHeatSoil);
                    newTemperature = zz_doThomas.getnewTemps();
                    heatStorage = zz_doThomas.getheatStorage();
                    thermalConductance = zz_doThomas.getthermalConductance();
                    zz_getBoundaryLayerConductance = Calculate_getBoundaryLayerConductance(newTemperature, weather_AirPressure, stefanBoltzmannConstant, waterBalance_Eos, weather_Wind, airTemperature, surfaceNode, waterBalance_Eo, instrumentHeight, canopyHeight);
                    thermalConductivity[airNode] = zz_getBoundaryLayerConductance.getboundaryLayerCond();
                    newTemperature = zz_getBoundaryLayerConductance.getTNew_zb();
                }
            }
            zz_doThomas = Calculate_doThomas(newTemperature, netRadiation, heatStorage, waterBalance_Eos, numNodes, timestep, netRadiationSource, latentHeatOfVapourisation, nodeDepth, waterBalance_Es, airNode, soilTemp, surfaceNode, internalTimeStep, thermalConductance, thermalConductivity, nu, volSpecHeatSoil);
            newTemperature = zz_doThomas.getnewTemps();
            heatStorage = zz_doThomas.getheatStorage();
            thermalConductance = zz_doThomas.getthermalConductance();
            zz_doUpdate = Calculate_doUpdate(interactionsPerDay, timeOfDaySecs, boundaryLayerConductance, minSoilTemp, airNode, soilTemp, newTemperature, numNodes, surfaceNode, internalTimeStep, maxSoilTemp, aveSoilTemp, thermalConductivity);
            minSoilTemp = zz_doUpdate.getminSoilTemp();
            soilTemp = zz_doUpdate.getsoilTemp();
            maxSoilTemp = zz_doUpdate.getmaxSoilTemp();
            aveSoilTemp = zz_doUpdate.getaveSoilTemp();
            boundaryLayerConductance = zz_doUpdate.getboundaryLayerConductance();
            if (Math.abs(timeOfDaySecs - (5.0d * 3600.0d)) <= (Math.min(timeOfDaySecs, 5.0d * 3600.0d) * 0.0001d))
            {
                System.arraycopy(soilTemp, 0, morningSoilTemp, 0, soilTemp.length);
            }
        }
        minTempYesterday = weather_MinT;
        maxTempYesterday = weather_MaxT;
        return new doProcess(minSoilTemp, maxSoilTemp, soilTemp, newTemperature, thermalConductivity, aveSoilTemp, morningSoilTemp, volSpecHeatSoil, heatStorage, thermalConductance, timeOfDaySecs, netRadiation, airTemperature, internalTimeStep, minTempYesterday, boundaryLayerConductance, maxTempYesterday);
    }
    public static Double [] ToCumThickness(Double [] Thickness)
    {
        Integer Layer;
        Double[] CumThickness =  new Double [Thickness.length];
        if (Thickness.length > 0)
        {
            CumThickness[0] = Thickness[0];
            for (Layer=1 ; Layer!=Thickness.length ; Layer+=1)
            {
                CumThickness[Layer] = Thickness[Layer] + CumThickness[Layer - 1];
            }
        }
        return CumThickness;
    }
    public static Double [] calcSoilTemperature(Double [] soilTempIO, double weather_Tav, Integer clock_Today_DayOfYear, Integer surfaceNode, Integer numNodes, double weather_Amp, Double [] thickness, double weather_Latitude)
    {
        Integer nodes;
        Double[] cumulativeDepth = null ;
        double w;
        double dh;
        double zd;
        double offset;
        Double[] soilTemp =  new Double [numNodes + 1 + 1];
        cumulativeDepth = ToCumThickness(thickness);
        w = 2 * Math.PI / (365.25d * 24 * 3600);
        dh = 0.6d;
        zd = Math.sqrt(2 * dh / w);
        offset = 0.25d;
        if (weather_Latitude > 0.0d)
        {
            offset = -0.25d;
        }
        for (nodes=1 ; nodes!=numNodes + 1 ; nodes+=1)
        {
            soilTemp[nodes] = weather_Tav + (weather_Amp * Math.exp(-1 * cumulativeDepth[nodes] / zd) * Math.sin(((clock_Today_DayOfYear / 365.0d + offset) * 2.0d * Math.PI - (cumulativeDepth[nodes] / zd))));
        }
         System.arraycopy(soilTemp, 0, soilTempIO, surfaceNode, numNodes);
        return soilTempIO;
    }
    public static double calcSurfaceTemperature(double weather_MeanT, double weather_MaxT, double waterBalance_Salb, double weather_Radn)
    {
        double surfaceT;
        surfaceT = (1.0d - waterBalance_Salb) * (weather_MeanT + ((weather_MaxT - weather_MeanT) * Math.sqrt(Math.max(weather_Radn, 0.1d) * 23.8846d / 800.0d))) + (waterBalance_Salb * weather_MeanT);
        return surfaceT;
    }
    public static Boolean ValuesInArray(Double [] Values, double MissingValue)
    {
        double Value;
        if (Values != null)
        {
            for(Double Value_cyml : Values)
            {
                Value = Value_cyml;
                if (Value != MissingValue && !Double.isNaN(Value))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
final class getProfileVariables {
    private Double [] heatStorage;
    public Double [] getheatStorage()
    { return heatStorage; }

    public void setheatStorage(Double [] _heatStorage)
    { this.heatStorage= _heatStorage; } 
    
    private Double [] minSoilTemp;
    public Double [] getminSoilTemp()
    { return minSoilTemp; }

    public void setminSoilTemp(Double [] _minSoilTemp)
    { this.minSoilTemp= _minSoilTemp; } 
    
    private Double [] bulkDensity;
    public Double [] getbulkDensity()
    { return bulkDensity; }

    public void setbulkDensity(Double [] _bulkDensity)
    { this.bulkDensity= _bulkDensity; } 
    
    private Double [] maxSoilTemp;
    public Double [] getmaxSoilTemp()
    { return maxSoilTemp; }

    public void setmaxSoilTemp(Double [] _maxSoilTemp)
    { this.maxSoilTemp= _maxSoilTemp; } 
    
    private Double [] nodeDepth;
    public Double [] getnodeDepth()
    { return nodeDepth; }

    public void setnodeDepth(Double [] _nodeDepth)
    { this.nodeDepth= _nodeDepth; } 
    
    private Double [] newTemperature;
    public Double [] getnewTemperature()
    { return newTemperature; }

    public void setnewTemperature(Double [] _newTemperature)
    { this.newTemperature= _newTemperature; } 
    
    private Double [] soilWater;
    public Double [] getsoilWater()
    { return soilWater; }

    public void setsoilWater(Double [] _soilWater)
    { this.soilWater= _soilWater; } 
    
    private Double [] thermalConductance;
    public Double [] getthermalConductance()
    { return thermalConductance; }

    public void setthermalConductance(Double [] _thermalConductance)
    { this.thermalConductance= _thermalConductance; } 
    
    private Double [] thermalConductivity;
    public Double [] getthermalConductivity()
    { return thermalConductivity; }

    public void setthermalConductivity(Double [] _thermalConductivity)
    { this.thermalConductivity= _thermalConductivity; } 
    
    private Double [] sand;
    public Double [] getsand()
    { return sand; }

    public void setsand(Double [] _sand)
    { this.sand= _sand; } 
    
    private Double [] carbon;
    public Double [] getcarbon()
    { return carbon; }

    public void setcarbon(Double [] _carbon)
    { this.carbon= _carbon; } 
    
    private Double [] thickness;
    public Double [] getthickness()
    { return thickness; }

    public void setthickness(Double [] _thickness)
    { this.thickness= _thickness; } 
    
    private Double [] rocks;
    public Double [] getrocks()
    { return rocks; }

    public void setrocks(Double [] _rocks)
    { this.rocks= _rocks; } 
    
    private Double [] clay;
    public Double [] getclay()
    { return clay; }

    public void setclay(Double [] _clay)
    { this.clay= _clay; } 
    
    private Double [] soilTemp;
    public Double [] getsoilTemp()
    { return soilTemp; }

    public void setsoilTemp(Double [] _soilTemp)
    { this.soilTemp= _soilTemp; } 
    
    private Double [] silt;
    public Double [] getsilt()
    { return silt; }

    public void setsilt(Double [] _silt)
    { this.silt= _silt; } 
    
    private Double [] volSpecHeatSoil;
    public Double [] getvolSpecHeatSoil()
    { return volSpecHeatSoil; }

    public void setvolSpecHeatSoil(Double [] _volSpecHeatSoil)
    { this.volSpecHeatSoil= _volSpecHeatSoil; } 
    
    private Double [] aveSoilTemp;
    public Double [] getaveSoilTemp()
    { return aveSoilTemp; }

    public void setaveSoilTemp(Double [] _aveSoilTemp)
    { this.aveSoilTemp= _aveSoilTemp; } 
    
    private Double [] morningSoilTemp;
    public Double [] getmorningSoilTemp()
    { return morningSoilTemp; }

    public void setmorningSoilTemp(Double [] _morningSoilTemp)
    { this.morningSoilTemp= _morningSoilTemp; } 
    
    private Integer numNodes;
    public Integer getnumNodes()
    { return numNodes; }

    public void setnumNodes(Integer _numNodes)
    { this.numNodes= _numNodes; } 
    
    private Integer numLayers;
    public Integer getnumLayers()
    { return numLayers; }

    public void setnumLayers(Integer _numLayers)
    { this.numLayers= _numLayers; } 
    
    public getProfileVariables(Double [] heatStorage,Double [] minSoilTemp,Double [] bulkDensity,Double [] maxSoilTemp,Double [] nodeDepth,Double [] newTemperature,Double [] soilWater,Double [] thermalConductance,Double [] thermalConductivity,Double [] sand,Double [] carbon,Double [] thickness,Double [] rocks,Double [] clay,Double [] soilTemp,Double [] silt,Double [] volSpecHeatSoil,Double [] aveSoilTemp,Double [] morningSoilTemp,Integer numNodes,Integer numLayers)
    {
        this.heatStorage = heatStorage;
        this.minSoilTemp = minSoilTemp;
        this.bulkDensity = bulkDensity;
        this.maxSoilTemp = maxSoilTemp;
        this.nodeDepth = nodeDepth;
        this.newTemperature = newTemperature;
        this.soilWater = soilWater;
        this.thermalConductance = thermalConductance;
        this.thermalConductivity = thermalConductivity;
        this.sand = sand;
        this.carbon = carbon;
        this.thickness = thickness;
        this.rocks = rocks;
        this.clay = clay;
        this.soilTemp = soilTemp;
        this.silt = silt;
        this.volSpecHeatSoil = volSpecHeatSoil;
        this.aveSoilTemp = aveSoilTemp;
        this.morningSoilTemp = morningSoilTemp;
        this.numNodes = numNodes;
        this.numLayers = numLayers;
    }
}final class doThermalConductivityCoeffs {
    private Double [] thermCondPar2;
    public Double [] getthermCondPar2()
    { return thermCondPar2; }

    public void setthermCondPar2(Double [] _thermCondPar2)
    { this.thermCondPar2= _thermCondPar2; } 
    
    private Double [] thermCondPar3;
    public Double [] getthermCondPar3()
    { return thermCondPar3; }

    public void setthermCondPar3(Double [] _thermCondPar3)
    { this.thermCondPar3= _thermCondPar3; } 
    
    private Double [] thermCondPar4;
    public Double [] getthermCondPar4()
    { return thermCondPar4; }

    public void setthermCondPar4(Double [] _thermCondPar4)
    { this.thermCondPar4= _thermCondPar4; } 
    
    private Double [] thermCondPar1;
    public Double [] getthermCondPar1()
    { return thermCondPar1; }

    public void setthermCondPar1(Double [] _thermCondPar1)
    { this.thermCondPar1= _thermCondPar1; } 
    
    public doThermalConductivityCoeffs(Double [] thermCondPar2,Double [] thermCondPar3,Double [] thermCondPar4,Double [] thermCondPar1)
    {
        this.thermCondPar2 = thermCondPar2;
        this.thermCondPar3 = thermCondPar3;
        this.thermCondPar4 = thermCondPar4;
        this.thermCondPar1 = thermCondPar1;
    }
}final class readParam {
    private Double [] newTemperature;
    public Double [] getnewTemperature()
    { return newTemperature; }

    public void setnewTemperature(Double [] _newTemperature)
    { this.newTemperature= _newTemperature; } 
    
    private Double [] soilTemp;
    public Double [] getsoilTemp()
    { return soilTemp; }

    public void setsoilTemp(Double [] _soilTemp)
    { this.soilTemp= _soilTemp; } 
    
    private Double [] thermCondPar2;
    public Double [] getthermCondPar2()
    { return thermCondPar2; }

    public void setthermCondPar2(Double [] _thermCondPar2)
    { this.thermCondPar2= _thermCondPar2; } 
    
    private Double [] thermCondPar3;
    public Double [] getthermCondPar3()
    { return thermCondPar3; }

    public void setthermCondPar3(Double [] _thermCondPar3)
    { this.thermCondPar3= _thermCondPar3; } 
    
    private Double [] thermCondPar4;
    public Double [] getthermCondPar4()
    { return thermCondPar4; }

    public void setthermCondPar4(Double [] _thermCondPar4)
    { this.thermCondPar4= _thermCondPar4; } 
    
    private Double [] thermCondPar1;
    public Double [] getthermCondPar1()
    { return thermCondPar1; }

    public void setthermCondPar1(Double [] _thermCondPar1)
    { this.thermCondPar1= _thermCondPar1; } 
    
    private double soilRoughnessHeight;
    public double getsoilRoughnessHeight()
    { return soilRoughnessHeight; }

    public void setsoilRoughnessHeight(double _soilRoughnessHeight)
    { this.soilRoughnessHeight= _soilRoughnessHeight; } 
    
    public readParam(Double [] newTemperature,Double [] soilTemp,Double [] thermCondPar2,Double [] thermCondPar3,Double [] thermCondPar4,Double [] thermCondPar1,double soilRoughnessHeight)
    {
        this.newTemperature = newTemperature;
        this.soilTemp = soilTemp;
        this.thermCondPar2 = thermCondPar2;
        this.thermCondPar3 = thermCondPar3;
        this.thermCondPar4 = thermCondPar4;
        this.thermCondPar1 = thermCondPar1;
        this.soilRoughnessHeight = soilRoughnessHeight;
    }
}final class getOtherVariables {
    private Double [] soilWater;
    public Double [] getsoilWater()
    { return soilWater; }

    public void setsoilWater(Double [] _soilWater)
    { this.soilWater= _soilWater; } 
    
    private double instrumentHeight;
    public double getinstrumentHeight()
    { return instrumentHeight; }

    public void setinstrumentHeight(double _instrumentHeight)
    { this.instrumentHeight= _instrumentHeight; } 
    
    private double canopyHeight;
    public double getcanopyHeight()
    { return canopyHeight; }

    public void setcanopyHeight(double _canopyHeight)
    { this.canopyHeight= _canopyHeight; } 
    
    public getOtherVariables(Double [] soilWater,double instrumentHeight,double canopyHeight)
    {
        this.soilWater = soilWater;
        this.instrumentHeight = instrumentHeight;
        this.canopyHeight = canopyHeight;
    }
}final class doUpdate {
    private Double [] minSoilTemp;
    public Double [] getminSoilTemp()
    { return minSoilTemp; }

    public void setminSoilTemp(Double [] _minSoilTemp)
    { this.minSoilTemp= _minSoilTemp; } 
    
    private Double [] soilTemp;
    public Double [] getsoilTemp()
    { return soilTemp; }

    public void setsoilTemp(Double [] _soilTemp)
    { this.soilTemp= _soilTemp; } 
    
    private Double [] maxSoilTemp;
    public Double [] getmaxSoilTemp()
    { return maxSoilTemp; }

    public void setmaxSoilTemp(Double [] _maxSoilTemp)
    { this.maxSoilTemp= _maxSoilTemp; } 
    
    private Double [] aveSoilTemp;
    public Double [] getaveSoilTemp()
    { return aveSoilTemp; }

    public void setaveSoilTemp(Double [] _aveSoilTemp)
    { this.aveSoilTemp= _aveSoilTemp; } 
    
    private double boundaryLayerConductance;
    public double getboundaryLayerConductance()
    { return boundaryLayerConductance; }

    public void setboundaryLayerConductance(double _boundaryLayerConductance)
    { this.boundaryLayerConductance= _boundaryLayerConductance; } 
    
    public doUpdate(Double [] minSoilTemp,Double [] soilTemp,Double [] maxSoilTemp,Double [] aveSoilTemp,double boundaryLayerConductance)
    {
        this.minSoilTemp = minSoilTemp;
        this.soilTemp = soilTemp;
        this.maxSoilTemp = maxSoilTemp;
        this.aveSoilTemp = aveSoilTemp;
        this.boundaryLayerConductance = boundaryLayerConductance;
    }
}final class doThomas {
    private Double [] newTemps;
    public Double [] getnewTemps()
    { return newTemps; }

    public void setnewTemps(Double [] _newTemps)
    { this.newTemps= _newTemps; } 
    
    private Double [] heatStorage;
    public Double [] getheatStorage()
    { return heatStorage; }

    public void setheatStorage(Double [] _heatStorage)
    { this.heatStorage= _heatStorage; } 
    
    private Double [] thermalConductance;
    public Double [] getthermalConductance()
    { return thermalConductance; }

    public void setthermalConductance(Double [] _thermalConductance)
    { this.thermalConductance= _thermalConductance; } 
    
    public doThomas(Double [] newTemps,Double [] heatStorage,Double [] thermalConductance)
    {
        this.newTemps = newTemps;
        this.heatStorage = heatStorage;
        this.thermalConductance = thermalConductance;
    }
}final class getBoundaryLayerConductance {
    private double boundaryLayerCond;
    public double getboundaryLayerCond()
    { return boundaryLayerCond; }

    public void setboundaryLayerCond(double _boundaryLayerCond)
    { this.boundaryLayerCond= _boundaryLayerCond; } 
    
    private Double [] TNew_zb;
    public Double [] getTNew_zb()
    { return TNew_zb; }

    public void setTNew_zb(Double [] _TNew_zb)
    { this.TNew_zb= _TNew_zb; } 
    
    public getBoundaryLayerConductance(double boundaryLayerCond,Double [] TNew_zb)
    {
        this.boundaryLayerCond = boundaryLayerCond;
        this.TNew_zb = TNew_zb;
    }
}final class doNetRadiation {
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
}final class doProcess {
    private Double [] minSoilTemp;
    public Double [] getminSoilTemp()
    { return minSoilTemp; }

    public void setminSoilTemp(Double [] _minSoilTemp)
    { this.minSoilTemp= _minSoilTemp; } 
    
    private Double [] maxSoilTemp;
    public Double [] getmaxSoilTemp()
    { return maxSoilTemp; }

    public void setmaxSoilTemp(Double [] _maxSoilTemp)
    { this.maxSoilTemp= _maxSoilTemp; } 
    
    private Double [] soilTemp;
    public Double [] getsoilTemp()
    { return soilTemp; }

    public void setsoilTemp(Double [] _soilTemp)
    { this.soilTemp= _soilTemp; } 
    
    private Double [] newTemperature;
    public Double [] getnewTemperature()
    { return newTemperature; }

    public void setnewTemperature(Double [] _newTemperature)
    { this.newTemperature= _newTemperature; } 
    
    private Double [] thermalConductivity;
    public Double [] getthermalConductivity()
    { return thermalConductivity; }

    public void setthermalConductivity(Double [] _thermalConductivity)
    { this.thermalConductivity= _thermalConductivity; } 
    
    private Double [] aveSoilTemp;
    public Double [] getaveSoilTemp()
    { return aveSoilTemp; }

    public void setaveSoilTemp(Double [] _aveSoilTemp)
    { this.aveSoilTemp= _aveSoilTemp; } 
    
    private Double [] morningSoilTemp;
    public Double [] getmorningSoilTemp()
    { return morningSoilTemp; }

    public void setmorningSoilTemp(Double [] _morningSoilTemp)
    { this.morningSoilTemp= _morningSoilTemp; } 
    
    private Double [] volSpecHeatSoil;
    public Double [] getvolSpecHeatSoil()
    { return volSpecHeatSoil; }

    public void setvolSpecHeatSoil(Double [] _volSpecHeatSoil)
    { this.volSpecHeatSoil= _volSpecHeatSoil; } 
    
    private Double [] heatStorage;
    public Double [] getheatStorage()
    { return heatStorage; }

    public void setheatStorage(Double [] _heatStorage)
    { this.heatStorage= _heatStorage; } 
    
    private Double [] thermalConductance;
    public Double [] getthermalConductance()
    { return thermalConductance; }

    public void setthermalConductance(Double [] _thermalConductance)
    { this.thermalConductance= _thermalConductance; } 
    
    private double timeOfDaySecs;
    public double gettimeOfDaySecs()
    { return timeOfDaySecs; }

    public void settimeOfDaySecs(double _timeOfDaySecs)
    { this.timeOfDaySecs= _timeOfDaySecs; } 
    
    private double netRadiation;
    public double getnetRadiation()
    { return netRadiation; }

    public void setnetRadiation(double _netRadiation)
    { this.netRadiation= _netRadiation; } 
    
    private double airTemperature;
    public double getairTemperature()
    { return airTemperature; }

    public void setairTemperature(double _airTemperature)
    { this.airTemperature= _airTemperature; } 
    
    private double internalTimeStep;
    public double getinternalTimeStep()
    { return internalTimeStep; }

    public void setinternalTimeStep(double _internalTimeStep)
    { this.internalTimeStep= _internalTimeStep; } 
    
    private double minTempYesterday;
    public double getminTempYesterday()
    { return minTempYesterday; }

    public void setminTempYesterday(double _minTempYesterday)
    { this.minTempYesterday= _minTempYesterday; } 
    
    private double boundaryLayerConductance;
    public double getboundaryLayerConductance()
    { return boundaryLayerConductance; }

    public void setboundaryLayerConductance(double _boundaryLayerConductance)
    { this.boundaryLayerConductance= _boundaryLayerConductance; } 
    
    private double maxTempYesterday;
    public double getmaxTempYesterday()
    { return maxTempYesterday; }

    public void setmaxTempYesterday(double _maxTempYesterday)
    { this.maxTempYesterday= _maxTempYesterday; } 
    
    public doProcess(Double [] minSoilTemp,Double [] maxSoilTemp,Double [] soilTemp,Double [] newTemperature,Double [] thermalConductivity,Double [] aveSoilTemp,Double [] morningSoilTemp,Double [] volSpecHeatSoil,Double [] heatStorage,Double [] thermalConductance,double timeOfDaySecs,double netRadiation,double airTemperature,double internalTimeStep,double minTempYesterday,double boundaryLayerConductance,double maxTempYesterday)
    {
        this.minSoilTemp = minSoilTemp;
        this.maxSoilTemp = maxSoilTemp;
        this.soilTemp = soilTemp;
        this.newTemperature = newTemperature;
        this.thermalConductivity = thermalConductivity;
        this.aveSoilTemp = aveSoilTemp;
        this.morningSoilTemp = morningSoilTemp;
        this.volSpecHeatSoil = volSpecHeatSoil;
        this.heatStorage = heatStorage;
        this.thermalConductance = thermalConductance;
        this.timeOfDaySecs = timeOfDaySecs;
        this.netRadiation = netRadiation;
        this.airTemperature = airTemperature;
        this.internalTimeStep = internalTimeStep;
        this.minTempYesterday = minTempYesterday;
        this.boundaryLayerConductance = boundaryLayerConductance;
        this.maxTempYesterday = maxTempYesterday;
    }
}