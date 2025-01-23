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
    private FWSimVariable<Double[]> InitialValues;
    private FWSimVariable<Double[]> pInitialValues;
    private FWSimVariable<Double> DepthToConstantTemperature;
    private FWSimVariable<Double> timestep;
    private FWSimVariable<Double> latentHeatOfVapourisation;
    private FWSimVariable<Double> stefanBoltzmannConstant;
    private FWSimVariable<Integer> airNode;
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
        addVariable(FWSimVariable.createSimVariable("weather_Latitude", "Latitude", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"deg", null, null, null, this));
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
        addVariable(FWSimVariable.createSimVariable("InitialValues", "Initial soil temperature", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"oC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("pInitialValues", "Initial soil temperature", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"oC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("DepthToConstantTemperature", "Soil depth to constant temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"mm", null, null, 10000, this));
        addVariable(FWSimVariable.createSimVariable("timestep", "Internal time-step (minutes)", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"minutes", null, null, 24.0 * 60.0 * 60.0, this));
        addVariable(FWSimVariable.createSimVariable("latentHeatOfVapourisation", "Latent heat of vapourisation for water", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"miJ/kg", null, null, 2465000, this));
        addVariable(FWSimVariable.createSimVariable("stefanBoltzmannConstant", "The Stefan-Boltzmann constant", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"W/m2/K4", null, null, 0.0000000567, this));
        addVariable(FWSimVariable.createSimVariable("airNode", "The index of the node in the atmosphere (aboveground)", DATA_TYPE.INT, CONTENT_TYPE.constant,"", null, null, 0, this));
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
        addVariable(FWSimVariable.createSimVariable("nodeDepth", "Depths of nodes", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.privat,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thermCondPar1", "Parameter 1 for computing thermal conductivity of soil solids", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.privat,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thermCondPar2", "Parameter 2 for computing thermal conductivity of soil solids", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.privat,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thermCondPar3", "Parameter 3 for computing thermal conductivity of soil solids", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.privat,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thermCondPar4", "Parameter 4 for computing thermal conductivity of soil solids", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.privat,"", null, null, null, this));
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
        addVariable(FWSimVariable.createSimVariable("soilRoughnessHeight", "Height of soil roughness", DATA_TYPE.DOUBLE, CONTENT_TYPE.privat,"mm", null, null, 0, this));
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
        Double [] t_pInitialValues = pInitialValues.getValue();
        double t_DepthToConstantTemperature = DepthToConstantTemperature.getValue();
        double t_timestep = timestep.getValue();
        double t_latentHeatOfVapourisation = latentHeatOfVapourisation.getValue();
        double t_stefanBoltzmannConstant = stefanBoltzmannConstant.getValue();
        Integer t_airNode = airNode.getValue();
        Integer t_surfaceNode = surfaceNode.getValue();
        Integer t_topsoilNode = topsoilNode.getValue();
        Integer t_numPhantomNodes = numPhantomNodes.getValue();
        double t_constantBoundaryLayerConductance = constantBoundaryLayerConductance.getValue();
        Integer t_numIterationsForBoundaryLayerConductance = numIterationsForBoundaryLayerConductance.getValue();
        double t_defaultTimeOfMaximumTemperature = defaultTimeOfMaximumTemperature.getValue();
        double t_defaultInstrumentHeight = defaultInstrumentHeight.getValue();
        double t_bareSoilRoughness = bareSoilRoughness.getValue();
        Double [] t_nodeDepth = nodeDepth.getDefault();
        Double [] t_thermCondPar1 = thermCondPar1.getDefault();
        Double [] t_thermCondPar2 = thermCondPar2.getDefault();
        Double [] t_thermCondPar3 = thermCondPar3.getDefault();
        Double [] t_thermCondPar4 = thermCondPar4.getDefault();
        double t_pom = pom.getValue();
        double t_soilRoughnessHeight = soilRoughnessHeight.getDefault();
        double t_nu = nu.getValue();
        String t_boundarLayerConductanceSource = boundarLayerConductanceSource.getValue();
        String t_netRadiationSource = netRadiationSource.getValue();
        double t_MissingValue = MissingValue.getValue();
        String [] t_soilConstituentNames = soilConstituentNames.getValue();
        Double [] t_InitialValues = InitialValues.getDefault();
        Boolean t_doInitialisationStuff = doInitialisationStuff.getDefault();
        double t_internalTimeStep = internalTimeStep.getDefault();
        double t_timeOfDaySecs = timeOfDaySecs.getDefault();
        Integer t_numNodes = numNodes.getDefault();
        Integer t_numLayers = numLayers.getDefault();
        Double [] t_volSpecHeatSoil = volSpecHeatSoil.getDefault();
        Double [] t_soilTemp = soilTemp.getDefault();
        Double [] t_morningSoilTemp = morningSoilTemp.getDefault();
        Double [] t_heatStorage = heatStorage.getDefault();
        Double [] t_thermalConductance = thermalConductance.getDefault();
        Double [] t_thermalConductivity = thermalConductivity.getDefault();
        double t_boundaryLayerConductance = boundaryLayerConductance.getDefault();
        Double [] t_newTemperature = newTemperature.getDefault();
        double t_airTemperature = airTemperature.getDefault();
        double t_maxTempYesterday = maxTempYesterday.getDefault();
        double t_minTempYesterday = minTempYesterday.getDefault();
        Double [] t_soilWater = soilWater.getDefault();
        Double [] t_minSoilTemp = minSoilTemp.getDefault();
        Double [] t_maxSoilTemp = maxSoilTemp.getDefault();
        Double [] t_aveSoilTemp = aveSoilTemp.getDefault();
        Double [] t_aveSoilWater = aveSoilWater.getDefault();
        Double [] t_thickness = thickness.getDefault();
        Double [] t_bulkDensity = bulkDensity.getDefault();
        Double [] t_rocks = rocks.getDefault();
        Double [] t_carbon = carbon.getDefault();
        Double [] t_sand = sand.getDefault();
        Double [] t_silt = silt.getDefault();
        Double [] t_clay = clay.getDefault();
        double t_instrumentHeight = instrumentHeight.getDefault();
        double t_netRadiation = netRadiation.getDefault();
        double t_canopyHeight = canopyHeight.getDefault();
        double t_instrumHeight = instrumHeight.getDefault();
        t_doInitialisationStuff = true;
        t_instrumentHeight = getIniVariables(t_instrumentHeight, t_instrumHeight, t_defaultInstrumentHeight);
        zz_getProfileVariables = Calculate_getProfileVariables(t_heatStorage, t_minSoilTemp, t_bulkDensity, t_numNodes, t_physical_BD, t_maxSoilTemp, t_waterBalance_SW, t_organic_Carbon, t_physical_Rocks, t_nodeDepth, t_topsoilNode, t_newTemperature, t_surfaceNode, t_soilWater, t_thermalConductance, t_thermalConductivity, t_sand, t_carbon, t_thickness, t_numPhantomNodes, t_physical_ParticleSizeSand, t_rocks, t_clay, t_physical_ParticleSizeSilt, t_airNode, t_physical_ParticleSizeClay, t_soilTemp, t_numLayers, t_physical_Thickness, t_silt, t_volSpecHeatSoil, t_aveSoilTemp, t_morningSoilTemp, t_DepthToConstantTemperature, t_MissingValue);
        t_heatStorage = zz_getProfileVariables.getheatStorage();
        t_minSoilTemp = zz_getProfileVariables.getminSoilTemp();
        t_bulkDensity = zz_getProfileVariables.getbulkDensity();
        t_maxSoilTemp = zz_getProfileVariables.getmaxSoilTemp();
        t_nodeDepth = zz_getProfileVariables.getnodeDepth();
        t_newTemperature = zz_getProfileVariables.getnewTemperature();
        t_soilWater = zz_getProfileVariables.getsoilWater();
        t_thermalConductance = zz_getProfileVariables.getthermalConductance();
        t_thermalConductivity = zz_getProfileVariables.getthermalConductivity();
        t_sand = zz_getProfileVariables.getsand();
        t_carbon = zz_getProfileVariables.getcarbon();
        t_thickness = zz_getProfileVariables.getthickness();
        t_rocks = zz_getProfileVariables.getrocks();
        t_clay = zz_getProfileVariables.getclay();
        t_soilTemp = zz_getProfileVariables.getsoilTemp();
        t_silt = zz_getProfileVariables.getsilt();
        t_volSpecHeatSoil = zz_getProfileVariables.getvolSpecHeatSoil();
        t_aveSoilTemp = zz_getProfileVariables.getaveSoilTemp();
        t_morningSoilTemp = zz_getProfileVariables.getmorningSoilTemp();
        t_numNodes = zz_getProfileVariables.getnumNodes();
        t_numLayers = zz_getProfileVariables.getnumLayers();
        zz_readParam = Calculate_readParam(t_bareSoilRoughness, t_newTemperature, t_soilRoughnessHeight, t_soilTemp, t_thermCondPar2, t_numLayers, t_bulkDensity, t_numNodes, t_thermCondPar3, t_thermCondPar4, t_clay, t_thermCondPar1, t_weather_Tav, t_clock_Today_DayOfYear, t_surfaceNode, t_weather_Amp, t_thickness, t_weather_Latitude);
        t_newTemperature = zz_readParam.getnewTemperature();
        t_soilTemp = zz_readParam.getsoilTemp();
        t_thermCondPar2 = zz_readParam.getthermCondPar2();
        t_thermCondPar3 = zz_readParam.getthermCondPar3();
        t_thermCondPar4 = zz_readParam.getthermCondPar4();
        t_thermCondPar1 = zz_readParam.getthermCondPar1();
        t_soilRoughnessHeight = zz_readParam.getsoilRoughnessHeight();
        t_InitialValues = t_pInitialValues;
        nodeDepth.setValue(t_nodeDepth, this);
        thermCondPar1.setValue(t_thermCondPar1, this);
        thermCondPar2.setValue(t_thermCondPar2, this);
        thermCondPar3.setValue(t_thermCondPar3, this);
        thermCondPar4.setValue(t_thermCondPar4, this);
        soilRoughnessHeight.setValue(t_soilRoughnessHeight, this);
        InitialValues.setValue(t_InitialValues, this);
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
        Double [] t_InitialValues = InitialValues.getValue();
        Double [] t_pInitialValues = pInitialValues.getValue();
        double t_DepthToConstantTemperature = DepthToConstantTemperature.getValue();
        double t_timestep = timestep.getValue();
        double t_latentHeatOfVapourisation = latentHeatOfVapourisation.getValue();
        double t_stefanBoltzmannConstant = stefanBoltzmannConstant.getValue();
        Integer t_airNode = airNode.getValue();
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
        zz_getOtherVariables = Calculate_getOtherVariables(t_numLayers, t_numNodes, t_soilWater, t_instrumentHeight, t_soilRoughnessHeight, t_waterBalance_SW, t_microClimate_CanopyHeight, t_canopyHeight);
        t_soilWater = zz_getOtherVariables.getsoilWater();
        t_instrumentHeight = zz_getOtherVariables.getinstrumentHeight();
        t_canopyHeight = zz_getOtherVariables.getcanopyHeight();
        if (t_doInitialisationStuff)
        {
            if (ValuesInArray(t_InitialValues, t_MissingValue))
            {
                Arrays.fill(t_soilTemp, 0.0d);
                System.arraycopy(t_InitialValues, 0, t_soilTemp, t_topsoilNode, t_InitialValues.length);
            }
            else
            {
                t_soilTemp = calcSoilTemperature(t_soilTemp, t_weather_Tav, t_clock_Today_DayOfYear, t_surfaceNode, t_numNodes, t_weather_Amp, t_thickness, t_weather_Latitude);
                Arrays.fill(t_InitialValues, 0.0d);
                System.arraycopy(t_soilTemp, t_topsoilNode, t_InitialValues, 0, t_numLayers);
            }
            t_soilTemp[t_airNode] = t_weather_MeanT;
            t_soilTemp[t_surfaceNode] = calcSurfaceTemperature(t_weather_MeanT, t_weather_MaxT, t_waterBalance_Salb, t_weather_Radn);
            for (i=t_numNodes + 1 ; i!=t_soilTemp.length ; i+=1)
            {
                t_soilTemp[i] = t_weather_Tav;
            }
            System.arraycopy(t_soilTemp, 0, t_newTemperature, 0, t_soilTemp.length);
            t_maxTempYesterday = t_weather_MaxT;
            t_minTempYesterday = t_weather_MinT;
            t_doInitialisationStuff = false;
        }
        zz_doProcess = Calculate_doProcess(t_timeOfDaySecs, t_netRadiation, t_minSoilTemp, t_maxSoilTemp, t_numIterationsForBoundaryLayerConductance, t_timestep, t_boundaryLayerConductance, t_maxTempYesterday, t_airNode, t_soilTemp, t_airTemperature, t_newTemperature, t_weather_MaxT, t_internalTimeStep, t_boundarLayerConductanceSource, t_thermalConductivity, t_minTempYesterday, t_aveSoilTemp, t_morningSoilTemp, t_weather_MeanT, t_constantBoundaryLayerConductance, t_weather_MinT, t_clock_Today_DayOfYear, t_weather_Radn, t_weather_Latitude, t_soilConstituentNames, t_numNodes, t_volSpecHeatSoil, t_soilWater, t_nodeDepth, t_thickness, t_surfaceNode, t_MissingValue, t_carbon, t_bulkDensity, t_pom, t_rocks, t_sand, t_ps, t_silt, t_clay, t_defaultTimeOfMaximumTemperature, t_waterBalance_Eo, t_waterBalance_Eos, t_waterBalance_Salb, t_stefanBoltzmannConstant, t_weather_AirPressure, t_weather_Wind, t_instrumentHeight, t_canopyHeight, t_heatStorage, t_netRadiationSource, t_latentHeatOfVapourisation, t_waterBalance_Es, t_thermalConductance, t_nu);
        t_minSoilTemp = zz_doProcess.getminSoilTemp();
        t_maxSoilTemp = zz_doProcess.getmaxSoilTemp();
        t_soilTemp = zz_doProcess.getsoilTemp();
        t_newTemperature = zz_doProcess.getnewTemperature();
        t_thermalConductivity = zz_doProcess.getthermalConductivity();
        t_aveSoilTemp = zz_doProcess.getaveSoilTemp();
        t_morningSoilTemp = zz_doProcess.getmorningSoilTemp();
        t_volSpecHeatSoil = zz_doProcess.getvolSpecHeatSoil();
        t_heatStorage = zz_doProcess.getheatStorage();
        t_thermalConductance = zz_doProcess.getthermalConductance();
        t_timeOfDaySecs = zz_doProcess.gettimeOfDaySecs();
        t_netRadiation = zz_doProcess.getnetRadiation();
        t_airTemperature = zz_doProcess.getairTemperature();
        t_internalTimeStep = zz_doProcess.getinternalTimeStep();
        t_minTempYesterday = zz_doProcess.getminTempYesterday();
        t_boundaryLayerConductance = zz_doProcess.getboundaryLayerConductance();
        t_maxTempYesterday = zz_doProcess.getmaxTempYesterday();
        InitialValues.setValue(t_InitialValues, this);
        doInitialisationStuff.setValue(t_doInitialisationStuff, this);
        internalTimeStep.setValue(t_internalTimeStep, this);
        timeOfDaySecs.setValue(t_timeOfDaySecs, this);
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
        instrumentHeight.setValue(t_instrumentHeight, this);
        netRadiation.setValue(t_netRadiation, this);
        canopyHeight.setValue(t_canopyHeight, this);
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
        Double[] oldDepth;
        Double[] oldBulkDensity;
        Double[] oldSoilWater;
        numLayers = physical_Thickness.length;
        numNodes = numLayers + numPhantomNodes;
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
        Arrays.fill(carbon, 0.0d);
        for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
        {
            carbon[layer] = organic_Carbon[layer - 1];
        }
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            carbon[layer] = carbon[numLayers];
        }
        Arrays.fill(rocks, 0.0d);
        for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
        {
            rocks[layer] = physical_Rocks[layer - 1];
        }
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            rocks[layer] = rocks[numLayers];
        }
        Arrays.fill(sand, 0.0d);
        for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
        {
            sand[layer] = physical_ParticleSizeSand[layer - 1];
        }
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            sand[layer] = sand[numLayers];
        }
        Arrays.fill(silt, 0.0d);
        for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
        {
            silt[layer] = physical_ParticleSizeSilt[layer - 1];
        }
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            silt[layer] = silt[numLayers];
        }
        Arrays.fill(clay, 0.0d);
        for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
        {
            clay[layer] = physical_ParticleSizeClay[layer - 1];
        }
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            clay[layer] = clay[numLayers];
        }
        Arrays.fill(maxSoilTemp, 0.0d);
        Arrays.fill(minSoilTemp, 0.0d);
        Arrays.fill(aveSoilTemp, 0.0d);
        Arrays.fill(volSpecHeatSoil, 0.0d);
        Arrays.fill(soilTemp, 0.0d);
        Arrays.fill(morningSoilTemp, 0.0d);
        Arrays.fill(newTemperature, 0.0d);
        Arrays.fill(thermalConductivity, 0.0d);
        Arrays.fill(heatStorage, 0.0d);
        Arrays.fill(thermalConductance, 0.0d);
        return new getProfileVariables(heatStorage, minSoilTemp, bulkDensity, maxSoilTemp, nodeDepth, newTemperature, soilWater, thermalConductance, thermalConductivity, sand, carbon, thickness, rocks, clay, soilTemp, silt, volSpecHeatSoil, aveSoilTemp, morningSoilTemp, numNodes, numLayers);
    }
    public doThermalConductivityCoeffs Calculate_doThermalConductivityCoeffs (Double [] thermCondPar2, Integer numLayers, Double [] bulkDensity, Integer numNodes, Double [] thermCondPar3, Double [] thermCondPar4, Double [] clay, Double [] thermCondPar1)
    {
        Integer layer;
        Double[] oldGC1;
        Double[] oldGC2;
        Double[] oldGC3;
        Double[] oldGC4;
        Integer element;
        oldGC1 = thermCondPar1;
        Arrays.fill(thermCondPar1, 0.0d);
        if (oldGC1 != null)
        {
            System.arraycopy(oldGC1, 0, thermCondPar1, 0, Math.min(numNodes + 1, oldGC1.length));
        }
        oldGC2 = thermCondPar2;
        Arrays.fill(thermCondPar2, 0.0d);
        if (oldGC2 != null)
        {
            System.arraycopy(oldGC2, 0, thermCondPar2, 0, Math.min(numNodes + 1, oldGC2.length));
        }
        oldGC3 = thermCondPar3;
        Arrays.fill(thermCondPar3, 0.0d);
        if (oldGC3 != null)
        {
            System.arraycopy(oldGC3, 0, thermCondPar3, 0, Math.min(numNodes + 1, oldGC3.length));
        }
        oldGC4 = thermCondPar4;
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
        Double[] a = new Double[numNodes + 1 + 1];
        Double[] b = new Double[numNodes + 1];
        Double[] c = new Double[numNodes + 1];
        Double[] d = new Double[numNodes + 1];
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
        Double[] thermCondLayers = new Double[numNodes + 1];
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
        Double[] volspecHeatSoil_ = new Double[numNodes + 1];
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
        Double[] m1 = new Double[ITERATIONSperDAY + 1];
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
        Double[] solarRadn = new Double[49];
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
        Double[] CumThickness = new Double[Thickness.length];
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
        Double[] cumulativeDepth;
        double w;
        double dh;
        double zd;
        double offset;
        Double[] soilTemp = new Double[numNodes + 1 + 1];
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