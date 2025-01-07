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


public class Temp_amp extends FWSimComponent
{
    private FWSimVariable<Double> min_temp;
    private FWSimVariable<Double> max_temp;
    private FWSimVariable<Double> temp_amp;

    public Temp_amp(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public Temp_amp(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("min_temp", "current minimum temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", -50.0, 50.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("max_temp", "current maximum temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", -50.0, 50.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("temp_amp", "current temperature amplitude", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"degC", 0.0, 100.0, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        double t_min_temp = min_temp.getValue();
        double t_max_temp = max_temp.getValue();
        double t_temp_amp;
        t_temp_amp = t_max_temp - t_min_temp;
        temp_amp.setValue(t_temp_amp, this);
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
        return new Temp_amp(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}