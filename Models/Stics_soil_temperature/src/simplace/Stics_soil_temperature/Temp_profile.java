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
    private FWSimVariable<Double[]> prev_temp_profile;
    private FWSimVariable<Double> prev_canopy_temp;
    private FWSimVariable<Double> min_air_temp;
    private FWSimVariable<Double> air_temp_day1;
    private FWSimVariable<Integer[]> layer_thick;
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
        addVariable(FWSimVariable.createSimVariable("temp_amp", "current temperature amplitude", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"degC", 0.0, 100.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("prev_temp_profile", "previous soil temperature profile ", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", -50.0, 50.0, null, this));
        addVariable(FWSimVariable.createSimVariable("prev_canopy_temp", "previous crop temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"degC", 0.0, 50.0, null, this));
        addVariable(FWSimVariable.createSimVariable("min_air_temp", "current minimum air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", -50.0, 50.0, null, this));
        addVariable(FWSimVariable.createSimVariable("air_temp_day1", "Mean temperature on first day", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"degC", 0.0, 100.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("layer_thick", "layers thickness", DATA_TYPE.INTARRAY, CONTENT_TYPE.constant,"cm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("temp_profile", "current soil profile temperature ", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", -50.0, 50.0, null, this));

        return iFieldMap;
    }
    @Override
    protected void init()
    {
        Double t_min_air_temp = min_air_temp.getValue();
        Double t_air_temp_day1 = air_temp_day1.getValue();
        Integer [] t_layer_thick = layer_thick.getValue();
        Double t_temp_amp = temp_amp.getDefault();
        Double [] t_prev_temp_profile = prev_temp_profile.getValue();;
        Double t_prev_canopy_temp = prev_canopy_temp.getDefault();
        t_prev_canopy_temp = 0.0d;
        Integer soil_depth;
        soil_depth = Arrays.stream(t_layer_thick).mapToInt(Integer::intValue).sum();
        t_prev_temp_profile = new Double [soil_depth];
        t_prev_temp_profile = new ArrayList<>(Arrays.asList(t_air_temp_day1)) * soil_depth;
        t_prev_canopy_temp = t_air_temp_day1;
        temp_amp.setValue(t_temp_amp, this);
        prev_temp_profile.setValue(t_prev_temp_profile, this);
        prev_canopy_temp.setValue(t_prev_canopy_temp, this);
    }
    @Override
    protected void process()
    {
        Double t_temp_amp = temp_amp.getValue();
        Double [] t_prev_temp_profile = prev_temp_profile.getValue();
        Double t_prev_canopy_temp = prev_canopy_temp.getValue();
        Double t_min_air_temp = min_air_temp.getValue();
        Double t_air_temp_day1 = air_temp_day1.getValue();
        Integer [] t_layer_thick = layer_thick.getValue();
        Double [] t_temp_profile;
        Integer z;
        Integer n;
        List<> Doublevexp = new ArrayList<>(Arrays.asList());
        Double therm_diff = 5.37e-3d;
        Double temp_freq = 7.272e-5d;
        Double therm_amp;
        n = t_prev_temp_profile.length;
        t_temp_profile = new Double [n];
        vexp = new Double [n];
        therm_amp = Math.sqrt(temp_freq / 2 / therm_diff);
        for (z=1 ; z!=n + 1 ; z+=1)
        {
            vexp.set(z - 1,Math.exp(-(z * therm_amp)));
        }
        for (z=1 ; z!=n + 1 ; z+=1)
        {
            t_temp_profile[z - 1] = t_prev_temp_profile[z - 1] - (vexp.get((z - 1)) * (t_prev_canopy_temp - t_min_air_temp)) + (0.1d * (t_prev_canopy_temp - t_prev_temp_profile[z - 1])) + (t_temp_amp * vexp.get((z - 1)) / 2);
        }
        temp_profile.setValue(t_temp_profile, this);
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