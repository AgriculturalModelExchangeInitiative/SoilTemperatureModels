package net.simplace.sim.components.Campbell;
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


public class Campbell extends FWSimComponent
{
    private FWSimVariable<Integer> NLAYR;
    private FWSimVariable<Double[]> THICK;
    private FWSimVariable<Double[]> BD;
    private FWSimVariable<Double[]> SLCARB;
    private FWSimVariable<Double[]> CLAY;
    private FWSimVariable<Double[]> SLROCK;
    private FWSimVariable<Double[]> SLSILT;
    private FWSimVariable<Double[]> SLSAND;
    private FWSimVariable<Double[]> SW;
    private FWSimVariable<Double[]> THICKApsim;
    private FWSimVariable<Double[]> DEPTHApsim;
    private FWSimVariable<Double> CONSTANT_TEMPdepth;
    private FWSimVariable<Double[]> BDApsim;
    private FWSimVariable<Double> T2M;
    private FWSimVariable<Double> TMAX;
    private FWSimVariable<Double> TMIN;
    private FWSimVariable<Double> TAV;
    private FWSimVariable<Double> TAMP;
    private FWSimVariable<Double> XLAT;
    private FWSimVariable<Double[]> CLAYApsim;
    private FWSimVariable<Double[]> SWApsim;
    private FWSimVariable<Integer> DOY;
    private FWSimVariable<Double> airPressure;
    private FWSimVariable<Double> canopyHeight;
    private FWSimVariable<Double> SALB;
    private FWSimVariable<Double> SRAD;
    private FWSimVariable<Double> ESP;
    private FWSimVariable<Double> ES;
    private FWSimVariable<Double> EOAD;
    private FWSimVariable<Double[]> soilTemp;
    private FWSimVariable<Double[]> newTemperature;
    private FWSimVariable<Double[]> minSoilTemp;
    private FWSimVariable<Double[]> maxSoilTemp;
    private FWSimVariable<Double[]> aveSoilTemp;
    private FWSimVariable<Double[]> morningSoilTemp;
    private FWSimVariable<Double[]> thermalCondPar1;
    private FWSimVariable<Double[]> thermalCondPar2;
    private FWSimVariable<Double[]> thermalCondPar3;
    private FWSimVariable<Double[]> thermalCondPar4;
    private FWSimVariable<Double[]> thermalConductivity;
    private FWSimVariable<Double[]> thermalConductance;
    private FWSimVariable<Double[]> heatStorage;
    private FWSimVariable<Double[]> volSpecHeatSoil;
    private FWSimVariable<Double> maxTempYesterday;
    private FWSimVariable<Double> minTempYesterday;
    private FWSimVariable<Double> instrumentHeight;
    private FWSimVariable<String> boundaryLayerConductanceSource;
    private FWSimVariable<String> netRadiationSource;
    private FWSimVariable<Double> windSpeed;
    private FWSimVariable<Double[]> SLCARBApsim;
    private FWSimVariable<Double[]> SLROCKApsim;
    private FWSimVariable<Double[]> SLSILTApsim;
    private FWSimVariable<Double[]> SLSANDApsim;
    private FWSimVariable<Double> _boundaryLayerConductance;

