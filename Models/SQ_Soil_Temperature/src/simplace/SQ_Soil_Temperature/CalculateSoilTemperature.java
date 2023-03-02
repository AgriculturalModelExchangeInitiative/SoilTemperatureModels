package net.simplace.sim.components.SQ_Soil_Temperature;
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


public class CalculateSoilTemperature extends FWSimComponent
{
    private FWSimVariable<Double> deepLayerT;
    private FWSimVariable<Double> lambda_;
    private FWSimVariable<Double> heatFlux;
    private FWSimVariable<Double> meanTAir;
    private FWSimVariable<Double> minTAir;
    private FWSimVariable<Double> deepLayerT_t1;
    private FWSimVariable<Double> maxTAir;
    private FWSimVariable<Double> maxTSoil;
    private FWSimVariable<Double> minTSoil;

    public CalculateSoilTemperature(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public CalculateSoilTemperature(){
        super();
    }
    @Override
    protected void process()
    {
        Double t_deepLayerT = deepLayerT.getValue();
        Double t_lambda_ = lambda_.getValue();
        Double t_heatFlux = heatFlux.getValue();
        Double t_meanTAir = meanTAir.getValue();
        Double t_minTAir = minTAir.getValue();
        Double t_deepLayerT_t1 = deepLayerT_t1.getValue();
        Double t_maxTAir = maxTAir.getValue();
        Double t_maxTSoil;
        Double t_minTSoil;
        if (t_maxTAir == (double)(-999) && t_minTAir == (double)(999))
        {
            t_minTSoil = (double)(999);
            t_maxTSoil = (double)(-999);
            t_deepLayerT_t1 = 0.0d;
        }
        else
        {
            t_minTSoil = SoilMinimumTemperature(t_maxTAir, t_meanTAir, t_minTAir, t_heatFlux, t_lambda_, t_deepLayerT);
            t_maxTSoil = SoilMaximumTemperature(t_maxTAir, t_meanTAir, t_minTAir, t_heatFlux, t_lambda_, t_deepLayerT_t1);
            t_deepLayerT_t1 = UpdateTemperature(t_minTSoil, t_maxTSoil, t_deepLayerT);
        }
        deepLayerT_t1.setValue(t_deepLayerT_t1, this);
        maxTSoil.setValue(t_maxTSoil, this);
        minTSoil.setValue(t_minTSoil, this);
    }
    public static Double SoilTempB(Double weatherMinTemp, Double deepTemperature)
    {
        return (weatherMinTemp + deepTemperature) / 2.0d;
    }
    public static Double SoilTempA(Double weatherMaxTemp, Double weatherMeanTemp, Double soilHeatFlux, Double lambda_)
    {
        Double TempAdjustment;
        Double SoilAvailableEnergy;
        TempAdjustment = weatherMeanTemp < 8.0d ? -0.5d * weatherMeanTemp + 4.0d : (double)(0);
        SoilAvailableEnergy = soilHeatFlux * t_lambda_ / 1000;
        return weatherMaxTemp + (11.2d * (1.0d - Math.exp(-0.07d * (SoilAvailableEnergy - 5.5d)))) + TempAdjustment;
    }
    public static Double SoilMinimumTemperature(Double weatherMaxTemp, Double weatherMeanTemp, Double weatherMinTemp, Double soilHeatFlux, Double lambda_, Double deepTemperature)
    {
        return Math.min(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, t_lambda_), SoilTempB(weatherMinTemp, deepTemperature));
    }
    public static Double SoilMaximumTemperature(Double weatherMaxTemp, Double weatherMeanTemp, Double weatherMinTemp, Double soilHeatFlux, Double lambda_, Double deepTemperature)
    {
        return Math.max(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, t_lambda_), SoilTempB(weatherMinTemp, deepTemperature));
    }
    public static Double UpdateTemperature(Double minSoilTemp, Double maxSoilTemp, Double Temperature)
    {
        Double meanTemp;
        meanTemp = (minSoilTemp + maxSoilTemp) / 2.0d;
        Temperature = (9.0d * Temperature + meanTemp) / 10.0d;
        return Temperature;
    }

    @Override
    protected void init()
    {
    }
    public HashMap<String, FWSimVariable<?>> fillTestVariables(int aParamIndex, TEST_STATE aDefineOrCheck)
    {
        return iFieldMap;
    }

    @Override
    protected FWSimComponent clone(FWSimVarMap aVarMap)
    {
        return new CalculateSoilTemperature(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("deepLayerT", "Temperature of the last soil layer", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"", -30, 80, 20, this));
        addVariable(FWSimVariable.createSimVariable("lambda_", "Latente heat of water vaporization at 20°C", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"", 0, 10, 2.454, this));
        addVariable(FWSimVariable.createSimVariable("heatFlux", "Soil Heat Flux from Energy Balance Component", DATA_TYPE.DOUBLE, CONTENT_TYPE.rate,"", 0, 100, 50, this));
        addVariable(FWSimVariable.createSimVariable("meanTAir", "Mean Air Temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"", -30, 80, 22, this));
        addVariable(FWSimVariable.createSimVariable("minTAir", "Minimum Air Temperature from Weather files", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"", -30, 80, 20, this));
        addVariable(FWSimVariable.createSimVariable("deepLayerT_t1", "Temperature of the last soil layer", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"", -30, 80, 20, this));
        addVariable(FWSimVariable.createSimVariable("maxTAir", "Maximum Air Temperature from Weather Files", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"", -30, 80, 25, this));
        addVariable(FWSimVariable.createSimVariable("maxTSoil", "Maximum Soil Temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"", -30, 80, null, this));
        addVariable(FWSimVariable.createSimVariable("minTSoil", "Minimum Soil Temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"", -30, 80, null, this));

        return iFieldMap;
    }
}