package net.simplace.sim.components.Stics_soil_temperature;
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


public class Temp_profile extends FWSimComponent
{
    private FWSimVariable<Double> temp_amp;
    private FWSimVariable<Double> therm_amp;
    private FWSimVariable<Double[]> prev_temp_profile;
    private FWSimVariable<Double> prev_canopy_temp;
    private FWSimVariable<Double> min_air_temp;
    private FWSimVariable<Double[]> temp_profile;

    public Temp_profile(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public Temp_profile(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("temp_amp", "current temperature amplitude", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", 0.0, 100.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("therm_amp", "current thermal amplitude", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("prev_temp_profile", "previous soil temperature profile ", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", -50.0, 50.0, null, this));
        addVariable(FWSimVariable.createSimVariable("prev_canopy_temp", "previous crop temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", 0.0, 50.0, null, this));
        addVariable(FWSimVariable.createSimVariable("min_air_temp", "current minimum air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", -50.0, 50.0, null, this));
        addVariable(FWSimVariable.createSimVariable("temp_profile", "current soil profile temperature ", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", -50.0, 50.0, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Double t_temp_amp = temp_amp.getValue();
        Double t_therm_amp = therm_amp.getValue();
        Double [] t_prev_temp_profile = new Double[1];
        Double t_prev_canopy_temp = prev_canopy_temp.getValue();
        Double t_min_air_temp = min_air_temp.getValue();
        Double [] t_temp_profile;
        Integer z;
        Integer n;
        Double[] vexp;
        n = t_prev_temp_profile.length;
        t_temp_profile = new Double [n];
        vexp = new Double [n];
        for (z=1 ; z!=n + 1 ; z+=1)
        {
            vexp[z - 1] = Math.exp(-(z * t_therm_amp));
        }
        for (z=1 ; z!=n + 1 ; z+=1)
        {
            t_temp_profile[z - 1] = t_prev_temp_profile[z - 1] - (vexp[(z - 1)] * (t_prev_canopy_temp - t_min_air_temp)) + (0.1d * (t_prev_canopy_temp - t_prev_temp_profile[z - 1])) + (t_temp_amp * vexp[(z - 1)] / 2);
        }
        t_prev_temp_profile = t_temp_profile;
        temp_profile.setValue(t_temp_profile, this);
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
        return new Temp_profile(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}