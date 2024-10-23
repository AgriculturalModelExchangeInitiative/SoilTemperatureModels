using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSIM
{
    public class SoilTempCampbellTeiki
    {
        #region Constants & Parameters
        const int AIRnode = 0;
        const int SURFACEnode = 1;
        const int TOPSOILnode = 2;
        const double windSpeed = 259.2; //(km/d)
        const double nu = 0.6;
        const double STEFAN_BOLTZMANNconst = 0.0000000567;   // defines the power per unit area emitted by a black body as a function of its thermodynamic temperature (W/m^2/K^4).
        const double LAMBDA = 2465000.0;      // latent heat of vapourisation for water (J/kg); 1 mm evap/day = 1 kg/m^2 day requires 2.45*10^6 J/m^2
        const double M2MM = 1000.0;
        const double MM2M = 1.0 / 1000.0;
        const double DEG2RAD = Math.PI / 180.0;
        const double DAYSinYear = 365.25;    // no of days in one year
        const double DOY2RAD = DEG2RAD * 360.0 / DAYSinYear;          // convert day of year to radians
        const double MIN2SEC = 60.0;          // 60 seconds in a minute - conversion minutes to seconds
        const double HR2MIN = 60.0;           // 60 minutes in an hour - conversion hours to minutes
        const double SEC2HR = 1.0 / (HR2MIN * MIN2SEC);  // conversion seconds to hours
        const double DAYhrs = 24.0;           // hours in a day
        const double DAYmins = DAYhrs * HR2MIN;           // minutes in a day
        const double DAYsecs = DAYmins * MIN2SEC;         // seconds in a day
        const double PA2HPA = 1.0 / 100.0;        // conversion of air pressure pascals to hectopascals
        const double MJ2J = 1000000.0;            // convert MJ to J
        const double J2MJ = 1.0 / MJ2J;            // convert J to MJ
        const int NUM_PHANTOM_NODES = 5;
        const double CONSTANT_TEMPdepth = 10; 
        const double soilRoughnessHeight = 57;
        const double tempStepSec = 1440.0 * 60.0;
        double instrumentHeight = 1.2;
        double AltitudeMetres = 18.0; 
        double pom = 1.3;
        double ps = 2.63; 
        const double BoundaryLayerConductanceIterations = 1; 
        double _boundaryLayerConductance; 
        const int ITERATIONSperDAY = 48;     // number of iterations in a day
        private double volSpecHeatClay = 2.39e6;  // [Joules*m-3*K-1]
        private double volSpecHeatOM = 5e6;       // [Joules*m-3*K-1]
        private double volSpecHeatWater = 4.18e6; // [Joules*m-3*K-1]
        #endregion

        #region States
        int numLayers;
        int numNodes;
        double albedo;
        double canopyHeight;
        double[] thickness;
        double[] bulkDensity;
        double[] soilWater;
        double[] clay;
        double[] depth;
        double latitude; 
        private double gDt = 0.0;             // Internal timestep in seconds.
        double airPressure;

        private double[] thermCondPar1;       // soil solids thermal conductivity parameter
        private double[] thermCondPar2;       // soil solids thermal conductivity parameter
        private double[] thermCondPar3;       // soil solids thermal conductivity parameter
        private double[] thermCondPar4;       // soil solids thermal conductivity parameter

        double maxTempYesterday;
        double minTempYesterday;
        #endregion

        #region Outputs
        public double[] maxSoilTemp;
        public double[] minSoilTemp;
        public double[] aveSoilTemp;
        public double[] volSpecHeatSoil;
        public double[] soilTemp;
        public double[] morningSoilTemp;
        public double[] tempNew;
        public double[] thermalConductivity;
        public double[] heatStorage;
        public double[] thermalConductance;
        #endregion

        #region Constructor
        public SoilTempCampbellTeiki()
        {

        }
        #endregion


        #region Standalone
        static void Main(string[] args)
        {
            //Weather arrays
            List<string> DATE = new List<string>();
            List<double> T2M = new List<double>();
            List<double> TMIN = new List<double>();
            List<double> TMAX = new List<double>();
            List<double> RAIN = new List<double>();
            List<double> SRAD = new List<double>();
            List<double> DAYLD = new List<double>();
            List<double> SUNUP = new List<double>();
            List<double> SUNDN = new List<double>();
            List<double> EOAD = new List<double>();
            List<double> ESP = new List<double>();
            List<double> LE = new List<double>();
            List<double> G = new List<double>();
            List<double> SNOW = new List<double>();

            // Soil arrays
            List<string> SOILID = new List<string>();
            List<string> SOILNAME = new List<string>();
            List<double> SLID = new List<double>();
            List<double> SLLT = new List<double>();
            List<double> SLLB = new List<double>();
            List<double> THICK = new List<double>();
            List<double> SLBDM = new List<double>();
            List<double> SLOC = new List<double>();
            List<double> SLSAT = new List<double>();
            List<double> SLDUL = new List<double>();
            List<double> SLLL = new List<double>();
            List<double> SLCLY = new List<double>();
            List<double> SVSE = new List<double>();

            // Soil metadata
            string soilID = "SICL";
            double SALB = 0.11;
            int numberLayer = 10;
            double soilDepth = 210 * 0.01;
            double bd = 1.36;

            // Site metadata
            string WST_ID = "USGA";
            string SITE_NAME = "Gainesville";
            string FL_LOC_1 = "USA";
            double XLAT = 29.652;
            double XLONG = -82.325;
            double TAMP = 21.8;
            double TAV = 15.8;

            // Treatment
            int LAI = 2;
            double AWC = 0.50;
            int BIOMAS = 1800;

            using (var reader = new StreamReader(@"C:\Users\raihauti\Documents\AMEI\CampbellSoilT_Python\APSIM inputs\DailyValues.WTH"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var values = line.Trim().Split('\t');
                    if (values[0] == "DATE")
                        continue;

                    DATE.Add(values[0]);
                    T2M.Add(double.Parse(values[1]));
                    TMIN.Add(double.Parse(values[2]));
                    TMAX.Add(double.Parse(values[3]));
                    RAIN.Add(double.Parse(values[4]));
                    SRAD.Add(double.Parse(values[5]));
                    DAYLD.Add(double.Parse(values[6]));
                    SUNUP.Add(double.Parse(values[7]));
                    SUNDN.Add(double.Parse(values[8]));
                    EOAD.Add(double.Parse(values[9]));
                    ESP.Add(double.Parse(values[10]));
                    LE.Add(double.Parse(values[11]));
                    G.Add(double.Parse(values[12]));
                    SNOW.Add(double.Parse(values[13]));
                }
            }

            using (var reader = new StreamReader(@"C:\Users\raihauti\Documents\AMEI\CampbellSoilT_Python\APSIM inputs\SoilLayers.txt"))
            {
                for (int i = 0; i < 3; i++)
                    reader.ReadLine();

                for (int i = 0; i < 10; i++)
                {
                    var values = reader.ReadLine().Trim().Split('\t');
                    SOILID.Add(values[0]);
                    SOILNAME.Add(values[1]);
                    SLID.Add(double.Parse(values[2]));
                    SLLT.Add(double.Parse(values[3]));
                    SLLB.Add(double.Parse(values[4]) * 0.01);
                    THICK.Add(double.Parse(values[5]) * 10);
                    SLBDM.Add(double.Parse(values[6]));
                    SLOC.Add(double.Parse(values[7]));
                    SLSAT.Add(double.Parse(values[8]));
                    SLDUL.Add(double.Parse(values[9]));
                    SLLL.Add(double.Parse(values[10]));
                    SLCLY.Add(double.Parse(values[11]));
                    SVSE.Add(double.Parse(values[12]) * 1e6);
                }
            }

            List<double> soilW = new List<double>();
            List<int> year = new List<int>();
            List<int> doy = new List<int>();

            for (int i = 0; i < numberLayer; i++)
            {
                soilW.Add(SLLL[i] + AWC * (SLDUL[i] - SLLL[i]));
            }

            for (int i = 0; i < DATE.Count; i++)
            {
                year.Add(int.Parse(DATE[i].Substring(0, 4)));
                doy.Add(int.Parse(DATE[i].Substring(4, 3)));
            }
            double canopyHeight = 0.0;

            using (var writer = new StreamWriter("C:/Users/raihauti/Documents/CampbellOutputs.txt"))
            {
                writer.WriteLine("Date\tSLLT\tSLLB\tTSLD\tTSLX\tTSLN");
                SoilTempCampbellTeiki class1 = new SoilTempCampbellTeiki();

                class1.init(numberLayer, THICK.ToArray(), SLBDM.ToArray(), TMAX[0], TMIN[0], SLCLY.ToArray(), 
                    soilW.ToArray(), SLLB.ToArray(), TAV, TAMP, doy[0], canopyHeight, SALB, SRAD[0], XLAT);
                for (int i = 0; i < DATE.Count; i++)
                {

                    // Créer une date à partir de l'année et du jour julien
                    DateTime date = new DateTime(year[i], 1, 1).AddDays(doy[i] - 1);

                    // Formater la date en "yyyy-MM-dd"
                    string dateFormatted = date.ToString("yyyy-MM-dd");

                    class1.doProcess(doy[i], SRAD[i], TMIN[i], TMAX[i], ESP[i], EOAD[i], ESP[i], soilW.ToArray());

                    writer.WriteLine($"{dateFormatted}\t0\t0\t{Math.Round(class1.soilTemp[1], 6)}\t" +
                        $"{Math.Round(class1.maxSoilTemp[1], 6)}\t{Math.Round(class1.minSoilTemp[1], 6)}");

                    for (int j = 0; j < numberLayer; j++)
                    {
                        writer.WriteLine($"{dateFormatted}\t{(int)SLLT[j]}\t{(int)(SLLB[j] * 100)}\t" +
                            $"{Math.Round(class1.soilTemp[j+2], 6)}\t{Math.Round(class1.maxSoilTemp[j+2], 6)}\t" +
                            $"{Math.Round(class1.minSoilTemp[j+2], 6)}");
                    }
                }
            }
        }

    #endregion


    #region InitVariables
    public void init(int nbLayers, double[] thick, double[] bd, double tmax, double tmin, double[] cla, double[] sw, double[] dpth, 
            double tav, double tamp, double doy, double canopHeight, double SALB, double rad, double XLAT)
        {
            albedo = SALB;
            canopyHeight = Math.Max(canopHeight, soilRoughnessHeight) * MM2M;
            airPressure = 101325.0 * Math.Pow((1.0 - 2.25577 * 0.00001 * AltitudeMetres), 5.25588) * 0.01;
            numLayers = nbLayers;
            numNodes = nbLayers + NUM_PHANTOM_NODES; 
            thickness = new double[numLayers + 1 + NUM_PHANTOM_NODES];
            Array.Copy(thick, thickness, thick.Length);
            double sumThickness = 0;
            for (int i = 1; i <= numLayers; i++) sumThickness += thickness[i];
            double BelowProfileDepth = Math.Max(CONSTANT_TEMPdepth * M2MM - sumThickness, 1.0 * M2MM);    // Metres. Depth added below profile to take last node to constant temperature zone

            double thicknessForPhantomNodes = BelowProfileDepth * 2.0 / NUM_PHANTOM_NODES; // double depth so that bottom node at mid-point is at the ConstantTempDepth
            int firstPhantomNode = numLayers;
            for (int i = firstPhantomNode; i < firstPhantomNode + NUM_PHANTOM_NODES; i++)
                thickness[i] = thicknessForPhantomNodes;
            depth = new double[numNodes + 1 + 1];

            Array.Copy(dpth, depth, Math.Min(numNodes + 1 + 1, dpth.Length));      // Z_zb dimensioned for nodes 0 to Nz + 1 extra for zone below bottom layer
            depth[AIRnode] = 0.0D;
            depth[SURFACEnode] = 0.0D;
            depth[TOPSOILnode] = 0.5 * thickness[1] * MM2M;

            for (int node = TOPSOILnode; node <= numNodes; node++)
            {
                sumThickness = 0;
                for (int i = 1; i <= node - 1; i++) sumThickness += thickness[i];
                depth[node + 1] = (sumThickness + 0.5 * thickness[node]) * MM2M;
            }

            // BD
            bulkDensity = new double[numLayers + 1 + NUM_PHANTOM_NODES];
            Array.Copy(bd, bulkDensity, Math.Min(numLayers + 1 + NUM_PHANTOM_NODES, bd.Length));     // Rhob dimensioned for layers 1 to gNumlayers + extra for zone below bottom layer
            bulkDensity[numNodes] = bulkDensity[numLayers];
            for (int layer = numLayers + 1; layer <= numLayers + NUM_PHANTOM_NODES; layer++)
                bulkDensity[layer] = bulkDensity[numLayers];

            // SW
            soilWater = new double[numLayers + 1 + NUM_PHANTOM_NODES];
            Array.Copy(sw, soilWater, Math.Min(numLayers + 1 + NUM_PHANTOM_NODES, sw.Length));     // SW dimensioned for layers 1 to gNumlayers + extra for zone below bottom layer
            for (int layer = numLayers + 1; layer <= numLayers + NUM_PHANTOM_NODES; layer++)
                soilWater[layer] = soilWater[numLayers];

            // Clay
            clay = new double[numLayers + 1 + NUM_PHANTOM_NODES];
            for (int layer = 1; layer <= numLayers; layer++)
                clay[layer] = cla[layer - 1];
            for (int layer = numLayers + 1; layer <= numLayers + NUM_PHANTOM_NODES; layer++)
                clay[layer] = clay[numLayers];

            maxSoilTemp = new double[numLayers + 1 + NUM_PHANTOM_NODES];
            minSoilTemp = new double[numLayers + 1 + NUM_PHANTOM_NODES];
            aveSoilTemp = new double[numLayers + 1 + NUM_PHANTOM_NODES];
            volSpecHeatSoil = new double[numNodes + 1];
            soilTemp = new double[numNodes + 1 + 1];
            morningSoilTemp = new double[numNodes + 1 + 1];
            tempNew = new double[numNodes + 1 + 1];
            thermalConductivity = new double[numNodes + 1];
            heatStorage = new double[numNodes + 1];
            thermalConductance = new double[numNodes + 1 + 1];

            doThermalConductivityCoeffs(nbLayers);
            latitude = XLAT;
            CalcSoilTemp(ref soilTemp, tav, tamp, doy, latitude);     // FIXME - returns as zero here because initialisation is not complete.
            soilTemp.CopyTo(tempNew, 0);

            double[] InitialValues = new double[numLayers];
            Array.ConstrainedCopy(soilTemp, TOPSOILnode, InitialValues, 0, numLayers);

            soilTemp[AIRnode] = (tmax + tmin) * 0.5;
            double ave_temp = (tmax + tmin) * 0.5;
            double surfaceT = (1.0 - albedo) * (ave_temp + (tmax - ave_temp) * Math.Sqrt(Math.Max(rad, 0.1) * 23.8846 / 800.0)) + albedo * ave_temp;
            soilTemp[SURFACEnode] = surfaceT;

            for (int i = numNodes + 1; i < soilTemp.Length; i++)
                soilTemp[i] = tav;

            soilTemp.CopyTo(tempNew, 0);

            minTempYesterday = tmin;
            maxTempYesterday = tmax;
        }

        private void doThermalConductivityCoeffs(double nbLayers)
        {
            thermCondPar1 = new double[numNodes + 1];    // C1 dimensioned for nodes 0 to Nz
            thermCondPar2 = new double[numNodes + 1]; // C2 dimensioned for nodes 0 to Nz
            thermCondPar3 = new double[numNodes + 1];// C3 dimensioned for nodes 0 to Nz
            thermCondPar4 = new double[numNodes + 1]; // C4 dimensioned for nodes 0 to Nz

            for (int layer = 1; layer <= nbLayers + 1; layer++)
            {
                int element = layer;
                thermCondPar1[element] = 0.65 - 0.78 * bulkDensity[layer] + 0.6 * Math.Pow(bulkDensity[layer], 2);      // A approximation to e
                                                                                                                        // The coefficient C2 (B in Campbell 4.25) can be evaluated from data and for mineral soils is approximated by -
                thermCondPar2[element] = 1.06 * bulkDensity[layer];                              // * SW[i]; //B for mineral soil - assume (is there missing text here??)
                                                                                                 // The coefficient C3 (C in Caqmpbell 4.28) determines the water content where thermal conductivity begins to
                                                                                                 // increase rapidly and is highly correlated with clayy content. The following correlation appears to fit data well.
                thermCondPar3[element] = 1.0D + Divide(2.6, Math.Sqrt(clay[layer]), 0);             // C is the water content where co (is there missing text here??)
                                                                                                    // Coefficient C4 (D in Campbell 4.22) is the thermal conductivity when volumetric water content=0.
                                                                                                    // For mineral soils with a particle density of 2.65 Mg/m3 the equation becomes the following.
                thermCondPar4[element] = 0.03 + 0.1 * Math.Pow(bulkDensity[layer], 2);           // D assume mineral soil particle d (is there missing text here??)
            }
        }


        private void CalcSoilTemp(ref double[] soilTempIO, double ttav, double tamp, double doy, double latitude)
        {
            double[] cumulativeDepth = new double[thickness.Length];
            if (thickness.Length > 0)
            {
                cumulativeDepth[0] = thickness[0];
                for (int Layer = 1; Layer != thickness.Length; Layer++)
                    cumulativeDepth[Layer] = thickness[Layer] + cumulativeDepth[Layer - 1];
            }

            double w = 2 * Math.PI / (365.25 * 24 * 3600);
            double dh = 0.6;   // this needs to be in mm a default value for a loam at field capacity - consider makeing this settable
            double zd = Math.Sqrt(2 * dh / w);
            double offset = 0.25;  // moves the "0" and rise in the sin to the spring equinox for southern latitudes 
            if (latitude > 0.0)  // to cope with the northern summer
                offset = -0.25;

            double[] soilTemp = new double[numNodes + 1 + 1];
            for (int nodes = 1; nodes <= numNodes; nodes++)
            {
                soilTemp[nodes] = ttav + tamp * Math.Exp(-1 * cumulativeDepth[nodes] / zd) *
                                                              Math.Sin((doy / 365.0 + offset) * 2.0 * Math.PI - cumulativeDepth[nodes] / zd);
            }

            Array.ConstrainedCopy(soilTemp, 0, soilTempIO, SURFACEnode, numNodes);
        }
        #endregion

        #region Loop
        public void doProcess(double doy, double rad, double tmin, double tmax, double potE, double potET, double actE, double[] sw)
        {
            double cva = 0.0;
            double cloudFr = 0.0;
            double[] solarRadn = new double[49];   // Total incoming short wave solar radiation per timestep
            DoNetRadiation(ref solarRadn, ref cloudFr, ref cva, ITERATIONSperDAY, doy, rad, tmin);

            // zero the temperature profiles
            Zero(minSoilTemp);
            Zero(maxSoilTemp);
            Zero(aveSoilTemp);
            _boundaryLayerConductance = 0.0;

            // calc dt
            gDt = Math.Round(tempStepSec / System.Convert.ToDouble(ITERATIONSperDAY));

            // These two call used to be inside the timestep loop. I've taken them outside,
            // as the results do not appear to vary over the course of the day.
            // The results would vary if soil water content were to vary, so if future versions
            // to more communication within subday time steps, these may need to be moved
            // back into the loop. EZJ March 2014
            soilWater = new double[numLayers + 1 + NUM_PHANTOM_NODES];
            Array.Copy(sw, soilWater, Math.Min(numLayers + 1 + NUM_PHANTOM_NODES, sw.Length));     // SW dimensioned for layers 1 to gNumlayers + extra for zone below bottom layer
            for (int layer = numLayers + 1; layer <= numLayers + NUM_PHANTOM_NODES; layer++)
                soilWater[layer] = soilWater[numLayers];
            doVolumetricSpecificHeat(soilWater);      // RETURNS volSpecHeatSoil() (volumetric heat capacity of nodes)
            doThermConductivityCampbell(soilWater);     // RETURNS gThermConductivity_zb()

            for (int timeStepIteration = 1; timeStepIteration <= ITERATIONSperDAY; timeStepIteration++)
            {
                double timeOfDaySecs = gDt * System.Convert.ToDouble(timeStepIteration);
                double tMean;
                if (tempStepSec < DAYsecs)
                    tMean = 0.5 * (tmax + tmin);
                else
                    tMean = InterpTemp(timeOfDaySecs * SEC2HR, tmax, tmin);
                tempNew[AIRnode] = tMean;

                double netRadiation = RadnNetInterpolate(solarRadn[timeStepIteration], cloudFr, cva, potE, potET, tMean);

                thermalConductivity[AIRnode] = boundaryLayerConductanceF(ref tempNew, tMean, potE, potET);
                for (int iteration = 1; iteration <= BoundaryLayerConductanceIterations; iteration++)
                {
                    doThomas(ref tempNew, netRadiation, actE);        // RETURNS TNew_zb()
                    thermalConductivity[AIRnode] = boundaryLayerConductanceF(ref tempNew, tMean, potE, potET);
                }

                // Now start again with final atmosphere boundary layer conductance
                doThomas(ref tempNew, netRadiation, actE);        // RETURNS gTNew_zb()
                doUpdate(ITERATIONSperDAY, timeOfDaySecs);

                double precision = Math.Min(timeOfDaySecs, 5.0 * HR2MIN * MIN2SEC) * 0.0001;
                if (Math.Abs(timeOfDaySecs - 5.0 * HR2MIN * MIN2SEC) <= precision)
                    soilTemp.CopyTo(morningSoilTemp, 0);

                minTempYesterday = tmin;
                maxTempYesterday = tmax;
            }
        }

        #endregion

        #region Processes
        private void DoNetRadiation(ref double[] solarRadn, ref double cloudFr, ref double cva, int ITERATIONSperDAY, double doy, double rad, double tmin)
        {
            double TSTEPS2RAD = Divide(DEG2RAD * 360.0, Convert.ToDouble(ITERATIONSperDAY), 0);          // convert timestep of day to radians
            const double SOLARconst = 1360.0;     // W/M^2
            double solarDeclination = 0.3985 * Math.Sin(4.869 + doy * DOY2RAD + 0.03345 * Math.Sin(6.224 + doy * DOY2RAD));
            double cD = Math.Sqrt(1.0 - solarDeclination * solarDeclination);
            double[] m1 = new double[ITERATIONSperDAY + 1];
            double m1Tot = 0.0;
            for (int timestepNumber = 1; timestepNumber <= ITERATIONSperDAY; timestepNumber++)
            {
                m1[timestepNumber] = (solarDeclination * Math.Sin(latitude * DEG2RAD) + cD * Math.Cos(latitude * DEG2RAD) *
                    Math.Cos(TSTEPS2RAD * (System.Convert.ToDouble(timestepNumber) - System.Convert.ToDouble(ITERATIONSperDAY) / 2.0))) * 
                    24.0 / System.Convert.ToDouble(ITERATIONSperDAY);
                if (m1[timestepNumber] > 0.0)
                    m1Tot += m1[timestepNumber];
                else
                    m1[timestepNumber] = 0.0;
            }

            const double W2MJ = HR2MIN * MIN2SEC * J2MJ;      // convert W to MJ
            double psr = m1Tot * SOLARconst * W2MJ;   // potential solar radiation for the day (MJ/m^2)
            double fr = Divide(Math.Max(rad, 0.1), psr, 0);               // ratio of potential to measured daily solar radiation (0-1)
            cloudFr = 2.33 - 3.33 * fr;    // fractional cloud cover (0-1)
            if (cloudFr < 0.0) cloudFr = 0.0;
            else if (cloudFr > 1.0) cloudFr = 1.0;

            for (int timestepNumber = 1; timestepNumber <= ITERATIONSperDAY; timestepNumber++)
                solarRadn[timestepNumber] = Math.Max(rad, 0.1) * Divide(m1[timestepNumber], m1Tot, 0);

            // cva is vapour concentration of the air (g/m^3)
            cva = Math.Exp(31.3716 - 6014.79 / kelvinT(tmin) - 0.00792495 * kelvinT(tmin)) / kelvinT(tmin);
        }

        /// <summary>
        /// Calculate the volumetric specific heat (volumetric heat capicity Cv) of the soil layer
        /// to Campbell, G.S. (1985) "Soil physics with BASIC: Transport
        /// models for soil-plant systems" (Amsterdam, Elsevier)
        /// RETURNS volSpecHeatSoil()  [Joules*m-3*K-1]
        /// </summary>
        private void doVolumetricSpecificHeat(double[] soilW)
        {
            const double SPECIFICbd = 2.65;   // (g/cc) specific bulk density
            double[] volSpecHeatSoil = new double[numLayers + 1];

            for (int layer = 1; layer <= numLayers; layer++)
            {
                double solidity = bulkDensity[layer] / SPECIFICbd;

                // the Campbell version
                // heatStore[i] = (vol_spec_heat_clay * (1-porosity) + vol_spec_heat_water * SWg[i]) * (zb_z[i+1]-zb_z[i-1])/(2*real(dt));
                volSpecHeatSoil[layer] = volSpecHeatClay * solidity
                                       + volSpecHeatWater * soilWater[layer];
            }
            // mapLayer2Node(volSpecHeatSoil, gVolSpecHeatSoil)
            volSpecHeatSoil.CopyTo(this.volSpecHeatSoil, 1);     // map volumetric heat capicity (Cv) from layers to nodes (node 2 in centre of layer 1)
            this.volSpecHeatSoil[1] = volSpecHeatSoil[1];        // assume surface node Cv is same as top layer Cv
        }

        /// <summary>
        /// Calculate the thermal conductivity of the soil layer.
        /// </summary>
        private void doThermConductivityCampbell(double[] soilW)
        {
            double temp = 0;

            // no change needed from Campbell to my version
            // Do thermal conductivity for soil layers
            double[] thermCondLayers = new double[numNodes + 1];
            for (int layer = 1; layer <= numNodes; layer++)
            {
                temp = Math.Pow((thermCondPar3[layer] * soilWater[layer]), 4) * (-1);
                thermCondLayers[layer] = thermCondPar1[layer] + (thermCondPar2[layer] * soilWater[layer])
                                       - (thermCondPar1[layer] - thermCondPar4[layer]) * Math.Exp(temp);  // Eqn 4.20 Campbell.
            }

            // now get weighted average for soil elements between the nodes. i.e. map layers to nodes
            mapLayer2Node(thermCondLayers, ref thermalConductivity);
        }

        /// <summary>
        /// Calculate the net radiation at the soil surface.
        /// </summary>
        /// <param name="solarRadn"></param>
        /// <param name="cloudFr"></param>
        /// <param name="cva"></param>
        /// <returns>Net radiation (SW and LW) for timestep (MJ)</returns>
        /// <remarks></remarks>
        private double RadnNetInterpolate(double solarRadn, double cloudFr, double cva, double potE, double potET, double tMean)
        {
            const double EMISSIVITYsurface = 0.96;    // Campbell Eqn. 12.1
            double w2MJ = gDt * J2MJ;      // convert W to MJ

            // Eqns 12.2 & 12.3
            double emissivityAtmos = (1 - 0.84 * cloudFr) * 0.58 * Math.Pow(cva, (1.0 / 7.0)) + 0.84 * cloudFr;
            // To calculate the longwave radiation out, we need to account for canopy and residue cover
            // Calculate a penetration constant. Here we estimate this using the Soilwat algorithm for calculating EOS from EO and the cover effects.
            double PenetrationConstant = Divide(Math.Max(0.1, potE),Math.Max(0.1, potET), 0);

            // Eqn 12.1 modified by cover.
            double lwRinSoil = longWaveRadn(emissivityAtmos, tMean) * PenetrationConstant * w2MJ;

            double lwRoutSoil = longWaveRadn(EMISSIVITYsurface, soilTemp[SURFACEnode]) * PenetrationConstant * w2MJ; // _
                                                                                                                     // + longWaveRadn(emissivityAtmos, (gT_zb(SURFACEnode) + gAirT) * 0.5) * (1.0 - PenetrationConstant) * w2MJ

            // Ignore (mulch/canopy) temperature and heat balance
            double lwRnetSoil = lwRinSoil - lwRoutSoil;

            double swRin = solarRadn;
            double swRout = albedo * solarRadn;
            // Dim swRout As Double = (salb + (1.0 - salb) * (1.0 - sunAngleAdjust())) * solarRadn   'FIXME temp test
            double swRnetSoil = (swRin - swRout) * PenetrationConstant;
            return swRnetSoil + lwRnetSoil;
        }


        private double longWaveRadn(double emissivity, double tDegC)
        {
            return STEFAN_BOLTZMANNconst * emissivity * Math.Pow(kelvinT(tDegC), 4);
        }
        /// <summary>
        ///     Calculate atmospheric boundary layer conductance.
        ///     From Program 12.2, p140, Campbell, Soil Physics with Basic.
        /// </summary>
        /// <returns>thermal conductivity of surface layer (W/m2/K)</returns>
        /// <remarks> During first stage drying, evaporation prevents the surface from becoming hot,
        /// so stability corrections are small. Once the surface dries and becomes hot, boundary layer
        /// resistance is relatively unimportant in determining evaporation rate.
        /// A dry soil surface reaches temperatures well above air temperatures during the day, and can be well
        /// below air temperature on a clear night. Thermal stratification on a clear night can be strong enough
        /// to reduce sensible heat exchange between the soil surface and the air to almost nothing. If stability
        /// corrections are not made, soil temperature profiles can have large errors.
        /// </remarks>
        private double boundaryLayerConductanceF(ref double[] TNew_zb, double tMean, double potE, double potET)
        {
            const double VONK = 0.41;                 // VK; von Karman's constant
            const double GRAVITATIONALconst = 9.8;    // GR; gravitational constant (m/s/s)
            const double CAPP = 1010.0;               // (J/kg/K) Specific heat of air at constant pressure
            const double EMISSIVITYsurface = 0.98;
            double SpecificHeatAir = CAPP * RhoA(tMean, airPressure); // CH; volumetric specific heat of air (J/m3/K) (1200 at 200C at sea level)
                                                                      // canopy_height, instrum_ht (Z) = 1.2m, AirPressure = 1010
                                                                      // gTNew_zb = TN; gAirT = TA;

            // Zero plane displacement and roughness parameters depend on the height, density and shape of
            // surface roughness elements. For typical crop surfaces, the following empirical correlations have
            // been obtained. (Extract from Campbell p138.). Canopy height is the height of the roughness elements.
            double RoughnessFacMomentum = 0.13 * canopyHeight;    // ZM; surface roughness factor for momentum
            double RoughnessFacHeat = 0.2 * RoughnessFacMomentum;  // ZH; surface roughness factor for heat
            double d = 0.77 * canopyHeight;                       // D; zero plane displacement for the surface

            double SurfaceTemperature = TNew_zb[SURFACEnode];    // surface temperature (oC)

            // To calculate the radiative conductance term of the boundary layer conductance, we need to account for canopy and residue cover
            // Calculate a diffuce penetration constant (KL Bristow, 1988. Aust. J. Soil Res, 26, 269-80. The Role of Mulch and its Architecture
            // in modifying soil temperature). Here we estimate this using the Soilwat algorithm for calculating EOS from EO and the cover effects,
            // assuming the cover effects on EO are similar to Bristow's diffuse penetration constant - 0.26 for horizontal mulch treatment and 0.44
            // for vertical mulch treatment.
            double PenetrationConstant = Math.Max(0.1, potE) / Math.Max(0.1, potET);

            // Campbell, p136, indicates the radiative conductance is added to the boundary layer conductance to form a combined conductance for
            // heat transfer in the atmospheric boundary layer. Eqn 12.9 modified for residue and plant canopy cover
            double radiativeConductance = 4.0 * STEFAN_BOLTZMANNconst * EMISSIVITYsurface * PenetrationConstant
                                               * Math.Pow(kelvinT(tMean), 3);    // Campbell uses air temperature in leiu of surface temperature

            // Zero iteration variables
            double FrictionVelocity = 0.0;        // FV; UStar
            double BoundaryLayerCond = 0.0;       // KH; sensible heat flux in the boundary layer;(OUTPUT) thermal conductivity  (W/m2/K)
            double StabilityParam = 0.0;          // SP; Index of the relative importance of thermal and mechanical turbulence in boundary layer transport.
            double StabilityCorMomentum = 0.0;    // PM; stability correction for momentum
            double StabilityCorHeat = 0.0;        // PH; stability correction for heat
            double HeatFluxDensity = 0.0;         // H; sensible heat flux in the boundary layer

            // Since the boundary layer conductance is a function of the heat flux density, an iterative metnod must be used to find the boundary layer conductance.
            for (int iteration = 1; iteration <= 3; iteration++)
            {
                // Heat and water vapour are transported by eddies in the turbulent atmosphere above the crop.
                // Boundary layer conductance would therefore be expected to vary depending on the wind speed and level
                // of turbulence above the crop. The level of turbulence, in turn, is determined by the roughness of the surface,
                // the distance from the surface and the thermal stratification of the boundary layer.
                // Eqn 12.11 Campbell
                FrictionVelocity = Divide(windSpeed * VONK, Math.Log(Divide(instrumentHeight - d + RoughnessFacMomentum,
                                                                                      RoughnessFacMomentum,
                                                                                      0)) + StabilityCorMomentum,
                                                        0);
                // Eqn 12.10 Campbell
                BoundaryLayerCond = Divide(SpecificHeatAir * VONK * FrictionVelocity,
                                                         Math.Log(Divide(instrumentHeight - d + RoughnessFacHeat,
                                                                                       RoughnessFacHeat, 0)) + StabilityCorHeat,
                                                         0);

                BoundaryLayerCond += radiativeConductance; // * (1.0 - sunAngleAdjust())

                HeatFluxDensity = BoundaryLayerCond * (SurfaceTemperature - tMean);
                // Eqn 12.14
                StabilityParam = Divide(-VONK * instrumentHeight * GRAVITATIONALconst * HeatFluxDensity,
                                                      SpecificHeatAir * kelvinT(tMean) * Math.Pow(FrictionVelocity, 3.0)
                                                      , 0);

                // The stability correction parameters correct the boundary layer conductance for the effects
                // of buoyancy in the atmosphere. When the air near the surface is hotter than the air above,
                // the atmosphere becomes unstable, and mixing at a given wind speed is greater than would occur
                // in a neutral atmosphere. If the air near the surface is colder than the air above, the atmosphere
                // is unstable and mixing is supressed.

                if (StabilityParam > 0.0)
                {
                    // Stable conditions, when surface temperature is lower than air temperature, the sensible heat flux
                    // in the boundary layer is negative and stability parameter is positive.
                    // Eqn 12.15
                    StabilityCorHeat = 4.7 * StabilityParam;
                    StabilityCorMomentum = StabilityCorHeat;
                }
                else
                {
                    // Unstable conditions, when surface temperature is higher than air temperature, sensible heat flux in the
                    // boundary layer is positive and stability parameter is negative.
                    StabilityCorHeat = -2.0 * Math.Log((1.0 + Math.Sqrt(1.0 - 16.0 * StabilityParam)) / 2.0);    // Eqn 12.16
                    StabilityCorMomentum = 0.6 * StabilityCorHeat;                // Eqn 12.17
                }
            }
            return BoundaryLayerCond;   // thermal conductivity  (W/m2/K)
        }

        /// <summary>
        ///     calculate the density of air (kg/m3) at a given temperature and pressure
        /// </summary>
        /// <param name="temperature">temperature (oC)</param>
        /// <param name="AirPressure">air pressure (hPa)</param>
        /// <returns>density of air</returns>
        /// <remarks></remarks>
        private double RhoA(double temperature, double AirPressure)
        {
            const double MWair = 0.02897;     // molecular weight air (kg/mol)
            const double RGAS = 8.3143;       // universal gas constant (J/mol/K)
            const double HPA2PA = 100.0;      // hectoPascals to Pascals

            return Divide(MWair * AirPressure * HPA2PA
                         , kelvinT(temperature) * RGAS
                         , 0.0);
        }

        /// <summary>
        /// Numerical solution of the differential equations. Solves the
        /// tri_diagonal matrix using the Thomas algorithm, Thomas, L.H. (1946)
        /// "Elliptic problems in linear difference equations over a network"
        /// Watson Sci Comput. Lab. Report., (Columbia University, New York)"
        /// RETURNS newTemps()
        /// </summary>
        /// <remarks>John Hargreaves' version from Campbell Program 4.1</remarks>
        private void doThomas(ref double[] newTemps, double netRadiation, double actE)
        {
            double[] a = new double[numNodes + 1 + 1];    // A; thermal conductance at next node (W/m/K)
            double[] b = new double[numNodes + 1];        // B; heat storage at node (W/K)
            double[] c = new double[numNodes + 1];        // C; thermal conductance at node (W/m/K)
            double[] d = new double[numNodes + 1];        // D; heat flux at node (w/m) and then temperature
                                                          // nu = F; Nz = M; 1-nu = G; T_zb = T; newTemps = TN;

            thermalConductance[AIRnode] = thermalConductivity[AIRnode];
            // The first node gZ_zb(1) is at the soil surface (Z = 0)
            for (int node = SURFACEnode; node <= numNodes; node++)
            {
                double VolSoilAtNode = 0.5 * (depth[node + 1] - depth[node - 1]);   // Volume of soil around node (m^3), assuming area is 1 m^2
                heatStorage[node] = Divide(volSpecHeatSoil[node] * VolSoilAtNode, gDt, 0);       // Joules/s/K or W/K
                                                                                                               // rate of heat
                                                                                                               // convert to thermal conductance
                double elementLength = depth[node + 1] - depth[node];             // (m)
                thermalConductance[node] = Divide(thermalConductivity[node], elementLength, 0);  // (W/m/K)
            }

            // Debug test: multiplyArray(gThermalConductance_zb, 2.0)

            // John's version
            double g = 1 - nu;
            for (int node = SURFACEnode; node <= numNodes; node++)
            {
                c[node] = (-nu) * thermalConductance[node];   //
                a[node + 1] = c[node];             // Eqn 4.13
                b[node] = nu * (thermalConductance[node] + thermalConductance[node - 1]) + heatStorage[node];    // Eqn 4.12
                                                                                                                 // Eqn 4.14
                d[node] = g * thermalConductance[node - 1] * soilTemp[node - 1]
                        + (heatStorage[node] - g * (thermalConductance[node] + thermalConductance[node - 1])) * soilTemp[node]
                        + g * thermalConductance[node] * soilTemp[node + 1];
            }
            a[SURFACEnode] = 0.0D;

            // The boundary condition at the soil surface is more complex since convection and radiation may be important.
            // When radiative and latent heat transfer are unimportant, then D(1) = D(1) + nu*K(0)*TN(0).
            // d(SURFACEnode) += nu * thermalConductance(AIRnode) * newTemps(AIRnode)       ' Eqn. 4.16
            double sensibleHeatFlux = nu * thermalConductance[AIRnode] * newTemps[AIRnode];       // Eqn. 4.16

            // When significant radiative and/or latent heat transfer occur they are added as heat sources at node 1
            // to give D(1) = D(1) = + nu*K(0)*TN(0) - Rn + LE, where Rn is net radiation at soil surface and LE is the
            // latent heat flux. Eqn. 4.17

            double RadnNet = 0.0;     // (W/m)
            RadnNet = Divide(netRadiation * MJ2J, gDt, 0);       // net Radiation Rn heat flux (J/m2/s or W/m2).

            double LatentHeatFlux = Divide(actE * LAMBDA, tempStepSec, 0);      // Es*L = latent heat flux LE (W/m)
            double SoilSurfaceHeatFlux = sensibleHeatFlux + RadnNet - LatentHeatFlux;  // from Rn = G + H + LE (W/m)
            d[SURFACEnode] += SoilSurfaceHeatFlux;        // FIXME JNGH testing alternative net radn

            // last line is unfulfilled soil water evaporation
            // The boundary condition at the bottom of the soil column is usually specified as remaining at some constant,
            // measured temperature, TN(M+1). The last value for D is therefore -

            d[numNodes] += nu * thermalConductance[numNodes] * newTemps[numNodes + 1];
            // For a no-flux condition, K(M) = 0, so nothing is added.

            // The Thomas algorithm
            // Calculate coeffs A, B, C, D for intermediate nodes
            for (int node = SURFACEnode; node <= numNodes - 1; node++)
            {
                c[node] = Divide(c[node], b[node], 0);
                d[node] = Divide(d[node], b[node], 0);
                b[node + 1] -= a[node + 1] * c[node];
                d[node + 1] -= a[node + 1] * d[node];
            }
            newTemps[numNodes] = Divide(d[numNodes], b[numNodes], 0);  // do temperature at bottom node

            // Do temperatures at intermediate nodes from second bottom to top in soil profile
            for (int node = numNodes - 1; node >= SURFACEnode; node += -1)
            {
                newTemps[node] = d[node] - c[node] * newTemps[node + 1];
            }
        }

        /// <summary>
        /// Determine min, max, and average soil temperature from the
        /// half-hourly iterations.
        /// RETURNS gAveTsoil(); gMaxTsoil(); gMinTsoil()
        /// </summary>
        /// <param name="IterationsPerDay">number of times in a day the function is called</param>
        /// <remarks></remarks>
        private void doUpdate(int IterationsPerDay, double timeOfDaySecs)
        {

            // Now transfer to old temperature array
            tempNew.CopyTo(soilTemp, 0);

            // initialise the min & max to soil temperature if this is the first iteration
            if (timeOfDaySecs < gDt * 1.2)
            {
                for (int node = SURFACEnode; node <= numNodes; node++)
                {
                    minSoilTemp[node] = soilTemp[node];
                    maxSoilTemp[node] = soilTemp[node];
                }
            }

            for (int node = SURFACEnode; node <= numNodes; node++)
            {
                if (soilTemp[node] < minSoilTemp[node])
                    minSoilTemp[node] = soilTemp[node];
                else if (soilTemp[node] > maxSoilTemp[node])
                    maxSoilTemp[node] = soilTemp[node];
                aveSoilTemp[node] += Divide(soilTemp[node], System.Convert.ToDouble(IterationsPerDay), 0);
            }
            _boundaryLayerConductance += Divide(thermalConductivity[AIRnode], System.Convert.ToDouble(IterationsPerDay), 0);
        }

        /// <summary>
        ///  Interpolate air temperature
        /// </summary>
        /// <param name="timeHours">time of day that air temperature is required</param>
        /// <returns>Interpolated air temperature for specified time of day (oC)</returns>
        /// <remarks>
        /// Notes:
        ///  Between midinight and MinT_time just a linear interpolation between
        ///  yesterday's midnight temperature and today's MinTg. For the rest of
        ///  the day use a sin function.
        /// Note: This can result in the Midnight temperature being lower than the following minimum.
        /// </remarks>
        private double InterpTemp(double timeHours, double tmax, double tmin)
        {
            // using global vars:
            // double MaxT_time
            // double MinTg
            // double MaxTg
            // double MinT_yesterday
            // double MaxT_yesterday

            double time = timeHours / DAYhrs;           // Current time of day as a fraction of a day
            double maxT_time = tmax / DAYhrs;     // Time of maximum temperature as a fraction of a day
            double minT_time = maxT_time - 0.5;       // Time of minimum temperature as a fraction of a day

            if (time < minT_time)
            {
                // Current time of day is between midnight and time of minimum temperature
                double midnightT = Math.Sin((0.0D + 0.25 - maxT_time) * 2.0D * Math.PI)
                                        * (maxTempYesterday - minTempYesterday) / 2.0D
                                        + (maxTempYesterday + minTempYesterday) / 2.0D;
                double tScale = (minT_time - time) / minT_time;

                // set bounds for t_scale (0 <= tScale <= 1)
                if (tScale > 1.0D)
                    tScale = 1.0D;
                else if (tScale < 0)
                    tScale = 0;
                else
                {
                }

                double CurrentTemp = tmin + tScale * (midnightT - tmin);
                return CurrentTemp;
            }
            else
            {
                // Current time of day is at time of minimum temperature or after it up to midnight.
                double CurrentTemp = Math.Sin((time + 0.25 - maxT_time) * 2.0D * Math.PI)
                                          * (tmax - tmin) / 2.0D
                                          + (tmax + tmin) / 2.0D;
                return CurrentTemp;
            }
        }

        #endregion

        #region Utilities

        private double Divide(double val1, double val2, double errVal)
        {
            double returnValue = val1 / val2;
            if (double.IsInfinity(returnValue) || double.IsNaN(returnValue))
                return errVal;
            return returnValue;
        }

        /// <summary>
        /// Zero the specified array.
        /// </summary>
        /// <param name="arr">The array to be zeroed</param>
        static public void Zero(double[] arr)
        {
            if (arr != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = 0;
                }
            }
        }

        /// <summary>
        /// Convert deg Celcius to deg Kelvin
        /// </summary>
        /// <param name="celciusT">(INPUT) Temperature in deg Celcius</param>
        /// <returns>Temperature in deg Kelvin</returns>
        /// <remarks></remarks>
        private double kelvinT(double celciusT)
        {
            const double ZEROTkelvin = 273.18;   // Absolute Temperature (oK)
            return celciusT + ZEROTkelvin; // (deg K)
        }

        private void mapLayer2Node(double[] layerArray, ref double[] nodeArray)
        {
            // now get weighted average for soil elements between the nodes. i.e. map layers to nodes
            for (int node = SURFACEnode; node <= numNodes; node++)
            {
                int layer = node - 1;     // node n lies at the centre of layer n-1
                double depthLayerAbove = 0.0;
                if (layer >= 1)
                {
                    for (int i = 1; i <= layer; i++) depthLayerAbove += thickness[i];
                }
                double d1 = depthLayerAbove - (depth[node] * M2MM);
                double d2 = depth[node + 1] * M2MM - depthLayerAbove;
                double dSum = d1 + d2;

                nodeArray[node] = Divide(layerArray[layer] * d1, dSum, 0) + Divide(layerArray[layer + 1] * d2, dSum, 0);
            }
        }

        /// <summary>
        /// Tests if two real values are practically equal
        /// </summary>
        /// <param name="double1"></param>
        /// <param name="double2"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool RealsAreEqual(double double1, double double2)
        {
            double precision = Math.Min(double1, double2) * 0.0001;
            return (Math.Abs(double1 - double2) <= precision);
        }
        #endregion 
    }
}
