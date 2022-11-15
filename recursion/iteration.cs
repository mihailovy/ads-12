// Код без рекурсия
using System;
class NonRecursive {
  
  static int Solve(int num, int step, int i) {
    Console.WriteLine("i = "+i);
    if (i < num) {
      Solve(num, step, i+step);
    }
  }
  
  static void Main() {
    int num  = 1000000;
    int step = 1;
    
    Solve(num, step, 1);
  }
}
