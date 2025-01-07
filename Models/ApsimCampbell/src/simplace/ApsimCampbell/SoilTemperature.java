package net.simplace.sim.components.ApsimCampbell;
import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
import net.simplace.sim.model.FWSimComponent;
import net.simplace.sim.util.FWSimVarMap;
import net.simplace.sim.util.FWSimVariable;
import net.simplace.sim.util.FWSimVariable.CONTENT_TYPE;
import net.simplace.sim.util.FWSimVariable.DATA_TYPE;
import org.jdom2.Element;


public class SoilTemperature extends FWSimComponent
{
    private FWSimVariable<Double> weather_MinT;
    private FWSimVariable<Double> weather_MaxT;
    private FWSimVariable<Double> weather_MeanT;
    private FWSimVariable<Double> weather_Tav;
    private FWSimVariable<Double> weather_Amp;
    private FWSimVariable<Double> weather_AirPressure;
    private FWSimVariable<Double> weather_Wind;
    private FWSimVariable<Double> weather_Latitude;
    private FWSimVariable<Double> weather_Radn;
    private FWSimVariable<Integer> clock_Today_DayOfYear;
    private FWSimVariable<Double> microClimate_CanopyHeight;
    private FWSimVariable<Double[]> physical_Thickness;
    private FWSimVariable<Double[]> physical_BD;
    private FWSimVariable<Double> ps;
    private FWSimVariable<Double[]> physical_Rocks;
    private FWSimVariable<Double[]> physical_ParticleSizeSand;
    private FWSimVariable<Double[]> physical_ParticleSizeSilt;
    private FWSimVariable<Double[]> physical_ParticleSizeClay;
    private FWSimVariable<Double[]> organic_Carbon;
    private FWSimVariable<Double[]> waterBalance_SW;
    private FWSimVariable<Double> waterBalance_Eos;
    private FWSimVariable<Double> waterBalance_Eo;
    private FWSimVariable<Double> waterBalance_Es;
    private FWSimVariable<Double> waterBalance_Salb;
    private FWSimVariable<Double[]> Thickness;
    private FWSimVariable<Double[]> InitialValues;
    private FWSimVariable<Double> DepthToConstantTemperature;
    private FWSimVariable<Double> timestep;
    private FWSimVariable<Double> latentHeatOfVapourisation;
    private FWSimVariable<Double> stefanBoltzmannConstant;
    private FWSimVariable<Double> airNode;
    private FWSimVariable<Integer> surfaceNode;
    private FWSimVariable<Integer> topsoilNode;
    private FWSimVariable<Integer> numPhantomNodes;
    private FWSimVariable<Double> constantBoundaryLayerConductance;
    private FWSimVariable<Integer> numIterationsForBoundaryLayerConductance;
    private FWSimVariable<Double> defaultTimeOfMaximumTemperature;
    private FWSimVariable<Double> defaultInstrumentHeight;
    private FWSimVariable<Double> bareSoilRoughness;
    private FWSimVariable<Boolean> doInitialisationStuff;
    private FWSimVariable<Double> internalTimeStep;
    private FWSimVariable<Double> timeOfDaySecs;
    private FWSimVariable<Integer> numNodes;
    private FWSimVariable<Integer> numLayers;
    private FWSimVariable<Double[]> nodeDepth;
    private FWSimVariable<Double[]> thermCondPar1;
    private FWSimVariable<Double[]> thermCondPar2;
    private FWSimVariable<Double[]> thermCondPar3;
    private FWSimVariable<Double[]> thermCondPar4;
    private FWSimVariable<Double[]> volSpecHeatSoil;
    private FWSimVariable<Double[]> soilTemp;
    private FWSimVariable<Double[]> morningSoilTemp;
    private FWSimVariable<Double[]> heatStorage;
    private FWSimVariable<Double[]> thermalConductance;
    private FWSimVariable<Double[]> thermalConductivity;
    private FWSimVariable<Double> boundaryLayerConductance;
    private FWSimVariable<Double[]> newTemperature;
    private FWSimVariable<Double> airTemperature;
    private FWSimVariable<Double> maxTempYesterday;
    private FWSimVariable<Double> minTempYesterday;
    private FWSimVariable<Double[]> soilWater;
    private FWSimVariable<Double[]> minSoilTemp;
    private FWSimVariable<Double[]> maxSoilTemp;
    private FWSimVariable<Double[]> aveSoilTemp;
    private FWSimVariable<Double[]> aveSoilWater;
    private FWSimVariable<Double[]> thickness;
    private FWSimVariable<Double[]> bulkDensity;
    private FWSimVariable<Double[]> rocks;
    private FWSimVariable<Double[]> carbon;
    private FWSimVariable<Double[]> sand;
    private FWSimVariable<Double> pom;
    private FWSimVariable<Double[]> silt;
    private FWSimVariable<Double[]> clay;
    private FWSimVariable<Double> soilRoughnessHeight;
    private FWSimVariable<Double> instrumentHeight;
    private FWSimVariable<Double> netRadiation;
    private FWSimVariable<Double> canopyHeight;
    private FWSimVariable<Double> instrumHeight;
    private FWSimVariable<Double> nu;
    private FWSimVariable<String> boundarLayerConductanceSource;
    private FWSimVariable<String> netRadiationSource;
    private FWSimVariable<Double> MissingValue;
    private FWSimVariable<String[]> soilConstituentNames;

