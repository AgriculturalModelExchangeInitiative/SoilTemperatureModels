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


public class Layers_temp extends FWSimComponent
{
    private FWSimVariable<Double[]> temp_profile;
    private FWSimVariable<Integer[]> layer_thick;
    private FWSimVariable<Double[]> layer_temp;

    public Layers_temp(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public Layers_temp(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("temp_profile", "soil temperature profile", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", -50.0, 50.0, 0.0, this));
        addVariable(FWSimVariable.createSimVariable("layer_thick", "layers thickness", DATA_TYPE.INTARRAY, CONTENT_TYPE.constant,"cm", null, null, null, this));
        addVariable(FWSimVariable.createSimVariable("layer_temp", "soil layers temperature", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", -50.0, 50.0, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        get_layers_number zz_get_layers_number;
        layer_thickness2depth zz_layer_thickness2depth;
        Double [] t_temp_profile = temp_profile.getValue();
        Integer [] t_layer_thick = layer_thick.getValue();
        Double [] t_layer_temp;
        Integer z;
        Integer layers_nb;
        List<> Integerup_depth = new ArrayList<>(Arrays.asList());
        List<> Integerlayer_depth = new ArrayList<>(Arrays.asList());
        Integer depth_value;
        layers_nb = get_layers_number(t_layer_thick);
        t_layer_temp = new Double [layers_nb];
        up_depth = new Integer [layers_nb + 1];
        layer_depth = new Integer [layers_nb];
        up_depth = new ArrayList<>(Arrays.asList(0)) * (layers_nb + 1);
        layer_depth = layer_thickness2depth(t_layer_thick);
        for (z=1 ; z!=layers_nb + 1 ; z+=1)
        {
            depth_value = layer_depth.get(z - 1);
            up_depth.set(z + 1 - 1,depth_value);
        }
        for (z=1 ; z!=layers_nb + 1 ; z+=1)
        {
            t_layer_temp[z - 1] = Arrays.stream(t_temp_profile[(up_depth.get(z - 1) + 1 - 1):(up_depth.get(z + 1 - 1) + 1)]).mapToDouble(Double::doubleValue).sum() / t_layer_thick[(z - 1)];
        }
        layer_temp.setValue(t_layer_temp, this);
    }
    public static Integer get_layers_number(Integer [] layer_thick_or_depth)
    {
        Integer layers_number;
        Integer z;
        layers_number = 0;
        for (z=1 ; z!=layer_thick_or_depth.length + 1 ; z+=1)
        {
            if (layer_thick_or_depth[z - 1] != 0)
            {
                layers_number = layers_number + 1;
            }
        }
        return layers_number;
    }
    public static List<Integer> layer_thickness2depth(Integer [] t_layer_thick)
    {
        List<> Integerlayer_depth = new ArrayList<>(Arrays.asList());
        Integer layers_nb;
        Integer z;
        layers_nb = t_layer_thick.length;
        layer_depth = new Integer [layers_nb];
        layer_depth = new ArrayList<>(Arrays.asList(0)) * layers_nb;
        for (z=1 ; z!=layers_nb + 1 ; z+=1)
        {
            if (t_layer_thick[z - 1] != 0)
            {
                layer_depth.set(z - 1,Arrays.stream(t_layer_thick[1 - 1:z + 1]).mapToInt(Integer::intValue).sum());
            }
        }
        return layer_depth;
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
        return new Layers_temp(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}