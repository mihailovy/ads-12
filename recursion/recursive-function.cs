using System;
class Recursive {

  static void Solve(int i, int num, int step)  
  {
    if (i <= num) {
	    Console.WriteLine("i = " + i);
      Solve(i + step, num, step);
    }
  }

  static void Main() {
	  Solve(1, 10, 1);
  }
}

/*
// Код без рекурсия
using System;
class NonRecursive {
  static void Main() {
    
	  for(int i = 1; i <= 10; i++) {
        Console.WriteLine("i = " + i);
    }
      
  }
}
*/
