using System;
class SumOfNumbers {

  static int Gcd(int a, int b)  
  {
	  Console.WriteLine("a =" + a + ", b = " + b);  
    if (b == 0) {
      return a;
    } else {
	    return Gcd(b, a % b);
      // Пример: 7 % 5 = 2 
      // Пример: 9 % 8 = 1
      // Пример: 100 % 98 = 2
	  } 
  }

  static void Main() {
	int gcd;
	
    // Вход 
    gcd  = Gcd(13600, 23600);
    Console.WriteLine("GCD = " + gcd);  
  }
}
