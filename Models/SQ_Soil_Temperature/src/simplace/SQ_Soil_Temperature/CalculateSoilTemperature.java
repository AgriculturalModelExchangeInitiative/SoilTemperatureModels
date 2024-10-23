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
    private FWSimVariable<Double> meanTAir;
    private FWSimVariable<Double> minTAir;
    private FWSimVariable<Double> lambda_;
    private FWSimVariable<Double> deepLayerT;
    private FWSimVariable<Double> meanAnnualAirTemp;
    private FWSimVariable<Double> heatFlux;
    private FWSimVariable<Double> maxTAir;
    private FWSimVariable<Double> minTSoil;
    private FWSimVariable<Double> maxTSoil;

    public CalculateSoilTemperature(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public CalculateSoilTemperature(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("meanTAir", "Mean Air Temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"Â°C", -30, 80, 22, this));
        addVariable(FWSimVariable.createSimVariable("minTAir", "Minimum Air Temperature from Weather files", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"Â°C", -30, 80, 20, this));
        addVariable(FWSimVariable.createSimVariable("lambda_", "Latente heat of water vaporization at 20Â°C", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"MJ.kg-1", 0, 10, 2.454, this));
        addVariable(FWSimVariable.createSimVariable("deepLayerT", "Temperature of the last soil layer", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"Â°C", -30, 80, 20, this));
        addVariable(FWSimVariable.createSimVariable("meanAnnualAirTemp", "Annual Mean Air Temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"Â°C", -30, 80, 22, this));
        addVariable(FWSimVariable.createSimVariable("heatFlux", "Soil Heat Flux from Energy Balance Component", DATA_TYPE.DOUBLE, CONTENT_TYPE.rate,"g m-2 d-1", 0, 100, 50, this));
        addVariable(FWSimVariable.createSimVariable("maxTAir", "Maximum Air Temperature from Weather Files", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"Â°C", -30, 80, 25, this));
        addVariable(FWSimVariable.createSimVariable("minTSoil", "Minimum Soil Temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"Â°C", -30, 80, null, this));
        addVariable(FWSimVariable.createSimVariable("maxTSoil", "Maximum Soil Temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"Â°C", -30, 80, null, this));

        return iFieldMap;
    }
    @Override
    protected void init()
    {
        Double t_meanTAir = meanTAir.getValue();
        Double t_minTAir = minTAir.getValue();
        Double t_lambda_ = lambda_.getValue();
        Double t_meanAnnualAirTemp = meanAnnualAirTemp.getValue();
        Double t_maxTAir = maxTAir.getValue();
        Double t_deepLayerT = deepLayerT.getDefault();
        t_deepLayerT = t_meanAnnualAirTemp;
        deepLayerT.setValue(t_deepLayerT, this);
    }
    @Override
    protected void process()
    {
        SoilMinimumTemperature zz_SoilMinimumTemperature;
        SoilMaximumTemperature zz_SoilMaximumTemperature;
        UpdateTemperature zz_UpdateTemperature;
        Double t_meanTAir = meanTAir.getValue();
        Double t_minTAir = minTAir.getValue();
        Double t_lambda_ = lambda_.getValue();
        Double t_deepLayerT = deepLayerT.getValue();
        Double t_meanAnnualAirTemp = meanAnnualAirTemp.getValue();
        Double t_heatFlux = heatFlux.getValue();
        Double t_maxTAir = maxTAir.getValue();
        Double t_minTSoil;
        Double t_maxTSoil;
        Double tmp;
        tmp = t_meanAnnualAirTemp;
        if (t_maxTAir == (double)(-999) && t_minTAir == (double)(999))
        {
            t_minTSoil = (double)(999);
            t_maxTSoil = (double)(-999);
            t_deepLayerT = 0.0d;
        }
        else
        {
            t_minTSoil = SoilMinimumTemperature(t_maxTAir, t_meanTAir, t_minTAir, t_heatFlux, t_lambda_, t_deepLayerT);
            t_maxTSoil = SoilMaximumTemperature(t_maxTAir, t_meanTAir, t_minTAir, t_heatFlux, t_lambda_, t_deepLayerT);
            t_deepLayerT = UpdateTemperature(t_minTSoil, t_maxTSoil, t_deepLayerT);
        }
        deepLayerT.setValue(t_deepLayerT, this);
        minTSoil.setValue(t_minTSoil, this);
        maxTSoil.setValue(t_maxTSoil, this);
    }
    public static Double SoilTempB(Double weatherMinTemp, Double deepTemperature)
    {
        return (weatherMinTemp + deepTemperature) / 2.0d;
    }
    public static Double SoilTempA(Double weatherMaxTemp, Double weatherMeanTemp, Double soilHeatFlux, Double t_lambda_)
    {
        Double TempAdjustment;
        Double SoilAvailableEnergy;
        TempAdjustment = weatherMeanTemp < 8.0d ? -0.5d * weatherMeanTemp + 4.0d : (double)(0);
        SoilAvailableEnergy = soilHeatFlux * t_lambda_ / 1000;
        return weatherMaxTemp + (11.2d * (1.0d - Math.exp(-0.07d * (SoilAvailableEnergy - 5.5d)))) + TempAdjustment;
    }
    public static Double SoilMinimumTemperature(Double weatherMaxTemp, Double weatherMeanTemp, Double weatherMinTemp, Double soilHeatFlux, Double t_lambda_, Double deepTemperature)
    {
        return Math.min(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, t_lambda_), SoilTempB(weatherMinTemp, deepTemperature));
    }
    public static Double SoilMaximumTemperature(Double weatherMaxTemp, Double weatherMeanTemp, Double weatherMinTemp, Double soilHeatFlux, Double t_lambda_, Double deepTemperature)
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

    public HashMap<String, FWSimVariable<?>> fillTestVariables(int aParamIndex, TEST_STATE aDefineOrCheck)
    {
        return iFieldMap;
    }

    @Override
    protected FWSimComponent clone(FWSimVarMap aVarMap)
    {
        return new CalculateSoilTemperature(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}