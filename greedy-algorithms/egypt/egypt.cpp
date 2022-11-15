#include <iostream>

using namespace std;

unsigned int solve(unsigned long int pp, unsigned long int qq)
{
  unsigned long int denominator;
    
  // Намира най-близката дроб с най-малък знаменател	
  cout << "Searching for best match to " << pp << "/" << qq << "\n";  
  denominator = 2;
  
  // qq              pp 
  // ---           > --
  // denominator     1
  
  // denominator    1
  // ----------- <  --
  
  // qq             pp
  
  while (qq > pp*denominator) {
    denominator = denominator + 1;
  }
  return (denominator); // стойността на знаменателя
}

int main()
{
  unsigned long p,q, pCalc, qCalc, d;

  // Вход
  p = 121685; // 2
  q = 859981; // 3

  // Задавам начални стойности
  pCalc = p; 
  qCalc = q;
  
  /*
  d = solve(pCalc, qCalc);
  cout << "1/" << d << "\n";
  return 1;
  * */
  
  while (pCalc > 1) {
  	// Намира_се_максималната_дроб_1/r_ненадвишаваща_p/q;
    d = solve(pCalc, qCalc); 
    cout << "1/" << d << "\n";
    pCalc = pCalc*d - qCalc;
    qCalc = qCalc*d;
  }
}
