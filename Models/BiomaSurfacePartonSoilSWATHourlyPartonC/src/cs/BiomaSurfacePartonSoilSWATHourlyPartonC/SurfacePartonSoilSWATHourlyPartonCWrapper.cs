using System;
using System.Collections.Generic;
using System.Linq;
class SurfacePartonSoilSWATHourlyPartonCWrapper
{
    private SurfacePartonSoilSWATHourlyPartonCState s;
    private SurfacePartonSoilSWATHourlyPartonCState s1;
    private SurfacePartonSoilSWATHourlyPartonCRate r;
    private SurfacePartonSoilSWATHourlyPartonCAuxiliary a;
    private SurfacePartonSoilSWATHourlyPartonCExogenous ex;
    private SurfacePartonSoilSWATHourlyPartonCComponent surfacepartonsoilswathourlypartoncComponent;

    public SurfacePartonSoilSWATHourlyPartonCWrapper()
    {
        s = new SurfacePartonSoilSWATHourlyPartonCState();
        r = new SurfacePartonSoilSWATHourlyPartonCRate();
        a = new SurfacePartonSoilSWATHourlyPartonCAuxiliary();
        ex = new SurfacePartonSoilSWATHourlyPartonCExogenous();
        surfacepartonsoilswathourlypartoncComponent = new SurfacePartonSoilSWATHourlyPartonCComponent();
        loadParameters();
    }

        double SoilProfileDepth;
    double LagCoefficient;
    double AirTemperatureAnnualAverage;
    double[] LayerThickness =  new double [100];
    double[] BulkDensity =  new double [100];
    double[] Silt =  new double [100];
    double[] Clay =  new double [100];
    int layersNumber;

    public double[] SoilTemperatureByLayers{ get { return s.SoilTemperatureByLayers;}} 
     
    public double[] HeatCapacity{ get { return s.HeatCapacity;}} 
     
    public double[] ThermalConductivity{ get { return s.ThermalConductivity;}} 
     
    public double[] ThermalDiffusivity{ get { return s.ThermalDiffusivity;}} 
     
    public double[] SoilTemperatureRangeByLayers{ get { return s.SoilTemperatureRangeByLayers;}} 
     
    public double[] SoilTemperatureMinimum{ get { return s.SoilTemperatureMinimum;}} 
     
    public double[] SoilTemperatureMaximum{ get { return s.SoilTemperatureMaximum;}} 
     
    public double[] SoilTemperatureByLayersHourly{ get { return s.SoilTemperatureByLayersHourly;}} 
     
    public double SurfaceSoilTemperature{ get { return a.SurfaceSoilTemperature;}} 
     
    public double SurfaceTemperatureMinimum{ get { return a.SurfaceTemperatureMinimum;}} 
     
    public double SurfaceTemperatureMaximum{ get { return a.SurfaceTemperatureMaximum;}} 
     

    public SurfacePartonSoilSWATHourlyPartonCWrapper(SurfacePartonSoilSWATHourlyPartonCWrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new SurfacePartonSoilSWATHourlyPartonCState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new SurfacePartonSoilSWATHourlyPartonCRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new SurfacePartonSoilSWATHourlyPartonCAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new SurfacePartonSoilSWATHourlyPartonCExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            surfacepartonsoilswathourlypartoncComponent = (toCopy.surfacepartonsoilswathourlypartoncComponent != null) ? new SurfacePartonSoilSWATHourlyPartonCComponent(toCopy.surfacepartonsoilswathourlypartoncComponent) : null;
        }
    }

    public void Init(){
        surfacepartonsoilswathourlypartoncComponent.Init(s, r, a);
        loadParameters();
    }

    private void loadParameters()
    {
        surfacepartonsoilswathourlypartoncComponent.SoilProfileDepth = SoilProfileDepth;
        surfacepartonsoilswathourlypartoncComponent.LagCoefficient = LagCoefficient;
        surfacepartonsoilswathourlypartoncComponent.AirTemperatureAnnualAverage = AirTemperatureAnnualAverage;
        surfacepartonsoilswathourlypartoncComponent.LayerThickness = LayerThickness;
        surfacepartonsoilswathourlypartoncComponent.BulkDensity = BulkDensity;
        surfacepartonsoilswathourlypartoncComponent.Silt = Silt;
        surfacepartonsoilswathourlypartoncComponent.Clay = Clay;
        surfacepartonsoilswathourlypartoncComponent.layersNumber = layersNumber;
    }

    public void EstimateSurfacePartonSoilSWATHourlyPartonC(double AboveGroundBiomass, double[] Sand, double[] OrganicMatter, double AirTemperatureMinimum, double DayLength, double GlobalSolarRadiation, double AirTemperatureMaximum, double[] VolumetricWaterContent, double HourOfSunset, double HourOfSunrise)
    {
        a.AboveGroundBiomass = AboveGroundBiomass;
        a.Sand = Sand;
        a.OrganicMatter = OrganicMatter;
        a.AirTemperatureMinimum = AirTemperatureMinimum;
        a.DayLength = DayLength;
        a.GlobalSolarRadiation = GlobalSolarRadiation;
        a.AirTemperatureMaximum = AirTemperatureMaximum;
        a.VolumetricWaterContent = VolumetricWaterContent;
        a.HourOfSunset = HourOfSunset;
        a.HourOfSunrise = HourOfSunrise;
        surfacepartonsoilswathourlypartoncComponent.CalculateModel(s,s1, r, a, ex);
    }

}