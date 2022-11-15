using System;
class Nok {

  static ulong Gcd(ulong a, ulong b)  
  {
	  // Console.WriteLine("a =" + a + ", b = " + b);  
    if (b == 0) {
      return a;
    } else {
      return Gcd(b, a % b);
    } 
  }

  static ulong Lcm(ulong[]  a, ulong  n)
  {
	 ulong b;
	 if (n == 2) {
       return (a[0] * a[1]) / (Gcd(a[0], a[1]));
     } else {
       b = Lcm(a, n - 1);
       Console.WriteLine("LCM(a, n-1)  = " + b);  
       return(a[n - 1] * b) / (Gcd(a[n - 1], b)); 
     }
  }

  static void Main() {
    // Вход
    ulong n = 12; // Брой на числата
    //            0   1  2  3
    ulong[] a = { 10, 10, 10, 9, 10, 9, 10, 10, 9, 10, 10, 2}; // масив с числа 
    //   НОК(10, 8, 5) <->  9 - НОК
    // ( НОК(10, 8) <-> 5  - НОК) <-> 9 - НОК
    //
     
    // Изход
    ulong nok;   // изход (резултат)
    
    nok = Lcm(a, n);
    Console.WriteLine("NOK = " + nok);  
  }
}
