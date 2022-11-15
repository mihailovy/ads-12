using System;
class Egyptcs {

  static long Solve(long pp, long qq)  
  {
	  long denominator;
	
	  // Намира най-близката дроб с най-малък знаменател	
	  Console.WriteLine("Търсим дроб най-близка до " + pp + "/" + qq); 
	   
	  denominator = 2;	 
	  while (qq > pp*denominator) {
		denominator = denominator + 1;
	  }
	  return (denominator); // стойността на знаменателя
  }

  static void Main() {
    long p,q, d;

    // Input
    p = 3; // 2
    q = 7; // 3

    d = Solve(p, q); // Намира се максималната дроб 1/r ненадвишаваща p/q;
    Console.WriteLine("1/" + d);
  }   
}
