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


public class CalculateHourlySoilTemperature extends FWSimComponent
{
    private FWSimVariable<Double> minTSoil;
    private FWSimVariable<Double> dayLength;
    private FWSimVariable<Double> b;
    private FWSimVariable<Double> a;
    private FWSimVariable<Double> maxTSoil;
    private FWSimVariable<Double> c;
    private FWSimVariable<Double[]> hourlySoilT;

    public CalculateHourlySoilTemperature(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public CalculateHourlySoilTemperature(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("minTSoil", "Minimum Soil Temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"Â°C", -30, 80, 20, this));
        addVariable(FWSimVariable.createSimVariable("dayLength", "Length of the day", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"hour", 0, 24, 12, this));
        addVariable(FWSimVariable.createSimVariable("b", "Delay between sunrise and time when minimum temperature is reached", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"Hour", 0, 10, 1.81, this));
        addVariable(FWSimVariable.createSimVariable("a", "Delay between sunset and time when maximum temperature is reached", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"Hour", 0, 10, 0.5, this));
        addVariable(FWSimVariable.createSimVariable("maxTSoil", "Maximum Soil Temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"Â°C", -30, 80, 20, this));
        addVariable(FWSimVariable.createSimVariable("c", "Nighttime temperature coefficient", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"Dpmensionless", 0, 10, 0.49, this));
        addVariable(FWSimVariable.createSimVariable("hourlySoilT", "Hourly Soil Temperature", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"Â°C", -30, 80, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        getHourlySoilSurfaceTemperature zz_getHourlySoilSurfaceTemperature;
        Double t_minTSoil = minTSoil.getValue();
        Double t_dayLength = dayLength.getValue();
        Double t_b = b.getValue();
        Double t_a = a.getValue();
        Double t_maxTSoil = maxTSoil.getValue();
        Double t_c = c.getValue();
        Double [] t_hourlySoilT;
        Integer i;
        if (t_maxTSoil == (double)(-999) && t_minTSoil == (double)(999))
        {
            for (i=0 ; i!=12 ; i+=1)
            {
                t_hourlySoilT[i] = (double)(999);
            }
            for (i=12 ; i!=24 ; i+=1)
            {
                t_hourlySoilT[i] = (double)(-999);
            }
        }
        else
        {
            for (i=0 ; i!=24 ; i+=1)
            {
                t_hourlySoilT[i] = 0.0d;
            }
            t_hourlySoilT = getHourlySoilSurfaceTemperature(t_maxTSoil, t_minTSoil, t_dayLength, t_b, t_a, t_c);
        }
        hourlySoilT.setValue(t_hourlySoilT, this);
    }
    public static Double [] getHourlySoilSurfaceTemperature(Double TMax, Double TMin, Double ady, Double t_b, Double t_a, Double t_c)
    {
        Integer i;
        Double[] result = new Double[24];
        Double ahou;
        Double ani;
        Double bb;
        Double be;
        Double bbd;
        Double ddy;
        Double tsn;
        ahou = Math.PI * (ady / 24.0d);
        ani = 24 - ady;
        bb = 12 - (ady / 2) + t_c;
        be = 12 + (ady / 2);
        for (i=0 ; i!=24 ; i+=1)
        {
            if (i >= (int)(bb) && i <= (int)(be))
            {
                result[i] = (TMax - TMin) * Math.sin(3.14d * (i - bb) / (ady + (2 * t_a))) + TMin;
            }
            else
            {
                if (i > (int)(be))
                {
                    bbd = i - be;
                }
                else
                {
                    bbd = 24 + be + i;
                }
                ddy = ady - t_c;
                tsn = (TMax - TMin) * Math.sin(3.14d * ddy / (ady + (2 * t_a))) + TMin;
                result[i] = TMin + ((tsn - TMin) * Math.exp(-t_b * bbd / ani));
            }
        }
        return result;
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
        return new CalculateHourlySoilTemperature(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}