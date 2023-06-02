using System;
using System.Collections.Generic;
using System.Linq;
public class layers_temp
{
    private int[] _layer_thick;
    public int[] layer_thick
        {
            get { return this._layer_thick; }
            set { this._layer_thick= value; } 
        }
        public layers_temp() { }
    
    public void  CalculateModel(soil_tempState s, soil_tempState s1, soil_tempRate r, soil_tempAuxiliary a, soil_tempExogenous ex)
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
        double[] temp_profile = s.temp_profile;
        double[] layer_temp ;
        int z;
        int layers_nb;
        List<int> up_depth = new List<int>();
        List<int> layer_depth = new List<int>();
        int depth_value;
        layers_nb = get_layers_number(layer_thick);
        layer_temp = new double[ layers_nb];
        up_depth = new List<int>(layers_nb + 1);
        layer_depth = new List<int>(layers_nb);
        for (var i = 0; i < layers_nb + 1; i++){up_depth.Add(0);}
        layer_depth = layer_thickness2depth(layer_thick);
        for (z=1 ; z!=layers_nb + 1 ; z+=1)
        {
            depth_value = layer_depth[z - 1];
            up_depth[z + 1 - 1] = depth_value;
        }
        for (z=1 ; z!=layers_nb + 1 ; z+=1)
        {
            layer_temp[z - 1] = temp_profile.ToList().GetRange((up_depth[z - 1] + 1 - 1),up_depth[(z + 1 - 1)]).Sum() / layer_thick[(z - 1)];
        }
        s.layer_temp= layer_temp;
    }
    public static List<int> layer_thickness2depth(int[] layer_thick)
    {
        List<int> layer_depth = new List<int>();
        int layers_nb;
        int z;
        layers_nb = layer_thick.Length;
        layer_depth = new List<int>(layers_nb);
        for (var i = 0; i < layers_nb; i++){layer_depth.Add(0);}
        for (z=1 ; z!=layers_nb + 1 ; z+=1)
        {
            if (layer_thick[z - 1] != 0)
            {
                layer_depth[z - 1] = layer_thick.ToList().GetRange(1 - 1,z).Sum();
            }
        }
        return layer_depth;
    }
    public static int get_layers_number(int[] layer_thick_or_depth)
    {
        int layers_number;
        int z;
        layers_number = 0;
        for (z=1 ; z!=layer_thick_or_depth.Length + 1 ; z+=1)
        {
            if (layer_thick_or_depth[z - 1] != 0)
            {
                layers_number = layers_number + 1;
            }
        }
        return layers_number;
    }
}