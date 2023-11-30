import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class ThermalConductivitySIMULAT
{
    public void Init(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a,  SurfacePartonSoilSWATHourlyPartonCExogenous ex)
    {
        Double [] VolumetricWaterContent = ex.getVolumetricWaterContent();
        Double[] ThermalConductivity ;
        ThermalConductivity= new Double[VolumetricWaterContent.length];
        Arrays.fill(ThermalConductivity, 0.0d);
        s.setThermalConductivity(ThermalConductivity);
    }
    private Double [] BulkDensity;
    public Double [] getBulkDensity()
    { return BulkDensity; }

    public void setBulkDensity(Double [] _BulkDensity)
    { this.BulkDensity= _BulkDensity; } 
    
    private Double [] Clay;
    public Double [] getClay()
    { return Clay; }

    public void setClay(Double [] _Clay)
    { this.Clay= _Clay; } 
    
    public ThermalConductivitySIMULAT() { }
    public void  Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonCAuxiliary a,  SurfacePartonSoilSWATHourlyPartonCExogenous ex)
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
        Double [] VolumetricWaterContent = ex.getVolumetricWaterContent();
        Double [] ThermalConductivity = s.getThermalConductivity();
        Integer i;
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
        for (i=0 ; i!=VolumetricWaterContent.length ; i+=1)
        {
            Aterm = 0.65d - (0.78d * BulkDensity[i]) + (0.6d * Math.pow(BulkDensity[i], 2));
            Bterm = 1.06d * BulkDensity[i] * VolumetricWaterContent[i];
            Cterm = 1 + (2.6d * Math.sqrt(Clay[i] / 100));
            Dterm = 0.03d + (0.1d * Math.pow(BulkDensity[i], 2));
            ThermalConductivity[i] = Aterm + (Bterm * VolumetricWaterContent[i]) - ((Aterm - Dterm) * Math.pow(Math.exp(-(Cterm * VolumetricWaterContent[i])), Eterm));
        }
        s.setThermalConductivity(ThermalConductivity);
    }
}