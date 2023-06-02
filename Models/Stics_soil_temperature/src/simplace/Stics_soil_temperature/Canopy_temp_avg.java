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


public class Canopy_temp_avg extends FWSimComponent
{
    private FWSimVariable<Double> min_canopy_temp;
    private FWSimVariable<Double> max_canopy_temp;
    private FWSimVariable<Double> canopy_temp_avg;

    public Canopy_temp_avg(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public Canopy_temp_avg(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("min_canopy_temp", "current minimum temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", -50.0, 50.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("max_canopy_temp", "current maximum temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", -50.0, 50.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("canopy_temp_avg", "current temperature amplitude", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"degC", 0.0, 100.0, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Double t_min_canopy_temp = min_canopy_temp.getValue();
        Double t_max_canopy_temp = max_canopy_temp.getValue();
        Double t_canopy_temp_avg;
        t_canopy_temp_avg = (t_max_canopy_temp + t_min_canopy_temp) / 2;
        canopy_temp_avg.setValue(t_canopy_temp_avg, this);
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
        return new Canopy_temp_avg(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}