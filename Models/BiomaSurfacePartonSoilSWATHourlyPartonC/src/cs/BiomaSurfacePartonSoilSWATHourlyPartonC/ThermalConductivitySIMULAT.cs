using System;
using System.Collections.Generic;
using System.Linq;
public class ThermalConductivitySIMULAT
{
    public void Init(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        double[] VolumetricWaterContent = ex.VolumetricWaterContent;
        double[] ThermalConductivity ;
        ThermalConductivity = new double[VolumetricWaterContent.Length];
        s.ThermalConductivity= ThermalConductivity;
    }
    private double[] _BulkDensity;
    public double[] BulkDensity
        {
            get { return this._BulkDensity; }
            set { this._BulkDensity= value; } 
        }
    private double[] _Clay;
    public double[] Clay
        {
            get { return this._Clay; }
            set { this._Clay= value; } 
        }
        public ThermalConductivitySIMULAT() { }
    
    public void  CalculateModel(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        //- Name: ThermalConductivitySIMULAT -Version: 001, -Time step: 1
        //- Description:
    //            * Title: ThermalConductivitySIMULAT model
    //            * Authors: simone.bregaglio
    //            * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
    //            * Institution: University Of Milan
    //            * ExtendedDescription: Strategy for the calculation of thermal conductivity. Bristow, K.L., Thermal conductivity, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series
    //            * ShortDescription: Strategy for the calculation of thermal conductivity
        //- inputs:
    //            * name: VolumetricWaterContent
    //                          ** description : Volumetric soil water content
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 0.8
    //                          ** min : 0
    //                          ** default : 0.25
    //                          ** unit : m3 m-3
    //            * name: BulkDensity
    //                          ** description : Bulk density
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 1.8
    //                          ** min : 0.9
    //                          ** default : 1.3
    //                          ** unit : t m-3
    //            * name: Clay
    //                          ** description : Clay content of soil layer
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 100
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : 
    //            * name: ThermalConductivity
    //                          ** description : Thermal conductivity of soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 8
    //                          ** min : 0.025
    //                          ** default : 
    //                          ** unit : W m-1 K-1
        //- outputs:
    //            * name: ThermalConductivity
    //                          ** description : Thermal conductivity of soil layer
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 8
    //                          ** min : 0.025
    //                          ** unit : W m-1 K-1
        double[] VolumetricWaterContent = ex.VolumetricWaterContent;
        double[] ThermalConductivity = s.ThermalConductivity;
        int i;
        double Aterm;
        double Bterm;
        double Cterm;
        double Dterm;
        double Eterm;
        Aterm = (double)(0);
        Bterm = (double)(0);
        Cterm = (double)(0);
        Dterm = (double)(0);
        Eterm = (double)(4);
        for (i=0 ; i!=VolumetricWaterContent.Length ; i+=1)
        {
            Aterm = 0.650d - (0.780d * BulkDensity[i]) + (0.60d * Math.Pow(BulkDensity[i], 2));
            Bterm = 1.060d * BulkDensity[i] * VolumetricWaterContent[i];
            Cterm = 1 + (2.60d * Math.Sqrt(Clay[i] / 100));
            Dterm = 0.030d + (0.10d * Math.Pow(BulkDensity[i], 2));
            ThermalConductivity[i] = Aterm + (Bterm * VolumetricWaterContent[i]) - ((Aterm - Dterm) * Math.Pow(Math.Exp(-(Cterm * VolumetricWaterContent[i])), Eterm));
        }
        s.ThermalConductivity= ThermalConductivity;
    }
}