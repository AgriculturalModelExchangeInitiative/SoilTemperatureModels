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


public class Update extends FWSimComponent
{
    private FWSimVariable<Double> canopy_temp_avg;
    private FWSimVariable<Double[]> temp_profile;
    private FWSimVariable<Double> prev_canopy_temp;
    private FWSimVariable<Double[]> prev_temp_profile;

    public Update(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public Update(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("canopy_temp_avg", "current canopy mean temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"degC", -50.0, 50.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("temp_profile", "current soil profile temperature (for 1 cm layers)", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", -50.0, 50.0, null, this));
        addVariable(FWSimVariable.createSimVariable("prev_canopy_temp", "previous crop temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"degC", 0.0, 50.0, null, this));
        addVariable(FWSimVariable.createSimVariable("prev_temp_profile", "previous soil temperature profile (for 1 cm layers)", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", -50.0, 50.0, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Double t_canopy_temp_avg = canopy_temp_avg.getValue();
        Double [] t_temp_profile = temp_profile.getValue();
        Double t_prev_canopy_temp;
        Double [] t_prev_temp_profile;
        Integer n;
        t_prev_canopy_temp = t_canopy_temp_avg;
        n = t_temp_profile.length;
        t_prev_temp_profile = new Double [n];
        t_prev_temp_profile = t_temp_profile;
        prev_canopy_temp.setValue(t_prev_canopy_temp, this);
        prev_temp_profile.setValue(t_prev_temp_profile, this);
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
        return new Update(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}