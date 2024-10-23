using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: ThermalDiffu -Version: 001, -Time step: 1
///- Description:
///            * Title: ThermalDiffu model
///            * Authors: simone.bregaglio
///            * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
///            * Institution: University Of Milan
///            * ExtendedDescription: Strategy for the calculation of thermal diffusitivity. Bristow, K.L., Thermal conductivity, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series
///            * ShortDescription: Strategy for the calculation of thermal diffusitivity
///- inputs:
///            * name: ThermalDiffusivity
///                          ** description : Thermal diffusivity of soil layer
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 1
///                          ** min : 0
///                          ** default : 0.0025
///                          ** unit : mm s-1
///            * name: ThermalConductivity
///                          ** description : Thermal conductivity of soil layer
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 8
///                          ** min : 0.025
///                          ** default : 1
///                          ** unit : W m-1 K-1
///            * name: HeatCapacity
///                          ** description : Volumetric specific heat of soil
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 300
///                          ** min : 0
///                          ** default : 20
///                          ** unit : MJ m-3
///            * name: layersNumber
///                          ** description : Number of layersl
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : INT
///                          ** max : 300
///                          ** min : 0
///                          ** default : 10
///                          ** unit : dimensionless
///- outputs:
///            * name: ThermalDiffusivity
///                          ** description : Thermal diffusivity of soil layer
///                          ** datatype : DOUBLEARRAY
///                          ** variablecategory : state
///                          ** len : 
///                          ** max : 1
///                          ** min : 0
///                          ** unit : mm s-1
/// </summary>
public class ThermalDiffu
{

    private int _layersNumber;
    /// <summary>
    /// Gets and sets the Number of layersl
    /// </summary>
    [Description("Number of layersl")] 
    [Units("dimensionless")] 
    //[Crop2ML(datatype="INT", min=0, max=300, default=10, parametercategory=constant, inputtype="parameter")] 
    public int layersNumber
    {
        get { return this._layersNumber; }
        set { this._layersNumber= value; } 
    }

    
    /// <summary>
    /// Constructor of the ThermalDiffu component")
    /// </summary>  
    public ThermalDiffu() { }
    
    /// <summary>
    /// Algorithm of the ThermalDiffu component
    /// </summary>
    public void  CalculateModel(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        double[] ThermalDiffusivity = s.ThermalDiffusivity;
        double[] ThermalConductivity = a.ThermalConductivity;
        double[] HeatCapacity = a.HeatCapacity;
        int i;
        for (i=0 ; i!=layersNumber ; i+=1)
        {
            ThermalDiffusivity[i] = ThermalConductivity[i] / HeatCapacity[i] / 100;
        }
        s.ThermalDiffusivity= ThermalDiffusivity;
    }
}