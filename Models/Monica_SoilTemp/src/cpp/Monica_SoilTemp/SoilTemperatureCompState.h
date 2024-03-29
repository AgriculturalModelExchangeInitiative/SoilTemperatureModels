#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace Monica_SoilTemp {
class SoilTemperatureCompState
{
    private:
        std::vector<double> V ;
        std::vector<double> B ;
        std::vector<double> volumeMatrix ;
        std::vector<double> volumeMatrixOld ;
        std::vector<double> matrixPrimaryDiagonal ;
        std::vector<double> matrixSecondaryDiagonal ;
        std::vector<double> heatConductivity ;
        std::vector<double> heatConductivityMean ;
        std::vector<double> heatCapacity ;
        std::vector<double> solution ;
        std::vector<double> matrixDiagonal ;
        std::vector<double> matrixLowerTriangle ;
        std::vector<double> heatFlow ;
        double soilSurfaceTemperature ;
        std::vector<double> soilTemperature ;
        double noSnowSoilSurfaceTemperature ;
    public:
        SoilTemperatureCompState();
        std::vector<double> & getV();
        void setV(const std::vector<double> &  _V);
        std::vector<double> & getB();
        void setB(const std::vector<double> &  _B);
        std::vector<double> & getvolumeMatrix();
        void setvolumeMatrix(const std::vector<double> &  _volumeMatrix);
        std::vector<double> & getvolumeMatrixOld();
        void setvolumeMatrixOld(const std::vector<double> &  _volumeMatrixOld);
        std::vector<double> & getmatrixPrimaryDiagonal();
        void setmatrixPrimaryDiagonal(const std::vector<double> &  _matrixPrimaryDiagonal);
        std::vector<double> & getmatrixSecondaryDiagonal();
        void setmatrixSecondaryDiagonal(const std::vector<double> &  _matrixSecondaryDiagonal);
        std::vector<double> & getheatConductivity();
        void setheatConductivity(const std::vector<double> &  _heatConductivity);
        std::vector<double> & getheatConductivityMean();
        void setheatConductivityMean(const std::vector<double> &  _heatConductivityMean);
        std::vector<double> & getheatCapacity();
        void setheatCapacity(const std::vector<double> &  _heatCapacity);
        std::vector<double> & getsolution();
        void setsolution(const std::vector<double> &  _solution);
        std::vector<double> & getmatrixDiagonal();
        void setmatrixDiagonal(const std::vector<double> &  _matrixDiagonal);
        std::vector<double> & getmatrixLowerTriangle();
        void setmatrixLowerTriangle(const std::vector<double> &  _matrixLowerTriangle);
        std::vector<double> & getheatFlow();
        void setheatFlow(const std::vector<double> &  _heatFlow);
        double getsoilSurfaceTemperature();
        void setsoilSurfaceTemperature(double _soilSurfaceTemperature);
        std::vector<double> & getsoilTemperature();
        void setsoilTemperature(const std::vector<double> &  _soilTemperature);
        double getnoSnowSoilSurfaceTemperature();
        void setnoSnowSoilSurfaceTemperature(double _noSnowSoilSurfaceTemperature);

};
}