    public Campbell(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public Campbell(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("NLAYR", "number of soil layers in profile", DATA_TYPE.INT, CONTENT_TYPE.constant,"dimensionless", 1, null, 10, this));
        addVariable(FWSimVariable.createSimVariable("THICK", "Soil layer thickness of layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"mm", 1, null, null, this));
        addVariable(FWSimVariable.createSimVariable("BD", "bd (soil bulk density)", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"g/cm3             uri :", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("SLCARB", "Volumetric fraction of organic matter in the soil", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("CLAY", "Proportion of CLAY in each layer of profile", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"", 0, 100, 50, this));
        addVariable(FWSimVariable.createSimVariable("SLROCK", "Volumetric fraction of rocks in the soil", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("SLSILT", "Volumetric fraction of silt in the soil", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("SLSAND", "Volumetric fraction of sand in the soil", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("SW", "volumetric water content", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"cc water / cc soil", 0, 1, 0.5, this));
        addVariable(FWSimVariable.createSimVariable("THICKApsim", "APSIM soil layer depths of layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"mm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("DEPTHApsim", "Apsim node depths", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"m", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("CONSTANT_TEMPdepth", "Depth of constant temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"mm", null, null, 1000.0, this));
        addVariable(FWSimVariable.createSimVariable("BDApsim", "Apsim bd (soil bulk density)", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"g/cm3             uri :", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("T2M", "Mean daily Air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"", -60, 60, null, this));
        addVariable(FWSimVariable.createSimVariable("TMAX", "Max daily Air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"", -60, 60, null, this));
        addVariable(FWSimVariable.createSimVariable("TMIN", "Min daily Air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"", -60, 60, null, this));
        addVariable(FWSimVariable.createSimVariable("TAV", "Average annual air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", -60, 60, null, this));
        addVariable(FWSimVariable.createSimVariable("TAMP", "Amplitude air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", -100, 100, null, this));
        addVariable(FWSimVariable.createSimVariable("XLAT", "Latitude", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("CLAYApsim", "Apsim proportion of CLAY in each layer of profile", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("SWApsim", "Apsim volumetric water content", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"cc water / cc soil", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("DOY", "Day of year", DATA_TYPE.INT, CONTENT_TYPE.input,"dimensionless", 1, 366, 1, this));
        addVariable(FWSimVariable.createSimVariable("airPressure", "Air pressure", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"hPA", null, null, 1010, this));
        addVariable(FWSimVariable.createSimVariable("canopyHeight", "height of canopy above ground", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"m", 0, null, 0.057, this));
        addVariable(FWSimVariable.createSimVariable("SALB", "Soil albedo", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"dimensionless", 0, 1, null, this));
        addVariable(FWSimVariable.createSimVariable("SRAD", "Solar radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"MJ/m2", 0, null, null, this));
        addVariable(FWSimVariable.createSimVariable("ESP", "Potential evaporation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", 0, null, null, this));
        addVariable(FWSimVariable.createSimVariable("ES", "Actual evaporation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", 0, null, null, this));
        addVariable(FWSimVariable.createSimVariable("EOAD", "Potential evapotranspiration", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", 0, null, null, this));
        addVariable(FWSimVariable.createSimVariable("soilTemp", "Temperature at end of last time-step within a day - midnight in layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("newTemperature", "Soil temperature at the end of one iteration", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("minSoilTemp", "Minimum soil temperature in layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("maxSoilTemp", "Maximum soil temperature in layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("aveSoilTemp", "Temperature averaged over all time-steps within a day in layers.", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("morningSoilTemp", "Temperature  in the morning in layers.", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thermalCondPar1", "thermal conductivity coeff in layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"(W/m2/K)", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thermalCondPar2", "thermal conductivity coeff in layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"(W/m2/K)", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thermalCondPar3", "thermal conductivity coeff in layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"(W/m2/K)", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thermalCondPar4", "thermal conductivity coeff in layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"(W/m2/K)", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thermalConductivity", "thermal conductivity in layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"(W/m2/K)", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("thermalConductance", "Thermal conductance between layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"(W/m2/K)", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("heatStorage", "Heat storage between layers (internal)", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"J/s/K", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("volSpecHeatSoil", "Volumetric specific heat over the soil profile", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"J/K/m3", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("maxTempYesterday", "Air max temperature from previous day", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"", -60, 60, null, this));
        addVariable(FWSimVariable.createSimVariable("minTempYesterday", "Air min temperature from previous day", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"", -60, 60, null, this));
        addVariable(FWSimVariable.createSimVariable("instrumentHeight", "Default instrument height", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"m", 0, null, 1.2, this));
        addVariable(FWSimVariable.createSimVariable("boundaryLayerConductanceSource", "Flag whether boundary layer conductance is calculated or gotten from input", DATA_TYPE.CHAR, CONTENT_TYPE.constant,"dimensionless", null, null, "calc", this));
        addVariable(FWSimVariable.createSimVariable("netRadiationSource", "Flag whether net radiation is calculated or gotten from input", DATA_TYPE.CHAR, CONTENT_TYPE.constant,"dimensionless", null, null, "calc", this));
        addVariable(FWSimVariable.createSimVariable("windSpeed", "Speed of wind", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"m/s", 0.0, null, 3.0, this));
        addVariable(FWSimVariable.createSimVariable("SLCARBApsim", "Apsim volumetric fraction of organic matter in the soil", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("SLROCKApsim", "Apsim volumetric fraction of rocks in the soil", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("SLSILTApsim", "Apsim volumetric fraction of silt in the soil", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("SLSANDApsim", "Apsim volumetric fraction of sand in the soil", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("_boundaryLayerConductance", "Boundary layer conductance", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"K/W", null, null, null, this));

        return iFieldMap;
    }
    @Override
    protected void init()
    {
        doThermalConductivityCoeffs zz_doThermalConductivityCoeffs;
        CalcSoilTemp zz_CalcSoilTemp;
        Integer t_NLAYR = NLAYR.getValue();
        Double [] t_THICK = THICK.getValue();
        Double [] t_BD = BD.getValue();
        Double [] t_SLCARB = SLCARB.getValue();
        Double [] t_CLAY = CLAY.getValue();
        Double [] t_SLROCK = SLROCK.getValue();
        Double [] t_SLSILT = SLSILT.getValue();
        Double [] t_SLSAND = SLSAND.getValue();
        Double [] t_SW = SW.getValue();
        double t_CONSTANT_TEMPdepth = CONSTANT_TEMPdepth.getValue();
        double t_T2M = T2M.getValue();
        double t_TMAX = TMAX.getValue();
        double t_TMIN = TMIN.getValue();
        double t_TAV = TAV.getValue();
        double t_TAMP = TAMP.getValue();
        double t_XLAT = XLAT.getValue();
        Integer t_DOY = DOY.getValue();
        double t_airPressure = airPressure.getValue();
        double t_canopyHeight = canopyHeight.getValue();
        double t_SALB = SALB.getValue();
        double t_SRAD = SRAD.getValue();
        double t_ESP = ESP.getValue();
        double t_ES = ES.getValue();
        double t_EOAD = EOAD.getValue();
        double t_instrumentHeight = instrumentHeight.getValue();
        String t_boundaryLayerConductanceSource = boundaryLayerConductanceSource.getValue();
        String t_netRadiationSource = netRadiationSource.getValue();
        double t_windSpeed = windSpeed.getValue();
        List<Double> t_THICKApsim = THICKApsim.getDefault();
        List<Double> t_DEPTHApsim = DEPTHApsim.getDefault();
        List<Double> t_BDApsim = BDApsim.getDefault();
        List<Double> t_CLAYApsim = CLAYApsim.getDefault();
        List<Double> t_SWApsim = SWApsim.getDefault();
        List<Double> t_soilTemp = soilTemp.getDefault();
        List<Double> t_newTemperature = newTemperature.getDefault();
        List<Double> t_minSoilTemp = minSoilTemp.getDefault();
        List<Double> t_maxSoilTemp = maxSoilTemp.getDefault();
        List<Double> t_aveSoilTemp = aveSoilTemp.getDefault();
        List<Double> t_morningSoilTemp = morningSoilTemp.getDefault();
        List<Double> t_thermalCondPar1 = thermalCondPar1.getDefault();
        List<Double> t_thermalCondPar2 = thermalCondPar2.getDefault();
        List<Double> t_thermalCondPar3 = thermalCondPar3.getDefault();
        List<Double> t_thermalCondPar4 = thermalCondPar4.getDefault();
        List<Double> t_thermalConductivity = thermalConductivity.getDefault();
        List<Double> t_thermalConductance = thermalConductance.getDefault();
        List<Double> t_heatStorage = heatStorage.getDefault();
        List<Double> t_volSpecHeatSoil = volSpecHeatSoil.getDefault();
        double t_maxTempYesterday = maxTempYesterday.getDefault();
        double t_minTempYesterday = minTempYesterday.getDefault();
        List<Double> t_SLCARBApsim = SLCARBApsim.getDefault();
        List<Double> t_SLROCKApsim = SLROCKApsim.getDefault();
        List<Double> t_SLSILTApsim = SLSILTApsim.getDefault();
        List<Double> t_SLSANDApsim = SLSANDApsim.getDefault();
        double t__boundaryLayerConductance = _boundaryLayerConductance.getDefault();
        t_THICKApsim = new ArrayList<>(Arrays.asList());
        t_DEPTHApsim = new ArrayList<>(Arrays.asList());
        t_BDApsim = new ArrayList<>(Arrays.asList());
        t_CLAYApsim = new ArrayList<>(Arrays.asList());
        t_SWApsim = new ArrayList<>(Arrays.asList());
        t_soilTemp = new ArrayList<>(Arrays.asList());
        t_newTemperature = new ArrayList<>(Arrays.asList());
        t_minSoilTemp = new ArrayList<>(Arrays.asList());
        t_maxSoilTemp = new ArrayList<>(Arrays.asList());
        t_aveSoilTemp = new ArrayList<>(Arrays.asList());
        t_morningSoilTemp = new ArrayList<>(Arrays.asList());
        t_thermalCondPar1 = new ArrayList<>(Arrays.asList());
        t_thermalCondPar2 = new ArrayList<>(Arrays.asList());
        t_thermalCondPar3 = new ArrayList<>(Arrays.asList());
        t_thermalCondPar4 = new ArrayList<>(Arrays.asList());
        t_thermalConductivity = new ArrayList<>(Arrays.asList());
        t_thermalConductance = new ArrayList<>(Arrays.asList());
        t_heatStorage = new ArrayList<>(Arrays.asList());
        t_volSpecHeatSoil = new ArrayList<>(Arrays.asList());
        t_maxTempYesterday = 0.0d;
        t_minTempYesterday = 0.0d;
        t_SLCARBApsim = new ArrayList<>(Arrays.asList());
        t_SLROCKApsim = new ArrayList<>(Arrays.asList());
        t_SLSILTApsim = new ArrayList<>(Arrays.asList());
        t_SLSANDApsim = new ArrayList<>(Arrays.asList());
        t__boundaryLayerConductance = 0.0d;
        List<> DoubleheatCapacity = new ArrayList<>(Arrays.asList());
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
        soilRoughnessHeight = 57.0d;
        defaultInstrumentHeight = 1.2d;
        AltitudeMetres = 18.0d;
        NUM_PHANTOM_NODES = 5;
        AIRnode = 0;
        SURFACEnode = 1;
        TOPSOILnode = 2;
        if (t_instrumentHeight > 0.00001d)
        {
            t_instrumentHeight = t_instrumentHeight;
        }
        else
        {
            t_instrumentHeight = defaultInstrumentHeight;
        }
        numNodes = t_NLAYR + NUM_PHANTOM_NODES;
        t_THICKApsim = new ArrayList<>(Arrays.asList(0.0d)) * (t_NLAYR + 1 + NUM_PHANTOM_NODES);
        for (layer=1 ; layer!=t_NLAYR + 1 ; layer+=1)
        {
            THICKApsim.set(layer,t_THICK[layer - 1]);
        }
        sumThickness = 0.0d;
        for (I=1 ; I!=t_NLAYR + 1 ; I+=1)
        {
            sumThickness = sumThickness + t_THICKApsim.get(I);
        }
        BelowProfileDepth = Math.max(t_CONSTANT_TEMPdepth - sumThickness, 1000.0d);
        thicknessForPhantomNodes = BelowProfileDepth * 2.0d / NUM_PHANTOM_NODES;
        firstPhantomNode = t_NLAYR;
        for (I=firstPhantomNode ; I!=firstPhantomNode + NUM_PHANTOM_NODES ; I+=1)
        {
            THICKApsim.set(I,thicknessForPhantomNodes);
        }
        t_DEPTHApsim = new ArrayList<>(Arrays.asList(0.0d)) * (numNodes + 1 + 1);
        DEPTHApsim.set(AIRnode,0.0d);
        DEPTHApsim.set(SURFACEnode,0.0d);
        DEPTHApsim.set(TOPSOILnode,0.5d * t_THICKApsim.get(1) / 1000.0d);
        for (node=TOPSOILnode ; node!=numNodes + 1 ; node+=1)
        {
            sumThickness = 0.0d;
            for (I=1 ; I!=node ; I+=1)
            {
                sumThickness = sumThickness + t_THICKApsim.get(I);
            }
            DEPTHApsim.set(node + 1,(sumThickness + (0.5d * t_THICKApsim.get(node))) / 1000.0d);
        }
        t_BDApsim = new ArrayList<>(Arrays.asList(0.0d)) * (t_NLAYR + 1 + NUM_PHANTOM_NODES);
        for (layer=1 ; layer!=t_NLAYR + 1 ; layer+=1)
        {
            BDApsim.set(layer,t_BD[layer - 1]);
        }
        BDApsim.set(numNodes,t_BDApsim.get(t_NLAYR));
        for (layer=t_NLAYR + 1 ; layer!=t_NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            BDApsim.set(layer,t_BDApsim.get(t_NLAYR));
        }
        t_SWApsim = new ArrayList<>(Arrays.asList(0.0d)) * (t_NLAYR + 1 + NUM_PHANTOM_NODES);
        for (layer=1 ; layer!=t_NLAYR + 1 ; layer+=1)
        {
            SWApsim.set(layer,t_SW[layer - 1]);
        }
        for (layer=t_NLAYR + 1 ; layer!=t_NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SWApsim.set(layer,t_SWApsim.get((t_NLAYR - 1)) * t_THICKApsim.get((t_NLAYR - 1)) / t_THICKApsim.get(t_NLAYR));
        }
        t_SLCARBApsim = new ArrayList<>(Arrays.asList(0.0d)) * (t_NLAYR + 1 + NUM_PHANTOM_NODES);
        for (layer=1 ; layer!=t_NLAYR + 1 ; layer+=1)
        {
            SLCARBApsim.set(layer,t_SLCARB[layer - 1]);
        }
        for (layer=t_NLAYR + 1 ; layer!=t_NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SLCARBApsim.set(layer,t_SLCARBApsim.get(t_NLAYR));
        }
        t_SLROCKApsim = new ArrayList<>(Arrays.asList(0.0d)) * (t_NLAYR + 1 + NUM_PHANTOM_NODES);
        for (layer=1 ; layer!=t_NLAYR + 1 ; layer+=1)
        {
            SLROCKApsim.set(layer,t_SLROCK[layer - 1]);
        }
        for (layer=t_NLAYR + 1 ; layer!=t_NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SLROCKApsim.set(layer,t_SLROCKApsim.get(t_NLAYR));
        }
        t_SLSANDApsim = new ArrayList<>(Arrays.asList(0.0d)) * (t_NLAYR + 1 + NUM_PHANTOM_NODES);
        for (layer=1 ; layer!=t_NLAYR + 1 ; layer+=1)
        {
            SLSANDApsim.set(layer,t_SLSAND[layer - 1]);
        }
        for (layer=t_NLAYR + 1 ; layer!=t_NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SLSANDApsim.set(layer,t_SLSANDApsim.get(t_NLAYR));
        }
        t_SLSILTApsim = new ArrayList<>(Arrays.asList(0.0d)) * (t_NLAYR + 1 + NUM_PHANTOM_NODES);
        for (layer=1 ; layer!=t_NLAYR + 1 ; layer+=1)
        {
            SLSILTApsim.set(layer,t_SLSILT[layer - 1]);
        }
        for (layer=t_NLAYR + 1 ; layer!=t_NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            SLSILTApsim.set(layer,t_SLSILTApsim.get(t_NLAYR));
        }
        t_CLAYApsim = new ArrayList<>(Arrays.asList(0.0d)) * (t_NLAYR + 1 + NUM_PHANTOM_NODES);
        for (layer=1 ; layer!=t_NLAYR + 1 ; layer+=1)
        {
            CLAYApsim.set(layer,t_CLAY[layer - 1]);
        }
        for (layer=t_NLAYR + 1 ; layer!=t_NLAYR + NUM_PHANTOM_NODES + 1 ; layer+=1)
        {
            CLAYApsim.set(layer,t_CLAYApsim.get(t_NLAYR));
        }
        t_maxSoilTemp = new ArrayList<>(Arrays.asList(0.0d)) * (t_NLAYR + 1 + NUM_PHANTOM_NODES);
        t_minSoilTemp = new ArrayList<>(Arrays.asList(0.0d)) * (t_NLAYR + 1 + NUM_PHANTOM_NODES);
        t_aveSoilTemp = new ArrayList<>(Arrays.asList(0.0d)) * (t_NLAYR + 1 + NUM_PHANTOM_NODES);
        t_volSpecHeatSoil = new ArrayList<>(Arrays.asList(0.0d)) * (numNodes + 1);
        t_soilTemp = new ArrayList<>(Arrays.asList(0.0d)) * (numNodes + 1 + 1);
        t_morningSoilTemp = new ArrayList<>(Arrays.asList(0.0d)) * (numNodes + 1 + 1);
        t_newTemperature = new ArrayList<>(Arrays.asList(0.0d)) * (numNodes + 1 + 1);
        t_thermalConductivity = new ArrayList<>(Arrays.asList(0.0d)) * (numNodes + 1);
        t_heatStorage = new ArrayList<>(Arrays.asList(0.0d)) * (numNodes + 1);
        t_thermalConductance = new ArrayList<>(Arrays.asList(0.0d)) * (numNodes + 1 + 1);
        zz_doThermalConductivityCoeffs = Calculate_doThermalConductivityCoeffs(t_NLAYR, numNodes, t_BDApsim, t_CLAYApsim);
        t_thermalCondPar1 = zz_doThermalConductivityCoeffs.getthermalCondPar1();
        t_thermalCondPar2 = zz_doThermalConductivityCoeffs.getthermalCondPar2();
        t_thermalCondPar3 = zz_doThermalConductivityCoeffs.getthermalCondPar3();
        t_thermalCondPar4 = zz_doThermalConductivityCoeffs.getthermalCondPar4();
        t_newTemperature = CalcSoilTemp(t_THICKApsim, t_TAV, t_TAMP, t_DOY, t_XLAT, numNodes);
        t_instrumentHeight = Math.max(t_instrumentHeight, t_canopyHeight + 0.5d);
        t_soilTemp = CalcSoilTemp(t_THICKApsim, t_TAV, t_TAMP, t_DOY, t_XLAT, numNodes);
        soilTemp.set(AIRnode,t_T2M);
        surfaceT = (1.0d - t_SALB) * (t_T2M + ((t_TMAX - t_T2M) * Math.sqrt(Math.max(t_SRAD, 0.1d) * 23.8846d / 800.0d))) + (t_SALB * t_T2M);
        soilTemp.set(SURFACEnode,surfaceT);
        for (I=numNodes + 1 ; I!=t_soilTemp.size() ; I+=1)
        {
            soilTemp.set(I,t_TAV);
        }
        for (I=0 ; I!=t_soilTemp.size() ; I+=1)
        {
            newTemperature.set(I,t_soilTemp.get(I));
        }
        t_maxTempYesterday = t_TMAX;
        t_minTempYesterday = t_TMIN;
        THICKApsim.setValue(t_THICKApsim.toArray(new Double[0]), this);
        DEPTHApsim.setValue(t_DEPTHApsim.toArray(new Double[0]), this);
        BDApsim.setValue(t_BDApsim.toArray(new Double[0]), this);
        CLAYApsim.setValue(t_CLAYApsim.toArray(new Double[0]), this);
        SWApsim.setValue(t_SWApsim.toArray(new Double[0]), this);
        soilTemp.setValue(t_soilTemp.toArray(new Double[0]), this);
        newTemperature.setValue(t_newTemperature.toArray(new Double[0]), this);
        minSoilTemp.setValue(t_minSoilTemp.toArray(new Double[0]), this);
        maxSoilTemp.setValue(t_maxSoilTemp.toArray(new Double[0]), this);
        aveSoilTemp.setValue(t_aveSoilTemp.toArray(new Double[0]), this);
        morningSoilTemp.setValue(t_morningSoilTemp.toArray(new Double[0]), this);
        thermalCondPar1.setValue(t_thermalCondPar1.toArray(new Double[0]), this);
        thermalCondPar2.setValue(t_thermalCondPar2.toArray(new Double[0]), this);
        thermalCondPar3.setValue(t_thermalCondPar3.toArray(new Double[0]), this);
        thermalCondPar4.setValue(t_thermalCondPar4.toArray(new Double[0]), this);
        thermalConductivity.setValue(t_thermalConductivity.toArray(new Double[0]), this);
        thermalConductance.setValue(t_thermalConductance.toArray(new Double[0]), this);
        heatStorage.setValue(t_heatStorage.toArray(new Double[0]), this);
        volSpecHeatSoil.setValue(t_volSpecHeatSoil.toArray(new Double[0]), this);
        maxTempYesterday.setValue(t_maxTempYesterday, this);
        minTempYesterday.setValue(t_minTempYesterday, this);
        SLCARBApsim.setValue(t_SLCARBApsim.toArray(new Double[0]), this);
        SLROCKApsim.setValue(t_SLROCKApsim.toArray(new Double[0]), this);
        SLSILTApsim.setValue(t_SLSILTApsim.toArray(new Double[0]), this);
        SLSANDApsim.setValue(t_SLSANDApsim.toArray(new Double[0]), this);
        _boundaryLayerConductance.setValue(t__boundaryLayerConductance, this);
    }
    @Override
    protected void process()
    {
        doNetRadiation zz_doNetRadiation;
        Zero zz_Zero;
        doVolumetricSpecificHeat zz_doVolumetricSpecificHeat;
        doThermConductivity zz_doThermConductivity;
        InterpTemp zz_InterpTemp;
        RadnNetInterpolate zz_RadnNetInterpolate;
        boundaryLayerConductanceF zz_boundaryLayerConductanceF;
        doThomas zz_doThomas;
        doUpdate zz_doUpdate;
        Integer t_NLAYR = NLAYR.getValue();
        Double [] t_THICK = THICK.getValue();
        Double [] t_BD = BD.getValue();
        Double [] t_SLCARB = SLCARB.getValue();
        Double [] t_CLAY = CLAY.getValue();
        Double [] t_SLROCK = SLROCK.getValue();
        Double [] t_SLSILT = SLSILT.getValue();
        Double [] t_SLSAND = SLSAND.getValue();
        Double [] t_SW = SW.getValue();
        List<Double> t_THICKApsim = THICKApsim.getValue();
        List<Double> t_DEPTHApsim = DEPTHApsim.getValue();
        double t_CONSTANT_TEMPdepth = CONSTANT_TEMPdepth.getValue();
        List<Double> t_BDApsim = BDApsim.getValue();
        double t_T2M = T2M.getValue();
        double t_TMAX = TMAX.getValue();
        double t_TMIN = TMIN.getValue();
        double t_TAV = TAV.getValue();
        double t_TAMP = TAMP.getValue();
        double t_XLAT = XLAT.getValue();
        List<Double> t_CLAYApsim = CLAYApsim.getValue();
        List<Double> t_SWApsim = SWApsim.getValue();
        Integer t_DOY = DOY.getValue();
        double t_airPressure = airPressure.getValue();
        double t_canopyHeight = canopyHeight.getValue();
        double t_SALB = SALB.getValue();
        double t_SRAD = SRAD.getValue();
        double t_ESP = ESP.getValue();
        double t_ES = ES.getValue();
        double t_EOAD = EOAD.getValue();
        List<Double> t_soilTemp = soilTemp.getValue();
        List<Double> t_newTemperature = newTemperature.getValue();
        List<Double> t_minSoilTemp = minSoilTemp.getValue();
        List<Double> t_maxSoilTemp = maxSoilTemp.getValue();
        List<Double> t_aveSoilTemp = aveSoilTemp.getValue();
        List<Double> t_morningSoilTemp = morningSoilTemp.getValue();
        List<Double> t_thermalCondPar1 = thermalCondPar1.getValue();
        List<Double> t_thermalCondPar2 = thermalCondPar2.getValue();
        List<Double> t_thermalCondPar3 = thermalCondPar3.getValue();
        List<Double> t_thermalCondPar4 = thermalCondPar4.getValue();
        List<Double> t_thermalConductivity = thermalConductivity.getValue();
        List<Double> t_thermalConductance = thermalConductance.getValue();
        List<Double> t_heatStorage = heatStorage.getValue();
        List<Double> t_volSpecHeatSoil = volSpecHeatSoil.getValue();
        double t_maxTempYesterday = maxTempYesterday.getValue();
        double t_minTempYesterday = minTempYesterday.getValue();
        double t_instrumentHeight = instrumentHeight.getValue();
        String t_boundaryLayerConductanceSource = boundaryLayerConductanceSource.getValue();
        String t_netRadiationSource = netRadiationSource.getValue();
        double t_windSpeed = windSpeed.getValue();
        List<Double> t_SLCARBApsim = SLCARBApsim.getValue();
        List<Double> t_SLROCKApsim = SLROCKApsim.getValue();
        List<Double> t_SLSILTApsim = SLSILTApsim.getValue();
        List<Double> t_SLSANDApsim = SLSANDApsim.getValue();
        double t__boundaryLayerConductance = _boundaryLayerConductance.getValue();
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
        String[] soilConstituentNames;
        Integer timeStepIteration;
        double netRadiation;
        double constantBoundaryLayerConductance;
        double precision;
        double cva;
        double cloudFr;
        List<> DoublesolarRadn = new ArrayList<>(Arrays.asList());
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
        numNodes = t_NLAYR + NUM_PHANTOM_NODES;
        soilConstituentNames = new ArrayList<>(Arrays.asList("Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"));
        timeStepIteration = 1;
        constantBoundaryLayerConductance = 20.0d;
        layer = 0;
        cva = 0.0d;
        cloudFr = 0.0d;
        solarRadn = new ArrayList<>(Arrays.asList(0.0d));
        for (layer=0 ; layer!=50 ; layer+=1)
        {
            solarRadn.add(0.0d);
        }
        zz_doNetRadiation = Calculate_doNetRadiation(solarRadn, cloudFr, cva, ITERATIONSperDAY, t_DOY, t_SRAD, t_TMIN, t_XLAT);
        solarRadn = zz_doNetRadiation.getsolarRadn();
        cloudFr = zz_doNetRadiation.getcloudFr();
        cva = zz_doNetRadiation.getcva();
        t_minSoilTemp = Zero(t_minSoilTemp);
        t_maxSoilTemp = Zero(t_maxSoilTemp);
        t_aveSoilTemp = Zero(t_aveSoilTemp);
        t__boundaryLayerConductance = 0.0d;
        internalTimeStep = tempStepSec / (double)(ITERATIONSperDAY);
        t_volSpecHeatSoil = doVolumetricSpecificHeat(t_volSpecHeatSoil, t_SWApsim, numNodes, soilConstituentNames, t_THICKApsim, t_DEPTHApsim);
        t_thermalConductivity = doThermConductivity(t_SWApsim, t_SLCARBApsim, t_SLROCKApsim, t_SLSANDApsim, t_SLSILTApsim, t_CLAYApsim, t_BDApsim, t_thermalConductivity, t_THICKApsim, t_DEPTHApsim, numNodes, soilConstituentNames);
        for (timeStepIteration=1 ; timeStepIteration!=ITERATIONSperDAY + 1 ; timeStepIteration+=1)
        {
            timeOfDaySecs = internalTimeStep * (double)(timeStepIteration);
            if (tempStepSec < (24.0d * 60.0d * 60.0d))
            {
                tMean = t_T2M;
            }
            else
            {
                tMean = InterpTemp(timeOfDaySecs * SEC2HR, t_TMAX, t_TMIN, t_T2M, t_maxTempYesterday, t_minTempYesterday);
            }
            newTemperature.set(AIRnode,tMean);
            netRadiation = RadnNetInterpolate(internalTimeStep, solarRadn.get(timeStepIteration), cloudFr, cva, t_ESP, t_EOAD, tMean, t_SALB, t_soilTemp);
            if (t_boundaryLayerConductanceSource == "constant")
            {
                thermalConductivity.set(AIRnode,constantBoundaryLayerConductance);
            }
            else if ( t_boundaryLayerConductanceSource == "calc")
            {
                thermalConductivity.set(AIRnode,boundaryLayerConductanceF(t_newTemperature, tMean, t_ESP, t_EOAD, t_airPressure, t_canopyHeight, t_windSpeed, t_instrumentHeight));
                for (iteration=1 ; iteration!=BoundaryLayerConductanceIterations + 1 ; iteration+=1)
                {
                    t_newTemperature = doThomas(t_newTemperature, t_soilTemp, t_thermalConductivity, t_thermalConductance, t_DEPTHApsim, t_volSpecHeatSoil, internalTimeStep, netRadiation, t_ESP, t_ES, numNodes, t_netRadiationSource);
                    thermalConductivity.set(AIRnode,boundaryLayerConductanceF(t_newTemperature, tMean, t_ESP, t_EOAD, t_airPressure, t_canopyHeight, t_windSpeed, t_instrumentHeight));
                }
            }
            t_newTemperature = doThomas(t_newTemperature, t_soilTemp, t_thermalConductivity, t_thermalConductance, t_DEPTHApsim, t_volSpecHeatSoil, internalTimeStep, netRadiation, t_ESP, t_ES, numNodes, t_netRadiationSource);
            zz_doUpdate = Calculate_doUpdate(t_newTemperature, t_soilTemp, t_minSoilTemp, t_maxSoilTemp, t_aveSoilTemp, t_thermalConductivity, t__boundaryLayerConductance, ITERATIONSperDAY, timeOfDaySecs, internalTimeStep, numNodes);
            t_soilTemp = zz_doUpdate.getsoilTemp();
            t__boundaryLayerConductance = zz_doUpdate.getboundaryLayerConductance();
            precision = Math.min(timeOfDaySecs, 5.0d * 3600.0d) * 0.0001d;
            if (Math.abs(timeOfDaySecs - (5.0d * 3600.0d)) <= precision)
            {
                for (layer=0 ; layer!=t_soilTemp.size() ; layer+=1)
                {
                    morningSoilTemp.set(layer,t_soilTemp.get(layer));
                }
            }
        }
        t_minTempYesterday = t_TMIN;
        t_maxTempYesterday = t_TMAX;
        THICKApsim.setValue(t_THICKApsim, this);
        DEPTHApsim.setValue(t_DEPTHApsim, this);
        BDApsim.setValue(t_BDApsim, this);
        CLAYApsim.setValue(t_CLAYApsim, this);
        SWApsim.setValue(t_SWApsim, this);
        soilTemp.setValue(t_soilTemp, this);
        newTemperature.setValue(t_newTemperature, this);
        minSoilTemp.setValue(t_minSoilTemp, this);
        maxSoilTemp.setValue(t_maxSoilTemp, this);
        aveSoilTemp.setValue(t_aveSoilTemp, this);
        morningSoilTemp.setValue(t_morningSoilTemp, this);
        thermalCondPar1.setValue(t_thermalCondPar1, this);
        thermalCondPar2.setValue(t_thermalCondPar2, this);
        thermalCondPar3.setValue(t_thermalCondPar3, this);
        thermalCondPar4.setValue(t_thermalCondPar4, this);
        thermalConductivity.setValue(t_thermalConductivity, this);
        thermalConductance.setValue(t_thermalConductance, this);
        heatStorage.setValue(t_heatStorage, this);
        volSpecHeatSoil.setValue(t_volSpecHeatSoil, this);
        maxTempYesterday.setValue(t_maxTempYesterday, this);
        minTempYesterday.setValue(t_minTempYesterday, this);
        SLCARBApsim.setValue(t_SLCARBApsim, this);
        SLROCKApsim.setValue(t_SLROCKApsim, this);
        SLSILTApsim.setValue(t_SLSILTApsim, this);
        SLSANDApsim.setValue(t_SLSANDApsim, this);
        _boundaryLayerConductance.setValue(t__boundaryLayerConductance, this);
    }
    public doNetRadiation Calculate_doNetRadiation (List<Double> solarRadn, double cloudFr, double cva, Integer ITERATIONSperDAY, Integer doy, double rad, double tmin, double latitude)
    {
        List<> Doublem1 = new ArrayList<>(Arrays.asList());
        Integer lay;
        solarRadn = new ArrayList<>(Arrays.asList(0.0d)) * (ITERATIONSperDAY + 1);
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
    public static List<Double> doVolumetricSpecificHeat(List<Double> volSpecLayer, List<Double> soilW, Integer numNodes, String [] constituents, List<Double> t_THICKApsim, List<Double> t_DEPTHApsim)
    {
        List<t_> DoublevolSpecHeatSoil = new ArrayList<>(Arrays.asList());
        t_volSpecHeatSoil = new ArrayList<>(Arrays.asList(0.0d));
        Integer node;
        for (node=0 ; node!=numNodes + 1 ; node+=1)
        {
            t_volSpecHeatSoil.add(0.0d);
        }
        Integer constituent;
        for (node=1 ; node!=numNodes + 1 ; node+=1)
        {
            volSpecHeatSoil.set(node,0.0d);
            for (constituent=0 ; constituent!=constituents.length ; constituent+=1)
            {
                volSpecHeatSoil.set(node,t_volSpecHeatSoil.get(node) + (volumetricSpecificHeat(constituents[constituent]) * 1000000.0d * soilW.get(node)));
            }
        }
        volSpecLayer = mapLayer2Node(t_volSpecHeatSoil, volSpecLayer, t_THICKApsim, t_DEPTHApsim, numNodes);
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
    public static List<Double> mapLayer2Node(List<Double> layerArray, List<Double> nodeArray, List<Double> t_THICKApsim, List<Double> t_DEPTHApsim, Integer numNodes)
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
                    depthLayerAbove = depthLayerAbove + t_THICKApsim.get(I);
                }
            }
            d1 = depthLayerAbove - (t_DEPTHApsim.get(node) * 1000.0d);
            d2 = t_DEPTHApsim.get((node + 1)) * 1000.0d - depthLayerAbove;
            dSum = d1 + d2;
            nodeArray.set(node,Divide(layerArray.get(layer) * d1, dSum, 0.0d) + Divide(layerArray.get((layer + 1)) * d2, dSum, 0.0d));
        }
        return nodeArray;
    }
    public static List<Double> doThermConductivity(List<Double> soilW, List<Double> t_SLCARBApsim, List<Double> t_SLROCKApsim, List<Double> t_SLSANDApsim, List<Double> t_SLSILTApsim, List<Double> t_CLAYApsim, List<Double> t_BDApsim, List<Double> t_thermalConductivity, List<Double> t_THICKApsim, List<Double> t_DEPTHApsim, Integer numNodes, String [] constituents)
    {
        List<> DoublethermCondLayers = new ArrayList<>(Arrays.asList());
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
                shapeFactorConstituent = shapeFactor(constituents[constituent], t_SLROCKApsim, t_SLCARBApsim, t_SLSANDApsim, t_SLSILTApsim, t_CLAYApsim, soilW, t_BDApsim, node);
                thermalConductanceConstituent = ThermalConductance(constituents[constituent]);
                thermalConductanceWater = ThermalConductance("Water");
                k = 2.0d / 3.0d * Math.pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0d))), -1) + (1.0d / 3.0d * Math.pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0d) * (1.0d - (2.0d * shapeFactorConstituent)))), -1));
                numerator = numerator + (thermalConductanceConstituent * soilW.get(node) * k);
                denominator = denominator + (soilW.get(node) * k);
            }
            thermCondLayers.set(node,numerator / denominator);
        }
        t_thermalConductivity = mapLayer2Node(thermCondLayers, t_thermalConductivity, t_THICKApsim, t_DEPTHApsim, numNodes);
        return t_thermalConductivity;
    }
    public static double shapeFactor(String name, List<Double> t_SLROCKApsim, List<Double> t_SLCARBApsim, List<Double> t_SLSANDApsim, List<Double> t_SLSILTApsim, List<Double> t_CLAYApsim, List<Double> t_SWApsim, List<Double> t_BDApsim, Integer layer)
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
            result = 0.333d - (0.333d * 0.0d / (volumetricFractionWater(t_SWApsim, t_SLCARBApsim, t_BDApsim, layer) + 0.0d + volumetricFractionAir(t_SLROCKApsim, t_SLCARBApsim, t_SLSANDApsim, t_SLSILTApsim, t_CLAYApsim, t_SWApsim, t_BDApsim, layer)));
            return result;
        }
        else if ( name == "Air")
        {
            result = 0.333d - (0.333d * volumetricFractionAir(t_SLROCKApsim, t_SLCARBApsim, t_SLSANDApsim, t_SLSILTApsim, t_CLAYApsim, t_SWApsim, t_BDApsim, layer) / (volumetricFractionWater(t_SWApsim, t_SLCARBApsim, t_BDApsim, layer) + 0.0d + volumetricFractionAir(t_SLROCKApsim, t_SLCARBApsim, t_SLSANDApsim, t_SLSILTApsim, t_CLAYApsim, t_SWApsim, t_BDApsim, layer)));
            return result;
        }
        else if ( name == "Minerals")
        {
            result = shapeFactorRocks * volumetricFractionRocks(t_SLROCKApsim, layer) + (shapeFactorSand * volumetricFractionSand(t_SLSANDApsim, t_SLROCKApsim, t_SLCARBApsim, t_BDApsim, layer)) + (shapeFactorSilt * volumetricFractionSilt(t_SLSILTApsim, t_SLROCKApsim, t_SLCARBApsim, t_BDApsim, layer)) + (shapeFactorClay * volumetricFractionClay(t_CLAYApsim, t_SLROCKApsim, t_SLCARBApsim, t_BDApsim, layer));
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
    public static double volumetricFractionWater(List<Double> t_SWApsim, List<Double> t_SLCARBApsim, List<Double> t_BDApsim, Integer layer)
    {
        double res = (1.0d - volumetricFractionOrganicMatter(t_SLCARBApsim, t_BDApsim, layer)) * t_SWApsim.get(layer);
        return res;
    }
    public static double volumetricFractionAir(List<Double> t_SLROCKApsim, List<Double> t_SLCARBApsim, List<Double> t_SLSANDApsim, List<Double> t_SLSILTApsim, List<Double> t_CLAYApsim, List<Double> t_SWApsim, List<Double> t_BDApsim, Integer layer)
    {
        double res = 1.0d - volumetricFractionRocks(t_SLROCKApsim, layer) - volumetricFractionOrganicMatter(t_SLCARBApsim, t_BDApsim, layer) - volumetricFractionSand(t_SLSANDApsim, t_SLROCKApsim, t_SLCARBApsim, t_BDApsim, layer) - volumetricFractionSilt(t_SLSILTApsim, t_SLROCKApsim, t_SLCARBApsim, t_BDApsim, layer) - volumetricFractionClay(t_CLAYApsim, t_SLROCKApsim, t_SLCARBApsim, t_BDApsim, layer) - volumetricFractionWater(t_SWApsim, t_SLCARBApsim, t_BDApsim, layer) - 0.0d;
        return res;
    }
    public static double volumetricFractionRocks(List<Double> t_SLROCKApsim, Integer layer)
    {
        double res = t_SLROCKApsim.get(layer) / 100.0d;
        return res;
    }
    public static double volumetricFractionSand(List<Double> t_SLSANDApsim, List<Double> t_SLROCKApsim, List<Double> t_SLCARBApsim, List<Double> t_BDApsim, Integer layer)
    {
        double ps = 2.63;
        double res = (1.0d - volumetricFractionOrganicMatter(t_SLCARBApsim, t_BDApsim, layer) - volumetricFractionRocks(t_SLROCKApsim, layer)) * t_SLSANDApsim.get(layer) / 100.0d * t_BDApsim.get(layer) / ps;
        return res;
    }
    public static double volumetricFractionSilt(List<Double> t_SLSILTApsim, List<Double> t_SLROCKApsim, List<Double> t_SLCARBApsim, List<Double> t_BDApsim, Integer layer)
    {
        double ps = 2.63;
        double res = (1.0d - volumetricFractionOrganicMatter(t_SLCARBApsim, t_BDApsim, layer) - volumetricFractionRocks(t_SLROCKApsim, layer)) * t_SLSILTApsim.get(layer) / 100.0d * t_BDApsim.get(layer) / ps;
        return res;
    }
    public static double volumetricFractionClay(List<Double> t_CLAYApsim, List<Double> t_SLROCKApsim, List<Double> t_SLCARBApsim, List<Double> t_BDApsim, Integer layer)
    {
        double ps = 2.63;
        double res = (1.0d - volumetricFractionOrganicMatter(t_SLCARBApsim, t_BDApsim, layer) - volumetricFractionRocks(t_SLROCKApsim, layer)) * t_CLAYApsim.get(layer) / 100.0d * t_BDApsim.get(layer) / ps;
        return res;
    }
    public static double volumetricFractionOrganicMatter(List<Double> t_SLCARBApsim, List<Double> t_BDApsim, Integer layer)
    {
        double pom = 1.3;
        double res = t_SLCARBApsim.get(layer) / 100.0d * 2.5d * t_BDApsim.get(layer) / pom;
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
    public static double RadnNetInterpolate(double internalTimeStep, double solarRadiation, double cloudFr, double cva, double potE, double potET, double tMean, double albedo, List<Double> t_soilTemp)
    {
        double EMISSIVITYsurface = 0.96;
        double w2MJ = internalTimeStep / 1000000.0d;
        Integer SURFACEnode = 1;
        double emissivityAtmos = (1 - (0.84d * cloudFr)) * 0.58d * Math.pow(cva, 1.0d / 7.0d) + (0.84d * cloudFr);
        double PenetrationConstant = Divide(Math.max(0.1d, potE), Math.max(0.1d, potET), 0.0d);
        double lwRinSoil = longWaveRadn(emissivityAtmos, tMean) * PenetrationConstant * w2MJ;
        double lwRoutSoil = longWaveRadn(EMISSIVITYsurface, t_soilTemp.get(SURFACEnode)) * PenetrationConstant * w2MJ;
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
    public static double boundaryLayerConductanceF(List<Double> TNew_zb, double tMean, double potE, double potET, double t_airPressure, double t_canopyHeight, double t_windSpeed, double t_instrumentHeight)
    {
        double VONK = 0.41;
        double GRAVITATIONALconst = 9.8;
        double specificHeatOfAir = 1010.0;
        double EMISSIVITYsurface = 0.98;
        Integer SURFACEnode = 1;
        double STEFAN_BOLTZMANNconst = 0.0000000567;
        double SpecificHeatAir = specificHeatOfAir * airDensity(tMean, t_airPressure);
        double RoughnessFacMomentum = 0.13d * t_canopyHeight;
        double RoughnessFacHeat = 0.2d * RoughnessFacMomentum;
        double d = 0.77d * t_canopyHeight;
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
            FrictionVelocity = Divide(t_windSpeed * VONK, Math.log(Divide(t_instrumentHeight - d + RoughnessFacMomentum, RoughnessFacMomentum, 0.0d)) + StabilityCorMomentum, 0.0d);
            BoundaryLayerCond = Divide(SpecificHeatAir * VONK * FrictionVelocity, Math.log(Divide(t_instrumentHeight - d + RoughnessFacHeat, RoughnessFacHeat, 0.0d)) + StabilityCorHeat, 0.0d);
            BoundaryLayerCond = BoundaryLayerCond + radiativeConductance;
            HeatFluxDensity = BoundaryLayerCond * (SurfaceTemperature - tMean);
            StabilityParam = Divide(-VONK * t_instrumentHeight * GRAVITATIONALconst * HeatFluxDensity, SpecificHeatAir * kelvinTemp * Math.pow(FrictionVelocity, 3), 0.0d);
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
    public static List<Double> doThomas(List<Double> newTemps, List<Double> t_soilTemp, List<Double> t_thermalConductivity, List<Double> t_thermalConductance, List<Double> t_DEPTHApsim, List<Double> t_volSpecHeatSoil, double gDt, double netRadiation, double potE, double actE, Integer numNodes, String t_netRadiationSource)
    {
        double nu = 0.6;
        Integer AIRnode = 0;
        Integer SURFACEnode = 1;
        double MJ2J = 1000000.0;
        double latentHeatOfVapourisation = 2465000.0;
        double tempStepSec = 24.0d * 60.0d * 60.0d;
        Integer I;
        List<t_> DoubleheatStorage = new ArrayList<>(Arrays.asList());
        t_heatStorage = new ArrayList<>(Arrays.asList(0.d));
        double VolSoilAtNode;
        double elementLength;
        double g = 1 - nu;
        double sensibleHeatFlux;
        double RadnNet;
        double LatentHeatFlux;
        double SoilSurfaceHeatFlux;
        List<> Doublea = new ArrayList<>(Arrays.asList());
        List<> Doubleb = new ArrayList<>(Arrays.asList());
        List<> Doublec = new ArrayList<>(Arrays.asList());
        List<> Doubled = new ArrayList<>(Arrays.asList());
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
            t_heatStorage.add(0.0d);
        }
        a.add(0.0d);
        t_thermalConductance = new ArrayList<>(Arrays.asList(0.d)) * (numNodes + 1);
        thermalConductance.set(AIRnode,t_thermalConductivity.get(AIRnode));
        Integer node = SURFACEnode;
        for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
        {
            VolSoilAtNode = 0.5d * (t_DEPTHApsim.get(node + 1) - t_DEPTHApsim.get(node - 1));
            heatStorage.set(node,Divide(t_volSpecHeatSoil.get(node) * VolSoilAtNode, gDt, 0.0d));
            elementLength = t_DEPTHApsim.get(node + 1) - t_DEPTHApsim.get(node);
            thermalConductance.set(node,Divide(t_thermalConductivity.get(node), elementLength, 0.0d));
        }
        for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
        {
            c.set(node,-nu * t_thermalConductance.get(node));
            a.set(node + 1,c.get(node));
            b.set(node,nu * (t_thermalConductance.get(node) + t_thermalConductance.get(node - 1)) + t_heatStorage.get(node));
            d.set(node,g * t_thermalConductance.get((node - 1)) * t_soilTemp.get((node - 1)) + ((t_heatStorage.get(node) - (g * (t_thermalConductance.get(node) + t_thermalConductance.get(node - 1)))) * t_soilTemp.get(node)) + (g * t_thermalConductance.get(node) * t_soilTemp.get((node + 1))));
        }
        a.set(SURFACEnode,0.0d);
        sensibleHeatFlux = nu * t_thermalConductance.get(AIRnode) * newTemps.get(AIRnode);
        RadnNet = 0.0d;
        if (t_netRadiationSource == "calc")
        {
            RadnNet = Divide(netRadiation * 1000000.0d, gDt, 0.0d);
        }
        else if ( t_netRadiationSource == "eos")
        {
            RadnNet = Divide(potE * latentHeatOfVapourisation, tempStepSec, 0.0d);
        }
        LatentHeatFlux = Divide(actE * latentHeatOfVapourisation, tempStepSec, 0.0d);
        SoilSurfaceHeatFlux = sensibleHeatFlux + RadnNet - LatentHeatFlux;
        d.set(SURFACEnode,d.get(SURFACEnode) + SoilSurfaceHeatFlux);
        d.set(numNodes,d.get(numNodes) + (nu * t_thermalConductance.get(numNodes) * newTemps.get((numNodes + 1))));
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
    public doUpdate Calculate_doUpdate (List<Double> tempNew, List<Double> t_soilTemp, List<Double> t_minSoilTemp, List<Double> t_maxSoilTemp, List<Double> t_aveSoilTemp, List<Double> t_thermalConductivity, double boundaryLayerConductance, Integer IterationsPerDay, double timeOfDaySecs, double gDt, Integer numNodes)
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
                minSoilTemp.set(node,t_soilTemp.get(node));
                maxSoilTemp.set(node,t_soilTemp.get(node));
            }
        }
        for (node=SURFACEnode ; node!=numNodes + 1 ; node+=1)
        {
            if (t_soilTemp.get(node) < t_minSoilTemp.get(node))
            {
                minSoilTemp.set(node,t_soilTemp.get(node));
            }
            else if ( t_soilTemp.get(node) > t_maxSoilTemp.get(node))
            {
                maxSoilTemp.set(node,t_soilTemp.get(node));
            }
            aveSoilTemp.set(node,t_aveSoilTemp.get(node) + Divide(t_soilTemp.get(node), (double)(IterationsPerDay), 0.0d));
        }
        boundaryLayerConductance = boundaryLayerConductance + Divide(t_thermalConductivity.get(AIRnode), (double)(IterationsPerDay), 0.0d);
        return new doUpdate(t_soilTemp, boundaryLayerConductance);
    }
    public doThermalConductivityCoeffs Calculate_doThermalConductivityCoeffs (Integer nbLayers, Integer numNodes, List<Double> t_BDApsim, List<Double> t_CLAYApsim)
    {
        List<t_> DoublethermalCondPar1 = new ArrayList<>(Arrays.asList());
        List<t_> DoublethermalCondPar2 = new ArrayList<>(Arrays.asList());
        List<t_> DoublethermalCondPar3 = new ArrayList<>(Arrays.asList());
        List<t_> DoublethermalCondPar4 = new ArrayList<>(Arrays.asList());
        Integer layer;
        Integer element;
        t_thermalCondPar1 = new ArrayList<>(Arrays.asList(0.0d));
        t_thermalCondPar2 = new ArrayList<>(Arrays.asList(0.0d));
        t_thermalCondPar3 = new ArrayList<>(Arrays.asList(0.0d));
        t_thermalCondPar4 = new ArrayList<>(Arrays.asList(0.0d));
        for (layer=0 ; layer!=numNodes + 1 ; layer+=1)
        {
            t_thermalCondPar1.add(0.0d);
            t_thermalCondPar2.add(0.0d);
            t_thermalCondPar3.add(0.0d);
            t_thermalCondPar4.add(0.0d);
        }
        for (layer=1 ; layer!=nbLayers + 2 ; layer+=1)
        {
            element = layer;
            thermalCondPar1.set(element,0.65d - (0.78d * t_BDApsim.get(layer)) + (0.6d * Math.pow(t_BDApsim.get(layer), 2)));
            thermalCondPar2.set(element,1.06d * t_BDApsim.get(layer));
            thermalCondPar3.set(element,Divide(2.6d, Math.sqrt(t_CLAYApsim.get(layer)), 0.0d));
            thermalCondPar3.set(element,1.0d + t_thermalCondPar3.get(element));
            thermalCondPar4.set(element,0.03d + (0.1d * Math.pow(t_BDApsim.get(layer), 2)));
        }
        return new doThermalConductivityCoeffs(t_thermalCondPar1, t_thermalCondPar2, t_thermalCondPar3, t_thermalCondPar4);
    }
    public static List<Double> CalcSoilTemp(List<Double> t_THICKApsim, double tav, double tamp, Integer doy, double latitude, Integer numNodes)
    {
        List<> DoublecumulativeDepth = new ArrayList<>(Arrays.asList());
        List<> DoublesoilTempIO = new ArrayList<>(Arrays.asList());
        List<> DoublesoilTemperat = new ArrayList<>(Arrays.asList());
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
        for (Layer=0 ; Layer!=t_THICKApsim.size() ; Layer+=1)
        {
            cumulativeDepth.add(0.0d);
        }
        if (t_THICKApsim.size() > 0)
        {
            cumulativeDepth.set(0,t_THICKApsim.get(0));
            for (Layer=1 ; Layer!=t_THICKApsim.size() ; Layer+=1)
            {
                cumulativeDepth.set(Layer,t_THICKApsim.get(Layer) + cumulativeDepth.get(Layer - 1));
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

    public HashMap<String, FWSimVariable<?>> fillTestVariables(int aParamIndex, TEST_STATE aDefineOrCheck)
    {
        return iFieldMap;
    }

    @Override
    protected FWSimComponent clone(FWSimVarMap aVarMap)
    {
        return new Campbell(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
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