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
        vector<double> soilTemperature ;
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
        void setprevDaySoilTemperature(const vector<double>&  _prevDaySoilTemperature);
        vector<double>& getsoilTemperature();
        void setsoilTemperature(const vector<double>&  _soilTemperature);
        vector<double>& getV();
        void setV(const vector<double>&  _V);
        vector<double>& getB();
        void setB(const vector<double>&  _B);
        vector<double>& getvolumeMatrix();
        void setvolumeMatrix(const vector<double>&  _volumeMatrix);
        vector<double>& getvolumeMatrixOld();
        void setvolumeMatrixOld(const vector<double>&  _volumeMatrixOld);
        vector<double>& getmatrixPrimaryDiagonal();
        void setmatrixPrimaryDiagonal(const vector<double>&  _matrixPrimaryDiagonal);
        vector<double>& getmatrixSecondaryDiagonal();
        void setmatrixSecondaryDiagonal(const vector<double>&  _matrixSecondaryDiagonal);
        vector<double>& getheatConductivity();
        void setheatConductivity(const vector<double>&  _heatConductivity);
        vector<double>& getheatConductivityMean();
        void setheatConductivityMean(const vector<double>&  _heatConductivityMean);
        vector<double>& getheatCapacity();
        void setheatCapacity(const vector<double>&  _heatCapacity);
        vector<double>& getsolution();
        void setsolution(const vector<double>&  _solution);
        vector<double>& getmatrixDiagonal();
        void setmatrixDiagonal(const vector<double>&  _matrixDiagonal);
        vector<double>& getmatrixLowerTriangle();
        void setmatrixLowerTriangle(const vector<double>&  _matrixLowerTriangle);
        vector<double>& getheatFlow();
        void setheatFlow(const vector<double>&  _heatFlow);
        double getsoilSurfaceTemperature();
        void setsoilSurfaceTemperature(double _soilSurfaceTemperature);
        double getnoSnowSoilSurfaceTemperature();
        void setnoSnowSoilSurfaceTemperature(double _noSnowSoilSurfaceTemperature);

};
#endif