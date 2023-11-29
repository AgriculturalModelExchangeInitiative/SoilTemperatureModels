using System;
using System.Collections.Generic;
using System.Linq;
class SurfaceSWATSoilSWATCWrapper
{
    private SurfaceSWATSoilSWATCState s;
    private SurfaceSWATSoilSWATCState s1;
    private SurfaceSWATSoilSWATCRate r;
    private SurfaceSWATSoilSWATCAuxiliary a;
    private SurfaceSWATSoilSWATCExogenous ex;
    private SurfaceSWATSoilSWATCComponent surfaceswatsoilswatcComponent;

    public SurfaceSWATSoilSWATCWrapper()
    {
        s = new SurfaceSWATSoilSWATCState();
        r = new SurfaceSWATSoilSWATCRate();
        a = new SurfaceSWATSoilSWATCAuxiliary();
        ex = new SurfaceSWATSoilSWATCExogenous();
        surfaceswatsoilswatcComponent = new SurfaceSWATSoilSWATCComponent();
        loadParameters();
    }

        double AirTemperatureAnnualAverage;
    double SoilProfileDepth;
    double[] BulkDensity =  new double [100];
    double[] LayerThickness =  new double [100];
    double LagCoefficient;

    public double[] SoilTemperatureByLayers{ get { return s.SoilTemperatureByLayers;}} 
     
    public double SurfaceSoilTemperature{ get { return a.SurfaceSoilTemperature;}} 
     

    public SurfaceSWATSoilSWATCWrapper(SurfaceSWATSoilSWATCWrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new SurfaceSWATSoilSWATCState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new SurfaceSWATSoilSWATCRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new SurfaceSWATSoilSWATCAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new SurfaceSWATSoilSWATCExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            surfaceswatsoilswatcComponent = (toCopy.surfaceswatsoilswatcComponent != null) ? new SurfaceSWATSoilSWATCComponent(toCopy.surfaceswatsoilswatcComponent) : null;
        }
    }

    public void Init(){
        surfaceswatsoilswatcComponent.Init(s, r, a);
        loadParameters();
    }

    private void loadParameters()
    {
        surfaceswatsoilswatcComponent.AirTemperatureAnnualAverage = AirTemperatureAnnualAverage;
        surfaceswatsoilswatcComponent.SoilProfileDepth = SoilProfileDepth;
        surfaceswatsoilswatcComponent.BulkDensity = BulkDensity;
        surfaceswatsoilswatcComponent.LayerThickness = LayerThickness;
        surfaceswatsoilswatcComponent.LagCoefficient = LagCoefficient;
    }

    public void EstimateSurfaceSWATSoilSWATC(double AboveGroundBiomass, double[] VolumetricWaterContent, double Albedo, double AirTemperatureMinimum, double WaterEquivalentOfSnowPack, double GlobalSolarRadiation, double AirTemperatureMaximum)
    {
        a.AboveGroundBiomass = AboveGroundBiomass;
        a.VolumetricWaterContent = VolumetricWaterContent;
        a.Albedo = Albedo;
        a.AirTemperatureMinimum = AirTemperatureMinimum;
        a.WaterEquivalentOfSnowPack = WaterEquivalentOfSnowPack;
        a.GlobalSolarRadiation = GlobalSolarRadiation;
        a.AirTemperatureMaximum = AirTemperatureMaximum;
        surfaceswatsoilswatcComponent.CalculateModel(s,s1, r, a, ex);
    }

}