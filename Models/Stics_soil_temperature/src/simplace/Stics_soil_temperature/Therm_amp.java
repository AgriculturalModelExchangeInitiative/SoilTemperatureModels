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


public class Therm_amp extends FWSimComponent
{
    private FWSimVariable<Double> therm_diff;
    private FWSimVariable<Double> temp_wave_freq;
    private FWSimVariable<Double> therm_amp;

    public Therm_amp(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public Therm_amp(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("therm_diff", "soil thermal diffusivity", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"cm2 s-1", 0.0, 1.0e-1, 5.37e-3, this));
        addVariable(FWSimVariable.createSimVariable("temp_wave_freq", "angular frequency of the diurnal temperature sine wave", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"radians s-1", 0.0, null, 7.272e-5, this));
        addVariable(FWSimVariable.createSimVariable("therm_amp", "thermal amplitude", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"radians cm-2", null, null, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Double t_therm_diff = therm_diff.getValue();
        Double t_temp_wave_freq = temp_wave_freq.getValue();
        Double t_therm_amp;
        Double temp_freq;
        temp_freq = t_temp_wave_freq;
        t_therm_amp = Math.sqrt(temp_freq / 2 / t_therm_diff);
        therm_amp.setValue(t_therm_amp, this);
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
        return new Therm_amp(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}