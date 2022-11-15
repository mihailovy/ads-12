using System;
class Egyptcs {

  static long Solve(long pp, long qq)  
  {
    long denominator;

    // Намира най-близката дроб с най-малък знаменател	
    Console.WriteLine("Търсим дроб най-близка до " + pp + "/" + qq); 
    denominator = 2;
    
    // while(q/denominator > pp/qq)
    while (qq > pp*denominator) {
	  Console.WriteLine("Пробваме дали 1/" + denominator + " < "+pp+"/" + qq);
	  denominator = denominator + 1;
    }
    return (denominator); // стойността на знаменателя
    
/*
  1    pp
  - <  --       / * d
  d    qq 
  
       pp * d 
  1 < --------  / * qq
       qq
       
  qq < pp * d
*/   

  }

  static void Main() {
    long p,q, pCalc, qCalc, d;

    // Вход 3/13
    p = 3; 
    q = 13;

    // d = Solve(p, q);
    // Console.WriteLine("1/" + d);
    // System.Environment.Exit(0);

    // Задавам начални стойности
    pCalc = p; 
    qCalc = q;
  
    while (pCalc > 1) {
      d = Solve(pCalc, qCalc); // Намира се максималната дроб 1/r ненадвишаваща p/q;
      Console.WriteLine("1/" + d);
      
      pCalc = pCalc*d - qCalc;
      qCalc = qCalc*d;
      
    }
  }
}
