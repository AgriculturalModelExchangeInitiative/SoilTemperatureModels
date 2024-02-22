

#include "STEMP_EPIC.h"
#include "STEMP_EPIC_State.h"
#include "STEMP_EPIC_Rate.h"
#include "STEMP_EPIC_Exogenous.h"
#include <iostream>

void cal()
{
    STEMP_EPIC_State s;
    STEMP_EPIC_State s1;
    STEMP_EPIC_Rate r;
    STEMP_EPIC_Exogenous ex;
    STEMP_EPIC_Auxiliary a;
    STEMP_EPIC st;



    vector<double> BD(20,1.6);
    vector<double> DLAYR(20, 10.0);
    vector<double> DS = {10.0,  20.0,30.0, 40.0 } ;

    vector<double> DUL(20,0.3) ;
    vector<double> LL(20,0.2) ;
    st.setDUL(DUL);
    st.setDS(DS);
    st.setBD(BD);
    st.setLL(LL);
    st.setNLAYR(4);
    st.setNL(20);
    ex.setTMIN(20.0);

    st.setDLAYR(DLAYR);
    vector<double> SW(5,0.2);
    double TAVG    = 25.0;
    ex.setTAVG(TAVG);
    double TMAX    = 30.0;
    ex.setTMAX(TMAX);
    double TAV     = 20.0;
    ex.setTAV(TAV);
    double TAMP    = 10.0;
    ex.setTAMP(TAMP);
    ex.setMULCHMASS(0.0);
    ex.setSNOW(0.0);
    ex.setRAIN(0.0);
    ex.setDEPIR(0.0);
    st.setSW(SW);
    st.setISWWAT("Y");

    st.Init(s, s1, r, a, ex);
    std::cout <<s.getSRFTEMP()<< std::endl;
    std::cout <<s.getST()[0]<< std::endl;
    std::cout <<s.getST()[1]<< std::endl;
    std::cout <<s.getST()[2]<< std::endl;
    std::cout <<s.getST()[3]<< std::endl;
    st.Calculate_Model(s, s1, r, a, ex);

    // Your implementation of Calculate_Model goes here
    std::cout <<"Calculating model gen..." << std::endl;
    std::cout <<s.getSRFTEMP()<< std::endl;
    std::cout <<s.getST()[0]<< std::endl;
    std::cout <<s.getST()[1]<< std::endl;
    std::cout <<s.getST()[2]<< std::endl;
    std::cout <<s.getST()[3]<< std::endl;
}

int main()
{
    // Call cal function
    cal();

    return 0;
}

//g++ -c STEMP_Exogenous.cpp -o STEMP_Exogenous.o
// g++ program.cpp STEMP_State.o STEMP_Rate.o STEMP_Exogenous.o STEMP_AUxiliary.o STEMP.o -o myprogram