    public SoilTemperature(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public SoilTemperature(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("weather_MinT", "Minimum temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"oC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("weather_MaxT", "Maximum temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"oC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("weather_MeanT", "Mean temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"oC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("weather_Tav", "Annual average temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"oC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("weather_Amp", "Annual average temperature amplitude", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"oC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("weather_AirPressure", "Air pressure", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"hPa", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("weather_Wind", "Wind speed", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"m/s", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("weather_Latitude", "Latitude", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"deg", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("weather_Radn", "Solar radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"MJ/m2/day", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("clock_Today_DayOfYear", "Day of year", DATA_TYPE.INT, CONTENT_TYPE.input,"day number", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("microClimate_CanopyHeight", "Canopy height", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("physical_Thickness", "Soil layer thickness", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("physical_BD", "Bulk density", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"g/cc", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("ps", "ps", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("physical_Rocks", "Rocks", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.input,"%", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("physical_ParticleSizeSand", "Particle size sand", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.input,"%", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("physical_ParticleSizeSilt", "Particle size silt", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.input,"%", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("physical_ParticleSizeClay", "Particle size clay", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.input,"%", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("organic_Carbon", "Total organic carbon", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.input,"%", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("waterBalance_SW", "Volumetric water content", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.input,"mm/mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("waterBalance_Eos", "Potential soil evaporation from soil surface", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("waterBalance_Eo", "Potential soil evapotranspiration from soil surface", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("waterBalance_Es", "Actual (realised) soil water evaporation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("waterBalance_Salb", "Fraction of incoming radiation reflected from bare soil", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"0-1", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("Thickness", "Thickness of soil layers (mm)", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("InitialValues", "Initial soil temperature", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"oC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("DepthToConstantTemperature", "Soil depth to constant temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"mm", null, null, 10000, this));
        addVariable(FWSimVariable.createSimVariable("timestep", "Internal time-step (minutes)", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"minutes", null, null, 24.0 * 60.0 * 60.0, this));
        addVariable(FWSimVariable.createSimVariable("latentHeatOfVapourisation", "Latent heat of vapourisation for water", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"miJ/kg", null, null, 2465000, this));
        addVariable(FWSimVariable.createSimVariable("stefanBoltzmannConstant", "The Stefan-Boltzmann constant", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"W/m2/K4", null, null, 0.0000000567, this));
        addVariable(FWSimVariable.createSimVariable("airNode", "The index of the node in the atmosphere (aboveground)", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", null, null, 0, this));
        addVariable(FWSimVariable.createSimVariable("surfaceNode", "The index of the node on the soil surface (depth = 0)", DATA_TYPE.INT, CONTENT_TYPE.constant,"", null, null, 1, this));
        addVariable(FWSimVariable.createSimVariable("topsoilNode", "The index of the first node within the soil (top layer)", DATA_TYPE.INT, CONTENT_TYPE.constant,"", null, null, 2, this));
        addVariable(FWSimVariable.createSimVariable("numPhantomNodes", "The number of phantom nodes below the soil profile", DATA_TYPE.INT, CONTENT_TYPE.constant,"", null, null, 5, this));
        addVariable(FWSimVariable.createSimVariable("constantBoundaryLayerConductance", "Boundary layer conductance, if constant", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"K/W", null, null, 20, this));
        addVariable(FWSimVariable.createSimVariable("numIterationsForBoundaryLayerConductance", "Number of iterations to calculate atmosphere boundary layer conductance", DATA_TYPE.INT, CONTENT_TYPE.constant,"", null, null, 1, this));
        addVariable(FWSimVariable.createSimVariable("defaultTimeOfMaximumTemperature", "Time of maximum temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"minutes", null, null, 14.0, this));
        addVariable(FWSimVariable.createSimVariable("defaultInstrumentHeight", "Default instrument height", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"m", null, null, 1.2, this));
        addVariable(FWSimVariable.createSimVariable("bareSoilRoughness", "Roughness element height of bare soil", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"mm", null, null, 57, this));
        addVariable(FWSimVariable.createSimVariable("doInitialisationStuff", "Flag whether initialisation is needed", DATA_TYPE.BOOLEAN, CONTENT_TYPE.state,"mintes", null, null, false, this));
        addVariable(FWSimVariable.createSimVariable("internalTimeStep", "Internal time-step", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"sec", null, null, 0, this));
        addVariable(FWSimVariable.createSimVariable("timeOfDaySecs", "Time of day from midnight", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"sec", null, null, 0, this));
        addVariable(FWSimVariable.createSimVariable("numNodes", "Number of nodes over the soil profile", DATA_TYPE.INT, CONTENT_TYPE.state,"", null, null, 0, this));
        addVariable(FWSimVariable.createSimVariable("numLayers", "Number of layers in the soil profile", DATA_TYPE.INT, CONTENT_TYPE.state,"", null, null, 0, this));
        addVariable(FWSimVariable.createSimVariable("nodeDepth", "Depths of nodes", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thermCondPar1", "Parameter 1 for computing thermal conductivity of soil solids", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thermCondPar2", "Parameter 2 for computing thermal conductivity of soil solids", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thermCondPar3", "Parameter 3 for computing thermal conductivity of soil solids", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thermCondPar4", "Parameter 4 for computing thermal conductivity of soil solids", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("volSpecHeatSoil", "Volumetric specific heat over the soil profile", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"J/K/m3", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("soilTemp", "Soil temperature over the soil profile at morning", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"oC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("morningSoilTemp", "Soil temperature over the soil profile at morning", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"oC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("heatStorage", "CP, heat storage between nodes", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"J/K", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thermalConductance", "K, conductance of element between nodes", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"W/K", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thermalConductivity", "Thermal conductivity", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"W.m/K", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("boundaryLayerConductance", "Average daily atmosphere boundary layer conductance", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"", null, null, 0, this));
        addVariable(FWSimVariable.createSimVariable("newTemperature", "Soil temperature at the end of this iteration", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"oC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("airTemperature", "Air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"oC", null, null, 0, this));
        addVariable(FWSimVariable.createSimVariable("maxTempYesterday", "Yesterday's maximum daily air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"oC", null, null, 0, this));
        addVariable(FWSimVariable.createSimVariable("minTempYesterday", "Yesterday's minimum daily air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"oC", null, null, 0, this));
        addVariable(FWSimVariable.createSimVariable("soilWater", "Volumetric water content of each soil layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"mm3/mm3", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("minSoilTemp", "Minimum soil temperature", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"oC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("maxSoilTemp", "Maximum soil temperature", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"oC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("aveSoilTemp", "average soil temperature", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"oC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("aveSoilWater", "Average soil temperaturer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"oC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thickness", "Thickness of each soil, includes phantom layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("bulkDensity", "Soil bulk density, includes phantom layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"g/cm3", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("rocks", "Volumetric fraction of rocks in each soil laye", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"%", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("carbon", "Volumetric fraction of carbon (CHECK, OM?) in each soil layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"%", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("sand", "Volumetric fraction of sand in each soil layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"%", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("pom", "Particle density of organic matter", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"Mg/m3", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("silt", "Volumetric fraction of silt in each soil layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"%", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("clay", "Volumetric fraction of clay in each soil layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"%", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("soilRoughnessHeight", "Height of soil roughness", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"mm", null, null, 0, this));
        addVariable(FWSimVariable.createSimVariable("instrumentHeight", "Height of instruments above soil surface", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"mm", null, null, 0, this));
        addVariable(FWSimVariable.createSimVariable("netRadiation", "Net radiation per internal time-step", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"MJ", null, null, 0, this));
        addVariable(FWSimVariable.createSimVariable("canopyHeight", "Height of canopy above ground", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"mm", null, null, 0, this));
        addVariable(FWSimVariable.createSimVariable("instrumHeight", "Height of instruments above ground", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"mm", null, null, 0, this));
        addVariable(FWSimVariable.createSimVariable("nu", "Forward/backward differencing coefficient", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"0-1", null, null, 0.6, this));
        addVariable(FWSimVariable.createSimVariable("boundarLayerConductanceSource", "Flag whether boundary layer conductance is calculated or gotten from inpu", DATA_TYPE.CHAR, CONTENT_TYPE.constant,"", null, null, "calc", this));
        addVariable(FWSimVariable.createSimVariable("netRadiationSource", "Flag whether net radiation is calculated or gotten from input", DATA_TYPE.CHAR, CONTENT_TYPE.constant,"m", null, null, "calc", this));
        addVariable(FWSimVariable.createSimVariable("MissingValue", "missing value", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"m", null, null, 99999, this));
        addVariable(FWSimVariable.createSimVariable("soilConstituentNames", "soilConstituentNames", DATA_TYPE.CHARARRAY, CONTENT_TYPE.constant,"m", null, null, new String[] {"Rocks","OrganicMatter","Sand","Silt","Clay","Water","Ice","Air"}, this));

        return iFieldMap;
    }
    @Override
    protected void init()
    {
        getProfileVariables zz_getProfileVariables;
        readParam zz_readParam;
        double t_weather_MinT = weather_MinT.getValue();
        double t_weather_MaxT = weather_MaxT.getValue();
        double t_weather_MeanT = weather_MeanT.getValue();
        double t_weather_Tav = weather_Tav.getValue();
        double t_weather_Amp = weather_Amp.getValue();
        double t_weather_AirPressure = weather_AirPressure.getValue();
        double t_weather_Wind = weather_Wind.getValue();
        double t_weather_Latitude = weather_Latitude.getValue();
        double t_weather_Radn = weather_Radn.getValue();
        Integer t_clock_Today_DayOfYear = clock_Today_DayOfYear.getValue();
        double t_microClimate_CanopyHeight = microClimate_CanopyHeight.getValue();
        Double [] t_physical_Thickness = physical_Thickness.getValue();
        Double [] t_physical_BD = physical_BD.getValue();
        double t_ps = ps.getValue();
        Double [] t_physical_Rocks = physical_Rocks.getValue();
        Double [] t_physical_ParticleSizeSand = physical_ParticleSizeSand.getValue();
        Double [] t_physical_ParticleSizeSilt = physical_ParticleSizeSilt.getValue();
        Double [] t_physical_ParticleSizeClay = physical_ParticleSizeClay.getValue();
        Double [] t_organic_Carbon = organic_Carbon.getValue();
        Double [] t_waterBalance_SW = waterBalance_SW.getValue();
        double t_waterBalance_Eos = waterBalance_Eos.getValue();
        double t_waterBalance_Eo = waterBalance_Eo.getValue();
        double t_waterBalance_Es = waterBalance_Es.getValue();
        double t_waterBalance_Salb = waterBalance_Salb.getValue();
        Double [] t_Thickness = Thickness.getValue();
        Double [] t_InitialValues = InitialValues.getValue();
        double t_DepthToConstantTemperature = DepthToConstantTemperature.getValue();
        double t_timestep = timestep.getValue();
        double t_latentHeatOfVapourisation = latentHeatOfVapourisation.getValue();
        double t_stefanBoltzmannConstant = stefanBoltzmannConstant.getValue();
        double t_airNode = airNode.getValue();
        Integer t_surfaceNode = surfaceNode.getValue();
        Integer t_topsoilNode = topsoilNode.getValue();
        Integer t_numPhantomNodes = numPhantomNodes.getValue();
        double t_constantBoundaryLayerConductance = constantBoundaryLayerConductance.getValue();
        Integer t_numIterationsForBoundaryLayerConductance = numIterationsForBoundaryLayerConductance.getValue();
        double t_defaultTimeOfMaximumTemperature = defaultTimeOfMaximumTemperature.getValue();
        double t_defaultInstrumentHeight = defaultInstrumentHeight.getValue();
        double t_bareSoilRoughness = bareSoilRoughness.getValue();
        double t_pom = pom.getValue();
        double t_nu = nu.getValue();
        String t_boundarLayerConductanceSource = boundarLayerConductanceSource.getValue();
        String t_netRadiationSource = netRadiationSource.getValue();
        double t_MissingValue = MissingValue.getValue();
        String [] t_soilConstituentNames = soilConstituentNames.getValue();
        Boolean t_doInitialisationStuff = doInitialisationStuff.getDefault();
        double t_internalTimeStep = internalTimeStep.getDefault();
        double t_timeOfDaySecs = timeOfDaySecs.getDefault();
        Integer t_numNodes = numNodes.getDefault();
        Integer t_numLayers = numLayers.getDefault();
        Double [] t_volSpecHeatSoil = volSpecHeatSoil.getValue();
        Double [] t_soilTemp = soilTemp.getValue();
        Double [] t_morningSoilTemp = morningSoilTemp.getValue();
        Double [] t_heatStorage = heatStorage.getValue();
        Double [] t_thermalConductance = thermalConductance.getValue();
        Double [] t_thermalConductivity = thermalConductivity.getValue();
        double t_boundaryLayerConductance = boundaryLayerConductance.getDefault();
        Double [] t_newTemperature = newTemperature.getValue();
        double t_airTemperature = airTemperature.getDefault();
        double t_maxTempYesterday = maxTempYesterday.getDefault();
        double t_minTempYesterday = minTempYesterday.getDefault();
        Double [] t_soilWater = soilWater.getValue();
        Double [] t_minSoilTemp = minSoilTemp.getValue();
        Double [] t_maxSoilTemp = maxSoilTemp.getValue();
        Double [] t_aveSoilTemp = aveSoilTemp.getValue();
        Double [] t_aveSoilWater = aveSoilWater.getValue();
        Double [] t_thickness = thickness.getValue();
        Double [] t_bulkDensity = bulkDensity.getValue();
        Double [] t_rocks = rocks.getValue();
        Double [] t_carbon = carbon.getValue();
        Double [] t_sand = sand.getValue();
        Double [] t_silt = silt.getValue();
        Double [] t_clay = clay.getValue();
        double t_instrumentHeight = instrumentHeight.getDefault();
        double t_netRadiation = netRadiation.getDefault();
        double t_canopyHeight = canopyHeight.getDefault();
        double t_instrumHeight = instrumHeight.getDefault();
        t_doInitialisationStuff = true;
        t_instrumentHeight = getIniVariables(t_instrumHeight, t_defaultInstrumentHeight, t_instrumentHeight);
        zz_getProfileVariables = Calculate_getProfileVariables(t_maxSoilTemp, t_minSoilTemp, t_topsoilNode, t_thermalConductance, t_physical_BD, t_soilTemp, t_carbon, t_physical_ParticleSizeSand, t_physical_Thickness, t_newTemperature, t_heatStorage, t_numPhantomNodes, t_soilWater, t_nodeDepth, t_volSpecHeatSoil, t_aveSoilTemp, t_surfaceNode, t_rocks, t_physical_Rocks, t_physical_ParticleSizeSilt, t_thermalConductivity, t_silt, t_sand, t_numNodes, t_organic_Carbon, t_morningSoilTemp, t_DepthToConstantTemperature, t_clay, t_thickness, t_bulkDensity, t_waterBalance_SW, t_airNode, t_physical_ParticleSizeClay, t_numLayers, t_MissingValue);
        t_maxSoilTemp = zz_getProfileVariables.getmaxSoilTemp();
        t_minSoilTemp = zz_getProfileVariables.getminSoilTemp();
        t_thermalConductance = zz_getProfileVariables.getthermalConductance();
        t_soilTemp = zz_getProfileVariables.getsoilTemp();
        t_carbon = zz_getProfileVariables.getcarbon();
        t_newTemperature = zz_getProfileVariables.getnewTemperature();
        t_heatStorage = zz_getProfileVariables.getheatStorage();
        t_soilWater = zz_getProfileVariables.getsoilWater();
        t_nodeDepth = zz_getProfileVariables.getnodeDepth();
        t_volSpecHeatSoil = zz_getProfileVariables.getvolSpecHeatSoil();
        t_aveSoilTemp = zz_getProfileVariables.getaveSoilTemp();
        t_rocks = zz_getProfileVariables.getrocks();
        t_thermalConductivity = zz_getProfileVariables.getthermalConductivity();
        t_silt = zz_getProfileVariables.getsilt();
        t_sand = zz_getProfileVariables.getsand();
        t_morningSoilTemp = zz_getProfileVariables.getmorningSoilTemp();
        t_clay = zz_getProfileVariables.getclay();
        t_thickness = zz_getProfileVariables.getthickness();
        t_bulkDensity = zz_getProfileVariables.getbulkDensity();
        t_numNodes = zz_getProfileVariables.getnumNodes();
        t_numLayers = zz_getProfileVariables.getnumLayers();
        zz_readParam = Calculate_readParam(t_soilTemp, t_soilRoughnessHeight, t_newTemperature, t_bareSoilRoughness, t_thermCondPar2, t_thermCondPar3, t_thermCondPar4, t_bulkDensity, t_thermCondPar1, t_numNodes, t_clay, t_numLayers, t_weather_Latitude, t_weather_Amp, t_clock_Today_DayOfYear, t_weather_Tav, t_surfaceNode, t_thickness);
        t_soilTemp = zz_readParam.getsoilTemp();
        t_newTemperature = zz_readParam.getnewTemperature();
        t_thermCondPar2 = zz_readParam.getthermCondPar2();
        t_thermCondPar3 = zz_readParam.getthermCondPar3();
        t_thermCondPar4 = zz_readParam.getthermCondPar4();
        t_thermCondPar1 = zz_readParam.getthermCondPar1();
        t_soilRoughnessHeight = zz_readParam.getsoilRoughnessHeight();
        nodeDepth.setValue(t_nodeDepth, this);
        thermCondPar1.setValue(t_thermCondPar1, this);
        thermCondPar2.setValue(t_thermCondPar2, this);
        thermCondPar3.setValue(t_thermCondPar3, this);
        thermCondPar4.setValue(t_thermCondPar4, this);
        soilRoughnessHeight.setValue(t_soilRoughnessHeight, this);
        doInitialisationStuff.setValue(t_doInitialisationStuff, this);
        internalTimeStep.setValue(t_internalTimeStep, this);
        timeOfDaySecs.setValue(t_timeOfDaySecs, this);
        numNodes.setValue(t_numNodes, this);
        numLayers.setValue(t_numLayers, this);
        volSpecHeatSoil.setValue(t_volSpecHeatSoil, this);
        soilTemp.setValue(t_soilTemp, this);
        morningSoilTemp.setValue(t_morningSoilTemp, this);
        heatStorage.setValue(t_heatStorage, this);
        thermalConductance.setValue(t_thermalConductance, this);
        thermalConductivity.setValue(t_thermalConductivity, this);
        boundaryLayerConductance.setValue(t_boundaryLayerConductance, this);
        newTemperature.setValue(t_newTemperature, this);
        airTemperature.setValue(t_airTemperature, this);
        maxTempYesterday.setValue(t_maxTempYesterday, this);
        minTempYesterday.setValue(t_minTempYesterday, this);
        soilWater.setValue(t_soilWater, this);
        minSoilTemp.setValue(t_minSoilTemp, this);
        maxSoilTemp.setValue(t_maxSoilTemp, this);
        aveSoilTemp.setValue(t_aveSoilTemp, this);
        aveSoilWater.setValue(t_aveSoilWater, this);
        thickness.setValue(t_thickness, this);
        bulkDensity.setValue(t_bulkDensity, this);
        rocks.setValue(t_rocks, this);
        carbon.setValue(t_carbon, this);
        sand.setValue(t_sand, this);
        silt.setValue(t_silt, this);
        clay.setValue(t_clay, this);
        instrumentHeight.setValue(t_instrumentHeight, this);
        netRadiation.setValue(t_netRadiation, this);
        canopyHeight.setValue(t_canopyHeight, this);
        instrumHeight.setValue(t_instrumHeight, this);
    }
    @Override
    protected void process()
    {
        getOtherVariables zz_getOtherVariables;
        doProcess zz_doProcess;
        double t_weather_MinT = weather_MinT.getValue();
        double t_weather_MaxT = weather_MaxT.getValue();
        double t_weather_MeanT = weather_MeanT.getValue();
        double t_weather_Tav = weather_Tav.getValue();
        double t_weather_Amp = weather_Amp.getValue();
        double t_weather_AirPressure = weather_AirPressure.getValue();
        double t_weather_Wind = weather_Wind.getValue();
        double t_weather_Latitude = weather_Latitude.getValue();
        double t_weather_Radn = weather_Radn.getValue();
        Integer t_clock_Today_DayOfYear = clock_Today_DayOfYear.getValue();
        double t_microClimate_CanopyHeight = microClimate_CanopyHeight.getValue();
        Double [] t_physical_Thickness = physical_Thickness.getValue();
        Double [] t_physical_BD = physical_BD.getValue();
        double t_ps = ps.getValue();
        Double [] t_physical_Rocks = physical_Rocks.getValue();
        Double [] t_physical_ParticleSizeSand = physical_ParticleSizeSand.getValue();
        Double [] t_physical_ParticleSizeSilt = physical_ParticleSizeSilt.getValue();
        Double [] t_physical_ParticleSizeClay = physical_ParticleSizeClay.getValue();
        Double [] t_organic_Carbon = organic_Carbon.getValue();
        Double [] t_waterBalance_SW = waterBalance_SW.getValue();
        double t_waterBalance_Eos = waterBalance_Eos.getValue();
        double t_waterBalance_Eo = waterBalance_Eo.getValue();
        double t_waterBalance_Es = waterBalance_Es.getValue();
        double t_waterBalance_Salb = waterBalance_Salb.getValue();
        Double [] t_Thickness = Thickness.getValue();
        Double [] t_InitialValues = InitialValues.getValue();
        double t_DepthToConstantTemperature = DepthToConstantTemperature.getValue();
        double t_timestep = timestep.getValue();
        double t_latentHeatOfVapourisation = latentHeatOfVapourisation.getValue();
        double t_stefanBoltzmannConstant = stefanBoltzmannConstant.getValue();
        double t_airNode = airNode.getValue();
        Integer t_surfaceNode = surfaceNode.getValue();
        Integer t_topsoilNode = topsoilNode.getValue();
        Integer t_numPhantomNodes = numPhantomNodes.getValue();
        double t_constantBoundaryLayerConductance = constantBoundaryLayerConductance.getValue();
        Integer t_numIterationsForBoundaryLayerConductance = numIterationsForBoundaryLayerConductance.getValue();
        double t_defaultTimeOfMaximumTemperature = defaultTimeOfMaximumTemperature.getValue();
        double t_defaultInstrumentHeight = defaultInstrumentHeight.getValue();
        double t_bareSoilRoughness = bareSoilRoughness.getValue();
        Boolean t_doInitialisationStuff = doInitialisationStuff.getValue();
        double t_internalTimeStep = internalTimeStep.getValue();
        double t_timeOfDaySecs = timeOfDaySecs.getValue();
        Integer t_numNodes = numNodes.getValue();
        Integer t_numLayers = numLayers.getValue();
        Double [] t_nodeDepth = nodeDepth.getValue();
        Double [] t_thermCondPar1 = thermCondPar1.getValue();
        Double [] t_thermCondPar2 = thermCondPar2.getValue();
        Double [] t_thermCondPar3 = thermCondPar3.getValue();
        Double [] t_thermCondPar4 = thermCondPar4.getValue();
        Double [] t_volSpecHeatSoil = volSpecHeatSoil.getValue();
        Double [] t_soilTemp = soilTemp.getValue();
        Double [] t_morningSoilTemp = morningSoilTemp.getValue();
        Double [] t_heatStorage = heatStorage.getValue();
        Double [] t_thermalConductance = thermalConductance.getValue();
        Double [] t_thermalConductivity = thermalConductivity.getValue();
        double t_boundaryLayerConductance = boundaryLayerConductance.getValue();
        Double [] t_newTemperature = newTemperature.getValue();
        double t_airTemperature = airTemperature.getValue();
        double t_maxTempYesterday = maxTempYesterday.getValue();
        double t_minTempYesterday = minTempYesterday.getValue();
        Double [] t_soilWater = soilWater.getValue();
        Double [] t_minSoilTemp = minSoilTemp.getValue();
        Double [] t_maxSoilTemp = maxSoilTemp.getValue();
        Double [] t_aveSoilTemp = aveSoilTemp.getValue();
        Double [] t_aveSoilWater = aveSoilWater.getValue();
        Double [] t_thickness = thickness.getValue();
        Double [] t_bulkDensity = bulkDensity.getValue();
        Double [] t_rocks = rocks.getValue();
        Double [] t_carbon = carbon.getValue();
        Double [] t_sand = sand.getValue();
        double t_pom = pom.getValue();
        Double [] t_silt = silt.getValue();
        Double [] t_clay = clay.getValue();
        double t_soilRoughnessHeight = soilRoughnessHeight.getValue();
        double t_instrumentHeight = instrumentHeight.getValue();
        double t_netRadiation = netRadiation.getValue();
        double t_canopyHeight = canopyHeight.getValue();
        double t_instrumHeight = instrumHeight.getValue();
        double t_nu = nu.getValue();
        String t_boundarLayerConductanceSource = boundarLayerConductanceSource.getValue();
        String t_netRadiationSource = netRadiationSource.getValue();
        double t_MissingValue = MissingValue.getValue();
        String [] t_soilConstituentNames = soilConstituentNames.getValue();
        Integer i;
        zz_getOtherVariables = Calculate_getOtherVariables(t_soilWater, t_instrumentHeight, t_microClimate_CanopyHeight, t_waterBalance_SW, t_numNodes, t_canopyHeight, t_soilRoughnessHeight, t_numLayers);
        t_soilWater = zz_getOtherVariables.getsoilWater();
        t_canopyHeight = zz_getOtherVariables.getcanopyHeight();
        t_instrumentHeight = zz_getOtherVariables.getinstrumentHeight();
        if (t_doInitialisationStuff)
        {
            if (ValuesInArray(t_InitialValues, t_MissingValue))
            {
                Arrays.fill(t_soilTemp, 0.0d);
                t_soilTemp[t_topsoilNode:t_topsoilNode + t_InitialValues.length] = t_InitialValues[0:0 + t_InitialValues.length];
            }
            else
            {
                t_soilTemp = calcSoilTemperature(t_soilTemp, t_weather_Latitude, t_weather_Amp, t_numNodes, t_clock_Today_DayOfYear, t_weather_Tav, t_surfaceNode, t_thickness);
                Arrays.fill(t_InitialValues, 0.0d);
                t_InitialValues[0:0 + t_numLayers] = t_soilTemp[t_topsoilNode:t_topsoilNode + t_numLayers];
            }
            t_soilTemp[t_airNode] = t_weather_MeanT;
            t_soilTemp[t_surfaceNode] = calcSurfaceTemperature(t_waterBalance_Salb, t_weather_MeanT, t_weather_Radn, t_weather_MaxT);
            for (i=t_numNodes + 1 ; i!=t_soilTemp.length ; i+=1)
            {
                t_soilTemp[i] = t_weather_Tav;
            }
            t_newTemperature[0:0 + t_soilTemp.length] = t_soilTemp;
            t_maxTempYesterday = t_weather_MaxT;
            t_minTempYesterday = t_weather_MinT;
            t_doInitialisationStuff = false;
        }
        zz_doProcess = Calculate_doProcess(t_maxSoilTemp, t_minSoilTemp, t_weather_MaxT, t_numIterationsForBoundaryLayerConductance, t_maxTempYesterday, t_thermalConductivity, t_timeOfDaySecs, t_soilTemp, t_weather_MeanT, t_morningSoilTemp, t_newTemperature, t_boundaryLayerConductance, t_constantBoundaryLayerConductance, t_airTemperature, t_timestep, t_weather_MinT, t_airNode, t_netRadiation, t_aveSoilTemp, t_minTempYesterday, t_internalTimeStep, t_boundarLayerConductanceSource, t_clock_Today_DayOfYear, t_weather_Latitude, t_weather_Radn, t_soilConstituentNames, t_soilWater, t_volSpecHeatSoil, t_numNodes, t_nodeDepth, t_surfaceNode, t_thickness, t_MissingValue, t_bulkDensity, t_carbon, t_pom, t_rocks, t_ps, t_sand, t_silt, t_clay, t_defaultTimeOfMaximumTemperature, t_waterBalance_Eo, t_waterBalance_Eos, t_waterBalance_Salb, t_stefanBoltzmannConstant, t_weather_AirPressure, t_instrumentHeight, t_weather_Wind, t_canopyHeight, t_netRadiationSource, t_thermalConductance, t_waterBalance_Es, t_heatStorage, t_latentHeatOfVapourisation, t_nu);
        t_maxSoilTemp = zz_doProcess.getmaxSoilTemp();
        t_minSoilTemp = zz_doProcess.getminSoilTemp();
        t_thermalConductivity = zz_doProcess.getthermalConductivity();
        t_soilTemp = zz_doProcess.getsoilTemp();
        t_morningSoilTemp = zz_doProcess.getmorningSoilTemp();
        t_newTemperature = zz_doProcess.getnewTemperature();
        t_aveSoilTemp = zz_doProcess.getaveSoilTemp();
        t_volSpecHeatSoil = zz_doProcess.getvolSpecHeatSoil();
        t_thermalConductance = zz_doProcess.getthermalConductance();
        t_heatStorage = zz_doProcess.getheatStorage();
        t_timeOfDaySecs = zz_doProcess.gettimeOfDaySecs();
        t_boundaryLayerConductance = zz_doProcess.getboundaryLayerConductance();
        t_minTempYesterday = zz_doProcess.getminTempYesterday();
        t_maxTempYesterday = zz_doProcess.getmaxTempYesterday();
        t_airTemperature = zz_doProcess.getairTemperature();
        t_netRadiation = zz_doProcess.getnetRadiation();
        t_internalTimeStep = zz_doProcess.getinternalTimeStep();
        doInitialisationStuff.setValue(t_doInitialisationStuff, this);
        volSpecHeatSoil.setValue(t_volSpecHeatSoil, this);
        soilTemp.setValue(t_soilTemp, this);
        morningSoilTemp.setValue(t_morningSoilTemp, this);
        heatStorage.setValue(t_heatStorage, this);
        thermalConductance.setValue(t_thermalConductance, this);
        thermalConductivity.setValue(t_thermalConductivity, this);
        boundaryLayerConductance.setValue(t_boundaryLayerConductance, this);
        newTemperature.setValue(t_newTemperature, this);
        maxTempYesterday.setValue(t_maxTempYesterday, this);
        minTempYesterday.setValue(t_minTempYesterday, this);
        soilWater.setValue(t_soilWater, this);
        minSoilTemp.setValue(t_minSoilTemp, this);
        maxSoilTemp.setValue(t_maxSoilTemp, this);
        aveSoilTemp.setValue(t_aveSoilTemp, this);
        instrumentHeight.setValue(t_instrumentHeight, this);
    }
    public static double getIniVariables(double t_instrumHeight, double t_defaultInstrumentHeight, double t_instrumentHeight)
    {
        if (t_instrumHeight > 0.00001d)
        {
            t_instrumentHeight = t_instrumHeight;
        }
        else
        {
            t_instrumentHeight = t_defaultInstrumentHeight;
        }
        return t_instrumentHeight;
    }
    public getProfileVariables Calculate_getProfileVariables (Double [] t_maxSoilTemp, Double [] t_minSoilTemp, Integer t_topsoilNode, Double [] t_thermalConductance, Double [] t_physical_BD, Double [] t_soilTemp, Double [] t_carbon, Double [] t_physical_ParticleSizeSand, Double [] t_physical_Thickness, Double [] t_newTemperature, Double [] t_heatStorage, Integer t_numPhantomNodes, Double [] t_soilWater, Double [] t_nodeDepth, Double [] t_volSpecHeatSoil, Double [] t_aveSoilTemp, Integer t_surfaceNode, Double [] t_rocks, Double [] t_physical_Rocks, Double [] t_physical_ParticleSizeSilt, Double [] t_thermalConductivity, Double [] t_silt, Double [] t_sand, Integer t_numNodes, Double [] t_organic_Carbon, Double [] t_morningSoilTemp, double t_DepthToConstantTemperature, Double [] t_clay, Double [] t_thickness, Double [] t_bulkDensity, Double [] t_waterBalance_SW, double t_airNode, Double [] t_physical_ParticleSizeClay, Integer t_numLayers, double t_MissingValue)
    {
        Integer layer;
        Integer node;
        Integer i;
        double belowProfileDepth;
        double thicknessForPhantomNodes;
        Integer firstPhantomNode;
        Double[] oldDepth;
        Double[] oldBulkDensity;
        Double[] oldSoilWater;
        t_numLayers = t_physical_Thickness.length;
        t_numNodes = t_numLayers + t_numPhantomNodes;
        Arrays.fill(t_thickness, 0.0d);
        t_thickness[1:1 + t_physical_Thickness.length] = t_physical_Thickness;
        belowProfileDepth = Math.max(t_DepthToConstantTemperature - Sum(t_thickness, 1, t_numLayers, t_MissingValue), 1000.0d);
        thicknessForPhantomNodes = belowProfileDepth * 2.0d / t_numPhantomNodes;
        firstPhantomNode = t_numLayers;
        for (i=firstPhantomNode ; i!=firstPhantomNode + t_numPhantomNodes ; i+=1)
        {
            t_thickness[i] = thicknessForPhantomNodes;
        }
        oldDepth = t_nodeDepth;
        Arrays.fill(t_nodeDepth, 0.0d);
        if (oldDepth != )
        {
            t_nodeDepth[0:Math.min(t_numNodes + 1 + 1, oldDepth.length)] = oldDepth[0:Math.min(t_numNodes + 1 + 1, oldDepth.length)];
        }
        t_nodeDepth[t_airNode] = 0.0d;
        t_nodeDepth[t_surfaceNode] = 0.0d;
        t_nodeDepth[t_topsoilNode] = 0.5d * t_thickness[1] / 1000.0d;
        for (node=t_topsoilNode ; node!=t_numNodes + 1 ; node+=1)
        {
            t_nodeDepth[node + 1] = (Sum(t_thickness, 1, node - 1, t_MissingValue) + (0.5d * t_thickness[node])) / 1000.0d;
        }
        oldBulkDensity = t_bulkDensity;
        Arrays.fill(t_bulkDensity, 0.0d);
        if (oldBulkDensity != )
        {
            t_bulkDensity[0:Math.min(t_numLayers + 1 + t_numPhantomNodes, oldBulkDensity.length)] = oldBulkDensity[0:Math.min(t_numLayers + 1 + t_numPhantomNodes, oldBulkDensity.length)];
        }
        t_bulkDensity[1:1 + t_physical_BD.length] = t_physical_BD;
        t_bulkDensity[t_numNodes] = t_bulkDensity[t_numLayers];
        for (layer=t_numLayers + 1 ; layer!=t_numLayers + t_numPhantomNodes + 1 ; layer+=1)
        {
            t_bulkDensity[layer] = t_bulkDensity[t_numLayers];
        }
        oldSoilWater = t_soilWater;
        Arrays.fill(t_soilWater, 0.0d);
        if (oldSoilWater != )
        {
            t_soilWater[0:Math.min(t_numLayers + 1 + t_numPhantomNodes, oldSoilWater.length)] = oldSoilWater[0:Math.min(t_numLayers + 1 + t_numPhantomNodes, oldSoilWater.length)];
        }
        if (t_waterBalance_SW != )
        {
            for (layer=1 ; layer!=t_numLayers + 1 ; layer+=1)
            {
                t_soilWater[layer] = Divide(t_waterBalance_SW[(layer - 1)] * t_thickness[(layer - 1)], t_thickness[layer], 0);
            }
            for (layer=t_numLayers + 1 ; layer!=t_numLayers + t_numPhantomNodes + 1 ; layer+=1)
            {
                t_soilWater[layer] = t_soilWater[t_numLayers];
            }
        }
        Arrays.fill(t_carbon, 0.0d);
        for (layer=1 ; layer!=t_numLayers + 1 ; layer+=1)
        {
            t_carbon[layer] = t_organic_Carbon[layer - 1];
        }
        for (layer=t_numLayers + 1 ; layer!=t_numLayers + t_numPhantomNodes + 1 ; layer+=1)
        {
            t_carbon[layer] = t_carbon[t_numLayers];
        }
        Arrays.fill(t_rocks, 0.0d);
        for (layer=1 ; layer!=t_numLayers + 1 ; layer+=1)
        {
            t_rocks[layer] = t_physical_Rocks[layer - 1];
        }
        for (layer=t_numLayers + 1 ; layer!=t_numLayers + t_numPhantomNodes + 1 ; layer+=1)
        {
            t_rocks[layer] = t_rocks[t_numLayers];
        }
        Arrays.fill(t_sand, 0.0d);
        for (layer=1 ; layer!=t_numLayers + 1 ; layer+=1)
        {
            t_sand[layer] = t_physical_ParticleSizeSand[layer - 1];
        }
        for (layer=t_numLayers + 1 ; layer!=t_numLayers + t_numPhantomNodes + 1 ; layer+=1)
        {
            t_sand[layer] = t_sand[t_numLayers];
        }
        Arrays.fill(t_silt, 0.0d);
        for (layer=1 ; layer!=t_numLayers + 1 ; layer+=1)
        {
            t_silt[layer] = t_physical_ParticleSizeSilt[layer - 1];
        }
        for (layer=t_numLayers + 1 ; layer!=t_numLayers + t_numPhantomNodes + 1 ; layer+=1)
        {
            t_silt[layer] = t_silt[t_numLayers];
        }
        Arrays.fill(t_clay, 0.0d);
        for (layer=1 ; layer!=t_numLayers + 1 ; layer+=1)
        {
            t_clay[layer] = t_physical_ParticleSizeClay[layer - 1];
        }
        for (layer=t_numLayers + 1 ; layer!=t_numLayers + t_numPhantomNodes + 1 ; layer+=1)
        {
            t_clay[layer] = t_clay[t_numLayers];
        }
        Arrays.fill(t_maxSoilTemp, 0.0d);
        Arrays.fill(t_minSoilTemp, 0.0d);
        Arrays.fill(t_aveSoilTemp, 0.0d);
        Arrays.fill(t_volSpecHeatSoil, 0.0d);
        Arrays.fill(t_soilTemp, 0.0d);
        Arrays.fill(t_morningSoilTemp, 0.0d);
        Arrays.fill(t_newTemperature, 0.0d);
        Arrays.fill(t_thermalConductivity, 0.0d);
        Arrays.fill(t_heatStorage, 0.0d);
        Arrays.fill(t_thermalConductance, 0.0d);
        return new getProfileVariables(t_maxSoilTemp, t_minSoilTemp, t_thermalConductance, t_soilTemp, t_carbon, t_newTemperature, t_heatStorage, t_soilWater, t_nodeDepth, t_volSpecHeatSoil, t_aveSoilTemp, t_rocks, t_thermalConductivity, t_silt, t_sand, t_morningSoilTemp, t_clay, t_thickness, t_bulkDensity, t_numNodes, t_numLayers);
    }
    public doThermalConductivityCoeffs Calculate_doThermalConductivityCoeffs (Double [] t_thermCondPar2, Double [] t_thermCondPar3, Double [] t_thermCondPar4, Double [] t_bulkDensity, Double [] t_thermCondPar1, Integer t_numNodes, Double [] t_clay, Integer t_numLayers)
    {
        Integer layer;
        Double[] oldGC1;
        Double[] oldGC2;
        Double[] oldGC3;
        Double[] oldGC4;
        Integer element;
        oldGC1 = t_thermCondPar1;
        Arrays.fill(t_thermCondPar1, 0.0d);
        if (oldGC1 != )
        {
            t_thermCondPar1[0:Math.min(t_numNodes + 1, oldGC1.length)] = oldGC1[0:Math.min(t_numNodes + 1, oldGC1.length)];
        }
        oldGC2 = t_thermCondPar2;
        Arrays.fill(t_thermCondPar2, 0.0d);
        if (oldGC2 != )
        {
            t_thermCondPar2[0:Math.min(t_numNodes + 1, oldGC2.length)] = oldGC2[0:Math.min(t_numNodes + 1, oldGC2.length)];
        }
        oldGC3 = t_thermCondPar3;
        Arrays.fill(t_thermCondPar3, 0.0d);
        if (oldGC3 != )
        {
            t_thermCondPar3[0:Math.min(t_numNodes + 1, oldGC3.length)] = oldGC3[0:Math.min(t_numNodes + 1, oldGC3.length)];
        }
        oldGC4 = t_thermCondPar4;
        Arrays.fill(t_thermCondPar4, 0.0d);
        if (oldGC4 != )
        {
            t_thermCondPar4[0:Math.min(t_numNodes + 1, oldGC4.length)] = oldGC4[0:Math.min(t_numNodes + 1, oldGC4.length)];
        }
        for (layer=1 ; layer!=t_numLayers + 1 + 1 ; layer+=1)
        {
            element = layer;
            t_thermCondPar1[element] = 0.65d - (0.78d * t_bulkDensity[layer]) + (0.6d * Math.pow(t_bulkDensity[layer], 2));
            t_thermCondPar2[element] = 1.06d * t_bulkDensity[layer];
            t_thermCondPar3[element] = 1.0d + Divide(2.6d, Math.sqrt(t_clay[layer]), 0);
            t_thermCondPar4[element] = 0.03d + (0.1d * Math.pow(t_bulkDensity[layer], 2));
        }
        return new doThermalConductivityCoeffs(t_thermCondPar2, t_thermCondPar3, t_thermCondPar4, t_thermCondPar1);
    }
    public readParam Calculate_readParam (Double [] t_soilTemp, double t_soilRoughnessHeight, Double [] t_newTemperature, double t_bareSoilRoughness, Double [] t_thermCondPar2, Double [] t_thermCondPar3, Double [] t_thermCondPar4, Double [] t_bulkDensity, Double [] t_thermCondPar1, Integer t_numNodes, Double [] t_clay, Integer t_numLayers, double t_weather_Latitude, double t_weather_Amp, Integer t_clock_Today_DayOfYear, double t_weather_Tav, Integer t_surfaceNode, Double [] t_thickness)
    {
        zz_doThermalConductivityCoeffs = Calculate_doThermalConductivityCoeffs(t_thermCondPar2, t_thermCondPar3, t_thermCondPar4, t_bulkDensity, t_thermCondPar1, t_numNodes, t_clay, t_numLayers);
        t_thermCondPar2 = zz_doThermalConductivityCoeffs.getthermCondPar2();
        t_thermCondPar3 = zz_doThermalConductivityCoeffs.getthermCondPar3();
        t_thermCondPar4 = zz_doThermalConductivityCoeffs.getthermCondPar4();
        t_thermCondPar1 = zz_doThermalConductivityCoeffs.getthermCondPar1();
        t_soilTemp = calcSoilTemperature(t_soilTemp, t_weather_Latitude, t_weather_Amp, t_numNodes, t_clock_Today_DayOfYear, t_weather_Tav, t_surfaceNode, t_thickness);
        t_newTemperature[0:0 + t_soilTemp.length] = t_soilTemp;
        t_soilRoughnessHeight = t_bareSoilRoughness;
        return new readParam(t_soilTemp, t_newTemperature, t_thermCondPar2, t_thermCondPar3, t_thermCondPar4, t_thermCondPar1, t_soilRoughnessHeight);
    }
    public getOtherVariables Calculate_getOtherVariables (Double [] t_soilWater, double t_instrumentHeight, double t_microClimate_CanopyHeight, Double [] t_waterBalance_SW, Integer t_numNodes, double t_canopyHeight, double t_soilRoughnessHeight, Integer t_numLayers)
    {
        t_soilWater[1:1 + t_waterBalance_SW.length] = t_waterBalance_SW;
        t_soilWater[t_numNodes] = t_soilWater[t_numLayers];
        t_canopyHeight = Math.max(t_microClimate_CanopyHeight, t_soilRoughnessHeight) / 1000.0d;
        t_instrumentHeight = Math.max(t_instrumentHeight, t_canopyHeight + 0.5d);
        return new getOtherVariables(t_soilWater, t_canopyHeight, t_instrumentHeight);
    }
    public static double volumetricFractionOrganicMatter(Integer layer, Double [] t_bulkDensity, Double [] t_carbon, double t_pom)
    {
        return t_carbon[layer] / 100.0d * 2.5d * t_bulkDensity[layer] / t_pom;
    }
    public static double volumetricFractionRocks(Integer layer, Double [] t_rocks)
    {
        return t_rocks[layer] / 100.0d;
    }
    public static double volumetricFractionIce(Integer layer)
    {
        return 0.0d;
    }
    public static double volumetricFractionWater(Integer layer, Double [] t_soilWater, Double [] t_bulkDensity, Double [] t_carbon, double t_pom)
    {
        return (1 - volumetricFractionOrganicMatter(layer, t_bulkDensity, t_carbon, t_pom)) * t_soilWater[layer];
    }
    public static double volumetricFractionClay(Integer layer, Double [] t_bulkDensity, Double [] t_clay, double t_ps, Double [] t_carbon, double t_pom, Double [] t_rocks)
    {
        return (1 - volumetricFractionOrganicMatter(layer, t_bulkDensity, t_carbon, t_pom) - volumetricFractionRocks(layer, t_rocks)) * t_clay[layer] / 100.0d * t_bulkDensity[layer] / t_ps;
    }
    public static double volumetricFractionSilt(Integer layer, Double [] t_bulkDensity, Double [] t_silt, double t_ps, Double [] t_carbon, double t_pom, Double [] t_rocks)
    {
        return (1 - volumetricFractionOrganicMatter(layer, t_bulkDensity, t_carbon, t_pom) - volumetricFractionRocks(layer, t_rocks)) * t_silt[layer] / 100.0d * t_bulkDensity[layer] / t_ps;
    }
    public static double volumetricFractionSand(Integer layer, Double [] t_bulkDensity, double t_ps, Double [] t_sand, Double [] t_carbon, double t_pom, Double [] t_rocks)
    {
        return (1 - volumetricFractionOrganicMatter(layer, t_bulkDensity, t_carbon, t_pom) - volumetricFractionRocks(layer, t_rocks)) * t_sand[layer] / 100.0d * t_bulkDensity[layer] / t_ps;
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
    public static double Sum(Double [] values, Integer startIndex, Integer endIndex, double t_MissingValue)
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
            if (index >= startIndex && value != t_MissingValue)
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
    public static double volumetricFractionAir(Integer layer, Double [] t_rocks, Double [] t_bulkDensity, Double [] t_carbon, double t_pom, double t_ps, Double [] t_sand, Double [] t_silt, Double [] t_clay, Double [] t_soilWater)
    {
        return 1.0d - volumetricFractionRocks(layer, t_rocks) - volumetricFractionOrganicMatter(layer, t_bulkDensity, t_carbon, t_pom) - volumetricFractionSand(layer, t_bulkDensity, t_ps, t_sand, t_carbon, t_pom, t_rocks) - volumetricFractionSilt(layer, t_bulkDensity, t_silt, t_ps, t_carbon, t_pom, t_rocks) - volumetricFractionClay(layer, t_bulkDensity, t_clay, t_ps, t_carbon, t_pom, t_rocks) - volumetricFractionWater(layer, t_soilWater, t_bulkDensity, t_carbon, t_pom) - volumetricFractionIce(layer);
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
    public static double longWaveRadn(double emissivity, double tDegC, double t_stefanBoltzmannConstant)
    {
        return t_stefanBoltzmannConstant * emissivity * Math.pow(kelvinT(tDegC), 4);
    }
    public static Double [] mapLayer2Node(Double [] layerArray, Double [] nodeArray, Integer t_numNodes, Double [] t_nodeDepth, Integer t_surfaceNode, Double [] t_thickness, double t_MissingValue)
    {
        Integer node;
        Integer layer;
        double depthLayerAbove;
        double d1;
        double d2;
        double dSum;
        for (node=t_surfaceNode ; node!=t_numNodes + 1 ; node+=1)
        {
            layer = node - 1;
            depthLayerAbove = layer >= 1 ? Sum(t_thickness, 1, layer, t_MissingValue) : 0.0d;
            d1 = depthLayerAbove - (t_nodeDepth[node] * 1000.0d);
            d2 = t_nodeDepth[(node + 1)] * 1000.0d - depthLayerAbove;
            dSum = d1 + d2;
            nodeArray[node] = Divide(layerArray[layer] * d1, dSum, 0) + Divide(layerArray[(layer + 1)] * d2, dSum, 0);
        }
        return nodeArray;
    }
    public static double ThermalConductance(String name, Integer layer, Double [] t_rocks, Double [] t_bulkDensity, double t_ps, Double [] t_sand, Double [] t_carbon, double t_pom, Double [] t_silt, Double [] t_clay)
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
            result = Math.pow(thermalConductanceRocks, volumetricFractionRocks(layer, t_rocks)) * Math.pow(thermalConductanceSand, volumetricFractionSand(layer, t_bulkDensity, t_ps, t_sand, t_carbon, t_pom, t_rocks)) + Math.pow(thermalConductanceSilt, volumetricFractionSilt(layer, t_bulkDensity, t_silt, t_ps, t_carbon, t_pom, t_rocks)) + Math.pow(thermalConductanceClay, volumetricFractionClay(layer, t_bulkDensity, t_clay, t_ps, t_carbon, t_pom, t_rocks));
        }
        result = volumetricSpecificHeat(name, layer);
        return result;
    }
    public static double shapeFactor(String name, Integer layer, Double [] t_soilWater, Double [] t_bulkDensity, Double [] t_carbon, double t_pom, Double [] t_rocks, double t_ps, Double [] t_sand, Double [] t_silt, Double [] t_clay)
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
            result = 0.333d - (0.333d * volumetricFractionIce(layer) / (volumetricFractionWater(layer, t_soilWater, t_bulkDensity, t_carbon, t_pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, t_rocks, t_bulkDensity, t_carbon, t_pom, t_ps, t_sand, t_silt, t_clay, t_soilWater)));
            return result;
        }
        else if ( name == "Air")
        {
            result = 0.333d - (0.333d * volumetricFractionAir(layer, t_rocks, t_bulkDensity, t_carbon, t_pom, t_ps, t_sand, t_silt, t_clay, t_soilWater) / (volumetricFractionWater(layer, t_soilWater, t_bulkDensity, t_carbon, t_pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, t_rocks, t_bulkDensity, t_carbon, t_pom, t_ps, t_sand, t_silt, t_clay, t_soilWater)));
            return result;
        }
        else if ( name == "Minerals")
        {
            result = shapeFactorRocks * volumetricFractionRocks(layer, t_rocks) + (shapeFactorSand * volumetricFractionSand(layer, t_bulkDensity, t_ps, t_sand, t_carbon, t_pom, t_rocks)) + (shapeFactorSilt * volumetricFractionSilt(layer, t_bulkDensity, t_silt, t_ps, t_carbon, t_pom, t_rocks)) + (shapeFactorClay * volumetricFractionClay(layer, t_bulkDensity, t_clay, t_ps, t_carbon, t_pom, t_rocks));
        }
        result = volumetricSpecificHeat(name, layer);
        return result;
    }
    public doUpdate Calculate_doUpdate (Integer numInterationsPerDay, Double [] t_maxSoilTemp, Double [] t_minSoilTemp, Double [] t_thermalConductivity, Double [] t_soilTemp, double t_timeOfDaySecs, Integer t_numNodes, double t_boundaryLayerConductance, Double [] t_aveSoilTemp, double t_airNode, Double [] t_newTemperature, Integer t_surfaceNode, double t_internalTimeStep)
    {
        Integer node;
        t_soilTemp[0:0 + t_newTemperature.length] = t_newTemperature;
        if (t_timeOfDaySecs < (t_internalTimeStep * 1.2d))
        {
            for (node=t_surfaceNode ; node!=t_numNodes + 1 ; node+=1)
            {
                t_minSoilTemp[node] = t_soilTemp[node];
                t_maxSoilTemp[node] = t_soilTemp[node];
            }
        }
        for (node=t_surfaceNode ; node!=t_numNodes + 1 ; node+=1)
        {
            if (t_soilTemp[node] < t_minSoilTemp[node])
            {
                t_minSoilTemp[node] = t_soilTemp[node];
            }
            else if ( t_soilTemp[node] > t_maxSoilTemp[node])
            {
                t_maxSoilTemp[node] = t_soilTemp[node];
            }
            t_aveSoilTemp[node] = t_aveSoilTemp[node] + Divide(t_soilTemp[node], numInterationsPerDay, 0);
        }
        t_boundaryLayerConductance = t_boundaryLayerConductance + Divide(t_thermalConductivity[t_airNode], numInterationsPerDay, 0);
        return new doUpdate(t_maxSoilTemp, t_minSoilTemp, t_soilTemp, t_aveSoilTemp, t_boundaryLayerConductance);
    }
    public doThomas Calculate_doThomas (Double [] newTemps, String t_netRadiationSource, Double [] t_thermalConductance, double t_waterBalance_Eos, double t_waterBalance_Es, Double [] t_thermalConductivity, Double [] t_soilTemp, Integer t_numNodes, double t_internalTimeStep, Double [] t_heatStorage, double t_latentHeatOfVapourisation, Double [] t_nodeDepth, double t_nu, Double [] t_volSpecHeatSoil, double t_airNode, double t_netRadiation, Integer t_surfaceNode, double t_timestep)
    {
        Integer node;
        Double[] a = new Double[t_numNodes + 1 + 1];
        Double[] b = new Double[t_numNodes + 1];
        Double[] c = new Double[t_numNodes + 1];
        Double[] d = new Double[t_numNodes + 1];
        double volumeOfSoilAtNode;
        double elementLength;
        double g;
        double sensibleHeatFlux;
        double radnNet;
        double latentHeatFlux;
        double soilSurfaceHeatFlux;
        t_thermalConductance[t_airNode] = t_thermalConductivity[t_airNode];
        for (node=t_surfaceNode ; node!=t_numNodes + 1 ; node+=1)
        {
            volumeOfSoilAtNode = 0.5d * (t_nodeDepth[node + 1] - t_nodeDepth[node - 1]);
            t_heatStorage[node] = Divide(t_volSpecHeatSoil[node] * volumeOfSoilAtNode, t_internalTimeStep, 0);
            elementLength = t_nodeDepth[node + 1] - t_nodeDepth[node];
            t_thermalConductance[node] = Divide(t_thermalConductivity[node], elementLength, 0);
        }
        g = 1 - t_nu;
        for (node=t_surfaceNode ; node!=t_numNodes + 1 ; node+=1)
        {
            c[node] = -t_nu * t_thermalConductance[node];
            a[node + 1] = c[node];
            b[node] = t_nu * (t_thermalConductance[node] + t_thermalConductance[node - 1]) + t_heatStorage[node];
            d[node] = g * t_thermalConductance[(node - 1)] * t_soilTemp[(node - 1)] + ((t_heatStorage[node] - (g * (t_thermalConductance[node] + t_thermalConductance[node - 1]))) * t_soilTemp[node]) + (g * t_thermalConductance[node] * t_soilTemp[(node + 1)]);
        }
        a[t_surfaceNode] = 0.0d;
        sensibleHeatFlux = t_nu * t_thermalConductance[t_airNode] * newTemps[t_airNode];
        radnNet = 0.0d;
        if (t_netRadiationSource == "calc")
        {
            radnNet = Divide(t_netRadiation * 1000000.0d, t_internalTimeStep, 0);
        }
        else if ( t_netRadiationSource == "eos")
        {
            radnNet = Divide(t_waterBalance_Eos * t_latentHeatOfVapourisation, t_timestep, 0);
        }
        latentHeatFlux = Divide(t_waterBalance_Es * t_latentHeatOfVapourisation, t_timestep, 0);
        soilSurfaceHeatFlux = sensibleHeatFlux + radnNet - latentHeatFlux;
        d[t_surfaceNode] = d[t_surfaceNode] + soilSurfaceHeatFlux;
        d[t_numNodes] = d[t_numNodes] + (t_nu * t_thermalConductance[t_numNodes] * newTemps[(t_numNodes + 1)]);
        for (node=t_surfaceNode ; node!=t_numNodes - 1 + 1 ; node+=1)
        {
            c[node] = Divide(c[node], b[node], 0);
            d[node] = Divide(d[node], b[node], 0);
            b[node + 1] = b[node + 1] - (a[(node + 1)] * c[node]);
            d[node + 1] = d[node + 1] - (a[(node + 1)] * d[node]);
        }
        newTemps[t_numNodes] = Divide(d[t_numNodes], b[t_numNodes], 0);
        for (node=t_numNodes - 1 ; node!=t_surfaceNode - 1 ; node+=-1)
        {
            newTemps[node] = d[node] - (c[node] * newTemps[(node + 1)]);
        }
        return new doThomas(newTemps, t_thermalConductance, t_heatStorage);
    }
    public getBoundaryLayerConductance Calculate_getBoundaryLayerConductance (Double [] TNew_zb, double t_stefanBoltzmannConstant, double t_airTemperature, double t_waterBalance_Eos, double t_weather_AirPressure, double t_instrumentHeight, double t_waterBalance_Eo, double t_weather_Wind, double t_canopyHeight, Integer t_surfaceNode)
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
        SpecificHeatAir = specificHeatOfAir * airDensity(t_airTemperature, t_weather_AirPressure);
        roughnessFactorMomentum = 0.13d * t_canopyHeight;
        roughnessFactorHeat = 0.2d * roughnessFactorMomentum;
        d = 0.77d * t_canopyHeight;
        surfaceTemperature = TNew_zb[t_surfaceNode];
        diffusePenetrationConstant = Math.max(0.1d, t_waterBalance_Eos) / Math.max(0.1d, t_waterBalance_Eo);
        radiativeConductance = 4.0d * t_stefanBoltzmannConstant * surfaceEmissivity * diffusePenetrationConstant * Math.pow(kelvinT(t_airTemperature), 3);
        frictionVelocity = 0.0d;
        boundaryLayerCond = 0.0d;
        stabilityParammeter = 0.0d;
        stabilityCorrectionMomentum = 0.0d;
        stabilityCorrectionHeat = 0.0d;
        heatFluxDensity = 0.0d;
        for (iteration=1 ; iteration!=3 + 1 ; iteration+=1)
        {
            frictionVelocity = Divide(t_weather_Wind * vonKarmanConstant, Math.log(Divide(t_instrumentHeight - d + roughnessFactorMomentum, roughnessFactorMomentum, 0)) + stabilityCorrectionMomentum, 0);
            boundaryLayerCond = Divide(SpecificHeatAir * vonKarmanConstant * frictionVelocity, Math.log(Divide(t_instrumentHeight - d + roughnessFactorHeat, roughnessFactorHeat, 0)) + stabilityCorrectionHeat, 0);
            boundaryLayerCond = boundaryLayerCond + radiativeConductance;
            heatFluxDensity = boundaryLayerCond * (surfaceTemperature - t_airTemperature);
            stabilityParammeter = Divide(-vonKarmanConstant * t_instrumentHeight * gravitationalConstant * heatFluxDensity, SpecificHeatAir * kelvinT(t_airTemperature) * Math.pow(frictionVelocity, 3.0d), 0);
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
    public static double interpolateNetRadiation(double solarRadn, double cloudFr, double cva, Double [] t_soilTemp, double t_airTemperature, double t_waterBalance_Eo, double t_waterBalance_Eos, double t_waterBalance_Salb, Integer t_surfaceNode, double t_internalTimeStep, double t_stefanBoltzmannConstant)
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
        w2MJ = t_internalTimeStep / 1000000.0d;
        emissivityAtmos = (1 - (0.84d * cloudFr)) * 0.58d * Math.pow(cva, 1.0d / 7.0d) + (0.84d * cloudFr);
        PenetrationConstant = Divide(Math.max(0.1d, t_waterBalance_Eos), Math.max(0.1d, t_waterBalance_Eo), 0);
        lwRinSoil = longWaveRadn(emissivityAtmos, t_airTemperature, t_stefanBoltzmannConstant) * PenetrationConstant * w2MJ;
        lwRoutSoil = longWaveRadn(surfaceEmissivity, t_soilTemp[t_surfaceNode], t_stefanBoltzmannConstant) * PenetrationConstant * w2MJ;
        lwRnetSoil = lwRinSoil - lwRoutSoil;
        swRin = solarRadn;
        swRout = t_waterBalance_Salb * solarRadn;
        swRnetSoil = (swRin - swRout) * PenetrationConstant;
        return swRnetSoil + lwRnetSoil;
    }
    public static double interpolateTemperature(double timeHours, double t_defaultTimeOfMaximumTemperature, double t_weather_MeanT, double t_weather_MaxT, double t_maxTempYesterday, double t_minTempYesterday, double t_weather_MinT)
    {
        double time;
        double maxT_time;
        double minT_time;
        double midnightT;
        double tScale;
        double currentTemperature;
        time = timeHours / 24.0d;
        maxT_time = t_defaultTimeOfMaximumTemperature / 24.0d;
        minT_time = maxT_time - 0.5d;
        if (time < minT_time)
        {
            midnightT = Math.sin((0.0d + 0.25d - maxT_time) * 2.0d * Math.PI) * (t_maxTempYesterday - t_minTempYesterday) / 2.0d + ((t_maxTempYesterday + t_minTempYesterday) / 2.0d);
            tScale = (minT_time - time) / minT_time;
            if (tScale > 1.0d)
            {
                tScale = 1.0d;
            }
            else if ( tScale < (double)(0))
            {
                tScale = (double)(0);
            }
            currentTemperature = t_weather_MinT + (tScale * (midnightT - t_weather_MinT));
            return currentTemperature;
        }
        else
        {
            currentTemperature = Math.sin((time + 0.25d - maxT_time) * 2.0d * Math.PI) * (t_weather_MaxT - t_weather_MinT) / 2.0d + t_weather_MeanT;
            return currentTemperature;
        }
    }
    public static Double [] doThermalConductivity(String [] t_soilConstituentNames, Double [] t_soilWater, Double [] t_thermalConductivity, Integer t_numNodes, Double [] t_bulkDensity, Double [] t_carbon, double t_pom, Double [] t_rocks, double t_ps, Double [] t_sand, Double [] t_silt, Double [] t_clay, Double [] t_nodeDepth, Integer t_surfaceNode, Double [] t_thickness, double t_MissingValue)
    {
        Integer node;
        String constituentName;
        Double[] thermCondLayers = new Double[t_numNodes + 1];
        double numerator;
        double denominator;
        double shapeFactorConstituent;
        double thermalConductanceConstituent;
        double thermalConductanceWater;
        double k;
        for (node=1 ; node!=t_numNodes + 1 ; node+=1)
        {
            numerator = 0.0d;
            denominator = 0.0d;
            for(String constituentName_cyml : t_soilConstituentNames)
            {
                constituentName = constituentName_cyml;
                shapeFactorConstituent = shapeFactor(constituentName, node, t_soilWater, t_bulkDensity, t_carbon, t_pom, t_rocks, t_ps, t_sand, t_silt, t_clay);
                thermalConductanceConstituent = ThermalConductance(constituentName, node, t_rocks, t_bulkDensity, t_ps, t_sand, t_carbon, t_pom, t_silt, t_clay);
                thermalConductanceWater = ThermalConductance("Water", node, t_rocks, t_bulkDensity, t_ps, t_sand, t_carbon, t_pom, t_silt, t_clay);
                k = 2.0d / 3.0d * Math.pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0d))), -1) + (1.0d / 3.0d * Math.pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0d) * (1 - (2 * shapeFactorConstituent)))), -1));
                numerator = numerator + (thermalConductanceConstituent * t_soilWater[node] * k);
                denominator = denominator + (t_soilWater[node] * k);
            }
            thermCondLayers[node] = numerator / denominator;
        }
        t_thermalConductivity = mapLayer2Node(thermCondLayers, t_thermalConductivity, t_numNodes, t_nodeDepth, t_surfaceNode, t_thickness, t_MissingValue);
        return t_thermalConductivity;
    }
    public static Double [] doVolumetricSpecificHeat(String [] t_soilConstituentNames, Double [] t_soilWater, Double [] t_volSpecHeatSoil, Integer t_numNodes, Double [] t_nodeDepth, Integer t_surfaceNode, Double [] t_thickness, double t_MissingValue)
    {
        Integer node;
        String constituentName;
        Double[] volspecHeatSoil_ = new Double[t_numNodes + 1];
        for (node=1 ; node!=t_numNodes + 1 ; node+=1)
        {
            volspecHeatSoil_[node] = (double)(0);
            for(String constituentName_cyml : t_soilConstituentNames)
            {
                constituentName = constituentName_cyml;
                if (!new ArrayList<>(Arrays.asList("Minerals")).contains(constituentName))
                {
                    volspecHeatSoil_[node] = volspecHeatSoil_[node] + (volumetricSpecificHeat(constituentName, node) * 1000000.0d * t_soilWater[node]);
                }
            }
        }
        t_volSpecHeatSoil = mapLayer2Node(volspecHeatSoil_, t_volSpecHeatSoil, t_numNodes, t_nodeDepth, t_surfaceNode, t_thickness, t_MissingValue);
        return t_volSpecHeatSoil;
    }
    public static Double [] Zero(Double [] arr)
    {
        Integer i;
        if (arr != )
        {
            for (i=0 ; i!=arr.length ; i+=1)
            {
                arr[i] = (double)(0);
            }
        }
        return arr;
    }
    public doNetRadiation Calculate_doNetRadiation (Double [] solarRadn, double cloudFr, double cva, Integer ITERATIONSperDAY, Integer t_clock_Today_DayOfYear, double t_weather_Latitude, double t_weather_Radn, double t_weather_MinT)
    {
        Integer timestepNumber;
        double TSTEPS2RAD;
        double solarConstant;
        double solarDeclination;
        double cD;
        Double[] m1 = new Double[ITERATIONSperDAY + 1];
        double m1Tot;
        double psr;
        double fr;
        TSTEPS2RAD = Divide(2.0d * Math.PI, (double)(ITERATIONSperDAY), 0);
        solarConstant = 1360.0d;
        solarDeclination = 0.3985d * Math.sin((4.869d + (t_clock_Today_DayOfYear * 2.0d * Math.PI / 365.25d) + (0.03345d * Math.sin((6.224d + (t_clock_Today_DayOfYear * 2.0d * Math.PI / 365.25d))))));
        cD = Math.sqrt(1.0d - (solarDeclination * solarDeclination));
        m1Tot = 0.0d;
        for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
        {
            m1[timestepNumber] = (solarDeclination * Math.sin(t_weather_Latitude * Math.PI / 180.0d) + (cD * Math.cos(t_weather_Latitude * Math.PI / 180.0d) * Math.cos(TSTEPS2RAD * (timestepNumber - (ITERATIONSperDAY / 2.0d))))) * 24.0d / ITERATIONSperDAY;
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
        fr = Divide(Math.max(t_weather_Radn, 0.1d), psr, 0);
        cloudFr = 2.33d - (3.33d * fr);
        cloudFr = Math.min(Math.max(cloudFr, 0.0d), 1.0d);
        for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
        {
            solarRadn[timestepNumber] = Math.max(t_weather_Radn, 0.1d) * Divide(m1[timestepNumber], m1Tot, 0);
        }
        cva = Math.exp((31.3716d - (6014.79d / kelvinT(t_weather_MinT)) - (0.00792495d * kelvinT(t_weather_MinT)))) / kelvinT(t_weather_MinT);
        return new doNetRadiation(solarRadn, cva, cloudFr);
    }
    public doProcess Calculate_doProcess (Double [] t_maxSoilTemp, Double [] t_minSoilTemp, double t_weather_MaxT, Integer t_numIterationsForBoundaryLayerConductance, double t_maxTempYesterday, Double [] t_thermalConductivity, double t_timeOfDaySecs, Double [] t_soilTemp, double t_weather_MeanT, Double [] t_morningSoilTemp, Double [] t_newTemperature, double t_boundaryLayerConductance, double t_constantBoundaryLayerConductance, double t_airTemperature, double t_timestep, double t_weather_MinT, double t_airNode, double t_netRadiation, Double [] t_aveSoilTemp, double t_minTempYesterday, double t_internalTimeStep, String t_boundarLayerConductanceSource, Integer t_clock_Today_DayOfYear, double t_weather_Latitude, double t_weather_Radn, String [] t_soilConstituentNames, Double [] t_soilWater, Double [] t_volSpecHeatSoil, Integer t_numNodes, Double [] t_nodeDepth, Integer t_surfaceNode, Double [] t_thickness, double t_MissingValue, Double [] t_bulkDensity, Double [] t_carbon, double t_pom, Double [] t_rocks, double t_ps, Double [] t_sand, Double [] t_silt, Double [] t_clay, double t_defaultTimeOfMaximumTemperature, double t_waterBalance_Eo, double t_waterBalance_Eos, double t_waterBalance_Salb, double t_stefanBoltzmannConstant, double t_weather_AirPressure, double t_instrumentHeight, double t_weather_Wind, double t_canopyHeight, String t_netRadiationSource, Double [] t_thermalConductance, double t_waterBalance_Es, Double [] t_heatStorage, double t_latentHeatOfVapourisation, double t_nu)
    {
        Integer timeStepIteration;
        Integer iteration;
        Integer interactionsPerDay;
        double cva;
        double cloudFr;
        Double[] solarRadn = new Double[49];
        interactionsPerDay = 48;
        cva = 0.0d;
        cloudFr = 0.0d;
        zz_doNetRadiation = Calculate_doNetRadiation(solarRadn, cloudFr, cva, interactionsPerDay, t_clock_Today_DayOfYear, t_weather_Latitude, t_weather_Radn, t_weather_MinT);
        solarRadn = zz_doNetRadiation.getsolarRadn();
        cva = zz_doNetRadiation.getcva();
        cloudFr = zz_doNetRadiation.getcloudFr();
        t_minSoilTemp = Zero(t_minSoilTemp);
        t_maxSoilTemp = Zero(t_maxSoilTemp);
        t_aveSoilTemp = Zero(t_aveSoilTemp);
        t_boundaryLayerConductance = 0.0d;
        t_internalTimeStep = Math.round(t_timestep / interactionsPerDay);
        t_volSpecHeatSoil = doVolumetricSpecificHeat(t_soilConstituentNames, t_soilWater, t_volSpecHeatSoil, t_numNodes, t_nodeDepth, t_surfaceNode, t_thickness, t_MissingValue);
        t_thermalConductivity = doThermalConductivity(t_soilConstituentNames, t_soilWater, t_thermalConductivity, t_numNodes, t_bulkDensity, t_carbon, t_pom, t_rocks, t_ps, t_sand, t_silt, t_clay, t_nodeDepth, t_surfaceNode, t_thickness, t_MissingValue);
        for (timeStepIteration=1 ; timeStepIteration!=interactionsPerDay + 1 ; timeStepIteration+=1)
        {
            t_timeOfDaySecs = t_internalTimeStep * (double)(timeStepIteration);
            if (t_timestep < (24.0d * 60.0d * 60.0d))
            {
                t_airTemperature = t_weather_MeanT;
            }
            else
            {
                t_airTemperature = interpolateTemperature(t_timeOfDaySecs / 3600.0d, t_defaultTimeOfMaximumTemperature, t_weather_MeanT, t_weather_MaxT, t_maxTempYesterday, t_minTempYesterday, t_weather_MinT);
            }
            t_newTemperature[t_airNode] = t_airTemperature;
            t_netRadiation = interpolateNetRadiation(solarRadn[timeStepIteration], cloudFr, cva, t_soilTemp, t_airTemperature, t_waterBalance_Eo, t_waterBalance_Eos, t_waterBalance_Salb, t_surfaceNode, t_internalTimeStep, t_stefanBoltzmannConstant);
            if (t_boundarLayerConductanceSource == "constant")
            {
                t_thermalConductivity[t_airNode] = t_constantBoundaryLayerConductance;
            }
            else if ( t_boundarLayerConductanceSource == "calc")
            {
                zz_getBoundaryLayerConductance = Calculate_getBoundaryLayerConductance(t_newTemperature, t_stefanBoltzmannConstant, t_airTemperature, t_waterBalance_Eos, t_weather_AirPressure, t_instrumentHeight, t_waterBalance_Eo, t_weather_Wind, t_canopyHeight, t_surfaceNode);
                t_thermalConductivity[t_airNode] = zz_getBoundaryLayerConductance.getboundaryLayerCond();
                t_newTemperature = zz_getBoundaryLayerConductance.getTNew_zb();
                for (iteration=1 ; iteration!=t_numIterationsForBoundaryLayerConductance + 1 ; iteration+=1)
                {
                    zz_doThomas = Calculate_doThomas(t_newTemperature, t_netRadiationSource, t_thermalConductance, t_waterBalance_Eos, t_waterBalance_Es, t_thermalConductivity, t_soilTemp, t_numNodes, t_internalTimeStep, t_heatStorage, t_latentHeatOfVapourisation, t_nodeDepth, t_nu, t_volSpecHeatSoil, t_airNode, t_netRadiation, t_surfaceNode, t_timestep);
                    t_newTemperature = zz_doThomas.getnewTemps();
                    t_thermalConductance = zz_doThomas.getthermalConductance();
                    t_heatStorage = zz_doThomas.getheatStorage();
                    zz_getBoundaryLayerConductance = Calculate_getBoundaryLayerConductance(t_newTemperature, t_stefanBoltzmannConstant, t_airTemperature, t_waterBalance_Eos, t_weather_AirPressure, t_instrumentHeight, t_waterBalance_Eo, t_weather_Wind, t_canopyHeight, t_surfaceNode);
                    t_thermalConductivity[t_airNode] = zz_getBoundaryLayerConductance.getboundaryLayerCond();
                    t_newTemperature = zz_getBoundaryLayerConductance.getTNew_zb();
                }
            }
            zz_doThomas = Calculate_doThomas(t_newTemperature, t_netRadiationSource, t_thermalConductance, t_waterBalance_Eos, t_waterBalance_Es, t_thermalConductivity, t_soilTemp, t_numNodes, t_internalTimeStep, t_heatStorage, t_latentHeatOfVapourisation, t_nodeDepth, t_nu, t_volSpecHeatSoil, t_airNode, t_netRadiation, t_surfaceNode, t_timestep);
            t_newTemperature = zz_doThomas.getnewTemps();
            t_thermalConductance = zz_doThomas.getthermalConductance();
            t_heatStorage = zz_doThomas.getheatStorage();
            zz_doUpdate = Calculate_doUpdate(interactionsPerDay, t_maxSoilTemp, t_minSoilTemp, t_thermalConductivity, t_soilTemp, t_timeOfDaySecs, t_numNodes, t_boundaryLayerConductance, t_aveSoilTemp, t_airNode, t_newTemperature, t_surfaceNode, t_internalTimeStep);
            t_maxSoilTemp = zz_doUpdate.getmaxSoilTemp();
            t_minSoilTemp = zz_doUpdate.getminSoilTemp();
            t_soilTemp = zz_doUpdate.getsoilTemp();
            t_aveSoilTemp = zz_doUpdate.getaveSoilTemp();
            t_boundaryLayerConductance = zz_doUpdate.getboundaryLayerConductance();
            if (Math.abs(t_timeOfDaySecs - (5.0d * 3600.0d)) <= (Math.min(t_timeOfDaySecs, 5.0d * 3600.0d) * 0.0001d))
            {
                t_morningSoilTemp[0:0 + t_soilTemp.length] = t_soilTemp;
            }
        }
        t_minTempYesterday = t_weather_MinT;
        t_maxTempYesterday = t_weather_MaxT;
        return new doProcess(t_maxSoilTemp, t_minSoilTemp, t_thermalConductivity, t_soilTemp, t_morningSoilTemp, t_newTemperature, t_aveSoilTemp, t_volSpecHeatSoil, t_thermalConductance, t_heatStorage, t_timeOfDaySecs, t_boundaryLayerConductance, t_minTempYesterday, t_maxTempYesterday, t_airTemperature, t_netRadiation, t_internalTimeStep);
    }
    public static Double [] ToCumThickness(Double [] t_Thickness)
    {
        Integer Layer;
        Double[] CumThickness = new Double[t_Thickness.length];
        if (t_Thickness.length > 0)
        {
            CumThickness[0] = t_Thickness[0];
            for (Layer=1 ; Layer!=t_Thickness.length ; Layer+=1)
            {
                CumThickness[Layer] = t_Thickness[Layer] + CumThickness[Layer - 1];
            }
        }
        return CumThickness;
    }
    public static Double [] calcSoilTemperature(Double [] soilTempIO, double t_weather_Latitude, double t_weather_Amp, Integer t_numNodes, Integer t_clock_Today_DayOfYear, double t_weather_Tav, Integer t_surfaceNode, Double [] t_thickness)
    {
        Integer nodes;
        Double[] cumulativeDepth;
        double w;
        double dh;
        double zd;
        double offset;
        Double[] soilTemp = new Double[t_numNodes + 1 + 1];
        cumulativeDepth = ToCumThickness(t_thickness);
        w = 2 * Math.PI / (365.25d * 24 * 3600);
        dh = 0.6d;
        zd = Math.sqrt(2 * dh / w);
        offset = 0.25d;
        if (t_weather_Latitude > 0.0d)
        {
            offset = -0.25d;
        }
        for (nodes=1 ; nodes!=t_numNodes + 1 ; nodes+=1)
        {
            t_soilTemp[nodes] = t_weather_Tav + (t_weather_Amp * Math.exp(-1 * cumulativeDepth[nodes] / zd) * Math.sin(((t_clock_Today_DayOfYear / 365.0d + offset) * 2.0d * Math.PI - (cumulativeDepth[nodes] / zd))));
        }
        soilTempIO[t_surfaceNode:t_surfaceNode + t_numNodes] = t_soilTemp[0:0 + t_numNodes];
        return soilTempIO;
    }
    public static double calcSurfaceTemperature(double t_waterBalance_Salb, double t_weather_MeanT, double t_weather_Radn, double t_weather_MaxT)
    {
        double surfaceT;
        surfaceT = (1.0d - t_waterBalance_Salb) * (t_weather_MeanT + ((t_weather_MaxT - t_weather_MeanT) * Math.sqrt(Math.max(t_weather_Radn, 0.1d) * 23.8846d / 800.0d))) + (t_waterBalance_Salb * t_weather_MeanT);
        return surfaceT;
    }
    public static Boolean ValuesInArray(Double [] Values, double t_MissingValue)
    {
        double Value;
        if (Values != )
        {
            for(Double Value_cyml : Values)
            {
                Value = Value_cyml;
                if (Value != t_MissingValue && !Double.isNaN(Value))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public HashMap<String, FWSimVariable<?>> fillTestVariables(int aParamIndex, TEST_STATE aDefineOrCheck)
    {
        return iFieldMap;
    }

    @Override
    protected FWSimComponent clone(FWSimVarMap aVarMap)
    {
        return new SoilTemperature(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}
final class getProfileVariables {
    private Double [] maxSoilTemp;
    public Double [] getmaxSoilTemp()
    { return maxSoilTemp; }

    public void setmaxSoilTemp(Double [] _maxSoilTemp)
    { this.maxSoilTemp= _maxSoilTemp; } 
    
    private Double [] minSoilTemp;
    public Double [] getminSoilTemp()
    { return minSoilTemp; }

    public void setminSoilTemp(Double [] _minSoilTemp)
    { this.minSoilTemp= _minSoilTemp; } 
    
    private Double [] thermalConductance;
    public Double [] getthermalConductance()
    { return thermalConductance; }

    public void setthermalConductance(Double [] _thermalConductance)
    { this.thermalConductance= _thermalConductance; } 
    
    private Double [] soilTemp;
    public Double [] getsoilTemp()
    { return soilTemp; }

    public void setsoilTemp(Double [] _soilTemp)
    { this.soilTemp= _soilTemp; } 
    
    private Double [] carbon;
    public Double [] getcarbon()
    { return carbon; }

    public void setcarbon(Double [] _carbon)
    { this.carbon= _carbon; } 
    
    private Double [] newTemperature;
    public Double [] getnewTemperature()
    { return newTemperature; }

    public void setnewTemperature(Double [] _newTemperature)
    { this.newTemperature= _newTemperature; } 
    
    private Double [] heatStorage;
    public Double [] getheatStorage()
    { return heatStorage; }

    public void setheatStorage(Double [] _heatStorage)
    { this.heatStorage= _heatStorage; } 
    
    private Double [] soilWater;
    public Double [] getsoilWater()
    { return soilWater; }

    public void setsoilWater(Double [] _soilWater)
    { this.soilWater= _soilWater; } 
    
    private Double [] nodeDepth;
    public Double [] getnodeDepth()
    { return nodeDepth; }

    public void setnodeDepth(Double [] _nodeDepth)
    { this.nodeDepth= _nodeDepth; } 
    
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
    
    private Double [] rocks;
    public Double [] getrocks()
    { return rocks; }

    public void setrocks(Double [] _rocks)
    { this.rocks= _rocks; } 
    
    private Double [] thermalConductivity;
    public Double [] getthermalConductivity()
    { return thermalConductivity; }

    public void setthermalConductivity(Double [] _thermalConductivity)
    { this.thermalConductivity= _thermalConductivity; } 
    
    private Double [] silt;
    public Double [] getsilt()
    { return silt; }

    public void setsilt(Double [] _silt)
    { this.silt= _silt; } 
    
    private Double [] sand;
    public Double [] getsand()
    { return sand; }

    public void setsand(Double [] _sand)
    { this.sand= _sand; } 
    
    private Double [] morningSoilTemp;
    public Double [] getmorningSoilTemp()
    { return morningSoilTemp; }

    public void setmorningSoilTemp(Double [] _morningSoilTemp)
    { this.morningSoilTemp= _morningSoilTemp; } 
    
    private Double [] clay;
    public Double [] getclay()
    { return clay; }

    public void setclay(Double [] _clay)
    { this.clay= _clay; } 
    
    private Double [] thickness;
    public Double [] getthickness()
    { return thickness; }

    public void setthickness(Double [] _thickness)
    { this.thickness= _thickness; } 
    
    private Double [] bulkDensity;
    public Double [] getbulkDensity()
    { return bulkDensity; }

    public void setbulkDensity(Double [] _bulkDensity)
    { this.bulkDensity= _bulkDensity; } 
    
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
    
    public getProfileVariables(Double [] maxSoilTemp,Double [] minSoilTemp,Double [] thermalConductance,Double [] soilTemp,Double [] carbon,Double [] newTemperature,Double [] heatStorage,Double [] soilWater,Double [] nodeDepth,Double [] volSpecHeatSoil,Double [] aveSoilTemp,Double [] rocks,Double [] thermalConductivity,Double [] silt,Double [] sand,Double [] morningSoilTemp,Double [] clay,Double [] thickness,Double [] bulkDensity,Integer numNodes,Integer numLayers)
    {
        this.maxSoilTemp = maxSoilTemp;
        this.minSoilTemp = minSoilTemp;
        this.thermalConductance = thermalConductance;
        this.soilTemp = soilTemp;
        this.carbon = carbon;
        this.newTemperature = newTemperature;
        this.heatStorage = heatStorage;
        this.soilWater = soilWater;
        this.nodeDepth = nodeDepth;
        this.volSpecHeatSoil = volSpecHeatSoil;
        this.aveSoilTemp = aveSoilTemp;
        this.rocks = rocks;
        this.thermalConductivity = thermalConductivity;
        this.silt = silt;
        this.sand = sand;
        this.morningSoilTemp = morningSoilTemp;
        this.clay = clay;
        this.thickness = thickness;
        this.bulkDensity = bulkDensity;
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
    
    public readParam(Double [] soilTemp,Double [] newTemperature,Double [] thermCondPar2,Double [] thermCondPar3,Double [] thermCondPar4,Double [] thermCondPar1,double soilRoughnessHeight)
    {
        this.soilTemp = soilTemp;
        this.newTemperature = newTemperature;
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
    
    private double canopyHeight;
    public double getcanopyHeight()
    { return canopyHeight; }

    public void setcanopyHeight(double _canopyHeight)
    { this.canopyHeight= _canopyHeight; } 
    
    private double instrumentHeight;
    public double getinstrumentHeight()
    { return instrumentHeight; }

    public void setinstrumentHeight(double _instrumentHeight)
    { this.instrumentHeight= _instrumentHeight; } 
    
    public getOtherVariables(Double [] soilWater,double canopyHeight,double instrumentHeight)
    {
        this.soilWater = soilWater;
        this.canopyHeight = canopyHeight;
        this.instrumentHeight = instrumentHeight;
    }
}final class doUpdate {
    private Double [] maxSoilTemp;
    public Double [] getmaxSoilTemp()
    { return maxSoilTemp; }

    public void setmaxSoilTemp(Double [] _maxSoilTemp)
    { this.maxSoilTemp= _maxSoilTemp; } 
    
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
    
    public doUpdate(Double [] maxSoilTemp,Double [] minSoilTemp,Double [] soilTemp,Double [] aveSoilTemp,double boundaryLayerConductance)
    {
        this.maxSoilTemp = maxSoilTemp;
        this.minSoilTemp = minSoilTemp;
        this.soilTemp = soilTemp;
        this.aveSoilTemp = aveSoilTemp;
        this.boundaryLayerConductance = boundaryLayerConductance;
    }
}final class doThomas {
    private Double [] newTemps;
    public Double [] getnewTemps()
    { return newTemps; }

    public void setnewTemps(Double [] _newTemps)
    { this.newTemps= _newTemps; } 
    
    private Double [] thermalConductance;
    public Double [] getthermalConductance()
    { return thermalConductance; }

    public void setthermalConductance(Double [] _thermalConductance)
    { this.thermalConductance= _thermalConductance; } 
    
    private Double [] heatStorage;
    public Double [] getheatStorage()
    { return heatStorage; }

    public void setheatStorage(Double [] _heatStorage)
    { this.heatStorage= _heatStorage; } 
    
    public doThomas(Double [] newTemps,Double [] thermalConductance,Double [] heatStorage)
    {
        this.newTemps = newTemps;
        this.thermalConductance = thermalConductance;
        this.heatStorage = heatStorage;
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
    
    private double cva;
    public double getcva()
    { return cva; }

    public void setcva(double _cva)
    { this.cva= _cva; } 
    
    private double cloudFr;
    public double getcloudFr()
    { return cloudFr; }

    public void setcloudFr(double _cloudFr)
    { this.cloudFr= _cloudFr; } 
    
    public doNetRadiation(Double [] solarRadn,double cva,double cloudFr)
    {
        this.solarRadn = solarRadn;
        this.cva = cva;
        this.cloudFr = cloudFr;
    }
}final class doProcess {
    private Double [] maxSoilTemp;
    public Double [] getmaxSoilTemp()
    { return maxSoilTemp; }

    public void setmaxSoilTemp(Double [] _maxSoilTemp)
    { this.maxSoilTemp= _maxSoilTemp; } 
    
    private Double [] minSoilTemp;
    public Double [] getminSoilTemp()
    { return minSoilTemp; }

    public void setminSoilTemp(Double [] _minSoilTemp)
    { this.minSoilTemp= _minSoilTemp; } 
    
    private Double [] thermalConductivity;
    public Double [] getthermalConductivity()
    { return thermalConductivity; }

    public void setthermalConductivity(Double [] _thermalConductivity)
    { this.thermalConductivity= _thermalConductivity; } 
    
    private Double [] soilTemp;
    public Double [] getsoilTemp()
    { return soilTemp; }

    public void setsoilTemp(Double [] _soilTemp)
    { this.soilTemp= _soilTemp; } 
    
    private Double [] morningSoilTemp;
    public Double [] getmorningSoilTemp()
    { return morningSoilTemp; }

    public void setmorningSoilTemp(Double [] _morningSoilTemp)
    { this.morningSoilTemp= _morningSoilTemp; } 
    
    private Double [] newTemperature;
    public Double [] getnewTemperature()
    { return newTemperature; }

    public void setnewTemperature(Double [] _newTemperature)
    { this.newTemperature= _newTemperature; } 
    
    private Double [] aveSoilTemp;
    public Double [] getaveSoilTemp()
    { return aveSoilTemp; }

    public void setaveSoilTemp(Double [] _aveSoilTemp)
    { this.aveSoilTemp= _aveSoilTemp; } 
    
    private Double [] volSpecHeatSoil;
    public Double [] getvolSpecHeatSoil()
    { return volSpecHeatSoil; }

    public void setvolSpecHeatSoil(Double [] _volSpecHeatSoil)
    { this.volSpecHeatSoil= _volSpecHeatSoil; } 
    
    private Double [] thermalConductance;
    public Double [] getthermalConductance()
    { return thermalConductance; }

    public void setthermalConductance(Double [] _thermalConductance)
    { this.thermalConductance= _thermalConductance; } 
    
    private Double [] heatStorage;
    public Double [] getheatStorage()
    { return heatStorage; }

    public void setheatStorage(Double [] _heatStorage)
    { this.heatStorage= _heatStorage; } 
    
    private double timeOfDaySecs;
    public double gettimeOfDaySecs()
    { return timeOfDaySecs; }

    public void settimeOfDaySecs(double _timeOfDaySecs)
    { this.timeOfDaySecs= _timeOfDaySecs; } 
    
    private double boundaryLayerConductance;
    public double getboundaryLayerConductance()
    { return boundaryLayerConductance; }

    public void setboundaryLayerConductance(double _boundaryLayerConductance)
    { this.boundaryLayerConductance= _boundaryLayerConductance; } 
    
    private double minTempYesterday;
    public double getminTempYesterday()
    { return minTempYesterday; }

    public void setminTempYesterday(double _minTempYesterday)
    { this.minTempYesterday= _minTempYesterday; } 
    
    private double maxTempYesterday;
    public double getmaxTempYesterday()
    { return maxTempYesterday; }

    public void setmaxTempYesterday(double _maxTempYesterday)
    { this.maxTempYesterday= _maxTempYesterday; } 
    
    private double airTemperature;
    public double getairTemperature()
    { return airTemperature; }

    public void setairTemperature(double _airTemperature)
    { this.airTemperature= _airTemperature; } 
    
    private double netRadiation;
    public double getnetRadiation()
    { return netRadiation; }

    public void setnetRadiation(double _netRadiation)
    { this.netRadiation= _netRadiation; } 
    
    private double internalTimeStep;
    public double getinternalTimeStep()
    { return internalTimeStep; }

    public void setinternalTimeStep(double _internalTimeStep)
    { this.internalTimeStep= _internalTimeStep; } 
    
    public doProcess(Double [] maxSoilTemp,Double [] minSoilTemp,Double [] thermalConductivity,Double [] soilTemp,Double [] morningSoilTemp,Double [] newTemperature,Double [] aveSoilTemp,Double [] volSpecHeatSoil,Double [] thermalConductance,Double [] heatStorage,double timeOfDaySecs,double boundaryLayerConductance,double minTempYesterday,double maxTempYesterday,double airTemperature,double netRadiation,double internalTimeStep)
    {
        this.maxSoilTemp = maxSoilTemp;
        this.minSoilTemp = minSoilTemp;
        this.thermalConductivity = thermalConductivity;
        this.soilTemp = soilTemp;
        this.morningSoilTemp = morningSoilTemp;
        this.newTemperature = newTemperature;
        this.aveSoilTemp = aveSoilTemp;
        this.volSpecHeatSoil = volSpecHeatSoil;
        this.thermalConductance = thermalConductance;
        this.heatStorage = heatStorage;
        this.timeOfDaySecs = timeOfDaySecs;
        this.boundaryLayerConductance = boundaryLayerConductance;
        this.minTempYesterday = minTempYesterday;
        this.maxTempYesterday = maxTempYesterday;
        this.airTemperature = airTemperature;
        this.netRadiation = netRadiation;
        this.internalTimeStep = internalTimeStep;
    }
}