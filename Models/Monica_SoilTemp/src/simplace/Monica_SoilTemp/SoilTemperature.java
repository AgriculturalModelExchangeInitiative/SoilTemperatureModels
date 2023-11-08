package net.simplace.sim.components.Monica_SoilTemp;
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
    private FWSimVariable<Double> soilSurfaceTemperature;
    private FWSimVariable<Double> timeStep;
    private FWSimVariable<Double> soilMoistureConst;
    private FWSimVariable<Double> baseTemp;
    private FWSimVariable<Double> initialSurfaceTemp;
    private FWSimVariable<Double> densityAir;
    private FWSimVariable<Double> specificHeatCapacityAir;
    private FWSimVariable<Double> densityHumus;
    private FWSimVariable<Double> specificHeatCapacityHumus;
    private FWSimVariable<Double> densityWater;
    private FWSimVariable<Double> specificHeatCapacityWater;
    private FWSimVariable<Double> quartzRawDensity;
    private FWSimVariable<Double> specificHeatCapacityQuartz;
    private FWSimVariable<Double> nTau;
    private FWSimVariable<Integer> noOfTempLayers;
    private FWSimVariable<Integer> noOfSoilLayers;
    private FWSimVariable<Double[]> layerThickness;
    private FWSimVariable<Double[]> soilBulkDensity;
    private FWSimVariable<Double[]> saturation;
    private FWSimVariable<Double[]> soilOrganicMatter;
    private FWSimVariable<Double[]> soilTemperature;
    private FWSimVariable<Double[]> V;
    private FWSimVariable<Double[]> B;
    private FWSimVariable<Double[]> volumeMatrix;
    private FWSimVariable<Double[]> volumeMatrixOld;
    private FWSimVariable<Double[]> matrixPrimaryDiagonal;
    private FWSimVariable<Double[]> matrixSecondaryDiagonal;
    private FWSimVariable<Double[]> heatConductivity;
    private FWSimVariable<Double[]> heatConductivityMean;
    private FWSimVariable<Double[]> heatCapacity;
    private FWSimVariable<Double[]> solution;
    private FWSimVariable<Double[]> matrixDiagonal;
    private FWSimVariable<Double[]> matrixLowerTriangle;
    private FWSimVariable<Double[]> heatFlow;

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
        addVariable(FWSimVariable.createSimVariable("soilSurfaceTemperature", "current soilSurfaceTemperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"°C", -50, 80, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("timeStep", "timeStep", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"dimensionless", null, null, 1.0, this));
        addVariable(FWSimVariable.createSimVariable("soilMoistureConst", "initial soilmoisture", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"m**3/m**3", null, null, 0.25, this));
        addVariable(FWSimVariable.createSimVariable("baseTemp", "baseTemperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"°C", null, null, 9.5, this));
        addVariable(FWSimVariable.createSimVariable("initialSurfaceTemp", "initialSurfaceTemperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"°C", null, null, 10.0, this));
        addVariable(FWSimVariable.createSimVariable("densityAir", "DensityAir", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"kg/m**3", null, null, 1.25, this));
        addVariable(FWSimVariable.createSimVariable("specificHeatCapacityAir", "SpecificHeatCapacityAir", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"J/kg/K", null, null, 1005, this));
        addVariable(FWSimVariable.createSimVariable("densityHumus", "DensityHumus", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"kg/m**3", null, null, 1300, this));
        addVariable(FWSimVariable.createSimVariable("specificHeatCapacityHumus", "SpecificHeatCapacityHumus", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"J/kg/K", null, null, 1920, this));
        addVariable(FWSimVariable.createSimVariable("densityWater", "DensityWater", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"kg/m**3", null, null, 1000, this));
        addVariable(FWSimVariable.createSimVariable("specificHeatCapacityWater", "SpecificHeatCapacityWater", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"J/kg/K", null, null, 4192, this));
        addVariable(FWSimVariable.createSimVariable("quartzRawDensity", "QuartzRawDensity", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"kg/m**3", null, null, 2650, this));
        addVariable(FWSimVariable.createSimVariable("specificHeatCapacityQuartz", "SpecificHeatCapacityQuartz", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"J/kg/K", null, null, 750, this));
        addVariable(FWSimVariable.createSimVariable("nTau", "NTau", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"?", null, null, 0.65, this));
        addVariable(FWSimVariable.createSimVariable("noOfTempLayers", "noOfTempLayers=noOfSoilLayers+2", DATA_TYPE.INT, CONTENT_TYPE.constant,"dimensionless", null, null, 22, this));
        addVariable(FWSimVariable.createSimVariable("noOfSoilLayers", "noOfSoilLayers", DATA_TYPE.INT, CONTENT_TYPE.constant,"dimensionless", null, null, 20, this));
        addVariable(FWSimVariable.createSimVariable("layerThickness", "layerThickness", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"m", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("soilBulkDensity", "bulkDensity", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"kg/m**3", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("saturation", "saturation", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"m**3/m**3", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("soilOrganicMatter", "soilOrganicMatter", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"m**3/m**3", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("soilTemperature", "soilTemperature", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"°C", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("V", "V", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"°C", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("B", "B", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"°C", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("volumeMatrix", "volumeMatrix", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"°C", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("volumeMatrixOld", "volumeMatrixOld", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"°C", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("matrixPrimaryDiagonal", "matrixPrimaryDiagonal", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"°C", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("matrixSecondaryDiagonal", "matrixSecondaryDiagonal", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"°C", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("heatConductivity", "heatConductivity", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"°C", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("heatConductivityMean", "heatConductivityMean", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"°C", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("heatCapacity", "heatCapacity", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"°C", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("solution", "solution", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"°C", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("matrixDiagonal", "matrixDiagonal", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"°C", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("matrixLowerTriangle", "matrixLowerTriangle", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"°C", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("heatFlow", "heatFlow", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"°C", null, null, null, this));

        return iFieldMap;
    }
    @Override
    protected void init()
    {
        Double t_timeStep = timeStep.getValue();
        Double t_soilMoistureConst = soilMoistureConst.getValue();
        Double t_baseTemp = baseTemp.getValue();
        Double t_initialSurfaceTemp = initialSurfaceTemp.getValue();
        Double t_densityAir = densityAir.getValue();
        Double t_specificHeatCapacityAir = specificHeatCapacityAir.getValue();
        Double t_densityHumus = densityHumus.getValue();
        Double t_specificHeatCapacityHumus = specificHeatCapacityHumus.getValue();
        Double t_densityWater = densityWater.getValue();
        Double t_specificHeatCapacityWater = specificHeatCapacityWater.getValue();
        Double t_quartzRawDensity = quartzRawDensity.getValue();
        Double t_specificHeatCapacityQuartz = specificHeatCapacityQuartz.getValue();
        Double t_nTau = nTau.getValue();
        Integer t_noOfTempLayers = noOfTempLayers.getValue();
        Integer t_noOfSoilLayers = noOfSoilLayers.getValue();
        Double [] t_layerThickness = layerThickness.getValue();
        Double [] t_soilBulkDensity = soilBulkDensity.getValue();
        Double [] t_saturation = saturation.getValue();
        Double [] t_soilOrganicMatter = soilOrganicMatter.getValue();
        Double t_soilSurfaceTemperature = soilSurfaceTemperature.getDefault();
        Double [] t_soilTemperature = new Double[22];
        Double [] t_V = new Double[22];
        Double [] t_B = new Double[22];
        Double [] t_volumeMatrix = new Double[22];
        Double [] t_volumeMatrixOld = new Double[22];
        Double [] t_matrixPrimaryDiagonal = new Double[22];
        Double [] t_matrixSecondaryDiagonal = new Double[23];
        Double [] t_heatConductivity = new Double[22];
        Double [] t_heatConductivityMean = new Double[22];
        Double [] t_heatCapacity = new Double[22];
        Double [] t_solution = new Double[22];
        Double [] t_matrixDiagonal = new Double[22];
        Double [] t_matrixLowerTriangle = new Double[22];
        Double [] t_heatFlow = new Double[22];
        Arrays.fill(t_soilTemperature, 0.0d);
        Arrays.fill(t_V, 0.0d);
        Arrays.fill(t_B, 0.0d);
        Arrays.fill(t_volumeMatrix, 0.0d);
        Arrays.fill(t_volumeMatrixOld, 0.0d);
        Arrays.fill(t_matrixPrimaryDiagonal, 0.0d);
        Arrays.fill(t_matrixSecondaryDiagonal, 0.0d);
        Arrays.fill(t_heatConductivity, 0.0d);
        Arrays.fill(t_heatConductivityMean, 0.0d);
        Arrays.fill(t_heatCapacity, 0.0d);
        Arrays.fill(t_solution, 0.0d);
        Arrays.fill(t_matrixDiagonal, 0.0d);
        Arrays.fill(t_matrixLowerTriangle, 0.0d);
        Arrays.fill(t_heatFlow, 0.0d);
        t_soilTemperature = new Double [t_noOfTempLayers];
        t_V = new Double [t_noOfTempLayers];
        t_volumeMatrix = new Double [t_noOfTempLayers];
        t_volumeMatrixOld = new Double [t_noOfTempLayers];
        t_B = new Double [t_noOfTempLayers];
        t_matrixPrimaryDiagonal = new Double [t_noOfTempLayers];
        t_matrixSecondaryDiagonal = new Double [t_noOfTempLayers + 1];
        t_heatConductivity = new Double [t_noOfTempLayers];
        t_heatConductivityMean = new Double [t_noOfTempLayers];
        t_heatCapacity = new Double [t_noOfTempLayers];
        t_solution = new Double [t_noOfTempLayers];
        t_matrixDiagonal = new Double [t_noOfTempLayers];
        t_matrixLowerTriangle = new Double [t_noOfTempLayers];
        t_heatFlow = new Double [t_noOfTempLayers];
        Integer i;
        for (i=0 ; i!=t_noOfSoilLayers ; i+=1)
        {
            t_soilTemperature[i] = (1.0d - ((double)(i) / t_noOfSoilLayers)) * t_initialSurfaceTemp + ((double)(i) / t_noOfSoilLayers * t_baseTemp);
        }
        Integer groundLayer;
        groundLayer = t_noOfTempLayers - 2;
        Integer bottomLayer;
        bottomLayer = t_noOfTempLayers - 1;
        t_layerThickness[groundLayer] = 2.0d * t_layerThickness[(groundLayer - 1)];
        t_layerThickness[bottomLayer] = 1.0d;
        t_soilTemperature[groundLayer] = (t_soilTemperature[groundLayer - 1] + t_baseTemp) * 0.5d;
        t_soilTemperature[bottomLayer] = t_baseTemp;
        t_V[0] = t_layerThickness[0];
        t_B[0] = 2.0d / t_layerThickness[0];
        Double lti_1;
        Double lti;
        for (i=1 ; i!=t_noOfTempLayers ; i+=1)
        {
            lti_1 = t_layerThickness[i - 1];
            lti = t_layerThickness[i];
            t_B[i] = 2.0d / (lti + lti_1);
            t_V[i] = lti * t_nTau;
        }
        Double ts;
        ts = t_timeStep;
        Double dw;
        dw = t_densityWater;
        Double cw;
        cw = t_specificHeatCapacityWater;
        Double dq;
        dq = t_quartzRawDensity;
        Double cq;
        cq = t_specificHeatCapacityQuartz;
        Double da;
        da = t_densityAir;
        Double ca;
        ca = t_specificHeatCapacityAir;
        Double dh;
        dh = t_densityHumus;
        Double ch;
        ch = t_specificHeatCapacityHumus;
        Double sbdi;
        Double smi;
        Double sati;
        Double somi;
        for (i=0 ; i!=t_noOfSoilLayers ; i+=1)
        {
            sbdi = t_soilBulkDensity[i];
            smi = t_soilMoistureConst;
            t_heatConductivity[i] = (3.0d * (sbdi / 1000.0d) - 1.7d) * 0.001d / (1.0d + ((11.5d - (5.0d * (sbdi / 1000.0d))) * Math.exp(-50.0d * Math.pow(smi / (sbdi / 1000.0d), 1.5d)))) * 86400.0d * ts * 100.0d * 4.184d;
            sati = t_saturation[i];
            somi = t_soilOrganicMatter[i] / da * sbdi;
            t_heatCapacity[i] = smi * dw * cw + ((sati - smi) * da * ca) + (somi * dh * ch) + ((1.0d - sati - somi) * dq * cq);
        }
        t_heatCapacity[groundLayer] = t_heatCapacity[groundLayer - 1];
        t_heatCapacity[bottomLayer] = t_heatCapacity[groundLayer];
        t_heatConductivity[groundLayer] = t_heatConductivity[groundLayer - 1];
        t_heatConductivity[bottomLayer] = t_heatConductivity[groundLayer];
        t_soilSurfaceTemperature = t_initialSurfaceTemp;
        t_heatConductivityMean[0] = t_heatConductivity[0];
        Double hci_1;
        Double hci;
        for (i=1 ; i!=t_noOfTempLayers ; i+=1)
        {
            lti_1 = t_layerThickness[i - 1];
            lti = t_layerThickness[i];
            hci_1 = t_heatConductivity[i - 1];
            hci = t_heatConductivity[i];
            t_heatConductivityMean[i] = (lti_1 * hci_1 + (lti * hci)) / (lti + lti_1);
        }
        for (i=0 ; i!=t_noOfTempLayers ; i+=1)
        {
            t_volumeMatrix[i] = t_V[i] * t_heatCapacity[i];
            t_volumeMatrixOld[i] = t_volumeMatrix[i];
            t_matrixSecondaryDiagonal[i] = -t_B[i] * t_heatConductivityMean[i];
        }
        t_matrixSecondaryDiagonal[bottomLayer + 1] = 0.0d;
        for (i=0 ; i!=t_noOfTempLayers ; i+=1)
        {
            t_matrixPrimaryDiagonal[i] = t_volumeMatrix[i] - t_matrixSecondaryDiagonal[i] - t_matrixSecondaryDiagonal[i + 1];
        }
        soilSurfaceTemperature.setValue(t_soilSurfaceTemperature, this);
        soilTemperature.setValue(t_soilTemperature, this);
        V.setValue(t_V, this);
        B.setValue(t_B, this);
        volumeMatrix.setValue(t_volumeMatrix, this);
        volumeMatrixOld.setValue(t_volumeMatrixOld, this);
        matrixPrimaryDiagonal.setValue(t_matrixPrimaryDiagonal, this);
        matrixSecondaryDiagonal.setValue(t_matrixSecondaryDiagonal, this);
        heatConductivity.setValue(t_heatConductivity, this);
        heatConductivityMean.setValue(t_heatConductivityMean, this);
        heatCapacity.setValue(t_heatCapacity, this);
        solution.setValue(t_solution, this);
        matrixDiagonal.setValue(t_matrixDiagonal, this);
        matrixLowerTriangle.setValue(t_matrixLowerTriangle, this);
        heatFlow.setValue(t_heatFlow, this);
    }
    @Override
    protected void process()
    {
        Double t_soilSurfaceTemperature = soilSurfaceTemperature.getValue();
        Double t_timeStep = timeStep.getValue();
        Double t_soilMoistureConst = soilMoistureConst.getValue();
        Double t_baseTemp = baseTemp.getValue();
        Double t_initialSurfaceTemp = initialSurfaceTemp.getValue();
        Double t_densityAir = densityAir.getValue();
        Double t_specificHeatCapacityAir = specificHeatCapacityAir.getValue();
        Double t_densityHumus = densityHumus.getValue();
        Double t_specificHeatCapacityHumus = specificHeatCapacityHumus.getValue();
        Double t_densityWater = densityWater.getValue();
        Double t_specificHeatCapacityWater = specificHeatCapacityWater.getValue();
        Double t_quartzRawDensity = quartzRawDensity.getValue();
        Double t_specificHeatCapacityQuartz = specificHeatCapacityQuartz.getValue();
        Double t_nTau = nTau.getValue();
        Integer t_noOfTempLayers = noOfTempLayers.getValue();
        Integer t_noOfSoilLayers = noOfSoilLayers.getValue();
        Double [] t_layerThickness = layerThickness.getValue();
        Double [] t_soilBulkDensity = soilBulkDensity.getValue();
        Double [] t_saturation = saturation.getValue();
        Double [] t_soilOrganicMatter = soilOrganicMatter.getValue();
        Double [] t_soilTemperature = new Double[22];
        Double [] t_V = new Double[22];
        Double [] t_B = new Double[22];
        Double [] t_volumeMatrix = new Double[22];
        Double [] t_volumeMatrixOld = new Double[22];
        Double [] t_matrixPrimaryDiagonal = new Double[22];
        Double [] t_matrixSecondaryDiagonal = new Double[23];
        Double [] t_heatConductivity = new Double[22];
        Double [] t_heatConductivityMean = new Double[22];
        Double [] t_heatCapacity = new Double[22];
        Double [] t_solution = new Double[22];
        Double [] t_matrixDiagonal = new Double[22];
        Double [] t_matrixLowerTriangle = new Double[22];
        Double [] t_heatFlow = new Double[22];
        Integer groundLayer;
        Integer bottomLayer;
        groundLayer = t_noOfTempLayers - 2;
        bottomLayer = t_noOfTempLayers - 1;
        t_heatFlow[0] = t_soilSurfaceTemperature * t_B[0] * t_heatConductivityMean[0];
        Integer i;
        for (i=0 ; i!=t_noOfTempLayers ; i+=1)
        {
            t_solution[i] = (t_volumeMatrixOld[i] + ((t_volumeMatrix[i] - t_volumeMatrixOld[i]) / t_layerThickness[i])) * t_soilTemperature[i] + t_heatFlow[i];
        }
        t_matrixDiagonal[0] = t_matrixPrimaryDiagonal[0];
        for (i=1 ; i!=t_noOfTempLayers ; i+=1)
        {
            t_matrixLowerTriangle[i] = t_matrixSecondaryDiagonal[i] / t_matrixDiagonal[(i - 1)];
            t_matrixDiagonal[i] = t_matrixPrimaryDiagonal[i] - (t_matrixLowerTriangle[i] * t_matrixSecondaryDiagonal[i]);
        }
        for (i=1 ; i!=t_noOfTempLayers ; i+=1)
        {
            t_solution[i] = t_solution[i] - (t_matrixLowerTriangle[i] * t_solution[(i - 1)]);
        }
        t_solution[bottomLayer] = t_solution[bottomLayer] / t_matrixDiagonal[bottomLayer];
        Integer j;
        Integer j_1;
        for (i=0 ; i!=bottomLayer ; i+=1)
        {
            j = bottomLayer - 1 - i;
            j_1 = j + 1;
            t_solution[j] = t_solution[j] / t_matrixDiagonal[j] - (t_matrixLowerTriangle[j_1] * t_solution[j_1]);
        }
        for (i=0 ; i!=t_noOfTempLayers ; i+=1)
        {
            t_soilTemperature[i] = t_solution[i];
        }
        for (i=0 ; i!=t_noOfSoilLayers ; i+=1)
        {
            t_volumeMatrixOld[i] = t_volumeMatrix[i];
        }
        t_volumeMatrixOld[groundLayer] = t_volumeMatrix[groundLayer];
        t_volumeMatrixOld[bottomLayer] = t_volumeMatrix[bottomLayer];
        soilTemperature.setValue(t_soilTemperature, this);
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