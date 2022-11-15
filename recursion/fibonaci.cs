using System;

class Fionaci {

  static int Fibonaci(int n) {
    if (n < 2) {
		  return 1; // Fibonaci(1) = 1, Fibonaci(0) = 1
	  } else {
		  return Fibonaci(n - 1) + Fibonaci(n - 2);
	  }
  } 

  static void Main() {
	  int n, fib;
  	n    = 1024;  
    fib  = Fibonaci(n);
    Console.WriteLine("Fibonaci("+n+")= " + fib);  
  }
}

/*
using System;
class Fionaci { 
	
  static void Main() {
	  int n = 3;
	  int f1, f2;
    
	  f1 = 1;
	  f2 = 1;
	  while (n > 0) {
		  n--;
		  f2 = f1 + f2;
		  f1 = f2 - f1;	
	  }
	  Console.WriteLine("Fibonaci("+n+")= " + f2);
  }
}
*/
