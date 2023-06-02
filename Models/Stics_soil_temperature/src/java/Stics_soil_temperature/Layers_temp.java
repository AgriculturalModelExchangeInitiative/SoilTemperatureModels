import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class Layers_temp
{
    private Integer [] layer_thick;
    public Integer [] getlayer_thick()
    { return layer_thick; }

    public void setlayer_thick(Integer [] _layer_thick)
    { this.layer_thick= _layer_thick; } 
    
    public Layers_temp() { }
    public void  Calculate_Model(soil_tempState s, soil_tempState s1, soil_tempRate r, soil_tempAuxiliary a,  soil_tempExogenous ex)
    {
        //- Name: layers_temp -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: layers mean temperature model
    //            * Authors: None
    //            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    //            * Institution: INRAE
    //            * ExtendedDescription: None
    //            * ShortDescription: None
        //- inputs:
    //            * name: temp_profile
    //                          ** description : soil temperature profile
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** default : 0.0
    //                          ** unit : degC
    //            * name: layer_thick
    //                          ** description : layers thickness
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INTARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : cm
        //- outputs:
    //            * name: layer_temp
    //                          ** description : soil layers temperature
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** unit : degC
        get_layers_number zz_get_layers_number;
        layer_thickness2depth zz_layer_thickness2depth;
        Double [] temp_profile = s.gettemp_profile();
        Double[] layer_temp ;
        Integer z;
        Integer layers_nb;
        List<Integer> up_depth = new ArrayList<>(Arrays.asList());
        List<Integer> layer_depth = new ArrayList<>(Arrays.asList());
        Integer depth_value;
        layers_nb = get_layers_number(layer_thick);
        layer_temp = new Double [layers_nb];
        up_depth = new Integer [layers_nb + 1];
        layer_depth = new Integer [layers_nb];
        up_depth = new ArrayList<>(Arrays.asList(0)) * (layers_nb + 1);
        layer_depth = layer_thickness2depth(layer_thick);
        for (z=1 ; z!=layers_nb + 1 ; z+=1)
        {
            depth_value = layer_depth.get(z - 1);
            up_depth.set(z + 1 - 1,depth_value);
        }
        for (z=1 ; z!=layers_nb + 1 ; z+=1)
        {
            layer_temp[z - 1] = Arrays.stream(temp_profile[(up_depth.get(z - 1) + 1 - 1):up_depth.get((z + 1 - 1))]).mapToDouble(Double::doubleValue).sum() / layer_thick[(z - 1)];
        }
        s.setlayer_temp(layer_temp);
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
    public static List<Integer> layer_thickness2depth(Integer [] layer_thick)
    {
        List<Integer> layer_depth = new ArrayList<>(Arrays.asList());
        Integer layers_nb;
        Integer z;
        layers_nb = layer_thick.length;
        layer_depth = new Integer [layers_nb];
        layer_depth = new ArrayList<>(Arrays.asList(0)) * layers_nb;
        for (z=1 ; z!=layers_nb + 1 ; z+=1)
        {
            if (layer_thick[z - 1] != 0)
            {
                layer_depth.set(z - 1,Arrays.stream(layer_thick[1 - 1:z]).mapToInt(Integer::intValue).sum());
            }
        }
        return layer_depth;
    }
}