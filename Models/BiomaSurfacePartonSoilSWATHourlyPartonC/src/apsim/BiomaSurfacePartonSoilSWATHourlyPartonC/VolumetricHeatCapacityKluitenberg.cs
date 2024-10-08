using System;
using System.Collections.Generic;
using System.Linq;    
using Models.Core;   
namespace Models.Crop2ML;

/// <summary>
///- Name: VolumetricHeatCapacityKluitenberg -Version: 001, -Time step: 1
///- Description:
///            * Title: VolumetricHeatCapacityKluitenberg model
///            * Authors: simone.bregaglio
///            * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
///            * Institution: University Of Milan
///            * ExtendedDescription: Strategy for the calculation of soil thermal diffusivity. Reference: J.M.H.Hendrickx, H. Xie, B. Borchers, J.B.J. Harrison, 2008. Global Prediction of Thermal Soil Regimes. SPIE Proceedings Volume 6953 Detection and Sensing of Mines, Explosive Objects, and Obscured Targets XIII.
///            * ShortDescription: Strategy for the calculation of volumetric heat capacity. Kluitenberg, G.J., Heat capacity and specific heat, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series
///- inputs:
///            * name: VolumetricWaterContent
///                          ** description : Volumetric soil water content
///                          ** inputtype : variable
///                          ** variablecategory : exogenous
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 0.8
///                          ** min : 0
///                          ** default : 0.25
///                          ** unit : m3 m-3
///            * name: Sand
///                          ** description : Sand content of soil layer
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 100
///                          ** min : 0
///                          ** default : 30
///                          ** unit : 
///            * name: BulkDensity
///                          ** description : Bulk density
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 1.8
///                          ** min : 0.9
///                          ** default : 1.3
///                          ** unit : t m-3
///            * name: OrganicMatter
///                          ** description : Organic matter content of soil layer
///                          ** inputtype : variable
///                          ** variablecategory : auxiliary
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 20
///                          ** min : 0
///                          ** default : 1.5
///                          ** unit : 
///            * name: HeatCapacity
///                          ** description : Volumetric specific heat of soil
///                          ** inputtype : variable
///                          ** variablecategory : state
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 300
///                          ** min : 0
///                          ** default : 20
///                          ** unit : MJ m-3
///            * name: Clay
///                          ** description : Clay content of soil layer
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 100
///                          ** min : 0
///                          ** default : 0
///                          ** unit : 
///            * name: Silt
///                          ** description : Silt content of soil layer
///                          ** inputtype : parameter
///                          ** parametercategory : constant
///                          ** datatype : DOUBLEARRAY
///                          ** len : 
///                          ** max : 100
///                          ** min : 0
///                          ** default : 20
///                          ** unit : 
///- outputs:
///            * name: HeatCapacity
///                          ** description : Volumetric specific heat of soil
///                          ** datatype : DOUBLEARRAY
///                          ** variablecategory : state
///                          ** len : 
///                          ** max : 300
///                          ** min : 0
///                          ** unit : MJ m-3
/// </summary>
public class VolumetricHeatCapacityKluitenberg
{

    private double[] _BulkDensity;
    /// <summary>
    /// Gets and sets the Bulk density
    /// </summary>
    [Description("Bulk density")] 
    [Units("t m-3")] 
    //[Crop2ML(datatype="DOUBLEARRAY", min=0.9, max=1.8, default=1.3, parametercategory=constant, inputtype="parameter")] 
    public double[] BulkDensity
    {
        get { return this._BulkDensity; }
        set { this._BulkDensity= value; } 
    }

    private double[] _Clay;
    /// <summary>
    /// Gets and sets the Clay content of soil layer
    /// </summary>
    [Description("Clay content of soil layer")] 
    [Units("")] 
    //[Crop2ML(datatype="DOUBLEARRAY", min=0, max=100, default=0, parametercategory=constant, inputtype="parameter")] 
    public double[] Clay
    {
        get { return this._Clay; }
        set { this._Clay= value; } 
    }

    private double[] _Silt;
    /// <summary>
    /// Gets and sets the Silt content of soil layer
    /// </summary>
    [Description("Silt content of soil layer")] 
    [Units("")] 
    //[Crop2ML(datatype="DOUBLEARRAY", min=0, max=100, default=20, parametercategory=constant, inputtype="parameter")] 
    public double[] Silt
    {
        get { return this._Silt; }
        set { this._Silt= value; } 
    }

    
    /// <summary>
    /// Constructor of the VolumetricHeatCapacityKluitenberg component")
    /// </summary>  
    public VolumetricHeatCapacityKluitenberg() { }
    
    /// <summary>
    /// Algorithm of the VolumetricHeatCapacityKluitenberg component
    /// </summary>
    public void  CalculateModel(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        double[] VolumetricWaterContent = ex.VolumetricWaterContent;
        double[] Sand = a.Sand;
        double[] OrganicMatter = a.OrganicMatter;
        double[] HeatCapacity = s.HeatCapacity;
        int i;
        double SandFraction;
        double SiltFraction;
        double ClayFraction;
        double FractionMinerals;
        double OrganicMatterFraction;
        SandFraction = (double)(0);
        SiltFraction = (double)(0);
        ClayFraction = (double)(0);
        FractionMinerals = (double)(0);
        OrganicMatterFraction = (double)(0);
        for (i=0 ; i!=HeatCapacity.Length ; i+=1)
        {
            SandFraction = Sand[i] / (Sand[i] + Silt[i] + Clay[i] + OrganicMatter[i]);
            SiltFraction = Silt[i] / (Sand[i] + Silt[i] + Clay[i] + OrganicMatter[i]);
            ClayFraction = Clay[i] / (Sand[i] + Silt[i] + Clay[i] + OrganicMatter[i]);
            FractionMinerals = SandFraction + SiltFraction + ClayFraction;
            OrganicMatterFraction = OrganicMatter[i] / (Sand[i] + Silt[i] + Clay[i] + OrganicMatter[i]);
            HeatCapacity[i] = BulkDensity[i] * 0.73 * FractionMinerals + (BulkDensity[i] * 1.9 * OrganicMatterFraction) + (4.18 * VolumetricWaterContent[i]);
        }
        s.HeatCapacity= HeatCapacity;
    }
}