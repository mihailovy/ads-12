// Намиране на сумата на числата от 1 до num
using System;
class Factoriel {

  static ulong Solve(ulong num)  
  {
    // Console.Write(". ");  
    if (num < 2) {
       return 1;
    } else {
       return num * Solve(num - 1);
    } 
  }

  static void Main() {
	ulong num = 50;
    Console.WriteLine("Факториел("+num+") = "  + Solve(num));  
  }
}

/*
 0! = 1
 1! = 1 
 4! = 1 * 2 * 3 * 4
 5! = 1 * 2 * 3 * 4 * 5
    = 5 * 4 * 3 * 2 * 1 
    = 5 * 4!
    = 5 * (4 * 3!)
    = 5 * (4 * (3 * 2!))
 
 factoriel(n) = n * factoriel(n - 1), n >= 1
 
 */
 
