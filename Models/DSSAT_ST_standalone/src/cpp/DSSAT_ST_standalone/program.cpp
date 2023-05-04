
#include "STEMP.h"
#include "STEMP_State.h"
#include "STEMP_Rate.h"
#include "STEMP_Exogenous.h"
#include "STEMP_Auxiliary.h"
#include <iostream>

void cal() {
  STEMP_State s;
  STEMP_State s1;
  STEMP_Rate r;
  STEMP_Exogenous ex;
  STEMP_Auxiliary a;
  STEMP st;

  double CUMDPT ;
  double HDAY ;
  double TDL ;


  int NL = 20;

    string ISWWAT = "Y";
    st.setISWWAT(ISWWAT);

  vector<double> ST(NL) ;
  s.setST(ST);


  vector<double> BD(NL,1.6);
  st.setBD(BD);
  vector<double> DLAYR(NL, 10.0);
  st.setDLAYR(DLAYR);
  vector<double> DS(NL, 0.0);
  DS[0] = 10.0;
  DS[1] = 20.0;
  DS[2] = 30.0;
  DS[3] = 40.0 ;
  st.setDS(DS);
 std::cout <<st.getDS()[0]<< std::endl;
  std::cout <<st.getDS()[1]<< std::endl;
   std::cout <<st.getDS()[2]<< std::endl;
    std::cout <<st.getDS()[3]<< std::endl;
    std::cout <<st.getDS()[4]<< std::endl;

  vector<double> DUL(NL,0.3) ;
  st.setDUL(DUL);
  vector<double> LL(NL,0.2) ;
  st.setLL(LL);
  int NLAYR = 4 ;
  st.setNLAYR(NLAYR);
  double MSALB = 0.13;
  st.setMSALB(MSALB);
  double SRAD    = 20.0 ;
  ex.setSRAD(SRAD);
  vector<double> SW(5,0.2);
  st.setSW(SW);
  double TAVG    = 25.0;
  ex.setTAVG(TAVG);
  double TMAX    = 30.0;
  ex.setTMAX(TMAX);
  double XLAT    = 28.0;
  st.setXLAT(XLAT);
  double TAV     = 20.0;
  ex.setTAV(TAV);
  double TAMP    = 10.0;
  ex.setTAMP(TAMP);
  ex.setDOY(100);

  st.setNL(NL);

 std::cout <<"Calculating model Init..." << std::endl;
 st.Init(s, s1, r, a, ex);
 st.Calculate_Model(s, s1, r, a, ex);

  // Your implementation of Calculate_Model goes here
  std::cout <<"Calculating model ST..." << std::endl;

  std::cout <<s.getSRFTEMP()<< std::endl;
  std::cout <<s.getST()[0]<< std::endl;
  std::cout <<s.getST()[1]<< std::endl;
  std::cout <<s.getST()[2]<< std::endl;
  std::cout <<s.getST()[3]<< std::endl;

std::cout <<"Calculating model ST2..." << std::endl;
  st.Calculate_Model(s, s1, r, a, ex);
  std::cout <<s.getSRFTEMP()<< std::endl;
  std::cout <<s.getST()[0]<< std::endl;
  std::cout <<s.getST()[1]<< std::endl;
  std::cout <<s.getST()[2]<< std::endl;
  std::cout <<s.getST()[3]<< std::endl;

  std::cout <<"Calculating model ST2..." << std::endl;
  st.Calculate_Model(s, s1, r, a, ex);
  std::cout <<s.getSRFTEMP()<< std::endl;
  std::cout <<s.getST()[0]<< std::endl;
  std::cout <<s.getST()[1]<< std::endl;
  std::cout <<s.getST()[2]<< std::endl;
  std::cout <<s.getST()[3]<< std::endl;
  //std::cout <<"Calculating model cumdt..." << std::endl;
  //std::cout <<s.getCUMDPT()<< std::endl;
}

int main() {
  // Call cal function
  cal();

  return 0;
}

//g++ -c STEMP_Exogenous.cpp -o STEMP_Exogenous.o
// g++ program.cpp STEMP_State.o STEMP_Rate.o STEMP_Exogenous.o STEMP_AUxiliary.o STEMP.o -o myprogram
