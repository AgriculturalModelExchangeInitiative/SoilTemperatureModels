
#include "STEMP.h"
#include "STEMP_State.h"
#include "STEMP_Rate.h"
#include "STEMP_Exogenous.h"
#include <iostream>

void cal() {
  STEMP_State s;
  STEMP_State s1;
  STEMP_Rate r;
  STEMP_Exogenous ex;
  STEMP_Auxiliary a;
  STEMP st;


}

int main() {
  // Call cal function
  cal();

  return 0;
}

//g++ -c STEMP_Exogenous.cpp -o STEMP_Exogenous.o
// g++ program.cpp STEMP_State.o STEMP_Rate.o STEMP_Exogenous.o STEMP_AUxiliary.o STEMP.o -o myprogram
