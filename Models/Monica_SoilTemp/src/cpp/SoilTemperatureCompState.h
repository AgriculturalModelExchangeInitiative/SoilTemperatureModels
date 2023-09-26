#ifndef _SoilTemperatureCompState_
#define _SoilTemperatureCompState_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class SoilTemperatureCompState
{
    private:
        double soilCoverage ;
        double prevDaySoilSurfaceTemperature ;
        double soilSurfaceTemperatureBelowSnow ;
        bool hasSnowCover ;
        vector<double> prevDaySoilTemperature ;
        vector<double> V ;
        vector<double> B ;
        vector<double> volumeMatrix ;
        vector<double> volumeMatrixOld ;
        vector<double> matrixPrimaryDiagonal ;
        vector<double> matrixSecondaryDiagonal ;
        vector<double> heatConductivity ;
        vector<double> heatConductivityMean ;
        vector<double> heatCapacity ;
        vector<double> solution ;
        vector<double> matrixDiagonal ;
        vector<double> matrixLowerTriangle ;
        vector<double> heatFlow ;
        double soilSurfaceTemperature ;
        vector<double> soilTemperature ;
        double noSnowSoilSurfaceTemperature ;
    public:
        SoilTemperatureCompState();
        double getsoilCoverage();
        void setsoilCoverage(double _soilCoverage);
        double getprevDaySoilSurfaceTemperature();
        void setprevDaySoilSurfaceTemperature(double _prevDaySoilSurfaceTemperature);
        double getsoilSurfaceTemperatureBelowSnow();
        void setsoilSurfaceTemperatureBelowSnow(double _soilSurfaceTemperatureBelowSnow);
        bool gethasSnowCover();
        void sethasSnowCover(bool _hasSnowCover);
        vector<double>& getprevDaySoilTemperature();
        void setprevDaySoilTemperature(vector<double> _prevDaySoilTemperature);
        vector<double>& getV();
        void setV(vector<double> _V);
        vector<double>& getB();
        void setB(vector<double> _B);
        vector<double>& getvolumeMatrix();
        void setvolumeMatrix(vector<double> _volumeMatrix);
        vector<double>& getvolumeMatrixOld();
        void setvolumeMatrixOld(vector<double> _volumeMatrixOld);
        vector<double>& getmatrixPrimaryDiagonal();
        void setmatrixPrimaryDiagonal(vector<double> _matrixPrimaryDiagonal);
        vector<double>& getmatrixSecondaryDiagonal();
        void setmatrixSecondaryDiagonal(vector<double> _matrixSecondaryDiagonal);
        vector<double>& getheatConductivity();
        void setheatConductivity(vector<double> _heatConductivity);
        vector<double>& getheatConductivityMean();
        void setheatConductivityMean(vector<double> _heatConductivityMean);
        vector<double>& getheatCapacity();
        void setheatCapacity(vector<double> _heatCapacity);
        vector<double>& getsolution();
        void setsolution(vector<double> _solution);
        vector<double>& getmatrixDiagonal();
        void setmatrixDiagonal(vector<double> _matrixDiagonal);
        vector<double>& getmatrixLowerTriangle();
        void setmatrixLowerTriangle(vector<double> _matrixLowerTriangle);
        vector<double>& getheatFlow();
        void setheatFlow(vector<double> _heatFlow);
        double getsoilSurfaceTemperature();
        void setsoilSurfaceTemperature(double _soilSurfaceTemperature);
        vector<double>& getsoilTemperature();
        void setsoilTemperature(vector<double> _soilTemperature);
        double getnoSnowSoilSurfaceTemperature();
        void setnoSnowSoilSurfaceTemperature(double _noSnowSoilSurfaceTemperature);

};
#endif